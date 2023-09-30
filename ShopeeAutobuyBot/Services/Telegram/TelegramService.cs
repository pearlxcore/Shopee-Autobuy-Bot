using Shopee_Autobuy_Bot.Services.Logger;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace Shopee_Autobuy_Bot.Services.Telegram
{
    public class TelegramService : ITelegramService
    {
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;

        public TelegramService(IAutoBuyLoggerService autoBuyLoggerService)
        {
            _autoBuyLoggerService = autoBuyLoggerService;
        }

        void ITelegramService.SendNotification(bool scheduleBot, string buyingMode, string orderPrice, string productLink)
        {
            try
            {
                string timerMode = scheduleBot ? "Countdown mode" : "Normal";
                string text = "*Order price*: " + orderPrice +
                    "\n*Product link*: " + productLink +
                    "\n*Buying mode*: " + buyingMode;
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "1914520458:AAGKuro58sqowR4fawgcn9XuE4o9cC0jyvg";
                string chatId = "@SAB_pxc";
                urlString = String.Format(urlString, apiToken, chatId, text);
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
                _autoBuyLoggerService.AutoBuyProcessLog("Notification sent to telegram", Color.LawnGreen, true, true, true);
            }
            catch (Exception ex) { _autoBuyLoggerService.AutoBuyProcessLog("Failed to send notification to telegram. " + ex.Message, Color.LawnGreen, true, true, true); }
        }
    }
}
