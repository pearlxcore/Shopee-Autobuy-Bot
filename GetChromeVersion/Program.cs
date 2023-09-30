using Microsoft.Win32;
using System.Diagnostics;

namespace GetChromeVersion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string registryPath;
            if (Environment.Is64BitOperatingSystem)
                registryPath =@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
            else
                registryPath = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";

            object path;
            string version = "";
            path = Registry.GetValue(registryPath, "", null);

            if (path != null)
            {
                version =  FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion;
            }

            Console.WriteLine(version);
            Console.ReadLine();
        }

        public static void GetChromeVersion()
        {

        }
    }
}