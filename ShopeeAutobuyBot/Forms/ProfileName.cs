using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Utililties.BotProfileHelper;

namespace Shopee_Autobuy_Bot
{
    public partial class ProfileName : DarkUI.Forms.DarkForm
    {

        public ProfileName()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbProfileName.Text == string.Empty)
            {
                MessageBox.Show("Profile name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if profile name exist
            var profileList = ReadProfileToList();
            if (profileList != null)
            {
                var profileNameAlreadyExist = profileList.Any(x => x.profile_name==tbProfileName.Text);
                if (profileNameAlreadyExist)
                {
                    MessageBox.Show("Profile name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Utililties.BotProfileHelper.Name = tbProfileName.Text;
            SaveProfile = true;
            this.Close();
        }

        private void ProfileName_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

        }

        private void ProfileName_Load(object sender, EventArgs e)
        {
            if (!File.Exists("profile.setting"))
                File.Create("profile.setting").Dispose();
            SaveProfile = false;
        }
    }
}
