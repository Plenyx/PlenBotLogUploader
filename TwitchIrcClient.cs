using System;
using System.IO;
using System.Timers;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TwitchIRCClient
{
    class TwitchIrcClient
    {
        private string UserName { get; set; }
        private string Password { get; set; }
        private string ServerIp { get; set; }
        private int ServerPort { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader InputStream { get; set; }
        private StreamWriter OutputStream { get; set; }
        private Timer KeepAliveTimer { get; set; }
        public string LastChannelName { get; private set; }
        public List<string> ChannelNames { get; private set; } = new List<string>();
        public bool Connected { get; set; } = false;
        public EventHandler ReceiveMessage { get; set; }


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
            await OutputStream.WriteLineAsync($"PASS {Password}");
            await OutputStream.WriteLineAsync($"NICK {UserName}");
            if(LastChannelName != "")
            {
                await OutputStream.WriteLineAsync($"JOIN #{LastChannelName}");
            }
            await OutputStream.FlushAsync();
            KeepAliveTimer.Enabled = true;
            Connected = true;
            // ReceiveMessage += MessageListener; // add event listener to received message, see example at the end
            await ReadMessages();
        }

        public async Task<bool> JoinRoom(string channelName, bool partChannel = false)
        {
            channelName = channelName.ToLower();
            if(ChannelNames.Contains(channelName))
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
            if(!ChannelNames.Contains(channelName))
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
            if(!ChannelNames.Contains(channelName))
            {
                return false;
            }
            await OutputStream.WriteLineAsync($":{UserName}!{UserName}@{UserName}.tmi.twitch.tv PRIVMSG #{channelName} :{message}");
            await OutputStream.FlushAsync();
            return true;
        }

        public async void SendWhisperMessage(string userName, string message) => await SendIrcMessage($"PRIVMSG #jtv :/w {userName} {message}");

        public async Task<string> ReadMessage() => await InputStream.ReadLineAsync();

        private async void KeepAliveTimerTick(object sender, EventArgs e) => await SendIrcMessage($"PING {ServerIp}");

        private async Task ReadMessages()
        {
            while(Connected)
            {
                string message = await ReadMessage();
                OnMessageReceived(new IrcMessageEventArgs(message));
            }
        }

        protected void OnMessageReceived(IrcMessageEventArgs e) => ReceiveMessage?.Invoke(this, e);
        
        
        /* * Example of an Event Listener to catch chat messages
        protected void MessageListener(object sender, EventArgs e)
        {
            if(e == null)
            {
                return;
            }
            IrcMessageEventArgs ea = (IrcMessageEventArgs)e;
            Console.WriteLine(ea.Message);
        }*/
    }
}
