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
        public bool todayChecked = false;
        private int LagTime = 5;

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
            if(IsRepeatingCheck())
            {
                MessageBox.Show("今日已打过卡，无需重复打卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DoesStartUp();
            // 获取用户名和密码
            string userName = Txt_Username.Text.Trim();
            string passWord = Txt_Password.Text.Trim();
            string email = Txt_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("用户名不可为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("密码不可为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //保存其他控件的情况
            ConfigHelper.UpdateAppConfig("Rad_IsBachelor", this.Rad_IsBachelor.Checked);
            ConfigHelper.UpdateAppConfig("Rad_IsGraduate", this.Rad_IsGraduate.Checked);
            ConfigHelper.UpdateAppConfig("Chk_Rememberme", this.Chk_Rememberme.Checked);
            ConfigHelper.UpdateAppConfig("Chk_AutoCheckin", this.Chk_AutoCheckin.Checked);
            ConfigHelper.UpdateAppConfig("Chk_SendMail", this.Chk_SendMail.Checked);
            ConfigHelper.UpdateAppConfig("Chk_StartUp", this.Chk_StartUp.Checked);

            // 读取滞后时间
            if (!int.TryParse(Txt_LagTime.Text, out LagTime))
                LagTime = 5;
            // 是否是本科生
            bool isBachelor = Rad_IsBachelor.Checked;
            // 打卡
            if (Checkin(userName, passWord, isBachelor))
            {
                GlobalVars.log.Info(string.Format("用户【{0}】打卡成功", userName));
                MessageBox.Show("打卡成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Lbl_LastCheckinTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                //增加缓存写入
                ConfigHelper.UpdateAppConfig("LastCheckTime", Lbl_LastCheckinTime.Text);

                if (Chk_SendMail.Checked)
                    Task.Run(() => MailHelper.SendMail(email, $"【{userName}】同学你好：\n 你已经于【{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}】打卡成功! \n HHU非官方快捷打卡平台"));
            }
            else
            {
                GlobalVars.log.Error(string.Format("用户【{0}】打卡失败", userName));
                MessageBox.Show("打卡失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            statusHandler?.Invoke(null, new Msg("初始化完成"));
        }

        private bool IsRepeatingCheck()
        {
            DateTime lastCheckTime = Convert.ToDateTime(Lbl_LastCheckinTime.Text);
            if (lastCheckTime.Year == DateTime.Now.Year && lastCheckTime.Month == DateTime.Now.Month && lastCheckTime.Day == DateTime.Now.Day)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 打卡
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private bool Checkin(string userName, string passWord, bool isBachelor)
        {
            // 打卡
            Authentication auth = new Authentication(userName, passWord);
            var cookies = auth.Do();
            if (cookies != null)
            {
                Checkin checkin = new Checkin(cookies, isBachelor);
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
            // 读取保存的信息
            this.Txt_Username.Text = ConfigHelper.GetAppConfig("Username");
            this.Txt_Password.Text = ConfigHelper.GetAppConfig("Password");
            this.Txt_Email.Text = ConfigHelper.GetAppConfig("EMail");
            this.Lbl_LastCheckinTime.Text = ConfigHelper.GetAppConfig("LastCheckTime") == string.Empty ? "1990-01-01 00:00:00": ConfigHelper.GetAppConfig("LastCheckTime");
            this.Rad_IsBachelor.Checked = ConfigHelper.GetAppConfig("Rad_IsBachelor") != string.Empty;
            this.Rad_IsGraduate.Checked = ConfigHelper.GetAppConfig("Rad_IsGraduate") != string.Empty;
            this.Chk_Rememberme.Checked = ConfigHelper.GetAppConfig("Chk_Rememberme") != string.Empty;
            this.Chk_AutoCheckin.Checked = ConfigHelper.GetAppConfig("Chk_AutoCheckin") != string.Empty;
            this.Chk_SendMail.Checked = ConfigHelper.GetAppConfig("Chk_SendMail") != string.Empty;
            this.Chk_StartUp.Checked = ConfigHelper.GetAppConfig("Chk_StartUp") != string.Empty;
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
            // 更新滞后时间
            if (int.TryParse(Txt_LagTime.Text, out LagTime))
                LagTime = 5;
            // 更新预计打卡时间
            if (now.Hour >= 10 && now.Hour <= 21 && now.Minute >= LagTime)
            {
                if (now.Day != Convert.ToDateTime(Lbl_LastCheckinTime.Text).Day)
                    todayChecked = false;
                if (!todayChecked)
                {
                    // 获取用户名和密码
                    string userName = Txt_Username.Text.Trim();
                    string passWord = Txt_Password.Text.Trim();
                    string email = Txt_Email.Text.Trim();
                    if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
                        return;
                    // 是否是本科生
                    bool isBachelor = Rad_IsBachelor.Checked;
                    todayChecked = Checkin(userName, passWord, isBachelor);
                    // 如果打卡成功，发送邮件，更新界面上的时间
                    if (todayChecked)
                    {
                        Lbl_LastCheckinTime.Text = now.ToString("yyyy/MM/dd HH:mm:ss");

                        //增加缓存写入
                        ConfigHelper.UpdateAppConfig("LastCheckTime", Lbl_LastCheckinTime.Text);

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
        /// <summary>
        /// 是否启用开机自启动
        /// </summary>
        private void DoesStartUp()
        {
            string path = Application.StartupPath;
            string keyName = path.Substring(path.LastIndexOf("\\") + 1);
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (this.Chk_StartUp.Checked)
            {
                if (Rkey == null)
                {
                    Rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Rkey.SetValue(keyName, path + @"\PeisDoctorHZ.exe");
            }
            else
            {
                if (Rkey != null)
                {
                    Rkey.DeleteValue(keyName, false);
                }
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
