using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NeatKeys.Views
{
    class PresetSizeViewState : ViewState
    {
        public static readonly int[,] sizeTable = new int[,] {
            {0,0},
            {1024,768},
            {1280,1024},
            {320,240},
            {400,300},
            {512,384},
            {640,480},
            {720,540},
            {800,600},
            {1280,960}};

        internal override void Paint(System.Windows.Forms.PaintEventArgs e)
        {
            Font f = ScaleFont(e.Graphics, vc.Font, vc.Height / 15);
            int height = vc.Height;
            using (Brush red = new SolidBrush(Color.Red), black = new SolidBrush(Color.Black), 
                gray = new SolidBrush(Color.DarkGray), dark = new SolidBrush(Color.DarkRed))
            {
                for (int i = 0; i < 10; i++)
                {
                    string desc = sizeTable[i, 0] + "x" + sizeTable[i, 1];
                    if (i == 0) desc = "0 = Custom Size";
                    int yy = height * i / 10 + height / 20;
                    Brush norm, high;
                    if (sizeTable[i, 0] > vc.Width || sizeTable[i, 1] > vc.Height)
                    {
                        norm = gray; high = dark;
                    }
                    else
                    {
                        norm = black; high = red;
                    }
                    int pos = desc.IndexOf((char)('0' + i));
                    if (pos == -1) throw new Exception();
                    DrawString(e.Graphics, f, desc, 10, yy, 0, 0.5f, norm);
                    DrawString(e.Graphics, f, desc.Substring(0, pos + 1), 10, yy, 0, 0.5f, high);
                    DrawString(e.Graphics, f, desc.Substring(0, pos), 10, yy, 0, 0.5f, norm);
                }
                if (vc.ShowHints)
                {
                    DrawHelpBox(e.Graphics, vc.Font, vc.Width / 2, height / 2,
                        "Use red digits to select size\n"+
                        ",: Reset size to current\n"+
                        "Return: Cancel\n");
                }
            }
        }

        internal override void KeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            switch(e.KeyChar) {
                case '\r':
                    vc.NextState = ViewState.DOCK;
                    break;
                case ',':
                case '.':
                    vc.Adjustment.setSize(-1, -1);
                    vc.NextState = ViewState.DOCK;
                    break;
                case '0':
                    try
                    {
                        string w = InputBox.Show(vc.Form, "Width:", ""+vc.Adjustment.BaseRect.Width);
                        if (w == null) return;
                        int ww = int.Parse(w);
                        if (ww < 0) return;
                        string h = InputBox.Show(vc.Form, "Height:", "" + vc.Adjustment.BaseRect.Height);
                        if (h == null) return;
                        int hh = int.Parse(h);
                        if (hh < 0) return;
                        vc.Adjustment.setSize(ww, hh);
                        vc.NextState = ViewState.DOCK;
                    }
                    catch { }
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
                    int idx = e.KeyChar-'0';
                    vc.Adjustment.setSize(sizeTable[idx, 0], sizeTable[idx, 1]);
                    vc.NextState = ViewState.DOCK;
                    break;
            }
        }
    }
}
