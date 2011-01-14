namespace ScreenShooter
{
    partial class PluginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginForm));
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.settings = new ScreenShooter.ScreenshotSettings();
            this.doneTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(301, 21);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 42);
            this.saveSettingsButton.TabIndex = 0;
            this.saveSettingsButton.Text = "Save S&ettings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "ScreenshotSettings";
            this.saveDialog.FileName = "Custom.ScreenshotSettings";
            this.saveDialog.Filter = "Screenshot Settings Files (*.ScreenshotSettings)|*.ScreenshotSettings|All files (" +
                "*.*)|*.*";
            this.saveDialog.RestoreDirectory = true;
            this.saveDialog.Title = "Save Settings";
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(12, 12);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(376, 304);
            this.settings.TabIndex = 1;
            this.settings.ScreenshotTaken += new ScreenShooter.ScreenshotSettings.ScreenshotHandler(this.settings_ScreenshotTaken);
            // 
            // doneTimer
            // 
            this.doneTimer.Tick += new System.EventHandler(this.doneTimer_Tick);
            // 
            // PluginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 328);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PluginForm";
            this.Text = "ScreenShooter";
            this.ResumeLayout(false);

        }

        #endregion

        private ScreenshotSettings settings;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.Timer doneTimer;
    }
}

