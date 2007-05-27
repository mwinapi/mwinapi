using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ManagedWinapi.Windows;

namespace WinternalExplorer
{
    class WindowCache
    {
        private Dictionary<int, List<SystemWindow>> windowsByThreadId = new Dictionary<int, List<SystemWindow>>();
        private Dictionary<int, List<SystemWindow>> windowsByProcessId = new Dictionary<int, List<SystemWindow>>();
        private List<SystemWindow> windows = new List<SystemWindow>();

        private Dictionary<int, List<SystemWindow>> visibleWindowsByThreadId = new Dictionary<int, List<SystemWindow>>();
        private Dictionary<int, List<SystemWindow>> visibleWindowsByProcessId = new Dictionary<int, List<SystemWindow>>();
        private List<SystemWindow> visibleWindows = new List<SystemWindow>();

        private Dictionary<int, List<Process>> childProcesses = null;

        public WindowCache()
        {
            foreach (SystemWindow sw in SystemWindow.AllToplevelWindows)
            {
                DoAdd(sw);
            }
        }

        private void DoAdd(SystemWindow sw)
        {
            windows.Add(sw);
            AddToList(windowsByProcessId, sw.Process.Id, sw);
            AddToList(windowsByThreadId, sw.Thread.Id, sw);
            if (sw.Visible)
            {
                visibleWindows.Add(sw);
                AddToList(visibleWindowsByProcessId, sw.Process.Id, sw);
                AddToList(visibleWindowsByThreadId, sw.Thread.Id, sw);
            }
        }

        private void AddToList<T>(Dictionary<int, List<T>> list, int key, T value)
        {
            if (!list.ContainsKey(key))
                list[key] = new List<T>();
            list[key].Add(value);
        }

        public IList<SystemWindow> WindowsByThread(ProcessThread t, bool visibleOnly)
        {
            if (visibleOnly)
            {
                if (visibleWindowsByThreadId.ContainsKey(t.Id))
                    return visibleWindowsByThreadId[t.Id];
            }
            else
            {
                if (windowsByThreadId.ContainsKey(t.Id))
                    return windowsByThreadId[t.Id];
            }
            return new List<SystemWindow>();
        }

        public IList<SystemWindow> WindowsByProcess(Process p, bool visibleOnly)
        {
            if (visibleOnly)
            {
                if (visibleWindowsByProcessId.ContainsKey(p.Id))
                    return visibleWindowsByProcessId[p.Id];
            }
            else
            {
                if (windowsByProcessId.ContainsKey(p.Id))
                    return windowsByProcessId[p.Id];
            }
            return new List<SystemWindow>();
        }

        public IList<SystemWindow> AllWindows
        {
            get
            {
                return windows;
            }
        }

        public IList<SystemWindow> AllVisibleWindows
        {
            get
            {
                return visibleWindows;
            }
        }

        private Dictionary<object, object> userValues = new Dictionary<object, object>();

        public void Add(object k, object v)
        {
            userValues.Add(k, v);
        }

        public object Get(object k)
        {
            if (userValues.ContainsKey(k))
                return userValues[k];
            return null;
        }

        internal List<Process> ChildProcesses(int pid)
        {
            if (childProcesses == null)
            {
                LoadChildProcesses();
            }
            if (childProcesses.ContainsKey(pid))
                return childProcesses[pid];
            return new List<Process>();
        }

        private void LoadChildProcesses()
        {
            childProcesses = new Dictionary<int, List<Process>>();
            foreach (Process proc in Process.GetProcesses())
            {
                AddToList(childProcesses, ParentID(proc), proc);
            }
        }

        public static int ParentID(Process proc)
        {
            PerformanceCounter pc = new PerformanceCounter("Process", "Creating Process Id", proc.ProcessName);
            return (int)pc.RawValue;
        }

        internal bool IsProcessVisible(Process p)
        {
            return WindowsByProcess(p, true).Count > 0;
        }

        internal bool IsThreadVisible(ProcessThread t)
        {
            return WindowsByThread(t, true).Count > 0;
        }

        internal bool AddUnlisted(SystemWindow current)
        {
            while (current.ParentSymmetric != null)
                current = current.ParentSymmetric;
            if (!windows.Contains(current))
            {
                DoAdd(current);
                return true;
            }
            return false;
        }
    }
}
