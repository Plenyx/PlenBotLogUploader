using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONMinimal
    {
        public string Permalink { get; set; }
        public DPSReportJSONEvtc Evtc { get; set; }
        public DPSReportJSONEncounter Encounter { get; set; }
        public Dictionary<string, DPSReportJSONPlayers> Players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();

        public string GetUrlId() => Permalink.Substring(Permalink.IndexOf("dps.report/")+11);
    }
}
