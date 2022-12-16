namespace PlenBotLogUploader {
	partial class FormHSBuildCodeCompressionSettings {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHSBuildCodeCompressionSettings));
			this.label1 = new System.Windows.Forms.Label();
			this.CheckBoxDemoteRunes = new System.Windows.Forms.CheckBox();
			this.CheckBoxDemoteSigils = new System.Windows.Forms.CheckBox();
			this.CheckboxListCompressionOptions = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(564, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// CheckBoxDemoteRunes
			// 
			this.CheckBoxDemoteRunes.AutoSize = true;
			this.CheckBoxDemoteRunes.Location = new System.Drawing.Point(12, 70);
			this.CheckBoxDemoteRunes.Name = "CheckBoxDemoteRunes";
			this.CheckBoxDemoteRunes.Size = new System.Drawing.Size(251, 19);
			this.CheckBoxDemoteRunes.TabIndex = 1;
			this.CheckBoxDemoteRunes.Text = "Demote Runes from Legendary to Superior";
			this.CheckBoxDemoteRunes.UseVisualStyleBackColor = true;
			this.CheckBoxDemoteRunes.CheckedChanged += new System.EventHandler(this.CheckBoxDemoteRunes_CheckedChanged);
			// 
			// CheckBoxDemoteSigils
			// 
			this.CheckBoxDemoteSigils.AutoSize = true;
			this.CheckBoxDemoteSigils.Location = new System.Drawing.Point(12, 95);
			this.CheckBoxDemoteSigils.Name = "CheckBoxDemoteSigils";
			this.CheckBoxDemoteSigils.Size = new System.Drawing.Size(246, 19);
			this.CheckBoxDemoteSigils.TabIndex = 2;
			this.CheckBoxDemoteSigils.Text = "Demote Sigils from Legendary to Superior";
			this.CheckBoxDemoteSigils.UseVisualStyleBackColor = true;
			this.CheckBoxDemoteSigils.CheckedChanged += new System.EventHandler(this.CheckBoxDemoteSigils_CheckedChanged);
			// 
			// CheckboxListCompressionOptions
			// 
			this.CheckboxListCompressionOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CheckboxListCompressionOptions.FormattingEnabled = true;
			this.CheckboxListCompressionOptions.Location = new System.Drawing.Point(311, 65);
			this.CheckboxListCompressionOptions.Name = "CheckboxListCompressionOptions";
			this.CheckboxListCompressionOptions.Size = new System.Drawing.Size(265, 166);
			this.CheckboxListCompressionOptions.TabIndex = 3;
			this.CheckboxListCompressionOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckboxListCompressionOptions_ItemCheck);
			// 
			// FormHSBuildCodeCompressionSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 254);
			this.Controls.Add(this.CheckboxListCompressionOptions);
			this.Controls.Add(this.CheckBoxDemoteSigils);
			this.Controls.Add(this.CheckBoxDemoteRunes);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormHSBuildCodeCompressionSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BuildCode Compression Settings";
			this.BackColor = System.Drawing.Color.White;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox CheckBoxDemoteRunes;
		private System.Windows.Forms.CheckBox CheckBoxDemoteSigils;
		private System.Windows.Forms.CheckedListBox CheckboxListCompressionOptions;
	}
}