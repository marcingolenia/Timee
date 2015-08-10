namespace Timee.Dialogs
{
    partial class HotKeysDialog
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
            this.grdHotKeys = new System.Windows.Forms.DataGridView();
            this.btnOk = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifierKeys = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdHotKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // grdHotKeys
            // 
            this.grdHotKeys.AllowUserToAddRows = false;
            this.grdHotKeys.AllowUserToDeleteRows = false;
            this.grdHotKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHotKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.ModifierKeys,
            this.KeyName});
            this.grdHotKeys.Location = new System.Drawing.Point(12, 12);
            this.grdHotKeys.Name = "grdHotKeys";
            this.grdHotKeys.Size = new System.Drawing.Size(343, 282);
            this.grdHotKeys.TabIndex = 0;
            this.grdHotKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdHotKeys_KeyDown);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(305, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Modifier Key";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            // 
            // ModifierKeys
            // 
            this.ModifierKeys.HeaderText = "Modifier Keys";
            this.ModifierKeys.Items.AddRange(new object[] {
            "Alt",
            "Control",
            "Shift",
            "Win"});
            this.ModifierKeys.Name = "ModifierKeys";
            // 
            // KeyName
            // 
            this.KeyName.HeaderText = "KeyName";
            this.KeyName.Name = "KeyName";
            this.KeyName.ReadOnly = true;
            // 
            // HotKeysDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 335);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grdHotKeys);
            this.Name = "HotKeysDialog";
            this.Text = "HotKeysDialog";
            this.Load += new System.EventHandler(this.HotKeysDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHotKeys)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.DataGridView grdHotKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.DataGridViewComboBoxColumn ModifierKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyName;
    }
}