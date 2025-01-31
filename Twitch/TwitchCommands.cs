using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlenBotLogUploader.Twitch;

internal static class TwitchCommands
{
    private static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\twitch_commands.json";

    private static readonly List<TwitchCommand> DefaultCommands =
    [
        new()
        {
            Enabled = true,
            Name = "!uploader",
            IsRegEx = false,
            Command = "!uploader",
            Response = "PlenBot Log Uploader r%appVersion% | https://plenbot.net/uploader/ | https://github.com/Plenyx/PlenBotLogUploader/",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = true,
            Name = "!lastlog",
            IsRegEx = false,
            Command = "!lastlog",
            Response = "%lastLog%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = false,
            Name = "!song",
            IsRegEx = false,
            Command = "!song",
            Response = "%spotifySong%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = false,
            Name = "Smart song recognition",
            IsRegEx = true,
            Command = @"(?:(?:song)|(?:music)){1}(?:(?:\?)|(?: is)|(?: name))+",
            Response = "%spotifySong%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = false,
            Name = "!ign",
            IsRegEx = false,
            Command = "!ign",
            Response = "%gw2Ign%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = false,
            Name = "!build",
            IsRegEx = false,
            Command = "!build",
            Response = "%gw2Build%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
        new()
        {
            Enabled = false,
            Name = "Smart build recognition",
            IsRegEx = true,
            Command = @"(?:(?:build)){1}(?:(?:\?)|(?: is))+",
            Response = "%gw2Build%",
            ResponseType = TwitchResponseType.ReplyAt,
        },
    ];

    internal static List<TwitchCommand> All { get; private set; } = DefaultCommands;

    internal static void Save() => File.WriteAllText(JsonFileLocation, JsonConvert.SerializeObject(All, Formatting.Indented));

    internal static void Load()
    {
        if (File.Exists(JsonFileLocation))
        {
            All = JsonConvert.DeserializeObject<List<TwitchCommand>>(File.ReadAllText(JsonFileLocation));
        }
    }

    internal static List<TwitchCommand> FindResponsesForInput(string input)
    {
        var responses = new List<TwitchCommand>();
        var enabled = All.Where(x => x.Enabled).ToArray();
        responses.AddRange(enabled.Where(x => x.IsRegEx && (x.Regex?.IsMatch(input) ?? false)));
        responses.AddRange(enabled.Where(x => input.StartsWith(x.Command)));
        return responses;
    }
}
