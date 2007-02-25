namespace TreeSizeSharp.Core
{
    public struct FolderSize
    {
        public int fileCount;
        public int folderCount;
        public ulong logicalSize;
        public ulong physicalSize;
        public ulong diskSize;
        public bool childrenDenied;

        public FolderSize(bool zero)
        {
            fileCount = zero ? 0 : -1;
            folderCount = zero ? 0 : -1;
            logicalSize = physicalSize = diskSize = 0;
            childrenDenied = false;
        }

        internal void Zero()
        {
            fileCount = folderCount = 0;
            logicalSize = physicalSize = diskSize = 0;
        }

        internal void Add(FolderSize other)
        {
            this.fileCount += other.fileCount;
            this.folderCount += other.folderCount;
            this.logicalSize += other.logicalSize;
            this.physicalSize += other.physicalSize;
            this.diskSize += other.diskSize;
        }

        internal void Subtract(FolderSize other)
        {
            this.fileCount -= other.fileCount;
            this.folderCount -= other.folderCount;
            this.logicalSize -= other.logicalSize;
            this.physicalSize -= other.physicalSize;
            this.diskSize -= other.diskSize;
        }
    }
}