namespace Timee.Dialogs
{
    partial class PrototypeDialog
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
            this.lbProjects = new System.Windows.Forms.ListBox();
            this.lbSubProjects = new System.Windows.Forms.ListBox();
            this.lbTasks = new System.Windows.Forms.ListBox();
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblProjects = new System.Windows.Forms.Label();
            this.lblSubProjects = new System.Windows.Forms.Label();
            this.lblTasks = new System.Windows.Forms.Label();
            this.lblLocations = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbProjects
            // 
            this.lbProjects.FormattingEnabled = true;
            this.lbProjects.Location = new System.Drawing.Point(12, 18);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(142, 134);
            this.lbProjects.TabIndex = 0;
            this.lbProjects.SelectedIndexChanged += new System.EventHandler(this.lbProjects_SelectedIndexChanged);
            // 
            // lbSubProjects
            // 
            this.lbSubProjects.FormattingEnabled = true;
            this.lbSubProjects.Location = new System.Drawing.Point(160, 18);
            this.lbSubProjects.Name = "lbSubProjects";
            this.lbSubProjects.Size = new System.Drawing.Size(120, 134);
            this.lbSubProjects.TabIndex = 1;
            this.lbSubProjects.SelectedIndexChanged += new System.EventHandler(this.lbSubProjects_SelectedIndexChanged);
            // 
            // lbTasks
            // 
            this.lbTasks.FormattingEnabled = true;
            this.lbTasks.Location = new System.Drawing.Point(286, 18);
            this.lbTasks.Name = "lbTasks";
            this.lbTasks.Size = new System.Drawing.Size(120, 134);
            this.lbTasks.TabIndex = 2;
            this.lbTasks.SelectedIndexChanged += new System.EventHandler(this.lbTasks_SelectedIndexChanged);
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(429, 18);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(120, 134);
            this.lbLocations.TabIndex = 3;
            this.lbLocations.SelectedIndexChanged += new System.EventHandler(this.lbLocations_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(555, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(555, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            // PrototypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 164);
            this.Controls.Add(this.lblLocations);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lblSubProjects);
            this.Controls.Add(this.lblProjects);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbLocations);
            this.Controls.Add(this.lbTasks);
            this.Controls.Add(this.lbSubProjects);
            this.Controls.Add(this.lbProjects);
            this.Name = "PrototypeDialog";
            this.Text = "PrototypeDialog";
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblProjects;
        private System.Windows.Forms.Label lblSubProjects;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Label lblLocations;
    }
}