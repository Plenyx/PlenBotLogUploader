namespace PlenBotLogUploader.DPSReport
{
    public static class Players
    {
        public static string ResolveSpecName(int profession, int elite_spec) => ((EliteSpecs)elite_spec).ToString() == elite_spec.ToString() ? $"Base {((Professions)profession).ToString()}" : ((EliteSpecs)elite_spec).ToString();
    }
}
