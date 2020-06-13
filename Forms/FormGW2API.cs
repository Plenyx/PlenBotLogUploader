using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormGW2API : Form
    {
        #region definitions
        // fields
        private readonly FormMain mainLink;
        #endregion

        public FormGW2API(FormMain mainLink)
        {
            this.mainLink = mainLink;
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormGW2API_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.GW2APIKey = textBoxAPIKey.Text;
        }

        private void buttonShowAPIKey_MouseDown(object sender, MouseEventArgs e)
        {
            textBoxAPIKey.UseSystemPasswordChar = false;
        }

        private void buttonShowAPIKey_MouseUp(object sender, MouseEventArgs e)
        {
            textBoxAPIKey.UseSystemPasswordChar = true;
        }
    }
}
