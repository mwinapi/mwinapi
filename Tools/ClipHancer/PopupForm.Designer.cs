namespace ClipHancer
{
    partial class PopupForm
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
            this.entryBox = new System.Windows.Forms.Panel();
            this.actionList = new System.Windows.Forms.ListBox();
            this.caption = new System.Windows.Forms.Label();
            this.keys = new System.Windows.Forms.Label();
            this.entryBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // entryBox
            // 
            this.entryBox.Controls.Add(this.actionList);
            this.entryBox.Location = new System.Drawing.Point(12, 38);
            this.entryBox.Name = "entryBox";
            this.entryBox.Size = new System.Drawing.Size(500, 240);
            this.entryBox.TabIndex = 1;
            this.entryBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            // 
            // actionList
            // 
            this.actionList.FormattingEnabled = true;
            this.actionList.Location = new System.Drawing.Point(159, 2);
            this.actionList.Name = "actionList";
            this.actionList.Size = new System.Drawing.Size(182, 238);
            this.actionList.TabIndex = 0;
            this.actionList.Visible = false;
            this.actionList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            this.actionList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PopupForm_KeyPress);
            // 
            // caption
            // 
            this.caption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.caption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caption.Location = new System.Drawing.Point(12, 9);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(500, 24);
            this.caption.TabIndex = 2;
            this.caption.Text = "Select Clipboard Entry to ";
            this.caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.caption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            // 
            // keys
            // 
            this.keys.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.keys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keys.Location = new System.Drawing.Point(12, 281);
            this.keys.Name = "keys";
            this.keys.Size = new System.Drawing.Size(500, 24);
            this.keys.TabIndex = 3;
            this.keys.Text = "Keys: ";
            this.keys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.keys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            // 
            // PopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 314);
            this.ControlBox = false;
            this.Controls.Add(this.keys);
            this.Controls.Add(this.caption);
            this.Controls.Add(this.entryBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "PopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.PopupForm_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PopupForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PopupForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopupForm_MouseDown);
            this.entryBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel entryBox;
        private System.Windows.Forms.Label caption;
        private System.Windows.Forms.Label keys;
        private System.Windows.Forms.ListBox actionList;

    }
}