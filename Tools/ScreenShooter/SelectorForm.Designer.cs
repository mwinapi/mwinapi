namespace ScreenShooter
{
    partial class SelectorForm
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
            this.label = new System.Windows.Forms.Label();
            this.mouseHook = new ManagedWinapi.Hooks.LowLevelMouseHook();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Padding = new System.Windows.Forms.Padding(10);
            this.label.Size = new System.Drawing.Size(336, 79);
            this.label.TabIndex = 0;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mouseHook
            // 
            this.mouseHook.Type = ManagedWinapi.Hooks.HookType.WH_MOUSE_LL;
            this.mouseHook.MouseIntercepted += new ManagedWinapi.Hooks.LowLevelMouseHook.MouseCallback(this.mouseHook_MouseIntercepted);
            this.mouseHook.MouseUp += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.mouseHook_MouseUp);
            this.mouseHook.MouseDown += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.mouseHook_MouseDown);
            this.mouseHook.MouseMove += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.mouseHook_MouseMove);
            // 
            // SelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(336, 79);
            this.Controls.Add(this.label);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(20, 20);
            this.Name = "SelectorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectorForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectorForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ManagedWinapi.Hooks.LowLevelMouseHook mouseHook;
        private System.Windows.Forms.Label label;

    }
}