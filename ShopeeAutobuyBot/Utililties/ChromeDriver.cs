using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Shopee_Autobuy_Bot.Utililties
{
    public class ChromeDriverHelper
    {
        public IWebDriver driver { get; set; }
        public int driverProc { get; set; }
        public ChromeDriverService driverService = ChromeDriverService.CreateDefaultService();
        public ChromeOptions options = new ChromeOptions();
    }
}
