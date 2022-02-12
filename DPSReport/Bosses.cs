using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlenBotLogUploader.AppSettings;

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
        
        private static IDictionary<int, BossData> _All { get; set; }

        /// <summary>
        /// Returns the main dictionary with all encounters.
        /// </summary>
        /// <returns>A dictionary with all encounters</returns>
        public static IDictionary<int, BossData> All => _All ??= new Dictionary<int, BossData>();

        /// <summary>
        /// Loads all bosses' data from a specified file.
        /// </summary>
        /// <param name="file">The file from which the bosses are loaded from</param>
        /// <returns>A dictionary with all encounters</returns>
        public static IDictionary<int, BossData> FromTxtFile(string file)
        {
            var allBosses = All;
            if (allBosses.Count > 0)
            {
                allBosses.Clear();
            }

            using (var reader = new StreamReader(file))
            {
                string line = reader.ReadLine(); // skip the first line
                while (!((line = reader.ReadLine()) is null))
                {
                    allBosses.Add(allBosses.Count + 1, BossData.FromSavedFormat(line));
                }
            }

            return allBosses;
        }

        /// <summary>
        /// Loads BossData from specified json file.
        /// </summary>
        /// <param name="filePath">The json file form which the data is loaded.</param>
        /// <returns>A Dictionary containing the loaded BossData.</returns>
        public static IDictionary<int, BossData> FromJsonFile(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);

            _All = BossData.ParseJsonString(jsonData);

            return _All;
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

            _All = BossData.ParseJsonString(jsonString);
            SaveToJson(_All);

            return _All;
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
                case (int)BossIds.BanditTrio:
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
                case (int)BossIds.LargosTwins:
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
                case (int)BossIds.BanditTrio:
                case (int)BossIds.KeepConstruct:
                case (int)BossIds.MursaatOverseer:
                case (int)BossIds.RiverOfSouls:
                case (int)BossIds.LargosTwins:
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
            switch (wingNumber)
            {
                case 1:
                    return "Spirit Vale";
                case 2:
                    return "Salvation Pass";
                case 3:
                    return "Stronghold of the Faithful";
                case 4:
                    return "Bastion of the Penitent";
                case 5:
                    return "Hall of Chains";
                case 6:
                    return "Mythwright Gambit";
                case 7:
                    return "The Key of Ahdashim";
                default:
                    return "Unknown wing";
            }
        }
    }
}