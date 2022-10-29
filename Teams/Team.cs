﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PlenBotLogUploader.Teams
{
    internal sealed class Team
    {
        /// <summary>
        /// ID of the team, for internal use
        /// </summary>
        [JsonProperty("id")]
        internal int ID { get; set; }

        /// <summary>
        /// Name of the webhook team
        /// </summary>
        [JsonProperty("name")]
        internal string Name { get; set; }

        /// <summary>
        /// What condition to use to resolve the team
        /// </summary>
        [JsonProperty("condition")]
        internal TeamCondition MainCondition { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => Name;

        internal bool IsSatisfied(DPSReport.DPSReportJSONExtraJSON extraJSON) => MainCondition?.IsSatisfied(extraJSON) ?? false;

        internal static IDictionary<int, Team> FromJsonString(string jsonData)
        {
            var parsedData = JsonConvert.DeserializeObject<IEnumerable<Team>>(jsonData)
                             ?? throw new JsonException("Could not parse json to WebhookData");

            var result = parsedData.Select(x => (Key: x.ID, TeamData: x))
                .ToDictionary(x => x.Key, x => x.TeamData);

            foreach (var team in result.Values)
            {
                team.MainCondition?.SetUp(null);
            }

            return result;
        }

        internal bool Equals(Team other) => (ID == other.ID) && (Name == other.Name);
    }
}
