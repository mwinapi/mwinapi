using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PaintDotNet;

namespace ScreenShooter
{
    public partial class PluginForm : Form
    {
        public Bitmap ResultImage = new Bitmap(1, 1);

        public PluginForm(string settingsString)
        {
            InitializeComponent();
            settings.Settings = settingsString;
            settings.EnableHotkey();
        }

        private void settings_ScreenshotTaken(Bitmap bitmap)
        {
            if (bitmap != null)
            {
                ResultImage = bitmap;
                doneTimer.Enabled = true;
            }
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveDialog.FileName, settings.Settings, Encoding.ASCII);
            }
        }

        private void doneTimer_Tick(object sender, EventArgs e)
        {
            doneTimer.Enabled = false;
            Hide();
        }
    }

    public class ScreenShooterFileType : FileType
    {
        public ScreenShooterFileType() : base("Screenshot Settings File", FileTypeFlags.SupportsLoading, new string[] { ".ScreenshotSettings" }) { }

        protected override Document OnLoad(Stream input)
        {
            Image resultImage = null;
            Thread thread = new Thread(delegate()
            {
                PluginForm f = new PluginForm(new StreamReader(input, Encoding.ASCII).ReadToEnd());
                f.ShowDialog();
                f.Dispose();
                resultImage = f.ResultImage;
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return Document.FromImage(resultImage);
        }
    }

    public class ScreenShooterFileTypeFactory : IFileTypeFactory
    {
        public FileType[] GetFileTypeInstances()
        {
            return new FileType[] { new ScreenShooterFileType() };
        }
    }
}
