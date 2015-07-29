using System;
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
            this.grdWorkSummary = new Timee.Controls.TimeeGrid();
            this.userConfigurationProjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userConfigurationSubprojectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userConfigurationTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeeDataSet = new Timee.DAL.TimeeDataSet();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuTimee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countdownAlertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlugins = new System.Windows.Forms.ToolStripMenuItem();
            this.lGBSExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcelExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExcell = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTimeSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarColumn1 = new Timee.Controls.CalendarColumn.CalendarColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTimeSummary1 = new System.Windows.Forms.Label();
            this.lblTimeSummaryResult = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblAlarmValue = new System.Windows.Forms.Label();
            this.Date = new Timee.Controls.CalendarColumn.CalendarColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Project = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SubProject = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Task = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Save = new System.Windows.Forms.DataGridViewImageColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).BeginInit();
            this.mnu.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLocations
            // 
            this.cmbLocations.DataSource = this.userConfigurationLocationBindingSource;
            this.cmbLocations.DisplayMember = "name";
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(644, 49);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(121, 21);
            this.cmbLocations.TabIndex = 0;
            this.cmbLocations.Validating += new System.ComponentModel.CancelEventHandler(this.cmbLocations_Validating);
            // 
            // userConfigurationLocationBindingSource
            // 
            this.userConfigurationLocationBindingSource.DataSource = typeof(Timee.Models.UserConfigurationLocation);
            // 
            // grdWorkSummary
            // 
            this.grdWorkSummary.AllowDrop = true;
            this.grdWorkSummary.AllowUserToAddRows = false;
            this.grdWorkSummary.AllowUserToOrderColumns = true;
            this.grdWorkSummary.AllowUserToResizeRows = false;
            this.grdWorkSummary.AutoGenerateColumns = false;
            this.grdWorkSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdWorkSummary.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.grdWorkSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdWorkSummary.CausesValidation = false;
            this.grdWorkSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Time,
            this.Project,
            this.SubProject,
            this.Task,
            this.Comment,
            this.Location,
            this.Save,
            this.Remove});
            this.grdWorkSummary.DataMember = "TimeSheetTable";
            this.grdWorkSummary.DataSource = this.timeeDataSet;
            this.grdWorkSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdWorkSummary.Location = new System.Drawing.Point(13, 115);
            this.grdWorkSummary.Name = "grdWorkSummary";
            this.grdWorkSummary.Size = new System.Drawing.Size(880, 149);
            this.grdWorkSummary.TabIndex = 1;
            this.grdWorkSummary.btnDeleteRowClicked += new System.EventHandler<System.Windows.Forms.DataGridViewCellEventArgs>(this.grdWorkSummary_btnDeleteRowClicked);
            this.grdWorkSummary.btnSaveRowClicked += new System.EventHandler<System.Windows.Forms.DataGridViewCellEventArgs>(this.grdWorkSummary_btnSaveRowClicked);
            this.grdWorkSummary.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.grdWorkSummary_CellValidating);
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
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(813, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(40, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbProject
            // 
            this.cmbProject.DataSource = this.userConfigurationProjectBindingSource;
            this.cmbProject.DisplayMember = "name";
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(170, 49);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(121, 21);
            this.cmbProject.TabIndex = 4;
            this.cmbProject.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProject_Validating);
            // 
            // cmbSubProject
            // 
            this.cmbSubProject.DataSource = this.userConfigurationSubprojectBindingSource;
            this.cmbSubProject.DisplayMember = "name";
            this.cmbSubProject.FormattingEnabled = true;
            this.cmbSubProject.Location = new System.Drawing.Point(328, 49);
            this.cmbSubProject.Name = "cmbSubProject";
            this.cmbSubProject.Size = new System.Drawing.Size(121, 21);
            this.cmbSubProject.TabIndex = 5;
            this.cmbSubProject.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSubProject_Validating);
            // 
            // cmbTask
            // 
            this.cmbTask.DataSource = this.userConfigurationTaskBindingSource;
            this.cmbTask.DisplayMember = "name";
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(486, 49);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(121, 21);
            this.cmbTask.TabIndex = 6;
            this.cmbTask.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTask_Validating);
            // 
            // btnProject
            // 
            this.btnProject.Location = new System.Drawing.Point(297, 49);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(25, 21);
            this.btnProject.TabIndex = 9;
            this.btnProject.Text = "+";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnSubProject
            // 
            this.btnSubProject.Location = new System.Drawing.Point(455, 49);
            this.btnSubProject.Name = "btnSubProject";
            this.btnSubProject.Size = new System.Drawing.Size(25, 21);
            this.btnSubProject.TabIndex = 10;
            this.btnSubProject.Text = "+";
            this.btnSubProject.UseVisualStyleBackColor = true;
            this.btnSubProject.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnTask
            // 
            this.btnTask.Location = new System.Drawing.Point(613, 49);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(25, 21);
            this.btnTask.TabIndex = 11;
            this.btnTask.Text = "+";
            this.btnTask.UseVisualStyleBackColor = true;
            this.btnTask.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(771, 49);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(25, 21);
            this.btnLocation.TabIndex = 12;
            this.btnLocation.Text = "+";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnConfigureComponent_Click);
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(12, 76);
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
            this.dpWorkDate.Location = new System.Drawing.Point(13, 50);
            this.dpWorkDate.Name = "dpWorkDate";
            this.dpWorkDate.Size = new System.Drawing.Size(151, 20);
            this.dpWorkDate.TabIndex = 14;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 32);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Data";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(167, 32);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 16;
            this.lblProject.Text = "Project";
            // 
            // lblSubProject
            // 
            this.lblSubProject.AutoSize = true;
            this.lblSubProject.Location = new System.Drawing.Point(325, 32);
            this.lblSubProject.Name = "lblSubProject";
            this.lblSubProject.Size = new System.Drawing.Size(61, 13);
            this.lblSubProject.TabIndex = 17;
            this.lblSubProject.Text = "Sub-project";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(641, 32);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 18;
            this.lblLocation.Text = "Location";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(483, 32);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 19;
            this.lblTask.Text = "Task";
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(813, 76);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 20);
            this.btnPause.TabIndex = 20;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // mnu
            // 
            this.mnu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimee,
            this.menuPlugins});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(904, 24);
            this.mnu.TabIndex = 22;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuTimee
            // 
            this.mnuTimee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.countdownAlertToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuTimee.Name = "mnuTimee";
            this.mnuTimee.Size = new System.Drawing.Size(52, 20);
            this.mnuTimee.Text = "Timee";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // countdownAlertToolStripMenuItem
            // 
            this.countdownAlertToolStripMenuItem.Name = "countdownAlertToolStripMenuItem";
            this.countdownAlertToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.countdownAlertToolStripMenuItem.Text = "Count-down alert";
            this.countdownAlertToolStripMenuItem.Click += new System.EventHandler(this.countdownAlertToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // menuPlugins
            // 
            this.menuPlugins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lGBSExcelToolStripMenuItem,
            this.menuExcell,
            this.menuContext,
            this.menuTimeSheet});
            this.menuPlugins.Name = "menuPlugins";
            this.menuPlugins.Size = new System.Drawing.Size(58, 20);
            this.menuPlugins.Text = "Plugins";
            // 
            // lGBSExcelToolStripMenuItem
            // 
            this.lGBSExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuExcelExport});
            this.lGBSExcelToolStripMenuItem.Name = "lGBSExcelToolStripMenuItem";
            this.lGBSExcelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lGBSExcelToolStripMenuItem.Text = "LGBS Excel";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(116, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuExcelExport
            // 
            this.mnuExcelExport.Name = "mnuExcelExport";
            this.mnuExcelExport.Size = new System.Drawing.Size(116, 22);
            this.mnuExcelExport.Text = "Export";
            this.mnuExcelExport.Click += new System.EventHandler(this.mnuExcelExport_Click);
            // 
            // menuExcell
            // 
            this.menuExcell.Name = "menuExcell";
            this.menuExcell.Size = new System.Drawing.Size(130, 22);
            this.menuExcell.Text = "Excell";
            // 
            // menuContext
            // 
            this.menuContext.Name = "menuContext";
            this.menuContext.Size = new System.Drawing.Size(130, 22);
            this.menuContext.Text = "Context";
            // 
            // menuTimeSheet
            // 
            this.menuTimeSheet.Name = "menuTimeSheet";
            this.menuTimeSheet.Size = new System.Drawing.Size(130, 22);
            this.menuTimeSheet.Text = "TimeSheet";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "Date";
            this.calendarColumn1.FillWeight = 99.78245F;
            this.calendarColumn1.HeaderText = "Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn1.Width = 116;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Time";
            this.dataGridViewTextBoxColumn1.HeaderText = "Time";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 117;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn2.FillWeight = 99.78245F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 116;
            // 
            // trayIcon
            // 
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuExit});
            this.trayMenu.Name = "contextMenuStrip1";
            this.trayMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(92, 22);
            this.trayMenuExit.Text = "Exit";
            this.trayMenuExit.Click += new System.EventHandler(this.exit_Click);
            // 
            // lblTimeSummary1
            // 
            this.lblTimeSummary1.AutoSize = true;
            this.lblTimeSummary1.Location = new System.Drawing.Point(12, 281);
            this.lblTimeSummary1.Name = "lblTimeSummary1";
            this.lblTimeSummary1.Size = new System.Drawing.Size(77, 13);
            this.lblTimeSummary1.TabIndex = 23;
            this.lblTimeSummary1.Text = "Time summary:";
            // 
            // lblTimeSummaryResult
            // 
            this.lblTimeSummaryResult.AutoSize = true;
            this.lblTimeSummaryResult.Location = new System.Drawing.Point(95, 281);
            this.lblTimeSummaryResult.Name = "lblTimeSummaryResult";
            this.lblTimeSummaryResult.Size = new System.Drawing.Size(0, 13);
            this.lblTimeSummaryResult.TabIndex = 24;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::Timee.Properties.Resources.folder;
            this.btnBrowse.Location = new System.Drawing.Point(853, 39);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(40, 40);
            this.btnBrowse.TabIndex = 25;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblAlarm
            // 
            this.lblAlarm.AutoSize = true;
            this.lblAlarm.Location = new System.Drawing.Point(801, 281);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(47, 13);
            this.lblAlarm.TabIndex = 26;
            this.lblAlarm.Text = "Alarm in:";
            // 
            // lblAlarmValue
            // 
            this.lblAlarmValue.AutoSize = true;
            this.lblAlarmValue.Location = new System.Drawing.Point(850, 281);
            this.lblAlarmValue.Name = "lblAlarmValue";
            this.lblAlarmValue.Size = new System.Drawing.Size(0, 13);
            this.lblAlarmValue.TabIndex = 27;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 88.33056F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.FillWeight = 88.52315F;
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Project
            // 
            this.Project.DataPropertyName = "Project";
            this.Project.DataSource = this.userConfigurationProjectBindingSource;
            this.Project.DisplayMember = "Name";
            this.Project.FillWeight = 88.33056F;
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
            this.SubProject.FillWeight = 88.33056F;
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
            this.Task.FillWeight = 88.33056F;
            this.Task.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Task.HeaderText = "Task";
            this.Task.Name = "Task";
            this.Task.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Task.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Task.ValueMember = "Name";
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.FillWeight = 88.33056F;
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // Location
            // 
            this.Location.DataPropertyName = "Location";
            this.Location.DataSource = this.userConfigurationLocationBindingSource;
            this.Location.DisplayMember = "Name";
            this.Location.FillWeight = 88.33056F;
            this.Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Location.ValueMember = "Name";
            // 
            // Save
            // 
            this.Save.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Save.FillWeight = 25F;
            this.Save.HeaderText = "";
            this.Save.Image = global::Timee.Properties.Resources.save;
            this.Save.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Save.Name = "Save";
            this.Save.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Save.Width = 25;
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
            // TimeeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 303);
            this.Controls.Add(this.lblAlarmValue);
            this.Controls.Add(this.lblAlarm);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblTimeSummaryResult);
            this.Controls.Add(this.lblTimeSummary1);
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
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grdWorkSummary);
            this.Controls.Add(this.cmbLocations);
            this.Controls.Add(this.mnu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnu;
            this.MaximizeBox = false;
            this.Name = "TimeeMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeeMain_FormClosing);
            this.Load += new System.EventHandler(this.Timee_Load);
            this.Shown += new System.EventHandler(this.TimeeMain_Shown);
            this.Resize += new System.EventHandler(this.TimeeMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationLocationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationProjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationSubprojectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userConfigurationTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeeDataSet)).EndInit();
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocations;
        private Controls.TimeeGrid grdWorkSummary;
        private System.Windows.Forms.Button btnStart;
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
        public DAL.TimeeDataSet timeeDataSet;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuTimee;
        private System.Windows.Forms.ToolStripMenuItem menuPlugins;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lGBSExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuExcelExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.CalendarColumn.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.Label lblTimeSummary1;
        private System.Windows.Forms.Label lblTimeSummaryResult;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ToolStripMenuItem countdownAlertToolStripMenuItem;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblAlarmValue;
        private System.Windows.Forms.ToolStripMenuItem menuExcell;
        private System.Windows.Forms.ToolStripMenuItem menuContext;
        private System.Windows.Forms.ToolStripMenuItem menuTimeSheet;
        private Controls.CalendarColumn.CalendarColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewComboBoxColumn Project;
        private System.Windows.Forms.DataGridViewComboBoxColumn SubProject;
        private System.Windows.Forms.DataGridViewComboBoxColumn Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewComboBoxColumn Location;
        private System.Windows.Forms.DataGridViewImageColumn Save;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
    }
}

