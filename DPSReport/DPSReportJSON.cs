namespace PlenBotLogUploader.DPSReport
{
    class DPSReportJSON
    {
        public int id { get; set; }
        public string permalink { get; set; }
        public int uploadTime { get; set; }
        public int? encounterTime { get; set; }
        public string generator { get; set; }
        public DPSReportJSONEncounter encounter { get; set; }
        public DPSReportJSONevtc evtc { get; set; }
        public DPSReportJSONPlayers[] players { get; set; }
    }
}
