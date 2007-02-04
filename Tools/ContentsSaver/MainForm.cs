using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;
using ManagedWinapi.Windows.Contents;

namespace ContentsSaver
{
    public partial class MainForm : Form
    {
        private SystemWindow current;
        private WindowContent content;

        public MainForm()
        {
            InitializeComponent();
        }

        private void crossHair_CrosshairDragging(object sender, EventArgs e)
        {
            update();
        }

        private void crossHair_CrosshairDragged(object sender, EventArgs e)
        {
            update();
        }

        private void update()
        {
            update(SystemWindow.FromPointEx(MousePosition.X, MousePosition.Y, false, false));
        }

        private void update(SystemWindow sw)
        {
            current = sw;
            if (sw == null)
            {
                shortText.Text = "";
                saveButton.Enabled = saveAllButton.Enabled = false;
            }
            else
            {
                saveAllButton.Enabled = true;
                className.Text = sw.ClassName;
                content = sw.Content;
                if (content == null)
                {
                    shortText.Text = "<Unknown Type>";
                    saveButton.Enabled = false;
                }
                else
                {
                    shortText.Text = content.ShortDescription;
                    saveButton.Enabled = true;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TextForm tf = new TextForm();
            tf.SetText(getContent(sender == saveAllButton));
            tf.Show();
        }

        private void appendContent(StringBuilder sb, SystemWindow sw, WindowContent c) {
            if (c == null) {
                sb.AppendLine("<Unknown Type>");
                return;
            }
            sb.AppendLine(c.ShortDescription);
            sb.AppendLine("Class Name: " + sw.ClassName);
            String ldesc = c.LongDescription.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
            if (ldesc != null && c.ShortDescription != ldesc) {
                sb.AppendLine("------------------------------------------------------------");
                sb.AppendLine(ldesc);
            }
        }

        private string getContent(bool withChildren)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("************************************************************");
            appendContent(sb, current, content);
            if (withChildren)
            {
                sb.AppendLine("************************ Subitems: *************************");
                foreach (SystemWindow child in current.AllDescendantWindows)
                {
                    appendContent(sb, child, child.Content);
                    sb.AppendLine("============================================================");
                }
            }
            sb.AppendLine("************************************************************");
            sb.AppendLine("  Created by ContentsSaver, (c) 2006 Michael Schierl        ");
            return sb.ToString();
        }

        private void kbdButton_Click(object sender, EventArgs e)
        {
            kbdControls.Visible = !kbdControls.Visible;
            kbdButton.Text = kbdControls.Visible ? "<< &Keyboard" : "&Keyboard >>";
            this.Height = kbdControls.Visible ? 354 : 127;
            if (kbdControls.Visible)
            {
                windowBox.Items.Clear();
                windowBox.Items.AddRange(SystemWindow.FilterToplevelWindows(delegate(SystemWindow sw) {return sw.Visible;}));
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Height = 127;
        }

        private void windowBox_Format(object sender, ListControlConvertEventArgs e)
        {
            SystemWindow sw = (SystemWindow)e.ListItem;
            String title = sw.Title;
            if (title == "") title = "<no title>";
            e.Value = title;
        }

        private void controlBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlBox.SelectedIndex == -1) return;
            if (controlBox.SelectedItem is string)
            {
                update((SystemWindow)windowBox.SelectedItem);
            }
            else
            {
                update((SystemWindow)controlBox.SelectedItem);
            }
        }

        private void windowBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            controlBox.Items.Clear();
            if (windowBox.SelectedIndex != -1)
            {
                SystemWindow sw = (SystemWindow) windowBox.SelectedItem;
                controlBox.Items.Add("");
                controlBox.Items.AddRange(sw.AllDescendantWindows);
                controlBox.SelectedIndex = 0;
            }
        }

        private void controlBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is string)
            {
                e.Value = "(whole window)";
            }
            else
            {
                WindowContent wc = ((SystemWindow)e.ListItem).Content;
                e.Value = wc == null ? "<Unknown Type>" : wc.ShortDescription;
            }
        }
    }
}