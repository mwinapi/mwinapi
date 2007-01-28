using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NeatKeys.Views;

namespace NeatKeys
{
    public partial class MouseForm : Form
    {
        ViewContainer vc;
        int posx = -1, posy = -1, basex = -1, basey = -1, adj = -1, siz = -1;
        bool wlock = false, hlock = false;
        string customLabel = "(Custom)";

        private static readonly int[,] SIZES = {
            {0,6}, {0,6}, {0,4}, {0,6}, {0,8}, {0,12},
            {4,8},
            {0,12}, {4,12}, {6,12}, {8, 12}, {6, 12}, {6, 12}
        };

        public MouseForm(ViewContainer vc) 
        {
            this.vc = vc;
            InitializeComponent();
            Left = MousePosition.X;
            Top = MousePosition.Y;
            if (Right > Screen.FromPoint(MousePosition).WorkingArea.Right)
            {
                Left = MousePosition.X- Width;
            }
            if (Bottom > Screen.FromPoint(MousePosition).WorkingArea.Bottom)
            {
                Top = MousePosition.Y-Height;
            }
            ToolTip.SetToolTip(position, "Left click = Select position on screen\nLeft drag = Drag custom size\nRight click = Maximize");
            ToolTip.SetToolTip(anchor, "Left click = Change anchor\nRight click = Stretch");
            ToolTip.SetToolTip(screens, "Left click = Select screen\nRight click = Original size on selected screen");
            ToolTip.SetToolTip(sizes, "Left click = Select size\nRight click = Use original size");
            ToolTip.SetToolTip(button1, "Close");
            Show();
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void position_Paint(object sender, PaintEventArgs e)
        {
            int distance = shiftPressed ? 6 : 1;
            for (int i = 0; i <= 12; i+=distance)
            {
                for (int j = 0; j <= 12; j+=distance)
                {
                    e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(i * 20 - 1, j * 15 - 1, 3, 3));
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(i * 20 - 2, j * 15 - 2, 5, 5));
                    }
                }
            }
            if (posx >= 0 && posx <= 12 && posy >= 0 && posy <= 12)
            {
                int x1, x2, y1, y2;
                makeRect(out x1, out x2, out y1, out y2);
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x1 * 20, y1 * 15, (x2-x1)*20, (y2-y1)*15));
            }
        }

        private void MouseForm_Load(object sender, EventArgs e)
        {

        }

        private void position_Click(object sender, EventArgs e)
        {

        }

        private void position_MouseMove(object sender, MouseEventArgs e)
        {
            posx = (e.X + 10) / 20;
            posy = (e.Y + 7) / 15;
            position.Invalidate();
        }

        private void position_MouseLeave(object sender, EventArgs e)
        {
            posx = posy = -1;
            position.Invalidate();
        }

        private void position_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                vc.DoResize(1, 0, 0, 1, 1, true);
                Dispose();
                return;
            }
            else if (posx >= 0 && posx <= 12 && posy >= 0 && posy <= 12)
            {
                basex = posx;
                basey = posy;
            }
            else
            {
                basex = basey = -1;
            }
            position.Invalidate();
        }

        private void position_MouseUp(object sender, MouseEventArgs e)
        {
            if (basex != -1 && posx >= 0 && posx <= 12 && posy >= 0 && posy <= 12)
            {
                int x1, y1, x2, y2;
                makeRect(out x1, out x2, out y1, out y2);
                vc.DoResize(12, x1, y1, x2 - x1, y2 - y1, true);
                Dispose();
            }
            else
            {
                basex = basey = -1;
                position.Invalidate();
            }
        }

        private void makeRect(out int x1, out int x2, out int y1, out int y2)
        {
            x2 = posx;
            y2 = posy;
            if (basex == -1)
            {
                x1 = posx;
                y1 = posy;
            }
            else
            {
                x1 = basex;
                y1 = basey;
            }
            if (shiftPressed)
            {
                x1 = (x1 + 3) / 6 * 6;
                x2 = (x2 + 3) / 6 * 6;
                y1 = (y1 + 3) / 6 * 6;
                y2 = (y2 + 3) / 6 * 6;
            }
            if (x1 > x2)
            {
                int tmp = x1;
                x1 = x2;
                x2 = tmp;
            }
            if (y1 > y2)
            {
                int tmp = y1;
                y1 = y2;
                y2 = tmp;
            }
            if (x1 == x2)
            {
                if (shiftPressed && x2 == 6) x2 = 5;
                x1 = SIZES[x2,0];
                x2 = SIZES[x2,1];
            }
            if (y1 == y2)
            {
                if (shiftPressed && y2 == 6) y2 = 5;
                y1 = SIZES[y2,0];
                y2 = SIZES[y2,1];
            }
            if (x2 <= x1 || y2 <= y1) throw new Exception();
        }

        private void anchor_Paint(object sender, PaintEventArgs e)
        {
            if (adj == -1)
            {
                e.Graphics.FillRectangle(Brushes.Black, 0, 0, 30, 30);
            }
            else
            {
                int x = adj % 3;
                int y = adj / 3;
                e.Graphics.FillRectangle(Brushes.Black, x * 10, y * 10, 10, 10);
            }
        }

        private void anchor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X / 10;
                int y = e.Y / 10;
                adj = y * 3 + x;
                vc.Adjustment.setDock((2 - y) * 3 + x + 1);
            }
            else
            {
                adj = -1;
                vc.Adjustment.setDock(0);
                siz = -1;
                vc.Adjustment.setSize(-1, -1);
                sizes.Invalidate();
            }
            anchor.Invalidate();
            resetlocks();
        }

        private void sizes_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < PresetSizeViewState.sizeTable.GetLength(0); i++)
            {
                string label =
                    PresetSizeViewState.sizeTable[i, 0] + "x" +
                    PresetSizeViewState.sizeTable[i, 1];
                if (label == "0x0")
                {
                    label = customLabel;
                }
                if (siz == i)
                {
                    e.Graphics.FillRectangle(Brushes.Black, 0, i * 18, 60, 18);
                    e.Graphics.DrawString(label, this.Font, Brushes.White,
                        2, i * 18 + 2, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Black, 0, i * 18, 60, 18);
                    e.Graphics.DrawString(label, this.Font, Brushes.Black,
                        2, i * 18 + 2, StringFormat.GenericDefault);
                }
            }
        }

        private void sizes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int siz = e.Y / 18;
                int ww, hh;
                if (siz == 0)
                {
                    string w = InputBox.Show(this, "Width:", "" + vc.Adjustment.BaseRect.Width);
                    if (w == null) return;
                    ww = int.Parse(w);
                    if (ww < 0) return;
                    string h = InputBox.Show(this, "Height:", "" + vc.Adjustment.BaseRect.Height);
                    if (h == null) return;
                    hh = int.Parse(h);
                    if (hh < 0) return;
                    customLabel = "("+ww + "*" + hh+")";
                }
                else
                {
                    ww = PresetSizeViewState.sizeTable[siz,0];
                    hh = PresetSizeViewState.sizeTable[siz,1];
                }
                this.siz = siz;
                vc.Adjustment.setSize(ww, hh);
                if (adj == -1)
                {
                    adj = 4;
                    vc.Adjustment.setDock(5);
                    resetlocks();
                    anchor.Invalidate();
                }
            }
            else
            {
                siz = -1;
                vc.Adjustment.setSize(-1, -1);
            }
            sizes.Invalidate();
        }

        private void resetlocks()
        {
            wlock = hlock = false;
            lockwidth.Invalidate();
            lockheight.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ToolTip.Active = checkBox1.Checked;
            AlwaysToolTip.Active = !checkBox1.Checked;
        }

        private void screens_Paint(object sender, PaintEventArgs e)
        {
            Font f = new Font(this.Font.FontFamily, 16.0f) ;
            for (int i = 0; i < vc.ScreenCount; i++)
            {
                if (i == vc.CurrentScreen)
                {
                    e.Graphics.FillRectangle(Brushes.Black, i * 40, 0, 40, 40);
                    e.Graphics.DrawString("" + (i + 1), f, Brushes.White, i * 40 + 10, 8, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Black, i * 40, 0, 40, 40);
                    e.Graphics.DrawString("" + (i + 1), f, Brushes.Black, i * 40 + 10, 8, StringFormat.GenericDefault);
                }
            }
        }

        private void screens_MouseDown(object sender, MouseEventArgs e)
        {
            int screen = e.X / 40;
            if (screen >= vc.ScreenCount) return;
            if (e.Button == MouseButtons.Left)
            {
                vc.CurrentScreen = screen;
                screens.Invalidate();
            }
            else
            {
                vc.CurrentScreen = screen;
                vc.DoResize(-1, -1, -1, -1, -1, true);
                Dispose();
            }
        }

        private void lockwidth_Paint(object sender, PaintEventArgs e)
        {
            if (wlock)
                e.Graphics.FillRectangle(Brushes.Red, 0, 0, 40, 40);
        }

        private void lockheight_Paint(object sender, PaintEventArgs e)
        {
            if (hlock)
                e.Graphics.FillRectangle(Brushes.Red, 0, 0, 40, 40);
        }

        private void lockwidth_MouseDown(object sender, MouseEventArgs e)
        {
            wlock = true;
            vc.Adjustment.LockWidth();
            lockwidth.Invalidate();
            if (e.Button != MouseButtons.Left)
            {
                vc.DoResize(1, 0, 0, 1, 1, true);
                Dispose();
            }
        }

        private void lockheight_MouseDown(object sender, MouseEventArgs e)
        {
            hlock = true;
            vc.Adjustment.LockHeight();
            lockheight.Invalidate();
            if (e.Button != MouseButtons.Left)
            {
                vc.DoResize(1, 0, 0, 1, 1, true);
                Dispose();
            }
        }

        bool shiftPressed = false;
        private void MouseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                shiftPressed = true;
                position.Invalidate();
            }
        }

        private void MouseForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
            {
                shiftPressed = false;
                position.Invalidate();
            }
        }

        private void drawMode_Click(object sender, EventArgs e)
        {
            Dispose();
            new DrawForm(vc);
        }
    }
}