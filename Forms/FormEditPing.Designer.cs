namespace PlenBotLogUploader
{
    partial class FormEditPing
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
            this.groupBoxAuthorisation = new System.Windows.Forms.GroupBox();
            this.labelAuthToken = new System.Windows.Forms.Label();
            this.labelAuthName = new System.Windows.Forms.Label();
            this.textBoxAuthName = new System.Windows.Forms.TextBox();
            this.radioButtonUseNormalField = new System.Windows.Forms.RadioButton();
            this.radioButtonUseAuthField = new System.Windows.Forms.RadioButton();
            this.textBoxAuthToken = new System.Windows.Forms.TextBox();
            this.groupBoxUrl = new System.Windows.Forms.GroupBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.groupBoxMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonMethodDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodPut = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodGet = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodPost = new System.Windows.Forms.RadioButton();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonTestPing = new System.Windows.Forms.Button();
            this.groupBoxAuthorisation.SuspendLayout();
            this.groupBoxUrl.SuspendLayout();
            this.groupBoxMethod.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAuthorisation
            // 
            this.groupBoxAuthorisation.Controls.Add(this.labelAuthToken);
            this.groupBoxAuthorisation.Controls.Add(this.labelAuthName);
            this.groupBoxAuthorisation.Controls.Add(this.textBoxAuthName);
            this.groupBoxAuthorisation.Controls.Add(this.radioButtonUseNormalField);
            this.groupBoxAuthorisation.Controls.Add(this.radioButtonUseAuthField);
            this.groupBoxAuthorisation.Controls.Add(this.textBoxAuthToken);
            this.groupBoxAuthorisation.Location = new System.Drawing.Point(12, 112);
            this.groupBoxAuthorisation.Name = "groupBoxAuthorisation";
            this.groupBoxAuthorisation.Size = new System.Drawing.Size(282, 109);
            this.groupBoxAuthorisation.TabIndex = 5;
            this.groupBoxAuthorisation.TabStop = false;
            this.groupBoxAuthorisation.Text = "Authorisation";
            // 
            // labelAuthToken
            // 
            this.labelAuthToken.AutoSize = true;
            this.labelAuthToken.Location = new System.Drawing.Point(3, 61);
            this.labelAuthToken.Name = "labelAuthToken";
            this.labelAuthToken.Size = new System.Drawing.Size(62, 13);
            this.labelAuthToken.TabIndex = 5;
            this.labelAuthToken.Text = "Auth token:";
            // 
            // labelAuthName
            // 
            this.labelAuthName.AutoSize = true;
            this.labelAuthName.Location = new System.Drawing.Point(3, 19);
            this.labelAuthName.Name = "labelAuthName";
            this.labelAuthName.Size = new System.Drawing.Size(101, 13);
            this.labelAuthName.TabIndex = 4;
            this.labelAuthName.Text = "Auth scheme name:";
            // 
            // textBoxAuthName
            // 
            this.textBoxAuthName.Location = new System.Drawing.Point(6, 35);
            this.textBoxAuthName.Name = "textBoxAuthName";
            this.textBoxAuthName.Size = new System.Drawing.Size(139, 20);
            this.textBoxAuthName.TabIndex = 3;
            // 
            // radioButtonUseNormalField
            // 
            this.radioButtonUseNormalField.AutoSize = true;
            this.radioButtonUseNormalField.Location = new System.Drawing.Point(151, 77);
            this.radioButtonUseNormalField.Name = "radioButtonUseNormalField";
            this.radioButtonUseNormalField.Size = new System.Drawing.Size(89, 17);
            this.radioButtonUseNormalField.TabIndex = 2;
            this.radioButtonUseNormalField.Text = "Use as a field";
            this.radioButtonUseNormalField.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseAuthField
            // 
            this.radioButtonUseAuthField.AutoSize = true;
            this.radioButtonUseAuthField.Checked = true;
            this.radioButtonUseAuthField.Location = new System.Drawing.Point(151, 35);
            this.radioButtonUseAuthField.Name = "radioButtonUseAuthField";
            this.radioButtonUseAuthField.Size = new System.Drawing.Size(122, 17);
            this.radioButtonUseAuthField.TabIndex = 1;
            this.radioButtonUseAuthField.TabStop = true;
            this.radioButtonUseAuthField.Text = "Use as Authorisation";
            this.radioButtonUseAuthField.UseVisualStyleBackColor = true;
            // 
            // textBoxAuthToken
            // 
            this.textBoxAuthToken.Location = new System.Drawing.Point(6, 77);
            this.textBoxAuthToken.MaxLength = 50;
            this.textBoxAuthToken.Name = "textBoxAuthToken";
            this.textBoxAuthToken.Size = new System.Drawing.Size(139, 20);
            this.textBoxAuthToken.TabIndex = 0;
            this.textBoxAuthToken.UseSystemPasswordChar = true;
            // 
            // groupBoxUrl
            // 
            this.groupBoxUrl.Controls.Add(this.textBoxURL);
            this.groupBoxUrl.Location = new System.Drawing.Point(12, 62);
            this.groupBoxUrl.Name = "groupBoxUrl";
            this.groupBoxUrl.Size = new System.Drawing.Size(479, 44);
            this.groupBoxUrl.TabIndex = 4;
            this.groupBoxUrl.TabStop = false;
            this.groupBoxUrl.Text = "URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(6, 18);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(460, 20);
            this.textBoxURL.TabIndex = 3;
            // 
            // groupBoxMethod
            // 
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodDelete);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodPut);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodGet);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodPost);
            this.groupBoxMethod.Location = new System.Drawing.Point(300, 113);
            this.groupBoxMethod.Name = "groupBoxMethod";
            this.groupBoxMethod.Size = new System.Drawing.Size(127, 73);
            this.groupBoxMethod.TabIndex = 2;
            this.groupBoxMethod.TabStop = false;
            this.groupBoxMethod.Text = "Method";
            // 
            // radioButtonMethodDelete
            // 
            this.radioButtonMethodDelete.AutoSize = true;
            this.radioButtonMethodDelete.Location = new System.Drawing.Point(59, 46);
            this.radioButtonMethodDelete.Name = "radioButtonMethodDelete";
            this.radioButtonMethodDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonMethodDelete.Size = new System.Drawing.Size(67, 17);
            this.radioButtonMethodDelete.TabIndex = 3;
            this.radioButtonMethodDelete.Text = "DELETE";
            this.radioButtonMethodDelete.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodPut
            // 
            this.radioButtonMethodPut.AutoSize = true;
            this.radioButtonMethodPut.Location = new System.Drawing.Point(6, 46);
            this.radioButtonMethodPut.Name = "radioButtonMethodPut";
            this.radioButtonMethodPut.Size = new System.Drawing.Size(47, 17);
            this.radioButtonMethodPut.TabIndex = 2;
            this.radioButtonMethodPut.Text = "PUT";
            this.radioButtonMethodPut.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodGet
            // 
            this.radioButtonMethodGet.AutoSize = true;
            this.radioButtonMethodGet.Location = new System.Drawing.Point(6, 19);
            this.radioButtonMethodGet.Name = "radioButtonMethodGet";
            this.radioButtonMethodGet.Size = new System.Drawing.Size(47, 17);
            this.radioButtonMethodGet.TabIndex = 0;
            this.radioButtonMethodGet.Text = "GET";
            this.radioButtonMethodGet.UseVisualStyleBackColor = true;
            // 
            // radioButtonMethodPost
            // 
            this.radioButtonMethodPost.AutoSize = true;
            this.radioButtonMethodPost.Checked = true;
            this.radioButtonMethodPost.Location = new System.Drawing.Point(59, 19);
            this.radioButtonMethodPost.Name = "radioButtonMethodPost";
            this.radioButtonMethodPost.Size = new System.Drawing.Size(54, 17);
            this.radioButtonMethodPost.TabIndex = 1;
            this.radioButtonMethodPost.TabStop = true;
            this.radioButtonMethodPost.Text = "POST";
            this.radioButtonMethodPost.UseVisualStyleBackColor = true;
            // 
            // groupBoxName
            // 
            this.groupBoxName.Controls.Add(this.textBoxName);
            this.groupBoxName.Location = new System.Drawing.Point(12, 12);
            this.groupBoxName.Name = "groupBoxName";
            this.groupBoxName.Size = new System.Drawing.Size(479, 44);
            this.groupBoxName.TabIndex = 9;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(460, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // buttonTestPing
            // 
            this.buttonTestPing.Location = new System.Drawing.Point(416, 198);
            this.buttonTestPing.Name = "buttonTestPing";
            this.buttonTestPing.Size = new System.Drawing.Size(75, 23);
            this.buttonTestPing.TabIndex = 10;
            this.buttonTestPing.Text = "Test Ping";
            this.buttonTestPing.UseVisualStyleBackColor = true;
            this.buttonTestPing.Click += new System.EventHandler(this.ButtonTestPing_Click);
            // 
            // FormEditPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(502, 230);
            this.Controls.Add(this.buttonTestPing);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.groupBoxAuthorisation);
            this.Controls.Add(this.groupBoxMethod);
            this.Controls.Add(this.groupBoxUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit remote ping settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPing_FormClosing);
            this.groupBoxAuthorisation.ResumeLayout(false);
            this.groupBoxAuthorisation.PerformLayout();
            this.groupBoxUrl.ResumeLayout(false);
            this.groupBoxUrl.PerformLayout();
            this.groupBoxMethod.ResumeLayout(false);
            this.groupBoxMethod.PerformLayout();
            this.groupBoxName.ResumeLayout(false);
            this.groupBoxName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxMethod;
        private System.Windows.Forms.GroupBox groupBoxUrl;
        private System.Windows.Forms.GroupBox groupBoxAuthorisation;
        private System.Windows.Forms.RadioButton radioButtonUseNormalField;
        private System.Windows.Forms.RadioButton radioButtonUseAuthField;
        private System.Windows.Forms.RadioButton radioButtonMethodDelete;
        private System.Windows.Forms.RadioButton radioButtonMethodPut;
        private System.Windows.Forms.RadioButton radioButtonMethodGet;
        private System.Windows.Forms.RadioButton radioButtonMethodPost;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxAuthToken;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelAuthToken;
        private System.Windows.Forms.Label labelAuthName;
        private System.Windows.Forms.TextBox textBoxAuthName;
        private System.Windows.Forms.Button buttonTestPing;
    }
}