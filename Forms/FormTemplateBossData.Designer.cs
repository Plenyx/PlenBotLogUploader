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
            groupBoxTemplateControls = new System.Windows.Forms.GroupBox();
            buttonFailSave = new System.Windows.Forms.Button();
            buttonSuccessSave = new System.Windows.Forms.Button();
            labelFailedMessage = new System.Windows.Forms.Label();
            labelSuccessMessage = new System.Windows.Forms.Label();
            textBoxFailMessage = new System.Windows.Forms.TextBox();
            textBoxSuccessMessage = new System.Windows.Forms.TextBox();
            labelAvailableWildcards = new System.Windows.Forms.Label();
            labelWBoss = new System.Windows.Forms.Label();
            labelWLog = new System.Windows.Forms.Label();
            labelWPulls = new System.Windows.Forms.Label();
            labelWPercent = new System.Windows.Forms.Label();
            labelWPhase = new System.Windows.Forms.Label();
            groupBoxTemplateControls.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTemplateControls
            // 
            groupBoxTemplateControls.Controls.Add(buttonFailSave);
            groupBoxTemplateControls.Controls.Add(buttonSuccessSave);
            groupBoxTemplateControls.Controls.Add(labelFailedMessage);
            groupBoxTemplateControls.Controls.Add(labelSuccessMessage);
            groupBoxTemplateControls.Controls.Add(textBoxFailMessage);
            groupBoxTemplateControls.Controls.Add(textBoxSuccessMessage);
            groupBoxTemplateControls.Location = new System.Drawing.Point(16, 11);
            groupBoxTemplateControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxTemplateControls.Name = "groupBoxTemplateControls";
            groupBoxTemplateControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxTemplateControls.Size = new System.Drawing.Size(528, 155);
            groupBoxTemplateControls.TabIndex = 0;
            groupBoxTemplateControls.TabStop = false;
            groupBoxTemplateControls.Text = "Template controls";
            // 
            // buttonFailSave
            // 
            buttonFailSave.Location = new System.Drawing.Point(445, 105);
            buttonFailSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonFailSave.Name = "buttonFailSave";
            buttonFailSave.Size = new System.Drawing.Size(75, 35);
            buttonFailSave.TabIndex = 5;
            buttonFailSave.Text = "Save";
            buttonFailSave.UseVisualStyleBackColor = true;
            buttonFailSave.Click += ButtonFailSave_Click;
            // 
            // buttonSuccessSave
            // 
            buttonSuccessSave.Location = new System.Drawing.Point(445, 45);
            buttonSuccessSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonSuccessSave.Name = "buttonSuccessSave";
            buttonSuccessSave.Size = new System.Drawing.Size(75, 35);
            buttonSuccessSave.TabIndex = 4;
            buttonSuccessSave.Text = "Save";
            buttonSuccessSave.UseVisualStyleBackColor = true;
            buttonSuccessSave.Click += ButtonSuccessSave_Click;
            // 
            // labelFailedMessage
            // 
            labelFailedMessage.AutoSize = true;
            labelFailedMessage.Location = new System.Drawing.Point(4, 85);
            labelFailedMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelFailedMessage.Name = "labelFailedMessage";
            labelFailedMessage.Size = new System.Drawing.Size(162, 20);
            labelFailedMessage.TabIndex = 3;
            labelFailedMessage.Text = "Twitch message on fail:";
            // 
            // labelSuccessMessage
            // 
            labelSuccessMessage.AutoSize = true;
            labelSuccessMessage.Location = new System.Drawing.Point(4, 25);
            labelSuccessMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSuccessMessage.Name = "labelSuccessMessage";
            labelSuccessMessage.Size = new System.Drawing.Size(189, 20);
            labelSuccessMessage.TabIndex = 2;
            labelSuccessMessage.Text = "Twitch message on success:";
            // 
            // textBoxFailMessage
            // 
            textBoxFailMessage.Location = new System.Drawing.Point(8, 109);
            textBoxFailMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxFailMessage.Name = "textBoxFailMessage";
            textBoxFailMessage.Size = new System.Drawing.Size(429, 27);
            textBoxFailMessage.TabIndex = 1;
            // 
            // textBoxSuccessMessage
            // 
            textBoxSuccessMessage.Location = new System.Drawing.Point(8, 49);
            textBoxSuccessMessage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            textBoxSuccessMessage.Name = "textBoxSuccessMessage";
            textBoxSuccessMessage.Size = new System.Drawing.Size(429, 27);
            textBoxSuccessMessage.TabIndex = 0;
            // 
            // labelAvailableWildcards
            // 
            labelAvailableWildcards.AutoSize = true;
            labelAvailableWildcards.Location = new System.Drawing.Point(20, 171);
            labelAvailableWildcards.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAvailableWildcards.Name = "labelAvailableWildcards";
            labelAvailableWildcards.Size = new System.Drawing.Size(195, 20);
            labelAvailableWildcards.TabIndex = 1;
            labelAvailableWildcards.Text = "Available variables for texts:";
            // 
            // labelWBoss
            // 
            labelWBoss.AutoSize = true;
            labelWBoss.Location = new System.Drawing.Point(200, 171);
            labelWBoss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWBoss.Name = "labelWBoss";
            labelWBoss.Size = new System.Drawing.Size(180, 20);
            labelWBoss.TabIndex = 2;
            labelWBoss.Text = "<boss> - encounter name";
            // 
            // labelWLog
            // 
            labelWLog.AutoSize = true;
            labelWLog.Location = new System.Drawing.Point(200, 191);
            labelWLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWLog.Name = "labelWLog";
            labelWLog.Size = new System.Drawing.Size(229, 20);
            labelWLog.TabIndex = 3;
            labelWLog.Text = "<log> - link to the dps.report log";
            // 
            // labelWPulls
            // 
            labelWPulls.AutoSize = true;
            labelWPulls.Location = new System.Drawing.Point(200, 211);
            labelWPulls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWPulls.Name = "labelWPulls";
            labelWPulls.Size = new System.Drawing.Size(235, 20);
            labelWPulls.TabIndex = 4;
            labelWPulls.Text = "<pulls> - the current wipe counter";
            // 
            // labelWPercent
            // 
            labelWPercent.AutoSize = true;
            labelWPercent.Location = new System.Drawing.Point(200, 251);
            labelWPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWPercent.Name = "labelWPercent";
            labelWPercent.Size = new System.Drawing.Size(311, 20);
            labelWPercent.TabIndex = 11;
            labelWPercent.Text = "<percent> - the % of targets of the encounter";
            // 
            // labelWPhase
            // 
            labelWPhase.AutoSize = true;
            labelWPhase.Location = new System.Drawing.Point(200, 231);
            labelWPhase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelWPhase.Name = "labelWPhase";
            labelWPhase.Size = new System.Drawing.Size(259, 20);
            labelWPhase.TabIndex = 12;
            labelWPhase.Text = "<phase> - the phase of the encounter";
            // 
            // FormTemplateBossData
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(555, 279);
            Controls.Add(labelWPhase);
            Controls.Add(labelWPercent);
            Controls.Add(labelWPulls);
            Controls.Add(labelWLog);
            Controls.Add(labelWBoss);
            Controls.Add(labelAvailableWildcards);
            Controls.Add(groupBoxTemplateControls);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Boss data templates";
            FormClosing += FormTemplateBossData_FormClosing;
            groupBoxTemplateControls.ResumeLayout(false);
            groupBoxTemplateControls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.Label labelWPhase;
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