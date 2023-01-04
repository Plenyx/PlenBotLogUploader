using Newtonsoft.Json;
using static Hardstuck.GuildWars2.BuildCodes.V2.Static;

namespace PlenBotLogUploader.AppSettings
{
    internal sealed class ApplicationSettingsBuildCodes
    {
        [JsonProperty("demoteRunes")]
        internal bool DemoteRunes { get; set; } = true;

        [JsonProperty("demoteSigils")]
        internal bool DemoteSigils { get; set; } = true;

        [JsonProperty("compression")]
        internal CompressionOptions Compression { get; set; } = CompressionOptions.ALL;
    }
}
