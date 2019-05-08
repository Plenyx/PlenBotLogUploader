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
            this.groupBoxPredefinedServers = new System.Windows.Forms.GroupBox();
            this.buttonPlenyxWay = new System.Windows.Forms.Button();
            this.buttonTestPing = new System.Windows.Forms.Button();
            this.groupBoxAuthentication = new System.Windows.Forms.GroupBox();
            this.radioButtonUseNormalField = new System.Windows.Forms.RadioButton();
            this.radioButtonUseAuthField = new System.Windows.Forms.RadioButton();
            this.textBoxSign = new System.Windows.Forms.TextBox();
            this.groupBoxUrl = new System.Windows.Forms.GroupBox();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.groupBoxMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonMethodDelete = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodPut = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodGet = new System.Windows.Forms.RadioButton();
            this.radioButtonMethodPost = new System.Windows.Forms.RadioButton();
            this.groupBoxName = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxPredefinedServers.SuspendLayout();
            this.groupBoxAuthentication.SuspendLayout();
            this.groupBoxUrl.SuspendLayout();
            this.groupBoxMethod.SuspendLayout();
            this.groupBoxName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPredefinedServers
            // 
            this.groupBoxPredefinedServers.Controls.Add(this.buttonPlenyxWay);
            this.groupBoxPredefinedServers.Location = new System.Drawing.Point(297, 113);
            this.groupBoxPredefinedServers.Name = "groupBoxPredefinedServers";
            this.groupBoxPredefinedServers.Size = new System.Drawing.Size(157, 93);
            this.groupBoxPredefinedServers.TabIndex = 8;
            this.groupBoxPredefinedServers.TabStop = false;
            this.groupBoxPredefinedServers.Text = "Predefined servers";
            // 
            // buttonPlenyxWay
            // 
            this.buttonPlenyxWay.Location = new System.Drawing.Point(6, 19);
            this.buttonPlenyxWay.Name = "buttonPlenyxWay";
            this.buttonPlenyxWay.Size = new System.Drawing.Size(143, 24);
            this.buttonPlenyxWay.TabIndex = 6;
            this.buttonPlenyxWay.Text = "Plenyx\'s server";
            this.buttonPlenyxWay.UseVisualStyleBackColor = true;
            this.buttonPlenyxWay.Click += new System.EventHandler(this.buttonPlenyxWay_Click);
            // 
            // buttonTestPing
            // 
            this.buttonTestPing.Location = new System.Drawing.Point(460, 173);
            this.buttonTestPing.Name = "buttonTestPing";
            this.buttonTestPing.Size = new System.Drawing.Size(90, 33);
            this.buttonTestPing.TabIndex = 7;
            this.buttonTestPing.Text = "Test ping";
            this.buttonTestPing.UseVisualStyleBackColor = true;
            this.buttonTestPing.Click += new System.EventHandler(this.buttonTestPing_Click);
            // 
            // groupBoxAuthentication
            // 
            this.groupBoxAuthentication.Controls.Add(this.radioButtonUseNormalField);
            this.groupBoxAuthentication.Controls.Add(this.radioButtonUseAuthField);
            this.groupBoxAuthentication.Controls.Add(this.textBoxSign);
            this.groupBoxAuthentication.Location = new System.Drawing.Point(145, 113);
            this.groupBoxAuthentication.Name = "groupBoxAuthentication";
            this.groupBoxAuthentication.Size = new System.Drawing.Size(146, 93);
            this.groupBoxAuthentication.TabIndex = 5;
            this.groupBoxAuthentication.TabStop = false;
            this.groupBoxAuthentication.Text = "Authentication";
            // 
            // radioButtonUseNormalField
            // 
            this.radioButtonUseNormalField.AutoSize = true;
            this.radioButtonUseNormalField.Checked = true;
            this.radioButtonUseNormalField.Location = new System.Drawing.Point(7, 69);
            this.radioButtonUseNormalField.Name = "radioButtonUseNormalField";
            this.radioButtonUseNormalField.Size = new System.Drawing.Size(89, 17);
            this.radioButtonUseNormalField.TabIndex = 2;
            this.radioButtonUseNormalField.TabStop = true;
            this.radioButtonUseNormalField.Text = "Use as a field";
            this.radioButtonUseNormalField.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseAuthField
            // 
            this.radioButtonUseAuthField.AutoSize = true;
            this.radioButtonUseAuthField.Location = new System.Drawing.Point(7, 46);
            this.radioButtonUseAuthField.Name = "radioButtonUseAuthField";
            this.radioButtonUseAuthField.Size = new System.Drawing.Size(129, 17);
            this.radioButtonUseAuthField.TabIndex = 1;
            this.radioButtonUseAuthField.Text = "Use as Authentication";
            this.radioButtonUseAuthField.UseVisualStyleBackColor = true;
            // 
            // textBoxSign
            // 
            this.textBoxSign.Location = new System.Drawing.Point(7, 20);
            this.textBoxSign.MaxLength = 50;
            this.textBoxSign.Name = "textBoxSign";
            this.textBoxSign.Size = new System.Drawing.Size(133, 20);
            this.textBoxSign.TabIndex = 0;
            this.textBoxSign.UseSystemPasswordChar = true;
            // 
            // groupBoxUrl
            // 
            this.groupBoxUrl.Controls.Add(this.textBoxURL);
            this.groupBoxUrl.Location = new System.Drawing.Point(12, 62);
            this.groupBoxUrl.Name = "groupBoxUrl";
            this.groupBoxUrl.Size = new System.Drawing.Size(538, 44);
            this.groupBoxUrl.TabIndex = 4;
            this.groupBoxUrl.TabStop = false;
            this.groupBoxUrl.Text = "URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(6, 18);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(521, 20);
            this.textBoxURL.TabIndex = 3;
            // 
            // groupBoxMethod
            // 
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodDelete);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodPut);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodGet);
            this.groupBoxMethod.Controls.Add(this.radioButtonMethodPost);
            this.groupBoxMethod.Location = new System.Drawing.Point(12, 113);
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
            this.groupBoxName.Size = new System.Drawing.Size(538, 44);
            this.groupBoxName.TabIndex = 9;
            this.groupBoxName.TabStop = false;
            this.groupBoxName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(6, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(521, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // FormEditPing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 213);
            this.Controls.Add(this.groupBoxName);
            this.Controls.Add(this.groupBoxPredefinedServers);
            this.Controls.Add(this.buttonTestPing);
            this.Controls.Add(this.groupBoxAuthentication);
            this.Controls.Add(this.groupBoxMethod);
            this.Controls.Add(this.groupBoxUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditPing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit remote ping settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPing_FormClosing);
            this.groupBoxPredefinedServers.ResumeLayout(false);
            this.groupBoxAuthentication.ResumeLayout(false);
            this.groupBoxAuthentication.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxAuthentication;
        private System.Windows.Forms.Button buttonTestPing;
        private System.Windows.Forms.GroupBox groupBoxPredefinedServers;
        private System.Windows.Forms.RadioButton radioButtonUseNormalField;
        private System.Windows.Forms.RadioButton radioButtonUseAuthField;
        private System.Windows.Forms.RadioButton radioButtonMethodDelete;
        private System.Windows.Forms.RadioButton radioButtonMethodPut;
        private System.Windows.Forms.RadioButton radioButtonMethodGet;
        private System.Windows.Forms.RadioButton radioButtonMethodPost;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxSign;
        private System.Windows.Forms.Button buttonPlenyxWay;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}