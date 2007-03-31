using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Audio.Mixer;

namespace VolumeFader
{
    public partial class MainForm : Form
    {
        private Mixer mix = null;
        private DestinationLine dline = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (uint i = 0; i < Mixer.MixerCount; i++)
            {
                using (Mixer m = Mixer.OpenMixer(i))
                {
                    mixers.Items.Add(m.Name);
                }
            }
            mixers.SelectedIndex = -1;
        }

        private void mixers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mixers.SelectedIndex == -1) return;
            if (mix != null) mix.Dispose();
            mix = Mixer.OpenMixer((uint)mixers.SelectedIndex);
            mix.CreateEvents = true;
            destLines.Items.Clear();
            foreach (DestinationLine dl in mix.DestinationLines)
            {
                destLines.Items.Add(dl.Name);
            }
            destLines_SelectedIndexChanged(this, e);
        }

        private List<LineControl> srcLineControls = new List<LineControl>();

        private void destLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (LineControl slc in srcLineControls)
            {
                slc.Parent.Controls.Remove(slc);
            }
            srcLineControls.Clear();
            if (destLines.SelectedIndex == -1)
            {
                destLineControl.Line = null;
                dline = null;
            }
            else
            {
                dline = mix.DestinationLines[destLines.SelectedIndex];
                destLineControl.Line = dline;
                srcLineControlContainer.RowCount = dline.SourceLineCount;
                srcLineControlContainer.RowStyles.Clear();
                int sumHeight = 0;
                for (int i = 0; i < dline.SourceLineCount; i++)
                {
                    LineControl slc = new LineControl();
                    slc.Line = dline.SourceLines[i];
                    srcLineControlContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, slc.PreferredHeight));
                    sumHeight += slc.PreferredHeight;
                    srcLineControlContainer.Controls.Add(slc, 0, i);
                    srcLineControls.Add(slc);
                    slc.Dock = DockStyle.Fill;
                }
                srcLineControlContainer.Height = sumHeight;
            }
        }

        public bool IsLiveUpdate
        {
            get { return live.Checked; }
        }

        private void faceButton_Click(object sender, EventArgs e)
        {
            fadeTimer.Enabled = true;
            fadeButton.Enabled = false;
            live.Enabled = false;
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            bool finished = true;
            int amount = fadeSpeed.Value * 1000;
            if (destLineControl.Fade(amount)) finished = false;
            for (int i = 0; i < srcLineControls.Count; i++)
            {
                if (srcLineControls[i].Fade(amount)) finished = false;
            }
            if (finished)
            {
                fadeTimer.Enabled = false;
                fadeButton.Enabled = true;
                live.Enabled = true;
            }
        }

        private void live_CheckedChanged(object sender, EventArgs e)
        {
            fadeButton.Enabled = !live.Checked;
            fadeLabel.Enabled = !live.Checked;
            fadeSpeed.Enabled = !live.Checked;
        }
    }
}