namespace ShootNotes
{
    partial class NoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            this.mainNote = new System.Windows.Forms.Panel();
            this.noteContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.noteTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingToolbar = new System.Windows.Forms.Panel();
            this.clear = new System.Windows.Forms.Button();
            this.largeDrawingToolbarMark = new System.Windows.Forms.Panel();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.smallDrawingToolbar = new System.Windows.Forms.Panel();
            this.colorBox2 = new System.Windows.Forms.PictureBox();
            this.moveMode2 = new System.Windows.Forms.RadioButton();
            this.collapse = new System.Windows.Forms.CheckBox();
            this.rectMode2 = new System.Windows.Forms.RadioButton();
            this.lineMode2 = new System.Windows.Forms.RadioButton();
            this.freehandMode2 = new System.Windows.Forms.RadioButton();
            this.rectMode = new System.Windows.Forms.RadioButton();
            this.lineMode = new System.Windows.Forms.RadioButton();
            this.freehandMode = new System.Windows.Forms.RadioButton();
            this.moveMode = new System.Windows.Forms.RadioButton();
            this.textNote = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.mainNote.SuspendLayout();
            this.noteContextMenu.SuspendLayout();
            this.drawingToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.smallDrawingToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox2)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainNote
            // 
            this.mainNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainNote.BackColor = System.Drawing.Color.Blue;
            this.mainNote.ContextMenuStrip = this.noteContextMenu;
            this.mainNote.Controls.Add(this.drawingToolbar);
            this.mainNote.Location = new System.Drawing.Point(0, 0);
            this.mainNote.Name = "mainNote";
            this.mainNote.Size = new System.Drawing.Size(430, 241);
            this.mainNote.TabIndex = 0;
            this.mainNote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainNote_MouseDown);
            this.mainNote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainNote_MouseMove);
            this.mainNote.Paint += new System.Windows.Forms.PaintEventHandler(this.mainNote_Paint);
            this.mainNote.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainNote_MouseUp);
            // 
            // noteContextMenu
            // 
            this.noteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameNoteToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolWindowToolStripMenuItem,
            this.drawingToolbarToolStripMenuItem,
            this.toolStripSeparator2,
            this.noteTextToolStripMenuItem});
            this.noteContextMenu.Name = "noteContextMenu";
            this.noteContextMenu.Size = new System.Drawing.Size(164, 104);
            // 
            // renameNoteToolStripMenuItem
            // 
            this.renameNoteToolStripMenuItem.Name = "renameNoteToolStripMenuItem";
            this.renameNoteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.renameNoteToolStripMenuItem.Text = "Re&name Note...";
            this.renameNoteToolStripMenuItem.Click += new System.EventHandler(this.renameNoteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // toolWindowToolStripMenuItem
            // 
            this.toolWindowToolStripMenuItem.Checked = true;
            this.toolWindowToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolWindowToolStripMenuItem.Name = "toolWindowToolStripMenuItem";
            this.toolWindowToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.toolWindowToolStripMenuItem.Text = "&Tool Window";
            this.toolWindowToolStripMenuItem.Click += new System.EventHandler(this.toolWindowToolStripMenuItem_Click);
            // 
            // drawingToolbarToolStripMenuItem
            // 
            this.drawingToolbarToolStripMenuItem.Name = "drawingToolbarToolStripMenuItem";
            this.drawingToolbarToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.drawingToolbarToolStripMenuItem.Text = "&Drawing Toolbar";
            this.drawingToolbarToolStripMenuItem.Click += new System.EventHandler(this.drawingToolbarToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // noteTextToolStripMenuItem
            // 
            this.noteTextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disabledToolStripMenuItem,
            this.rightToolStripMenuItem,
            this.bottomToolStripMenuItem});
            this.noteTextToolStripMenuItem.Name = "noteTextToolStripMenuItem";
            this.noteTextToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.noteTextToolStripMenuItem.Text = "&Note T&ext";
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Checked = true;
            this.disabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.disabledToolStripMenuItem.Text = "&Off";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // rightToolStripMenuItem
            // 
            this.rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            this.rightToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.rightToolStripMenuItem.Text = "&Right";
            this.rightToolStripMenuItem.Click += new System.EventHandler(this.rightToolStripMenuItem_Click);
            // 
            // bottomToolStripMenuItem
            // 
            this.bottomToolStripMenuItem.Name = "bottomToolStripMenuItem";
            this.bottomToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.bottomToolStripMenuItem.Text = "&Bottom";
            this.bottomToolStripMenuItem.Click += new System.EventHandler(this.bottomToolStripMenuItem_Click);
            // 
            // drawingToolbar
            // 
            this.drawingToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.drawingToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingToolbar.Controls.Add(this.clear);
            this.drawingToolbar.Controls.Add(this.largeDrawingToolbarMark);
            this.drawingToolbar.Controls.Add(this.colorBox);
            this.drawingToolbar.Controls.Add(this.smallDrawingToolbar);
            this.drawingToolbar.Controls.Add(this.rectMode);
            this.drawingToolbar.Controls.Add(this.lineMode);
            this.drawingToolbar.Controls.Add(this.freehandMode);
            this.drawingToolbar.Controls.Add(this.moveMode);
            this.drawingToolbar.Location = new System.Drawing.Point(12, 12);
            this.drawingToolbar.Name = "drawingToolbar";
            this.drawingToolbar.Size = new System.Drawing.Size(128, 134);
            this.drawingToolbar.TabIndex = 0;
            this.drawingToolbar.Visible = false;
            this.drawingToolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseDown);
            this.drawingToolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseMove);
            this.drawingToolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseUp);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(80, 47);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(39, 22);
            this.clear.TabIndex = 12;
            this.clear.Text = "&Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            this.clear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            // 
            // largeDrawingToolbarMark
            // 
            this.largeDrawingToolbarMark.Location = new System.Drawing.Point(116, 119);
            this.largeDrawingToolbarMark.Name = "largeDrawingToolbarMark";
            this.largeDrawingToolbarMark.Size = new System.Drawing.Size(11, 14);
            this.largeDrawingToolbarMark.TabIndex = 11;
            this.largeDrawingToolbarMark.Visible = false;
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.Red;
            this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorBox.Location = new System.Drawing.Point(80, 19);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(39, 22);
            this.colorBox.TabIndex = 10;
            this.colorBox.TabStop = false;
            this.colorBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorBox_MouseUp);
            // 
            // smallDrawingToolbar
            // 
            this.smallDrawingToolbar.Controls.Add(this.colorBox2);
            this.smallDrawingToolbar.Controls.Add(this.moveMode2);
            this.smallDrawingToolbar.Controls.Add(this.collapse);
            this.smallDrawingToolbar.Controls.Add(this.rectMode2);
            this.smallDrawingToolbar.Controls.Add(this.lineMode2);
            this.smallDrawingToolbar.Controls.Add(this.freehandMode2);
            this.smallDrawingToolbar.Location = new System.Drawing.Point(0, 0);
            this.smallDrawingToolbar.Name = "smallDrawingToolbar";
            this.smallDrawingToolbar.Size = new System.Drawing.Size(127, 16);
            this.smallDrawingToolbar.TabIndex = 9;
            this.smallDrawingToolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseDown);
            this.smallDrawingToolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseMove);
            this.smallDrawingToolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingToolbar_MouseUp);
            // 
            // colorBox2
            // 
            this.colorBox2.BackColor = System.Drawing.Color.Red;
            this.colorBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorBox2.Location = new System.Drawing.Point(109, 3);
            this.colorBox2.Name = "colorBox2";
            this.colorBox2.Size = new System.Drawing.Size(10, 10);
            this.colorBox2.TabIndex = 11;
            this.colorBox2.TabStop = false;
            this.colorBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorBox_MouseUp);
            // 
            // moveMode2
            // 
            this.moveMode2.Appearance = System.Windows.Forms.Appearance.Button;
            this.moveMode2.Checked = true;
            this.moveMode2.Location = new System.Drawing.Point(45, 3);
            this.moveMode2.Name = "moveMode2";
            this.moveMode2.Size = new System.Drawing.Size(10, 10);
            this.moveMode2.TabIndex = 5;
            this.moveMode2.TabStop = true;
            this.moveMode2.UseVisualStyleBackColor = true;
            this.moveMode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.moveMode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // collapse
            // 
            this.collapse.Appearance = System.Windows.Forms.Appearance.Button;
            this.collapse.Location = new System.Drawing.Point(3, 3);
            this.collapse.Name = "collapse";
            this.collapse.Size = new System.Drawing.Size(36, 10);
            this.collapse.TabIndex = 4;
            this.collapse.Text = "Compact";
            this.collapse.UseVisualStyleBackColor = false;
            this.collapse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.collapse.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rectMode2
            // 
            this.rectMode2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectMode2.Location = new System.Drawing.Point(77, 3);
            this.rectMode2.Name = "rectMode2";
            this.rectMode2.Size = new System.Drawing.Size(10, 10);
            this.rectMode2.TabIndex = 8;
            this.rectMode2.UseVisualStyleBackColor = true;
            this.rectMode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.rectMode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // lineMode2
            // 
            this.lineMode2.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineMode2.Location = new System.Drawing.Point(61, 3);
            this.lineMode2.Name = "lineMode2";
            this.lineMode2.Size = new System.Drawing.Size(10, 10);
            this.lineMode2.TabIndex = 6;
            this.lineMode2.UseVisualStyleBackColor = true;
            this.lineMode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.lineMode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // freehandMode2
            // 
            this.freehandMode2.Appearance = System.Windows.Forms.Appearance.Button;
            this.freehandMode2.Location = new System.Drawing.Point(93, 3);
            this.freehandMode2.Name = "freehandMode2";
            this.freehandMode2.Size = new System.Drawing.Size(10, 10);
            this.freehandMode2.TabIndex = 7;
            this.freehandMode2.UseVisualStyleBackColor = true;
            this.freehandMode2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.freehandMode2.CheckedChanged += new System.EventHandler(this.mode2_CheckedChanged);
            // 
            // rectMode
            // 
            this.rectMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.rectMode.Location = new System.Drawing.Point(3, 75);
            this.rectMode.Name = "rectMode";
            this.rectMode.Size = new System.Drawing.Size(71, 22);
            this.rectMode.TabIndex = 3;
            this.rectMode.Text = "Re&ctangles";
            this.rectMode.UseVisualStyleBackColor = true;
            this.rectMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.rectMode.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // lineMode
            // 
            this.lineMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineMode.Location = new System.Drawing.Point(3, 47);
            this.lineMode.Name = "lineMode";
            this.lineMode.Size = new System.Drawing.Size(71, 22);
            this.lineMode.TabIndex = 2;
            this.lineMode.Text = "&Lines";
            this.lineMode.UseVisualStyleBackColor = true;
            this.lineMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.lineMode.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // freehandMode
            // 
            this.freehandMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.freehandMode.Location = new System.Drawing.Point(3, 103);
            this.freehandMode.Name = "freehandMode";
            this.freehandMode.Size = new System.Drawing.Size(71, 22);
            this.freehandMode.TabIndex = 1;
            this.freehandMode.Text = "&FreeHand";
            this.freehandMode.UseVisualStyleBackColor = true;
            this.freehandMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.freehandMode.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // moveMode
            // 
            this.moveMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.moveMode.Checked = true;
            this.moveMode.Location = new System.Drawing.Point(3, 19);
            this.moveMode.Name = "moveMode";
            this.moveMode.Size = new System.Drawing.Size(71, 22);
            this.moveMode.TabIndex = 0;
            this.moveMode.TabStop = true;
            this.moveMode.Text = "&Move";
            this.moveMode.UseVisualStyleBackColor = true;
            this.moveMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.moveMode.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // textNote
            // 
            this.textNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textNote.Location = new System.Drawing.Point(335, 221);
            this.textNote.Multiline = true;
            this.textNote.Name = "textNote";
            this.textNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textNote.Size = new System.Drawing.Size(114, 48);
            this.textNote.TabIndex = 1;
            this.textNote.Text = "Note Text";
            this.textNote.Visible = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(409, 62);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(68, 64);
            this.splitContainer.SplitterDistance = 35;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.Visible = false;
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 240);
            this.Controls.Add(this.textNote);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.mainNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteForm";
            this.Text = "ShootNotes";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NoteForm_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NoteForm_FormClosing);
            this.Load += new System.EventHandler(this.NoteForm_Load);
            this.mainNote.ResumeLayout(false);
            this.noteContextMenu.ResumeLayout(false);
            this.drawingToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.smallDrawingToolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox2)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainNote;
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip noteContextMenu;
        private System.Windows.Forms.ToolStripMenuItem renameNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem noteTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel drawingToolbar;
        private System.Windows.Forms.RadioButton rectMode;
        private System.Windows.Forms.RadioButton lineMode;
        private System.Windows.Forms.RadioButton freehandMode;
        private System.Windows.Forms.RadioButton moveMode;
        private System.Windows.Forms.CheckBox collapse;
        private System.Windows.Forms.RadioButton lineMode2;
        private System.Windows.Forms.RadioButton moveMode2;
        private System.Windows.Forms.RadioButton rectMode2;
        private System.Windows.Forms.RadioButton freehandMode2;
        private System.Windows.Forms.Panel smallDrawingToolbar;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.PictureBox colorBox2;
        private System.Windows.Forms.Panel largeDrawingToolbarMark;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}