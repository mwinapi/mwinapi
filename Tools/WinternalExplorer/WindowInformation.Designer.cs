namespace WinternalExplorer
{
    partial class WindowInformation
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.windowProperties = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.parentProperties = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.clearCopied = new System.Windows.Forms.Button();
            this.copied = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.includeContents = new System.Windows.Forms.CheckBox();
            this.autoCopy = new System.Windows.Forms.CheckBox();
            this.delayedUpdate = new System.Windows.Forms.CheckBox();
            this.ctrlMenu = new System.Windows.Forms.CheckBox();
            this.altToggleTab = new System.Windows.Forms.CheckBox();
            this.avoidMouse = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opacityBar = new System.Windows.Forms.TrackBar();
            this.delay = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.defaultPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuButton7 = new System.Windows.Forms.Button();
            this.menuButton9 = new System.Windows.Forms.Button();
            this.menuButton4 = new System.Windows.Forms.Button();
            this.menuButton8 = new System.Windows.Forms.Button();
            this.menuButton6 = new System.Windows.Forms.Button();
            this.menuButton1 = new System.Windows.Forms.Button();
            this.menuButton5 = new System.Windows.Forms.Button();
            this.menuButton3 = new System.Windows.Forms.Button();
            this.menuButton2 = new System.Windows.Forms.Button();
            this.listPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.menuCancel = new System.Windows.Forms.Button();
            this.menuListBox = new System.Windows.Forms.ListBox();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            this.defaultPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.listPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage4);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(294, 228);
            this.tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.windowProperties);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(286, 202);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Window";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // windowProperties
            // 
            this.windowProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowProperties.Location = new System.Drawing.Point(3, 3);
            this.windowProperties.Multiline = true;
            this.windowProperties.Name = "windowProperties";
            this.windowProperties.ReadOnly = true;
            this.windowProperties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.windowProperties.Size = new System.Drawing.Size(280, 196);
            this.windowProperties.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.parentProperties);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(286, 202);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Main Window";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // parentProperties
            // 
            this.parentProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentProperties.Location = new System.Drawing.Point(3, 3);
            this.parentProperties.Multiline = true;
            this.parentProperties.Name = "parentProperties";
            this.parentProperties.ReadOnly = true;
            this.parentProperties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.parentProperties.Size = new System.Drawing.Size(280, 196);
            this.parentProperties.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.clearCopied);
            this.tabPage4.Controls.Add(this.copied);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(286, 202);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Copied";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(101, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Goto &Main Window";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "&Goto Window";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // clearCopied
            // 
            this.clearCopied.Location = new System.Drawing.Point(215, 171);
            this.clearCopied.Name = "clearCopied";
            this.clearCopied.Size = new System.Drawing.Size(68, 23);
            this.clearCopied.TabIndex = 1;
            this.clearCopied.Text = "&Clear";
            this.clearCopied.UseVisualStyleBackColor = true;
            this.clearCopied.Click += new System.EventHandler(this.clearCopied_Click);
            // 
            // copied
            // 
            this.copied.FormattingEnabled = true;
            this.copied.Location = new System.Drawing.Point(3, 3);
            this.copied.Name = "copied";
            this.copied.Size = new System.Drawing.Size(280, 160);
            this.copied.TabIndex = 0;
            this.copied.SelectedIndexChanged += new System.EventHandler(this.copied_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.includeContents);
            this.tabPage3.Controls.Add(this.autoCopy);
            this.tabPage3.Controls.Add(this.delayedUpdate);
            this.tabPage3.Controls.Add(this.ctrlMenu);
            this.tabPage3.Controls.Add(this.altToggleTab);
            this.tabPage3.Controls.Add(this.avoidMouse);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.opacityBar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(286, 202);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // includeContents
            // 
            this.includeContents.AutoSize = true;
            this.includeContents.Location = new System.Drawing.Point(11, 171);
            this.includeContents.Name = "includeContents";
            this.includeContents.Size = new System.Drawing.Size(148, 17);
            this.includeContents.TabIndex = 7;
            this.includeContents.Text = "Include Window Contents";
            this.includeContents.UseVisualStyleBackColor = true;
            // 
            // autoCopy
            // 
            this.autoCopy.AutoSize = true;
            this.autoCopy.Checked = true;
            this.autoCopy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoCopy.Location = new System.Drawing.Point(11, 147);
            this.autoCopy.Name = "autoCopy";
            this.autoCopy.Size = new System.Drawing.Size(199, 17);
            this.autoCopy.TabIndex = 6;
            this.autoCopy.Text = "Copy Window Information after delay";
            this.autoCopy.UseVisualStyleBackColor = true;
            // 
            // delayedUpdate
            // 
            this.delayedUpdate.AutoSize = true;
            this.delayedUpdate.Location = new System.Drawing.Point(11, 123);
            this.delayedUpdate.Name = "delayedUpdate";
            this.delayedUpdate.Size = new System.Drawing.Size(189, 17);
            this.delayedUpdate.TabIndex = 5;
            this.delayedUpdate.Text = "&Update information after delay only";
            this.delayedUpdate.UseVisualStyleBackColor = true;
            // 
            // ctrlMenu
            // 
            this.ctrlMenu.AutoSize = true;
            this.ctrlMenu.Checked = true;
            this.ctrlMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctrlMenu.Location = new System.Drawing.Point(11, 99);
            this.ctrlMenu.Name = "ctrlMenu";
            this.ctrlMenu.Size = new System.Drawing.Size(156, 17);
            this.ctrlMenu.TabIndex = 4;
            this.ctrlMenu.Text = "Use [Ctrl] for clickless menu";
            this.ctrlMenu.UseVisualStyleBackColor = true;
            // 
            // altToggleTab
            // 
            this.altToggleTab.AutoSize = true;
            this.altToggleTab.Checked = true;
            this.altToggleTab.CheckState = System.Windows.Forms.CheckState.Checked;
            this.altToggleTab.Location = new System.Drawing.Point(11, 75);
            this.altToggleTab.Name = "altToggleTab";
            this.altToggleTab.Size = new System.Drawing.Size(148, 17);
            this.altToggleTab.TabIndex = 3;
            this.altToggleTab.Text = "Use [Alt] key to toggle tab";
            this.altToggleTab.UseVisualStyleBackColor = true;
            // 
            // avoidMouse
            // 
            this.avoidMouse.AutoSize = true;
            this.avoidMouse.Location = new System.Drawing.Point(11, 51);
            this.avoidMouse.Name = "avoidMouse";
            this.avoidMouse.Size = new System.Drawing.Size(222, 17);
            this.avoidMouse.TabIndex = 2;
            this.avoidMouse.Text = "Avoid mouse cursor (Hold Shift to disable)";
            this.avoidMouse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity:";
            // 
            // opacityBar
            // 
            this.opacityBar.LargeChange = 10;
            this.opacityBar.Location = new System.Drawing.Point(60, 3);
            this.opacityBar.Maximum = 20;
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(218, 42);
            this.opacityBar.TabIndex = 0;
            this.opacityBar.Value = 20;
            this.opacityBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // delay
            // 
            this.delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delay.Location = new System.Drawing.Point(240, 4);
            this.delay.Name = "delay";
            this.delay.Size = new System.Drawing.Size(50, 13);
            this.delay.TabIndex = 0;
            this.delay.Text = "Delay";
            this.delay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // defaultPanel
            // 
            this.defaultPanel.Controls.Add(this.delay);
            this.defaultPanel.Controls.Add(this.tabs);
            this.defaultPanel.Location = new System.Drawing.Point(0, 0);
            this.defaultPanel.Margin = new System.Windows.Forms.Padding(0);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.Size = new System.Drawing.Size(294, 228);
            this.defaultPanel.TabIndex = 1;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.label2);
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(294, 228);
            this.infoPanel.TabIndex = 2;
            this.infoPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 81);
            this.label2.TabIndex = 0;
            this.label2.Text = "Move your mouse to change the window.\r\n\r\nRelease the Shift key to return to the m" +
                "enu.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.label4);
            this.menuPanel.Controls.Add(this.tableLayoutPanel1);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(294, 228);
            this.menuPanel.TabIndex = 0;
            this.menuPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Move mouse to select, press Shift to activate";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.menuButton7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuButton9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuButton4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuButton8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuButton6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuButton1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuButton5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuButton3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuButton2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 206);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // menuButton7
            // 
            this.menuButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton7.Location = new System.Drawing.Point(3, 139);
            this.menuButton7.Name = "menuButton7";
            this.menuButton7.Size = new System.Drawing.Size(89, 64);
            this.menuButton7.TabIndex = 4;
            this.menuButton7.Text = "Advanced (unused)";
            this.menuButton7.UseVisualStyleBackColor = true;
            // 
            // menuButton9
            // 
            this.menuButton9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton9.Location = new System.Drawing.Point(194, 139);
            this.menuButton9.Name = "menuButton9";
            this.menuButton9.Size = new System.Drawing.Size(91, 64);
            this.menuButton9.TabIndex = 6;
            this.menuButton9.Text = "Resize";
            this.menuButton9.UseVisualStyleBackColor = true;
            // 
            // menuButton4
            // 
            this.menuButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton4.Location = new System.Drawing.Point(3, 71);
            this.menuButton4.Name = "menuButton4";
            this.menuButton4.Size = new System.Drawing.Size(89, 62);
            this.menuButton4.TabIndex = 4;
            this.menuButton4.Text = "Select Parent or Ancestor";
            this.menuButton4.UseVisualStyleBackColor = true;
            // 
            // menuButton8
            // 
            this.menuButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton8.Location = new System.Drawing.Point(98, 139);
            this.menuButton8.Name = "menuButton8";
            this.menuButton8.Size = new System.Drawing.Size(90, 64);
            this.menuButton8.TabIndex = 5;
            this.menuButton8.Text = "Copy";
            this.menuButton8.UseVisualStyleBackColor = true;
            // 
            // menuButton6
            // 
            this.menuButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton6.Location = new System.Drawing.Point(194, 71);
            this.menuButton6.Name = "menuButton6";
            this.menuButton6.Size = new System.Drawing.Size(91, 62);
            this.menuButton6.TabIndex = 6;
            this.menuButton6.Text = "Select Child";
            this.menuButton6.UseVisualStyleBackColor = true;
            // 
            // menuButton1
            // 
            this.menuButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton1.Location = new System.Drawing.Point(3, 3);
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.Size = new System.Drawing.Size(89, 62);
            this.menuButton1.TabIndex = 0;
            this.menuButton1.Text = "Move";
            this.menuButton1.UseVisualStyleBackColor = true;
            // 
            // menuButton5
            // 
            this.menuButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton5.Location = new System.Drawing.Point(98, 71);
            this.menuButton5.Name = "menuButton5";
            this.menuButton5.Size = new System.Drawing.Size(90, 62);
            this.menuButton5.TabIndex = 5;
            this.menuButton5.Text = "Change/Scroll Tab";
            this.menuButton5.UseVisualStyleBackColor = true;
            // 
            // menuButton3
            // 
            this.menuButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton3.Location = new System.Drawing.Point(194, 3);
            this.menuButton3.Name = "menuButton3";
            this.menuButton3.Size = new System.Drawing.Size(91, 62);
            this.menuButton3.TabIndex = 2;
            this.menuButton3.Text = "Toggle Visible";
            this.menuButton3.UseVisualStyleBackColor = true;
            // 
            // menuButton2
            // 
            this.menuButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButton2.Location = new System.Drawing.Point(98, 3);
            this.menuButton2.Name = "menuButton2";
            this.menuButton2.Size = new System.Drawing.Size(90, 62);
            this.menuButton2.TabIndex = 1;
            this.menuButton2.Text = "Toggle Enabled";
            this.menuButton2.UseVisualStyleBackColor = true;
            // 
            // listPanel
            // 
            this.listPanel.Controls.Add(this.label3);
            this.listPanel.Controls.Add(this.menuCancel);
            this.listPanel.Controls.Add(this.menuListBox);
            this.listPanel.Location = new System.Drawing.Point(0, 0);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(294, 228);
            this.listPanel.TabIndex = 3;
            this.listPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Release the Shift key to select";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuCancel
            // 
            this.menuCancel.Location = new System.Drawing.Point(4, 9);
            this.menuCancel.Name = "menuCancel";
            this.menuCancel.Size = new System.Drawing.Size(100, 186);
            this.menuCancel.TabIndex = 1;
            this.menuCancel.Text = "&Cancel";
            this.menuCancel.UseVisualStyleBackColor = true;
            // 
            // menuListBox
            // 
            this.menuListBox.FormattingEnabled = true;
            this.menuListBox.Location = new System.Drawing.Point(110, 9);
            this.menuListBox.Name = "menuListBox";
            this.menuListBox.Size = new System.Drawing.Size(170, 186);
            this.menuListBox.TabIndex = 0;
            this.menuListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.menuListBox_Format);
            // 
            // WindowInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 227);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.defaultPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WindowInformation";
            this.Text = "Window Information";
            this.TopMost = true;
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).EndInit();
            this.defaultPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.listPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label delay;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox windowProperties;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.TextBox parentProperties;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button clearCopied;
        private System.Windows.Forms.ListBox copied;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar opacityBar;
        private System.Windows.Forms.CheckBox avoidMouse;
        private System.Windows.Forms.CheckBox autoCopy;
        private System.Windows.Forms.CheckBox delayedUpdate;
        private System.Windows.Forms.CheckBox ctrlMenu;
        private System.Windows.Forms.CheckBox altToggleTab;
        private System.Windows.Forms.CheckBox includeContents;
        private System.Windows.Forms.Panel defaultPanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button menuCancel;
        private System.Windows.Forms.ListBox menuListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button menuButton1;
        private System.Windows.Forms.Button menuButton3;
        private System.Windows.Forms.Button menuButton2;
        private System.Windows.Forms.Button menuButton4;
        private System.Windows.Forms.Button menuButton6;
        private System.Windows.Forms.Button menuButton5;
        private System.Windows.Forms.Button menuButton7;
        private System.Windows.Forms.Button menuButton9;
        private System.Windows.Forms.Button menuButton8;
        private System.Windows.Forms.Label label4;
    }
}