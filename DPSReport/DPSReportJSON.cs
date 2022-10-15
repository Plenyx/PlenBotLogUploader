using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// DPSReport response after a log has been uploaded
    /// </summary>
    internal sealed class DPSReportJSON
    {
        /// <summary>
        /// DPSReport ID
        /// </summary>
        [JsonProperty("id")]
        internal string ID { get; set; }

        /// <summary>
        /// URL to DPSReport
        /// </summary>
        [JsonProperty("permalink")]
        internal string Permalink { get; set; }

        /// <summary>
        /// URL to DPSReport using server configured in settings
        /// </summary>
        internal string ConfigAwarePermalink => $"{ApplicationSettings.Current.Upload.DPSReportServerLink}/{UrlId}";

        /// <summary>
        /// Time when the log was uploaded to DPSReport
        /// </summary>
        [JsonProperty("uploadTime")]
        internal int UploadTime { get; set; }

        /// <summary>
        /// Total time of the encounter, might be null
        /// </summary>
        [JsonProperty("encounterTime")]
        internal int? EncounterTime { get; set; }

        /// <summary>
        /// Log tool used with processing the log on DPSReport
        /// </summary>
        [JsonProperty("generator")]
        internal string Generator { get; set; }

        /// <summary>
        /// User token used during the upload to DPSReport
        /// </summary>
        [JsonProperty("userToken")]
        internal string UserToken { get; set; }

        /// <summary>
        /// EVTC sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("evtc")]
        internal DPSReportJSONEVTC EVTC { get; set; }

        /// <summary>
        /// Encounter sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("encounter")]
        internal DPSReportJSONEncounter Encounter { get; set; }

        /// <summary>
        /// Players sub-objects of DPSReport's response
        /// </summary>
        [JsonProperty("players")]
        internal Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();

        /// <summary>
        /// Report sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("report")]
        internal DPSReportJSONReport Report { get; set; }

        /// <summary>
        /// ExtraJSON sub-objects of DPSReport's response
        /// </summary>
        internal DPSReportJSONExtraJSON ExtraJSON { get; set; }

        /// <summary>
        /// Returns an error if one was encountered
        /// </summary>
        [JsonProperty("error")]
        internal string Error { get; set; }

        /// <summary>
        /// the URL ID used in dps.report
        /// </summary>
        internal string UrlId => Permalink?.Substring(Permalink.IndexOf("dps.report/") + 11) ?? "";

        /// <summary>
        /// whether the enouncter was in challenge mode
        /// </summary>
        internal bool ChallengeMode => (ExtraJSON?.IsCM ?? false) ? true : (Encounter?.IsCM ?? false);
    }
}
