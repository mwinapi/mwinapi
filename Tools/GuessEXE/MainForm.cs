using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using GuessEXE.Core;
using ManagedWinapi.Windows;
using System.Diagnostics;

namespace GuessEXE
{
    public partial class MainForm : Form, IGuesserListener
    {
        Controller controller;
        List<string> attributes = new List<string>();

        public MainForm(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loglevel.SelectedIndex = 0;
        }

        private void crosshair_CrosshairDragged(object sender, EventArgs e)
        {
            SystemWindow sw = SystemWindow.FromPointEx(Cursor.Position.X, Cursor.Position.Y, true, false);
            if (autoHide.Checked)
            {
                Visible = true;
            }
            if (sw == null) return;
            log.Text = "";
            attributes.Clear();
            controller.guessWindow(this, sw);
            controller.summarize(this, attributes.ToArray());
        }


        public void guessInfo(int priority, string info)
        {
            if (priority > loglevel.SelectedIndex) return;

            for (int i = 0; i < priority; i++)
            {
                info = "\t" + info;
            }
            log.Text += info + "\r\n";
            log.SelectionStart = log.Text.Length;
        }

        public void guessAttribute(string attribute, string value)
        {
            attributes.Add(attribute + "=" + value);
        }

        private void crosshair_CrosshairDragging(object sender, EventArgs e)
        {
            if (autoHide.Checked)
            {
                Visible = false;
                crosshair.RestoreMouseCapture();
            }
        }

        private void guessAll_Click(object sender, EventArgs e)
        {
            if (loglevel.SelectedIndex == 0)
            {
                loglevel.SelectedIndex = -1;
            }
            log.Text = "";
            Process[] all = Process.GetProcesses();
            int idx = 0;
            foreach (Process p in all)
            {
                IntPtr hWnd = p.MainWindowHandle;
                bool mainModuleOk;
                try
                {
                    p.MainModule.FileName.ToString();
                    mainModuleOk = true;
                }
                catch
                {
                    mainModuleOk = false;
                    log.Text += p.ProcessName + ":\t(Access denied)\r\n";
                }
                if (mainModuleOk && hWnd == IntPtr.Zero)
                {
                    SystemWindow[] swl = SystemWindow.FilterToplevelWindows(delegate(SystemWindow sw)
                    {
                        return sw.Process.Id == p.Id;
                    });
                    if (swl.Length > 0) hWnd = swl[0].HWnd;
                }

                if (mainModuleOk && hWnd != IntPtr.Zero)
                {
                    SystemWindow sw = new SystemWindow(hWnd);
                    if (loglevel.SelectedIndex != -1)
                    {
                        log.Text += "===" + sw.Title + " (" + p.ProcessName + ") ===\r\n";
                    }
                    attributes.Clear();
                    controller.guessWindow(this, sw);
                    string summary = controller.summarize(this, attributes.ToArray());
                    if (loglevel.SelectedIndex == -1)
                    {
                        log.Text += p.ProcessName + ":\t" + summary + "\r\n";
                    }
                }
                Text = "GuessEXE - " + (++idx) + "/" + all.Length;
                Validate();
            }
            if (loglevel.SelectedIndex == -1)
            {
                loglevel.SelectedIndex = 0;
            }
            Text = "GuessEXE";
        }
    }
}