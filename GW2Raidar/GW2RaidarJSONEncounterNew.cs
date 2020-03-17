using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Raidar
{
    public class GW2RaidarJSONEncounterNew
    {
        [JsonProperty("filename")]
        public string Filename { get; set; } = "";

        [JsonProperty("upload_id")]
        public int? UploadId { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; } = "";
    }
}
