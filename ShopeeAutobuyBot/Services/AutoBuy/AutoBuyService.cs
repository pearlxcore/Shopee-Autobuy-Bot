using DarkUI.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Mp3Player;
using Shopee_Autobuy_Bot.Services.Profile;
using Shopee_Autobuy_Bot.Services.Telegram;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Threading;
using static Shopee_Autobuy_Bot.Constants.AutoBuyInfo;

namespace Shopee_Autobuy_Bot.Services
{
    public class AutoBuyService : IAutoBuyService
    {
        private readonly IProfileService _profileService;
        private readonly IMp3PlayerService _mp3PlayerService;
        private readonly ITelegramService _telegramService;
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;
        private readonly ISeleniumService _seleniumService;
        private readonly DarkButton _startButton;
        public DateTime WorkTime; // Read-only property
        public TimeSpan TimeSpan { get; private set; }
        public TimeSpan CheckoutTimeFinal { get; private set; }

        public bool Aborted => _aborted;

        private readonly bool _aborted = false;

        public AutoBuyService(IAutoBuyLoggerService autoBuyLoggerService, ISeleniumService seleniumService, DarkButton startButton, IProfileService profileService)
        {

            _autoBuyLoggerService = autoBuyLoggerService;
            _seleniumService = seleniumService;
            _startButton = startButton;
            _profileService=profileService;
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

        public void ShopeeAutobuy(int Try, int step, DateTime? workTime = null)
        {
            if (_startButton.Text.Equals("Start") || _startButton.Text.Equals("Stopping..."))
            {
                _startButton.Text = "Stopping...";
                return;
            }

            if (workTime != null)
            {
                WorkTime = workTime.Value;
            }

            //below specific price (cart checkout)
            if (step == 94)
            {
                step94(Try);
            }
            //below specific price
            if (step == 95)
            {
                step95(Try);
            }
            //checkout from cart
            if (step == 96)
            {
                step96(Try);
            }
            //flash sale
            if (step == 0)
            {
                step0(Try);
            }
            // Load product page, select variation if exists, click buy button, load cart page
            if (step == 1)
            {
                step1(Try);
            }
            // in cart page
            if (step == 2)
            {
                step2(Try);
            }
            // in checkout page, select payment method
            if (step == 3)
            {
                step3(Try);
            }
            // in checkout page, select courier
            if (step == 4)
            {
                step4(Try);
            }
            // in checkout page, place order
            if (step == 5)
            {
                step5(Try);
            }
            // optional : in pay order page, click pay now button
            if (step == 6)
            {
                step6(Try);
            }
            if (step == 7)
            {
                step7(Try);
            }
            if (step == 8)
            {
                step8(Try);
            }
        }

        public void AutobuyErrorHandler(int Try, int step, Exception ex, string navigateLink, bool includeInputStringError, bool skipRefreshPage)
        {
            if (_startButton.Text.Equals("Start") || _startButton.Text.Equals("Stopping..."))
            {
                _startButton.Text = "Stopping...";
                return;
            }

            string currentElementKey = "";
            string currentElementValue = "";

            foreach (var kv in CurrentElementDictionary)
            {
                if (kv.Key == "desiredKey")
                {
                    currentElementKey = kv.Key;
                    currentElementValue = kv.Value;
                    break; // Break out of the loop once the desired key is found
                }
            }


            if (includeInputStringError)
            {
                if (ex.Message.Contains("Input string was not in a correct format."))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog($"[S{step}] Input string was not in a correct format. Current element : {currentElementKey} ({currentElementValue})", Color.IndianRed, true, true, true);
                }
            }
            else
            {
                if (ex.Message.Contains("Waiting for element"))
                    _autoBuyLoggerService.AutoBuyProcessLog($"[S{step}] Waiting for element : {currentElementKey}. Current element : {currentElementValue}", Color.IndianRed, true, true, true);
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
            ShopeeAutobuy(Try, step);
        }

        public void RefreshPageAndLoopAutobuy(string navigateLink, int Try, int step, bool loopAutobuy)
        {
            if (_profileService.SelectedProfile.BotSettings.autorefresh_webpage)
            {
                Thread.Sleep(_profileService.SelectedProfile.BotSettings.autorefresh_interval * 1000);
                _seleniumService.GoToUrl(navigateLink);
                if (loopAutobuy)
                    ShopeeAutobuy(Try, step);
            }
            else
                return;
        }

        //below specific price (cart checkout)
        public void step94(int Try)
        {
            string pageUrl = "https://shopee.com.my/cart";
            try
            {
                _seleniumService.WaitForUrlToMatch(pageUrl);
                _autoBuyLoggerService.AutoBuyProcessLog("Cart page loaded.", Color.LawnGreen, true, true, true);
                Thread.Sleep(ConfigInfo.delay_step_94);
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.CartEmptyLabel)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Your shopping cart is empty", Color.IndianRed, true, true, true);
                    return;
                }
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InactiveProducts)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Warning! Some of cart item is inactive.", Color.Yellow, true, true, true);
                }
                _seleniumService.WaitElementExists(By.XPath(ConstantElements.CartPage.SelectAllLabel));
                if (_seleniumService.GetElement(By.XPath(ConstantElements.CartPage.SelectAllLabel)).Text == "Select All (0)")
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("No item available to checkout.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                }
                else
                {
                    // check select all checkbox
                    CartCheckout_SelectAllCheckBox();
                    _autoBuyLoggerService.AutoBuyProcessLog("All item selected.", Color.LawnGreen, true, true, true);
                    Thread.Sleep(ConfigInfo.delay_step_2);
                    (decimal userPrice, decimal cartTotalPrice) priceTuple = CartCheckout_GetPrice();
                    decimal userPrice = priceTuple.userPrice;
                    decimal cartTotalPrice = priceTuple.cartTotalPrice;
                    _autoBuyLoggerService.AutoBuyProcessLog("User price : " + userPrice, Color.White, true, true, true);
                    if (cartTotalPrice > userPrice || cartTotalPrice == userPrice)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("Cart total price : " + cartTotalPrice, Color.IndianRed, true, true, true);
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                    }
                    else
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("Cart total price : " + cartTotalPrice, Color.LawnGreen, true, true, true);
                        CheckoutTime = DateTime.Now;
                        // claim multiple shop voucher
                        CartCheckout_ClaimShopVoucher();
                        // click checkout button
                        CartCheckout_ClickCheckoutButton();
                        _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.LawnGreen, true, true, true);
                        if (_seleniumService.ElementExists(By.XPath(ElementXpath.ItemNotSelected)))
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog("No item available to checkout.", Color.IndianRed, true, true, true);
                            RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                        }
                        else
                            ShopeeAutobuy(Try, 3);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 94, ex, pageUrl, false, false);
            }
        }

        public (decimal userPrice, decimal productPrice) GetPrice()
        {
            string strUserPrice = _profileService.SelectedProfile.BuyingMode.below_specific_price;
            var price = ConstantElements.ProductPage.CurrentPriceLabel;
            string strCurrentPrice = _seleniumService.GetElement(By.XPath(price)).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var CurrentPrice = Convert.ToDecimal(strCurrentPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, CurrentPrice);
        }

        public (decimal userPrice, decimal cartTotalPrice) CartCheckout_GetPrice()
        {
            string strUserPrice = _profileService.SelectedProfile.BuyingMode.cart_below_specific_price;
            string strTotalPrice = _seleniumService.GetElement(By.XPath(ConstantElements.CartPage.CartTotalPriceLabel)).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var cartTotalPrice = Convert.ToDecimal(strTotalPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, cartTotalPrice);
        }

        //below specific price
        public void step95(int Try)
        {
            try
            {
                IWebElement BuyNowButton;
                string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
                string pageUrl = _profileService.SelectedProfile.ProductDetail.product_link;
                _seleniumService.WaitUrlContainString(pageUrl);
                CheckoutTime = DateTime.Now;
                Thread.Sleep(ConfigInfo.delay_step_95);
                _autoBuyLoggerService.AutoBuyProcessLog("Product page loaded.", Color.LawnGreen, true, true, true);
                SetCurrentElement(nameof(ConstantElements.ProductPage.BuyNowButton), ConstantElements.ProductPage.BuyNowButton);

                try
                {
                    _seleniumService.WaitElementExists(By.XPath(strButtonBuyNow));
                }
                catch { }

                BuyNowButton = _seleniumService.GetElement(By.XPath(strButtonBuyNow));

                if (!_seleniumService.ElementExists(By.XPath(strButtonBuyNow)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is not available.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("true"))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is not available.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("false"))
                {
                    var errorMessage = SelectVariant();
                    if (errorMessage.Length > 0)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(errorMessage, Color.IndianRed, true, true, true);
                        if (errorMessage.Contains("Product only need") || errorMessage.Contains("Product need 2"))
                            return;
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                    }
                    else
                    {
                        // get user and product price
                        (decimal userPrice, decimal productPrice) priceTuple = GetPrice();
                        decimal userPrice = priceTuple.userPrice;
                        decimal productPrice = priceTuple.productPrice;
                        _autoBuyLoggerService.AutoBuyProcessLog("User price : " + userPrice, Color.White, true, true, true);

                        // if user price is below that product price then proceed
                        if (productPrice < userPrice)
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog("Current product price : " + productPrice, Color.LawnGreen, true, true, true);
                            IncreaseQuantity();
                            _seleniumService.SelectElement(By.XPath(strButtonBuyNow))
                                .ClickElement();
                            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Buy Now'.", Color.LawnGreen, true, true, true);
                            ShopeeAutobuy(Try, 2);
                        }
                        else if (productPrice > userPrice || productPrice == userPrice)
                        {
                            _autoBuyLoggerService.AutoBuyProcessLog("Current product price : " + productPrice, Color.IndianRed, true, true, true);
                            RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 95, ex, _profileService.SelectedProfile.ProductDetail.product_link, true, false);
            }
        }

        private static void SetCurrentElement(string variableName, string elementValue)
        {
            CurrentElementDictionary.Clear();
            CurrentElementDictionary.Add(variableName, elementValue);
        }

        //checkout from cart
        public void step96(int Try)
        {
            try
            {
                string pageUrl = "https://shopee.com.my/cart";
                _seleniumService.WaitUrlContainString(pageUrl);
                _autoBuyLoggerService.AutoBuyProcessLog("Cart page loaded.", Color.LawnGreen, true, true, true);
                Thread.Sleep(ConfigInfo.delay_step_96);
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.CartEmptyLabel)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Your shopping cart is empty", Color.IndianRed, true, true, true);
                    return;
                }
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InactiveProducts)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Warning! Some of cart item is inactive.", Color.Yellow, true, true, true);
                }
                if (_seleniumService.WaitElementExists(By.XPath(ConstantElements.CartPage.SelectAllLabel))
                        .GetElement(By.XPath(ConstantElements.CartPage.SelectAllLabel)).Text == "Select All (0)")
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("No item available to checkout.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                }
                else
                {
                    CheckoutTime = DateTime.Now;
                    // check select all checkbox
                    CartCheckout_SelectAllCheckBox();
                    _autoBuyLoggerService.AutoBuyProcessLog("Item selected.", Color.LawnGreen, true, true, true);
                    // claim multiple shop voucher
                    CartCheckout_ClaimShopVoucher();
                    // click checkout button
                    CartCheckout_ClickCheckoutButton();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.LawnGreen, true, true, true);

                    if (_seleniumService.ElementExists(By.XPath(ElementXpath.ItemNotSelected)))
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog("No item available to checkout.", Color.IndianRed, true, true, true);
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 96, true);
                    }
                    else
                        ShopeeAutobuy(Try, 3);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 96, ex, "https://shopee.com.my/cart", false, false);
            }
        }

        public void CartCheckout_ClickCheckoutButton()
        {
            SetCurrentElement(nameof(ConstantElements.CartPage.CheckOutButton), ConstantElements.CartPage.CheckOutButton);
            _seleniumService.WaitElementExists(By.XPath(ConstantElements.CartPage.CheckOutButton))
                .SelectElement(By.XPath(ConstantElements.CartPage.CheckOutButton))
                .ClickElement();
        }

        public void CartCheckout_ClaimShopVoucher()
        {
            if (_profileService.SelectedProfile.Voucher_Coin.claim_shop_vc)
            {
                Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);
                if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton)))
                {
                    ReadOnlyCollection<IWebElement> claimVcs;
                    claimVcs = _seleniumService._driver.FindElements(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton));
                    foreach (IWebElement element in claimVcs)
                    {
                        _seleniumService.ClickElement(element);
                    }
                }
            }
        }

        public void CartCheckout_SelectAllCheckBox()
        {
            SetCurrentElement(nameof(ConstantElements.CartPage.SelectAllCheckbox), ConstantElements.CartPage.SelectAllCheckbox);
            _seleniumService.WaitElementExists(By.XPath(ConstantElements.CartPage.SelectAllCheckbox))
                .SelectElement(By.XPath(ConstantElements.CartPage.SelectAllCheckbox))
                .ClickElement();
        }

        //flash sale
        public void step0(int Try)
        {
            string pageUrl = _profileService.SelectedProfile.ProductDetail.product_link;
            try
            {
                _seleniumService.WaitUrlContainString(pageUrl);

                string strFlashShockingSaleBanner = ConstantElements.ProductPage.SaleBanner;
                try
                {
                    _seleniumService.WaitElementExists(By.XPath(strFlashShockingSaleBanner));
                }
                catch { }
                Thread.Sleep(ConfigInfo.delay_step_0);
                if (_seleniumService.ElementExists(By.XPath(strFlashShockingSaleBanner)) == false)
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is not in Flash/Shocking Sale.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 0, true);
                }
                else
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is in Flash/Shocking Sale.", Color.LawnGreen, true, true, true);
                    ShopeeAutobuy(Try, 1);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 0, ex, pageUrl, false, false);
            }
        }

        public void step1(int Try)
        {
            string pageUrl = _profileService.SelectedProfile.ProductDetail.product_link;
            try
            {
                string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
                IWebElement BuyNowButton;
                _seleniumService.WaitUrlContainString(pageUrl);
                CheckoutTime = DateTime.Now;
                Thread.Sleep(ConfigInfo.delay_step_1);
                _autoBuyLoggerService.AutoBuyProcessLog("Product page loaded.", Color.LawnGreen, true, true, true);

                try
                {
                    _seleniumService.WaitElementExists(By.XPath(strButtonBuyNow));
                }
                catch { }

                SetCurrentElement(nameof(ConstantElements.ProductPage.BuyNowButton), ConstantElements.ProductPage.BuyNowButton);
                BuyNowButton = _seleniumService.GetElement(By.XPath(strButtonBuyNow));

                if (!_seleniumService.ElementExists(By.XPath(strButtonBuyNow)))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is not available.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("true"))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Product is not available.", Color.IndianRed, true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("false"))
                {
                    var errorMessage = SelectVariant();
                    if (errorMessage.Length > 0)
                    {
                        _autoBuyLoggerService.AutoBuyProcessLog(errorMessage, Color.IndianRed, true, true, true);
                        if (errorMessage.Contains("Product only need") || errorMessage.Contains("Product need 2"))
                            return;
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                    }
                    else
                    {
                        IncreaseQuantity();
                        _seleniumService.ClickElement(BuyNowButton);
                        _autoBuyLoggerService.AutoBuyProcessLog("Click 'Buy Now'.", Color.LawnGreen, true, true, true);
                        ShopeeAutobuy(Try, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 1, ex, _profileService.SelectedProfile.ProductDetail.product_link, false, false);
            }
        }

        public string SelectVariant()
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
                        IReadOnlyCollection<IWebElement> variantElements = _seleniumService._driver.FindElements(By.XPath("//div[contains(@class, 'flex items-center bR6mEk')]"));
                        foreach (IWebElement variantElement in variantElements)
                        {
                            foreach (IWebElement variant in variantElement.FindElements(By.XPath(".//*")))
                            {
                                if (!variant.GetAttribute("class").Equals("product-variation product-variation--disabled"))
                                {
                                    _seleniumService.ClickElement(variant);
                                    _autoBuyLoggerService.AutoBuyProcessLog("Click " + variant.Text + ".", Color.LawnGreen, true, true, true);
                                    break;
                                }
                            }
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
                                _autoBuyLoggerService.AutoBuyProcessLog("Click " + variationElement.Text + ".", Color.LawnGreen, true, true, true);
                            }
                        }

                        // all variations are available, continue with other logic here
                    }
                }
            }
            return "";
        }

        public void step2(int Try)
        {
            try
            {
                _seleniumService.WaitUrlContainString("cart");
                if (_seleniumService.UrlContainString("https://shopee.com.my/buyer/login"))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Shopee account not logged in.", Color.IndianRed, true, true, true);
                    return;
                }
                else if (_seleniumService.UrlContainString("cart"))
                {
                    _autoBuyLoggerService.AutoBuyProcessLog("Cart page loaded.", Color.LawnGreen, true, true, true);

                    // claim shop voucher
                    if (_profileService.SelectedProfile.Voucher_Coin.claim_shop_vc)
                    {
                        Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);

                        if (_seleniumService.ElementExists(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton)))
                        {
                            string strClaimShopeVoucher = ConstantElements.CartPage.ClaimShopVoucherButton;
                            _seleniumService.WaitElementClickable(By.XPath(strClaimShopeVoucher));
                            _seleniumService.WaitElementVisible(By.XPath(strClaimShopeVoucher));
                            SetCurrentElement(nameof(ConstantElements.CartPage.ClaimShopVoucherButton), ConstantElements.CartPage.ClaimShopVoucherButton);
                            _seleniumService.SelectElement(By.XPath(strClaimShopeVoucher))
                                .ClickElement();
                            _autoBuyLoggerService.AutoBuyProcessLog("Click 'Claim shop voucher'.", Color.LawnGreen, true, true, true);
                        }
                        Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);
                    }

                    Thread.Sleep(ConfigInfo.delay_step_2);
                    string strCheckOutButton = ConstantElements.CartPage.CheckOutButton;
                    SetCurrentElement(nameof(ConstantElements.CartPage.CheckOutButton), ConstantElements.CartPage.CheckOutButton);
                    _seleniumService.SelectElement(By.XPath(strCheckOutButton))
                                .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Check Out'.", Color.LawnGreen, true, true, true);
                    _autoBuyLoggerService.AutoBuyProcessLog("Checkout page loaded.", Color.LawnGreen, true, true, true);

                    if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "Cart")
                        Thread.Sleep(300);

                    if (_profileService.SelectedProfile.PaymentDetail.payment_method != "Default")
                    {
                        ShopeeAutobuy(Try, 3); // to payment
                    }
                    else
                    {
                        ShopeeAutobuy(Try, 5); // skip payment & courier
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 2, ex, "", false, true);
            }
        }

        public void step3(int Try)
        {
            try
            {
                string strBankType = "";
                if (_profileService.SelectedProfile.PaymentDetail.bank_type != string.Empty)
                    strBankType = "//div[contains(@class, 'checkout-bank-transfer-item__title') and contains(text(), '" + _profileService.SelectedProfile.PaymentDetail.bank_type + "')]";
                string strDebitCreditVariation = "//div[contains(@class, '_11C6dM ') and contains(text(), '" + _profileService.SelectedProfile.PaymentDetail.last_4_digit_card + "')]";
                string strCreditDebitOption = "";
                if (_profileService.SelectedProfile.PaymentDetail.payment_method != "Default")
                {
                    _seleniumService.WaitUrlContainString("checkout");
                    if (_seleniumService.ElementExists(By.XPath(ConstantElements.CheckoutPage.ChangePaymentButton)))
                    {
                        _seleniumService.SelectElement(By.XPath(ConstantElements.CheckoutPage.ChangePaymentButton))
                            .ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Click 'Change Payment Method'.", Color.LawnGreen, true, true, true);
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
                                _autoBuyLoggerService.AutoBuyProcessLog("Select 'Credit / Debit card (" + _profileService.SelectedProfile.PaymentDetail.last_4_digit_card + ")'.", Color.LawnGreen, true, true, true);
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
                                _autoBuyLoggerService.AutoBuyProcessLog("Select 'ATM / Cash Deposit'.", Color.LawnGreen, true, true, true);
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
                            _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash on Delivery'.", Color.LawnGreen, true, true, true);
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
                            _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash Payment at Convenience Stores'.", Color.LawnGreen, true, true, true);
                            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                            {
                                _autoBuyLoggerService.AutoBuyProcessLog("You have exceeded the transaction limit. Aborting..", Color.IndianRed, true, true, true);
                                return;
                            }
                            _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentConvenienceStoresType.KKMart))
                                .ClickElement();
                            _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.payment_method + "'.", Color.LawnGreen, true, true, true);
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
                            _autoBuyLoggerService.AutoBuyProcessLog("Select 'Cash Payment at Convenience Stores'.", Color.LawnGreen, true, true, true);
                            if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                            {
                                _autoBuyLoggerService.AutoBuyProcessLog("You have exceeded the transaction limit. Aborting..", Color.IndianRed, true, true, true);
                                return;
                            }
                            _seleniumService.SelectElement(By.XPath(ConstantElements.Payment.PaymentConvenienceStoresType.SevenEleven))
                                .ClickElement();
                            _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.payment_method + "'.", Color.LawnGreen, true, true, true);
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
                            _autoBuyLoggerService.AutoBuyProcessLog("Select 'Online Banking'.", Color.LawnGreen, true, true, true);
                            _seleniumService.SelectElement(By.XPath(strBankType))
                                .ClickElement();
                            _autoBuyLoggerService.AutoBuyProcessLog("Select '" + _profileService.SelectedProfile.PaymentDetail.bank_type + "'.", Color.LawnGreen, true, true, true);
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
                                _autoBuyLoggerService.AutoBuyProcessLog("Select 'ShopeePay'.", Color.LawnGreen, true, true, true);
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
                                _autoBuyLoggerService.AutoBuyProcessLog("Select 'ShopeePay'.", Color.LawnGreen, true, true, true);
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
                    ShopeeAutobuy(Try, 5); // skip courier
                }
                else
                {
                    ShopeeAutobuy(Try, 5); // skip courier
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 3, ex, "", false, true);
            }
        }

        public void step4(int Try)
        {
            try
            {
                // click change button
                Thread.Sleep(ConfigInfo.delay_step_4);
                _seleniumService.SelectElement(By.XPath(ElementXpath.strChangeCourier))
                     .ClickElement();
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Change Courier'.", Color.LawnGreen, true, true, true);

                // click courier type
                Thread.Sleep(ConfigInfo.delay_step_4);
                string strCourierType = "";
                Actions actions = new Actions(_seleniumService._driver);
                strCourierType = "//div[contains(text(), '" + Helper.Shopee.Courier + "')]/../../../../../div[1]";

                _seleniumService
                    .WaitElementExists(By.XPath(ElementXpath.strChangeCourier))
                .SelectElement(By.XPath(ElementXpath.strChangeCourier))
                    .ClickElement();
                _autoBuyLoggerService.AutoBuyProcessLog("Click '" + Helper.Shopee.Courier + "'.", Color.LawnGreen, true, true, true);

                // click deliver anytime
                Thread.Sleep(ConfigInfo.delay_step_4);
                foreach (IWebElement DeliverAnytimeElement in _seleniumService._driver.FindElements(By.XPath(ElementXpath.strDeliverAnytime)))
                {
                    _seleniumService.WaitElementExists(By.XPath(ElementXpath.strDeliverAnytime));
                    if (DeliverAnytimeElement.Displayed)
                    {
                        actions.MoveToElement(DeliverAnytimeElement).Click().Perform();
                        _seleniumService.ClickElement(DeliverAnytimeElement);
                    }
                }
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Deliver any time'.", Color.LawnGreen, true, true, true);

                // click submit button
                _seleniumService.SelectElement(By.XPath(ElementXpath.strSubmitCourier))
                    .ClickElement();
                _autoBuyLoggerService.AutoBuyProcessLog("Click 'Submit'.", Color.LawnGreen, true, true, true);
                ShopeeAutobuy(Try, 5);
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 4, ex, "", false, true);
            }
        }

        public void step5(int Try)
        {
            try
            {
                _seleniumService.WaitUrlContainString("checkout");
                Thread.Sleep(ConfigInfo.delay_step_5);
                // redeem coin
                if (_profileService.SelectedProfile.Voucher_Coin.redeem_coin)
                {
                    Thread.Sleep(ConfigInfo.delay_redeem_coin);
                    string strRedeemCoin = ConstantElements.CheckoutPage.RedeemCoinCheckbox;
                    _seleniumService.WaitElementClickable(By.XPath(strRedeemCoin));
                    _seleniumService.WaitElementVisible(By.XPath(strRedeemCoin));
                    // original
                    _seleniumService.SelectElement(By.XPath(strRedeemCoin))
                        .ClickElement();
                    // alternate
                    //IWebElement checkBox = driver.FindElement(By.XPath(strRedeemCoin));
                    //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                    //jse.ExecuteScript("arguments[0].click();", checkBox);
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Redeem Shopee Coin'.", Color.LawnGreen, true, true, true);
                    Thread.Sleep(ConfigInfo.delay_redeem_coin);
                }
                // redeem any shopee voucher
                if (_profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc)
                {
                    string strSelectVoucher = ConstantElements.CheckoutPage.SelectShopeeVoucherButton;
                    SetCurrentElement(nameof(ConstantElements.CheckoutPage.SelectShopeeVoucherButton), ConstantElements.CheckoutPage.SelectShopeeVoucherButton);
                    _seleniumService.SelectElement(By.XPath(strSelectVoucher))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Select Voucher'.", Color.LawnGreen, true, true, true);
                    Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);
                    _seleniumService.WaitElementClickable(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherContainer));
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherContainer));
                    string strEnterVoucherCodeOKButton = ConstantElements.CheckoutPage.ShopeeVoucherOkButton;
                    _seleniumService
                        .WaitElementExists(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherOkButton))
                        .SelectElement(By.XPath(ConstantElements.CheckoutPage.ShopeeVoucherOkButton))
                        .ClickElement();
                    SetCurrentElement(nameof(ConstantElements.CheckoutPage.ShopeeVoucherOkButton), ConstantElements.CheckoutPage.ShopeeVoucherOkButton);
                    _seleniumService.SelectElement(By.XPath(strEnterVoucherCodeOKButton))
                        .ClickElement();
                    Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);
                }
                Thread.Sleep(ConfigInfo.delay_step_5);
                if (!_profileService.SelectedProfile.BotSettings.test_mode)
                {
                    SetCurrentElement(nameof(ConstantElements.CheckoutPage.OrderPrice), ConstantElements.CheckoutPage.OrderPrice);
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.OrderPrice));
                    Helper.Shopee.OrderPrice = _seleniumService.GetElement(By.XPath(ConstantElements.CheckoutPage.OrderPrice)).Text;
                    SetCurrentElement(nameof(ConstantElements.CheckoutPage.PlaceOrderButton), ConstantElements.CheckoutPage.PlaceOrderButton);
                    _seleniumService.WaitElementVisible(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                        .SelectElement(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Place Order'.", Color.LawnGreen, true, true, true);
                    TimeSpan = WorkTime - DateTime.Now;
                    CheckoutTimeFinal = CheckoutTime - DateTime.Now;
                    Thread.Sleep(300);

                    if (_seleniumService.ElementExists(By.XPath(ConstantElements.Payment.PaymentErrorMessage.CartItemOutOfStock)))
                    {
                        _seleniumService.SelectElement(By.XPath(ElementXpath.strInformationUpdatedOkButton))
                        .ClickElement()
                            .SelectElement(By.XPath(ConstantElements.CheckoutPage.PlaceOrderButton))
                            .ClickElement();
                        _autoBuyLoggerService.AutoBuyProcessLog("Click 'Place Order'.", Color.LawnGreen, true, true, true);
                        TimeSpan = WorkTime - DateTime.Now;
                        CheckoutTimeFinal = CheckoutTime - DateTime.Now;
                    }
                    if (_profileService.SelectedProfile.BotSettings.play_sound)
                        _mp3PlayerService.PlaySound();
                    Thread.Sleep(800);
                    if (_profileService.SelectedProfile.PaymentDetail.payment_method == "ShopeePay")
                        ShopeeAutobuy(Try, 6);
                    else
                        ShopeeAutobuy(Try, 8);
                }
                else
                {
                    TimeSpan = WorkTime - DateTime.Now;
                    _autoBuyLoggerService.AutoBuyProcessLog("Finish test mode in " + TimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.White, true, true, true);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 5, ex, "", false, true);
            }
        }

        public void step6(int Try)
        {
            try
            {
                string pageUrl = "https://wallet.airpay.com.my/";
                _seleniumService.WaitUrlContainString(pageUrl);
                ShopeeAutobuy(Try, 7);
                if (_seleniumService._driver.Url.Contains(pageUrl))
                {
                    Thread.Sleep(ConfigInfo.delay_shopee_pay);
                    _seleniumService.SelectElement(By.XPath(ElementXpath.strPayButtonID))
                        .ClickElement();
                    _autoBuyLoggerService.AutoBuyProcessLog("Click 'Pay'.", Color.LawnGreen, true, true, true);
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
                        _autoBuyLoggerService.AutoBuyProcessLog("Checkout time : " + CheckoutTimeFinal.ToString("hh\\:mm\\:ss\\:ff"), Color.LawnGreen, true, true, true);
                        _autoBuyLoggerService.AutoBuyProcessLog("Total time : " + TimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.LawnGreen, true, true, true);
                        _telegramService.SendNotification(_profileService.SelectedProfile.ScheduleBot.schedule,
                            _profileService.SelectedProfile.BuyingMode.ToString(),
                            Helper.Shopee.OrderPrice,
                            _profileService.SelectedProfile.ProductDetail.product_link);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandler(Try, 3, ex, "", false, true);
            }
        }

        public void step7(int Try)
        {
            if (_seleniumService._driver.Url.Contains("/checkout"))
            {
                TimeSpan = new TimeSpan(0, 0, 0);
                ShopeeAutobuy(Try, 5);
            }
        }

        public void step8(int Try)
        {
            string pageUrl = "https://wallet.airpay.com.my/";
            if (_seleniumService._driver.Url.Contains(pageUrl))
                ShopeeAutobuy(Try, 6);
            try
            {
                _seleniumService.WaitUrlContainString("payment");
            }
            catch
            {
                ShopeeAutobuy(Try, 7);
            }
            _autoBuyLoggerService.AutoBuyProcessLog("Checkout time : " + CheckoutTimeFinal.ToString("hh\\:mm\\:ss\\:ff"), Color.LawnGreen, true, true, true);
            _autoBuyLoggerService.AutoBuyProcessLog("Total time : " + TimeSpan.ToString("hh\\:mm\\:ss\\:ff"), Color.LawnGreen, true, true, true);
            _telegramService.SendNotification(_profileService.SelectedProfile.ScheduleBot.schedule,
                            _profileService.SelectedProfile.BuyingMode.ToString(),
                            Helper.Shopee.OrderPrice,
                            _profileService.SelectedProfile.ProductDetail.product_link);
        }

        public void StartAutoBuy()
        {
            WorkTime = DateTime.Now;
            if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Flash_Shocking) //shocking sale
            {
                _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                ShopeeAutobuy(0, 0);
            }
            else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price) //price specific
            {
                _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                ShopeeAutobuy(0, 95);
            }
            else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Cart) //checkout form cart
            {
                _seleniumService.GoToUrl("https://shopee.com.my/cart");

                ShopeeAutobuy(0, 96);
            }
            else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Normal) //normal
            {
                _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                ShopeeAutobuy(0, 1);
            }
            else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart) // price specific CART CHECKOUT
            {
                _seleniumService.GoToUrl("https://shopee.com.my/cart");

                ShopeeAutobuy(0, 94);
            }
        }
    }
}
