using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopee_Autobuy_Bot.Utililties
{
    public class SettingsHelper
    {
        public class Element
        {
            public static ElementInfo.Root Elements { get; set; }
            public static ElementInfo.Root ParseElementSettingsFromFile()
            {
                if (!File.Exists(DirectoryProvider.ElementSettingsPath))
                    return null;
                var text = File.ReadAllText(DirectoryProvider.ElementSettingsPath, Encoding.UTF8);
                var deserialized = JsonConvert.DeserializeObject<ElementInfo.Root>(text);
                return deserialized;
            }
        }

        public class Profile
        {
            public static string Name { get; set; }
            public static bool SaveProfile { get; set; } = false;
            public static bool LoadProfile { get; set; } = false;

            public static Utililties.Profile.Root SelectedProfile { get; set; }

            public static List<Utililties.Profile.Root> ReadProfileToList()
            {
                if (!File.Exists(DirectoryProvider.ProfileSettingsPath)) return null;
                return JsonConvert.DeserializeObject<List<Utililties.Profile.Root>>(File.ReadAllText(DirectoryProvider.ProfileSettingsPath, Encoding.UTF8));
            }

            public static bool DeleteProfile(string profileName)
            {
                try
                {
                    var profileList = JsonConvert.DeserializeObject<List<Utililties.Profile.Root>>(File.ReadAllText(DirectoryProvider.ProfileSettingsPath, Encoding.UTF8));
                    profileList.RemoveAll(p => p.profile_name==profileName);
                    var json = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                    File.WriteAllText(DirectoryProvider.ProfileSettingsPath, json);
                }
                catch { return false; }

                return true;
            }

            public static void SaveNewProfile(Utililties.Profile.Root root)
            {
                string jsonString = JsonConvert.SerializeObject(root, Formatting.Indented);
                var profilePath = DirectoryProvider.ProfileSettingsPath;
                var profileIsExists = File.Exists(profilePath);

                if (!profileIsExists || (profileIsExists && File.ReadAllText(profilePath) == ""))
                    File.WriteAllText(profilePath, "[\n" + jsonString + "\n]");
                else
                {
                    var profiles = File.ReadAllText(profilePath);
                    var list = JsonConvert.DeserializeObject<List<Utililties.Profile.Root>>(profiles);
                    list.Add(root);
                    var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                    File.WriteAllText(profilePath, convertedJson);
                }
            }
        }

        public class BotConfiguration
        {

        }

    }
}
