
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
            components = new System.ComponentModel.Container();
            buttonChangeGW2Location = new System.Windows.Forms.Button();
            timerCheckUpdates = new System.Windows.Forms.Timer(components);
            checkedListBoxArcDpsPlugins = new System.Windows.Forms.CheckedListBox();
            checkBoxModuleEnabled = new System.Windows.Forms.CheckBox();
            groupBoxModuleEnabled = new System.Windows.Forms.GroupBox();
            groupBoxModuleControls = new System.Windows.Forms.GroupBox();
            groupBoxChainLoad = new System.Windows.Forms.GroupBox();
            radioButtonChainLoadNexus = new System.Windows.Forms.RadioButton();
            radioButtonChainLoadAL = new System.Windows.Forms.RadioButton();
            radioButtonChainLoadNone = new System.Windows.Forms.RadioButton();
            checkBoxEnableNotifications = new System.Windows.Forms.CheckBox();
            buttonCheckNow = new System.Windows.Forms.Button();
            labelStatusText = new System.Windows.Forms.Label();
            buttonShowPluginInfo = new System.Windows.Forms.Button();
            toolTipAL = new System.Windows.Forms.ToolTip(components);
            groupBoxModuleEnabled.SuspendLayout();
            groupBoxModuleControls.SuspendLayout();
            groupBoxChainLoad.SuspendLayout();
            SuspendLayout();
            // 
            // buttonChangeGW2Location
            // 
            buttonChangeGW2Location.Location = new System.Drawing.Point(8, 29);
            buttonChangeGW2Location.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonChangeGW2Location.Name = "buttonChangeGW2Location";
            buttonChangeGW2Location.Size = new System.Drawing.Size(209, 35);
            buttonChangeGW2Location.TabIndex = 0;
            buttonChangeGW2Location.Text = "Change GW2 location";
            buttonChangeGW2Location.UseVisualStyleBackColor = true;
            buttonChangeGW2Location.Click += ButtonChangeGW2Location_Click;
            // 
            // timerCheckUpdates
            // 
            timerCheckUpdates.Interval = 9000000;
            timerCheckUpdates.Tick += TimerCheckUpdates_Tick;
            // 
            // checkedListBoxArcDpsPlugins
            // 
            checkedListBoxArcDpsPlugins.BorderStyle = System.Windows.Forms.BorderStyle.None;
            checkedListBoxArcDpsPlugins.Enabled = false;
            checkedListBoxArcDpsPlugins.Location = new System.Drawing.Point(249, 18);
            checkedListBoxArcDpsPlugins.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkedListBoxArcDpsPlugins.Name = "checkedListBoxArcDpsPlugins";
            checkedListBoxArcDpsPlugins.Size = new System.Drawing.Size(354, 286);
            checkedListBoxArcDpsPlugins.Sorted = true;
            checkedListBoxArcDpsPlugins.TabIndex = 2;
            checkedListBoxArcDpsPlugins.SelectedIndexChanged += CheckedListBoxArcDpsPlugins_SelectedIndexChanged;
            // 
            // checkBoxModuleEnabled
            // 
            checkBoxModuleEnabled.AutoSize = true;
            checkBoxModuleEnabled.Location = new System.Drawing.Point(8, 29);
            checkBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxModuleEnabled.Name = "checkBoxModuleEnabled";
            checkBoxModuleEnabled.Size = new System.Drawing.Size(131, 24);
            checkBoxModuleEnabled.TabIndex = 3;
            checkBoxModuleEnabled.Text = "enable module";
            checkBoxModuleEnabled.UseVisualStyleBackColor = true;
            checkBoxModuleEnabled.CheckedChanged += CheckBoxModuleEnabled_CheckedChanged;
            // 
            // groupBoxModuleEnabled
            // 
            groupBoxModuleEnabled.Controls.Add(checkBoxModuleEnabled);
            groupBoxModuleEnabled.Location = new System.Drawing.Point(16, 18);
            groupBoxModuleEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxModuleEnabled.Name = "groupBoxModuleEnabled";
            groupBoxModuleEnabled.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxModuleEnabled.Size = new System.Drawing.Size(225, 68);
            groupBoxModuleEnabled.TabIndex = 4;
            groupBoxModuleEnabled.TabStop = false;
            groupBoxModuleEnabled.Text = "arcdps plugin manager";
            // 
            // groupBoxModuleControls
            // 
            groupBoxModuleControls.Controls.Add(groupBoxChainLoad);
            groupBoxModuleControls.Controls.Add(checkBoxEnableNotifications);
            groupBoxModuleControls.Controls.Add(buttonCheckNow);
            groupBoxModuleControls.Controls.Add(buttonChangeGW2Location);
            groupBoxModuleControls.Enabled = false;
            groupBoxModuleControls.Location = new System.Drawing.Point(16, 95);
            groupBoxModuleControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxModuleControls.Name = "groupBoxModuleControls";
            groupBoxModuleControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            groupBoxModuleControls.Size = new System.Drawing.Size(225, 250);
            groupBoxModuleControls.TabIndex = 5;
            groupBoxModuleControls.TabStop = false;
            groupBoxModuleControls.Text = "Module controls";
            // 
            // groupBoxChainLoad
            // 
            groupBoxChainLoad.Controls.Add(radioButtonChainLoadNexus);
            groupBoxChainLoad.Controls.Add(radioButtonChainLoadAL);
            groupBoxChainLoad.Controls.Add(radioButtonChainLoadNone);
            groupBoxChainLoad.Location = new System.Drawing.Point(8, 72);
            groupBoxChainLoad.Name = "groupBoxChainLoad";
            groupBoxChainLoad.Size = new System.Drawing.Size(209, 109);
            groupBoxChainLoad.TabIndex = 9;
            groupBoxChainLoad.TabStop = false;
            groupBoxChainLoad.Text = "Chainload settings";
            // 
            // radioButtonChainLoadNexus
            // 
            radioButtonChainLoadNexus.AutoSize = true;
            radioButtonChainLoadNexus.Location = new System.Drawing.Point(6, 79);
            radioButtonChainLoadNexus.Name = "radioButtonChainLoadNexus";
            radioButtonChainLoadNexus.Size = new System.Drawing.Size(98, 24);
            radioButtonChainLoadNexus.TabIndex = 2;
            radioButtonChainLoadNexus.TabStop = true;
            radioButtonChainLoadNexus.Text = "Use Nexus";
            radioButtonChainLoadNexus.UseVisualStyleBackColor = true;
            // 
            // radioButtonChainLoadAL
            // 
            radioButtonChainLoadAL.AutoSize = true;
            radioButtonChainLoadAL.Location = new System.Drawing.Point(6, 50);
            radioButtonChainLoadAL.Name = "radioButtonChainLoadAL";
            radioButtonChainLoadAL.Size = new System.Drawing.Size(153, 24);
            radioButtonChainLoadAL.TabIndex = 1;
            radioButtonChainLoadAL.TabStop = true;
            radioButtonChainLoadAL.Text = "Use Addon Loader";
            radioButtonChainLoadAL.UseVisualStyleBackColor = true;
            // 
            // radioButtonChainLoadNone
            // 
            radioButtonChainLoadNone.AutoSize = true;
            radioButtonChainLoadNone.Checked = true;
            radioButtonChainLoadNone.Location = new System.Drawing.Point(6, 22);
            radioButtonChainLoadNone.Name = "radioButtonChainLoadNone";
            radioButtonChainLoadNone.Size = new System.Drawing.Size(119, 24);
            radioButtonChainLoadNone.TabIndex = 0;
            radioButtonChainLoadNone.TabStop = true;
            radioButtonChainLoadNone.Text = "No chainload";
            radioButtonChainLoadNone.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnableNotifications
            // 
            checkBoxEnableNotifications.AutoSize = true;
            checkBoxEnableNotifications.Location = new System.Drawing.Point(8, 185);
            checkBoxEnableNotifications.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            checkBoxEnableNotifications.Name = "checkBoxEnableNotifications";
            checkBoxEnableNotifications.Size = new System.Drawing.Size(213, 24);
            checkBoxEnableNotifications.TabIndex = 2;
            checkBoxEnableNotifications.Text = "enable update notifications";
            checkBoxEnableNotifications.UseVisualStyleBackColor = true;
            checkBoxEnableNotifications.CheckedChanged += CheckBoxEnableNotifications_CheckedChanged;
            // 
            // buttonCheckNow
            // 
            buttonCheckNow.Location = new System.Drawing.Point(8, 210);
            buttonCheckNow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonCheckNow.Name = "buttonCheckNow";
            buttonCheckNow.Size = new System.Drawing.Size(209, 35);
            buttonCheckNow.TabIndex = 1;
            buttonCheckNow.Text = "Check now";
            buttonCheckNow.UseVisualStyleBackColor = true;
            buttonCheckNow.Click += ButtonCheckNow_Click;
            // 
            // labelStatusText
            // 
            labelStatusText.Location = new System.Drawing.Point(16, 350);
            labelStatusText.Margin = new System.Windows.Forms.Padding(0);
            labelStatusText.Name = "labelStatusText";
            labelStatusText.Size = new System.Drawing.Size(588, 35);
            labelStatusText.TabIndex = 6;
            labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonShowPluginInfo
            // 
            buttonShowPluginInfo.Enabled = false;
            buttonShowPluginInfo.Location = new System.Drawing.Point(245, 305);
            buttonShowPluginInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonShowPluginInfo.Name = "buttonShowPluginInfo";
            buttonShowPluginInfo.Size = new System.Drawing.Size(358, 35);
            buttonShowPluginInfo.TabIndex = 8;
            buttonShowPluginInfo.Text = "Show plugin information";
            buttonShowPluginInfo.UseVisualStyleBackColor = true;
            buttonShowPluginInfo.Click += ButtonShowPluginInfo_Click;
            // 
            // FormArcPluginManager
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(612, 393);
            Controls.Add(buttonShowPluginInfo);
            Controls.Add(labelStatusText);
            Controls.Add(groupBoxModuleControls);
            Controls.Add(groupBoxModuleEnabled);
            Controls.Add(checkedListBoxArcDpsPlugins);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormArcPluginManager";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "arcdps plugin manager";
            FormClosing += FormArcPluginManager_FormClosing;
            FormClosed += FormArcPluginManager_FormClosed;
            groupBoxModuleEnabled.ResumeLayout(false);
            groupBoxModuleEnabled.PerformLayout();
            groupBoxModuleControls.ResumeLayout(false);
            groupBoxModuleControls.PerformLayout();
            groupBoxChainLoad.ResumeLayout(false);
            groupBoxChainLoad.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.ToolTip toolTipAL;
        private System.Windows.Forms.GroupBox groupBoxChainLoad;
        private System.Windows.Forms.RadioButton radioButtonChainLoadNexus;
        private System.Windows.Forms.RadioButton radioButtonChainLoadAL;
        private System.Windows.Forms.RadioButton radioButtonChainLoadNone;
    }
}