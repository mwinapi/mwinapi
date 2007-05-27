namespace WinternalExplorer
{
    partial class NoneControl
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
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(24, 19);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 13);
            this.label.TabIndex = 0;
            this.label.Text = "No element selected.";
            // 
            // NoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Name = "NoneControl";
            this.Size = new System.Drawing.Size(154, 51);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
    }
}
