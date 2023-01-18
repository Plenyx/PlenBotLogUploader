namespace PlenBotLogUploader
{
    partial class FormEditDpsReportUserToken
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
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxUserToken = new System.Windows.Forms.GroupBox();
            this.buttonDPSReportGetToken = new System.Windows.Forms.Button();
            this.textBoxUserToken = new System.Windows.Forms.TextBox();
            this.groupBoxName.SuspendLayout();
            this.groupBoxUserToken.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.textBoxName);
            this.groupBoxName.Location = new System.Drawing.Point(12, 15);
            this.groupBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxName.Size = new System.Drawing.Size(419, 68);
            this.groupBoxName.TabIndex = 0;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 26);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(405, 27);
            this.textBoxName.TabIndex = 0;
            // 
            // groupBoxUserToken
            // 
            this.groupBoxUserToken.Controls.Add(this.buttonDPSReportGetToken);
            this.groupBoxUserToken.Controls.Add(this.textBoxUserToken);
            this.groupBoxUserToken.Location = new System.Drawing.Point(12, 90);
            this.groupBoxUserToken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUserToken.Name = "groupBoxUserToken";
            this.groupBoxUserToken.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxUserToken.Size = new System.Drawing.Size(419, 109);
            this.groupBoxUserToken.TabIndex = 1;
            this.groupBoxUserToken.TabStop = false;
            this.groupBoxUserToken.Text = "User token";
            // 
            // buttonDPSReportGetToken
            // 
            this.buttonDPSReportGetToken.Location = new System.Drawing.Point(126, 62);
            this.buttonDPSReportGetToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDPSReportGetToken.Name = "buttonDPSReportGetToken";
            this.buttonDPSReportGetToken.Size = new System.Drawing.Size(285, 35);
            this.buttonDPSReportGetToken.TabIndex = 4;
            this.buttonDPSReportGetToken.Text = "Generate token from the DPS.report API";
            this.buttonDPSReportGetToken.UseVisualStyleBackColor = true;
            this.buttonDPSReportGetToken.Click += new System.EventHandler(this.ButtonDPSReportGetToken_Click);
            // 
            // textBoxUserToken
            // 
            this.textBoxUserToken.Location = new System.Drawing.Point(6, 26);
            this.textBoxUserToken.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUserToken.Name = "textBoxUserToken";
            this.textBoxUserToken.Size = new System.Drawing.Size(405, 27);
            this.textBoxUserToken.TabIndex = 0;
            // 
            // FormEditDPSReportUserToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(440, 210);
            this.Controls.Add(this.groupBoxUserToken);
            this.Controls.Add(this.groupBoxName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditDPSReportUserToken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEditDPSReportUserToken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditDPSReportUserToken_FormClosing);
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.groupBoxUserToken.ResumeLayout(false);
            this.groupBoxUserToken.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxUserToken;
        private System.Windows.Forms.TextBox textBoxUserToken;
        private System.Windows.Forms.Button buttonDPSReportGetToken;
    }
}