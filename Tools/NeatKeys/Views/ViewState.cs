using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace NeatKeys.Views
{
    public abstract class ViewState
    {

        public static readonly ViewState START = new StartViewState();
        public static readonly ViewState OPTIONS = new OptionsViewState();
        public static readonly ViewState DOCK = new DockViewState();
        public static readonly ViewState PRESET_SIZE = new PresetSizeViewState();
        public static readonly ViewState XY_SIZES = new XYSizesViewState();
        public static readonly ViewState SAVED_POSITION = new SavedPositionsViewState();
        public static readonly ViewState TILING = new TilingViewState();
        public static readonly ViewState OPTIONS_TILED = new TileOptionsViewState();


        protected ViewContainer vc;

        internal ViewContainer VC { set { vc = value; } }
        abstract internal void Paint(PaintEventArgs e);

        internal virtual void MouseDown(MouseEventArgs e)
        {
            vc.Hide();
        }

        internal virtual void MouseUp(MouseEventArgs e)
        {
        }

        internal virtual void InternalKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                vc.Hide();
            }
            else if (e.KeyCode == Keys.F1)
            {
                vc.ShowHints = !vc.ShowHints;
            }
            else if (e.KeyCode >= Keys.F2 && e.KeyCode <= Keys.F9)
            {
                int newScreen = e.KeyCode - Keys.F2;
                if (newScreen < vc.ScreenCount)
                {
                    vc.CurrentScreen = newScreen;
                }
            }
            else
            {
                KeyDown(e);
            }
        }

        internal virtual void KeyDown( KeyEventArgs e) { }
        internal virtual void KeyUp(KeyEventArgs e) { }

        internal abstract void KeyPress(KeyPressEventArgs e);



        internal void DrawHelpBox(Graphics g, Font f, int x, int y, string text)
        {
            SizeF size = g.MeasureString(text, f);
            int width = (int)size.Width, height = (int)size.Height;
            x -= (width + 12) / 2;
            g.FillRectangle(SystemBrushes.Info, x, y, width+12, height+12);
            g.DrawRectangle(new Pen(SystemColors.InfoText), x, y, width+12, height+12);
            g.DrawString(text, f, SystemBrushes.InfoText, x + 6, y + 6);
        }

        internal void DrawString(Graphics g, Font f, string text, int x, int y, float xpos, float ypos, Brush brush)
        {
            SizeF size = g.MeasureString(text, f);
            x -= (int)(size.Width * xpos);
            y -= (int)(size.Height * ypos);
            g.DrawString(text, f, brush, x, y);
        }

        internal Font ScaleFont(Graphics g, Font font, int minHeight)
        {
            float size = font.SizeInPoints;
            do
            {
                size++;
            } while (g.MeasureString("9", new Font(font.FontFamily, size)).Height < minHeight);
            return new Font(font.FontFamily, size);
        }

        internal virtual void restart() { }

    }
}
