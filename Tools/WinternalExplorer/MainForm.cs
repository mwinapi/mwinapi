using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using ManagedWinapi.Windows;
using System.Globalization;
using ManagedWinapi.Accessibility;

namespace WinternalExplorer
{
    public partial class MainForm : Form
    {

        ChildControl selectedChild = NoneControl.Instance;
        bool autoExpand = false;

        public MainForm()
        {
            InitializeComponent();
            UpdateChildControl();
            tree.Nodes.Add("");
            tree.Nodes[0].Tag = new RootData(this);
            refreshTree(new WindowCache());
        }

        private void refreshTree(WindowCache wc)
        {
            this.Cursor = Cursors.WaitCursor;
            tree.Visible = false;
            refreshNode(wc, tree.Nodes[0], false);
            tree.Visible = true;
            this.Cursor = null;
        }

        private void refreshNode(WindowCache wc, TreeNode node, bool forceChildren)
        {
            TreeNodeData tnd = (TreeNodeData)node.Tag;
            node.ImageIndex = node.SelectedImageIndex = tnd.Icon;
            node.Text = tnd.Name;
            if (node.Nodes.Count == 1 && node.Nodes[0].Tag is string) return;
            if (node.Nodes.Count == 0 && tnd.HasChildren(wc, visibleObjectsOnlyToolStripMenuItem.Checked) && !node.IsExpanded && !forceChildren)
            {
                node.Nodes.Add("");
                node.Nodes[0].Tag = "";
                return;
            }
            IList<TreeNodeData> children = tnd.GetChildren(wc, visibleObjectsOnlyToolStripMenuItem.Checked);
            bool[] found = new bool[children.Count];
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                TreeNode n = node.Nodes[i];
                TreeNodeData nd = (TreeNodeData)n.Tag;
                int pos = children.IndexOf(nd);
                if (pos == -1)
                {
                    node.Nodes.RemoveAt(i);
                    removeFromExistingNodes(n, nd);
                    i--;
                }
                else
                {
                    found[pos] = true;
                    refreshNode(wc, n, false);
                }
            }
            for (int i = 0; i < children.Count; i++)
            {
                if (!found[i] && !existingNodes.ContainsKey(children[i]))
                {
                    TreeNode newnode = new TreeNode();
                    newnode.Tag = children[i];
                    node.Nodes.Add(newnode);
                    existingNodes.Add(children[i], newnode);
                    refreshNode(wc, newnode, false);
                }
            }
        }

        private void removeFromExistingNodes(TreeNode n, TreeNodeData nd)
        {
            existingNodes.Remove(nd);
            foreach (TreeNode tn in n.Nodes)
            {
                if (tn.Tag is TreeNodeData)
                {
                    removeFromExistingNodes(tn, (TreeNodeData)tn.Tag);
                }
            }
        }



        private void UpdateChildControl()
        {
            details.Controls.Clear();
            details.Controls.Add(selectedChild);
            selectedChild.Dock = DockStyle.Fill;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refreshTree(new WindowCache());
        }

        private static Dictionary<int, int> parentId = new Dictionary<int, int>();

        // not used
        internal static int __UNUSED__GetParentID(Process proc)
        {
            if (!parentId.ContainsKey(proc.Id))
            {
                PerformanceCounter pc = new PerformanceCounter("Process", "Creating Process Id", proc.ProcessName);
                parentId[proc.Id] = (int)pc.RawValue;
            }
            return parentId[proc.Id];
        }

        internal int DisplayProcesses
        {
            get
            {
                if (processesToolStripMenuItem.Checked) return 1;
                if (processTreeToolStripMenuItem.Checked) return 2;
                return 0;
            }
        }
        internal bool DisplayThreads
        {
            get { return threadsToolStripMenuItem.Checked; }
        }
        internal int DisplayWindows
        {
            get
            {
                if (toplevelWindowsToolStripMenuItem.Checked) return 1;
                if (allWindowsToolStripMenuItem.Checked) return 2;
                return 0;
            }
        }

        internal bool DisplayAccObjs
        {
            get { return accessibleObjectsToolStripMenuItem.Checked; }
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (autoExpand) return;
            this.Cursor = Cursors.WaitCursor;
            TreeNode n = e.Node;
            if (n.Nodes.Count == 1 && n.Nodes[0].Tag is string)
            {
                n.Nodes.Clear();
            }
            refreshNode(new WindowCache(), n, true);
            this.Cursor = null;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                selectedChild = NoneControl.Instance;
            }
            else
            {
                TreeNodeData tnd = (TreeNodeData)tree.SelectedNode.Tag;
                selectedChild = tnd.Details;
                selectedChild.Update(tnd, allowChanges.Checked, this);
            }
            UpdateChildControl();
        }

        private void ViewFilter_click(object sender, EventArgs e)
        {
            refreshTree(new WindowCache());
        }

        private void WindowViewFilter_click(object sender, EventArgs e)
        {
            toplevelWindowsToolStripMenuItem.Checked = false;
            allWindowsToolStripMenuItem.Checked = false;
            noWindowsToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            refreshTree(new WindowCache());
        }

        private void crossHair_CrosshairDragged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lastX = MousePosition.X;
            lastY = MousePosition.Y;
            UpdateSelection(true);
            this.Cursor = null;
        }

        private void UpdateSelection(bool includeTree)
        {
            SelectableTreeNodeData stnd = SelectFromPoint(lastX, lastY);
            if (!Visible) Visible = true;
            DoSelect(stnd, includeTree);
        }

        private SelectableTreeNodeData SelectFromPoint(int lastX, int lastY)
        {
            if (selAccObjs.Checked)
            {
                SystemAccessibleObject sao = SystemAccessibleObject.FromPoint(lastX, lastY);
                return new AccessibilityData(this, sao);
            }
            else
            {
                SystemWindow sw = SystemWindow.FromPointEx(lastX, lastY, selToplevel.Checked, false);
                return new WindowData(this, sw);
            }
        }

        private Dictionary<TreeNodeData, TreeNode> existingNodes = new Dictionary<TreeNodeData, TreeNode>();

        private TreeNode findNode(WindowCache wc, SelectableTreeNodeData wd)
        {
            if (wd is WindowData)
            {
                if (wc.AddUnlisted(((WindowData)wd).Window))
                {
                    MessageBox.Show("This Window is not included in EnumWindows");
                }
            }
            if (!existingNodes.ContainsKey(wd))
            {
                IList<TreeNodeData> parents = wd.PossibleParents;
                TreeNode curr = tree.Nodes[0];
                foreach (TreeNodeData p in parents)
                {
                    if (existingNodes.ContainsKey(p))
                    {
                        curr = existingNodes[p];
                        break;
                    }
                }
                while (!curr.Tag.Equals(wd))
                {
                    if (curr.Nodes.Count == 1 && curr.Nodes[0].Tag is string)
                    {
                        curr.Nodes.Clear();
                        refreshNode(wc, curr, true);
                    }
                    bool found = false;
                    foreach (TreeNodeData parent in parents)
                    {
                        foreach (TreeNode n in curr.Nodes)
                        {
                            if (n.Tag.Equals(parent))
                            {
                                curr = n;
                                found = true;
                                break;
                            }
                        }
                        if (found) break;
                    }
                    if (!found)
                    {
                        refreshNode(wc, curr, true);
                        foreach (TreeNodeData parent in parents)
                        {
                            foreach (TreeNode n in curr.Nodes)
                            {
                                if (n.Tag.Equals(parent))
                                {
                                    curr = n;
                                    found = true;
                                    break;
                                }
                            }
                            if (found) break;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("Could not find window below " + curr.Text);
                        return null;
                    }
                }
                if (existingNodes[wd] != curr) throw new Exception();
            }
            return existingNodes[wd];
        }

        int lastX = -1, lastY = -1;

        private void crossHair_CrosshairDragging(object sender, EventArgs e)
        {
            if (autoHide.Checked && Visible)
            {
                Visible = false;
                crossHair.RestoreMouseCapture();
            }
            else if (!autoHide.Checked)
            {
                if (MousePosition.X != lastX || MousePosition.Y != lastY)
                {
                    lastX = MousePosition.X;
                    lastY = MousePosition.Y;
                    UpdateSelection(false);
                    Update();
                }
            }
        }

        private void ProcessViewFilter_Click(object sender, EventArgs e)
        {
            processesToolStripMenuItem.Checked = false;
            processTreeToolStripMenuItem.Checked = false;
            noProcessesToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            if (noProcessesToolStripMenuItem.Checked)
            {
                threadsToolStripMenuItem.Enabled = false;
                threadsToolStripMenuItem.Checked = false;
            }
            else
            {
                threadsToolStripMenuItem.Enabled = true;
            }
            refreshTree(new WindowCache());
        }

        private void allowChanges_CheckedChanged(object sender, EventArgs e)
        {
            if (allowChanges.Checked)
            {
                if (MessageBox.Show(this, "Allowing unsafe changes may crash your operating system or your programs.\r\nSave all your data before enabling this.\r\n\r\nProceed anyway?", "Winternals Explorer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    allowChanges.Checked = false;
                }
            }
            selectedChild.Update(allowChanges.Checked);
        }

        private void windowsByClassNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prefix = InputBox.Show(this, "Find windows by class name starting with:", "");
            if (prefix == null) return;
            SearchResultForm srf = new SearchResultForm(this, "Windows by class name starting with \"" + prefix + "\"", prefix);
            foreach (SystemWindow sw in SystemWindow.AllToplevelWindows)
            {
                searchWindows(srf, sw, true);
            }
            srf.Finish();
        }

        private void searchWindows(SearchResultForm srf, SystemWindow sw, bool className)
        {
            srf.AddPossibleResult(new WindowData(this, sw), className ? sw.ClassName : sw.Title);
            foreach (SystemWindow cw in sw.AllChildWindows)
            {
                searchWindows(srf, cw, className);
            }
        }

        private void windowByHandleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string typed = InputBox.Show(this, "Search Window by Window handle", "");
            if (typed == null) return;
            SystemWindow sw;
            try
            {
                long hWnd;
                if (typed.StartsWith("0x"))
                {
                    hWnd = int.Parse(typed.Substring(2), NumberStyles.HexNumber);
                }
                else
                {
                    hWnd = int.Parse(typed);
                }
                sw = new SystemWindow(new IntPtr(hWnd));
            }
            catch
            {
                MessageBox.Show("Invalid number");
                return;
            }
            try
            {
                sw.ClassName.ToString();
            }
            catch
            {
                MessageBox.Show("Not found.");
                return;
            }
            DoSelect(new WindowData(this, sw), true);
        }

        internal void DoSelect(SelectableTreeNodeData wd, bool includeTree)
        {
            selectedChild = wd.Details;
            selectedChild.Update(wd, allowChanges.Checked, this);
            UpdateChildControl();
            if (!includeTree) return;
            Application.DoEvents();
            TreeNode n = findNode(new WindowCache(), wd);
            if (n != null)
            {
                autoExpand = true;
                tree.SelectedNode = n;
                autoExpand = false;
            }
        }

        private void windowInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WindowInformation(this).Show();
        }

        private void windowsByTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prefix = InputBox.Show(this, "Find windows by title starting with:", "");
            if (prefix == null) return;
            SearchResultForm srf = new SearchResultForm(this, "Windows by title starting with \"" + prefix + "\"", prefix);
            foreach (SystemWindow sw in SystemWindow.AllToplevelWindows)
            {
                searchWindows(srf, sw, false);
            }
            srf.Finish();
        }

        internal ImageList TreeImageList
        {
            get { return treeImages; }
        }

        private void stolenOrphanWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchResultForm srf = new SearchResultForm(this, "Stolen/Orphan Windows", "{.}");
            foreach (SystemWindow sw in SystemWindow.AllToplevelWindows)
            {
                searchOrphanWindows(srf, sw);
            }
            srf.Finish();
        }

        private void searchOrphanWindows(SearchResultForm srf, SystemWindow sw)
        {
            string stolenOrphan = "";
            if (sw.ParentSymmetric != null && sw.ParentSymmetric.HWnd != IntPtr.Zero)
            {
                if (sw.ParentSymmetric.Process.Id != sw.Process.Id)
                {
                    stolenOrphan = "Stolen";
                }
            }
            if (sw.Process.Id == 0)
                stolenOrphan = "Orphan";
            srf.AddPossibleResult(new WindowData(this, sw), stolenOrphan);
            foreach (SystemWindow cw in sw.AllChildWindows)
            {
                searchOrphanWindows(srf, cw);
            }
        }
    }
}