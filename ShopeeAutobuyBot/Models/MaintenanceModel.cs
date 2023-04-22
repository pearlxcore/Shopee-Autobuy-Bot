using System.Collections.Generic;

namespace Shopee_Autobuy_Bot.Models
{
    public class MaintenanceModel
    {
        public int status { get; set; }
        public List<string> exclude { get; set; }
    }
}
