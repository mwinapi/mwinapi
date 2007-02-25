using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TreeSizeSharp.Core
{
    class FolderQueue
    {
        Stack<FolderInfo> queue = new Stack<FolderInfo>();
        int generation = 1;

        public int Generation { get { return generation; } }

        private bool closed = false;

        public void Close()
        {
            lock (this)
            {
                closed = true;
                generation = 0;
                Monitor.PulseAll(this);
            }
        }

        public void Clear()
        {
            lock (this)
            {
                queue.Clear();
                generation++;
            }
        }

        public void AddFolder(FolderInfo fi, int gen)
        {
            AddFolders(new FolderInfo[] { fi }, gen);
        }

        public void AddFolders(IList<FolderInfo> fi, int gen)
        {
            lock (this)
            {
                if (gen != generation) return;
                if (queue.Count == 0)
                {
                    Monitor.PulseAll(this);
                }
                for (int i = fi.Count - 1; i >= 0; i--)
                {
                    if (fi[i].State != ScanState.QUEUED && fi[i].State != ScanState.EXPANDQUEUED) throw new Exception();
                    queue.Push(fi[i]);
                }
            }
        }

        public FolderInfo GetNextFolder(out int gen)
        {
            lock (this)
            {
                while (queue.Count == 0 && !closed)
                {
                    Monitor.Wait(this);
                }
                gen = generation;
                if (closed) return new FolderInfo(null, null, null, 0);
                return queue.Pop();
            }
        }

        public void MoveToFront(FolderInfo fi)
        {
            lock (this)
            {
                if (!queue.Contains(fi)) return;
                Stack<FolderInfo> tmp = new Stack<FolderInfo>();
                while (true)
                {
                    FolderInfo f = queue.Pop();
                    if (f == fi) break;
                    tmp.Push(f);
                }
                while (tmp.Count > 0)
                {
                    queue.Push(tmp.Pop());
                }
                queue.Push(fi);
            }
        }
    }
}
