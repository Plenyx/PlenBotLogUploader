namespace PlenBotLogUploader.Teams
{
    public enum WebhookTeamLimiter
    {
        AtLeast = 0,
        Exact = 1,
        Except = 2,
        MeCommander = 3,
        CommanderName = 4,
        AND = 5,
        OR = 6,
    }
}
