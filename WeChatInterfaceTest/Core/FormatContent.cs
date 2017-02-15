using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeChatInterfaceTest.Core
{
    public class FormatContent
    {
        public static Content Format(string html)
        {
            var content = new Content();
            content.nickname = Regex.Match(html, "var nickname = \"(.*?)\";").Groups[1].Value;
            content.msg_title = Regex.Match(html, "var msg_title = \"(.*?)\";").Groups[1].Value;
            content.msg_desc = Regex.Match(html, "var msg_desc = \"(.*?)\";").Groups[1].Value;
            return content;
        }
    }

    public class Content
    {
        public string nickname { get; set; }
        public string msg_title { get; set; }
        public string msg_desc { get; set; }
    }
}
