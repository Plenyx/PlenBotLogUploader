using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PlenBotLogUploader.TwitchIRCClient
{
    class TwitchIrcClient : IDisposable
    {
        // public
        /// <summary>
        /// Last channel joined.
        /// </summary>
        public string LastChannelName { get; private set; } = "";

        /// <summary>
        /// List of all channel currently joined.
        /// </summary>
        public List<string> ChannelNames { get; private set; } = new List<string>();

        /// <summary>
        /// Indicates if the connection is about to commence.
        /// </summary>
        public bool Connecting { get; private set; } = false;

        /// <summary>
        /// Indicates if a successfull connection with Twitch has been estabilished.
        /// </summary>
        public bool Connected { get; private set; } = false;

        /// <summary>
        /// A thread for message invokes.
        /// </summary>
        public Thread ReadMessagesThread { get; private set; }

        /// <summary>
        /// An event that triggers on new IRC message being received.
        /// </summary>
        public event EventHandler<IrcMessageEventArgs> ReceiveMessage;

        /// <summary>
        /// An event that triggers on new IRC state change.
        /// </summary>
        public event EventHandler<IrcChangedEventArgs> StateChange;

        // private
        private readonly string userName;
        private readonly string password;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        // constants
        private const string serverIp = "irc.chat.twitch.tv";
        private const int serverPort = 6667;

        /// <summary>
        /// Create TwitchIrcClient class using user name and a password.
        /// </summary>
        /// <param name="userName">Username for Twitch IRC</param>
        /// <param name="password">Password for Twitch IRC</param>
        public TwitchIrcClient(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// Create TwitchIrcClient class using user name, a password and immediate channel join.
        /// </summary>
        /// <param name="userName">Username for Twitch IRC</param>
        /// <param name="password">Password for Twitch IRC</param>
        /// <param name="channelName">Channel to connect to at startup</param>
        public TwitchIrcClient(string userName, string password, string channelName)
        {
            this.userName = userName;
            this.password = password;
            LastChannelName = channelName.ToLower();
            ChannelNames.Add(LastChannelName);
        }

        /// <summary>
        /// Start the connection to the IRC.
        /// </summary>
        public void BeginConnection()
        {
            try
            {
                tcpClient = new TcpClient(serverIp, serverPort);
                inputStream = new StreamReader(tcpClient.GetStream());
                outputStream = new StreamWriter(tcpClient.GetStream());
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Connecting));
                LoginAsync();
            }
            catch
            {
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
            }
        }

        private async void LoginAsync()
        {
            try
            {
                await outputStream.WriteLineAsync($"PASS {password}");
                await outputStream.WriteLineAsync($"NICK {userName}");
                if (LastChannelName != "")
                {
                    await outputStream.WriteLineAsync($"JOIN #{LastChannelName}");
                    StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.ChannelJoining, LastChannelName));
                }
                await outputStream.FlushAsync();
                Connecting = true;
                ReceiveMessage += OnMessageReceived;
                ReadMessagesThread = new Thread(ReadMessagesAsync)
                {
                    IsBackground = true
                };
                ReadMessagesThread.Start();
            }
            catch
            {
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
            }
        }

        /// <summary>
        /// Enter IRC room asynchronously.
        /// </summary>
        /// <param name="channelName">Room name to enter</param>
        /// <param name="partPreviousChannels">if set to true leave all previous entered channels</param>
        /// <returns>If room was entered successfully.</returns>
        public async Task<bool> JoinRoomAsync(string channelName, bool partPreviousChannels = false)
        {
            channelName = channelName.ToLower();
            if (ChannelNames.Contains(channelName))
            {
                return false;
            }
            if (partPreviousChannels)
            {
                foreach (string name in ChannelNames)
                {
                    await LeaveRoomAsync(name);
                }
                ChannelNames.Clear();
            }
            try
            {
                await outputStream.WriteLineAsync($"JOIN #{channelName}");
                await outputStream.FlushAsync();
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.ChannelJoining, channelName));
                LastChannelName = channelName;
                ChannelNames.Add(channelName);
                return true;
            }
            catch
            {
                Connected = false;
                Connecting = false;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                return false;
            }
        }

        /// <summary>
        /// Leave IRC room asynchronously.
        /// </summary>
        /// <param name="channelName">Room name to leave</param>
        /// <returns>If room was left successfully.</returns>
        public async Task<bool> LeaveRoomAsync(string channelName)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            try
            {
                await outputStream.WriteLineAsync($"PART #{channelName}");
                await outputStream.FlushAsync();
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.ChannelLeaving, channelName));
                ChannelNames.Remove(channelName);
                return true;
            }
            catch
            {
                Connected = false;
                Connecting = false;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                return false;
            }
        }

        /// <summary>
        /// Sends an IRC message to the server.
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <returns>If message was successfully sent.</returns>
        public async Task<bool> SendIrcMessageAsync(string message)
        {
            try
            {
                await outputStream.WriteLineAsync(message);
                await outputStream.FlushAsync();
                return true;
            }
            catch
            {
                Connected = false;
                Connecting = false;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                return false;
            }
        }

        /// <summary>
        /// Sends a message to a specified channel.
        /// </summary>
        /// <param name="channelName">Name of the channel</param>
        /// <param name="message">Message to send</param>
        /// <returns>If message was successfully sent.</returns>
        public async Task<bool> SendChatMessageAsync(string channelName, string message)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            try
            {
                await outputStream.WriteLineAsync($":{userName}!{userName}@{userName}.tmi.twitch.tv PRIVMSG #{channelName} :{message}");
                await outputStream.FlushAsync();
                return true;
            }
            catch
            {
                Connected = false;
                Connecting = false;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                return false;
            }
        }

        /// <summary>
        /// Disposes of the resources held by the class.
        /// </summary>
        public void Dispose()
        {
            Connecting = false;
            Connected = false;
            ReadMessagesThread?.Abort();
            inputStream?.Dispose();
            outputStream?.Dispose();
            tcpClient?.Close();
        }

        private async void ReadMessagesAsync()
        {
            while (Connecting || Connected)
            {
                try
                {
                    string message = await inputStream.ReadLineAsync();
                    ReceiveMessage?.Invoke(this, new IrcMessageEventArgs(message));
                }
                catch
                {
                    StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                    Connected = false;
                    Connecting = false;
                }
            }
        }

        protected async void OnMessageReceived(object sender, IrcMessageEventArgs e)
        {
            if ((e == null) || (e.Message == null))
            {
                if (Connecting && !Connected)
                {
                    StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.FailedConnection));
                }
                else
                {
                    StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Disconnected));
                }
                Connecting = false;
                Connected = false;
                return;
            }
            if (!Connected && e.Message.Equals($":tmi.twitch.tv 001 {userName} :Welcome, GLHF!"))
            {
                Connected = true;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Connected));
            }
            else if (Connected && e.Message.Equals("PING :tmi.twitch.tv"))
            {
                await SendIrcMessageAsync("PONG :tmi.twitch.tv");
            }
            else if (Connected && e.Message.Equals($":{userName}.tmi.twitch.tv 353 {userName} = #{LastChannelName} :{userName}"))
            {
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.ChannelJoined, LastChannelName));
            }
        }
    }
}
