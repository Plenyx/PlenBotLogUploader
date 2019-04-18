namespace PlenBotLogUploader.DPSReport
{
    public class BossData
    {
        public int BossId { get; }
        public string Name { get; }
        public string SuccessMsg { get; } = "kill";
        public string FailMsg { get; } = "pull";

        public BossData(int bossId, string name)
        {
            BossId = bossId;
            Name = name;
        }

        public BossData(int bossId, string name, string success, string fail)
        {
            BossId = bossId;
            Name = name;
            SuccessMsg = success;
            FailMsg = fail;
        }
    }
}
