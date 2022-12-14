using PlenBotLogUploader.AppSettings;
using System;
using System.Windows.Forms;
using static Hardstuck.GuildWars2.BuildCodes.V2.Static;

namespace PlenBotLogUploader
{
	public partial class FormHSBuildCodeCompressionSettings : Form
	{
		public FormHSBuildCodeCompressionSettings()
		{
			InitializeComponent();

			var settings = ApplicationSettings.Current.BuildCodes;
			this.CheckBoxDemoteRunes .Checked = settings.DemoteRunes;
			this.CheckBoxDemoteSigils.Checked = settings.DemoteSigils;
			foreach(var option in Enum.GetValues<CompressionOptions>())
			{
				if(option == CompressionOptions.ALL || option == CompressionOptions.NONE) continue;
				this.CheckboxListCompressionOptions.Items.Add(option, settings.Compression.HasFlag(option));
			}
		}

		private void  CheckBoxDemoteRunes_CheckedChanged(object s, EventArgs e) => ApplicationSettings.Current.BuildCodes.DemoteRunes  = this.CheckBoxDemoteRunes .Checked;
		private void CheckBoxDemoteSigils_CheckedChanged(object s, EventArgs e) => ApplicationSettings.Current.BuildCodes.DemoteSigils = this.CheckBoxDemoteSigils.Checked;

		private void CheckboxListCompressionOptions_ItemCheck(object s, ItemCheckEventArgs e)
		{
			var compressionOption = (CompressionOptions)this.CheckboxListCompressionOptions.Items[e.Index];

			if(e.NewValue == CheckState.Checked)
				ApplicationSettings.Current.BuildCodes.Compression |= compressionOption;
			else
				ApplicationSettings.Current.BuildCodes.Compression &= ~compressionOption;
		}
	}
}
