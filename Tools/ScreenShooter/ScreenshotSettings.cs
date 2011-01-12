using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ManagedWinapi;
using ManagedWinapi.Accessibility;
using ManagedWinapi.Windows;

namespace ScreenShooter
{
    public partial class ScreenshotSettings : UserControl
    {
        /// <summary>
        /// Controls used to compute the setting string. Add new controls to the end.
        /// Remove obsolete controls by null!
        /// </summary>
        private readonly Control[] settingControls;

        public delegate void ScreenshotHandler(Bitmap bitmap);

        public event ScreenshotHandler ScreenshotTaken;

        public ScreenshotSettings()
        {
            InitializeComponent();
            settingControls = new Control[] {
                shortcutBox,
                fullScreenOption, windowOption, clientAreaOption, objectOption, scrollingAreaOption,
                cursorOption, shapeOption,
                autodetectScrollOption, wmPrintScrollOption, wmPrintClientScrollOption, 
                vWheelScrollOption, hWheelScrollOption, 
                vBarScrollOption, hBarScrollOption
            };
        }

        private void HandleScreenshot(Bitmap bitmap)
        {
            if (ScreenshotTaken != null)
                ScreenshotTaken(bitmap);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Settings
        {
            get
            {
                string[] opts = new string[settingControls.Length];
                for (int i = 0; i < settingControls.Length; i++)
                {
                    string opt;
                    Control ctrl = settingControls[i];
                    if (ctrl == null)
                        opt = "";
                    else if (ctrl is CheckBox)
                        opt = ((CheckBox)ctrl).Checked ? "1" : "0";
                    else if (ctrl is RadioButton)
                        opt = ((RadioButton)ctrl).Checked ? "1" : "0";
                    else if (ctrl is ShortcutBox)
                    {
                        ShortcutBox sb = (ShortcutBox)ctrl;
                        opt = (sb.Ctrl ? "C" : "") + (sb.Alt ? "A" : "") + (sb.Shift ? "S" : "") + (sb.WindowsKey ? "W" : "") + "+" + (int)sb.KeyCode;
                    }
                    else
                        throw new Exception("Unsupported control: " + ctrl);
                    opts[i] = opt;
                }
                return "ScreenShotSettings:" + string.Join(":", opts);
            }
            set
            {
                if (value.StartsWith("ScreenShotSettings:"))
                {
                    string[] opts = value.Substring("ScreenShotSettings:".Length).Split(':');
                    for (int i = 0; i < Math.Min(opts.Length, settingControls.Length); i++)
                    {
                        string opt = opts[i];
                        Control ctrl = settingControls[i];
                        if (ctrl == null)
                            opt = "";
                        else if (ctrl is CheckBox)
                            ((CheckBox)ctrl).Checked = (opt == "1");
                        else if (ctrl is RadioButton)
                            ((RadioButton)ctrl).Checked = (opt == "1");
                        else if (ctrl is ShortcutBox)
                        {
                            try
                            {
                                ShortcutBox sb = (ShortcutBox)ctrl;
                                string[] parts = opt.Split('+');
                                sb.KeyCode = (Keys)int.Parse(parts[1]);
                                sb.Ctrl = parts[0].Contains("C");
                                sb.Alt = parts[0].Contains("A");
                                sb.Shift = parts[0].Contains("S");
                                sb.WindowsKey = parts[0].Contains("W");
                            }
                            catch { }
                        }
                        else
                            throw new Exception("Unsupported control: " + ctrl);
                    }
                }
            }
        }

        public void EnableHotkey()
        {
            hotkey.Enabled = false;
            hotkey.WindowsKey = shortcutBox.WindowsKey;
            hotkey.Ctrl = shortcutBox.Ctrl;
            hotkey.Alt = shortcutBox.Alt;
            hotkey.Shift = shortcutBox.Shift;
            hotkey.KeyCode = shortcutBox.KeyCode;
            try
            {
                hotkey.Enabled = true;
            }
            catch (HotkeyAlreadyInUseException)
            {
                MessageBox.Show("The selected hotkey " + shortcutBox.Text + " is already used. Please configure a different hotkey.");
            }
        }

        private void setHotkeyButton_Click(object sender, EventArgs e)
        {
            EnableHotkey();
        }

        private void contentOption_CheckedChanged(object sender, EventArgs e)
        {
            cursorOption.Enabled = fullScreenOption.Checked || windowOption.Checked || clientAreaOption.Checked;
            cursorOption.Checked &= cursorOption.Enabled;
            shapeOption.Enabled = windowOption.Checked || clientAreaOption.Checked || objectOption.Checked;
            shapeOption.Checked &= shapeOption.Enabled;
            scrollingAreaBox.Enabled = scrollingAreaOption.Checked;
        }

        private void hotkey_HotkeyPressed(object sender, EventArgs e)
        {
            if (fullScreenOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeScreenshot(cursorOption.Checked));
            }
            else if (windowOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeScreenshot(SystemWindow.ForegroundWindow, false, cursorOption.Checked, shapeOption.Checked));
            }
            else if (clientAreaOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeScreenshot(SystemWindow.ForegroundWindow, true, cursorOption.Checked, shapeOption.Checked));
            }
            else if (objectOption.Checked)
            {
                SelectorForm sf = new SelectorForm(true, "");
                sf.SelectionFinished += new SelectorForm.SelectionFinishedDelegate(objectSelection_SelectionFinished);
                sf.Show();
            }
            else if (scrollingAreaOption.Checked)
            {
                List<String> extraPointMessages = new List<string>();
                bool scroll = autodetectScrollOption.Checked || hWheelScrollOption.Checked || vWheelScrollOption.Checked;
                if (vBarScrollOption.Checked)
                    extraPointMessages.Add("the down arrow of the vertical scroll bar");
                if (hBarScrollOption.Checked)
                    extraPointMessages.Add("the right arrow of the horizontal scroll bar");
                SelectorForm sf = new SelectorForm(false, " at a point inside the scroll area" + (scroll ? " where scroll wheel events can be applied" : ""), extraPointMessages.ToArray());
                sf.SelectionFinished += new SelectorForm.SelectionFinishedDelegate(scrollingSelection_SelectionFinished);
                sf.Show();
            }
        }

        private void objectSelection_SelectionFinished(Point pt, SystemWindow sw, SystemAccessibleObject accObj, Point[] extraPoints)
        {
            if (accObj != null)
                HandleScreenshot(Screenshot.TakeScreenshot(accObj, false, shapeOption.Checked));
            else
                HandleScreenshot(Screenshot.TakeScreenshot(sw, false, false, shapeOption.Checked));
        }


        void scrollingSelection_SelectionFinished(Point pt, SystemWindow sw, SystemAccessibleObject accObj, Point[] extraPoints)
        {
            if (autodetectScrollOption.Checked)
            {
                Rectangle position = sw.Position;
                Bitmap bmp = Screenshot.TakeOverlargeScreenshot(sw, false);
                if (bmp.Width == position.Width + 1 && bmp.Height == position.Height + 1)
                {
                    bmp = Screenshot.TakeOverlargeScreenshot(sw, true);
                }
                if (bmp.Width == position.Width + 1 && bmp.Height == position.Height + 1)
                {
                    bmp = Screenshot.TakeVerticalScrollingScreenshot(pt, sw, null);
                }
                if (bmp.Width == position.Width && bmp.Height == position.Height)
                {
                    KeyboardKey.InjectMouseEvent(0x0800, 0, 0, 120, UIntPtr.Zero);
                    Application.DoEvents();
                    Thread.Sleep(500);
                    Application.DoEvents();
                    bmp = Screenshot.TakeHorizontalScrollingScreenshot(pt, sw, null);
                }
                if (bmp.Width == position.Width && bmp.Height == position.Height)
                {
                    KeyboardKey.InjectMouseEvent(0x0800, 0, 0, 120, UIntPtr.Zero);
                    MessageBox.Show("Unable to create scrolling capture. You might want to try one of the manual options.");
                }
                else
                {
                    HandleScreenshot(bmp);
                }
            }
            else if (wmPrintScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeOverlargeScreenshot(sw, false));
            }
            else if (wmPrintClientScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeOverlargeScreenshot(sw, true));
            }
            else if (vWheelScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeVerticalScrollingScreenshot(pt, sw, null));
            }
            else if (hWheelScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeHorizontalScrollingScreenshot(pt, sw, null));
            }
            else if (vBarScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeVerticalScrollingScreenshot(pt, sw, extraPoints[0]));
            }
            else if (hBarScrollOption.Checked)
            {
                HandleScreenshot(Screenshot.TakeHorizontalScrollingScreenshot(pt, sw, extraPoints[0]));
            }
        }
    }
}
