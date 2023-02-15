
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
            this.checkBoxUseAL = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableNotifications = new System.Windows.Forms.CheckBox();
            this.buttonCheckNow = new System.Windows.Forms.Button();
            this.labelStatusText = new System.Windows.Forms.Label();
            this.buttonShowPluginInfo = new System.Windows.Forms.Button();
            this.toolTipAL = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxModuleEnabled.SuspendLayout();
            this.groupBoxModuleControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeGW2Location
            // 
            this.buttonChangeGW2Location.Location = new System.Drawing.Point(8, 29);
            this.buttonChangeGW2Location.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonChangeGW2Location.Name = "buttonChangeGW2Location";
            this.buttonChangeGW2Location.Size = new System.Drawing.Size(209, 35);
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
            this.checkedListBoxArcDpsPlugins.Location = new System.Drawing.Point(249, 18);
            this.checkedListBoxArcDpsPlugins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkedListBoxArcDpsPlugins.Name = "checkedListBoxArcDpsPlugins";
            this.checkedListBoxArcDpsPlugins.Size = new System.Drawing.Size(354, 220);
            this.checkedListBoxArcDpsPlugins.Sorted = true;
            this.checkedListBoxArcDpsPlugins.TabIndex = 2;
            this.checkedListBoxArcDpsPlugins.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxArcDpsPlugins_SelectedIndexChanged);
            // 
            // checkBoxModuleEnabled
            // 
            this.checkBoxModuleEnabled.AutoSize = true;
            this.checkBoxModuleEnabled.Location = new System.Drawing.Point(8, 29);
            this.checkBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxModuleEnabled.Name = "checkBoxModuleEnabled";
            this.checkBoxModuleEnabled.Size = new System.Drawing.Size(131, 24);
            this.checkBoxModuleEnabled.TabIndex = 3;
            this.checkBoxModuleEnabled.Text = "enable module";
            this.checkBoxModuleEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModuleEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxModuleEnabled_CheckedChanged);
            // 
            // groupBoxModuleEnabled
            // 
            this.groupBoxModuleEnabled.Controls.Add(this.checkBoxModuleEnabled);
            this.groupBoxModuleEnabled.Location = new System.Drawing.Point(16, 18);
            this.groupBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxModuleEnabled.Name = "groupBoxModuleEnabled";
            this.groupBoxModuleEnabled.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxModuleEnabled.Size = new System.Drawing.Size(225, 68);
            this.groupBoxModuleEnabled.TabIndex = 4;
            this.groupBoxModuleEnabled.TabStop = false;
            this.groupBoxModuleEnabled.Text = "arcdps plugin manager";
            // 
            // groupBoxModuleControls
            // 
            this.groupBoxModuleControls.Controls.Add(this.checkBoxUseAL);
            this.groupBoxModuleControls.Controls.Add(this.checkBoxEnableNotifications);
            this.groupBoxModuleControls.Controls.Add(this.buttonCheckNow);
            this.groupBoxModuleControls.Controls.Add(this.buttonChangeGW2Location);
            this.groupBoxModuleControls.Enabled = false;
            this.groupBoxModuleControls.Location = new System.Drawing.Point(16, 95);
            this.groupBoxModuleControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxModuleControls.Name = "groupBoxModuleControls";
            this.groupBoxModuleControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxModuleControls.Size = new System.Drawing.Size(225, 186);
            this.groupBoxModuleControls.TabIndex = 5;
            this.groupBoxModuleControls.TabStop = false;
            this.groupBoxModuleControls.Text = "Module controls";
            // 
            // checkBoxUseAL
            // 
            this.checkBoxUseAL.AutoSize = true;
            this.checkBoxUseAL.Location = new System.Drawing.Point(8, 74);
            this.checkBoxUseAL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxUseAL.Name = "checkBoxUseAL";
            this.checkBoxUseAL.Size = new System.Drawing.Size(152, 24);
            this.checkBoxUseAL.TabIndex = 3;
            this.checkBoxUseAL.Text = "use Addon Loader";
            this.toolTipAL.SetToolTip(this.checkBoxUseAL, "Check this if you use the Addon Manager for other Addons such as GW2Radial alread" +
        "y");
            this.checkBoxUseAL.UseVisualStyleBackColor = true;
            this.checkBoxUseAL.CheckedChanged += new System.EventHandler(this.CheckBoxUseAL_CheckedChanged);
            // 
            // checkBoxEnableNotifications
            // 
            this.checkBoxEnableNotifications.AutoSize = true;
            this.checkBoxEnableNotifications.Location = new System.Drawing.Point(8, 106);
            this.checkBoxEnableNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxEnableNotifications.Name = "checkBoxEnableNotifications";
            this.checkBoxEnableNotifications.Size = new System.Drawing.Size(213, 24);
            this.checkBoxEnableNotifications.TabIndex = 2;
            this.checkBoxEnableNotifications.Text = "enable update notifications";
            this.checkBoxEnableNotifications.UseVisualStyleBackColor = true;
            this.checkBoxEnableNotifications.CheckedChanged += new System.EventHandler(this.CheckBoxEnableNotifications_CheckedChanged);
            // 
            // buttonCheckNow
            // 
            this.buttonCheckNow.Location = new System.Drawing.Point(8, 142);
            this.buttonCheckNow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCheckNow.Name = "buttonCheckNow";
            this.buttonCheckNow.Size = new System.Drawing.Size(209, 35);
            this.buttonCheckNow.TabIndex = 1;
            this.buttonCheckNow.Text = "Check now";
            this.buttonCheckNow.UseVisualStyleBackColor = true;
            this.buttonCheckNow.Click += new System.EventHandler(this.ButtonCheckNow_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.Location = new System.Drawing.Point(15, 286);
            this.labelStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(588, 35);
            this.labelStatusText.TabIndex = 6;
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonShowPluginInfo
            // 
            this.buttonShowPluginInfo.Enabled = false;
            this.buttonShowPluginInfo.Location = new System.Drawing.Point(245, 246);
            this.buttonShowPluginInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShowPluginInfo.Name = "buttonShowPluginInfo";
            this.buttonShowPluginInfo.Size = new System.Drawing.Size(358, 35);
            this.buttonShowPluginInfo.TabIndex = 8;
            this.buttonShowPluginInfo.Text = "Show plugin information";
            this.buttonShowPluginInfo.UseVisualStyleBackColor = true;
            this.buttonShowPluginInfo.Click += new System.EventHandler(this.ButtonShowPluginInfo_Click);
            // 
            // FormArcPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 335);
            this.Controls.Add(this.buttonShowPluginInfo);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.groupBoxModuleControls);
            this.Controls.Add(this.groupBoxModuleEnabled);
            this.Controls.Add(this.checkedListBoxArcDpsPlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        internal System.Windows.Forms.Timer timerCheckUpdates;
        private System.Windows.Forms.CheckedListBox checkedListBoxArcDpsPlugins;
        private System.Windows.Forms.GroupBox groupBoxModuleEnabled;
        private System.Windows.Forms.GroupBox groupBoxModuleControls;
        private System.Windows.Forms.Button buttonCheckNow;
        private System.Windows.Forms.Label labelStatusText;
        private System.Windows.Forms.Button buttonShowPluginInfo;
        internal System.Windows.Forms.CheckBox checkBoxModuleEnabled;
        internal System.Windows.Forms.CheckBox checkBoxEnableNotifications;
        internal System.Windows.Forms.CheckBox checkBoxUseAL;
        private System.Windows.Forms.ToolTip toolTipAL;
    }
}