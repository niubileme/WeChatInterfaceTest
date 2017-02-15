using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeChatInterfaceTest.Core;
using WeChatInterfaceTest.Test;

namespace WeChatInterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uinkey = "";

            uinkey = UinKeyHelper.GetOneByMarket();
           // GetNumTest.Run("https://mp.weixin.qq.com/s?__biz=MzA5ODg1NTk2MQ==&mid=2651813908&idx=1&sn=04b20e024f47dd6ab5a440fd83554d16&", uinkey);
            
            //ReadNumTest.Run("https://mp.weixin.qq.com/s?__biz=MzA5ODg1NTk2MQ==&mid=2651813908&idx=1&sn=04b20e024f47dd6ab5a440fd83554d16&", UinKeyHelper.GetOneByMarket());




            var uinkeys = UinKeyHelper.GetByVBang();
            Log.Show($"Uinkeys : {uinkeys.Count}");
            foreach (var item in uinkeys)
            {
                GetNumTest.Run("https://mp.weixin.qq.com/s?__biz=MzA5ODg1NTk2MQ==&mid=2651813908&idx=1&sn=04b20e024f47dd6ab5a440fd83554d16&", item);
                Thread.Sleep(2000);
            }
            //Parallel.ForEach(uinkeys, item =>
            //{
            //    Thread.Sleep(1000);
            //    GetNumTest.Run("http://mp.weixin.qq.com/s?__biz=MzIyNjE4NjI2Nw==&mid=2652557485&idx=1&sn=23ba574d7381dc2c538313aab937f5f9#", item);
            //});

            Console.ReadKey();
        }
    }
}
