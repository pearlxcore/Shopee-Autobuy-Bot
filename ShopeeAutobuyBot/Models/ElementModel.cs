namespace Shopee_Autobuy_Bot.Models
{
    public class ElementModel
    {
        public class Root
        {
            public ProductPage ProductPage { get; set; }
            public CartPage CartPage { get; set; }
            public CheckoutPage CheckoutPage { get; set; }
        }
        public class ProductPage
        {
            public string BuyNowButton { get; set; }
            public string ProductVariationFlexBox { get; set; }
            public string QuantityCheckbox { get; set; }
            public string CurrentPriceLabel { get; set; }
            public string SaleBanner { get; set; }
        }

        public class CartPage
        {
            public string CheckOutButton { get; set; }
            public string SelectAllCheckbox { get; set; }
            public string ProductPriceLabel { get; set; }
            public string ClaimShopVoucherButton { get; set; }
            public string CartEmptyLabel { get; set; }
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
    }
}
