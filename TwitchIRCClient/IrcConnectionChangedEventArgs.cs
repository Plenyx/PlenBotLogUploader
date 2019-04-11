using System;

namespace TwitchIRCClient
{
    public class IrcConnectionChangedEventArgs : EventArgs
    {
        public bool NewState { get; }

        public IrcConnectionChangedEventArgs(bool newState)
        {
            NewState = newState;
        }
    }
}
