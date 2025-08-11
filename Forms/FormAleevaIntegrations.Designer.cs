namespace PlenBotLogUploader
{
    partial class FormAleevaIntegrations
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
            groupBoxAleevaStatus = new System.Windows.Forms.GroupBox();
            buttonAddAleevaIntegration = new System.Windows.Forms.Button();
            listViewAleevaIntegrations = new System.Windows.Forms.ListView();
            contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(components);
            toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            groupBoxAccessCode = new System.Windows.Forms.GroupBox();
            textBoxAccessCode = new System.Windows.Forms.TextBox();
            buttonVerifyCode = new System.Windows.Forms.Button();
            groupBoxAleevaStatus.SuspendLayout();
            contextMenuStripInteract.SuspendLayout();
            groupBoxAccessCode.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxAleevaStatus
            // 
            groupBoxAleevaStatus.Controls.Add(buttonAddAleevaIntegration);
            groupBoxAleevaStatus.Controls.Add(listViewAleevaIntegrations);
            groupBoxAleevaStatus.Location = new System.Drawing.Point(15, 96);
            groupBoxAleevaStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            groupBoxAleevaStatus.Name = "groupBoxAleevaStatus";
            groupBoxAleevaStatus.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            groupBoxAleevaStatus.Size = new System.Drawing.Size(632, 378);
            groupBoxAleevaStatus.TabIndex = 2;
            groupBoxAleevaStatus.TabStop = false;
            groupBoxAleevaStatus.Text = "Status: Not verified";
            // 
            // buttonAddAleevaIntegration
            // 
            buttonAddAleevaIntegration.Location = new System.Drawing.Point(408, 338);
            buttonAddAleevaIntegration.Name = "buttonAddAleevaIntegration";
            buttonAddAleevaIntegration.Size = new System.Drawing.Size(216, 29);
            buttonAddAleevaIntegration.TabIndex = 2;
            buttonAddAleevaIntegration.Text = "Add a new Aleeva integration";
            buttonAddAleevaIntegration.UseVisualStyleBackColor = true;
            buttonAddAleevaIntegration.Click += ButtonAddAleevaIntegration_Click;
            // 
            // listViewAleevaIntegrations
            // 
            listViewAleevaIntegrations.CheckBoxes = true;
            listViewAleevaIntegrations.ContextMenuStrip = contextMenuStripInteract;
            listViewAleevaIntegrations.Enabled = false;
            listViewAleevaIntegrations.Location = new System.Drawing.Point(9, 24);
            listViewAleevaIntegrations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            listViewAleevaIntegrations.MultiSelect = false;
            listViewAleevaIntegrations.Name = "listViewAleevaIntegrations";
            listViewAleevaIntegrations.Size = new System.Drawing.Size(615, 306);
            listViewAleevaIntegrations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            listViewAleevaIntegrations.TabIndex = 1;
            listViewAleevaIntegrations.UseCompatibleStateImageBehavior = false;
            listViewAleevaIntegrations.ItemChecked += ListViewAleevaIntegrations_ItemChecked;
            // 
            // contextMenuStripInteract
            // 
            contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemEdit, toolStripMenuItemDelete, toolStripSeparatorOne, toolStripMenuItemAdd });
            contextMenuStripInteract.Name = "contextMenuStripInteract";
            contextMenuStripInteract.Size = new System.Drawing.Size(333, 82);
            contextMenuStripInteract.Opening += ContextMenuStripInteract_Opening;
            // 
            // toolStripMenuItemEdit
            // 
            toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            toolStripMenuItemEdit.Size = new System.Drawing.Size(332, 24);
            toolStripMenuItemEdit.Text = "Edit the selected Aleeva integration";
            toolStripMenuItemEdit.Click += ToolStripMenuItemEdit_Click;
            // 
            // toolStripMenuItemDelete
            // 
            toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            toolStripMenuItemDelete.Size = new System.Drawing.Size(332, 24);
            toolStripMenuItemDelete.Text = "Delete the selected Aleeva integration";
            toolStripMenuItemDelete.Click += ToolStripMenuItemDelete_Click;
            // 
            // toolStripSeparatorOne
            // 
            toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            toolStripSeparatorOne.Size = new System.Drawing.Size(329, 6);
            // 
            // toolStripMenuItemAdd
            // 
            toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            toolStripMenuItemAdd.Size = new System.Drawing.Size(332, 24);
            toolStripMenuItemAdd.Text = "Add a new Aleeva integration";
            toolStripMenuItemAdd.Click += ToolStripMenuItemAdd_Click;
            // 
            // groupBoxAccessCode
            // 
            groupBoxAccessCode.Controls.Add(textBoxAccessCode);
            groupBoxAccessCode.Controls.Add(buttonVerifyCode);
            groupBoxAccessCode.Location = new System.Drawing.Point(15, 16);
            groupBoxAccessCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            groupBoxAccessCode.Name = "groupBoxAccessCode";
            groupBoxAccessCode.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            groupBoxAccessCode.Size = new System.Drawing.Size(632, 72);
            groupBoxAccessCode.TabIndex = 0;
            groupBoxAccessCode.TabStop = false;
            groupBoxAccessCode.Text = "Authorise with Aleeva using her generated API access code";
            // 
            // textBoxAccessCode
            // 
            textBoxAccessCode.Location = new System.Drawing.Point(8, 29);
            textBoxAccessCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            textBoxAccessCode.Name = "textBoxAccessCode";
            textBoxAccessCode.Size = new System.Drawing.Size(507, 27);
            textBoxAccessCode.TabIndex = 1;
            // 
            // buttonVerifyCode
            // 
            buttonVerifyCode.Location = new System.Drawing.Point(523, 29);
            buttonVerifyCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            buttonVerifyCode.Name = "buttonVerifyCode";
            buttonVerifyCode.Size = new System.Drawing.Size(101, 27);
            buttonVerifyCode.TabIndex = 0;
            buttonVerifyCode.Text = "Verify code";
            buttonVerifyCode.UseVisualStyleBackColor = true;
            buttonVerifyCode.Click += ButtonVerifyCode_Click;
            // 
            // FormAleevaIntegrations
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(662, 487);
            Controls.Add(groupBoxAccessCode);
            Controls.Add(groupBoxAleevaStatus);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Aleeva integrations";
            HelpButtonClicked += FormAleevaIntegrations_HelpButtonClicked;
            FormClosing += FormAleevaIntegrations_FormClosing;
            groupBoxAleevaStatus.ResumeLayout(false);
            contextMenuStripInteract.ResumeLayout(false);
            groupBoxAccessCode.ResumeLayout(false);
            groupBoxAccessCode.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAleevaStatus;
        private System.Windows.Forms.GroupBox groupBoxAccessCode;
        private System.Windows.Forms.TextBox textBoxAccessCode;
        private System.Windows.Forms.Button buttonVerifyCode;
        private System.Windows.Forms.ListView listViewAleevaIntegrations;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.Button buttonAddAleevaIntegration;
    }
}