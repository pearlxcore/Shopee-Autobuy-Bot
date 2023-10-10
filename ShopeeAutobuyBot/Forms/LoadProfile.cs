using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace Shopee_Autobuy_Bot
{
    public partial class LoadProfile : Form
    {
        private List<Utililties.ProfileModel.Root> profileList = new List<Utililties.ProfileModel.Root>();
        private readonly IProfileService _profileService;

        public LoadProfile(IProfileService profileService)
        {
            InitializeComponent();
            _profileService=profileService;
        }

        private void Profile_Load_1(object sender, EventArgs e)
        {
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
                File.Create(DirectoryPaths.ProfileSettingsPath);
            profileList = _profileService.LoadProfiles();
            if (profileList == null)
            {
                MessageBox.Show("No profile found", "LogInfo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
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
                    radioButtonPriceSpecificCARTCHECKOUT.Checked = true;
                if (_profileService.SelectedProfile.BuyingMode.mode.ToString() == "CartPage")
                    radioButtonCheckOutCart.Checked = true;

                darkCheckBoxTomorrow.Checked = _profileService.SelectedProfile.ScheduleBot.tomorrow;
                darkCheckBoxScheduleBot.Checked = _profileService.SelectedProfile.ScheduleBot.schedule;
                tbPriceSpecific.Text = _profileService.SelectedProfile.BuyingMode.below_specific_price;
                tbBelowSpecificPriceCARTCHECKOUTPrice.Text = _profileService.SelectedProfile.BuyingMode.cart_below_specific_price;
                checkBoxDesktopNotification.Checked = _profileService.SelectedProfile.BotSettings.desktop_notification;
                darkCheckBoxNotifyTelegram.Checked = _profileService.SelectedProfile.BotSettings.alert_telegram;

                tbCountdownHour.Text = _profileService.SelectedProfile.ScheduleBot.hour.ToString();
                tbCountdownMinutes.Text = _profileService.SelectedProfile.ScheduleBot.minute.ToString();
                tbCountdownSeconds.Text = _profileService.SelectedProfile.ScheduleBot.second.ToString();

                tbPaymentMethod.Text = _profileService.SelectedProfile.PaymentDetail.payment_method;
                darkTextBoxShopeePayPin.Text = _profileService.SelectedProfile.PaymentDetail.shopeepay_pin;

                darkTextBoxProductLink.Text = _profileService.SelectedProfile.ProductDetail.product_link;
                cbRandom.Checked = _profileService.SelectedProfile.ProductDetail.random_variant;
                cbVariantPreSelected.Checked = _profileService.SelectedProfile.ProductDetail.variant_preSelected;

                darkTextBoxVariationString.Text = _profileService.SelectedProfile.ProductDetail.variant;
                tbQuality.Text = _profileService.SelectedProfile.ProductDetail.quantity.ToString();


                darkCheckBoxLogging.Checked = _profileService.SelectedProfile.BotSettings.disable_logging;
                darkCheckBoxRefresh.Checked = _profileService.SelectedProfile.BotSettings.autorefresh_webpage;
                darkCheckBoxRedeemCoin.Checked = _profileService.SelectedProfile.Voucher_Coin.redeem_coin;
                tbRefreshSecond.Text = _profileService.SelectedProfile.BotSettings.autorefresh_interval.ToString();
                tbTimeOut.Text = _profileService.SelectedProfile.BotSettings.timeout.ToString();
                darkCheckBoxTestMode.Checked = _profileService.SelectedProfile.BotSettings.test_mode;
                tbLast4Digit.Text = _profileService.SelectedProfile.PaymentDetail.last_4_digit_card;
                tbBankType.Text = _profileService.SelectedProfile.PaymentDetail.bank_type;
                darkCheckBoxClaimShopVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.claim_shop_vc;
                darkCheckBoxRedeemShopeeVoucher.Checked = _profileService.SelectedProfile.Voucher_Coin.redeeem_shopee_vc;
            }
            catch { }

        }
    }
}
