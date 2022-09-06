
namespace PlenBotLogUploader
{
    partial class FormArcPluginManager
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
            this.components = new System.ComponentModel.Container();
            this.buttonChangeGW2Location = new System.Windows.Forms.Button();
            this.timerCheckUpdates = new System.Windows.Forms.Timer(this.components);
            this.checkedListBoxArcDpsPlugins = new System.Windows.Forms.CheckedListBox();
            this.checkBoxModuleEnabled = new System.Windows.Forms.CheckBox();
            this.groupBoxModuleEnabled = new System.Windows.Forms.GroupBox();
            this.groupBoxModuleControls = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableNotifications = new System.Windows.Forms.CheckBox();
            this.buttonCheckNow = new System.Windows.Forms.Button();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.buttonShowPluginInfo = new System.Windows.Forms.Button();
            this.groupBoxModuleEnabled.SuspendLayout();
            this.groupBoxModuleControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeGW2Location
            // 
            this.buttonChangeGW2Location.Location = new System.Drawing.Point(8, 23);
            this.buttonChangeGW2Location.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChangeGW2Location.Name = "buttonChangeGW2Location";
            this.buttonChangeGW2Location.Size = new System.Drawing.Size(201, 28);
            this.buttonChangeGW2Location.TabIndex = 0;
            this.buttonChangeGW2Location.Text = "Change GW2 location";
            this.buttonChangeGW2Location.UseVisualStyleBackColor = true;
            this.buttonChangeGW2Location.Click += new System.EventHandler(this.ButtonChangeGW2Location_Click);
            // 
            // timerCheckUpdates
            // 
            this.timerCheckUpdates.Interval = 9000000;
            this.timerCheckUpdates.Tick += new System.EventHandler(this.TimerCheckUpdates_Tick);
            // 
            // checkedListBoxArcDpsPlugins
            // 
            this.checkedListBoxArcDpsPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxArcDpsPlugins.Enabled = false;
            this.checkedListBoxArcDpsPlugins.Location = new System.Drawing.Point(241, 15);
            this.checkedListBoxArcDpsPlugins.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxArcDpsPlugins.Name = "checkedListBoxArcDpsPlugins";
            this.checkedListBoxArcDpsPlugins.Size = new System.Drawing.Size(355, 170);
            this.checkedListBoxArcDpsPlugins.Sorted = true;
            this.checkedListBoxArcDpsPlugins.TabIndex = 2;
            this.checkedListBoxArcDpsPlugins.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxArcDpsPlugins_SelectedIndexChanged);
            // 
            // checkBoxModuleEnabled
            // 
            this.checkBoxModuleEnabled.AutoSize = true;
            this.checkBoxModuleEnabled.Location = new System.Drawing.Point(8, 23);
            this.checkBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxModuleEnabled.Name = "checkBoxModuleEnabled";
            this.checkBoxModuleEnabled.Size = new System.Drawing.Size(119, 20);
            this.checkBoxModuleEnabled.TabIndex = 3;
            this.checkBoxModuleEnabled.Text = "enable module";
            this.checkBoxModuleEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModuleEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxModuleEnabled_CheckedChanged);
            // 
            // groupBoxModuleEnabled
            // 
            this.groupBoxModuleEnabled.Controls.Add(this.checkBoxModuleEnabled);
            this.groupBoxModuleEnabled.Location = new System.Drawing.Point(16, 15);
            this.groupBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxModuleEnabled.Name = "groupBoxModuleEnabled";
            this.groupBoxModuleEnabled.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxModuleEnabled.Size = new System.Drawing.Size(217, 54);
            this.groupBoxModuleEnabled.TabIndex = 4;
            this.groupBoxModuleEnabled.TabStop = false;
            this.groupBoxModuleEnabled.Text = "arcdps plugin manager";
            // 
            // groupBoxModuleControls
            // 
            this.groupBoxModuleControls.Controls.Add(this.checkBoxEnableNotifications);
            this.groupBoxModuleControls.Controls.Add(this.buttonCheckNow);
            this.groupBoxModuleControls.Controls.Add(this.buttonChangeGW2Location);
            this.groupBoxModuleControls.Enabled = false;
            this.groupBoxModuleControls.Location = new System.Drawing.Point(16, 101);
            this.groupBoxModuleControls.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxModuleControls.Name = "groupBoxModuleControls";
            this.groupBoxModuleControls.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxModuleControls.Size = new System.Drawing.Size(217, 124);
            this.groupBoxModuleControls.TabIndex = 5;
            this.groupBoxModuleControls.TabStop = false;
            this.groupBoxModuleControls.Text = "Module controls";
            // 
            // checkBoxEnableNotifications
            // 
            this.checkBoxEnableNotifications.AutoSize = true;
            this.checkBoxEnableNotifications.Location = new System.Drawing.Point(8, 59);
            this.checkBoxEnableNotifications.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEnableNotifications.Name = "checkBoxEnableNotifications";
            this.checkBoxEnableNotifications.Size = new System.Drawing.Size(189, 20);
            this.checkBoxEnableNotifications.TabIndex = 2;
            this.checkBoxEnableNotifications.Text = "enable update notifications";
            this.checkBoxEnableNotifications.UseVisualStyleBackColor = true;
            this.checkBoxEnableNotifications.CheckedChanged += new System.EventHandler(this.CheckBoxEnableNotifications_CheckedChanged);
            // 
            // buttonCheckNow
            // 
            this.buttonCheckNow.Location = new System.Drawing.Point(8, 87);
            this.buttonCheckNow.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCheckNow.Name = "buttonCheckNow";
            this.buttonCheckNow.Size = new System.Drawing.Size(201, 28);
            this.buttonCheckNow.TabIndex = 1;
            this.buttonCheckNow.Text = "Check now";
            this.buttonCheckNow.UseVisualStyleBackColor = true;
            this.buttonCheckNow.Click += new System.EventHandler(this.ButtonCheckNow_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusText.Location = new System.Drawing.Point(15, 229);
            this.labelStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(581, 28);
            this.labelStatusText.TabIndex = 6;
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonShowPluginInfo
            // 
            this.buttonShowPluginInfo.Enabled = false;
            this.buttonShowPluginInfo.Location = new System.Drawing.Point(240, 197);
            this.buttonShowPluginInfo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowPluginInfo.Name = "buttonShowPluginInfo";
            this.buttonShowPluginInfo.Size = new System.Drawing.Size(356, 28);
            this.buttonShowPluginInfo.TabIndex = 8;
            this.buttonShowPluginInfo.Text = "Show plugin information";
            this.buttonShowPluginInfo.UseVisualStyleBackColor = true;
            this.buttonShowPluginInfo.Click += new System.EventHandler(this.ButtonShowPluginInfo_Click);
            // 
            // FormArcPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 268);
            this.Controls.Add(this.buttonShowPluginInfo);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.groupBoxModuleControls);
            this.Controls.Add(this.groupBoxModuleEnabled);
            this.Controls.Add(this.checkedListBoxArcDpsPlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArcPluginManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "arcdps plugin manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormArcPluginManager_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormArcPluginManager_FormClosed);
            this.groupBoxModuleEnabled.ResumeLayout(false);
            this.groupBoxModuleEnabled.PerformLayout();
            this.groupBoxModuleControls.ResumeLayout(false);
            this.groupBoxModuleControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeGW2Location;
        public System.Windows.Forms.Timer timerCheckUpdates;
        private System.Windows.Forms.CheckedListBox checkedListBoxArcDpsPlugins;
        private System.Windows.Forms.GroupBox groupBoxModuleEnabled;
        private System.Windows.Forms.GroupBox groupBoxModuleControls;
        private System.Windows.Forms.Button buttonCheckNow;
        private System.Windows.Forms.Label labelStatusText;
        public System.Windows.Forms.CheckBox checkBoxModuleEnabled;
        public System.Windows.Forms.CheckBox checkBoxEnableNotifications;
        private System.Windows.Forms.Button buttonShowPluginInfo;
    }
}