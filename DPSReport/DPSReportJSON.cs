using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSON
    {
        public string id { get; set; }
        public string permalink { get; set; }
        public int uploadTime { get; set; }
        public int? encounterTime { get; set; }
        public string generator { get; set; }
        public DPSReportJSONevtc evtc { get; set; }
        public DPSReportJSONEncounter encounter { get; set; }
        public Dictionary<string, DPSReportJSONPlayers> players { get; set; } = new Dictionary<string, DPSReportJSONPlayers>();
        public string userid { get; set; }
    }
}
