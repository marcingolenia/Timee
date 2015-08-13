namespace Timee.Dialogs
{
    partial class PredefinedTasksDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PredefinedTasksDialog));
            this.grdPredefinedSummary = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewImageColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.timeeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeeDataSet = new Timee.DAL.TimeeDataSet();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPredefinedSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPredefinedSummary
            // 
            this.grdPredefinedSummary.AllowDrop = true;
            this.grdPredefinedSummary.AllowUserToAddRows = false;
            this.grdPredefinedSummary.AllowUserToOrderColumns = true;
            this.grdPredefinedSummary.AllowUserToResizeRows = false;
            this.grdPredefinedSummary.AutoGenerateColumns = false;
            this.grdPredefinedSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPredefinedSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdPredefinedSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPredefinedSummary.CausesValidation = false;
            this.grdPredefinedSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPredefinedSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Project,
            this.SubProject,
            this.Task,
            this.Location,
            this.Comment,
            this.Time,
            this.Add,
            this.Remove});
            this.grdPredefinedSummary.DataMember = "TimeSheetTable";
            this.grdPredefinedSummary.DataSource = this.timeeDataSetBindingSource;
            this.grdPredefinedSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdPredefinedSummary.Location = new System.Drawing.Point(1, 53);
            this.grdPredefinedSummary.Name = "grdPredefinedSummary";
            this.grdPredefinedSummary.Size = new System.Drawing.Size(880, 149);
            this.grdPredefinedSummary.TabIndex = 2;
            this.grdPredefinedSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPredefinedSummary_CellContentClick);
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Project
            // 
            this.Project.DataPropertyName = "Project";
            this.Project.HeaderText = "Project";
            this.Project.Name = "Project";
            // 
            // SubProject
            // 
            this.SubProject.DataPropertyName = "SubProject";
            this.SubProject.HeaderText = "SubProject";
            this.SubProject.Name = "SubProject";
            // 
            // Task
            // 
            this.Task.DataPropertyName = "Task";
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Add.FillWeight = 25F;
            this.Add.HeaderText = "";
            this.Add.Image = global::Timee.Properties.Resources._new;
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
            this.Remove.Image = global::Timee.Properties.Resources.remove;
            this.Remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.Width = 25;
            // 
            // timeeDataSetBindingSource
            // 
            this.timeeDataSetBindingSource.DataSource = this.timeeDataSet;
            this.timeeDataSetBindingSource.Position = 0;
            // 
            // timeeDataSet
            // 
            this.timeeDataSet.DataSetName = "TimeeDataSet";
            this.timeeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn1.FillWeight = 88.52315F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 789;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Project";
            this.dataGridViewTextBoxColumn2.HeaderText = "Project";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 112;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SubProject";
            this.dataGridViewTextBoxColumn3.HeaderText = "SubProject";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 113;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Task";
            this.dataGridViewTextBoxColumn4.HeaderText = "Task";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 113;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn5.HeaderText = "Location";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 113;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn6.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 112;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn7.HeaderText = "Time";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 113;
            // 
            // PredefinedTasksDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 261);
            this.Controls.Add(this.grdPredefinedSummary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PredefinedTasksDialog";
            this.Text = "Predefined Tasks";
            this.Load += new System.EventHandler(this.PredefinedTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPredefinedSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPredefinedSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.BindingSource timeeDataSetBindingSource;
        private DAL.TimeeDataSet timeeDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewImageColumn Add;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
    }
}