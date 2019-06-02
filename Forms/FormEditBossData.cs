using System.Windows.Forms;
using PlenBotLogUploader.DPSReport;

namespace PlenBotLogUploader
{
    public partial class FormEditBossData : Form
    {
        #region definitions
        // fields
        private FormBossData editLink;
        private BossData data;
        private int reservedId;
        #endregion

        public FormEditBossData(FormBossData editLink, BossData data, int reservedId)
        {
            this.editLink = editLink;
            InitializeComponent();
            this.data = data;
            this.reservedId = reservedId;
            Icon = Properties.Resources.AppIcon;
            if (data == null)
            {
                Text = "Add a new boss";
            }
            else
            {
                Text = $"{data.Name} ({data.BossId})";
            }
            textBoxBossID.Text = data?.BossId.ToString() ?? "";
            textBoxBossName.Text = data?.Name ?? "";
            textBoxSuccessMsg.Text = data?.SuccessMsg ?? "Boss kill";
            textBoxFailMsg.Text = data?.FailMsg ?? "Boss pull";
            textBoxIcon.Text = data?.Icon ?? "";
        }

        private void FormEditBossData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (int.TryParse(textBoxBossID.Text, out int bossId))
            {
                if (textBoxBossName.Text != "")
                {
                    if (data == null)
                    {
                        editLink.AllBosses[reservedId] = new BossData(bossId, textBoxBossName.Text, textBoxSuccessMsg.Text, textBoxFailMsg.Text, textBoxIcon.Text);
                        editLink.listViewBosses.Items.Add(new ListViewItem() { Name = reservedId.ToString(), Text = textBoxBossName.Text });
                    }
                    else
                    {
                        editLink.AllBosses[reservedId] = new BossData(bossId, textBoxBossName.Text, textBoxSuccessMsg.Text, textBoxFailMsg.Text, textBoxIcon.Text);
                    }
                }
            }
        }
    }
}
