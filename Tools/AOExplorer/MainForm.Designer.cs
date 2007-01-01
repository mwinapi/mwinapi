namespace AOExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.propValue = new System.Windows.Forms.TextBox();
            this.propDescription = new System.Windows.Forms.TextBox();
            this.propChildID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.propLocation = new System.Windows.Forms.Button();
            this.propDefaultAction = new System.Windows.Forms.Button();
            this.propWindow = new System.Windows.Forms.TextBox();
            this.propState = new System.Windows.Forms.TextBox();
            this.propRole = new System.Windows.Forms.TextBox();
            this.propName = new System.Windows.Forms.TextBox();
            this.includeChildren = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selCaret = new System.Windows.Forms.Button();
            this.selMouse = new System.Windows.Forms.Button();
            this.allParents = new System.Windows.Forms.CheckBox();
            this.selCrosshair = new ManagedWinapi.Crosshair();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(654, 374);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 1;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.HideSelection = false;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(197, 374);
            this.tree.TabIndex = 0;
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tree_BeforeExpand);
            this.tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.propValue);
            this.groupBox2.Controls.Add(this.propDescription);
            this.groupBox2.Controls.Add(this.propChildID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.propLocation);
            this.groupBox2.Controls.Add(this.propDefaultAction);
            this.groupBox2.Controls.Add(this.propWindow);
            this.groupBox2.Controls.Add(this.propState);
            this.groupBox2.Controls.Add(this.propRole);
            this.groupBox2.Controls.Add(this.propName);
            this.groupBox2.Controls.Add(this.includeChildren);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 281);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object Properties";
            // 
            // propValue
            // 
            this.propValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propValue.Location = new System.Drawing.Point(75, 197);
            this.propValue.Multiline = true;
            this.propValue.Name = "propValue";
            this.propValue.ReadOnly = true;
            this.propValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.propValue.Size = new System.Drawing.Size(363, 52);
            this.propValue.TabIndex = 17;
            // 
            // propDescription
            // 
            this.propDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propDescription.Location = new System.Drawing.Point(75, 129);
            this.propDescription.Multiline = true;
            this.propDescription.Name = "propDescription";
            this.propDescription.ReadOnly = true;
            this.propDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.propDescription.Size = new System.Drawing.Size(363, 62);
            this.propDescription.TabIndex = 15;
            // 
            // propChildID
            // 
            this.propChildID.Location = new System.Drawing.Point(61, 103);
            this.propChildID.Name = "propChildID";
            this.propChildID.ReadOnly = true;
            this.propChildID.Size = new System.Drawing.Size(40, 20);
            this.propChildID.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Child&ID:";
            // 
            // propLocation
            // 
            this.propLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.propLocation.Location = new System.Drawing.Point(266, 71);
            this.propLocation.Name = "propLocation";
            this.propLocation.Size = new System.Drawing.Size(172, 23);
            this.propLocation.TabIndex = 9;
            this.propLocation.Text = "button1";
            this.propLocation.UseVisualStyleBackColor = true;
            this.propLocation.Click += new System.EventHandler(this.propLocation_Click);
            // 
            // propDefaultAction
            // 
            this.propDefaultAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propDefaultAction.Location = new System.Drawing.Point(187, 100);
            this.propDefaultAction.Name = "propDefaultAction";
            this.propDefaultAction.Size = new System.Drawing.Size(251, 23);
            this.propDefaultAction.TabIndex = 13;
            this.propDefaultAction.Text = "button1";
            this.propDefaultAction.UseVisualStyleBackColor = true;
            this.propDefaultAction.Click += new System.EventHandler(this.propDefaultAction_Click);
            // 
            // propWindow
            // 
            this.propWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propWindow.Location = new System.Drawing.Point(61, 73);
            this.propWindow.Name = "propWindow";
            this.propWindow.ReadOnly = true;
            this.propWindow.Size = new System.Drawing.Size(142, 20);
            this.propWindow.TabIndex = 7;
            // 
            // propState
            // 
            this.propState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propState.Location = new System.Drawing.Point(47, 45);
            this.propState.Name = "propState";
            this.propState.ReadOnly = true;
            this.propState.Size = new System.Drawing.Size(391, 20);
            this.propState.TabIndex = 5;
            // 
            // propRole
            // 
            this.propRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.propRole.Location = new System.Drawing.Point(259, 19);
            this.propRole.Name = "propRole";
            this.propRole.ReadOnly = true;
            this.propRole.Size = new System.Drawing.Size(179, 20);
            this.propRole.TabIndex = 3;
            // 
            // propName
            // 
            this.propName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propName.Location = new System.Drawing.Point(47, 19);
            this.propName.Name = "propName";
            this.propName.ReadOnly = true;
            this.propName.Size = new System.Drawing.Size(168, 20);
            this.propName.TabIndex = 1;
            // 
            // includeChildren
            // 
            this.includeChildren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.includeChildren.AutoSize = true;
            this.includeChildren.Location = new System.Drawing.Point(75, 255);
            this.includeChildren.Name = "includeChildren";
            this.includeChildren.Size = new System.Drawing.Size(189, 17);
            this.includeChildren.TabIndex = 18;
            this.includeChildren.Text = "Include Values from &child elements";
            this.includeChildren.UseVisualStyleBackColor = true;
            this.includeChildren.CheckedChanged += new System.EventHandler(this.includeChildren_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "&Window:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "&Value:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "&Location:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "&Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Default&Action:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&State:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Role:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.allParents);
            this.groupBox1.Controls.Add(this.selCaret);
            this.groupBox1.Controls.Add(this.selMouse);
            this.groupBox1.Controls.Add(this.selCrosshair);
            this.groupBox1.Location = new System.Drawing.Point(104, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Object";
            // 
            // selCaret
            // 
            this.selCaret.Location = new System.Drawing.Point(144, 19);
            this.selCaret.Name = "selCaret";
            this.selCaret.Size = new System.Drawing.Size(90, 23);
            this.selCaret.TabIndex = 2;
            this.selCaret.Text = "&TextCaret";
            this.selCaret.UseVisualStyleBackColor = true;
            this.selCaret.Click += new System.EventHandler(this.selCaret_Click);
            // 
            // selMouse
            // 
            this.selMouse.Location = new System.Drawing.Point(48, 19);
            this.selMouse.Name = "selMouse";
            this.selMouse.Size = new System.Drawing.Size(90, 23);
            this.selMouse.TabIndex = 1;
            this.selMouse.Text = "&MousePointer";
            this.selMouse.UseVisualStyleBackColor = true;
            this.selMouse.Click += new System.EventHandler(this.selMouse_Click);
            // 
            // allParents
            // 
            this.allParents.Checked = true;
            this.allParents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allParents.Location = new System.Drawing.Point(48, 48);
            this.allParents.Name = "allParents";
            this.allParents.Size = new System.Drawing.Size(186, 18);
            this.allParents.TabIndex = 3;
            this.allParents.Text = "Include all &Parents";
            this.allParents.UseVisualStyleBackColor = true;
            // 
            // selCrosshair
            // 
            this.selCrosshair.Location = new System.Drawing.Point(6, 19);
            this.selCrosshair.Name = "selCrosshair";
            this.selCrosshair.Size = new System.Drawing.Size(36, 36);
            this.selCrosshair.TabIndex = 0;
            this.selCrosshair.CrosshairDragged += new System.EventHandler(this.selCrosshair_CrosshairDragged);
            this.selCrosshair.CrosshairDragging += new System.EventHandler(this.selCrosshair_CrosshairDragging);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 374);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Accessible Object Explorer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ManagedWinapi.Crosshair selCrosshair;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selMouse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selCaret;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox propRole;
        private System.Windows.Forms.TextBox propName;
        private System.Windows.Forms.CheckBox includeChildren;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox propState;
        private System.Windows.Forms.Button propLocation;
        private System.Windows.Forms.Button propDefaultAction;
        private System.Windows.Forms.TextBox propWindow;
        private System.Windows.Forms.TextBox propChildID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox propDescription;
        private System.Windows.Forms.TextBox propValue;
        private System.Windows.Forms.CheckBox allParents;
    }
}

