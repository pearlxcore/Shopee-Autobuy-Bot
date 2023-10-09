using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Extensions;
using Shopee_Autobuy_Bot.Services.Profile;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot.Services.Logger
{
    public class AutoBuyLoggerService : IAutoBuyLoggerService
    {
        private readonly RichTextBox _richTextBox;
        private readonly IProfileService _profileService;

        public AutoBuyLoggerService(RichTextBox richTextBox, IProfileService profileService)
        {
            _richTextBox=richTextBox;
            _profileService=profileService;
        }

        private delegate void SetTextCallback(string text, Color? color, bool NewLine, bool Production, bool WithDateTime);

        public void AutoBuyProcessLog(string text, Color? color = null, bool NewLine = true, bool Production = true, bool WithDateTime = true)
        {
            if (_richTextBox.InvokeRequired)
            {
                SetTextCallback callback = new SetTextCallback(AutoBuyProcessLog);
                object[] args = { text, color, NewLine, Production, WithDateTime };
                _richTextBox.Invoke(callback, args);
            }
            else
            {
                if (WithDateTime)
                    _richTextBox.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] ", Color.Gray, false);
                _richTextBox.AppendText(text, color ?? Color.White, NewLine);
            }
        }


        public void ProgramLog()
        {
            throw new NotImplementedException();
        }

        public void SaveAutoBuyProcessLogToLogFile(RichTextBox richTextBox)
        {
            if (!Directory.Exists(DirectoryPaths.LogDirectory))
                Directory.CreateDirectory(DirectoryPaths.LogDirectory);

            bool testmode;
            string testMode = "Test mode : " + (testmode = (_profileService.SelectedProfile.BotSettings.test_mode) ? true : false).ToString() + "\n";

            string belowPrice = "";

            string productLink = "";
            productLink = "Product link : " + _profileService.SelectedProfile.ProductDetail.product_link + "\n";
            string buyingMode = "";
            string buyMode = _profileService.SelectedProfile.BuyingMode.mode.ToString();
            if (buyMode == "Below_Price")
                belowPrice = " (RM" + _profileService.SelectedProfile.BuyingMode.below_specific_price + ")";
            if (buyMode == "Below_Price_Cart")
                belowPrice = " (RM" + _profileService.SelectedProfile.BuyingMode.cart_below_specific_price + ")";

            if (buyMode == "Below_Price"|| buyMode == "Below_Price_Cart")
                buyingMode = "Buying Mode : " + buyMode + belowPrice + "\n\n";
            else
                buyingMode = "Buying Mode : " + buyMode + "\n\n";

            string quantity = "Quantity : " + _profileService.SelectedProfile.ProductDetail.quantity + "\n";

            string paymentdetail = "Payment method : " + _profileService.SelectedProfile.PaymentDetail.payment_method + "\n";

            string detail = "";
            if (buyMode == BuyingMode.Cart|| buyMode == BuyingMode.Below_Price_Cart)
                detail = testMode + quantity + paymentdetail + buyingMode;
            else
                detail = testMode + productLink + quantity + paymentdetail + buyingMode;

            Helper.SaveToLog.Append(detail);

            Helper.SaveToLog.Append(richTextBox.Text);

            string output = DirectoryPaths.LogDirectory + "\\" + AutoBuyInfo.AutoBuyStartTime.ToString("yyyy-dd-M--HH-mm-ss") + ".txt";
            File.AppendAllText(output, Helper.SaveToLog.ToString());
            Helper.SaveToLog.Clear();
        }
    }
}
