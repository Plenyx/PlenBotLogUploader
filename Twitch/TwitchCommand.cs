using Newtonsoft.Json;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PlenBotLogUploader.Twitch;

[JsonObject(MemberSerialization.OptIn)]
internal class TwitchCommand : IListViewItemInfo<TwitchCommand>
{
    private string _command = "";

    [JsonProperty("enabled")]
    internal bool Enabled { get; set; }

    [JsonProperty("name")]
    internal string Name { get; set; } = "";

    [JsonProperty("isRegEx")]
    internal bool IsRegEx { get; set; }

    [JsonProperty("command")]
    internal string Command
    {
        get => _command;
        set
        {
            if (_command == value || value is null)
            {
                return;
            }
            _command = value;
            Regex = IsRegEx ? new Regex(_command, RegexOptions.CultureInvariant | RegexOptions.Multiline | RegexOptions.IgnoreCase) : null;
        }
    }

    internal Regex Regex { get; set; }

    [JsonProperty("response")]
    internal string Response { get; set; } = "";

    [JsonProperty("responseType")]
    internal TwitchResponseType ResponseType { get; set; } = TwitchResponseType.Plain;

    string IListViewItemInfo<TwitchCommand>.NameToDisplay => Name;

    string IListViewItemInfo<TwitchCommand>.TextToDisplay => Name;

    bool IListViewItemInfo<TwitchCommand>.CheckedToDisplay => Enabled;

    List<ListViewItemCustom<TwitchCommand>> IListViewItemInfo<TwitchCommand>.ConnectedItems { get; } = [];

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
        var prepend = "";
        if (ResponseType == TwitchResponseType.ReplyAt)
        {
            var builder = new StringBuilder();
            builder.Append('@').Append(receiver).Append(' ');
            prepend = builder.ToString();
        }
        if (string.IsNullOrWhiteSpace(response))
        {
            return null;
        }
        return prepend + response;
    }
}
