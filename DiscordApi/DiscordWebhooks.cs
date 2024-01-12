using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.DiscordApi
{
    internal static class DiscordWebhooks
    {
        internal static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks.json";

        private static IDictionary<int, DiscordWebhookData> _all = new Dictionary<int, DiscordWebhookData>();
        /// <summary>
        /// Returns the main dictionary with all webhooks.
        /// </summary>
        /// <returns>A dictionary with all webhooks</returns>
        internal static IDictionary<int, DiscordWebhookData> All => _all;

        private static IDictionary<int, DiscordWebhookData> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _all = DiscordWebhookData.FromJsonString(jsonData);

            return All;
        }

        internal static void SaveToJson(IDictionary<int, DiscordWebhookData> webhookData, string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(webhookData.Values, Formatting.Indented);

            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }

        internal static IDictionary<int, DiscordWebhookData> LoadDiscordWebhooks()
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
