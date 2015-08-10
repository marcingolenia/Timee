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
        public List<Project> selectedProjects = new List<Project>();
        private List<Project> searchedProjects = new List<Project>();

        public ImportDialog()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text.Length > 2)
            {
                chkSelected.Checked = false;
                chlProjects.DataSource = this.projects.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                                                .Select(p => p).ToList();
                chlProjects.DisplayMember = "Name";
            }


        }

        private void ImportDialog_Load(object sender, EventArgs e)
        {
            chlProjects.DataSource = this.projects.ToList();
            chlProjects.DisplayMember = "Name";
        }
        private void chlProjects_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            try
            {
                if (!chkSelected.Checked && !this.selectedProjects.Contains((Project)chlProjects.Items[e.Index]))
                {
                   this.selectedProjects.Add((Project)chlProjects.Items[e.Index]);

                }
                else if (!chkSelected.Checked && this.selectedProjects.Contains((Project)chlProjects.Items[e.Index]) && e.NewValue == CheckState.Unchecked)
                {
                    this.selectedProjects.Remove((Project)chlProjects.Items[e.Index]);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Something Happened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                chlProjects.DataSource = this.projects.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                                                .Select(p => p).ToList();

                chlProjects.DisplayMember = "Name";

                foreach (Project item in this.selectedProjects)
                {
                    chlProjects.SetItemChecked(chlProjects.Items.IndexOf(item), true);                    
                }
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
