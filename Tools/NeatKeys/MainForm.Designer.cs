namespace NeatKeys
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
            System.Windows.Forms.ToolStripMenuItem kbdModeMenuItem;
            System.Windows.Forms.NotifyIcon trayIcon;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mouseModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.alignCurrentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotkeyKeypad = new ManagedWinapi.Hotkey(this.components);
            this.hotkeyMain = new ManagedWinapi.Hotkey(this.components);
            kbdModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // kbdModeMenuItem
            // 
            kbdModeMenuItem.Name = "kbdModeMenuItem";
            kbdModeMenuItem.ShortcutKeyDisplayString = "[Window]+[+]";
            kbdModeMenuItem.Size = new System.Drawing.Size(246, 22);
            kbdModeMenuItem.Text = "NeatKeys &Keyboard Mode";
            kbdModeMenuItem.Click += new System.EventHandler(this.startNeatKeysToolStripMenuItem_Click);
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = this.trayMenu;
            trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            trayIcon.Text = "NeatKeys 0.0.1";
            trayIcon.Visible = true;
            trayIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseMove);
            trayIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseUp);
            trayIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDown);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            kbdModeMenuItem,
            this.mouseModeMenuItem,
            this.toolStripSeparator2,
            this.alignCurrentMenuItem,
            this.alignAllMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.trayMenu.ShowImageMargin = false;
            this.trayMenu.Size = new System.Drawing.Size(247, 126);
            // 
            // mouseModeMenuItem
            // 
            this.mouseModeMenuItem.Name = "mouseModeMenuItem";
            this.mouseModeMenuItem.ShortcutKeyDisplayString = "Click";
            this.mouseModeMenuItem.Size = new System.Drawing.Size(246, 22);
            this.mouseModeMenuItem.Text = "NeatKeys &Mouse Mode";
            this.mouseModeMenuItem.Click += new System.EventHandler(this.mouseModeMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // alignCurrentMenuItem
            // 
            this.alignCurrentMenuItem.Name = "alignCurrentMenuItem";
            this.alignCurrentMenuItem.ShortcutKeyDisplayString = "";
            this.alignCurrentMenuItem.Size = new System.Drawing.Size(246, 22);
            this.alignCurrentMenuItem.Text = "Align &Current Window";
            this.alignCurrentMenuItem.Click += new System.EventHandler(this.alignCurrentMenuItem_Click);
            // 
            // alignAllMenuItem
            // 
            this.alignAllMenuItem.Name = "alignAllMenuItem";
            this.alignAllMenuItem.Size = new System.Drawing.Size(246, 22);
            this.alignAllMenuItem.Text = "Align &All Windows";
            this.alignAllMenuItem.Click += new System.EventHandler(this.alignAllMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hotkeyKeypad
            // 
            this.hotkeyKeypad.Alt = false;
            this.hotkeyKeypad.Ctrl = false;
            this.hotkeyKeypad.Enabled = true;
            this.hotkeyKeypad.KeyCode = System.Windows.Forms.Keys.Add;
            this.hotkeyKeypad.Shift = false;
            this.hotkeyKeypad.WindowsKey = true;
            this.hotkeyKeypad.HotkeyPressed += new System.EventHandler(this.hotKeyKeypad_HotkeyPressed);
            // 
            // hotkeyMain
            // 
            this.hotkeyMain.Alt = false;
            this.hotkeyMain.Ctrl = false;
            this.hotkeyMain.Enabled = true;
            this.hotkeyMain.KeyCode = System.Windows.Forms.Keys.Oemplus;
            this.hotkeyMain.Shift = false;
            this.hotkeyMain.WindowsKey = true;
            this.hotkeyMain.HotkeyPressed += new System.EventHandler(this.hotkeyMain_HotkeyPressed);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.9;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "NeatKeys";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private ManagedWinapi.Hotkey hotkeyKeypad;
        private ManagedWinapi.Hotkey hotkeyMain;
        private System.Windows.Forms.ToolStripMenuItem mouseModeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem alignCurrentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignAllMenuItem;

    }
}

