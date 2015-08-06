using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timesheet.TimesheetService;

namespace Timesheet
{
    public partial class ImportDialog : Form
    {
        public List<Project> projects = new List<Project>();
        private List<Project> searchedProjects = new List<Project>();
        public List<Project> selectedProjects = new List<Project>();
        public Dictionary<string, int> Projects { get; set; }

        public ImportDialog()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 2)
            {
                searchedProjects = this.projects.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                                   .Select(p => p).ToList();
                chkSelected.Checked = false;
                chlProjects.DataSource = searchedProjects;
                chlProjects.DisplayMember = "Name";
            }

        }

        private void ImportDialog_Load(object sender, EventArgs e)
        {
            Projects = new Dictionary<string, int>();
            this.searchedProjects = this.projects.ToList();
            chlProjects.DataSource = searchedProjects;
            chlProjects.DisplayMember = "Name";
        }

        private void ImportDialog_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Abort;
        }

        private void chlProjects_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if (!chkSelected.Checked)
            {
                Project checkedProject = (Project)chlProjects.Items[e.Index];
                    try
                    {
                        if (!this.selectedProjects.Contains(checkedProject))
                        {
                            this.selectedProjects.Add(checkedProject);
                            this.projects.Remove(checkedProject);
                        }
                    }
                    catch (Exception ex) { }
            }
        }
           

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelected.Checked)
            {

                chlProjects.DataSource = this.selectedProjects;
                chlProjects.DisplayMember = "Name";
            }
            else
            {
                this.searchedProjects = projects.Where(p => p.Name.Contains(txtSearch.Text))
                                               .Select(p => p).ToList();
                chlProjects.DataSource = this.searchedProjects;
                chlProjects.DisplayMember = "Name";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
