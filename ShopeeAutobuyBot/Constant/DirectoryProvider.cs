using System;

namespace Shopee_Autobuy_Bot.Constant
{
    public static class DirectoryProvider
    {
        public static readonly string SabTempDirectory = System.IO.Path.GetTempPath() + @"86dg5fd86g5d9f86b8d6\";
        public static readonly string UserTempDirectory = System.IO.Path.GetTempPath();
        public static readonly string LogDirectory = Environment.CurrentDirectory + @"\Logs\";
        public static readonly string ShopeeAccountDirectory = Environment.CurrentDirectory + @"\Shopee Account\";
        public static readonly string CurrentDirectory = Environment.CurrentDirectory + "\\";


    }
}
