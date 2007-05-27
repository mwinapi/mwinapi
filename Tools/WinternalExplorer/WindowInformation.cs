using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;
using ManagedWinapi.Windows.Contents;
using ManagedWinapi;

namespace WinternalExplorer
{
    public partial class WindowInformation : Form
    {
        int lastX = -1, lastY = -1, delaycount = -1, copiedX = 0, copiedY = 0, menuMode = 0, menuIndex = 0;
        WindowData windowData, parentData;
        readonly MainForm mf;
        readonly KeyboardKey shiftKey, ctrlKey, altKey;
        string delayedProperties, delayedMainProperties;
        bool altToggle = false;
        Button[] menuButtons;

        public WindowInformation(MainForm mf)
        {
            this.mf = mf;
            shiftKey = new KeyboardKey(Keys.ShiftKey);
            ctrlKey = new KeyboardKey(Keys.ControlKey);
            altKey = new KeyboardKey(Keys.Menu);
            InitializeComponent();
            menuButtons = new Button[] {
                menuButton1, menuButton2, menuButton3, 
                menuButton4, menuButton5, menuButton6,
                menuButton7, menuButton8, menuButton9
            };
            clearCopied_Click(null, null);
            defaultPanel.BringToFront();
            menuPanel.BringToFront();
            listPanel.BringToFront();
            infoPanel.BringToFront();
            tmrUpdate.Enabled = true;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            int shiftState = shiftKey.AsyncState;
            int altState = altKey.AsyncState;
            int ctrlState = ctrlKey.AsyncState;
            if (menuMode != 0)
            {
                switch (menuMode)
                {
                    case 1: // in menu
                        {
                            if (ctrlState >= 0)
                            {
                                menuMode = 0;
                                menuPanel.Visible = false;
                            }
                            else if (shiftState < 0)
                            {
                                InvokeMenu(menuIndex);
                                return;
                            }
                            else
                            {
                                if (MousePosition.X / 5 > lastX && menuIndex % 3 != 2)
                                    menuIndex++;
                                if (MousePosition.X / 5 < lastX && menuIndex % 3 != 0)
                                    menuIndex--;
                                if (MousePosition.Y / 5 > lastY && menuIndex < 6)
                                    menuIndex += 3;
                                if (MousePosition.Y / 5 < lastY && menuIndex >= 3)
                                    menuIndex -= 3;
                                menuButtons[menuIndex].Select();
                            }
                            lastX = MousePosition.X / 5;
                            lastY = MousePosition.Y / 5;
                        }
                        break;
                    case 2: // move/resize
                        if (shiftState >= 0)
                        {
                            infoPanel.Visible = false;
                            menuMode = 1;
                            lastX = MousePosition.X / 5;
                            lastY = MousePosition.Y / 5;
                        }
                        else
                        {
                            Rectangle r = windowData.Window.Position.ToRectangle();
                            if (menuIndex == 0)
                            {
                                r.Location = new Point(MousePosition.X + lastX, MousePosition.Y + lastY);
                            }
                            else
                            {
                                r.Size = new Size(MousePosition.X + lastX, MousePosition.Y + lastY);
                            }
                            windowData.Window.Position = RECT.FromRectangle(r);
                        }
                        break;
                    case 3: // select
                        if (shiftState >= 0)
                        {
                            if (menuListBox.Focused && menuListBox.Items.Count > 0)
                            {
                                switch (menuIndex)
                                {
                                    case 1: // Toggle enabled
                                        windowData.Window.Enabled = menuListBox.SelectedIndex == 0;
                                        break;
                                    case 2: // Toggle visible
                                        windowData.Window.VisibilityFlag = menuListBox.SelectedIndex == 0;
                                        break;
                                    case 3: // Select Parent or Ancestor
                                        goto case 5;
                                    case 5: // Select Child  
                                        SystemWindow sw = (SystemWindow)menuListBox.SelectedItem;
                                        if (sw != null) UpdateProperties(sw);
                                        break;
                                    case 6: // Advanced
                                        // unused
                                        break;
                                }
                            }
                            listPanel.Visible = false;
                            menuMode = 1;
                        }
                        else
                        {
                            if (menuListBox.Focused && menuListBox.Items.Count > 0)
                            {
                                if (MousePosition.Y / 5 > lastY)
                                    menuListBox.SelectedIndex = (menuListBox.SelectedIndex + 1) % menuListBox.Items.Count;
                                if (MousePosition.Y / 5 < lastY)
                                    menuListBox.SelectedIndex = (menuListBox.SelectedIndex + menuListBox.Items.Count) % menuListBox.Items.Count;
                            }
                            if (MousePosition.X / 5 > lastX)
                                menuListBox.Focus();
                            if (MousePosition.X / 5 < lastX)
                                menuCancel.Focus();
                        }
                        lastX = MousePosition.X / 5;
                        lastY = MousePosition.Y / 5;
                        break;
                    case 4: // Change/Scroll Tab
                        if (shiftState >= 0)
                        {
                            menuPanel.Visible = true;
                            menuMode = 1;
                        }
                        else
                        {
                            if (tabs.SelectedIndex <= 1)
                            {
                                TextBox tb = tabs.SelectedIndex == 1 ? parentProperties : windowProperties;
                                if (MousePosition.Y / 5 > lastY)
                                {
                                    int pos = tb.SelectionStart;
                                    pos = tb.Text.IndexOf('\n', pos);
                                    if (pos == -1) tb.Select(tb.Text.Length, 0);
                                    else tb.Select(pos + 1, 0);
                                    tb.ScrollToCaret();
                                }
                                if (MousePosition.Y / 5 < lastY)
                                {
                                    int pos = tb.SelectionStart;
                                    pos = tb.Text.LastIndexOf("\n", pos);
                                    if (pos == -1) tb.Select(0, 0);
                                    else tb.Select(pos - 2, 0);
                                    tb.ScrollToCaret();
                                }
                            }

                            if (MousePosition.X / 5 > lastX)
                                tabs.SelectedIndex = 1;
                            if (MousePosition.X / 5 < lastX)
                                tabs.SelectedIndex = 0;
                        }
                        lastX = MousePosition.X / 5;
                        lastY = MousePosition.Y / 5;
                        break;
                    default:
                        break;
                }
                return;
            }
            if (ctrlMenu.Checked && ctrlState < 0)
            {
                menuPanel.Visible = true;
                menuMode = 1;
                menuIndex = 4;
                menuButtons[4].Select();
                lastX = MousePosition.X / 5;
                lastY = MousePosition.Y / 5;
                Text = "Window Information (Menu)";
                return;
            }
            if (altState < 0 && altToggleTab.Checked)
            {
                altToggle = true;
                tabs.SelectedIndex = 1;
            }
            else if (altToggle)
            {
                altToggle = false;
                tabs.SelectedIndex = 0;
            }
            if (MousePosition.X != lastX || MousePosition.Y != lastY)
            {
                delaycount = 50;
                delay.Text = "Delay";
                lastX = MousePosition.X;
                lastY = MousePosition.Y;
                if (avoidMouse.Checked && shiftState >= 0)
                {
                    if (lastX >= Left && lastY >= Top && lastX <= Left + Width && lastY <= Top + Height)
                    {
                        Screen cs = Screen.FromPoint(Location);
                        int ll = cs.WorkingArea.Width - (Left + Width - cs.WorkingArea.X) + cs.WorkingArea.X;
                        int tt = cs.WorkingArea.Height - (Top + Height - cs.WorkingArea.Y) + cs.WorkingArea.Y;
                        Location = new Point(ll, tt);
                        if (lastX >= Left && lastY >= Top && lastX <= Left + Width && lastY <= Top + Height)
                        {
                            Location = new Point(5, 5);
                        }
                    }
                }
                SystemWindow sw = SystemWindow.FromPointEx(lastX, lastY, false, false);
                UpdateProperties(sw);
                if (tabs.SelectedIndex == 1)
                {
                    this.Text = "Window Information (Relative: " + (lastX - copiedX) + "," + (lastY - copiedY) + ")";
                }
                else
                {
                    this.Text = "Window Information (Mouse: " + lastX + "," + lastY + ")";
                }
            }
            else
            {
                if (delaycount > 0)
                {
                    delaycount--;
                    if (delaycount < 40)
                        delay.Text = "" + delaycount / 10;
                    if (delaycount < 10)
                    {
                        delaycount = -1;
                        if (delayedUpdate.Checked)
                        {
                            windowProperties.Text = delayedProperties;
                            parentProperties.Text = delayedMainProperties;
                        }
                        if (autoCopy.Checked)
                        {
                            copied.Items.Insert(1, new CopiedWindow(windowData, windowProperties.Text, parentData, parentProperties.Text));
                            delay.Text = "Copied";
                        }
                        else
                        {
                            delay.Text = "Delay";
                        }
                    }
                }
            }
        }

        private void UpdateProperties(SystemWindow sw)
        {
            if (!delayedUpdate.Checked && (sw.HWnd == windowProperties.Handle || sw.HWnd == parentProperties.Handle))
            {
                windowProperties.Text = "(recursive)";
                parentProperties.Text = "(recursive)";
            }
            delayedProperties = getWindowProperties(sw);
            windowData = new WindowData(mf, sw);
            SystemWindow swParent = sw.ParentSymmetric;
            while (swParent != null)
            {
                sw = swParent;
                swParent = sw.ParentSymmetric;
            }
            delayedMainProperties = getWindowProperties(sw);
            parentData = new WindowData(mf, sw);
            if (!delayedUpdate.Checked)
            {
                windowProperties.Text = delayedProperties;
                parentProperties.Text = delayedMainProperties;
            }
        }

        private void InvokeMenu(int menuIndex)
        {
            switch (menuIndex)
            {
                case 0: // Move
                    menuMode = 2;
                    lastX = windowData.Window.Position.Left - MousePosition.X;
                    lastY = windowData.Window.Position.Top - MousePosition.Y;
                    infoPanel.Visible = true;
                    infoPanel.BringToFront();
                    break;
                case 1: // Toggle Enabled
                    menuMode = 3;
                    menuListBox.Items.Clear();
                    menuListBox.Items.Add("Enabled");
                    menuListBox.Items.Add("Disabled");
                    menuListBox.SelectedIndex = windowData.Window.Enabled ? 1 : 0;
                    break;
                case 2: // Toggle Visible
                    menuMode = 3;
                    menuListBox.Items.Clear();
                    menuListBox.Items.Add("Visible");
                    menuListBox.Items.Add("Invisible");
                    menuListBox.SelectedIndex = windowData.Window.VisibilityFlag ? 1 : 0;
                    break;
                case 3: // Select Parent or Ancestor
                    menuMode = 3;
                    menuListBox.Items.Clear();
                    SystemWindow ww = windowData.Window;
                    while (ww != null)
                    {
                        menuListBox.Items.Add(ww);
                        ww = ww.ParentSymmetric;
                    }
                    break;
                case 4: // Change/Scroll Tab
                    menuMode = 4;
                    menuPanel.Visible = false;
                    break;
                case 5: // Select Child
                    menuMode = 3;
                    menuListBox.Items.Clear();
                    foreach (SystemWindow c in windowData.Window.AllChildWindows)
                    {
                        menuListBox.Items.Add(c);
                    }
                    break;
                case 6: // Advanced
                    // not used
                    break;
                case 7: // Copy
                    copied.Items.Insert(1, new CopiedWindow(windowData, windowProperties.Text, parentData, parentProperties.Text));
                    break;
                case 8: // Resize
                    menuMode = 2;
                    lastX = windowData.Window.Position.Width - MousePosition.X;
                    lastY = windowData.Window.Position.Height - MousePosition.Y;
                    infoPanel.Visible = true;
                    break;
                default:
                    break;
            }
            if (menuMode == 3)
            {
                listPanel.Visible = true;
                listPanel.BringToFront();
                menuListBox.Focus();
            }
        }

        private string getWindowProperties(SystemWindow sw)
        {
            string content;
            if (includeContents.Checked)
            {
                try
                {
                    WindowContent cc = sw.Content;
                    if (cc == null)
                    {
                        content = "Unknown";
                    }
                    else
                    {
                        content = "\"" + cc.ShortDescription + "\"\r\n" +
                            cc.LongDescription.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                    }
                }
                catch (Exception ex)
                {
                    content = "\"Exception\"\r\n" + ex.ToString();
                }
            }
            else
            {
                content = "(Enable in Options tab if desired)";
            }
            return "  Handle:\t\t0x" + sw.HWnd.ToString("x8") + " (" + sw.HWnd + ")\r\n" +
                "  DialogID:\t0x" + sw.DialogID.ToString("x8") + " (" + sw.DialogID + ")\r\n" +
                "  Position:\t\t(" + sw.Position.Left + ", " + sw.Position.Top + "), " + sw.Position.Width + "x" + sw.Position.Height + "\r\n" +
                "  Parent:\t\t" + (sw.Parent == null ? "None" : (sw.ParentSymmetric == null ? "Asymmetric" : "Symmetric") + " 0x" + sw.Parent.HWnd.ToString("x8")) + "\r\n" +
                "  Appearance:\t" + (sw.Enabled ? "Enabled " : "Disabled ") + (sw.Visible ? "Visible" : "Invisible") + "\r\n" +
                "  Changable:\t" + (sw.Movable ? "Movable " : "NotMovable ") + (sw.Resizable ? "Resizable" : "FixedSize") + "\r\n" +
                "  WindowState:\t" +
                (sw.TopMost ? "TopMost " : "") + sw.WindowState.ToString() + "\r\n" +
                "  Process:\t\t" + sw.Process.ProcessName + " (0x" + sw.Process.Id.ToString("x8") + "), " +
                "\r\n" +
                "  ClassName:\t\"" + sw.ClassName + "\"\r\n" +
                "  Title:\t\t\"" + sw.Title + "\"\r\n\r\n" +
                "Content:\t" + content;
        }

        private void clearCopied_Click(object sender, EventArgs e)
        {
            copied.Items.Clear();
            copied.Items.Add(new CopiedWindow(null, "", null, ""));
            copied.SelectedIndex = 0;
        }

        private void copied_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (copied.SelectedIndex == -1 || copied.SelectedIndex == 0)
            {
                tmrUpdate.Enabled = true;
                tmrUpdate_Tick(null, null);
            }
            else
            {
                tmrUpdate.Enabled = false;
                this.Text = "Window Information (examine copied entry)";
                windowProperties.Text = ((CopiedWindow)copied.SelectedItem).Window;
                parentProperties.Text = ((CopiedWindow)copied.SelectedItem).MainWindow;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = opacityBar.Value / 25.0 + 0.2;
        }

        private void menuListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is string) e.Value = e.ListItem;
            if (e.ListItem is SystemWindow)
            {
                SystemWindow sw = (SystemWindow)e.ListItem;
                try
                {
                    string title = sw.Title;
                    if (title == "") title = "{Class: " + sw.ClassName + "}";
                    e.Value = "[" + sw.HWnd.ToString("x8") + "] " + title + (sw.VisibilityFlag ? "" : " [INV]" + (sw.Enabled ? "" : " [DIS]"));
                }
                catch (Win32Exception)
                {
                    e.Value = "[" + sw.HWnd.ToString("x8") + "] {destroyed}";
                }
            }
        }
    }

    class CopiedWindow
    {
        string title, window, mainWindow;
        WindowData windowData, mainData;
        public CopiedWindow(WindowData windowData, string window, WindowData mainData, string mainWindow)
        {
            this.title = windowData == null ? "[live display]" : windowData.Name;
            this.window = window;
            this.mainWindow = mainWindow;
            this.windowData = windowData;
            this.mainData = mainData;
        }

        public override string ToString()
        {
            return title;
        }

        public string Window { get { return window; } }
        public string MainWindow { get { return mainWindow; } }
    }
}