using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace TreeSizeSharp.Core
{
    class FolderScanner
    {
        private FolderQueue fq;
        IFolderView fv;

        public FolderScanner(FolderQueue fq, IFolderView fv)
        {
            this.fq = fq;
            this.fv = fv;
            Thread t = new Thread(Runner);
            t.Priority = ThreadPriority.Lowest;
            t.Start();
        }

        private void Runner()
        {
            while (true)
            {
                int gen;
                FolderInfo toScan = fq.GetNextFolder(out gen);
                if (toScan.FullPath == null) return;
                bool expandAfter = false;
                if (toScan.State == ScanState.EXPANDQUEUED)
                {
                    toScan.State = ScanState.QUEUED;
                    expandAfter = true;
                }
                toScan.DoScan();
                List<FolderInfo> c = toScan.Children;
                fq.AddFolders(c, gen);
                FolderInfo f = toScan;
                fv.UpdateFolder(f);
                if (expandAfter)
                {
                    fv.ExpandFolder(toScan);
                }
            }
        }
    }
}
