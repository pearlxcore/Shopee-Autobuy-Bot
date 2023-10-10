using Microsoft.Win32;
using Shopee_Autobuy_Bot.Constants;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot.Utililties
{
    public static class StreamExtensions
    {
        public static byte[] ReadAllBytesss(this Stream instream)
        {
            if (instream is MemoryStream)
                return ((MemoryStream)instream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                instream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }

    public class Helper
    {
        // obselete
        public static StringBuilder SaveToLog = new StringBuilder();
        public class ProgramRegistration
        {
            static byte[] fortyByteOf00 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            static BinaryReader br;


            private static string tempFile_;
            public static string tempFile
            {
                get { return tempFile_; }
                set { tempFile_ = value; }
            }

            private static string currentFile_;
            public static string currentFile
            {
                get { return currentFile_; }
                set { currentFile_ = value; }
            }

            private static bool MultipleInstances_ = false;
            public static bool MultipleInstances
            {
                get { return MultipleInstances_; }
                set { MultipleInstances_ = value; }
            }

            private static bool updating_ = false;
            public static bool updating
            {
                get { return updating_; }
                set { updating_ = value; }
            }

            private static bool firstTime_ = false;
            public static bool firstTime
            {
                get { return firstTime_; }
                set { firstTime_ = value; }
            }

            private static string serial_number_;
            public static string serial_number
            {
                get { return serial_number_; }
                set { serial_number_ = value; }
            }
            public static string GetHexStringFrom(byte[] byteArray)
            {
                return BitConverter.ToString(byteArray); //To convert the whole array
            }

            public static void WriteSerial(string currentProgram, string SerialNumberMagicByte, bool lifetime)
            {

                try { }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                byte[] hex = null;
                byte[] randomHex = null;
                if (lifetime == true)
                {
                    SerialNumberMagicByte = new string('0', SerialNumberMagicByte.Length);
                    hex = HexStringConverter.ToByteArray(SerialNumberMagicByte);

                    randomHex = fortyByteOf00;

                }
                else
                {
                    hex = HexStringConverter.ToByteArray(SerialNumberMagicByte);
                    randomHex = HexStringConverter.ToByteArray(GetRandomHexNumber(40));

                }

                tempFile = DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe";
                currentFile = DirectoryPaths.CurrentDirectory + "Shopee Autobuy Bot.exe";
                var all_byte = File.ReadAllBytes(currentProgram);
                Stream S = new MemoryStream(all_byte);

                using (var bw = new BinaryWriter(S))
                {

                    bw.Seek(-48, SeekOrigin.End);
                    bw.Write(hex);

                    bw.Seek(-28, SeekOrigin.End);
                    bw.Write(randomHex);

                    byte[] bytes = S.ReadAllBytesss();

                    if (!Directory.Exists(DirectoryPaths.SabTempDirectory))
                        Directory.CreateDirectory(DirectoryPaths.SabTempDirectory);

                    File.WriteAllBytes(tempFile, bytes);
                    if (File.Exists(tempFile))
                    {
                        firstTime = true;
                        //MessageBox.Show("Thanks for purchasing this program :)", "Thanks!");
                        Thread.Sleep(1500);
                        Application.Exit();
                    }
                }
            }


            static Random random = new Random();
            public static string GetRandomHexNumber(int digits)
            {
                byte[] buffer = new byte[digits / 2];
                random.NextBytes(buffer);
                string result = string.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
                if (digits % 2 == 0)
                    return result;
                return result + random.Next(16).ToString("X");
            }


            public static byte[] ReadMagicByte(string currentProgram, byte[] buffer)
            {
                br = new BinaryReader(File.OpenRead(currentProgram));
                br.BaseStream.Seek(-48, SeekOrigin.End);
                br.Read(buffer, 0, 20);
                br.Dispose();
                return buffer;
            }

            public static string ComputeSha256Hash(string txt)
            {
                // Create a SHA256
                using (SHA1 SHA1 = SHA1.Create())
                {
                    // ComputeHash - returns byte array
                    byte[] bytes = SHA1.ComputeHash(Encoding.UTF8.GetBytes(txt));

                    // Convert byte array to a string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }

            public static DateTime GetLocalTime()
            {
                DateTime localDateTime = new DateTime();
                var client = new TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

                }
                return localDateTime;
            }

            public static class HexStringConverter
            {
                public static byte[] ToByteArray(string HexString)
                {
                    int NumberChars = HexString.Length;
                    byte[] bytes = new byte[NumberChars / 2];
                    for (int i = 0; i < NumberChars; i += 2)
                    {
                        bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
                    }
                    return bytes;
                }
            }
        }


        public delegate void SetTextCallbackl(
            RichTextBox richTextBox,
          string text,
          Color? color = null,
          bool NewLine = true,
          bool Production = true,
          bool WithDateTime = true);

        // obselete
        public class Utilities
        {
            public static string GetChromeDriverVersion()
            {
                //check local version
                ProcessStartInfo startInfo = new ProcessStartInfo();
                var chromedriverPath = DirectoryPaths.CurrentDirectory + "chromedriver.exe";
                startInfo.FileName = chromedriverPath;
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.Arguments = "--version";
                var cmd = Process.Start(startInfo);
                string version = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();

                int pFrom = version.IndexOf("ChromeDriver ") + "ChromeDriver ".Length;
                int pTo = version.LastIndexOf(" (");
                version = version.Substring(pFrom, pTo - pFrom);
                return version;
            }


            public static void KillChromedriver()
            {
                try
                {
                    var chromeDriverProcesses = Process.GetProcesses().
Where(pr => pr.ProcessName == "chromedriver"); // without '.exe'

                    foreach (var process in chromeDriverProcesses)
                    {
                        process.Kill();
                    }
                    Thread.Sleep(500);
                    if (File.Exists(DirectoryPaths.CurrentDirectory + "chromedriver.exe"))
                        File.Delete(DirectoryPaths.CurrentDirectory + "chromedriver.exe");
                }
                catch { }
            }

            public static void ExtractChromedriver(string source, string destination)
            {
                ZipFile.ExtractToDirectory(source, destination);
            }
            public static void DownloadChromedriver(string chromeVersion, string targetFile)
            {
                WebClient client = new WebClient();
                client.Proxy = WebRequest.DefaultWebProxy;
                string downloadUrl = $"https://chromedriver.storage.googleapis.com/{chromeVersion}/chromedriver_win32.zip";
                client.DownloadFile(downloadUrl, targetFile);
            }

            public static bool IsWindows64Bit()
            {
                if (Environment.Is64BitOperatingSystem)
                    return true;
                else
                    return false;
            }

            public static string GetChromeVersion()
            {
                string registryPath;
                if (IsWindows64Bit())
                    registryPath =@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
                else
                    registryPath = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";

                object path;
                string version = "";
                path = Registry.GetValue(registryPath, "", null);

                if (path != null)
                {
                    return version =  FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion;
                }
                return null;
            }

            public static bool CheckConnection()
            {
                try
                {
                    Ping myPing = new Ping();
                    string host = "google.com";
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public static bool PingServer()
            {
                try
                {
                    Ping myPing = new Ping();
                    string host = $"{Urls.Github}";
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public class Shopee
        {
            private static string CountdownMicroseconds_;
            public static string CountdownMicroseconds
            {
                get { return CountdownMicroseconds_; }
                set { CountdownMicroseconds_ = value; }
            }

            private static string Courier_;
            public static string Courier
            {
                get { return Courier_; }
                set { Courier_ = value; }
            }

            private static string VariationString_;
            public static string VariationString
            {
                get { return VariationString_; }
                set { VariationString_ = value; }
            }

            private static string PaymentMethod_;
            public static string PaymentMethod
            {
                get { return PaymentMethod_; }
                set { PaymentMethod_ = value; }
            }

            private static string Status_;
            public static string Status
            {
                get { return Status_; }
                set { Status_ = value; }
            }

            private static string[] ProductLink_;
            public static string[] ProductLink
            {
                get { return ProductLink_; }
                set { ProductLink_ = value; }
            }
            private static TimeSpan seconds_;
            public static TimeSpan seconds
            {
                get { return seconds_; }
                set { seconds_ = value; }
            }

            private static bool RedeemCoin_;
            public static bool RedeemCoin
            {
                get { return RedeemCoin_; }
                set { RedeemCoin_ = value; }
            }

            private static bool RedeemShopeeVoucher_;
            public static bool RedeemShopeeVoucher
            {
                get { return RedeemShopeeVoucher_; }
                set { RedeemShopeeVoucher_ = value; }
            }

            private static bool RandomVariant_;
            public static bool RandomVariant
            {
                get { return RandomVariant_; }
                set { RandomVariant_ = value; }
            }

            private static bool HasVariation_;
            public static bool HasVariation
            {
                get { return HasVariation_; }
                set { HasVariation_ = value; }
            }
        }
    }
}
