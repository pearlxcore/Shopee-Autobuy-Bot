using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class SaveProfile : Form
    {
        private readonly IProfileService _profileService;

        public SaveProfile(IProfileService profileService)
        {
            InitializeComponent();
            _profileService=profileService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbProfileName.Text == string.Empty)
            {
                MessageBox.Show("Profile name cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check if profile name exist
            var profileList = _profileService.LoadProfiles();
            if (profileList != null)
            {
                var profileNameAlreadyExist = profileList.Any(x => x.profile_name==tbProfileName.Text);
                if (profileNameAlreadyExist)
                {
                    MessageBox.Show("Profile name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _profileService.Name = tbProfileName.Text;
            _profileService.SaveProfile = true;
            this.Close();
        }

        private void ProfileName_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {

        }

        private void ProfileName_Load(object sender, EventArgs e)
        {
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
                File.Create(DirectoryPaths.ProfileSettingsPath).Dispose();
            _profileService.SaveProfile = false;
        }
    }
}
