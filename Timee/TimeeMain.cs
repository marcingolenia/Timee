using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timee.Controls;
using Timee.DAL;
using Timee.Hotkeys;
using Timee.Models;
using Timee.Plugins.LGBSExcelExport;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        /// <summary>
        /// Used in drag&drop
        /// </summary>
        private int rowIndexFromMouseDown { get; set; }
        /// <summary>
        /// Hold context data
        /// </summary>
        private TimeeContext context { get; set; }
        /// <summary>
        /// Current cell in which time is being counted.
        /// </summary>
        private DataGridViewCell currentTimeCell { get; set; }
        private readonly KeyboardHook hook = new KeyboardHook();

        //Custom event for handling rows removal
        public event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;

        //constructor
        public TimeeMain()
        {
            InitializeComponent();
            this.InitializeTrayElements();
            this.hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            //Show all records + shortcuts(or numbers)
            hook.RegisterHotKey(Hotkeys.ModifierKeys.Control, Keys.F11);
            //Add new row
            hook.RegisterHotKey(Hotkeys.ModifierKeys.Control, Keys.F12);
        }

        /// <summary>
        /// Initializes tray control.
        /// </summary>
        private void InitializeTrayElements()
        {
            // Create a tray icon.
            trayIcon.Text = this.Text;
            trayIcon.Icon = new Icon("Resources/timee.ico", 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = false;
        }

        // Events
        /// <summary>
        /// Main form loaded -> get data, init grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timee_Load(object sender, EventArgs e)
        {
            this.context = TimeeXMLService.Instance.LoadContext();
            cmbProject.DataSource = context.Projects;
            cmbTask.DataSource = context.Tasks;
            cmbSubProject.DataSource = context.Subprojects;
            cmbLocations.DataSource = context.Locations;
            grdWorkSummaryInit();
        }
        /// <summary>
        /// Handle hotkey combination press.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">KeyPressedEventArgs.</param>
        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            int? row = null;

            switch (e.Key)
            {
                case Keys.F1:
                    row = 0;
                    break;
                case Keys.F2:
                    row = 1;
                    break;
                case Keys.F3:
                    row = 2;
                    break;
                case Keys.F4:
                    row = 3;
                    break;
                case Keys.F5:
                    row = 4;
                    break;
                case Keys.F6:
                    row = 5;
                    break;
                case Keys.F7:
                    row = 6;
                    break;
                case Keys.F8:
                    row = 7;
                    break;
                case Keys.F9:
                    row = 8;
                    break;
                case Keys.F10:
                    row = 9;
                    break;
            }
            if (row.HasValue)
            {
                this.SwitchTimerToRow(row.Value);
                this.ShowTimerSwitchNotification();
            }
            else
            {
                switch (e.Key)
                {
                    case Keys.F11:
                        ShowTimerSummaryNotification();
                        break;
                    case Keys.F12:
                        QuickNewRow();
                        break;
                }
            }
        }
        /// <summary>
        /// Handling application exit via tray menu.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void trayMenu_OnExitSelected(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Bring back UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// Exit App from menu or tray icon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handle application resize.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void TimeeMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.trayIcon.Visible = true;
                this.ShowNotification("Timee", "Timee has been minimized to system tray", ToolTipIcon.Info, 500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                this.trayIcon.Visible = false;
            }
        }
        private void TimeeMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("All data will be lost, are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
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
            row.Time = TimeSpan.Zero;
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
            using (var dlgEdit = new TimeeEditDialog(this.context, component))
            {
                dlgEdit.ShowDialog();
                if (dlgEdit.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    TimeeXMLService.Instance.SaveContext(this.context);
                }
            }
        }
        /// <summary>
        /// Update cell value while counting time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {

            this.currentTimeCell.Value = ((TimeSpan)this.currentTimeCell.Value).Add(new TimeSpan(0, 0, 0, 0, timer.Interval));

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
                && (this.context.Projects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newProject = new Models.UserConfigurationProject()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.context.Projects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.context.Projects.Add(newProject);
                cell.Value = newProject.Name;
            }
            //Subprojects
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.context.Subprojects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newSubProject = new Models.UserConfigurationSubproject()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.context.Subprojects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.context.Subprojects.Add(newSubProject);
                cell.Value = newSubProject.Name;
            }
            //Tasks
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.context.Tasks.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newTask = new Models.UserConfigurationTask()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.context.Tasks.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.context.Tasks.Add(newTask);
                cell.Value = newTask.Name;
            }
            //Locations
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName
                && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
                && (this.context.Locations.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            {
                var newLocation = new Models.UserConfigurationLocation()
                {
                    Name = cell.EditedFormattedValue.ToString(),
                    Order = this.context.Locations.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.context.Locations.Add(newLocation);
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
            if (grdWorkSummary.Rows[e.RowIndex].Cells.Contains(currentTimeCell))
            {
                timer.Stop();
            }
            grdWorkSummary.Rows.RemoveAt(e.RowIndex);
            hook.UnregisterLastHotKey();
        }
        /// <summary>
        /// Neglect invalid data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
            if (rowIndexOfItemUnderMouseToDrop != dragSourceGridRow.Index && rowIndexOfItemUnderMouseToDrop > -1)
            {
                //Stop timer if user is draging row in which time is counting
                if (rowIndexFromMouseDown == currentTimeCell.RowIndex)
                {
                    btnPause_Click(null, EventArgs.Empty);
                }
                //Just check against possible another future drag effects.
                if (e.Effect == DragDropEffects.Move)
                {
                    ((TimeeDataSet.TimeSheetTableRow)(grdWorkSummary.Rows[rowIndexOfItemUnderMouseToDrop].DataBoundItem as DataRowView).Row).Time +=
                    dragSourceTypedRow.Time;
                    grdWorkSummary.Rows.RemoveAt(rowIndexFromMouseDown);
                    hook.UnregisterLastHotKey();
                }
            }
        }

        //Menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().Show();
        }
        //TODO: In version 2 handle this with some general plugin mechanism
        private void mnuExcelExport_Click(object sender, EventArgs e)
        {
            grdWorkSummary.EndEdit();
            DataRowCollection allEntries = this.timeeDataSet.TimeSheetTable.Rows;
            if (allEntries.Count > 0)
            {
                XlsExportManager exporter = new XlsExportManager();
                exporter.ExportAllEntries(allEntries);
            }
        }
        private void mnuSettings_Click(object sender, EventArgs e)
        {
            new ExcelExportSettings().ShowDialog();
        }

        //Methods
        /// <summary>
        /// Init grid comboboxes, set handlers for custom events, change behaviour.
        /// </summary>
        private void grdWorkSummaryInit()
        {
            this.grdWorkSummary.Columns[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].DefaultCellStyle.Format = "hh\\:mm\\:ss";
            this.timeeDataSet.TimeSheetTable.DateColumn.DefaultValue = DateTime.Today;
            this.timeeDataSet.TimeSheetTable.TimeColumn.DefaultValue = TimeSpan.Zero;


            foreach (DataGridViewColumn column in this.grdWorkSummary.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DataGridViewComboBoxColumn c;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName];
            c.DataSource = context.Projects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName];
            c.DataSource = context.Subprojects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName];
            c.DataSource = context.Tasks;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName];
            c.DataSource = context.Locations;

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

            int currentRowIndex = this.grdWorkSummary.Rows.Count - 1;
            this.currentTimeCell = grdWorkSummary.Rows[currentRowIndex]
                                                 .Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            //Enter edit mode on Project by default
            grdWorkSummary.CurrentCell = grdWorkSummary.Rows[currentTimeCell.RowIndex]
                                         .Cells[timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName];
            grdWorkSummary.BeginEdit(true);
            // Register key
            Keys keyToRegister = this.GetKeyByRowNumber(currentRowIndex);
            if (keyToRegister != Keys.None)
            {
                this.hook.RegisterHotKey(Timee.Hotkeys.ModifierKeys.Control, keyToRegister);
            }

            this.timer.Start();
        }
        /// <summary>
        /// Returns key (keyboard) representing given row number.
        /// </summary>
        /// <param name="rowNumber">Row index.</param>
        /// <returns>Keys.</returns>
        private Keys GetKeyByRowNumber(int rowNumber)
        {
            Keys key = Keys.None;
            switch (rowNumber)
            {
                case 0:
                    key = Keys.F1;
                    break;
                case 1:
                    key = Keys.F2;
                    break;
                case 2:
                    key = Keys.F3;
                    break;
                case 3:
                    key = Keys.F4;
                    break;
                case 4:
                    key = Keys.F5;
                    break;
                case 5:
                    key = Keys.F6;
                    break;
                case 6:
                    key = Keys.F7;
                    break;
                case 7:
                    key = Keys.F8;
                    break;
                case 8:
                    key = Keys.F9;
                    break;
                case 9:
                    key = Keys.F10;
                    break;
                default:
                    break;
            }
            return key;
        }
        /// <summary>
        /// Set time counting to specific row (used in deleting/adding/double click row).
        /// </summary>
        /// <param name="rowIndex"></param>
        private void SwitchTimerToRow(int rowIndex)
        {
            this.currentTimeCell = grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            if (!timer.Enabled)
            {
                timer.Enabled = true;
            }
        }
        /// <summary>
        /// Show notification message
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ShowTimerSwitchNotification()
        {
            var rowIndex = this.currentTimeCell.RowIndex;
            var currentRow = grdWorkSummary.Rows[rowIndex];
            if (currentRow != null)
            {
                string projectName = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName].Value;
                string subProjectName = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName].Value;
                string comment = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.CommentColumn.ColumnName].Value;
                TimeSpan time = (TimeSpan)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].Value;
                string notificationText = string.Format("Timer has been switched to:{0} {1} - {2} - '{3}' ({4:hh\\:mm\\:ss}).", new object[] { Environment.NewLine, projectName, subProjectName, comment, time });
                this.ShowNotification("Timee", notificationText, ToolTipIcon.Info, 500);
            }
        }
        /// <summary>
        /// Show possible switches
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ShowTimerSummaryNotification()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in grdWorkSummary.Rows)
            {
                var typedRow = (TimeeDataSet.TimeSheetTableRow)(row.DataBoundItem as DataRowView).Row;
                sb.AppendFormat("{0}. {1} | {2} | {3}", row.Index, typedRow.Project, typedRow.Task, typedRow.Comment);
                sb.AppendLine();
            }
            this.ShowNotification("Timee", sb.ToString(), ToolTipIcon.Info, 1500);
        }
        /// <summary>
        /// Show possible switches
        /// </summary>
        /// <param name="rowIndex"></param>
        private void QuickNewRow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            TimeeDataSet.TimeSheetTableRow row = this.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
            row.Date = DateTime.Today;
            AddNewRow(row);
        }
        /// <summary>
        /// Shows baloon tooltip in system tray.
        /// </summary>
        /// <param name="title">Tooltip title.</param>
        /// <param name="text">Tooltip text.</param>
        /// <param name="icon">Tooltip icon.</param>
        /// <param name="showTime">Time to show.</param>
        private void ShowNotification(string title, string text, ToolTipIcon icon, int showTime)
        {
            this.trayIcon.BalloonTipTitle = title;
            this.trayIcon.BalloonTipText = text;
            this.trayIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.trayIcon.ShowBalloonTip(showTime);
        }
    }
}