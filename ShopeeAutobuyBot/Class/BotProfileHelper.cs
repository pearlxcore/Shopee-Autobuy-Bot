using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopee_Autobuy_Bot.Class
{
    public class BotProfileHelper
    {
        public static string Name { get; set; }
        public static bool SaveProfile { get; set; } = false;
        public static bool LoadProfile { get; set; } = false;

        public static BotProfileModel.Root SelectedProfile { get; set; }

        public static List<BotProfileModel.Root> ReadProfileToList()
        {
            return JsonConvert.DeserializeObject<List<BotProfileModel.Root>>(File.ReadAllText("profile.setting", Encoding.UTF8));
        }

        public static bool DeleteProfile(string profileName)
        {
            try
            {
                var profileList = JsonConvert.DeserializeObject<List<BotProfileModel.Root>>(File.ReadAllText("profile.setting", Encoding.UTF8));
                profileList.RemoveAll(p => p.profile_name==profileName);
                var json = JsonConvert.SerializeObject(profileList, Formatting.Indented);
                File.WriteAllText("profile.setting", json);
            }
            catch { return false; }

            return true;
        }
    }
}
