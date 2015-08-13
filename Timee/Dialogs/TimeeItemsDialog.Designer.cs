namespace Timee.Dialogs
{
    partial class TimeeItemsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeeItemsDialog));
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.lbSubProjects = new System.Windows.Forms.ListBox();
            this.lbTasks = new System.Windows.Forms.ListBox();
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.lblProjects = new System.Windows.Forms.Label();
            this.lblSubProjects = new System.Windows.Forms.Label();
            this.lblTasks = new System.Windows.Forms.Label();
            this.lblLocations = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.txtSubProject = new System.Windows.Forms.TextBox();
            this.txtTask = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.btnAddSubProject = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnDeleteSubProject = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.dpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbProjects
            // 
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.Location = new System.Drawing.Point(12, 44);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(142, 134);
            this.lbProjects.TabIndex = 0;
            this.lbProjects.SelectedIndexChanged += new System.EventHandler(this.lbProjects_SelectedIndexChanged);
            // 
            // lbSubProjects
            // 
            this.lbSubProjects.FormattingEnabled = true;
            this.lbSubProjects.Location = new System.Drawing.Point(160, 44);
            this.lbSubProjects.Name = "lbSubProjects";
            this.lbSubProjects.Size = new System.Drawing.Size(120, 134);
            this.lbSubProjects.TabIndex = 1;
            this.lbSubProjects.SelectedIndexChanged += new System.EventHandler(this.lbSubProjects_SelectedIndexChanged);
            // 
            // lbTasks
            // 
            this.lbTasks.FormattingEnabled = true;
            this.lbTasks.Location = new System.Drawing.Point(286, 44);
            this.lbTasks.Name = "lbTasks";
            this.lbTasks.Size = new System.Drawing.Size(120, 134);
            this.lbTasks.TabIndex = 2;
            this.lbTasks.SelectedIndexChanged += new System.EventHandler(this.lbTasks_SelectedIndexChanged);
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(429, 44);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(135, 134);
            this.lbLocations.TabIndex = 3;
            this.lbLocations.SelectedIndexChanged += new System.EventHandler(this.lbLocations_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(429, 219);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(12, 180);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(142, 23);
            this.btnDeleteProject.TabIndex = 5;
            this.btnDeleteProject.Text = "Delete";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // lblProjects
            // 
            this.lblProjects.AutoSize = true;
            this.lblProjects.Location = new System.Drawing.Point(9, 2);
            this.lblProjects.Name = "lblProjects";
            this.lblProjects.Size = new System.Drawing.Size(45, 13);
            this.lblProjects.TabIndex = 6;
            this.lblProjects.Text = "Projects";
            // 
            // lblSubProjects
            // 
            this.lblSubProjects.AutoSize = true;
            this.lblSubProjects.Location = new System.Drawing.Point(157, 2);
            this.lblSubProjects.Name = "lblSubProjects";
            this.lblSubProjects.Size = new System.Drawing.Size(67, 13);
            this.lblSubProjects.TabIndex = 7;
            this.lblSubProjects.Text = "Sub Projects";
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(283, 2);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(36, 13);
            this.lblTasks.TabIndex = 8;
            this.lblTasks.Text = "Tasks";
            // 
            // lblLocations
            // 
            this.lblLocations.AutoSize = true;
            this.lblLocations.Location = new System.Drawing.Point(426, 2);
            this.lblLocations.Name = "lblLocations";
            this.lblLocations.Size = new System.Drawing.Size(53, 13);
            this.lblLocations.TabIndex = 9;
            this.lblLocations.Text = "Locations";
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(12, 18);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(114, 20);
            this.txtProject.TabIndex = 10;
            this.txtProject.Text = "New Project";
            // 
            // txtSubProject
            // 
            this.txtSubProject.Location = new System.Drawing.Point(160, 18);
            this.txtSubProject.Name = "txtSubProject";
            this.txtSubProject.Size = new System.Drawing.Size(95, 20);
            this.txtSubProject.TabIndex = 11;
            this.txtSubProject.Text = "New SubProject";
            // 
            // txtTask
            // 
            this.txtTask.Location = new System.Drawing.Point(286, 18);
            this.txtTask.Name = "txtTask";
            this.txtTask.Size = new System.Drawing.Size(94, 20);
            this.txtTask.TabIndex = 12;
            this.txtTask.Text = "New Task";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(429, 18);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(107, 20);
            this.txtLocation.TabIndex = 13;
            this.txtLocation.Text = "New Location";
            // 
            // btnAddProject
            // 
            this.btnAddProject.Location = new System.Drawing.Point(132, 18);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(22, 20);
            this.btnAddProject.TabIndex = 14;
            this.btnAddProject.Text = "+";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnAddSubProject
            // 
            this.btnAddSubProject.Location = new System.Drawing.Point(261, 18);
            this.btnAddSubProject.Name = "btnAddSubProject";
            this.btnAddSubProject.Size = new System.Drawing.Size(22, 20);
            this.btnAddSubProject.TabIndex = 15;
            this.btnAddSubProject.Text = "+";
            this.btnAddSubProject.UseVisualStyleBackColor = true;
            this.btnAddSubProject.Click += new System.EventHandler(this.btnAddSubProject_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(386, 18);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(22, 20);
            this.btnAddTask.TabIndex = 16;
            this.btnAddTask.Text = "+";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(542, 18);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(22, 20);
            this.btnAddLocation.TabIndex = 17;
            this.btnAddLocation.Text = "+";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnDeleteSubProject
            // 
            this.btnDeleteSubProject.Location = new System.Drawing.Point(160, 180);
            this.btnDeleteSubProject.Name = "btnDeleteSubProject";
            this.btnDeleteSubProject.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteSubProject.TabIndex = 18;
            this.btnDeleteSubProject.Text = "Delete";
            this.btnDeleteSubProject.UseVisualStyleBackColor = true;
            this.btnDeleteSubProject.Click += new System.EventHandler(this.btnDeleteSubProject_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(286, 180);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(122, 23);
            this.btnDeleteTask.TabIndex = 19;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(429, 180);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(135, 23);
            this.btnDeleteLocation.TabIndex = 20;
            this.btnDeleteLocation.Text = "Delete";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(9, 206);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "Data";
            // 
            // dpWorkDate
            // 
            this.dpWorkDate.Location = new System.Drawing.Point(9, 222);
            this.dpWorkDate.Name = "dpWorkDate";
            this.dpWorkDate.Size = new System.Drawing.Size(144, 20);
            this.dpWorkDate.TabIndex = 21;
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(160, 222);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(248, 20);
            this.tbComment.TabIndex = 23;
            this.tbComment.Text = "Comment";
            // 
            // PrototypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 248);
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dpWorkDate);
            this.Controls.Add(this.btnDeleteLocation);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnDeleteSubProject);
            this.Controls.Add(this.btnAddLocation);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnAddSubProject);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtTask);
            this.Controls.Add(this.txtSubProject);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.lblLocations);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lblSubProjects);
            this.Controls.Add(this.lblProjects);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbLocations);
            this.Controls.Add(this.lbTasks);
            this.Controls.Add(this.lbSubProjects);
            this.Controls.Add(this.lbProjects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrototypeDialog";
            this.Text = "Timee Items";
            this.Load += new System.EventHandler(this.PrototypeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbProjects;
        private System.Windows.Forms.ListBox lbSubProjects;
        private System.Windows.Forms.ListBox lbTasks;
        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.Label lblSubProjects;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Label lblLocations;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.TextBox txtSubProject;
        private System.Windows.Forms.TextBox txtTask;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Button btnAddSubProject;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnDeleteSubProject;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dpWorkDate;
        private System.Windows.Forms.TextBox tbComment;
    }
}