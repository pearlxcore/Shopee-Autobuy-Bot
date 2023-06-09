﻿using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Extensions;
using Shopee_Autobuy_Bot.Models;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Utililties.Helper;
using static Shopee_Autobuy_Bot.Utililties.Helper.Shopee;
using static Shopee_Autobuy_Bot.Utililties.SettingsHelper.Element;
using static Shopee_Autobuy_Bot.Utililties.SettingsHelper.Profile;

namespace Shopee_Autobuy_Bot
{
    public partial class Main : DarkUI.Forms.DarkForm
    {
        private DelayModel ConfigInfo = new DelayModel();
        private UserModel UserInfo = new UserModel();
        private ChromeDriverHelper ChromedriverHelper = new ChromeDriverHelper();
        private string userId { get; set; }



        private static string strShopeePay_5 = "//*[@id=\"main\"]/div/div[3]/div[2]/div[5]/div[1]/div/div[1]/div[2]/span[1]/button";
        private static string strShopeePay_4 = "//*[@id=\"main\"]/div/div[3]/div[2]/div[4]/div[1]/div/div[1]/div[2]/span[1]/button";



        private static string strInformationUpdatedOkButton = "//span[contains(@class, 'stardust-popup-button stardust-popup-button--main') and contains(text(), 'OK')]";

        private static string strChangeCourier = "//div[contains(@class, '_26DEZ8') and contains(text(), 'change')]";
        private static string strDeliverAnytime = "//div[contains(text(), 'Deliver any time')]";
        private static string strSubmitCourier = "//button[contains(text(), 'submit')]";
        private static string strPayButtonID = "//*[@id=\"pay-button\"]";
        private static string strShopeePayPin = "//div[contains(@class, 'digit-input active')]";
        private static string strShopeePayCOnfirm = "//div[contains(@class, 'okText') and contains(text(), 'CONFIRM')]";
        private static string str7ElevenOk = "//button[contains(@class, '_2W0k_h _2yXzsi') and contains(text(), 'OK')]";
        private static string strPayCcardButton = "//button[contains(@class, '_2W0k_h _2yXzsi') and contains(text(), 'Pay')]";

        private static string ItemNotSelected = "//div[contains(@class, 'shopee-alert-popup__message') and contains(text(), 'You have not selected any items for checkout')]";

        private static Mutex mutex = null;
        public bool DoneSetupQuickBuyMode = false;

        private string currentElement;

        public Main(ChromeDriverHelper chromeDriverHelper)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            darkComboBoxPaymentMethod.SelectedIndexChanged -= darkComboBoxPaymentMethod_SelectedIndexChanged;
            //userId = userid;
            ChromedriverHelper = chromeDriverHelper;
        }

        private void Logger(
        string text,
        Color? color = null,
        bool NewLine = true,
        bool Production = true,
        bool WithDateTime = true, bool isLogging = true)
        {
            if (isLogging == true)
            {
                if (richTextBoxLogs.InvokeRequired)
                {
                    Invoke((Delegate)new SetTextCallbackl(Logger), text, color, NewLine, Production, WithDateTime, isLogging);
                }
                else
                {
                    if (WithDateTime)
                        richTextBoxLogs.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] ", Color.LightBlue, false);
                    richTextBoxLogs.AppendText(text, color ?? Color.White, NewLine);
                }
            }
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
        }

        private void darkButton4_Click(object sender, EventArgs e)
        {
        }

        private void darkButton3_Click(object sender, EventArgs e)
        {
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
        }

        private void darkButtonStart_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                if (darkButtonStart.Text.Equals("Start"))
                {
                    timerlabel1.Text = "00:00:00:00";

                    if (radioButtonBuyNormal.Checked && darkTextBoxProductLink.Text == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (radioButtonShockingSale.Checked && darkTextBoxProductLink.Text == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (radioButtonPriceSpecific.Checked && darkTextBoxProductLink.Text == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (radioButtonPriceSpecific.Checked == true && tbPriceSpecific.Text == string.Empty)
                    {
                        MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true && tbBelowSpecificPriceCARTCHECKOUTPrice.Text == string.Empty)
                    {
                        MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //if (darkComboBoxCourier.Text == string.Empty)
                    //{
                    //    MessageBox.Show("Select courier type.", "Error");
                    //    return;
                    //}
                    if (darkComboBoxPaymentMethod.Text == string.Empty)
                    {
                        MessageBox.Show("Select payment type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (darkComboBoxPaymentMethod.Text == "Online Banking" && darkComboBoxBankType.Text == string.Empty)
                    {
                        MessageBox.Show("Select bank type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (darkComboBoxPaymentMethod.Text == "ShopeePay" && darkTextBoxShopeePayPin.Text == string.Empty)
                    {
                        MessageBox.Show("Specify ShopeePay pin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (darkComboBoxPaymentMethod.Text == "Credit / Debit Card" && tbLast4Digit.Text == string.Empty)
                    {
                        MessageBox.Show("Specify last 4 digit of debit/credit card to be used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if ((!radioButtonCheckOutCart.Checked && !radioButtonPriceSpecificCARTCHECKOUT.Checked)
                    && !darkTextBoxProductLink.Text.Contains("https://shopee.com.my/"))
                    {
                        MessageBox.Show("Link not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (darkCheckBoxScheduleBot.Checked)
                    {
                        if (darkCheckBoxTomorrow.Checked == true)
                        {
                            //currentday = 12.00am - date.now
                            //total = current + tomolo
                            FlashSale = DateTime.Today.AddDays(1) + new TimeSpan(Convert.ToInt32(darkNumericUpDownCountdownHour.Value), Convert.ToInt32(darkNumericUpDownCountdownMinutes.Value), Convert.ToInt32(darkNumericUpDownCountDownSecond.Value));
                            //MessageBox.Show(FlashSale.ToString());
                        }
                        else
                        {
                            FlashSale = DateTime.Today;
                            FlashSale = FlashSale.Date + new TimeSpan(Convert.ToInt32(darkNumericUpDownCountdownHour.Value), Convert.ToInt32(darkNumericUpDownCountdownMinutes.Value), Convert.ToInt32(darkNumericUpDownCountDownSecond.Value));
                            if (FlashSale < DateTime.Now)
                            {
                                MessageBox.Show("Time is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        FlashSale = DateTime.Now/*.AddSeconds(Convert.ToDouble(darkNumericUpDownRefreshSeconds.Value))*/;
                    }

                    darkButtonDeleteAllOrder.Enabled = false;
                    darkSectionPanelProductDetails.Enabled = false;
                    darkSectionPanelTimerMode.Enabled = false;
                    darkSectionPanelBuyingMode.Enabled = false;
                    darkSectionPanelPaymentDetails.Enabled = false;
                    Aborted = false;
                    richTextBoxLogs.Text = string.Empty;
                    TimeOut = Convert.ToInt32(darkNumericUpDownTimeOut.Value);
                    try
                    {
                        if (radioButtonCheckOutCart.Checked == true || radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                        {
                            ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/cart");
                        }
                        else
                            ChromedriverHelper.driver.Navigate().GoToUrl(darkTextBoxProductLink.Text);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("window was already closed"))
                        {
                            MessageBox.Show("Main Chrome browser windows was closed. Please restart the program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    int result = 0;
                    string str1 = "";
                    string str2 = "";
                    ShopeePayPin = darkTextBoxShopeePayPin.Text.Trim();
                    string[] lines = darkTextBoxProductLink.Lines;
                    Courier = "";
                    Courier = darkComboBoxCourier.Text.Trim();

                    PaymentMethod = "";
                    PaymentMethod = darkComboBoxPaymentMethod.Text;
                    if (darkComboBoxPaymentMethod.Text == "Online Banking")
                        BankType = darkComboBoxBankType.Text;
                    else
                        BankType = "";

                    Status = "Fail";
                    foreach (string str3 in lines)
                    {
                        if (!str3.Trim().Equals(""))
                        {
                            str1 = str1 + ((IEnumerable<string>)str3.Split('|')).First<string>() + "|";
                            if (str3.Split('|').Length > 1)
                                str2 = str2 + ((IEnumerable<string>)str3.Split('|')).Last<string>() + "|";
                            else
                                str2 = str2 + result.ToString() + "|";
                        }
                    }
                    ProductLink = str1.TrimEnd('|').Split('|');

                    Logger("Autobuy starts at : " + FlashSale.ToString(), new Color?(), true, true, true);
                    darkButtonStart.Text = "Stop";
                    StartButtonString = darkButtonStart.Text;
                    VariationString = darkTextBoxVariationString.Text.Replace('|', ',');
                    startWorkThreadAsync();
                }
                else
                {
                    Aborted = true;

                    darkButtonStart.Text = "Stopping...";
                    StartButtonString = darkButtonStart.Text;
                    darkButtonStart.Enabled = false;
                    darkButtonDeleteAllOrder.Enabled = false;
                    darkSectionPanelProductDetails.Enabled = false;
                    darkSectionPanelTimerMode.Enabled = false;
                    darkSectionPanelPaymentDetails.Enabled = false;
                }
            }).Start();
        }

        private void startWorkThread()
        {
            try
            {
                countdownTimer();
            }
            catch (Exception ex)
            {
                Thread.Sleep(10000);
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startWorkThreadAsync()
        {
            try
            {
                new Thread(new ThreadStart(startWorkThread))
                {
                    IsBackground = true
                }.Start();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void countdownTimer()
        {
            if (darkCheckBoxScheduleBot.Checked == true)
            {
                Logger("Countdown started..", new Color?(), true, true, true);
            }
            seconds = FlashSale - DateTime.Now;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 100.0;
            timer.Elapsed += (ElapsedEventHandler)((obj, args) =>
            {
                if (seconds.TotalSeconds < 0.0)
                {
                    timer.Stop();
                    workTime = DateTime.Now;
                    StartButtonString = darkButtonStart.Text;
                    if (radioButtonShockingSale.Checked == true) //shocking sale
                    {
                        ChromedriverHelper.driver.Navigate().GoToUrl(darkTextBoxProductLink.Text);
                        ShopeeAutobuy(0, 0);
                    }
                    else if (radioButtonPriceSpecific.Checked == true) //price specific
                    {
                        ChromedriverHelper.driver.Navigate().GoToUrl(darkTextBoxProductLink.Text);
                        ShopeeAutobuy(0, 95);
                    }
                    else if (radioButtonCheckOutCart.Checked == true) //checkout form cart
                    {
                        ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/cart");

                        ShopeeAutobuy(0, 96);
                    }
                    else if (radioButtonBuyNormal.Checked == true) //normal
                    {
                        ChromedriverHelper.driver.Navigate().GoToUrl(darkTextBoxProductLink.Text);
                        ShopeeAutobuy(0, 1);
                    }
                    else if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true) // price specific CART CHECKOUT
                    {
                        ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/cart");

                        ShopeeAutobuy(0, 94);
                    }
                    darkButtonStart.Text = "Start";
                    darkButtonStart.Enabled = true;
                    darkButtonDeleteAllOrder.Enabled = true;

                    //old (delete)
                    //if (Authentication.subscription == "lite")
                    //{
                    //    darkSectionPanelTimerMode.Enabled = false;
                    //    darkSectionPanelBotSettings.Enabled = false;
                    //    darkSectionPanelBuyingMode.Enabled = false;
                    //    darkSectionPanelProductDetails.Enabled = true;
                    //    darkSectionPanelPaymentDetails.Enabled = true;

                    //}
                    //else
                    //{
                    //    darkSectionPanelBotSettings.Enabled = true;
                    //    darkSectionPanelBuyingMode.Enabled = true;
                    //    darkSectionPanelProductDetails.Enabled = true;
                    //    darkSectionPanelTimerMode.Enabled = true;
                    //    darkSectionPanelPaymentDetails.Enabled = true;

                    //    if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                    //        darkSectionPanelProductDetails.Enabled = false;

                    //    if (radioButtonCheckOutCart.Checked == true)
                    //        darkSectionPanelProductDetails.Enabled = false;

                    //}

                    darkSectionPanelBotSettings.Enabled = true;
                    darkSectionPanelBuyingMode.Enabled = true;
                    darkSectionPanelProductDetails.Enabled = true;
                    darkSectionPanelTimerMode.Enabled = true;
                    darkSectionPanelPaymentDetails.Enabled = true;

                    if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                        darkSectionPanelProductDetails.Enabled = false;
                    if (radioButtonCheckOutCart.Checked == true)
                        darkSectionPanelProductDetails.Enabled = false;

                    timerlabel1.Text = timeSpan.ToString("dd\\:hh\\:mm\\:ss");
                    if (Aborted == true)
                        Logger("Job aborted.", new Color?(Color.IndianRed), true, true, true);

                    ExportLog();
                }
                else
                    Invoke(new Action(() =>
                    {
                        if (darkButtonStart.Text.Equals("Stopping..."))
                        {
                            timer.Stop();
                            darkButtonStart.Text = "Start";
                            darkButtonStart.Enabled = true;
                            darkButtonDeleteAllOrder.Enabled = true;

                            //old (delete)
                            //if (Authentication.subscription == "lite")
                            //{
                            //    darkSectionPanelTimerMode.Enabled = false;
                            //    darkSectionPanelBotSettings.Enabled = false;
                            //    darkSectionPanelBuyingMode.Enabled = false;
                            //    darkSectionPanelProductDetails.Enabled = true;
                            //    darkSectionPanelPaymentDetails.Enabled = true;

                            //}
                            //else
                            //{
                            //    darkSectionPanelBotSettings.Enabled = true;
                            //    darkSectionPanelBuyingMode.Enabled = true;
                            //    darkSectionPanelProductDetails.Enabled = true;
                            //    darkSectionPanelTimerMode.Enabled = true;
                            //    darkSectionPanelPaymentDetails.Enabled = true;

                            //    if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                            //        darkSectionPanelProductDetails.Enabled = false;
                            //    if (radioButtonCheckOutCart.Checked == true)
                            //        darkSectionPanelProductDetails.Enabled = false;

                            //}

                            darkSectionPanelBotSettings.Enabled = true;
                            darkSectionPanelBuyingMode.Enabled = true;
                            darkSectionPanelProductDetails.Enabled = true;
                            darkSectionPanelTimerMode.Enabled = true;
                            darkSectionPanelPaymentDetails.Enabled = true;

                            if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                                darkSectionPanelProductDetails.Enabled = false;
                            if (radioButtonCheckOutCart.Checked == true)
                                darkSectionPanelProductDetails.Enabled = false;

                            timerlabel1.Text = "00:00:00:00";
                        }
                        else
                        {
                            TimeSpan timeSpan1 = FlashSale - DateTime.Now;
                            double result;
                            double.TryParse(CountdownMicroseconds, out result);
                            TimeSpan timeSpan2 = timeSpan1.Add(TimeSpan.FromMilliseconds(result));
                            seconds = timeSpan2;
                            timerlabel1.Text = timeSpan2.ToString("dd\\:hh\\:mm\\:ss");

                            //if (timeSpan2.Days > 0)
                            //    timerlabel1.Text = timeSpan2.ToString("dd\\:hh\\:mm\\:ss");
                            //else
                            //    timerlabel1.Text = timeSpan2.ToString("hh\\:mm\\:ss");
                        }
                    }));
            });
            timer.Start();
        }

        private void ExportLog()
        {
            if (!Directory.Exists(DirectoryPaths.LogDirectory))
                Directory.CreateDirectory(DirectoryPaths.LogDirectory);

            bool testmode;
            string testMode = "Test mode : " + (testmode = (darkCheckBoxTestMode.Checked) ? true : false).ToString() + "\n";

            string belowPrice = "";
            var checkedButton = darkSectionPanelBuyingMode.Controls.OfType<RadioButton>()
                              .FirstOrDefault(r => r.Checked);

            string productLink = "";
            productLink = "Product link : " + darkTextBoxProductLink.Text + "\n";

            if (checkedButton.Name == "radioButtonPriceSpecific")
                belowPrice = " (RM" + tbPriceSpecific.Text + ")";
            if (checkedButton.Name == "radioButtonPriceSpecificCARTCHECKOUT")
                belowPrice = " (RM" + tbBelowSpecificPriceCARTCHECKOUTPrice.Text + ")";

            string buyingMode = "";
            if (radioButtonPriceSpecific.Checked == true || radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
                buyingMode = "Buying Mode : " + checkedButton.Text.Replace(" :", "") + belowPrice + "\n\n";
            else
                buyingMode = "Buying Mode : " + checkedButton.Text.Replace(" :", "") + "\n\n";

            string quantity = "";
            quantity = "Quantity : " + darkNumericUpDownProductQuantity.Value + "\n";

            string paymentdetail = "";
            paymentdetail = "Payment type : " + darkComboBoxPaymentMethod.Text + "\n";

            string detail = "";
            if (checkedButton.Name == "radioButtonCheckOutCart" || checkedButton.Name == "radioButtonPriceSpecificCARTCHECKOUT")
                detail = testMode + quantity + paymentdetail + buyingMode;
            else
                detail = testMode + productLink + quantity + paymentdetail + buyingMode;

            Helper.SaveToLog.Append(detail);

            Helper.SaveToLog.Append(richTextBoxLogs.Text);

            string output = DirectoryPaths.LogDirectory + "\\" + FlashSale.ToString("yyyy-dd-M--HH-mm-ss") + ".txt";
            File.AppendAllText(output, Helper.SaveToLog.ToString());
            Helper.SaveToLog.Clear();
        }

        private void ToTelegram()
        {
            try
            {
                string timerMode = darkCheckBoxScheduleBot.Checked ? "Countdown mode" : "Normal";
                string buyingMode = "";
                if (radioButtonBuyNormal.Checked)
                {
                    buyingMode = "Normal mode";
                }
                else if (radioButtonCheckOutCart.Checked)
                {
                    buyingMode = "Cart checkout";
                }
                else if (radioButtonPriceSpecific.Checked)
                {
                    buyingMode = "Below specific price";
                }
                else if (radioButtonShockingSale.Checked)
                {
                    buyingMode = "Shocking/Flash sale";
                }
                else if (radioButtonPriceSpecificCARTCHECKOUT.Checked)
                {
                    buyingMode = "Below specific price (Cart Checkout)";
                }

                string text = "*User*: " + UserInfo.name + " " + Helper.OrderPrice +
                    "\n*Product link*: " + darkTextBoxProductLink.Text +
                    "\n*IP*: " + GetIP() + "&parse_mode=Markdown";
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "1914520458:AAGKuro58sqowR4fawgcn9XuE4o9cC0jyvg";
                string chatId = "@SAB_pxc";
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                string response = sb.ToString();
            }
            catch { }
        }

        private void IncreaseQuantity()
        {
            string strQuantity = darkNumericUpDownProductQuantity.Value.ToString();

            //alternative method
            if (strQuantity != "1")
            {
                currentElement = ConstantElements.ProductPage.QuantityCheckbox;
                string QuantitiyTextBox = ConstantElements.ProductPage.QuantityCheckbox;
                try { WaitElementExists(QuantitiyTextBox); } catch { }
                try { WaitElementVisible(QuantitiyTextBox); } catch { }
                try { WaitElementClickable(QuantitiyTextBox); } catch { }
                var QuantityTextBox_ = NewElementByXpath(QuantitiyTextBox);
                QuantityTextBox_.Clear();
                QuantityTextBox_.SendKeys(strQuantity);
            }
        }

        private void ShopeeAutobuy(int Try = 0, int step = 1, bool isLogging = true)
        {
            if (StartButtonString.Equals("Start") || StartButtonString.Equals("Stopping..."))
            {
                darkButtonStart.Text = "Stopping...";
                return;
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

        private void AutobuyErrorHandle(int Try, int step, Exception ex, string navigateLink, bool includeInputStringError, bool skipRefreshPage)
        {
            if (StartButtonString.Equals("Start") || StartButtonString.Equals("Stopping..."))
            {
                darkButtonStart.Text = "Stopping...";
                return;
            }

            if (includeInputStringError)
            {
                if (ex.Message.Contains("Input string was not in a correct format."))
                {
                    Logger($"[S{step}] Input string was not in a correct format...", new Color?(Color.IndianRed), true, true, true);
                }
            }
            else
            {
                if (ex.Message.Contains("Waiting for element"))
                    Logger($"[S{step}] Waiting for element : " + currentElement, new Color?(Color.IndianRed), true, true, true);
                else
                    Logger(ex.Message, new Color?(Color.IndianRed), true, true, true);
            }

            if (!skipRefreshPage)
            {
                if (darkCheckBoxRefresh.Checked == true)
                {
                    Thread.Sleep(Convert.ToInt32(darkNumericUpDownRefreshSeconds.Value) * 1000);
                    ChromedriverHelper.driver.Navigate().GoToUrl(navigateLink);
                }
                else
                    return;
            }
            ShopeeAutobuy(Try, step);
        }

        private void RefreshPageAndLoopAutobuy(string navigateLink, int Try, int step, bool loopAutobuy)
        {
            if (darkCheckBoxRefresh.Checked == true)
            {
                Thread.Sleep(Convert.ToInt32(darkNumericUpDownRefreshSeconds.Value) * 1000);
                ChromedriverHelper.driver.Navigate().GoToUrl(navigateLink);
                if (loopAutobuy)
                    ShopeeAutobuy(Try, step);
            }
            else
                return;
        }

        //below specific price (cart checkout)
        private void step94(int Try)
        {
            string pageUrl = "https://shopee.com.my/cart";
            //try
            //{
            WaitUrlContain(pageUrl);
            Logger("Cart page loaded.", new Color?(Color.LawnGreen), true, true, true);
            Thread.Sleep(ConfigInfo.delay_step_94);
            if (IsElementPresent(By.XPath(ConstantElements.CartPage.CartEmptyLabel)) == true)
            {
                Logger("Your shopping cart is empty", new Color?(Color.IndianRed), true, true, true);
                return;
            }
            if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InactiveProducts)) == true)
            {
                Logger("Warning! Some of cart item is inactive.", new Color?(Color.Yellow), true, true, true);
            }
            WaitElementExists(ConstantElements.CartPage.SelectAllLabel);
            if (NewElementByXpath(ConstantElements.CartPage.SelectAllLabel).Text == "Select All (0)")
            {
                Logger("No item available to checkout.", new Color?(Color.IndianRed), true, true, true);
                RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
            }
            else
            {
                // check select all checkbox
                CartCheckout_SelectAllCheckBox();
                Logger("All item selected.", new Color?(Color.LawnGreen), true, true, true);
                Thread.Sleep(ConfigInfo.delay_step_2);
                (decimal userPrice, decimal cartTotalPrice) priceTuple = CartCheckout_GetPrice();
                decimal userPrice = priceTuple.userPrice;
                decimal cartTotalPrice = priceTuple.cartTotalPrice;
                Logger("User price : " + userPrice, new Color?(Color.White), true, true, true);
                if (cartTotalPrice > userPrice || cartTotalPrice == userPrice)
                {
                    Logger("Cart total price : " + cartTotalPrice, new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                }
                else
                {
                    Logger("Cart total price : " + cartTotalPrice, new Color?(Color.LawnGreen), true, true, true);
                    CheckoutTime = DateTime.Now;
                    // claim multiple shop voucher
                    CartCheckout_ClaimShopVoucher();
                    // click checkout button
                    CartCheckout_ClickCheckoutButton();
                    Logger("Click 'Check Out'.", new Color?(Color.LawnGreen), true, true, true);
                    if (IsElementPresent(By.XPath(ItemNotSelected)) == true)
                    {
                        Logger("No item available to checkout.", new Color?(Color.IndianRed), true, true, true);
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                    }
                    else
                        ShopeeAutobuy(Try, 3);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    AutobuyErrorHandle(Try, 94, ex, pageUrl, false, false);
            //}
        }

        private (decimal userPrice, decimal productPrice) GetPrice()
        {
            string strUserPrice = tbPriceSpecific.Text;
            var price = ConstantElements.ProductPage.CurrentPriceLabel;
            string strCurrentPrice = NewElementByXpath(price).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var CurrentPrice = Convert.ToDecimal(strCurrentPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, CurrentPrice);
        }

        private (decimal userPrice, decimal cartTotalPrice) CartCheckout_GetPrice()
        {
            string strUserPrice = tbBelowSpecificPriceCARTCHECKOUTPrice.Text;
            string strTotalPrice = NewElementByXpath(ConstantElements.CartPage.CartTotalPriceLabel).Text.Replace(",", "").Replace("RM", "").Replace("$", "");
            var cartTotalPrice = Convert.ToDecimal(strTotalPrice);
            var UserPrice = Convert.ToDecimal(strUserPrice);
            return (UserPrice, cartTotalPrice);
        }

        //below specific price
        private void step95(int Try)
        {
            try
            {
                string pageUrl = darkTextBoxProductLink.Text;
                WaitUrlContain(pageUrl);
                CheckoutTime = DateTime.Now;
                Thread.Sleep(ConfigInfo.delay_step_95);
                Logger("Product page loaded.", new Color?(Color.LawnGreen), true, true, true);
                string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
                currentElement = strButtonBuyNow;
                IWebElement BuyNowButton;

                try
                {
                    WaitElementExists(strButtonBuyNow);
                }
                catch { }

                BuyNowButton = NewElementByXpath(strButtonBuyNow);

                if (!IsElementPresent(By.XPath(strButtonBuyNow)))
                {
                    Logger("Product is not available.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("true"))
                {
                    Logger("Product is not available.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("false"))
                {
                    var errorMessage = SelectVariant();
                    if (errorMessage.Length> 0)
                    {
                        Logger(errorMessage, new Color?(Color.IndianRed), true, true, true);
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
                        Logger("User price : " + userPrice, new Color?(Color.White), true, true, true);

                        // if user price is below that product price then proceed
                        if (productPrice < userPrice)
                        {
                            Logger("Current product price : " + productPrice, new Color?(Color.LawnGreen), true, true, true);
                            IncreaseQuantity();
                            ClickElement(BuyNowButton);
                            Logger("Click 'Buy Now'.", new Color?(Color.LawnGreen), true, true, true);
                            ShopeeAutobuy(Try, 2);
                        }
                        else if (productPrice > userPrice || productPrice == userPrice)
                        {
                            Logger("Current product price : " + productPrice, new Color?(Color.IndianRed), true, true, true);
                            RefreshPageAndLoopAutobuy(pageUrl, Try, 95, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 95, ex, darkTextBoxProductLink.Text, true, false);
            }
        }

        //checkout from cart
        private void step96(int Try)
        {
            try
            {
                string pageUrl = "https://shopee.com.my/cart";
                WaitUrlContain(pageUrl);
                Logger("Cart page loaded.", new Color?(Color.LawnGreen), true, true, true);
                Thread.Sleep(ConfigInfo.delay_step_96);
                if (IsElementPresent(By.XPath(ConstantElements.CartPage.CartEmptyLabel)) == true)
                {
                    Logger("Your shopping cart is empty", new Color?(Color.IndianRed), true, true, true);
                    return;
                }
                if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InactiveProducts)) == true)
                {
                    Logger("Warning! Some of cart item is inactive.", new Color?(Color.Yellow), true, true, true);
                }
                WaitElementExists(ConstantElements.CartPage.SelectAllLabel);
                if (NewElementByXpath(ConstantElements.CartPage.SelectAllLabel).Text == "Select All (0)")
                {
                    Logger("No item available to checkout.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 94, true);
                }
                else
                {
                    CheckoutTime = DateTime.Now;
                    // check select all checkbox
                    CartCheckout_SelectAllCheckBox();
                    Logger("Item selected.", new Color?(Color.LawnGreen), true, true, true);
                    // claim multiple shop voucher
                    CartCheckout_ClaimShopVoucher();
                    // click checkout button
                    CartCheckout_ClickCheckoutButton();
                    Logger("Click 'Check Out'.", new Color?(Color.LawnGreen), true, true, true);

                    if (IsElementPresent(By.XPath(ItemNotSelected)) == true)
                    {
                        Logger("No item available to checkout.", new Color?(Color.IndianRed), true, true, true);
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 96, true);
                    }
                    else
                        ShopeeAutobuy(Try, 3);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 96, ex, "https://shopee.com.my/cart", false, false);
            }
        }

        private void CartCheckout_ClickCheckoutButton()
        {
            string strCheckOutButton = ConstantElements.CartPage.CheckOutButton;
            currentElement = strCheckOutButton;
            var CheckOutButton = NewElementByXpath(strCheckOutButton);
            ClickElement(CheckOutButton);
        }

        private void CartCheckout_ClaimShopVoucher()
        {
            if (darkCheckBoxClaimShopVoucher.Checked == true)
            {
                Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);
                if (IsElementPresent(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton)))
                {
                    ReadOnlyCollection<IWebElement> claimVcs;
                    claimVcs = ChromedriverHelper.driver.FindElements(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton));
                    int num = 0;
                    foreach (IWebElement element in claimVcs)
                    {
                        ClickElement(element);
                    }
                }
            }
        }

        private void CartCheckout_SelectAllCheckBox()
        {
            string CartCheckBoxAllItem = ConstantElements.CartPage.SelectAllCheckbox;
            currentElement = CartCheckBoxAllItem;
            WaitElementExists(CartCheckBoxAllItem);
            var CheckBoxSelectItem = NewElementByXpath(CartCheckBoxAllItem);
            ClickElement(CheckBoxSelectItem);
        }

        //flash sale
        private void step0(int Try)
        {
            string pageUrl = darkTextBoxProductLink.Text;
            try
            {
                WaitUrlContain(pageUrl);

                string strFlashShockingSaleBanner = ConstantElements.ProductPage.SaleBanner;
                try
                {
                    WaitElementExists(strFlashShockingSaleBanner);
                }
                catch { }
                Thread.Sleep(ConfigInfo.delay_step_0);
                if (IsElementPresent(By.XPath(strFlashShockingSaleBanner)) == false)
                {
                    Logger("Product is not in Flash/Shocking Sale.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 0, true);
                }
                else
                {
                    Logger("Product is in Flash/Shocking Sale.", new Color?(Color.LawnGreen), true, true, true);
                    ShopeeAutobuy(Try, 1);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 0, ex, pageUrl, false, false);
            }
        }

        private void step1(int Try)
        {
            string pageUrl = darkTextBoxProductLink.Text;
            try
            {
                WaitUrlContain(pageUrl);
                CheckoutTime = DateTime.Now;
                Thread.Sleep(ConfigInfo.delay_step_1);
                Logger("Product page loaded.", new Color?(Color.LawnGreen), true, true, true);

                string strButtonBuyNow = ConstantElements.ProductPage.BuyNowButton;
                IWebElement BuyNowButton;
                try
                {
                    WaitElementExists(strButtonBuyNow);
                }
                catch { }

                currentElement = strButtonBuyNow;
                BuyNowButton = NewElementByXpath(strButtonBuyNow);

                if (!IsElementPresent(By.XPath(strButtonBuyNow)))
                {
                    Logger("Product is not available.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("true"))
                {
                    Logger("Product is not available.", new Color?(Color.IndianRed), true, true, true);
                    RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                }
                else if (BuyNowButton.GetAttribute("aria-disabled").Equals("false"))
                {
                    var errorMessage = SelectVariant();
                    if (errorMessage.Length> 0)
                    {
                        Logger(errorMessage, new Color?(Color.IndianRed), true, true, true);
                        if (errorMessage.Contains("Product only need") || errorMessage.Contains("Product need 2"))
                            return;
                        RefreshPageAndLoopAutobuy(pageUrl, Try, 1, true);
                    }
                    else
                    {
                        IncreaseQuantity();
                        ClickElement(BuyNowButton);
                        Logger("Click 'Buy Now'.", new Color?(Color.LawnGreen), true, true, true);
                        ShopeeAutobuy(Try, 2);
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 1, ex, darkTextBoxProductLink.Text, false, false);
            }
        }

        private string SelectVariant()
        {
            // if variant container is exists.
            if (IsElementPresent(By.XPath(ConstantElements.ProductPage.ProductVariationContainer)))
            {
                // select random variant
                if (cbRandom.Checked)
                {
                    IReadOnlyCollection<IWebElement> variantElements = ChromedriverHelper.driver.FindElements(By.XPath("//div[contains(@class, 'flex items-center bR6mEk')]"));
                    foreach (IWebElement variantElement in variantElements)
                    {
                        foreach (IWebElement variant in variantElement.FindElements(By.XPath(".//*")))
                        {
                            if (!variant.GetAttribute("class").Equals("product-variation product-variation--disabled"))
                            {
                                ClickElement(variant);
                                Logger("Click " + variant.Text + ".", new Color?(Color.LawnGreen), true, true, true);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // variant type eg Size, Color
                    var variantElements = ChromedriverHelper.driver.FindElements(By.XPath("//div[contains(@class, 'flex items-center bR6mEk')]"));
                    var variantTypeCount = variantElements.Count;

                    if (darkTextBoxVariationString.Text == string.Empty)
                    {
                        return "Specify product variation.";
                    }

                    // split the variation input into an array of variant names
                    string[] variantNames = darkTextBoxVariationString.Text.Split('|');

                    if (variantNames.Length != variantTypeCount)
                    {
                        return $"Product needs {variantTypeCount} variant types.";
                    }

                    foreach (string variantName in variantNames)
                    {
                        Thread.Sleep(100);
                        string template = "//button[contains(@class, 'product-variation') and contains(text(), '" + variantName + "')]";

                        if (!IsElementPresent(By.XPath(template)) || IsElementPresent(By.XPath($"{template}[contains(@class, '--disabled')]")))
                        {
                            return $"'{variantName}' not available.";
                        }

                        IWebElement variationElement = ChromedriverHelper.driver.FindElement(By.XPath(template));
                        if (!variationElement.GetAttribute("class").Equals("product-variation product-variation--selected"))
                        {
                            ClickElement(variationElement);
                            Logger("Click " + variationElement.Text + ".", new Color?(Color.LawnGreen), true, true, true);
                        }
                    }
                    // all variations are available, continue with other logic here
                }
            }
            return "";
        }

        private void step2(int Try)
        {
            try
            {
                WaitUrlContain("/cart");
                if (ChromedriverHelper.driver.Url.Contains("/cart"))
                {
                    Logger("Cart page loaded.", new Color?(Color.LawnGreen), true, true, true);

                    // claim shop voucher
                    if (darkCheckBoxClaimShopVoucher.Checked == true)
                    {
                        Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);

                        if (IsElementPresent(By.XPath(ConstantElements.CartPage.ClaimShopVoucherButton)))
                        {
                            string strClaimShopeVoucher = ConstantElements.CartPage.ClaimShopVoucherButton;
                            WaitElementClickable(strClaimShopeVoucher);
                            WaitElementVisible(strClaimShopeVoucher);
                            currentElement = strClaimShopeVoucher;
                            var ClaimShopeVoucher = NewElementByXpath(strClaimShopeVoucher);
                            ClickElement(ClaimShopeVoucher);
                            Logger("Click 'Claim shop voucher'.", new Color?(Color.LawnGreen), true, true, true);
                        }
                        Thread.Sleep(ConfigInfo.delay_claim_shop_voucher);
                    }
                    Thread.Sleep(ConfigInfo.delay_step_2);
                    string strCheckOutButton = ConstantElements.CartPage.CheckOutButton;
                    currentElement = strCheckOutButton;
                    var CheckOutButton = NewElementByXpath(strCheckOutButton);
                    ClickElement(CheckOutButton);
                    Logger("Click 'Check Out'.", new Color?(Color.LawnGreen), true, true, true);
                    Logger("Checkout page loaded.", new Color?(Color.LawnGreen), true, true, true);

                    if (radioButtonCheckOutCart.Checked == true)
                        Thread.Sleep(300);

                    if (PaymentMethod != "Default")
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
                AutobuyErrorHandle(Try, 2, ex, "", false, true);
            }
        }

        private void step3(int Try)
        {
            try
            {
                string strBankType = "";
                if (BankType != string.Empty)
                    strBankType = "//div[contains(@class, 'checkout-bank-transfer-item__title') and contains(text(), '" + BankType + "')]";
                string strDebitCreditVariation = "//div[contains(@class, '_11C6dM ') and contains(text(), '" + tbLast4Digit.Text + "')]";
                string strCreditDebitOption = "";
                if (PaymentMethod != "Default")
                {
                    WaitUrlContain("checkout");
                    if (IsElementPresent(By.XPath(ConstantElements.CheckoutPage.ChangePaymentButton)))
                    {
                        WaitElementExists(ConstantElements.CheckoutPage.ChangePaymentButton);
                        var ChangePaymentMethodDiv = NewElementByXpath(ConstantElements.CheckoutPage.ChangePaymentButton);
                        ClickElement(ChangePaymentMethodDiv);
                        Logger("Click 'Change Payment Method'.", new Color?(Color.LawnGreen), true, true, true);
                    }
                    bool exists_5 = true;
                    bool exists_4 = true;
                    bool exists = true;
                    bool Clickable = true;
                    switch (PaymentMethod) // kena guna waitelementvisible saja
                    {
                        case "Credit / Debit Card":
                            strCreditDebitOption = "//button[contains(@class, 'product-variation') and contains(text(), 'Credit / Debit Card')]";
                            WaitElementVisible(strCreditDebitOption);
                            exists = IsElementPresent(By.XPath(strCreditDebitOption));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(strCreditDebitOption);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var CreditDebitButton = NewElementByXpath(strCreditDebitOption);
                            if (CreditDebitButton.Text.Contains("Credit / Debit Card"))
                            {
                                ClickElement(CreditDebitButton);
                                exists = IsElementPresent(By.XPath(strDebitCreditVariation));
                                if (!exists)
                                {
                                    Logger("Credit / Debit variation ending with " + tbLast4Digit.Text + " is not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                    return;
                                }
                                var DebitCreditVariation = NewElementByXpath(strDebitCreditVariation);
                                ClickElement(DebitCreditVariation);
                                Logger("Select 'Credit / Debit card (" + tbLast4Digit.Text + ")'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "ATM / Cash Deposit":
                            WaitElementVisible(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit);
                            exists = IsElementPresent(By.XPath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var CashDepoButton = NewElementByXpath(ConstantElements.Payment.PaymentMethod.ATM_CashDeposit);
                            if (CashDepoButton.Text.Contains("ATM / Cash Deposit"))
                            {
                                ClickElement(CashDepoButton);
                                Logger("Select 'ATM / Cash Deposit'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "Cash on Delivery":
                            WaitElementVisible(ConstantElements.Payment.PaymentMethod.CashOnDelivery);
                            exists = IsElementPresent(By.XPath(ConstantElements.Payment.PaymentMethod.CashOnDelivery));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(ConstantElements.Payment.PaymentMethod.CashOnDelivery);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var CODButton = NewElementByXpath(ConstantElements.Payment.PaymentMethod.CashOnDelivery);
                            if (CODButton.Text.Contains("Cash on Delivery"))
                            {
                                ClickElement(CODButton);
                                Logger("Select 'Cash on Delivery'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "KK Mart":
                            WaitElementVisible(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            exists = IsElementPresent(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var RetailStoreButton = NewElementByXpath(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            if (RetailStoreButton.Text.Contains("Cash Payment at Convenience Stores"))
                            {
                                ClickElement(RetailStoreButton);
                                Logger("Select 'Cash Payment at Convenience Stores'.", new Color?(Color.LawnGreen), true, true, true);
                                if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                                {
                                    Logger("You have exceeded the transaction limit. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                    return;
                                }
                                WaitElementVisible(ConstantElements.Payment.PaymentConvenienceStoresType.KKMart);
                                WaitElementClickable(ConstantElements.Payment.PaymentConvenienceStoresType.KKMart);
                                var KkMartButton = NewElementByXpath(ConstantElements.Payment.PaymentConvenienceStoresType.KKMart);
                                ClickElement(KkMartButton);
                                Logger("Select '" + darkComboBoxPaymentMethod.Text + "'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "7-Eleven":
                            WaitElementVisible(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            exists = IsElementPresent(By.XPath(ConstantElements.Payment.PaymentMethod.ConvenienceStores));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var RetailStoreButton_ = NewElementByXpath(ConstantElements.Payment.PaymentMethod.ConvenienceStores);
                            if (RetailStoreButton_.Text.Contains("Cash Payment at Convenience Stores"))
                            {
                                ClickElement(RetailStoreButton_);
                                Logger("Select 'Cash Payment at Convenience Stores'.", new Color?(Color.LawnGreen), true, true, true);
                                if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.TransactionExceeded)))
                                {
                                    Logger("You have exceeded the transaction limit. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                    return;
                                }
                                WaitElementVisible(ConstantElements.Payment.PaymentConvenienceStoresType.SevenEleven);
                                WaitElementClickable(ConstantElements.Payment.PaymentConvenienceStoresType.SevenEleven);
                                var SevenElevenButton = NewElementByXpath(ConstantElements.Payment.PaymentConvenienceStoresType.SevenEleven);
                                ClickElement(SevenElevenButton);
                                Logger("Select '" + darkComboBoxPaymentMethod.Text + "'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "Online Banking":
                            WaitElementVisible(ConstantElements.Payment.PaymentMethod.OnlineBanking);
                            exists = IsElementPresent(By.XPath(ConstantElements.Payment.PaymentMethod.OnlineBanking));
                            if (!exists)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            Clickable = isClickable(ConstantElements.Payment.PaymentMethod.OnlineBanking);
                            if (!Clickable)
                            {
                                Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            var OnlinebankingButton = NewElementByXpath(ConstantElements.Payment.PaymentMethod.OnlineBanking);
                            if (OnlinebankingButton.Text.Contains("Online Banking"))
                            {
                                ClickElement(OnlinebankingButton);
                                Logger("Select 'Online Banking'.", new Color?(Color.LawnGreen), true, true, true);
                                WaitElementVisible(strBankType);
                                WaitElementClickable(strBankType);
                                var BankTypebutton = NewElementByXpath(strBankType);
                                ClickElement(BankTypebutton);
                                Logger("Select '" + BankType + "'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                        case "ShopeePay":
                            Thread.Sleep(ConfigInfo.delay_shopee_pay);
                            exists_5 = IsElementPresent(By.XPath(strShopeePay_5));
                            exists_4 = IsElementPresent(By.XPath(strShopeePay_4));
                            if (!exists_5 && !exists_4)
                            {
                                Logger(PaymentMethod + " not available. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                return;
                            }
                            if (exists_5 == true)
                            {
                                Clickable = isClickable(strShopeePay_5);
                                if (!Clickable)
                                {
                                    Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                    return;
                                }
                                var ShopeePayButton = NewElementByXpath(strShopeePay_5);
                                ClickElement(ShopeePayButton);
                                Logger("Select 'ShopeePay'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            if (exists_4 == true)
                            {
                                Clickable = isClickable(strShopeePay_4);
                                if (!Clickable)
                                {
                                    Logger(PaymentMethod + " not selectable. Aborting..", new Color?(Color.IndianRed), true, true, true);
                                    return;
                                }
                                var ShopeePayButton = NewElementByXpath(strShopeePay_4);
                                ClickElement(ShopeePayButton);
                                Logger("Select 'ShopeePay'.", new Color?(Color.LawnGreen), true, true, true);
                            }
                            break;
                    }
                    Thread.Sleep(ConfigInfo.delay_step_3);
                    if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.BankMaintenance)))
                    {
                        Logger("Selected bank currently unavailable due to a scheduled system maintenance. Aborting..", new Color?(Color.IndianRed), true, true, true);
                        return;
                    }
                    if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.ActivateShopeePay)))
                    {
                        Logger("ShopeePay not activated. Aborting..", new Color?(Color.IndianRed), true, true, true);
                        return;
                    }
                    if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.ShopeePayInsufficientFund)))
                    {
                        Logger("Insufficient ShopeePay balance. Aborting..", new Color?(Color.IndianRed), true, true, true);
                        return;
                    }
                    if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.PayNowMaintenance)))
                    {
                        Logger("Payment channel is disabled for maintenance. Aborting..", new Color?(Color.IndianRed), true, true, true);
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
                AutobuyErrorHandle(Try, 3, ex, "", false, true);
            }
        }

        private void step4(int Try)
        {
            try
            {
                // click change button
                Thread.Sleep(ConfigInfo.delay_step_4);
                WaitElementExists(strChangeCourier);
                var ChangeCourierButton = NewElementByXpath(strChangeCourier);
                ClickElement(ChangeCourierButton);
                Logger("Click 'Change Courier'.", new Color?(Color.LawnGreen), true, true, true);

                // click courier type
                Thread.Sleep(ConfigInfo.delay_step_4);
                string strCourierType = "";
                Actions actions = new Actions(ChromedriverHelper.driver);
                strCourierType = "//div[contains(text(), '" + Courier + "')]/../../../../../div[1]";
                WaitElementExists(strCourierType);
                var CourierTypeButton = NewElementByXpath(strCourierType);
                ClickElement(CourierTypeButton);
                Logger("Click '" + Courier + "'.", new Color?(Color.LawnGreen), true, true, true);

                // click deliver anytime
                Thread.Sleep(ConfigInfo.delay_step_4);
                foreach (IWebElement DeliverAnytimeElement in ChromedriverHelper.driver.FindElements(By.XPath(strDeliverAnytime)))
                {
                    WaitElementExists(strDeliverAnytime);
                    if (DeliverAnytimeElement.Displayed)
                    {
                        actions.MoveToElement(DeliverAnytimeElement).Click().Perform();
                        ClickElement(DeliverAnytimeElement);
                    }
                }
                Logger("Click 'Deliver any time'.", new Color?(Color.LawnGreen), true, true, true);

                // click submit button
                var SubmitButton = NewElementByXpath(strSubmitCourier);
                ClickElement(SubmitButton);
                Logger("Click 'Submit'.", new Color?(Color.LawnGreen), true, true, true);
                ShopeeAutobuy(Try, 5);
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 4, ex, "", false, true);
            }
        }

        private void step5(int Try)
        {
            try
            {
                WaitUrlContain("checkout");
                Thread.Sleep(ConfigInfo.delay_step_5);
                // redeem coin
                if (darkCheckBoxRedeemCoin.Checked == true)
                {
                    Thread.Sleep(ConfigInfo.delay_redeem_coin);
                    string strRedeemCoin = ConstantElements.CheckoutPage.RedeemCoinCheckbox;
                    currentElement = strRedeemCoin;
                    WaitElementClickable(strRedeemCoin);
                    WaitElementVisible(strRedeemCoin);
                    // original
                    var RedeemCoinCheckBox = NewElementByXpath(strRedeemCoin);
                    ClickElement(RedeemCoinCheckBox);
                    // alternate
                    //IWebElement checkBox = driver.FindElement(By.XPath(strRedeemCoin));
                    //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                    //jse.ExecuteScript("arguments[0].click();", checkBox);
                    Logger("Click 'Redeem Shopee Coin'.", new Color?(Color.LawnGreen), true, true, true);
                    Thread.Sleep(ConfigInfo.delay_redeem_coin);
                }
                // redeem any shopee voucher
                if (darkCheckBoxRedeemShopeeVoucher.Checked == true)
                {
                    string strSelectVoucher = ConstantElements.CheckoutPage.SelectShopeeVoucherButton;
                    currentElement = strSelectVoucher;
                    var EnterVoucherCode = NewElementByXpath(strSelectVoucher);
                    ClickElement(EnterVoucherCode);
                    Logger("Click 'Select Voucher'.", new Color?(Color.LawnGreen), true, true, true);
                    Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);
                    WaitElementClickable(ConstantElements.CheckoutPage.ShopeeVoucherContainer);
                    WaitElementVisible(ConstantElements.CheckoutPage.ShopeeVoucherContainer);
                    string strEnterVoucherCodeOKButton = ConstantElements.CheckoutPage.ShopeeVoucherOkButton;
                    WaitElementClickable(strEnterVoucherCodeOKButton);
                    WaitElementVisible(strEnterVoucherCodeOKButton);
                    currentElement = strEnterVoucherCodeOKButton;
                    var EnterVoucherCodeOkButton = NewElementByXpath(strEnterVoucherCodeOKButton);
                    ClickElement(EnterVoucherCodeOkButton);
                    Thread.Sleep(ConfigInfo.delay_any_shopee_voucher);
                }
                Thread.Sleep(ConfigInfo.delay_step_5);
                if (darkCheckBoxTestMode.Checked != true)
                {
                    currentElement = ConstantElements.CheckoutPage.OrderPrice;
                    WaitElementVisible(ConstantElements.CheckoutPage.OrderPrice);
                    Helper.OrderPrice = NewElementByXpath(ConstantElements.CheckoutPage.OrderPrice).Text;
                    string strPlaceOrder = ConstantElements.CheckoutPage.PlaceOrderButton;
                    currentElement = strPlaceOrder;
                    WaitElementVisible(strPlaceOrder);
                    var PlaceOrderButton = NewElementByXpath(strPlaceOrder);
                    ClickElement(PlaceOrderButton);
                    Logger("Click 'Place Order'.", new Color?(Color.LawnGreen), true, true, true);
                    timeSpan = workTime - DateTime.Now;
                    CheckoutTimeFinal = CheckoutTime - DateTime.Now;
                    Thread.Sleep(300);
                    if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.CartItemOutOfStock)))
                    {
                        var strInformationUpdatedOkButton_ = NewElementByXpath(strInformationUpdatedOkButton);
                        ClickElement(strInformationUpdatedOkButton_);
                        ClickElement(PlaceOrderButton);
                        Logger("Click 'Place Order'.", new Color?(Color.LawnGreen), true, true, true);
                        timeSpan = workTime - DateTime.Now;
                        CheckoutTimeFinal = CheckoutTime - DateTime.Now;
                    }
                    if (darkCheckBoxPlaySound.Checked == true)
                        Cashing();
                    Thread.Sleep(800);
                    if (PaymentMethod == "ShopeePay")
                        ShopeeAutobuy(Try, 6);
                    else
                        ShopeeAutobuy(Try, 8);
                }
                else
                {
                    timeSpan = workTime - DateTime.Now;
                    Logger("Finish test mode in " + timeSpan.ToString("hh\\:mm\\:ss\\:ff"), new Color?(Color.White), true, true, true);
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 5, ex, "", false, true);
            }
        }

        private void step6(int Try)
        {
            try
            {
                string pageUrl = "https://wallet.airpay.com.my/";
                WaitUrlContain(pageUrl);
                ShopeeAutobuy(Try, 7);
                if (ChromedriverHelper.driver.Url.Contains(pageUrl))
                {
                    Thread.Sleep(ConfigInfo.delay_shopee_pay);
                    var ButtonPay = NewElementByXpath(strPayButtonID);
                    ButtonPay.Click();
                    ClickElement(ButtonPay);
                    Logger("Click 'Pay'.", new Color?(Color.LawnGreen), true, true, true);
                    WaitElementExists(strShopeePayPin);
                    WaitElementClickable(strShopeePayPin);
                    if (IsElementPresent(By.XPath(strShopeePayPin)))
                    {
                        var PinContainer = NewElementByXpath(strShopeePayPin);
                        Actions actions = new Actions(ChromedriverHelper.driver);
                        actions.MoveToElement(PinContainer).Click().Perform();
                        Thread.Sleep(ConfigInfo.delay_step_6);
                        actions.MoveToElement(PinContainer).SendKeys(darkTextBoxShopeePayPin.Text).Perform();
                        Thread.Sleep(ConfigInfo.delay_step_6);
                        var confirmButton = NewElementByXpath(strShopeePayCOnfirm);
                        actions.MoveToElement(confirmButton).Click().Perform();
                        Thread.Sleep(250);
                        if (IsElementPresent(By.XPath(ConstantElements.Payment.PaymentErrorMessage.InvalidShopeePayPin)))
                        {
                            Logger("Wrong PIN entered. Please key in ShopeePay PIN manually.", new Color?(Color.IndianRed), true, true, true);
                            return;
                        }
                        Logger("Checkout time : " + CheckoutTimeFinal.ToString("hh\\:mm\\:ss\\:ff"), new Color?(), true, true, true);
                        Logger("Total time : " + timeSpan.ToString("hh\\:mm\\:ss\\:ff"), new Color?(), true, true, true);
                        ToTelegram();
                    }
                }
            }
            catch (Exception ex)
            {
                AutobuyErrorHandle(Try, 3, ex, "", false, true);
            }
        }

        private void step7(int Try)
        {
            if (ChromedriverHelper.driver.Url.Contains("/checkout"))
            {
                timeSpan = new TimeSpan(0, 0, 0);
                ShopeeAutobuy(Try, 5);
            }
        }

        private void step8(int Try)
        {
            string pageUrl = "https://wallet.airpay.com.my/";
            if (ChromedriverHelper.driver.Url.Contains(pageUrl))
                ShopeeAutobuy(Try, 6);
            try
            {
                WaitUrlContain("/payment");
            }
            catch
            {
                ShopeeAutobuy(Try, 7);
            }
            Logger("Checkout time : " + CheckoutTimeFinal.ToString("hh\\:mm\\:ss\\:ff"), new Color?(), true, true, true);
            Logger("Total time : " + timeSpan.ToString("hh\\:mm\\:ss\\:ff"), new Color?(), true, true, true);
            ToTelegram();
            //if (IsElementPresent(By.XPath(str7ElevenLabel)))
            //{
            //    var PlaceOrderButton = NewElementByXpath(str7ElevenOk);
            //    ClickElement(PlaceOrderButton);
            //}
            //if (IsElementPresent(By.XPath(strPayCcardLabel)))
            //{
            //    var PayCcButton = NewElementByXpath(strPayCcardButton);
            //    ClickElement(PayCcButton);
            //}
        }

        private string GetIP()
        {
            IPAddress externalIp = null;
            try
            {
                string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
                externalIp = IPAddress.Parse(externalIpString);
            }
            catch { }
            return externalIp.ToString();
        }

        private void Cashing()
        {
            Mp3Player.WaveOut.Play();
            Mp3Player.WaveOut.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, EventArgs e/*, WaveOut wave, Mp3FileReader mpefilereader*/)
        {
            Mp3Player.Mp3FileReader.Position = 0;
        }

        private bool isClickable(string xpath)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(ChromedriverHelper.driver, new TimeSpan(0, 0, TimeOut));
                webDriverWait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void WaitUrlContain(string text)
        {
            WebDriverWait webDriverWait = new WebDriverWait(ChromedriverHelper.driver, new TimeSpan(0, 0, TimeOut));
            webDriverWait.Until<bool>(ExpectedConditions.UrlContains(text));
        }

        private void WaitElementVisible(string xpath)
        {
            try
            {
                WebDriverWait webDriverWait = new WebDriverWait(ChromedriverHelper.driver, new TimeSpan(0, 0, TimeOut));
                webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }
            catch { }
        }

        private void WaitElementExists(string xpath)
        {
            WebDriverWait webDriverWait = new WebDriverWait(ChromedriverHelper.driver, new TimeSpan(0, 0, TimeOut));
            webDriverWait.Until<IWebElement>(ExpectedConditions.ElementExists(By.XPath(xpath)));
        }

        private void WaitElementClickable(string xpath)
        {
            WebDriverWait webDriverWait = new WebDriverWait(ChromedriverHelper.driver, new TimeSpan(0, 0, TimeOut));
            webDriverWait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
        }

        private void ClickElement(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ChromedriverHelper.driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        private IWebElement NewElementByXpath(string xpath)
        {
            IWebElement element;
            element = ChromedriverHelper.driver.FindElement(By.XPath(xpath));
            return element;
        }

        private IWebElement NewElementById(string id)
        {
            IWebElement element;
            element = ChromedriverHelper.driver.FindElement(By.Id(id));
            return element;
        }

        private bool ElementDisplayed(By locator)
        {
            new WebDriverWait(ChromedriverHelper.driver, TimeSpan.FromSeconds(TimeOut)).Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            return ChromedriverHelper.driver.FindElement(locator).Displayed;
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                ChromedriverHelper.driver.FindElement(by);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void richTextBoxLogs_TextChanged(object sender, EventArgs e)
        {
            richTextBoxLogs.SelectionStart = richTextBoxLogs.Text.Length;
            // scroll it automatically
            richTextBoxLogs.ScrollToCaret();
        }

        private void darkRadioButtonCountdownMode_CheckedChanged(object sender, EventArgs e)
        {
            BotSettings();
        }

        private void darkRadioButtonRefreshMode_CheckedChanged(object sender, EventArgs e)
        {
            BotSettings();
        }

        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        private bool checkDuplicates()
        {
            const string appName = "myapp";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
                return true;

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                this.Text = "Shopee Autobuy Bot " + currentVersion;        // load element value from element.settings
                try
                {
                    LoadElementSettings();
                }
                catch (Exception ex) { MessageBox.Show("Fail to load element settings from element.settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                // enable this event to prevent error while initializing bot
                darkComboBoxPaymentMethod.SelectedIndexChanged += darkComboBoxPaymentMethod_SelectedIndexChanged;

                // navigate chrome to shopee website
                try
                {
                    ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Object reference not set to an instance of an object."))
                    {
                        MessageBox.Show(ex.Message + "\n\nCannot launch Google Chrome. Make sure ChromeDriver.exe and Google Chrome browser is on the latest version.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                    else if (ex.Message.Contains("cannot determine loading status"))
                    {
                        var dialog = MessageBox.Show(ex.Message + "\n\nThis error may caused by outdated Chrome browser. Make sure Chrome browser is on the latest version. Ignore this error?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        { }
                        else
                            Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }

                // get UserInfo and display username and program version and display profile name
                //GetUserInfo(userId);

                // checking subscription
                //SubscriptionCheck(UserInfo);

                // add payment type into combobox
                AddPaymentToComboBox();
                darkComboBoxPaymentMethod.Text = "Default";
                EnableDisableControlOnPaymentMethod();

                Logger("Ready.", new Color?(), true, true, true);
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
        }

        private void GetUserInfo(string userId)
        {
            string userResponse = GetWithResponse($"{ServerInfos.Host}api/user/{userId}");
            UserInfo = JsonConvert.DeserializeObject<UserModel>(userResponse);
            var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            this.Text = "Shopee Autobuy Bot " + currentVersion + " | " + UserInfo.name;
            labelShopeeAcc.Text = chromeProfile;
        }

        private void SubscriptionCheck(UserModel userInfo)
        {
            if (UserInfo.expiry_date != null)
            {
                this.Text += " | Subscription ends " + UserInfo.expiry_date;
                //ExpiryCheck();
            }
            else
                this.Text += " | Lifetime";
            this.Text += " | " + chromeProfile;
        }

        private void LoadElementSettings()
        {
            ConstantElements = SettingsHelper.Element.LoadElementsFromFile();
            if (ConstantElements is null)
            { MessageBox.Show("No local elements settings found. Create new settings by saving new one or choose option 'Update element from repository' in Element Editor window.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void AddPaymentToComboBox()
        {
            var paymentMalaysia = new List<string> { "Default",
"Credit / Debit Card",
"ATM / Cash Deposit",
"Online Banking",
"ShopeePay",
"Cash on Delivery",
"7-Eleven",
"KK Mart"};

            foreach (var item in paymentMalaysia)
            {
                darkComboBoxPaymentMethod.Items.Add(item);
            }
        }

        private void ExpiryCheck()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */

                DateTime expiryDate = DateTime.ParseExact(UserInfo.expiry_date, "dd/MM/yyyy h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                while (true)
                {
                    try
                    {
                        //if (Helper.CheckInternetConnection() == false)
                        //{
                        //    MessageBox.Show("No internet connection detected. Exiting..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    Application.Exit();
                        //    return;
                        //}
                        //Thread.Sleep(1500);

                        var localDateTime = GetLocalTime();
                        if (localDateTime > expiryDate) // subscription ended
                        {
                            MessageBox.Show("Your subscription has ended. Contact admin to renew subscription.", "Subscription ended", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Application.Exit();
                            return;
                        }
                    }
                    catch { }

                    Thread.Sleep(1500);
                }
            }).Start();
        }

        private void BotSettings()
        {
            //enable/disable when changing radio check
            if (darkCheckBoxScheduleBot.Checked == true)
            {
                darkNumericUpDownCountdownHour.Enabled = true;
                darkNumericUpDownCountdownMinutes.Enabled = true;
                darkNumericUpDownCountDownSecond.Enabled = true;
                darkCheckBoxTomorrow.Enabled = true;

                darkLabel1.Enabled = true;
                darkLabel2.Enabled = true;
                darkLabel3.Enabled = true;

                if (darkNumericUpDownCountdownHour.Value == 24)
                {
                    darkNumericUpDownCountdownMinutes.Value = 0;
                    darkNumericUpDownCountDownSecond.Value = 0;
                    darkNumericUpDownCountdownMinutes.Enabled = false;
                    darkNumericUpDownCountDownSecond.Enabled = false;
                }
                else
                {
                    darkNumericUpDownCountdownMinutes.Enabled = true;
                    darkNumericUpDownCountDownSecond.Enabled = true;
                }
            }
            else
            {
                darkNumericUpDownCountdownHour.Enabled = false;
                darkNumericUpDownCountdownMinutes.Enabled = false;
                darkNumericUpDownCountDownSecond.Enabled = false;
                darkCheckBoxTomorrow.Enabled = false;

                darkLabel1.Enabled = false;
                darkLabel2.Enabled = false;
                darkLabel3.Enabled = false;
            }
        }

        private void darkNumericUpDownTimeOut_ValueChanged(object sender, EventArgs e)
        {
            TimeOut = Convert.ToInt32(darkNumericUpDownTimeOut.Value);
        }

        private string GetWithResponse(string url)
        {
            string html_ = string.Empty;

            HttpWebRequest request_ = (HttpWebRequest)WebRequest.Create(url);
            request_.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request_.GetResponse())
            using (Stream stream_ = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream_))
            {
                html_ = reader.ReadToEnd();
            }
            return html_;
        }

        private string PostWithResponseAsync(string url, string body)
        {
            string result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = body;

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MultipleInstances != true)
                {
                    if (firstTime == true)
                    {
                        string tempPath = Path.GetDirectoryName(tempFile);

                        if (File.Exists(tempPath + @"\Executer.exe"))
                            File.Delete(tempPath + @"\Executer.exe");
                        File.WriteAllBytes(tempPath + @"\Executer.exe", Properties.Resources.Executer);

                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = tempPath + @"\Executer.exe";
                        startInfo.CreateNoWindow = true;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        startInfo.Arguments = "\"" + currentFile + "\" \"" + tempFile + "\"";
                        Process.Start(startInfo);
                    }
                    else
                    {
                        ChromedriverHelper.driver.Quit();
                        ChromedriverHelper.driver = null;
                    }
                }
            }
            catch { }
        }

        private async Task darkButton5_ClickAsync(object sender, EventArgs e)
        {
            richTextBoxLogs.Text = string.Empty;
            darkButtonDeleteAllOrder.Enabled = false;
            darkButtonStart.Enabled = false;
            ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/user/purchase/list/?checkout=true&type=9");
            Thread.Sleep(1000);
            string strMore = "//span[contains(text(), 'More')]";

            if (IsElementPresent(By.XPath(strMore)))
            {
                Logger("Deleting order(s) (To pay)..", new Color?(Color.White), true, true, true);
                startAsync("CancelOrder");
            }
            else
            {
                Logger("No order available to delete.", new Color?(Color.White), true, true, true);
                darkButtonDeleteAllOrder.Enabled = true;
                darkButtonStart.Enabled = true;
            }
        }

        private void startAsync(string type)
        {
            try
            {
                Thread myNewThread = new Thread(() => WorkThread(type));
                myNewThread.Start();
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkThread(string type)
        {
            try
            {
                if (type == "CancelOrder")
                    DeleteAllOrderAsync();
                else
                    ClearCartAsync();
            }
            catch (Exception ex)
            {
                Thread.Sleep(10000);
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task ClearCartAsync()
        {
            ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/cart");

            string strCartIsEmpty = "//div[contains(@class, '_2BNbCE') and contains(text(), 'Your shopping cart is empty')]";

            string strDelete = "//button[contains(@class, 'clear-btn-style') and contains(text(), 'Delete')]";
            string strConfirmDelete = "//button[contains(@class, 'cancel-btn') and contains(text(), 'yes')]";
            string strCheckbox = "//div[contains(@class, 'stardust-checkbox__box')]";

            if (IsElementPresent(By.XPath(strCartIsEmpty)) == true)
            {
                var checkbox = NewElementByXpath(strCheckbox);
                ClickElement(checkbox);
                Thread.Sleep(250);
                var deletebutton = NewElementByXpath(strDelete);
                ClickElement(deletebutton);
                Thread.Sleep(250);
                var ConfirmButton = NewElementByXpath(strConfirmDelete);
                ClickElement(ConfirmButton);
            }
            else { MessageBox.Show("ade"); }
        }

        private async Task DeleteAllOrderAsync()
        {
            Thread.Sleep(1000);

            while (true)
            {
                string strToPay = "//*[@id=\"main\"]/div/div[2]/div[2]/div[2]/div/div[1]/div[2]/span[1]";
                string strMore = "//*[@id=\"main\"]/div/div[2]/div[2]/div[2]/div/div[4]/div[1]/div[4]/div[2]/div[3]/div";
                string strCancel = "//*[@id=\"main\"]/div/div[2]/div[2]/div[2]/div/div[4]/div[1]/div[4]/div[2]/div[3]/div/div[2]/button[2]";
                string strReasonContainer = "//*[@id=\"main\"]/div/div/div[2]/div";
                string strReason = "//div[contains(text(), 'Payment procedure too troublesome')]";
                string strConfirmCancel = "//button[contains(@class, 'btn btn-solid-primary btn--s btn--inline _1wSE68) and contains(text(), 'Cancel Order')]";

                Actions actions = new Actions(ChromedriverHelper.driver);
                if (IsElementPresent(By.XPath(strMore)))
                {
                    Logger("STEP 0", new Color?(Color.White), true, true, true);

                    Thread.Sleep(500);
                    var Morebutton = NewElementByXpath(strMore);
                    var Cancelbutton = NewElementByXpath(strCancel);

                    var selectproxy = ChromedriverHelper.driver.FindElement(By.XPath(strMore));
                    selectproxy.Click();
                    var SelectOption = new OpenQA.Selenium.Support.UI.SelectElement(selectproxy);
                    SelectOption.SelectByText("Cancel Order");

                    Logger("STEP 1", new Color?(Color.White), true, true, true);

                    actions.MoveToElement(Cancelbutton);
                    actions.Click();
                    actions.Perform();
                    Logger("STEP 2", new Color?(Color.White), true, true, true);

                    Thread.Sleep(500);

                    var ReasonCContainer = NewElementByXpath(strReasonContainer);

                    //actions.MoveToElement(ReasonCContainer).Click().Perform();
                    var ReasonButton = NewElementByXpath(strReason);

                    //actions.MoveToElement(ReasonButton).Click().Perform();

                    ClickElement(ReasonButton);
                    //Thread.Sleep(500);

                    var ConfirmCancelButton = NewElementByXpath(strConfirmCancel);
                    //Thread.Sleep(500);

                    //actions.MoveToElement(ConfirmCancelButton).Click().Perform();
                    ClickElement(ConfirmCancelButton);

                    ChromedriverHelper.driver.Navigate().GoToUrl("https://shopee.com.my/user/purchase/list/?checkout=true&type=9");
                    Thread.Sleep(1500);
                }
                else
                {
                    Logger("Done.", new Color?(Color.White), true, true, true);
                    darkButtonDeleteAllOrder.Enabled = true;
                    darkButtonStart.Enabled = true;
                    break;
                }
            }
        }

        private void darkCheckBoxDisableImageExtension_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart program for the changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void darkRadioButtonFlashSale_CheckedChanged(object sender, EventArgs e)
        {
            BotSettings();
        }

        private void darkCheckBoxHeadless_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart program for the changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void visitFacebookPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://facebook.com/ShopeeAutobuyBot");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void darkComboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(darkComboBoxPaymentMethod.Text == "Online Banking")
            //{
            //    darkLabel8.Enabled = true;
            //    darkComboBoxBankType.Enabled = true;
            //}
            //else
            //{
            //    darkLabel8.Enabled = false;
            //    darkComboBoxBankType.Enabled = false;
            //}

            //if (darkComboBoxPaymentMethod.Text == "ShopeePay")
            //{
            //    darkLabel7.Enabled = true;
            //    darkTextBoxWalletPin.Enabled = true;
            //}
            //else
            //{
            //    darkLabel7.Enabled = false;
            //    darkTextBoxWalletPin.Enabled = false;
            //}

            //if (darkComboBoxPaymentMethod.Text == "Default")
            //{
            //    MessageBox.Show("Make sure default payment method already set.", "Warning");
            //}
            EnableDisableControlOnPaymentMethod();
        }

        private void EnableDisableControlOnPaymentMethod()
        {
            if (darkComboBoxPaymentMethod.Text == "ShopeePay")
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;
            else
            {
                darkCheckBoxRedeemShopeeVoucher.Enabled = false;
            }

            if (darkComboBoxPaymentMethod.Text == "Default")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "Credit / Debit Card")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                tbLast4Digit.Enabled = true;
                darkLabel14.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "ATM / Cash Deposit")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "Online Banking")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkComboBoxBankType.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                darkLabel8.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "ShopeePay")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;
                darkTextBoxShopeePayPin.Enabled = true;
                darkLabel7.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "Cash on Delivery")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemCoin.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "7-Eleven")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                darkCheckBoxRedeemCoin.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text == "KK Mart")
            {
                foreach (Control x in darkSectionPanelPaymentDetails.Controls)
                {
                    x.Enabled = false;
                }
                darkComboBoxPaymentMethod.Enabled = true;
                darkCheckBoxRedeemShopeeVoucher.Enabled = true;

                darkCheckBoxRedeemCoin.Enabled = true;
                darkLabel6.Enabled = true;
            }

            if (darkComboBoxPaymentMethod.Text != "Online Banking")
            {
                darkComboBoxBankType.SelectedIndex = -1;
            }
        }

        private void darkTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar);
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            //if (Regex.IsMatch(tbPriceSpecific.Text, @"\.\d\d"))
            //{
            //    e.Handled = true;
            //}
            //else if (Regex.IsMatch(tbPriceSpecific.Text, @"\.\d\d") && e.KeyChar == (char)8)
            //{
            //    e.Handled = false;
            //}
        }

        private void darkCheckBoxCountDownMode_CheckedChanged(object sender, EventArgs e)
        {
            BotSettings();
        }

        private void radioButtonPriceSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPriceSpecific.Checked == true)
            {
                tbPriceSpecific.Enabled = true;
            }
            else
            {
                tbPriceSpecific.Enabled = false;
            }
        }

        private void tbPriceSpecific_Leave(object sender, EventArgs e)
        {
            if (tbPriceSpecific.Text == string.Empty)
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPriceSpecific.Text = string.Empty;
            }
            else if (tbPriceSpecific.Text.Substring(0, 1) == "0")
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPriceSpecific.Text = string.Empty;
            }
            else if (!Regex.IsMatch(tbPriceSpecific.Text, @"^[0-9]+\.[0-9][0-9]$"))
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPriceSpecific.Text = string.Empty;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shopee Autobuy Bot is an automation tool that help customers buying exclusive items without having to wait by their screens.\n\nDisclaimer : We are not responsible for any damage or harm to your Shopee account and your PC. Please know what you are doing.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void disclaimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We are not responsible for any damage or harm to your Shopee account and your PC. Please know what you are doing.", "Disclaimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void changelogHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangelogHistory form = new ChangelogHistory();
            form.ShowDialog();
        }

        private void darkNumericUpDownCountdownHour_ValueChanged(object sender, EventArgs e)
        {
            //if(darkNumericUpDownCountdownHour.Value == 24)
            //{
            //    darkNumericUpDownCountdownMinutes.Value = 0;
            //    darkNumericUpDownCountDownSecond.Value = 0;
            //    darkNumericUpDownCountdownMinutes.Enabled = false;
            //    darkNumericUpDownCountDownSecond.Enabled = false;
            //}
            //else
            //{
            //    darkNumericUpDownCountdownMinutes.Enabled = true;
            //    darkNumericUpDownCountDownSecond.Enabled = true;
            //}
        }

        private void updateConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { MessageBox.Show("Fail to update configuration from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void darkButton5_Click_1(object sender, EventArgs e)
        {
        }

        private void tbLast4Digit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void darkTextBoxWalletPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangelogHistory form = new ChangelogHistory();
            form.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());

            MessageBox.Show("Shopee Autobuy Bot\nVersion : " + currentVersion + "\nCopyright © " + DateTime.Now.Year + " Shopee Autobuy Bot Team\n\nShopee Autobuy Bot is an automation tool that help customers buying exclusive items without having to wait by their screens.\n\nDisclaimer : We are not responsible for any damage or harm to your Shopee account and your PC. Please know what you are doing. While this bot helps in buying item from Shopee, however" +
                " it doesn't 100% guarantee successful order due to circumstances such as limited promotional item, underperformed PC and internet speed and also intervention and competition with other buyers who are using bot as well.", "About Shopee Autobuy Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateConfigurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //get delay config

                GetConfig();

                MessageBox.Show("Configuration updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Fail to update configuration from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void GetConfig()
        {
            string configResponse = GetWithResponse($"{ServerInfos.Host}api/config");
            ConfigInfo = JsonConvert.DeserializeObject<DelayModel>(configResponse);
        }

        private void darkButton6_Click(object sender, EventArgs e)
        {
            ToTelegram();
            MessageBox.Show(Helper.OrderPrice);
        }

        private void radioButtonCheckOutCart_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonCheckOutCart.Checked == true) ? false : true;
        }

        private void radioButtonPriceSpecificCheckoutLink_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonPriceSpecificCARTCHECKOUT.Checked == true) ? false : true;
            if (radioButtonPriceSpecificCARTCHECKOUT.Checked == true)
            {
                tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = true;
            }
            else
            {
                tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = false;
            }
        }

        private void tbCheckoutLinkPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
            }
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !char.IsControl(e.KeyChar);
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbCheckoutLinkPrice_Leave(object sender, EventArgs e)
        {
            if (tbBelowSpecificPriceCARTCHECKOUTPrice.Text == string.Empty)
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = string.Empty;
            }
            else if (tbBelowSpecificPriceCARTCHECKOUTPrice.Text.Substring(0, 1) == "0")
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = string.Empty;
            }
            else if (!Regex.IsMatch(tbBelowSpecificPriceCARTCHECKOUTPrice.Text, @"^[0-9]+\.[0-9][0-9]$"))
            {
                MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = string.Empty;
            }
        }

        private void darkButton7_Click(object sender, EventArgs e)
        {
            richTextBoxLogs.SelectAll();
            richTextBoxLogs.Copy();
        }

        private void darkSectionPanelBuyingMode_Click(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.DontShowThisAgain)
            {
                Warning w = new Warning();
                w.ShowDialog();
            }
        }

        private void saveCookiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Path cookiesFile = Paths.get("C:\\Temp\\cookies.txt");

            //// save the cookies to a file for the current domain
            //try (PrintWriter file = new PrintWriter(cookiesFile.toFile(), "UTF-8")) {
            //    for (Cookie c : driver.manage().getCookies())
            //    {
            //        file.println(c.toString());
            //    }
            //}

            string cookiesPath = Environment.CurrentDirectory + "\\cookie\\";
            if (!Directory.Exists(cookiesPath))
                Directory.CreateDirectory(cookiesPath);
            var cookies = ChromedriverHelper.driver.Manage().Cookies.AllCookies;
            if (!File.Exists(cookiesPath + "cookies.txt"))
                File.Create(cookiesPath + "cookies.txt");
            using (StreamWriter fs = new StreamWriter(cookiesPath + "cookies.txt", true))
            {
                foreach (var cookie in cookies)
                {
                    fs.WriteLine(cookie.ToString());
                }
            }
        }

        [STAThreadAttribute]
        private void scanSaleItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
                Scan_payday_sale Scan_payday_sale = new Scan_payday_sale(ChromedriverHelper);
                Scan_payday_sale.ShowDialog();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void lazadaAutobuyBotBETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string LazadaBotDir = "";
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                using (WebClient client = new WebClient())
                {
                    string lazadaUrl = $"{ServerInfos.Host}sab/appdata/updt/Lazada%20Autobuy%20Bot.exe";

                    client.Proxy = WebRequest.DefaultWebProxy;
                    try
                    {
                        Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                        notifyIcon1.Icon = appIcon;
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = "Lazada Autobuy Bot";
                        notifyIcon1.BalloonTipText = "Downloading latest version.. Please wait.";
                        notifyIcon1.ShowBalloonTip(10000000);
                    }
                    catch (Exception ex)
                    {
                    }

                    LazadaBotDir = Environment.CurrentDirectory + @"\Lazada Autobuy Bot";
                    if (!Directory.Exists(LazadaBotDir))
                        Directory.CreateDirectory(LazadaBotDir);
                    client.DownloadFile(lazadaUrl, LazadaBotDir + @"\Lazada Autobuy Bot.exe");
                    notifyIcon1.Dispose();
                }

                DialogResult dialog = MessageBox.Show("File downloaded. Open file location?", "Lazada Autobuy Bot", MessageBoxButtons.OK, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                    Process.Start(LazadaBotDir);
            }).Start();
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
            {
                MessageBox.Show("profile.settings not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void SaveBotProfile()
        {
            try
            {
                var botSettings = new Utililties.ProfileModel.BotSettings()
                {
                    play_sound = darkCheckBoxPlaySound.Checked,
                    hide_browser = darkCheckBoxHeadless.Checked,
                    disable_image = darkCheckBoxDisableImageExtension.Checked,
                    autorefresh_webpage = darkCheckBoxRefresh.Checked,
                    autorefresh_interval = Convert.ToInt32(darkNumericUpDownRefreshSeconds.Value),
                    disable_logging = darkCheckBoxLogging.Checked,
                    test_mode = darkCheckBoxTestMode.Checked,
                    timeout = Convert.ToInt32(darkNumericUpDownTimeOut.Value)
                };
                var productInfo = new Utililties.ProfileModel.ProductDetail()
                {
                    product_link = darkTextBoxProductLink.Text,
                    variant = darkTextBoxVariationString.Text,
                    quantity = Convert.ToInt32(darkNumericUpDownProductQuantity.Value)
                };
                var voucherInfo = new Utililties.ProfileModel.Voucher_Coin()
                {
                    claim_shop_vc = darkCheckBoxClaimShopVoucher.Checked,
                    redeeem_shopee_vc = darkCheckBoxRedeemShopeeVoucher.Checked,
                    redeem_coin = darkCheckBoxRedeemCoin.Checked
                };
                var scheduleInfo = new Utililties.ProfileModel.ScheduleBot()
                {
                    schedule = darkCheckBoxScheduleBot.Checked,
                    hour = Convert.ToInt32(darkNumericUpDownCountdownHour.Value),
                    minute = Convert.ToInt32(darkNumericUpDownCountdownMinutes.Value),
                    second = Convert.ToInt32(darkNumericUpDownCountDownSecond.Value),
                    tomorrow = darkCheckBoxTomorrow.Checked
                };
                var buyMode = "";
                foreach (RadioButton c in darkSectionPanelBuyingMode.Controls.OfType<RadioButton>())
                {
                    if (c.Checked == true)
                        buyMode = c.Name;
                }
                var buyingMode = new Utililties.ProfileModel.BuyingMode()
                {
                    mode = buyMode,
                    below_specific_price = tbPriceSpecific.Text,
                    cart_below_specific_price = tbBelowSpecificPriceCARTCHECKOUTPrice.Text
                };
                var paymentInfo = new Utililties.ProfileModel.PaymentDetail()
                {
                    payment_type = darkComboBoxPaymentMethod.Text,
                    bank_type = darkComboBoxBankType.Text,
                    last_4_digit_card = tbLast4Digit.Text,
                    shopeepay_pin = darkTextBoxShopeePayPin.Text
                };
                var root = new Utililties.ProfileModel.Root()
                {
                    profile_name = SettingsHelper.Profile.Name,
                    BotSettings = botSettings,
                    ProductDetail = productInfo,
                    Voucher_Coin = voucherInfo,
                    ScheduleBot = scheduleInfo,
                    BuyingMode = buyingMode,
                    PaymentDetail = paymentInfo
                };
                SaveNewProfileToFile(root);
                MessageBox.Show("New profile (" + SettingsHelper.Profile.Name + ") successfully saved into profile.settings", "Profile saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("An error occured while saving profile", "Error"); }
        }

        private void testCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var allcookies = ChromedriverHelper.driver.Manage().Cookies.AllCookies;
            foreach (var cookie in allcookies)
            {
                MessageBox.Show("cookie: " + cookie.Name
                                + "\nvalue: " + cookie.Value);
            }
        }

        private void elementEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Element_Editor form = new Element_Editor();
            form.Show();
        }

        private void fontTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fontSize = this.Font.Size;
            this.Font = new Font("Arial", 24, FontStyle.Bold);
        }

        private void saveProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProfile profileName = new SaveProfile();
            profileName.ShowDialog();
            if (SettingsHelper.Profile.SaveProfile)
                SaveBotProfile();
        }

        private void loadProfileSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadProfile profile = new LoadProfile();
            profile.ShowDialog();

            if (SettingsHelper.Profile.LoadProfile == true)
            {
                //Load value from settings
                foreach (RadioButton c in darkSectionPanelBuyingMode.Controls.OfType<RadioButton>())
                {
                    try
                    {
                        if (SelectedProfile.BuyingMode.mode != string.Empty)
                        {
                            if (SelectedProfile.BuyingMode.mode == c.Name)
                                c.Checked = true;
                        }
                    }
                    catch
                    {
                    }
                }

                darkCheckBoxTomorrow.Checked = SelectedProfile.ScheduleBot.tomorrow;
                darkCheckBoxScheduleBot.Checked = SelectedProfile.ScheduleBot.schedule;
                tbPriceSpecific.Text = SelectedProfile.BuyingMode.below_specific_price;
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = SelectedProfile.BuyingMode.cart_below_specific_price;
                darkCheckBoxPlaySound.Checked = SelectedProfile.BotSettings.play_sound;
                darkCheckBoxDisableImageExtension.Checked = SelectedProfile.BotSettings.disable_image;

                darkNumericUpDownCountdownHour.Value = SelectedProfile.ScheduleBot.hour;
                darkNumericUpDownCountdownMinutes.Value = SelectedProfile.ScheduleBot.minute;
                darkNumericUpDownCountDownSecond.Value = SelectedProfile.ScheduleBot.second;

                darkComboBoxPaymentMethod.Text = SelectedProfile.PaymentDetail.payment_type;
                darkTextBoxShopeePayPin.Text = SelectedProfile.PaymentDetail.shopeepay_pin;

                darkTextBoxProductLink.Text = SelectedProfile.ProductDetail.product_link;

                darkTextBoxVariationString.Text = SelectedProfile.ProductDetail.variant;
                darkNumericUpDownProductQuantity.Value = SelectedProfile.ProductDetail.quantity;

                darkCheckBoxHeadless.Checked = SelectedProfile.BotSettings.hide_browser;

                darkCheckBoxLogging.Checked = SelectedProfile.BotSettings.disable_logging;
                darkCheckBoxRefresh.Checked = SelectedProfile.BotSettings.autorefresh_webpage;
                darkCheckBoxRedeemCoin.Checked = SelectedProfile.Voucher_Coin.redeem_coin;
                darkNumericUpDownRefreshSeconds.Value = SelectedProfile.BotSettings.autorefresh_interval;
                darkNumericUpDownTimeOut.Value = SelectedProfile.BotSettings.timeout;
                darkCheckBoxTestMode.Checked = SelectedProfile.BotSettings.test_mode;
                tbLast4Digit.Text = SelectedProfile.PaymentDetail.last_4_digit_card;
                darkComboBoxBankType.Text = SelectedProfile.PaymentDetail.bank_type;
                darkCheckBoxClaimShopVoucher.Checked = SelectedProfile.Voucher_Coin.claim_shop_vc;
                darkCheckBoxRedeemShopeeVoucher.Checked = SelectedProfile.Voucher_Coin.redeeem_shopee_vc;

                MessageBox.Show("Profile loaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {
            darkTextBoxVariationString.Enabled = (cbRandom.Checked) ? false : true;
            //if (cbRandom.Checked)
            //    darkTextBoxVariationString.Text = "";
        }
    }
}