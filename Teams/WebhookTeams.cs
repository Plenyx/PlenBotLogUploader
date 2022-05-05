using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.Teams
{
    public static class WebhookTeams
    {
        public static string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\webhook_teams.json";
        public static string TxtFileLocation = $@"{ApplicationSettings.LocalDir}\webhook_teams.txt";
        public static string MigratedTxtFileLocation = $@"{ApplicationSettings.LocalDir}\webhook_teams-migrated.txt";

        private static IDictionary<int, WebhookTeam> _All;

        /// <summary>
        /// Returns the main dictionary with all webhook teams.
        /// </summary>
        /// <returns>A dictionary with all webhook teams</returns>
        public static IDictionary<int, WebhookTeam> All => _All ??= new Dictionary<int, WebhookTeam>();

        public static IDictionary<int, WebhookTeam> ResetDictionary()
        {
            All.Clear();
            All.Add(0, new WebhookTeam() { Name = "No team selected" });
            return All;
        }

        public static void SaveToJson(IDictionary<int, WebhookTeam> weebhookData)
        {
            var jsonString = JsonConvert.SerializeObject(weebhookData.Values, Formatting.Indented);

            File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
        }

        public static IDictionary<int, WebhookTeam> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _All = WebhookTeam.FromJsonString(jsonData);

            return All;
        }
    }
}
