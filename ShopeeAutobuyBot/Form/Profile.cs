using Shopee_Autobuy_Bot.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Class.BotProfileHelper;


namespace Shopee_Autobuy_Bot
{
    public partial class Profile : DarkUI.Forms.DarkForm
    {
        private List<BotProfileModel.Root> profileList = new List<BotProfileModel.Root>();
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load_1(object sender, EventArgs e)
        {
            if (!File.Exists("profile.setting"))
                File.Create("profile.setting");
            profileList = ReadProfileToList();
            if (profileList == null)
            {
                MessageBox.Show("No profile found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            foreach (var profile in profileList)
            {
                darkComboBoxProfile.Items.Add(profile.profile_name);
            }
            LoadProfile = false;
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (profileList.Count == 0)
                return;

            var deleteProfile = DeleteProfile(darkComboBoxProfile.Text);
            if (!deleteProfile)
            {
                MessageBox.Show("Error occured when deleting profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            darkComboBoxProfile.Items.Remove(darkComboBoxProfile.Text);
            profileList.Clear();
            profileList = ReadProfileToList();
            MessageBox.Show("Profile deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            if (darkComboBoxProfile.Text == string.Empty)
            {
                MessageBox.Show("Select profile to load", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadProfile = true;
            this.Close();
        }

        private void darkComboBoxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProfile = new BotProfileModel.Root();
            foreach (var profile in profileList)
            {
                if (profile.profile_name == darkComboBoxProfile.Text)
                {
                    SelectedProfile = profile;
                    break;
                }
            }

            if (SelectedProfile == null)
            {
                MessageBox.Show("Failed to loaad profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
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

                tbCountdownHour.Text = SelectedProfile.ScheduleBot.hour.ToString();
                tbCountdownMinutes.Text = SelectedProfile.ScheduleBot.minute.ToString();
                tbCountdownSeconds.Text = SelectedProfile.ScheduleBot.second.ToString();

                tbPaymentMethod.Text = SelectedProfile.PaymentDetail.payment_type;
                darkTextBoxShopeePayPin.Text = SelectedProfile.PaymentDetail.shopeepay_pin;

                darkTextBoxProductLink.Text = SelectedProfile.ProductDetail.product_link;

                darkTextBoxVariationString.Text = SelectedProfile.ProductDetail.variant;
                tbQuality.Text = SelectedProfile.ProductDetail.quantity.ToString();

                darkCheckBoxHeadless.Checked = SelectedProfile.BotSettings.hide_browser;

                darkCheckBoxLogging.Checked = SelectedProfile.BotSettings.disable_logging;
                darkCheckBoxRefresh.Checked = SelectedProfile.BotSettings.autorefresh_webpage;
                darkCheckBoxRedeemCoin.Checked = SelectedProfile.Voucher_Coin.redeem_coin;
                tbRefreshSecond.Text = SelectedProfile.BotSettings.autorefresh_interval.ToString();
                tbTimeOut.Text = SelectedProfile.BotSettings.timeout.ToString();
                darkCheckBoxTestMode.Checked = SelectedProfile.BotSettings.test_mode;
                tbLast4Digit.Text = SelectedProfile.PaymentDetail.last_4_digit_card;
                tbBankType.Text = SelectedProfile.PaymentDetail.bank_type;
                darkCheckBoxClaimShopVoucher.Checked = SelectedProfile.Voucher_Coin.claim_shop_vc;
                darkCheckBoxRedeemShopeeVoucher.Checked = SelectedProfile.Voucher_Coin.redeeem_shopee_vc;
            }
            catch { }

        }
    }
}
