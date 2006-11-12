/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2006 Michael Schierl
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
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace ManagedWinapi.Windows
{
    /// <summary>
    /// Window Style Flags. The original constants started with WS_.
    /// </summary>
    /// <seealso cref="SystemWindow.Style"/>
    [Flags]
    public enum WindowStyleFlags
    {
        /// <summary>
        /// WS_OVERLAPPED
        /// </summary>
        OVERLAPPED = 0x00000000,

        /// <summary>
        /// WS_POPUP
        /// </summary>
        POPUP = unchecked((int)0x80000000),

        /// <summary>
        /// WS_CHILD
        /// </summary>
        CHILD = 0x40000000,

        /// <summary>
        /// WS_MINIMIZE
        /// </summary>
        MINIMIZE = 0x20000000,

        /// <summary>
        /// WS_VISIBLE
        /// </summary>
        VISIBLE = 0x10000000,

        /// <summary>
        /// WS_DISABLED
        /// </summary>
        DISABLED = 0x08000000,

        /// <summary>
        /// WS_CLIPSIBLINGS
        /// </summary>
        CLIPSIBLINGS = 0x04000000,

        /// <summary>
        /// WS_CLIPCHILDREN
        /// </summary>
        CLIPCHILDREN = 0x02000000,

        /// <summary>
        /// WS_MAXIMIZE
        /// </summary>
        MAXIMIZE = 0x01000000,

        /// <summary>
        /// WS_BORDER
        /// </summary>
        BORDER = 0x00800000,

        /// <summary>
        /// WS_DLGFRAME
        /// </summary>
        DLGFRAME = 0x00400000,

        /// <summary>
        /// WS_VSCROLL
        /// </summary>
        VSCROLL = 0x00200000,

        /// <summary>
        /// WS_HSCROLL
        /// </summary>
        HSCROLL = 0x00100000,

        /// <summary>
        /// WS_SYSMENU
        /// </summary>
        SYSMENU = 0x00080000,

        /// <summary>
        /// WS_THICKFRAME
        /// </summary>
        THICKFRAME = 0x00040000,

        /// <summary>
        /// WS_GROUP
        /// </summary>
        GROUP = 0x00020000,

        /// <summary>
        /// WS_TABSTOP
        /// </summary>
        TABSTOP = 0x00010000,

        /// <summary>
        /// WS_MINIMIZEBOX
        /// </summary>
        MINIMIZEBOX = 0x00020000,

        /// <summary>
        /// WS_MAXIMIZEBOX
        /// </summary>
        MAXIMIZEBOX = 0x00010000,

        /// <summary>
        /// WS_CAPTION
        /// </summary>
        CAPTION = BORDER | DLGFRAME,

        /// <summary>
        /// WS_TILED
        /// </summary>
        TILED = OVERLAPPED,

        /// <summary>
        /// WS_ICONIC
        /// </summary>
        ICONIC = MINIMIZE,

        /// <summary>
        /// WS_SIZEBOX
        /// </summary>
        SIZEBOX = THICKFRAME,

        /// <summary>
        /// WS_TILEDWINDOW
        /// </summary>
        TILEDWINDOW = OVERLAPPEDWINDOW,

        /// <summary>
        /// WS_OVERLAPPEDWINDOW
        /// </summary>
        OVERLAPPEDWINDOW = OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX,

        /// <summary>
        /// WS_POPUPWINDOW
        /// </summary>
        POPUPWINDOW = POPUP | BORDER | SYSMENU,

        /// <summary>
        /// WS_CHILDWINDOW
        /// </summary>
        CHILDWINDOW = CHILD,
    }

    /// <summary>
    /// Represents any window used by Windows, including those from other applications.
    /// </summary>
    public class SystemWindow
    {

        private static readonly Predicate<SystemWindow> ALL = delegate { return true; };

        private IntPtr _hwnd;

        /// <summary>
        /// Allows getting the current foreground window and setting it.
        /// </summary>
        public static SystemWindow ForegroundWindow
        {
            get
            {
                return new SystemWindow(GetForegroundWindow());
            }
            set
            {
                SetForegroundWindow(value.HWnd);
            }
        }

        /// <summary>
        /// Returns all available toplevel windows.
        /// </summary>
        public static SystemWindow[] AllToplevelWindows
        {
            get
            {
                return FilterToplevelWindows(new Predicate<SystemWindow>(ALL));
            }
        }

        /// <summary>
        /// Returns all toplevel windows that match the given predicate.
        /// </summary>
        /// <param name="predicate">The predicate to filter.</param>
        /// <returns>The filtered toplevel windows</returns>
        public static SystemWindow[] FilterToplevelWindows(Predicate<SystemWindow> predicate)
        {
            List<SystemWindow> wnds = new List<SystemWindow>();
            EnumWindows(new EnumWindowsProc(delegate(IntPtr hwnd, IntPtr lParam)
            {
                SystemWindow tmp = new SystemWindow(hwnd);
                if (predicate(tmp))
                    wnds.Add(tmp);
                return 1;
            }), new IntPtr(0));
            return wnds.ToArray();
        }

        /// <summary>
        /// Finds the system window below the given point. This need not be a
        /// toplevel window; disabled windows are not returned either.
        /// If you have problems with transparent windows that cover nontransparent
        /// windows, consider using <see cref="FromPointEx"/>, since that method
        /// tries hard to avoid this problem.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns></returns>
        public static SystemWindow FromPoint(int x, int y)
        {
            IntPtr hwnd = WindowFromPoint(new POINT(x, y));
            if (hwnd.ToInt64() == 0)
            {
                return null;
            }
            return new SystemWindow(hwnd);
        }

        /// <summary>
        /// Finds the system window below the given point. This method uses a more
        /// sophisticated algorithm than <see cref="FromPoint"/>, but is slower.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="toplevel">Whether to return the toplevel window.</param>
        /// <param name="enabledOnly">Whether to return enabled windows only.</param>
        /// <returns></returns>
        public static SystemWindow FromPointEx(int x, int y, bool toplevel, bool enabledOnly) {
            SystemWindow sw = FromPoint(x, y);
            if (sw == null) return null;
            while (sw.ParentSymmetric != null)
                sw = sw.ParentSymmetric;
            if (toplevel)
                return sw;
            int area;
                area = getArea(sw);
            SystemWindow result = sw;
            foreach(SystemWindow w in sw.AllDescendantWindows) {
                if (w.Visible && (w.Enabled || !enabledOnly))
                {
                    if (w.Rectangle.ToRectangle().Contains(x, y))
                    {
                        int ar2 = getArea(sw);
                        if (ar2 <= area)
                        {
                            area = ar2;
                            result = w;
                        }
                    }
                }
            }
            return result;
        }

        private static int getArea(SystemWindow sw)
        {
            RECT rr = sw.Rectangle;
            return rr.Height * rr.Width;
        }

        /// <summary>
        /// Create a new SystemWindow instance from a window handle.
        /// </summary>
        /// <param name="HWnd">The window handle.</param>
        public SystemWindow(IntPtr HWnd)
        {
            _hwnd = HWnd;
        }

        /// <summary>
        /// Create a new SystemWindow instance from a Windows Form.
        /// </summary>
        /// <param name="form">The form.</param>
        public SystemWindow(Form form)
        {
            _hwnd = form.Handle;
        }

        /// <summary>
        /// Return all descendant windows (child windows and their descendants).
        /// </summary>
        public SystemWindow[] AllDescendantWindows
        {
            get
            {
                return FilterDescendantWindows(false, ALL);
            }
        }

        /// <summary>
        /// Return all direct child windows.
        /// </summary>
        public SystemWindow[] AllChildWindows
        {
            get
            {
                return FilterDescendantWindows(true, ALL);
            }
        }

        /// <summary>
        /// Returns all child windows that match the given predicate.
        /// </summary>
        /// <param name="directOnly">Whether to include only direct children (no descendants)</param>
        /// <param name="predicate">The predicate to filter.</param>
        /// <returns>The list of child windows.</returns>
        public SystemWindow[] FilterDescendantWindows(bool directOnly, Predicate<SystemWindow> predicate)
        {
            List<SystemWindow> wnds = new List<SystemWindow>();
            EnumChildWindows(_hwnd, delegate(IntPtr hwnd, IntPtr lParam)
            {
                SystemWindow tmp = new SystemWindow(hwnd);
                bool add = true;
                if (directOnly)
                {
                    add = tmp.Parent._hwnd == _hwnd;
                }
                if (add && predicate(tmp))
                    wnds.Add(tmp);
                return 1;
            }, new IntPtr(0));
            return wnds.ToArray();
        }

        /// <summary>
        /// The Window handle of this window.
        /// </summary>
        public IntPtr HWnd { get { return _hwnd; } }

        /// <summary>
        /// The title of this window (by the <c>GetWindowText</c> API function).
        /// </summary>
        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder(GetWindowTextLength(_hwnd) + 1);
                GetWindowText(_hwnd, sb, sb.Capacity);
                return sb.ToString();
            }
        }

        /// <summary>
        /// The name of the window class (by the <c>GetClassName</c> API function).
        /// This class has nothing to do with classes in C# or other .NET languages.
        /// </summary>
        public string ClassName
        {
            get
            {
                StringBuilder sb = new StringBuilder(256);
                GetClassName(_hwnd, sb, sb.Capacity);
                return sb.ToString();
            }
        }

        /// <summary>
        /// Whether this window is currently visible. A window is visible if its 
        /// and all ancestor's visibility flags are true.
        /// </summary>
        public bool Visible
        {
            get
            {
                return IsWindowVisible(_hwnd);
            }
        }

        /// <summary>
        /// Whether this window is currently enabled (able to accept keyboard input).
        /// </summary>
        public bool Enabled
        {
            get
            {
                return IsWindowEnabled(_hwnd);
            }
            set
            {
                EnableWindow(_hwnd, value);
            }
        }

        /// <summary>
        /// Returns or sets the visibility flag.
        /// </summary>
        /// <seealso cref="SystemWindow.Visible"/>
        public bool VisibilityFlag
        {
            get
            {
                return (Style & WindowStyleFlags.VISIBLE) != 0;
            }
            set
            {
                if (value)
                {
                    Style |= WindowStyleFlags.VISIBLE;
                }
                else
                {
                    Style &= ~WindowStyleFlags.VISIBLE;
                }
            }
        }

        /// <summary>
        /// This window's style flags.
        /// </summary>
        public WindowStyleFlags Style
        {
            get
            {
                return (WindowStyleFlags)GetWindowLongPtr(_hwnd, (int)(GWL.GWL_STYLE));
            }
            set
            {
                SetWindowLong(_hwnd, (int)GWL.GWL_STYLE, (int)value);
            }

        }

        /// <summary>
        /// This window's parent. A dialog's parent is its owner, a component's parent is
        /// the window that contains it.
        /// </summary>
        public SystemWindow Parent {
            get
            {
                return new SystemWindow(GetParent(_hwnd));
            }
        }

        /// <summary>
        /// The window's parent, but only if this window is its parent child. Some
        /// parents, like dialog owners, do not have the window as its child. In that case,
        /// <c>null</c> will be returned.
        /// </summary>
        public SystemWindow ParentSymmetric
        {
            get
            {
                SystemWindow result = Parent;
                if (!this.IsDescendantOf(result)) result = null;
                return result;
            }
        }

        /// <summary>
        /// The window's position inside its parent or on the screen.
        /// </summary>
        public RECT Position {
            get
            {
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                wp.length = Marshal.SizeOf(wp);
                GetWindowPlacement(_hwnd, ref wp);
                return wp.rcNormalPosition;
            }

            set
            {
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                wp.length = Marshal.SizeOf(wp);
                GetWindowPlacement(_hwnd, ref wp);
                wp.rcNormalPosition = value;
                SetWindowPlacement(_hwnd, ref wp);
            }
        }

        /// <summary>
        /// The window's position in absolute screen coordinates. Use 
        /// <see cref="Position"/> if you want to use the relative position.
        /// </summary>
        public RECT Rectangle
        {
            get
            {
                RECT r = new RECT();
                GetWindowRect(_hwnd, out r);
                return r;
            }
        }

        /// <summary>
        /// Check whether this window is a descendant of <c>ancestor</c>
        /// </summary>
        /// <param name="ancestor">The suspected ancestor</param>
        /// <returns>If this is really an ancestor</returns>
        public bool IsDescendantOf(SystemWindow ancestor)
        {
            return IsChild(ancestor._hwnd, _hwnd);
        }

        /// <summary>
        /// The process which created this window.
        /// </summary>
        public Process Process
        {
            get
            {
                int pid;
                GetWindowThreadProcessId(HWnd, out pid);
                return Process.GetProcessById(pid);
            }
        }

        /// <summary>
        /// Whether this window is minimized or maximized.
        /// </summary>
        public FormWindowState WindowState 
        {
            get {
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                wp.length = Marshal.SizeOf(wp);
                GetWindowPlacement(HWnd, ref wp);
                switch (wp.showCmd % 4) {
                    case 2: return FormWindowState.Minimized;
                    case 3: return FormWindowState.Maximized;
                    default: return FormWindowState.Normal;
                }
            }
            set {
                int showCommand;
                switch(value) {
                    case FormWindowState.Normal:
                        showCommand = 1;
                        break;
                    case FormWindowState.Minimized:
                       showCommand=2;
                        break;
                    case FormWindowState.Maximized:
                        showCommand=3;
                        break;
                    default: return;
                }
                ShowWindow(HWnd, showCommand);
            }
        }

        public bool Movable
        {
            get
            {
                return (Style & WindowStyleFlags.SYSMENU) != 0;
            }
        }

        public bool Resizable
        {
            get
            {
                return (Style & WindowStyleFlags.THICKFRAME) != 0;
            }
        }

        #region Equals and HashCode

        ///
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            SystemWindow sw = obj as SystemWindow;
            return Equals(sw);
        }

        ///
        public bool Equals(SystemWindow sw)
        {
            if ((object)sw == null)
            {
                return false;
            }
            return _hwnd == sw._hwnd;
        }

        ///
        public override int GetHashCode()
        {
            // avoid exceptions
            return unchecked((int)_hwnd.ToInt64());
        }

        /// <summary>
        /// Compare two instances of this class for equality.
        /// </summary>
        public static bool operator ==(SystemWindow a, SystemWindow b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a._hwnd == b._hwnd;
        }

        /// <summary>
        /// Compare two instances of this class for inequality.
        /// </summary>
        public static bool operator !=(SystemWindow a, SystemWindow b)
        {
            return !(a == b);
        }

        #endregion

        #region PInvoke Declarations

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private delegate int EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        private static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetWindowLong32(hWnd, nIndex));
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        private enum GWL
        {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        [DllImport("user32.dll")]
        static extern bool GetWindowPlacement(IntPtr hWnd,
           ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        static extern bool SetWindowPlacement(IntPtr hWnd,
           [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion
    }
}
