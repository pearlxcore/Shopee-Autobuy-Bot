using System;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class Form4 : DarkUI.Forms.DarkForm
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void darkButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.DontShowThisAgainTipsPrompt = true;
            try
            {
                //if (darkCheckBoxTomorrow.Visible == false)
                //    Properties.Settings.Default.ShowTipsPromptDontShowThisAgain = true;
                //else
                //    Properties.Settings.Default.DontShowThisAgainTipsPrompt = darkCheckBoxTomorrow.Checked;

            }
            catch { }

        }
    }
}
