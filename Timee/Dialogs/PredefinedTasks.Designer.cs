namespace Timee.Dialogs
{
    partial class PredefinedTasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredefinedTasks));
            this.grdPredefinedSummary = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewImageColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPredefinedSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPredefinedSummary
            // 
            this.grdPredefinedSummary.AllowDrop = true;
            this.grdPredefinedSummary.AllowUserToAddRows = false;
            this.grdPredefinedSummary.AllowUserToOrderColumns = true;
            this.grdPredefinedSummary.AllowUserToResizeRows = false;
            this.grdPredefinedSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPredefinedSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdPredefinedSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPredefinedSummary.CausesValidation = false;
            this.grdPredefinedSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPredefinedSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Add,
            this.Remove});
            this.grdPredefinedSummary.DataMember = "TimeSheetTable";
            this.grdPredefinedSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPredefinedSummary.Location = new System.Drawing.Point(1, 53);
            this.grdPredefinedSummary.Name = "grdPredefinedSummary";
            this.grdPredefinedSummary.Size = new System.Drawing.Size(880, 149);
            this.grdPredefinedSummary.TabIndex = 2;
            this.grdPredefinedSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPredefinedSummary_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn1.FillWeight = 88.52315F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 789;
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Add.FillWeight = 25F;
            this.Add.HeaderText = "";
            this.Add.Image = global::Timee.Properties.Resources.save;
            this.Add.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.Width = 25;
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Remove.FillWeight = 25F;
            this.Remove.HeaderText = "";
            this.Remove.Image = ((System.Drawing.Image)(resources.GetObject("Remove.Image")));
            this.Remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.Width = 25;
            // 
            // PredefinedTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 261);
            this.Controls.Add(this.grdPredefinedSummary);
            this.Name = "PredefinedTasks";
            this.Text = "PredefinedTasks";
            this.Load += new System.EventHandler(this.PredefinedTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPredefinedSummary)).EndInit();
            this.ResumeLayout(false);


        }

        #endregion

        private System.Windows.Forms.DataGridView grdPredefinedSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewImageColumn Add;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
    }
}