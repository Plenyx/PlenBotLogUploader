using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlenBotLogUploader.DPSReport
{
    /// <summary>
    /// Contains static methods for working with encounters
    /// </summary>
    public static class Bosses
    {
        private static Dictionary<int, BossData> _all = null;
        /// <summary>
        /// Returns the main dictionary with all encounters.
        /// </summary>
        /// <returns>A dictionary with all encounters</returns>
        public static Dictionary<int, BossData> All
        {
            get
            {
                if (_all == null)
                {
                    _all = new Dictionary<int, BossData>();
                }
                return _all;
            }
        }

        /// <summary>
        /// Loads all bosses' data from a specified file.
        /// </summary>
        /// <param name="file">The file from which the bosses are loaded from</param>
        /// <returns>A dictionary with all encounters</returns>
        public static Dictionary<int, BossData> FromFile(string file)
        {
            var allBosses = All;
            if (allBosses.Count > 0)
            {
                allBosses.Clear();
            }
            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine(); // skip the first line
                while ((line = reader.ReadLine()) != null)
                {
                    allBosses.Add(allBosses.Count + 1, BossData.FromSavedFormat(line));
                }
            }
            return allBosses;
        }

        /// <summary>
        /// Loads all bosses' data from a specified file asynchronously.
        /// </summary>
        /// <param name="file">The file from which the bosses are loaded from</param>
        /// <returns>A dictionary with all encounters</returns>
        public static async Task<Dictionary<int, BossData>> FromFileAsync(string file)
        {
            var allBosses = All;
            if (allBosses.Count > 0)
            {
                allBosses.Clear();
            }
            using (StreamReader reader = new StreamReader(file))
            {
                string line = await reader.ReadLineAsync(); // skip the first line
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    allBosses.Add(allBosses.Count + 1, BossData.FromSavedFormat(line));
                }
            }
            return allBosses;
        }

        /// <summary>
        /// Returns a dictionary with default BossData values.
        /// </summary>
        /// <returns>Dictionary with default BossData values</returns>
        public static Dictionary<int, BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            return new Dictionary<int, BossData>()
            {
                { 1, new BossData() { BossId = (int)BossIds.AiKeeperOfThePeak, Name = "Ai, Keeper of the Peak", Icon = "https://plenbot.net/img/ai_icon.png", Type = BossType.Fractal } },
                { 2, new BossData() { BossId = (int)BossIds.Arkk, Name = "Arkk", Icon = "https://i.imgur.com/u6vv8cW.png", Type = BossType.Fractal } },
                { 3, new BossData() { BossId = (int)BossIds.Artsariiv, Name = "Artsariiv", Type = BossType.Fractal } },
                { 4, new BossData() { BossId = (int)BossIds.BanditTrio, Name = "Bandit Trio", SuccessMsg = "Bandit Trio log: <log>", FailMsg = "Bandit Trio log: <log> | Wipe counter: <pulls>", Icon = "https://i.imgur.com/UZZQUdf.png", Type = BossType.Raid, Event = true } },
                { 5, new BossData() { BossId = (int)BossIds.Boneskinner, Name = "Boneskinner", Icon = "https://i.imgur.com/meYwQmA.png", Type = BossType.Strike } },
                { 6, new BossData() { BossId = (int)BossIds.BrokenKing, Name = "Broken King", Icon = "https://i.imgur.com/FNgUmvL.png", Type = BossType.Raid } },
                { 7, new BossData() { BossId = (int)BossIds.Cairn, Name = "Cairn the Indomitable", Icon = "https://wiki.guildwars2.com/images/b/b8/Mini_Cairn_the_Indomitable.png", Type = BossType.Raid } },
                { 8, new BossData() { BossId = (int)BossIds.CardinalAdina, Name = "Cardinal Adina", Icon = "https://wiki.guildwars2.com/images/a/a0/Mini_Earth_Djinn.png", Type = BossType.Raid } },
                { 9, new BossData() { BossId = (int)BossIds.CardinalSabir, Name = "Cardinal Sabir", Icon = "https://wiki.guildwars2.com/images/f/fc/Mini_Air_Djinn.png", Type = BossType.Raid } },
                { 10, new BossData() { BossId = (int)BossIds.ConjuredAmalgamate, Name = "Conjured Amalgamate", Icon = "https://plenbot.net/img/amalgamate.png", Type = BossType.Raid } },
                { 11, new BossData() { BossId = (int)BossIds.Deimos, Name = "Deimos", Icon = "https://wiki.guildwars2.com/images/e/e0/Mini_Ragged_White_Mantle_Figurehead.png", Type = BossType.Raid } },
                { 12, new BossData() { BossId = (int)BossIds.Dhuum, Name = "Dhuum", Icon = "https://wiki.guildwars2.com/images/e/e4/Mini_Dhuum.png", Type = BossType.Raid } },
                { 13, new BossData() { BossId = (int)BossIds.EaterOfSouls, Name = "Eater of Souls", Icon = "https://i.imgur.com/Sd6Az8M.png", Type = BossType.Raid, Event = true } },
                { 14, new BossData() { BossId = (int)BossIds.Ensolyss, Name = "Ensolyss of the Endless Torment", Icon = "https://i.imgur.com/GUTNuyP.png", Type = BossType.Fractal } },
                { 15, new BossData() { BossId = (int)BossIds.EyeOfFate, Name = "Eyes of Fate & Judgement", Icon = "https://i.imgur.com/kAgdoa5.png", Type = BossType.Raid, Event = true } },
                { 16, new BossData() { BossId = (int)BossIds.EyeOfJudgement, Name = "Eyes of Judgement & Fate", Icon = "https://i.imgur.com/kAgdoa5.png", Type = BossType.Raid, Event = true } },
                { 17, new BossData() { BossId = (int)BossIds.FraenirOfJormag, Name = "Fraenir of Jormag", Icon = "https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_6_67_Fraenir_of_Jormag.jpg_208px-Fraenir_of_Jormag.jpg", Type = BossType.Strike } },
                { 18, new BossData() { BossId = (int)BossIds.Freezie, Name = "Freezie", Icon = "https://dps.report/cache/https_wiki.guildwars2.com_images_thumb_8_8b_Freezie.jpg_189px-Freezie.jpg", Type = BossType.Strike } },
                { 19, new BossData() { BossId = (int)BossIds.Gorseval, Name = "Gorseval", Icon = "https://wiki.guildwars2.com/images/d/d1/Mini_Gorseval_the_Multifarious.png", Type = BossType.Raid } },
                { 20, new BossData() { BossId = (int)BossIds.IcebroodConstruct, Name = "Icebrood Construct", Icon = "https://wiki.guildwars2.com/images/e/e2/Icebrood_Construct.jpg", Type = BossType.Strike } },
                { 21, new BossData() { BossId = (int)BossIds.KeepConstruct, Name = "Keep Construct", Icon = "https://wiki.guildwars2.com/images/e/ea/Mini_Keep_Construct.png", Type = BossType.Raid } },
                { 22, new BossData() { BossId = (int)BossIds.LargeGolem, Name = "Large Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/4/47/Mini_Baron_von_Scrufflebutt.png", Type = BossType.Golem } },
                { 23, new BossData() { BossId = (int)BossIds.LargosTwins, Name = "Largos Twins", Icon = "https://wiki.guildwars2.com/images/e/ea/Mini_Kenut.png", Type = BossType.Raid } },
                { 24, new BossData() { BossId = (int)BossIds.MAMA, Name = "M.A.M.A.", Icon = "https://i.imgur.com/1h7HOII.png", Type = BossType.Fractal } },
                { 25, new BossData() { BossId = (int)BossIds.Matthias, Name = "Matthias Gabrel", Icon = "https://wiki.guildwars2.com/images/5/5d/Mini_Matthias_Abomination.png", Type = BossType.Raid } },
                { 26, new BossData() { BossId = (int)BossIds.MediumGolem, Name = "Medium Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/c/cb/Mini_Mister_Mittens.png", Type = BossType.Golem } },
                { 27, new BossData() { BossId = (int)BossIds.MursaatOverseer, Name = "Mursaat Overseer", Icon = "https://wiki.guildwars2.com/images/c/c8/Mini_Mursaat_Overseer.png", Type = BossType.Raid } },
                { 28, new BossData() { BossId = (int)BossIds.Qadim, Name = "Qadim", Icon = "https://wiki.guildwars2.com/images/f/f2/Mini_Qadim.png", Type = BossType.Raid } },
                { 29, new BossData() { BossId = (int)BossIds.QadimThePeerless, Name = "Qadim the Peerless", Icon = "https://wiki.guildwars2.com/images/8/8b/Mini_Qadim_the_Peerless.png", Type = BossType.Raid } },
                { 30, new BossData() { BossId = (int)BossIds.RiverOfSouls, Name = "River of Souls", SuccessMsg = "River of Souls log: <log>", FailMsg = "River of Souls log: <log> | Wipe counter: <pulls>", Type = BossType.Raid, Event = true } },
                { 31, new BossData() { BossId = (int)BossIds.Sabetha, Name = "Sabetha the Saboteur", Icon = "https://wiki.guildwars2.com/images/5/54/Mini_Sabetha.png", Type = BossType.Raid } },
                { 32, new BossData() { BossId = (int)BossIds.Samarog, Name = "Samarog", Icon = "https://wiki.guildwars2.com/images/f/f0/Mini_Samarog.png", Type = BossType.Raid } },
                { 33, new BossData() { BossId = (int)BossIds.Siax, Name = "Siax the Corrupted", Icon = "https://i.imgur.com/5C60cQb.png", Type = BossType.Fractal } },
                { 34, new BossData() { BossId = (int)BossIds.Skorvald, Name = "Skorvald the Shattered", Icon = "https://i.imgur.com/IOPAHRE.png", Type = BossType.Fractal } },
                { 35, new BossData() { BossId = (int)BossIds.Slothasor, Name = "Slothasor", Icon = "https://wiki.guildwars2.com/images/1/12/Mini_Slothasor.png", Type = BossType.Raid } },
                { 36, new BossData() { BossId = (int)BossIds.SoullessHorror, Name = "Soulless Horror", Icon = "https://wiki.guildwars2.com/images/d/d4/Mini_Desmina.png", Type = BossType.Raid } },
                { 37, new BossData() { BossId = (int)BossIds.StandardGolem, Name = "Standard Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/8/8f/Mini_Professor_Mew.png", Type = BossType.Golem } },
                { 38, new BossData() { BossId = (int)BossIds.TwistedCastle, Name = "Twisted Castle", SuccessMsg = "Twisted Castle log: <log>", FailMsg = "Twisted Castle log: <log> | Wipe counter: <pulls>", Type = BossType.Raid, Event = true }  },
                { 39, new BossData() { BossId = (int)BossIds.TheVoiceAndTheClawOfTheFallen, Name = "The Voice and the Claw of the Fallen", Icon = "https://i.imgur.com/lNXXbnC.png", Type = BossType.Strike } },
                { 40, new BossData() { BossId = (int)BossIds.ValeGuardian, Name = "Vale Guardian", Icon = "https://wiki.guildwars2.com/images/f/fb/Mini_Vale_Guardian.png", Type = BossType.Raid } },
                { 41, new BossData() { BossId = (int)BossIds.VariniaStormsounder, Name = "Varinia Stormsounder (Cold War)", Icon = "https://i.imgur.com/r9b2oww.png", Type = BossType.Strike } },
                { 42, new BossData() { BossId = (int)BossIds.WhisperOfJormag, Name = "Whisper of Jormag", Icon = "https://wiki.guildwars2.com/images/c/c0/Mini_Whisper_of_Jormag.png", Type = BossType.Strike } },
                { 43, new BossData() { BossId = (int)BossIds.WvW, Name = "World vs World", SuccessMsg = "WvW log: <log>", FailMsg = "WvW log: <log>", Icon = "https://wiki.guildwars2.com/images/5/54/Commander_tag_%28blue%29.png", Type = BossType.WvW } },
                { 44, new BossData() { BossId = (int)BossIds.Xera, Name = "Xera", Icon = "https://wiki.guildwars2.com/images/4/4b/Mini_Xera.png", Type = BossType.Raid } }
            };
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
