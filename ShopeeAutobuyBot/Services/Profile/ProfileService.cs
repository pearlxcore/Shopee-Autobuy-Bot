using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopee_Autobuy_Bot.Services.Profile
{
    public class ProfileService : IProfileService
    {
        public static bool _saveProfile { get; set; } = false;
        public bool SaveProfile { get => _saveProfile; set => _saveProfile = value; }

        public static bool _loadProfile { get; set; } = false;
        public bool LoadProfile { get => _loadProfile; set => _loadProfile = value; }


        public static Utililties.ProfileModel.Root _selectedProfile = new Utililties.ProfileModel.Root();

        public Utililties.ProfileModel.Root SelectedProfile
        {
            get => _selectedProfile; // Implement the getter
            set => _selectedProfile = value; // Implement the setter
        }

        private static string _name { get; set; }
        public string Name { get => _name; set => _name = value; }

        public List<Utililties.ProfileModel.Root> LoadProfiles()
        {
            if (!File.Exists(DirectoryPaths.ProfileSettingsPath))
                return null;
            string profileStr = File.ReadAllText(DirectoryPaths.ProfileSettingsPath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(profileStr);
        }

        public bool DeleteProfile(string profileName)
        {
            try
            {
                var profileList = JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(File.ReadAllText(DirectoryPaths.ProfileSettingsPath, Encoding.UTF8));
                profileList.RemoveAll(p => p.profile_name==profileName);
                var json = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                File.WriteAllText(DirectoryPaths.ProfileSettingsPath, json);
            }
            catch { return false; }

            return true;
        }

        public void CreateProfile(Utililties.ProfileModel.Root root)
        {
            string jsonString = JsonConvert.SerializeObject(root, Formatting.Indented);
            var profilePath = DirectoryPaths.ProfileSettingsPath;
            var profileIsExists = File.Exists(profilePath);

            if (!profileIsExists || (profileIsExists && File.ReadAllText(profilePath) == ""))
                File.WriteAllText(profilePath, "[\n" + jsonString + "\n]");
            else
            {
                var profiles = File.ReadAllText(profilePath);
                var list = JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(profiles);
                list.Add(root);
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(profilePath, convertedJson);
            }
        }
    }
}
