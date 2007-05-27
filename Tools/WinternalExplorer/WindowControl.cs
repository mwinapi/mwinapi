using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;
using ManagedWinapi.Windows.Contents;

namespace WinternalExplorer
{
    public partial class WindowControl : ChildControl
    {
        public static WindowControl Instance = new WindowControl();
        private SystemWindow currentWindow;
        private bool updating, allowUnsafeChanges;
        private FrameForm ff;
        private MainForm mf;

        private static readonly string[] styleBitNames = {
            "MAXIMIZEBOX/TABSTOP", "MINIMIZEBOX/GROUP", "THICKFRAME","SYSMENU", 
            "HSCROLL", "VSCROLL", "DLGFRAME", "BORDER",
            "MAXIMIZE", "CLIPCHILDREN", "CLIPSIBLINGS", "DISABLED", 
            "VISIBLE", "MINIMIZED", "CHILD", "POPUP"
        };

        private static readonly string[] exStyleBitNames = {
            "DLGMODALFRAME","Reserved (0x00000002)","NOPARENTNOTIFY", "TOPMOST",
            "ACCEPTFILES","TRANSPARENT","MDICHILD","TOOLWINDOW",
            "WINDOWEDGE","CLIENTEDGE","CONTEXTHELP","Reserved (0x00000800)",
            "RIGHT","RTLREADING","LEFTSCROLLBAR","Reserved (0x00008000)",
            "CONTROLPARENT","STATICEDGE","APPWINDOW","LAYERED",
            "NOINHERITLAYOUT","Reserved (0x00200000)","LAYOUTRTL","Reserved (0x00800000)",
            "Reserved (0x01000000)","COMPOSITED","Reserved (0x04000000)","NOACTIVATE"
        };


        public WindowControl()
        {
            InitializeComponent();
            foreach (Screen s in Screen.AllScreens)
            {
                if (s.WorkingArea.Width > 640 && s.WorkingArea.Height > 480) s640x480ToolStripMenuItem.Enabled = true;
                if (s.WorkingArea.Width > 800 && s.WorkingArea.Height > 600) s800x600ToolStripMenuItem.Enabled = true;
                if (s.WorkingArea.Width > 1024 && s.WorkingArea.Height > 768) s1024x768ToolStripMenuItem.Enabled = true;
                if (s.WorkingArea.Width > 1280 && s.WorkingArea.Height > 1024) s1280x1024ToolStripMenuItem.Enabled = true;
            }
        }

        internal override void Update(TreeNodeData tnd, bool allowUnsafeChanges, MainForm mf)
        {
            this.mf = mf;
            this.allowUnsafeChanges = allowUnsafeChanges;
            currentWindow = ((WindowData)tnd).Window;
            UpdateControls();
        }

        internal override void Update(bool allowUnsafeChanges)
        {
            this.allowUnsafeChanges = allowUnsafeChanges;
            UpdateControls();
        }

        private void UpdateControls()
        {
            outline.Checked = false;
            updating = true;
            SystemWindow sw = currentWindow;
            hWnd.Text = "0x" + sw.HWnd.ToString("x8") + " (" + sw.HWnd + ")";
            try
            {
                className.Text = sw.ClassName;
            }
            catch (Win32Exception)
            {
                // window has been destroyed
                className.Text = "(destroyed)";
                title.Text = "";
                tabs.Visible = false;
                updating = false;
                return;
            }
            title.Text = sw.Title;
            UpdateTab(tabs.SelectedIndex);
            bool changePosition = allowUnsafeChanges || sw.Movable;
            bool changeSize = allowUnsafeChanges || sw.Resizable;
            position.Enabled = positionDrag.Enabled = changePosition;
            size.Enabled = resizeDrag.Enabled = wState.Enabled = changeSize;
            styleList.SelectionMode = allowUnsafeChanges ? SelectionMode.One : SelectionMode.None;
            exStyleList.SelectionMode = allowUnsafeChanges ? SelectionMode.One : SelectionMode.None;
            checkState.Enabled = allowUnsafeChanges;
            tabs.Visible = true;
            updating = false;
        }
        private void UpdateTab(int index)
        {
            SystemWindow sw = currentWindow;
            switch (index)
            {
                case 0:
                    position.Text = sw.Position.Left + "," + sw.Position.Top;
                    size.Text = sw.Position.Width + "x" + sw.Position.Height;
                    enabled.Checked = sw.Enabled;
                    visible.Checked = sw.VisibilityFlag;
                    topMost.Checked = sw.TopMost;
                    wState.SelectedIndex = (int)sw.WindowState;
                    capInfo.Text = "Window is " + (sw.Movable ? "" : "not ") + "movable and " +
                        (sw.Resizable ? "" : "not ") + "resizable.";
                    dialogId.Text = "0x" + sw.DialogID.ToString("x8") + " (" + sw.DialogID + ")";
                    checkState.SelectedIndex = (int)sw.CheckState;
                    SystemWindow parent = sw.Parent;
                    SystemWindow parentS = sw.ParentSymmetric;
                    hWndParent.Text = parent == null || parent.HWnd == IntPtr.Zero ? "None" :
                        ("0x" + parent.HWnd.ToString("x8") + " (" + parent.HWnd + ")" +
                        (parent == parentS ? " [Symmetric]" : ""));
                    process.Text = sw.Process.ProcessName + " (0x" + sw.Process.Id.ToString("x8") + ")";
                    position.ContextMenuStrip = parentS == null ? positionContextMenu : null;
                    size.ContextMenuStrip = parentS == null ? sizeContextMenu : null;
                    break;
                case 1:
                    WindowContent wc = sw.Content;
                    if (wc == null)
                    {
                        contentShort.Text = contentLong.Text = "";
                    }
                    else
                    {
                        contentShort.Text = wc.ShortDescription;
                        contentLong.Text = wc.LongDescription.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                    }
                    passwordChar.Text = "" + sw.PasswordCharacter;
                    break;
                case 2:
                    uint style = (uint)sw.Style;
                    styleText.Text = "0x" + style.ToString("x8") + " (" + style.ToString() + ")";
                    style = style >> 16;
                    styleList.Items.Clear();
                    foreach (string styleName in styleBitNames)
                    {
                        styleList.Items.Add(styleName, (style & 1) != 0);
                        style >>= 1;
                    }
                    uint exstyle = (uint)sw.ExtendedStyle;
                    exStyleText.Text = "0x" + exstyle.ToString("x8") + " (" + exstyle.ToString() + ")";
                    exStyleList.Items.Clear();
                    foreach (string exStyleName in exStyleBitNames)
                    {
                        exStyleList.Items.Add(exStyleName, (exstyle & 1) != 0);
                        exstyle >>= 1;
                    }
                    break;
                case 3:

                    //sw.Process
                    //sw.Thread
                    //sw.WindowAbove/Below
                    break;
            }
        }

        private void title_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.Title = title.Text;
            UpdateControls();
        }

        private void position_Click(object sender, EventArgs e)
        {
            int xx, yy;
            Rectangle pos = currentWindow.Position.ToRectangle();
            string left = InputBox.Show(ParentForm, "Left:", "" + pos.Left);
            if (left == null || !int.TryParse(left, out xx)) return;
            string top = InputBox.Show(ParentForm, "Top:", "" + pos.Top);
            if (top == null || !int.TryParse(top, out yy)) return;
            pos.Location = new Point(xx, yy);

            currentWindow.Position = RECT.FromRectangle(pos);
            UpdateControls();
        }

        private void size_Click(object sender, EventArgs e)
        {
            int ww, hh;
            Rectangle pos = currentWindow.Position.ToRectangle();
            string width = InputBox.Show(ParentForm, "Width:", "" + pos.Width);
            if (width == null || !int.TryParse(width, out ww)) return;
            string height = InputBox.Show(ParentForm, "Height:", "" + pos.Height);
            if (height == null || !int.TryParse(height, out hh)) return;
            pos.Size = new Size(ww, hh);
            currentWindow.Position = RECT.FromRectangle(pos);
            UpdateControls();
        }

        private void visible_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.VisibilityFlag = visible.Checked;
            UpdateControls();
        }

        private void enabled_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.Enabled = enabled.Checked;
            UpdateControls();
        }

        private void topMost_CheckedChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.TopMost = topMost.Checked;
            UpdateControls();
        }

        private void wState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.WindowState = (FormWindowState)wState.SelectedIndex;
            UpdateControls();
        }

        bool positionDragging, sizeDragging;
        int posX, posY;

        private void positionDrag_MouseDown(object sender, MouseEventArgs e)
        {
            posX = e.X;
            posY = e.Y;
            positionDragging = true;
        }

        private void positionDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (positionDragging)
            {
                Rectangle pos = currentWindow.Position.ToRectangle();
                pos.Location = new Point(pos.Location.X + e.X - posX, pos.Location.Y + e.Y - posY);
                currentWindow.Position = RECT.FromRectangle(pos);
                posX = e.X;
                posY = e.Y;
                UpdateControls();
            }
        }

        private void positionDrag_MouseUp(object sender, MouseEventArgs e)
        {
            positionDrag_MouseMove(sender, e);
            positionDragging = false;
        }

        private void flash_MouseDownUp(object sender, MouseEventArgs e)
        {
            visible.Checked = !visible.Checked;
        }

        private void resizeDrag_MouseDown(object sender, MouseEventArgs e)
        {
            posX = e.X;
            posY = e.Y;
            sizeDragging = true;
        }

        private void resizeDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (sizeDragging)
            {
                Rectangle pos = currentWindow.Position.ToRectangle();
                pos.Size = new Size(pos.Size.Width + e.X - posX, pos.Size.Height + e.Y - posY);
                currentWindow.Position = RECT.FromRectangle(pos);
                posX = e.X;
                posY = e.Y;
                UpdateControls();
            }
        }

        private void resizeDrag_MouseUp(object sender, MouseEventArgs e)
        {
            resizeDrag_MouseMove(sender, e);
            sizeDragging = false;
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] tmp = ((string)((ToolStripMenuItem)sender).Tag).Split('x');
            int ww = int.Parse(tmp[0]);
            int hh = int.Parse(tmp[1]);
            Rectangle pos = currentWindow.Position.ToRectangle();
            pos.Size = new Size(ww, hh);
            currentWindow.Position = RECT.FromRectangle(pos);
            UpdateControls();
        }

        private void positionXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int where = int.Parse((string)((ToolStripMenuItem)sender).Tag);
            Rectangle pos = currentWindow.Position.ToRectangle();
            Rectangle outer = Screen.FromRectangle(pos).WorkingArea;
            int spacingX = outer.Width - pos.Width;
            pos.X = spacingX * where / 2 + outer.X;
            currentWindow.Position = RECT.FromRectangle(pos);
            UpdateControls();
        }

        private void positionYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int where = int.Parse((string)((ToolStripMenuItem)sender).Tag);
            Rectangle pos = currentWindow.Position.ToRectangle();
            Rectangle outer = Screen.FromRectangle(pos).WorkingArea;
            int spacingY = outer.Height - pos.Height;
            pos.Y = spacingY * where / 2 + outer.Y;
            currentWindow.Position = RECT.FromRectangle(pos);
            UpdateControls();
        }

        private void outline_CheckedChanged(object sender, EventArgs e)
        {
            if (ff != null)
                ff.Dispose();
            if (outline.Checked)
            {
                ff = new FrameForm(currentWindow.Rectangle.ToRectangle(), position.Enabled && size.Enabled ? new ResizedDelegate(outlineResized) : null);
            }
        }

        private void outlineResized(FrameForm target)
        {
            Rectangle rectangle = currentWindow.Rectangle.ToRectangle();
            Rectangle position = currentWindow.Position.ToRectangle();
            Point p = new Point(target.Left - rectangle.Left + position.Left,
                target.Top - rectangle.Top + position.Top);
            Rectangle newPos = new Rectangle(p, target.Size);
            currentWindow.Position = RECT.FromRectangle(newPos);
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void checkState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            currentWindow.CheckState = (CheckState)checkState.SelectedIndex;
            UpdateControls();
        }

        private void styleList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (updating) return;
            uint bit = (uint)(1 << (16 + e.Index));
            uint style = (uint)currentWindow.Style;
            style &= ~bit;
            if (e.NewValue == CheckState.Checked)
                style |= bit;
            currentWindow.Style = (WindowStyleFlags)style;
        }

        private void exStyleList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (updating) return;
            uint bit = (uint)(1 << e.Index);
            uint exstyle = (uint)currentWindow.ExtendedStyle;
            exstyle &= ~bit;
            if (e.NewValue == CheckState.Checked)
                exstyle |= bit;
            currentWindow.ExtendedStyle = (WindowExStyleFlags)exstyle;
        }
    }
}
