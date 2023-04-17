using System;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class BotSettings : DarkUI.Forms.DarkForm
    {
        public BotSettings()
        {
            InitializeComponent();
        }

        private void darkButton5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Logging = darkCheckBoxLogging.Checked;
            Properties.Settings.Default.Headless = darkCheckBoxHeadless.Checked;
            Properties.Settings.Default.DisableImageExtension = darkCheckBoxDisableImageExtension.Checked;
            Properties.Settings.Default.Refresh = darkCheckBoxRefresh.Checked;
            Properties.Settings.Default.PlaySound = darkCheckBoxPlaySound.Checked;
            Properties.Settings.Default.TestMode = darkCheckBoxTestMode.Checked;
            Properties.Settings.Default.RefreshSeconds = Convert.ToInt32(darkNumericUpDownRefreshSeconds.Value);
            Shopee_Autobuy_Bot.Helper.Shopee.TimeOut = Properties.Settings.Default.TimeOut = Convert.ToInt32(darkNumericUpDownTimeOut.Value);
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void BotSettings_Load(object sender, EventArgs e)
        {
            darkCheckBoxPlaySound.Checked = Properties.Settings.Default.PlaySound;
            darkCheckBoxRefresh.Checked = Properties.Settings.Default.Refresh;
            darkCheckBoxHeadless.Checked = Properties.Settings.Default.Headless;
            darkCheckBoxLogging.Checked = Properties.Settings.Default.Logging;
            darkCheckBoxDisableImageExtension.Checked = Properties.Settings.Default.DisableImageExtension;
            darkCheckBoxTestMode.Checked = Properties.Settings.Default.TestMode;
            darkNumericUpDownTimeOut.Value = Properties.Settings.Default.TimeOut;
            darkNumericUpDownRefreshSeconds.Value = Properties.Settings.Default.RefreshSeconds;
        }

        private void darkCheckBoxDisableImageExtension_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart program for the changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.Save();
        }

        private void darkCheckBoxHeadless_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restart program for the changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Properties.Settings.Default.Save();
        }
    }
}
