using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NeatKeys.Views
{
    class StartViewState : ViewState
    {
        internal override void Paint(PaintEventArgs e)
        {
           int width = vc.DisplayWidth;
            int height = vc.DisplayHeight;
            SolidBrush bg = new System.Drawing.SolidBrush(vc.BackColor);
            using (SolidBrush red = new System.Drawing.SolidBrush(Color.Red))
            {
                PaintDot(e, 0, 0, red);
                PaintDot(e, width - 1, 0, red);
                PaintDot(e, 0, height - 1, red);
                PaintDot(e, width - 1, height - 1, red);
            }
            using (SolidBrush black = new System.Drawing.SolidBrush(vc.ForeColor))
            {
                e.Graphics.FillRectangle(black, new Rectangle(0, height / 2 - 1, width, 2));
                e.Graphics.FillRectangle(black, new Rectangle(width / 2 - 1, 0, 2, height));
                using (Pen green = new Pen(new System.Drawing.SolidBrush(Color.Green), 3))
                {
                    e.Graphics.DrawRectangle(green, new Rectangle(16,             16,              width / 2 - 34, height / 2 - 34));
                    e.Graphics.DrawRectangle(green, new Rectangle(width / 2 + 17, 16,              width / 2 - 34, height / 2 - 34));
                    e.Graphics.DrawRectangle(green, new Rectangle(16,             height / 2 + 17, width / 2 - 34, height / 2 - 34));
                    e.Graphics.DrawRectangle(green, new Rectangle(width / 2 + 17, height / 2 + 17, width / 2 - 34, height / 2 - 34));
                }
                using (Pen red = new Pen(new System.Drawing.SolidBrush(Color.Red), 3))
                {
                    e.Graphics.DrawRectangle(red, new Rectangle(10, 10, width / 2 - 18-4, height - 17-4));
                    e.Graphics.DrawRectangle(red, new Rectangle(width/2+11, 10, width / 2 - 18-4, height -17-4));
                }
                using (Pen blue = new Pen(new System.Drawing.SolidBrush(Color.Blue), 3))
                {
                    e.Graphics.DrawRectangle(blue, new Rectangle(4, 4, width  - 9, height / 2 - 10));
                    e.Graphics.DrawRectangle(blue, new Rectangle(4, height / 2 + 5, width -9, height / 2 - 10));
                }
                Font f = ScaleFont(e.Graphics, vc.Font, height / 4);
                printDigit(e.Graphics, f, '7', 22, 22, 0, 0, Color.Green);
                printDigit(e.Graphics, f, '8', width / 2, 22, 0.5f, 0, Color.Blue);
                printDigit(e.Graphics, f, '9', width - 22, 22, 1, 0, Color.Green);
                printDigit(e.Graphics, f, '4', 22, height / 2, 0, 0.5f, Color.Red);
                printDigit(e.Graphics, f, '6', width - 22, height / 2, 1, 0.5f, Color.Red);
                printDigit(e.Graphics, f, '1', 22, height-22, 0, 1, Color.Green);
                printDigit(e.Graphics, f, '2', width / 2, height-22, 0.5f, 1, Color.Blue);
                printDigit(e.Graphics, f, '3', width - 22, height-22, 1, 1, Color.Green);
                if (vc.ShowHints)
                {
                    DrawHelpBox(e.Graphics, vc.Font, width / 2, height / 4,
                        "Type one of the colored digits to resize the current window\n" +
                        "(mentioned in the center) to the size of the surrounding colored box.\n" +
                        "For more options, see the other help boxes on this screen");
                    DrawHelpBox(e.Graphics, vc.Font, width / 3, height / 2 + 10,
                        ",: Keep position; 0: Fullscreen; 5: more sizes\n" +
                        "1-4,6-9: See digits around\n" +
                        "Ctrl: Saved positions; Alt: Display options\n" +
                        "*: Switch screen (if available)\n" +
                        "+: Override Size Change; -: X/Y overrides\n"+
                        "Return: Tiling mode\n"+
                        "Space: Align current; Shift+Space: Align all\n"+
 //                       "A-Z: Create tab/split container [TODO]\n"+
                        ""
                        );
                    DrawHelpBox(e.Graphics, vc.Font, width * 2 / 3, height / 2 + 10,
                        "Global keys:\n" +
                        "ESC: hide window\n"+
                        "F1: Toggle help boxes display\n"+
                        "F2-F9: Select screen (if available)");

                }
                string title = vc.Adjustment.Caption;
                if (title == null || title.Length == 0) title = "(no title)";
                SizeF labelSize = e.Graphics.MeasureString(title, vc.Font);
                int rectwidth = ((int)labelSize.Width / 2) * 2 + 50;
                if (rectwidth < 300) rectwidth = 300;
                e.Graphics.FillRectangle(bg, new Rectangle(width / 2 - rectwidth / 2, height / 2 - 70, rectwidth, 40));
                e.Graphics.DrawRectangle(new Pen(black), new Rectangle(width / 2 - rectwidth / 2, height / 2 - 70, rectwidth, 40));
                e.Graphics.DrawString(title, vc.Font, black, width / 2 - labelSize.Width / 2, height / 2 - labelSize.Height / 2-50);
            }
            bg.Dispose();            
        }

        private void printDigit(Graphics g, Font f, char digit, int x, int y, float xpos, float ypos, Color color)
        {
            using (SolidBrush sb = new SolidBrush(color))
            {
                DrawString(g, f, "" + digit, x, y, xpos, ypos, sb);
            }
        }



        private void PaintDot(PaintEventArgs e, int x, int y, Brush color)
        {
            e.Graphics.FillRectangle(color, new Rectangle(x, y, 1, 1));
        }

        internal override void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Menu:
                    vc.NextState = ViewState.OPTIONS;
                    break;
                case Keys.ControlKey:
                    vc.NextState = ViewState.SAVED_POSITION;
                    break;
                case Keys.Space:
                    vc.DoAlign(e.Shift);
                    break;
            }
        }

        internal override void KeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0': vc.DoResize(1, 0, 0, 1, 1, true); break;
                case '1': vc.DoResize(2, 0, 1, 1, 1, true); break;
                case '2': vc.DoResize(2, 0, 1, 2, 1, true); break;
                case '3': vc.DoResize(2, 1, 1, 1, 1, true); break;
                case '4': vc.DoResize(2, 0, 0, 1, 2, true); break;
                case '6': vc.DoResize(2, 1, 0, 1, 2, true); break;
                case '7': vc.DoResize(2, 0, 0, 1, 1, true); break;
                case '8': vc.DoResize(2, 0, 0, 2, 1, true); break;
                case '9': vc.DoResize(2, 1, 0, 1, 1, true); break;
                case '5':
                    vc.NextState = ViewState.XY_SIZES;
                    break;
                case '*':
                    int cs = vc.CurrentScreen;
                    cs = (cs + 1) % vc.ScreenCount;
                    vc.CurrentScreen = cs;
                    break;
                case ',':
                case '.':
                    vc.DoResize(1, -1, -1, -1, -1, true); break;
                case '+':
                    vc.Adjustment.setDock(5);
                    vc.NextState = ViewState.DOCK;
                    break;
                case '-':
                    vc.Adjustment.switchXY();
                    vc.Adjustment.setDock(5);
                    vc.NextState = ViewState.DOCK;
                    break;
                case '\r':
                    vc.NextState = ViewState.TILING;
                    break;
            }
        }
    }
}
