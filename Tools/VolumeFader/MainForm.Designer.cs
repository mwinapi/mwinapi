namespace VolumeFader
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.destLines = new System.Windows.Forms.ComboBox();
            this.mixers = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fadeLabel = new System.Windows.Forms.Label();
            this.fadeSpeed = new System.Windows.Forms.TrackBar();
            this.fadeButton = new System.Windows.Forms.Button();
            this.live = new System.Windows.Forms.CheckBox();
            this.srcLineControlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.destLineControl = new VolumeFader.LineControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fadeSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.destLines, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.mixers, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // destLines
            // 
            this.destLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.destLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destLines.FormattingEnabled = true;
            this.destLines.Location = new System.Drawing.Point(256, 3);
            this.destLines.Name = "destLines";
            this.destLines.Size = new System.Drawing.Size(248, 21);
            this.destLines.TabIndex = 1;
            this.destLines.SelectedIndexChanged += new System.EventHandler(this.destLines_SelectedIndexChanged);
            // 
            // mixers
            // 
            this.mixers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mixers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mixers.FormattingEnabled = true;
            this.mixers.Location = new System.Drawing.Point(3, 3);
            this.mixers.Name = "mixers";
            this.mixers.Size = new System.Drawing.Size(247, 21);
            this.mixers.TabIndex = 0;
            this.mixers.SelectedIndexChanged += new System.EventHandler(this.mixers_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fadeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.fadeSpeed);
            this.splitContainer1.Panel1.Controls.Add(this.fadeButton);
            this.splitContainer1.Panel1.Controls.Add(this.live);
            this.splitContainer1.Panel1.Controls.Add(this.destLineControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.srcLineControlContainer);
            this.splitContainer1.Size = new System.Drawing.Size(507, 257);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 1;
            // 
            // fadeLabel
            // 
            this.fadeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fadeLabel.Enabled = false;
            this.fadeLabel.Location = new System.Drawing.Point(3, 144);
            this.fadeLabel.Name = "fadeLabel";
            this.fadeLabel.Size = new System.Drawing.Size(220, 13);
            this.fadeLabel.TabIndex = 4;
            this.fadeLabel.Text = "Fade Speed:";
            // 
            // fadeSpeed
            // 
            this.fadeSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fadeSpeed.Enabled = false;
            this.fadeSpeed.Location = new System.Drawing.Point(3, 160);
            this.fadeSpeed.Maximum = 16;
            this.fadeSpeed.Name = "fadeSpeed";
            this.fadeSpeed.Size = new System.Drawing.Size(220, 42);
            this.fadeSpeed.TabIndex = 3;
            this.fadeSpeed.Value = 16;
            // 
            // fadeButton
            // 
            this.fadeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.fadeButton.Enabled = false;
            this.fadeButton.Location = new System.Drawing.Point(3, 208);
            this.fadeButton.Name = "fadeButton";
            this.fadeButton.Size = new System.Drawing.Size(220, 23);
            this.fadeButton.TabIndex = 2;
            this.fadeButton.Text = "Fade";
            this.fadeButton.UseVisualStyleBackColor = true;
            this.fadeButton.Click += new System.EventHandler(this.faceButton_Click);
            // 
            // live
            // 
            this.live.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.live.Checked = true;
            this.live.CheckState = System.Windows.Forms.CheckState.Checked;
            this.live.Location = new System.Drawing.Point(3, 237);
            this.live.Name = "live";
            this.live.Size = new System.Drawing.Size(220, 17);
            this.live.TabIndex = 1;
            this.live.Text = "Update values in real time";
            this.live.UseVisualStyleBackColor = true;
            this.live.CheckedChanged += new System.EventHandler(this.live_CheckedChanged);
            // 
            // srcLineControlContainer
            // 
            this.srcLineControlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.srcLineControlContainer.ColumnCount = 1;
            this.srcLineControlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.srcLineControlContainer.Location = new System.Drawing.Point(-1, 0);
            this.srcLineControlContainer.Name = "srcLineControlContainer";
            this.srcLineControlContainer.RowCount = 2;
            this.srcLineControlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.srcLineControlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.srcLineControlContainer.Size = new System.Drawing.Size(278, 230);
            this.srcLineControlContainer.TabIndex = 2;
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 50;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // destLineControl
            // 
            this.destLineControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.destLineControl.Line = null;
            this.destLineControl.Location = new System.Drawing.Point(3, 3);
            this.destLineControl.Name = "destLineControl";
            this.destLineControl.Size = new System.Drawing.Size(220, 109);
            this.destLineControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(531, 319);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Volume Fader";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fadeSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox destLines;
        private System.Windows.Forms.ComboBox mixers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LineControl destLineControl;
        private System.Windows.Forms.TableLayoutPanel srcLineControlContainer;
        private System.Windows.Forms.Button fadeButton;
        private System.Windows.Forms.CheckBox live;
        private System.Windows.Forms.Label fadeLabel;
        private System.Windows.Forms.TrackBar fadeSpeed;
        private System.Windows.Forms.Timer fadeTimer;

    }
}

