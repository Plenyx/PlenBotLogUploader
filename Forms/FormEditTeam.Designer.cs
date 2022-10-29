
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
            this.buttonOpenMainCondition = new System.Windows.Forms.Button();
            this.groupBoxTeamName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTeamName
            // 
            this.groupBoxTeamName.Controls.Add(this.textBoxName);
            this.groupBoxTeamName.Location = new System.Drawing.Point(16, 19);
            this.groupBoxTeamName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTeamName.Name = "groupBoxTeamName";
            this.groupBoxTeamName.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTeamName.Size = new System.Drawing.Size(384, 71);
            this.groupBoxTeamName.TabIndex = 0;
            this.groupBoxTeamName.TabStop = false;
            this.groupBoxTeamName.Text = "Team name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(8, 29);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(368, 27);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.TextBoxName_TextChanged);
            // 
            // buttonOpenMainCondition
            // 
            this.buttonOpenMainCondition.Enabled = false;
            this.buttonOpenMainCondition.Location = new System.Drawing.Point(16, 99);
            this.buttonOpenMainCondition.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOpenMainCondition.Name = "buttonOpenMainCondition";
            this.buttonOpenMainCondition.Size = new System.Drawing.Size(384, 40);
            this.buttonOpenMainCondition.TabIndex = 4;
            this.buttonOpenMainCondition.Text = "Setup condition parameters";
            this.buttonOpenMainCondition.UseVisualStyleBackColor = true;
            this.buttonOpenMainCondition.Click += new System.EventHandler(this.ButtonOpenMainCondition_Click);
            // 
            // FormEditTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 148);
            this.Controls.Add(this.buttonOpenMainCondition);
            this.Controls.Add(this.groupBoxTeamName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditTeam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditTeam_FormClosing);
            this.groupBoxTeamName.ResumeLayout(false);
            this.groupBoxTeamName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTeamName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonOpenMainCondition;
    }
}