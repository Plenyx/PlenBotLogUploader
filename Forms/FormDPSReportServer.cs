using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormDPSReportServer : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormDPSReportServer(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormDPSReportServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.DPSReportServer = radioButtonA.Checked ? 1 : 0;
            if (radioButtonA.Checked)
            {
                mainLink.DPSReportServer = "a.dps.report";
            }
            else
            {
                mainLink.DPSReportServer = "dps.report";
            }
        }
    }
}
