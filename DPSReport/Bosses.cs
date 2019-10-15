using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public static class Bosses
    {
        public static Dictionary<int, BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            return new Dictionary<int, BossData>()
            {
                { 1, new BossData() { BossId = (int)BossIds.Arkk, Name = "Arkk", Icon = "https://i.imgur.com/u6vv8cW.png" } },
                { 2, new BossData() { BossId = (int)BossIds.Artsariiv, Name = "Artsariiv" } },
                { 3, new BossData() { BossId = (int)BossIds.BanditTrio, Name = "Bandit Trio", SuccessMsg = "Bandit Trio log: <log>", FailMsg = "Bandit Trio log: <log>", Icon = "https://i.imgur.com/UZZQUdf.png" } },
                { 4, new BossData() { BossId = (int)BossIds.BrokenKing, Name = "Broken King", Icon = "https://i.imgur.com/FNgUmvL.png" } },
                { 5, new BossData() { BossId = (int)BossIds.Cairn, Name = "Cairn the Indomitable", Icon = "https://wiki.guildwars2.com/images/b/b8/Mini_Cairn_the_Indomitable.png" } },
                { 6, new BossData() { BossId = (int)BossIds.CardinalAdina, Name = "Cardinal Adina", Icon = "https://wiki.guildwars2.com/images/a/a0/Mini_Earth_Djinn.png" } },
                { 7, new BossData() { BossId = (int)BossIds.CardinalSabir, Name = "Cardinal Sabir", Icon = "https://wiki.guildwars2.com/images/f/fc/Mini_Air_Djinn.png" } },
                { 8, new BossData() { BossId = (int)BossIds.ConjuredAmalgamate, Name = "Conjured Amalgamate", Icon = "https://plenbot.net/img/amalgamate.png" } },
                { 9, new BossData() { BossId = (int)BossIds.Deimos, Name = "Deimos", Icon = "https://wiki.guildwars2.com/images/e/e0/Mini_Ragged_White_Mantle_Figurehead.png" } },
                { 10, new BossData() { BossId = (int)BossIds.Dhuum, Name = "Dhuum", Icon = "https://wiki.guildwars2.com/images/e/e4/Mini_Dhuum.png" } },
                { 11, new BossData() { BossId = (int)BossIds.EaterOfSouls, Name = "Eater of Souls", Icon = "https://i.imgur.com/Sd6Az8M.png" } },
                { 12, new BossData() { BossId = (int)BossIds.Ensolyss, Name = "Ensolyss of the Endless Torment", Icon = "https://i.imgur.com/GUTNuyP.png" } },
                { 13, new BossData() { BossId = (int)BossIds.EyesFateJudgement, Name = "Eyes of Fate & Judgement", Icon = "https://i.imgur.com/kAgdoa5.png" } },
                { 14, new BossData() { BossId = (int)BossIds.IcebroodConstruct, Name = "Icebrood Construct", Icon = "https://wiki.guildwars2.com/images/e/e2/Icebrood_Construct.jpg" } },
                { 15, new BossData() { BossId = (int)BossIds.Gorseval, Name = "Gorseval", Icon = "https://wiki.guildwars2.com/images/d/d1/Mini_Gorseval_the_Multifarious.png" } },
                { 16, new BossData() { BossId = (int)BossIds.KeepConstruct, Name = "Keep Construct", Icon = "https://wiki.guildwars2.com/images/e/ea/Mini_Keep_Construct.png" } },
                { 17, new BossData() { BossId = (int)BossIds.LargeGolem, Name = "Large Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/4/47/Mini_Baron_von_Scrufflebutt.png" } },
                { 18, new BossData() { BossId = (int)BossIds.LargosTwins, Name = "Largos Twins", Icon = "https://wiki.guildwars2.com/images/e/ea/Mini_Kenut.png" } },
                { 19, new BossData() { BossId = (int)BossIds.MAMA, Name = "M.A.M.A.", Icon = "https://i.imgur.com/1h7HOII.png" } },
                { 20, new BossData() { BossId = (int)BossIds.Matthias, Name = "Matthias Gabrel", Icon = "https://wiki.guildwars2.com/images/5/5d/Mini_Matthias_Abomination.png" } },
                { 21, new BossData() { BossId = (int)BossIds.MediumGolem, Name = "Medium Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/c/cb/Mini_Mister_Mittens.png" } },
                { 22, new BossData() { BossId = (int)BossIds.MursaatOverseer, Name = "Mursaat Overseer", Icon = "https://wiki.guildwars2.com/images/c/c8/Mini_Mursaat_Overseer.png" } },
                { 23, new BossData() { BossId = (int)BossIds.Qadim, Name = "Qadim", Icon = "https://wiki.guildwars2.com/images/f/f2/Mini_Qadim.png" } },
                { 24, new BossData() { BossId = (int)BossIds.QadimThePeerless, Name = "Qadim the Peerless", Icon = "https://wiki.guildwars2.com/images/8/8b/Mini_Qadim_the_Peerless.png" } },
                { 25, new BossData() { BossId = (int)BossIds.RiverOfSouls, Name = "River of Souls", SuccessMsg = "River of Souls log: <log>", FailMsg = "River of Souls log: <log>" } },
                { 26, new BossData() { BossId = (int)BossIds.Sabetha, Name = "Sabetha the Saboteur", Icon = "https://wiki.guildwars2.com/images/5/54/Mini_Sabetha.png" } },
                { 27, new BossData() { BossId = (int)BossIds.Samarog, Name = "Samarog", Icon = "https://wiki.guildwars2.com/images/f/f0/Mini_Samarog.png" } },
                { 28, new BossData() { BossId = (int)BossIds.Siax, Name = "Siax the Corrupted", Icon = "https://i.imgur.com/5C60cQb.png" } },
                { 29, new BossData() { BossId = (int)BossIds.Skorvald, Name = "Skorvald the Shattered", Icon = "https://i.imgur.com/IOPAHRE.png" } },
                { 30, new BossData() { BossId = (int)BossIds.Slothasor, Name = "Slothasor", Icon = "https://wiki.guildwars2.com/images/1/12/Mini_Slothasor.png" } },
                { 31, new BossData() { BossId = (int)BossIds.SoullessHorror, Name = "Soulless Horror", Icon = "https://wiki.guildwars2.com/images/d/d4/Mini_Desmina.png" } },
                { 32, new BossData() { BossId = (int)BossIds.StandardGolem, Name = "Standard Kitty Golem", SuccessMsg = "Golem log: <log>", FailMsg = "Golem log: <log>", Icon = "https://wiki.guildwars2.com/images/8/8f/Mini_Professor_Mew.png" } },
                { 33, new BossData() { BossId = (int)BossIds.ValeGuardian, Name = "Vale Guardian", Icon = "https://wiki.guildwars2.com/images/f/fb/Mini_Vale_Guardian.png" } },
                { 34, new BossData() { BossId = (int)BossIds.WvW, Name = "World vs World", SuccessMsg = "WvW log: <log>", FailMsg = "WvW log: <log>", Icon = "https://wiki.guildwars2.com/images/5/54/Commander_tag_%28blue%29.png" } },
                { 35, new BossData() { BossId = (int)BossIds.Xera, Name = "Xera", Icon = "https://wiki.guildwars2.com/images/4/4b/Mini_Xera.png" } }
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

        public static bool IsStrike(int bossId) => bossId == (int)BossIds.IcebroodConstruct;
    }
}
