using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Utililties;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopee_Autobuy_Bot.Services.Profile
{
    public class ProfileService : IProfileService
    {
        public static bool _saveProfile { get; set; } = false;
        public bool IsSavingProfile { get => _saveProfile; set => _saveProfile = value; }

        public static bool _loadProfile { get; set; } = false;
        public bool LoadProfile { get => _loadProfile; set => _loadProfile = value; }


        public static Utililties.ProfileModel.Root _selectedProfile = new Utililties.ProfileModel.Root();

        public Utililties.ProfileModel.Root SelectedProfile
        {
            get => _selectedProfile; // Implement the getter
            set => _selectedProfile = value; // Implement the setter
        }

        private static string _name { get; set; }
        public string NewProfileName { get => _name; set => _name = value; }

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

        public void CreateNewProfile(Utililties.ProfileModel.Root profile)
        {
            string jsonString = JsonConvert.SerializeObject(profile, Formatting.Indented);
            var profilePath = DirectoryPaths.ProfileSettingsPath;
            var profileIsExists = File.Exists(profilePath);

            if (!profileIsExists || (profileIsExists && File.ReadAllText(profilePath) == ""))
                File.WriteAllText(profilePath, "[\n" + jsonString + "\n]");
            else
            {
                var profileString = File.ReadAllText(profilePath);
                var profileList = JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(profileString);
                profileList.Add(profile);
                var convertedJson = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                File.WriteAllText(profilePath, convertedJson);
            }
        }

        public void UpdateExistingProfile(ProfileModel.Root existingProfile)
        {
            string jsonString = JsonConvert.SerializeObject(existingProfile, Formatting.Indented);
            var profilePath = DirectoryPaths.ProfileSettingsPath;

            if (File.Exists(profilePath))
            {
                var profileString = File.ReadAllText(profilePath);
                var profileList = JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(profileString);

                bool matched = false;

                for (int i = 0; i < profileList.Count; i++)
                {
                    if (profileList[i].profile_name == existingProfile.profile_name)
                    {
                        profileList[i] = existingProfile;
                        matched = true;
                        break;
                    }
                }

                if (!matched)
                    profileList.Add(existingProfile);

                var convertedJson = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                File.WriteAllText(profilePath, convertedJson);
            }
            else
            {
                // If the file doesn't exist, create a new one with the profile
                File.WriteAllText(profilePath, "[\n" + jsonString + "\n]");
            }
        }


    }
}
