namespace Timee
{
    partial class TimeeMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeeMain));
            this.cmbLocations = new System.Windows.Forms.ComboBox();
            this.userConfigurationLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdWorkSummary = new System.Windows.Forms.DataGridView();
            this.userConfigurationProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userConfigurationSubprojectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userConfigurationTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeeDataSet = new Timee.DAL.TimeeDataSet();
            this.btnStart = new System.Windows.Forms.Button();
            this.exportToXlsButton = new System.Windows.Forms.Button();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.cmbSubProject = new System.Windows.Forms.ComboBox();
            this.cmbTask = new System.Windows.Forms.ComboBox();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnSubProject = new System.Windows.Forms.Button();
            this.btnTask = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblSubProject = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDataGridViewTextBoxColumn = new Timee.Controls.CalendarColumn.CalendarColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubProject = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLocations
            // 
            this.cmbLocations.DataSource = this.userConfigurationLocationBindingSource;
            this.cmbLocations.DisplayMember = "name";
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(644, 26);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(121, 21);
            this.cmbLocations.TabIndex = 0;
            // 
            // userConfigurationLocationBindingSource
            // 
            this.userConfigurationLocationBindingSource.DataSource = typeof(Timee.Models.UserConfigurationLocation);
            // 
            // grdWorkSummary
            // 
            this.grdWorkSummary.AllowDrop = true;
            this.grdWorkSummary.AllowUserToAddRows = false;
            this.grdWorkSummary.AllowUserToResizeRows = false;
            this.grdWorkSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkSummary.AutoGenerateColumns = false;
            this.grdWorkSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdWorkSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdWorkSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdWorkSummary.CausesValidation = false;
            this.grdWorkSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.Time,
            this.Project,
            this.SubProject,
            this.Task,
            this.Location,
            this.Comment,
            this.Remove});
            this.grdWorkSummary.DataMember = "TimeSheetTable";
            this.grdWorkSummary.DataSource = this.timeeDataSet;
            this.grdWorkSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdWorkSummary.Location = new System.Drawing.Point(13, 107);
            this.grdWorkSummary.Name = "grdWorkSummary";
            this.grdWorkSummary.Size = new System.Drawing.Size(880, 153);
            this.grdWorkSummary.TabIndex = 1;
            this.grdWorkSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWorkSummary_CellContentClick);
            this.grdWorkSummary.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdWorkSummary_CellValidating);
            this.grdWorkSummary.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdWorkSummary_EditingControlShowing);
            this.grdWorkSummary.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdWorkSummary_RowHeaderMouseDoubleClick);
            this.grdWorkSummary.DragDrop += new System.Windows.Forms.DragEventHandler(this.grdWorkSummary_DragDrop);
            this.grdWorkSummary.DragEnter += new System.Windows.Forms.DragEventHandler(this.grdWorkSummary_DragEnter);
            this.grdWorkSummary.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdWorkSummary_MouseMove);
            // 
            // userConfigurationProjectBindingSource
            // 
            this.userConfigurationProjectBindingSource.DataSource = typeof(Timee.Models.UserConfigurationProject);
            // 
            // userConfigurationSubprojectBindingSource
            // 
            this.userConfigurationSubprojectBindingSource.DataSource = typeof(Timee.Models.UserConfigurationSubproject);
            // 
            // userConfigurationTaskBindingSource
            // 
            this.userConfigurationTaskBindingSource.DataSource = typeof(Timee.Models.UserConfigurationTask);
            // 
            // timeeDataSet
            // 
            this.timeeDataSet.DataSetName = "TimeeDataSet";
            this.timeeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(813, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // exportToXlsButton
            // 
            this.exportToXlsButton.Location = new System.Drawing.Point(813, 265);
            this.exportToXlsButton.Name = "exportToXlsButton";
            this.exportToXlsButton.Size = new System.Drawing.Size(79, 26);
            this.exportToXlsButton.TabIndex = 3;
            this.exportToXlsButton.Text = "Export to *.xls";
            this.exportToXlsButton.UseVisualStyleBackColor = true;
            this.exportToXlsButton.Click += new System.EventHandler(this.exportToXlsButton_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DataSource = this.userConfigurationProjectBindingSource;
            this.cmbProject.DisplayMember = "name";
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(170, 26);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(121, 21);
            this.cmbProject.TabIndex = 4;
            // 
            // cmbSubProject
            // 
            this.cmbSubProject.DataSource = this.userConfigurationSubprojectBindingSource;
            this.cmbSubProject.DisplayMember = "name";
            this.cmbSubProject.FormattingEnabled = true;
            this.cmbSubProject.Location = new System.Drawing.Point(328, 26);
            this.cmbSubProject.Name = "cmbSubProject";
            this.cmbSubProject.Size = new System.Drawing.Size(121, 21);
            this.cmbSubProject.TabIndex = 5;
            // 
            // cmbTask
            // 
            this.cmbTask.DataSource = this.userConfigurationTaskBindingSource;
            this.cmbTask.DisplayMember = "name";
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(486, 26);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(121, 21);
            this.cmbTask.TabIndex = 6;
            // 
            // btnProject
            // 
            this.btnProject.Location = new System.Drawing.Point(297, 26);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(25, 21);
            this.btnProject.TabIndex = 9;
            this.btnProject.Text = "+";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnSubProject
            // 
            this.btnSubProject.Location = new System.Drawing.Point(455, 26);
            this.btnSubProject.Name = "btnSubProject";
            this.btnSubProject.Size = new System.Drawing.Size(25, 21);
            this.btnSubProject.TabIndex = 10;
            this.btnSubProject.Text = "+";
            this.btnSubProject.UseVisualStyleBackColor = true;
            this.btnSubProject.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(613, 26);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(25, 21);
            this.btnTask.TabIndex = 11;
            this.btnTask.Text = "+";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(771, 26);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(25, 21);
            this.btnLocation.TabIndex = 12;
            this.btnLocation.Text = "+";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(12, 53);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(753, 20);
            this.tbComment.TabIndex = 13;
            this.tbComment.Text = "Comment";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dpWorkDate
            // 
            this.dpWorkDate.Location = new System.Drawing.Point(13, 27);
            this.dpWorkDate.Name = "dpWorkDate";
            this.dpWorkDate.Size = new System.Drawing.Size(151, 20);
            this.dpWorkDate.TabIndex = 14;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 9);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Data";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(167, 9);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 16;
            this.lblProject.Text = "Project";
            // 
            // lblSubProject
            // 
            this.lblSubProject.AutoSize = true;
            this.lblSubProject.Location = new System.Drawing.Point(325, 9);
            this.lblSubProject.Name = "lblSubProject";
            this.lblSubProject.Size = new System.Drawing.Size(61, 13);
            this.lblSubProject.TabIndex = 17;
            this.lblSubProject.Text = "Sub-project";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(641, 9);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 18;
            this.lblLocation.Text = "Location";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(483, 9);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 19;
            this.lblTask.Text = "Task";
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(813, 53);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 20);
            this.btnPause.TabIndex = 20;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "[CTRL + X] to delete row.";
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.FillWeight = 99.78245F;
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Project
            // 
            this.Project.DataPropertyName = "Project";
            this.Project.DataSource = this.userConfigurationProjectBindingSource;
            this.Project.DisplayMember = "Name";
            this.Project.FillWeight = 99.78245F;
            this.Project.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Project.HeaderText = "Project";
            this.Project.Name = "Project";
            this.Project.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Project.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SubProject
            // 
            this.SubProject.DataPropertyName = "SubProject";
            this.SubProject.DataSource = this.userConfigurationSubprojectBindingSource;
            this.SubProject.DisplayMember = "Name";
            this.SubProject.FillWeight = 99.78245F;
            this.SubProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubProject.HeaderText = "SubProject";
            this.SubProject.Name = "SubProject";
            this.SubProject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SubProject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SubProject.ValueMember = "Name";
            // 
            // Task
            // 
            this.Task.DataPropertyName = "Task";
            this.Task.DataSource = this.userConfigurationTaskBindingSource;
            this.Task.DisplayMember = "Name";
            this.Task.FillWeight = 99.78245F;
            this.Task.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            this.Task.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Task.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Task.ValueMember = "Name";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.DataSource = this.userConfigurationLocationBindingSource;
            this.Location.DisplayMember = "Name";
            this.Location.FillWeight = 99.78245F;
            this.Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Location.ValueMember = "Name";
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.FillWeight = 99.78245F;
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
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
            // TimeeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSubProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dpWorkDate);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.btnTask);
            this.Controls.Add(this.btnSubProject);
            this.Controls.Add(this.btnProject);
            this.Controls.Add(this.cmbTask);
            this.Controls.Add(this.cmbSubProject);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.exportToXlsButton);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grdWorkSummary);
            this.Controls.Add(this.cmbLocations);
            this.Name = "TimeeMain";
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.Timee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocations;
        private System.Windows.Forms.DataGridView grdWorkSummary;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button exportToXlsButton;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.ComboBox cmbSubProject;
        private System.Windows.Forms.ComboBox cmbTask;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnSubProject;
        private System.Windows.Forms.Button btnTask;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.TextBox tbComment;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DateTimePicker dpWorkDate;
        private System.Windows.Forms.BindingSource userConfigurationProjectBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationSubprojectBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationLocationBindingSource;
        private System.Windows.Forms.BindingSource userConfigurationTaskBindingSource;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblSubProject;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblTask;
        private DAL.TimeeDataSet timeeDataSet;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label label1;
        private Controls.CalendarColumn.CalendarColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewComboBoxColumn Project;
        private System.Windows.Forms.DataGridViewComboBoxColumn SubProject;
        private System.Windows.Forms.DataGridViewComboBoxColumn Task;
        private System.Windows.Forms.DataGridViewComboBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
    }
}

