namespace GuessEXE
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
            this.label1 = new System.Windows.Forms.Label();
            this.loglevel = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.log = new System.Windows.Forms.TextBox();
            this.crosshair = new ManagedWinapi.Crosshair();
            this.guessAll = new System.Windows.Forms.Button();
            this.autoHide = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Drag crosshair to a window to guess it!";
            // 
            // loglevel
            // 
            this.loglevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loglevel.FormattingEnabled = true;
            this.loglevel.Items.AddRange(new object[] {
            "Show Guesses Only",
            "Show More Information",
            "Show Verbose Information"});
            this.loglevel.Location = new System.Drawing.Point(54, 27);
            this.loglevel.Name = "loglevel";
            this.loglevel.Size = new System.Drawing.Size(192, 21);
            this.loglevel.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.log);
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 204);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guess Results";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.log.Location = new System.Drawing.Point(6, 19);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.log.Size = new System.Drawing.Size(298, 179);
            this.log.TabIndex = 0;
            this.log.WordWrap = false;
            // 
            // crosshair
            // 
            this.crosshair.Location = new System.Drawing.Point(12, 12);
            this.crosshair.Name = "crosshair";
            this.crosshair.Size = new System.Drawing.Size(36, 36);
            this.crosshair.TabIndex = 4;
            this.crosshair.CrosshairDragged += new System.EventHandler(this.crosshair_CrosshairDragged);
            this.crosshair.CrosshairDragging += new System.EventHandler(this.crosshair_CrosshairDragging);
            // 
            // guessAll
            // 
            this.guessAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guessAll.Location = new System.Drawing.Point(252, 27);
            this.guessAll.Name = "guessAll";
            this.guessAll.Size = new System.Drawing.Size(70, 21);
            this.guessAll.TabIndex = 5;
            this.guessAll.Text = "Guess All";
            this.guessAll.UseVisualStyleBackColor = true;
            this.guessAll.Click += new System.EventHandler(this.guessAll_Click);
            // 
            // autoHide
            // 
            this.autoHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoHide.AutoSize = true;
            this.autoHide.Location = new System.Drawing.Point(252, 8);
            this.autoHide.Name = "autoHide";
            this.autoHide.Size = new System.Drawing.Size(70, 17);
            this.autoHide.TabIndex = 6;
            this.autoHide.Text = "AutoHide";
            this.autoHide.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 270);
            this.Controls.Add(this.autoHide);
            this.Controls.Add(this.guessAll);
            this.Controls.Add(this.crosshair);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.loglevel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "GuessEXE";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox loglevel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox log;
        private ManagedWinapi.Crosshair crosshair;
        private System.Windows.Forms.Button guessAll;
        private System.Windows.Forms.CheckBox autoHide;
    }
}

