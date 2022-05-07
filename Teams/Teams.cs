using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.Teams
{
    public static class Teams
    {
        public static string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\teams.json";

        private static IDictionary<int, Team> _All;

        /// <summary>
        /// Returns the main dictionary with all webhook teams.
        /// </summary>
        /// <returns>A dictionary with all webhook teams</returns>
        public static IDictionary<int, Team> All => _All ??= new Dictionary<int, Team>();

        public static IDictionary<int, Team> ResetDictionary()
        {
            All.Clear();
            All.Add(0, new Team() { Name = "No team selected", MainCondition = new TeamCondition() { Limiter = TeamLimiter.Exact, LimiterValue = 0 } });
            return All;
        }

        public static void SaveToJson(IDictionary<int, Team> weebhookData)
        {
            var jsonString = JsonConvert.SerializeObject(weebhookData.Values, Formatting.Indented);

            File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
        }

        public static IDictionary<int, Team> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _All = Team.FromJsonString(jsonData);

            return All;
        }
    }
}
