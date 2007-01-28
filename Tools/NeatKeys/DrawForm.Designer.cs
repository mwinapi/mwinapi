namespace NeatKeys
{
    partial class DrawForm
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
            this.SuspendLayout();
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(322, 182);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DrawForm";
            this.Opacity = 0.85;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DrawForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawForm_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseUp);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DrawForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DrawForm_KeyUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawForm_MouseDown);
            this.Load += new System.EventHandler(this.DrawForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}