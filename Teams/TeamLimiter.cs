namespace PlenBotLogUploader.Teams
{
    public enum TeamLimiter
    {
        AtLeast = 0,
        Exact = 1,
        Except = 2,
        CommanderName = 3,
        AND = 4,
        OR = 5,
    }
}
