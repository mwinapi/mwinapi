using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace ClipHancer
{
    public partial class PopupForm : Form
    {
        PopupEntry[] entries = new PopupEntry[10];
        int frame = 0, framecount = 10;
        readonly char mychar;

        public PopupForm(char mychar, string action, string keyHelp)
        {
            InitializeComponent();
            ClipboardEntry[] ce = MainForm.Instance.LastClipboardEntries;
            if (ce.Length < 10) framecount = ce.Length;
            this.mychar = mychar;
            for (int i = 0; i < 10; i++)
            {
                entries[i] = new PopupEntry();
                entries[i].Index = i + 1;
                entries[i].Left = i < 5 ? 0 : 250;
                entries[i].Top = (i * 48) % 240;
                entries[i].MouseDown += PopupForm_MouseDown;
                entryBox.Controls.Add(entries[i]);
                if (i >= ce.Length)
                {
                    entries[i].Visible = false;
                }
                else
                {
                    entries[i].ClipboardEntry = ce[i];
                }
            }
            entries[frame].Framed = true;
            caption.Text += action;
            keys.Text += keyHelp;
        }

        private void PopupForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                string format = null;
                if (actionList.Visible)
                {
                    format = actionList.SelectedItem.ToString();
                    if (format.StartsWith("[")) format = format.Substring(4);
                }
                hideme();
                MainForm.Instance.DoAction(mychar, entries[frame].ClipboardEntry, frame, format);
            }
        }

        private void PopupForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (actionList.Visible)
            {
                if (e.KeyChar == 27 || e.KeyChar == mychar || e.KeyChar == char.ToUpperInvariant(mychar))
                {
                    actionList.Visible = false;
                }
                if (e.KeyChar == 'x')
                {
                    int idx = actionList.SelectedIndex + 1;
                    idx %= actionList.Items.Count;
                    while ((string)actionList.Items[idx] == "-----") idx++;
                    actionList.SelectedIndex = idx;
                }
                if (e.KeyChar == 'X')
                {
                    int idx = actionList.SelectedIndex + actionList.Items.Count - 1;
                    idx %= actionList.Items.Count;
                    while ((string)actionList.Items[idx] == "-----") idx--;
                    actionList.SelectedIndex = idx;
                }
                if (e.KeyChar >= '0' && e.KeyChar <= '9')
                {
                    for (int i = 0; i < actionList.Items.Count; i++)
                    {
                        if (((string)actionList.Items[i]).StartsWith("[" + e.KeyChar + "] "))
                        {
                            actionList.SelectedIndex = i;
                            break;
                        }
                    }
                }
                return;
            }
            if (e.KeyChar == mychar)
            {
                entries[frame].Framed = false;
                frame = (frame + 1) % framecount;
                entries[frame].Framed = true;
            }
            if (e.KeyChar == char.ToUpperInvariant(mychar))
            {
                entries[frame].Framed = false;
                frame = (frame + framecount - 1) % framecount;
                entries[frame].Framed = true;
            }
            if (e.KeyChar == 27)
            {
                hideme();
            }
            if (e.KeyChar == ' ' || e.KeyChar == 13)
            {
                hideme();
                MainForm.Instance.Visible = true;
            }
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                int newframe = (e.KeyChar - '0' + 9) % 10;
                if (newframe < framecount)
                {
                    entries[frame].Framed = false;
                    frame = newframe;
                    entries[frame].Framed = true;
                }
            }
            if (e.KeyChar == 'x' && mychar != 'x')
            {
                actionList.Items.Clear();
                int idx = 1; bool firstSep = true;
                foreach (String format in entries[frame].ClipboardEntry.Formats)
                {
                    if (format == null)
                    {
                        actionList.Items.Add("-----");
                        if (!firstSep) idx = 11;
                        firstSep = false;
                    }
                    else
                    {
                        string f = format;
                        if (idx < 10)
                        {
                            f = "[" + idx + "] " + format;
                            idx++;
                        }
                        else if (idx == 11)
                        {
                            f = "[0] " + format;
                            idx--;
                        }
                        actionList.Items.Add(f);
                    }
                }
                if (actionList.Items.Count > 0)
                {
                    actionList.SelectedIndex = 0;
                    actionList.Visible = true;
                }
            }
            if (e.KeyChar == 'a' && mychar == 'x')
            {
                hideme();
                MainForm.Instance.DoAction('X', null, 0, null);
            }
        }

        private void PopupForm_MouseDown(object sender, MouseEventArgs e)
        {
            hideme();
        }

        private void hideme()
        {
            MainForm.Instance.SetHotkeysEnabled(true);
            Dispose();
        }

        private void PopupForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                // force window to be foreground window
                SystemWindow.ForegroundWindow = new SystemWindow(this);
            }
        }
    }
}