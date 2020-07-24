using System.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace HHUCheckin
{
    public static class MailHelper
    {
        private const string host = "???";
        private const int port = 25;
        private const string guestUser = "???";
        private const string guestPass = "???";


        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toMail"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SendMail(string toMail,string msg)
        {
            if (!Utils.IsEmail(toMail)) return false;
            MailMessage message = new MailMessage();
            // 设置发件人
            MailAddress fromAddr = new MailAddress("api@edlinus.cn", "HHU非官方快捷健康打卡平台");
            message.From = fromAddr;
            // 设置收件人
            message.To.Add(toMail);
            message.Subject = $"【{DateTime.Now.ToString("yyyy/MM/dd")}】健康打卡提醒";
            message.Body = msg;
            // 准备发送邮件
            SmtpClient client = new SmtpClient(host, port);
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(guestUser, guestPass);
            //client.EnableSsl = true;
            client.Timeout = 10000;
            // 发送邮件
            try
            {
                client.Send(message);
            }catch(SmtpException e)
            {
                Console.WriteLine($"发送邮件时发生错误:{e.Message}");
                return false;
            }
            Console.WriteLine("邮件发送成功！");
            return true;
        }
    }
    public static class ConfigHelper
    {
        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="strKey"></param> 
        ///<returns></returns> 
        public static string GetAppConfig(string strKey)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return "";
        }

        ///<summary>  
        ///在*.exe.config文件中appSettings配置节增加一对键值对  
        ///</summary>  
        ///<param name="newKey"></param>  
        ///<param name="newValue"></param>  
        public static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
    public static class Utils
    {
        /// <summary>
        /// 将T1对象转换成T2，仅复制属性
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T2 ChangeType<T1, T2>(T1 source)
            => JsonConvert.DeserializeObject<T2>(JsonConvert.SerializeObject(source));

        /// <summary>
        /// 转换成键值对集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> ConvertToKeyValuePairs<T>(T source)
        {
            var pairs = new List<KeyValuePair<string, string>>();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
                pairs.Add(new KeyValuePair<string, string>(prop.Name, (prop.GetValue(source) ?? "").ToString()));

            return pairs;
        }

        /// <summary>
        /// 验证是否是合法邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
            => System.Text.RegularExpressions.Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
    }
}
