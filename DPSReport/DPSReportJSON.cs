using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// DPSReport response after a log has been uploaded
    /// </summary>
    public class DPSReportJSON
    {
        /// <summary>
        /// DPSReport ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }

        /// <summary>
        /// URL to DPSReport
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// Time when the log was uploaded to DPSReport
        /// </summary>
        [JsonProperty("uploadTime")]
        public int UploadTime { get; set; }

        /// <summary>
        /// Total time of the encounter, might be null
        /// </summary>
        [JsonProperty("encounterTime")]
        public int? EncounterTime { get; set; }

        /// <summary>
        /// Log tool used with processing the log on DPSReport
        /// </summary>
        [JsonProperty("generator")]
        public string Generator { get; set; }

        /// <summary>
        /// User ID when uploading multiple logs to DPSReport
        /// </summary>
        [JsonProperty("userid")]
        public string UserId { get; set; }

        /// <summary>
        /// EVTC sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("evtc")]
        public DPSReportJSONEVTC EVTC { get; set; }

        /// <summary>
        /// Encounter sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("encounter")]
        public DPSReportJSONEncounter Encounter { get; set; }

        /// <summary>
        /// Players sub-objects of DPSReport's response
        /// </summary>
        [JsonProperty("players")]
        public Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();

        /// <summary>
        /// ExtraJSON sub-objects of DPSReport's response
        /// </summary>
        public DPSReportJSONExtraJSON ExtraJSON { get; set; }

        /// <summary>
        /// Returns an error if one was encountered
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// the URL ID used in dps.report
        /// </summary>
        public string UrlId
        {
            get => Permalink?.Substring(Permalink.IndexOf("dps.report/") + 11) ?? "";
        }

        /// <summary>
        /// whether the enouncter was in challenge mode
        /// </summary>
        public bool ChallengeMode
        {
            get => ExtraJSON?.IsCM ?? false;
        }
    }
}
