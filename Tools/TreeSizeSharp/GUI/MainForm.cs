using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ManagedWinapi;
using TreeSizeSharp.Core;
using System.Diagnostics;

namespace TreeSizeSharp.GUI
{
    public partial class MainForm : Form, IFolderView
    {
        static Dictionary<string, Icon> extensionIcons = new Dictionary<string, Icon>();
        FolderQueue fqueue = new FolderQueue();
        SizeValue sizeValue = SizeValue.PHYSICAL;
        DisplayMode displayMode = DisplayMode.MIXED;
        readonly ToolStripMenuItem[] sizeValueMenuItems, displayModeMenuItems;
        bool firstone;

        public MainForm(bool firstone)
        {
            this.firstone = firstone;
            InitializeComponent();
            sizeValueMenuItems = new ToolStripMenuItem[] {
                logicalSizeToolStripMenuItem,
                physicalSizeToolStripMenuItem,
                allocatedSpaceToolStripMenuItem,
                spaceWastedToolStripMenuItem,
                fileCountToolStripMenuItem,
                folderCountToolStripMenuItem,
                totalCountToolStripMenuItem
            };
            displayModeMenuItems = new ToolStripMenuItem[] {
                kBOnlyToolStripMenuItem,
                mBOnlyToolStripMenuItem,
                gBOnlyToolStripMenuItem,
                mixedToolStripMenuItem,
                percentToolStripMenuItem, 
                percentParentToolStripMenuItem
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new FolderScanner(fqueue, this);
            new FolderScanner(fqueue, this);
            new FolderScanner(fqueue, this);
            foreach (String drive in Directory.GetLogicalDrives())
            {
                ToolStripMenuItem mi = new ToolStripMenuItem("&" + drive, Bitmap.FromHicon(ExtendedFileInfo.GetIconForFilename(drive, true).Handle));
                mi.Tag = drive;
                mi.Click += new EventHandler(driveMenuItem_Click);
                scanToolStripMenuItem.DropDown.Items.Add(mi);
            }
            folderBrowser.SelectedPath = Directory.GetCurrentDirectory();
            ScanFolder();
        }

        void driveMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowser.SelectedPath = ((ToolStripMenuItem)sender).Tag.ToString();
            RescanFolder();
        }

        public static Icon GetIconForExtension(string extension)
        {
            if (!extensionIcons.ContainsKey(extension))
            {
                Icon ic = ExtendedFileInfo.GetExtensionIcon(extension, true);
                if (ic == null) throw new NullReferenceException("Icon for extension: " + extension);
                extensionIcons[extension] = ic;
            }
            return extensionIcons[extension];
        }

        private void ScanFolder()
        {
            filesByExtensionToolStripMenuItem.Checked = false;
            filesByExtensionToolStripMenuItem.Enabled = true;
            string directory = folderBrowser.SelectedPath;
            FolderInfo fi = new FolderInfo(null, directory, directory, 0);
            fi.State = ScanState.EXPANDQUEUED;
            SizeNode sn = new SizeNode(fi);
            nodeMap[fi] = sn;
            TreeNode tn = BuildTreeNode(sn);
            tree.Nodes.Add(tn);
            fqueue.AddFolder(fi, fqueue.Generation);
        }

        private TreeNode BuildTreeNode(SizeNode sn)
        {
            TreeNode tn = new TreeNode();
            updateTreeNode(tn, sn);
            BuildChildren(tn);
            return tn;
        }

        private void BuildChildren(TreeNode tn)
        {
            SizeNode sn = (SizeNode)tn.Tag;
            List<SizeNode> allKids = new List<SizeNode>();
            if (sn.Directories != null)
            {
                if (filesByExtensionToolStripMenuItem.Checked)
                {
                    allKids.AddRange(sn.FileTypeSummaries);
                }
                else
                {
                    allKids.AddRange(sn.FileSummaries);
                }
                allKids.AddRange(sn.Directories);
            }
            else if (sn.DummyNode != null)
            {
                allKids.Add(sn.DummyNode);
            }
            foreach (SizeNode kid in allKids)
            {
                BuildChild(tn, kid);
            }
            SortNodes(sn, tn);
        }

        private void BuildChild(TreeNode tn, SizeNode kid)
        {
            TreeNode child = new TreeNode();
            updateTreeNode(child, kid);
            tn.Nodes.Add(child);
        }

        private void updateTreeNode(TreeNode tn, SizeNode sn)
        {
            tn.ContextMenuStrip = treeMenuStrip;
            sn.treeNode = tn;
            tn.Tag = sn;
            string iconName = sn.IconName;
            if (!treeIcons.Images.ContainsKey(iconName))
            {
                treeIcons.Images.Add(iconName, sn.Icon);
            }
            tn.ImageKey = iconName;
            tn.SelectedImageKey = iconName;
            string s;
            if (tn.Parent == null)
            {
                s = SizeString(sn, sn, sn);
            }
            else
            {
                s = SizeString(sn, (SizeNode)tn.Parent.Tag, (SizeNode)tree.Nodes[0].Tag);
            }
            tn.Text = PadString(s);
            tn.Text = s + "  " + sn.DisplayName;
        }

        private Dictionary<string, string> paddedStrings = new Dictionary<string, string>();

        private string PadString(string str)
        {
            if (!paddedStrings.ContainsKey(str))
            {
                string s = str;
                Graphics g = this.CreateGraphics();
                while (g.MeasureString(s, tree.Font).Width < 64) s = " " + s;
                g.Dispose();
                paddedStrings.Add(str, s);
            }
            return paddedStrings[str];
        }

        private static readonly string FORMAT = "#,##0";

        private string SizeString(SizeNode sn, SizeNode sizeParent, SizeNode sizeRoot)
        {
            FolderSize size = sn.Size;
            ScanState ss = sn.State;
            if (ss == ScanState.QUEUED) return "QUEUED";
            if (ss == ScanState.SCANNING) return "SCAN";
            if (size.fileCount == 0 && size.folderCount == 0 && size.childrenDenied) return "DENIED";
            string den = size.childrenDenied ? "?" : "";
            ulong dsize = displayValue(size);
            if (sizeValue >= SizeValue.ALLCOUNT)
            {
                if (displayMode != DisplayMode.PERCENT && displayMode != DisplayMode.PERCENTPARENT)
                {
                    return dsize.ToString(FORMAT) + den;
                }
            }
            switch (displayMode)
            {
                case DisplayMode.KB:
                    return RoundDiv(dsize, 1024).ToString(FORMAT) + " kb" + den;
                case DisplayMode.MB:
                    return RoundDiv(dsize, 1024 * 1024).ToString(FORMAT) + " MB" + den;
                case DisplayMode.GB:
                    return RoundDiv(dsize, 1024 * 1024 * 1024).ToString(FORMAT) + " GB" + den;
                case DisplayMode.MIXED:
                    {
                        ulong kb = RoundDiv(dsize, 1024);
                        if (kb < 100 * 1024)
                            return kb.ToString(FORMAT) + " kb" + den;
                        else
                            return (kb / 1024).ToString(FORMAT) + " MB" + den;
                    }
                case DisplayMode.PERCENT:
                    return MakePercent(dsize, sizeRoot) + den;
                case DisplayMode.PERCENTPARENT:
                    return MakePercent(dsize, sizeParent) + den;
                default:
                    throw new Exception();
            }
        }

        private ulong RoundDiv(ulong size, ulong unit)
        {
            ulong result = size / unit;
            if (result == 0 && size > 0) result = 1;
            return result;
        }

        private string MakePercent(ulong size, SizeNode sizeRef)
        {
            if (size == 0) return "0%";
            if (sizeRef.State != ScanState.DONE)
            {
                return "WAIT";
            }
            ulong refval = displayValue(sizeRef.Size);
            uint percent = (uint)(size * 100 / refval);
            if (percent < 0) percent = 0;
            if (percent > 100) percent = 100;
            return percent + "%";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            fqueue.Close();
        }

        private void UpdateFolder0(TreeNode n)
        {
            UpdateFolder00(n);
        }

        private void UpdateFolder00(TreeNode n)
        {
            SizeNode sn = (SizeNode)n.Tag;
            sn.Update();
            updateTreeNode(n, sn);
            for (int i = 0; i < n.Nodes.Count; i++)
            {
                TreeNode nn = n.Nodes[i];
                SizeNode ssn = (SizeNode)nn.Tag;
                if (ssn.DummyNode == ssn && sn.DummyNode == null)
                {
                    n.Nodes.RemoveAt(i);
                }
                else
                {
                    updateTreeNode(nn, ssn);
                }
            }
            SortNodes((SizeNode)n.Tag, n);
        }

        private void SortNodes(SizeNode sn, TreeNode n)
        {
            if (n.Nodes.Count < 2) return;
            if (sn.State != ScanState.DONE) return;
            int cnt = n.Nodes.Count;
            TreeNode[] l = new TreeNode[cnt];
            for (int i = 0; i < cnt; i++)
            {
                l[i] = n.Nodes[i];
            }
            Array.Sort<TreeNode>(l, new Comparison<TreeNode>(CompareNodes));
            n.Nodes.Clear();
            for (int i = 0; i < cnt; i++)
            {
                n.Nodes.Add(l[i]);
            }
        }

        private int CompareNodes(TreeNode t1, TreeNode t2)
        {
            ulong s1 = displayValue(NodeSize(t1)), s2 = displayValue(NodeSize(t2));
            return s2.CompareTo(s1);
        }

        private ulong displayValue(FolderSize folderSize)
        {
            switch (sizeValue)
            {
                case SizeValue.PHYSICAL:
                    return folderSize.physicalSize;
                case SizeValue.LOGICAL:
                    return folderSize.logicalSize;
                case SizeValue.ALLOCATED:
                    return folderSize.diskSize;
                case SizeValue.WASTED:
                    return folderSize.diskSize - folderSize.physicalSize;
                case SizeValue.FILECOUNT:
                    return (ulong)folderSize.fileCount;
                case SizeValue.FOLDERCOUNT:
                    return (ulong)folderSize.folderCount;
                case SizeValue.ALLCOUNT:
                    return (ulong)(folderSize.fileCount + folderSize.folderCount);
                default: throw new Exception();
            }
        }

        private FolderSize NodeSize(TreeNode node)
        {
            return ((SizeNode)node.Tag).Size;
        }

        private void tree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                SizeNode sn = (SizeNode)e.Node.Tag;
                if (sn.FolderInfo != null)
                {
                    FolderInfo fi = sn.FolderInfo;
                    if (fi != null)
                    {
                        if (fi.State == ScanState.QUEUED || fi.State == ScanState.EXPANDQUEUED)
                        {
                            if (fi.State == ScanState.QUEUED)
                            {
                                fqueue.MoveToFront(fi);
                            }
                            fi.State = ScanState.EXPANDQUEUED;
                            e.Cancel = true;
                            return;
                        }
                        if (!sn.ChildrenVisible)
                        {
                            FillInChildren(sn, e.Node);
                        }
                    }
                }
            }
        }

        private void FillInChildren(SizeNode snParent, TreeNode n)
        {
            if (snParent.ChildrenVisible)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            snParent.LoadChildren();
            foreach (SizeNode sn in snParent.Directories)
            {
                TreeNode tn = BuildTreeNode(sn);
                nodeMap[sn.FolderInfo] = sn;
                n.Nodes.Add(tn);
                UpdateFolder0(tn);
            }
            foreach (SizeNode sn in filesByExtensionToolStripMenuItem.Checked ? snParent.FileTypeSummaries : snParent.FileSummaries)
            {
                TreeNode tn = BuildTreeNode(sn);
                n.Nodes.Add(tn);
            }
            snParent.Update();
            UpdateFolder0(n);
            this.Cursor = null;
        }

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowser.ShowDialog();
            if (dr == DialogResult.OK)
            {
                RescanFolder();
            }
        }

        private void RescanFolder()
        {
            fqueue.Clear();
            tree.Nodes.Clear();
            ScanFolder();
        }

        private void sizeValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SizeValue newsv = (SizeValue)((ToolStripMenuItem)sender).Tag;
            sizeValue = newsv;
            foreach (ToolStripMenuItem mi in sizeValueMenuItems)
            {
                mi.Checked = mi == sender;
            }
            UpdateNumbers(tree.Nodes[0], true);
        }

        private void UpdateNumbers(TreeNode tn, bool resort)
        {
            updateTreeNode(tn, (SizeNode)tn.Tag);
            foreach (TreeNode child in tn.Nodes)
            {
                UpdateNumbers(child, resort);
            }
            if (resort)
            {
                SortNodes((SizeNode)tn.Tag, tn);
            }
        }

        private void displayModeMenuItem_Click(object sender, EventArgs e)
        {
            DisplayMode dm = (DisplayMode)((ToolStripMenuItem)sender).Tag;
            displayMode = dm;
            foreach (ToolStripMenuItem mi in displayModeMenuItems)
            {
                mi.Checked = (mi == sender);
            }
            UpdateNumbers(tree.Nodes[0], false);
        }


        #region Interface between scanner and GUI

        Dictionary<FolderInfo, SizeNode> nodeMap = new Dictionary<FolderInfo, SizeNode>();
        public delegate void FolderDelegate(FolderInfo fi);

        public void ExpandFolder(FolderInfo fi)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new FolderDelegate(ExpandFolder), fi);
                }
                catch (ObjectDisposedException) { }
                return;
            }
            lock (this)
            {
                SizeNode sn = nodeMap[fi];
                TreeNode n = sn.treeNode;
                FillInChildren(sn, n);
                n.Expand();
            }
        }

        public void UpdateFolder(FolderInfo f)
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new FolderDelegate(UpdateFolder), f);
                }
                catch (ObjectDisposedException) { }
                return;
            }
            while (f != null && !nodeMap.ContainsKey(f))
                f = f.Parent;
            if (f != null && f.StateChanged)
                UpdateFolder99(f);
        }

        public void UpdateFolder99(FolderInfo toUpdate)
        {
            // update parents
            UpdateFolder00(nodeMap[toUpdate].treeNode);
            toUpdate.StateChanged = false;
            FolderInfo f = toUpdate.Parent;
            while (f != null && f.State == ScanState.DONE)
            {
                if (nodeMap.ContainsKey(f))
                    UpdateFolder00(nodeMap[f].treeNode);
                f = f.Parent;
            }
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MainForm(false).Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && firstone && Application.OpenForms.Count > 1)
            {
                MessageBox.Show("There are extra windows open. Close them first");
                e.Cancel = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startExplorer(false);
        }

        private void startExplorer(bool useExploreView)
        {
            ProcessStartInfo psi = new ProcessStartInfo(((SizeNode)contextMenuNode.Tag).Path);
            psi.Verb = useExploreView ? "Explore" : "Open";
            Process.Start(psi);
        }

        TreeNode contextMenuNode;

        private void treeMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            contextMenuNode = tree.GetNodeAt(tree.PointToClient(Cursor.Position));
            if (contextMenuNode == null)
            {
                SetContextMenuCommandsEnabled(false, false, false, 0, false, -1);
            }
            else
            {
                SizeNode sn = (SizeNode)contextMenuNode.Tag;
                int depth = 0;
                TreeNode tn = contextMenuNode;
                while (tn != tree.Nodes[0])
                {
                    tn = tn.Parent;
                    depth++;
                }
                SetContextMenuCommandsEnabled(sn.Path != null, sn.State == ScanState.DONE,
                    contextMenuNode == tree.Nodes[0] ? false : ((SizeNode)contextMenuNode.Parent.Tag).State == ScanState.DONE,
                    1, sn.Path != null && sn.FolderInfo != null, depth);
            }
        }

        private void SetContextMenuCommandsEnabled(bool folder, bool done, bool parentDone, int selcount, bool backed, int depth)
        {
            openToolStripMenuItem.Enabled = folder;
            exploreToolStripMenuItem.Enabled = folder;
            scanThisFolderOnlyToolStripMenuItem.Enabled = folder;
            refreshToolStripMenuItem.Enabled = backed && done;
            moveUpToolStripMenuItem.Enabled = selcount > 0 && depth > 1 && done && parentDone;
            moveUpChildrenToolStripMenuItem.Enabled = folder && depth > 0 && done;
            createGroupOfChildrenToolStripMenuItem.Enabled = folder && done;
            flattenToolStripMenuItem.Enabled = folder && done;
            combineFileEntriesToolStripMenuItem.Enabled = folder && done;
        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startExplorer(true);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SizeNode sn = (SizeNode)contextMenuNode.Tag;
            contextMenuNode.Nodes.Clear();
            sn.PrepareRefresh(contextMenuNode.IsExpanded);
            contextMenuNode.Collapse();
            updateTreeNode(contextMenuNode, sn);
            FolderInfo f = sn.FolderInfo.Parent;
            while (f != null)
            {
                lock (f)
                {
                    f.State = ScanState.SCANNING;
                }
                if (nodeMap.ContainsKey(f))
                {
                    SizeNode s = nodeMap[f];
                    s.Update();
                    TreeNode t = s.treeNode;
                    updateTreeNode(t, s);
                }
                f = f.Parent;
            }
            BuildChildren(contextMenuNode);
            fqueue.AddFolder(sn.FolderInfo, fqueue.Generation);
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesByExtensionToolStripMenuItem.Enabled = false;
            MoveUp(contextMenuNode);
        }

        private void MoveUp(TreeNode node)
        {
            TreeNode n = node;
            TreeNode nn = n.Parent;
            TreeNode nnn = nn.Parent;
            SizeNode s = (SizeNode)n.Tag;
            SizeNode ss = (SizeNode)nn.Tag;
            SizeNode sss = (SizeNode)nnn.Tag;
            s.PrefixName(ss);
            if (ss.FolderInfo != null)
                nodeMap.Remove(ss.FolderInfo);
            ss.RemoveChild(s);
            nn.Nodes.Remove(n);
            if (nn.Nodes.Count == 0)
            {
                nnn.Nodes.Remove(nn);
            }
            nnn.Nodes.Add(n);
            SortNodes(sss, nnn);
            updateTreeNode(n, s);
            updateTreeNode(nn, ss);
        }

        private void scanThisFolderOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesByExtensionToolStripMenuItem.Enabled = false;
            folderBrowser.SelectedPath = ((SizeNode)contextMenuNode.Tag).Path;
            RescanFolder();
        }

        private void moveUpChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesByExtensionToolStripMenuItem.Enabled = false;
            MoveUpChildren(contextMenuNode);
        }

        private void MoveUpChildren(TreeNode node)
        {
            FillInChildren((SizeNode)node.Tag, node);
            System.Collections.ArrayList children = new System.Collections.ArrayList(node.Nodes);
            foreach (TreeNode child in children)
            {
                MoveUp(child);
            }
        }

        private void flattenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesByExtensionToolStripMenuItem.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Flatten(contextMenuNode);
            this.Cursor = null;
        }

        private void Flatten(TreeNode node)
        {
            FillInChildren((SizeNode)node.Tag, node);
            System.Collections.ArrayList children = new System.Collections.ArrayList(node.Nodes);
            foreach (TreeNode child in children)
            {
                Flatten(child);
                MoveUpChildren(child);
            }
        }

        private void filesByExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesByExtensionToolStripMenuItem.Checked = !filesByExtensionToolStripMenuItem.Checked;
            UpdateExtensionView((SizeNode)tree.Nodes[0].Tag, filesByExtensionToolStripMenuItem.Checked);
        }

        private void UpdateExtensionView(SizeNode sn, bool showExtensions)
        {
            if (sn.Directories == null) return;
            TreeNode tn = sn.treeNode;
            foreach (SizeNode fNode in sn.FileSummaries)
            {
                if (showExtensions)
                {
                    tn.Nodes.Remove(fNode.treeNode);
                    fNode.treeNode = null;
                }
                else
                {
                    BuildChild(tn, fNode);
                }
            }
            foreach (SizeNode ftNode in sn.FileTypeSummaries)
            {
                if (!showExtensions)
                {
                    tn.Nodes.Remove(ftNode.treeNode);
                    ftNode.treeNode = null;
                }
                else
                {
                    BuildChild(tn, ftNode);
                }
            }
            foreach (SizeNode child in sn.Directories)
            {
                UpdateExtensionView(child, showExtensions);
            }
            SortNodes(sn, tn);
        }
    }

    enum SizeValue
    {
        LOGICAL, PHYSICAL, ALLOCATED, WASTED, ALLCOUNT, FILECOUNT, FOLDERCOUNT
    }

    enum DisplayMode
    {
        MIXED, KB, MB, GB, PERCENT, PERCENTPARENT
    }
}