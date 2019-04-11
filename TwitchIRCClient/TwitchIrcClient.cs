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
        public string LastChannelName { get; private set; }
        public List<string> ChannelNames { get; private set; } = new List<string>();
        public bool Connecting { get; set; } = false;
        public bool Connected { get; set; } = false;
        public Thread ReadMessagesThread { get; private set; }
        public event EventHandler<IrcMessageEventArgs> ReceiveMessage;
        public event EventHandler<IrcConnectionChangedEventArgs> ConnectionChange;
        // private
        private string UserName { get; set; }
        private string Password { get; set; }
        private string ServerIp { get; set; }
        private int ServerPort { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader InputStream { get; set; }
        private StreamWriter OutputStream { get; set; }

        public TwitchIrcClient(string userName, string password)
        {
            UserName = userName;
            Password = password;
            ServerIp = "irc.chat.twitch.tv";
            ServerPort = 6667;
            CreateAndLogin();
        }

        public TwitchIrcClient(string userName, string password, string channelName)
        {
            UserName = userName;
            Password = password;
            ServerIp = "irc.chat.twitch.tv";
            ServerPort = 6667;
            channelName = channelName.ToLower();
            LastChannelName = channelName;
            ChannelNames.Add(channelName);
            CreateAndLogin();
        }

        public TwitchIrcClient(string userName, string password, string ip, int port)
        {
            UserName = userName;
            Password = password;
            ServerIp = ip;
            ServerPort = port;
            CreateAndLogin();
        }

        private void CreateAndLogin()
        {
            TcpClient = new TcpClient(ServerIp, ServerPort);
            InputStream = new StreamReader(TcpClient.GetStream());
            OutputStream = new StreamWriter(TcpClient.GetStream());
            Login();
        }

        public async void Login()
        {
            await OutputStream.WriteLineAsync($"PASS {Password}");
            await OutputStream.WriteLineAsync($"NICK {UserName}");
            if (LastChannelName != "")
            {
                await OutputStream.WriteLineAsync($"JOIN #{LastChannelName}");
            }
            await OutputStream.FlushAsync();
            Connecting = true;
            ReceiveMessage += MessageListener;
            ReadMessagesThread = new Thread(ReadMessages);
            ReadMessagesThread.Start();
        }

        public async Task<bool> JoinRoom(string channelName, bool partChannel = false)
        {
            channelName = channelName.ToLower();
            if (ChannelNames.Contains(channelName))
            {
                return false;
            }
            if (partChannel)
            {
                await LeaveRoom(channelName);
            }
            LastChannelName = channelName;
            await OutputStream.WriteLineAsync($"JOIN #{channelName}");
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> LeaveRoom(string channelName)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            ChannelNames.Remove(channelName);
            await OutputStream.WriteLineAsync($"PART #{channelName}");
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendIrcMessage(string message)
        {
            await OutputStream.WriteLineAsync(message);
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendChatMessage(string channelName, string message)
        {
            channelName = channelName.ToLower();
            if (!ChannelNames.Contains(channelName))
            {
                return false;
            }
            await OutputStream.WriteLineAsync($":{UserName}!{UserName}@{UserName}.tmi.twitch.tv PRIVMSG #{channelName} :{message}");
            await OutputStream.FlushAsync();
            return true;
        }

        public async void SendWhisperMessage(string userName, string message) => await SendIrcMessage($"PRIVMSG #jtv :/w {userName} {message}");

        public void Dispose()
        {
            ReadMessagesThread.Abort();
            Connecting = false;
            Connected = false;
            InputStream.Dispose();
            OutputStream.Dispose();
            TcpClient.Close();
        }

        private async Task<string> ReadMessage() => await InputStream.ReadLineAsync();

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
            if (!Connected && e.Message.Equals($":tmi.twitch.tv 001 {UserName} :Welcome, GLHF!"))
            {
                Connected = true;
                ConnectionChange?.Invoke(this, new IrcConnectionChangedEventArgs(true));
            }
            else if (Connected && e.Message.Equals("PING :tmi.twitch.tv"))
            {
                await SendIrcMessage("PONG :tmi.twitch.tv");
            }
        }
    }
}
