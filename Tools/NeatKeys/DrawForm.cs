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
    public partial class DrawForm : Form
    {

        private static DrawForm activeForm;

        private ViewContainer vc;
        private List<int> splitsX = new List<int>();
        private List<int> splitsY = new List<int>();
        private int mouseX=-1, mouseY, downX, downY;
        private bool shift, ctrl;
        private int gridMinX, gridMaxX, gridMinY, gridMaxY;
        private Rectangle acceptRect;
        MouseButtons mouseDown = MouseButtons.None;

        public DrawForm(ViewContainer vc)
        {
            this.vc = vc;
            activeForm = this;
            InitializeComponent();
            splitsX.Add(vc.Adjustment.BaseRect.X);
            splitsX.Add(vc.Adjustment.BaseRect.X + vc.Adjustment.BaseRect.Width);
            splitsY.Add(vc.Adjustment.BaseRect.Y);
            splitsY.Add(vc.Adjustment.BaseRect.Y+vc.Adjustment.BaseRect.Height);
            placeOnScreen();
            Show();
        }

        internal static bool Reactivate()
        {
            if (activeForm != null)
            {
                activeForm.Show();
                return true;
            }
            return false;
        }

        private void DrawForm_Load(object sender, EventArgs e)
        {
            
        }

        private void placeOnScreen()
        {
            Rectangle r = Screen.AllScreens[vc.CurrentScreen].WorkingArea;
            this.Top = r.Top;
            this.Width = r.Width;
            this.Height = r.Height;
            this.Left = r.Left;
        }

        private void DrawForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            quit();
        }

        private void quit()
        {
            if (splitsX.Count == 0 && splitsY.Count == 0)
            {
                activeForm = null;
                Dispose();
            }
            else
            {
                mouseDown = MouseButtons.None;
                Hide();
            }
        }

        bool allLinesRed = false;

        private void DrawForm_Paint(object sender, PaintEventArgs e)
        {
            int xmin = 0, ymin = 0, xmax = Width-1, ymax = Height-1;
            int xminf = xmin, yminf = ymin, xmaxf = xmax, ymaxf = ymax;
            bool rightButton = (mouseDown != MouseButtons.None && mouseDown != MouseButtons.Left);
            bool found = false;
            foreach (int x in splitsX)
            {
                if (x >= mouseX && x < xmax) { xmax = x; }
                if (x <= mouseX && x > xmin) { xmin = x+1; }
                if (x >= mouseX && x >= downX && x < xmaxf) { xmaxf = x; }
                if (x <= mouseX && x <= downX && x > xminf) { xminf = x + 1; }
                if (rightButton && (allLinesRed || (x >= Math.Min(mouseX, downX)  && x <=Math.Max(mouseX, downX) ))) {
                    e.Graphics.DrawLine(Pens.Red, x, 0, x,Height);
                    found = true;
                } else {
                e.Graphics.DrawLine(Pens.Black, x, 0, x, Height);
                }
            }
            foreach (int y in splitsY)
            {
                if (y >= mouseY && y < ymax) { ymax = y; }
                if (y <= mouseY && y > ymin) { ymin = y+1; }
                if (y >= mouseY && y >= downY && y < ymaxf) { ymaxf = y; }
                if (y <= mouseY && y <= downY && y > yminf) { yminf = y + 1; }
                if (rightButton && (allLinesRed || y >= Math.Min(mouseY, downY) && y <= Math.Max(mouseY, downY)))
                {
                    e.Graphics.DrawLine(Pens.Red, 0, y, Width, y);
                    found = true;
                }
                else
                {
                    e.Graphics.DrawLine(Pens.Black, 0, y, Width, y);
                }
            }
            if (rightButton && !found && !allLinesRed) {
                allLinesRed = true;
                DrawForm_Paint(sender, e);
                allLinesRed = false;
                return;
            }
            if (mouseX == -1) return;
            if (mouseDown == MouseButtons.None)
            {
                e.Graphics.FillRectangle(Brushes.DarkGray, xmin, ymin, xmax - xmin, ymax - ymin);
                e.Graphics.DrawLine(Pens.White, mouseX - 5, mouseY, mouseX + 5, mouseY);
                e.Graphics.DrawLine(Pens.White, mouseX, mouseY-5, mouseX, mouseY+5);
                if (ctrl && shift && gridMaxX > gridMinX && gridMaxY > gridMinY)
                {
                    int gridWidth = Math.Min(gridMaxX - mouseX, mouseX - gridMinX);
                    int gridHeight = Math.Min(gridMaxY - mouseY, mouseY - gridMinY);
                    for (int xx = gridMinX + gridWidth; xx < gridMaxX - 7; xx += gridWidth)
                    {
                        for (int yy = gridMinY + gridHeight; yy < gridMaxY - 7; yy += gridHeight)
                        {
                            e.Graphics.DrawLine(Pens.White, xx - 5, yy, xx + 5, yy);
                            e.Graphics.DrawLine(Pens.White, xx, yy - 5, xx, yy + 5);
                        }
                    }
                }
            }
            else if (mouseDown == MouseButtons.Left)
            {
                acceptRect = new Rectangle();
                if (xmin == xminf && ymin == yminf && xmax == xmaxf && ymax == ymaxf)
                {
                    // mouse did not cross split line
                    if (Math.Abs(mouseX - downX) > 10 || Math.Abs(mouseY - downY) > 10)
                    {
                        // make new line(s)
                        if (ctrl && shift)
                        {
                            // make multiple lines
                            if (Math.Abs(mouseX - downX) > Math.Abs(mouseY - downY))
                            {
                                int gridHeight = Math.Min(gridMaxY - downY, downY - gridMinY);
                                for (int yy = gridMinY + gridHeight; yy < gridMaxY - 7; yy += gridHeight)
                                {
                                    e.Graphics.DrawLine(Pens.DarkGreen, 0, yy, Width, yy);
                                }
                            }
                            else
                            {
                                int gridWidth = Math.Min(gridMaxX - downX, downX - gridMinX);
                                for (int xx = gridMinX + gridWidth; xx < gridMaxX - 7; xx += gridWidth)
                                {
                                    e.Graphics.DrawLine(Pens.DarkGreen, xx, 0, xx, Height);
                                }
                            }
                        }
                        else
                        {
                            // make single line
                            if (Math.Abs(mouseX - downX) > Math.Abs(mouseY - downY))
                            {
                                e.Graphics.DrawLine(Pens.DarkGreen, 0, downY, Width, downY);
                            }
                            else
                            {
                                e.Graphics.DrawLine(Pens.DarkGreen, downX, 0, downX, Height);
                            }
                        }
                    }
                    else
                    {
                        //accept
                        acceptRect = new Rectangle(xminf, yminf, xmaxf - xminf, ymaxf - yminf);
                    }
                }
                else
                {
                    // mouse crossed split line, so always accept
                    acceptRect = new Rectangle(xminf, yminf, xmaxf - xminf, ymaxf - yminf);
                }
                if (acceptRect.Width != 0)
                {
                    e.Graphics.FillRectangle(Brushes.DarkGray, acceptRect);
                }
                Pen p = new Pen(Color.Red);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawRectangle(p, Math.Min(downX, mouseX), Math.Min(downY, mouseY), Math.Abs(downX - mouseX), Math.Abs(downY - mouseY));
                p.Dispose();
            }
            else
            {
                Pen p = new Pen(Color.DarkGray);
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawRectangle(p, Math.Min(downX, mouseX), Math.Min(downY, mouseY), Math.Abs(downX - mouseX), Math.Abs(downY - mouseY));
                p.Dispose();
            }
        }

        private void DrawForm_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = constrainX(e.X);
            mouseY = constrainY(e.Y);
            Invalidate();
        }

        private int constrainY(int y)
        {
            return constrain(y, Height, splitsY, ref gridMinY, ref gridMaxY);
        }

        private int constrainX(int x)
        {
            return constrain(x, Width, splitsX, ref gridMinX, ref gridMaxX);
        }

        private int constrain(int value, int max, List<int> splits, ref int gridMin, ref int gridMax)
        {
            int leftLimit = 0, rightLimit = max;
            foreach (int split in splits)
            {
                if (split > value && split < rightLimit) rightLimit = split;
                if (split < value && split > leftLimit) leftLimit = split;
            }
            if (ctrl && shift)
            {
                int val = leftLimit + rightLimit / 2;
                for (int i = 3; i < 7; i++)
                {
                    int newval = leftLimit + (rightLimit - leftLimit) / i;
                    if (Math.Abs(val - value) > Math.Abs(newval - value)) val = newval;
                    newval = rightLimit - (rightLimit - leftLimit) / i;
                    if (Math.Abs(val - value) > Math.Abs (newval - value)) val = newval;
                }
                gridMin = leftLimit;
                gridMax = rightLimit;
                return val;
            } else if (shift)
            {
                return ((value *12+ (max / 2)) / max) * max/12;
            }
            else if (ctrl)
            {
                int mmax = rightLimit - leftLimit;
                return (((value-leftLimit) * 12 + (mmax / 2)) / mmax) * mmax / 12 + leftLimit;
            }
            else
            {
                return value;
            }
        }

        private void DrawForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseDown == MouseButtons.None)
            {
                downX = constrainX(e.X);
                downY = constrainY(e.Y);
                mouseDown = e.Button;
                if (e.Button != MouseButtons.Left && splitsX.Count == 0 && splitsY.Count == 0)
                    quit();
            }
            else
            {
                mouseDown = MouseButtons.None;
            }
            Invalidate();
        }

        private void DrawForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDown == MouseButtons.None) return;
            if (mouseDown == MouseButtons.Left)
            {
                if (acceptRect.Width > 0)
                {
                    vc.DoResize(0, acceptRect.X, acceptRect.Y, acceptRect.Width, acceptRect.Height, true);
                    quit();
                    return;
                }
                else if (ctrl && shift) {
                    if (Math.Abs(mouseX - downX) > Math.Abs(mouseY - downY))
                    {
                        int gridHeight = Math.Min(gridMaxY - downY, downY - gridMinY);
                        for (int yy = gridMinY + gridHeight; yy < gridMaxY - 7; yy += gridHeight)
                        {
                            splitsY.Add(yy);
                        }
                    }
                    else
                    {
                        int gridWidth = Math.Min(gridMaxX - downX, downX - gridMinX);
                        for (int xx = gridMinX + gridWidth; xx < gridMaxX - 7; xx += gridWidth)
                        {
                            splitsX.Add(xx);
                        }
                    }
                }
                else
                {
                    if (Math.Abs(mouseX - downX) > Math.Abs(mouseY - downY))
                    {
                        splitsY.Add(downY);
                    }
                    else
                    {
                        splitsX.Add(downX);
                    }
                }
            }
            else
            {
                bool deleted = false;

                for (int i = 0; i < splitsX.Count; i++)
                {
                    int x = splitsX[i];
                    if (x >= Math.Min(downX, mouseX) && x <= Math.Max(downX, mouseX))
                    {
                        deleted = true;
                        splitsX.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < splitsY.Count; i++)
                {
                    int y = splitsY[i];
                    if (y >= Math.Min(downY, mouseY) && y <= Math.Max(downY, mouseY))
                    {
                        deleted = true;
                        splitsY.RemoveAt(i);
                        i--;
                    }
                }
                if (!deleted)
                {
                    splitsX.Clear();
                    splitsY.Clear();
                }
            }
            mouseDown = MouseButtons.None;
            Invalidate();
        }

        private void DrawForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = false;
                Invalidate();
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                shift = false;
                Invalidate();
            }
        }

        private void DrawForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ctrl = true;
                Invalidate();
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                shift = true;
                Invalidate();
            }
        }
    }
}