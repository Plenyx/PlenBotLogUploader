
namespace PlenBotLogUploader
{
    partial class FormEditTeam
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
            this.groupBoxTeamName = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxLimiter = new System.Windows.Forms.GroupBox();
            this.textBoxLimiterValue = new System.Windows.Forms.TextBox();
            this.radioButtonLimiterMin = new System.Windows.Forms.RadioButton();
            this.textBoxAccountNames = new System.Windows.Forms.TextBox();
            this.groupBoxAccountNames = new System.Windows.Forms.GroupBox();
            this.radioButtonLimiterExact = new System.Windows.Forms.RadioButton();
            this.radioButtonLimiterExcept = new System.Windows.Forms.RadioButton();
            this.groupBoxTeamName.SuspendLayout();
            this.groupBoxLimiter.SuspendLayout();
            this.groupBoxAccountNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTeamName
            // 
            this.groupBoxTeamName.Controls.Add(this.textBoxName);
            this.groupBoxTeamName.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTeamName.Name = "groupBoxTeamName";
            this.groupBoxTeamName.Size = new System.Drawing.Size(277, 46);
            this.groupBoxTeamName.TabIndex = 0;
            this.groupBoxTeamName.TabStop = false;
            this.groupBoxTeamName.Text = "Team name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(264, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // groupBoxLimiter
            // 
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterExcept);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterExact);
            this.groupBoxLimiter.Controls.Add(this.textBoxLimiterValue);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterMin);
            this.groupBoxLimiter.Location = new System.Drawing.Point(12, 64);
            this.groupBoxLimiter.Name = "groupBoxLimiter";
            this.groupBoxLimiter.Size = new System.Drawing.Size(277, 89);
            this.groupBoxLimiter.TabIndex = 1;
            this.groupBoxLimiter.TabStop = false;
            this.groupBoxLimiter.Text = "Limiter settings";
            // 
            // textBoxLimiterValue
            // 
            this.textBoxLimiterValue.Location = new System.Drawing.Point(116, 28);
            this.textBoxLimiterValue.Name = "textBoxLimiterValue";
            this.textBoxLimiterValue.Size = new System.Drawing.Size(154, 20);
            this.textBoxLimiterValue.TabIndex = 1;
            this.textBoxLimiterValue.Text = "1";
            // 
            // radioButtonLimiterMin
            // 
            this.radioButtonLimiterMin.AutoSize = true;
            this.radioButtonLimiterMin.Checked = true;
            this.radioButtonLimiterMin.Location = new System.Drawing.Point(6, 19);
            this.radioButtonLimiterMin.Name = "radioButtonLimiterMin";
            this.radioButtonLimiterMin.Size = new System.Drawing.Size(104, 17);
            this.radioButtonLimiterMin.TabIndex = 0;
            this.radioButtonLimiterMin.TabStop = true;
            this.radioButtonLimiterMin.Text = "At least x players";
            this.radioButtonLimiterMin.UseVisualStyleBackColor = true;
            this.radioButtonLimiterMin.CheckedChanged += new System.EventHandler(this.RadioButtonLimiterMin_CheckedChanged);
            // 
            // textBoxAccountNames
            // 
            this.textBoxAccountNames.Location = new System.Drawing.Point(6, 19);
            this.textBoxAccountNames.Multiline = true;
            this.textBoxAccountNames.Name = "textBoxAccountNames";
            this.textBoxAccountNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAccountNames.Size = new System.Drawing.Size(264, 224);
            this.textBoxAccountNames.TabIndex = 2;
            // 
            // groupBoxAccountNames
            // 
            this.groupBoxAccountNames.Controls.Add(this.textBoxAccountNames);
            this.groupBoxAccountNames.Location = new System.Drawing.Point(12, 159);
            this.groupBoxAccountNames.Name = "groupBoxAccountNames";
            this.groupBoxAccountNames.Size = new System.Drawing.Size(276, 249);
            this.groupBoxAccountNames.TabIndex = 3;
            this.groupBoxAccountNames.TabStop = false;
            this.groupBoxAccountNames.Text = "Account names (separate by new line)";
            // 
            // radioButtonLimiterExact
            // 
            this.radioButtonLimiterExact.AutoSize = true;
            this.radioButtonLimiterExact.Location = new System.Drawing.Point(6, 42);
            this.radioButtonLimiterExact.Name = "radioButtonLimiterExact";
            this.radioButtonLimiterExact.Size = new System.Drawing.Size(103, 17);
            this.radioButtonLimiterExact.TabIndex = 2;
            this.radioButtonLimiterExact.TabStop = true;
            this.radioButtonLimiterExact.Text = "Exactly x players";
            this.radioButtonLimiterExact.UseVisualStyleBackColor = true;
            this.radioButtonLimiterExact.CheckedChanged += new System.EventHandler(this.RadioButtonLimiterExact_CheckedChanged);
            // 
            // radioButtonLimiterExcept
            // 
            this.radioButtonLimiterExcept.AutoSize = true;
            this.radioButtonLimiterExcept.Location = new System.Drawing.Point(6, 65);
            this.radioButtonLimiterExcept.Name = "radioButtonLimiterExcept";
            this.radioButtonLimiterExcept.Size = new System.Drawing.Size(121, 17);
            this.radioButtonLimiterExcept.TabIndex = 3;
            this.radioButtonLimiterExcept.TabStop = true;
            this.radioButtonLimiterExcept.Text = "Except listed players";
            this.radioButtonLimiterExcept.UseVisualStyleBackColor = true;
            this.radioButtonLimiterExcept.CheckedChanged += new System.EventHandler(this.RadioButtonLimiterExcept_CheckedChanged);
            // 
            // FormEditTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 417);
            this.Controls.Add(this.groupBoxAccountNames);
            this.Controls.Add(this.groupBoxLimiter);
            this.Controls.Add(this.groupBoxTeamName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditTeam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditTeam_FormClosing);
            this.groupBoxTeamName.ResumeLayout(false);
            this.groupBoxTeamName.PerformLayout();
            this.groupBoxLimiter.ResumeLayout(false);
            this.groupBoxLimiter.PerformLayout();
            this.groupBoxAccountNames.ResumeLayout(false);
            this.groupBoxAccountNames.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTeamName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxLimiter;
        private System.Windows.Forms.TextBox textBoxLimiterValue;
        private System.Windows.Forms.RadioButton radioButtonLimiterMin;
        private System.Windows.Forms.TextBox textBoxAccountNames;
        private System.Windows.Forms.GroupBox groupBoxAccountNames;
        private System.Windows.Forms.RadioButton radioButtonLimiterExcept;
        private System.Windows.Forms.RadioButton radioButtonLimiterExact;
    }
}