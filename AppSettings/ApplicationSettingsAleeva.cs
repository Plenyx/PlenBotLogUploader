using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings;

[JsonObject(MemberSerialization.OptIn)]
internal sealed class ApplicationSettingsAleeva
{

    private bool _isAuthorised;
    [JsonProperty("refreshToken")]
    internal string RefreshToken { get; set; } = "";

    [JsonProperty("refreshTokenExpire")]
    internal DateTime RefreshTokenExpire { get; set; } = DateTime.Now;

    internal bool Authorised
    {
        get => _isAuthorised;
        set
        {
            _isAuthorised = value;
            AuthorisedChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    internal string AccessToken { get; set; }

    internal DateTime AccessTokenExpire { get; set; }

    internal event EventHandler<EventArgs> AuthorisedChanged;
}
