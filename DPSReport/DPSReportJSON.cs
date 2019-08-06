using System;
using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSON
    {
        // private
        private string _error;

        //public
        public string Id { get; set; }
        public string Permalink { get; set; }
        public int UploadTime { get; set; }
        public int? EncounterTime { get; set; }
        public string Generator { get; set; }
        public string Userid { get; set; }
        public DPSReportJSONEvtc Evtc { get; set; }
        public DPSReportJSONEncounter Encounter { get; set; }
        public Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();
        public DPSReportJSONExtraJSON ExtraJSON { get; set; }
        public string Error
        {
            get
            {
                if (!String.IsNullOrEmpty(_error))
                {
                    return "";
                }
                return _error;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    _error = value;
                }
            }
        }
        public string UrlId
        {
            get
            {
                return Permalink.Substring(Permalink.IndexOf("dps.report/") + 11);
            }
        }
        public bool ChallengeMode
        {
            get
            {
                return ExtraJSON?.FightName.EndsWith(" CM") ?? false;
            }
        }
    }
}
