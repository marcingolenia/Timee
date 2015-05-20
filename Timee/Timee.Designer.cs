namespace Timee
{
    partial class Timee
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
            this.cbLocations = new System.Windows.Forms.ComboBox();
            this.userConfigurationLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdWorkSummary = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subProjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeeDataSet = new DAL.TimeeDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.userConfigurationProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subprojectcombobox = new System.Windows.Forms.ComboBox();
            this.userConfigurationSubprojectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taskcomboBox = new System.Windows.Forms.ComboBox();
            this.userConfigurationTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datecomboBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLocations
            // 
            this.cbLocations.DataSource = this.userConfigurationLocationBindingSource;
            this.cbLocations.DisplayMember = "name";
            this.cbLocations.FormattingEnabled = true;
            this.cbLocations.Location = new System.Drawing.Point(644, 11);
            this.cbLocations.Name = "cbLocations";
            this.cbLocations.Size = new System.Drawing.Size(121, 21);
            this.cbLocations.TabIndex = 0;
            // 
            // userConfigurationLocationBindingSource
            // 
            this.userConfigurationLocationBindingSource.DataSource = typeof(Models.UserConfigurationLocation);
            // 
            // grdWorkSummary
            // 
            this.grdWorkSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkSummary.AutoGenerateColumns = false;
            this.grdWorkSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Data,
            this.Project,
            this.SubProject,
            this.Task,
            this.Comment,
            this.Location,
            this.timeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.projectDataGridViewTextBoxColumn,
            this.subProjectDataGridViewTextBoxColumn,
            this.taskDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.grdWorkSummary.DataMember = "TimeSheetTable";
            this.grdWorkSummary.DataSource = this.timeeDataSetBindingSource;
            this.grdWorkSummary.Location = new System.Drawing.Point(13, 107);
            this.grdWorkSummary.Name = "grdWorkSummary";
            this.grdWorkSummary.Size = new System.Drawing.Size(785, 153);
            this.grdWorkSummary.TabIndex = 1;
            // 
            // Time
            // 
            this.Time.HeaderText = "Czas";
            this.Time.Name = "Time";
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Project
            // 
            this.Project.HeaderText = "Projekt";
            this.Project.Name = "Project";
            // 
            // SubProject
            // 
            this.SubProject.HeaderText = "Sub-project";
            this.SubProject.Name = "SubProject";
            // 
            // Task
            // 
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Komentarz";
            this.Comment.Name = "Comment";
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            // 
            // projectDataGridViewTextBoxColumn
            // 
            this.projectDataGridViewTextBoxColumn.DataPropertyName = "Project";
            this.projectDataGridViewTextBoxColumn.HeaderText = "Project";
            this.projectDataGridViewTextBoxColumn.Name = "projectDataGridViewTextBoxColumn";
            // 
            // subProjectDataGridViewTextBoxColumn
            // 
            this.subProjectDataGridViewTextBoxColumn.DataPropertyName = "SubProject";
            this.subProjectDataGridViewTextBoxColumn.HeaderText = "SubProject";
            this.subProjectDataGridViewTextBoxColumn.Name = "subProjectDataGridViewTextBoxColumn";
            // 
            // taskDataGridViewTextBoxColumn
            // 
            this.taskDataGridViewTextBoxColumn.DataPropertyName = "Task";
            this.taskDataGridViewTextBoxColumn.HeaderText = "Task";
            this.taskDataGridViewTextBoxColumn.Name = "taskDataGridViewTextBoxColumn";
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(253, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(281, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cmbProject
            // 
            this.cmbProject.DataSource = this.userConfigurationProjectBindingSource;
            this.cmbProject.DisplayMember = "name";
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(171, 13);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(121, 21);
            this.cmbProject.TabIndex = 4;
            // 
            // userConfigurationProjectBindingSource
            // 
            this.userConfigurationProjectBindingSource.DataSource = typeof(Models.UserConfigurationProject);
            // 
            // subprojectcombobox
            // 
            this.subprojectcombobox.DataSource = this.userConfigurationSubprojectBindingSource;
            this.subprojectcombobox.DisplayMember = "name";
            this.subprojectcombobox.FormattingEnabled = true;
            this.subprojectcombobox.Location = new System.Drawing.Point(328, 12);
            this.subprojectcombobox.Name = "subprojectcombobox";
            this.subprojectcombobox.Size = new System.Drawing.Size(121, 21);
            this.subprojectcombobox.TabIndex = 5;
            // 
            // userConfigurationSubprojectBindingSource
            // 
            this.userConfigurationSubprojectBindingSource.DataSource = typeof(Models.UserConfigurationSubproject);
            // 
            // taskcomboBox
            // 
            this.taskcomboBox.DataSource = this.userConfigurationTaskBindingSource;
            this.taskcomboBox.DisplayMember = "name";
            this.taskcomboBox.FormattingEnabled = true;
            this.taskcomboBox.Location = new System.Drawing.Point(486, 12);
            this.taskcomboBox.Name = "taskcomboBox";
            this.taskcomboBox.Size = new System.Drawing.Size(121, 21);
            this.taskcomboBox.TabIndex = 6;
            // 
            // userConfigurationTaskBindingSource
            // 
            this.userConfigurationTaskBindingSource.DataSource = typeof(Models.UserConfigurationTask);
            // 
            // datecomboBox
            // 
            this.datecomboBox.FormattingEnabled = true;
            this.datecomboBox.Location = new System.Drawing.Point(13, 14);
            this.datecomboBox.Name = "datecomboBox";
            this.datecomboBox.Size = new System.Drawing.Size(121, 21);
            this.datecomboBox.TabIndex = 7;
            this.datecomboBox.Text = "date";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 21);
            this.button3.TabIndex = 8;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(298, 13);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(25, 21);
            this.btnAddProject.TabIndex = 9;
            this.btnAddProject.Text = "+";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(455, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 21);
            this.button5.TabIndex = 10;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(613, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(25, 21);
            this.button6.TabIndex = 11;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(771, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(25, 21);
            this.button7.TabIndex = 12;
            this.button7.Text = "+";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(12, 74);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(764, 20);
            this.tbComment.TabIndex = 13;
            this.tbComment.Text = "Comment";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Timee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 303);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.datecomboBox);
            this.Controls.Add(this.taskcomboBox);
            this.Controls.Add(this.subprojectcombobox);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdWorkSummary);
            this.Controls.Add(this.cbLocations);
            this.Name = "Timee";
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.Timer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocations;
        private System.Windows.Forms.DataGridView grdWorkSummary;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.ComboBox subprojectcombobox;
        private System.Windows.Forms.ComboBox taskcomboBox;
        private System.Windows.Forms.ComboBox datecomboBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Project;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.BindingSource userConfigurationLocationBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationProjectBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationSubprojectBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationTaskBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subProjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource timeeDataSetBindingSource;
        private DAL.TimeeDataSet timeeDataSet;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

