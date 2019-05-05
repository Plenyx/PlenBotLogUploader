using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public static class Bosses
    {
        public static Dictionary<int, BossData> GetDefaultSettingsForBossesAsDictionary()
        {
            return new Dictionary<int, BossData>()
            {
                { (int)BossIds.Arkk, new BossData((int)BossIds.Arkk, "Arkk") },
                { (int)BossIds.Artsariiv, new BossData((int)BossIds.Artsariiv, "Artsariiv") },
                { (int)BossIds.BanditTrio, new BossData((int)BossIds.BanditTrio, "Bandit Trio", "Bandit Trio log", "Bandit Trio log", "https://i.imgur.com/UZZQUdf.png") },
                { (int)BossIds.BrokenKing, new BossData((int)BossIds.BrokenKing, "Broken King") },
                { (int)BossIds.Cairn, new BossData((int)BossIds.Cairn, "Cairn the Indomitable", "https://wiki.guildwars2.com/images/b/b8/Mini_Cairn_the_Indomitable.png") },
                { (int)BossIds.ConjuredAmalgamate, new BossData((int)BossIds.ConjuredAmalgamate, "Conjured Amalgamate", "https://plenbot.net/img/amalgamate.png") },
                { (int)BossIds.Deimos, new BossData((int)BossIds.Deimos, "Deimos", "https://wiki.guildwars2.com/images/e/e0/Mini_Ragged_White_Mantle_Figurehead.png") },
                { (int)BossIds.Dhuum, new BossData((int)BossIds.Dhuum, "Dhuum", "https://wiki.guildwars2.com/images/e/e4/Mini_Dhuum.png") },
                { (int)BossIds.EaterOfSouls, new BossData((int)BossIds.EaterOfSouls, "Eater of Souls") },
                { (int)BossIds.Ensolyss, new BossData((int)BossIds.Ensolyss, "Ensolyss of the Endless Torment") },
                { (int)BossIds.EyesFateJudgement, new BossData((int)BossIds.EyesFateJudgement, "Eyes of Fate & Judgement") },
                { (int)BossIds.Gorseval, new BossData((int)BossIds.Gorseval, "Gorseval", "https://wiki.guildwars2.com/images/d/d1/Mini_Gorseval_the_Multifarious.png") },
                { (int)BossIds.KeepConstruct, new BossData((int)BossIds.KeepConstruct, "Keep Construct", "https://wiki.guildwars2.com/images/e/ea/Mini_Keep_Construct.png") },
                { (int)BossIds.LargeGolem, new BossData((int)BossIds.LargeGolem, "Large Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/4/47/Mini_Baron_von_Scrufflebutt.png") },
                { (int)BossIds.LargosTwins, new BossData((int)BossIds.LargosTwins, "Largos Twins", "https://wiki.guildwars2.com/images/e/ea/Mini_Kenut.png") },
                { (int)BossIds.MAMA, new BossData((int)BossIds.MAMA, "M.A.M.A.") },
                { (int)BossIds.Matthias, new BossData((int)BossIds.Matthias, "Matthias Gabrel", "https://wiki.guildwars2.com/images/5/5d/Mini_Matthias_Abomination.png") },
                { (int)BossIds.MediumGolem, new BossData((int)BossIds.MediumGolem, "Medium Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/c/cb/Mini_Mister_Mittens.png") },
                { (int)BossIds.MursaatOverseer, new BossData((int)BossIds.MursaatOverseer, "Mursaat Overseer", "https://wiki.guildwars2.com/images/c/c8/Mini_Mursaat_Overseer.png") },
                { (int)BossIds.Qadim, new BossData((int)BossIds.Qadim, "Qadim", "https://wiki.guildwars2.com/images/f/f2/Mini_Qadim.png") },
                { (int)BossIds.RiverOfSouls, new BossData((int)BossIds.RiverOfSouls, "River of Souls", "River of Souls log", "River of Souls log") },
                { (int)BossIds.Sabetha, new BossData((int)BossIds.Sabetha, "Sabetha the Saboteur", "https://wiki.guildwars2.com/images/5/54/Mini_Sabetha.png") },
                { (int)BossIds.Samarog, new BossData((int)BossIds.Samarog, "Samarog", "https://wiki.guildwars2.com/images/f/f0/Mini_Samarog.png") },
                { (int)BossIds.Siax, new BossData((int)BossIds.Siax, "Siax the Corrupted") },
                { (int)BossIds.Skorvald, new BossData((int)BossIds.Skorvald, "Skorvald the Shattered") },
                { (int)BossIds.Slothasor, new BossData((int)BossIds.Slothasor, "Slothasor", "https://wiki.guildwars2.com/images/1/12/Mini_Slothasor.png") },
                { (int)BossIds.SoullessHorror, new BossData((int)BossIds.SoullessHorror, "Soulless Horror", "https://wiki.guildwars2.com/images/d/d4/Mini_Desmina.png") },
                { (int)BossIds.StandardGolem, new BossData((int)BossIds.StandardGolem, "Standard Kitty Golem", "Golem log", "Golem log", "https://wiki.guildwars2.com/images/8/8f/Mini_Professor_Mew.png") },
                { (int)BossIds.ValeGuardian, new BossData((int)BossIds.ValeGuardian, "Vale Guardian", "https://wiki.guildwars2.com/images/f/fb/Mini_Vale_Guardian.png") },
                { (int)BossIds.WvW, new BossData((int)BossIds.WvW, "World vs World", "WvW log", "WvW log", "https://wiki.guildwars2.com/images/5/54/Commander_tag_%28blue%29.png") },
                { (int)BossIds.Xera, new BossData((int)BossIds.Xera, "Xera", "https://wiki.guildwars2.com/images/4/4b/Mini_Xera.png") }
            };
        }

        public static bool IsFractal(int bossId) => (bossId == (int)BossIds.Arkk) || (bossId == (int)BossIds.Artsariiv) || (bossId == (int)BossIds.Ensolyss) || (bossId == (int)BossIds.MAMA) || (bossId == (int)BossIds.Siax) || (bossId == (int)BossIds.Skorvald);

        public static bool IsGolem(int bossId) => (bossId == (int)BossIds.StandardGolem) || (bossId == (int)BossIds.MediumGolem) || (bossId == (int)BossIds.LargeGolem);

        public static bool IsEvent(int bossId) => (bossId == (int)BossIds.BanditTrio) || (bossId == (int)BossIds.RiverOfSouls);

        public static bool IsWvW(int bossId) => bossId == (int)BossIds.WvW;
    }
}
