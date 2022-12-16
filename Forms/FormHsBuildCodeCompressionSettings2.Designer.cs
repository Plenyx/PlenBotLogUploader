namespace PlenBotLogUploader
{
	partial class FormHsBuildCodeCompressionSettings2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHsBuildCodeCompressionSettings2));
            this.labelCompressionSettings = new System.Windows.Forms.Label();
            this.checkBoxDemoteRunes = new System.Windows.Forms.CheckBox();
            this.checkBoxDemoteSigils = new System.Windows.Forms.CheckBox();
            this.checkboxListCompressionOptions = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // labelCompressionSettings
            // 
            this.labelCompressionSettings.Location = new System.Drawing.Point(14, 12);
            this.labelCompressionSettings.Name = "labelCompressionSettings";
            this.labelCompressionSettings.Size = new System.Drawing.Size(645, 60);
            this.labelCompressionSettings.TabIndex = 0;
            this.labelCompressionSettings.Text = resources.GetString("labelCompressionSettings.Text");
            // 
            // checkBoxDemoteRunes
            // 
            this.checkBoxDemoteRunes.AutoSize = true;
            this.checkBoxDemoteRunes.Location = new System.Drawing.Point(14, 93);
            this.checkBoxDemoteRunes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxDemoteRunes.Name = "checkBoxDemoteRunes";
            this.checkBoxDemoteRunes.Size = new System.Drawing.Size(315, 24);
            this.checkBoxDemoteRunes.TabIndex = 1;
            this.checkBoxDemoteRunes.Text = "Demote Runes from Legendary to Superior";
            this.checkBoxDemoteRunes.UseVisualStyleBackColor = true;
            this.checkBoxDemoteRunes.CheckedChanged += new System.EventHandler(this.CheckBoxDemoteRunes_CheckedChanged);
            // 
            // checkBoxDemoteSigils
            // 
            this.checkBoxDemoteSigils.AutoSize = true;
            this.checkBoxDemoteSigils.Location = new System.Drawing.Point(14, 127);
            this.checkBoxDemoteSigils.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxDemoteSigils.Name = "checkBoxDemoteSigils";
            this.checkBoxDemoteSigils.Size = new System.Drawing.Size(311, 24);
            this.checkBoxDemoteSigils.TabIndex = 2;
            this.checkBoxDemoteSigils.Text = "Demote Sigils from Legendary to Superior";
            this.checkBoxDemoteSigils.UseVisualStyleBackColor = true;
            this.checkBoxDemoteSigils.CheckedChanged += new System.EventHandler(this.CheckBoxDemoteSigils_CheckedChanged);
            // 
            // checkboxListCompressionOptions
            // 
            this.checkboxListCompressionOptions.FormattingEnabled = true;
            this.checkboxListCompressionOptions.Location = new System.Drawing.Point(355, 87);
            this.checkboxListCompressionOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkboxListCompressionOptions.Name = "checkboxListCompressionOptions";
            this.checkboxListCompressionOptions.Size = new System.Drawing.Size(302, 158);
            this.checkboxListCompressionOptions.TabIndex = 3;
            this.checkboxListCompressionOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckboxListCompressionOptions_ItemCheck);
            // 
            // FormHsBuildCodeCompressionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(672, 259);
            this.Controls.Add(this.checkboxListCompressionOptions);
            this.Controls.Add(this.checkBoxDemoteSigils);
            this.Controls.Add(this.checkBoxDemoteRunes);
            this.Controls.Add(this.labelCompressionSettings);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHsBuildCodeCompressionSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuildCode Compression Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelCompressionSettings;
		private System.Windows.Forms.CheckBox checkBoxDemoteRunes;
		private System.Windows.Forms.CheckBox checkBoxDemoteSigils;
		private System.Windows.Forms.CheckedListBox checkboxListCompressionOptions;
	}
}