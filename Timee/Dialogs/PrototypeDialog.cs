using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public PrototypeDialog()
        {
            InitializeComponent();
        }

        private void PrototypeDialog_Load(object sender, EventArgs e)
        {
            lbProjects.DataSource = Context.Projects;
            lbProjects.DisplayMember = "Name";
            lbLocations.DataSource = Context.Locations;
            lbLocations.DisplayMember = "Name";

            if(this.Project !=null)  tmpProject = this.Project;
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

                this.Project = (Models.UserConfigurationProject)lbProjects.SelectedItem;
                if (this.Project == null) this.Project = tmpProject;
                lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Select(s => s).ToList();
                lbSubProjects.DisplayMember = "Name";



            if (lbSubProjects.Items.Count == 0)
            {
                lbTasks.DataSource = null;
                this.SubProject = null;
                this.Task = null;
            }
        }

        private void lbSubProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SubProject = (Models.UserConfigurationSubproject)lbSubProjects.SelectedItem;

                lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Select(s => s).ToList();
                lbTasks.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK; 
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Task = (Models.UserConfigurationTask)lbTasks.SelectedItem;

        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Location = (Models.UserConfigurationLocation)lbLocations.SelectedItem;
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
            lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == this.Project.Name).Select(s => s).ToList();
            lbSubProjects.DisplayMember = "Name";
            lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == this.SubProject.Name).Select(s => s).ToList();
            lbTasks.DisplayMember = "Name";
            Services.TimeeXMLService.Instance.SaveContext(this.Context);


        }


    }
}
