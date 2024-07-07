using Newtonsoft.Json;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PlenBotLogUploader.Twitch
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class TwitchCommand : IListViewItemInfo<TwitchCommand>
    {
        [JsonProperty("enabled")]
        internal bool Enabled { get; set; } = false;

        [JsonProperty("name")]
        internal string Name { get; set; } = string.Empty;

        [JsonProperty("isRegEx")]
        internal bool IsRegEx { get; set; } = false;

        private string _command = string.Empty;
        [JsonProperty("command")]
        internal string Command
        {
            get
            {
                return _command;
            }
            set
            {
                if ((_command != value) && (value is not null))
                {
                    _command = value;
                    Regex = IsRegEx ? new Regex(_command, RegexOptions.CultureInvariant | RegexOptions.Multiline | RegexOptions.IgnoreCase) : null;
                }
            }
        }

        internal Regex Regex { get; set; } = null;

        [JsonProperty("response")]
        internal string Response { get; set; } = string.Empty;

        [JsonProperty("responseType")]
        internal TwitchResponseType ResponseType { get; set; } = TwitchResponseType.Plain;

        internal List<ListViewItemCustom<TwitchCommand>> _connectedItems = [];

        string IListViewItemInfo<TwitchCommand>.NameToDisplay => Name;

        string IListViewItemInfo<TwitchCommand>.TextToDisplay => Name;

        bool IListViewItemInfo<TwitchCommand>.CheckedToDisplay => Enabled;

        List<ListViewItemCustom<TwitchCommand>> IListViewItemInfo<TwitchCommand>.ConnectedItems => _connectedItems;

        internal string FormattedResponse(string receiver, Dictionary<string, string> valuesToChange)
        {
            var response = Response;
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            foreach (var kvp in valuesToChange)
            {
                response = response.Replace(kvp.Key, kvp.Value);
            }
            var prepend = string.Empty;
            if (ResponseType == TwitchResponseType.ReplyAt)
            {
                var builder = new StringBuilder();
                builder.Append('@').Append(receiver).Append(':').Append(' ');
                prepend = builder.ToString();
            }
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return prepend + response;
        }
    }
}
