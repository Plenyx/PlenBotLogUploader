using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Timers;

namespace IRCClient
{
    class IrcClient
    {
        private string UserName { get; set; }
        private string Password { get; set; }
        private string ServerIp { get; set; }
        private int ServerPort { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader InputStream { get; set; }
        private StreamWriter OutputStream { get; set; }
        private Timer KeepAliveTimer { get; set; }
        public string ChannelName { get; set; }
        public bool Connected { get; set; } = false;

        public IrcClient(string userName, string password)
        {
            UserName = userName;
            Password = password;
            ServerIp = "irc.chat.twitch.tv";
            ServerPort = 6667;
            CreateAndLogin();
        }

        public IrcClient(string userName, string password, string channelName)
        {
            UserName = userName;
            Password = password;
            ServerIp = "irc.chat.twitch.tv";
            ServerPort = 6667;
            ChannelName = channelName;
            CreateAndLogin();
        }

        public IrcClient(string userName, string password, string ip, int port)
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
            KeepAliveTimer = new Timer
            {
                Enabled = false,
                Interval = 4 * 60 * 1000 // 4 minutes
            };
            KeepAliveTimer.Elapsed += KeepAliveTimerTick;
            Login();
        }

        public async void Login()
        {
            await OutputStream.WriteLineAsync("PASS " + Password);
            await OutputStream.WriteLineAsync("NICK " + UserName);
            if (ChannelName != "")
                await OutputStream.WriteLineAsync("JOIN #" + ChannelName);
            await OutputStream.FlushAsync();
            KeepAliveTimer.Enabled = true;
            this.Connected = true;
        }

        public async Task<bool> JoinRoom(string channelName)
        {
            if (ChannelName != "")
                await LeaveRoom(ChannelName);
            ChannelName = channelName;
            await OutputStream.WriteLineAsync("JOIN #" + channelName);
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> LeaveRoom(string channelName)
        {
            ChannelName = "";
            await OutputStream.WriteLineAsync("LEAVE #" + channelName);
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendIrcMessage(string message)
        {
            await OutputStream.WriteLineAsync(message);
            await OutputStream.FlushAsync();
            return true;
        }

        public async Task<bool> SendChatMessage(string message)
        {
            await OutputStream.WriteLineAsync(":" + UserName + "!" + UserName + "@" + UserName + ".tmi.twitch.tv PRIVMSG #" + ChannelName + " :" + message);
            await OutputStream.FlushAsync();
            return true;
        }

        public async void SendWhisperMessage(string userName, string message) => await SendIrcMessage("PRIVMSG #jtv :/w " + userName + " " + message);

        public async Task<string> ReadMessage() => await InputStream.ReadLineAsync();

        private async void KeepAliveTimerTick(object sender, EventArgs e) => await SendIrcMessage("PING " + ServerIp);
    }
}
