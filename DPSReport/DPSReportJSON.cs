using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSON
    {
        public string Id { get; set; }
        public string Permalink { get; set; }
        public int UploadTime { get; set; }
        public int? EncounterTime { get; set; }
        public string Generator { get; set; }
        public string Userid { get; set; }
        public DPSReportJSONEvtc Evtc { get; set; }
        public DPSReportJSONEncounter Encounter { get; set; }
        public Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();

        public string GetUrlId() => Permalink.Substring(Permalink.IndexOf("dps.report/") + 11);
    }
}
