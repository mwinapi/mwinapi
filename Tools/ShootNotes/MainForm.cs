using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ShootNotes
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            Hide();
            hideTimer.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = opacityBar.Value / 20.0;
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog.Color = colorBox.BackColor;
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
                colorBox.BackColor = colorDialog.Color;
        }

        private void shotButton_Click(object sender, EventArgs e)
        {
            Hide();
            Rectangle range = this.RectangleToScreen(rangePanel.Bounds);
            Bitmap bmp = new Bitmap(range.Width, range.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(range.Location, new Point(0, 0), range.Size);
            g.Dispose();
            NoteForm nf = new NoteForm(this);
            nf.setNote(new Note(bmp, range, colorBox.BackColor), true);

            nf.Show();
        }

        private void emptyButton_Click(object sender, EventArgs e)
        {
            Hide();
            NoteForm nf = new NoteForm(this);
            Rectangle range = this.RectangleToScreen(rangePanel.Bounds);
            nf.setNote(new Note(null, range, colorBox.BackColor), true);
            nf.Show();
        }

        internal void AddClosedNote(Note n)
        {
            noneToolStripMenuItem.Visible = false;
            ToolStripMenuItem nmi = new ToolStripMenuItem(n.Title);
            nmi.Click += new EventHandler(closedNoteMenuItem_Click);
            nmi.Tag = n;
            closedNotesToolStripMenuItem.DropDownItems.Add(nmi);
        }

        void closedNoteMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem nmi = (ToolStripMenuItem)sender;
            closedNotesToolStripMenuItem.DropDownItems.Remove(nmi);
            if (closedNotesToolStripMenuItem.DropDownItems.Count == 1)
            {
                noneToolStripMenuItem.Visible = true;
            }
            NoteForm nf = new NoteForm(this);
            Note n = (Note)nmi.Tag;
            nf.setNote((Note)nmi.Tag, false);
            nf.Show();
        }
    }
}