using Shopee_Autobuy_Bot.Models;
using System;
using System.Collections.Generic;

namespace Shopee_Autobuy_Bot.Constants
{
    public static class AutoBuyInfo
    {
        public static string SAB_Account { get; set; }
        public static DateTime AutoBuyStartTime { get; set; }
        public static Dictionary<string, string> CurrentElementDictionary = new Dictionary<string, string>();
        public static DelayModel ConfigInfo { get; set; }
        public static ElementModel.Root ConstantElements { get; set; }
    }
}
