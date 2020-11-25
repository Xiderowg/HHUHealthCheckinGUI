namespace HHUCheckin
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Btn_Checkin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Lbl_Status = new System.Windows.Forms.Label();
            this.Chk_Rememberme = new System.Windows.Forms.CheckBox();
            this.LoopTimer = new System.Windows.Forms.Timer(this.components);
            this.Chk_AutoCheckin = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Lbl_LastCheckinTime = new System.Windows.Forms.Label();
            this.Txt_Email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Chk_SendMail = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_LagTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Rad_IsBachelor = new System.Windows.Forms.RadioButton();
            this.Rad_IsGraduate = new System.Windows.Forms.RadioButton();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "学号：";
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(79, 14);
            this.Txt_Username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(184, 28);
            this.Txt_Username.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(79, 60);
            this.Txt_Password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(184, 28);
            this.Txt_Password.TabIndex = 3;
            // 
            // Btn_Checkin
            // 
            this.Btn_Checkin.Location = new System.Drawing.Point(280, 13);
            this.Btn_Checkin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Checkin.Name = "Btn_Checkin";
            this.Btn_Checkin.Size = new System.Drawing.Size(164, 199);
            this.Btn_Checkin.TabIndex = 4;
            this.Btn_Checkin.Text = "打卡";
            this.Btn_Checkin.UseVisualStyleBackColor = true;
            this.Btn_Checkin.Click += new System.EventHandler(this.Btn_Checkin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "状态：";
            // 
            // Lbl_Status
            // 
            this.Lbl_Status.AutoSize = true;
            this.Lbl_Status.ForeColor = System.Drawing.Color.DarkGreen;
            this.Lbl_Status.Location = new System.Drawing.Point(79, 313);
            this.Lbl_Status.Name = "Lbl_Status";
            this.Lbl_Status.Size = new System.Drawing.Size(98, 18);
            this.Lbl_Status.TabIndex = 8;
            this.Lbl_Status.Text = "初始化完成";
            // 
            // Chk_Rememberme
            // 
            this.Chk_Rememberme.AutoSize = true;
            this.Chk_Rememberme.Checked = true;
            this.Chk_Rememberme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_Rememberme.Location = new System.Drawing.Point(17, 234);
            this.Chk_Rememberme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chk_Rememberme.Name = "Chk_Rememberme";
            this.Chk_Rememberme.Size = new System.Drawing.Size(88, 22);
            this.Chk_Rememberme.TabIndex = 9;
            this.Chk_Rememberme.Text = "记住我";
            this.Chk_Rememberme.UseVisualStyleBackColor = true;
            // 
            // LoopTimer
            // 
            this.LoopTimer.Enabled = true;
            this.LoopTimer.Interval = 60000;
            this.LoopTimer.Tick += new System.EventHandler(this.LoopTimer_Tick);
            // 
            // Chk_AutoCheckin
            // 
            this.Chk_AutoCheckin.AutoSize = true;
            this.Chk_AutoCheckin.Checked = true;
            this.Chk_AutoCheckin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_AutoCheckin.Location = new System.Drawing.Point(108, 234);
            this.Chk_AutoCheckin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chk_AutoCheckin.Name = "Chk_AutoCheckin";
            this.Chk_AutoCheckin.Size = new System.Drawing.Size(106, 22);
            this.Chk_AutoCheckin.TabIndex = 10;
            this.Chk_AutoCheckin.Text = "自动打卡";
            this.Chk_AutoCheckin.UseVisualStyleBackColor = true;
            this.Chk_AutoCheckin.Click += new System.EventHandler(this.Chk_AutoCheckin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "上一次打卡时间：";
            // 
            // Lbl_LastCheckinTime
            // 
            this.Lbl_LastCheckinTime.AutoSize = true;
            this.Lbl_LastCheckinTime.ForeColor = System.Drawing.Color.Black;
            this.Lbl_LastCheckinTime.Location = new System.Drawing.Point(166, 277);
            this.Lbl_LastCheckinTime.Name = "Lbl_LastCheckinTime";
            this.Lbl_LastCheckinTime.Size = new System.Drawing.Size(44, 18);
            this.Lbl_LastCheckinTime.TabIndex = 12;
            this.Lbl_LastCheckinTime.Text = "未知";
            // 
            // Txt_Email
            // 
            this.Txt_Email.Location = new System.Drawing.Point(79, 102);
            this.Txt_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_Email.Name = "Txt_Email";
            this.Txt_Email.Size = new System.Drawing.Size(184, 28);
            this.Txt_Email.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 13;
            this.label5.Text = "邮箱：";
            // 
            // Chk_SendMail
            // 
            this.Chk_SendMail.AutoSize = true;
            this.Chk_SendMail.Location = new System.Drawing.Point(215, 234);
            this.Chk_SendMail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chk_SendMail.Name = "Chk_SendMail";
            this.Chk_SendMail.Size = new System.Drawing.Size(178, 22);
            this.Chk_SendMail.TabIndex = 15;
            this.Chk_SendMail.Text = "打卡结果发送邮箱";
            this.Chk_SendMail.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "程序已最小化到托盘";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "HHUCheckin v2";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "滞后：";
            // 
            // Txt_LagTime
            // 
            this.Txt_LagTime.Location = new System.Drawing.Point(79, 182);
            this.Txt_LagTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_LagTime.Name = "Txt_LagTime";
            this.Txt_LagTime.Size = new System.Drawing.Size(126, 28);
            this.Txt_LagTime.TabIndex = 17;
            this.Txt_LagTime.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "分钟";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "身份：";
            // 
            // Rad_IsBachelor
            // 
            this.Rad_IsBachelor.AutoSize = true;
            this.Rad_IsBachelor.Checked = true;
            this.Rad_IsBachelor.Location = new System.Drawing.Point(79, 145);
            this.Rad_IsBachelor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rad_IsBachelor.Name = "Rad_IsBachelor";
            this.Rad_IsBachelor.Size = new System.Drawing.Size(87, 22);
            this.Rad_IsBachelor.TabIndex = 20;
            this.Rad_IsBachelor.TabStop = true;
            this.Rad_IsBachelor.Text = "本科生";
            this.Rad_IsBachelor.UseVisualStyleBackColor = true;
            // 
            // Rad_IsGraduate
            // 
            this.Rad_IsGraduate.AutoSize = true;
            this.Rad_IsGraduate.Location = new System.Drawing.Point(181, 145);
            this.Rad_IsGraduate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rad_IsGraduate.Name = "Rad_IsGraduate";
            this.Rad_IsGraduate.Size = new System.Drawing.Size(87, 22);
            this.Rad_IsGraduate.TabIndex = 21;
            this.Rad_IsGraduate.Text = "研究生";
            this.Rad_IsGraduate.UseVisualStyleBackColor = true;
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(304, 313);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(124, 22);
            this.chkStartUp.TabIndex = 22;
            this.chkStartUp.Text = "开机自启动";
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 348);
            this.Controls.Add(this.chkStartUp);
            this.Controls.Add(this.Rad_IsGraduate);
            this.Controls.Add(this.Rad_IsBachelor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Txt_LagTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Chk_SendMail);
            this.Controls.Add(this.Txt_Email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Lbl_LastCheckinTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Chk_AutoCheckin);
            this.Controls.Add(this.Chk_Rememberme);
            this.Controls.Add(this.Lbl_Status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_Checkin);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "HHUCheckin v2.3";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Button Btn_Checkin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lbl_Status;
        private System.Windows.Forms.CheckBox Chk_Rememberme;
        private System.Windows.Forms.Timer LoopTimer;
        private System.Windows.Forms.CheckBox Chk_AutoCheckin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Lbl_LastCheckinTime;
        private System.Windows.Forms.TextBox Txt_Email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Chk_SendMail;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_LagTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton Rad_IsBachelor;
        private System.Windows.Forms.RadioButton Rad_IsGraduate;
        private System.Windows.Forms.CheckBox chkStartUp;
    }
}

