using System;
using System.Drawing;
using System.Windows.Forms;
using ManagedWinapi.Accessibility;
using ManagedWinapi.Windows;

namespace ScreenShooter
{
    public partial class SelectorForm : Form
    {
        private readonly string windowSelectName, accessibleObjectSelectName;
        private readonly string windowSelectInfo;
        private readonly string[] extraPointMessages;
        private readonly Point[] extraPoints;
        private bool selectAccObjects = false, freshWindow = false;
        private Point highlightedPoint = new Point(-1, -1);
        private SystemWindow highlightedWindow = null;
        private SystemAccessibleObject highlightedObject = null;
        private int extraPointIndex = -1;
        private bool shouldClose = false;

        public delegate void SelectionFinishedDelegate(Point pt, SystemWindow sw, SystemAccessibleObject accObj, Point[] extraPoints);
        public event SelectionFinishedDelegate SelectionFinished;

        public SelectorForm(bool selectAccessibleObjects, string windowSelectInfo, params string[] extraPointMessages)
        {
            InitializeComponent();
            this.windowSelectName = "window object";
            this.accessibleObjectSelectName = selectAccessibleObjects ? "screenreader object" : null;
            this.windowSelectInfo = windowSelectInfo;
            this.extraPointMessages = extraPointMessages;
            extraPoints = new Point[extraPointMessages.Length];
            this.Focus();
            this.Cursor = Cursors.No;
            UpdateLabel();
            mouseHook.StartHook();
        }

        private void UpdateLabel()
        {
            if (extraPointIndex == -1)
            {
                string primaryName = windowSelectName, secondaryName = accessibleObjectSelectName;
                if (selectAccObjects)
                {
                    primaryName = accessibleObjectSelectName;
                    secondaryName = windowSelectName;
                }
                label.Text = "Left-click to select a " + primaryName + windowSelectInfo + ". Right-click to enlarge the currently selected " + primaryName + (secondaryName == null ? "" : ". Left-click while right-clicking to switch to selecting a " + secondaryName) + ". Press any key to cancel.";
            }
            else
            {
                label.Text = "Left click on " + extraPointMessages[extraPointIndex] + " to select it. Right-click to start over. Press any key to cancel.";
            }
        }

        private void Highlight(SystemWindow sw, SystemAccessibleObject acc)
        {
            if (sw == null) return;
            if (acc != null && acc != highlightedObject)
            {
                if (highlightedWindow != null)
                    highlightedWindow.Refresh();
                acc.Highlight();
            }
            else if (sw != highlightedWindow)
            {
                if (highlightedWindow != null)
                    highlightedWindow.Refresh();
                sw.Highlight();
            }
            highlightedObject = acc;
            highlightedWindow = sw;
        }

        private void SelectorForm_KeyDown(object sender, KeyEventArgs e)
        {
            Close();
        }

        bool rightButtonDown = false;

        private void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (highlightedWindow == null || shouldClose)
                return;
            if (e.Button == MouseButtons.Right)
            {
                rightButtonDown = true;
                if (extraPointIndex != -1)
                {
                    extraPointIndex = -1;
                    UpdateLabel();
                }
                else if (highlightedObject != null)
                {
                    SystemAccessibleObject acc = highlightedObject.Parent;
                    if (acc.Window == highlightedWindow)
                        Highlight(highlightedWindow, acc);
                    else
                        Highlight(highlightedWindow, null);
                }
                else
                {
                    if (freshWindow)
                    {
                        Point pt = Cursor.Position;
                        SystemWindow sw = SystemWindow.FromPoint(pt.X, pt.Y);
                        if (highlightedWindow.IsDescendantOf(sw))
                            sw = highlightedWindow;
                        if (sw == highlightedWindow)
                            sw = sw.ParentSymmetric;
                        Highlight(sw, null);
                        freshWindow = false;
                    }
                    else
                    {
                        Highlight(highlightedWindow.ParentSymmetric, null);
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (extraPointIndex != -1)
                    extraPoints[extraPointIndex] = Cursor.Position;
                if (rightButtonDown && accessibleObjectSelectName != null)
                {
                    selectAccObjects = !selectAccObjects;
                }
                else if (extraPointIndex != extraPoints.Length - 1)
                {
                    extraPointIndex++;
                }
                else
                {
                    shouldClose = true;
                }
                UpdateLabel();
            }
        }

        private void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rightButtonDown = false;
            }
            if (shouldClose)
            {
                Close();
                if (SelectionFinished != null)
                    SelectionFinished(highlightedPoint, highlightedWindow, highlightedObject, extraPoints);
            }
        }

        private void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            if (shouldClose) return;
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Point pt = Cursor.Position;
            int left = pt.X > screen.Width / 2 ? 20 : screen.Width - this.Width - 20;
            int top = pt.Y > screen.Height / 2 ? 20 : screen.Height - this.Height - 20;
            if (left != Left || top != Top)
            {
                Location = new Point(left, top);
                Focus();
            }
            if (extraPointIndex != -1 || pt == highlightedPoint)
                return;
            highlightedPoint = pt;
            if (selectAccObjects)
            {
                SystemAccessibleObject acc = SystemAccessibleObject.FromPoint(pt.X, pt.Y);
                Highlight(acc.Window, acc);
            }
            else
            {
                SystemWindow sw = SystemWindow.FromPointEx(pt.X, pt.Y, false, false);
                Highlight(sw, null);
                freshWindow = true;
            }
        }

        private void mouseHook_MouseIntercepted(int msg, POINT pt, int mouseData, int flags, int time, IntPtr dwExtraInfo, ref bool handled)
        {
            handled = (msg != 0x200); // WM_MOUSEMOVE
        }

        private void SelectorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouseHook.Unhook();
            if (highlightedWindow != null)
                highlightedWindow.Refresh();
        }
    }
}
