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
        public string LastChannelName { get; private set; }
        public List<string> ChannelNames { get; private set; } = new List<string>();
        public bool Connected { get; set; } = false;
        public EventHandler<IrcMessageEventArgs> ReceiveMessage { get; set; }
        public Thread ReadMessagesThread { get; private set; }
        public Thread PingThread { get; private set; }

        private string UserName { get; set; }
        private string Password { get; set; }
        private string ServerIp { get; set; }
        private int ServerPort { get; set; }
        private TcpClient TcpClient { get; set; }
        private StreamReader InputStream { get; set; }
        private StreamWriter OutputStream { get; set; }
        private const int PingTimerMS = 240000;

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
            Connected = true;
            // ReceiveMessage += MessageListener; // add event listener to received message, see example at the end
            ReadMessagesThread = new Thread(ReadMessages);
            ReadMessagesThread.Start();
            PingThread = new Thread(KeepConnectionAlive);
            PingThread.Start();
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
            PingThread.Abort();
            Connected = false;
            InputStream.Dispose();
            OutputStream.Dispose();
            TcpClient.Close();
        }

        private async Task<string> ReadMessage() => await InputStream.ReadLineAsync();

        private async void KeepConnectionAlive()
        {
            while (Connected)
            {
                Thread.Sleep(PingTimerMS);
                await SendIrcMessage($"PING {ServerIp}");
            }
        }

        private async void ReadMessages()
        {
            while (Connected)
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


        /* * Example of an Event Listener to catch chat messages
        protected void MessageListener(object sender, IrcMessageEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            Console.WriteLine(e.Message);
        }*/
    }
}
