using PlenBotLogUploader.AppSettings;
using System;
using System.Windows.Forms;
using static Hardstuck.GuildWars2.BuildCodes.V2.Static;

namespace PlenBotLogUploader
{
    public partial class FormHsBuildCodeCompressionSettings : Form
    {
        public FormHsBuildCodeCompressionSettings()
        {
            InitializeComponent();
            Icon = Properties.Resources.AppIcon;

            var settings = ApplicationSettings.Current.BuildCodes;
            checkBoxDemoteRunes.Checked = settings.DemoteRunes;
            checkBoxDemoteSigils.Checked = settings.DemoteSigils;
            foreach (var option in Enum.GetValues<CompressionOptions>())
            {
                if ((option == CompressionOptions.ALL) || (option == CompressionOptions.NONE))
                {
                    continue;
                }
                checkboxListCompressionOptions.Items.Add(option, settings.Compression.HasFlag(option));
            }
        }

        private void CheckBoxDemoteRunes_CheckedChanged(object s, EventArgs e) => ApplicationSettings.Current.BuildCodes.DemoteRunes = checkBoxDemoteRunes.Checked;
        private void CheckBoxDemoteSigils_CheckedChanged(object s, EventArgs e) => ApplicationSettings.Current.BuildCodes.DemoteSigils = checkBoxDemoteSigils.Checked;

        private void CheckboxListCompressionOptions_ItemCheck(object s, ItemCheckEventArgs e)
        {
            var compressionOption = (CompressionOptions)checkboxListCompressionOptions.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                ApplicationSettings.Current.BuildCodes.Compression |= compressionOption;
            }
            else
            {
                ApplicationSettings.Current.BuildCodes.Compression &= ~compressionOption;
            }
        }
    }
}
