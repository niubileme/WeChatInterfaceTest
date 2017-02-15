using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeChatInterfaceTest.Core;

namespace WeChatInterfaceTest.Test
{
    /// <summary>
    /// 刷阅读数
    /// </summary>
    public class ReadNumTest
    {
        public static void Run(string url, string uinkey)
        {
            var _Url = FormatUrl.Format(url, uinkey);
            try
            {
                //访问url
                var result = HttpHelper.Get(_Url.url);
                Log.Success($"[ReadNumTest : Success] {_Url.url}");
            }
            catch (Exception ex)
            {
                Log.Error($"[ReadNumTest : Error] {ex.Message} {_Url.url}");
            }
        }
    }
}
