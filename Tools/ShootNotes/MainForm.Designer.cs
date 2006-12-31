namespace ShootNotes
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityBar = new System.Windows.Forms.TrackBar();
            this.opacityLabel = new System.Windows.Forms.Label();
            this.shotButton = new System.Windows.Forms.Button();
            this.emptyButton = new System.Windows.Forms.Button();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.hideTimer = new System.Windows.Forms.Timer(this.components);
            this.rangePanel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closedNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.rangePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "ShootNotes";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator2,
            this.closedNotesToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(149, 82);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "&New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // opacityBar
            // 
            this.opacityBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityBar.Location = new System.Drawing.Point(12, 60);
            this.opacityBar.Maximum = 20;
            this.opacityBar.Minimum = 4;
            this.opacityBar.Name = "opacityBar";
            this.opacityBar.Size = new System.Drawing.Size(304, 42);
            this.opacityBar.TabIndex = 1;
            this.opacityBar.Value = 15;
            this.opacityBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // opacityLabel
            // 
            this.opacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.opacityLabel.Location = new System.Drawing.Point(12, 41);
            this.opacityLabel.Name = "opacityLabel";
            this.opacityLabel.Size = new System.Drawing.Size(304, 16);
            this.opacityLabel.TabIndex = 2;
            this.opacityLabel.Text = "&Opacity of this window:";
            this.opacityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shotButton
            // 
            this.shotButton.Location = new System.Drawing.Point(15, 12);
            this.shotButton.Name = "shotButton";
            this.shotButton.Size = new System.Drawing.Size(104, 26);
            this.shotButton.TabIndex = 3;
            this.shotButton.Text = "Create &Screenshot";
            this.shotButton.UseVisualStyleBackColor = true;
            this.shotButton.Click += new System.EventHandler(this.shotButton_Click);
            // 
            // emptyButton
            // 
            this.emptyButton.Location = new System.Drawing.Point(125, 12);
            this.emptyButton.Name = "emptyButton";
            this.emptyButton.Size = new System.Drawing.Size(117, 26);
            this.emptyButton.TabIndex = 4;
            this.emptyButton.Text = "Create &Empty Note";
            this.emptyButton.UseVisualStyleBackColor = true;
            this.emptyButton.Click += new System.EventHandler(this.emptyButton_Click);
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorBox.Location = new System.Drawing.Point(248, 12);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(35, 26);
            this.colorBox.TabIndex = 5;
            this.colorBox.TabStop = false;
            this.colorBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // hideTimer
            // 
            this.hideTimer.Enabled = true;
            this.hideTimer.Interval = 1;
            this.hideTimer.Tick += new System.EventHandler(this.hideTimer_Tick);
            // 
            // rangePanel
            // 
            this.rangePanel.Controls.Add(this.opacityLabel);
            this.rangePanel.Controls.Add(this.colorBox);
            this.rangePanel.Controls.Add(this.opacityBar);
            this.rangePanel.Controls.Add(this.emptyButton);
            this.rangePanel.Controls.Add(this.shotButton);
            this.rangePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rangePanel.Location = new System.Drawing.Point(0, 0);
            this.rangePanel.Name = "rangePanel";
            this.rangePanel.Size = new System.Drawing.Size(328, 111);
            this.rangePanel.TabIndex = 6;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // closedNotesToolStripMenuItem
            // 
            this.closedNotesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem});
            this.closedNotesToolStripMenuItem.Name = "closedNotesToolStripMenuItem";
            this.closedNotesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closedNotesToolStripMenuItem.Text = "&Closed Notes";
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Enabled = false;
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noneToolStripMenuItem.Text = "(None)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 111);
            this.Controls.Add(this.rangePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainForm";
            this.Opacity = 0.75;
            this.ShowInTaskbar = false;
            this.Text = "Create New Note - ShootNotes";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.trayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opacityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.rangePanel.ResumeLayout(false);
            this.rangePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.TrackBar opacityBar;
        private System.Windows.Forms.Label opacityLabel;
        private System.Windows.Forms.Button shotButton;
        private System.Windows.Forms.Button emptyButton;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Timer hideTimer;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel rangePanel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closedNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
    }
}

