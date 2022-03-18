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

        /// <summary>
        /// Loads all webhook teams from a specified file.
        /// </summary>
        /// <param name="file">The file from which the webhook teams are loaded from</param>
        /// <returns>A dictionary with all webhook teams</returns>
        public static IDictionary<int, WebhookTeam> FromFile(string file)
        {
            var allTeams = new Dictionary<int, WebhookTeam>();
            if (allTeams.Count > 0)
            {
                ResetDictionary();
            }

            using var reader = new StreamReader(file);
            var line = reader.ReadLine(); // skip the first line
            while (!((line = reader.ReadLine()) is null))
            {
                var team = WebhookTeam.FromSavedFormat(line);
                allTeams.Add(team.ID, team);
            }

            _All = allTeams;
            return allTeams;
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
