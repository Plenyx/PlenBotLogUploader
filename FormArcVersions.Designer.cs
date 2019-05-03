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
            this.linkLabelLink = new System.Windows.Forms.LinkLabel();
            this.labelInformation = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonEnabler = new System.Windows.Forms.Button();
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
            this.groupBoxUpdating.Location = new System.Drawing.Point(160, 12);
            this.groupBoxUpdating.Name = "groupBoxUpdating";
            this.groupBoxUpdating.Size = new System.Drawing.Size(200, 71);
            this.groupBoxUpdating.TabIndex = 2;
            this.groupBoxUpdating.TabStop = false;
            this.groupBoxUpdating.Text = "Update process";
            // 
            // linkLabelLink
            // 
            this.linkLabelLink.AutoSize = true;
            this.linkLabelLink.Location = new System.Drawing.Point(214, 93);
            this.linkLabelLink.Name = "linkLabelLink";
            this.linkLabelLink.Size = new System.Drawing.Size(87, 13);
            this.linkLabelLink.TabIndex = 2;
            this.linkLabelLink.TabStop = true;
            this.linkLabelLink.Text = "Open Delta\'s site";
            this.linkLabelLink.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkLabelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLink_LinkClicked);
            // 
            // labelInformation
            // 
            this.labelInformation.Location = new System.Drawing.Point(6, 42);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(188, 23);
            this.labelInformation.TabIndex = 1;
            this.labelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUpdate.Location = new System.Drawing.Point(6, 13);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(188, 23);
            this.buttonUpdate.TabIndex = 0;
            this.buttonUpdate.Text = "Update now";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonEnabler);
            this.groupBoxSettings.Controls.Add(this.buttonChangeGWLocation);
            this.groupBoxSettings.Controls.Add(this.buttonCheckNow);
            this.groupBoxSettings.Location = new System.Drawing.Point(12, 6);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(142, 106);
            this.groupBoxSettings.TabIndex = 3;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
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
            // FormArcVersions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 119);
            this.Controls.Add(this.linkLabelLink);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxUpdating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArcVersions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "arcdps version checking settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormArcVersions_FormClosing);
            this.groupBoxUpdating.ResumeLayout(false);
            this.groupBoxSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeGWLocation;
        private System.Windows.Forms.Timer timerCheckNewArcversion;
        private System.Windows.Forms.Button buttonCheckNow;
        private System.Windows.Forms.GroupBox groupBoxUpdating;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        public System.Windows.Forms.Button buttonEnabler;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.LinkLabel linkLabelLink;
        private System.Windows.Forms.Label labelInformation;
    }
}