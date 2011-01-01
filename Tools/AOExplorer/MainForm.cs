using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ManagedWinapi.Windows;
using ManagedWinapi.Accessibility;

namespace AOExplorer
{
    public partial class MainForm : Form
    {

        private SystemAccessibleObject lastObject;

        public MainForm()
        {
            InitializeComponent();
            LoadProperties(null);
        }

        private void LoadAll(SystemAccessibleObject sao)
        {
            LoadProperties(sao);
            LoadTree(sao);
            tree.Enabled = true;
        }

        private void LoadTree(SystemAccessibleObject sao)
        {
            tree.Nodes.Clear();
            if (sao == null) return;
            IntPtr hwnd = sao.Window.HWnd;
            List<SystemAccessibleObject> parents = new List<SystemAccessibleObject>();
            parents.Add(sao);
            while (true)
            {
                sao = sao.Parent;
                if (sao == null) break;
                if (!allParents.Checked && sao.Window.HWnd != hwnd) break;
                parents.Add(sao);
            }
            sao = parents[parents.Count-1];
            parents.RemoveAt(parents.Count - 1);
            TreeNode curr = new TreeNode(sao.ToString());
            curr.Tag = sao;
            tree.Nodes.Add(curr);
            LoadTreeChildren(curr);
            while (parents.Count > 0)
            {
                sao = parents[parents.Count - 1];
                parents.RemoveAt(parents.Count - 1);
                TreeNode newcurr = null;
                foreach (TreeNode sub in curr.Nodes)
                {
                    if ((SystemAccessibleObject)sub.Tag == sao)
                    {
                        newcurr = sub;
                        break;
                    }
                }
                if (newcurr == null)
                {
                    foreach (TreeNode sub in curr.Nodes)
                    {
                        if (sao.Equals((SystemAccessibleObject)sub.Tag))
                        {
                            newcurr = sub;
                            break;
                        }
                    }
                }
                if (newcurr == null)
                {
                    newcurr = new TreeNode("!! " + sao.ToString());
                    newcurr.Tag = sao;
                    curr.Nodes.Add(newcurr);
                }
                curr = newcurr;
                LoadTreeChildren(curr);
            }
            tree.SelectedNode = curr;
        }

        private void LoadTreeChildren(TreeNode curr)
        {
            if (curr.Nodes.Count == 1 && curr.Nodes[0].Tag == null) {
                curr.Nodes.RemoveAt(0);
            }
            else if (curr.Nodes.Count > 0)
            {
                return;
            }
            SystemAccessibleObject sao = (SystemAccessibleObject)curr.Tag;
            SystemAccessibleObject[] selected = sao.SelectedObjects;
            SystemAccessibleObject[] children = sao.Children;
            List<SystemAccessibleObject> stepChildren = new List<SystemAccessibleObject>();
            foreach (SystemAccessibleObject o in selected)
            {
                if (Array.IndexOf<SystemAccessibleObject>(children, o) == -1)
                {
                    stepChildren.Add(o);
                }
            }
            foreach (SystemAccessibleObject o in children)
            {
                TreeNode tn = new TreeNode(o.ToString());
                tn.Tag = o;
                if (Array.IndexOf<SystemAccessibleObject>(selected, o) != -1)
                {
                    tn.Text = "* " + tn.Text;
                }
                curr.Nodes.Add(tn);
                AddIfChildren(o, tn);
            }
            foreach (SystemAccessibleObject o in stepChildren)
            {
                TreeNode tn = new TreeNode(o.ToString());
                tn.Tag = o;
                if (Array.IndexOf<SystemAccessibleObject>(selected, o) != -1)
                {
                    tn.Text = "** " + tn.Text;
                }
                else
                {
                    throw new Exception();
                }
                curr.Nodes.Add(tn);
                AddIfChildren(o, tn);
            }
        }

        private void AddIfChildren(SystemAccessibleObject o, TreeNode tn)
        {
            try
            {
                if (o.Children.Length > 0)
                {
                    tn.Nodes.Add(new TreeNode("(loading)"));
                }
            }
            catch (COMException) { }
        }

        public void SetSelectedObject(SystemAccessibleObject sao)
        {
            LoadProperties(sao);
            LoadTree(sao);
        }

        private void LoadProperties(SystemAccessibleObject sao)
        {
            if (sao == null)
            {
                propChildID.Text = "";
                propDefaultAction.Text = "(none)";
                propDescription.Text = "";
                propLocation.Text = "";
                propName.Text = "(no object selected)";
                propRole.Text = "";
                propState.Text = "";
                propValue.Text = "";
                propWindow.Text = "";
                propLocation.Enabled = propDefaultAction.Enabled = false;
            }
            else
            {
                propChildID.Text = "" + sao.ChildID;
                propLocation.Enabled = propDefaultAction.Enabled = true;


                // sao.Children not used

                try { propDefaultAction.Text = sao.DefaultAction; }
                catch (COMException) { propDefaultAction.Text = "??"; }

                try
                {
                    propDefaultAction.Text += " [" + sao.KeyboardShortcut + "]";
                }
                catch (COMException) { }

                try { propDescription.Text = sao.Description; }
                catch (COMException) { propDescription.Text = "??"; }

                // sao.IAccessible not used

                try
                {
                    Rectangle location = sao.Location;
                    propLocation.Text = "(" + location.X + "," + location.Y + ")+(" + location.Width + "x" + location.Height + ")";
                }
                catch (COMException)
                {
                    propLocation.Text = "??";
                    propLocation.Enabled = false;
                }

                try { propName.Text = sao.Name; }
                catch (COMException) { propName.Text = "??"; }

                // sao.Parent not used

                try {
                    int r = sao.RoleIndex;
                    propRole.Text = (r == -1 ? "" : "["+r+"] ")+sao.RoleString; }
                catch (COMException) { propRole.Text = "??"; }

                // sao.SelectedObjects not used

                try { propState.Text = "[0x"+sao.State.ToString("x")+"] "+sao.StateString; }
                catch (COMException) { propState.Text = "??"; }

                try
                {
                    if (includeChildren.Checked)
                    {
                        StringBuilder sb = new StringBuilder();
                        collectValues(sb, sao);
                        propValue.Text = sb.ToString();
                    }
                    else
                    {
                        propValue.Text = sao.Value;
                    }
                }
                catch (COMException ex)
                {
                    propValue.Text = "?? " + ex.ToString();
                }

                try { propWindow.Text = "[0x"+sao.Window.HWnd.ToString("x")+"] "+sao.Window.Title; }
                catch (COMException) { propWindow.Text = "??"; }
            }
            lastObject = sao;
        }

        private void collectValues(StringBuilder sb, SystemAccessibleObject sao)
        {
            try
            {
                sb.AppendLine(sao.Value);
            }
            catch (COMException) { }
            try
            {
                SystemAccessibleObject[] children = sao.Children;
                foreach (SystemAccessibleObject c in children)
                {
                    collectValues(sb, c);
                }
            }
            catch (COMException) { }
        }

        private void includeChildren_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties(lastObject);
        }

        private void selMouse_Click(object sender, EventArgs e)
        {
            LoadAll(SystemAccessibleObject.MouseCursor);
        }

        private void selCaret_Click(object sender, EventArgs e)
        {
            LoadAll(SystemAccessibleObject.Caret);
        }

        private SystemAccessibleObject highlightedObject = null;

        private void selCrosshair_CrosshairDragging(object sender, EventArgs e)
        {
            SystemAccessibleObject sao = SystemAccessibleObject.FromPoint(MousePosition.X, MousePosition.Y);
            if (highlightedObject == null || !highlightedObject.Equals(sao))
            {
                if (highlightedObject != null)
                {
                    highlightedObject.Window.Refresh();
                    highlightedObject = null;
                }
                sao.Highlight();
                highlightedObject = sao;
            }
            LoadProperties(sao);
            tree.Enabled = false;
        }

        private void selCrosshair_CrosshairDragged(object sender, EventArgs e)
        {
            selCrosshair_CrosshairDragging(sender, e);
            if (highlightedObject != null)
            {
                highlightedObject.Window.Refresh();
                highlightedObject = null;
            }
            LoadTree(lastObject);
            tree.Enabled = true;
            
        }

        private void propLocation_Click(object sender, EventArgs e)
        {
            WindowDeviceContext hdc = SystemWindow.DesktopWindow.GetDeviceContext(false);
            Graphics g = Graphics.FromHdc(hdc.HDC);
            try
            {
                Rectangle r = lastObject.Location;
                g.DrawRectangle(Pens.Blue, r.X, r.Y, r.Width, r.Height);
            }
            catch (COMException) { }
            g.Dispose();
            hdc.Dispose();
        }

        private void propDefaultAction_Click(object sender, EventArgs e)
        {
            try
            {
                lastObject.DoDefaultAction();
            }
            catch (COMException) { }
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            LoadTreeChildren(e.Node);
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadProperties((SystemAccessibleObject)tree.SelectedNode.Tag);
        }

        private void events_Click(object sender, EventArgs e)
        {
            new EventForm(this).Show();
        }
    }
}