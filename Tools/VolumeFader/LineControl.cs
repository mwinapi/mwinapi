using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Audio.Mixer;

namespace VolumeFader
{
    public partial class LineControl : UserControl
    {
        private MixerLine line;
        private CheckBox[] muteSwitches = new CheckBox[0];
        private VolumePanel[] volumePanels = new VolumePanel[0];
        int channels;

        public int PreferredHeight
        {
            get
            {
                return 21 + 21 * channels + 5;
            }
        }
        public LineControl()
        {
            InitializeComponent();
            AdjustLayout();
        }

        public MixerLine Line
        {
            get { return line; }
            set
            {
                if (line != null)
                {
                    if (line.MuteSwitch != null) line.MuteSwitch.Changed -= line_changed;
                    if (line.VolumeControl != null) line.VolumeControl.Changed -= line_changed;
                }
                line = value;
                if (line != null)
                {
                    if (line.MuteSwitch != null) line.MuteSwitch.Changed += line_changed;
                    if (line.VolumeControl != null) line.VolumeControl.Changed += line_changed;
                }
                AdjustLayout();
            }
        }

        private void line_changed(object source, EventArgs e)
        {
            updateValue();
        }

        private bool noWrite = false;
        private void updateValue()
        {
            if (line == null) return;
            noWrite = true;
            //volume
            if (line.VolumeControl != null)
            {
                int[] values = line.VolumeControl.Values;
                for (int i = 0; i < values.Length; i++)
                {
                    volumePanels[i].ActualVolume = values[i];
                }
            }
            //mute
            if (line.MuteSwitch != null)
            {
                bool[] values = line.MuteSwitch.Values;
                for (int i = 0; i < values.Length; i++)
                {
                    muteSwitches[i].Checked = values[i];
                }
            }
            noWrite = false;
        }

        private void AdjustLayout()
        {
            int volchan = 0, mutechan = 0;
            if (line == null)
            {
                lineName.Text = "No Line Selected";
                channels = 0;
            }
            else
            {
                lineName.Text = line.Name;
                FaderMixerControl vol = line.VolumeControl;
                if (vol != null)
                {
                    volchan = vol.RawValueMultiplicity;
                }
                BooleanMixerControl mute = line.MuteSwitch;
                if (mute != null)
                {
                    mutechan = mute.RawValueMultiplicity;
                }
                channels = volchan > mutechan ? volchan : mutechan;
            }
            mainPanel.RowCount = channels;
            mainPanel.Height = channels * 21;
            mainPanel.RowStyles.Clear();
            for (int i = 0; i < channels; i++)
            {
                mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 21));
            }
            mainPanel.Controls.Clear();
            muteSwitches = new CheckBox[channels];
            volumePanels = new VolumePanel[channels];
            for (int i = 0; i < channels; i++)
            {
                muteSwitches[i] = new CheckBox();
                muteSwitches[i].Dock = DockStyle.Fill;
                muteSwitches[i].CheckedChanged += new System.EventHandler(this.muteSwitchTemplate_CheckedChanged);
                muteSwitches[i].Enabled = i < mutechan;
                mainPanel.Controls.Add(muteSwitches[i], 0, i);
                if (i < volchan)
                {
                    volumePanels[i] = new VolumePanel(this, i);
                    volumePanels[i].BorderStyle = BorderStyle.FixedSingle;
                    volumePanels[i].Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(volumePanels[i], 1, i);
                }
            }
            updateValue();
        }

        private void trackBarTemplate_Scroll(object sender, EventArgs e)
        {
            WriteValue();
        }

        public void WriteValue()
        {
            if (noWrite) return;
            //volume
            if (line.VolumeControl != null)
            {
                int[] values = new int[line.VolumeControl.RawValueMultiplicity];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = volumePanels[i].ActualVolume;
                }
                line.VolumeControl.Values = values;
            }
            //mute
            if (line.MuteSwitch != null)
            {
                bool[] values = new bool[line.MuteSwitch.RawValueMultiplicity];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = muteSwitches[i].Checked;
                }
                line.MuteSwitch.Values = values;
            }
            updateValue();
        }

        private void muteSwitchTemplate_CheckedChanged(object sender, EventArgs e)
        {
            WriteValue();
        }

        private void LineControl_Load(object sender, EventArgs e)
        {

        }

        public bool IsLiveUpdate
        {
            get
            {
                return ((MainForm)ParentForm).IsLiveUpdate;
            }
        }

        internal void UpdateChannels(int target)
        {
            for (int i = 0; i < volumePanels.Length; i++)
            {
                volumePanels[i].UpdateChannel(target);
            }
        }

        internal bool Fade(int amount)
        {
            bool fading = false;
            for (int i = 0; i < volumePanels.Length; i++)
            {
                if (volumePanels[i].Fade(amount)) fading = true;
            }
            if (fading) WriteValue();
            return fading;
        }
    }
}
