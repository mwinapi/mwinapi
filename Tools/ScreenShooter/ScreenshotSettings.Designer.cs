namespace ScreenShooter
{
    partial class ScreenshotSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenshotSettings));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.setHotkeyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.shapeOption = new System.Windows.Forms.CheckBox();
            this.scrollingAreaOption = new System.Windows.Forms.RadioButton();
            this.objectOption = new System.Windows.Forms.RadioButton();
            this.cursorOption = new System.Windows.Forms.CheckBox();
            this.clientAreaOption = new System.Windows.Forms.RadioButton();
            this.windowOption = new System.Windows.Forms.RadioButton();
            this.fullScreenOption = new System.Windows.Forms.RadioButton();
            this.autodetectScrollOption = new System.Windows.Forms.RadioButton();
            this.wmPrintScrollOption = new System.Windows.Forms.RadioButton();
            this.wmPrintClientScrollOption = new System.Windows.Forms.RadioButton();
            this.vWheelScrollOption = new System.Windows.Forms.RadioButton();
            this.hWheelScrollOption = new System.Windows.Forms.RadioButton();
            this.scrollingAreaBox = new System.Windows.Forms.GroupBox();
            this.vBarScrollOption = new System.Windows.Forms.RadioButton();
            this.hBarScrollOption = new System.Windows.Forms.RadioButton();
            this.shortcutBox = new ManagedWinapi.ShortcutBox();
            this.hotkey = new ManagedWinapi.Hotkey(this.components);
            label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.scrollingAreaBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(3, 241);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(369, 54);
            label1.TabIndex = 12;
            label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.shortcutBox);
            this.groupBox2.Controls.Add(this.setHotkeyButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hot&key";
            // 
            // setHotkeyButton
            // 
            this.setHotkeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setHotkeyButton.Location = new System.Drawing.Point(221, 19);
            this.setHotkeyButton.Name = "setHotkeyButton";
            this.setHotkeyButton.Size = new System.Drawing.Size(43, 23);
            this.setHotkeyButton.TabIndex = 3;
            this.setHotkeyButton.Text = "&Set";
            this.setHotkeyButton.UseVisualStyleBackColor = true;
            this.setHotkeyButton.Click += new System.EventHandler(this.setHotkeyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shapeOption);
            this.groupBox1.Controls.Add(this.scrollingAreaOption);
            this.groupBox1.Controls.Add(this.objectOption);
            this.groupBox1.Controls.Add(this.cursorOption);
            this.groupBox1.Controls.Add(this.clientAreaOption);
            this.groupBox1.Controls.Add(this.windowOption);
            this.groupBox1.Controls.Add(this.fullScreenOption);
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 181);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Content";
            // 
            // shapeOption
            // 
            this.shapeOption.AutoSize = true;
            this.shapeOption.Enabled = false;
            this.shapeOption.Location = new System.Drawing.Point(7, 135);
            this.shapeOption.Name = "shapeOption";
            this.shapeOption.Size = new System.Drawing.Size(127, 17);
            this.shapeOption.TabIndex = 11;
            this.shapeOption.Text = "Keep Window S&hape";
            this.shapeOption.UseVisualStyleBackColor = true;
            // 
            // scrollingAreaOption
            // 
            this.scrollingAreaOption.AutoSize = true;
            this.scrollingAreaOption.Location = new System.Drawing.Point(6, 111);
            this.scrollingAreaOption.Name = "scrollingAreaOption";
            this.scrollingAreaOption.Size = new System.Drawing.Size(90, 17);
            this.scrollingAreaOption.TabIndex = 9;
            this.scrollingAreaOption.Text = "&Scrolling Area";
            this.scrollingAreaOption.UseVisualStyleBackColor = true;
            this.scrollingAreaOption.CheckedChanged += new System.EventHandler(this.contentOption_CheckedChanged);
            // 
            // objectOption
            // 
            this.objectOption.AutoSize = true;
            this.objectOption.Location = new System.Drawing.Point(6, 88);
            this.objectOption.Name = "objectOption";
            this.objectOption.Size = new System.Drawing.Size(56, 17);
            this.objectOption.TabIndex = 8;
            this.objectOption.Text = "&Object";
            this.objectOption.UseVisualStyleBackColor = true;
            this.objectOption.CheckedChanged += new System.EventHandler(this.contentOption_CheckedChanged);
            // 
            // cursorOption
            // 
            this.cursorOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorOption.AutoSize = true;
            this.cursorOption.Location = new System.Drawing.Point(6, 158);
            this.cursorOption.Name = "cursorOption";
            this.cursorOption.Size = new System.Drawing.Size(129, 17);
            this.cursorOption.TabIndex = 10;
            this.cursorOption.Text = "Include Mouse &Cursor";
            this.cursorOption.UseVisualStyleBackColor = true;
            // 
            // clientAreaOption
            // 
            this.clientAreaOption.AutoSize = true;
            this.clientAreaOption.Location = new System.Drawing.Point(6, 65);
            this.clientAreaOption.Name = "clientAreaOption";
            this.clientAreaOption.Size = new System.Drawing.Size(76, 17);
            this.clientAreaOption.TabIndex = 7;
            this.clientAreaOption.Text = "Client &Area";
            this.clientAreaOption.UseVisualStyleBackColor = true;
            this.clientAreaOption.CheckedChanged += new System.EventHandler(this.contentOption_CheckedChanged);
            // 
            // windowOption
            // 
            this.windowOption.AutoSize = true;
            this.windowOption.Location = new System.Drawing.Point(6, 42);
            this.windowOption.Name = "windowOption";
            this.windowOption.Size = new System.Drawing.Size(64, 17);
            this.windowOption.TabIndex = 6;
            this.windowOption.Text = "&Window";
            this.windowOption.UseVisualStyleBackColor = true;
            this.windowOption.CheckedChanged += new System.EventHandler(this.contentOption_CheckedChanged);
            // 
            // fullScreenOption
            // 
            this.fullScreenOption.AutoSize = true;
            this.fullScreenOption.Checked = true;
            this.fullScreenOption.Location = new System.Drawing.Point(6, 19);
            this.fullScreenOption.Name = "fullScreenOption";
            this.fullScreenOption.Size = new System.Drawing.Size(78, 17);
            this.fullScreenOption.TabIndex = 5;
            this.fullScreenOption.TabStop = true;
            this.fullScreenOption.Text = "&Full Screen";
            this.fullScreenOption.UseVisualStyleBackColor = true;
            this.fullScreenOption.CheckedChanged += new System.EventHandler(this.contentOption_CheckedChanged);
            // 
            // autodetectScrollOption
            // 
            this.autodetectScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autodetectScrollOption.AutoSize = true;
            this.autodetectScrollOption.Checked = true;
            this.autodetectScrollOption.Location = new System.Drawing.Point(6, 19);
            this.autodetectScrollOption.Name = "autodetectScrollOption";
            this.autodetectScrollOption.Size = new System.Drawing.Size(196, 17);
            this.autodetectScrollOption.TabIndex = 0;
            this.autodetectScrollOption.TabStop = true;
            this.autodetectScrollOption.Text = "Auto&detect (try the next four options)";
            this.autodetectScrollOption.UseVisualStyleBackColor = true;
            // 
            // wmPrintScrollOption
            // 
            this.wmPrintScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wmPrintScrollOption.AutoSize = true;
            this.wmPrintScrollOption.Location = new System.Drawing.Point(6, 42);
            this.wmPrintScrollOption.Name = "wmPrintScrollOption";
            this.wmPrintScrollOption.Size = new System.Drawing.Size(112, 17);
            this.wmPrintScrollOption.TabIndex = 1;
            this.wmPrintScrollOption.Text = "Send &WM_PRINT";
            this.wmPrintScrollOption.UseVisualStyleBackColor = true;
            // 
            // wmPrintClientScrollOption
            // 
            this.wmPrintClientScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wmPrintClientScrollOption.AutoSize = true;
            this.wmPrintClientScrollOption.Location = new System.Drawing.Point(6, 65);
            this.wmPrintClientScrollOption.Name = "wmPrintClientScrollOption";
            this.wmPrintClientScrollOption.Size = new System.Drawing.Size(150, 17);
            this.wmPrintClientScrollOption.TabIndex = 2;
            this.wmPrintClientScrollOption.Text = "Send WM_PRINTC&LIENT";
            this.wmPrintClientScrollOption.UseVisualStyleBackColor = true;
            // 
            // vWheelScrollOption
            // 
            this.vWheelScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vWheelScrollOption.AutoSize = true;
            this.vWheelScrollOption.Location = new System.Drawing.Point(6, 88);
            this.vWheelScrollOption.Name = "vWheelScrollOption";
            this.vWheelScrollOption.Size = new System.Drawing.Size(175, 17);
            this.vWheelScrollOption.TabIndex = 3;
            this.vWheelScrollOption.Text = "Send &vertical scroll wheel event";
            this.vWheelScrollOption.UseVisualStyleBackColor = true;
            // 
            // hWheelScrollOption
            // 
            this.hWheelScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hWheelScrollOption.AutoSize = true;
            this.hWheelScrollOption.Location = new System.Drawing.Point(6, 111);
            this.hWheelScrollOption.Name = "hWheelScrollOption";
            this.hWheelScrollOption.Size = new System.Drawing.Size(186, 17);
            this.hWheelScrollOption.TabIndex = 4;
            this.hWheelScrollOption.Text = "Send &horizontal scroll wheel event";
            this.hWheelScrollOption.UseVisualStyleBackColor = true;
            // 
            // scrollingAreaBox
            // 
            this.scrollingAreaBox.Controls.Add(this.vBarScrollOption);
            this.scrollingAreaBox.Controls.Add(this.hBarScrollOption);
            this.scrollingAreaBox.Controls.Add(this.hWheelScrollOption);
            this.scrollingAreaBox.Controls.Add(this.vWheelScrollOption);
            this.scrollingAreaBox.Controls.Add(this.wmPrintClientScrollOption);
            this.scrollingAreaBox.Controls.Add(this.wmPrintScrollOption);
            this.scrollingAreaBox.Controls.Add(this.autodetectScrollOption);
            this.scrollingAreaBox.Enabled = false;
            this.scrollingAreaBox.Location = new System.Drawing.Point(153, 57);
            this.scrollingAreaBox.Name = "scrollingAreaBox";
            this.scrollingAreaBox.Size = new System.Drawing.Size(219, 181);
            this.scrollingAreaBox.TabIndex = 11;
            this.scrollingAreaBox.TabStop = false;
            this.scrollingAreaBox.Text = "Scrolling Area";
            // 
            // vBarScrollOption
            // 
            this.vBarScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vBarScrollOption.AutoSize = true;
            this.vBarScrollOption.Location = new System.Drawing.Point(6, 135);
            this.vBarScrollOption.Name = "vBarScrollOption";
            this.vBarScrollOption.Size = new System.Drawing.Size(126, 17);
            this.vBarScrollOption.TabIndex = 9;
            this.vBarScrollOption.Text = "Use vertical scroll &bar";
            this.vBarScrollOption.UseVisualStyleBackColor = true;
            // 
            // hBarScrollOption
            // 
            this.hBarScrollOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hBarScrollOption.AutoSize = true;
            this.hBarScrollOption.Location = new System.Drawing.Point(6, 157);
            this.hBarScrollOption.Name = "hBarScrollOption";
            this.hBarScrollOption.Size = new System.Drawing.Size(137, 17);
            this.hBarScrollOption.TabIndex = 8;
            this.hBarScrollOption.Text = "&Use horizontal scroll bar";
            this.hBarScrollOption.UseVisualStyleBackColor = true;
            // 
            // shortcutBox
            // 
            this.shortcutBox.Alt = false;
            this.shortcutBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shortcutBox.Ctrl = false;
            this.shortcutBox.KeyCode = System.Windows.Forms.Keys.S;
            this.shortcutBox.Location = new System.Drawing.Point(6, 21);
            this.shortcutBox.Name = "shortcutBox";
            this.shortcutBox.Shift = false;
            this.shortcutBox.Size = new System.Drawing.Size(209, 20);
            this.shortcutBox.TabIndex = 2;
            this.shortcutBox.Text = "Windows + S";
            this.shortcutBox.WindowsKey = true;
            // 
            // hotkey
            // 
            this.hotkey.Alt = false;
            this.hotkey.Ctrl = false;
            this.hotkey.Enabled = false;
            this.hotkey.KeyCode = System.Windows.Forms.Keys.None;
            this.hotkey.Shift = false;
            this.hotkey.WindowsKey = false;
            this.hotkey.HotkeyPressed += new System.EventHandler(this.hotkey_HotkeyPressed);
            // 
            // ScreenshotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.scrollingAreaBox);
            this.Name = "ScreenshotSettings";
            this.Size = new System.Drawing.Size(375, 304);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.scrollingAreaBox.ResumeLayout(false);
            this.scrollingAreaBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ManagedWinapi.Hotkey hotkey;
        private System.Windows.Forms.Button setHotkeyButton;
        private System.Windows.Forms.RadioButton fullScreenOption;
        private System.Windows.Forms.RadioButton windowOption;
        private System.Windows.Forms.RadioButton clientAreaOption;
        private System.Windows.Forms.CheckBox cursorOption;
        private System.Windows.Forms.RadioButton objectOption;
        private System.Windows.Forms.RadioButton scrollingAreaOption;
        private System.Windows.Forms.RadioButton autodetectScrollOption;
        private System.Windows.Forms.RadioButton wmPrintScrollOption;
        private System.Windows.Forms.RadioButton wmPrintClientScrollOption;
        private System.Windows.Forms.RadioButton vWheelScrollOption;
        private System.Windows.Forms.RadioButton hWheelScrollOption;
        private System.Windows.Forms.GroupBox scrollingAreaBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal ManagedWinapi.ShortcutBox shortcutBox;
        private System.Windows.Forms.CheckBox shapeOption;
        private System.Windows.Forms.RadioButton vBarScrollOption;
        private System.Windows.Forms.RadioButton hBarScrollOption;
    }
}
