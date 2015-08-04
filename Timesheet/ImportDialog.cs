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
        public Project[] projects;
        private Project[] searchedProjects;
        public Dictionary<string, int> Projects { get; set; }

        public ImportDialog()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            searchedProjects = projects.Where(p => p.Name.Contains(txtSearch.Text))
                                               .Select(p => p).ToArray();
            chkSelected.Checked = false;
            chlProjects.DataSource = searchedProjects;
            chlProjects.DisplayMember = "Name";
        }

        private void ImportDialog_Load(object sender, EventArgs e)
        {
            Projects = new Dictionary<string, int>();
            this.searchedProjects = this.projects;
            chlProjects.DataSource = searchedProjects;
            chlProjects.DisplayMember = "Name";
        }

        private void chlProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkSelected.Checked)
            {
                foreach (Project item in chlProjects.CheckedItems)
                {
                    try
                    {
                        this.Projects.Add(item.Name, item.Id);

                    }
                    catch (Exception ex) { }

                }
            }
           
        }

        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelected.Checked)
            {

                chlProjects.DataSource = Projects.ToArray();
            }
            else
            {
                chlProjects.DataSource = searchedProjects;
                chlProjects.DisplayMember = "Name";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
