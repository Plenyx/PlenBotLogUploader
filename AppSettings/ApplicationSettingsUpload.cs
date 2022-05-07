using Newtonsoft.Json;

namespace PlenBotLogUploader.AppSettings
{
    public class ApplicationSettingsUpload
    {
        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; } = false;

        [JsonProperty("detailedWvW")]
        public bool DetailedWvW { get; set; } = false;

        [JsonProperty("dpsReportServer")]
        public DPSReportServer DPSReportServer { get; set; } = DPSReportServer.Main;

        public string DPSReportServerLink
        {
            get
            {
                switch (DPSReportServer)
                {
                    case DPSReportServer.A:
                        return "http://a.dps.report";
                    case DPSReportServer.B:
                        return "https://b.dps.report";
                    default:
                        return "https://dps.report";
                }
            }
        }

        [JsonProperty("dpsReportUsertokenEnabled")]
        public bool DPSReportUsertokenEnabled { get; set; } = false;

        [JsonProperty("dpsReportUsertoken")]
        public string DPSReportUsertoken { get; set; } = string.Empty;

        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("postLogsToTwitch")]
        public bool PostLogsToTwitch { get; set; } = true;

        [JsonProperty("postLogsTwitchOnlySuccess")]
        public bool PostLogsToTwitchOnlySuccess { get; set; } = true;

        [JsonProperty("saveToCSVEnabled")]
        public bool SaveToCSVEnabled { get; set; } = true;
    }
}
