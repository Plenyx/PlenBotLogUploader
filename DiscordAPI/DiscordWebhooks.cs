using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.DiscordAPI
{
    class DiscordWebhooks
    {
        public static string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks.json";
        public static string TxtFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks.txt";
        public static string MigratedTxtFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks-migrated.txt";
        
        private static IDictionary<int, DiscordWebhookData> _All;
        /// <summary>
        /// Returns the main dictionary with all webhooks.
        /// </summary>
        /// <returns>A dictionary with all webhooks</returns>
        public static IDictionary<int, DiscordWebhookData> All => _All ??= new Dictionary<int, DiscordWebhookData>();

        private static IDictionary<int, DiscordWebhookData> FromTxtFile(string file)
        {
            var allWebhooks = new Dictionary<int, DiscordWebhookData>();
            if (allWebhooks.Count > 0)
            {
                allWebhooks.Clear();
            }

            using var reader = new StreamReader(file);
            var line = reader.ReadLine(); // skip the first line
            while (!((line = reader.ReadLine()) is null))
            {
                allWebhooks.Add(allWebhooks.Count + 1, DiscordWebhookData.FromSavedFormat(line));
            }

            _All = allWebhooks;
            return allWebhooks;
        }

        private static IDictionary<int, DiscordWebhookData> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _All = DiscordWebhookData.FromJsonString(jsonData);

            return All;
        }
        
        public static void SaveToJson(IDictionary<int, DiscordWebhookData> webhookData, string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(webhookData.Values, Formatting.Indented);

            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }

        public static IDictionary<int, DiscordWebhookData> LoadDiscordWebhooks()
        {
            try
            {
                if (File.Exists(TxtFileLocation))
                {
                    var webhooks = FromTxtFile(TxtFileLocation);
                    SaveToJson(webhooks, JsonFileLocation);
                    File.Move(TxtFileLocation, MigratedTxtFileLocation);
                    _All = webhooks;
                    return All;
                }
                else if (File.Exists(JsonFileLocation))
                {
                    return FromJsonFile(JsonFileLocation);
                }
                return All;
            }
            catch
            {
                return All;
            }
        }
    }
}
