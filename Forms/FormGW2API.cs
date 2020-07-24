using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormGW2API : Form
    {
        #region definitions
        #endregion

        public FormGW2API()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;
        }

        private void FormGW2API_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Properties.Settings.Default.GW2APIKey = textBoxAPIKey.Text;
        }

        private void ButtonShowAPIKey_MouseDown(object sender, MouseEventArgs e) => textBoxAPIKey.UseSystemPasswordChar = false;

        private void ButtonShowAPIKey_MouseUp(object sender, MouseEventArgs e) => textBoxAPIKey.UseSystemPasswordChar = true;
    }
}
