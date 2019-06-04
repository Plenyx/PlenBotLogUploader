namespace PlenBotLogUploader
{
    partial class FormLogSession
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
            this.buttonSessionStarter = new System.Windows.Forms.Button();
            this.checkBoxSupressWebhooks = new System.Windows.Forms.CheckBox();
            this.checkBoxOnlySuccess = new System.Windows.Forms.CheckBox();
            this.buttonUnPauseSession = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSessionStarter
            // 
            this.buttonSessionStarter.Location = new System.Drawing.Point(12, 12);
            this.buttonSessionStarter.Name = "buttonSessionStarter";
            this.buttonSessionStarter.Size = new System.Drawing.Size(163, 23);
            this.buttonSessionStarter.TabIndex = 0;
            this.buttonSessionStarter.Text = "Start a log session";
            this.buttonSessionStarter.UseVisualStyleBackColor = true;
            this.buttonSessionStarter.Click += new System.EventHandler(this.ButtonSessionStarter_Click);
            // 
            // checkBoxSupressWebhooks
            // 
            this.checkBoxSupressWebhooks.AutoSize = true;
            this.checkBoxSupressWebhooks.Checked = true;
            this.checkBoxSupressWebhooks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSupressWebhooks.Location = new System.Drawing.Point(12, 41);
            this.checkBoxSupressWebhooks.Name = "checkBoxSupressWebhooks";
            this.checkBoxSupressWebhooks.Size = new System.Drawing.Size(271, 17);
            this.checkBoxSupressWebhooks.TabIndex = 1;
            this.checkBoxSupressWebhooks.Text = "suppress Discord webhooks until session concludes";
            this.checkBoxSupressWebhooks.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnlySuccess
            // 
            this.checkBoxOnlySuccess.AutoSize = true;
            this.checkBoxOnlySuccess.Checked = true;
            this.checkBoxOnlySuccess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlySuccess.Location = new System.Drawing.Point(12, 64);
            this.checkBoxOnlySuccess.Name = "checkBoxOnlySuccess";
            this.checkBoxOnlySuccess.Size = new System.Drawing.Size(141, 17);
            this.checkBoxOnlySuccess.TabIndex = 2;
            this.checkBoxOnlySuccess.Text = "only successful attempts";
            this.checkBoxOnlySuccess.UseVisualStyleBackColor = true;
            // 
            // buttonUnPauseSession
            // 
            this.buttonUnPauseSession.Enabled = false;
            this.buttonUnPauseSession.Location = new System.Drawing.Point(181, 12);
            this.buttonUnPauseSession.Name = "buttonUnPauseSession";
            this.buttonUnPauseSession.Size = new System.Drawing.Size(102, 23);
            this.buttonUnPauseSession.TabIndex = 3;
            this.buttonUnPauseSession.Text = "Pause session";
            this.buttonUnPauseSession.UseVisualStyleBackColor = true;
            this.buttonUnPauseSession.Click += new System.EventHandler(this.ButtonUnPauseSession_Click);
            // 
            // FormLogSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 91);
            this.Controls.Add(this.buttonUnPauseSession);
            this.Controls.Add(this.checkBoxOnlySuccess);
            this.Controls.Add(this.checkBoxSupressWebhooks);
            this.Controls.Add(this.buttonSessionStarter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogSession";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log session settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogSession_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSessionStarter;
        public System.Windows.Forms.CheckBox checkBoxSupressWebhooks;
        public System.Windows.Forms.CheckBox checkBoxOnlySuccess;
        private System.Windows.Forms.Button buttonUnPauseSession;
    }
}