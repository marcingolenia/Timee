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
        public Timee.Models.TimeeContext Context { get; set; }
        public string Project { get; set; }
        public string SubProject { get; set; }
        public string Task { get; set; }
        public string Location { get; set; }

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
            
        }

        private void lbProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach ( Timee.Models.UserConfigurationProject item in lbProjects.SelectedItems)
            {
                lbSubProjects.DataSource = Context.Subprojects.Where(s => s.Parent == item.Name).Select(s => s).ToList();
                lbSubProjects.DisplayMember = "Name";
                this.Project = item.Name;
            }

            if (lbSubProjects.Items.Count == 0)
            {
                lbTasks.DataSource = null;
                this.SubProject = "";
                this.Task = "";
            }
        }

        private void lbSubProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Timee.Models.UserConfigurationSubproject item in lbSubProjects.SelectedItems)
            {
                lbTasks.DataSource = Context.Tasks.Where(s => s.Parent == item.Name).Select(s => s).ToList();
                lbTasks.DisplayMember = "Name";
                this.SubProject = item.Name;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK; 
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Timee.Models.UserConfigurationTask item in lbTasks.SelectedItems)
            {
                this.Task = item.Name;
            }
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Timee.Models.UserConfigurationLocation item in lbLocations.SelectedItems)
            {
                this.Location = item.Name;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }


    }
}
