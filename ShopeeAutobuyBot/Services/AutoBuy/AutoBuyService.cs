using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Notification;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Constants.AutoBuyInfo;

namespace Shopee_Autobuy_Bot.Services
{
    public class AutoBuyService : IAutoBuyService
    {
        private readonly IProfileService _profileService;
        private readonly INotificationService _notificationService;
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;
        private readonly ISeleniumService _seleniumService;
        private readonly Button _startButton;
        public DateTime JobStartTime;
        public DateTime CheckOutStartTime;
        public TimeSpan TotalTimeSpan { get; private set; }
        public TimeSpan CheckoutTimeSpan { get; private set; }
        public string OrderPrice { get; private set; }
        public bool Abort { get; set; } = false;

        public AutoBuyService(IAutoBuyLoggerService autoBuyLoggerService, ISeleniumService seleniumService, Button startButton, IProfileService profileService)
        {
            _autoBuyLoggerService = autoBuyLoggerService;
            _seleniumService = seleniumService;
            _startButton = startButton;
            _profileService=profileService;
            _notificationService = new NotificationService(_autoBuyLoggerService);
        }

        public void IncreaseQuantity()
        {
            string quantity = _profileService.SelectedProfile.ProductDetail.quantity.ToString();

            //alternative method
            if (quantity != "1")
            {
                CurrentElementDictionary.Add("Quantity checkbox", ConstantElements.ProductPage.QuantityCheckbox);
                var quantityTextboxLocator = By.XPath(ConstantElements.ProductPage.QuantityCheckbox);
                try { _seleniumService.WaitElementExists(quantityTextboxLocator); } catch { }
                try { _seleniumService.WaitElementVisible(quantityTextboxLocator); } catch { }
                try { _seleniumService.WaitElementClickable(quantityTextboxLocator); } catch { }
                _seleniumService.SelectElement(quantityTextboxLocator)
                    .ClearKeys()
                    .SendKeys(quantity);
            }
        }

        public void ShopeeAutobuy(DateTime? jobStartTime = null)
        {
            if (jobStartTime != null)
            {
                JobStartTime = jobStartTime.Value;
            }

            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Normal)
            {
                ProductPage(BuyingMode.Normal);
            }

            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Flash_Shocking)
            {
                ProductPage(BuyingMode.Flash_Shocking);
            }

            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price)
            {
                ProductPage(BuyingMode.Below_Price);
            }

            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Cart)
            {
                CartPage(BuyingMode.Cart);
            }

            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart)
            {
                CartPage(BuyingMode.Below_Price_Cart);
            }
        }

        public void AutobuyErrorHandler(string methodName, object[]? parameters, Exception ex, string navigateLink, bool includeInputStringError, bool skipRefreshPage)
        {
            if (_startButton.Text.Equals("Start") || _startButton.Text.Equals("Stopping..."))
            {
                _startButton.Text = "Stopping...";
                return;
            }

            string currentElementKey = "";
            string currentElementValue = "";

            if (CurrentElementDictionary.Count>0)
            {
                foreach (var kv in CurrentElementDictionary)
                {
                    currentElementKey = CurrentElementDictionary.First().Key;
                    currentElementValue = CurrentElementDictionary.First().Value;
                    break; // Break out of the loop once the desired key is found
                }
            }


            if (includeInputStringError)
            {
                if (ex.Message.Contains("Input string was not in a correct format."))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog($"[{methodName}] Input string was not in a correct format. Current element : {currentElementKey} ({currentElementValue})", Color.IndianRed, true, true, true);
                }
            }
            else
            {
                if (ex.Message.Contains("Waiting for element"))
                    _autoBuyLoggerService.AutoBuyProcessLog($"[{methodName}] Waiting for element : {currentElementKey}. Current element : {currentElementValue}", Color.IndianRed, true, true, true);
                else
                    _autoBuyLoggerService.AutoBuyProcessLog($"Current element : {currentElementKey} ({currentElementValue})\nAn error occurred on line {ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(':') + 1)}: {ex.Message}", Color.IndianRed, true, true, true);
            }

            if (!skipRefreshPage)
            {
                if (_profileService.SelectedProfile.BotSettings.autorefresh_webpage)
                {
                    Thread.Sleep(_profileService.SelectedProfile.BotSettings.autorefresh_interval * 1000);
                    _seleniumService.GoToUrl(navigateLink);
                }
                else
                    return;
            }

            if (!Abort)
            {
                if (methodName == "ProductPage")
                    ProductPage(_profileService.SelectedProfile.BuyingMode.mode);
                if (methodName == "CartPage")
                    CartPage(_profileService.SelectedProfile.BuyingMode.mode);
                if (methodName == "CheckoutPage")
                    CheckoutPage();
                if (methodName == "PostCheckout")
                    PostCheckout();
            }
        }

        public void RefreshPageAndLoopAutobuy(string methodName, object[] parameters, string navigateLink, bool loopAutobuy)
        {
            if (loopAutobuy)
            {
                Thread.Sleep(_profileService.SelectedProfile.BotSettings.autorefresh_interval * 1000);
                _seleniumService.GoToUrl(navigateLink);
                if (loopAutobuy && !Abort)
                {
                    if (methodName == "ProductPage")
                        ProductPage(_profileService.SelectedProfile.BuyingMode.mode);
                    if (methodName == "CartPage")
                        CartPage(_profileService.SelectedProfile.BuyingMode.mode);
                    if (methodName == "CheckoutPage")
                        CheckoutPage();
                    if (methodName == "PostCheckout")
                        PostCheckout();
                }
            }
            else
                return;
        }

        private void CartPage(string buyMode)
        {
            try
            {
                string pageUrl = "https://shopee.com.my/cart";
                _seleniumService.WaitUrlContainString(pageUrl);
                _autoBuyLoggerService.AutoBuyProcessLog("Cart page loaded.", Color.DarkGreen, true, true, true);
                Thread.Sleep(ConfigInfo.delay_step_96);

                if (_seleniumService.UrlContainString("https://shopee.com.my/buyer/login"))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Shopee account not logged in.", Color.IndianRed, true, true, true);
                    return;
                }
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.CartEmptyLabel)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Your shopping cart is empty", Color.IndianRed, true, true, true);
                    return;
                }

                if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InactiveProducts)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Warning! Some cart items are inactive.", Color.OrangeRed, true, true, true);
                }

                _seleniumService.WaitElementExists(By.XPath(ConstantElements.CartPage.SelectAllLabel));
                if (_seleniumService.GetElement(By.XPath(ConstantElements.CartPage.SelectAllLabel)).Text == "Select All (0)")
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("No items available to checkout.", Color.IndianRed, true, true, true);
                    return;
                }
                else
                {
                    // Claim shop voucher
                    if (_profileService.SelectedProfile.Voucher_Coin.claim_shop_vc)
                    {
                        RedeemShopeVoucher();
                    }

                    Thread.Sleep(ConfigInfo.delay_step_2);

                    if (buyMode == BuyingMode.Normal || buyMode == BuyingMode.Flash_Shocking || buyMode == BuyingMode.Below_Price)
                    {
                        HandleNormalCartCheckout();
                    }
                    else if (buyMode == BuyingMode.Cart)
                    {
                        CheckOutStartTime = DateTime.Now;
                        _autoBuyLoggerService.AutoBuyProcessLog($"Checkout started at {CheckOutStartTime}", Color.Black, true, true, true);
                        HandleCartCheckout();
                    }
                    else if (buyMode == BuyingMode.Below_Price_Cart)
                    {
                        CheckOutStartTime = DateTime.Now;
                        _autoBuyLoggerService.AutoBuyProcessLog($"Checkout started at {CheckOutStartTime}", Color.Black, true, true, true);
                        HandleCartCheckoutPriceSpecific(pageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(GetCurrentMethodName(), new object[] { buyMode }, ex, "https://shopee.com.my/cart", false, _profileService.SelectedProfile.BotSettings.autorefresh_webpage);
            }
        }

        private void HandleNormalCartCheckout()
        {
            string strCheckOutButton = ConstantElements.CartPage.CheckOutButton;
            SetCurrentElement(nameof(ConstantElements.CartPage.CheckOutButton), ConstantElements.CartPage.CheckOutButton);
            _seleniumService
                .WaitElementExists(By.XPath(strCheckOutButton))
                .SelectElement(By.XPath(strCheckOutButton)).ClickElement();
            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.DarkGreen, true, true, true);

            CheckoutPage();
        }

        private void RedeemShopeVoucher()
        {
            Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton)))
            {
                string strClaimShopeVoucher = ConstantElements.CartPage.ClaimShopVoucherButton;
                _seleniumService.WaitElementClickable(By.XPath(strClaimShopeVoucher));
                _seleniumService.WaitElementVisible(By.XPath(strClaimShopeVoucher));
                SetCurrentElement(nameof(ConstantElements.CartPage.ClaimShopVoucherButton), ConstantElements.CartPage.ClaimShopVoucherButton);
                _seleniumService.SelectElement(By.XPath(strClaimShopeVoucher)).ClickElement();
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Claim shop voucher'.", Color.DarkGreen, true, true, true);
            }
        }

        private void HandleCartCheckout()
        {
            CartPage_SelectAllCheckBox();
            _autoBuyLoggerService.AutoBuyProcessLog("All items selected.", Color.DarkGreen, true, true, true);
            CartPage_ClickCheckoutButton();
            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.DarkGreen, true, true, true);

            if (_seleniumService.ElementExists(By.XPath(ElementXpath.ItemNotSelected)))
            {
                _autoBuyLoggerService.AutoBuyProcessLog("No item available to checkout.", Color.IndianRed, true, true, true);
                return;
            }
            else
            {
                CheckoutPage();
            }
        }

        private void HandleCartCheckoutPriceSpecific(string pageUrl)
        {
            CartPage_SelectAllCheckBox();
            _autoBuyLoggerService.AutoBuyProcessLog("All items selected.", Color.DarkGreen, true, true, true);
            Thread.Sleep(ConfigInfo.delay_step_2);
            (decimal userPrice, decimal cartTotalPrice) priceTuple = CartPage_GetPrice();
            decimal userPrice = priceTuple.userPrice;
            decimal cartTotalPrice = priceTuple.cartTotalPrice;
            _autoBuyLoggerService.AutoBuyProcessLog("User price : " + userPrice, Color.Black, true, true, true);

            if (cartTotalPrice > userPrice || cartTotalPrice == userPrice)
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Cart total price : " + cartTotalPrice, Color.IndianRed, true, true, true);
                RefreshPageAndLoopAutobuy("CartPage", new object[] { _profileService.SelectedProfile.BuyingMode.mode }, pageUrl, true);
            }
            else
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Cart total price : " + cartTotalPrice, Color.DarkGreen, true, true, true);
                CartPage_ClickCheckoutButton();
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.DarkGreen, true, true, true);

                if (_seleniumService.ElementExists(By.XPath(ElementXpath.ItemNotSelected)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("No items available to checkout.", Color.IndianRed, true, true, true);
                    return;
                }
                else
                {
                    CheckoutPage();
                }
            }
        }

        public (decimal userPrice, decimal productPrice) ProductPage_GetPrice()
        {
            string strUserPrice = _profileService.SelectedProfile.BuyingMode.below_specific_price;
            SetCurrentElement(nameof(ConstantElements.ProductPage.CurrentPriceLabel), ConstantElements.ProductPage.CurrentPriceLabel);
            var price = ConstantElements.ProductPage.CurrentPriceLabel;
            string strCurrentPrice = _seleniumService
                //.WaitElementExists(By.XPath(ConstantElements.ProductPage.CurrentPriceLabel))
                .GetElement(By.XPath(price)).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var CurrentPrice = Convert.ToDecimal(strCurrentPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, CurrentPrice);
        }

        private (decimal userPrice, decimal cartTotalPrice) CartPage_GetPrice()
        {
            string strUserPrice = _profileService.SelectedProfile.BuyingMode.cart_below_specific_price;
            SetCurrentElement(nameof(ConstantElements.CartPage.CartTotalPriceLabel), ConstantElements.CartPage.CartTotalPriceLabel);
            string strTotalPrice = _seleniumService
                .WaitElementExists(By.XPath(ConstantElements.CartPage.CartTotalPriceLabel))
                .GetElement(By.XPath(ConstantElements.CartPage.CartTotalPriceLabel)).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var cartTotalPrice = Convert.ToDecimal(strTotalPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, cartTotalPrice);
        }

        private static void SetCurrentElement(string variableName, string elementValue)
        {
            CurrentElementDictionary.Clear();
            CurrentElementDictionary.Add(variableName, elementValue);
        }

        private void CartPage_ClickCheckoutButton()
        {
            SetCurrentElement(nameof(ConstantElements.CartPage.CheckOutButton), ConstantElements.CartPage.CheckOutButton);
            _seleniumService
                .SelectElement(By.XPath(ConstantElements.CartPage.CheckOutButton))
                .ClickElement();
        }

        private void CartPage_SelectAllCheckBox()
        {
            SetCurrentElement(nameof(ConstantElements.CartPage.SelectAllCheckbox), ConstantElements.CartPage.SelectAllCheckbox);
            _seleniumService
                .WaitElementExists(By.XPath(ConstantElements.CartPage.SelectAllCheckbox))
                .SelectElement(By.XPath(ConstantElements.CartPage.SelectAllCheckbox))
                .ClickElement();
        }

        private void ProductPage(string buyMode)
        {
            string pageUrl = _profileService.SelectedProfile.ProductDetail.product_link;

            try
            {
                _seleniumService.WaitUrlContainString(pageUrl);
                _autoBuyLoggerService.AutoBuyProcessLog("Product page loaded.", Color.DarkGreen, true, true, true);

                if (buyMode == BuyingMode.Flash_Shocking)
                {
                    // Check if the product is in Flash/Shocking Sale
                    if (IsProductInFlashSale())
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("Product is in Shocking Sale.", Color.DarkGreen, true, true, true);
                        BuyProduct(buyMode);
                    }
                    else
                    {
                        // Refresh the page since the product is not in Flash Sale
                        _autoBuyLoggerService.AutoBuyProcessLog("Product not in Shocking Sale.", Color.IndianRed, true, true, true);
                        RefreshPageAndLoopAutobuy(GetCurrentMethodName(), new object[] { buyMode }, pageUrl, true);
                    }
                }
                else if (buyMode == BuyingMode.Normal || buyMode == BuyingMode.Below_Price)
                {
                    // Go directly to the buy logic for step 1
                    BuyProduct(buyMode);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(GetCurrentMethodName(), new object[] { buyMode }, ex, pageUrl, false, false);
            }
        }

        private static string GetCurrentMethodName()
        {
            // Get the calling method's stack frame
            StackFrame frame = new StackFrame(1);

            // Get the calling method's method info
            MethodBase method = frame.GetMethod();

            // Get the name of the calling method
            string methodName = method.Name;

            return methodName;
        }

        private bool IsProductInFlashSale()
        {
            string strFlashShockingSaleBanner = ConstantElements.ProductPage.SaleBanner;
            SetCurrentElement(nameof(ConstantElements.ProductPage.SaleBanner), ConstantElements.ProductPage.SaleBanner);
            try
            {
                _seleniumService.WaitElementExists(By.XPath(strFlashShockingSaleBanner));
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool IsProductPriceSuitable()
        {
            var priceTuple = ProductPage_GetPrice();
            decimal userPrice = priceTuple.userPrice;
            decimal productPrice = priceTuple.productPrice;
            if (userPrice < productPrice || userPrice == productPrice)
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Product price : " + productPrice, Color.IndianRed, true, true, true);
            }
            else
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Product price : " + productPrice, Color.DarkGreen, true, true, true);
            }

            // Check if the product price is suitable for purchase
            return productPrice < userPrice;
        }

        private void BuyProduct(string buyMode)
        {
            bool available = IsProductAvailable();
            if (!available)
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Product is not available.", Color.IndianRed, true, true, true);
                RefreshPageAndLoopAutobuy("ProductPage", new object[] { buyMode }, _profileService.SelectedProfile.ProductDetail.product_link, true);
                return;
            }



            var errorMessage = SelectVariant();
            if (errorMessage.Length > 0)
            {
                _autoBuyLoggerService.AutoBuyProcessLog(errorMessage, Color.IndianRed, true, true, true);
                if (errorMessage.Contains("Product only need") || errorMessage.Contains("Product need 2"))
                    return;
                RefreshPageAndLoopAutobuy("ProductPage", new object[] { buyMode }, _profileService.SelectedProfile.ProductDetail.product_link, true);
                return;
            }

            bool unlisted = ProductUnlisted();
            if (unlisted)
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Product unlisted.", Color.IndianRed, true, true, true);
                return;
            }

            if (buyMode == BuyingMode.Below_Price && !IsProductPriceSuitable())
            {
                // Refresh the page since the price hasn't changed yet
                RefreshPageAndLoopAutobuy(GetCurrentMethodName(), new object[] { buyMode }, _profileService.SelectedProfile.ProductDetail.product_link, true);
                return;
            }

            CheckOutStartTime = DateTime.Now;
            _autoBuyLoggerService.AutoBuyProcessLog($"Checkout started at {CheckOutStartTime}", Color.Black, true, true, true);
            IncreaseQuantity();
            ClickBuyNowButton();

            CartPage(buyMode);
        }

        private bool IsProductAvailable()
        {
            string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
            IWebElement BuyNowButton;
            Thread.Sleep(ConfigInfo.delay_step_1);

            try
            {
                _seleniumService.WaitElementExists(By.XPath(strButtonBuyNow));
            }
            catch { }

            BuyNowButton = _seleniumService.GetElement(By.XPath(strButtonBuyNow));

            return _seleniumService.ElementExists(By.XPath(strButtonBuyNow)) && BuyNowButton.GetAttribute("aria-disabled").Equals("false");
        }

        private void ClickBuyNowButton()
        {
            SetCurrentElement(nameof(ConstantElements.ProductPage.BuyNowButton), ConstantElements.ProductPage.BuyNowButton);
            string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
            IWebElement BuyNowButton = _seleniumService.GetElement(By.XPath(strButtonBuyNow));

            _seleniumService.ClickElement(BuyNowButton);
            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Buy Now'.", Color.DarkGreen, true, true, true);
        }

        private bool ProductUnlisted()
        {
            try
            {
                return _seleniumService
                .ElementExists(By.XPath(ConstantElements.ProductPage.UnlistedError));
            }
            catch { return false; }

        }

        private string SelectVariant()
        {
            // if variant container is exists.
            if (_seleniumService.ElementExists(By.XPath(ConstantElements.ProductPage.ProductVariationContainer)))
            {
                // variant pre check, ignore this method
                if (!_profileService.SelectedProfile.ProductDetail.variant_preSelected)
                {
                    // select random variant
                    if (_profileService.SelectedProfile.ProductDetail.random_variant)
                    {
                        // update variant into profile
                        _profileService.SelectedProfile.ProductDetail.variant = "";
                        IReadOnlyCollection<IWebElement> variantElements = _seleniumService._driver.FindElements(By.XPath("//div[contains(@class, 'flex items-center bR6mEk')]"));
                        foreach (IWebElement variantElement in variantElements)
                        {
                            foreach (IWebElement variant in variantElement.FindElements(By.XPath(".//*")))
                            {
                                if (!variant.GetAttribute("class").Equals("product-variation product-variation--disabled"))
                                {
                                    _seleniumService.ClickElement(variant);
                                    _autoBuyLoggerService.AutoBuyProcessLog("Click " + variant.Text + ".", Color.DarkGreen, true, true, true);
                                    _profileService.SelectedProfile.ProductDetail.variant += variant.Text + "|";
                                    break;

                                }
                            }
                        }

                        // delete last '|' in variant string
                        if (_profileService.SelectedProfile.ProductDetail.variant.EndsWith("|"))
                        {
                            _profileService.SelectedProfile.ProductDetail.variant = _profileService.SelectedProfile.ProductDetail.variant.Substring(0, _profileService.SelectedProfile.ProductDetail.variant.Length - 1);
                        }
                    }
                    else
                    {
                        // variant type eg Size, Color
                        var variantElements = _seleniumService._driver.FindElements(By.XPath("//div[contains(@class, 'flex items-center bR6mEk')]"));
                        var variantTypeCount = variantElements.Count;

                        if (_profileService.SelectedProfile.ProductDetail.variant == string.Empty)
                        {
                            return "Specify product variation.";
                        }

                        // split the variation input into an array of variant names
                        string[] variantNames = _profileService.SelectedProfile.ProductDetail.variant.Split('|');

                        if (variantNames.Length != variantTypeCount)
                        {
                            return $"Product needs {variantTypeCount} variant types.";
                        }

                        foreach (string variantName in variantNames)
                        {
                            Thread.Sleep(100);
                            string template = "//button[contains(@class, 'product-variation') and contains(text(), '" + variantName + "')]";

                            if (!_seleniumService.ElementExists(By.XPath(template)) || _seleniumService.ElementExists(By.XPath($"{template}[contains(@class, '--disabled')]")))
                            {
                                return $"'{variantName}' not available.";
                            }

                            var variationElement = _seleniumService.GetElement(By.XPath(template));
                            if (!variationElement.GetAttribute("class").Equals("product-variation product-variation--selected"))
                            {
                                _seleniumService.ClickElement(variationElement);
                                _autoBuyLoggerService.AutoBuyProcessLog("Click " + variationElement.Text + ".", Color.DarkGreen, true, true, true);
                            }
                        }

                        // all variations are available, continue with other logic here
                    }
                }
            }
            return "";
        }

        private void CheckoutPage()
        {
            try
            {
                _seleniumService.WaitUrlContainString("checkout");
                Thread.Sleep(ConfigInfo.delay_step_3);

                // Check if user wants to make changes to the payment method
                if (_profileService.SelectedProfile.PaymentDetail.payment_method != "Default")
                {
                    // Make changes to the payment method
                    ChangePaymentMethod();
                }

                // Place the order
                PlaceOrder();
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(GetCurrentMethodName(), null, ex, "", false, true);
            }
        }

        private void ChangePaymentMethod()
        {
            string strBankType = "";
            if (_profileService.SelectedProfile.PaymentDetail.bank_type != string.Empty)
                strBankType = "//div[contains(@class, 'checkout-bank-transfer-item__title') and contains(text(), '" + _profileService.SelectedProfile.PaymentDetail.bank_type + "')]";
            string strDebitCreditVariation = "//div[contains(@class, '_11C6dM ') and contains(text(), '" + _profileService.SelectedProfile.PaymentDetail.last_4_digit_card + "')]";
            string strCreditDebitOption = "";

            _seleniumService.WaitUrlContainString("checkout");

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.CheckoutPage.ChangePaymentButton)))
            {
                _seleniumService.SelectElement(By.XPath(ConstantElements.CheckoutPage.ChangePaymentButton))
                    .ClickElement();
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Change Payment Method'.", Color.DarkGreen, true, true, true);
            }

            bool exists_5 = true;
            bool exists_4 = true;
            bool exists = true;
            bool Clickable = true;

            switch (_profileService.SelectedProfile.PaymentDetail.payment_method) // kena guna waitelementvisible saja
            {
                case "Credit / Debit Card":
                    strCreditDebitOption = "//button[contains(@class, 'product-variation') and contains(text(), 'Credit / Debit Card')]";
                    _seleniumService.WaitElementVisible(By.XPath(strCreditDebitOption));
                    exists = _seleniumService.ElementExists(By.XPath(strCreditDebitOption));
                    if (!exists)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(strCreditDebitOption)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }

                    if (_seleniumService.GetElement(By.XPath(strCreditDebitOption)).Text.Contains("Credit / Debit Card"))
                    {
                        _seleniumService.ClickElement();
                        if (!_seleniumService.ElementExists(By.XPath(strDebitCreditVariation)))
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog("Credit / Debit variation ending with " + _profileService.SelectedProfile.PaymentDetail.last_4_digit_card + " is not available. Aborting..", Color.IndianRed, true, true, true);
                            return;
                        }
                        _seleniumService.SelectElement(By.XPath(strDebitCreditVariation))
                            .ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Select 'Credit / Debit card (" + _profileService.SelectedProfile.PaymentDetail.last_4_digit_card + ")'.", Color.DarkGreen, true, true, true);
                    }
                    break;

                case "ATM / Cash Deposit":
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit));
                    exists = _seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit));
                    if (!exists)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (_seleniumService.GetElement(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit))
                        .Text.Contains("ATM / Cash Deposit"))
                    {
                        _seleniumService.ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Select 'ATM / Cash Deposit'.", Color.DarkGreen, true, true, true);
                    }
                    break;

                case "Cash on Delivery":
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.Payment.PaymentMethod.CashOnDelivery));
                    exists = _seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentMethod.CashOnDelivery));
                    if (!exists)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentMethod.CashOnDelivery))
                            .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash on Delivery'.", Color.DarkGreen, true, true, true);
                    break;

                case "KK Mart":
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores));
                    if (!_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores))
                            .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash Payment at Convenience Stores'.", Color.DarkGreen, true, true, true);
                    if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("You have exceeded the transaction limit. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentConvenienceStoresType.KKMart))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.payment_method + "'.", Color.DarkGreen, true, true, true);
                    break;

                case "7-Eleven":
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores));
                    exists = _seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores));
                    if (!exists)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores))
                             .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash Payment at Convenience Stores'.", Color.DarkGreen, true, true, true);
                    if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("You have exceeded the transaction limit. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentConvenienceStoresType.SevenEleven))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.payment_method + "'.", Color.DarkGreen, true, true, true);
                    break;

                case "Online Banking":
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.Payment.PaymentMethod.OnlineBanking));
                    if (!_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentMethod.OnlineBanking)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (!_seleniumService.ElementClickable(By.XPath(ConstantElements.Payment.PaymentMethod.OnlineBanking)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }

                    _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentMethod.OnlineBanking))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select 'Online Banking'.", Color.DarkGreen, true, true, true);
                    _seleniumService.SelectElement(By.XPath(strBankType))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.bank_type + "'.", Color.DarkGreen, true, true, true);
                    break;

                case "ShopeePay":
                    Thread.Sleep(ConfigInfo.delay_shopee_pay);
                    exists_5 = _seleniumService.ElementExists(By.XPath(ElementXpath.strShopeePay_5));
                    exists_4 = _seleniumService.ElementExists(By.XPath(ElementXpath.strShopeePay_4));
                    if (!exists_5 && !exists_4)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not available. Aborting..", Color.IndianRed, true, true, true);
                        return;
                    }
                    if (exists_5)
                    {
                        if (!_seleniumService.ElementClickable(By.XPath(ElementXpath.strShopeePay_5)))
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                            return;
                        }
                        _seleniumService.SelectElement(By.XPath(ElementXpath.strShopeePay_5))
                            .ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Select 'ShopeePay'.", Color.DarkGreen, true, true, true);
                    }
                    if (exists_4)
                    {
                        if (!_seleniumService.ElementClickable(By.XPath(ElementXpath.strShopeePay_4)))
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog(_profileService.SelectedProfile.PaymentDetail.payment_method + " not selectable. Aborting..", Color.IndianRed, true, true, true);
                            return;
                        }
                        _seleniumService.SelectElement(By.XPath(ElementXpath.strShopeePay_4))
                             .ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Select 'ShopeePay'.", Color.DarkGreen, true, true, true);
                    }
                    break;
            }

            Thread.Sleep(ConfigInfo.delay_step_3);

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.BankMaintenance)))
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Selected bank currently unavailable due to a scheduled system maintenance. Aborting..", Color.IndianRed, true, true, true);
                return;
            }

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.ActivateShopeePay)))
            {
                _autoBuyLoggerService.AutoBuyProcessLog("ShopeePay not activated. Aborting..", Color.IndianRed, true, true, true);
                return;
            }

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.ShopeePayInsufficientFund)))
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Insufficient ShopeePay balance. Aborting..", Color.IndianRed, true, true, true);
                return;
            }

            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.PayNowMaintenance)))
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Payment channel is disabled for maintenance. Aborting..", Color.IndianRed, true, true, true);
                return;
            }
        }

        private void PlaceOrder()
        {
            _seleniumService.WaitUrlContainString("checkout");
            Thread.Sleep(ConfigInfo.delay_step_5);

            // Redeem coin if desired
            if (_profileService.SelectedProfile.Voucher_Coin.redeem_coin)
            {
                RedeemCoin();
            }

            // Redeem any Shopee voucher
            if (_profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc)
            {
                RedeemShopVoucher();
            }

            Thread.Sleep(ConfigInfo.delay_step_5);

            if (!_profileService.SelectedProfile.BotSettings.test_mode)
            {
                SetCurrentElement(nameof(ConstantElements.CheckoutPage.OrderPrice), ConstantElements.CheckoutPage.OrderPrice);
                _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.OrderPrice));
                OrderPrice = _seleniumService.GetElement(By.XPath(ConstantElements.CheckoutPage.OrderPrice)).Text;

                SetCurrentElement(nameof(ConstantElements.CheckoutPage.PlaceOrderButton), ConstantElements.CheckoutPage.PlaceOrderButton);
                _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                    .SelectElement(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                    .ClickElement();

                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Place Order'.", Color.DarkGreen, true, true, true);

                TotalTimeSpan = JobStartTime - DateTime.Now;
                CheckoutTimeSpan = CheckOutStartTime - DateTime.Now;

                Thread.Sleep(300);

                if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.CartItemOutOfStock)))
                {
                    _seleniumService.SelectElement(By.XPath(ElementXpath.strInformationUpdatedOkButton))
                        .ClickElement()
                        .SelectElement(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                        .ClickElement();

                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Place Order'.", Color.DarkGreen, true, true, true);

                    TotalTimeSpan = JobStartTime - DateTime.Now;
                    CheckoutTimeSpan = CheckOutStartTime - DateTime.Now;
                }

                //if (_profileService.SelectedProfile.BotSettings.play_sound)


                Thread.Sleep(800);

                PostCheckout();
            }
            else
            {
                TotalTimeSpan = JobStartTime - DateTime.Now;
                CheckoutTimeSpan = CheckOutStartTime - DateTime.Now;

                _autoBuyLoggerService.AutoBuyProcessLog("Total time (Test mode) : " + TotalTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);
                _autoBuyLoggerService.AutoBuyProcessLog("Checkout time : " + CheckoutTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);

            }
        }

        private void RedeemShopVoucher()
        {
            string strSelectVoucher = ConstantElements.CheckoutPage.SelectShopeeVoucherButton;
            SetCurrentElement(nameof(ConstantElements.CheckoutPage.SelectShopeeVoucherButton), ConstantElements.CheckoutPage.SelectShopeeVoucherButton);

            _seleniumService.SelectElement(By.XPath(strSelectVoucher))
                .ClickElement();

            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Select Voucher'.", Color.DarkGreen, true, true, true);
            Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);

            _seleniumService.WaitElementClickable(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherContainer));
            _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherContainer));

            string strEnterVoucherCodeOKButton = ConstantElements.CheckoutPage.ShopeeVoucherOkButton;
            _seleniumService.WaitElementExists(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherOkButton))
                .SelectElement(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherOkButton))
                .ClickElement();

            SetCurrentElement(nameof(ConstantElements.CheckoutPage.ShopeeVoucherOkButton), ConstantElements.CheckoutPage.ShopeeVoucherOkButton);
            _seleniumService.SelectElement(By.XPath(strEnterVoucherCodeOKButton))
                .ClickElement();

            Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);
        }

        private void RedeemCoin()
        {
            Thread.Sleep(ConfigInfo.delay_redeem_coin);
            string strRedeemCoin = ConstantElements.CheckoutPage.RedeemCoinCheckbox;

            _seleniumService.WaitElementClickable(By.XPath(strRedeemCoin));
            _seleniumService.WaitElementVisible(By.XPath(strRedeemCoin));

            _seleniumService.SelectElement(By.XPath(strRedeemCoin))
                .ClickElement();

            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Redeem Shopee Coin'.", Color.DarkGreen, true, true, true);
            Thread.Sleep(ConfigInfo.delay_redeem_coin);
        }

        private void PostCheckout()
        {
            try
            {
                // if payment : shopeepay, go to ShopeePayPayment()
                if (_profileService.SelectedProfile.PaymentDetail.payment_method == "ShopeePay")
                {
                    ShopeePayPayment();
                }

                // Check if the URL is still in the checkout page
                if (_seleniumService._driver.Url.Contains("/checkout"))
                {
                    // Retry the checkout process
                    CheckoutPage();
                }
                else
                {
                    _seleniumService.WaitUrlContainString("/payment");
                    if (_seleniumService.UrlContainString("/payment"))
                    {
                        // If the code reaches here, it means the checkout was successful
                        _autoBuyLoggerService.AutoBuyProcessLog("Total time : " + TotalTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);
                        _autoBuyLoggerService.AutoBuyProcessLog("Checkout time : " + CheckoutTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);
                        _notificationService.SendNotification(SAB_Account, _profileService, OrderPrice, CheckoutTimeSpan);

                        // todo : add notifyicon
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(GetCurrentMethodName(), null, ex, "", false, true);
            }
        }

        private void ShopeePayPayment()
        {
            try
            {
                string pageUrl = "https://wallet.airpay.com.my/";
                _seleniumService.WaitUrlContainString(pageUrl);

                if (_seleniumService._driver.Url.Contains(pageUrl))
                {
                    Thread.Sleep(ConfigInfo.delay_shopee_pay);
                    _seleniumService.SelectElement(By.XPath(ElementXpath.strPayButtonID))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Pay'.", Color.DarkGreen, true, true, true);
                    _seleniumService.WaitElementExists(By.XPath(ElementXpath.strShopeePayPin));
                    _seleniumService.WaitElementClickable(By.XPath(ElementXpath.strShopeePayPin));
                    if (_seleniumService.ElementExists(By.XPath(ElementXpath.strShopeePayPin)))
                    {
                        var PinContainer = _seleniumService.GetElement(By.XPath(ElementXpath.strShopeePayPin));
                        Actions actions = new Actions(_seleniumService._driver);
                        actions.MoveToElement(PinContainer).Click().Perform();
                        Thread.Sleep(ConfigInfo.delay_step_6);
                        actions.MoveToElement(PinContainer).SendKeys(_profileService.SelectedProfile.PaymentDetail.shopeepay_pin).Perform();
                        Thread.Sleep(ConfigInfo.delay_step_6);
                        var confirmButton = _seleniumService.GetElement(By.XPath(ElementXpath.strShopeePayCOnfirm));
                        actions.MoveToElement(confirmButton).Click().Perform();
                        Thread.Sleep(250);
                        if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InvalidShopeePayPin)))
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog("Wrong PIN entered. Please key in ShopeePay PIN manually.", Color.IndianRed, true, true, true);
                            return;
                        }
                        _autoBuyLoggerService.AutoBuyProcessLog("Total time : " + TotalTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);
                        _autoBuyLoggerService.AutoBuyProcessLog("Checkout time : " + CheckoutTimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.Black, true, true, true);
                        _notificationService.SendNotification(SAB_Account, _profileService, OrderPrice, CheckoutTimeSpan);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler("PostCheckout", null, ex, "", false, true);
            }
        }
    }
}
