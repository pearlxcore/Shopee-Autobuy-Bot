using OpenQA.Selenium;

namespace Shopee_Autobuy_Bot
{
    public interface ISeleniumService
    {
        IWebDriver _driver { get; set; }
        int timeOut { get; set; }

        SeleniumService ClearKeys();

        SeleniumService ClickElement();

        void ClickElement(IWebElement webElement);

        bool ElementClickable(By locator);

        bool ElementExists(By locator);

        IWebElement GetElement(By locator);

        SeleniumService GoToUrl(string url);

        SeleniumService Initialize(bool disableImageExtension, bool headless, string chromeProfile);

        SeleniumService QuitDriver();

        SeleniumService RefreshPage();

        SeleniumService ReturnPage(string url);

        void Run();

        SeleniumService SelectElement(By locator);

        SeleniumService SendKeys(string text);

        bool UrlContainString(string text);

        SeleniumService WaitElementClickable(By locator);

        SeleniumService WaitElementExists(By locator);

        SeleniumService WaitElementVisible(By locator);

        SeleniumService WaitForUrlToMatch(string url);

        SeleniumService WaitUrlContainString(string text);
        void SaveCookie();

        void LoadCookie();

        void ClearCookie();

        public bool CheckLogin();
    }
}