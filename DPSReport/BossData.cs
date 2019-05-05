namespace PlenBotLogUploader.DPSReport
{
    public class BossData
    {
        public int BossId { get; }
        public string Name { get; }
        public string SuccessMsg { get; }
        public string FailMsg { get; }
        public string Icon { get; } = "";

        public BossData(int bossId, string name)
        {
            BossId = bossId;
            Name = name;
            SuccessMsg = $"{name} kill";
            FailMsg = $"{name} pull";
        }

        public BossData(int bossId, string name, string icon)
        {
            BossId = bossId;
            Name = name;
            SuccessMsg = $"{name} kill";
            FailMsg = $"{name} pull";
            Icon = icon;
        }

        public BossData(int bossId, string name, string success, string fail)
        {
            BossId = bossId;
            Name = name;
            if (success != "")
            {
                SuccessMsg = success;
            }
            else
            {
                SuccessMsg = $"{name} kill";
            }
            if (fail != "")
            {
                FailMsg = fail;
            }
            else
            {
                FailMsg = $"{name} pull";
            }
        }

        public BossData(int bossId, string name, string success, string fail, string icon)
        {
            BossId = bossId;
            Name = name;
            if (success != "")
            {
                SuccessMsg = success;
            }
            else
            {
                SuccessMsg = $"{name} kill";
            }
            if (fail != "")
            {
                FailMsg = fail;
            }
            else
            {
                FailMsg = $"{name} pull";
            }
            Icon = icon;
        }
    }
}
