using System.Collections.Generic;

namespace Shopee_Autobuy_Bot.Services.Profile
{
    public interface IProfileService
    {
        public bool DeleteProfile(string profileName);
        public List<Utililties.ProfileModel.Root> LoadProfiles();
        public void CreateNewProfile(Utililties.ProfileModel.Root profile);
        public void UpdateExistingProfile(Utililties.ProfileModel.Root profile);
        Utililties.ProfileModel.Root SelectedProfile { get; set; }
        string NewProfileName { get; set; }
        bool LoadProfile { get; set; }
        bool IsSavingProfile { get; set; }
    }
}
