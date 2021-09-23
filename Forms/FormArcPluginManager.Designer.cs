
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
            this.groupBoxDXVersion = new System.Windows.Forms.GroupBox();
            this.radioButtonDX11 = new System.Windows.Forms.RadioButton();
            this.radioButtonDX9 = new System.Windows.Forms.RadioButton();
            this.groupBoxModuleEnabled.SuspendLayout();
            this.groupBoxModuleControls.SuspendLayout();
            this.groupBoxDXVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeGW2Location
            // 
            this.buttonChangeGW2Location.Location = new System.Drawing.Point(6, 19);
            this.buttonChangeGW2Location.Name = "buttonChangeGW2Location";
            this.buttonChangeGW2Location.Size = new System.Drawing.Size(151, 23);
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
            this.checkedListBoxArcDpsPlugins.Enabled = false;
            this.checkedListBoxArcDpsPlugins.FormattingEnabled = true;
            this.checkedListBoxArcDpsPlugins.Location = new System.Drawing.Point(181, 12);
            this.checkedListBoxArcDpsPlugins.Name = "checkedListBoxArcDpsPlugins";
            this.checkedListBoxArcDpsPlugins.Size = new System.Drawing.Size(267, 199);
            this.checkedListBoxArcDpsPlugins.TabIndex = 2;
            // 
            // checkBoxModuleEnabled
            // 
            this.checkBoxModuleEnabled.AutoSize = true;
            this.checkBoxModuleEnabled.Location = new System.Drawing.Point(6, 19);
            this.checkBoxModuleEnabled.Name = "checkBoxModuleEnabled";
            this.checkBoxModuleEnabled.Size = new System.Drawing.Size(95, 17);
            this.checkBoxModuleEnabled.TabIndex = 3;
            this.checkBoxModuleEnabled.Text = "enable module";
            this.checkBoxModuleEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModuleEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxModuleEnabled_CheckedChanged);
            // 
            // groupBoxModuleEnabled
            // 
            this.groupBoxModuleEnabled.Controls.Add(this.checkBoxModuleEnabled);
            this.groupBoxModuleEnabled.Location = new System.Drawing.Point(12, 12);
            this.groupBoxModuleEnabled.Name = "groupBoxModuleEnabled";
            this.groupBoxModuleEnabled.Size = new System.Drawing.Size(163, 44);
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
            this.groupBoxModuleControls.Location = new System.Drawing.Point(12, 110);
            this.groupBoxModuleControls.Name = "groupBoxModuleControls";
            this.groupBoxModuleControls.Size = new System.Drawing.Size(163, 101);
            this.groupBoxModuleControls.TabIndex = 5;
            this.groupBoxModuleControls.TabStop = false;
            this.groupBoxModuleControls.Text = "Module controls";
            // 
            // checkBoxEnableNotifications
            // 
            this.checkBoxEnableNotifications.AutoSize = true;
            this.checkBoxEnableNotifications.Location = new System.Drawing.Point(6, 48);
            this.checkBoxEnableNotifications.Name = "checkBoxEnableNotifications";
            this.checkBoxEnableNotifications.Size = new System.Drawing.Size(153, 17);
            this.checkBoxEnableNotifications.TabIndex = 2;
            this.checkBoxEnableNotifications.Text = "enable update notifications";
            this.checkBoxEnableNotifications.UseVisualStyleBackColor = true;
            this.checkBoxEnableNotifications.CheckedChanged += new System.EventHandler(this.CheckBoxEnableNotifications_CheckedChanged);
            // 
            // buttonCheckNow
            // 
            this.buttonCheckNow.Location = new System.Drawing.Point(6, 71);
            this.buttonCheckNow.Name = "buttonCheckNow";
            this.buttonCheckNow.Size = new System.Drawing.Size(151, 23);
            this.buttonCheckNow.TabIndex = 1;
            this.buttonCheckNow.Text = "Check now";
            this.buttonCheckNow.UseVisualStyleBackColor = true;
            this.buttonCheckNow.Click += new System.EventHandler(this.ButtonCheckNow_Click);
            // 
            // labelStatusText
            // 
            this.labelStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusText.Location = new System.Drawing.Point(12, 214);
            this.labelStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(436, 23);
            this.labelStatusText.TabIndex = 6;
            this.labelStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxDXVersion
            // 
            this.groupBoxDXVersion.Controls.Add(this.radioButtonDX11);
            this.groupBoxDXVersion.Controls.Add(this.radioButtonDX9);
            this.groupBoxDXVersion.Location = new System.Drawing.Point(12, 62);
            this.groupBoxDXVersion.Name = "groupBoxDXVersion";
            this.groupBoxDXVersion.Size = new System.Drawing.Size(163, 42);
            this.groupBoxDXVersion.TabIndex = 7;
            this.groupBoxDXVersion.TabStop = false;
            this.groupBoxDXVersion.Text = "Game\'s DirectX version";
            // 
            // radioButtonDX11
            // 
            this.radioButtonDX11.AutoSize = true;
            this.radioButtonDX11.Location = new System.Drawing.Point(84, 19);
            this.radioButtonDX11.Name = "radioButtonDX11";
            this.radioButtonDX11.Size = new System.Drawing.Size(75, 17);
            this.radioButtonDX11.TabIndex = 1;
            this.radioButtonDX11.Text = "DirectX 11";
            this.radioButtonDX11.UseVisualStyleBackColor = true;
            // 
            // radioButtonDX9
            // 
            this.radioButtonDX9.AutoSize = true;
            this.radioButtonDX9.Checked = true;
            this.radioButtonDX9.Location = new System.Drawing.Point(6, 19);
            this.radioButtonDX9.Name = "radioButtonDX9";
            this.radioButtonDX9.Size = new System.Drawing.Size(69, 17);
            this.radioButtonDX9.TabIndex = 0;
            this.radioButtonDX9.TabStop = true;
            this.radioButtonDX9.Text = "DirectX 9";
            this.radioButtonDX9.UseVisualStyleBackColor = true;
            // 
            // FormArcPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 243);
            this.Controls.Add(this.groupBoxDXVersion);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.groupBoxModuleControls);
            this.Controls.Add(this.groupBoxModuleEnabled);
            this.Controls.Add(this.checkedListBoxArcDpsPlugins);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.groupBoxDXVersion.ResumeLayout(false);
            this.groupBoxDXVersion.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxDXVersion;
        private System.Windows.Forms.RadioButton radioButtonDX9;
        internal System.Windows.Forms.RadioButton radioButtonDX11;
    }
}