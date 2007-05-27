namespace WinternalExplorer
{
    partial class ThreadControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.threadState = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.startAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.totalTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.privTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.priorityBoost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPriority = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.basePriority = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.priorityLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 253);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.threadState);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.startAddress);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.startTime);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(367, 227);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // threadState
            // 
            this.threadState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.threadState.Location = new System.Drawing.Point(92, 58);
            this.threadState.Name = "threadState";
            this.threadState.ReadOnly = true;
            this.threadState.Size = new System.Drawing.Size(269, 20);
            this.threadState.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thread State:";
            // 
            // startAddress
            // 
            this.startAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startAddress.Location = new System.Drawing.Point(92, 32);
            this.startAddress.Name = "startAddress";
            this.startAddress.ReadOnly = true;
            this.startAddress.Size = new System.Drawing.Size(269, 20);
            this.startAddress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start Address:";
            // 
            // startTime
            // 
            this.startTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.startTime.Location = new System.Drawing.Point(92, 6);
            this.startTime.Name = "startTime";
            this.startTime.ReadOnly = true;
            this.startTime.Size = new System.Drawing.Size(269, 20);
            this.startTime.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Time:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.totalTime);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.userTime);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.privTime);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.priorityBoost);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.currentPriority);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.basePriority);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.priorityLevel);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(367, 227);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Performance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // totalTime
            // 
            this.totalTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.totalTime.Location = new System.Drawing.Point(92, 176);
            this.totalTime.Name = "totalTime";
            this.totalTime.ReadOnly = true;
            this.totalTime.Size = new System.Drawing.Size(269, 20);
            this.totalTime.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Total Time:";
            // 
            // userTime
            // 
            this.userTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userTime.Location = new System.Drawing.Point(92, 150);
            this.userTime.Name = "userTime";
            this.userTime.ReadOnly = true;
            this.userTime.Size = new System.Drawing.Size(269, 20);
            this.userTime.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "User Time:";
            // 
            // privTime
            // 
            this.privTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.privTime.Location = new System.Drawing.Point(92, 124);
            this.privTime.Name = "privTime";
            this.privTime.ReadOnly = true;
            this.privTime.Size = new System.Drawing.Size(269, 20);
            this.privTime.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Privileged Time:";
            // 
            // priorityBoost
            // 
            this.priorityBoost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityBoost.Location = new System.Drawing.Point(92, 84);
            this.priorityBoost.Name = "priorityBoost";
            this.priorityBoost.ReadOnly = true;
            this.priorityBoost.Size = new System.Drawing.Size(269, 20);
            this.priorityBoost.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Priority Boost:";
            // 
            // currentPriority
            // 
            this.currentPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPriority.Location = new System.Drawing.Point(92, 58);
            this.currentPriority.Name = "currentPriority";
            this.currentPriority.ReadOnly = true;
            this.currentPriority.Size = new System.Drawing.Size(269, 20);
            this.currentPriority.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Current Priority:";
            // 
            // basePriority
            // 
            this.basePriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.basePriority.Location = new System.Drawing.Point(92, 32);
            this.basePriority.Name = "basePriority";
            this.basePriority.ReadOnly = true;
            this.basePriority.Size = new System.Drawing.Size(269, 20);
            this.basePriority.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Base Priority:";
            // 
            // priorityLevel
            // 
            this.priorityLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.priorityLevel.Location = new System.Drawing.Point(92, 6);
            this.priorityLevel.Name = "priorityLevel";
            this.priorityLevel.ReadOnly = true;
            this.priorityLevel.Size = new System.Drawing.Size(269, 20);
            this.priorityLevel.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Priority Level:";
            // 
            // tid
            // 
            this.tid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tid.Location = new System.Drawing.Point(57, 3);
            this.tid.Name = "tid";
            this.tid.ReadOnly = true;
            this.tid.Size = new System.Drawing.Size(319, 20);
            this.tid.TabIndex = 23;
            this.tid.Text = "0x00a0affe (1234567)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "&TID:";
            // 
            // ThreadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tid);
            this.Controls.Add(this.label6);
            this.Name = "ThreadControl";
            this.Size = new System.Drawing.Size(384, 285);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox threadState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox startAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox priorityBoost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currentPriority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox basePriority;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox priorityLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox totalTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox privTime;
        private System.Windows.Forms.Label label11;
    }
}
