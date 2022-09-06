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
            this.textBoxGW2Build = new System.Windows.Forms.TextBox();
            this.checkBoxGW2BuildEnable = new System.Windows.Forms.CheckBox();
            this.labelBuildInfo = new System.Windows.Forms.Label();
            this.tabControlTwitchCommands = new System.Windows.Forms.TabControl();
            this.tabPageUploader = new System.Windows.Forms.TabPage();
            this.tabPageGW2API = new System.Windows.Forms.TabPage();
            this.tabPageMusic = new System.Windows.Forms.TabPage();
            this.groupBoxUploader.SuspendLayout();
            this.groupBoxLastLog.SuspendLayout();
            this.groupBoxSong.SuspendLayout();
            this.groupBoxGW2IGN.SuspendLayout();
            this.groupBoxPullCounter.SuspendLayout();
            this.groupBoxGW2Build.SuspendLayout();
            this.tabControlTwitchCommands.SuspendLayout();
            this.tabPageUploader.SuspendLayout();
            this.tabPageGW2API.SuspendLayout();
            this.tabPageMusic.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxUploaderEnable
            // 
            this.checkBoxUploaderEnable.AutoSize = true;
            this.checkBoxUploaderEnable.Location = new System.Drawing.Point(9, 25);
            this.checkBoxUploaderEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUploaderEnable.Name = "checkBoxUploaderEnable";
            this.checkBoxUploaderEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxUploaderEnable.TabIndex = 0;
            this.checkBoxUploaderEnable.Text = "enable command";
            this.checkBoxUploaderEnable.UseVisualStyleBackColor = true;
            // 
            // checkBoxLastLogEnable
            // 
            this.checkBoxLastLogEnable.AutoSize = true;
            this.checkBoxLastLogEnable.Location = new System.Drawing.Point(9, 23);
            this.checkBoxLastLogEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxLastLogEnable.Name = "checkBoxLastLogEnable";
            this.checkBoxLastLogEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxLastLogEnable.TabIndex = 1;
            this.checkBoxLastLogEnable.Text = "enable command";
            this.checkBoxLastLogEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxUploader
            // 
            this.groupBoxUploader.Controls.Add(this.textBoxUploaderCommand);
            this.groupBoxUploader.Controls.Add(this.checkBoxUploaderEnable);
            this.groupBoxUploader.Location = new System.Drawing.Point(7, 7);
            this.groupBoxUploader.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxUploader.Name = "groupBoxUploader";
            this.groupBoxUploader.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxUploader.Size = new System.Drawing.Size(239, 86);
            this.groupBoxUploader.TabIndex = 2;
            this.groupBoxUploader.TabStop = false;
            this.groupBoxUploader.Text = "!uploader";
            // 
            // textBoxUploaderCommand
            // 
            this.textBoxUploaderCommand.Location = new System.Drawing.Point(9, 53);
            this.textBoxUploaderCommand.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxUploaderCommand.Name = "textBoxUploaderCommand";
            this.textBoxUploaderCommand.Size = new System.Drawing.Size(217, 22);
            this.textBoxUploaderCommand.TabIndex = 1;
            // 
            // groupBoxLastLog
            // 
            this.groupBoxLastLog.Controls.Add(this.textBoxLastLogCommand);
            this.groupBoxLastLog.Controls.Add(this.checkBoxLastLogEnable);
            this.groupBoxLastLog.Location = new System.Drawing.Point(7, 195);
            this.groupBoxLastLog.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLastLog.Name = "groupBoxLastLog";
            this.groupBoxLastLog.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLastLog.Size = new System.Drawing.Size(239, 83);
            this.groupBoxLastLog.TabIndex = 3;
            this.groupBoxLastLog.TabStop = false;
            this.groupBoxLastLog.Text = "!lastlog";
            // 
            // textBoxLastLogCommand
            // 
            this.textBoxLastLogCommand.Location = new System.Drawing.Point(8, 51);
            this.textBoxLastLogCommand.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLastLogCommand.Name = "textBoxLastLogCommand";
            this.textBoxLastLogCommand.Size = new System.Drawing.Size(219, 22);
            this.textBoxLastLogCommand.TabIndex = 2;
            // 
            // groupBoxSong
            // 
            this.groupBoxSong.Controls.Add(this.checkBoxSongSmartRecognition);
            this.groupBoxSong.Controls.Add(this.textBoxSongCommand);
            this.groupBoxSong.Controls.Add(this.checkBoxSongEnable);
            this.groupBoxSong.Location = new System.Drawing.Point(7, 7);
            this.groupBoxSong.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSong.Name = "groupBoxSong";
            this.groupBoxSong.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSong.Size = new System.Drawing.Size(239, 113);
            this.groupBoxSong.TabIndex = 4;
            this.groupBoxSong.TabStop = false;
            this.groupBoxSong.Text = "(Spotify) !song";
            // 
            // checkBoxSongSmartRecognition
            // 
            this.checkBoxSongSmartRecognition.AutoSize = true;
            this.checkBoxSongSmartRecognition.Location = new System.Drawing.Point(9, 85);
            this.checkBoxSongSmartRecognition.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSongSmartRecognition.Name = "checkBoxSongSmartRecognition";
            this.checkBoxSongSmartRecognition.Size = new System.Drawing.Size(169, 20);
            this.checkBoxSongSmartRecognition.TabIndex = 2;
            this.checkBoxSongSmartRecognition.Text = "Smart !song recognition";
            this.checkBoxSongSmartRecognition.UseVisualStyleBackColor = true;
            // 
            // textBoxSongCommand
            // 
            this.textBoxSongCommand.Location = new System.Drawing.Point(9, 52);
            this.textBoxSongCommand.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSongCommand.Name = "textBoxSongCommand";
            this.textBoxSongCommand.Size = new System.Drawing.Size(217, 22);
            this.textBoxSongCommand.TabIndex = 1;
            // 
            // checkBoxSongEnable
            // 
            this.checkBoxSongEnable.AutoSize = true;
            this.checkBoxSongEnable.Location = new System.Drawing.Point(9, 23);
            this.checkBoxSongEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSongEnable.Name = "checkBoxSongEnable";
            this.checkBoxSongEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxSongEnable.TabIndex = 0;
            this.checkBoxSongEnable.Text = "enable command";
            this.checkBoxSongEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxGW2IGN
            // 
            this.groupBoxGW2IGN.Controls.Add(this.textBoxGW2Ign);
            this.groupBoxGW2IGN.Controls.Add(this.checkBoxGW2IgnEnable);
            this.groupBoxGW2IGN.Location = new System.Drawing.Point(7, 6);
            this.groupBoxGW2IGN.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxGW2IGN.Name = "groupBoxGW2IGN";
            this.groupBoxGW2IGN.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxGW2IGN.Size = new System.Drawing.Size(239, 87);
            this.groupBoxGW2IGN.TabIndex = 5;
            this.groupBoxGW2IGN.TabStop = false;
            this.groupBoxGW2IGN.Text = "!ign";
            // 
            // textBoxGW2Ign
            // 
            this.textBoxGW2Ign.Location = new System.Drawing.Point(9, 54);
            this.textBoxGW2Ign.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGW2Ign.Name = "textBoxGW2Ign";
            this.textBoxGW2Ign.Size = new System.Drawing.Size(217, 22);
            this.textBoxGW2Ign.TabIndex = 1;
            // 
            // checkBoxGW2IgnEnable
            // 
            this.checkBoxGW2IgnEnable.AutoSize = true;
            this.checkBoxGW2IgnEnable.Location = new System.Drawing.Point(9, 26);
            this.checkBoxGW2IgnEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxGW2IgnEnable.Name = "checkBoxGW2IgnEnable";
            this.checkBoxGW2IgnEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxGW2IgnEnable.TabIndex = 0;
            this.checkBoxGW2IgnEnable.Text = "enable command";
            this.checkBoxGW2IgnEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxPullCounter
            // 
            this.groupBoxPullCounter.Controls.Add(this.textBoxPullCounter);
            this.groupBoxPullCounter.Controls.Add(this.checkBoxPullCounterEnable);
            this.groupBoxPullCounter.Location = new System.Drawing.Point(7, 101);
            this.groupBoxPullCounter.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPullCounter.Name = "groupBoxPullCounter";
            this.groupBoxPullCounter.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxPullCounter.Size = new System.Drawing.Size(239, 86);
            this.groupBoxPullCounter.TabIndex = 6;
            this.groupBoxPullCounter.TabStop = false;
            this.groupBoxPullCounter.Text = "!pulls";
            // 
            // textBoxPullCounter
            // 
            this.textBoxPullCounter.Location = new System.Drawing.Point(9, 52);
            this.textBoxPullCounter.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPullCounter.Name = "textBoxPullCounter";
            this.textBoxPullCounter.Size = new System.Drawing.Size(217, 22);
            this.textBoxPullCounter.TabIndex = 1;
            // 
            // checkBoxPullCounterEnable
            // 
            this.checkBoxPullCounterEnable.AutoSize = true;
            this.checkBoxPullCounterEnable.Location = new System.Drawing.Point(8, 24);
            this.checkBoxPullCounterEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPullCounterEnable.Name = "checkBoxPullCounterEnable";
            this.checkBoxPullCounterEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxPullCounterEnable.TabIndex = 0;
            this.checkBoxPullCounterEnable.Text = "enable command";
            this.checkBoxPullCounterEnable.UseVisualStyleBackColor = true;
            // 
            // groupBoxGW2Build
            // 
            this.groupBoxGW2Build.Controls.Add(this.textBoxGW2Build);
            this.groupBoxGW2Build.Controls.Add(this.checkBoxGW2BuildEnable);
            this.groupBoxGW2Build.Location = new System.Drawing.Point(7, 101);
            this.groupBoxGW2Build.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxGW2Build.Name = "groupBoxGW2Build";
            this.groupBoxGW2Build.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxGW2Build.Size = new System.Drawing.Size(239, 89);
            this.groupBoxGW2Build.TabIndex = 7;
            this.groupBoxGW2Build.TabStop = false;
            this.groupBoxGW2Build.Text = "!build";
            // 
            // textBoxGW2Build
            // 
            this.textBoxGW2Build.Location = new System.Drawing.Point(8, 52);
            this.textBoxGW2Build.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxGW2Build.Name = "textBoxGW2Build";
            this.textBoxGW2Build.Size = new System.Drawing.Size(217, 22);
            this.textBoxGW2Build.TabIndex = 2;
            // 
            // checkBoxGW2BuildEnable
            // 
            this.checkBoxGW2BuildEnable.AutoSize = true;
            this.checkBoxGW2BuildEnable.Location = new System.Drawing.Point(9, 23);
            this.checkBoxGW2BuildEnable.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxGW2BuildEnable.Name = "checkBoxGW2BuildEnable";
            this.checkBoxGW2BuildEnable.Size = new System.Drawing.Size(134, 20);
            this.checkBoxGW2BuildEnable.TabIndex = 0;
            this.checkBoxGW2BuildEnable.Text = "enable command";
            this.checkBoxGW2BuildEnable.UseVisualStyleBackColor = true;
            // 
            // labelBuildInfo
            // 
            this.labelBuildInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBuildInfo.Location = new System.Drawing.Point(7, 194);
            this.labelBuildInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBuildInfo.Name = "labelBuildInfo";
            this.labelBuildInfo.Size = new System.Drawing.Size(239, 87);
            this.labelBuildInfo.TabIndex = 3;
            this.labelBuildInfo.Text = "Must have at least one GW2 API key set";
            this.labelBuildInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControlTwitchCommands
            // 
            this.tabControlTwitchCommands.Controls.Add(this.tabPageUploader);
            this.tabControlTwitchCommands.Controls.Add(this.tabPageGW2API);
            this.tabControlTwitchCommands.Controls.Add(this.tabPageMusic);
            this.tabControlTwitchCommands.Location = new System.Drawing.Point(12, 11);
            this.tabControlTwitchCommands.Name = "tabControlTwitchCommands";
            this.tabControlTwitchCommands.SelectedIndex = 0;
            this.tabControlTwitchCommands.Size = new System.Drawing.Size(263, 324);
            this.tabControlTwitchCommands.TabIndex = 9;
            // 
            // tabPageUploader
            // 
            this.tabPageUploader.BackColor = System.Drawing.Color.White;
            this.tabPageUploader.Controls.Add(this.groupBoxUploader);
            this.tabPageUploader.Controls.Add(this.groupBoxPullCounter);
            this.tabPageUploader.Controls.Add(this.groupBoxLastLog);
            this.tabPageUploader.Location = new System.Drawing.Point(4, 25);
            this.tabPageUploader.Name = "tabPageUploader";
            this.tabPageUploader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUploader.Size = new System.Drawing.Size(255, 295);
            this.tabPageUploader.TabIndex = 0;
            this.tabPageUploader.Text = "Uploader";
            // 
            // tabPageGW2API
            // 
            this.tabPageGW2API.BackColor = System.Drawing.Color.White;
            this.tabPageGW2API.Controls.Add(this.labelBuildInfo);
            this.tabPageGW2API.Controls.Add(this.groupBoxGW2IGN);
            this.tabPageGW2API.Controls.Add(this.groupBoxGW2Build);
            this.tabPageGW2API.Location = new System.Drawing.Point(4, 25);
            this.tabPageGW2API.Name = "tabPageGW2API";
            this.tabPageGW2API.Size = new System.Drawing.Size(255, 295);
            this.tabPageGW2API.TabIndex = 2;
            this.tabPageGW2API.Text = "GW2 API";
            // 
            // tabPageMusic
            // 
            this.tabPageMusic.BackColor = System.Drawing.Color.White;
            this.tabPageMusic.Controls.Add(this.groupBoxSong);
            this.tabPageMusic.Location = new System.Drawing.Point(4, 25);
            this.tabPageMusic.Name = "tabPageMusic";
            this.tabPageMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMusic.Size = new System.Drawing.Size(255, 295);
            this.tabPageMusic.TabIndex = 1;
            this.tabPageMusic.Text = "Song recognition";
            // 
            // FormTwitchCommands
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(285, 347);
            this.Controls.Add(this.tabControlTwitchCommands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.tabControlTwitchCommands.ResumeLayout(false);
            this.tabPageUploader.ResumeLayout(false);
            this.tabPageGW2API.ResumeLayout(false);
            this.tabPageMusic.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.CheckBox checkBoxUploaderEnable;
        internal System.Windows.Forms.CheckBox checkBoxLastLogEnable;
        private System.Windows.Forms.GroupBox groupBoxUploader;
        private System.Windows.Forms.GroupBox groupBoxLastLog;
        internal System.Windows.Forms.TextBox textBoxUploaderCommand;
        internal System.Windows.Forms.TextBox textBoxLastLogCommand;
        private System.Windows.Forms.GroupBox groupBoxSong;
        internal System.Windows.Forms.CheckBox checkBoxSongEnable;
        internal System.Windows.Forms.TextBox textBoxSongCommand;
        private System.Windows.Forms.GroupBox groupBoxGW2IGN;
        internal System.Windows.Forms.TextBox textBoxGW2Ign;
        internal System.Windows.Forms.CheckBox checkBoxGW2IgnEnable;
        private System.Windows.Forms.GroupBox groupBoxPullCounter;
        internal System.Windows.Forms.TextBox textBoxPullCounter;
        internal System.Windows.Forms.CheckBox checkBoxPullCounterEnable;
        internal System.Windows.Forms.CheckBox checkBoxSongSmartRecognition;
        private System.Windows.Forms.GroupBox groupBoxGW2Build;
        internal System.Windows.Forms.TextBox textBoxGW2Build;
        internal System.Windows.Forms.CheckBox checkBoxGW2BuildEnable;
        private System.Windows.Forms.Label labelBuildInfo;
        private System.Windows.Forms.TabControl tabControlTwitchCommands;
        private System.Windows.Forms.TabPage tabPageUploader;
        private System.Windows.Forms.TabPage tabPageMusic;
        private System.Windows.Forms.TabPage tabPageGW2API;
    }
}