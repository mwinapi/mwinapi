using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ManagedWinapi;
using System.ComponentModel;

namespace TreeSizeSharp.Core
{
    public class FolderInfo
    {

        private ScanState state = ScanState.QUEUED;
        private FolderSize size = new FolderSize(false);
        private List<FolderInfo> children = new List<FolderInfo>();
        private FolderSize allFilesSize = new FolderSize(false);
        private Dictionary<string, FolderSize> filesSizeByExtension = new Dictionary<string, FolderSize>();
        private readonly FolderInfo parent;
        private readonly uint clusterSizeOverride;
        readonly string fullPath;
        readonly string displayName;
        private bool stateChanged;

        public FolderInfo(FolderInfo parent, string fullPath, string displayName, uint clusterSizeOverride)
        {
            this.parent = parent;
            this.fullPath = fullPath;
            this.displayName = displayName;
            this.clusterSizeOverride = clusterSizeOverride;
        }

        public FolderSize Size { get { lock (this) { return size; } } }
        public FolderSize AllFilesSize { get { lock (this) { return allFilesSize; } } }
        public ScanState State
        {
            get { lock (this) { return state; } }
            set { lock (this) { this.state = value; } }
        }

        public Dictionary<string, FolderSize> FilesSizeByExtension
        {
            get { lock (this) { return filesSizeByExtension; } }
        }

        public string FullPath { get { return fullPath; } }
        public string DisplayName { get { return displayName; } }
        public FolderInfo Parent { get { return parent; } }

        public bool StateChanged
        {
            get { lock (this) { return stateChanged; } }
            set { lock (this) { stateChanged = value; } }
        }

        public List<FolderInfo> Children
        {
            get
            {
                return children;
            }
        }

        internal void DoScan()
        {
            bool updateSum = false;
            lock (this)
            {
                if (state != ScanState.QUEUED) throw new Exception();
                state = ScanState.SCANNING;
                stateChanged = true;
                allFilesSize.Zero();
                filesSizeByExtension.Clear();
                try
                {
                    foreach (string dir in Directory.GetDirectories(fullPath))
                    {
                        children.Add(new FolderInfo(this, dir, Path.GetFileName(dir), clusterSizeOverride));
                    }
                    children.Sort(new Comparison<FolderInfo>(delegate(FolderInfo fi1, FolderInfo fi2)
                    {
                        return fi1.DisplayName.CompareTo(fi2.DisplayName);
                    }));
                    string[] files = Directory.GetFiles(fullPath);
                    foreach (string file in files)
                    {
                        string extension;
                        string fn = Path.GetFileName(file);
                        if (fn.IndexOf(".") != -1) extension = fn.Substring(fn.LastIndexOf(".") + 1);
                        else extension = "";
                        FolderSize ext;
                        if (!filesSizeByExtension.ContainsKey(extension))
                        {
                            ext = new FolderSize(true);
                        }
                        else
                        {
                            ext = filesSizeByExtension[extension];
                        }
                        AddFileSize(ref ext, file);
                        filesSizeByExtension[extension] = ext;
                        AddFileSize(ref allFilesSize, file);
                    }
                    if (children.Count == 0)
                    {
                        // we are a leaf, so update the counts
                        updateSum = true;
                    }
                }
                catch (Exception)
                {
                    allFilesSize.Zero();
                    filesSizeByExtension.Clear();
                    updateSum = true;
                    children.Clear();
                    stateChanged = true;
                    size.childrenDenied = true;
                }
            }
            if (updateSum) UpdateSum();
        }

        private void AddFileSize(ref FolderSize sum, string path)
        {
            sum.fileCount++;
            sum.logicalSize += (ulong)new FileInfo(path).Length;
            try
            {
                ulong ps = ExtendedFileInfo.GetPhysicalFileSize(path);
                sum.physicalSize += ps;
                uint clusterSize = ExtendedFileInfo.GetClusterSize(path);
                if (clusterSizeOverride != 0) clusterSize = clusterSizeOverride;
                ulong ds = ((ps + clusterSize - 1) / clusterSize) * clusterSize;
                sum.diskSize += ds;
            }
            catch (Win32Exception ex)
            {
                throw new UnauthorizedAccessException("Cannot get file size: ", ex);
            }
        }

        private void UpdateSum()
        {
            lock (this)
            {
                if (state != ScanState.SCANNING) return;
                size.Zero();
                size.Add(allFilesSize);
                size.folderCount += children.Count;
                foreach (FolderInfo fi in children)
                {
                    if (fi.size.childrenDenied)
                    {
                        size.childrenDenied = true;
                    }
                    else if (fi.State != ScanState.DONE)
                    {
                        return; // not ready yet!
                    }
                    size.Add(fi.Size);
                }
                state = ScanState.DONE;
                stateChanged = true;
            }
            if (parent != null) parent.UpdateSum();
        }
    }

    public enum ScanState
    {
        QUEUED, SCANNING, DONE, EXPANDQUEUED
    }
}
