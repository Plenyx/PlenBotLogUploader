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
        internal DpsReportServer DPSReportServer { get; set; } = DpsReportServer.Main;

        internal string DPSReportServerLink => DPSReportServer switch
        {
            DpsReportServer.A => "http://a.dps.report",
            DpsReportServer.B => "https://b.dps.report",
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
