using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsUpload
    {
        [JsonProperty("anonymous")]
        internal bool Anonymous { get; set; } = false;

        [JsonProperty("detailedWvW")]
        internal bool DetailedWvW { get; set; } = false;

        [JsonProperty("dpsReportServer")]
        internal DPSReportServer DPSReportServer { get; set; } = DPSReportServer.Main;

        internal string DPSReportServerLink => DPSReportServer switch
        {
            DPSReportServer.A => "http://a.dps.report",
            DPSReportServer.B => "https://b.dps.report",
            _ => "https://dps.report",
        };

        [JsonProperty("dpsReportUserTokens")]
        internal List<ApplicationSettingsUploadUserToken> DPSReportUserTokens { get; set; } = new();

        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = true;

        [JsonProperty("postLogsToTwitch")]
        internal bool PostLogsToTwitch { get; set; } = true;

        [JsonProperty("postLogsTwitchOnlySuccess")]
        internal bool PostLogsToTwitchOnlySuccess { get; set; } = true;

        [JsonProperty("saveToCSVEnabled")]
        internal bool SaveToCSVEnabled { get; set; } = true;
    }
}
