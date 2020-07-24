using HHUCheckin.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHUCheckin
{
    public partial class FrmMain : Form
    {
        public static EventHandler<Msg> statusHandler;
        public DateTime lastCheckTime=new DateTime(1990,1,1);
        public bool todayChecked = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打卡按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Checkin_Click(object sender, EventArgs e)
        {
            // 获取用户名和密码
            string userName = Txt_Username.Text.Trim();
            string passWord = Txt_Password.Text.Trim();
            string email = Txt_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("用户名不可为空！");
                return;
            }
            if (string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("密码不可为空！");
                return;
            }
            // 保存用户名和密码
            if (Chk_Rememberme.Checked)
            {
                ConfigHelper.UpdateAppConfig("Username", userName);
                ConfigHelper.UpdateAppConfig("Password", passWord);
                ConfigHelper.UpdateAppConfig("EMail", email);
            }
            else
            {
                ConfigHelper.UpdateAppConfig("Username", "");
                ConfigHelper.UpdateAppConfig("Password", "");
                ConfigHelper.UpdateAppConfig("EMail", "");
            }
            // 打卡
            if (Checkin(userName, passWord))
            {
                MessageBox.Show("打卡成功！");
                Lbl_LastCheckinTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                if (Chk_SendMail.Checked)
                    Task.Run(() => MailHelper.SendMail(email, $"【{userName}】同学你好：\n 你已经于【{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}】打卡成功! \n HHU非官方快捷打卡平台"));
            }
            else
            {
                MessageBox.Show("打卡失败！");
            }
            statusHandler?.Invoke(null, new Msg("初始化完成"));
        }

        /// <summary>
        /// 打卡
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private bool Checkin(string userName, string passWord)
        {
            // 打卡
            Authentication auth = new Authentication(userName, passWord);
            var cookies = auth.Do();
            if (cookies != null)
            {
                Checkin checkin = new Checkin(cookies);
                return checkin.Do();
            }
            return false;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 绑定Handler
            statusHandler += OnStatusChanged;
            // 读取保存的用户名
            Txt_Username.Text = ConfigHelper.GetAppConfig("Username");
            Txt_Password.Text = ConfigHelper.GetAppConfig("Password");
            Txt_Email.Text = ConfigHelper.GetAppConfig("EMail");
            Lbl_LastCheckinTime.Text = lastCheckTime.ToString("yyyy/MM/dd HH:mm");
        }

        private void OnStatusChanged(object sender, Msg e)
        {
            Lbl_Status.Text = e.Message;
        }

        /// <summary>
        /// 后台时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoopTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            // 更新预计打卡时间
            if (now.Hour>=18 && now.Hour<=21 && now.Minute >= 5)
            {
                if (now.Day != lastCheckTime.Day)
                    todayChecked = false;
                if (!todayChecked)
                {
                    // 获取用户名和密码
                    string userName = Txt_Username.Text.Trim();
                    string passWord = Txt_Password.Text.Trim();
                    string email = Txt_Email.Text.Trim();
                    if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
                        return;
                    todayChecked = Checkin(userName, passWord);
                    // 如果打卡成功，发送邮件，更新界面上的时间
                    if (todayChecked)
                    {
                        Lbl_LastCheckinTime.Text = now.ToString("yyyy/MM/dd HH:mm:ss");
                        lastCheckTime = now;
                        if (Chk_SendMail.Checked)
                            Task.Run(() => MailHelper.SendMail(email, $"【{userName}】同学你好：\n 你已经于【{now.ToString("yyyy/MM/dd HH:mm:ss")}】打卡成功! \n HHU非官方快捷打卡平台"));
                    }
                }
            }
        }

        private void Chk_AutoCheckin_Click(object sender, EventArgs e)
        {
            if (Chk_AutoCheckin.Checked)
            {
                LoopTimer.Enabled = true;
            }
            else
            {
                LoopTimer.Enabled = false;
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(1000, this.notifyIcon1.BalloonTipTitle, this.notifyIcon1.BalloonTipText, ToolTipIcon.Info);//
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }
    }

    /// <summary>
    /// 简单的消息传输器
    /// </summary>
    public class Msg : EventArgs
    {
        public string Message
        {
            set;
            get;
        }
        public Msg(string _msg)
        {
            Message = _msg;
        }
    }
}
