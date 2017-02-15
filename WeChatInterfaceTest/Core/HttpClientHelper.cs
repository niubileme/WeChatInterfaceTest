using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeChatInterfaceTest.Core
{
    public class HttpClientHelper
    {
        private static readonly string BASE_ADDRESS = "https://mp.weixin.qq.com/";
        private static readonly HttpClient _httpClient;
        private static CookieContainer _cookieContainer = new CookieContainer();

        static HttpClientHelper()
        {
            _httpClient = new HttpClient(new HttpClientHandler()
            {
                CookieContainer = _cookieContainer
            });
            _httpClient.Timeout = new TimeSpan(0, 0, 20);

            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            //HttpClient热身
            _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri(BASE_ADDRESS)
            }).Result.EnsureSuccessStatusCode();
        }

        public static async Task<string> SendAsync(HttpMethod method, string url, List<KeyValuePair<string, string>> parames = null, int ua = 1, string referrer = "")
        {
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(url)
            };
            //UserAgent
            httpRequestMessage.Headers.Add("UserAgent", GetUserAgent(ua));
            //Referrer 
            if (!string.IsNullOrEmpty(referrer))
                httpRequestMessage.Headers.Referrer = new Uri(referrer);
            //Content
            if (parames != null)
                httpRequestMessage.Content = new FormUrlEncodedContent(parames);

            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();// 确认响应成功 状态码 2xx，否则抛出异常  
            return await response.Content.ReadAsStringAsync();
        }

        private static string GetUserAgent(int ua)
        {
            return "Mozilla/5.0 (Linux; U; Android 4.2.2; zh-cn; HM NOTE 1TD Build/JDQ39) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30 MicroMessenger/5.3.1.51_r733746.462 NetType/WIFI";
        }

   
    }

}
