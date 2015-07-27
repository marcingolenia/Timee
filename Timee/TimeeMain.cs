using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timee.DAL;
using Timee.Models;
using Timee.Plugins.LGBSExcelExport;
using Timee.Dialogs;
using AutoUpdaterDotNET;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Timee.Services;
using Timee.Services.Hotkeys;

namespace Timee
{
    public partial class TimeeMain : Form
    {
        /// <summary>
        /// Used in drag&drop
        /// </summary>
        private int RowIndexFromMouseDown { get; set; }
        /// <summary>
        /// Used in Alarm
        /// </summary>
        private AlarmService alarmService;

        /// <summary>
        /// Used to save task as predefined task
        /// </summary>
        public static List<TimeeDataSet.TimeSheetTableRow> newPredefinedTasks;
        /// <summary>
        /// used to load plugins
        /// </summary>
        [ImportMany(typeof(TimeeBridge.IExcell))]
        IEnumerable<Lazy<TimeeBridge.IExcell, TimeeBridge.IMetaData>> _excellPlugins;
        [ImportMany(typeof(TimeeBridge.IContext))]
        IEnumerable<Lazy<TimeeBridge.IContext, TimeeBridge.IMetaData>> _contextPlugins;
        /// <summary>
        /// Hold context data
        /// </summary>
        private TimeeContext Context { get; set; }
        /// <summary>
        /// Current cell in which time is being counted.
        /// </summary>
        private DataGridViewCell CurrentTimeCell { get; set; }
        //private DataGridViewCell TmpCurrentTimeCell { get; set; }
        private readonly KeyboardHook hook = new KeyboardHook();
        public TimeeMain()
        {
            InitializeComponent();
            this.InitializeTrayElements();
            this.hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            //Show all records + shortcuts(or numbers)
            hook.RegisterHotKey(Timee.Services.Hotkeys.ModifierKeys.Control, Keys.F11);
            //Add new row
            hook.RegisterHotKey(Timee.Services.Hotkeys.ModifierKeys.Control, Keys.F12);
            //Hints
        }

        //Events
        /// <summary>
        /// Main form loaded -> get data, init grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Timee_Load(object sender, EventArgs e)
        {
            //Prevent from losting saved tasks after update
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
            // Difine Catalog to load plugins
            DirectoryCatalog dirCatalog = new DirectoryCatalog("Plugins");
            CompositionContainer container = new CompositionContainer(dirCatalog);
            container.SatisfyImportsOnce(this);
            // Create new plugin position in menu
            foreach (Lazy<TimeeBridge.IExcell, TimeeBridge.IMetaData> excellPlugin in _excellPlugins)
            {
                
                
                ToolStripMenuItem excell = new ToolStripMenuItem(excellPlugin.Metadata.Name);
                excell.Name = excellPlugin.Metadata.Name;
                excell.Click += new EventHandler(menuPluginClick);

                menuExcell.DropDownItems.Insert(menuExcell.DropDownItems.Count, excell);
            }
            foreach (Lazy<TimeeBridge.IContext, TimeeBridge.IMetaData> contextPlugin in _contextPlugins)
            {


                ToolStripMenuItem context = new ToolStripMenuItem(contextPlugin.Metadata.Name);
                context.Name = contextPlugin.Metadata.Name;
                context.Click += new EventHandler(menuPluginClick);

                menuContext.DropDownItems.Insert(menuContext.DropDownItems.Count, context);
            }

            Assembly mainAssembly = Assembly.GetEntryAssembly();
            this.Context = TimeeXMLService.Instance.LoadContext();
            cmbProject.DataSource = Context.Projects;
            cmbTask.DataSource = Context.Tasks;
            cmbSubProject.DataSource = Context.Subprojects;
            cmbLocations.DataSource = Context.Locations;
            grdWorkSummaryInit();
            this.Text = "Timee v."+ mainAssembly.GetName().Version.ToString();

            //checking if there is new version
            AutoUpdater.CurrentCulture = CultureInfo.CreateSpecificCulture("en");
            AutoUpdater.Start("https://raw.githubusercontent.com/marcingolenia/Timee/master/Timee/timee.xml");

            //Load saved tasks
            StringReader mainTasksXml = new StringReader(Properties.Settings.Default.MainTasks);
            UserConfiguration testUser = new UserConfiguration();
            if (!(Properties.Settings.Default.MainTasks.Length == 0))
            {
               timeeDataSet.ReadXml(mainTasksXml);
               grdWorkSummary.DataSource = timeeDataSet;
               grdWorkSummary.DataMember = "TimeSheetTable";
               this.CurrentTimeCell = grdWorkSummary.Rows[0].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
               btnPause.Enabled = true;
               this.btnPause.Text = "Resume";
                
            //register hotkeys to previous saved tasks
                for (int row = 0; row < grdWorkSummary.Rows.Count; row++)
			    {
			      Keys keyToRegister = this.GetKeyByRowNumber(row);
                       if (keyToRegister != Keys.None)
                       {
                           this.hook.RegisterHotKey(Timee.Services.Hotkeys.ModifierKeys.Control, keyToRegister);
                       }
			    }
            }
           
            //Show help
        }
        /// <summary>
        /// Show hints
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeeMain_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ShowHints)
            {
                new Dialogs.Help().ShowDialog();
            }
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
                this.ShowNotification("Timee", "Timee has been minimized to system tray", ToolTipIcon.Info, 500);
                this.Hide();
            }
        }
        /// <summary>
        /// Confirm Exit without saving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeeMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            TimeeXMLService.Instance.SavePredefinedTasks(this.Context.PredefinedTasks);
            if ((timeeDataSet.Tables.Count > 0) && (timeeDataSet.Tables[0].Rows.Count > 0))
            {
                var result = MessageBox.Show("Save your data?", "Exit", MessageBoxButtons.YesNo);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Properties.Settings.Default.MainTasks = timeeDataSet.GetXml();
                    Properties.Settings.Default.Save();
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    Properties.Settings.Default.MainTasks = null;
                    Properties.Settings.Default.Save();

                }
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
        /// Open table with PredefinedTasks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dlg = new PredefinedTasksDialog(this.Context))
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    TimeeDataSet.TimeSheetTableRow row = timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
                    row.Comment = dlg.Row.Comment;
                    row.Date = DateTime.Today;
                    row.Project = dlg.Row.Project;
                    row.SubProject = dlg.Row.SubProject;
                    row.Task = dlg.Row.Task;
                    row.Time = TimeSpan.Zero;
                    row.Location = dlg.Row.Location;
                    AddNewRow(row);
                }
            }
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
                else if (dlgEdit.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Context = TimeeXMLService.Instance.LoadContext();

                    cmbProject.DataSource = Context.Projects;
                    cmbTask.DataSource = Context.Tasks;
                    cmbSubProject.DataSource = Context.Subprojects;
                    cmbLocations.DataSource = Context.Locations;
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
            this.CurrentTimeCell.Value = ((TimeSpan)this.CurrentTimeCell.Value).Add(new TimeSpan(0, 0, 0, 0, timer.Interval));

            //Update Time Summary.
            TimeSpan tmpSummary = new TimeSpan(timeeDataSet.TimeSheetTable.Sum(r => r.Time.Duration().Ticks));
            lblTimeSummaryResult.Text = tmpSummary.ToString(@"hh\:mm\:ss");
            if (tmpSummary.Minutes % 5 == 0)
            {
                Properties.Settings.Default.MainTasks = timeeDataSet.GetXml();
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// Allow users to add Project at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProject_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbProject.Text) &&
                !Context.Projects.Select(p => p.Name).Contains(cmbProject.Text))
            {
                var newProject = new Models.UserConfigurationProject()
                {
                    Name = cmbProject.Text.ToString(),
                    Order = this.Context.Projects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                Context.Projects.Add(newProject);
                cmbProject.SelectedItem = newProject;
            }
        }
        /// <summary>
        /// Allow users to add SubProject at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSubProject_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbSubProject.Text) &&
                !Context.Projects.Select(p => p.Name).Contains(cmbSubProject.Text))
            {
                var newSubProject = new Models.UserConfigurationSubproject()
                {
                    Name = cmbSubProject.Text.ToString(),
                    Order = this.Context.Subprojects.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                Context.Subprojects.Add(newSubProject);
                cmbSubProject.SelectedItem = newSubProject;
            }
        }
        /// <summary>
        /// Allow users to add Task at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTask_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbTask.Text) &&
                !Context.Tasks.Select(p => p.Name).Contains(cmbTask.Text))
            {
                var newTask = new Models.UserConfigurationTask()
                {
                    Name = cmbSubProject.Text.ToString(),
                    Order = this.Context.Tasks.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                Context.Tasks.Add(newTask);
                cmbSubProject.SelectedItem = newTask;
            }
        }
        /// <summary>
        /// Allow users to add Location at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLocations_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbLocations.Text) &&
    !Context.Locations.Select(p => p.Name).Contains(cmbLocations.Text))
            {
                var newLocation = new Models.UserConfigurationLocation()
                {
                    Name = cmbSubProject.Text.ToString(),
                    Order = this.Context.Locations.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                Context.Locations.Add(newLocation);
                cmbSubProject.SelectedItem = newLocation;
            }
        }

        //--Grid events
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
                    Order = this.Context.Projects.Count == 0 ? 1 : this.Context.Projects.Max(p => p.Order) + 1,
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
                    Order =  this.Context.Subprojects.Count == 0 ? 1 : this.Context.Subprojects.Max(p => p.Order) + 1,
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
                    Order = this.Context.Tasks.Count == 0 ? 1 : this.Context.Tasks.Max(p => p.Order) + 1,
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
                    Order = this.Context.Locations.Count == 0 ? 1 : this.Context.Locations.Max(p => p.Order) + 1,
                    OrderSpecified = true
                };
                this.Context.Locations.Add(newLocation);
                cell.Value = newLocation.Name;
            }
             //Time
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.TimeColumn.ColumnName)
            {
                TimeSpan dumb;
                if(TimeSpan.TryParse(cell.EditedFormattedValue.ToString(), out dumb) == false)
                {
                    cell.Value = new TimeSpan();
                    grdWorkSummary.CancelEdit();
                }
                //cell.EditedFormattedValue
            }
        }
        /// <summary>
        /// Setting time counting on double clicked row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SwitchTimerToRow(e.RowIndex);
        }
        /// <summary>
        /// Handle btnDeleteRowClicked custom event for deleting rows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_btnDeleteRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (grdWorkSummary.Rows[e.RowIndex].Cells.Contains(CurrentTimeCell))
            {
                timer.Stop();
            }
            if (grdWorkSummary.Rows.Count == 1)
            {
                btnPause.Enabled = false;
            }
            if (this.CurrentTimeCell.RowIndex == e.RowIndex)
            {
                btnPause.Text = "Resume";
            }
            grdWorkSummary.Rows.RemoveAt(e.RowIndex);


            hook.UnregisterLastHotKey();
        }
        /// <summary>
        /// Handle btnSaveRowClicked custom event for saving rows (adding them to predefinedTasks Table).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_btnSaveRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            TimeeDataSet.TimeSheetTableRow tmpPredefinedTask = Context.PredefinedTasks.TimeSheetTable.NewTimeSheetTableRow();
            var row = (TimeeDataSet.TimeSheetTableRow)((DataRowView)grdWorkSummary.Rows[e.RowIndex].DataBoundItem).Row;
            tmpPredefinedTask.ItemArray = row.ItemArray;

            Context.PredefinedTasks.TimeSheetTable.AddTimeSheetTableRow(tmpPredefinedTask);
            TimeeXMLService.Instance.SavePredefinedTasks(this.Context.PredefinedTasks);
           
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
                RowIndexFromMouseDown = grdWorkSummary.SelectedRows[0].Index;
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
                if (RowIndexFromMouseDown == CurrentTimeCell.RowIndex)
                {
                    SwitchTimerToRow(rowIndexOfItemUnderMouseToDrop);
                }
                //Just check against possible another future drag effects.
                if (e.Effect == DragDropEffects.Move)
                {
                    ((TimeeDataSet.TimeSheetTableRow)(grdWorkSummary.Rows[rowIndexOfItemUnderMouseToDrop].DataBoundItem as DataRowView).Row).Time +=
                    dragSourceTypedRow.Time;
                    grdWorkSummary.Rows.RemoveAt(RowIndexFromMouseDown);
                    hook.UnregisterLastHotKey();
                }
            }
        }

        //--Menuchyb
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().Show();
        }
        //TODO: In version 2 handle this with some general plugin mechanism
        private void menuPluginClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            var action = from plugin in _excellPlugins
                         where plugin.Metadata.Name == item.Name
                         select plugin;
            switch (action.First().Metadata.Type)
            {
                case "ExcellImport":
                    {
                       // StringReader tmpXml = new StringReader(action.First().Value.ImportXml(timeeDataSet.GetXml()));     
                        timeeDataSet.Tables[0].Merge(action.First().Value.ImportToExcell(timeeDataSet.Tables[0]));

                        break;
                    }
                case "ExcellExport":
                    {
                        action.First().Value.ExportFromExcell(timeeDataSet.GetXml());
                        break;
                    }
                case "ContextImport:":
                    {
                        break;
                    }
                case "ContextExport:":
                    {
                        break;
                    }
            }
        }
        private void mnuExcelExport_Click(object sender, EventArgs e)
        {
            //Check time validity, if some bullshit set 00:00:00.
            if(grdWorkSummary.CurrentCell.OwningColumn.Name == timeeDataSet.TimeSheetTable.TimeColumn.ColumnName)
            {
                TimeSpan dumb;
                if (TimeSpan.TryParse(grdWorkSummary.CurrentCell.EditedFormattedValue.ToString(), out dumb) == false)
                {
                    grdWorkSummary.CurrentCell.Value = new TimeSpan();
                }
            }
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
        /// <summary>
        /// Dialog for starting count-down alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countdownAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new AlarmDialog())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    this.alarmService = dlg.AlarmService;
                    this.alarmService.RemainingTimeInfoControl = this.lblAlarmValue;
                    this.alarmService.ActivationForm = this;
                    this.alarmService.StartCountDown();
                }
            }
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
            c.DataSource = Context.Projects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName];
            c.DataSource = Context.Subprojects;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName];
            c.DataSource = Context.Tasks;

            c = (DataGridViewComboBoxColumn)grdWorkSummary.Columns[this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName];
            c.DataSource = Context.Locations;
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
            this.CurrentTimeCell = grdWorkSummary.Rows[currentRowIndex]
                                                 .Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            //Enter edit mode on first cell by default
            grdWorkSummary.CurrentCell = grdWorkSummary.Rows[CurrentTimeCell.RowIndex]
                                         .Cells[0];
            grdWorkSummary.BeginEdit(true);
            // Register key
            Keys keyToRegister = this.GetKeyByRowNumber(currentRowIndex);
            if (keyToRegister != Keys.None)
            {
                this.hook.RegisterHotKey(Timee.Services.Hotkeys.ModifierKeys.Control, keyToRegister);
            }

            this.timer.Start();
            this.btnPause.Text = "Pause";
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
            this.CurrentTimeCell = grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName];
            if (!timer.Enabled)
            {
                timer.Enabled = true;
                this.btnPause.Text = "Pause";
            }
        }
        /// <summary>
        /// Show notification message
        /// </summary>
        /// <param name="rowIndex"></param>
        private void ShowTimerSwitchNotification()
        {
            var rowIndex = this.CurrentTimeCell.RowIndex;
            var currentRow = grdWorkSummary.Rows[rowIndex];
            if (currentRow != null)
            {
                string projectName = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName].Value;
                string subProjectName = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName].Value;
                string comment = (string)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.CommentColumn.ColumnName].Value;
                TimeSpan time = (TimeSpan)grdWorkSummary.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].Value;
                string notificationText = string.Format("Timer has been switched to:{0}{1}. {2} - {3} - '{4}' ({5:hh\\:mm\\:ss}).", new object[] {Environment.NewLine, rowIndex + 1 , projectName, subProjectName, comment, time});
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
                sb.AppendFormat("{0}. {1} | {2} | {3} | {4}", row.Index + 1, typedRow.Project, typedRow.Task, typedRow.Comment, typedRow.Time.ToString("hh':'mm':'ss"));
                sb.AppendLine();
            }
            this.ShowNotification("Timee", sb.ToString(), ToolTipIcon.Info, 1500);
        }
        /// <summary>
        /// CTRL + F12 by default -> Quickly create new empty row.
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
            if (!String.IsNullOrWhiteSpace(text))
            {
                this.trayIcon.BalloonTipTitle = title;
                this.trayIcon.BalloonTipText = text;
                this.trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                this.trayIcon.ShowBalloonTip(showTime);
            }
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
        }
    }
}