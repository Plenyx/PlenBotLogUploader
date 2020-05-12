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
            if (radioButtonB.Checked)
            {
                mainLink.DPSReportServer = "b.dps.report";
                Properties.Settings.Default.DPSReportServer = 2;
            }
            else if (radioButtonA.Checked)
            {
                mainLink.DPSReportServer = "a.dps.report";
                Properties.Settings.Default.DPSReportServer = 1;
            }
            else
            {
                mainLink.DPSReportServer = "dps.report";
                Properties.Settings.Default.DPSReportServer = 0;
            }
        }
    }
}
