using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Shopee_Autobuy_Bot
{
    public partial class Profile : Form
    {
        private List<Utililties.ProfileModel.Root> profileList = new List<Utililties.ProfileModel.Root>();
        private readonly IProfileService _profileService;

        public Profile(IProfileService profileService)
        {
            InitializeComponent();
            _profileService=profileService;
        }

        private void Profile_Load_1(object sender, EventArgs e)
        {
            LoadProfile();
            darkComboBoxPaymentMethod.Text = "Default";
        }

        private void LoadProfile()
        {
            darkComboBoxProfile.Items.Clear();
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
                File.Create(DirectoryPaths.ProfileSettingsPath);
            profileList = _profileService.LoadProfiles();
            if (profileList == null)
            {
                MessageBox.Show("No profile found", "LogInfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (var profile in profileList)
            {
                darkComboBoxProfile.Items.Add(profile.profile_name);
            }
            _profileService.LoadProfile = false;
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (darkComboBoxProfile.Text == string.Empty)
            {
                MessageBox.Show("Select profile to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (profileList.Count == 0)
                return;

            var deleteProfile = _profileService.DeleteProfile(darkComboBoxProfile.Text);
            if (!deleteProfile)
            {
                MessageBox.Show("Error occured when deleting profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            darkComboBoxProfile.Items.Remove(darkComboBoxProfile.Text);
            profileList.Clear();
            profileList = _profileService.LoadProfiles();
            MessageBox.Show("Profile deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            if (darkComboBoxProfile.Text == string.Empty)
            {
                MessageBox.Show("Select profile to load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _profileService.LoadProfile = true;
            this.Close();
        }

        private void darkComboBoxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var profile in profileList)
            {
                if (profile.profile_name == darkComboBoxProfile.Text)
                {
                    _profileService.SelectedProfile = profile;
                    break;
                }
            }

            if (_profileService.SelectedProfile == null)
            {
                MessageBox.Show("Failed to load profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "Normal")
                    radioButtonBuyNormal.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "Flash_Shocking")
                    radioButtonShockingSale.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "Below_Price")
                    radioButtonPriceSpecific.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "Below_Price_Cart")
                    radioButtonPriceSpecific_CartCheckout.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "CartPage")
                    radioButtonCheckOutCart.Checked = true;

                darkCheckBoxTomorrow.Checked = _profileService.SelectedProfile.ScheduleBot.tomorrow;
                darkCheckBoxScheduleBot.Checked = _profileService.SelectedProfile.ScheduleBot.schedule;
                tbPriceSpecific.Text = _profileService.SelectedProfile.BuyingMode.below_specific_price;
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = _profileService.SelectedProfile.BuyingMode.cart_below_specific_price;
                checkBoxDesktopNotification.Checked = _profileService.SelectedProfile.BotSettings.desktop_notification;
                darkCheckBoxNotifyTelegram.Checked = _profileService.SelectedProfile.BotSettings.alert_telegram;

                numericUpDownHour.Value = Convert.ToInt32(_profileService.SelectedProfile.ScheduleBot.hour.ToString());
                numericUpDownMinute.Value = Convert.ToInt32(_profileService.SelectedProfile.ScheduleBot.minute.ToString());
                numericUpDownSecond.Value = Convert.ToInt32(_profileService.SelectedProfile.ScheduleBot.second.ToString());

                darkComboBoxPaymentMethod.Text = _profileService.SelectedProfile.PaymentDetail.payment_method;
                darkTextBoxShopeePayPin.Text = _profileService.SelectedProfile.PaymentDetail.shopeepay_pin;

                darkTextBoxProductLink.Text = _profileService.SelectedProfile.ProductDetail.product_link;
                cbRandom.Checked = _profileService.SelectedProfile.ProductDetail.random_variant;
                cbVariantPreSelected.Checked = _profileService.SelectedProfile.ProductDetail.variant_preSelected;

                darkTextBoxVariationString.Text = _profileService.SelectedProfile.ProductDetail.variant;
                numericUpDownQuantity.Value = Convert.ToInt32(_profileService.SelectedProfile.ProductDetail.quantity.ToString());

                tbTelegramChatId.Text = _profileService.SelectedProfile.TelegramSettings.chat_id;
                tbTelegramApiToken.Text = _profileService.SelectedProfile.TelegramSettings.api_token;


                darkCheckBoxLogging.Checked = _profileService.SelectedProfile.BotSettings.disable_logging;
                darkCheckBoxRefresh.Checked = _profileService.SelectedProfile.BotSettings.autorefresh_webpage;
                darkCheckBoxRedeemCoin.Checked = _profileService.SelectedProfile.Voucher_Coin.redeem_coin;
                numericUpDownRefreshInterval.Value = Convert.ToInt32(_profileService.SelectedProfile.BotSettings.autorefresh_interval.ToString());
                numericUpDownTimeOut.Value =Convert.ToInt32(_profileService.SelectedProfile.BotSettings.timeout.ToString());
                darkCheckBoxTestMode.Checked = _profileService.SelectedProfile.BotSettings.test_mode;
                tbLast4Digit.Text = _profileService.SelectedProfile.PaymentDetail.last_4_digit_card;
                darkComboBoxBankType.Text = _profileService.SelectedProfile.PaymentDetail.bank_type;
                darkCheckBoxClaimShopVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.claim_shop_vc;
                darkCheckBoxRedeemShopeeVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc;
            }
            catch { }

        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            if (darkComboBoxProfile.Text == string.Empty)
            {
                MessageBox.Show("Select profile to load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in profileList)
            {
                if (item.profile_name == darkComboBoxProfile.SelectedItem.ToString())
                {
                    item.BotSettings.alert_telegram = darkCheckBoxNotifyTelegram.Checked;
                    item.BotSettings.desktop_notification = checkBoxDesktopNotification.Checked;
                    item.BotSettings.autorefresh_webpage = darkCheckBoxRefresh.Checked;
                    item.BotSettings.autorefresh_interval = Convert.ToInt32(numericUpDownRefreshInterval.Value);
                    item.BotSettings.disable_logging = darkCheckBoxLogging.Checked;
                    item.BotSettings.test_mode = darkCheckBoxTestMode.Checked;
                    item.BotSettings.timeout = Convert.ToInt32(numericUpDownTimeOut.Value);

                    item.TelegramSettings.chat_id = tbTelegramChatId.Text;
                    item.TelegramSettings.api_token = tbTelegramApiToken.Text;

                    item.ProductDetail.product_link = darkTextBoxProductLink.Text;
                    item.ProductDetail.variant = darkTextBoxVariationString.Text;
                    item.ProductDetail.quantity = Convert.ToInt32(numericUpDownQuantity.Value);
                    item.ProductDetail.random_variant = cbRandom.Checked;
                    item.ProductDetail.variant_preSelected = cbVariantPreSelected.Checked;

                    item.Voucher_Coin.claim_shop_vc = darkCheckBoxClaimShopVoucher.Checked;
                    item.Voucher_Coin.redeeem_shopee_vc = darkCheckBoxRedeemShopeeVoucher.Checked;
                    item.Voucher_Coin.redeem_coin = darkCheckBoxRedeemCoin.Checked;

                    item.ScheduleBot.schedule = darkCheckBoxScheduleBot.Checked;
                    item.ScheduleBot.hour = Convert.ToInt32(numericUpDownHour.Value);
                    item.ScheduleBot.minute = Convert.ToInt32(numericUpDownMinute.Value);
                    item.ScheduleBot.second = Convert.ToInt32(numericUpDownSecond.Value);
                    item.ScheduleBot.tomorrow = darkCheckBoxTomorrow.Checked;

                    string buyMode = "";
                    if (radioButtonBuyNormal.Checked)
                        buyMode = "Normal";
                    if (radioButtonShockingSale.Checked)
                        buyMode = "Flash_Shocking";
                    if (radioButtonPriceSpecific.Checked)
                        buyMode = "Below_Price";
                    if (radioButtonPriceSpecific_CartCheckout.Checked)
                        buyMode = "Below_Price_Cart";
                    if (radioButtonCheckOutCart.Checked)
                        buyMode = "Cart";

                    item.BuyingMode.mode = buyMode;
                    item.BuyingMode.below_specific_price = tbPriceSpecific.Text;
                    item.BuyingMode.cart_below_specific_price = tbBelowSpecificPriceCARTCHECKOUTPrice.Text;

                    item.PaymentDetail.payment_method = darkComboBoxPaymentMethod.Text;
                    item.PaymentDetail.bank_type = darkComboBoxBankType.Text;
                    item.PaymentDetail.last_4_digit_card = tbLast4Digit.Text;
                    item.PaymentDetail.shopeepay_pin = darkTextBoxShopeePayPin.Text;

                    _profileService.UpdateExistingProfile(item);
                    MessageBox.Show($"Profile \"{item.profile_name}\" updated.", "Profile updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCreateNewProfile_Click(object sender, EventArgs e)
        {
            if (tbNewProfileName.Text == string.Empty)
            {
                MessageBox.Show("Profile name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if profile name exist
            var profileList = _profileService.LoadProfiles();
            if (profileList != null)
            {
                var profileNameAlreadyExist = profileList.Any(x => x.profile_name==tbNewProfileName.Text);
                if (profileNameAlreadyExist)
                {
                    MessageBox.Show("Profile name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            SaveNewBotProfile(tbNewProfileName.Text);
        }

        private void SaveNewBotProfile(string newProfileName)
        {
            try
            {
                var botSettings = new Utililties.ProfileModel.BotSettings()
                {
                    alert_telegram = darkCheckBoxNotifyTelegram.Checked,
                    desktop_notification = checkBoxDesktopNotification.Checked,
                    autorefresh_webpage = darkCheckBoxRefresh.Checked,
                    autorefresh_interval = Convert.ToInt32(numericUpDownRefreshInterval.Value),
                    disable_logging = darkCheckBoxLogging.Checked,
                    test_mode = darkCheckBoxTestMode.Checked,
                    timeout = Convert.ToInt32(numericUpDownTimeOut.Value)
                };
                var telegramSettings = new Utililties.ProfileModel.TelegramSettings()
                {
                    chat_id = tbTelegramChatId.Text,
                    api_token = tbTelegramApiToken.Text
                };
                var productInfo = new Utililties.ProfileModel.ProductDetail()
                {
                    product_link = darkTextBoxProductLink.Text,
                    variant = darkTextBoxVariationString.Text,
                    quantity = Convert.ToInt32(numericUpDownQuantity.Value),
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
                    hour = Convert.ToInt32(numericUpDownHour.Value),
                    minute = Convert.ToInt32(numericUpDownMinute.Value),
                    second = Convert.ToInt32(numericUpDownSecond.Value),
                    tomorrow = darkCheckBoxTomorrow.Checked
                };

                string buyMode = "";
                if (radioButtonBuyNormal.Checked)
                    buyMode = "Normal";
                if (radioButtonShockingSale.Checked)
                    buyMode = "Flash_Shocking";
                if (radioButtonPriceSpecific.Checked)
                    buyMode = "Below_Price";
                if (radioButtonPriceSpecific_CartCheckout.Checked)
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
                    profile_name = newProfileName,
                    BotSettings = botSettings,
                    TelegramSettings = telegramSettings,
                    ProductDetail = productInfo,
                    Voucher_Coin = voucherInfo,
                    ScheduleBot = scheduleInfo,
                    BuyingMode = buyingMode,
                    PaymentDetail = paymentInfo
                };
                _profileService.CreateNewProfile(root);
                LoadProfile();
                MessageBox.Show($"New profile \"{newProfileName}\" created.", "Profile created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("An error occured while saving profile", "Error"); }
        }

        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {
            darkTextBoxVariationString.Enabled = (cbRandom.Checked) ? false : true;
            cbVariantPreSelected.Enabled = (cbRandom.Checked) ? false : true;
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

        private void darkCheckBoxScheduleBot_CheckedChanged(object sender, EventArgs e)
        {
            ScheduleBotUiUpdate();
        }

        private void ScheduleBotUiUpdate()
        {
            //enable/disable when changing radio check
            if (darkCheckBoxScheduleBot.Checked)
            {
                numericUpDownHour.Enabled = true;
                numericUpDownMinute.Enabled = true;
                numericUpDownSecond.Enabled = true;
                darkCheckBoxTomorrow.Enabled = true;

                labelHourMinuteSecond.Enabled = true;

                if (numericUpDownHour.Value == 24)
                {
                    numericUpDownMinute.Value = 0;
                    numericUpDownSecond.Value = 0;
                    numericUpDownMinute.Enabled = false;
                    numericUpDownSecond.Enabled = false;
                }
                else
                {
                    numericUpDownMinute.Enabled = true;
                    numericUpDownSecond.Enabled = true;
                }
            }
            else
            {
                numericUpDownHour.Enabled = false;
                numericUpDownMinute.Enabled = false;
                numericUpDownSecond.Enabled = false;
                darkCheckBoxTomorrow.Enabled = false;

                labelHourMinuteSecond.Enabled = false;

            }
        }

        private void darkComboBoxPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void radioButtonPriceSpecific_CartCheckout_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonPriceSpecific_CartCheckout.Checked) ? false : true;
            if (radioButtonPriceSpecific_CartCheckout.Checked)
            {
                tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = true;
            }
            else
            {
                tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = false;
            }
        }

        private void radioButtonCheckOutCart_CheckedChanged(object sender, EventArgs e)
        {
            darkSectionPanelProductDetails.Enabled = (radioButtonCheckOutCart.Checked) ? false : true;
        }
    }
}
