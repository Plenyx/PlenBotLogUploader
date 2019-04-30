using System.Collections.Generic;

namespace PlenBotLogUploader.DPSReport
{
    public static class Bosses
    {
        public static Dictionary<int, BossData> GetDefaultBossesAsDictionary()
        {
            return new Dictionary<int, BossData>()
            {
                { (int)BossIds.Arkk, new BossData((int)BossIds.Arkk, "Arkk") },
                { (int)BossIds.Artsariiv, new BossData((int)BossIds.Artsariiv, "Artsariiv") },
                { (int)BossIds.BanditTrio, new BossData((int)BossIds.BanditTrio, "Bandit Trio", "Bandit Trio log", "Bandit Trio log") },
                { (int)BossIds.BrokenKing, new BossData((int)BossIds.BrokenKing, "Broken King") },
                { (int)BossIds.Cairn, new BossData((int)BossIds.Cairn, "Cairn the Indomitable") },
                { (int)BossIds.ConjuredAmalgamate, new BossData((int)BossIds.ConjuredAmalgamate, "Conjured Amalgamate") },
                { (int)BossIds.Deimos, new BossData((int)BossIds.Deimos, "Deimos") },
                { (int)BossIds.Dhuum, new BossData((int)BossIds.Dhuum, "Dhuum") },
                { (int)BossIds.EaterOfSouls, new BossData((int)BossIds.EaterOfSouls, "Eater of Souls") },
                { (int)BossIds.Ensolyss, new BossData((int)BossIds.Ensolyss, "Ensolyss of the Endless Torment") },
                { (int)BossIds.EyesFateJudgement, new BossData((int)BossIds.EyesFateJudgement, "Eyes of Fate & Judgement") },
                { (int)BossIds.Gorseval, new BossData((int)BossIds.Gorseval, "Gorseval") },
                { (int)BossIds.KeepConstruct, new BossData((int)BossIds.KeepConstruct, "Keep Construct") },
                { (int)BossIds.LargeGolem, new BossData((int)BossIds.LargeGolem, "Large Kitty Golem", "Golem log", "Golem log") },
                { (int)BossIds.LargosTwins, new BossData((int)BossIds.LargosTwins, "Largos Twins") },
                { (int)BossIds.MAMA, new BossData((int)BossIds.MAMA, "M.A.M.A.") },
                { (int)BossIds.Matthias, new BossData((int)BossIds.Matthias, "Matthias Gabrel") },
                { (int)BossIds.MediumGolem, new BossData((int)BossIds.MediumGolem, "Medium Kitty Golem", "Golem log", "Golem log") },
                { (int)BossIds.MursaatOverseer, new BossData((int)BossIds.MursaatOverseer, "Mursaat Overseer") },
                { (int)BossIds.Qadim, new BossData((int)BossIds.Qadim, "Qadim") },
                { (int)BossIds.RiverOfSouls, new BossData((int)BossIds.RiverOfSouls, "River of Souls", "River of Souls log", "River of Souls log") },
                { (int)BossIds.Sabetha, new BossData((int)BossIds.Sabetha, "Sabetha the Saboteur") },
                { (int)BossIds.Samarog, new BossData((int)BossIds.Samarog, "Samarog") },
                { (int)BossIds.Siax, new BossData((int)BossIds.Siax, "Siax the Corrupted") },
                { (int)BossIds.Skorvald, new BossData((int)BossIds.Skorvald, "Skorvald the Shattered") },
                { (int)BossIds.Slothasor, new BossData((int)BossIds.Slothasor, "Slothasor") },
                { (int)BossIds.SoullessHorror, new BossData((int)BossIds.SoullessHorror, "Soulless Horror") },
                { (int)BossIds.StandardGolem, new BossData((int)BossIds.StandardGolem, "Standard Kitty Golem", "Golem log", "Golem log") },
                { (int)BossIds.ValeGuardian, new BossData((int)BossIds.ValeGuardian, "Vale Guardian") },
                { (int)BossIds.WvW, new BossData((int)BossIds.WvW, "World vs World", "WvW log", "WvW log") },
                { (int)BossIds.Xera, new BossData((int)BossIds.Xera, "Xera") }
            };
        }

        public static bool IsFractal(int bossId) => (bossId == (int)BossIds.Arkk) || (bossId == (int)BossIds.Artsariiv) || (bossId == (int)BossIds.MAMA) || (bossId == (int)BossIds.Siax) || (bossId == (int)BossIds.Skorvald);

        public static bool IsGolem(int bossId) => (bossId == (int)BossIds.StandardGolem) || (bossId == (int)BossIds.MediumGolem) || (bossId == (int)BossIds.LargeGolem);

        public static bool IsEvent(int bossId) => (bossId == (int)BossIds.BanditTrio) || (bossId == (int)BossIds.RiverOfSouls);

        public static bool IsWvW(int bossId) => bossId == (int)BossIds.WvW;
    }
}
