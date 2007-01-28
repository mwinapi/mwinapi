namespace NeatKeys
{
    partial class MouseForm
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
            this.AlwaysToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.position = new System.Windows.Forms.PictureBox();
            this.screens = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.anchor = new System.Windows.Forms.PictureBox();
            this.sizes = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lockwidth = new System.Windows.Forms.PictureBox();
            this.lockheight = new System.Windows.Forms.PictureBox();
            this.drawMode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.position)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockwidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockheight)).BeginInit();
            this.SuspendLayout();
            // 
            // AlwaysToolTip
            // 
            this.AlwaysToolTip.AutoPopDelay = 5000;
            this.AlwaysToolTip.InitialDelay = 10;
            this.AlwaysToolTip.ReshowDelay = 100;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(266, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(23, 23);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "?";
            this.AlwaysToolTip.SetToolTip(this.checkBox1, "Enable Tooltips");
            this.ToolTip.SetToolTip(this.checkBox1, "Enable Tooltips");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(12, 58);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(241, 181);
            this.position.TabIndex = 0;
            this.position.TabStop = false;
            this.position.MouseLeave += new System.EventHandler(this.position_MouseLeave);
            this.position.Click += new System.EventHandler(this.position_Click);
            this.position.MouseDown += new System.Windows.Forms.MouseEventHandler(this.position_MouseDown);
            this.position.MouseMove += new System.Windows.Forms.MouseEventHandler(this.position_MouseMove);
            this.position.Paint += new System.Windows.Forms.PaintEventHandler(this.position_Paint);
            this.position.MouseUp += new System.Windows.Forms.MouseEventHandler(this.position_MouseUp);
            // 
            // screens
            // 
            this.screens.Location = new System.Drawing.Point(12, 12);
            this.screens.Name = "screens";
            this.screens.Size = new System.Drawing.Size(201, 41);
            this.screens.TabIndex = 2;
            this.screens.TabStop = false;
            this.screens.MouseDown += new System.Windows.Forms.MouseEventHandler(this.screens_MouseDown);
            this.screens.Paint += new System.Windows.Forms.PaintEventHandler(this.screens_Paint);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "";
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Marlett", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(3)));
            this.button1.Location = new System.Drawing.Point(295, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "r";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // anchor
            // 
            this.anchor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anchor.Location = new System.Drawing.Point(223, 22);
            this.anchor.Name = "anchor";
            this.anchor.Size = new System.Drawing.Size(30, 30);
            this.anchor.TabIndex = 4;
            this.anchor.TabStop = false;
            this.anchor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.anchor_MouseDown);
            this.anchor.Paint += new System.Windows.Forms.PaintEventHandler(this.anchor_Paint);
            // 
            // sizes
            // 
            this.sizes.Location = new System.Drawing.Point(258, 58);
            this.sizes.Name = "sizes";
            this.sizes.Size = new System.Drawing.Size(61, 181);
            this.sizes.TabIndex = 5;
            this.sizes.TabStop = false;
            this.sizes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sizes_MouseDown);
            this.sizes.Paint += new System.Windows.Forms.PaintEventHandler(this.sizes_Paint);
            // 
            // ToolTip
            // 
            this.ToolTip.Active = false;
            this.ToolTip.AutomaticDelay = 1000;
            // 
            // lockwidth
            // 
            this.lockwidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lockwidth.Location = new System.Drawing.Point(223, 12);
            this.lockwidth.Name = "lockwidth";
            this.lockwidth.Size = new System.Drawing.Size(30, 10);
            this.lockwidth.TabIndex = 7;
            this.lockwidth.TabStop = false;
            this.ToolTip.SetToolTip(this.lockwidth, "Left click = Lock width\r\nRight click = Maximize vertically");
            this.lockwidth.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lockwidth_MouseDown);
            this.lockwidth.Paint += new System.Windows.Forms.PaintEventHandler(this.lockwidth_Paint);
            // 
            // lockheight
            // 
            this.lockheight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lockheight.Location = new System.Drawing.Point(213, 22);
            this.lockheight.Name = "lockheight";
            this.lockheight.Size = new System.Drawing.Size(10, 30);
            this.lockheight.TabIndex = 8;
            this.lockheight.TabStop = false;
            this.ToolTip.SetToolTip(this.lockheight, "Left click = Lock height\r\nRight click = Maximize horizontally");
            this.lockheight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lockheight_MouseDown);
            this.lockheight.Paint += new System.Windows.Forms.PaintEventHandler(this.lockheight_Paint);
            // 
            // drawMode
            // 
            this.drawMode.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawMode.Location = new System.Drawing.Point(266, 35);
            this.drawMode.Name = "drawMode";
            this.drawMode.Size = new System.Drawing.Size(52, 18);
            this.drawMode.TabIndex = 9;
            this.drawMode.Text = "Draw";
            this.drawMode.UseVisualStyleBackColor = true;
            this.drawMode.Click += new System.EventHandler(this.drawMode_Click);
            // 
            // MouseForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(330, 250);
            this.ControlBox = false;
            this.Controls.Add(this.drawMode);
            this.Controls.Add(this.lockheight);
            this.Controls.Add(this.lockwidth);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sizes);
            this.Controls.Add(this.anchor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.screens);
            this.Controls.Add(this.position);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MouseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MouseForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MouseForm_KeyDown);
            this.Load += new System.EventHandler(this.MouseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.position)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anchor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockwidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lockheight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox position;
        private System.Windows.Forms.PictureBox screens;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox anchor;
        private System.Windows.Forms.PictureBox sizes;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip AlwaysToolTip;
        private System.Windows.Forms.PictureBox lockwidth;
        private System.Windows.Forms.PictureBox lockheight;
        private System.Windows.Forms.Button drawMode;
    }
}