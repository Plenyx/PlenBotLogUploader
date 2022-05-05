using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// Contains static methods for working with encounters
    /// </summary>
    public static class Bosses
    {
        public static string JsonFileLocation = $@"{ApplicationSettings.LocalDir}\boss_data.json";
        public static string TxtFileLocation = $@"{ApplicationSettings.LocalDir}\boss_data.txt";
        public static string MigratedTxtFileLocation = $@"{ApplicationSettings.LocalDir}\boss_data-migrated.txt";

        private static IDictionary<int, BossData> _all;

        /// <summary>
        /// Returns the main dictionary with all encounters.
        /// </summary>
        /// <returns>A dictionary with all encounters</returns>
        public static IDictionary<int, BossData> All => _all ??= new Dictionary<int, BossData>();

        /// <summary>
        /// Loads BossData from specified json file.
        /// </summary>
        /// <param name="filePath">The json file form which the data is loaded.</param>
        /// <returns>A Dictionary containing the loaded BossData.</returns>
        public static IDictionary<int, BossData> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _all = BossData.ParseJsonString(jsonData);

            return _all;
        }

        /// <summary>
        /// Saves BossData to specified json file.
        /// </summary>
        /// <param name="bossDataToSave">BossData to persist.</param>
        /// <param name="filePath">File to be saved to.</param>
        public static void SaveToJson(IDictionary<int, BossData> bossDataToSave)
        {
            var jsonString = JsonConvert.SerializeObject(bossDataToSave.Values, Formatting.Indented);

            File.WriteAllText(JsonFileLocation, jsonString, Encoding.UTF8);
        }

        /// <summary>
        /// Returns a dictionary with default BossData values.
        /// </summary>
        /// <returns>Dictionary with default BossData values</returns>
        public static IDictionary<int, BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            const string defaultBossData = "PlenBotLogUploader.Resources.boss_data.default.json";
            var assembly = Assembly.GetExecutingAssembly();

            using var stream = assembly.GetManifestResourceStream(defaultBossData);
            using var reader = new StreamReader(stream);
            var jsonString = reader.ReadToEnd();

            _all = BossData.ParseJsonString(jsonString);
            foreach (var boss in _all)
            {
                if ((boss.Value.Type != BossType.Golem) && (boss.Value.Type != BossType.WvW) && !boss.Value.Event)
                {
                    boss.Value.SuccessMsg = ApplicationSettings.Current.BossTemplate.SuccessText;
                    boss.Value.FailMsg = ApplicationSettings.Current.BossTemplate.FailText;
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
        public static BossData GetBossDataFromId(int bossId)
        {
            var bossDataRef = All
                .Where(x => x.Value.BossId.Equals(bossId))
                .Select(x => x.Value);
            if (bossDataRef.Count() == 1)
            {
                return bossDataRef.First();
            }
            return null;
        }

        /// <summary>
        /// Returns a wing number based on a given encounter ID.
        /// </summary>
        /// <param name="bossId">ID of the encounter</param>
        /// <returns>wing number</returns>
        public static int GetWingForBoss(int bossId)
        {
            switch (bossId)
            {
                case (int)BossIds.ValeGuardian:
                case (int)BossIds.Gorseval:
                case (int)BossIds.Sabetha:
                    return 1;
                case (int)BossIds.Slothasor:
                case (int)BossIds.BanditTrioBerg:
                case (int)BossIds.BanditTrioZane:
                case (int)BossIds.BanditTrioNarella:
                case (int)BossIds.Matthias:
                    return 2;
                case (int)BossIds.KeepConstruct:
                case (int)BossIds.TwistedCastle:
                case (int)BossIds.Xera:
                    return 3;
                case (int)BossIds.Cairn:
                case (int)BossIds.MursaatOverseer:
                case (int)BossIds.Samarog:
                case (int)BossIds.Deimos:
                    return 4;
                case (int)BossIds.SoullessHorror:
                case (int)BossIds.RiverOfSouls:
                case (int)BossIds.BrokenKing:
                case (int)BossIds.EaterOfSouls:
                case (int)BossIds.EyeOfFate:
                case (int)BossIds.EyeOfJudgement:
                case (int)BossIds.Dhuum:
                    return 5;
                case (int)BossIds.ConjuredAmalgamate:
                case (int)BossIds.LargosTwinsKenut:
                case (int)BossIds.LargosTwinsNikare:
                case (int)BossIds.Qadim:
                    return 6;
                case (int)BossIds.CardinalAdina:
                case (int)BossIds.CardinalSabir:
                case (int)BossIds.QadimThePeerless:
                    return 7;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Returns the order of the encounter within a wing based on given encounter ID.
        /// </summary>
        /// <param name="bossId">ID of the encounter</param>
        /// <returns>order of the encounter within a wing</returns>
        public static int GetBossOrder(int bossId)
        {
            switch (bossId)
            {
                case (int)BossIds.ValeGuardian:
                case (int)BossIds.Slothasor:
                case (int)BossIds.Cairn:
                case (int)BossIds.SoullessHorror:
                case (int)BossIds.ConjuredAmalgamate:
                case (int)BossIds.CardinalAdina:
                    return 1;
                case (int)BossIds.Gorseval:
                case (int)BossIds.BanditTrioBerg:
                case (int)BossIds.BanditTrioNarella:
                case (int)BossIds.BanditTrioZane:
                case (int)BossIds.KeepConstruct:
                case (int)BossIds.MursaatOverseer:
                case (int)BossIds.RiverOfSouls:
                case (int)BossIds.LargosTwinsKenut:
                case (int)BossIds.LargosTwinsNikare:
                case (int)BossIds.CardinalSabir:
                    return 2;
                case (int)BossIds.Matthias:
                case (int)BossIds.TwistedCastle:
                case (int)BossIds.Sabetha:
                case (int)BossIds.Samarog:
                case (int)BossIds.BrokenKing:
                case (int)BossIds.Qadim:
                case (int)BossIds.QadimThePeerless:
                    return 3;
                case (int)BossIds.Deimos:
                case (int)BossIds.EaterOfSouls:
                case (int)BossIds.Xera:
                    return 4;
                case (int)BossIds.EyeOfFate:
                case (int)BossIds.EyeOfJudgement:
                    return 5;
                case (int)BossIds.Dhuum:
                    return 6;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Returns a wing name based on its number.
        /// </summary>
        /// <param name="wingNumber">number of the wing</param>
        /// <returns>wing name</returns>
        public static string GetWingName(int wingNumber)
        {
            return wingNumber switch
            {
                1 => "Spirit Vale",
                2 => "Salvation Pass",
                3 => "Stronghold of the Faithful",
                4 => "Bastion of the Penitent",
                5 => "Hall of Chains",
                6 => "Mythwright Gambit",
                7 => "The Key of Ahdashim",
                _ => "Unknown wing",
            };
        }
    }
}
