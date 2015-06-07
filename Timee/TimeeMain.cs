using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Timee.DAL;
using Timee.Models;
using Timee.Tools;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        //Fields + props
        private int rowIndexFromMouseDown;

        private DataGridViewCell CurrentTimeCell
        {
            get; set;
        }
        public TimeeContext Context;
        //Custom event for handling rows removal
        public event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;
        //constructor
        public TimeeMain()
        {
            InitializeComponent();
            this.timeeDataSet.TimeSheetTable.DateColumn.DefaultValue = DateTime.Today;
            this.timeeDataSet.TimeSheetTable.TimeColumn.DefaultValue = 0;
            this.grdWorkSummary.Columns[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].DefaultCellStyle.Format = "0";
        }

        //Events
        /// <summary>
        /// Main form loaded -> get data, init grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timee_Load(object sender, EventArgs e)
        {
            this.Context = TimeeXMLService.Instance.LoadContext();
            cmbProject.DataSource = Context.Projects;
            cmbTask.DataSource = Context.Tasks;
            cmbSubProject.DataSource = Context.Subprojects;
            grdWorkSummaryInit();
        }

        //--GUI besides grid
        /// <summary>
        /// Start counting time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            TimeeDataSet.TimeSheetTableRow row = this.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
            row.Comment = this.tbComment.Text;
            row.Date = this.dpWorkDate.Value;
            row.Project = this.cmbProject.Text;
            row.SubProject = this.cmbSubProject.Text;
            row.Task = this.cmbTask.Text;
            row.Time = 0;
            row.Location = this.cmbLocations.Text;
            AddNewRow(row);
            this.btnPause.Enabled = true;
            this.btnPause.Text = "Pause";
        }
        /// <summary>
        /// Pause time counting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.timer.Enabled)
            {
                this.timer.Stop();
                this.btnPause.Text = "Resume";
            }
            else
            {
                this.timer.Start();
                this.btnPause.Text = "Pause";
            }
        }
        /// <summary>
        /// Edit selected List.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Export grid data to Excel sheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToXlsButton_Click(object sender, EventArgs e)
        {
            DataRowCollection allEntries = this.timeeDataSet.TimeSheetTable.Rows;
            XlsExportManager exporter = new XlsExportManager();
            exporter.ExportAllEntries(allEntries);
        }
        /// <summary>
        /// Update cell value while counting time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {

            this.CurrentTimeCell.Value = (double)this.CurrentTimeCell.Value + ((double)timer.Interval / 1000);

            //DateTime dt = DateTime.ParseExact("0800", "HHmm", CultureInfo.InvariantCulture);
        }

        //--Grid events
        /// <summary>
        /// Attaching events for controls placed in the grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (grdWorkSummary.CurrentCell.RowIndex == grdWorkSummary.Rows.Count - 1 &&
                grdWorkSummary.CurrentCell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.CommentColumn.ColumnName)
            {
                e.Control.PreviewKeyDown -= CommentCell_PreviewKeyDown;
                e.Control.PreviewKeyDown += CommentCell_PreviewKeyDown;
            }
        }
        /// <summary>
        /// Handling delete-button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGridRemoveRow(object sender, EventArgs e)
        {
            grdWorkSummary.Rows.RemoveAt(grdWorkSummary.CurrentCell.RowIndex);
        }
        /// <summary>
        /// Comment is last column, so let's add new row after pressing Tab or Enter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentCell_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                AddNewRow();
            }
        }
        /// <summary>
        /// Handling editable comboboxes - Tab key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridCmb_KeyPress(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                grdWorkSummary.EndEdit();
                grdWorkSummary.CurrentCell.Value = ((DataGridViewComboBoxEditingControl)sender).EditingControlFormattedValue;
            }
        }
        /// <summary>
        /// Handling editable comboboxes - Adding new values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Setting time counting on clicked row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SwitchTimerToRow(e.RowIndex);
        }
        /// <summary>
        /// Trigger btnDeleteRowClicked event if cell is button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdWorkSummary.Columns[e.ColumnIndex].Name == "Remove")
            {
                btnDeleteRowClicked(sender, e);
            }
        }
        /// <summary>
        /// Handle btnDeleteRowClicked custom event for deleting rows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeeMain_btnDeleteRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (grdWorkSummary.Rows[e.RowIndex].Cells.Contains(CurrentTimeCell))
            {
                timer.Stop();
            }
            grdWorkSummary.Rows.RemoveAt(e.RowIndex);
        }

        //--Grid drag and drop
        /// <summary>
        /// Imitates left mouse hold left button, passes data to drag argruments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && grdWorkSummary.SelectedRows.Count == 1)
            {
                rowIndexFromMouseDown = grdWorkSummary.SelectedRows[0].Index;
                grdWorkSummary.DoDragDrop(grdWorkSummary.SelectedRows[0], DragDropEffects.Move);
            }
        }
        /// <summary>
        /// Defines what should happen on drag start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_DragEnter(object sender, DragEventArgs e)
        {
            if (grdWorkSummary.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        /// <summary>
        /// Copies time from source row to destination row, removes source row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_DragDrop(object sender, DragEventArgs e)
        {
            DataGridViewRow dragSourceGridRow = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
            TimeeDataSet.TimeSheetTableRow dragSourceTypedRow =
                (TimeeDataSet.TimeSheetTableRow)(dragSourceGridRow.DataBoundItem as DataRowView).Row;

            Point clientPoint = grdWorkSummary.PointToClient(new Point(e.X, e.Y));
            int rowIndexOfItemUnderMouseToDrop = grdWorkSummary.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            //No, drag to self is not possible :)
            if (rowIndexOfItemUnderMouseToDrop != dragSourceGridRow.Index)
            {
                //Stop timer if user is draging row in which time is counting
                if (rowIndexFromMouseDown == CurrentTimeCell.RowIndex)
                {
                    btnPause_Click(null, EventArgs.Empty);
                }
                //Just check against possible another future drag effects.
                if (e.Effect == DragDropEffects.Move)
                {
                    ((TimeeDataSet.TimeSheetTableRow)(grdWorkSummary.Rows[rowIndexOfItemUnderMouseToDrop].DataBoundItem as DataRowView).Row).Time +=
                    dragSourceTypedRow.Time;
                    grdWorkSummary.Rows.RemoveAt(rowIndexFromMouseDown);
                }
            }
        }

        //Methods
        /// <summary>
        /// Init grid comboboxes, set handlers for custom events, change behaviour.
        /// </summary>
        private void grdWorkSummaryInit()
        {
            foreach (DataGridViewColumn column in this.grdWorkSummary.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DataGridViewComboBoxColumn c;
            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName];
            c.DataSource = Context.Projects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName];
            c.DataSource = Context.Subprojects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName];
            c.DataSource = Context.Tasks;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName];
            c.DataSource = Context.Locations;

            btnDeleteRowClicked += TimeeMain_btnDeleteRowClicked;
        }
        /// <summary>
        /// Add new row with default values or a predefined one.
        /// </summary>
        /// <param name="row">TimeSheetTableRow</param>
        private void AddNewRow(TimeeDataSet.TimeSheetTableRow row = null)
        {
            if (row == null)
            {
                row = timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
                this.timeeDataSet.TimeSheetTable.AddTimeSheetTableRow(row);
            }
            else
            {
                this.timeeDataSet.TimeSheetTable.AddTimeSheetTableRow(row);
            }
            this.CurrentTimeCell = grdWorkSummary.Rows[this.grdWorkSummary.Rows.Count - 1]
                                                 .Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            this.timer.Start();

        }
        /// <summary>
        /// Set time counting to specific row (used in deleting/adding/double click row).
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SwitchTimerToRow(int rowIndex)
        {
            this.CurrentTimeCell = grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            if (!timer.Enabled)
            {
                timer.Enabled = true;
            }
        }
    }
}