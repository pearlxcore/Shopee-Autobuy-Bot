using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Utililties.SettingsHelper.Profile;

namespace Shopee_Autobuy_Bot
{
    public partial class SaveProfile : DarkUI.Forms.DarkForm
    {

        public SaveProfile()
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
            var profileList = LoadProfilesFromFile();
            if (profileList != null)
            {
                var profileNameAlreadyExist = profileList.Any(x => x.profile_name==tbProfileName.Text);
                if (profileNameAlreadyExist)
                {
                    MessageBox.Show("Profile name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            SettingsHelper.Profile.Name = tbProfileName.Text;
            SettingsHelper.Profile.SaveProfile = true;
            this.Close();
        }

        private void ProfileName_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

        }

        private void ProfileName_Load(object sender, EventArgs e)
        {
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
                File.Create(DirectoryPaths.ProfileSettingsPath).Dispose();
            SettingsHelper.Profile.SaveProfile = false;
        }
    }
}
