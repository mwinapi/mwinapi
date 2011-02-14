using System;
/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2011 Michael Schierl
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; see the file COPYING. if not, visit
 * http://www.gnu.org/licenses/lgpl.html or write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ManagedWinapi.Accessibility;

namespace ManagedWinapi.Windows
{
    /// <summary>
    /// Provides methods to obtain screenshots of different targets.
    /// </summary>
    public static class Screenshot
    {

        /// <summary>
        /// Take a screenshot of the full screen.
        /// </summary>
        /// <param name="includeCursor">Whether to include the mouse cursor.</param>
        public static Bitmap TakeScreenshot(bool includeCursor)
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            foreach (Screen screen in Screen.AllScreens)
                rect = Rectangle.Union(rect, screen.Bounds);
            return TakeScreenshot(rect, includeCursor, null);
        }

        /// <summary>
        /// Take a screenshot of a given window or object.
        /// </summary>
        /// <param name="window">Window to take the screenshot from.</param>
        /// <param name="clientAreaOnly">Whether to include only the client area or also the decoration (title bar).</param>
        /// <param name="includeCursor">Whether to include the mouse cursor.</param>
        /// <param name="keepShape">Whether to keep the shape (transparency region) of the window.</param>
        public static Bitmap TakeScreenshot(SystemWindow window, bool clientAreaOnly, bool includeCursor, bool keepShape)
        {
            Region shape = null;
            if (keepShape)
            {
                shape = window.Region;
                if (shape != null && clientAreaOnly)
                {
                    shape.Translate(window.Rectangle.Left - window.ClientRectangle.Left, window.Rectangle.Top - window.ClientRectangle.Top);
                }
            }
            return TakeScreenshot(clientAreaOnly ? window.ClientRectangle : window.Rectangle, includeCursor, shape);
        }

        /// <summary>
        /// Take a screenshot of a given accessible object
        /// </summary>
        /// <param name="accessibleObject">Accessible object to take the screenshot from.</param>
        /// <param name="includeCursor">Whether to include the mouse cursor.</param>
        /// <param name="keepShape">Whether to keep the shape (transparency region) of the window.</param>
        public static Bitmap TakeScreenshot(SystemAccessibleObject accessibleObject, bool includeCursor, bool keepShape)
        {
            Region shape = null;
            if (keepShape)
            {
                shape = accessibleObject.Window.Region;
                shape.Translate(accessibleObject.Window.Rectangle.Left - accessibleObject.Location.Left, accessibleObject.Window.Rectangle.Top - accessibleObject.Location.Top);
            }
            return TakeScreenshot(accessibleObject.Location, includeCursor, shape);
        }

        /// <summary>
        /// Take a screenshot of an arbitrary rectangle on the screen. Optionally a region
        /// can be used for clipping the rectangle. The mouse cursor, if included,
        /// is not affected by clipping.
        /// </summary>
        /// <param name="rect">Rectangle to include.</param>
        /// <param name="includeCursor">Whether to include the mouse cursor.</param>
        /// <param name="shape">Shape (region) used for clipping.</param>
        public static Bitmap TakeScreenshot(Rectangle rect, bool includeCursor, Region shape)
        {
            Bitmap result = new Bitmap(rect.Width, rect.Height);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
            }
            if (shape != null)
            {
                for (int i = 0; i < result.Width; i++)
                {
                    for (int j = 0; j < result.Height; j++)
                    {
                        if (!shape.IsVisible(new Point(i, j)))
                        {
                            result.SetPixel(i, j, Color.Transparent);
                        }
                    }
                }
            }
            if (includeCursor)
            {
                // Cursors may use XOR operations http://support.microsoft.com/kb/311221
                CURSORINFO ci;
                ci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
                ApiHelper.FailIfZero(GetCursorInfo(out ci));
                if ((ci.flags & CURSOR_SHOWING) != 0)
                {
                    using (Cursor c = new Cursor(ci.hCursor))
                    {
                        Point cursorLocation = new Point(ci.ptScreenPos.X - rect.X - c.HotSpot.X, ci.ptScreenPos.Y - rect.Y - c.HotSpot.Y);
                        // c.Draw() does not work with XOR cursors (like the default text cursor)
                        DrawCursor(ref result, c, cursorLocation);
                    }
                }
            }
            return result;
        }

        private static void DrawCursor(ref Bitmap bitmap, Cursor cursor, Point cursorLocation)
        {
            // http://support.microsoft.com/kb/311221
            // http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/291990e0-fb68-4e0a-ae12-835d43b9275b/

            IntPtr compatibleHDC;
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                IntPtr hDC = g.GetHdc();
                compatibleHDC = CreateCompatibleDC(hDC);
                g.ReleaseHdc();
            }
            IntPtr hBmp = bitmap.GetHbitmap();
            SelectObject(compatibleHDC, hBmp);
            DrawIcon(compatibleHDC, cursorLocation.X, cursorLocation.Y, cursor.Handle);
            bitmap.Dispose();
            bitmap = Image.FromHbitmap(hBmp);
            DeleteObject(hBmp);
        }

        /// <summary>
        /// Take a screenshot of a window which has a larger display area than on screen (i. e. it has scroll bars).
        /// This will send a <code>WM_PRINT</code> or <code>WM_PRINTCLIENT</code> message to the window to try to print it into an
        /// offscreen image. This will be repeated with larger images until a transparent border remains.
        /// This operation will only work with windows that explicitly support it.
        /// </summary>
        /// <param name="window">Window to take the screenshot of</param>
        /// <param name="clientAreaOnly">Whether to send WM_PRINTCLIENT message</param>
        public static Bitmap TakeOverlargeScreenshot(SystemWindow window, bool clientAreaOnly)
        {
            Rectangle position = window.Position;
            int width = position.Width + 1;
            int height = position.Height + 1;
            while (true)
            {
                Bitmap result = TakeOverlargeScreenshot(window, clientAreaOnly, width, height);
                if (result.GetPixel(0, height - 1).A != 0)
                    height *= 2;
                else if (result.GetPixel(width - 1, 0).A != 0)
                    width *= 2;
                else
                    return result;
                if (width * height > 256 * 1048576) // 1 gigabyte!
                    return result;
            }
        }

        /// <summary>
        /// Take a screenshot of a window which has a larger display area than on screen (i. e. it has scroll bars).
        /// This will send a <code>WM_PRINT</code> or <code>WM_PRINTCLIENT</code> message to the window to try to print it into an
        /// offscreen image of the given width and height.
        /// </summary>
        /// <param name="window">Window to take the screenshot of</param>
        /// <param name="clientAreaOnly">Whether to send WM_PRINTCLIENT message</param>
        /// <param name="width">Width of the bitmap</param>
        /// <param name="height">Height of the bitmap</param>
        public static Bitmap TakeOverlargeScreenshot(SystemWindow window, bool clientAreaOnly, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            IntPtr pTarget = g.GetHdc();
            IntPtr pSource = CreateCompatibleDC(pTarget);
            IntPtr pOrig = SelectObject(pSource, bmp.GetHbitmap());
            PrintWindow(window.HWnd, pTarget, clientAreaOnly ? (uint)1 : (uint)0);
            IntPtr pNew = SelectObject(pSource, pOrig);
            DeleteObject(pNew);
            DeleteObject(pSource);
            g.ReleaseHdc(pTarget);
            g.Dispose();
            return bmp;
        }

        /// <summary>
        /// Take a screenshot from a vertically scrolling window. The scrolling can be done either by simulating mouse wheel events,
        /// or by simulating mouse click events on the scrollbar button. The operation stops when scrolling does not result in any 
        /// new content or when the mouse is moved by the user.
        /// </summary>
        /// <param name="scrollPoint">Point inside the window that is inside the scrolling region and that might be used for sending scroll wheel events at</param>
        /// <param name="window">Window to take the screenshot of</param>
        /// <param name="clickPoint">Point above the scrollbar to click, if desired</param>
        public static Bitmap TakeVerticalScrollingScreenshot(Point scrollPoint, SystemWindow window, Point? clickPoint)
        {
            return TakeVerticalScrollingScreenshot(scrollPoint, window.Rectangle, clickPoint);
        }

        /// <summary>
        /// Take a screenshot from a vertically scrolling region. The scrolling can be done either by simulating mouse wheel events,
        /// or by simulating mouse click events on the scrollbar button. The operation stops when scrolling does not result in any 
        /// new content or when the mouse is moved by the user.
        /// </summary>
        /// <param name="scrollPoint">Point inside the window that is inside the scrolling region and that might be used for sending scroll wheel events at</param>
        /// <param name="rect">Rectangle to take the screenshot of</param>
        /// <param name="clickPoint">Point above the scrollbar to click, if desired</param>
        public static Bitmap TakeVerticalScrollingScreenshot(Point scrollPoint, Rectangle rect, Point? clickPoint)
        {
            int scrollCount;
            return TakeScrollingScreenshot(scrollPoint, rect, clickPoint.HasValue ? clickPoint.Value : scrollPoint, clickPoint.HasValue, r => TakeScreenshot(r, false, null), r => HighlightRect(r), out scrollCount);
        }

        /// <summary>
        /// Take a screenshot from a horizontally scrolling window. The scrolling can be done either by simulating mouse wheel events,
        /// or by simulating mouse click events on the scrollbar button. The operation stops when scrolling does not result in any 
        /// new content or when the mouse is moved by the user.
        /// </summary>
        /// <param name="scrollPoint">Point inside the window that is inside the scrolling region and that might be used for sending scroll wheel events at</param>
        /// <param name="window">Window to take the screenshot of</param>
        /// <param name="clickPoint">Point above the scrollbar to click, if desired</param>
        /// <returns></returns>
        public static Bitmap TakeHorizontalScrollingScreenshot(Point scrollPoint, SystemWindow window, Point? clickPoint)
        {
            return TakeHorizontalScrollingScreenshot(scrollPoint, window.Rectangle, clickPoint);
        }

        /// <summary>
        /// Take a screenshot from a horizontally scrolling region. The scrolling can be done either by simulating mouse wheel events,
        /// or by simulating mouse click events on the scrollbar button. The operation stops when scrolling does not result in any 
        /// new content or when the mouse is moved by the user.
        /// </summary>
        /// <param name="scrollPoint">Point inside the window that is inside the scrolling region and that might be used for sending scroll wheel events at</param>
        /// <param name="rect">Rectangle to take the screenshot of</param>
        /// <param name="clickPoint">Point above the scrollbar to click, if desired</param>
        /// <returns></returns>
        public static Bitmap TakeHorizontalScrollingScreenshot(Point scrollPoint, Rectangle rect, Point? clickPoint)
        {
            int scrollCount;
            return FlipRotate(TakeScrollingScreenshot(new Point(scrollPoint.Y, scrollPoint.X), FlipRotate(rect), clickPoint.HasValue ? clickPoint.Value : scrollPoint, clickPoint.HasValue, r => FlipRotate(TakeScreenshot(FlipRotate(r), false, null)), r => HighlightRect(FlipRotate(r)), out scrollCount));
        }

        private delegate Bitmap ScreenshotFunction(Rectangle rect);
        private delegate void HighlightFunction(Rectangle rect);

        private static Bitmap TakeScrollingScreenshot(Point centerPoint, Rectangle rect, Point mousePoint, bool click, ScreenshotFunction screenshot, HighlightFunction highlight, out int scrollCount)
        {
            scrollCount = 0;
            Cursor.Position = mousePoint;
            Bitmap buffer = screenshot(rect);
            int usedHeight = buffer.Height;
            buffer = ResizeBitmap(buffer, buffer.Height * 4);
            bool lastMayBeIncomplete = false;
            while (Cursor.Position == mousePoint)
            {
                scrollCount++;
                if (click)
                {
                    KeyboardKey.InjectMouseEvent(0x0002, 0, 0, 0, UIntPtr.Zero);
                    KeyboardKey.InjectMouseEvent(0x0004, 0, 0, 0, UIntPtr.Zero);
                }
                else
                {
                    KeyboardKey.InjectMouseEvent(0x0800, 0, 0, unchecked((uint)-120), UIntPtr.Zero);
                }
                Application.DoEvents();
                highlight(rect);
                Bitmap nextPart = screenshot(rect);
                int scrollHeight = AppendBelow(buffer, usedHeight, nextPart, false);
                foreach (int delay in new int[] { 0, 2, 10, 100, 200, 1000 })
                {
                    if (scrollHeight > 0 || Cursor.Position != mousePoint)
                        break;
                    Thread.Sleep(delay);
                    Application.DoEvents();
                    highlight(rect);
                    nextPart = screenshot(rect);
                    scrollHeight = AppendBelow(buffer, usedHeight, nextPart, false);
                }
                if (scrollHeight == -1)
                {
                    if (lastMayBeIncomplete)
                    {
                        scrollHeight = AppendBelow(buffer, usedHeight, nextPart, true);
                    }
                    lastMayBeIncomplete = false;
                }
                else
                {
                    lastMayBeIncomplete = true;
                }
                if (scrollHeight == -1)
                {
                    CropToSimilarRange(centerPoint, ref rect, ref buffer, ref usedHeight, ref nextPart);
                    highlight(rect);
                    scrollHeight = AppendBelow(buffer, usedHeight, nextPart, false);
                }
                if (scrollHeight <= 0)
                    break;
                usedHeight += scrollHeight;
                if (buffer.Height - usedHeight < rect.Height)
                    buffer = ResizeBitmap(buffer, buffer.Height * 2);
            }
            return ResizeBitmap(buffer, usedHeight);
        }

        private static void CropToSimilarRange(Point centerPoint, ref Rectangle rect, ref Bitmap buffer, ref int usedHeight, ref Bitmap nextPart)
        {
            Point mousePoint = Cursor.Position;
            int offs = usedHeight - nextPart.Height;
            int relX = centerPoint.X - rect.X;
            int relY = centerPoint.Y - rect.Y;

            // copy all pixel values
            int[,] bufferPixels = new int[rect.Width, rect.Height];
            int[,] nextPartPixels = new int[rect.Width, rect.Height];
            for (int x = 0; x < rect.Width; x++)
            {
                for (int y = 0; y < rect.Height; y++)
                {
                    bufferPixels[x, y] = buffer.GetPixel(x, y + offs).ToArgb();
                    nextPartPixels[x, y] = nextPart.GetPixel(x, y).ToArgb();
                }
            }

            // find a different point
            int diffX = relX, diffY = relY;
            if (bufferPixels[relX, relY] == nextPartPixels[relX, relY])
            {
                bool found = false;
                int maxDistance = Math.Min(Math.Min(relX, relY), Math.Min(nextPart.Width - relX, nextPart.Height - relY));
                for (int i = 1; !found && i < maxDistance; i++)
                {
                    for (int j = 0; j < i * 2; j++)
                    {
                        int x = relX - i + j;
                        int y = relY - i;
                        if (bufferPixels[x, y] != nextPartPixels[x, y])
                        {
                            diffX = x; diffY = y; found = true;
                            break;
                        }
                        x = relX + i;
                        y = relY - i + j;
                        if (bufferPixels[x, y] != nextPartPixels[x, y])
                        {
                            diffX = x; diffY = y; found = true;
                            break;
                        }
                        x = relX + i - j;
                        y = relY + i;
                        if (bufferPixels[x, y] != nextPartPixels[x, y])
                        {
                            diffX = x; diffY = y; found = true;
                            break;
                        }
                        x = relX - i;
                        y = relY + i - j;
                        if (bufferPixels[x, y] != nextPartPixels[x, y])
                        {
                            diffX = x; diffY = y; found = true;
                            break;
                        }
                    }
                }
                if (!found) return;
            }

            // score every possible scroll height
            int[] scrollScores = new int[nextPart.Height / 2];
            for (int x = 0; x < rect.Width; x++)
            {
#if !DEBUG
                if (Cursor.Position != mousePoint) return;
#endif
                for (int y = 0; y < rect.Height; y++)
                {
                    // look at every pixel that does not match unmoved
                    int pixel = nextPartPixels[x, y];
                    if (bufferPixels[x, y] != pixel)
                    {
                        int score = 1000 / (Math.Abs(relX - x) + Math.Abs(relY - y) + 1) + 1;
                        for (int scrollHeight = 1; scrollHeight < Math.Min(scrollScores.Length, rect.Height - y); scrollHeight++)
                        {
                            if (bufferPixels[x, y + scrollHeight] == pixel)
                            {
                                scrollScores[scrollHeight] += score;
                            }
                        }
                    }
                }
            }

            // remove scores that do not preserve relX/relY or diffX/diffY
            for (int scrollHeight = 1; scrollHeight < scrollScores.Length; scrollHeight++)
            {
                if ((relY + scrollHeight < rect.Height && bufferPixels[relX, relY + scrollHeight] != nextPartPixels[relX, relY])
                    || (diffY + scrollHeight < rect.Height && bufferPixels[diffX, diffY + scrollHeight] != nextPartPixels[diffX, diffY]))
                {
                    scrollScores[scrollHeight] = 0;
                }
            }

            // take the first 5 scroll distances based on score
            Rectangle newRect = rect;
            int newRectSize = 0;
            for (int i = 0; i < 5; i++)
            {
#if !DEBUG
                if (Cursor.Position != mousePoint) return;
#endif
                int maxScore = 0;
                for (int scrollHeight = 1; scrollHeight < scrollScores.Length; scrollHeight++)
                {
                    if (scrollScores[scrollHeight] > maxScore)
                        maxScore = scrollScores[scrollHeight];
                }
                if (maxScore == 0)
                    break;
                for (int scrollHeight = 1; scrollHeight < scrollScores.Length; scrollHeight++)
                {
                    if (scrollScores[scrollHeight] == maxScore)
                    {
#if !DEBUG
                        if (Cursor.Position != mousePoint) return;
#endif
                        scrollScores[scrollHeight] = 0;

                        // check the maximum rectangle that scrolls and its size
                        int minY = 0, maxY = rect.Height - 1 - scrollHeight;
                        // first scan up and down with a width of 7 pixels
                        for (int y = relY - 1; y >= minY; y--)
                        {
                            bool same = true;
                            for (int x = relX - 3; x <= relX + 3; x++)
                            {
                                if (bufferPixels[x, y + scrollHeight] != nextPartPixels[x, y])
                                {
                                    same = false;
                                    break;
                                }
                            }
                            if (!same)
                            {
                                minY = y + 1;
                            }
                        }
                        for (int y = relY + 1; y <= maxY; y++)
                        {
                            bool same = true;
                            for (int x = relX - 3; x <= relX + 3; x++)
                            {
                                if (bufferPixels[x, y + scrollHeight] != nextPartPixels[x, y])
                                {
                                    same = false;
                                    break;
                                }
                            }
                            if (!same)
                            {
                                maxY = y - 1;
                            }
                        }
                        // now check left and right
                        int minX = 0, maxX = rect.Width - 1;
                        for (int x = relX - 1; x >= minX; x--)
                        {
                            bool same = true;
                            for (int y = minY; y <= maxY; y++)
                            {

                                if (bufferPixels[x, y + scrollHeight] != nextPartPixels[x, y])
                                {
                                    same = false;
                                    break;
                                }
                            }
                            if (!same)
                                minX = x + 1;
                        }
                        for (int x = relX + 1; x <= maxX; x++)
                        {
                            bool same = true;
                            for (int y = minY; y <= maxY; y++)
                            {
                                if (bufferPixels[x, y + scrollHeight] != nextPartPixels[x, y])
                                {
                                    same = false;
                                    break;
                                }
                            }
                            if (!same)
                                maxX = x - 1;
                        }
                        Rectangle rr = new Rectangle(rect.X + minX, rect.Y + minY, maxX - minX + 1, maxY - minY + 1 + scrollHeight);
                        if (rr.Width > 16 && rr.Height > 16 && rr.Width * rr.Height > newRectSize)
                        {
                            newRect = rr;
                            newRectSize = rr.Width * rr.Height;
                        }
                    }
                }
            }

            // if we found a rectangle
            if (newRectSize > 0)
            {
                // do the cropping
                int cropTop = newRect.Top - rect.Top;
                int cropLeft = newRect.Left - rect.Left;
                int cropRight = rect.Right - newRect.Right;
                int cropBottom = rect.Bottom - newRect.Bottom;
                buffer = Crop(buffer, cropTop, cropLeft, cropRight, cropBottom);
                nextPart = Crop(nextPart, cropTop, cropLeft, cropRight, cropBottom);
                usedHeight -= cropTop + cropBottom;

                // update the rectangle
                rect = newRect;
            }
        }

        private static Bitmap Crop(Bitmap original, int cropTop, int cropLeft, int cropRight, int cropBottom)
        {
            Bitmap result = new Bitmap(original.Width - cropLeft - cropRight, original.Height - cropTop - cropBottom);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(original, -cropLeft, -cropTop);
            }
            return result;
        }

        private static int AppendBelow(Bitmap buffer, int usedHeight, Bitmap nextPart, bool ignoreLastPart)
        {
            int offs = usedHeight - nextPart.Height;

            // copy all pixel values
            int[,] bufferPixels = new int[nextPart.Width, nextPart.Height];
            int[,] nextPartPixels = new int[nextPart.Width, nextPart.Height];
            for (int x = 0; x < nextPart.Width; x++)
            {
                for (int y = 0; y < nextPart.Height; y++)
                {
                    bufferPixels[x, y] = buffer.GetPixel(x, y + offs).ToArgb();
                    nextPartPixels[x, y] = nextPart.GetPixel(x, y).ToArgb();
                }
            }

            // find offset and append
            for (int scrollHeight = 0; scrollHeight < nextPart.Height / (ignoreLastPart ? 4 : 2); scrollHeight++)
            {
                bool same = true;
                for (int y = 0; same && y < nextPart.Height - scrollHeight * (ignoreLastPart ? 2 : 1); y++)
                {
                    for (int x = 0; same && x < nextPart.Width; x++)
                    {
                        if (nextPartPixels[x, y] != bufferPixels[x, y + scrollHeight])
                            same = false;
                    }
                }
                if (same)
                {
                    using (Graphics g = Graphics.FromImage(buffer))
                    {
                        g.DrawImage(nextPart, 0, offs + scrollHeight);
                    }
                    return scrollHeight;
                }
            }
            return -1;
        }

        private static Bitmap ResizeBitmap(Bitmap original, int height)
        {
            Bitmap result = new Bitmap(original.Width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(original, 0, 0);
            }
            return result;
        }

        private static void HighlightRect(Rectangle rect)
        {
            SystemWindow window = SystemWindow.DesktopWindow;
            using (WindowDeviceContext windowDC = window.GetDeviceContext(false))
            {
                using (Graphics g = windowDC.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Blue, rect.X - 1, rect.Y - 1, rect.Width + 2, rect.Height + 2);
                }
            }
        }

        private static Bitmap FlipRotate(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Height, original.Width);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.Transform = new Matrix(0, 1, 1, 0, 0, 0);
                g.DrawImage(original, 0, 0);
            }
            return result;
        }

        private static Rectangle FlipRotate(Rectangle original)
        {
            return new Rectangle(original.Y, original.X, original.Height, original.Width);
        }

        #region PInvoke Declarations

        [StructLayout(LayoutKind.Sequential)]
        struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINT ptScreenPos;
        }

        [DllImport("user32.dll")]
        static extern int GetCursorInfo(out CURSORINFO pci);

        private const Int32 CURSOR_SHOWING = 0x00000001;

        [DllImport("user32.dll")]
        static extern int DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("gdi32.dll", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        #endregion
    }
}
