using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShooter
{
    public partial class MainForm : Form
    {
        public MainForm()
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
            ScreenshotForm form = new ScreenshotForm(bitmap);
            form.Icon = this.Icon;
            form.Show();
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
    }
}
