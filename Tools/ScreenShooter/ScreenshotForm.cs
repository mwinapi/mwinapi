using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenShooter
{
    public partial class ScreenshotForm : Form
    {
        public ScreenshotForm(Bitmap bitmap)
        {
            InitializeComponent();
            picture.Image = bitmap;
            if (bitmap.Width > 400 || bitmap.Height > 300)
                WindowState = FormWindowState.Maximized;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetImage(picture.Image);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                picture.Image.Save(saveDialog.FileName, ImageFormat.Png);
            }
        }
    }
}
