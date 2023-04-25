using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Shopee_Autobuy_Bot.Constants;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot.Utililties
{
    public class Helper
    {
        static byte[] fortyByteOf00 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        static BinaryReader br;
        public static StringBuilder SaveToLog = new StringBuilder();

        public delegate void SetTextCallbackl(
          string text,
          Color? color = null,
          bool NewLine = true,
          bool Production = true,
          bool WithDateTime = true,
            bool isLogging = true);

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
                string host = $"{ServerInfos.PingHost}";
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

        private static string Id_;
        public static string Id
        {
            get { return Id_; }
            set { Id_ = value; }
        }

        private static string OrderPrice_;
        public static string OrderPrice
        {
            get { return OrderPrice_; }
            set { OrderPrice_ = value; }
        }


        private static int delaySeconds_;
        public static int delaySeconds
        {
            get { return delaySeconds_; }
            set { delaySeconds_ = value; }
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

        private static string _chromeProfile;
        public static string chromeProfile
        {
            get { return _chromeProfile; }
            set { _chromeProfile = value; }
        }

        public class Shopee
        {

            private static int TimeOut_;
            public static int TimeOut
            {
                get { return TimeOut_; }
                set { TimeOut_ = value; }
            }

            private static int ProductQuantity_;
            public static int ProductQuantity
            {
                get { return ProductQuantity_; }
                set { ProductQuantity_ = value; }
            }

            private static string BankType_;
            public static string BankType
            {
                get { return BankType_; }
                set { BankType_ = value; }
            }

            private static bool Aborted_;
            public static bool Aborted
            {
                get { return Aborted_; }
                set { Aborted_ = value; }
            }

            private static string ShopeePayPin_;
            public static string ShopeePayPin
            {
                get { return ShopeePayPin_; }
                set { ShopeePayPin_ = value; }
            }

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

            private static string StartButtonString_;
            public static string StartButtonString
            {
                get { return StartButtonString_; }
                set { StartButtonString_ = value; }
            }

            private static string[] ProductLink_;
            public static string[] ProductLink
            {
                get { return ProductLink_; }
                set { ProductLink_ = value; }
            }

            private static DateTime FlashSale_;
            public static DateTime FlashSale
            {
                get { return FlashSale_; }
                set { FlashSale_ = value; }
            }

            private static DateTime workTime_;
            public static DateTime workTime
            {
                get { return workTime_; }
                set { workTime_ = value; }
            }

            private static TimeSpan timeSpan_;
            public static TimeSpan timeSpan
            {
                get { return timeSpan_; }
                set { timeSpan_ = value; }
            }

            private static DateTime CheckoutTime_;
            public static DateTime CheckoutTime
            {
                get { return CheckoutTime_; }
                set { CheckoutTime_ = value; }
            }

            private static TimeSpan CheckoutTimeFinal_;
            public static TimeSpan CheckoutTimeFinal
            {
                get { return CheckoutTimeFinal_; }
                set { CheckoutTimeFinal_ = value; }
            }

            private static TimeSpan seconds_;
            public static TimeSpan seconds
            {
                get { return seconds_; }
                set { seconds_ = value; }
            }





            private static bool HasVariation_;
            public static bool HasVariation
            {
                get { return HasVariation_; }
                set { HasVariation_ = value; }
            }


        }

        public class QuickBuyMode
        {



            private static string csrfToken_;
            public static string csrfToken
            {
                get { return csrfToken_; }
                set { csrfToken_ = value; }
            }

            private static string userAgent_;
            public static string userAgent
            {
                get { return userAgent_; }
                set { userAgent_ = value; }
            }

            private static string addOnDealId_;
            public static string addOnDealId
            {
                get { return addOnDealId_; }
                set { addOnDealId_ = value; }
            }

            private static string shopId_;
            public static string shopId
            {
                get { return shopId_; }
                set { shopId_ = value; }
            }
            private static string itemId_;
            public static string itemId
            {
                get { return itemId_; }
                set { itemId_ = value; }
            }

            private static string itemGroupId_;
            public static string itemGroupId
            {
                get { return itemGroupId_; }
                set { itemGroupId_ = value; }
            }

            private static string modelId_;
            public static string modelId
            {
                get { return modelId_; }
                set { modelId_ = value; }
            }

            private static string promotionId_;
            public static string promotionId
            {
                get { return promotionId_; }
                set { promotionId_ = value; }
            }

            private static string quantity_;
            public static string quantity
            {
                get { return quantity_; }
                set { quantity_ = value; }
            }

            private static bool isMonitorPrice_;
            public static bool isMonitorPrice
            {
                get { return isMonitorPrice_; }
                set { isMonitorPrice_ = value; }
            }

            private static int monitorPrice_;
            public static int monitorPrice
            {
                get { return monitorPrice_; }
                set { monitorPrice_ = value; }
            }

            private static string variation_;
            public static string variation
            {
                get { return variation_; }
                set { variation_ = value; }
            }

            private static bool startCheckout_ = false;
            public static bool startCheckout
            {
                get { return startCheckout_; }
                set { startCheckout_ = value; }
            }

            private static string isAddOnSubItem_;
            public static string isAddOnSubItem
            {
                get { return isAddOnSubItem_; }
                set { isAddOnSubItem_ = value; }
            }

            private static string useCoin_;
            public static string useCoin
            {
                get { return useCoin_; }
                set { useCoin_ = value; }
            }

            private static string selectedLogisticChannelId_;
            public static string selectedLogisticChannelId
            {
                get { return selectedLogisticChannelId_; }
                set { selectedLogisticChannelId_ = value; }
            }

            private static JObject JObject_;
            public static JObject JObject__
            {
                get { return JObject_; }
                set { JObject_ = value; }
            }
        }

        public class Lazada
        {
            private static string WalletPin_;
            public static string WalletPin
            {
                get { return WalletPin_; }
                set { WalletPin_ = value; }
            }

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

            private static string StartButtonString_;
            public static string StartButtonString
            {
                get { return StartButtonString_; }
                set { StartButtonString_ = value; }
            }

            private static string[] ProductLink_;
            public static string[] ProductLink
            {
                get { return ProductLink_; }
                set { ProductLink_ = value; }
            }

            private static DateTime FlashSale_;
            public static DateTime FlashSale
            {
                get { return FlashSale_; }
                set { FlashSale_ = value; }
            }

            private static DateTime workTime_;
            public static DateTime workTime
            {
                get { return workTime_; }
                set { workTime_ = value; }
            }

            private static TimeSpan seconds_;
            public static TimeSpan seconds
            {
                get { return seconds_; }
                set { seconds_ = value; }
            }

            private static IWebDriver driver_;
            public static IWebDriver driver
            {
                get { return driver_; }
                set { driver_ = value; }
            }

            private static int driverProc_;
            public static int driverProc
            {
                get { return driverProc_; }
                set { driverProc_ = value; }
            }

            private static bool DisableImageExtension_;
            public static bool DisableImageExtension
            {
                get { return DisableImageExtension_; }
                set { DisableImageExtension_ = value; }
            }

            private static bool HasVariation_;
            public static bool HasVariation
            {
                get { return HasVariation_; }
                set { HasVariation_ = value; }
            }

            private static string ID_;
            public static string ID
            {
                get { return ID_; }
                set { ID_ = value; }
            }
        }

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
}
