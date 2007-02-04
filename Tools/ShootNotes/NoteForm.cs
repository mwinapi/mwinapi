
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace ShootNotes
{
    public partial class NoteForm : Form
    {

        private enum TextPosition { NONE, RIGHT, BOTTOM }
        private enum DrawingMode { MOVE, FREEHAND, LINE, RECT }

        private DrawingMode drawingMode = DrawingMode.MOVE;
        private TextPosition tp = TextPosition.NONE;
        private Note n;
        private RadioButton[,] PAIR_BUTTONS;
        private MainForm mf;

        public NoteForm(MainForm mf)
        {
            this.mf = mf;
            InitializeComponent();
            PAIR_BUTTONS = new RadioButton[,] {
                {moveMode, moveMode2}, 
                {freehandMode, freehandMode2},
                {lineMode, lineMode2},
                {rectMode, rectMode2}
            };
        }

        public void setNote(Note n, bool tooltip)
        {
            this.n = n;
            mainNote.BackColor = n.BackColor;
            colorBox.BackColor = colorBox2.BackColor = n.DrawColor;
            this.Text = n.Title + " - ShootNote";
            toolWindowToolStripMenuItem.Checked = tooltip;
            this.FormBorderStyle = toolWindowToolStripMenuItem.Checked ? FormBorderStyle.SizableToolWindow : FormBorderStyle.Sizable;
            this.ShowInTaskbar = !toolWindowToolStripMenuItem.Checked;
            this.TopMost = toolWindowToolStripMenuItem.Checked;
            loadPos();
        }

        private void loadPos()
        {
            Rectangle outer = new SystemWindow(this).Rectangle.ToRectangle();
            Rectangle inner = new SystemWindow(mainNote).Rectangle.ToRectangle();
            this.Left = n.ScreenX - inner.X + outer.X;
            this.Top = n.ScreenY - inner.Y + outer.Y;
            this.Width = n.Width - inner.Width + outer.Width;
            this.Height = n.Height - inner.Height + outer.Height;
        }

        private void savePos()
        {
            Rectangle outer = new SystemWindow(this).Rectangle.ToRectangle();
            Rectangle inner = new SystemWindow(mainNote).Rectangle.ToRectangle();
            n.ScreenX = this.Left + inner.X - outer.X;
            n.ScreenY = this.Top + inner.Y - outer.Y;
            n.Width = this.Width + inner.Width - outer.Width;
            n.Height = this.Height + inner.Height - outer.Height;
        }

        private void NoteForm_Load(object sender, EventArgs e)
        {

        }

        private void toolWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolWindowToolStripMenuItem.Checked = !toolWindowToolStripMenuItem.Checked;
            savePos();
            this.FormBorderStyle = toolWindowToolStripMenuItem.Checked ? FormBorderStyle.SizableToolWindow : FormBorderStyle.Sizable;
            this.ShowInTaskbar = !toolWindowToolStripMenuItem.Checked;
            this.TopMost = toolWindowToolStripMenuItem.Checked;
            loadPos();
        }

        private void renameNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String t = InputBox.Show(this, "New name:", n.Title);
            if (t != null)
            {
                n.Title = t;
                Text = n.Title + " - ShootNotes";
            }
        }
        private void rehideText()
        {
            int ow = mainNote.Width;
            int oh = mainNote.Height;
            SuspendLayout();

            mainNote.Parent = this;
            mainNote.Left = splitContainer.Left;
            mainNote.Top = splitContainer.Top;
            mainNote.Height = splitContainer.Height;
            mainNote.Width = splitContainer.Width;
            splitContainer.Visible = false;
            textNote.Visible = false;
            ResumeLayout();

            Width += ow - mainNote.Width;
            Height += oh - mainNote.Height;
            tp = TextPosition.NONE;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tp == TextPosition.RIGHT) return;
            if (tp == TextPosition.BOTTOM) rehideText();
            if (tp != TextPosition.NONE) throw new Exception("Assertion failed!");
            int oldWidth = mainNote.Width;
            this.Width += 100;
            SuspendLayout();
            prepareSplit();
            splitContainer.Orientation = Orientation.Vertical;
            ResumeLayout();
            splitContainer.SplitterDistance = splitContainer.Width - 100;
            splitContainer.SplitterDistance += oldWidth - mainNote.Width;
            tp = TextPosition.RIGHT;
            rightToolStripMenuItem.Checked = true;
            disabledToolStripMenuItem.Checked = false;
            bottomToolStripMenuItem.Checked = false;
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tp == TextPosition.BOTTOM) return;
            if (tp == TextPosition.RIGHT) rehideText();
            if (tp != TextPosition.NONE) throw new Exception("Assertion failed!");
            int oldHeight = mainNote.Height;
            this.Height += 100;
            SuspendLayout();
            prepareSplit();
            splitContainer.Orientation = Orientation.Horizontal;
            ResumeLayout();
            splitContainer.SplitterDistance = splitContainer.Height - 100;
            splitContainer.SplitterDistance += oldHeight - mainNote.Height;
            tp = TextPosition.BOTTOM;
            rightToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = false;
            bottomToolStripMenuItem.Checked = true;
        }

        private void prepareSplit()
        {
            splitContainer.Visible = true;
            textNote.Visible = true;

            splitContainer.Left = mainNote.Left;
            splitContainer.Top = mainNote.Top;
            splitContainer.Width = mainNote.Width;
            splitContainer.Height = mainNote.Height;

            mainNote.Parent = splitContainer.Panel1;
            mainNote.Left = mainNote.Top = 0;
            mainNote.Width = splitContainer.Panel1.Width;
            mainNote.Height = splitContainer.Panel1.Height;

            textNote.Parent = splitContainer.Panel2;
            textNote.Left = textNote.Top = 0;
            textNote.Width = splitContainer.Panel2.Width;
            textNote.Height = splitContainer.Panel2.Height;
        }

        private void disabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tp == TextPosition.NONE) return;
            rehideText();
            rightToolStripMenuItem.Checked = false;
            disabledToolStripMenuItem.Checked = true;
            bottomToolStripMenuItem.Checked = false;
        }

        private void mainNote_Paint(object sender, PaintEventArgs e)
        {
            if (n.ScreenShot != null)
            {
                e.Graphics.DrawImage(n.ScreenShot, new Point(n.Dx, n.Dy));
            }
            if (n.Drawing != null)
            {
                e.Graphics.DrawImage(n.Drawing, new Point(n.Dx + n.Ddx, n.Dy + n.Ddy));
            }
            if (downX != -1 && drawingMode != DrawingMode.MOVE && drawingMode != DrawingMode.FREEHAND)
            {
                drawRectangleOrLine(drawingMode == DrawingMode.LINE, e.Graphics, n.DrawPen, downX, downY, lastX, lastY);
            }
        }

        int downX = -1, downY = -1, lastX, lastY;

        private void mainNote_MouseMove(object sender, MouseEventArgs e)
        {
            if (downX != -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    switch (drawingMode)
                    {
                        case DrawingMode.MOVE:
                            n.Dx += e.X - downX;
                            n.Dy += e.Y - downY;
                            downX = e.X;
                            downY = e.Y;
                            mainNote.Invalidate();
                            break;
                        case DrawingMode.FREEHAND:
                            n.EnlargeDrawing(downX - n.Dx, downY - n.Dy);
                            n.EnlargeDrawing(e.X - n.Dx, e.X - n.Dy);
                            Graphics g = n.GetDrawingGraphics();
                            g.DrawLine(n.DrawPen, downX - n.Dx, downY - n.Dy, e.X - n.Dx, e.Y - n.Dy);
                            g.Dispose();
                            downX = e.X;
                            downY = e.Y;
                            mainNote.Invalidate();
                            break;
                        case DrawingMode.LINE:
                        case DrawingMode.RECT:
                            lastX = e.X;
                            lastY = e.Y;
                            mainNote.Invalidate();
                            break;
                    }
                }
                else
                {
                    if (drawingMode == DrawingMode.RECT)
                    {
                        n.EnlargeDrawing(downX - n.Dx, downY - n.Dy);
                        n.EnlargeDrawing(e.X - n.Dx, e.X - n.Dy);
                        Graphics g = n.GetDrawingGraphics();
                        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), downX - n.Dx - n.DrawSize * 3, downY - n.Dy - n.DrawSize * 3, e.X - downX + n.DrawSize * 6, e.Y - downY + n.DrawSize * 6);
                        g.Dispose();
                        mainNote.Invalidate();
                    }
                    else
                    {
                        n.EnlargeDrawing(e.X - n.Dx, e.Y - n.Dy);
                        Graphics g = n.GetDrawingGraphics();
                        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), e.X - n.Dx - n.DrawSize * 3, e.Y - n.Dy - n.DrawSize * 3, n.DrawSize * 6, n.DrawSize * 6);
                        g.Dispose();
                        mainNote.Invalidate();
                    }
                }
            }
        }

        private void mainNote_MouseDown(object sender, MouseEventArgs e)
        {
            downX = lastX = e.X;
            downY = lastY = e.Y;
        }

        private void mainNote_MouseUp(object sender, MouseEventArgs e)
        {
            mainNote_MouseMove(sender, e);
            if (e.Button == MouseButtons.Left && drawingMode != DrawingMode.MOVE && drawingMode != DrawingMode.FREEHAND)
            {
                n.EnlargeDrawing(downX - n.Dx, downY - n.Dy);
                n.EnlargeDrawing(e.X - n.Dx, e.Y - n.Dy);
                Graphics g = n.GetDrawingGraphics();
                drawRectangleOrLine(drawingMode == DrawingMode.LINE, g, n.DrawPen, downX - n.Dx, downY - n.Dy, e.X - n.Dx, e.Y - n.Dy);
                g.Dispose();
                mainNote.Invalidate();
            }
            downX = downY = -1;
        }

        private void drawRectangleOrLine(bool drawLine, Graphics g, Pen pen, int x1, int y1, int x2, int y2)
        {
            if (drawLine)
            {
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            else
            {
                if (x1 > x2) { int tmp = x1; x1 = x2; x2 = tmp; }
                if (y1 > y2) { int tmp = y1; y1 = y2; y2 = tmp; }
                g.DrawRectangle(pen, x1, y1, x2 - x1, y2 - y1);
            }
        }

        int tbX = -1, tbY = -1;

        private void drawingToolbar_MouseDown(object sender, MouseEventArgs e)
        {
            tbX = e.X; tbY = e.Y;

        }

        private void drawingToolbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (tbX != -1)
            {
                drawingToolbar.Left += e.X - tbX;
                drawingToolbar.Top += e.Y - tbY;
            }
        }

        private void drawingToolbar_MouseUp(object sender, MouseEventArgs e)
        {
            drawingToolbar_MouseMove(sender, e);
            tbX = tbY = -1;
        }

        private void drawingToolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawingToolbar.Visible = !drawingToolbar.Visible;
            drawingToolbarToolStripMenuItem.Checked = drawingToolbar.Visible;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (collapse.Checked)
            {
                drawingToolbar.Height = smallDrawingToolbar.Height;
            }
            else
            {
                drawingToolbar.Height = largeDrawingToolbarMark.Top + largeDrawingToolbarMark.Height;
            }
        }

        bool ignoreModeChange = false;

        private void mode_CheckedChanged(object sender, EventArgs e)
        {
            modeCheckedChanged(0);
        }

        private void modeCheckedChanged(int which)
        {
            if (ignoreModeChange) return;
            try
            {
                ignoreModeChange = true;
                for (int i = 0; i < PAIR_BUTTONS.GetLength(0); i++)
                {
                    if (PAIR_BUTTONS[i, which].Checked)
                    {
                        PAIR_BUTTONS[i, 1 - which].Checked = PAIR_BUTTONS[i, which].Checked;
                        drawingMode = (DrawingMode)i;
                        if (i == 0)
                        {
                            mainNote.ContextMenuStrip = noteContextMenu;
                        }
                        else
                        {
                            mainNote.ContextMenuStrip = null;
                        }
                    }
                }
            }
            finally
            {
                ignoreModeChange = false;
            }
        }

        private void mode2_CheckedChanged(object sender, EventArgs e)
        {
            modeCheckedChanged(1);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            n.Drawing = null;
            mainNote.Invalidate();
        }


        private void colorBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                colorDialog.Color = n.DrawColor;
                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    n.DrawColor = colorDialog.Color;
                    colorBox.BackColor = colorBox2.BackColor = n.DrawColor;
                }
            }
            else
            {
                String ds = InputBox.Show(this, "Draw width", "" + n.DrawSize);
                try
                {
                    if (ds != null)
                    {
                        int s = int.Parse(ds);
                        if (s > 0) n.DrawSize = s;
                    }

                }
                catch { }
            }
        }

        private void NoteForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'n':
                    renameNoteToolStripMenuItem_Click(sender, e);
                    break;
                case 't':
                    toolWindowToolStripMenuItem_Click(sender, e);
                    break;
                case 'd':
                    drawingToolbarToolStripMenuItem_Click(sender, e);
                    break;
                case 'D':
                    if (drawingToolbar.Visible)
                    {
                        checkBox1_CheckedChanged(sender, e);
                    }
                    break;
                case 'o':
                    disabledToolStripMenuItem_Click(sender, e);
                    break;
                case 'r':
                    rightToolStripMenuItem_Click(sender, e);
                    break;
                case 'b':
                    bottomToolStripMenuItem_Click(sender, e);
                    break;
            }
        }

        private void NoteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.AddClosedNote(n);
        }
    }
}