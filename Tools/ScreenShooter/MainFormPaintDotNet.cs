using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Diagnostics;

namespace ScreenShooter
{
    public partial class MainFormPaintDotNet : Form
    {

        int counter = 0;
        string lastScreenshot = null;

        public MainFormPaintDotNet()
        {
            InitializeComponent();
            trayIcon.Icon = this.Icon;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                settings.Settings = args[1];
            settings.EnableHotkey();
        }

        private void settings_ScreenshotTaken(Bitmap bitmap)
        {
            MainFormPaintDotNet_FormClosing(this, null);
            lastScreenshot = Path.Combine(Path.GetTempPath(), "~pdn" + counter + ".png");
            counter++;
            bitmap.Save(lastScreenshot, ImageFormat.Png);
            string path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Paint.NET", "TARGETDIR", null) as string;
            if (path == null)
            {
                MessageBox.Show("Paint.NET is not installed!");
            }
            else
            {
                Process.Start(Path.Combine(path, "PaintDotNet.exe"), "untitled:\"" + lastScreenshot+"\"");
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            Keys mask = Keys.Shift | Keys.Control;
            if ((Control.ModifierKeys & mask) == mask)
            {
                Clipboard.Clear();
                Clipboard.SetText(settings.Settings);
            }
            Visible = false;
        }

        private void MainFormPaintDotNet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lastScreenshot != null)
            {
                File.Delete(lastScreenshot);
                lastScreenshot = null;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormPaintDotNet());
        }
    }
}
