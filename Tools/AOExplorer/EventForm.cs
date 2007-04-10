using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ManagedWinapi.Windows;
using ManagedWinapi.Accessibility;

namespace AOExplorer
{
    public partial class EventForm : Form
    {
        private MainForm mf;

        public EventForm(MainForm mf)
        {
            this.mf = mf;
            InitializeComponent();
        }

        int idx = 1, skipped = 0;

        private void listener_EventOccurred(object sender, ManagedWinapi.Accessibility.AccessibleEventArgs e)
        {
            if (nomouse.Checked && e.EventType == AccessibleEventType.EVENT_OBJECT_LOCATIONCHANGE && e.HWnd == IntPtr.Zero && e.ObjectID == (uint)AccessibleObjectID.OBJID_CURSOR) return;
            if (e.HWnd == clear.Handle || e.HWnd == skip.Handle || e.HWnd == list.Handle) return;
            if (skip.Checked)
            {
                skipped++;
                skip.Text = "Skip (" + skipped + ")";
            }
            else
            {
                ListViewItem lvi = new ListViewItem(new string[] { ""+(idx++), e.EventType.ToString(), "0x"+e.HWnd.ToString("x8"),
                "0x"+e.ObjectID.ToString("x8"), "0x"+e.ChildID.ToString("x8"), "0x"+e.Thread.ToString("x8"),
                e.Time.ToString()});
                lvi.Tag = e;
                list.Items.Add(lvi);
                lvi.EnsureVisible();
            }
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            listener.Enabled = true;
        }

        private void list_DoubleClick(object sender, EventArgs e)
        {
            if (list.SelectedIndices.Count == 0) return;
            ListViewItem lvi = list.SelectedItems[0];
            SystemAccessibleObject sao = ((AccessibleEventArgs)lvi.Tag).AccessibleObject;
            mf.SetSelectedObject(sao);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            list.Items.Clear();
            idx = 1;
            skipped = 0;
            skip.Text = "Skip";
        }
    }
}