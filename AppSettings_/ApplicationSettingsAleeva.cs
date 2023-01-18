using Newtonsoft.Json;
using System;

namespace PlenBotLogUploader.AppSettings
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class ApplicationSettingsAleeva
    {
        [JsonProperty("refreshToken")]
        internal string RefreshToken { get; set; } = "";

        [JsonProperty("refreshTokenExpire")]
        internal DateTime RefreshTokenExpire { get; set; } = DateTime.Now;

        internal event EventHandler<EventArgs> AuthorisedChanged;

        private bool _isAuthorised = false;

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
    }
}
