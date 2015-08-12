using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.DAL;
using Timee.Models;

namespace Timee.Dialogs
{
    public partial class PrototypeDialog : Form
    {
        public Models.TimeeContext Context { get; set; }
        public Models.UserConfigurationProject Project { get; set; }
        public Models.UserConfigurationSubproject SubProject { get; set; }
        public Models.UserConfigurationTask Task { get; set; }
        public Models.UserConfigurationLocation Location { get; set; }
        private Models.UserConfigurationProject tmpProject;
        private TimeeMain main;

        public PrototypeDialog(TimeeMain main)
        {
            this.main = main;
            InitializeComponent();
        }

        private void PrototypeDialog_Load(object sender, EventArgs e)
        {
            lbProjects.DataSource = Context.Projects;
            lbProjects.DisplayMember = "Name";
            lbLocations.DataSource = Context.Locations;
            lbLocations.DisplayMember = "Name";
            this.ListBoxesValidate();
            this.Project = (Models.UserConfigurationProject)lbProjects.SelectedItem;
            this.SubProject = (Models.UserConfigurationSubproject)lbSubProjects.SelectedItem;
            this.Task = (Models.UserConfigurationTask)lbTasks.SelectedItem;
            this.Location = (Models.UserConfigurationLocation)lbLocations.SelectedItem;
            if(this.Project !=null)  tmpProject = this.Project;
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.Project = (Models.UserConfigurationProject)lbProjects.SelectedItem;
            if (this.Project == null) this.Project = tmpProject;
            lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Where(s=>s.ParentId == this.Project.Value).Select(s => s).ToList();
            lbSubProjects.DisplayMember = "Name";
            this.txtSubProject.Enabled = true;
            this.txtTask.Enabled = true;
            this.btnAddSubProject.Enabled = true;
            this.btnAddTask.Enabled = true;
            this.btnDeleteProject.Enabled = true;
            this.btnDeleteSubProject.Enabled = true;
            this.btnDeleteTask.Enabled = true;

            this.ListBoxesValidate();
        }

        private void lbSubProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SubProject = (Models.UserConfigurationSubproject)lbSubProjects.SelectedItem;

                lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(s=>s.ParentId == this.SubProject.Value).Select(s => s).ToList();
                lbTasks.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TimeeDataSet.TimeSheetTableRow row = this.main.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
                row.Comment = this.tbComment.Text;
                row.Date = this.dpWorkDate.Value;
                row.Project = this.Project.Name;
                row.SubProject = this.SubProject.Name == null? "" : this.SubProject.Name;
                row.Task = this.Task.Name == null ? "" : this.Task.Name;
                row.Time = TimeSpan.Zero;
                row.Location = this.Location.Name;
                this.main.AddNewRow(row);
                //this.btnPause.Enabled = true;
                //this.btnPause.Text = "Pause";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incomplete Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //this.DialogResult = DialogResult.OK; 
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Task = (Models.UserConfigurationTask)lbTasks.SelectedItem;
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Location = (Models.UserConfigurationLocation)lbLocations.SelectedItem;
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            string tmpSelectedProject = this.Project.Name;
            this.Context.Projects.Remove(this.Context.Projects.Where(p => p.Name == tmpSelectedProject).Select(p => p).First());
            var subProjectRemove = this.Context.Subprojects.Where(s => s.Parent == tmpSelectedProject).ToList();
            foreach (var item in subProjectRemove)
            {
                var taskRemove = this.Context.Tasks.Where(t => t.Parent == item.Name).ToList();
                foreach (var task in taskRemove)
                {
                    this.Context.Tasks.Remove(task);
                }
                this.Context.Subprojects.Remove(item);
            }
            this.Project = (Models.UserConfigurationProject)lbProjects.SelectedItem;
            lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Where(s=>s.ParentId == this.Project.Value).Select(s => s).ToList();
            lbSubProjects.DisplayMember = "Name";
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(s=>s.ParentId == this.SubProject.Value).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";
            Services.TimeeXMLService.Instance.SaveContext(this.Context);

            this.ListBoxesValidate();
        }
        private void btnDeleteSubProject_Click(object sender, EventArgs e)
        {
            string tmpSelectedSubProject = this.SubProject.Name;
            string tmpSelectedSubProjectId = this.SubProject.Value;
            this.Context.Subprojects.Remove(this.Context.Subprojects.Where(p=>p.Parent == this.Project.Name).Where(p => p.Name == tmpSelectedSubProject).Select(p => p).First());
            var taskRemove = this.Context.Tasks.Where(s => s.Parent == tmpSelectedSubProject).Where(s=>s.ParentId == tmpSelectedSubProjectId).ToList();
            foreach (var item in taskRemove)
            {
                this.Context.Tasks.Remove(item);
            }
            this.SubProject = (Models.UserConfigurationSubproject)lbSubProjects.SelectedItem;
            lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Where(s=>s.ParentId == this.Project.Value).Select(s => s).ToList();
            lbSubProjects.DisplayMember = "Name";
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(t=>t.ParentId == this.SubProject.Value).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";
            Services.TimeeXMLService.Instance.SaveContext(this.Context);

            this.ListBoxesValidate();
        }
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            string tmpSelectedTask = this.Task.Name;
            this.Context.Tasks.Remove(this.Context.Tasks.Where(t => t.Name == tmpSelectedTask).Select(t => t).First());
            this.Task = (Models.UserConfigurationTask)lbTasks.SelectedItem;
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(s=>s.ParentId == this.SubProject.Value).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";

            this.ListBoxesValidate();
        }
        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            string tmpSelectedLocation = this.Location.Name;
            this.Context.Locations.Remove(this.Context.Locations.Where(t => t.Name == tmpSelectedLocation).Select(t => t).First());
            this.Location = (Models.UserConfigurationLocation)lbLocations.SelectedItem;
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            this.ListBoxesValidate();
        }


        private void btnAddProject_Click(object sender, EventArgs e)
        {
            UserConfigurationProject tmpProject = new UserConfigurationProject();


            tmpProject.Name = txtProject.Text;
            if (tmpProject.Name != null)
            {
                if (this.Context.Projects.Where(i => i.Name == tmpProject.Name).Count() == 0)
                {
                    tmpProject.Value = "-1";
                    int tmpValue = Convert.ToInt32(tmpProject.Value);
                    while (this.Context.Projects.Where(i => i.Value == tmpValue.ToString()).Count() == 1)
                    {
                        --tmpValue;
                    }
                    tmpProject.Value = tmpValue.ToString();
                    tmpProject.Order = Context.Projects.Count == 0 ? 1 : this.Context.Projects.Max(i => i.Order + 1);
                    tmpProject.OrderSpecified = true;
                    this.Context.Projects.Add(tmpProject);
                    this.Project = tmpProject;
                }

            }
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            this.ListBoxesValidate();
        }

        private void btnAddSubProject_Click(object sender, EventArgs e)
        {
            UserConfigurationSubproject tmpSubproject = new UserConfigurationSubproject();
            tmpSubproject.Name = txtSubProject.Text;
            if (tmpSubproject.Name != null)
            {
                tmpSubproject.Value = "-1";
                int tmpValue = Convert.ToInt32(tmpSubproject.Value);
                while (this.Context.Subprojects.Where(i => i.Value == tmpValue.ToString()).Count() == 1)
                {
                    --tmpValue;
                }
                tmpSubproject.Value = tmpValue.ToString();
                tmpSubproject.Parent = this.Project.Name;
                tmpSubproject.ParentId = this.Project.Value;
                tmpSubproject.Order = Context.Subprojects.Count == 0 ? 1 : this.Context.Subprojects.Max(i => i.Order + 1);
                tmpSubproject.OrderSpecified = true;
                this.Context.Subprojects.Add(tmpSubproject);
                this.SubProject = tmpSubproject;
            }
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Where(s=>s.ParentId == this.Project.Value).Select(s => s).ToList();
            lbSubProjects.DisplayMember = "Name";
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(s=>s.ParentId == this.SubProject.Value).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";
            this.ListBoxesValidate();

        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            UserConfigurationTask tmpTask = new UserConfigurationTask();
            tmpTask.Name = txtTask.Text;
            if (tmpTask.Name != null)
            {
                tmpTask.Value = "-1";
                int tmpValue = Convert.ToInt32(tmpTask.Value);
                while (this.Context.Tasks.Where(i => i.Value == tmpValue.ToString()).Count() == 1)
                {
                    --tmpValue;
                }
                tmpTask.Value = tmpValue.ToString();
                tmpTask.Parent = this.SubProject.Name;
                tmpTask.ParentId = this.SubProject.Value;
                tmpTask.Order = Context.Tasks.Count == 0 ? 1 : this.Context.Tasks.Max(i => i.Order + 1);
                tmpTask.OrderSpecified = true;
                this.Context.Tasks.Add(tmpTask);
                this.Task = tmpTask;
            }
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Where(t=>t.ParentId == this.SubProject.Value).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";
            this.ListBoxesValidate();

        }
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            UserConfigurationLocation tmpLocation = new UserConfigurationLocation();

            tmpLocation.Name = txtLocation.Text;
            if (tmpLocation.Name != null)
            {
                    tmpLocation.Value = "-1";
                    int tmpValue = Convert.ToInt32(tmpLocation.Value);
                    while (this.Context.Locations.Where(i => i.Value == tmpValue.ToString()).Count() == 1)
                        {
                            --tmpValue;
                        }
                    tmpLocation.Value = tmpValue.ToString();
                    tmpLocation.Value = null;
                    tmpLocation.Order = Context.Locations.Count == 0 ? 1 : this.Context.Locations.Max(i => i.Order + 1);
                    tmpLocation.OrderSpecified = true;
                    this.Context.Locations.Add(tmpLocation);
                    this.Location = tmpLocation;
            }
            Services.TimeeXMLService.Instance.SaveContext(this.Context);
            this.ListBoxesValidate();
        }
        private void ListBoxesValidate()
        {
            this.txtSubProject.Enabled = true;
            this.txtTask.Enabled = true;
            this.txtProject.Enabled = true;
            this.btnAddProject.Enabled = true;
            this.btnAddSubProject.Enabled = true;
            this.btnAddTask.Enabled = true;
            this.btnDeleteProject.Enabled = true;
            this.btnDeleteSubProject.Enabled = true;
            this.btnDeleteTask.Enabled = true;
            this.btnDeleteLocation.Enabled = true;

            if (lbProjects.Items.Count == 0)
            {
                this.btnDeleteProject.Enabled = false;
                this.btnAddSubProject.Enabled = false;
                this.txtSubProject.Enabled = false;
            }
            if (lbSubProjects.Items.Count == 0)
            {
                lbTasks.DataSource = null;
                this.SubProject = null;
                this.Task = null;
                this.btnAddTask.Enabled = false;
                this.txtTask.Enabled = false;
                this.btnDeleteSubProject.Enabled = false;
            }
            if (lbTasks.Items.Count == 0)
            {

                this.btnDeleteTask.Enabled = false;
            }
            if (lbLocations.Items.Count == 0)
            {
                this.btnDeleteLocation.Enabled = false;
            }
        }

    }
}
