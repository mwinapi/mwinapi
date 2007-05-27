namespace WinternalExplorer
{
    partial class FrameForm
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
            // FrameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(122, 98);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrameForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrameForm_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrameForm_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrameForm_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrameForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}