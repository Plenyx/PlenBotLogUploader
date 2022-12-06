using Hardstuck.GuildWars2;
using System;

namespace PlenBotLogUploader.DpsReport
{
    public static class Players
    {
        public static string ResolveSpecName(int profession, int eliteSpec) => Enum.IsDefined(typeof(EliteSpecialisation), eliteSpec) ? ((EliteSpecialisation)eliteSpec).ToString() : $"Base {(Profession)profession}";
    }
}
