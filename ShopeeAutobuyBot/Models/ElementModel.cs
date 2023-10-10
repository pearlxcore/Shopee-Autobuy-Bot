namespace Shopee_Autobuy_Bot.Models
{
    public class ElementModel
    {
        public class Root
        {
            public ProductPage ProductPage { get; set; }
            public CartPage CartPage { get; set; }
            public CheckoutPage CheckoutPage { get; set; }
            public Payment Payment { get; set; }
        }
        public class ProductPage
        {
            public string BuyNowButton { get; set; }
            public string ProductVariationContainer { get; set; }
            public string QuantityCheckbox { get; set; }
            public string CurrentPriceLabel { get; set; }
            public string SaleBanner { get; set; }
            public string UnlistedError { get; set; }
        }

        public class CartPage
        {
            public string CheckOutButton { get; set; }
            public string SelectAllCheckbox { get; set; }
            public string CartTotalPriceLabel { get; set; }
            public string ClaimShopVoucherButton { get; set; }
            public string CartEmptyLabel { get; set; }
            public string SelectAllLabel { get; set; }
        }

        public class CheckoutPage
        {
            public string PlaceOrderButton { get; set; }
            public string SelectShopeeVoucherButton { get; set; }
            public string ShopeeVoucherContainer { get; set; }
            public string ShopeeVoucherOkButton { get; set; }
            public string RedeemCoinCheckbox { get; set; }
            public string ChangePaymentButton { get; set; }
            public string OrderPrice { get; set; }
        }

        public class Payment
        {
            public PaymentMethod PaymentMethod { get; set; }
            public PaymentConvenienceStoresType PaymentConvenienceStoresType { get; set; }
            public PaymentErrorMessage PaymentErrorMessage { get; set; }
        }

        public class PaymentMethod
        {
            public string ATM_CashDeposit { get; set; }
            public string OnlineBanking { get; set; }
            public string CashOnDelivery { get; set; }
            public string DebitCreditCard { get; set; }
            public string ConvenienceStores { get; set; }
            public string CreditCardInstallment { get; set; }
            public string GooglePay { get; set; }
        }

        public class PaymentConvenienceStoresType
        {
            public string SevenEleven { get; set; }
            public string KKMart { get; set; }
        }

        public class PaymentErrorMessage
        {
            public string InvalidShopeePayPin { get; set; }
            public string BankMaintenance { get; set; }
            public string ActivateShopeePay { get; set; }
            public string ShopeePayInsufficientFund { get; set; }
            public string PayNowMaintenance { get; set; }
            public string TransactionExceeded { get; set; }
            public string CartItemOutOfStock { get; set; }
            public string InactiveProducts { get; set; }
        }
    }
}
