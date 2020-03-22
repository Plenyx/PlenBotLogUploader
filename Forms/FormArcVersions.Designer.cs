namespace PlenBotLogUploader
{
    partial class FormArcVersions
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.buttonChangeGWLocation = new System.Windows.Forms.Button();
            this.timerCheckNewArcversion = new System.Windows.Forms.Timer(this.components);
            this.buttonCheckNow = new System.Windows.Forms.Button();
            this.groupBoxUpdating = new System.Windows.Forms.GroupBox();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoUpdateArc = new System.Windows.Forms.CheckBox();
            this.buttonEnabler = new System.Windows.Forms.Button();
            this.labelIssues = new System.Windows.Forms.Label();
            this.groupBoxUpdating.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeGWLocation
            // 
            this.buttonChangeGWLocation.Location = new System.Drawing.Point(6, 19);
            this.buttonChangeGWLocation.Name = "buttonChangeGWLocation";
            this.buttonChangeGWLocation.Size = new System.Drawing.Size(130, 23);
            this.buttonChangeGWLocation.TabIndex = 0;
            this.buttonChangeGWLocation.Text = "Change GW location";
            this.buttonChangeGWLocation.UseVisualStyleBackColor = true;
            this.buttonChangeGWLocation.Click += new System.EventHandler(this.buttonChangeGWLocation_Click);
            // 
            // timerCheckNewArcversion
            // 
            this.timerCheckNewArcversion.Interval = 3600000;
            this.timerCheckNewArcversion.Tick += new System.EventHandler(this.timerCheckNewArcversion_Tick);
            // 
            // buttonCheckNow
            // 
            this.buttonCheckNow.Enabled = false;
            this.buttonCheckNow.Location = new System.Drawing.Point(6, 48);
            this.buttonCheckNow.Name = "buttonCheckNow";
            this.buttonCheckNow.Size = new System.Drawing.Size(130, 23);
            this.buttonCheckNow.TabIndex = 1;
            this.buttonCheckNow.Text = "Check now";
            this.buttonCheckNow.UseVisualStyleBackColor = true;
            this.buttonCheckNow.Click += new System.EventHandler(this.buttonCheckNow_Click);
            // 
            // groupBoxUpdating
            // 
            this.groupBoxUpdating.Controls.Add(this.labelInformation);
            this.groupBoxUpdating.Controls.Add(this.buttonUpdate);
            this.groupBoxUpdating.Enabled = false;
            this.groupBoxUpdating.Location = new System.Drawing.Point(160, 6);
            this.groupBoxUpdating.Name = "groupBoxUpdating";
            this.groupBoxUpdating.Size = new System.Drawing.Size(288, 134);
            this.groupBoxUpdating.TabIndex = 2;
            this.groupBoxUpdating.TabStop = false;
            this.groupBoxUpdating.Text = "Update process";
            // 
            // labelInformation
            // 
            this.labelInformation.Location = new System.Drawing.Point(3, 102);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(279, 23);
            this.labelInformation.TabIndex = 1;
            this.labelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdate.Location = new System.Drawing.Point(6, 13);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(276, 87);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update now";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxAutoUpdateArc);
            this.groupBoxSettings.Controls.Add(this.buttonEnabler);
            this.groupBoxSettings.Controls.Add(this.buttonChangeGWLocation);
            this.groupBoxSettings.Controls.Add(this.buttonCheckNow);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 6);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(142, 134);
            this.groupBoxSettings.TabIndex = 3;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // checkBoxAutoUpdateArc
            // 
            this.checkBoxAutoUpdateArc.AutoSize = true;
            this.checkBoxAutoUpdateArc.Location = new System.Drawing.Point(6, 106);
            this.checkBoxAutoUpdateArc.Name = "checkBoxAutoUpdateArc";
            this.checkBoxAutoUpdateArc.Size = new System.Drawing.Size(119, 17);
            this.checkBoxAutoUpdateArc.TabIndex = 3;
            this.checkBoxAutoUpdateArc.Text = "Auto update arcdps";
            this.checkBoxAutoUpdateArc.UseVisualStyleBackColor = true;
            // 
            // buttonEnabler
            // 
            this.buttonEnabler.Enabled = false;
            this.buttonEnabler.Location = new System.Drawing.Point(6, 77);
            this.buttonEnabler.Name = "buttonEnabler";
            this.buttonEnabler.Size = new System.Drawing.Size(130, 23);
            this.buttonEnabler.TabIndex = 2;
            this.buttonEnabler.Text = "Disable checking";
            this.buttonEnabler.UseVisualStyleBackColor = true;
            this.buttonEnabler.Click += new System.EventHandler(this.buttonEnabler_Click);
            // 
            // labelIssues
            // 
            this.labelIssues.Location = new System.Drawing.Point(12, 143);
            this.labelIssues.Name = "labelIssues";
            this.labelIssues.Size = new System.Drawing.Size(436, 37);
            this.labelIssues.TabIndex = 4;
            this.labelIssues.Text = "If you are experiencing issues with these settings please disable checking so you" +
    " are not bothered by notifications and contact me on Discord or Github";
            this.labelIssues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormArcVersions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 184);
            this.Controls.Add(this.labelIssues);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxUpdating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArcVersions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "arcdps version checking settings";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormArcVersions_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormArcVersions_FormClosing);
            this.groupBoxUpdating.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeGWLocation;
        private System.Windows.Forms.Timer timerCheckNewArcversion;
        private System.Windows.Forms.GroupBox groupBoxUpdating;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        public System.Windows.Forms.Button buttonEnabler;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.Label labelIssues;
        public System.Windows.Forms.CheckBox checkBoxAutoUpdateArc;
        public System.Windows.Forms.Button buttonCheckNow;
    }
}