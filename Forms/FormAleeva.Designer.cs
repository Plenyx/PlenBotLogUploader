namespace PlenBotLogUploader
{
    partial class FormAleeva
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
            this.groupBoxAccessCode = new System.Windows.Forms.GroupBox();
            this.textBoxAccessCode = new System.Windows.Forms.TextBox();
            this.buttonGetBearerFromAccess = new System.Windows.Forms.Button();
            this.groupBoxAleevaStatus = new System.Windows.Forms.GroupBox();
            this.groupBoxUploadSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxOnlySuccessful = new System.Windows.Forms.CheckBox();
            this.checkBoxSendNotification = new System.Windows.Forms.CheckBox();
            this.groupBoxChannel = new System.Windows.Forms.GroupBox();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.groupBoxAccessCode.SuspendLayout();
            this.groupBoxAleevaStatus.SuspendLayout();
            this.groupBoxUploadSettings.SuspendLayout();
            this.groupBoxChannel.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAccessCode
            // 
            this.groupBoxAccessCode.Controls.Add(this.textBoxAccessCode);
            this.groupBoxAccessCode.Controls.Add(this.buttonGetBearerFromAccess);
            this.groupBoxAccessCode.Location = new System.Drawing.Point(6, 19);
            this.groupBoxAccessCode.Name = "groupBoxAccessCode";
            this.groupBoxAccessCode.Size = new System.Drawing.Size(474, 47);
            this.groupBoxAccessCode.TabIndex = 0;
            this.groupBoxAccessCode.TabStop = false;
            this.groupBoxAccessCode.Text = "Authorise with Aleeva using a generated access code from her";
            // 
            // textBoxAccessCode
            // 
            this.textBoxAccessCode.Location = new System.Drawing.Point(6, 19);
            this.textBoxAccessCode.Name = "textBoxAccessCode";
            this.textBoxAccessCode.Size = new System.Drawing.Size(381, 20);
            this.textBoxAccessCode.TabIndex = 1;
            // 
            // buttonGetBearerFromAccess
            // 
            this.buttonGetBearerFromAccess.Location = new System.Drawing.Point(393, 17);
            this.buttonGetBearerFromAccess.Name = "buttonGetBearerFromAccess";
            this.buttonGetBearerFromAccess.Size = new System.Drawing.Size(75, 23);
            this.buttonGetBearerFromAccess.TabIndex = 0;
            this.buttonGetBearerFromAccess.Text = "Authorise";
            this.buttonGetBearerFromAccess.UseVisualStyleBackColor = true;
            this.buttonGetBearerFromAccess.Click += new System.EventHandler(this.ButtonGetBearerFromAccess_Click);
            // 
            // groupBoxAleevaStatus
            // 
            this.groupBoxAleevaStatus.Controls.Add(this.groupBoxUploadSettings);
            this.groupBoxAleevaStatus.Controls.Add(this.groupBoxChannel);
            this.groupBoxAleevaStatus.Controls.Add(this.groupBoxServer);
            this.groupBoxAleevaStatus.Controls.Add(this.groupBoxAccessCode);
            this.groupBoxAleevaStatus.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAleevaStatus.Name = "groupBoxAleevaStatus";
            this.groupBoxAleevaStatus.Size = new System.Drawing.Size(487, 229);
            this.groupBoxAleevaStatus.TabIndex = 1;
            this.groupBoxAleevaStatus.TabStop = false;
            this.groupBoxAleevaStatus.Text = "Status: Not authorised";
            // 
            // groupBoxUploadSettings
            // 
            this.groupBoxUploadSettings.Controls.Add(this.checkBoxOnlySuccessful);
            this.groupBoxUploadSettings.Controls.Add(this.checkBoxSendNotification);
            this.groupBoxUploadSettings.Enabled = false;
            this.groupBoxUploadSettings.Location = new System.Drawing.Point(6, 180);
            this.groupBoxUploadSettings.Name = "groupBoxUploadSettings";
            this.groupBoxUploadSettings.Size = new System.Drawing.Size(474, 41);
            this.groupBoxUploadSettings.TabIndex = 5;
            this.groupBoxUploadSettings.TabStop = false;
            this.groupBoxUploadSettings.Text = "Upload settings";
            // 
            // checkBoxOnlySuccessful
            // 
            this.checkBoxOnlySuccessful.AutoSize = true;
            this.checkBoxOnlySuccessful.Location = new System.Drawing.Point(117, 18);
            this.checkBoxOnlySuccessful.Name = "checkBoxOnlySuccessful";
            this.checkBoxOnlySuccessful.Size = new System.Drawing.Size(157, 17);
            this.checkBoxOnlySuccessful.TabIndex = 1;
            this.checkBoxOnlySuccessful.Text = "Upload only successful logs";
            this.checkBoxOnlySuccessful.UseVisualStyleBackColor = true;
            this.checkBoxOnlySuccessful.CheckedChanged += new System.EventHandler(this.CheckBoxOnlySuccessful_CheckedChanged);
            // 
            // checkBoxSendNotification
            // 
            this.checkBoxSendNotification.AutoSize = true;
            this.checkBoxSendNotification.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSendNotification.Name = "checkBoxSendNotification";
            this.checkBoxSendNotification.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSendNotification.TabIndex = 0;
            this.checkBoxSendNotification.Text = "Send notification";
            this.checkBoxSendNotification.UseVisualStyleBackColor = true;
            this.checkBoxSendNotification.CheckedChanged += new System.EventHandler(this.CheckBoxSendNotification_CheckedChanged);
            // 
            // groupBoxChannel
            // 
            this.groupBoxChannel.Controls.Add(this.comboBoxChannel);
            this.groupBoxChannel.Enabled = false;
            this.groupBoxChannel.Location = new System.Drawing.Point(6, 126);
            this.groupBoxChannel.Name = "groupBoxChannel";
            this.groupBoxChannel.Size = new System.Drawing.Size(475, 48);
            this.groupBoxChannel.TabIndex = 4;
            this.groupBoxChannel.TabStop = false;
            this.groupBoxChannel.Text = "Notification channel";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(6, 19);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(462, 21);
            this.comboBoxChannel.TabIndex = 2;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxChannel_SelectedIndexChanged);
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.comboBoxServer);
            this.groupBoxServer.Enabled = false;
            this.groupBoxServer.Location = new System.Drawing.Point(6, 72);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(474, 48);
            this.groupBoxServer.TabIndex = 3;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Notification server";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.FormattingEnabled = true;
            this.comboBoxServer.Location = new System.Drawing.Point(6, 19);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(462, 21);
            this.comboBoxServer.TabIndex = 1;
            this.comboBoxServer.DropDown += new System.EventHandler(this.ComboBoxServer_DropDown);
            this.comboBoxServer.SelectedIndexChanged += new System.EventHandler(this.ComboBoxServer_SelectedIndexChanged);
            // 
            // FormAleeva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 252);
            this.Controls.Add(this.groupBoxAleevaStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAleeva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aleeva integration";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.FormAleeva_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAleeva_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAleeva_FormClosed);
            this.groupBoxAccessCode.ResumeLayout(false);
            this.groupBoxAccessCode.PerformLayout();
            this.groupBoxAleevaStatus.ResumeLayout(false);
            this.groupBoxUploadSettings.ResumeLayout(false);
            this.groupBoxUploadSettings.PerformLayout();
            this.groupBoxChannel.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAccessCode;
        private System.Windows.Forms.TextBox textBoxAccessCode;
        private System.Windows.Forms.Button buttonGetBearerFromAccess;
        private System.Windows.Forms.GroupBox groupBoxAleevaStatus;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.GroupBox groupBoxChannel;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.GroupBox groupBoxUploadSettings;
        private System.Windows.Forms.CheckBox checkBoxSendNotification;
        private System.Windows.Forms.CheckBox checkBoxOnlySuccessful;
    }
}