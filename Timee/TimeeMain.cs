using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timee.DAL;
using Timee.Models;
using Timee.Tools;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        public TimeeContext Context;
        public TimeeMain()
        {
            InitializeComponent();
            //Test purposes only:
            this.timeeDataSet.TimeSheetTable.AddTimeSheetTableRow(2.25, DateTime.Now, null, null, null, null, null);
            this.timeeDataSet.TimeSheetTable.AddTimeSheetTableRow(2.25, DateTime.Now, null, null, null, null, null);

        }
        private void grdWorkSummaryInit()
        {
            DataGridViewComboBoxColumn c;
            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName];
            c.DataSource = Context.Projects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName];
            c.DataSource = Context.Subprojects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName];
            c.DataSource = Context.Tasks;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName];
            c.DataSource = Context.Locations;

        }
        //Events
        private void Timer_Load(object sender, EventArgs e)
        {
            this.Context = TimeeXMLService.Instance.LoadContext();
            cmbLocations.DataSource = Context.Locations;
            cmbProject.DataSource = Context.Projects;
            cmbTask.DataSource = Context.Tasks;
            cmbSubProject.DataSource = Context.Subprojects;
            grdWorkSummaryInit();
        }

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
                if (dlgEdit.DialogResult == System.Windows.Forms.DialogResult.OK)
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

        private void grdWorkSummary_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdWorkSummary.CurrentCell.OwningColumn.CellType == typeof(DataGridViewComboBoxCell))
            {
                ComboBox cmb = e.Control as ComboBox;

                if (cmb == null)
                    return;

                cmb.DropDownStyle = ComboBoxStyle.DropDown;
                cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmb.PreviewKeyDown -= new PreviewKeyDownEventHandler(GridCmb_KeyPress);
                cmb.PreviewKeyDown += new PreviewKeyDownEventHandler(GridCmb_KeyPress);
            }
        }

        private void GridCmb_KeyPress(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                grdWorkSummary.EndEdit();
                grdWorkSummary.CurrentCell.Value = ((DataGridViewComboBoxEditingControl)sender).EditingControlFormattedValue;
            }
        }

        private void grdWorkSummary_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Projects
            var cell = ((DataGridView)sender).CurrentCell;
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.Context.Projects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newProject = new Models.UserConfigurationProject()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.Context.Projects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.Context.Projects.Add(newProject);
                cell.Value = newProject.Name;
            }
            //Subprojects
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.Context.Subprojects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newSubProject = new Models.UserConfigurationSubproject()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.Context.Subprojects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.Context.Subprojects.Add(newSubProject);
                cell.Value = newSubProject.Name;
            }
            //Tasks
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.Context.Tasks.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newTask = new Models.UserConfigurationTask()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.Context.Tasks.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.Context.Tasks.Add(newTask);
                cell.Value = newTask.Name;
            }
            //Locations
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.Context.Locations.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newLocation = new Models.UserConfigurationLocation()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.Context.Locations.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.Context.Locations.Add(newLocation);
                cell.Value = newLocation.Name;
            }
        }
    }
}