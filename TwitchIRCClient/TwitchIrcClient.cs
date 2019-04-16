using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TwitchIRCClient
{
    class TwitchIrcClient : IDisposable
    {
        // public
        public string LastChannelName { get; private set; } = "";
        public List<string> ChannelNames { get; private set; } = new List<string>();
        public bool Connecting { get; set; } = false;
        public bool Connected { get; set; } = false;
        public Thread ReadMessagesThread { get; private set; }
        public event EventHandler<IrcMessageEventArgs> ReceiveMessage;
        public event EventHandler<IrcChangedEventArgs> StateChange;

        // private
        private string userName;
        private string password;
        private string serverIp;
        private int serverPort;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        public TwitchIrcClient(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            serverIp = "irc.chat.twitch.tv";
            serverPort = 6667;
        }

        public TwitchIrcClient(string userName, string password, string channelName)
        {
            this.userName = userName;
            this.password = password;
            serverIp = "irc.chat.twitch.tv";
            serverPort = 6667;
            channelName = channelName.ToLower();
            LastChannelName = channelName;
            ChannelNames.Add(channelName);
        }

        public TwitchIrcClient(string userName, string password, string ip, int port)
        {
            this.userName = userName;
            this.password = password;
            serverIp = ip;
            serverPort = port;
        }

        public void BeginConnection()
        {
            tcpClient = new TcpClient(serverIp, serverPort);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());
            Login();
            StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Connecting));
        }

        public async void Login()
        {
            await outputStream.WriteLineAsync($"PASS {password}");
            await outputStream.WriteLineAsync($"NICK {userName}");
            if (LastChannelName != "")
            {
                await outputStream.WriteLineAsync($"JOIN #{LastChannelName}");
                StateChange?.Invoke(this, new IrcChangedEventArgs(LastChannelName));
            }
            await outputStream.FlushAsync();
            Connecting = true;
            ReceiveMessage += MessageListener;
            ReadMessagesThread = new Thread(ReadMessages);
            ReadMessagesThread.Start();
        }

        public async Task<bool> JoinRoom(string channelName, bool partPreviousChannels = false)
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
                    await LeaveRoom(name);
                    StateChange?.Invoke(this, new IrcChangedEventArgs(name, true));
                }
                ChannelNames.Clear();
            }
            StateChange?.Invoke(this, new IrcChangedEventArgs(channelName));
            LastChannelName = channelName;
            ChannelNames.Add(channelName);
            await outputStream.WriteLineAsync($"JOIN #{channelName}");
            await outputStream.FlushAsync();
            return true;
        }

        public async Task<bool> LeaveRoom(string channelName)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            StateChange?.Invoke(this, new IrcChangedEventArgs(channelName, true));
            ChannelNames.Remove(channelName);
            await outputStream.WriteLineAsync($"PART #{channelName}");
            await outputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendIrcMessage(string message)
        {
            await outputStream.WriteLineAsync(message);
            await outputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendChatMessage(string channelName, string message)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            await outputStream.WriteLineAsync($":{userName}!{userName}@{userName}.tmi.twitch.tv PRIVMSG #{channelName} :{message}");
            await outputStream.FlushAsync();
            return true;
        }

        public async void SendWhisperMessage(string userName, string message) => await SendIrcMessage($"PRIVMSG #jtv :/w {userName} {message}");

        public void Dispose()
        {
            ReadMessagesThread?.Abort();
            Connecting = false;
            Connected = false;
            inputStream?.Dispose();
            outputStream?.Dispose();
            tcpClient?.Close();
        }

        private async Task<string> ReadMessage() => await inputStream.ReadLineAsync();

        private async void ReadMessages()
        {
            while (Connecting || Connected)
            {
                try
                {
                    string message = await ReadMessage();
                    OnMessageReceived(new IrcMessageEventArgs(message));
                }
                catch { /* do nothing */ }
            }
        }

        protected void OnMessageReceived(IrcMessageEventArgs e) => ReceiveMessage?.Invoke(this, e);

        protected async void MessageListener(object sender, IrcMessageEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            if (!Connected && e.Message.Equals($":tmi.twitch.tv 001 {userName} :Welcome, GLHF!"))
            {
                Connected = true;
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.Connected));
            }
            else if (Connected && e.Message.Equals("PING :tmi.twitch.tv"))
            {
                await SendIrcMessage("PONG :tmi.twitch.tv");
            }
            else if (Connecting && e.Message.Equals($":{userName}.tmi.twitch.tv 353 {userName} = #{LastChannelName} :{userName}"))
            {
                StateChange?.Invoke(this, new IrcChangedEventArgs(IrcStates.ChannelJoined));
            }
        }
    }
}
