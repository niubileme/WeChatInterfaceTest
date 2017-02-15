using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeChatInterfaceTest.Core
{
    public class FormatUrl
    {
        public static Url Format(string url)
        {
            Url u = new Url();
            Match match = Regex.Match(url.Trim(), "__biz=(.+?)&mid=(.+?)&idx=(.+?)&sn=(.+?)[&#]");
            u.url = UrlDecode(url.Trim());
            u.biz = match.Groups[1].Value;
            u.mid = match.Groups[2].Value;
            u.idx = match.Groups[3].Value;
            u.sn = match.Groups[4].Value;
            u.baseurl = UrlDecode($"http://mp.weixin.qq.com/s?__biz={u.biz}&mid={u.mid}&idx={u.idx}&sn={u.sn}#");
            return u;
        }

        public static Url Format(string url, string uinkey)
        {
            Url u = new Url();
            Match match = Regex.Match(url.Trim(), "__biz=(.+?)&mid=(.+?)&idx=(.+?)&sn=(.+?)[&#]");
            u.biz = match.Groups[1].Value;
            u.mid = match.Groups[2].Value;
            u.idx = match.Groups[3].Value;
            u.sn = match.Groups[4].Value;
            u.url = UrlDecode($"http://mp.weixin.qq.com/s?__biz={u.biz}&mid={u.mid}&idx={u.idx}&sn={u.sn}{uinkey}");
            u.baseurl = UrlDecode($"http://mp.weixin.qq.com/s?__biz={u.biz}&mid={u.mid}&idx={u.idx}&sn={u.sn}#");
            return u;
        }

        public static string UrlDecode(string url)
        {
            return System.Web.HttpUtility.UrlDecode(url);
        }

    }

    public class Url
    {
        public string url { get; set; }
        public string biz { get; set; }
        public string mid { get; set; }
        public string idx { get; set; }
        public string sn { get; set; }
        public string baseurl { get; set; }
        public string uinkey { get; set; }
    }
}
