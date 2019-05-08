namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSON : DPSReportJSONMinimal
    {
        public string Id { get; set; }
        public int UploadTime { get; set; }
        public int? EncounterTime { get; set; }
        public string Generator { get; set; }
        public string Userid { get; set; }
    }
}
