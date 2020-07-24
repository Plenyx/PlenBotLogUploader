using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormDPSReportSettings : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormDPSReportSettings(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormDPSReportSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            if (radioButtonB.Checked)
            {
                mainLink.DPSReportServer = "https://b.dps.report";
                Properties.Settings.Default.DPSReportServer = 2;
            }
            else if (radioButtonA.Checked)
            {
                mainLink.DPSReportServer = "http://a.dps.report";
                Properties.Settings.Default.DPSReportServer = 1;
            }
            else
            {
                mainLink.DPSReportServer = "https://dps.report";
                Properties.Settings.Default.DPSReportServer = 0;
            }
            Properties.Settings.Default.DPSReportUsertokenEnabled = checkBoxDPSReportEnableUsertoken.Checked;
            Properties.Settings.Default.DPSReportUsertoken = textBoxDPSReportUsertoken.Text;
        }

        private void ButtonDPSReportShowUsertoken_MouseDown(object sender, MouseEventArgs e) => textBoxDPSReportUsertoken.UseSystemPasswordChar = false;

        private void ButtonDPSReportShowUsertoken_MouseUp(object sender, MouseEventArgs e) => textBoxDPSReportUsertoken.UseSystemPasswordChar = true;

        private void CheckBoxDPSReportEnableUsertoken_CheckedChanged(object sender, System.EventArgs e)
        {
            var enable = checkBoxDPSReportEnableUsertoken.Checked;
            textBoxDPSReportUsertoken.Enabled = enable;
            buttonDPSReportShowUsertoken.Enabled = enable;
        }
    }
}
