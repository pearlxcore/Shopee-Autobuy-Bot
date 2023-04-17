namespace Shopee_Autobuy_Bot.Utililties
{
    public class BotProfileModel
    {
        public class BotSettings
        {
            public bool play_sound { get; set; }
            public bool hide_browser { get; set; }
            public bool disable_image { get; set; }
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
            public string payment_type { get; set; }
            public string bank_type { get; set; }
            public string last_4_digit_card { get; set; }
            public string shopeepay_pin { get; set; }
        }

        public class Root
        {
            public string profile_name { get; set; }
            public BotSettings BotSettings { get; set; }
            public ProductDetail ProductDetail { get; set; }
            public Voucher_Coin Voucher_Coin { get; set; }
            public ScheduleBot ScheduleBot { get; set; }
            public BuyingMode BuyingMode { get; set; }
            public PaymentDetail PaymentDetail { get; set; }
        }
    }
}
