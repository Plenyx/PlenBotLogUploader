using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlenBotLogUploader.DpsReport
{
    /// <summary>
    /// Contains static methods for working with encounters
    /// </summary>
    internal static class Bosses
    {
        internal static readonly string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\boss_data.json";

        private static List<BossData> _all;

        /// <summary>
        /// Returns the main dictionary with all encounters.
        /// </summary>
        /// <returns>A dictionary with all encounters</returns>
        internal static List<BossData> All => _all ??= new List<BossData>();

        /// <summary>
        /// Loads BossData from specified json file.
        /// </summary>
        /// <param name="filePath">The json file form which the data is loaded.</param>
        /// <returns>A Dictionary containing the loaded BossData.</returns>
        internal static List<BossData> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _all = ParseJsonString(jsonData);

            return _all;
        }

        /// <summary>
        /// Deserializes a json string to BossData
        /// </summary>
        /// <param name="jsonString">The json to parse</param>
        /// <exception cref="JsonException"></exception>
        internal static List<BossData> ParseJsonString(string jsonString)
        {
            var parsedJson = JsonConvert.DeserializeObject<IEnumerable<BossData>>(jsonString)
                             ?? throw new JsonException("Could not parse json to BossData");

            return parsedJson.ToList();
        }

        /// <summary>
        /// Saves BossData to specified json file.
        /// </summary>
        /// <param name="bossDataToSave">BossData to persist.</param>
        internal static void SaveToJson(List<BossData> bossDataToSave)
        {
            var jsonString = JsonConvert.SerializeObject(bossDataToSave, Formatting.Indented);

            File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
        }

        /// <summary>
        /// Returns a dictionary with default BossData values.
        /// </summary>
        /// <returns>Dictionary with default BossData values</returns>
        internal static List<BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            const string defaultBossData = "PlenBotLogUploader.Resources.boss_data.default.json";
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(defaultBossData);
            using var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();

            _all = ParseJsonString(jsonString);
            foreach (var boss in _all.AsSpan())
            {
                if ((boss.Type != BossType.Golem) && (boss.Type != BossType.WvW) && !boss.Event)
                {
                    boss.SuccessMsg = ApplicationSettings.Current.BossTemplate.SuccessText;
                    boss.FailMsg = ApplicationSettings.Current.BossTemplate.FailText;
                }
            }
            SaveToJson(_all);

            return _all;
        }

        /// <summary>
        /// Returns a BossData object based on its boss id, null if no object has been found.
        /// </summary>
        /// <param name="bossId">The boss id to query for</param>
        /// <returns>BossData object or null</returns>
        internal static BossData GetBossDataFromId(int bossId) => All.Find(x => x.BossId.Equals(bossId));

        /// <summary>
        /// Returns a wing number based on a given encounter ID.
        /// </summary>
        /// <param name="bossId">ID of the encounter</param>
        /// <returns>wing number</returns>
        internal static int GetWingForBoss(int bossId)
            => bossId switch
            {
                (int)BossIds.ValeGuardian or (int)BossIds.Gorseval or (int)BossIds.Sabetha => 1,
                (int)BossIds.Slothasor or (int)BossIds.BanditTrioBerg or (int)BossIds.BanditTrioZane or (int)BossIds.BanditTrioNarella or (int)BossIds.Matthias => 2,
                (int)BossIds.KeepConstruct or (int)BossIds.TwistedCastle or (int)BossIds.Xera => 3,
                (int)BossIds.Cairn or (int)BossIds.MursaatOverseer or (int)BossIds.Samarog or (int)BossIds.Deimos => 4,
                (int)BossIds.SoullessHorror or (int)BossIds.RiverOfSouls or (int)BossIds.BrokenKing or (int)BossIds.EaterOfSouls or (int)BossIds.EyeOfFate or (int)BossIds.EyeOfJudgement or (int)BossIds.Dhuum => 5,
                (int)BossIds.ConjuredAmalgamate or (int)BossIds.LargosTwinsKenut or (int)BossIds.LargosTwinsNikare or (int)BossIds.Qadim => 6,
                (int)BossIds.CardinalAdina or (int)BossIds.CardinalSabir or (int)BossIds.QadimThePeerless => 7,
                _ => 0,
            };

        /// <summary>
        /// Returns the order of the encounter within a wing based on given encounter ID.
        /// </summary>
        /// <param name="bossId">ID of the encounter</param>
        /// <returns>order of the encounter within a wing</returns>
        internal static int GetBossOrder(int bossId)
            => bossId switch
            {
                (int)BossIds.ValeGuardian or (int)BossIds.Slothasor or (int)BossIds.Cairn or (int)BossIds.SoullessHorror or (int)BossIds.ConjuredAmalgamate or (int)BossIds.CardinalAdina => 1,
                (int)BossIds.Gorseval or (int)BossIds.BanditTrioBerg or (int)BossIds.BanditTrioNarella or (int)BossIds.BanditTrioZane or (int)BossIds.KeepConstruct or (int)BossIds.MursaatOverseer or (int)BossIds.RiverOfSouls or (int)BossIds.LargosTwinsKenut or (int)BossIds.LargosTwinsNikare or (int)BossIds.CardinalSabir => 2,
                (int)BossIds.Matthias or (int)BossIds.TwistedCastle or (int)BossIds.Sabetha or (int)BossIds.Samarog or (int)BossIds.BrokenKing or (int)BossIds.Qadim or (int)BossIds.QadimThePeerless => 3,
                (int)BossIds.Deimos or (int)BossIds.EaterOfSouls or (int)BossIds.Xera => 4,
                (int)BossIds.EyeOfFate or (int)BossIds.EyeOfJudgement => 5,
                (int)BossIds.Dhuum => 6,
                _ => 0,
            };

        /// <summary>
        /// Returns a wing name based on its number.
        /// </summary>
        /// <param name="wingNumber">number of the wing</param>
        /// <returns>wing name</returns>
        internal static string GetWingName(int wingNumber)
            => wingNumber switch
            {
                1 => "Spirit Vale",
                2 => "Salvation Pass",
                3 => "Stronghold of the Faithful",
                4 => "Bastion of the Penitent",
                5 => "Hall of Chains",
                6 => "Mythwright Gambit",
                7 => "The Key of Ahdashim",
                _ => "Unknown raid wing",
            };
    }
}
