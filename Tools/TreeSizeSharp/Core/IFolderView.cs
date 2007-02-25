using System;
using System.Collections.Generic;
using System.Text;

namespace TreeSizeSharp.Core
{
    interface IFolderView
    {
        void UpdateFolder(FolderInfo toScan);

        void ExpandFolder(FolderInfo toScan);
    }
}
