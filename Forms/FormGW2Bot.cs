using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlenBotLogUploader
{
    public partial class FormGW2Bot : Form
    {
        #region definitions
        #endregion

        public FormGW2Bot()
        {
            InitializeComponent();
            Icon = Properties.Resources.gw2bot_icon;
        }

        private void FormGW2Bot_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
