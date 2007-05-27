namespace WinternalExplorer
{
    partial class WindowControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.Button();
            this.positionContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.leftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.middleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionDrag = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.TextBox();
            this.className = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.process = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.hWndParent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkState = new System.Windows.Forms.ComboBox();
            this.dialogId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.outline = new System.Windows.Forms.CheckBox();
            this.capInfo = new System.Windows.Forms.Label();
            this.flash = new System.Windows.Forms.Label();
            this.wState = new System.Windows.Forms.ComboBox();
            this.topMost = new System.Windows.Forms.CheckBox();
            this.visible = new System.Windows.Forms.CheckBox();
            this.enabled = new System.Windows.Forms.CheckBox();
            this.resizeDrag = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Button();
            this.sizeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.s640x480ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s800x600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s1024x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s1280x1024ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.passwordChar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.contentLong = new System.Windows.Forms.TextBox();
            this.contentShort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.styleList = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.exStyleList = new System.Windows.Forms.CheckedListBox();
            this.exStyleText = new System.Windows.Forms.TextBox();
            this.styleText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hWnd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.positionContextMenu.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.sizeContextMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "&Title:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "&Class:";
            // 
            // position
            // 
            this.position.ContextMenuStrip = this.positionContextMenu;
            this.position.Location = new System.Drawing.Point(59, 6);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(79, 23);
            this.position.TabIndex = 4;
            this.position.Text = "1111x1111";
            this.position.UseVisualStyleBackColor = true;
            this.position.Click += new System.EventHandler(this.position_Click);
            // 
            // positionContextMenu
            // 
            this.positionContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.toolStripSeparator1,
            this.topToolStripMenuItem,
            this.middleToolStripMenuItem,
            this.bottomToolStripMenuItem});
            this.positionContextMenu.Name = "positionContextMenu";
            this.positionContextMenu.Size = new System.Drawing.Size(120, 142);
            // 
            // leftToolStripMenuItem
            // 
            this.leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            this.leftToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.leftToolStripMenuItem.Tag = "0";
            this.leftToolStripMenuItem.Text = "&Left";
            this.leftToolStripMenuItem.Click += new System.EventHandler(this.positionXToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.centerToolStripMenuItem.Tag = "1";
            this.centerToolStripMenuItem.Text = "&Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.positionXToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.rightToolStripMenuItem.Tag = "2";
            this.rightToolStripMenuItem.Text = "&Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.positionXToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(116, 6);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.topToolStripMenuItem.Tag = "0";
            this.topToolStripMenuItem.Text = "&Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.positionYToolStripMenuItem_Click);
            // 
            // middleToolStripMenuItem
            // 
            this.middleToolStripMenuItem.Name = "middleToolStripMenuItem";
            this.middleToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.middleToolStripMenuItem.Tag = "1";
            this.middleToolStripMenuItem.Text = "&Middle";
            this.middleToolStripMenuItem.Click += new System.EventHandler(this.positionYToolStripMenuItem_Click);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.bottomToolStripMenuItem.Tag = "2";
            this.bottomToolStripMenuItem.Text = "&Bottom";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.positionYToolStripMenuItem_Click);
            // 
            // positionDrag
            // 
            this.positionDrag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.positionDrag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.positionDrag.Location = new System.Drawing.Point(144, 7);
            this.positionDrag.Name = "positionDrag";
            this.positionDrag.Size = new System.Drawing.Size(41, 21);
            this.positionDrag.TabIndex = 5;
            this.positionDrag.Text = "Move";
            this.positionDrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.positionDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.positionDrag_MouseDown);
            this.positionDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.positionDrag_MouseMove);
            this.positionDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.positionDrag_MouseUp);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Location = new System.Drawing.Point(57, 34);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(324, 20);
            this.title.TabIndex = 6;
            this.title.TextChanged += new System.EventHandler(this.title_TextChanged);
            // 
            // className
            // 
            this.className.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.className.Location = new System.Drawing.Point(225, 3);
            this.className.Name = "className";
            this.className.ReadOnly = true;
            this.className.Size = new System.Drawing.Size(156, 20);
            this.className.TabIndex = 7;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage3);
            this.tabs.Location = new System.Drawing.Point(6, 60);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(375, 222);
            this.tabs.TabIndex = 8;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.process);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.hWndParent);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.checkState);
            this.tabPage2.Controls.Add(this.dialogId);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.outline);
            this.tabPage2.Controls.Add(this.capInfo);
            this.tabPage2.Controls.Add(this.flash);
            this.tabPage2.Controls.Add(this.wState);
            this.tabPage2.Controls.Add(this.topMost);
            this.tabPage2.Controls.Add(this.visible);
            this.tabPage2.Controls.Add(this.enabled);
            this.tabPage2.Controls.Add(this.resizeDrag);
            this.tabPage2.Controls.Add(this.size);
            this.tabPage2.Controls.Add(this.position);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.positionDrag);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(367, 196);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Appearance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // process
            // 
            this.process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.process.Location = new System.Drawing.Point(132, 135);
            this.process.Name = "process";
            this.process.ReadOnly = true;
            this.process.Size = new System.Drawing.Size(229, 20);
            this.process.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Process:";
            // 
            // hWndParent
            // 
            this.hWndParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hWndParent.Location = new System.Drawing.Point(132, 109);
            this.hWndParent.Name = "hWndParent";
            this.hWndParent.ReadOnly = true;
            this.hWndParent.Size = new System.Drawing.Size(229, 20);
            this.hWndParent.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Parent Window Handle:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(200, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "CheckState:";
            // 
            // checkState
            // 
            this.checkState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkState.FormattingEnabled = true;
            this.checkState.Items.AddRange(new object[] {
            "Unchecked",
            "Checked",
            "Indeterminate"});
            this.checkState.Location = new System.Drawing.Point(272, 82);
            this.checkState.Name = "checkState";
            this.checkState.Size = new System.Drawing.Size(89, 21);
            this.checkState.TabIndex = 17;
            this.checkState.SelectedIndexChanged += new System.EventHandler(this.checkState_SelectedIndexChanged);
            // 
            // dialogId
            // 
            this.dialogId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogId.Location = new System.Drawing.Point(66, 82);
            this.dialogId.Name = "dialogId";
            this.dialogId.ReadOnly = true;
            this.dialogId.Size = new System.Drawing.Size(128, 20);
            this.dialogId.TabIndex = 16;
            this.dialogId.Text = "0x00000000 (1234567)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Dialog ID:";
            // 
            // outline
            // 
            this.outline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outline.AutoSize = true;
            this.outline.Location = new System.Drawing.Point(272, 58);
            this.outline.Name = "outline";
            this.outline.Size = new System.Drawing.Size(89, 17);
            this.outline.TabIndex = 14;
            this.outline.Text = "Show Outline";
            this.outline.UseVisualStyleBackColor = true;
            this.outline.CheckedChanged += new System.EventHandler(this.outline_CheckedChanged);
            // 
            // capInfo
            // 
            this.capInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.capInfo.Location = new System.Drawing.Point(6, 61);
            this.capInfo.Name = "capInfo";
            this.capInfo.Size = new System.Drawing.Size(260, 18);
            this.capInfo.TabIndex = 13;
            this.capInfo.Text = "Window is not movable and not resizable.";
            // 
            // flash
            // 
            this.flash.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flash.Location = new System.Drawing.Point(71, 32);
            this.flash.Name = "flash";
            this.flash.Size = new System.Drawing.Size(41, 21);
            this.flash.TabIndex = 11;
            this.flash.Text = "Flash";
            this.flash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flash.MouseDown += new System.Windows.Forms.MouseEventHandler(this.flash_MouseDownUp);
            this.flash.MouseUp += new System.Windows.Forms.MouseEventHandler(this.flash_MouseDownUp);
            // 
            // wState
            // 
            this.wState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wState.FormattingEnabled = true;
            this.wState.Items.AddRange(new object[] {
            "Normal",
            "Minimized",
            "Maximized"});
            this.wState.Location = new System.Drawing.Point(293, 33);
            this.wState.Name = "wState";
            this.wState.Size = new System.Drawing.Size(68, 21);
            this.wState.TabIndex = 12;
            this.wState.SelectedIndexChanged += new System.EventHandler(this.wState_SelectedIndexChanged);
            // 
            // topMost
            // 
            this.topMost.AutoSize = true;
            this.topMost.Location = new System.Drawing.Point(189, 35);
            this.topMost.Name = "topMost";
            this.topMost.Size = new System.Drawing.Size(98, 17);
            this.topMost.TabIndex = 10;
            this.topMost.Text = "Always On Top";
            this.topMost.UseVisualStyleBackColor = true;
            this.topMost.CheckedChanged += new System.EventHandler(this.topMost_CheckedChanged);
            // 
            // visible
            // 
            this.visible.AutoSize = true;
            this.visible.Location = new System.Drawing.Point(9, 35);
            this.visible.Name = "visible";
            this.visible.Size = new System.Drawing.Size(56, 17);
            this.visible.TabIndex = 9;
            this.visible.Text = "Visible";
            this.visible.UseVisualStyleBackColor = true;
            this.visible.CheckedChanged += new System.EventHandler(this.visible_CheckedChanged);
            // 
            // enabled
            // 
            this.enabled.AutoSize = true;
            this.enabled.Location = new System.Drawing.Point(118, 35);
            this.enabled.Name = "enabled";
            this.enabled.Size = new System.Drawing.Size(65, 17);
            this.enabled.TabIndex = 8;
            this.enabled.Text = "Enabled";
            this.enabled.UseVisualStyleBackColor = true;
            this.enabled.CheckedChanged += new System.EventHandler(this.enabled_CheckedChanged);
            // 
            // resizeDrag
            // 
            this.resizeDrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resizeDrag.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.resizeDrag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resizeDrag.Location = new System.Drawing.Point(320, 7);
            this.resizeDrag.Name = "resizeDrag";
            this.resizeDrag.Size = new System.Drawing.Size(41, 21);
            this.resizeDrag.TabIndex = 7;
            this.resizeDrag.Text = "Resize";
            this.resizeDrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resizeDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resizeDrag_MouseDown);
            this.resizeDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resizeDrag_MouseMove);
            this.resizeDrag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resizeDrag_MouseUp);
            // 
            // size
            // 
            this.size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.size.ContextMenuStrip = this.sizeContextMenu;
            this.size.Location = new System.Drawing.Point(235, 6);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(79, 23);
            this.size.TabIndex = 6;
            this.size.Text = "1111x1111";
            this.size.UseVisualStyleBackColor = true;
            this.size.Click += new System.EventHandler(this.size_Click);
            // 
            // sizeContextMenu
            // 
            this.sizeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s640x480ToolStripMenuItem,
            this.s800x600ToolStripMenuItem,
            this.s1024x768ToolStripMenuItem,
            this.s1280x1024ToolStripMenuItem});
            this.sizeContextMenu.Name = "sizeContextMenu";
            this.sizeContextMenu.Size = new System.Drawing.Size(140, 92);
            // 
            // s640x480ToolStripMenuItem
            // 
            this.s640x480ToolStripMenuItem.Enabled = false;
            this.s640x480ToolStripMenuItem.Name = "s640x480ToolStripMenuItem";
            this.s640x480ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.s640x480ToolStripMenuItem.Tag = "640x480";
            this.s640x480ToolStripMenuItem.Text = "&640x480";
            this.s640x480ToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // s800x600ToolStripMenuItem
            // 
            this.s800x600ToolStripMenuItem.Enabled = false;
            this.s800x600ToolStripMenuItem.Name = "s800x600ToolStripMenuItem";
            this.s800x600ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.s800x600ToolStripMenuItem.Tag = "800x600";
            this.s800x600ToolStripMenuItem.Text = "&800x600";
            this.s800x600ToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // s1024x768ToolStripMenuItem
            // 
            this.s1024x768ToolStripMenuItem.Enabled = false;
            this.s1024x768ToolStripMenuItem.Name = "s1024x768ToolStripMenuItem";
            this.s1024x768ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.s1024x768ToolStripMenuItem.Tag = "1024x768";
            this.s1024x768ToolStripMenuItem.Text = "&1024x768";
            this.s1024x768ToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // s1280x1024ToolStripMenuItem
            // 
            this.s1280x1024ToolStripMenuItem.Enabled = false;
            this.s1280x1024ToolStripMenuItem.Name = "s1280x1024ToolStripMenuItem";
            this.s1280x1024ToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.s1280x1024ToolStripMenuItem.Tag = "1280x1024";
            this.s1280x1024ToolStripMenuItem.Text = "1&280x1024";
            this.s1280x1024ToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.passwordChar);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.contentLong);
            this.tabPage1.Controls.Add(this.contentShort);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(367, 196);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Content";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // passwordChar
            // 
            this.passwordChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordChar.Location = new System.Drawing.Point(119, 170);
            this.passwordChar.Name = "passwordChar";
            this.passwordChar.ReadOnly = true;
            this.passwordChar.Size = new System.Drawing.Size(242, 20);
            this.passwordChar.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Password Character:";
            // 
            // contentLong
            // 
            this.contentLong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentLong.Location = new System.Drawing.Point(11, 33);
            this.contentLong.Multiline = true;
            this.contentLong.Name = "contentLong";
            this.contentLong.ReadOnly = true;
            this.contentLong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.contentLong.Size = new System.Drawing.Size(350, 126);
            this.contentLong.TabIndex = 2;
            // 
            // contentShort
            // 
            this.contentShort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contentShort.Location = new System.Drawing.Point(67, 7);
            this.contentShort.Name = "contentShort";
            this.contentShort.ReadOnly = true;
            this.contentShort.Size = new System.Drawing.Size(294, 20);
            this.contentShort.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Summary:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(367, 196);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Style";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.styleList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.exStyleList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.exStyleText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.styleText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 190);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // styleList
            // 
            this.styleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.styleList.FormattingEnabled = true;
            this.styleList.IntegralHeight = false;
            this.styleList.Location = new System.Drawing.Point(3, 42);
            this.styleList.Name = "styleList";
            this.styleList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.styleList.Size = new System.Drawing.Size(174, 145);
            this.styleList.TabIndex = 11;
            this.styleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.styleList_ItemCheck);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Extended Style:";
            // 
            // exStyleList
            // 
            this.exStyleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exStyleList.FormattingEnabled = true;
            this.exStyleList.IntegralHeight = false;
            this.exStyleList.Location = new System.Drawing.Point(183, 42);
            this.exStyleList.Name = "exStyleList";
            this.exStyleList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.exStyleList.Size = new System.Drawing.Size(175, 145);
            this.exStyleList.TabIndex = 8;
            this.exStyleList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.exStyleList_ItemCheck);
            // 
            // exStyleText
            // 
            this.exStyleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exStyleText.Location = new System.Drawing.Point(183, 16);
            this.exStyleText.Name = "exStyleText";
            this.exStyleText.ReadOnly = true;
            this.exStyleText.Size = new System.Drawing.Size(175, 20);
            this.exStyleText.TabIndex = 7;
            // 
            // styleText
            // 
            this.styleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.styleText.Location = new System.Drawing.Point(3, 16);
            this.styleText.Name = "styleText";
            this.styleText.ReadOnly = true;
            this.styleText.Size = new System.Drawing.Size(174, 20);
            this.styleText.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Style:";
            // 
            // hWnd
            // 
            this.hWnd.Location = new System.Drawing.Point(57, 3);
            this.hWnd.Name = "hWnd";
            this.hWnd.ReadOnly = true;
            this.hWnd.Size = new System.Drawing.Size(121, 20);
            this.hWnd.TabIndex = 10;
            this.hWnd.Text = "0x00a0affe (1234567)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "&Handle:";
            // 
            // WindowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hWnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.className);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "WindowControl";
            this.Size = new System.Drawing.Size(384, 285);
            this.positionContextMenu.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.sizeContextMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button position;
        private System.Windows.Forms.Label positionDrag;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label resizeDrag;
        private System.Windows.Forms.Button size;
        private System.Windows.Forms.TextBox hWnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox topMost;
        private System.Windows.Forms.CheckBox visible;
        private System.Windows.Forms.CheckBox enabled;
        private System.Windows.Forms.ComboBox wState;
        private System.Windows.Forms.Label flash;
        private System.Windows.Forms.Label capInfo;
        private System.Windows.Forms.ContextMenuStrip positionContextMenu;
        private System.Windows.Forms.ToolStripMenuItem leftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip sizeContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem middleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s640x480ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s800x600ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s1024x768ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s1280x1024ToolStripMenuItem;
        private System.Windows.Forms.CheckBox outline;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox styleList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox exStyleList;
        private System.Windows.Forms.TextBox exStyleText;
        private System.Windows.Forms.TextBox styleText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox contentLong;
        private System.Windows.Forms.TextBox contentShort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox passwordChar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dialogId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox checkState;
        private System.Windows.Forms.TextBox hWndParent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox process;
        private System.Windows.Forms.Label label13;
    }
}
