using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlenBotLogUploader.Teams;

internal static class Teams
{
    internal static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\teams.json";

    /// <summary>
    ///     Returns the main dictionary with all webhook teams.
    /// </summary>
    /// <returns>A dictionary with all webhook teams</returns>
    internal static Dictionary<int, Team> All { get; private set; } = new();

    internal static Dictionary<int, Team> ResetDictionary()
    {
        All.Clear();
        All.Add(0, new Team
        {
            Name = "No team selected",
            MainCondition = new TeamCondition
            {
                Limiter = TeamLimiter.Exact,
                LimiterValue = 0,
            },
        });
        return All;
    }

    internal static void SaveToJson(Dictionary<int, Team> webhookData)
    {
        var jsonString = JsonConvert.SerializeObject(webhookData.Values, Formatting.Indented);

        File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
    }

    internal static Dictionary<int, Team> FromJsonFile(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);

        All = Team.FromJsonString(jsonData);

        return All;
    }
}
