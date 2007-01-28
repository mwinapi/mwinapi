using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NeatKeys.Views
{
    class OptionsViewState : ViewState
    {
        internal override void Paint(PaintEventArgs e)
        {
            Font f = ScaleFont(e.Graphics, vc.Font, vc.Height / 5);
            using (SolidBrush fg = new SolidBrush(vc.ForeColor))
            {
                DrawString(e.Graphics, f, "Opacity: " + vc.Opacity + "%", vc.Width / 2, 40, 0.5f, 0, fg);
                if (vc.ShowHints)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.Width / 2, 20, "Use digits to set opacity.");
                }
            }
        }


        internal override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                DigitPress(e.KeyCode - Keys.D0);
            }
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                DigitPress(e.KeyCode - Keys.NumPad0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                AdjustOpacity(-10);
            }
                        else if (e.KeyCode == Keys.Down)
            {
                AdjustOpacity(10);
            }
            else if (e.KeyCode == Keys.Left)
            {
                AdjustOpacity(-1);
            }
            else if (e.KeyCode == Keys.Right)
            {
                AdjustOpacity(1);
            }
        }

        private void AdjustOpacity(int increment)
        {
            if (vc.Opacity + increment >= 0 && vc.Opacity + increment <= 100)
            {
                vc.Opacity += increment;
                vc.Invalidate();
            }
        }

        internal void DigitPress(int digit)
        {
            if (digit >=1 && digit <= 9)
            {
                vc.Opacity = digit * 10;
            }
            else if (digit == 0)
            {
                vc.Opacity = 100;
            }
            vc.Invalidate();
        }

        internal virtual ViewState BACK
        {
            get
            {
                return ViewState.START;
            }
        }
        internal override void KeyUp( KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Menu)
            {
                vc.NextState = BACK;
            }
        }

        internal override void KeyPress(KeyPressEventArgs e)
        {
        }
    }

    class TileOptionsViewState : OptionsViewState
    {
        internal override ViewState BACK
        {
            get
            {
                return ViewState.TILING;
            }
        }
    }
}
