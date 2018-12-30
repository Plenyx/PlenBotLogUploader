using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Timers;

namespace IRCClient
{
    class IrcClient
    {
        private string userName;
        private string channelName;
        private string password;
        private string serverIp;
        private int serverPort;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;
        private Timer KeepAliveTimer;

        public IrcClient(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.serverIp = "irc.chat.twitch.tv";
            this.serverPort = 6667;
            createAndLogin();
        }

        public IrcClient(string userName, string password, string ip, int port) : this(userName, password)
        {
            this.serverIp = ip;
            this.serverPort = port;
            createAndLogin();
        }

        private void createAndLogin()
        {
            this.tcpClient = new TcpClient(this.serverIp, this.serverPort);
            this.inputStream = new StreamReader(tcpClient.GetStream());
            this.outputStream = new StreamWriter(tcpClient.GetStream());

            this.KeepAliveTimer = new Timer();
            this.KeepAliveTimer.Enabled = false;
            this.KeepAliveTimer.Interval = 4 * 60 * 1000;
            this.KeepAliveTimer.Elapsed += keepAliveTimerTick;

            login();
        }

        public async void login()
        {
            await this.outputStream.WriteLineAsync("PASS " + password);
            await this.outputStream.WriteLineAsync("NICK " + userName);
            await this.outputStream.FlushAsync();
            this.KeepAliveTimer.Enabled = true;
        }

        public async Task<bool> joinRoom(string channelName)
        {
            this.channelName = channelName;
            await this.outputStream.WriteLineAsync("JOIN #" + channelName);
            await this.outputStream.FlushAsync();
            return true;
        }

        public async Task<bool> leaveRoom(string channelName)
        {
            this.channelName = "";
            await this.outputStream.WriteLineAsync("LEAVE #" + channelName);
            await this.outputStream.FlushAsync();
            return true;
        }

        public string getUserName()
        {
            return this.userName;
        }

        public async Task<bool> sendIrcMessage(string message)
        {
            await this.outputStream.WriteLineAsync(message);
            await this.outputStream.FlushAsync();
            return true;
        }

        public async Task<bool> sendChatMessage(string message)
        {
            await this.outputStream.WriteLineAsync(":" + this.userName + "!" + this.userName + "@" + this.userName + ".tmi.twitch.tv PRIVMSG #" + this.channelName + " :" + message);
            await this.outputStream.FlushAsync();
            return true;
        }

        public async void sendWhisperMessage(string userName, string message)
        {
            await this.sendIrcMessage("PRIVMSG #jtv :/w " + userName + " " + message);
        }

        public async Task<string> readMessage()
        {
            return await this.inputStream.ReadLineAsync();
        }

        private async void keepAliveTimerTick(object sender, EventArgs e)
        {
            await this.sendIrcMessage("PING "+ this.serverIp);
        }
    }
}
