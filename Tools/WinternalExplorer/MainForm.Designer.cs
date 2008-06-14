namespace WinternalExplorer
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
            this.refresh = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.threadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toplevelWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.accessibleObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.visibleObjectsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowByHandleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.windowsByTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsByClassNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stolenOrphanWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree = new System.Windows.Forms.TreeView();
            this.treeImages = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.allowChanges = new System.Windows.Forms.CheckBox();
            this.autoHide = new System.Windows.Forms.CheckBox();
            this.details = new System.Windows.Forms.GroupBox();
            this.selAccObjs = new System.Windows.Forms.RadioButton();
            this.selChildWindows = new System.Windows.Forms.RadioButton();
            this.selToplevel = new System.Windows.Forms.RadioButton();
            this.crossHair = new ManagedWinapi.Crosshair();
            this.heuristicSearch = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh.Location = new System.Drawing.Point(0, 323);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(192, 26);
            this.refresh.TabIndex = 1;
            this.refresh.Text = "&Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.findToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processTreeToolStripMenuItem,
            this.processesToolStripMenuItem,
            this.noProcessesToolStripMenuItem,
            this.toolStripSeparator1,
            this.threadsToolStripMenuItem,
            this.toolStripSeparator2,
            this.toplevelWindowsToolStripMenuItem,
            this.allWindowsToolStripMenuItem,
            this.noWindowsToolStripMenuItem,
            this.toolStripSeparator3,
            this.accessibleObjectsToolStripMenuItem,
            this.toolStripSeparator5,
            this.visibleObjectsOnlyToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // processTreeToolStripMenuItem
            // 
            this.processTreeToolStripMenuItem.Name = "processTreeToolStripMenuItem";
            this.processTreeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.processTreeToolStripMenuItem.Text = "Process T&ree";
            this.processTreeToolStripMenuItem.Click += new System.EventHandler(this.ProcessViewFilter_Click);
            // 
            // processesToolStripMenuItem
            // 
            this.processesToolStripMenuItem.Checked = true;
            this.processesToolStripMenuItem.CheckOnClick = true;
            this.processesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.processesToolStripMenuItem.Name = "processesToolStripMenuItem";
            this.processesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.processesToolStripMenuItem.Text = "&Processes";
            this.processesToolStripMenuItem.Click += new System.EventHandler(this.ProcessViewFilter_Click);
            // 
            // noProcessesToolStripMenuItem
            // 
            this.noProcessesToolStripMenuItem.Name = "noProcessesToolStripMenuItem";
            this.noProcessesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.noProcessesToolStripMenuItem.Text = "&No Processes";
            this.noProcessesToolStripMenuItem.Click += new System.EventHandler(this.ProcessViewFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // threadsToolStripMenuItem
            // 
            this.threadsToolStripMenuItem.Checked = true;
            this.threadsToolStripMenuItem.CheckOnClick = true;
            this.threadsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.threadsToolStripMenuItem.Name = "threadsToolStripMenuItem";
            this.threadsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.threadsToolStripMenuItem.Text = "&Threads";
            this.threadsToolStripMenuItem.Click += new System.EventHandler(this.ViewFilter_click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // toplevelWindowsToolStripMenuItem
            // 
            this.toplevelWindowsToolStripMenuItem.Name = "toplevelWindowsToolStripMenuItem";
            this.toplevelWindowsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.toplevelWindowsToolStripMenuItem.Text = "T&oplevel Windows";
            this.toplevelWindowsToolStripMenuItem.Click += new System.EventHandler(this.WindowViewFilter_click);
            // 
            // allWindowsToolStripMenuItem
            // 
            this.allWindowsToolStripMenuItem.Checked = true;
            this.allWindowsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allWindowsToolStripMenuItem.Name = "allWindowsToolStripMenuItem";
            this.allWindowsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.allWindowsToolStripMenuItem.Text = "&All Windows";
            this.allWindowsToolStripMenuItem.Click += new System.EventHandler(this.WindowViewFilter_click);
            // 
            // noWindowsToolStripMenuItem
            // 
            this.noWindowsToolStripMenuItem.Name = "noWindowsToolStripMenuItem";
            this.noWindowsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.noWindowsToolStripMenuItem.Text = "No &Windows";
            this.noWindowsToolStripMenuItem.Click += new System.EventHandler(this.WindowViewFilter_click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // accessibleObjectsToolStripMenuItem
            // 
            this.accessibleObjectsToolStripMenuItem.Checked = true;
            this.accessibleObjectsToolStripMenuItem.CheckOnClick = true;
            this.accessibleObjectsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.accessibleObjectsToolStripMenuItem.Name = "accessibleObjectsToolStripMenuItem";
            this.accessibleObjectsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.accessibleObjectsToolStripMenuItem.Text = "&Accessible Objects";
            this.accessibleObjectsToolStripMenuItem.Click += new System.EventHandler(this.ViewFilter_click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
            // 
            // visibleObjectsOnlyToolStripMenuItem
            // 
            this.visibleObjectsOnlyToolStripMenuItem.CheckOnClick = true;
            this.visibleObjectsOnlyToolStripMenuItem.Name = "visibleObjectsOnlyToolStripMenuItem";
            this.visibleObjectsOnlyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.visibleObjectsOnlyToolStripMenuItem.Text = "&Visible Objects Only";
            this.visibleObjectsOnlyToolStripMenuItem.Click += new System.EventHandler(this.ViewFilter_click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowByHandleToolStripMenuItem,
            this.toolStripSeparator4,
            this.windowsByTitleToolStripMenuItem,
            this.windowsByClassNameToolStripMenuItem,
            this.stolenOrphanWindowsToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.findToolStripMenuItem.Text = "&Find";
            // 
            // windowByHandleToolStripMenuItem
            // 
            this.windowByHandleToolStripMenuItem.Name = "windowByHandleToolStripMenuItem";
            this.windowByHandleToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windowByHandleToolStripMenuItem.Text = "Window by &Handle...";
            this.windowByHandleToolStripMenuItem.Click += new System.EventHandler(this.windowByHandleToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(210, 6);
            // 
            // windowsByTitleToolStripMenuItem
            // 
            this.windowsByTitleToolStripMenuItem.Name = "windowsByTitleToolStripMenuItem";
            this.windowsByTitleToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windowsByTitleToolStripMenuItem.Text = "&Windows by Title...";
            this.windowsByTitleToolStripMenuItem.Click += new System.EventHandler(this.windowsByTitleToolStripMenuItem_Click);
            // 
            // windowsByClassNameToolStripMenuItem
            // 
            this.windowsByClassNameToolStripMenuItem.Name = "windowsByClassNameToolStripMenuItem";
            this.windowsByClassNameToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.windowsByClassNameToolStripMenuItem.Text = "Windows by &Class Name...";
            this.windowsByClassNameToolStripMenuItem.Click += new System.EventHandler(this.windowsByClassNameToolStripMenuItem_Click);
            // 
            // stolenOrphanWindowsToolStripMenuItem
            // 
            this.stolenOrphanWindowsToolStripMenuItem.Name = "stolenOrphanWindowsToolStripMenuItem";
            this.stolenOrphanWindowsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.stolenOrphanWindowsToolStripMenuItem.Text = "&Stolen/Orphan Windows...";
            this.stolenOrphanWindowsToolStripMenuItem.Click += new System.EventHandler(this.stolenOrphanWindowsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowInformationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "T&ools";
            // 
            // windowInformationToolStripMenuItem
            // 
            this.windowInformationToolStripMenuItem.Name = "windowInformationToolStripMenuItem";
            this.windowInformationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.windowInformationToolStripMenuItem.Text = "&Window Information";
            this.windowInformationToolStripMenuItem.Click += new System.EventHandler(this.windowInformationToolStripMenuItem_Click);
            // 
            // tree
            // 
            this.tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.treeImages;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.SelectedImageIndex = 0;
            this.tree.Size = new System.Drawing.Size(192, 322);
            this.tree.TabIndex = 3;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // treeImages
            // 
            this.treeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeImages.ImageStream")));
            this.treeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.treeImages.Images.SetKeyName(0, "process.ico");
            this.treeImages.Images.SetKeyName(1, "thread.ico");
            this.treeImages.Images.SetKeyName(2, "window.ico");
            this.treeImages.Images.SetKeyName(3, "hiddenwindow.ico");
            this.treeImages.Images.SetKeyName(4, "accobj.ico");
            this.treeImages.Images.SetKeyName(5, "hiddenaccobj.ico");
            this.treeImages.Images.SetKeyName(6, "category.ico");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.refresh);
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.heuristicSearch);
            this.splitContainer1.Panel2.Controls.Add(this.allowChanges);
            this.splitContainer1.Panel2.Controls.Add(this.autoHide);
            this.splitContainer1.Panel2.Controls.Add(this.details);
            this.splitContainer1.Panel2.Controls.Add(this.selAccObjs);
            this.splitContainer1.Panel2.Controls.Add(this.selChildWindows);
            this.splitContainer1.Panel2.Controls.Add(this.selToplevel);
            this.splitContainer1.Panel2.Controls.Add(this.crossHair);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(671, 349);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 4;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // allowChanges
            // 
            this.allowChanges.AutoSize = true;
            this.allowChanges.Location = new System.Drawing.Point(172, 22);
            this.allowChanges.Name = "allowChanges";
            this.allowChanges.Size = new System.Drawing.Size(130, 17);
            this.allowChanges.TabIndex = 7;
            this.allowChanges.Text = "Allow &unsafe changes";
            this.allowChanges.UseVisualStyleBackColor = true;
            this.allowChanges.CheckedChanged += new System.EventHandler(this.allowChanges_CheckedChanged);
            // 
            // autoHide
            // 
            this.autoHide.AutoSize = true;
            this.autoHide.Location = new System.Drawing.Point(45, 22);
            this.autoHide.Name = "autoHide";
            this.autoHide.Size = new System.Drawing.Size(121, 17);
            this.autoHide.TabIndex = 6;
            this.autoHide.Text = "&Hide when dragging";
            this.autoHide.UseVisualStyleBackColor = true;
            // 
            // details
            // 
            this.details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.details.Location = new System.Drawing.Point(3, 45);
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(469, 304);
            this.details.TabIndex = 5;
            this.details.TabStop = false;
            this.details.Text = "Details";
            // 
            // selAccObjs
            // 
            this.selAccObjs.AutoSize = true;
            this.selAccObjs.Location = new System.Drawing.Point(265, 3);
            this.selAccObjs.Name = "selAccObjs";
            this.selAccObjs.Size = new System.Drawing.Size(115, 17);
            this.selAccObjs.TabIndex = 4;
            this.selAccObjs.Text = "&Accessible Objects";
            this.selAccObjs.UseVisualStyleBackColor = true;
            // 
            // selChildWindows
            // 
            this.selChildWindows.AutoSize = true;
            this.selChildWindows.Checked = true;
            this.selChildWindows.Location = new System.Drawing.Point(164, 3);
            this.selChildWindows.Name = "selChildWindows";
            this.selChildWindows.Size = new System.Drawing.Size(95, 17);
            this.selChildWindows.TabIndex = 3;
            this.selChildWindows.TabStop = true;
            this.selChildWindows.Text = "&Child Windows";
            this.selChildWindows.UseVisualStyleBackColor = true;
            // 
            // selToplevel
            // 
            this.selToplevel.AutoSize = true;
            this.selToplevel.Location = new System.Drawing.Point(45, 3);
            this.selToplevel.Name = "selToplevel";
            this.selToplevel.Size = new System.Drawing.Size(113, 17);
            this.selToplevel.TabIndex = 2;
            this.selToplevel.Text = "&Toplevel Windows";
            this.selToplevel.UseVisualStyleBackColor = true;
            // 
            // crossHair
            // 
            this.crossHair.Location = new System.Drawing.Point(3, 3);
            this.crossHair.Name = "crossHair";
            this.crossHair.Size = new System.Drawing.Size(36, 36);
            this.crossHair.TabIndex = 1;
            this.crossHair.CrosshairDragged += new System.EventHandler(this.crossHair_CrosshairDragged);
            this.crossHair.CrosshairDragging += new System.EventHandler(this.crossHair_CrosshairDragging);
            // 
            // heuristicSearch
            // 
            this.heuristicSearch.AutoSize = true;
            this.heuristicSearch.Checked = true;
            this.heuristicSearch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.heuristicSearch.Location = new System.Drawing.Point(308, 22);
            this.heuristicSearch.Name = "heuristicSearch";
            this.heuristicSearch.Size = new System.Drawing.Size(138, 17);
            this.heuristicSearch.TabIndex = 8;
            this.heuristicSearch.Text = "Heuristic Control search";
            this.heuristicSearch.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 373);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Winternal Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton selAccObjs;
        private System.Windows.Forms.RadioButton selChildWindows;
        private System.Windows.Forms.RadioButton selToplevel;
        private ManagedWinapi.Crosshair crossHair;
        private System.Windows.Forms.ToolStripMenuItem processesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toplevelWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem accessibleObjectsToolStripMenuItem;
        private System.Windows.Forms.ImageList treeImages;
        private System.Windows.Forms.GroupBox details;
        private System.Windows.Forms.ToolStripMenuItem processTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.CheckBox autoHide;
        private System.Windows.Forms.CheckBox allowChanges;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowByHandleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem windowsByTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsByClassNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stolenOrphanWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem visibleObjectsOnlyToolStripMenuItem;
        private System.Windows.Forms.CheckBox heuristicSearch;
    }
}

