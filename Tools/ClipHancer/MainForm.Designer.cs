namespace ClipHancer
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
            this.clips = new System.Windows.Forms.ListView();
            this.Main = new System.Windows.Forms.ColumnHeader();
            this.previewImages = new System.Windows.Forms.ImageList(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hide = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.deleteStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.clearClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copy = new System.Windows.Forms.Button();
            this.copyStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.storedFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.share = new System.Windows.Forms.Button();
            this.shareStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.stopSharingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receive = new System.Windows.Forms.Button();
            this.onReceiveStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelReceiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.receiveStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.receiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.copyServerListToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteServerListFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipNotify = new ManagedWinapi.ClipboardNotifier(this.components);
            this.hotkeyX = new ManagedWinapi.Hotkey(this.components);
            this.hotkeyC = new ManagedWinapi.Hotkey(this.components);
            this.hotkeyV = new ManagedWinapi.Hotkey(this.components);
            this.trayStrip.SuspendLayout();
            this.deleteStrip.SuspendLayout();
            this.copyStrip.SuspendLayout();
            this.shareStrip.SuspendLayout();
            this.onReceiveStrip.SuspendLayout();
            this.receiveStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clips
            // 
            this.clips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Main});
            this.clips.FullRowSelect = true;
            this.clips.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.clips.HideSelection = false;
            this.clips.LabelWrap = false;
            this.clips.Location = new System.Drawing.Point(12, 12);
            this.clips.MultiSelect = false;
            this.clips.Name = "clips";
            this.clips.ShowGroups = false;
            this.clips.Size = new System.Drawing.Size(291, 397);
            this.clips.SmallImageList = this.previewImages;
            this.clips.TabIndex = 0;
            this.clips.UseCompatibleStateImageBehavior = false;
            this.clips.View = System.Windows.Forms.View.Details;
            this.clips.SelectedIndexChanged += new System.EventHandler(this.clips_SelectedIndexChanged);
            this.clips.SizeChanged += new System.EventHandler(this.clips_SizeChanged);
            // 
            // Main
            // 
            this.Main.Text = "Entry";
            this.Main.Width = 271;
            // 
            // previewImages
            // 
            this.previewImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.previewImages.ImageSize = new System.Drawing.Size(48, 48);
            this.previewImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "ClipHancer";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayStrip
            // 
            this.trayStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.trayStrip.Name = "trayStrip";
            this.trayStrip.Size = new System.Drawing.Size(112, 54);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(108, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hide
            // 
            this.hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hide.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hide.Location = new System.Drawing.Point(309, 12);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(75, 23);
            this.hide.TabIndex = 2;
            this.hide.Text = "&Hide";
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.ContextMenuStrip = this.deleteStrip;
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(309, 328);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "&Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // deleteStrip
            // 
            this.deleteStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearListToolStripMenuItem,
            this.toolStripSeparator4,
            this.clearClipboardToolStripMenuItem});
            this.deleteStrip.Name = "deleteStrip";
            this.deleteStrip.Size = new System.Drawing.Size(159, 82);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // clearListToolStripMenuItem
            // 
            this.clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            this.clearListToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clearListToolStripMenuItem.Text = "Clear &List";
            this.clearListToolStripMenuItem.Click += new System.EventHandler(this.clearListToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(155, 6);
            // 
            // clearClipboardToolStripMenuItem
            // 
            this.clearClipboardToolStripMenuItem.Name = "clearClipboardToolStripMenuItem";
            this.clearClipboardToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.clearClipboardToolStripMenuItem.Text = "Clear Clip&board";
            this.clearClipboardToolStripMenuItem.Click += new System.EventHandler(this.clearClipboardToolStripMenuItem_Click);
            // 
            // copy
            // 
            this.copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copy.ContextMenuStrip = this.copyStrip;
            this.copy.Enabled = false;
            this.copy.Location = new System.Drawing.Point(309, 299);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(75, 23);
            this.copy.TabIndex = 4;
            this.copy.Text = "&Copy";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // copyStrip
            // 
            this.copyStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allFormatsToolStripMenuItem,
            this.toolStripSeparator2,
            this.storedFormatsToolStripMenuItem});
            this.copyStrip.Name = "copyStrip";
            this.copyStrip.Size = new System.Drawing.Size(181, 54);
            // 
            // allFormatsToolStripMenuItem
            // 
            this.allFormatsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.allFormatsToolStripMenuItem.Name = "allFormatsToolStripMenuItem";
            this.allFormatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.allFormatsToolStripMenuItem.Text = "Copy &All Formats";
            this.allFormatsToolStripMenuItem.Click += new System.EventHandler(this.copy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // storedFormatsToolStripMenuItem
            // 
            this.storedFormatsToolStripMenuItem.Enabled = false;
            this.storedFormatsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.storedFormatsToolStripMenuItem.Name = "storedFormatsToolStripMenuItem";
            this.storedFormatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storedFormatsToolStripMenuItem.Text = "Stored formats:";
            // 
            // share
            // 
            this.share.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.share.ContextMenuStrip = this.shareStrip;
            this.share.Enabled = false;
            this.share.Location = new System.Drawing.Point(309, 357);
            this.share.Name = "share";
            this.share.Size = new System.Drawing.Size(75, 23);
            this.share.TabIndex = 5;
            this.share.Text = "&Share";
            this.share.UseVisualStyleBackColor = true;
            this.share.Click += new System.EventHandler(this.share_Click);
            // 
            // shareStrip
            // 
            this.shareStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareToolStripMenuItem,
            this.toolStripSeparator5,
            this.stopSharingToolStripMenuItem});
            this.shareStrip.Name = "shareStrip";
            this.shareStrip.Size = new System.Drawing.Size(146, 54);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.shareToolStripMenuItem.Text = "&Share";
            this.shareToolStripMenuItem.Click += new System.EventHandler(this.share_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(142, 6);
            // 
            // stopSharingToolStripMenuItem
            // 
            this.stopSharingToolStripMenuItem.Name = "stopSharingToolStripMenuItem";
            this.stopSharingToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.stopSharingToolStripMenuItem.Text = "St&op sharing";
            this.stopSharingToolStripMenuItem.Click += new System.EventHandler(this.stopSharingToolStripMenuItem_Click);
            // 
            // receive
            // 
            this.receive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.receive.Location = new System.Drawing.Point(309, 386);
            this.receive.Name = "receive";
            this.receive.Size = new System.Drawing.Size(75, 23);
            this.receive.TabIndex = 6;
            this.receive.Text = "&Receive";
            this.receive.UseVisualStyleBackColor = true;
            this.receive.Click += new System.EventHandler(this.receive_Click);
            // 
            // onReceiveStrip
            // 
            this.onReceiveStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.cancelReceiveToolStripMenuItem});
            this.onReceiveStrip.Name = "receiveStrip";
            this.onReceiveStrip.Size = new System.Drawing.Size(118, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // cancelReceiveToolStripMenuItem
            // 
            this.cancelReceiveToolStripMenuItem.Name = "cancelReceiveToolStripMenuItem";
            this.cancelReceiveToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.cancelReceiveToolStripMenuItem.Text = "Cancel";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(310, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 254);
            this.label1.TabIndex = 7;
            this.label1.Text = "Right-click buttons below to show a context menu.\r\n\r\nUse [Win]+ [X/C/V] and hold " +
                "[Win] key for a quick menu.";
            // 
            // receiveStrip
            // 
            this.receiveStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receiveToolStripMenuItem,
            this.toolStripSeparator6,
            this.copyServerListToClipboardToolStripMenuItem,
            this.pasteServerListFromClipboardToolStripMenuItem});
            this.receiveStrip.Name = "receiveStrip";
            this.receiveStrip.Size = new System.Drawing.Size(242, 76);
            // 
            // receiveToolStripMenuItem
            // 
            this.receiveToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.receiveToolStripMenuItem.Name = "receiveToolStripMenuItem";
            this.receiveToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.receiveToolStripMenuItem.Text = "&Receive";
            this.receiveToolStripMenuItem.Click += new System.EventHandler(this.receive_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(238, 6);
            // 
            // copyServerListToClipboardToolStripMenuItem
            // 
            this.copyServerListToClipboardToolStripMenuItem.Name = "copyServerListToClipboardToolStripMenuItem";
            this.copyServerListToClipboardToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.copyServerListToClipboardToolStripMenuItem.Text = "&Copy Server List To Clipboard";
            this.copyServerListToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyServerListToClipboardToolStripMenuItem_Click);
            // 
            // pasteServerListFromClipboardToolStripMenuItem
            // 
            this.pasteServerListFromClipboardToolStripMenuItem.Name = "pasteServerListFromClipboardToolStripMenuItem";
            this.pasteServerListFromClipboardToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.pasteServerListFromClipboardToolStripMenuItem.Text = "&Paste Server List From Clipboard";
            this.pasteServerListFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pasteServerListFromClipboardToolStripMenuItem_Click);
            // 
            // clipNotify
            // 
            this.clipNotify.ClipboardChanged += new System.EventHandler(this.clipNotify_ClipboardChanged);
            // 
            // hotkeyX
            // 
            this.hotkeyX.Alt = false;
            this.hotkeyX.Ctrl = false;
            this.hotkeyX.Enabled = false;
            this.hotkeyX.KeyCode = System.Windows.Forms.Keys.X;
            this.hotkeyX.Shift = false;
            this.hotkeyX.WindowsKey = true;
            this.hotkeyX.HotkeyPressed += new System.EventHandler(this.hotkeyX_HotkeyPressed);
            // 
            // hotkeyC
            // 
            this.hotkeyC.Alt = false;
            this.hotkeyC.Ctrl = false;
            this.hotkeyC.Enabled = false;
            this.hotkeyC.KeyCode = System.Windows.Forms.Keys.C;
            this.hotkeyC.Shift = false;
            this.hotkeyC.WindowsKey = true;
            this.hotkeyC.HotkeyPressed += new System.EventHandler(this.hotkeyC_HotkeyPressed);
            // 
            // hotkeyV
            // 
            this.hotkeyV.Alt = false;
            this.hotkeyV.Ctrl = false;
            this.hotkeyV.Enabled = false;
            this.hotkeyV.KeyCode = System.Windows.Forms.Keys.V;
            this.hotkeyV.Shift = false;
            this.hotkeyV.WindowsKey = true;
            this.hotkeyV.HotkeyPressed += new System.EventHandler(this.hotkeyV_HotkeyPressed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 421);
            this.ContextMenuStrip = this.receiveStrip;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clips);
            this.Controls.Add(this.receive);
            this.Controls.Add(this.share);
            this.Controls.Add(this.hide);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.copy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClipHancer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.trayStrip.ResumeLayout(false);
            this.deleteStrip.ResumeLayout(false);
            this.copyStrip.ResumeLayout(false);
            this.shareStrip.ResumeLayout(false);
            this.onReceiveStrip.ResumeLayout(false);
            this.receiveStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ManagedWinapi.ClipboardNotifier clipNotify;
        private ManagedWinapi.Hotkey hotkeyX;
        private ManagedWinapi.Hotkey hotkeyC;
        private ManagedWinapi.Hotkey hotkeyV;
        private System.Windows.Forms.ListView clips;
        private System.Windows.Forms.ImageList previewImages;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Main;
        private System.Windows.Forms.Button hide;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button copy;
        private System.Windows.Forms.Button share;
        private System.Windows.Forms.Button receive;
        private System.Windows.Forms.ContextMenuStrip onReceiveStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelReceiveToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip copyStrip;
        private System.Windows.Forms.ToolStripMenuItem allFormatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem storedFormatsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip deleteStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearListToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem clearClipboardToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip shareStrip;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem stopSharingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip receiveStrip;
        private System.Windows.Forms.ToolStripMenuItem receiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem copyServerListToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteServerListFromClipboardToolStripMenuItem;
    }
}

