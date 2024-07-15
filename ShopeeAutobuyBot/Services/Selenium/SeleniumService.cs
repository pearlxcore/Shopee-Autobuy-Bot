using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shopee_Autobuy_Bot.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Shopee_Autobuy_Bot
{
    public class SeleniumService : ISeleniumService
    {
        private ChromeDriverService _chromeDriverService = ChromeDriverService.CreateDefaultService();
        private ChromeOptions _chromeOptions = new ChromeOptions();
        private int driverProc { get; set; }
        private List<Action> _methodList = new List<Action>();
        private bool _disableImageExtension { get; set; }
        private bool _headless { get; set; }
        private string _chromeProfile { get; set; }
        public int timeOut { get; set; }
        public IWebDriver _driver { get; set; }
        private IWebElement element { get; set; }

        public SeleniumService Initialize(bool disableImageExtension, bool headless, string chromeProfile)
        {
            _disableImageExtension=disableImageExtension;
            _headless=headless;
            _chromeProfile=chromeProfile;
            try
            {
                _driver = InitializeDriver();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return this;
        }

        #region FluentApi

        public SeleniumService WaitForUrlToMatch(string url)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(driver => driver.Url == url);
            return this;
        }

        public SeleniumService WaitUrlContainString(string text)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(driver => driver.Url.Contains(text));
            return this;
        }

        public SeleniumService GoToUrl(string url)
        {
            // Open a new tab using JavaScript
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.open();");
            // Sleep for 1 second (adjust as needed)
            Thread.Sleep(1000);


            // Switch to the new tab
            var windowHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(windowHandles[^1]);
            // Sleep for 1 second (adjust as needed)
            Thread.Sleep(1000);



            // Navigate to the specified URL in the new tab
            _driver.Navigate().GoToUrl(url);
            // Sleep for 1 second (adjust as needed)
            Thread.Sleep(1000);



            return this;
        }

        public SeleniumService RefreshPage()
        {
            _driver.Navigate().Refresh();
            return this;
        }

        public SeleniumService ReturnPage(string url)
        {
            _driver.Navigate().Back();
            return this;
        }

        public SeleniumService WaitElementExists(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            return this;
        }

        public SeleniumService WaitElementClickable(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            return this;
        }

        public SeleniumService WaitElementVisible(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return this;
        }

        public SeleniumService QuitDriver()
        {
            _driver.Quit();
            _driver = null;
            return this;
        }

        public SeleniumService SelectElement(By locator)
        {
            element = _driver.FindElement(locator);
            return this;
        }

        public SeleniumService ClickElement()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return this;
        }

        public SeleniumService SendKeys(string text)
        {
            element.SendKeys(text);
            return this;
        }

        public SeleniumService ClearKeys()
        {
            element.Clear();
            return this;
        }

        public void Run()
        {
            try
            {
                foreach (var method in _methodList)
                {
                    method.Invoke();
                }
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebDriverTimeoutException($"Timeout.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion FluentApi

        #region ElementConditionCheck

        public bool UrlContainString(string text)
        {
            try
            {
                if (_driver.Url.Contains(text))
                    return true;
                else
                    return false;
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Timeout.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ElementClickable(By locator)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(_driver, new TimeSpan(0, 0, timeOut));
                webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ElementExists(By locator)
        {
            try
            {
                _driver.FindElement(locator);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion ElementConditionCheck

        public IWebElement GetElement(By locator)
        {
            element = _driver.FindElement(locator);
            return element;
        }

        public void ClickElement(IWebElement webElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }

        private IWebDriver InitializeDriver()
        {
            _chromeDriverService = ChromeDriverService.CreateDefaultService();
            _chromeOptions = new ChromeOptions();
            IWebDriver _webDriver;
            _chromeDriverService.HideCommandPromptWindow = true;
            _chromeOptions = GetOptions(_chromeOptions);
            driverProc = _chromeDriverService.ProcessId;
            _webDriver = (IWebDriver)new ChromeDriver(_chromeDriverService, _chromeOptions, TimeSpan.FromMinutes(3.0));
            _webDriver.Manage().Window.Maximize();
            return _webDriver;
        }

        private ChromeOptions GetOptions(ChromeOptions chromeOptions)
        {
            if (_disableImageExtension)
            {
                chromeOptions.AddArgument("--disable-extensions");
                chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
            }
            else
                chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.images", 1);
            if (_headless)
                chromeOptions.AddArgument("headless");
            chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
            //chromeOptions.EnableMobileEmulation("iPhone X");
            //chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 14_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.1 Mobile/15E148 Safari/604.1");

            chromeOptions.AddArgument($"user-data-dir={DirectoryPaths.SabProfileDirectory}{_chromeProfile}");
            chromeOptions.AddArgument($"--profile-directory=Default");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArgument("no-sandbox");
            return chromeOptions;
        }

        public void SaveCookie()
        {
            _driver.Navigate().GoToUrl("https://shopee.com.my/");

            // Get all cookies from the current tab
            var cookies = _driver.Manage().Cookies.AllCookies;

            // Convert the cookies to a string
            string cookieString = string.Join("; ", cookies);

            // Save the cookies to a file
            File.WriteAllText("cookies.txt", cookieString);
        }

        public void LoadCookie()
        {
            // Navigate to a webpage (you can navigate to any page)
            _driver.Navigate().GoToUrl("https://shopee.com.my/");

            // Load cookies from a file
            string cookieString = File.ReadAllText("cookies.txt");

            // Split the cookie string into individual cookies
            var cookieArray = cookieString.Split(';');

            // Add each cookie to the WebDriver's cookie store
            foreach (var cookie in cookieArray)
            {
                var parts = cookie.Split('=');
                if (parts.Length == 2)
                {
                    var name = parts[0].Trim();
                    var value = parts[1].Trim();
                    _driver.Manage().Cookies.AddCookie(new Cookie(name, value));
                }
            }

            // Refresh the page to apply the loaded cookies
            _driver.Navigate().Refresh();
        }

        public void ClearCookie()
        {
            try
            {
                // Navigate to a webpage
                _driver.Navigate().GoToUrl("https://shopee.com.my/");

                // Clear all cookies
                _driver.Manage().Cookies.DeleteAllCookies();


                _driver.Navigate().Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to clear SPC_EC cookie:\n\n" + ex.Message, ex);
            }
        }

        public bool CheckLogin()
        {
            _driver.Navigate().GoToUrl("https://shopee.com.my/user/account/profile");
            var result = WaitUrlContainString("https://shopee.com.my/user/account/profile");
            if (result.UrlContainString("https://shopee.com.my/buyer/login"))
                return false;
            return true;
        }
    }
}
