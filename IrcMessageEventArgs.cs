using System;

namespace TwitchIRCClient
{
    public class IrcMessageEventArgs : EventArgs
    {
        public string Message;
        public IrcMessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
