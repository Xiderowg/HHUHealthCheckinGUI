using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HHUCheckin.Modules
{
    /// <summary>
    /// 认证模块
    /// Description : 返回经过认证后的CookieContainer，供后续调用接口时使用
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 登录API地址
        /// </summary>
        const string BASE = "http://ids.hhu.edu.cn/amserver/UI/Login?goto=http://form.hhu.edu.cn/pdc/form/list";
        const string API = "http://ids.hhu.edu.cn/amserver/UI/Login";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        public Authentication(string userName, string passWord)
        {
            this.Username = userName;
            this.Password = passWord;
        }

        /// <summary>
        /// 进行认证
        /// </summary>
        /// <returns></returns>
        public CookieContainer Do()
        {
            FrmMain.statusHandler?.Invoke(null, new Msg("正在进行登录验证"));
            // 首先访问登录页面，获取诸如AMAuthCookie=???;Domain=.hhu.edu.cn;Path=/的Cookie，这一步没测试过是不是必要的
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler
            {
                CookieContainer = cookies,
                UseCookies = true
            };
            HttpClient client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(10);
            HttpResponseMessage res;
            try
            {
                res = client.GetAsync(BASE).Result;
            }
            catch (TaskCanceledException e)
            {
                FrmMain.statusHandler?.Invoke(null, new Msg("获取初始Cookie失败，请检查网络链接"));
                return null;
            }
            // 接下来POST数据到API上面，得到Cookie
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("IDToken0", ""));
            nvc.Add(new KeyValuePair<string, string>("IDToken1", Username));
            nvc.Add(new KeyValuePair<string, string>("IDToken2", Password));
            nvc.Add(new KeyValuePair<string, string>("IDButton", "Submit"));
            nvc.Add(new KeyValuePair<string, string>("goto", "aHR0cDovL2Zvcm0uaGh1LmVkdS5jbi9wZGMvZm9ybS9saXN0"));
            nvc.Add(new KeyValuePair<string, string>("encoded", "true"));
            nvc.Add(new KeyValuePair<string, string>("inputCode", ""));
            nvc.Add(new KeyValuePair<string, string>("gx_charset", "UTF-8"));
            var req = new HttpRequestMessage(HttpMethod.Post, API) { Content = new FormUrlEncodedContent(nvc) };
            try
            {
                res = client.SendAsync(req).Result;
            }
            catch (TaskCanceledException e)
            {
                FrmMain.statusHandler?.Invoke(null, new Msg("登录账号失败，请检查网络链接"));
                return null;
            }
            //if (res.StatusCode != HttpStatusCode.Redirect)
            //{
            //    FrmMain.statusHandler?.Invoke(null, new Msg("账号或密码错误，请检查"));
            //    return null;
            //}
            bool isLogin = false;
            foreach (var cookie in cookies.GetCookies(new Uri(API)))
            {
                if (cookie.ToString().StartsWith("iPlanetDirectoryPro="))
                    isLogin = true;
            }
            if (!isLogin)
            {
                FrmMain.statusHandler?.Invoke(null, new Msg("账号或密码错误，请检查"));
                return null;
            }
            // 调试信息
            Console.WriteLine($"Cookies count: {cookies.Count}");
            FrmMain.statusHandler?.Invoke(null, new Msg("登录成功"));
            return cookies;
        }
    }
}
