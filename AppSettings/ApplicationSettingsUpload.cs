using Newtonsoft.Json;
using System.Collections.Generic;

namespace PlenBotLogUploader.AppSettings;

internal sealed class ApplicationSettingsUpload
{
    [JsonProperty("anonymous")]
    internal bool Anonymous { get; set; }

    [JsonProperty("detailedWvW")]
    internal bool DetailedWvw { get; set; }

    [JsonProperty("dpsReportServer")]
    internal DpsReportServer DpsReportServer { get; set; } = DpsReportServer.B;

    [JsonProperty("uploadToWingman")]
    internal bool UploadToWingman { get; set; }

    internal string DpsReportServerLink => DpsReportServer switch
    {
        DpsReportServer.A => "http://a.dps.report",
        DpsReportServer.B => "https://b.dps.report",
        _ => "https://dps.report",
    };

    [JsonProperty("dpsReportUserTokens")]
    internal List<ApplicationSettingsUploadUserToken> DpsReportUserTokens { get; set; } = [];

    [JsonProperty("enabled")]
    internal bool Enabled { get; set; } = true;

    [JsonProperty("postLogsToTwitch")]
    internal bool PostLogsToTwitch { get; set; } = true;

    [JsonProperty("postLogsTwitchOnlySuccess")]
    internal bool PostLogsToTwitchOnlySuccess { get; set; } = true;

    [JsonProperty("postLogsToTwitchOnlyWithStreamingSoftware")]
    internal bool PostLogsToTwitchOnlyWithStreamingSoftware { get; set; } = true;

    [JsonProperty("saveToCSVEnabled")]
    internal bool SaveToCsvEnabled { get; set; } = true;
}
