using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ManagedWinapi.Audio.Mixer;

namespace VolumeFader
{
    class VolumePanel : Panel
    {
        private int actual, target;
        private bool adjustTarget = true, down = false;
        private LineControl lc;
        private int channel;

        public VolumePanel(LineControl lc, int channel)
        {
            this.lc = lc;
            this.channel = channel;
            this.MouseDown += new MouseEventHandler(VolumePanel_MouseDown);
            this.MouseUp += new MouseEventHandler(VolumePanel_MouseUp);
            this.MouseMove += new MouseEventHandler(VolumePanel_MouseMove);
        }

        void VolumePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                target = e.X * 65535 / Width;
                if (target < 0) target = 0;
                if (target > 65535) target = 65535;
                if (lc.IsLiveUpdate)
                {
                    actual = target;
                    lc.WriteValue();
                }
                if (e.Button != MouseButtons.Left)
                {
                    lc.UpdateChannels(target);
                }
                Refresh();
            }
        }

        void VolumePanel_MouseUp(object sender, MouseEventArgs e)
        {
            VolumePanel_MouseMove(sender, e);
            down = false;
        }

        void VolumePanel_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
            VolumePanel_MouseMove(sender, e);
        }

        public int ActualVolume
        {
            get { return actual; }
            set
            {
                actual = value;
                if (adjustTarget)
                {
                    adjustTarget = false;
                    target = value;
                }
                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Blue, 0, 0, Width * actual / 65535, Height / 2);
            e.Graphics.FillRectangle(Brushes.Green, 0, Height / 2, Width * target / 65536, Height / 2);
        }

        internal void UpdateChannel(int newTarget)
        {
            target = newTarget;
            if (lc.IsLiveUpdate)
            {
                actual = target;
                lc.WriteValue();
            }
            Refresh();

        }

        internal bool Fade(int amount)
        {
            if (actual == target) return false;
            if (actual < target)
            {
                if (actual + amount < target) actual += amount;
                else actual = target;
            }
            else
            {
                if (actual - amount > target) actual -= amount;
                else actual = target;
            }
            return true;
        }
    }
}
