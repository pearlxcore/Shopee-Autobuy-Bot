using System;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }

        private void darkButton5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DontShowThisAgain = darkCheckBoxTomorrow.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Warning_Load(object sender, EventArgs e)
        {
            darkCheckBoxTomorrow.Checked = Properties.Settings.Default.DontShowThisAgain;
        }

        private void darkCheckBoxTomorrow_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}