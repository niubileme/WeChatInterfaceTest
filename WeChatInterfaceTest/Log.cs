using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatInterfaceTest
{
    public class Log
    {
        public static void Success(string msg)
        {
            Show(msg, ConsoleColor.Green);
        }

        public static void Fail(string msg)
        {
            Show(msg, ConsoleColor.Yellow);
        }

        public static void Error(string msg)
        {
            Show(msg, ConsoleColor.Red);
        }

        public static void Show(string msg, ConsoleColor color = ConsoleColor.White, int newline = 1)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now.ToString("MM-dd HH:mm:ss.ff")}] : {msg}");
            if (newline != 0)
            {
                for (int i = 0; i < newline; i++)
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
