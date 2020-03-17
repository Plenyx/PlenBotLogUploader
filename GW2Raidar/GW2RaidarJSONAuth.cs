using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlenBotLogUploader.GW2Raidar
{
    public class GW2RaidarJSONAuth
    {
        [JsonProperty("non_field_errors")]
        public List<string> NonFieldErrors { get; set; } = new List<string>();

        [JsonProperty("token")]
        public string Token { get; set; } = "";
    }
}
