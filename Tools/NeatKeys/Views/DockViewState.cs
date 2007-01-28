using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace NeatKeys.Views
{
    class DockViewState : ViewState
    {
        internal override void Paint(PaintEventArgs e)
        {
            int width = vc.DisplayWidth;
            int height = vc.DisplayHeight;
            SolidBrush bg = new System.Drawing.SolidBrush(vc.BackColor);
            using (SolidBrush black = new System.Drawing.SolidBrush(vc.ForeColor))
            {
                e.Graphics.DrawRectangle(new Pen(black, 3), 5, 5, width - 10, height - 10);
                Font f = ScaleFont(e.Graphics, vc.Font, height / 4);
                DrawString(e.Graphics, f, "7", 10, 10, 0, 0, black);
                DrawString(e.Graphics, f, "8", width / 2, 10, 0.5f, 0, black);
                DrawString(e.Graphics, f, "9", width - 10, 10, 1, 0, black);
                DrawString(e.Graphics, f, "4", 22, height / 2, 0, 0.5f, black);
                DrawString(e.Graphics, f, "5", width / 2, height / 2, 0.5f, 0.5f, black);
                DrawString(e.Graphics, f, "6", width - 22, height / 2, 1, 0.5f, black);
                DrawString(e.Graphics, f, "1", 10, height - 10, 0, 1, black);
                DrawString(e.Graphics, f, "2", width / 2, height - 10, 0.5f, 1, black);
                DrawString(e.Graphics, f, "3", width - 10, height - 10, 1, 1, black);
                f = ScaleFont(e.Graphics, vc.Font, height / 8);
                DrawString(e.Graphics, f, "Select Alignment Position", width / 2, height / 4, 0.5f, 0, black);
                if (vc.ShowHints)
                {
                    DrawHelpBox(e.Graphics, vc.Font, width / 3, height / 2 + 10,
                        "If you want to position the window only\n"+
                        "and not to resize it, select a corner,\n"+
                        "an edge or the center. The window will be\n"+
                        "aligned at this position of the target\n"+
                        "rectangle. You can as well select a preset\n"+
                        "size first.");
                    DrawHelpBox(e.Graphics, vc.Font, width * 2 / 3, height / 2 + 10,
                        "1-9: Align window\n"+
                        "0: Stretch window (default)\n"+
                        ",: No move/resize\n"+
                        "+: Set size to preset\n"+
                        "*: Multiply size\n"+
                        "/: Divide size\n"
                        );
                }
                string title = vc.Adjustment.Caption;
                if (title == null || title.Length == 0) title = "(no title)";
                SizeF labelSize = e.Graphics.MeasureString(title, vc.Font);
                int rectwidth = ((int)labelSize.Width / 2) * 2 + 50;
                if (rectwidth < 300) rectwidth = 300;
                e.Graphics.FillRectangle(bg, new Rectangle(width / 2 - rectwidth / 2, height / 2 - 70, rectwidth, 40));
                e.Graphics.DrawRectangle(new Pen(black), new Rectangle(width / 2 - rectwidth / 2, height / 2 - 70, rectwidth, 40));
                e.Graphics.DrawString(title, vc.Font, black, width / 2 - labelSize.Width / 2, height / 2 - labelSize.Height / 2 - 50);
            }
            bg.Dispose(); 
        }

        internal override void KeyDown(KeyEventArgs e)
        {
        }
        internal override void KeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    vc.Adjustment.setDock(0);
                    vc.NextState = START;
                    break;
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    vc.Adjustment.setDock(e.KeyChar  - '1' + 1);
                    vc.NextState = START;
                    break;
                case '.':
                case ',':
                    vc.Adjustment.setDock(-1);
                    vc.NextState = START;
                    break;
                case '+':
                    vc.NextState = PRESET_SIZE;
                    break;
                case '*':
                    string factor = InputBox.Show(vc.Form, "Factor:", "1");
                    if (factor != null)
                    {
                        try
                        {
                            vc.Adjustment.multiplySize(int.Parse(factor), 1);
                        }
                        catch { }
                    }
                    break;
                    case '/':
                        string divisor = InputBox.Show(vc.Form, "Divisor:", "1");
                        if (divisor != null)
                        {
                            try
                            {
                                vc.Adjustment.multiplySize(1, int.Parse(divisor));
                            }
                            catch { }
                        }
                        break;
            }
        }
    }
}
