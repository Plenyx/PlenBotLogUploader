using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;

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
        public static IDictionary<int, DiscordWebhookData> All => _All ?? (_All = new Dictionary<int, DiscordWebhookData>());

        /// <summary>
        /// Loads all webhooks from a specified file.
        /// </summary>
        /// <param name="file">The file from which the webhooks are loaded from</param>
        /// <returns>A dictionary with all webhooks</returns>
        public static IDictionary<int, DiscordWebhookData> FromTxtFile(string file)
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

        public static IDictionary<int, DiscordWebhookData> FromJsonFile(string filePath)
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
    }
}