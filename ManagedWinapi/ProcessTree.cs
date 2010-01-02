/*
 * ManagedWinapi - A collection of .NET components that wrap PInvoke calls to 
 * access native API by managed code. http://mwinapi.sourceforge.net/
 * Copyright (C) 2006, 2007, 2008, 2009, 2010 Michael Schierl
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; see the file COPYING. if not, visit
 * http://www.gnu.org/licenses/lgpl.html or write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedWinapi
{
    /// <summary>
    /// Class for finding the parent and children of a <see cref="Process"/>.
    /// </summary>
    public class ProcessTree
    {

        private IDictionary<int, int> parents = new Dictionary<int, int>();

        /// <summary>
        /// Create a new process tree. This process tree stores all parent/child
        /// process relationships of the time when this process tree was created.
        /// </summary>
        public ProcessTree()
        {
            PROCESSENTRY32 procEntry = new PROCESSENTRY32();
            procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));

            IntPtr handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
            if (!Process32First(handleToSnapshot, ref procEntry))
                throw new Win32Exception();

            do
            {
                parents.Add(procEntry.th32ProcessID, procEntry.th32ParentProcessID);
            }
            while (Process32Next(handleToSnapshot, ref procEntry));

            CloseHandle(handleToSnapshot);
        }

        /// <summary>
        /// Find the parent process of a process, or <code>null</code> if no such
        /// process exists.
        /// </summary>
        /// <param name="process">Process to find parent of</param>
        public Process FindParent(Process process)
        {
            if (parents.ContainsKey(process.Id))
            {
                try
                {
                    return Process.GetProcessById((int)parents[process.Id]);
                }
                catch (ArgumentException) { } // process has terminated
            }
            return null;
        }

        /// <summary>
        /// Find the child processes of a process, i. e. those processes
        /// started by this process.
        /// </summary>
        /// <param name="process">Process to find children of</param>
        public IList<Process> FindChildren(Process process)
        {
            List<Process> childProcs = new List<Process>();

            foreach (KeyValuePair<int, int> pids in parents)
            {
                if (pids.Value == process.Id)
                {
                    try
                    {
                        childProcs.Add(Process.GetProcessById(pids.Key));
                    }
                    catch (ArgumentException) { } // process has terminated
                }
            }
            return childProcs;
        }

        #region PInvoke Declarations
        [Flags]
        private enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct PROCESSENTRY32
        {
            const int MAX_PATH = 260;
            internal uint dwSize;
            internal uint cntUsage;
            internal int th32ProcessID;
            internal IntPtr th32DefaultHeapID;
            internal uint th32ModuleID;
            internal uint cntThreads;
            internal int th32ParentProcessID;
            internal uint pcPriClassBase;
            internal uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string szExeFile;
        }

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);
        #endregion
    }
}
