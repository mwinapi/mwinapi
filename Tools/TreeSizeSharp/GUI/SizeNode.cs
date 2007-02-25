using System;
using System.Collections.Generic;
using System.Text;
using TreeSizeSharp.Core;
using System.Drawing;
using ManagedWinapi;
using System.Windows.Forms;

namespace TreeSizeSharp.GUI
{
    class SizeNode
    {
        private static Icon fileIcon = MainForm.GetIconForExtension("");
        private FolderSize size;
        private ScanState state;
        private string displayName;
        private readonly string iconName;
        private FolderInfo folderInfo;
        public TreeNode treeNode;
        private readonly Icon icon;
        private List<SizeNode> directories = new List<SizeNode>();
        private List<SizeNode> fileSummaries = new List<SizeNode>();
        private List<SizeNode> fileTypeSummaries = new List<SizeNode>();
        private SizeNode dummyNode;
        private string path;

        public SizeNode(FolderInfo fi)
            : this(
            fi.DisplayName, fi.FullPath, fi.State, fi.Size, ExtendedFileInfo.GetIconForFilename(fi.FullPath, true), fi.FullPath)
        {
            this.folderInfo = fi;
            directories = null; // not loaded yet
            if (fi.State == ScanState.SCANNING || fi.State == ScanState.DONE)
            {
                FillInFiles();
            }
            BuildDummyNode();
        }

        private void BuildDummyNode()
        {
            dummyNode = new SizeNode("DummyNodeNeverVisible", null, ScanState.QUEUED, folderInfo.AllFilesSize, fileIcon, null);
            dummyNode.dummyNode = dummyNode; // self-pointer to identify dummy nodes
        }

        public SizeNode(string displayName, string iconName, ScanState state, FolderSize size, Icon icon, string path)
        {
            this.displayName = displayName;
            this.iconName = iconName;
            this.state = state;
            this.size = size;
            this.icon = icon;
            this.path = path;
            if (icon == null) throw new ArgumentNullException();
        }

        public List<SizeNode> Directories { get { return directories; } }
        public List<SizeNode> FileSummaries { get { return fileSummaries; } }
        public List<SizeNode> FileTypeSummaries { get { return fileTypeSummaries; } }
        public FolderInfo FolderInfo { get { return folderInfo; } }
        public FolderSize Size { get { return size; } }
        public string IconName { get { return iconName; } }
        public string DisplayName { get { return displayName; } }
        public Icon Icon { get { return icon; } }
        public ScanState State { get { return state; } }
        public bool ChildrenVisible { get { return directories != null; } }
        public string Path { get { return path; } }
        public SizeNode DummyNode { get { return dummyNode; } }

        public bool HasChildren
        {
            get
            {
                if (dummyNode != null) return true;
                if (fileSummaries.Count > 0) return true;
                if (directories != null)
                {
                    return directories.Count > 0;
                }
                else
                {
                    return folderInfo.Children.Count > 0;
                }
            }
        }

        public void Update()
        {
            if (folderInfo == null) return;
            this.size = folderInfo.Size;
            this.state = folderInfo.State;
            if (fileSummaries.Count == 0 && (folderInfo.State == ScanState.SCANNING || folderInfo.State == ScanState.DONE))
            {
                FillInFiles();
                // If there are no files or directories below, load "them" immediately
                // to remove the dummy node.
                if (folderInfo.Children.Count == 0 && folderInfo.AllFilesSize.fileCount == 0)
                {
                    LoadChildren();
                }
            }
        }

        private void FillInFiles()
        {
            fileSummaries.Add(new SizeNode("<Files>", "*", ScanState.DONE, FolderInfo.AllFilesSize, fileIcon, null));
            foreach (KeyValuePair<string, FolderSize> ext in folderInfo.FilesSizeByExtension)
            {
                fileTypeSummaries.Add(new SizeNode("<*." + ext.Key + ">", "*." + ext.Key, ScanState.DONE, ext.Value, MainForm.GetIconForExtension(ext.Key), null));
            }
        }

        public void PrepareRefresh(bool expandAfter)
        {
            lock (folderInfo)
            {
                folderInfo.State = expandAfter ? ScanState.EXPANDQUEUED : ScanState.QUEUED;
                folderInfo.Children.Clear();
            }
            directories = null;
            fileSummaries.Clear();
            fileTypeSummaries.Clear();
            BuildDummyNode();
            Update();
        }

        public void LoadChildren()
        {
            if (directories == null && folderInfo != null)
            {
                directories = new List<SizeNode>();
                foreach (FolderInfo child in folderInfo.Children)
                {
                    directories.Add(new SizeNode(child));
                }
                dummyNode = null;
            }
        }

        private void Unlink()
        {
            if (folderInfo == null) return;
            if (state != ScanState.DONE) throw new Exception();
            LoadChildren();
            folderInfo = null;
            displayName += "*";
        }

        internal void RemoveChild(SizeNode s)
        {
            Unlink();
            directories.Remove(s);
            fileSummaries.Remove(s);
            size.Subtract(s.Size);
        }

        internal void PrefixName(SizeNode parent)
        {
            string prefix = parent.displayName;
            if (prefix.EndsWith("*")) prefix = prefix.Substring(0, prefix.Length - 1);
            displayName = prefix + "/" + displayName;
        }
    }
}
