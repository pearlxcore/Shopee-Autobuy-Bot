﻿using System;

namespace Shopee_Autobuy_Bot.Services
{
    public interface IAutoBuyService
    {
        TimeSpan TotalTimeSpan { get; }
        TimeSpan CheckoutTimeSpan { get; }
        String TotalPayment { get; }
        void ShopeeAutobuy(DateTime? jobStartTime = null);
        bool Abort { get; set; }
    }
}