namespace VolumeFader
{
    partial class LineControl
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
            this.lineName = new System.Windows.Forms.Label();
            this.mute1 = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lineName
            // 
            this.lineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineName.Location = new System.Drawing.Point(1, 0);
            this.lineName.Name = "lineName";
            this.lineName.Size = new System.Drawing.Size(199, 20);
            this.lineName.TabIndex = 1;
            this.lineName.Text = "LineName";
            this.lineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mute1
            // 
            this.mute1.AutoSize = true;
            this.mute1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mute1.Location = new System.Drawing.Point(3, 3);
            this.mute1.Name = "mute1";
            this.mute1.Size = new System.Drawing.Size(14, 15);
            this.mute1.TabIndex = 3;
            this.mute1.UseVisualStyleBackColor = true;
            this.mute1.Visible = false;
            this.mute1.CheckedChanged += new System.EventHandler(this.muteSwitchTemplate_CheckedChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.mute1, 0, 0);
            this.mainPanel.Location = new System.Drawing.Point(0, 21);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.mainPanel.Size = new System.Drawing.Size(200, 42);
            this.mainPanel.TabIndex = 4;
            // 
            // LineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lineName);
            this.Name = "LineControl";
            this.Size = new System.Drawing.Size(200, 89);
            this.Load += new System.EventHandler(this.LineControl_Load);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lineName;
        private System.Windows.Forms.CheckBox mute1;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
    }
}
