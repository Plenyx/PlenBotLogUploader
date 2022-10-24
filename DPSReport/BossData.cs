using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// An object holding boss information
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class BossData
    {
        /// <summary>
        /// ID of the encounter
        /// </summary>
        [JsonProperty("bossId")]
        internal int BossId { get; set; }

        /// <summary>
        /// Name of the encounter
        /// </summary>
        [JsonProperty("name")]
        internal string Name { get; set; }

        /// <summary>
        /// Internal description of the boss, only visible in the Uploader app
        /// </summary>
        [JsonProperty("internalDescription")]
        internal string InternalDescription { get; set; } = string.Empty;

        /// <summary>
        /// Twitch message when encounter is a success
        /// </summary>
        [JsonProperty("successMsg")]
        internal string SuccessMsg { get; set; } = ApplicationSettings.Current.BossTemplate.SuccessText;

        /// <summary>
        /// Twitch message when encounter is a failure
        /// </summary>
        [JsonProperty("failMsg")]
        internal string FailMsg { get; set; } = ApplicationSettings.Current.BossTemplate.FailText;

        /// <summary>
        /// Icon used for Discord webhooks
        /// </summary>
        [JsonProperty("icon")]
        internal string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Type of the boss
        /// </summary>
        [JsonProperty("type")]
        internal BossType Type { get; set; } = BossType.None;

        /// <summary>
        /// Indication if the encounter is an event
        /// </summary>
        [JsonProperty("isEvent")]
        internal bool Event { get; set; } = false;

        /// <summary>
        /// Returns the name the object is using in the Uploader UI
        /// </summary>
        internal string UIName => $"{Name}{(!string.IsNullOrWhiteSpace(InternalDescription) ? $" [{InternalDescription}]" : string.Empty)}";

        /// <summary>
        /// Formats Twitch message based on the DPSReport's JSON response.
        /// </summary>
        /// <param name="reportJSON">DPSReport's JSON response</param>
        /// <returns>Formatted string</returns>
        internal string TwitchMessageFormat(DPSReportJSON reportJSON, int pullCounter)
        {
            var format = (reportJSON.Encounter.Success ?? false) ? SuccessMsg : FailMsg;
            format = format.Replace("<boss>", reportJSON.ChallengeMode ? $"{Name} CM" : Name);
            format = format.Replace("<log>", reportJSON.ConfigAwarePermalink);
            format = format.Replace("<pulls>", pullCounter.ToString());
            format = (!(reportJSON.ExtraJSON is null) && !(reportJSON.ExtraJSON.PossiblyLastTarget is null))
                ? format.Replace("<percent>", $"{reportJSON.ExtraJSON.PossiblyLastTarget.Name} ({Math.Round(reportJSON.ExtraJSON.PossiblyLastTarget.RemainingHealthPercent, 2)}%)")
                : format.Replace("<percent>", string.Empty);
            return format;
        }

        /// <summary>
        /// Deserializes a json string to BossData
        /// </summary>
        /// <param name="jsonString">The json to parse</param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        internal static IDictionary<int, BossData> ParseJsonString(string jsonString)
        {
            var bossCount = 1;

            var parsedJson = JsonConvert.DeserializeObject<IEnumerable<BossData>>(jsonString)
                             ?? throw new JsonException("Could not parse json to BossData");

            var result = parsedJson
                .Select(x => (Key: bossCount++, BossData: x))
                .ToDictionary(x => x.Key, x => x.BossData);

            return result;
        }
    }
}
