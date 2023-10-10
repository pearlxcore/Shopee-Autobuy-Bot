using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Models;
using Shopee_Autobuy_Bot.Services;
using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Notification;
using Shopee_Autobuy_Bot.Services.Profile;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Constants.AutoBuyInfo;

namespace Shopee_Autobuy_Bot
{
    public partial class Main : Form
    {
        private UserModel UserInfo = new UserModel();
        private ChromeDriverHelper ChromedriverHelper = new ChromeDriverHelper();
        private static Mutex mutex = null;
        public bool DoneSetupQuickBuyMode = false;

        private readonly ISeleniumService _seleniumService;
        private readonly IProfileService _profileService;
        private readonly IAutoBuyService _autoBuyService;
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;

        public Main(ISeleniumService seleniumService, IProfileService profileService)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            darkComboBoxPaymentMethod.SelectedIndexChanged -= darkComboBoxPaymentMethod_SelectedIndexChanged;
            _seleniumService=seleniumService;
            _profileService=profileService;
            _autoBuyLoggerService = new AutoBuyLoggerService(richTextBoxLogs, _profileService);
            _autoBuyService = new AutoBuyService(_autoBuyLoggerService, seleniumService, darkButtonStart, _profileService);
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

        private void MapControlsToSelectedProfile()
        {
            if (_profileService.SelectedProfile is null)
                _profileService.SelectedProfile = new ProfileModel.Root();
            if (radioButtonBuyNormal.Checked)
                _profileService.SelectedProfile.BuyingMode.mode = BuyingMode.Normal;
            if (radioButtonShockingSale.Checked)
                _profileService.SelectedProfile.BuyingMode.mode = BuyingMode.Flash_Shocking;
            if (radioButtonCheckOutCart.Checked)
                _profileService.SelectedProfile.BuyingMode.mode = BuyingMode.Cart;
            if (radioButtonPriceSpecificCartCheckout.Checked)
                _profileService.SelectedProfile.BuyingMode.mode = BuyingMode.Below_Price_Cart;
            if (radioButtonPriceSpecific.Checked)
                _profileService.SelectedProfile.BuyingMode.mode = BuyingMode.Below_Price;

            _profileService.SelectedProfile.ScheduleBot.tomorrow = darkCheckBoxTomorrow.Checked;
            _profileService.SelectedProfile.ScheduleBot.schedule = darkCheckBoxScheduleBot.Checked;
            _profileService.SelectedProfile.BuyingMode.below_specific_price = tbPriceSpecific.Text;
            _profileService.SelectedProfile.BuyingMode.cart_below_specific_price = tbBelowSpecificPriceCARTCHECKOUTPrice.Text;
            _profileService.SelectedProfile.BotSettings.alert_telegram = darkCheckBoxNotifyTelegram.Checked;
            _profileService.SelectedProfile.BotSettings.desktop_notification = checkBoxDesktopNotification.Checked;

            _profileService.SelectedProfile.ScheduleBot.hour = Convert.ToInt32(darkNumericUpDownCountdownHour.Value);
            _profileService.SelectedProfile.ScheduleBot.minute = Convert.ToInt32(darkNumericUpDownCountdownMinutes.Value);
            _profileService.SelectedProfile.ScheduleBot.second = Convert.ToInt32(darkNumericUpDownCountDownSecond.Value);

            _profileService.SelectedProfile.PaymentDetail.payment_method = darkComboBoxPaymentMethod.Text;
            _profileService.SelectedProfile.PaymentDetail.shopeepay_pin = darkTextBoxShopeePayPin.Text;

            _profileService.SelectedProfile.ProductDetail.product_link = darkTextBoxProductLink.Text;

            _profileService.SelectedProfile.ProductDetail.random_variant = cbRandom.Checked;
            _profileService.SelectedProfile.ProductDetail.variant_preSelected = cbVariantPreSelected.Checked;

            _profileService.SelectedProfile.ProductDetail.variant = darkTextBoxVariationString.Text;
            _profileService.SelectedProfile.ProductDetail.quantity = Convert.ToInt32(darkNumericUpDownProductQuantity.Value);


            _profileService.SelectedProfile.BotSettings.disable_logging = darkCheckBoxLogging.Checked;
            _profileService.SelectedProfile.BotSettings.autorefresh_webpage = darkCheckBoxRefresh.Checked;
            _profileService.SelectedProfile.Voucher_Coin.redeem_coin = darkCheckBoxRedeemCoin.Checked;
            _profileService.SelectedProfile.BotSettings.autorefresh_interval = Convert.ToInt32(darkNumericUpDownRefreshSeconds.Value);
            _profileService.SelectedProfile.BotSettings.timeout = Convert.ToInt32(darkNumericUpDownTimeOut.Value);
            _profileService.SelectedProfile.BotSettings.test_mode = darkCheckBoxTestMode.Checked;
            _profileService.SelectedProfile.PaymentDetail.last_4_digit_card = tbLast4Digit.Text;
            _profileService.SelectedProfile.PaymentDetail.bank_type = darkComboBoxBankType.Text;
            _profileService.SelectedProfile.Voucher_Coin.claim_shop_vc = darkCheckBoxClaimShopVoucher.Checked;
            _profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc = darkCheckBoxRedeemShopeeVoucher.Checked;
        }

        public bool IsProfileValid(Utililties.ProfileModel.Root profile)
        {
            // Check if any of the required properties is null
            if (profile == null ||
                string.IsNullOrEmpty(profile.ProductDetail?.product_link) ||
                profile.ProductDetail.quantity < 1 ||
                string.IsNullOrEmpty(profile.PaymentDetail?.payment_method))
            {
                return false;
            }

            // All required properties are not null or empty, so return true
            return true;
        }

        private void darkButtonStart_Click(object sender, EventArgs e)
        {

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                if (darkButtonStart.Text.Equals("Start"))
                {
                    MapControlsToSelectedProfile();
                    if (!IsProfileValid(_profileService.SelectedProfile))
                    {
                        MessageBox.Show("Missing some product details", "Logged out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //if (!_seleniumService.CheckLogin())
                    //{
                    //    MessageBox.Show("Shopee account not logged in.", "Logged out", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}

                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Normal && _profileService.SelectedProfile.ProductDetail.product_link == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Flash_Shocking && _profileService.SelectedProfile.ProductDetail.product_link == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price && _profileService.SelectedProfile.ProductDetail.product_link == "")
                    {
                        MessageBox.Show("Specify product link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price && _profileService.SelectedProfile.BuyingMode.below_specific_price == string.Empty)
                    {
                        MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart && _profileService.SelectedProfile.BuyingMode.cart_below_specific_price == string.Empty)
                    {
                        MessageBox.Show("Invalid price format. E.g. 1.00/10.00/100.00", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.PaymentDetail.payment_method == string.Empty)
                    {
                        MessageBox.Show("Select payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.PaymentDetail.payment_method == "Online Banking" && _profileService.SelectedProfile.PaymentDetail.bank_type == string.Empty)
                    {
                        MessageBox.Show("Select bank type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.PaymentDetail.payment_method == "ShopeePay" && _profileService.SelectedProfile.PaymentDetail.shopeepay_pin == string.Empty)
                    {
                        MessageBox.Show("Specify ShopeePay pin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.PaymentDetail.payment_method == "Credit / Debit Card" && _profileService.SelectedProfile.PaymentDetail.last_4_digit_card == string.Empty)
                    {
                        MessageBox.Show("Specify last 4 digit of debit/credit card to be used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if ((_profileService.SelectedProfile.BuyingMode.mode.ToString() != "Below_Price_Cart"
                    && _profileService.SelectedProfile.BuyingMode.mode.ToString() != "Below_Price_Cart")
                    && !_profileService.SelectedProfile.ProductDetail.product_link.Contains("https://shopee.com.my/"))
                    {
                        MessageBox.Show("Link not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_profileService.SelectedProfile.ScheduleBot.schedule)
                    {
                        if (_profileService.SelectedProfile.ScheduleBot.tomorrow)
                        {
                            AutoBuyInfo.AutoBuyStartTime = DateTime.Today.AddDays(1) + new TimeSpan(_profileService.SelectedProfile.ScheduleBot.hour,
                                _profileService.SelectedProfile.ScheduleBot.minute,
                                _profileService.SelectedProfile.ScheduleBot.second);
                        }
                        else
                        {
                            AutoBuyInfo.AutoBuyStartTime = DateTime.Today;
                            AutoBuyInfo.AutoBuyStartTime = AutoBuyInfo.AutoBuyStartTime.Date + new TimeSpan(_profileService.SelectedProfile.ScheduleBot.hour,
                                _profileService.SelectedProfile.ScheduleBot.minute,
                                _profileService.SelectedProfile.ScheduleBot.second);
                            if (AutoBuyInfo.AutoBuyStartTime < DateTime.Now)
                            {
                                MessageBox.Show("Time is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                    {
                        AutoBuyInfo.AutoBuyStartTime = DateTime.Now/*.AddSeconds(Convert.ToDouble(darkNumericUpDownRefreshSeconds.Value))*/;
                    }

                    try
                    {
                        if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Cart
                        || _profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart)
                            _seleniumService.GoToUrl("https://shopee.com.my/cart");
                        else
                            _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("window was already closed"))
                        {
                            MessageBox.Show("Main Chrome browser windows was closed. Please restart the program", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    Helper.Shopee.Status = "Fail";
                    _autoBuyService.Abort = false;
                    _seleniumService.timeOut = _profileService.SelectedProfile.BotSettings.timeout;
                    _autoBuyLoggerService.AutoBuyProcessLog("Autobuy starts at : " + AutoBuyInfo.AutoBuyStartTime.ToString(), Color.Black, true, true, true);

                    timerlabelBig.Text = "00:00:00:00";
                    darkButtonDeleteAllOrder.Enabled = false;
                    darkSectionPanelProductDetails.Enabled = false;
                    darkSectionPanelTimerMode.Enabled = false;
                    darkSectionPanelBuyingMode.Enabled = false;
                    darkSectionPanelPaymentDetails.Enabled = false;
                    darkSectionPanelBotSettings.Enabled = false;
                    richTextBoxLogs.Text = string.Empty;
                    darkButtonStart.Text = "Stop";

                    startWorkThreadAsync();
                }
                else
                {
                    _autoBuyService.Abort = true;
                    darkButtonStart.Text = "Stopping...";
                    darkButtonStart.Enabled = false;
                    darkButtonDeleteAllOrder.Enabled = false;
                    darkSectionPanelProductDetails.Enabled = false;
                    darkSectionPanelTimerMode.Enabled = false;
                    darkSectionPanelPaymentDetails.Enabled = false;
                    darkSectionPanelBotSettings.Enabled = false;
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
                throw new Exception(ex.Message);
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
                throw new Exception(ex.Message);
            }
        }

        private void countdownTimer()
        {
            if (_profileService.SelectedProfile.ScheduleBot.schedule)
            {
                _autoBuyLoggerService.AutoBuyProcessLog("Countdown started..", Color.IndianRed, true, true, true);

            }
            Helper.Shopee.seconds = AutoBuyInfo.AutoBuyStartTime - DateTime.Now;
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 100.0;
            timer.Elapsed += (ElapsedEventHandler)((obj, args) =>
            {
                if (Helper.Shopee.seconds.TotalSeconds < 0.0)
                {
                    timer.Stop();
                    int stepType = 0;
                    if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Flash_Shocking) //shocking sale
                    {
                        _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                        stepType = 0;
                    }
                    else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price) //price specific
                    {
                        _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                        stepType = 95;
                    }
                    else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Cart) //checkout form cart
                    {
                        _seleniumService.GoToUrl("https://shopee.com.my/cart");
                        stepType = 96;
                    }
                    else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Normal) //normal
                    {
                        _seleniumService.GoToUrl(_profileService.SelectedProfile.ProductDetail.product_link);
                        stepType = 1;
                    }
                    else if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart) // price specific CART CHECKOUT
                    {
                        _seleniumService.GoToUrl("https://shopee.com.my/cart");
                        stepType = 94;
                    }
                    _autoBuyService.ShopeeAutobuy(DateTime.Now);

                    darkButtonStart.Text = "Start";
                    darkButtonStart.Enabled = true;
                    darkButtonDeleteAllOrder.Enabled = true;

                    darkSectionPanelBotSettings.Enabled = true;
                    darkSectionPanelBuyingMode.Enabled = true;
                    darkSectionPanelProductDetails.Enabled = true;
                    darkSectionPanelTimerMode.Enabled = true;
                    darkSectionPanelPaymentDetails.Enabled = true;
                    darkSectionPanelBotSettings.Enabled = true;

                    if (radioButtonPriceSpecificCartCheckout.Checked)
                        darkSectionPanelProductDetails.Enabled = false;
                    if (radioButtonCheckOutCart.Checked)
                        darkSectionPanelProductDetails.Enabled = false;

                    timerlabelBig.Text = _autoBuyService.TotalTimeSpan.ToString("dd\\:hh\\:mm\\:ss");
                    if (_autoBuyService.Abort)
                        _autoBuyLoggerService.AutoBuyProcessLog("Job aborted.", Color.OrangeRed, true, true, true);

                    _autoBuyLoggerService.SaveAutoBuyProcessLogToLogFile(richTextBoxLogs);
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

                            //    if (radioButtonPriceSpecificCARTCHECKOUT.Checked)
                            //        darkSectionPanelProductDetails.Enabled = false;
                            //    if (radioButtonCheckOutCart.Checked)
                            //        darkSectionPanelProductDetails.Enabled = false;

                            //}

                            darkSectionPanelBotSettings.Enabled = true;
                            darkSectionPanelBuyingMode.Enabled = true;
                            darkSectionPanelProductDetails.Enabled = true;
                            darkSectionPanelTimerMode.Enabled = true;
                            darkSectionPanelPaymentDetails.Enabled = true;
                            darkSectionPanelBotSettings.Enabled = true;

                            if (radioButtonPriceSpecificCartCheckout.Checked)
                                darkSectionPanelProductDetails.Enabled = false;
                            if (radioButtonCheckOutCart.Checked)
                                darkSectionPanelProductDetails.Enabled = false;

                            timerlabelBig.Text = "00:00:00:00";
                        }
                        else
                        {
                            TimeSpan timeSpan1 = AutoBuyInfo.AutoBuyStartTime - DateTime.Now;
                            double result;
                            double.TryParse(Helper.Shopee.CountdownMicroseconds, out result);
                            TimeSpan timeSpan2 = timeSpan1.Add(TimeSpan.FromMilliseconds(result));
                            Helper.Shopee.seconds = timeSpan2;
                            timerlabelBig.Text = timeSpan2.ToString("dd\\:hh\\:mm\\:ss");

                            //if (timeSpan2.Days > 0)
                            //    timerlabel1.Text = timeSpan2.ToString("dd\\:hh\\:mm\\:ss");
                            //else
                            //    timerlabel1.Text = timeSpan2.ToString("hh\\:mm\\:ss");
                        }
                    }));
            });
            timer.Start();
        }

        static string GetCurrentTime()
        {
            DateTime now = DateTime.Now;
            string currentTime = now.ToString("HH:mm:ss");
            return currentTime;
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
                    _seleniumService.GoToUrl("https://shopee.com.my/");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Object reference not set to an instance of an object."))
                    {
                        MessageBox.Show(ex.Message + "\n\nCannot launch Google Chrome. Make sure chromedriver.exe and Google Chrome browser is on the latest version.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                GetConfigAsync();
                _autoBuyLoggerService.AutoBuyProcessLog("Ready.", Color.Black, true, true, true);
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

        private void LoadElementSettings()
        {
            Constants.AutoBuyInfo.ConstantElements = SettingsHelper.Element.LoadElementsFromFile();
            if (Constants.AutoBuyInfo.ConstantElements is null)
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

        private void BotSettings()
        {
            //enable/disable when changing radio check
            if (darkCheckBoxScheduleBot.Checked)
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
        }

        private async Task<string> GetWithResponse(string url)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = await reader.ReadToEndAsync();
            }

            return html;
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
                _seleniumService.QuitDriver();
            }
            catch { }
        }

        private void darkCheckBoxDisableImageExtension_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart program for the changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (radioButtonPriceSpecific.Checked)
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

            MessageBox.Show("Shopee Autobuy Bot\nVersion : " + currentVersion + "\nCopyright © " + DateTime.Now.Year + " pearlxcore\n\nShopee Autobuy Bot is an automation tool that help customers buying exclusive items without having to wait by their screens.\n\nDisclaimer : We are not responsible for any damage or harm to your Shopee account and your PC. Please know what you are doing. While this bot helps in buying item from Shopee, however" +
                " it doesn't 100% guarantee successful order due to circumstances such as limited promotional item, underperformed PC and internet speed and also intervention and competition with other buyers who are using bot as well.", "About Shopee Autobuy Bot", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateConfigurationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //get delay config

                GetConfigAsync();

                MessageBox.Show("Configuration updated.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Fail to update configuration from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private async Task GetConfigAsync()
        {
            string configResponse = await GetWithResponse($"{Urls.SabSettings.Configuration}");
            Constants.AutoBuyInfo.ConfigInfo = JsonConvert.DeserializeObject<DelayModel>(configResponse);
        }

        private void darkButton6_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonCheckOutCart_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonCheckOutCart.Checked) ? false : true;
        }

        private void radioButtonPriceSpecificCheckoutLink_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonPriceSpecificCartCheckout.Checked) ? false : true;
            if (radioButtonPriceSpecificCartCheckout.Checked)
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
                    alert_telegram = darkCheckBoxNotifyTelegram.Checked,
                    desktop_notification = checkBoxDesktopNotification.Checked,
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
                    quantity = Convert.ToInt32(darkNumericUpDownProductQuantity.Value),
                    random_variant = cbRandom.Checked,
                    variant_preSelected = cbVariantPreSelected.Checked
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

                string buyMode = "";
                if (radioButtonBuyNormal.Checked)
                    buyMode = "Normal";
                if (radioButtonShockingSale.Checked)
                    buyMode = "Flash_Shocking";
                if (radioButtonPriceSpecific.Checked)
                    buyMode = "Below_Price";
                if (radioButtonPriceSpecificCartCheckout.Checked)
                    buyMode = "Below_Price_Cart";
                if (radioButtonCheckOutCart.Checked)
                    buyMode = "Cart";

                var buyingMode = new Utililties.ProfileModel.BuyingMode()
                {
                    mode = buyMode,
                    below_specific_price = tbPriceSpecific.Text,
                    cart_below_specific_price = tbBelowSpecificPriceCARTCHECKOUTPrice.Text
                };
                var paymentInfo = new Utililties.ProfileModel.PaymentDetail()
                {
                    payment_method = darkComboBoxPaymentMethod.Text,
                    bank_type = darkComboBoxBankType.Text,
                    last_4_digit_card = tbLast4Digit.Text,
                    shopeepay_pin = darkTextBoxShopeePayPin.Text
                };
                var root = new Utililties.ProfileModel.Root()
                {
                    profile_name = _profileService.Name,
                    BotSettings = botSettings,
                    ProductDetail = productInfo,
                    Voucher_Coin = voucherInfo,
                    ScheduleBot = scheduleInfo,
                    BuyingMode = buyingMode,
                    PaymentDetail = paymentInfo
                };
                _profileService.CreateProfile(root);
                MessageBox.Show("New profile (" + _profileService.Name + ") successfully saved into profile.settings", "Profile saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        }

        private void loadProfileSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {
            darkTextBoxVariationString.Enabled = (cbRandom.Checked) ? false : true;
            //if (cbRandom.Checked)
            //    darkTextBoxVariationString.Text = "";
        }


        private void loadCookiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _seleniumService.LoadCookie();
        }

        private void saveCookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _seleniumService.SaveCookie();
        }

        private void cleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _seleniumService.ClearCookie();
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //_seleniumService.TestCookie();
        }

        private void toolStripMenuItemLoadProfile_Click(object sender, EventArgs e)
        {
            LoadProfile profile = new LoadProfile(_profileService);
            profile.ShowDialog();

            if (_profileService.LoadProfile)
            {
                if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Normal)
                    radioButtonBuyNormal.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Flash_Shocking)
                    radioButtonShockingSale.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price)
                    radioButtonPriceSpecific.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Below_Price_Cart)
                    radioButtonPriceSpecificCartCheckout.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode == BuyingMode.Cart)
                    radioButtonCheckOutCart.Checked = true;

                darkCheckBoxTomorrow.Checked = _profileService.SelectedProfile.ScheduleBot.tomorrow;
                darkCheckBoxScheduleBot.Checked = _profileService.SelectedProfile.ScheduleBot.schedule;
                tbPriceSpecific.Text = _profileService.SelectedProfile.BuyingMode.below_specific_price;
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = _profileService.SelectedProfile.BuyingMode.cart_below_specific_price;
                darkCheckBoxNotifyTelegram.Checked = _profileService.SelectedProfile.BotSettings.alert_telegram;
                checkBoxDesktopNotification.Checked = _profileService.SelectedProfile.BotSettings.desktop_notification;

                darkNumericUpDownCountdownHour.Value = _profileService.SelectedProfile.ScheduleBot.hour;
                darkNumericUpDownCountdownMinutes.Value = _profileService.SelectedProfile.ScheduleBot.minute;
                darkNumericUpDownCountDownSecond.Value = _profileService.SelectedProfile.ScheduleBot.second;

                darkComboBoxPaymentMethod.Text = _profileService.SelectedProfile.PaymentDetail.payment_method;
                darkTextBoxShopeePayPin.Text = _profileService.SelectedProfile.PaymentDetail.shopeepay_pin;

                darkTextBoxProductLink.Text = _profileService.SelectedProfile.ProductDetail.product_link;
                cbRandom.Checked = _profileService.SelectedProfile.ProductDetail.random_variant;
                darkTextBoxVariationString.Text = _profileService.SelectedProfile.ProductDetail.variant;
                darkNumericUpDownProductQuantity.Value = _profileService.SelectedProfile.ProductDetail.quantity;


                darkCheckBoxLogging.Checked = _profileService.SelectedProfile.BotSettings.disable_logging;
                darkCheckBoxRefresh.Checked = _profileService.SelectedProfile.BotSettings.autorefresh_webpage;
                darkCheckBoxRedeemCoin.Checked = _profileService.SelectedProfile.Voucher_Coin.redeem_coin;
                darkNumericUpDownRefreshSeconds.Value = _profileService.SelectedProfile.BotSettings.autorefresh_interval;
                darkNumericUpDownTimeOut.Value = _profileService.SelectedProfile.BotSettings.timeout;
                darkCheckBoxTestMode.Checked = _profileService.SelectedProfile.BotSettings.test_mode;
                tbLast4Digit.Text = _profileService.SelectedProfile.PaymentDetail.last_4_digit_card;
                darkComboBoxBankType.Text = _profileService.SelectedProfile.PaymentDetail.bank_type;
                darkCheckBoxClaimShopVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.claim_shop_vc;
                darkCheckBoxRedeemShopeeVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc;

                MessageBox.Show("Profile loaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveCurrentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProfile profileName = new SaveProfile(_profileService);
            profileName.ShowDialog();
            if (_profileService.SaveProfile)
                SaveBotProfile();
        }

        private void cbVariantPreSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVariantPreSelected.Checked)
            {
                cbRandom.Enabled = false;
                darkTextBoxVariationString.Enabled = false;
            }
            else
            {
                cbRandom.Enabled = true;
                darkTextBoxVariationString.Enabled = true;
            }
        }

        private void telegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INotificationService telegramService = new NotificationService(_autoBuyLoggerService);
            telegramService.SendNotification(SAB_Account, _profileService, _autoBuyService.OrderPrice, _autoBuyService.CheckoutTimeSpan);
        }
    }
}