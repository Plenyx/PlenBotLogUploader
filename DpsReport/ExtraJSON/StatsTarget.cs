﻿using Newtonsoft.Json;

namespace PlenBotLogUploader.DpsReport.ExtraJson;

internal sealed class StatsTarget
{
    [JsonProperty("killed")]
    internal int Killed { get; set; }

    [JsonProperty("downed")]
    internal int Downed { get; set; }
}
