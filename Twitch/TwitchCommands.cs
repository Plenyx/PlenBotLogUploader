using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PlenBotLogUploader.Twitch
{
    internal class TwitchCommands
    {
        internal static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\twitch_commands.json";

        private static readonly List<TwitchCommand> defaultCommands = [
            new()
            {
                Enabled = true,
                Name = "!uploader",
                IsRegex = false,
                Command = "!uploader",
                Response = "PlenBot Log Uploader r%appVersion% | https://plenbot.net/uploader/ | https://github.com/Plenyx/PlenBotLogUploader/",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = true,
                Name = "!lastlog",
                IsRegex = false,
                Command = "!lastlog",
                Response = "%lastLog%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = false,
                Name = "!song",
                IsRegex = false,
                Command = "!song",
                Response = "%spotifySong%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = false,
                Name = "Smart song recognition",
                IsRegex = true,
                Command = @"(?:(?:song)|(?:music)){1}(?:(?:\?)|(?: is)|(?: name))+",
                Response = "%spotifySong%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = false,
                Name = "!ign",
                IsRegex = false,
                Command = "!ign",
                Response = "%gw2Ign%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = false,
                Name = "!build",
                IsRegex = false,
                Command = "!build",
                Response = "%gw2Build%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
            new()
            {
                Enabled = false,
                Name = "Smart build recognition",
                IsRegex = true,
                Command = @"(?:(?:build)){1}(?:(?:\?)|(?: is))+",
                Response = "%gw2Build%",
                ResponseType = TwitchResponseType.ReplyAt,
            },
        ];

        private static List<TwitchCommand> _all = defaultCommands;

        internal static List<TwitchCommand> All => _all;

        internal static void Save() => File.WriteAllText(JsonFileLocation, JsonConvert.SerializeObject(_all, Formatting.Indented));

        internal static List<TwitchCommand> Load()
        {
            if (File.Exists(JsonFileLocation))
            {
                _all = JsonConvert.DeserializeObject<List<TwitchCommand>>(File.ReadAllText(JsonFileLocation));
            }
            return _all;
        }

        internal static List<TwitchCommand> FindResponsesForInput(string input)
        {
            var responses = new List<TwitchCommand>();
            var enabled = _all.Where(x => x.Enabled).ToArray();
            responses.AddRange(enabled.Where(x => x.IsRegex && (x.Regex?.IsMatch(input) ?? false)));
            responses.AddRange(enabled.Where(x => input.StartsWith(x.Command)));
            return responses;
        }
    }
}
