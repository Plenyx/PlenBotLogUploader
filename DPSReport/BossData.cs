namespace PlenBotLogUploader.DPSReport
{
    public class BossData
    {
        public int BossId { get; set; }
        public string Name { get; set; }
        public string SuccessMsg { get; set; } = "<boss> kill: <log>";
        public string FailMsg { get; set; } = "<boss> pull: <log>";
        public string Icon { get; set; } = "";
    }
}
