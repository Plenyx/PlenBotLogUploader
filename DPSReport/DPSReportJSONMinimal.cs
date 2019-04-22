namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONMinimal
    {
        public string Permalink { get; set; }
        public DPSReportJSONEvtc Evtc { get; set; }
        public DPSReportJSONEncounter Encounter { get; set; }

        public string GetUrlId() => Permalink.Substring(Permalink.IndexOf("dps.report/")+11);
    }
}
