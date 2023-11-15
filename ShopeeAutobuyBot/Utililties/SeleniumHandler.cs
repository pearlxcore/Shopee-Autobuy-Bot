using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shopee_Autobuy_Bot.Constants;
using System;
using System.Collections.Generic;

namespace Shopee_Autobuy_Bot
{
    public class SeleniumHandler
    {
        private readonly bool _disableImageExtension;
        private readonly bool _headless;
        private readonly string _chromeProfile;
        private ChromeDriverService _chromeDriverService = ChromeDriverService.CreateDefaultService();
        private ChromeOptions _chromeOptions = new ChromeOptions();
        private int driverProc { get; set; }
        private List<Action> _methodList = new List<Action>();

        public int timeOut { get; set; }

        public IWebDriver _driver { get; set; }
        IWebElement element { get; set; }


        public SeleniumHandler(bool disableImageExtension, bool headless, string chromeProfile)
        {
            _disableImageExtension=disableImageExtension;
            _headless=headless;
            _chromeProfile=chromeProfile;
        }

        public SeleniumHandler Initialize()
        {
            try
            {
                _driver = InitializeDriver();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return this;
        }

        #region FluentControl

        public SeleniumHandler WaitForUrlToMatch(string url)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(driver => driver.Url == url);
            return this;
        }

        public SeleniumHandler WaitUrlContainString(string text)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(driver => driver.Url.Contains(text));
            return this;
        }

        public SeleniumHandler GoToUrl(string url)
        {
            return this;
        }


        public SeleniumHandler RefreshPage()
        {
            _driver.Navigate().Refresh();
            return this;
        }

        public SeleniumHandler ReturnPage(string url)
        {
            _driver.Navigate().Back();
            return this;
        }

        public SeleniumHandler WaitElementExists(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            return this;
        }

        public SeleniumHandler WaitElementClickable(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            return this;
        }

        public SeleniumHandler WaitElementVisible(By locator)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return this;
        }

        public SeleniumHandler QuitDriver()
        {
            _driver.Quit();
            _driver = null;
            return this;
        }

        public SeleniumHandler SelectElement(By locator)
        {
            element = _driver.FindElement(locator);
            return this;
        }

        public SeleniumHandler ClickElement()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", element);
            return this;
        }

        public SeleniumHandler SendKeys(string text)
        {
            element.SendKeys(text);
            return this;
        }

        public SeleniumHandler ClearKeys()
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


        #endregion

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

        #endregion

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
            chromeOptions.AddArgument($"user-data-dir={DirectoryPaths.SabProfileDirectory}{_chromeProfile}");
            chromeOptions.AddArgument($"--profile-directory=Default");
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArgument("no-sandbox");
            return chromeOptions;
        }
    }
}
