namespace PlenBotLogUploader.TwitchIRCClient
{
    public enum IrcStates
    {
        Disconnected,
        Connecting,
        Connected,
        ChannelJoining,
        ChannelJoined,
        ChannelLeaving,
        ChannelLeft
    }
}
