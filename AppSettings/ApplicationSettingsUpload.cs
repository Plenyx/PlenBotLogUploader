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

        [JsonProperty("dpsReportUsertokenEnabled")]
        public bool DPSReportUsertokenEnabled { get; set; } = false;

        [JsonProperty("dpsReportUsertoken")]
        public string DPSReportUsertoken { get; set; } = "";

        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("ignoreFileSize")]
        public bool IgnoreFileSize { get; set; } = false;

        [JsonProperty("postLogsToTwitch")]
        public bool PostLogsToTwitch { get; set; } = true;

        [JsonProperty("postLogsTwitchOnlySuccess")]
        public bool PostLogsToTwitchOnlySuccess { get; set; } = true;
    }
}
