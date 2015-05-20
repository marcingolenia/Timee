using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Timee
{

    public partial class Timee : Form
    {
        public BindingList<Models.UserConfigurationLocation> Locations { get; set; }
        public BindingList<Models.UserConfigurationProject> Projects { get; set; }
        public BindingList<Models.UserConfigurationSubproject> Subprojects { get; set; }
        public BindingList<Models.UserConfigurationTask> Tasks { get; set; }

        public Timee()
        {
            InitializeComponent();
        }

        private void Timee_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = " Aplication minimalized";
            notifyIcon1.BalloonTipText = "App has been minimalized. Double click to restore it.";
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
                
            }
        }

        //MGolenia; To coś właściwie robi?
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Timer_Load(object sender, EventArgs e)
        {

            XmlSerializer s = new XmlSerializer(typeof(Models.UserConfiguration));
            XDocument doc =
            XDocument.Load(Path.Combine(Environment.CurrentDirectory, "userConfiguration.xml"));
            var conf = (Models.UserConfiguration)s.Deserialize(doc.CreateReader());

            Locations = new BindingList<Models.UserConfigurationLocation>(conf.Location.ToList());
            cbLocations.DataSource = Locations;

            Projects = new BindingList<Models.UserConfigurationProject>(conf.Project.ToList());
            cmbProject.DataSource = Projects;

            Tasks = new BindingList<Models.UserConfigurationTask>(conf.Task.ToList());
            taskcomboBox.DataSource = Tasks;

            Subprojects = new BindingList<Models.UserConfigurationSubproject>(conf.Subproject.ToList());
            subprojectcombobox.DataSource = Subprojects;  
        }

        //Events
        private void btnAddProject_Click(object sender, EventArgs e)
        {//TODO: Add properties like in here to the TimeeEditDialog and pass in constructor.
            using (var dlgEdit = new TimeeEditDialog())
            {
                dlgEdit.ShowDialog();
            }
        }

    }
}

