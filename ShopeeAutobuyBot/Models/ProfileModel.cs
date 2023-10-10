namespace Shopee_Autobuy_Bot.Utililties
{
    public class ProfileModel
    {
        public class BotSettings
        {
            public bool alert_telegram { get; set; }
            public bool desktop_notification { get; set; }
            public bool autorefresh_webpage { get; set; }
            public int autorefresh_interval { get; set; }
            public bool disable_logging { get; set; }
            public bool test_mode { get; set; }
            public int timeout { get; set; }
        }

        public class ProductDetail
        {
            public string product_link { get; set; }
            public string variant { get; set; }
            public int quantity { get; set; }
            public bool random_variant { get; set; }
            public bool variant_preSelected { get; set; }

        }

        public class Voucher_Coin
        {
            public bool claim_shop_vc { get; set; }
            public bool redeem_coin { get; set; }
            public bool redeeem_shopee_vc { get; set; }
        }

        public class ScheduleBot
        {
            public bool schedule { get; set; }
            public int hour { get; set; }
            public int minute { get; set; }
            public int second { get; set; }
            public bool tomorrow { get; set; }
        }

        public class BuyingMode
        {
            public string mode { get; set; }
            public double user_price { get; set; }
            public string below_specific_price { get; set; }
            public string cart_below_specific_price { get; set; }
        }

        public class PaymentDetail
        {
            public string payment_method { get; set; }
            public string bank_type { get; set; }
            public string last_4_digit_card { get; set; }
            public string shopeepay_pin { get; set; }
        }

        public class Root
        {
            public string profile_name { get; set; }
            public BotSettings BotSettings = new BotSettings();
            public ProductDetail ProductDetail = new ProductDetail();
            public Voucher_Coin Voucher_Coin = new Voucher_Coin();
            public ScheduleBot ScheduleBot = new ScheduleBot();
            public BuyingMode BuyingMode = new BuyingMode();
            public PaymentDetail PaymentDetail = new PaymentDetail();
        }
    }
}
