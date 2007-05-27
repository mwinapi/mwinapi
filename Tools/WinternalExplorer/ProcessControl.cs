using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinternalExplorer
{
    public partial class ProcessControl : ChildControl
    {

        public static ProcessControl Instance = new ProcessControl();
        private Process currentProcess;
        private bool updating, allowUnsafeChanges;

        public ProcessControl()
        {
            InitializeComponent();
        }

        internal override void Update(TreeNodeData tnd, bool allowUnsafeChanges, MainForm mf)
        {
            this.allowUnsafeChanges = allowUnsafeChanges;
            currentProcess = ((ProcessData)tnd).Process;
            UpdateControls();
        }

        internal override void Update(bool allowUnsafeChanges)
        {
            this.allowUnsafeChanges = allowUnsafeChanges;
            UpdateControls();
        }

        private void UpdateControls()
        {
            updating = true;

            pid.Text = "0x" + currentProcess.Id.ToString("x8") + " (" + currentProcess.Id + ")";
            name.Text = currentProcess.ProcessName;

            try { path.Text = currentProcess.MainModule.FileName; }
            catch { path.Text = "Access Denied"; }

            machineName.Text = currentProcess.MachineName;
            mainWindow.Text = "0x" + currentProcess.MainWindowHandle.ToString("x8") + " (" +
                currentProcess.MainWindowHandle.ToInt64() + ")";
            responding.Text = currentProcess.Responding ? "Yes" : "No";

            waitForInputIdle.Enabled = allowUnsafeChanges;
            closeMainWindow.Enabled = allowUnsafeChanges;
            terminate.Enabled = allowUnsafeChanges;
            try
            {
                priority.Text = currentProcess.PriorityClass + " (" + currentProcess.BasePriority + (currentProcess.PriorityBoostEnabled ? "+Boost" : "") + ")";
            }
            catch (Win32Exception)
            {
                priority.Text = "Access denied";
            }
            modules.Items.Clear();
            try
            {
                foreach (ProcessModule pm in currentProcess.Modules)
                {
                    string pname = pm.ModuleName;
                    if (pm == currentProcess.MainModule) pname = "* " + pname;
                    modules.Items.Add(new ListViewItem(new string[] {
                         pname, "0x"+pm.BaseAddress.ToString("x8"),
                        "0x"+pm.ModuleMemorySize.ToString("x8"), 
                        pm.FileName,
                        "0x"+pm.EntryPointAddress.ToString("x8")
                    }));
                }
            }
            catch (Win32Exception)
            {
                modules.Items.Add(new ListViewItem("Access denied"));
            }

            // CPU

            long pa;

            try { pa = currentProcess.ProcessorAffinity.ToInt64(); }
            catch (Win32Exception) { pa = -1; }
            cpus.Items.Clear();
            for (int i = 0; i < System.Environment.ProcessorCount; i++)
            {
                cpus.Items.Add("CPU " + i, pa == -1 ? CheckState.Indeterminate : ((pa & 1L << i) != 0 ? CheckState.Checked : CheckState.Unchecked));
            }

            /*
            // actions

            // exited?
            currentProcess.EnableRaisingEvents;
            currentProcess.Exited;
            currentProcess.WaitForExit();
            currentProcess.HasExited;
            currentProcess.ExitCode;
            currentProcess.ExitTime;


            // performance data
            currentProcess.HandleCount;
            currentProcess.MaxWorkingSet;
            currentProcess.MinWorkingSet;
            currentProcess.NonpagedSystemMemorySize64;
            currentProcess.PagedMemorySize64;
            currentProcess.PagedSystemMemorySize64;
            currentProcess.PeakPagedMemorySize64;
            currentProcess.PeakVirtualMemorySize64;
            currentProcess.PeakWorkingSet64;
            currentProcess.PrivateMemorySize64;
            currentProcess.VirtualMemorySize64;
            currentProcess.WorkingSet64;

            

            // other
            currentProcess.PrivilegedProcessorTime;
            currentProcess.SessionId;
            currentProcess.Site;
            currentProcess.StartInfo;
            currentProcess.StartTime;
            currentProcess.TotalProcessorTime;
            currentProcess.UserProcessorTime;
            currentProcess.Container;
            currentProcess.Handle;
             */

            updating = false;
        }

        private void waitForInputIdle_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            currentProcess.WaitForInputIdle();
            this.Cursor = null;
        }

        private void closeMainWindow_Click(object sender, EventArgs e)
        {
            currentProcess.CloseMainWindow();
        }

        private void terminate_Click(object sender, EventArgs e)
        {
            currentProcess.Kill();
        }

        private void cpus_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (updating) return;
            try
            {
                long pa = currentProcess.ProcessorAffinity.ToInt64();
                long bit = 1L << e.Index;
                pa &= (~bit);
                if (e.NewValue == CheckState.Checked)
                {
                    pa |= bit;
                }
                currentProcess.ProcessorAffinity = new IntPtr(pa);
            }
            catch (Win32Exception) { }
            updateCPUsTimer.Enabled = true;
        }

        private void updateCPUsTimer_Tick(object sender, EventArgs e)
        {
            UpdateControls();
            updateCPUsTimer.Enabled = false;
        }
    }
}
