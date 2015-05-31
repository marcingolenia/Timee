﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using Timee.Models;
using System.Data;
using Timee.Tools;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        public TimeeContext Context = new TimeeContext();
        public TimeeMain()
        {
            InitializeComponent();
            //
            //Test purposes only:
            this.timeeDataSet.TimeSheetTable.AddTimeSheetTableRow(DateTime.Now, DateTime.Now, null, "testSP", "testT", "testL", "testC");

        }
        private void grdWorkSummaryInit()
        {
            var c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName];
            c.DataSource = Context.Projects;
            //grdWorkSummary.
        }

        private void Timer_Load(object sender, EventArgs e)
        {

            XmlSerializer s = new XmlSerializer(typeof(Models.UserConfiguration));
            XDocument doc =
            XDocument.Load(Path.Combine(Environment.CurrentDirectory, "userConfiguration.xml"));
            var conf = (Models.UserConfiguration)s.Deserialize(doc.CreateReader());

            Context.Locations = new BindingList<Models.UserConfigurationLocation>(conf.Location.ToList());
            cmbLocations.DataSource = Context.Locations;

            Context.Projects = new BindingList<Models.UserConfigurationProject>(conf.Project.ToList());
            cmbProject.DataSource = Context.Projects;

            Context.Tasks = new BindingList<Models.UserConfigurationTask>(conf.Task.ToList());
            cmbTask.DataSource = Context.Tasks;

            Context.Subprojects = new BindingList<Models.UserConfigurationSubproject>(conf.Subproject.ToList());
            cmbSubProject.DataSource = Context.Subprojects;

            grdWorkSummaryInit();
        }

        //Events
        private void btnConfigureComponent_Click(object sender, EventArgs e)
        {
            TimeeComponentType component = TimeeComponentType.Undefined;
            if (sender.Equals(btnProject))
            {
                component = TimeeComponentType.Project;
            }
            else if (sender.Equals(btnSubProject))
            {
                component = TimeeComponentType.Subproject;
            }
            else if (sender.Equals(btnTask))
            {
                component = TimeeComponentType.Task;
            }
            else if (sender.Equals(btnLocation))
            {
                component = TimeeComponentType.Location;
            }
            using (var dlgEdit = new TimeeEditDialog(this.Context, component))
            {
                dlgEdit.ShowDialog();
                //Do things...
            }
            // this.Context.Locations.ResetBindings();
            // this.cmbLocations.re.Refresh();
        }

        private void exportToXlsButton_Click(object sender, EventArgs e)
        {
            DataRowCollection allEntries = this.timeeDataSet.TimeSheetTable.Rows;
            XlsExportManager exporter = new XlsExportManager();
            exporter.ExportAllEntries(allEntries);
        }
    }
}

