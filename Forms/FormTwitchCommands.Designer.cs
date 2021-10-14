namespace PlenBotLogUploader
{
    partial class FormTwitchCommands
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
            this.checkBoxUploaderEnable = new System.Windows.Forms.CheckBox();
            this.checkBoxLastLogEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxUploader = new System.Windows.Forms.GroupBox();
            this.textBoxUploaderCommand = new System.Windows.Forms.TextBox();
            this.groupBoxLastLog = new System.Windows.Forms.GroupBox();
            this.textBoxLastLogCommand = new System.Windows.Forms.TextBox();
            this.groupBoxSong = new System.Windows.Forms.GroupBox();
            this.checkBoxSongSmartRecognition = new System.Windows.Forms.CheckBox();
            this.textBoxSongCommand = new System.Windows.Forms.TextBox();
            this.checkBoxSongEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxGW2IGN = new System.Windows.Forms.GroupBox();
            this.textBoxGW2Ign = new System.Windows.Forms.TextBox();
            this.checkBoxGW2IgnEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxPullCounter = new System.Windows.Forms.GroupBox();
            this.textBoxPullCounter = new System.Windows.Forms.TextBox();
            this.checkBoxPullCounterEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxGW2Build = new System.Windows.Forms.GroupBox();
            this.labelBuildInfo = new System.Windows.Forms.Label();
            this.textBoxGW2Build = new System.Windows.Forms.TextBox();
            this.checkBoxGW2BuildEnable = new System.Windows.Forms.CheckBox();
            this.groupBoxUploader.SuspendLayout();
            this.groupBoxLastLog.SuspendLayout();
            this.groupBoxSong.SuspendLayout();
            this.groupBoxGW2IGN.SuspendLayout();
            this.groupBoxPullCounter.SuspendLayout();
            this.groupBoxGW2Build.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUploaderEnable
            // 
            this.checkBoxUploaderEnable.AutoSize = true;
            this.checkBoxUploaderEnable.Location = new System.Drawing.Point(6, 19);
            this.checkBoxUploaderEnable.Name = "checkBoxUploaderEnable";
            this.checkBoxUploaderEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxUploaderEnable.TabIndex = 0;
            this.checkBoxUploaderEnable.Text = "enable command";
            this.checkBoxUploaderEnable.UseVisualStyleBackColor = true;
            // 
            // checkBoxLastLogEnable
            // 
            this.checkBoxLastLogEnable.AutoSize = true;
            this.checkBoxLastLogEnable.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLastLogEnable.Name = "checkBoxLastLogEnable";
            this.checkBoxLastLogEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxLastLogEnable.TabIndex = 1;
            this.checkBoxLastLogEnable.Text = "enable command";
            this.checkBoxLastLogEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxUploader
            // 
            this.groupBoxUploader.Controls.Add(this.textBoxUploaderCommand);
            this.groupBoxUploader.Controls.Add(this.checkBoxUploaderEnable);
            this.groupBoxUploader.Location = new System.Drawing.Point(195, 12);
            this.groupBoxUploader.Name = "groupBoxUploader";
            this.groupBoxUploader.Size = new System.Drawing.Size(179, 70);
            this.groupBoxUploader.TabIndex = 2;
            this.groupBoxUploader.TabStop = false;
            this.groupBoxUploader.Text = "!uploader";
            // 
            // textBoxUploaderCommand
            // 
            this.textBoxUploaderCommand.Location = new System.Drawing.Point(7, 43);
            this.textBoxUploaderCommand.Name = "textBoxUploaderCommand";
            this.textBoxUploaderCommand.Size = new System.Drawing.Size(164, 20);
            this.textBoxUploaderCommand.TabIndex = 1;
            // 
            // groupBoxLastLog
            // 
            this.groupBoxLastLog.Controls.Add(this.textBoxLastLogCommand);
            this.groupBoxLastLog.Controls.Add(this.checkBoxLastLogEnable);
            this.groupBoxLastLog.Location = new System.Drawing.Point(10, 88);
            this.groupBoxLastLog.Name = "groupBoxLastLog";
            this.groupBoxLastLog.Size = new System.Drawing.Size(179, 72);
            this.groupBoxLastLog.TabIndex = 3;
            this.groupBoxLastLog.TabStop = false;
            this.groupBoxLastLog.Text = "!lastlog";
            // 
            // textBoxLastLogCommand
            // 
            this.textBoxLastLogCommand.Location = new System.Drawing.Point(6, 46);
            this.textBoxLastLogCommand.Name = "textBoxLastLogCommand";
            this.textBoxLastLogCommand.Size = new System.Drawing.Size(165, 20);
            this.textBoxLastLogCommand.TabIndex = 2;
            // 
            // groupBoxSong
            // 
            this.groupBoxSong.Controls.Add(this.checkBoxSongSmartRecognition);
            this.groupBoxSong.Controls.Add(this.textBoxSongCommand);
            this.groupBoxSong.Controls.Add(this.checkBoxSongEnable);
            this.groupBoxSong.Location = new System.Drawing.Point(10, 164);
            this.groupBoxSong.Name = "groupBoxSong";
            this.groupBoxSong.Size = new System.Drawing.Size(179, 92);
            this.groupBoxSong.TabIndex = 4;
            this.groupBoxSong.TabStop = false;
            this.groupBoxSong.Text = "(Spotify) !song";
            // 
            // checkBoxSongSmartRecognition
            // 
            this.checkBoxSongSmartRecognition.AutoSize = true;
            this.checkBoxSongSmartRecognition.Location = new System.Drawing.Point(7, 69);
            this.checkBoxSongSmartRecognition.Name = "checkBoxSongSmartRecognition";
            this.checkBoxSongSmartRecognition.Size = new System.Drawing.Size(137, 17);
            this.checkBoxSongSmartRecognition.TabIndex = 2;
            this.checkBoxSongSmartRecognition.Text = "Smart !song recognition";
            this.checkBoxSongSmartRecognition.UseVisualStyleBackColor = true;
            // 
            // textBoxSongCommand
            // 
            this.textBoxSongCommand.Location = new System.Drawing.Point(7, 42);
            this.textBoxSongCommand.Name = "textBoxSongCommand";
            this.textBoxSongCommand.Size = new System.Drawing.Size(164, 20);
            this.textBoxSongCommand.TabIndex = 1;
            // 
            // checkBoxSongEnable
            // 
            this.checkBoxSongEnable.AutoSize = true;
            this.checkBoxSongEnable.Location = new System.Drawing.Point(7, 19);
            this.checkBoxSongEnable.Name = "checkBoxSongEnable";
            this.checkBoxSongEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxSongEnable.TabIndex = 0;
            this.checkBoxSongEnable.Text = "enable command";
            this.checkBoxSongEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxGW2IGN
            // 
            this.groupBoxGW2IGN.Controls.Add(this.textBoxGW2Ign);
            this.groupBoxGW2IGN.Controls.Add(this.checkBoxGW2IgnEnable);
            this.groupBoxGW2IGN.Location = new System.Drawing.Point(195, 88);
            this.groupBoxGW2IGN.Name = "groupBoxGW2IGN";
            this.groupBoxGW2IGN.Size = new System.Drawing.Size(179, 72);
            this.groupBoxGW2IGN.TabIndex = 5;
            this.groupBoxGW2IGN.TabStop = false;
            this.groupBoxGW2IGN.Text = "(GW2) !ign";
            // 
            // textBoxGW2Ign
            // 
            this.textBoxGW2Ign.Location = new System.Drawing.Point(7, 44);
            this.textBoxGW2Ign.Name = "textBoxGW2Ign";
            this.textBoxGW2Ign.Size = new System.Drawing.Size(164, 20);
            this.textBoxGW2Ign.TabIndex = 1;
            // 
            // checkBoxGW2IgnEnable
            // 
            this.checkBoxGW2IgnEnable.AutoSize = true;
            this.checkBoxGW2IgnEnable.Location = new System.Drawing.Point(7, 20);
            this.checkBoxGW2IgnEnable.Name = "checkBoxGW2IgnEnable";
            this.checkBoxGW2IgnEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxGW2IgnEnable.TabIndex = 0;
            this.checkBoxGW2IgnEnable.Text = "enable command";
            this.checkBoxGW2IgnEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxPullCounter
            // 
            this.groupBoxPullCounter.Controls.Add(this.textBoxPullCounter);
            this.groupBoxPullCounter.Controls.Add(this.checkBoxPullCounterEnable);
            this.groupBoxPullCounter.Location = new System.Drawing.Point(10, 12);
            this.groupBoxPullCounter.Name = "groupBoxPullCounter";
            this.groupBoxPullCounter.Size = new System.Drawing.Size(179, 70);
            this.groupBoxPullCounter.TabIndex = 6;
            this.groupBoxPullCounter.TabStop = false;
            this.groupBoxPullCounter.Text = "!pulls";
            // 
            // textBoxPullCounter
            // 
            this.textBoxPullCounter.Location = new System.Drawing.Point(7, 42);
            this.textBoxPullCounter.Name = "textBoxPullCounter";
            this.textBoxPullCounter.Size = new System.Drawing.Size(164, 20);
            this.textBoxPullCounter.TabIndex = 1;
            // 
            // checkBoxPullCounterEnable
            // 
            this.checkBoxPullCounterEnable.AutoSize = true;
            this.checkBoxPullCounterEnable.Location = new System.Drawing.Point(7, 19);
            this.checkBoxPullCounterEnable.Name = "checkBoxPullCounterEnable";
            this.checkBoxPullCounterEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxPullCounterEnable.TabIndex = 0;
            this.checkBoxPullCounterEnable.Text = "enable command";
            this.checkBoxPullCounterEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxGW2Build
            // 
            this.groupBoxGW2Build.Controls.Add(this.labelBuildInfo);
            this.groupBoxGW2Build.Controls.Add(this.textBoxGW2Build);
            this.groupBoxGW2Build.Controls.Add(this.checkBoxGW2BuildEnable);
            this.groupBoxGW2Build.Location = new System.Drawing.Point(195, 164);
            this.groupBoxGW2Build.Name = "groupBoxGW2Build";
            this.groupBoxGW2Build.Size = new System.Drawing.Size(179, 92);
            this.groupBoxGW2Build.TabIndex = 7;
            this.groupBoxGW2Build.TabStop = false;
            this.groupBoxGW2Build.Text = "(GW2) !build";
            // 
            // labelBuildInfo
            // 
            this.labelBuildInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBuildInfo.Location = new System.Drawing.Point(6, 70);
            this.labelBuildInfo.Name = "labelBuildInfo";
            this.labelBuildInfo.Size = new System.Drawing.Size(164, 16);
            this.labelBuildInfo.TabIndex = 3;
            this.labelBuildInfo.Text = "Must have a GW2 API key set";
            this.labelBuildInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxGW2Build
            // 
            this.textBoxGW2Build.Location = new System.Drawing.Point(6, 42);
            this.textBoxGW2Build.Name = "textBoxGW2Build";
            this.textBoxGW2Build.Size = new System.Drawing.Size(164, 20);
            this.textBoxGW2Build.TabIndex = 2;
            // 
            // checkBoxGW2BuildEnable
            // 
            this.checkBoxGW2BuildEnable.AutoSize = true;
            this.checkBoxGW2BuildEnable.Location = new System.Drawing.Point(7, 19);
            this.checkBoxGW2BuildEnable.Name = "checkBoxGW2BuildEnable";
            this.checkBoxGW2BuildEnable.Size = new System.Drawing.Size(107, 17);
            this.checkBoxGW2BuildEnable.TabIndex = 0;
            this.checkBoxGW2BuildEnable.Text = "enable command";
            this.checkBoxGW2BuildEnable.UseVisualStyleBackColor = true;
            // 
            // FormTwitchCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 268);
            this.Controls.Add(this.groupBoxGW2Build);
            this.Controls.Add(this.groupBoxPullCounter);
            this.Controls.Add(this.groupBoxGW2IGN);
            this.Controls.Add(this.groupBoxSong);
            this.Controls.Add(this.groupBoxLastLog);
            this.Controls.Add(this.groupBoxUploader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTwitchCommands";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch commands";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTwitchCommands_FormClosing);
            this.groupBoxUploader.ResumeLayout(false);
            this.groupBoxUploader.PerformLayout();
            this.groupBoxLastLog.ResumeLayout(false);
            this.groupBoxLastLog.PerformLayout();
            this.groupBoxSong.ResumeLayout(false);
            this.groupBoxSong.PerformLayout();
            this.groupBoxGW2IGN.ResumeLayout(false);
            this.groupBoxGW2IGN.PerformLayout();
            this.groupBoxPullCounter.ResumeLayout(false);
            this.groupBoxPullCounter.PerformLayout();
            this.groupBoxGW2Build.ResumeLayout(false);
            this.groupBoxGW2Build.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxUploaderEnable;
        public System.Windows.Forms.CheckBox checkBoxLastLogEnable;
        private System.Windows.Forms.GroupBox groupBoxUploader;
        private System.Windows.Forms.GroupBox groupBoxLastLog;
        public System.Windows.Forms.TextBox textBoxUploaderCommand;
        public System.Windows.Forms.TextBox textBoxLastLogCommand;
        private System.Windows.Forms.GroupBox groupBoxSong;
        public System.Windows.Forms.CheckBox checkBoxSongEnable;
        public System.Windows.Forms.TextBox textBoxSongCommand;
        private System.Windows.Forms.GroupBox groupBoxGW2IGN;
        public System.Windows.Forms.TextBox textBoxGW2Ign;
        public System.Windows.Forms.CheckBox checkBoxGW2IgnEnable;
        private System.Windows.Forms.GroupBox groupBoxPullCounter;
        public System.Windows.Forms.TextBox textBoxPullCounter;
        public System.Windows.Forms.CheckBox checkBoxPullCounterEnable;
        public System.Windows.Forms.CheckBox checkBoxSongSmartRecognition;
        private System.Windows.Forms.GroupBox groupBoxGW2Build;
        public System.Windows.Forms.TextBox textBoxGW2Build;
        public System.Windows.Forms.CheckBox checkBoxGW2BuildEnable;
        private System.Windows.Forms.Label labelBuildInfo;
    }
}