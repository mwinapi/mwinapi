namespace TreeSizeSharp.GUI
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
            this.tree = new System.Windows.Forms.TreeView();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.physicalSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allocatedSpaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceWastedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kBOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gBOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.percentParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.filesByExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanThisFolderOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flattenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combineFileEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.createGroupOfChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1.SuspendLayout();
            this.treeMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.treeIcons;
            this.tree.Location = new System.Drawing.Point(0, 24);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(371, 280);
            this.tree.TabIndex = 0;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            // 
            // treeIcons
            // 
            this.treeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.treeIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scanToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(371, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scanToolStripMenuItem
            // 
            this.scanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem,
            this.toolStripSeparator8});
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.scanToolStripMenuItem.Text = "&Scan";
            // 
            // selectFolderToolStripMenuItem
            // 
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.selectFolderToolStripMenuItem.Text = "&Select Folder...";
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.selectFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(156, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logicalSizeToolStripMenuItem,
            this.physicalSizeToolStripMenuItem,
            this.allocatedSpaceToolStripMenuItem,
            this.spaceWastedToolStripMenuItem,
            this.fileCountToolStripMenuItem,
            this.folderCountToolStripMenuItem,
            this.totalCountToolStripMenuItem,
            this.toolStripSeparator7,
            this.mixedToolStripMenuItem,
            this.kBOnlyToolStripMenuItem,
            this.mBOnlyToolStripMenuItem,
            this.gBOnlyToolStripMenuItem,
            this.percentToolStripMenuItem,
            this.percentParentToolStripMenuItem,
            this.toolStripSeparator5,
            this.filesByExtensionToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // logicalSizeToolStripMenuItem
            // 
            this.logicalSizeToolStripMenuItem.Name = "logicalSizeToolStripMenuItem";
            this.logicalSizeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.logicalSizeToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.LOGICAL;
            this.logicalSizeToolStripMenuItem.Text = "&Logical Size";
            this.logicalSizeToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // physicalSizeToolStripMenuItem
            // 
            this.physicalSizeToolStripMenuItem.Checked = true;
            this.physicalSizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.physicalSizeToolStripMenuItem.Name = "physicalSizeToolStripMenuItem";
            this.physicalSizeToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.physicalSizeToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.PHYSICAL;
            this.physicalSizeToolStripMenuItem.Text = "Physical &Size";
            this.physicalSizeToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // allocatedSpaceToolStripMenuItem
            // 
            this.allocatedSpaceToolStripMenuItem.Name = "allocatedSpaceToolStripMenuItem";
            this.allocatedSpaceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.allocatedSpaceToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.ALLOCATED;
            this.allocatedSpaceToolStripMenuItem.Text = "&Allocated Space";
            this.allocatedSpaceToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // spaceWastedToolStripMenuItem
            // 
            this.spaceWastedToolStripMenuItem.Name = "spaceWastedToolStripMenuItem";
            this.spaceWastedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.spaceWastedToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.WASTED;
            this.spaceWastedToolStripMenuItem.Text = "Space &Wasted";
            this.spaceWastedToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // fileCountToolStripMenuItem
            // 
            this.fileCountToolStripMenuItem.Name = "fileCountToolStripMenuItem";
            this.fileCountToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.fileCountToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.FILECOUNT;
            this.fileCountToolStripMenuItem.Text = "&File Count";
            this.fileCountToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // folderCountToolStripMenuItem
            // 
            this.folderCountToolStripMenuItem.Name = "folderCountToolStripMenuItem";
            this.folderCountToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.folderCountToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.FOLDERCOUNT;
            this.folderCountToolStripMenuItem.Text = "Folder Count";
            this.folderCountToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // totalCountToolStripMenuItem
            // 
            this.totalCountToolStripMenuItem.Name = "totalCountToolStripMenuItem";
            this.totalCountToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.totalCountToolStripMenuItem.Tag = TreeSizeSharp.GUI.SizeValue.ALLCOUNT;
            this.totalCountToolStripMenuItem.Text = "Total &Count";
            this.totalCountToolStripMenuItem.Click += new System.EventHandler(this.sizeValueToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(168, 6);
            // 
            // mixedToolStripMenuItem
            // 
            this.mixedToolStripMenuItem.Checked = true;
            this.mixedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mixedToolStripMenuItem.Name = "mixedToolStripMenuItem";
            this.mixedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.mixedToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.MIXED;
            this.mixedToolStripMenuItem.Text = "Mi&xed";
            this.mixedToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // kBOnlyToolStripMenuItem
            // 
            this.kBOnlyToolStripMenuItem.Name = "kBOnlyToolStripMenuItem";
            this.kBOnlyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.kBOnlyToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.KB;
            this.kBOnlyToolStripMenuItem.Text = "&KB Only";
            this.kBOnlyToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // mBOnlyToolStripMenuItem
            // 
            this.mBOnlyToolStripMenuItem.Name = "mBOnlyToolStripMenuItem";
            this.mBOnlyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.mBOnlyToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.MB;
            this.mBOnlyToolStripMenuItem.Text = "&MB Only";
            this.mBOnlyToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // gBOnlyToolStripMenuItem
            // 
            this.gBOnlyToolStripMenuItem.Name = "gBOnlyToolStripMenuItem";
            this.gBOnlyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gBOnlyToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.GB;
            this.gBOnlyToolStripMenuItem.Text = "&GB Only";
            this.gBOnlyToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // percentToolStripMenuItem
            // 
            this.percentToolStripMenuItem.Name = "percentToolStripMenuItem";
            this.percentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.percentToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.PERCENT;
            this.percentToolStripMenuItem.Text = "&Percent";
            this.percentToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // percentParentToolStripMenuItem
            // 
            this.percentParentToolStripMenuItem.Name = "percentParentToolStripMenuItem";
            this.percentParentToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.percentParentToolStripMenuItem.Tag = TreeSizeSharp.GUI.DisplayMode.PERCENTPARENT;
            this.percentParentToolStripMenuItem.Text = "Percent of Pa&rent";
            this.percentParentToolStripMenuItem.Click += new System.EventHandler(this.displayModeMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(168, 6);
            // 
            // filesByExtensionToolStripMenuItem
            // 
            this.filesByExtensionToolStripMenuItem.Enabled = false;
            this.filesByExtensionToolStripMenuItem.Name = "filesByExtensionToolStripMenuItem";
            this.filesByExtensionToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.filesByExtensionToolStripMenuItem.Text = "Files by &Extension";
            this.filesByExtensionToolStripMenuItem.Click += new System.EventHandler(this.filesByExtensionToolStripMenuItem_Click);
            // 
            // treeMenuStrip
            // 
            this.treeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshToolStripMenuItem,
            this.scanThisFolderOnlyToolStripMenuItem,
            this.toolStripSeparator3,
            this.moveUpToolStripMenuItem,
            this.moveUpChildrenToolStripMenuItem,
            this.flattenToolStripMenuItem,
            this.combineFileEntriesToolStripMenuItem,
            this.toolStripSeparator4,
            this.createGroupOfChildrenToolStripMenuItem});
            this.treeMenuStrip.Name = "contextMenuStrip1";
            this.treeMenuStrip.Size = new System.Drawing.Size(222, 220);
            this.treeMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.treeMenuStrip_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exploreToolStripMenuItem.Text = "&Explore";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // scanThisFolderOnlyToolStripMenuItem
            // 
            this.scanThisFolderOnlyToolStripMenuItem.Name = "scanThisFolderOnlyToolStripMenuItem";
            this.scanThisFolderOnlyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.scanThisFolderOnlyToolStripMenuItem.Text = "Scan &This Folder Only";
            this.scanThisFolderOnlyToolStripMenuItem.Click += new System.EventHandler(this.scanThisFolderOnlyToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.moveUpToolStripMenuItem.Text = "Move &Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveUpChildrenToolStripMenuItem
            // 
            this.moveUpChildrenToolStripMenuItem.Name = "moveUpChildrenToolStripMenuItem";
            this.moveUpChildrenToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.moveUpChildrenToolStripMenuItem.Text = "Move All &Children Up";
            this.moveUpChildrenToolStripMenuItem.Click += new System.EventHandler(this.moveUpChildrenToolStripMenuItem_Click);
            // 
            // flattenToolStripMenuItem
            // 
            this.flattenToolStripMenuItem.Name = "flattenToolStripMenuItem";
            this.flattenToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.flattenToolStripMenuItem.Text = "&Flatten";
            this.flattenToolStripMenuItem.Click += new System.EventHandler(this.flattenToolStripMenuItem_Click);
            // 
            // combineFileEntriesToolStripMenuItem
            // 
            this.combineFileEntriesToolStripMenuItem.Name = "combineFileEntriesToolStripMenuItem";
            this.combineFileEntriesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.combineFileEntriesToolStripMenuItem.Text = "Combine F&ile Entries (TODO)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(218, 6);
            // 
            // createGroupOfChildrenToolStripMenuItem
            // 
            this.createGroupOfChildrenToolStripMenuItem.Name = "createGroupOfChildrenToolStripMenuItem";
            this.createGroupOfChildrenToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.createGroupOfChildrenToolStripMenuItem.Text = "Create &Group... (TODO)";
            // 
            // folderBrowser
            // 
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 304);
            this.Controls.Add(this.tree);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TreeSize# 0.5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.treeMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem physicalSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocatedSpaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem percentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceWastedToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem filesByExtensionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGroupOfChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flattenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combineFileEntriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ToolStripMenuItem logicalSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kBOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mBOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gBOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem percentParentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem scanThisFolderOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

