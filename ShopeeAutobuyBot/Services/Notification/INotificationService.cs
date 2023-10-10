using Shopee_Autobuy_Bot.Services.Profile;
using System;

namespace Shopee_Autobuy_Bot.Services.Notification
{
    public interface INotificationService
    {
        void SendNotification(string sabAccount, IProfileService profileService, string orderPrice, TimeSpan checkoutTimeSpan);
    }
}
