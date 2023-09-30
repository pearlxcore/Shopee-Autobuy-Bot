using System.Collections.Generic;

namespace Shopee_Autobuy_Bot.Services.Profile
{
    public interface IProfileService
    {
        public bool DeleteProfile(string profileName);
        public List<Utililties.ProfileModel.Root> LoadProfiles();
        public void CreateProfile(Utililties.ProfileModel.Root root);
        Utililties.ProfileModel.Root SelectedProfile { get; set; }
        string Name { get; set; }
        bool LoadProfile { get; set; }
        bool SaveProfile { get; set; }
    }
}
