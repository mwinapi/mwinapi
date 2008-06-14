using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ManagedWinapi.Windows;
using ManagedWinapi.Accessibility;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WinternalExplorer
{
    internal abstract class TreeNodeData
    {
        internal MainForm mf;
        internal TreeNodeData(MainForm mf)
        {
            this.mf = mf;
        }
        internal abstract IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly);
        internal abstract bool HasChildren(WindowCache wc, bool visibleOnly);
        internal abstract string Name { get;}
        internal abstract int Icon { get;}
        internal abstract ChildControl Details { get;}

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            if (mf != ((TreeNodeData)obj).mf) return false;
            return EqualsInternal((TreeNodeData)obj);
        }

        public override int GetHashCode()
        {
            return 42;
        }

        protected abstract bool EqualsInternal(TreeNodeData tnd);
    }

    internal abstract class SelectableTreeNodeData : TreeNodeData
    {
        internal SelectableTreeNodeData(MainForm mf) : base(mf) { }
        internal abstract IList<TreeNodeData> PossibleParents { get;}
    }

    internal class RootData : TreeNodeData
    {
        public RootData(MainForm mf)
            : base(mf)
        {
        }

        internal override bool HasChildren(WindowCache wc, bool visibleOnly)
        {
            return GetChildren(wc, visibleOnly).Count > 0;
        }

        internal override IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly)
        {
            IList<TreeNodeData> cc = (IList<TreeNodeData>)wc.Get(this);
            if (cc == null)
            {

                if (mf.DisplayProcesses == 1)
                {
                    cc = ProcessData.GetAllProcesses(wc, mf, visibleOnly);
                }
                else if (mf.DisplayProcesses == 2)
                {
                    cc = ProcessData.GetToplevelProcesses(wc, mf, visibleOnly);
                }
                else
                {
                    cc = ThreadData.GetThreadsOrBelow(wc, mf, null, visibleOnly);
                }
                wc.Add(this, cc);
            }
            return cc;
        }

        internal override string Name
        {
            get { return "All Processes"; }
        }

        internal override int Icon { get { return 0; } }

        internal override ChildControl Details
        {
            get { return NoneControl.Instance; }
        }

        protected override bool EqualsInternal(TreeNodeData tnd)
        {
            return true;
        }
    }

    internal class ProcessData : TreeNodeData
    {
        readonly Process process;

        internal Process Process { get { return process; } }

        internal ProcessData(MainForm mf, Process process)
            : base(mf)
        {
            this.process = process;
        }
        internal override bool HasChildren(WindowCache wc, bool visibleOnly)
        {
            if (mf.DisplayProcesses == 2)
            {
                return ThreadData.HasThreadsOrBelow(wc, mf, process, visibleOnly)
                    || HasChildProcesses(wc, mf, visibleOnly);
            }
            else
            {
                return ThreadData.HasThreadsOrBelow(wc, mf, process, visibleOnly);
            }
        }

        internal override IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly)
        {
            if (mf.DisplayProcesses == 2)
            {
                List<TreeNodeData> result = new List<TreeNodeData>();
                result.AddRange(ThreadData.GetThreadsOrBelow(wc, mf, process, visibleOnly));
                result.AddRange(GetChildProcesses(wc, mf, process.Id, visibleOnly));
                return result;
            }
            else
            {
                return ThreadData.GetThreadsOrBelow(wc, mf, process, visibleOnly);
            }
        }

        private bool HasChildProcesses(WindowCache wc, MainForm mf, bool visibleOnly)
        {
            if (visibleOnly)
            {
                foreach (Process p in wc.ChildProcesses(this.process.Id))
                {
                    if (wc.IsProcessVisible(p)) return true;
                }
                return false;
            }
            else
            {
                return wc.ChildProcesses(this.process.Id).Count > 0;
            }
        }

        private static IList<TreeNodeData> GetChildProcesses(WindowCache wc, MainForm mf, int pid, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            foreach (Process p in wc.ChildProcesses(pid))
            {
                if (!visibleOnly || wc.IsProcessVisible(p))
                    result.Add(new ProcessData(mf, p));
            }
            sortProcesses(result);
            return result;
        }

        private static void sortProcesses(List<TreeNodeData> result)
        {
            result.Sort(delegate(TreeNodeData a, TreeNodeData b)
            {
                return a.Name.CompareTo(b.Name);
            });
        }

        internal override string Name
        {
            get { return process.ProcessName; }
        }

        internal override int Icon
        {
            get { return 0; }
        }

        internal static IList<TreeNodeData> GetAllProcesses(WindowCache wc, MainForm mf, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            foreach (Process p in Process.GetProcesses())
            {
                if (!visibleOnly || wc.IsProcessVisible(p))
                    result.Add(new ProcessData(mf, p));
            }
            sortProcesses(result);
            return result;
        }

        internal override ChildControl Details
        {
            get { return ProcessControl.Instance; }
        }

        protected override bool EqualsInternal(TreeNodeData tnd)
        {
            return ((ProcessData)tnd).process.Id == process.Id;
        }

        internal static IList<TreeNodeData> GetToplevelProcesses(WindowCache wc, MainForm mf, bool visibleOnly)
        {
            return GetChildProcesses(wc, mf, 0, visibleOnly);
        }
    }

    internal class ThreadData : TreeNodeData
    {
        readonly Process process;
        readonly ProcessThread thread;

        internal ProcessThread Thread { get { return thread; } }

        public ThreadData(MainForm mf, Process process, ProcessThread thread)
            : base(mf)
        {
            this.process = process;
            this.thread = thread;
        }

        internal override bool HasChildren(WindowCache wc, bool visibleOnly)
        {
            return WindowData.HasWindowsOrBelow(wc, mf, process, thread, visibleOnly);
        }
        internal override IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly)
        {
            return WindowData.GetWindowsOrBelow(wc, mf, process, thread, visibleOnly);
        }

        internal override string Name
        {
            get { return process.ProcessName + "." + thread.Id.ToString("x8"); }
        }

        internal override int Icon
        {
            get { return 1; }
        }


        internal static bool HasThreadsOrBelow(WindowCache wc, MainForm mf, Process process, bool visibleOnly)
        {
            if (mf.DisplayThreads)
            {
                if (process == null) return true; // there must be at least the thread executing this code :)
                if (visibleOnly)
                {
                    foreach (ProcessThread pt in process.Threads)
                    {
                        if (wc.IsThreadVisible(pt)) return true;
                    }
                    return false;
                }
                return process.Threads.Count > 0;
            }
            else
            {
                return WindowData.HasWindowsOrBelow(wc, mf, process, null, visibleOnly);
            }
        }

        internal static IList<TreeNodeData> GetThreadsOrBelow(WindowCache wc, MainForm mf, Process parent, bool visibleOnly)
        {
            if (mf.DisplayThreads)
            {
                return GetThreads(wc, mf, parent, visibleOnly);
            }
            else
            {
                return WindowData.GetWindowsOrBelow(wc, mf, parent, null, visibleOnly);
            }
        }

        internal static IList<TreeNodeData> GetThreads(WindowCache wc, MainForm mf, Process parent, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            if (parent == null)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    foreach (ProcessThread t in p.Threads)
                    {
                        if (!visibleOnly || wc.IsThreadVisible(t))
                            result.Add(new ThreadData(mf, p, t));
                    }
                }
            }
            else
            {
                foreach (ProcessThread t in parent.Threads)
                {
                    if (!visibleOnly || wc.IsThreadVisible(t))
                        result.Add(new ThreadData(mf, parent, t));
                }
            }
            return result;
        }

        internal override ChildControl Details
        {
            get { return ThreadControl.Instance; }
        }

        protected override bool EqualsInternal(TreeNodeData tnd)
        {
            return ((ThreadData)tnd).thread.Id.Equals(thread.Id);
        }
    }

    internal class WindowData : SelectableTreeNodeData
    {
        readonly SystemWindow sw;

        internal SystemWindow Window { get { return sw; } }

        public WindowData(MainForm mf, SystemWindow sw)
            : base(mf)
        {
            this.sw = sw;
        }

        internal override IList<TreeNodeData> PossibleParents
        {
            get
            {
                List<TreeNodeData> result = new List<TreeNodeData>();
                SystemWindow curr = sw;
                SystemWindow last = curr;
                while (curr != null)
                {
                    result.Add(new WindowData(mf, curr));
                    last = curr;
                    curr = curr.ParentSymmetric;
                }
                result.Add(new ThreadData(mf, last.Process, last.Thread));
                result.Add(new ProcessData(mf, last.Process));
                return result;
            }
        }

        internal override bool HasChildren(WindowCache wc, bool visibleOnly)
        {
            if (mf.DisplayWindows == 2)
            {
                foreach (SystemWindow w in sw.AllChildWindows)
                {
                    if (!visibleOnly || w.Visible)
                        return true;
                }
            }
            if (mf.DisplayAccObjs)
            {


                if (sw == null) throw new Exception();
                try
                {
                    SystemAccessibleObject sao = SystemAccessibleObject.FromWindow(sw, AccessibleObjectID.OBJID_WINDOW);
                    if (!visibleOnly || sao.Visible)
                        return true;
                }
                catch (COMException) { }
            }
            return false;
        }
        internal override IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            if (mf.DisplayWindows == 2)
            {
                foreach (SystemWindow w in sw.AllChildWindows)
                {
                    if (!visibleOnly || w.Visible)
                        result.Add(new WindowData(mf, w));
                }
            }
            if (mf.DisplayAccObjs)
            {
                AccessibilityData.AddAccessibleObjects(result, mf, sw, visibleOnly);
            }
            return result;
        }

        internal override string Name
        {
            get
            {
                try
                {
                    string title = sw.Title;
                    if (title == "") title = "{Class: " + sw.ClassName + "}";
                    return "[" + sw.HWnd.ToString("x8") + "] " + title;
                }
                catch (Win32Exception)
                {
                    return "[" + sw.HWnd.ToString("x8") + "] {destroyed}";
                }
            }
        }

        internal override int Icon
        {
            get { return sw.VisibilityFlag ? 2 : 3; }
        }

        internal override ChildControl Details
        {
            get { return WindowControl.Instance; }
        }

        protected override bool EqualsInternal(TreeNodeData tnd)
        {
            return ((WindowData)tnd).sw.HWnd == sw.HWnd;
        }


        internal static bool HasWindowsOrBelow(WindowCache wc, MainForm mf, Process proc, ProcessThread thread, bool visibleOnly)
        {
            if (mf.DisplayWindows > 0)
            {
                if (proc == null) return true;
                if (thread == null) return wc.WindowsByProcess(proc, visibleOnly).Count > 0;
                return wc.WindowsByThread(thread, visibleOnly).Count > 0;
            }
            else
            {
                return AccessibilityData.HasAccessibilityObjectsOrBelow(wc, mf, proc, thread, null, visibleOnly);
            }
        }


        public static IList<TreeNodeData> GetWindowsOrBelow(WindowCache wc, MainForm mf, Process proc, ProcessThread thread, bool visibleOnly)
        {
            if (mf.DisplayWindows > 0)
            {
                return GetWindows(wc, mf, proc, thread, visibleOnly);
            }
            else
            {
                return AccessibilityData.GetAccessibilityObjectsOrBelow(wc, mf, proc, thread, null, visibleOnly);
            }
        }

        private static IList<TreeNodeData> GetWindows(WindowCache wc, MainForm mf, Process proc, ProcessThread thread, bool visibleOnly)
        {
            IList<SystemWindow> windows;
            if (thread != null) windows = wc.WindowsByThread(thread, visibleOnly);
            else if (proc != null) windows = wc.WindowsByProcess(proc, visibleOnly);
            else if (visibleOnly) windows = wc.AllVisibleWindows;
            else windows = wc.AllWindows;
            List<TreeNodeData> result = new List<TreeNodeData>();
            foreach (SystemWindow w in windows)
            {
                result.Add(new WindowData(mf, w));
            }
            return result;
        }
    }

    internal class AccessibilityData : SelectableTreeNodeData
    {

        readonly SystemAccessibleObject accobj;

        internal SystemAccessibleObject AccObj { get { return accobj; } }

        internal AccessibilityData(MainForm mf, SystemAccessibleObject sao)
            : base(mf)
        {
            accobj = sao;
        }

        public static IList<TreeNodeData> GetAccessibilityObjectsOrBelow(WindowCache wc, MainForm mf, Process proc, ProcessThread thread, SystemWindow sw, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            if (mf.DisplayAccObjs)
            {
                if (sw != null)
                {
                    AddAccessibleObjects(result, mf, sw, visibleOnly);
                }
                else
                {
                    IList<SystemWindow> windows;
                    if (thread != null)
                    {
                        windows = wc.WindowsByThread(thread, visibleOnly);
                    }
                    else if (proc != null)
                    {
                        windows = wc.WindowsByProcess(proc, visibleOnly);
                    }
                    else if (visibleOnly)
                    {
                        windows = wc.AllVisibleWindows;
                    }
                    else
                    {
                        windows = wc.AllWindows;
                    }
                    foreach (SystemWindow w in windows)
                    {
                        AddAccessibleObjects(result, mf, w, visibleOnly);
                    }
                }
            }
            return result;
        }

        internal static void AddAccessibleObjects(List<TreeNodeData> result, MainForm mf, SystemWindow sw, bool visibleOnly)
        {
            if (sw == null) throw new Exception();
            try
            {
                SystemAccessibleObject sao = SystemAccessibleObject.FromWindow(sw, AccessibleObjectID.OBJID_WINDOW);
                if (!visibleOnly || sao.Visible)
                    result.Add(new AccessibilityData(mf, sao));
            }
            catch (COMException) { }
        }

        internal static bool HasAccessibilityObjectsOrBelow(WindowCache wc, MainForm mf, Process proc, ProcessThread thread, SystemWindow sw, bool visibleOnly)
        {
            if (!mf.DisplayAccObjs) return false;
            if (sw != null)
            {
                return true;
            }
            else
            {
                IList<SystemWindow> windows;
                if (thread != null)
                {
                    windows = wc.WindowsByThread(thread, visibleOnly);
                }
                else if (proc != null)
                {
                    windows = wc.WindowsByProcess(proc, visibleOnly);
                }
                else
                {
                    return true;
                }
                return windows.Count > 0;
            }
        }

        internal override IList<TreeNodeData> GetChildren(WindowCache wc, bool visibleOnly)
        {
            List<TreeNodeData> result = new List<TreeNodeData>();
            foreach (SystemAccessibleObject child in accobj.Children)
            {
                if (mf.DisplayWindows != 2 || child.Window.HWnd == accobj.Window.HWnd)
                {
                    if (!visibleOnly || child.Visible)
                        result.Add(new AccessibilityData(mf, child));
                }
            }
            return result;
        }

        internal override bool HasChildren(WindowCache wc, bool visibleOnly)
        {
            if (visibleOnly)
            {
                foreach (SystemAccessibleObject child in accobj.Children)
                {
                    if (child.Visible) return true;
                }
                return false;
            }
            else
            {
                return accobj.Children.Length != 0;
            }
        }

        internal override string Name
        {
            get
            {
                try
                {
                    return accobj.Name;
                }
                catch (COMException)
                { return "?"; }
            }
        }

        internal override int Icon
        {
            get { return accobj.Visible ? 4 : 5; }
        }

        internal override ChildControl Details
        {
            get { return AccessibilityControl.Instance; }
        }

        protected override bool EqualsInternal(TreeNodeData tnd)
        {
            return ((AccessibilityData)tnd).accobj.Equals(this.accobj);
        }

        internal override IList<TreeNodeData> PossibleParents
        {
            get
            {
                List<TreeNodeData> result = new List<TreeNodeData>();
                SystemWindow parent = accobj.Window;
                WindowData wd = new WindowData(mf, parent);
                result.Add(wd);
                result.AddRange(wd.PossibleParents);
                SystemAccessibleObject curr = accobj;
                while (curr != null)
                {
                    result.Add(new AccessibilityData(mf, curr));
                    curr = curr.Parent;
                }
                return result;
            }
        }
    }
}
