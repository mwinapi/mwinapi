namespace ContentsSaver
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
            this.crossHair = new ManagedWinapi.Crosshair();
            this.shortText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.copyright = new System.Windows.Forms.Label();
            this.kbdButton = new System.Windows.Forms.Button();
            this.className = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kbdControls = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.windowBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.controlBox = new System.Windows.Forms.ListBox();
            this.kbdControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // crossHair
            // 
            this.crossHair.Location = new System.Drawing.Point(12, 12);
            this.crossHair.Name = "crossHair";
            this.crossHair.Size = new System.Drawing.Size(36, 36);
            this.crossHair.TabIndex = 0;
            this.crossHair.CrosshairDragged += new System.EventHandler(this.crossHair_CrosshairDragged);
            this.crossHair.CrosshairDragging += new System.EventHandler(this.crossHair_CrosshairDragging);
            // 
            // shortText
            // 
            this.shortText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.shortText.Location = new System.Drawing.Point(54, 12);
            this.shortText.Name = "shortText";
            this.shortText.ReadOnly = true;
            this.shortText.Size = new System.Drawing.Size(227, 20);
            this.shortText.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(287, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "&Save...";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAllButton
            // 
            this.saveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAllButton.Enabled = false;
            this.saveAllButton.Location = new System.Drawing.Point(287, 38);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(75, 23);
            this.saveAllButton.TabIndex = 3;
            this.saveAllButton.Text = "Save &all...";
            this.saveAllButton.UseVisualStyleBackColor = true;
            this.saveAllButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // copyright
            // 
            this.copyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.copyright.Location = new System.Drawing.Point(12, 72);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(269, 13);
            this.copyright.TabIndex = 5;
            this.copyright.Text = "(c) 2006, 2007 Michael Schierl. Licensed under GPL.";
            // 
            // kbdButton
            // 
            this.kbdButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbdButton.Location = new System.Drawing.Point(287, 67);
            this.kbdButton.Name = "kbdButton";
            this.kbdButton.Size = new System.Drawing.Size(75, 23);
            this.kbdButton.TabIndex = 6;
            this.kbdButton.Text = "&Keyboard >>";
            this.kbdButton.UseVisualStyleBackColor = true;
            this.kbdButton.Click += new System.EventHandler(this.kbdButton_Click);
            // 
            // className
            // 
            this.className.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.className.Location = new System.Drawing.Point(95, 40);
            this.className.Name = "className";
            this.className.ReadOnly = true;
            this.className.Size = new System.Drawing.Size(186, 20);
            this.className.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "&Class:";
            // 
            // kbdControls
            // 
            this.kbdControls.Controls.Add(this.controlBox);
            this.kbdControls.Controls.Add(this.label3);
            this.kbdControls.Controls.Add(this.windowBox);
            this.kbdControls.Controls.Add(this.label2);
            this.kbdControls.Location = new System.Drawing.Point(12, 96);
            this.kbdControls.Name = "kbdControls";
            this.kbdControls.Size = new System.Drawing.Size(350, 221);
            this.kbdControls.TabIndex = 9;
            this.kbdControls.TabStop = false;
            this.kbdControls.Text = "Keyboard Selection";
            this.kbdControls.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Windows:";
            // 
            // windowBox
            // 
            this.windowBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.windowBox.FormattingEnabled = true;
            this.windowBox.Location = new System.Drawing.Point(6, 32);
            this.windowBox.Name = "windowBox";
            this.windowBox.Size = new System.Drawing.Size(338, 69);
            this.windowBox.TabIndex = 1;
            this.windowBox.SelectedIndexChanged += new System.EventHandler(this.windowBox_SelectedIndexChanged);
            this.windowBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.windowBox_Format);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "C&ontrols:";
            // 
            // controlBox
            // 
            this.controlBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox.FormattingEnabled = true;
            this.controlBox.Location = new System.Drawing.Point(6, 120);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(338, 95);
            this.controlBox.TabIndex = 3;
            this.controlBox.SelectedIndexChanged += new System.EventHandler(this.controlBox_SelectedIndexChanged);
            this.controlBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.controlBox_Format);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 343);
            this.Controls.Add(this.kbdControls);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.className);
            this.Controls.Add(this.kbdButton);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.saveAllButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.shortText);
            this.Controls.Add(this.crossHair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ContentsSaver#";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.kbdControls.ResumeLayout(false);
            this.kbdControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ManagedWinapi.Crosshair crossHair;
        private System.Windows.Forms.TextBox shortText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAllButton;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Button kbdButton;
        private System.Windows.Forms.TextBox className;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox kbdControls;
        private System.Windows.Forms.ListBox controlBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox windowBox;
        private System.Windows.Forms.Label label2;
    }
}

