using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormDPSReportServer : Form
    {
        // fields
        private FormMain mainLink;

        public FormDPSReportServer(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
        }

        private void FormDPSReportServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            mainLink.RegistryAccess.SetValue("dpsReportServer", (radioButtonA.Checked) ? 1 : 0);
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
