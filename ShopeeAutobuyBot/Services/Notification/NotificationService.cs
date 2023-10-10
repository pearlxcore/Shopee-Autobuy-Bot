using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;

        public NotificationService(IAutoBuyLoggerService autoBuyLoggerService)
        {
            _autoBuyLoggerService = autoBuyLoggerService;
        }

        public void SendNotification(string sabAccount, IProfileService profileService, string orderPrice, TimeSpan checkoutTimeSpan)
        {
            if (profileService.SelectedProfile.BotSettings.desktop_notification)
            {
                string checkoutTime = checkoutTimeSpan.ToString("hh\\:mm\\:ss\\:ff");

                Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Icon = appIcon;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "Order placed";
                notifyIcon.BalloonTipText = $"Account : {sabAccount}\nOrder Price : {orderPrice}\n" +
                    $"Checkout time : {checkoutTime}";
                notifyIcon.ShowBalloonTip(10000000);
            }

            if (profileService.SelectedProfile.BotSettings.alert_telegram)
            {
                try
                {
                    string checkoutTime = checkoutTimeSpan.ToString("hh\\:mm\\:ss\\:ff");
                    var variantMode = "";
                    variantMode = (profileService.SelectedProfile.ProductDetail.variant_preSelected) ? "(Pre selected)" : "";
                    variantMode = (profileService.SelectedProfile.ProductDetail.random_variant) ? "(Random)" : "";

                    string message = $@"Account  : {sabAccount}
Product Link : {profileService.SelectedProfile.ProductDetail.product_link}
Variation  : {profileService.SelectedProfile.ProductDetail.variant} {variantMode}
Mode : {profileService.SelectedProfile.BuyingMode.mode}
Total Price  : {orderPrice}
Chekout Time : {checkoutTime}";

                    string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                    string apiToken = "1914520458:AAGKuro58sqowR4fawgcn9XuE4o9cC0jyvg";
                    string chatId = "@SAB_pxc";
                    urlString = String.Format(urlString, apiToken, chatId, message);
                    WebRequest request = WebRequest.Create(urlString);
                    Stream rs = request.GetResponse().GetResponseStream();
                    StreamReader reader = new StreamReader(rs);
                    string line = "";
                    StringBuilder sb = new StringBuilder();
                    while (line != null)
                    {
                        line = reader.ReadLine();
                        if (line != null)
                            sb.Append(line);
                    }
                    string response = sb.ToString();

                    _autoBuyLoggerService.AutoBuyProcessLog("Notification sent to telegram", Color.Black, true, true, true);
                }
                catch (Exception ex) { _autoBuyLoggerService.AutoBuyProcessLog("Failed to send notification to telegram. " + ex.Message, Color.DarkGreen, true, true, true); }
            }
        }
    }
}
