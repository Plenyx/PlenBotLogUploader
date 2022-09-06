using Newtonsoft.Json;
using System.Collections.Generic;

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

        public string DPSReportServerLink => DPSReportServer switch
        {
            DPSReportServer.A => "http://a.dps.report",
            DPSReportServer.B => "https://b.dps.report",
            _ => "https://dps.report",
        };

        [JsonProperty("dpsReportUserTokens")]
        public List<ApplicationSettingsUploadUserToken> DPSReportUserTokens { get; set; } = new List<ApplicationSettingsUploadUserToken>();

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
