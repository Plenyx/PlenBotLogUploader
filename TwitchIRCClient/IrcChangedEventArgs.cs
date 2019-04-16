using System;

namespace TwitchIRCClient
{
    public class IrcChangedEventArgs : EventArgs
    {
        public IrcStates NewState { get; }
        public string Channel { get; }

        public IrcChangedEventArgs(IrcStates newState)
        {
            NewState = newState;
        }

        public IrcChangedEventArgs(string channel, bool channelPart = false)
        {
            NewState = (channelPart) ? IrcStates.ChannelLeaving : IrcStates.ChannelJoining;
            Channel = channel;
        }
    }
}
