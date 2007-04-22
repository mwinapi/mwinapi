using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi;
using Microsoft.Win32;
using System.Net.Sockets;
using System.IO;

namespace ClipHancer
{
    public partial class MainForm : Form
    {
        private static readonly string REGISTRY_PATH = @"Software\SMsoft Michael Schierl\ClipHancer\0.1\ServerList";
        private static MainForm instance;
        private int counter = 0;
        private ApplicationContext ac;
        bool copying = false;
        private SharingServer ss = null;
        private Dictionary<string, string> servers = new Dictionary<string, string>();

        public static MainForm Instance { get { return instance; } }

        public MainForm(ApplicationContext ac)
        {
            this.ac = ac;
            instance = this;
            InitializeComponent();
            SetHotkeysEnabled(true);
            LoadServerList();
            fetchClipboardEntry();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e != null && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                return;
            }
            SetHotkeysEnabled(false);
            ac.ExitThread();
        }

        public void SetHotkeysEnabled(bool enabled)
        {
            try
            {
                hotkeyX.Enabled = enabled;
                hotkeyC.Enabled = enabled;
                hotkeyV.Enabled = enabled;
            }
            catch (HotkeyAlreadyInUseException)
            {
                hotkeyX.Enabled = false;
                hotkeyC.Enabled = false;
                hotkeyV.Enabled = false;
                MessageBox.Show("One or more hotkeys are already in use by another application. Disabling all hotkeys.");
            }
        }

        private void clipNotify_ClipboardChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (copying) return;
                    fetchClipboardEntry();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception while reading clipboard: " + ex.ToString());
                }
            }
            catch { } // to prevent abrupt termination of this method
        }

        private void fetchClipboardEntry()
        {
            IDataObject ido = Clipboard.GetDataObject();
            ClipboardEntry ce = new ClipboardEntry(ido);
            ce = new ClipboardEntry(ce.Serialize(), "");
            string key = "image" + (counter++);
            previewImages.Images.Add(key, ce.PreviewImage);

            ListViewItem lvi = new ListViewItem(ce.Caption, previewImages.Images.IndexOfKey(key));
            lvi.Tag = ce;
            clips.Items.Insert(0, lvi);
        }

        private void hotkeyC_HotkeyPressed(object sender, EventArgs e)
        {
            if (clips.Items.Count == 0) return;
            SetHotkeysEnabled(false);
            PopupForm pf = new PopupForm('c', "copy", "c = cycle, x = select format, 0-9 = select");
            pf.Visible = true;
            pf.Focus();
        }

        private void hotkeyX_HotkeyPressed(object sender, EventArgs e)
        {
            if (clips.Items.Count == 0) return;
            SetHotkeysEnabled(false);
            PopupForm pf = new PopupForm('x', "delete", "x = cycle, a = all, 0-9 = select");
            pf.Visible = true;
            pf.Focus();
        }

        private void hotkeyV_HotkeyPressed(object sender, EventArgs e)
        {
            if (clips.Items.Count == 0) return;
            SetHotkeysEnabled(false);
            PopupForm pf = new PopupForm('v', "paste", "v = cycle, x = select format, 0-9 = select");
            pf.Visible = true;
            pf.Focus();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_FormClosing(null, null);
            Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        internal void DoAction(char mychar, ClipboardEntry ce, int index, string format)
        {
            if (mychar == 'x')
            {
                clips.Items.RemoveAt(index);
            }
            else if (mychar == 'X')
            {
                clips.Items.Clear();
            }
            else
            {
                copying = true;
                ce.CopyToClipboard(format);
                copying = false;
                fetchClipboardEntry();
                if (mychar == 'v')
                {
                    using (new LockKeyResetter())
                    {
                        SendKeys.Send("^v");
                    }
                }
            }
        }

        internal ClipboardEntry[] LastClipboardEntries
        {
            get
            {
                int count = clips.Items.Count;
                if (count > 10) count = 10;
                ClipboardEntry[] result = new ClipboardEntry[count];
                for (int i = 0; i < count; i++)
                {
                    ListViewItem lvi = clips.Items[i];
                    result[i] = (ClipboardEntry)lvi.Tag;
                }
                return result;
            }
        }

        private void copy_Click(object sender, EventArgs e)
        {
            copying = true;
            ClipboardEntry ce = (ClipboardEntry)clips.SelectedItems[0].Tag;
            ce.CopyToClipboard();
            copying = false;
            fetchClipboardEntry();
        }

        private void clips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clips.SelectedItems.Count == 0)
            {
                copy.Enabled = false;
                delete.Enabled = false;
                share.Enabled = false;
                clips.ContextMenuStrip = null;
            }
            else
            {
                clips.ContextMenuStrip = copyStrip;
                copy.Enabled = true;
                delete.Enabled = true;
                share.Enabled = true;
                while (copyStrip.Items.Count > 3)
                {
                    copyStrip.Items.RemoveAt(3);
                }
                ClipboardEntry ce = (ClipboardEntry)clips.SelectedItems[0].Tag;
                bool firstSep = true;
                foreach (String s in ce.Formats)
                {
                    if (s == null)
                    {
                        copyStrip.Items.Add(new ToolStripSeparator());
                        ToolStripMenuItem i = new ToolStripMenuItem(firstSep ? "Auto-converted formats:" : "Extra conversions:");
                        i.Font = storedFormatsToolStripMenuItem.Font;
                        i.Enabled = false;
                        copyStrip.Items.Add(i);
                        firstSep = false;
                    }
                    else
                    {
                        ToolStripMenuItem i = new ToolStripMenuItem(s);
                        i.Click += new EventHandler(copyFormat_Click);
                        copyStrip.Items.Add(i);
                    }
                }

            }
        }

        void copyFormat_Click(object sender, EventArgs e)
        {
            copying = true;
            ClipboardEntry ce = (ClipboardEntry)clips.SelectedItems[0].Tag;
            ce.CopyToClipboard(((ToolStripMenuItem)sender).Text);
            copying = false;
            fetchClipboardEntry();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            clips.Items.RemoveAt(clips.SelectedIndices[0]);
        }

        private void clearClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clips.Items.Clear();
            clips_SelectedIndexChanged(null, null);
        }

        private void share_Click(object sender, EventArgs e)
        {
            if (clips.SelectedItems.Count == 0) return;
            if (ss == null) ss = new SharingServer();
            ss.Share((ClipboardEntry)clips.SelectedItems[0].Tag);
        }

        private void stopSharingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ss != null)
            {
                ss.StopSharing();
                ss = null;
            }
        }


        private void LoadServerList()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_PATH, false);
            if (key != null)
            {
                foreach (string server in key.GetValueNames())
                {
                    servers.Add(server, (string)key.GetValue(server));
                }
                key.Close();
            }
        }

        private void SaveServerList()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_PATH, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (key != null)
            {
                foreach (String valueName in key.GetValueNames())
                {
                    key.DeleteValue(valueName);
                }
                foreach (KeyValuePair<string, string> p in servers)
                {
                    key.SetValue(p.Key, p.Value);
                }
            }
            key.Close();
        }

        private void receive_Click(object sender, EventArgs e)
        {
            while (onReceiveStrip.Items.Count > 2)
            {
                onReceiveStrip.Items.RemoveAt(0);
            }
            byte[] buff = new byte[4096];
            int len;
            foreach (KeyValuePair<string, string> p in servers)
            {
                TcpClient c;
                try
                {
                    c = new TcpClient(p.Value, 5120);
                }
                catch (SocketException)
                {
                    continue;
                }
                Stream s = c.GetStream();
                MemoryStream ms = new MemoryStream();
                while ((len = s.Read(buff, 0, buff.Length)) != 0)
                {
                    ms.Write(buff, 0, len);
                }
                c.Close();
                ClipboardEntry pe = new ClipboardEntry(ms.ToArray(), "[" + p.Key + "] ");
                ToolStripMenuItem mi = new ToolStripMenuItem(pe.Caption, pe.PreviewImage);
                mi.Click += new EventHandler(receivedItem_Click);
                mi.Tag = pe;
                onReceiveStrip.Items.Insert(0, mi);
            }
            onReceiveStrip.Show(receive, new Point(receive.Width, receive.Height), ToolStripDropDownDirection.AboveLeft);
        }

        void receivedItem_Click(object sender, EventArgs e)
        {
            ClipboardEntry ce = (ClipboardEntry)((ToolStripMenuItem)sender).Tag;
            copying = true;
            ce.CopyToClipboard();
            copying = false;
            fetchClipboardEntry();
        }

        private void copyServerListToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("# Servers for ClipHancer\r\n# Use lines servername=ip\r\n# Example: test=192.168.0.1\r\n");
            foreach (KeyValuePair<string, string> p in servers)
            {
                sb.Append(p.Key + "=" + p.Value + "\r\n");
            }
            Clipboard.SetText(sb.ToString());
        }

        private void pasteServerListFromClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cb;
            try
            {
                cb = Clipboard.GetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not read clipboard: " + ex.ToString());
                cb = "";
            }
            servers.Clear();
            foreach (string line_ in cb.Split('\r', '\n'))
            {
                string line = line_.Trim();
                if (line.StartsWith("#") || !line.Contains("=")) continue;
                int pos = line.IndexOf('=');
                servers.Add(line.Substring(0, pos), line.Substring(pos + 1));
            }
        }

        private void clips_SizeChanged(object sender, EventArgs e)
        {
            clips.Columns[0].Width = clips.Width - 22;
        }
    }
}