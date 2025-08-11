using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings;

[JsonObject(MemberSerialization.OptIn)]
internal sealed class ApplicationSettingsAleeva
{

    private bool _isAuthorised;

    internal bool Authorised
    {
        get => _isAuthorised;
        set
        {
            _isAuthorised = value;
            AuthorisedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    [JsonProperty("apiKey")]
    internal string ApiKey { get; set; }

    internal event EventHandler<EventArgs> AuthorisedChanged;
}
