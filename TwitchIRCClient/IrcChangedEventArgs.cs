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

        public IrcChangedEventArgs(IrcStates newState, string channel)
        {
            NewState = newState;
            Channel = channel;
        }
    }
}
