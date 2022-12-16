﻿using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;

namespace PlenBotLogUploader.DpsReport
{
    /// <summary>
    /// DPSReport response after a log has been uploaded
    /// </summary>
    internal sealed class DpsReportJson
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
        internal DpsReportJsonEvtc Evtc { get; set; }

        /// <summary>
        /// Encounter sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("encounter")]
        internal DpsReportJsonEncounter Encounter { get; set; }

        /// <summary>
        /// Players sub-objects of DPSReport's response
        /// </summary>
        [JsonProperty("players")]
        internal Dictionary<string, DpsReportJsonPlayers> Players { get; set; } = new();

        /// <summary>
        /// Report sub-object of DPSReport's response
        /// </summary>
        [JsonProperty("report")]
        internal DpsReportJsonReport Report { get; set; }

        /// <summary>
        /// ExtraJSON sub-objects of DPSReport's response
        /// </summary>
        internal DpsReportJsonExtraJson ExtraJson { get; set; }

        /// <summary>
        /// Returns an error if one was encountered
        /// </summary>
        [JsonProperty("error")]
        internal string Error { get; set; }

        /// <summary>
        /// the URL ID used in dps.report
        /// </summary>
        internal string UrlId => (!string.IsNullOrWhiteSpace(Permalink) && (Permalink.IndexOf("dps.report/") != -1)) ? Permalink[(Permalink.IndexOf("dps.report/") + 11)..] : string.Empty;

        /// <summary>
        /// whether the enouncter was in challenge mode
        /// </summary>
        internal bool ChallengeMode => (ExtraJson?.IsCM ?? false) || (Encounter?.IsCM ?? false);
    }
}
