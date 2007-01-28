using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NeatKeys
{
    public class RectangleAdjustment
    {

        private enum DockMode { STRETCH, LEFTTOP, CENTER, RIGHTBOTTOM, LOCK }

        private int width = 0, height = 0;
        DockMode dockX, dockY;
        Rectangle baseRect;
        bool yonly;
        string title;

        public Rectangle BaseRect { get { return baseRect; } }

        public void reset(Rectangle reference, string title)
        {
            baseRect = reference;
            width = baseRect.Width;
            height = baseRect.Height;
            dockX = dockY = DockMode.STRETCH;
            yonly = false;
            this.title = title;
        }

        public void switchXY()
        {
            if (yonly)
            {
                reset(baseRect, title);
            }
            else
            {
                yonly = true;
                height = baseRect.Height;
                dockY = DockMode.STRETCH;
            }
        }

        public string Caption
        {
            get
            {
                if (!yonly && dockX == DockMode.STRETCH && dockY == DockMode.STRETCH) {
                    if (title == null || title.Length == 0) 
                        return "(no title)";
                    return title;
                }
                string result = "Action modified: [";
                    switch(dockX) {
                        case DockMode.STRETCH: result +="Stretch"; break;
                        case DockMode.LEFTTOP: result+=width+" Left"; break;
                        case DockMode.CENTER: result +=width+" Center"; break;
                        case DockMode.RIGHTBOTTOM: result +=width+" Right"; break;
                        case DockMode.LOCK: result +="NoModify"; break;
                    }
                if (yonly) result+="[Locked]";
                result +=", ";
                    switch(dockY) {
                        case DockMode.STRETCH: result +="Stretch"; break;
                        case DockMode.LEFTTOP: result+=height+" Top"; break;
                        case DockMode.CENTER: result +=height+" Middle"; break;
                        case DockMode.RIGHTBOTTOM: result +=height+" Bottom"; break;
                        case DockMode.LOCK: result += "NoModify"; break;
                    }
                return result+"]";
            }
        }

        public void multiplySize(int factor, int divisor)
        {
            if (divisor <= 0 || factor < 0) throw new ArgumentException();
            setSize(width * factor / divisor, height * factor / divisor);
        }

        public void setSize(int newWidth, int newHeight)
        {
            if (newWidth == -1) newWidth = baseRect.Width;
            if (newHeight == -1) newHeight = baseRect.Height;
            if (!yonly) width = newWidth;
            height = newHeight;
        }

        // 0 = stretch
        // -1 = lock
        // 1 - 9 = dockpoints
        public void setDock(int dock)
        {
            DockMode dockXold = dockX;
            if (dock == 0)
            {
                dockX = dockY = DockMode.STRETCH;
            }
            else if (dock == -1)
            {
                dockX = dockY = DockMode.LOCK;
            }
            else if (dock >= 1 && dock <= 9)
            {
                int x = (dock - 1) % 3;
                int y = (dock - 1) / 3;
                dockX = DockMode.LEFTTOP + x;
                dockY = DockMode.RIGHTBOTTOM - y;
            }
            else
            {
                throw new ArgumentException();
            }
            if (yonly) dockX = dockXold;
        }

        public Rectangle adjust(Rectangle rect) 
        {
            if (dockX == DockMode.STRETCH && dockY == DockMode.STRETCH) return rect;
            int x = rect.X, w = rect.Width;
            switch (dockX)
            {
                case DockMode.STRETCH: break;
                case DockMode.LOCK:
                    x = baseRect.X; w = baseRect.Width;
                    break;
                case DockMode.LEFTTOP:
                    w = width;
                    break;
                case DockMode.CENTER:
                    x += (w- width) / 2;
                    w = width;
                    break;
                case DockMode.RIGHTBOTTOM:
                    x += w - width;
                    w = width;
                    break;
            }
            int y = rect.Y, h = rect.Height;
            switch (dockY)
            {
                case DockMode.STRETCH: break;
                case DockMode.LOCK:
                    y = baseRect.Y; h = baseRect.Height;
                    break;
                case DockMode.LEFTTOP:
                    h = height;
                    break;
                case DockMode.CENTER:
                    y += (h - height) / 2;
                    h = height;
                    break;
                case DockMode.RIGHTBOTTOM:
                    y += h - height;
                    h = height;
                    break;
            }
            return new Rectangle(x, y, w, h);
        }

        internal void LockWidth()
        {
            dockX = DockMode.LOCK;
        }

        internal void LockHeight()
        {
            dockY = DockMode.LOCK;
        }
    }
}
