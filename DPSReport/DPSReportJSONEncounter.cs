namespace PlenBotLogUploader.DPSReport
{
    public class DPSReportJSONEncounter
    {
        public bool? success { get; set; }
        public int? duration { get; set; }
        public int? compDps { get; set; }
        public int? numberOfPlayers { get; set; }
        public int? numberOfGroups { get; set; }
        public int bossId { get; set; }
        public string boss { get; set; }
        public int? gw2Build { get; set; }
    }
}
