namespace Shopee_Autobuy_Bot.Models
{
    public class UserModel
    {
        public string status { get; set; }
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool online { get; set; }
        public string device_fingerprintv2 { get; set; }
        public string device_fingerprint1 { get; set; }
        public string device_fingerprint2 { get; set; }
        public string device_fingerprint3 { get; set; }
        public string expiry_date { get; set; }
    }
}
