using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Web.Script.Serialization;
using PlenBotLogUploader.PlenyxAPI;

namespace PlenBotLogUploader
{
    public partial class FormPing : Form
    {
        // fields
        private FormMain mainLink;

        public FormPing(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
        }

        private void FormPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            mainLink.RegistryAccess.SetValue("remotePingMethod", radioButtonMethodGet.Checked ? 0 : 1);
            mainLink.RegistryAccess.SetValue("remotePingUrl", textBoxURL.Text);
            mainLink.RegistryAccess.SetValue("remotePingSign", textBoxSign.Text);
        }

        private void checkBoxEnablePing_CheckedChanged(object sender, EventArgs e)
        {
            mainLink.RegistryAccess.SetValue("remotePingEnabled", checkBoxEnablePing.Checked ? 1 : 0);
            groupBoxRemoteSettings.Enabled = checkBoxEnablePing.Enabled;
        }

        private void FormPing_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Process.Start("https://plenbot.net/uploader/#setup");
        }

        private void buttonPlenyxWay_Click(object sender, EventArgs e)
        {
            radioButtonMethodPost.Checked = true;
            textBoxURL.Text = "https://plenbot.net/uploader/ping/";
            textBoxSign.Text = "";
            MessageBox.Show("In order to use the ping server you need to have a valid sign.\nA browser window will be opened with instructions on how to get one.\nFrom there you can connect PlenBot to your Discord server and post logs directly into your desired channel. (WIP)");
            Process.Start("https://plenbot.net/uploader/#setup-sign");
        }

        public async void PingTest()
        {
            try
            {
                string response = await mainLink.DownloadFileAsyncToString($"{textBoxURL.Text}pingtest/?sign={textBoxSign.Text}");
                try
                {
                    PlenyxAPIPingTest pingtest = new JavaScriptSerializer().Deserialize<PlenyxAPIPingTest>(response);
                    if (pingtest.IsValid())
                    {
                        MessageBox.Show("Ping settings are valid.");
                    }
                    else
                    {
                        MessageBox.Show("Sign is not valid.");
                    }
                }
                catch
                {
                    MessageBox.Show("There has been an error checking the server settings.\nIs the server correctly set?");
                }
            }
            catch
            {
                MessageBox.Show("There has been an error pinging the server.\nCheck your settings.");
            }
        }

        private void buttonTestPing_Click(object sender, EventArgs e) => PingTest();
    }
}
