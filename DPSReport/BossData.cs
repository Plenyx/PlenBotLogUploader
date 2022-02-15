using PlenBotLogUploader.AppSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// An object holding boss information
    /// </summary>
    public class BossData
    {
        /// <summary>
        /// ID of the encounter
        /// </summary>
        [JsonProperty("bossId")]
        public int BossId { get; set; }

        /// <summary>
        /// Name of the encounter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Twitch message when encounter is a success
        /// </summary>
        [JsonProperty("successMsg")]
        public string SuccessMsg { get; set; } = ApplicationSettings.Current.BossTemplate.SuccessText;

        /// <summary>
        /// Twitch message when encounter is a failure
        /// </summary>
        [JsonProperty("failMsg")]
        public string FailMsg { get; set; } = ApplicationSettings.Current.BossTemplate.FailText;

        /// <summary>
        /// Icon used for Discord webhooks
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; } = "";

        /// <summary>
        /// Type of the boss
        /// </summary>
        [JsonProperty("type")]
        public BossType Type { get; set; } = BossType.None;

        /// <summary>
        /// Indication if the encounter is an event
        /// </summary>
        [JsonProperty("isEvent")]
        public bool Event { get; set; } = false;

        /// <summary>
        /// Formats Twitch message based on the DPSReport's JSON response.
        /// </summary>
        /// <param name="reportJSON">DPSReport's JSON response</param>
        /// <returns>Formatted string</returns>
        public string TwitchMessageFormat(DPSReportJSON reportJSON, int pullCounter)
        {
            string format = (reportJSON.Encounter.Success ?? false) ? SuccessMsg : FailMsg;
            format = format.Replace("<boss>", reportJSON.ChallengeMode ? $"{Name} CM" : Name);
            format = format.Replace("<log>", reportJSON.Permalink);
            format = format.Replace("<pulls>", pullCounter.ToString());
            return format;
        }

        /// <summary>
        /// Creates an BossData object from a serialised format.
        /// </summary>
        /// <param name="savedFormat">string representing the object</param>
        /// <returns>deserilised object of BossData type</returns>
        public static BossData FromSavedFormat(string serialisedFormat)
        {
            try
            {
                string[] values = serialisedFormat.Split(new string[] { "<;>" }, StringSplitOptions.None);
                int.TryParse(values[0], out int bossId);
                int.TryParse(values[5], out int type);
                int.TryParse(values[6], out int isEvent);
                return new BossData() { BossId = bossId, Name = values[1], SuccessMsg = values[2], FailMsg = values[3], Icon = values[4], Type = (BossType)(type), Event = isEvent == 1 };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Deserializes a json string to BossData
        /// </summary>
        /// <param name="jsonString">The json to parse</param>
        /// <returns></returns>
        /// <exception cref="JsonException"></exception>
        public static IDictionary<int, BossData> ParseJsonString(string jsonString)
        {
            var bossCount = 1;

            var parsedJson = JsonConvert.DeserializeObject<IEnumerable<BossData>>(jsonString)
                             ?? throw new JsonException("Could not parse json to BossData");

            var result = parsedJson.Select(x => (Key: bossCount++, BossData: x))
                .ToDictionary(x => x.Key, x => x.BossData);

            return result;
        }
    }
}