using System.Windows.Forms;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormEditBossData : Form
    {
        // fields
        private FormTwitchLogMessages editLink;
        private BossData data;

        public FormEditBossData(FormTwitchLogMessages editLink, BossData data)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            Icon = Properties.Resources.AppIcon;
            Text = $"{data.Name} ({data.BossId})";
            textBoxSuccessMsg.Text = data.SuccessMsg;
            textBoxFailMsg.Text = data.FailMsg;
        }

        private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e) => editLink.AllBosses[data.BossId] = new BossData(data.BossId, data.Name, textBoxSuccessMsg.Text, textBoxFailMsg.Text);
    }
}
