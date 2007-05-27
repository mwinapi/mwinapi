namespace WinternalExplorer
{
    partial class ProcessControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.pid = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.path = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.priority = new System.Windows.Forms.TextBox();
            this.terminate = new System.Windows.Forms.Button();
            this.closeMainWindow = new System.Windows.Forms.Button();
            this.waitForInputIdle = new System.Windows.Forms.Button();
            this.responding = new System.Windows.Forms.TextBox();
            this.mainWindow = new System.Windows.Forms.TextBox();
            this.machineName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.modules = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cpus = new System.Windows.Forms.CheckedListBox();
            this.updateCPUsTimer = new System.Windows.Forms.Timer(this.components);
            label6 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(8, 6);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(28, 13);
            label6.TabIndex = 15;
            label6.Text = "&PID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(185, 6);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(38, 13);
            label4.TabIndex = 12;
            label4.Text = "&Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 37);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(32, 13);
            label3.TabIndex = 11;
            label3.Text = "&Path:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 61);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(67, 13);
            label7.TabIndex = 6;
            label7.Text = "Responding:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 35);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(75, 13);
            label5.TabIndex = 4;
            label5.Text = "Main Window:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(82, 13);
            label1.TabIndex = 0;
            label1.Text = "Machine Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 83);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 11;
            label2.Text = "Priority";
            // 
            // pid
            // 
            this.pid.Location = new System.Drawing.Point(58, 3);
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Size = new System.Drawing.Size(121, 20);
            this.pid.TabIndex = 16;
            this.pid.Text = "0x00a0affe (1234567)";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.name.Location = new System.Drawing.Point(226, 3);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(156, 20);
            this.name.TabIndex = 14;
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(58, 34);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(324, 20);
            this.path.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 222);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.priority);
            this.tabPage1.Controls.Add(label2);
            this.tabPage1.Controls.Add(this.terminate);
            this.tabPage1.Controls.Add(this.closeMainWindow);
            this.tabPage1.Controls.Add(this.waitForInputIdle);
            this.tabPage1.Controls.Add(this.responding);
            this.tabPage1.Controls.Add(label7);
            this.tabPage1.Controls.Add(this.mainWindow);
            this.tabPage1.Controls.Add(label5);
            this.tabPage1.Controls.Add(this.machineName);
            this.tabPage1.Controls.Add(label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(367, 196);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // priority
            // 
            this.priority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.priority.Location = new System.Drawing.Point(92, 80);
            this.priority.Name = "priority";
            this.priority.ReadOnly = true;
            this.priority.Size = new System.Drawing.Size(269, 20);
            this.priority.TabIndex = 12;
            // 
            // terminate
            // 
            this.terminate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.terminate.Location = new System.Drawing.Point(247, 167);
            this.terminate.Name = "terminate";
            this.terminate.Size = new System.Drawing.Size(114, 23);
            this.terminate.TabIndex = 10;
            this.terminate.Text = "Terminate";
            this.terminate.UseVisualStyleBackColor = true;
            this.terminate.Click += new System.EventHandler(this.terminate_Click);
            // 
            // closeMainWindow
            // 
            this.closeMainWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.closeMainWindow.Location = new System.Drawing.Point(127, 167);
            this.closeMainWindow.Name = "closeMainWindow";
            this.closeMainWindow.Size = new System.Drawing.Size(114, 23);
            this.closeMainWindow.TabIndex = 9;
            this.closeMainWindow.Text = "Close Main Window";
            this.closeMainWindow.UseVisualStyleBackColor = true;
            this.closeMainWindow.Click += new System.EventHandler(this.closeMainWindow_Click);
            // 
            // waitForInputIdle
            // 
            this.waitForInputIdle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waitForInputIdle.Location = new System.Drawing.Point(7, 167);
            this.waitForInputIdle.Name = "waitForInputIdle";
            this.waitForInputIdle.Size = new System.Drawing.Size(114, 23);
            this.waitForInputIdle.TabIndex = 8;
            this.waitForInputIdle.Text = "Wait for Input Idle";
            this.waitForInputIdle.UseVisualStyleBackColor = true;
            this.waitForInputIdle.Click += new System.EventHandler(this.waitForInputIdle_Click);
            // 
            // responding
            // 
            this.responding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.responding.Location = new System.Drawing.Point(92, 58);
            this.responding.Name = "responding";
            this.responding.ReadOnly = true;
            this.responding.Size = new System.Drawing.Size(269, 20);
            this.responding.TabIndex = 7;
            // 
            // mainWindow
            // 
            this.mainWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainWindow.Location = new System.Drawing.Point(92, 32);
            this.mainWindow.Name = "mainWindow";
            this.mainWindow.ReadOnly = true;
            this.mainWindow.Size = new System.Drawing.Size(269, 20);
            this.mainWindow.TabIndex = 5;
            // 
            // machineName
            // 
            this.machineName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.machineName.Location = new System.Drawing.Point(92, 6);
            this.machineName.Name = "machineName";
            this.machineName.ReadOnly = true;
            this.machineName.Size = new System.Drawing.Size(269, 20);
            this.machineName.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.modules);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(367, 196);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Modules";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // modules
            // 
            this.modules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.modules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.modules.Location = new System.Drawing.Point(3, 3);
            this.modules.Name = "modules";
            this.modules.Size = new System.Drawing.Size(361, 190);
            this.modules.TabIndex = 0;
            this.modules.UseCompatibleStateImageBehavior = false;
            this.modules.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 143;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Base";
            this.columnHeader2.Width = 53;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 43;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "FileName";
            this.columnHeader4.Width = 57;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "EntryPoint";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cpus);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(367, 196);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "CPU";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cpus
            // 
            this.cpus.FormattingEnabled = true;
            this.cpus.Items.AddRange(new object[] {
            "CPU 0",
            "CPU 1",
            "CPU 2",
            "CPU 3",
            "CPU 4",
            "CPU 5",
            "CPU 6",
            "CPU 7"});
            this.cpus.Location = new System.Drawing.Point(6, 6);
            this.cpus.Name = "cpus";
            this.cpus.Size = new System.Drawing.Size(355, 184);
            this.cpus.TabIndex = 0;
            this.cpus.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cpus_ItemCheck);
            // 
            // updateCPUsTimer
            // 
            this.updateCPUsTimer.Interval = 10;
            this.updateCPUsTimer.Tick += new System.EventHandler(this.updateCPUsTimer_Tick);
            // 
            // ProcessControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pid);
            this.Controls.Add(label6);
            this.Controls.Add(this.name);
            this.Controls.Add(this.path);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Name = "ProcessControl";
            this.Size = new System.Drawing.Size(384, 285);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pid;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox responding;
        private System.Windows.Forms.TextBox mainWindow;
        private System.Windows.Forms.TextBox machineName;
        private System.Windows.Forms.Button waitForInputIdle;
        private System.Windows.Forms.Button terminate;
        private System.Windows.Forms.Button closeMainWindow;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView modules;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox priority;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox cpus;
        private System.Windows.Forms.Timer updateCPUsTimer;
    }
}
