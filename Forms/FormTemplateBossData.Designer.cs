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
            this.groupBoxTemplateControls.Location = new System.Drawing.Point(12, 7);
            this.groupBoxTemplateControls.Name = "groupBoxTemplateControls";
            this.groupBoxTemplateControls.Size = new System.Drawing.Size(379, 101);
            this.groupBoxTemplateControls.TabIndex = 0;
            this.groupBoxTemplateControls.TabStop = false;
            this.groupBoxTemplateControls.Text = "Template controls";
            // 
            // buttonFailSave
            // 
            this.buttonFailSave.Location = new System.Drawing.Point(317, 69);
            this.buttonFailSave.Name = "buttonFailSave";
            this.buttonFailSave.Size = new System.Drawing.Size(56, 23);
            this.buttonFailSave.TabIndex = 5;
            this.buttonFailSave.Text = "Save";
            this.buttonFailSave.UseVisualStyleBackColor = true;
            this.buttonFailSave.Click += new System.EventHandler(this.ButtonFailSave_Click);
            // 
            // buttonSuccessSave
            // 
            this.buttonSuccessSave.Location = new System.Drawing.Point(317, 30);
            this.buttonSuccessSave.Name = "buttonSuccessSave";
            this.buttonSuccessSave.Size = new System.Drawing.Size(56, 23);
            this.buttonSuccessSave.TabIndex = 4;
            this.buttonSuccessSave.Text = "Save";
            this.buttonSuccessSave.UseVisualStyleBackColor = true;
            this.buttonSuccessSave.Click += new System.EventHandler(this.ButtonSuccessSave_Click);
            // 
            // labelFailedMessage
            // 
            this.labelFailedMessage.AutoSize = true;
            this.labelFailedMessage.Location = new System.Drawing.Point(3, 55);
            this.labelFailedMessage.Name = "labelFailedMessage";
            this.labelFailedMessage.Size = new System.Drawing.Size(118, 13);
            this.labelFailedMessage.TabIndex = 3;
            this.labelFailedMessage.Text = "Twitch message on fail:";
            // 
            // labelSuccessMessage
            // 
            this.labelSuccessMessage.AutoSize = true;
            this.labelSuccessMessage.Location = new System.Drawing.Point(3, 16);
            this.labelSuccessMessage.Name = "labelSuccessMessage";
            this.labelSuccessMessage.Size = new System.Drawing.Size(144, 13);
            this.labelSuccessMessage.TabIndex = 2;
            this.labelSuccessMessage.Text = "Twitch message on success:";
            // 
            // textBoxFailMessage
            // 
            this.textBoxFailMessage.Location = new System.Drawing.Point(6, 71);
            this.textBoxFailMessage.Name = "textBoxFailMessage";
            this.textBoxFailMessage.Size = new System.Drawing.Size(305, 20);
            this.textBoxFailMessage.TabIndex = 1;
            // 
            // textBoxSuccessMessage
            // 
            this.textBoxSuccessMessage.Location = new System.Drawing.Point(6, 32);
            this.textBoxSuccessMessage.Name = "textBoxSuccessMessage";
            this.textBoxSuccessMessage.Size = new System.Drawing.Size(305, 20);
            this.textBoxSuccessMessage.TabIndex = 0;
            // 
            // FormTemplateBossData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 114);
            this.Controls.Add(this.groupBoxTemplateControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTemplateBossData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boss data templates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTemplateBossData_FormClosing);
            this.groupBoxTemplateControls.ResumeLayout(false);
            this.groupBoxTemplateControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTemplateControls;
        private System.Windows.Forms.Label labelFailedMessage;
        private System.Windows.Forms.Label labelSuccessMessage;
        private System.Windows.Forms.TextBox textBoxFailMessage;
        private System.Windows.Forms.TextBox textBoxSuccessMessage;
        private System.Windows.Forms.Button buttonSuccessSave;
        private System.Windows.Forms.Button buttonFailSave;
    }
}