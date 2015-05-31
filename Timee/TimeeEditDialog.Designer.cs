namespace Timee
{
    partial class TimeeEditDialog
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
            this.tabsComponents = new System.Windows.Forms.TabControl();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.compProjectControl = new Timee.Controls.TimeeEditProject();
            this.tabSubProject = new System.Windows.Forms.TabPage();
            this.compSubprojectControl = new Timee.Controls.TimeeEditSubproject();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.compTaskControl = new Timee.Controls.TimeeEditTask();
            this.tabLocation = new System.Windows.Forms.TabPage();
            this.compLocationControl = new Timee.Controls.TimeeEditLocation();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabsComponents.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabSubProject.SuspendLayout();
            this.tabTask.SuspendLayout();
            this.tabLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsComponents
            // 
            this.tabsComponents.Controls.Add(this.tabProject);
            this.tabsComponents.Controls.Add(this.tabSubProject);
            this.tabsComponents.Controls.Add(this.tabTask);
            this.tabsComponents.Controls.Add(this.tabLocation);
            this.tabsComponents.Location = new System.Drawing.Point(12, 12);
            this.tabsComponents.Name = "tabsComponents";
            this.tabsComponents.SelectedIndex = 0;
            this.tabsComponents.Size = new System.Drawing.Size(402, 252);
            this.tabsComponents.TabIndex = 7;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.compProjectControl);
            this.tabProject.Location = new System.Drawing.Point(4, 22);
            this.tabProject.Name = "tabProject";
            this.tabProject.Padding = new System.Windows.Forms.Padding(3);
            this.tabProject.Size = new System.Drawing.Size(394, 226);
            this.tabProject.TabIndex = 1;
            this.tabProject.Text = "Project";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // compProjectControl
            // 
            this.compProjectControl.BindingSourceList = null;
            this.compProjectControl.Location = new System.Drawing.Point(0, 0);
            this.compProjectControl.Name = "compProjectControl";
            this.compProjectControl.Size = new System.Drawing.Size(391, 215);
            this.compProjectControl.TabIndex = 0;
            // 
            // tabSubProject
            // 
            this.tabSubProject.Controls.Add(this.compSubprojectControl);
            this.tabSubProject.Location = new System.Drawing.Point(4, 22);
            this.tabSubProject.Name = "tabSubProject";
            this.tabSubProject.Size = new System.Drawing.Size(394, 226);
            this.tabSubProject.TabIndex = 2;
            this.tabSubProject.Text = "Sub-project";
            this.tabSubProject.UseVisualStyleBackColor = true;
            // 
            // compSubprojectControl
            // 
            this.compSubprojectControl.BindingSourceList = null;
            this.compSubprojectControl.Location = new System.Drawing.Point(0, 0);
            this.compSubprojectControl.Name = "compSubprojectControl";
            this.compSubprojectControl.Size = new System.Drawing.Size(391, 215);
            this.compSubprojectControl.TabIndex = 0;
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.compTaskControl);
            this.tabTask.Location = new System.Drawing.Point(4, 22);
            this.tabTask.Name = "tabTask";
            this.tabTask.Size = new System.Drawing.Size(394, 226);
            this.tabTask.TabIndex = 3;
            this.tabTask.Text = "Task";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // compTaskControl
            // 
            this.compTaskControl.BindingSourceList = null;
            this.compTaskControl.Location = new System.Drawing.Point(0, 0);
            this.compTaskControl.Name = "compTaskControl";
            this.compTaskControl.Size = new System.Drawing.Size(391, 215);
            this.compTaskControl.TabIndex = 0;
            // 
            // tabLocation
            // 
            this.tabLocation.Controls.Add(this.compLocationControl);
            this.tabLocation.Location = new System.Drawing.Point(4, 22);
            this.tabLocation.Name = "tabLocation";
            this.tabLocation.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocation.Size = new System.Drawing.Size(394, 226);
            this.tabLocation.TabIndex = 0;
            this.tabLocation.Text = "Location";
            this.tabLocation.UseVisualStyleBackColor = true;
            // 
            // compLocationControl
            // 
            this.compLocationControl.BindingSourceList = null;
            this.compLocationControl.Location = new System.Drawing.Point(0, 0);
            this.compLocationControl.Name = "compLocationControl";
            this.compLocationControl.Size = new System.Drawing.Size(391, 215);
            this.compLocationControl.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(335, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TimeeEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 316);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabsComponents);
            this.Name = "TimeeEditDialog";
            this.Text = "Edit positions";
            this.tabsComponents.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabSubProject.ResumeLayout(false);
            this.tabTask.ResumeLayout(false);
            this.tabLocation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsComponents;
        private System.Windows.Forms.TabPage tabLocation;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabSubProject;
        private System.Windows.Forms.TabPage tabTask;
        private Controls.TimeeEditLocation compLocationControl;
        private Controls.TimeeEditProject compProjectControl;
        private Controls.TimeeEditSubproject compSubprojectControl;
        private Controls.TimeeEditTask compTaskControl;
    }
}

