﻿using System;

namespace Shopee_Autobuy_Bot.Constants
{
    public static class DirectoryPaths
    {
        public static readonly string SabTempDirectory = System.IO.Path.GetTempPath() + @"86dg5fd86g5d9f86b8d6\";
        public static readonly string UserTempDirectory = System.IO.Path.GetTempPath();
        public static readonly string LogDirectory = Environment.CurrentDirectory + @"\Configuration\Logs\";
        public static readonly string ShopeeAccountDirectory = Environment.CurrentDirectory + @"\Configuration\Shopee Account\";
        public static readonly string CurrentDirectory = Environment.CurrentDirectory + "\\";
        public static readonly string ElementSettingsPath = Environment.CurrentDirectory + @"\Configuration\element.settings";
        public static readonly string ProfileSettingsPath = Environment.CurrentDirectory + @"\Configuration\profile.settings";
    }
}