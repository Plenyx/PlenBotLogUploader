using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.DiscordApi;

internal static class DiscordWebhooks
{
    internal static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\discord_webhooks.json";

    /// <summary>
    ///     Returns the main dictionary with all webhooks.
    /// </summary>
    /// <returns>A dictionary with all webhooks</returns>
    internal static Dictionary<int, DiscordWebhookData> All { get; private set; } = new();

    private static Dictionary<int, DiscordWebhookData> FromJsonFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);

        All = DiscordWebhookData.FromJsonString(jsonData);

        return All;
    }

    internal static void SaveToJson(Dictionary<int, DiscordWebhookData> webhookData, string filePath)
    {
        var jsonString = JsonConvert.SerializeObject(webhookData.Values, Formatting.Indented);

        File.WriteAllText(filePath, jsonString, Encoding.UTF8);
    }

    internal static Dictionary<int, DiscordWebhookData> LoadDiscordWebhooks()
    {
        try
        {
            return File.Exists(JsonFileLocation) ? FromJsonFile(JsonFileLocation) : All;
        }
        catch
        {
            return All;
        }
    }
}
