namespace PlenBotLogUploader.Teams
{
    internal enum TeamLimiter
    {
        AND = 0,
        OR = 1,
        AtLeast = 2,
        Exact = 3,
        Except = 4,
        CommanderName = 5,
        NOT = 6,
    }
}
