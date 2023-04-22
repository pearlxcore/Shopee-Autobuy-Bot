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
            public static ElementModel.Root ConstantElements { get; set; }
            public static ElementModel.Root LoadElementsFromFile()
            {
                if (!File.Exists(DirectoryPaths.ElementSettingsPath))
                    return null;
                var text = File.ReadAllText(DirectoryPaths.ElementSettingsPath, Encoding.UTF8);
                var deserialized = JsonConvert.DeserializeObject<ElementModel.Root>(text);
                return deserialized;
            }

            public static void SaveElementsToFile(ElementModel.Root rootElement)
            {
                string jsonString = JsonConvert.SerializeObject(rootElement, Formatting.Indented);
                var elementPath = DirectoryPaths.ElementSettingsPath;
                File.WriteAllText(elementPath, jsonString);
                SettingsHelper.Element.ConstantElements = rootElement;
            }
        }

        public class Profile
        {
            public static string Name { get; set; }
            public static bool SaveProfile { get; set; } = false;
            public static bool LoadProfile { get; set; } = false;

            public static Utililties.ProfileModel.Root SelectedProfile { get; set; }

            public static List<Utililties.ProfileModel.Root> LoadProfilesFromFile()
            {
                if (!File.Exists(DirectoryPaths.ProfileSettingsPath)) return null;
                return JsonConvert.DeserializeObject<List<Utililties.ProfileModel.Root>>(File.ReadAllText(DirectoryPaths.ProfileSettingsPath, Encoding.UTF8));
            }

            public static bool DeleteProfileFromFile(string profileName)
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

            public static void SaveNewProfileToFile(Utililties.ProfileModel.Root root)
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

        public class BotConfiguration
        {

        }

    }
}
