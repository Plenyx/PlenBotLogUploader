using System;
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
        public string Id { get; set; }

        /// <summary>
        /// URL to DPSReport
        /// </summary>
        public string Permalink { get; set; }

        /// <summary>
        /// Time when the log was uploaded to DPSReport
        /// </summary>
        public int UploadTime { get; set; }

        /// <summary>
        /// Total time of the encounter, might be null
        /// </summary>
        public int? EncounterTime { get; set; }

        /// <summary>
        /// Tool which processed the log on DPSReport
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// User ID when uploading multiple logs to DPSReport
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// EVTC sub-object of DPSReport's response
        /// </summary>
        public DPSReportJSONEvtc Evtc { get; set; }

        /// <summary>
        /// Encounter sub-object of DPSReport's response
        /// </summary>
        public DPSReportJSONEncounter Encounter { get; set; }

        /// <summary>
        /// Players sub-objects of DPSReport's response
        /// </summary>
        public Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();

        /// <summary>
        /// ExtraJSON sub-objects of DPSReport's response
        /// </summary>
        public DPSReportJSONExtraJSON ExtraJSON { get; set; }

        /// <summary>
        /// Returns an error if one was encountered
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// the URL ID used in dps.report
        /// </summary>
        public string UrlId
        {
            get
            {
                return Permalink.Substring(Permalink.IndexOf("dps.report/") + 11);
            }
        }

        /// <summary>
        /// whether the enouncter was in challenge mode (works only for raids and certain fractals)
        /// </summary>
        public bool ChallengeMode
        {
            get
            {
                return ExtraJSON?.FightName.EndsWith(" CM") ?? false;
            }
        }
    }
}
