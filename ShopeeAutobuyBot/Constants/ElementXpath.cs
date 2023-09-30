namespace Shopee_Autobuy_Bot.Constants
{
    public class ElementXpath
    {
        public static string strShopeePay_5 = "//*[@id=\"main\"]/div/div[3]/div[2]/div[5]/div[1]/div/div[1]/div[2]/span[1]/button";
        public static string strShopeePay_4 = "//*[@id=\"main\"]/div/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[2]/span[1]/button";
        public static string strInformationUpdatedOkButton = "//span[contains(@class, 'stardust-popup-button stardust-popup-button--main') and contains(text(), 'OK')]";
        public static string strChangeCourier = "//div[contains(@class, '_26DEZ8') and contains(text(), 'change')]";
        public static string strDeliverAnytime = "//div[contains(text(), 'Deliver any time')]";
        public static string strSubmitCourier = "//button[contains(text(), 'submit')]";
        public static string strPayButtonID = "//*[@id=\"pay-button\"]";
        public static string strShopeePayPin = "//div[contains(@class, 'digit-input active')]";
        public static string strShopeePayCOnfirm = "//div[contains(@class, 'okText') and contains(text(), 'CONFIRM')]";
        public static string str7ElevenOk = "//button[contains(@class, '_2W0k_h _2yXzsi') and contains(text(), 'OK')]";
        public static string strPayCcardButton = "//button[contains(@class, '_2W0k_h _2yXzsi') and contains(text(), 'Pay')]";
        public static string ItemNotSelected = "//div[contains(@class, 'shopee-alert-popup__message') and contains(text(), 'You have not selected any items for checkout')]";
    }
}
