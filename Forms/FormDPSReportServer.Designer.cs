namespace PlenBotLogUploader
{
    partial class FormDPSReportServer
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
            this.groupBoxAroundRadio = new System.Windows.Forms.GroupBox();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.groupBoxAroundRadio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAroundRadio
            // 
            this.groupBoxAroundRadio.Controls.Add(this.radioButtonB);
            this.groupBoxAroundRadio.Controls.Add(this.radioButtonA);
            this.groupBoxAroundRadio.Controls.Add(this.radioButtonNormal);
            this.groupBoxAroundRadio.Location = new System.Drawing.Point(13, 13);
            this.groupBoxAroundRadio.Name = "groupBoxAroundRadio";
            this.groupBoxAroundRadio.Size = new System.Drawing.Size(276, 62);
            this.groupBoxAroundRadio.TabIndex = 0;
            this.groupBoxAroundRadio.TabStop = false;
            this.groupBoxAroundRadio.Text = "DPS.report servers";
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Location = new System.Drawing.Point(184, 29);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(81, 17);
            this.radioButtonB.TabIndex = 2;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.Text = "b.dps.report";
            this.radioButtonB.UseVisualStyleBackColor = true;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Location = new System.Drawing.Point(97, 29);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(81, 17);
            this.radioButtonA.TabIndex = 1;
            this.radioButtonA.Text = "a.dps.report";
            this.radioButtonA.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(19, 29);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(72, 17);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "dps.report";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // FormDPSReportServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 87);
            this.Controls.Add(this.groupBoxAroundRadio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDPSReportServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DPS.report upload server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDPSReportServer_FormClosing);
            this.groupBoxAroundRadio.ResumeLayout(false);
            this.groupBoxAroundRadio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAroundRadio;
        public System.Windows.Forms.RadioButton radioButtonA;
        public System.Windows.Forms.RadioButton radioButtonNormal;
        public System.Windows.Forms.RadioButton radioButtonB;
    }
}