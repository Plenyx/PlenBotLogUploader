namespace PlenBotLogUploader.DPSReport
{
    public static class Players
    {
        public static string ResolveSpecName(int profession, int eliteSpec) => ((EliteSpecs)eliteSpec).ToString() == eliteSpec.ToString() ? $"Base {((Professions)profession)}" : ((EliteSpecs)eliteSpec).ToString();
    }
}
