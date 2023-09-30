using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Models;
using System.IO;
using System.Text;

namespace Shopee_Autobuy_Bot.Utililties
{
    public class SettingsHelper
    {
        public class Element
        {
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
                AutoBuyInfo.ConstantElements = rootElement;
            }
        }

        public class BotConfiguration
        {

        }

    }
}
