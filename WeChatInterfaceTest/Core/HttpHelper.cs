using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeChatInterfaceTest.Core
{
    public class HttpHelper
    {
        private static string GetUserAgent()
        {
            return "Mozilla/5.0 (Linux; U; Android 4.2.2; zh-cn; HM NOTE 1TD Build/JDQ39) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30 MicroMessenger/5.3.1.51_r733746.462 NetType/WIFI";
        }

        public static string Get(string url, CookieContainer cookieContainer = null)
        {
            var html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Get";
                request.UserAgent = GetUserAgent();
                request.Timeout = 1000 * 15;
                if (cookieContainer != null)
                    request.CookieContainer = cookieContainer;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[HttpWebRequest] - {ex.Message}");
            }
            return html;
        }

        public static string Post(string url, string parames = null, CookieContainer cookieContainer = null)
        {
            var html = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "Post";
                request.UserAgent = GetUserAgent();
                request.Timeout = 1000 * 15;
                if (cookieContainer != null)
                    request.CookieContainer = cookieContainer;
                byte[] bs = Encoding.UTF8.GetBytes(parames);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = bs.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        html = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"[HttpWebRequest] - {ex.Message}");
            }
            return html;
        }
    }
}
