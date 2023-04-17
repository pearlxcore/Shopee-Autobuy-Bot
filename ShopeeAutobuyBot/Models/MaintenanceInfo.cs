using System.Collections.Generic;

namespace Shopee_Autobuy_Bot.Models
{
    public class MaintenanceInfo
    {
        public int status { get; set; }
        public List<string> exclude { get; set; }
    }
}
