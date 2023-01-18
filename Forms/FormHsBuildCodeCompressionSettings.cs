using PlenBotLogUploader.AppSettings;
using PlenBotLogUploader.Tools;
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
            foreach (var compressionOption in HsBuildCodesCompressionSettingsHelperClass.All.AsSpan())
            {
                checkboxListCompressionOptions.Items.Add(compressionOption, settings.Compression.HasFlag(compressionOption.Value));
            }
            checkBoxDemoteRunes.CheckedChanged += CheckBoxDemoteRunes_CheckedChanged;
            checkBoxDemoteSigils.CheckedChanged += CheckBoxDemoteSigils_CheckedChanged;
            checkboxListCompressionOptions.ItemCheck += CheckboxListCompressionOptions_ItemCheck;
        }

        private void CheckBoxDemoteRunes_CheckedChanged(object s, EventArgs e)
        {
            ApplicationSettings.Current.BuildCodes.DemoteRunes = checkBoxDemoteRunes.Checked;
            ApplicationSettings.Current.Save();
        }

        private void CheckBoxDemoteSigils_CheckedChanged(object s, EventArgs e)
        {
            ApplicationSettings.Current.BuildCodes.DemoteSigils = checkBoxDemoteSigils.Checked;
            ApplicationSettings.Current.Save();
        }

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
            ApplicationSettings.Current.Save();
        }
    }
}
