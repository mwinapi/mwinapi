using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShootNotes
{
    public class Note
    {
        private Image screenshot;
        private Image drawing;
        private Color backColor;
        private Color drawColor;
        private int drawSize;
        private int screenX, screenY, width, height;
        //private string text;
        private string title;
        private int dx, dy, ddx, ddy;
        private static int counter = 0;

        public Note(Image screenshot, Rectangle screenPosition, Color backColor)
        {
            this.screenshot = screenshot;
            this.screenX = screenPosition.X;
            this.screenY = screenPosition.Y;
            this.width = screenPosition.Width;
            this.height = screenPosition.Height;
            this.backColor = backColor;
            this.drawColor = Color.Red;
            this.drawSize = 3;
            title = "New Note "+(++counter);
            dx = dy = 0;
        }

        public Image ScreenShot { get { return screenshot; } }
        public int ScreenX { get { return screenX; } set { this.screenX = value; } }
        public int ScreenY { get { return screenY; } set { this.screenY = value; } }
        public int Width { get { return width; } set { this.width = value; } }
        public int Height { get { return height; } set { this.height = value; } }
        public Color BackColor { get { return backColor; } }
        public int Dx { get { return dx; } set { dx = value; } }
        public int Dy { get { return dy; } set { dy = value; } }
        public int Ddx { get { return ddx; } set { ddx = value; } }
        public int Ddy { get { return ddy; } set { ddy = value; } }
        public Image Drawing { get { return drawing; } set { drawing = value; } }

        public Color DrawColor
        {
            get { return drawColor; }
            set { drawColor = value; InvalidatePen(); }
        }

        public int DrawSize
        {
            get { return drawSize; }
            set { drawSize = value; InvalidatePen(); }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public void EnlargeDrawing(int x, int y)
        {
            if (drawing == null)
            {
                drawing = new Bitmap(32, 32);
                ddx = x - 16;
                ddy = y - 16;
            }
            if (x >= ddx + 16 && y >= ddy + 16 &&
                x <= ddx + drawing.Width - 16 &&
                y <= ddx + drawing.Height - 16)
            {
                return;
            }
            int xmin = ddx, ymin = ddy, xmax = ddx + drawing.Width, ymax = ddy + drawing.Height;
            if (xmin > x - 16) xmin = x - 16;
            if (ymin > y - 16) ymin = y - 16;
            if (xmax < x + 16) xmax = x + 16;
            if (ymax < y + 16) ymax = y + 16;
            Image oldDrawing = drawing;
            drawing = new Bitmap(xmax - xmin, ymax - ymin);
            Graphics g = Graphics.FromImage(drawing);
            g.DrawImage(oldDrawing, ddx - xmin, ddy - ymin);
            g.Dispose();
            ddx = xmin;
            ddy = ymin;
        }

        internal Graphics GetDrawingGraphics()
        {
            Graphics g = Graphics.FromImage(drawing);
            g.TranslateTransform(-ddx, -ddy);
            return g;
        }

        private Pen drawPen;

        private void InvalidatePen()
        {
            if (drawPen != null)
            {
                drawPen.Dispose();
                drawPen = null; ;
            }
        }

        public Pen DrawPen
        {
            get
            {
                if (drawPen == null)
                {
                    drawPen = new Pen(drawColor, drawSize);
                    drawPen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
                }
                return drawPen;
            }
        }
    }
}
