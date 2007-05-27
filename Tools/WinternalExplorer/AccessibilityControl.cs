using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Accessibility;
using System.Runtime.InteropServices;

namespace WinternalExplorer
{
    public partial class AccessibilityControl : ChildControl
    {
        public static AccessibilityControl Instance = new AccessibilityControl();
        private SystemAccessibleObject currentAccObj;
        FrameForm ff;

        public AccessibilityControl()
        {
            InitializeComponent();
        }

        internal override void Update(TreeNodeData tnd, bool allowUnsafeChanges, MainForm mf)
        {
            currentAccObj = ((AccessibilityData)tnd).AccObj;
            UpdateControls();
        }

        private void UpdateControls()
        {
            outline.Checked = false;
            propChildID.Text = "" + currentAccObj.ChildID;
            propLocation.Enabled = propDefaultAction.Enabled = true;

            try { propDefaultAction.Text = currentAccObj.DefaultAction; }
            catch (COMException) { propDefaultAction.Text = "??"; }

            try
            {
                propDefaultAction.Text += " [" + currentAccObj.KeyboardShortcut + "]";
            }
            catch (COMException) { }

            try { propDescription.Text = currentAccObj.Description; }
            catch (COMException) { propDescription.Text = "??"; }

            try
            {
                Rectangle location = currentAccObj.Location;
                propLocation.Text = "(" + location.X + "," + location.Y + ")+(" + location.Width + "x" + location.Height + ")";
            }
            catch (COMException)
            {
                propLocation.Text = "??";
                propLocation.Enabled = false;
            }

            try { propName.Text = currentAccObj.Name; }
            catch (COMException) { propName.Text = "??"; }

            try
            {
                int r = currentAccObj.RoleIndex;
                propRole.Text = (r == -1 ? "" : "[" + r + "] ") + currentAccObj.RoleString;
            }
            catch (COMException) { propRole.Text = "??"; }

            try { propState.Text = "[0x" + currentAccObj.State.ToString("x") + "] " + currentAccObj.StateString; }
            catch (COMException) { propState.Text = "??"; }

            try { propValue.Text = currentAccObj.Value; }
            catch (COMException) { propValue.Text = "??"; }

            try { propWindow.Text = "[0x" + currentAccObj.Window.HWnd.ToString("x") + "] " + currentAccObj.Window.Title; }
            catch (COMException) { propWindow.Text = "??"; }
        }

        private void outline_CheckedChanged(object sender, EventArgs e)
        {
            if (ff != null)
                ff.Dispose();
            if (outline.Checked)
            {
                try
                {
                    ff = new FrameForm(currentAccObj.Location, null);
                }
                catch (COMException) { }
            }

        }

    }
}
