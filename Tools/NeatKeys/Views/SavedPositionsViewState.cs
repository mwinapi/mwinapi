using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NeatKeys.Views
{
    class SavedPositionsViewState : ViewState
    {

        bool deleteMode;
        public static readonly string TITLES = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        internal override void restart()
        {
            deleteMode = false;

        }
        internal override void Paint(PaintEventArgs e)
        {
            Dictionary<Point, int> labelsUsed = new Dictionary<Point,int>();
            for (int i = 0; i < 36; i++)
            {
                Rectangle? rr = PositionStore.Instance[i];
                if (rr.HasValue)
                {
                    Rectangle r = rr.Value;
                    Point p = r.Location, pp = p;
                    if (labelsUsed.ContainsKey(p))
                    {

                        pp.Offset(labelsUsed[p] * 10, 0);
                        labelsUsed[p]++;
                    }
                    else
                    {
                        labelsUsed[p] = 1;
                    }
                    e.Graphics.DrawRectangle(deleteMode ? Pens.Red : Pens.Black, r);
                    e.Graphics.DrawString("" + TITLES[i], vc.Font, deleteMode ? Brushes.Red : Brushes.Black, pp);
                }
            }
            if (vc.ShowHints)
            {
                if (deleteMode)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 100, 30,
                        "A-Z, 0-9: clear position\n" +
                        "DEL: back to normal mode\n"+
                        "SPACE: clear all positions\n");
                }
                else
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.DisplayWidth - 100, 30,
                        "A-Z, 0-9: save/use position\n" +
                        "DEL: delete mode");
                }
            }
        }

        internal override void KeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
        }

        internal override void KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                HandleKey(e.KeyCode - Keys.NumPad0);
            }
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                HandleKey(e.KeyCode - Keys.A + 10);
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                HandleKey(e.KeyCode - Keys.D0);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                deleteMode = !deleteMode;
                vc.Invalidate();
            }
            else if (e.KeyCode == Keys.Space && deleteMode)
            {
                for (int i = 0; i < 36; i++)
                {
                    PositionStore.Instance[i] = null;
                }
                vc.Invalidate();
            }
        }

        private void HandleKey(int p)
        {
            if (deleteMode)
            {
                PositionStore.Instance[p] = null;
            }
            else if (PositionStore.Instance[p] == null)
            {
                PositionStore.Instance[p] = vc.Adjustment.BaseRect;
            }
            else
            {
                Rectangle r = PositionStore.Instance[p].Value;
                vc.DoResize(0, r.X, r.Y, r.Width, r.Height, true);
            }
            vc.Invalidate();
        }

        internal override void KeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                vc.NextState = ViewState.START;
            }
        }
    }
}
