using Newtonsoft.Json;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONExtraJSON
    {
        [JsonProperty("eliteInsightsVersion")]
        public string EliteInsightsVersion { get; set; }

        [JsonProperty("recordedBy")]
        public string RecordedBy { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("triggerID")]
        public int TriggerID { get; set; }

        [JsonProperty("fightName")]
        public string FightName { get; set; }

        [JsonProperty("gw2Build")]
        public int GW2Build { get; set; }

        [JsonProperty("fightIcon")]
        public string FightIcon { get; set; }
    }
}
