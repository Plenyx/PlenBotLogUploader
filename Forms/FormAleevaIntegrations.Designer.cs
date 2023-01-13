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
            this.components = new System.ComponentModel.Container();
            this.groupBoxAleevaStatus = new System.Windows.Forms.GroupBox();
            this.buttonAddAleevaIntegration = new System.Windows.Forms.Button();
            this.listViewAleevaIntegrations = new System.Windows.Forms.ListView();
            this.contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorOne = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAccessCode = new System.Windows.Forms.GroupBox();
            this.textBoxAccessCode = new System.Windows.Forms.TextBox();
            this.buttonGetBearerFromAccess = new System.Windows.Forms.Button();
            this.groupBoxAleevaStatus.SuspendLayout();
            this.contextMenuStripInteract.SuspendLayout();
            this.groupBoxAccessCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAleevaStatus
            // 
            this.groupBoxAleevaStatus.Controls.Add(this.buttonAddAleevaIntegration);
            this.groupBoxAleevaStatus.Controls.Add(this.listViewAleevaIntegrations);
            this.groupBoxAleevaStatus.Location = new System.Drawing.Point(15, 96);
            this.groupBoxAleevaStatus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxAleevaStatus.Name = "groupBoxAleevaStatus";
            this.groupBoxAleevaStatus.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxAleevaStatus.Size = new System.Drawing.Size(632, 378);
            this.groupBoxAleevaStatus.TabIndex = 2;
            this.groupBoxAleevaStatus.TabStop = false;
            this.groupBoxAleevaStatus.Text = "Status: Not authorised";
            // 
            // buttonAddAleevaIntegration
            // 
            this.buttonAddAleevaIntegration.Location = new System.Drawing.Point(408, 338);
            this.buttonAddAleevaIntegration.Name = "buttonAddAleevaIntegration";
            this.buttonAddAleevaIntegration.Size = new System.Drawing.Size(216, 29);
            this.buttonAddAleevaIntegration.TabIndex = 2;
            this.buttonAddAleevaIntegration.Text = "Add a new Aleeva integration";
            this.buttonAddAleevaIntegration.UseVisualStyleBackColor = true;
            this.buttonAddAleevaIntegration.Click += new System.EventHandler(this.ButtonAddAleevaIntegration_Click);
            // 
            // listViewAleevaIntegrations
            // 
            this.listViewAleevaIntegrations.CheckBoxes = true;
            this.listViewAleevaIntegrations.ContextMenuStrip = this.contextMenuStripInteract;
            this.listViewAleevaIntegrations.Location = new System.Drawing.Point(9, 24);
            this.listViewAleevaIntegrations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewAleevaIntegrations.MultiSelect = false;
            this.listViewAleevaIntegrations.Name = "listViewAleevaIntegrations";
            this.listViewAleevaIntegrations.Size = new System.Drawing.Size(615, 306);
            this.listViewAleevaIntegrations.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewAleevaIntegrations.TabIndex = 1;
            this.listViewAleevaIntegrations.UseCompatibleStateImageBehavior = false;
            this.listViewAleevaIntegrations.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewAleevaIntegrations_ItemChecked);
            // 
            // contextMenuStripInteract
            // 
            this.contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete,
            this.toolStripSeparatorOne,
            this.toolStripMenuItemAdd});
            this.contextMenuStripInteract.Name = "contextMenuStripInteract";
            this.contextMenuStripInteract.Size = new System.Drawing.Size(333, 82);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(332, 24);
            this.toolStripMenuItemEdit.Text = "Edit the selected Aleeva integration";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(332, 24);
            this.toolStripMenuItemDelete.Text = "Delete the selected Aleeva integration";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripSeparatorOne
            // 
            this.toolStripSeparatorOne.Name = "toolStripSeparatorOne";
            this.toolStripSeparatorOne.Size = new System.Drawing.Size(329, 6);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(332, 24);
            this.toolStripMenuItemAdd.Text = "Add a new Aleeva integration";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // groupBoxAccessCode
            // 
            this.groupBoxAccessCode.Controls.Add(this.textBoxAccessCode);
            this.groupBoxAccessCode.Controls.Add(this.buttonGetBearerFromAccess);
            this.groupBoxAccessCode.Location = new System.Drawing.Point(15, 16);
            this.groupBoxAccessCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxAccessCode.Name = "groupBoxAccessCode";
            this.groupBoxAccessCode.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBoxAccessCode.Size = new System.Drawing.Size(632, 72);
            this.groupBoxAccessCode.TabIndex = 0;
            this.groupBoxAccessCode.TabStop = false;
            this.groupBoxAccessCode.Text = "Authorise with Aleeva using a generated access code from her";
            // 
            // textBoxAccessCode
            // 
            this.textBoxAccessCode.Location = new System.Drawing.Point(8, 29);
            this.textBoxAccessCode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxAccessCode.Name = "textBoxAccessCode";
            this.textBoxAccessCode.Size = new System.Drawing.Size(507, 27);
            this.textBoxAccessCode.TabIndex = 1;
            // 
            // buttonGetBearerFromAccess
            // 
            this.buttonGetBearerFromAccess.Location = new System.Drawing.Point(523, 27);
            this.buttonGetBearerFromAccess.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonGetBearerFromAccess.Name = "buttonGetBearerFromAccess";
            this.buttonGetBearerFromAccess.Size = new System.Drawing.Size(101, 36);
            this.buttonGetBearerFromAccess.TabIndex = 0;
            this.buttonGetBearerFromAccess.Text = "Authorise";
            this.buttonGetBearerFromAccess.UseVisualStyleBackColor = true;
            this.buttonGetBearerFromAccess.Click += new System.EventHandler(this.ButtonGetBearerFromAccess_Click);
            // 
            // FormAleevaIntegrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 487);
            this.Controls.Add(this.groupBoxAccessCode);
            this.Controls.Add(this.groupBoxAleevaStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAleevaIntegrations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aleeva integrations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAleevaIntegrations_FormClosing);
            this.groupBoxAleevaStatus.ResumeLayout(false);
            this.contextMenuStripInteract.ResumeLayout(false);
            this.groupBoxAccessCode.ResumeLayout(false);
            this.groupBoxAccessCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAleevaStatus;
        private System.Windows.Forms.GroupBox groupBoxAccessCode;
        private System.Windows.Forms.TextBox textBoxAccessCode;
        private System.Windows.Forms.Button buttonGetBearerFromAccess;
        internal System.Windows.Forms.ListView listViewAleevaIntegrations;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorOne;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.Button buttonAddAleevaIntegration;
    }
}