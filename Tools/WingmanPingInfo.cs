using Newtonsoft.Json;

namespace PlenBotLogUploader.Tools;

public sealed class WingmanPingInfo
{
    [JsonProperty("filePath")]
    internal string FilePath { get; set; }
    
    [JsonProperty("triggerID")]
    internal int TriggerId { get; set; }
    
    [JsonProperty("uploadedBy")]
    internal string UploadedBy { get; set; }
}
