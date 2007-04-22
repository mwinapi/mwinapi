namespace ClipHancer
{
    partial class PopupEntry
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
            this.pct = new System.Windows.Forms.PictureBox();
            this.lbl = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pct)).BeginInit();
            this.SuspendLayout();
            // 
            // pct
            // 
            this.pct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pct.InitialImage = null;
            this.pct.Location = new System.Drawing.Point(35, 8);
            this.pct.Name = "pct";
            this.pct.Size = new System.Drawing.Size(32, 32);
            this.pct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pct.TabIndex = 0;
            this.pct.TabStop = false;
            this.pct.MouseDown += new System.Windows.Forms.MouseEventHandler(this.any_MouseDown);
            // 
            // lbl
            // 
            this.lbl.AutoEllipsis = true;
            this.lbl.Location = new System.Drawing.Point(73, 18);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(163, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "[Preview]";
            this.lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.any_MouseDown);
            // 
            // num
            // 
            this.num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num.ForeColor = System.Drawing.Color.Red;
            this.num.Location = new System.Drawing.Point(6, 15);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(23, 18);
            this.num.TabIndex = 2;
            this.num.Text = "#";
            this.num.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.any_MouseDown);
            // 
            // PopupEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.num);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.pct);
            this.Name = "PopupEntry";
            this.Size = new System.Drawing.Size(250, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PopupEntry_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pct;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label num;
    }
}
