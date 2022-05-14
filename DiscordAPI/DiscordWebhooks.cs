using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.DiscordAPI
{
    class DiscordWebhooks
    {
        public static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks.json";
        
        private static IDictionary<int, DiscordWebhookData> _All;
        /// <summary>
        /// Returns the main dictionary with all webhooks.
        /// </summary>
        /// <returns>A dictionary with all webhooks</returns>
        public static IDictionary<int, DiscordWebhookData> All => _All ??= new Dictionary<int, DiscordWebhookData>();

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
                if (File.Exists(JsonFileLocation))
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
