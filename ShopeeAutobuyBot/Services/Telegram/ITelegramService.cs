namespace Shopee_Autobuy_Bot.Services.Telegram
{
    public interface ITelegramService
    {
        void SendNotification(bool scheduleBot, string buyingMode, string orderPrice, string productLink);
    }
}
