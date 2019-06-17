using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public static class Bosses
    {
        public static Dictionary<int, BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            return new Dictionary<int, BossData>()
            {
                { 1, new BossData((int)BossIds.Arkk, "Arkk") },
                { 2, new BossData((int)BossIds.Artsariiv, "Artsariiv") },
                { 3, new BossData((int)BossIds.BanditTrio, "Bandit Trio", "Bandit Trio log", "Bandit Trio log", "https://i.imgur.com/UZZQUdf.png") },
                { 4, new BossData((int)BossIds.BrokenKing, "Broken King") },
                { 5, new BossData((int)BossIds.Cairn, "Cairn the Indomitable", "https://wiki.guildwars2.com/images/b/b8/Mini_Cairn_the_Indomitable.png") },
                { 6, new BossData((int)BossIds.CardinalAdina, "Cardinal Adina", "https://wiki.guildwars2.com/images/a/a0/Mini_Earth_Djinn.png") },
                { 7, new BossData((int)BossIds.CardinalSabir, "Cardinal Sabir", "https://wiki.guildwars2.com/images/f/fc/Mini_Air_Djinn.png") },
                { 8, new BossData((int)BossIds.ConjuredAmalgamate, "Conjured Amalgamate", "https://plenbot.net/img/amalgamate.png") },
                { 9, new BossData((int)BossIds.Deimos, "Deimos", "https://wiki.guildwars2.com/images/e/e0/Mini_Ragged_White_Mantle_Figurehead.png") },
                { 10, new BossData((int)BossIds.Dhuum, "Dhuum", "https://wiki.guildwars2.com/images/e/e4/Mini_Dhuum.png") },
                { 11, new BossData((int)BossIds.EaterOfSouls, "Eater of Souls") },
                { 12, new BossData((int)BossIds.Ensolyss, "Ensolyss of the Endless Torment") },
                { 13, new BossData((int)BossIds.EyesFateJudgement, "Eyes of Fate & Judgement") },
                { 14, new BossData((int)BossIds.Gorseval, "Gorseval", "https://wiki.guildwars2.com/images/d/d1/Mini_Gorseval_the_Multifarious.png") },
                { 15, new BossData((int)BossIds.KeepConstruct, "Keep Construct", "https://wiki.guildwars2.com/images/e/ea/Mini_Keep_Construct.png") },
                { 16, new BossData((int)BossIds.LargeGolem, "Large Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/4/47/Mini_Baron_von_Scrufflebutt.png") },
                { 17, new BossData((int)BossIds.LargosTwins, "Largos Twins", "https://wiki.guildwars2.com/images/e/ea/Mini_Kenut.png") },
                { 18, new BossData((int)BossIds.MAMA, "M.A.M.A.") },
                { 19, new BossData((int)BossIds.Matthias, "Matthias Gabrel", "https://wiki.guildwars2.com/images/5/5d/Mini_Matthias_Abomination.png") },
                { 20, new BossData((int)BossIds.MediumGolem, "Medium Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/c/cb/Mini_Mister_Mittens.png") },
                { 21, new BossData((int)BossIds.MursaatOverseer, "Mursaat Overseer", "https://wiki.guildwars2.com/images/c/c8/Mini_Mursaat_Overseer.png") },
                { 22, new BossData((int)BossIds.Qadim, "Qadim", "https://wiki.guildwars2.com/images/f/f2/Mini_Qadim.png") },
                { 23, new BossData((int)BossIds.QadimThePeerless, "Qadim the Peerless", "https://wiki.guildwars2.com/images/8/8b/Mini_Qadim_the_Peerless.png")},
                { 24, new BossData((int)BossIds.RiverOfSouls, "River of Souls", "River of Souls log", "River of Souls log") },
                { 25, new BossData((int)BossIds.Sabetha, "Sabetha the Saboteur", "https://wiki.guildwars2.com/images/5/54/Mini_Sabetha.png") },
                { 26, new BossData((int)BossIds.Samarog, "Samarog", "https://wiki.guildwars2.com/images/f/f0/Mini_Samarog.png") },
                { 27, new BossData((int)BossIds.Siax, "Siax the Corrupted") },
                { 28, new BossData((int)BossIds.Skorvald, "Skorvald the Shattered") },
                { 29, new BossData((int)BossIds.Slothasor, "Slothasor", "https://wiki.guildwars2.com/images/1/12/Mini_Slothasor.png") },
                { 30, new BossData((int)BossIds.SoullessHorror, "Soulless Horror", "https://wiki.guildwars2.com/images/d/d4/Mini_Desmina.png") },
                { 31, new BossData((int)BossIds.StandardGolem, "Standard Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/8/8f/Mini_Professor_Mew.png") },
                { 32, new BossData((int)BossIds.ValeGuardian, "Vale Guardian", "https://wiki.guildwars2.com/images/f/fb/Mini_Vale_Guardian.png") },
                { 33, new BossData((int)BossIds.WvW, "World vs World", "WvW log", "WvW log", "https://wiki.guildwars2.com/images/5/54/Commander_tag_%28blue%29.png") },
                { 34, new BossData((int)BossIds.Xera, "Xera", "https://wiki.guildwars2.com/images/4/4b/Mini_Xera.png") }
            };
        }

        public static int GetWingForBoss(int bossId)
        {
            switch(bossId)
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
                case (int)BossIds.EyesFateJudgement:
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

        public static int GetBossOrder(int bossId)
        {
            switch(bossId)
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
                case (int)BossIds.Xera:
                case (int)BossIds.Sabetha:
                case (int)BossIds.Samarog:
                case (int)BossIds.BrokenKing:
                case (int)BossIds.Qadim:
                case (int)BossIds.QadimThePeerless:
                    return 3;
                case (int)BossIds.Deimos:
                case(int)BossIds.EaterOfSouls:
                    return 4;
                case (int)BossIds.EyesFateJudgement:
                    return 5;
                case (int)BossIds.Dhuum:
                    return 6;
                default:
                    return 0;
            }
        }

        public static string GetWingName(int wingNumber)
        {
            switch(wingNumber)
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

        public static bool IsFractal(int bossId) => (bossId == (int)BossIds.Arkk) || (bossId == (int)BossIds.Artsariiv) || (bossId == (int)BossIds.Ensolyss) || (bossId == (int)BossIds.MAMA) || (bossId == (int)BossIds.Siax) || (bossId == (int)BossIds.Skorvald);

        public static bool IsGolem(int bossId) => (bossId == (int)BossIds.StandardGolem) || (bossId == (int)BossIds.MediumGolem) || (bossId == (int)BossIds.LargeGolem);

        public static bool IsEvent(int bossId) => (bossId == (int)BossIds.BanditTrio) || (bossId == (int)BossIds.RiverOfSouls);

        public static bool IsWvW(int bossId) => bossId == (int)BossIds.WvW;
    }
}
