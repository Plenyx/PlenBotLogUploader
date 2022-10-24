namespace PlenBotLogUploader
{
    partial class FormTemplateBossData
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
            this.groupBoxTemplateControls = new System.Windows.Forms.GroupBox();
            this.buttonFailSave = new System.Windows.Forms.Button();
            this.buttonSuccessSave = new System.Windows.Forms.Button();
            this.labelFailedMessage = new System.Windows.Forms.Label();
            this.labelSuccessMessage = new System.Windows.Forms.Label();
            this.textBoxFailMessage = new System.Windows.Forms.TextBox();
            this.textBoxSuccessMessage = new System.Windows.Forms.TextBox();
            this.labelAvailableWildcards = new System.Windows.Forms.Label();
            this.labelWBoss = new System.Windows.Forms.Label();
            this.labelWLog = new System.Windows.Forms.Label();
            this.labelWPulls = new System.Windows.Forms.Label();
            this.labelWPercent = new System.Windows.Forms.Label();
            this.groupBoxTemplateControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTemplateControls
            // 
            this.groupBoxTemplateControls.Controls.Add(this.buttonFailSave);
            this.groupBoxTemplateControls.Controls.Add(this.buttonSuccessSave);
            this.groupBoxTemplateControls.Controls.Add(this.labelFailedMessage);
            this.groupBoxTemplateControls.Controls.Add(this.labelSuccessMessage);
            this.groupBoxTemplateControls.Controls.Add(this.textBoxFailMessage);
            this.groupBoxTemplateControls.Controls.Add(this.textBoxSuccessMessage);
            this.groupBoxTemplateControls.Location = new System.Drawing.Point(16, 9);
            this.groupBoxTemplateControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTemplateControls.Name = "groupBoxTemplateControls";
            this.groupBoxTemplateControls.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTemplateControls.Size = new System.Drawing.Size(505, 124);
            this.groupBoxTemplateControls.TabIndex = 0;
            this.groupBoxTemplateControls.TabStop = false;
            this.groupBoxTemplateControls.Text = "Template controls";
            // 
            // buttonFailSave
            // 
            this.buttonFailSave.Location = new System.Drawing.Point(423, 85);
            this.buttonFailSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFailSave.Name = "buttonFailSave";
            this.buttonFailSave.Size = new System.Drawing.Size(75, 28);
            this.buttonFailSave.TabIndex = 5;
            this.buttonFailSave.Text = "Save";
            this.buttonFailSave.UseVisualStyleBackColor = true;
            this.buttonFailSave.Click += new System.EventHandler(this.ButtonFailSave_Click);
            // 
            // buttonSuccessSave
            // 
            this.buttonSuccessSave.Location = new System.Drawing.Point(423, 37);
            this.buttonSuccessSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSuccessSave.Name = "buttonSuccessSave";
            this.buttonSuccessSave.Size = new System.Drawing.Size(75, 28);
            this.buttonSuccessSave.TabIndex = 4;
            this.buttonSuccessSave.Text = "Save";
            this.buttonSuccessSave.UseVisualStyleBackColor = true;
            this.buttonSuccessSave.Click += new System.EventHandler(this.ButtonSuccessSave_Click);
            // 
            // labelFailedMessage
            // 
            this.labelFailedMessage.AutoSize = true;
            this.labelFailedMessage.Location = new System.Drawing.Point(4, 68);
            this.labelFailedMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFailedMessage.Name = "labelFailedMessage";
            this.labelFailedMessage.Size = new System.Drawing.Size(146, 16);
            this.labelFailedMessage.TabIndex = 3;
            this.labelFailedMessage.Text = "Twitch message on fail:";
            // 
            // labelSuccessMessage
            // 
            this.labelSuccessMessage.AutoSize = true;
            this.labelSuccessMessage.Location = new System.Drawing.Point(4, 20);
            this.labelSuccessMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSuccessMessage.Name = "labelSuccessMessage";
            this.labelSuccessMessage.Size = new System.Drawing.Size(179, 16);
            this.labelSuccessMessage.TabIndex = 2;
            this.labelSuccessMessage.Text = "Twitch message on success:";
            // 
            // textBoxFailMessage
            // 
            this.textBoxFailMessage.Location = new System.Drawing.Point(8, 87);
            this.textBoxFailMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFailMessage.Name = "textBoxFailMessage";
            this.textBoxFailMessage.Size = new System.Drawing.Size(405, 22);
            this.textBoxFailMessage.TabIndex = 1;
            // 
            // textBoxSuccessMessage
            // 
            this.textBoxSuccessMessage.Location = new System.Drawing.Point(8, 39);
            this.textBoxSuccessMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSuccessMessage.Name = "textBoxSuccessMessage";
            this.textBoxSuccessMessage.Size = new System.Drawing.Size(405, 22);
            this.textBoxSuccessMessage.TabIndex = 0;
            // 
            // labelAvailableWildcards
            // 
            this.labelAvailableWildcards.AutoSize = true;
            this.labelAvailableWildcards.Location = new System.Drawing.Point(20, 137);
            this.labelAvailableWildcards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAvailableWildcards.Name = "labelAvailableWildcards";
            this.labelAvailableWildcards.Size = new System.Drawing.Size(174, 16);
            this.labelAvailableWildcards.TabIndex = 1;
            this.labelAvailableWildcards.Text = "Available variables for texts:";
            // 
            // labelWBoss
            // 
            this.labelWBoss.AutoSize = true;
            this.labelWBoss.Location = new System.Drawing.Point(200, 137);
            this.labelWBoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWBoss.Name = "labelWBoss";
            this.labelWBoss.Size = new System.Drawing.Size(157, 16);
            this.labelWBoss.TabIndex = 2;
            this.labelWBoss.Text = "<boss> - encounter name";
            // 
            // labelWLog
            // 
            this.labelWLog.AutoSize = true;
            this.labelWLog.Location = new System.Drawing.Point(200, 153);
            this.labelWLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWLog.Name = "labelWLog";
            this.labelWLog.Size = new System.Drawing.Size(191, 16);
            this.labelWLog.TabIndex = 3;
            this.labelWLog.Text = "<log> - link to the dps.report log";
            // 
            // labelWPulls
            // 
            this.labelWPulls.AutoSize = true;
            this.labelWPulls.Location = new System.Drawing.Point(200, 169);
            this.labelWPulls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWPulls.Name = "labelWPulls";
            this.labelWPulls.Size = new System.Drawing.Size(198, 16);
            this.labelWPulls.TabIndex = 4;
            this.labelWPulls.Text = "<pulls> - the current wipe counter";
            // 
            // labelWPercent
            // 
            this.labelWPercent.AutoSize = true;
            this.labelWPercent.Location = new System.Drawing.Point(200, 185);
            this.labelWPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWPercent.Name = "labelWPercent";
            this.labelWPercent.Size = new System.Drawing.Size(294, 16);
            this.labelWPercent.TabIndex = 11;
            this.labelWPercent.Text = "<percent> - the % of the encounter (experimental)";
            // 
            // FormTemplateBossData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(537, 209);
            this.Controls.Add(this.labelWPercent);
            this.Controls.Add(this.labelWPulls);
            this.Controls.Add(this.labelWLog);
            this.Controls.Add(this.labelWBoss);
            this.Controls.Add(this.labelAvailableWildcards);
            this.Controls.Add(this.groupBoxTemplateControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTemplateBossData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boss data templates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTemplateBossData_FormClosing);
            this.groupBoxTemplateControls.ResumeLayout(false);
            this.groupBoxTemplateControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTemplateControls;
        private System.Windows.Forms.Label labelFailedMessage;
        private System.Windows.Forms.Label labelSuccessMessage;
        private System.Windows.Forms.TextBox textBoxFailMessage;
        private System.Windows.Forms.TextBox textBoxSuccessMessage;
        private System.Windows.Forms.Button buttonSuccessSave;
        private System.Windows.Forms.Button buttonFailSave;
        private System.Windows.Forms.Label labelAvailableWildcards;
        private System.Windows.Forms.Label labelWBoss;
        private System.Windows.Forms.Label labelWLog;
        private System.Windows.Forms.Label labelWPulls;
        private System.Windows.Forms.Label labelWPercent;
    }
}