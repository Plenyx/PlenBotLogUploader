namespace PlenBotLogUploader
{
    partial class FormRaidar
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
            this.groupBoxCredentials = new System.Windows.Forms.GroupBox();
            this.buttonAuthenticate = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.checkBoxEnableRaidar = new System.Windows.Forms.CheckBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelTags = new System.Windows.Forms.Label();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.labelConfirmation = new System.Windows.Forms.Label();
            this.buttonRelog = new System.Windows.Forms.Button();
            this.groupBoxCredentials.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCredentials
            // 
            this.groupBoxCredentials.Controls.Add(this.buttonAuthenticate);
            this.groupBoxCredentials.Controls.Add(this.labelPassword);
            this.groupBoxCredentials.Controls.Add(this.labelUsername);
            this.groupBoxCredentials.Controls.Add(this.textBoxPassword);
            this.groupBoxCredentials.Controls.Add(this.textBoxUsername);
            this.groupBoxCredentials.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCredentials.Name = "groupBoxCredentials";
            this.groupBoxCredentials.Size = new System.Drawing.Size(138, 138);
            this.groupBoxCredentials.TabIndex = 0;
            this.groupBoxCredentials.TabStop = false;
            this.groupBoxCredentials.Text = "GW2Raidar credentials";
            // 
            // buttonAuthenticate
            // 
            this.buttonAuthenticate.Location = new System.Drawing.Point(9, 108);
            this.buttonAuthenticate.Name = "buttonAuthenticate";
            this.buttonAuthenticate.Size = new System.Drawing.Size(119, 23);
            this.buttonAuthenticate.TabIndex = 4;
            this.buttonAuthenticate.Text = "Login";
            this.buttonAuthenticate.UseVisualStyleBackColor = true;
            this.buttonAuthenticate.Click += new System.EventHandler(this.buttonAuthenticate_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(6, 60);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(6, 20);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(9, 76);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(119, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(9, 34);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(119, 20);
            this.textBoxUsername.TabIndex = 0;
            // 
            // checkBoxEnableRaidar
            // 
            this.checkBoxEnableRaidar.AutoSize = true;
            this.checkBoxEnableRaidar.Location = new System.Drawing.Point(9, 20);
            this.checkBoxEnableRaidar.Name = "checkBoxEnableRaidar";
            this.checkBoxEnableRaidar.Size = new System.Drawing.Size(153, 17);
            this.checkBoxEnableRaidar.TabIndex = 1;
            this.checkBoxEnableRaidar.Text = "enable uploading to Raidar";
            this.checkBoxEnableRaidar.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.buttonRelog);
            this.groupBoxSettings.Controls.Add(this.labelTags);
            this.groupBoxSettings.Controls.Add(this.textBoxTags);
            this.groupBoxSettings.Controls.Add(this.checkBoxEnableRaidar);
            this.groupBoxSettings.Enabled = false;
            this.groupBoxSettings.Location = new System.Drawing.Point(156, 12);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(201, 138);
            this.groupBoxSettings.TabIndex = 2;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "GW2Raidar settings";
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Location = new System.Drawing.Point(6, 41);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(34, 13);
            this.labelTags.TabIndex = 3;
            this.labelTags.Text = "Tags:";
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(9, 60);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(186, 20);
            this.textBoxTags.TabIndex = 2;
            // 
            // labelConfirmation
            // 
            this.labelConfirmation.AutoSize = true;
            this.labelConfirmation.Location = new System.Drawing.Point(9, 153);
            this.labelConfirmation.Name = "labelConfirmation";
            this.labelConfirmation.Size = new System.Drawing.Size(353, 13);
            this.labelConfirmation.TabIndex = 3;
            this.labelConfirmation.Text = "Your credentials are NOT saved within the settings, only authorised token";
            // 
            // buttonRelog
            // 
            this.buttonRelog.Location = new System.Drawing.Point(9, 108);
            this.buttonRelog.Name = "buttonRelog";
            this.buttonRelog.Size = new System.Drawing.Size(75, 23);
            this.buttonRelog.TabIndex = 4;
            this.buttonRelog.Text = "Relog";
            this.buttonRelog.UseVisualStyleBackColor = true;
            this.buttonRelog.Click += new System.EventHandler(this.buttonRelog_Click);
            // 
            // FormRaidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 172);
            this.Controls.Add(this.labelConfirmation);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.groupBoxCredentials);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRaidar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GW2Raidar settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRaidar_FormClosing);
            this.groupBoxCredentials.ResumeLayout(false);
            this.groupBoxCredentials.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBoxCredentials;
        public System.Windows.Forms.CheckBox checkBoxEnableRaidar;
        public System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Button buttonAuthenticate;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        public System.Windows.Forms.TextBox textBoxPassword;
        public System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelTags;
        public System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label labelConfirmation;
        private System.Windows.Forms.Button buttonRelog;
    }
}