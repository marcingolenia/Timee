using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using Timee.Models;
using System.Data;
using Timee.Tools;
using Timee.DAL;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        public TimeeContext Context;
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
            this.Context = TimeeXMLService.Instance.LoadContext();
            cmbLocations.DataSource = Context.Locations;
            cmbProject.DataSource = Context.Projects;
            cmbTask.DataSource = Context.Tasks;
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
                if(dlgEdit.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    TimeeXMLService.Instance.SaveContext(this.Context);
                }
            }
        }

        private void exportToXlsButton_Click(object sender, EventArgs e)
        {
            DataRowCollection allEntries = this.timeeDataSet.TimeSheetTable.Rows;
            XlsExportManager exporter = new XlsExportManager();
            exporter.ExportAllEntries(allEntries);
        }
    }
}

