using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ManagedWinapi.Windows;

namespace DeskIconRestore
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles(".", "*.deskicon", SearchOption.TopDirectoryOnly))
            {
                filename.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string[] icons = GetDesktopIcons();
            if (icons == null) return;
            string f = filename.Text + ".deskicon";
            if (File.Exists(f))
            {
                if (MessageBox.Show("Really overwrite file?", "DeskIconRestore", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            using (StreamWriter sw = new StreamWriter(new FileStream(f, FileMode.OpenOrCreate)))
            {
                foreach (String icon in icons)
                {
                    sw.WriteLine(icon);
                }
            }
            Dispose();
        }

        private void restore_Click(object sender, EventArgs e)
        {
            SystemListView desktop = GetDesktopListView();
            if (desktop == null) return;
            string f = filename.Text + ".deskicon";
            if (!File.Exists(f))
            {
                MessageBox.Show("File not found", "DeskIconRestore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (StreamReader sr = new StreamReader(new FileStream(f, FileMode.Open, FileAccess.Read)))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    PlaceDesktopIcon(desktop, line);
                }
            }
            Dispose();
        
        }

        private string[] GetDesktopIcons()
        {
            SystemListView desktop = GetDesktopListView();
            if (desktop == null) return null;
            string[] result = new string[desktop.Count];
            string[] titles = new string[desktop.Count];
            for (int i = 0; i < desktop.Count; i++)
            {
                Point p = desktop[i].Position;
                if (Array.IndexOf<string>(titles, desktop[i].Title) != -1)
                {
                    MessageBox.Show("Warning: Duplicate icon name '" + desktop[i].Title + "'", "DeskIconRestore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                titles[i] = desktop[i].Title;
                result[i] = titles[i] + ":" + p.X + ":" + p.Y;
            }
            return result;
        }

        private void PlaceDesktopIcon(SystemListView desktop, string line)
        {
            string[] fields = line.Split(':');
            if (fields.Length != 3) return;
            for (int i = 0; i < desktop.Count; i++)
            {
                if (desktop[i].Title == fields[0]) {
                    desktop[i].Position = new Point(int.Parse(fields[1]), int.Parse(fields[2]));
                    return;
                }
            }
        }

        private SystemListView GetDesktopListView()
        {
            SystemWindow[] sws = SystemWindow.FilterToplevelWindows(delegate(SystemWindow sw)
                {
                    return sw.ClassName == "Progman" && sw.Title == "Program Manager" && sw.Process.ProcessName == "explorer";
                });
            if (sws.Length != 1)
            {
                MessageBox.Show("Could not find Desktop window");
                return null;
            }
            sws = sws[0].FilterDescendantWindows(false, delegate(SystemWindow sw)
            {
                return sw.ClassName == "SysListView32" && sw.Title == "FolderView";
            });
            if (sws.Length != 1)
            {
                MessageBox.Show("Could not find Desktop window");
                return null;
            }
            SystemListView slv = SystemListView.FromSystemWindow(sws[0]);
            if (slv == null)
            {
                MessageBox.Show("No desktop icons found");
            }
            return slv;
        }
    }
}