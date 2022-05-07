namespace PlenBotLogUploader
{
    partial class FormEditTeamCondition
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
            this.groupBoxConditionVisual = new System.Windows.Forms.GroupBox();
            this.textBoxConditionVisual = new System.Windows.Forms.TextBox();
            this.groupBoxConditionDefinition = new System.Windows.Forms.GroupBox();
            this.groupBoxSubConditions = new System.Windows.Forms.GroupBox();
            this.buttonAddSubCondition = new System.Windows.Forms.Button();
            this.listBoxSubConditions = new System.Windows.Forms.ListBox();
            this.contextMenuStripInteract = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxLimiter = new System.Windows.Forms.GroupBox();
            this.radioButtonLimiterOR = new System.Windows.Forms.RadioButton();
            this.radioButtonLimiterAND = new System.Windows.Forms.RadioButton();
            this.radioButtonLimiterCommanderName = new System.Windows.Forms.RadioButton();
            this.radioButtonLimiterExcept = new System.Windows.Forms.RadioButton();
            this.radioButtonLimiterExact = new System.Windows.Forms.RadioButton();
            this.textBoxLimiterValue = new System.Windows.Forms.TextBox();
            this.radioButtonLimiterAtLeast = new System.Windows.Forms.RadioButton();
            this.groupBoxAccountNames = new System.Windows.Forms.GroupBox();
            this.textBoxAccountNames = new System.Windows.Forms.TextBox();
            this.groupBoxConditionDescription = new System.Windows.Forms.GroupBox();
            this.textBoxConditionDescription = new System.Windows.Forms.TextBox();
            this.groupBoxConditionVisual.SuspendLayout();
            this.groupBoxConditionDefinition.SuspendLayout();
            this.groupBoxSubConditions.SuspendLayout();
            this.contextMenuStripInteract.SuspendLayout();
            this.groupBoxLimiter.SuspendLayout();
            this.groupBoxAccountNames.SuspendLayout();
            this.groupBoxConditionDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConditionVisual
            // 
            this.groupBoxConditionVisual.Controls.Add(this.textBoxConditionVisual);
            this.groupBoxConditionVisual.Location = new System.Drawing.Point(404, 13);
            this.groupBoxConditionVisual.Name = "groupBoxConditionVisual";
            this.groupBoxConditionVisual.Size = new System.Drawing.Size(507, 634);
            this.groupBoxConditionVisual.TabIndex = 8;
            this.groupBoxConditionVisual.TabStop = false;
            this.groupBoxConditionVisual.Text = "Visualisation of the conditions";
            // 
            // textBoxConditionVisual
            // 
            this.textBoxConditionVisual.Location = new System.Drawing.Point(6, 23);
            this.textBoxConditionVisual.MaxLength = 999999;
            this.textBoxConditionVisual.Multiline = true;
            this.textBoxConditionVisual.Name = "textBoxConditionVisual";
            this.textBoxConditionVisual.Size = new System.Drawing.Size(495, 596);
            this.textBoxConditionVisual.TabIndex = 5;
            // 
            // groupBoxConditionDefinition
            // 
            this.groupBoxConditionDefinition.Controls.Add(this.groupBoxSubConditions);
            this.groupBoxConditionDefinition.Controls.Add(this.groupBoxLimiter);
            this.groupBoxConditionDefinition.Controls.Add(this.groupBoxAccountNames);
            this.groupBoxConditionDefinition.Location = new System.Drawing.Point(13, 77);
            this.groupBoxConditionDefinition.Name = "groupBoxConditionDefinition";
            this.groupBoxConditionDefinition.Size = new System.Drawing.Size(384, 570);
            this.groupBoxConditionDefinition.TabIndex = 7;
            this.groupBoxConditionDefinition.TabStop = false;
            this.groupBoxConditionDefinition.Text = "Condition definition";
            // 
            // groupBoxSubConditions
            // 
            this.groupBoxSubConditions.Controls.Add(this.buttonAddSubCondition);
            this.groupBoxSubConditions.Controls.Add(this.listBoxSubConditions);
            this.groupBoxSubConditions.Location = new System.Drawing.Point(7, 257);
            this.groupBoxSubConditions.Name = "groupBoxSubConditions";
            this.groupBoxSubConditions.Size = new System.Drawing.Size(368, 306);
            this.groupBoxSubConditions.TabIndex = 4;
            this.groupBoxSubConditions.TabStop = false;
            this.groupBoxSubConditions.Text = "Subconditions";
            // 
            // buttonAddSubCondition
            // 
            this.buttonAddSubCondition.Location = new System.Drawing.Point(208, 271);
            this.buttonAddSubCondition.Name = "buttonAddSubCondition";
            this.buttonAddSubCondition.Size = new System.Drawing.Size(151, 25);
            this.buttonAddSubCondition.TabIndex = 1;
            this.buttonAddSubCondition.Text = "Add new subcondition";
            this.buttonAddSubCondition.UseVisualStyleBackColor = true;
            this.buttonAddSubCondition.Click += new System.EventHandler(this.ButtonAddSubCondition_Click);
            // 
            // listBoxSubConditions
            // 
            this.listBoxSubConditions.ContextMenuStrip = this.contextMenuStripInteract;
            this.listBoxSubConditions.FormattingEnabled = true;
            this.listBoxSubConditions.ItemHeight = 16;
            this.listBoxSubConditions.Location = new System.Drawing.Point(8, 23);
            this.listBoxSubConditions.Name = "listBoxSubConditions";
            this.listBoxSubConditions.Size = new System.Drawing.Size(351, 244);
            this.listBoxSubConditions.TabIndex = 0;
            this.listBoxSubConditions.DoubleClick += new System.EventHandler(this.ListBoxSubConditions_DoubleClick);
            // 
            // contextMenuStripInteract
            // 
            this.contextMenuStripInteract.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripInteract.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemDelete,
            this.toolStripSeparator1,
            this.toolStripMenuItemAdd});
            this.contextMenuStripInteract.Name = "contextMenuStripInteract";
            this.contextMenuStripInteract.Size = new System.Drawing.Size(249, 82);
            this.contextMenuStripInteract.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripInteract_Opening);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(248, 24);
            this.toolStripMenuItemEdit.Text = "Edit selected condition";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.ToolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(248, 24);
            this.toolStripMenuItemDelete.Text = "Delete selected condition";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // toolStripMenuItemAdd
            // 
            this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
            this.toolStripMenuItemAdd.Size = new System.Drawing.Size(248, 24);
            this.toolStripMenuItemAdd.Text = "Add a condition";
            this.toolStripMenuItemAdd.Click += new System.EventHandler(this.ToolStripMenuItemAdd_Click);
            // 
            // groupBoxLimiter
            // 
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterOR);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterAND);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterCommanderName);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterExcept);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterExact);
            this.groupBoxLimiter.Controls.Add(this.textBoxLimiterValue);
            this.groupBoxLimiter.Controls.Add(this.radioButtonLimiterAtLeast);
            this.groupBoxLimiter.Location = new System.Drawing.Point(7, 22);
            this.groupBoxLimiter.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLimiter.Name = "groupBoxLimiter";
            this.groupBoxLimiter.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLimiter.Size = new System.Drawing.Size(369, 189);
            this.groupBoxLimiter.TabIndex = 1;
            this.groupBoxLimiter.TabStop = false;
            this.groupBoxLimiter.Text = "Limiter settings";
            // 
            // radioButtonLimiterOR
            // 
            this.radioButtonLimiterOR.AutoSize = true;
            this.radioButtonLimiterOR.Location = new System.Drawing.Point(8, 159);
            this.radioButtonLimiterOR.Name = "radioButtonLimiterOR";
            this.radioButtonLimiterOR.Size = new System.Drawing.Size(48, 20);
            this.radioButtonLimiterOR.TabIndex = 6;
            this.radioButtonLimiterOR.TabStop = true;
            this.radioButtonLimiterOR.Text = "OR";
            this.radioButtonLimiterOR.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterAND
            // 
            this.radioButtonLimiterAND.AutoSize = true;
            this.radioButtonLimiterAND.Location = new System.Drawing.Point(8, 133);
            this.radioButtonLimiterAND.Name = "radioButtonLimiterAND";
            this.radioButtonLimiterAND.Size = new System.Drawing.Size(57, 20);
            this.radioButtonLimiterAND.TabIndex = 5;
            this.radioButtonLimiterAND.TabStop = true;
            this.radioButtonLimiterAND.Text = "AND";
            this.radioButtonLimiterAND.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterCommanderName
            // 
            this.radioButtonLimiterCommanderName.AutoSize = true;
            this.radioButtonLimiterCommanderName.Location = new System.Drawing.Point(8, 107);
            this.radioButtonLimiterCommanderName.Name = "radioButtonLimiterCommanderName";
            this.radioButtonLimiterCommanderName.Size = new System.Drawing.Size(203, 20);
            this.radioButtonLimiterCommanderName.TabIndex = 4;
            this.radioButtonLimiterCommanderName.TabStop = true;
            this.radioButtonLimiterCommanderName.Text = "Any of the listed commanders";
            this.radioButtonLimiterCommanderName.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterExcept
            // 
            this.radioButtonLimiterExcept.AutoSize = true;
            this.radioButtonLimiterExcept.Location = new System.Drawing.Point(8, 80);
            this.radioButtonLimiterExcept.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLimiterExcept.Name = "radioButtonLimiterExcept";
            this.radioButtonLimiterExcept.Size = new System.Drawing.Size(152, 20);
            this.radioButtonLimiterExcept.TabIndex = 3;
            this.radioButtonLimiterExcept.TabStop = true;
            this.radioButtonLimiterExcept.Text = "Except listed players";
            this.radioButtonLimiterExcept.UseVisualStyleBackColor = true;
            // 
            // radioButtonLimiterExact
            // 
            this.radioButtonLimiterExact.AutoSize = true;
            this.radioButtonLimiterExact.Location = new System.Drawing.Point(8, 52);
            this.radioButtonLimiterExact.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLimiterExact.Name = "radioButtonLimiterExact";
            this.radioButtonLimiterExact.Size = new System.Drawing.Size(128, 20);
            this.radioButtonLimiterExact.TabIndex = 2;
            this.radioButtonLimiterExact.TabStop = true;
            this.radioButtonLimiterExact.Text = "Exactly x players";
            this.radioButtonLimiterExact.UseVisualStyleBackColor = true;
            // 
            // textBoxLimiterValue
            // 
            this.textBoxLimiterValue.Location = new System.Drawing.Point(155, 34);
            this.textBoxLimiterValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLimiterValue.Name = "textBoxLimiterValue";
            this.textBoxLimiterValue.Size = new System.Drawing.Size(204, 22);
            this.textBoxLimiterValue.TabIndex = 1;
            this.textBoxLimiterValue.Text = "1";
            this.textBoxLimiterValue.TextChanged += new System.EventHandler(this.TextBoxLimiterValue_TextChanged);
            // 
            // radioButtonLimiterAtLeast
            // 
            this.radioButtonLimiterAtLeast.AutoSize = true;
            this.radioButtonLimiterAtLeast.Checked = true;
            this.radioButtonLimiterAtLeast.Location = new System.Drawing.Point(8, 23);
            this.radioButtonLimiterAtLeast.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonLimiterAtLeast.Name = "radioButtonLimiterAtLeast";
            this.radioButtonLimiterAtLeast.Size = new System.Drawing.Size(129, 20);
            this.radioButtonLimiterAtLeast.TabIndex = 0;
            this.radioButtonLimiterAtLeast.TabStop = true;
            this.radioButtonLimiterAtLeast.Text = "At least x players";
            this.radioButtonLimiterAtLeast.UseVisualStyleBackColor = true;
            // 
            // groupBoxAccountNames
            // 
            this.groupBoxAccountNames.Controls.Add(this.textBoxAccountNames);
            this.groupBoxAccountNames.Location = new System.Drawing.Point(7, 257);
            this.groupBoxAccountNames.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAccountNames.Name = "groupBoxAccountNames";
            this.groupBoxAccountNames.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAccountNames.Size = new System.Drawing.Size(368, 306);
            this.groupBoxAccountNames.TabIndex = 3;
            this.groupBoxAccountNames.TabStop = false;
            this.groupBoxAccountNames.Text = "Account names (separate by new line)";
            // 
            // textBoxAccountNames
            // 
            this.textBoxAccountNames.Location = new System.Drawing.Point(8, 23);
            this.textBoxAccountNames.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAccountNames.Multiline = true;
            this.textBoxAccountNames.Name = "textBoxAccountNames";
            this.textBoxAccountNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAccountNames.Size = new System.Drawing.Size(351, 275);
            this.textBoxAccountNames.TabIndex = 2;
            // 
            // groupBoxConditionDescription
            // 
            this.groupBoxConditionDescription.Controls.Add(this.textBoxConditionDescription);
            this.groupBoxConditionDescription.Location = new System.Drawing.Point(13, 13);
            this.groupBoxConditionDescription.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxConditionDescription.Name = "groupBoxConditionDescription";
            this.groupBoxConditionDescription.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxConditionDescription.Size = new System.Drawing.Size(384, 57);
            this.groupBoxConditionDescription.TabIndex = 9;
            this.groupBoxConditionDescription.TabStop = false;
            this.groupBoxConditionDescription.Text = "Condition description";
            // 
            // textBoxConditionDescription
            // 
            this.textBoxConditionDescription.Location = new System.Drawing.Point(8, 23);
            this.textBoxConditionDescription.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConditionDescription.Name = "textBoxConditionDescription";
            this.textBoxConditionDescription.Size = new System.Drawing.Size(368, 22);
            this.textBoxConditionDescription.TabIndex = 1;
            this.textBoxConditionDescription.TextChanged += new System.EventHandler(this.TextBoxConditionDescription_TextChanged);
            // 
            // FormEditTeamCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(924, 659);
            this.Controls.Add(this.groupBoxConditionDescription);
            this.Controls.Add(this.groupBoxConditionVisual);
            this.Controls.Add(this.groupBoxConditionDefinition);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormEditTeamCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEditTeamCondition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditTeamCondition_FormClosing);
            this.groupBoxConditionVisual.ResumeLayout(false);
            this.groupBoxConditionVisual.PerformLayout();
            this.groupBoxConditionDefinition.ResumeLayout(false);
            this.groupBoxSubConditions.ResumeLayout(false);
            this.contextMenuStripInteract.ResumeLayout(false);
            this.groupBoxLimiter.ResumeLayout(false);
            this.groupBoxLimiter.PerformLayout();
            this.groupBoxAccountNames.ResumeLayout(false);
            this.groupBoxAccountNames.PerformLayout();
            this.groupBoxConditionDescription.ResumeLayout(false);
            this.groupBoxConditionDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConditionVisual;
        private System.Windows.Forms.TextBox textBoxConditionVisual;
        private System.Windows.Forms.GroupBox groupBoxConditionDefinition;
        private System.Windows.Forms.GroupBox groupBoxLimiter;
        private System.Windows.Forms.RadioButton radioButtonLimiterOR;
        private System.Windows.Forms.RadioButton radioButtonLimiterAND;
        private System.Windows.Forms.RadioButton radioButtonLimiterCommanderName;
        private System.Windows.Forms.RadioButton radioButtonLimiterExcept;
        private System.Windows.Forms.RadioButton radioButtonLimiterExact;
        private System.Windows.Forms.TextBox textBoxLimiterValue;
        private System.Windows.Forms.RadioButton radioButtonLimiterAtLeast;
        private System.Windows.Forms.GroupBox groupBoxAccountNames;
        private System.Windows.Forms.TextBox textBoxAccountNames;
        private System.Windows.Forms.GroupBox groupBoxConditionDescription;
        private System.Windows.Forms.TextBox textBoxConditionDescription;
        private System.Windows.Forms.GroupBox groupBoxSubConditions;
        private System.Windows.Forms.Button buttonAddSubCondition;
        private System.Windows.Forms.ListBox listBoxSubConditions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripInteract;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
    }
}