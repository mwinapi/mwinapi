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
    public partial class ThreadControl : ChildControl
    {
        public static ThreadControl Instance = new ThreadControl();
        private ProcessThread currentThread;


        public ThreadControl()
        {
            InitializeComponent();
        }

        internal override void Update(TreeNodeData tnd, bool allowUnsafeChanges, MainForm mf)
        {
            currentThread = ((ThreadData)tnd).Thread;
            UpdateControls();
        }

        private void UpdateControls()
        {

            tid.Text = "0x" + currentThread.Id.ToString("x8") + " (" + currentThread.Id + ")";
            // General
            try
            {
                startTime.Text = currentThread.StartTime.ToString();
            }
            catch (Win32Exception)
            {
                startTime.Text = "Access denied";
            }
            startAddress.Text = "0x" + currentThread.StartAddress.ToString("x8");
            threadState.Text = currentThread.ThreadState.ToString() +
                ((currentThread.ThreadState == ThreadState.Wait)
                ? (" [" + currentThread.WaitReason.ToString() + "]")
                : "");

            //Performance
            try
            {
                priorityLevel.Text = currentThread.PriorityLevel.ToString();
            }
            catch (Win32Exception)
            {
                startTime.Text = "Access denied";
            }
            basePriority.Text = "" + currentThread.BasePriority;
            currentPriority.Text = "" + currentThread.CurrentPriority;
            try
            {
                priorityBoost.Text = currentThread.PriorityBoostEnabled ? "Yes" : "No";

                privTime.Text = currentThread.PrivilegedProcessorTime.ToString();
                userTime.Text = currentThread.UserProcessorTime.ToString();
                totalTime.Text = currentThread.TotalProcessorTime.ToString();
            }
            catch (Win32Exception)
            {
                priorityBoost.Text = "Access denied";
                privTime.Text = "Access denied";
                userTime.Text = "Access denied";
                totalTime.Text = "Access denied";
            }
        }
    }
}
