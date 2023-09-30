using System;

namespace Shopee_Autobuy_Bot.Services
{
    public interface IAutoBuyService
    {
        TimeSpan CheckoutTimeFinal { get; }
        bool Aborted { get; }
        TimeSpan TimeSpan { get; }
        void StartAutoBuy();
        void AutobuyErrorHandler(int Try, int step, Exception ex, string navigateLink, bool includeInputStringError, bool skipRefreshPage);
        void CartCheckout_ClaimShopVoucher();
        void CartCheckout_ClickCheckoutButton();
        (decimal userPrice, decimal cartTotalPrice) CartCheckout_GetPrice();
        void CartCheckout_SelectAllCheckBox();
        (decimal userPrice, decimal productPrice) GetPrice();
        void IncreaseQuantity();
        void RefreshPageAndLoopAutobuy(string navigateLink, int Try, int step, bool loopAutobuy);
        string SelectVariant();
        void ShopeeAutobuy(int Try = 0, int step = 1, DateTime? workTime = null);
        void step0(int Try);
        void step1(int Try);
        void step2(int Try);
        void step3(int Try);
        void step4(int Try);
        void step5(int Try);
        void step6(int Try);
        void step7(int Try);
        void step8(int Try);
        void step94(int Try);
        void step95(int Try);
        void step96(int Try);
    }
}