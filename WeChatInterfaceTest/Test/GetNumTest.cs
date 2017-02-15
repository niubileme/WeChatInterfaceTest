using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using WeChatInterfaceTest.Core;
using System.Text.RegularExpressions;
using System.Net;

namespace WeChatInterfaceTest.Test
{
    /// <summary>
    /// 获取阅读数、点赞数
    /// </summary>
    public class GetNumTest
    {
        public static void Run(string url, string uinkey)
        {
            var _Url = FormatUrl.Format(url, uinkey);
            try
            {
                var ReadNum = 0;
                var LikeNum = 0;
                var cookieContainer = new CookieContainer();
                //访问url，获取req_id
                var html = HttpHelper.Get(_Url.url, cookieContainer);
                var req_id = Regex.Match(html, "var req_id = '(.+?)';").Groups[1].Value;
                var content = FormatContent.Format(html);
                //访问接口，获取数据
                var InterfaceUrl = $"https://mp.weixin.qq.com/mp/getappmsgext?__biz={_Url.biz}&mid={_Url.mid}&idx={_Url.idx}&sn={_Url.sn}{uinkey}";
                var parames = $"is_only_read=1&req_id={req_id}&is_temp_url=0";
                var result = HttpHelper.Post(InterfaceUrl, parames, cookieContainer);

                //判断
                if (result != null && Regex.IsMatch(result, "read_num\":(.+?),\"like_num\":(.+?),"))
                {
                    Match m = Regex.Match(result, "read_num\":(.+?),\"like_num\":(.+?),");
                    ReadNum = Convert.ToInt32(m.Groups[1].Value);
                    LikeNum = Convert.ToInt32(m.Groups[2].Value);


                    Log.Success($"[ReadNumTest : Success] - {content.msg_title} : ReadNum:{ReadNum} LikeNum:{LikeNum} - UinKey : {uinkey}");
                }
                else
                {
                    Log.Fail($"[ReadNumTest : Fail] {content.msg_title} {result} - UinKey : {uinkey}");
                }

            }
            catch (Exception ex)
            {
                Log.Error($"[ReadNumTest : Error] {ex.Message} {_Url.url}");
            }
        }
    }
}
