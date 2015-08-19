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
        /// Hold context data
        /// </summary>
        private TimeeContext Context { get; set; }
        /// <summary>
        /// Current cell in which time is being counted.
        /// </summary>
        private DataGridViewCell CurrentTimeCell { get; set; }
        //private DataGridViewCell TmpCurrentTimeCell { get; set; }
        private readonly KeyboardHook hook = new KeyboardHook();

        private string parent = "";
        private string parentId = "";
        public TimeeMain()
        {
            InitializeComponent();
            this.InitializeTrayElements();
            this.hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(this.hook_KeyPressed);
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
            HotkeysService.Instance.InitializeKeys();

            //Prevent from losting saved tasks after update
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
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
            AutoUpdater.Start("https://github.com/marcingolenia/Timee/releases/download/new/timee.xml");

            //Load saved tasks
            StringReader mainTasksXml = new StringReader(Properties.Settings.Default.MainTasks);
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
                    HotkeysService.Instance.RegisterKey(hook, row);
			    }
            }
           
            //Show help
            PluginsService initializePlugins = new PluginsService(this, this.Context);
            initializePlugins.InitializeMenu(mnu);

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
            

            
                string action = HotkeysService.Instance.KeysMap
                    .Where(k => (Keys)Enum.Parse(typeof(Keys), k.KeyName) == e.Key)
                    .Select(k => k.Action).FirstOrDefault();
                switch (action)
                {
                    case "Switch":
                        row = HotkeysService.Instance.KeysMap
                            .Where(k => (Keys)Enum.Parse(typeof(Keys), k.KeyName) == e.Key)
                            .Select(v => v.RowId).FirstOrDefault();
                        this.SwitchTimerToRow(row.Value);
                            NotificationService.Instance.ShowTimerSwitchNotification
                                (this.CurrentTimeCell.RowIndex,grdWorkSummary,timeeDataSet);
                        break;
                    case "Show Summary":
                        NotificationService.Instance.ShowTimerSummaryNotification(grdWorkSummary);
                        break;
                    case "Add new row":
                        QuickNewRow();
                        break;
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
                NotificationService.Instance.SimpleNotification("Timee", "Timee has been minimized to system tray");
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
            else
            {
                Properties.Settings.Default.MainTasks = null;
                Properties.Settings.Default.Save();
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
            {
                using (var dlg = new Dialogs.TimeeItemsDialog(this))
                {
                    dlg.Context = this.Context;
                    dlg.ShowDialog();
                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        //try
                        //{
                        //    TimeeDataSet.TimeSheetTableRow row = this.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
                        //    row.Comment = this.tbComment.Text;
                        //    row.Date = this.dpWorkDate.Value;
                        //    row.Project = dlg.Project.Name;
                        //    row.SubProject = dlg.SubProject.Name;
                        //    row.Task = dlg.Task.Name;
                        //    row.Time = TimeSpan.Zero;
                        //    row.Location = dlg.Location.Name;
                        //    AddNewRow(row);
                        //    this.btnPause.Enabled = true;
                        //    this.btnPause.Text = "Pause";
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("Incomplete Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}


                    }
                }
            }
            
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
        //private void btnConfigureComponent_Click(object sender, EventArgs e)
        //{
        //    TimeeComponentType component = TimeeComponentType.Undefined;
        //    if (sender.Equals(btnProject))
        //    {
        //        component = TimeeComponentType.Project;
        //    }
        //    else if (sender.Equals(btnSubProject))
        //    {
        //        component = TimeeComponentType.Subproject;
        //    }
        //    else if (sender.Equals(btnTask))
        //    {
        //        component = TimeeComponentType.Task;
        //    }
        //    else if (sender.Equals(btnAddRow))
        //    {

        //        component = TimeeComponentType.Location;
        //    }
        //    using (var dlgEdit = new TimeeEditDialog(this.Context, component))
        //    {
        //        dlgEdit.ShowDialog();
        //        if (dlgEdit.DialogResult == System.Windows.Forms.DialogResult.OK)
        //        {
        //            TimeeXMLService.Instance.SaveContext(this.Context);
        //            this.Context.ResetAllBindings();
        //        }
        //        else if (dlgEdit.DialogResult == System.Windows.Forms.DialogResult.Cancel)
        //        {
        //            this.Context = TimeeXMLService.Instance.LoadContext();

        //            cmbProject.DataSource = Context.Projects;
        //            cmbTask.DataSource = Context.Tasks;
        //            cmbSubProject.DataSource = Context.Subprojects;
        //            cmbLocations.DataSource = Context.Locations;
        //        }
        //    }
        //}
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
            //if (!String.IsNullOrEmpty(cmbProject.Text) &&
            //    !Context.Projects.Select(p => p.Name).Contains(cmbProject.Text))
            //{
            //    var newProject = new Models.UserConfigurationProject()
            //    {
            //        Name = cmbProject.Text.ToString(),
            //        Order = this.Context.Projects.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    Context.Projects.Add(newProject);
            //    cmbProject.SelectedItem = newProject;
            //}
            if (!Context.Projects.Any(p => p.Name.Equals(cmbProject.Text)))
            {
                cmbProject.SelectedItem = Context.Projects.FirstOrDefault();
            }
        }
        /// <summary>
        /// Allow users to add SubProject at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSubProject_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(cmbSubProject.Text) &&
            //    !Context.Projects.Select(p => p.Name).Contains(cmbSubProject.Text))
            //{
            //    var newSubProject = new Models.UserConfigurationSubproject()
            //    {
            //        Name = cmbSubProject.Text.ToString(),
            //        Order = this.Context.Subprojects.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    Context.Subprojects.Add(newSubProject);
            //    cmbSubProject.SelectedItem = newSubProject;
            //}
            if (!Context.Subprojects.Any(p => p.Name.Equals(cmbSubProject.Text)))
            {
                cmbSubProject.SelectedItem = Context.Subprojects.FirstOrDefault();
            }
        }
        /// <summary>
        /// Allow users to add Task at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTask_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(cmbTask.Text) &&
            //    !Context.Tasks.Select(p => p.Name).Contains(cmbTask.Text))
            //{
            //    var newTask = new Models.UserConfigurationTask()
            //    {
            //        Name = cmbSubProject.Text.ToString(),
            //        Order = this.Context.Tasks.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    Context.Tasks.Add(newTask);
            //    cmbSubProject.SelectedItem = newTask;
            //}
            if (!Context.Tasks.Any(p => p.Name.Equals(cmbTask.Text)))
            {
                cmbTask.SelectedItem = Context.Tasks.FirstOrDefault();
            }
        }
        /// <summary>
        /// Allow users to add Location at edit-time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbLocations_Validating(object sender, CancelEventArgs e)
        {
    //        if (!String.IsNullOrEmpty(cmbLocations.Text) &&
    //!Context.Locations.Select(p => p.Name).Contains(cmbLocations.Text))
    //        {
    //            var newLocation = new Models.UserConfigurationLocation()
    //            {
    //                Name = cmbSubProject.Text.ToString(),
    //                Order = this.Context.Locations.Max(p => p.Order) + 1,
    //                OrderSpecified = true
    //            };
    //            Context.Locations.Add(newLocation);
    //            cmbSubProject.SelectedItem = newLocation;
    //        }
            if (!Context.Locations.Any(p => p.Name.Equals(cmbLocations.Text)))
            {
                cmbLocations.SelectedItem = Context.Locations.FirstOrDefault();
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
                && this.Context.Projects.Any(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())))
            {
                cell.Value = this.Context.Projects.Where(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())).Select(p => p.Name).FirstOrDefault();
                parent = cell.Value.ToString();
            }
            //    && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
            //    && (this.Context.Projects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            //{
            //    var newProject = new Models.UserConfigurationProject()
            //    {
            //        Name = cell.EditedFormattedValue.ToString(),
            //        Order = this.Context.Projects.Count == 0 ? 1 : this.Context.Projects.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    this.Context.Projects.Add(newProject);
            //    cell.Value = newProject.Name;
            //}
            ////Subprojects
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName
                && this.Context.Subprojects.Any(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())))
            {
                cell.Value = this.Context.Subprojects.Where(p=>p.Parent == parent).Where(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())).Select(s => s.Name).FirstOrDefault();
                parentId = this.Context.Subprojects.Where(p => p.Parent == parent).Where(p=>p.Name == cell.Value.ToString()).Select(p => p.Value).FirstOrDefault();                
                parent = cell.Value.ToString();
            }
            //    && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
            //    && (this.Context.Subprojects.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            //{
            //    var newSubProject = new Models.UserConfigurationSubproject()
            //    {
            //        Name = cell.EditedFormattedValue.ToString(),
            //        Order =  this.Context.Subprojects.Count == 0 ? 1 : this.Context.Subprojects.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    this.Context.Subprojects.Add(newSubProject);
            //    cell.Value = newSubProject.Name;
            //}
            ////Tasks
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.TaskColumn.ColumnName
                && this.Context.Tasks.Any(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())))
            {
                cell.Value = this.Context.Tasks.Where(p=>p.ParentId == parentId).Where(p=> p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())).Select(t => t.Name).FirstOrDefault();
            }
            //    && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
            //    && (this.Context.Tasks.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            //{
            //    var newTask = new Models.UserConfigurationTask()
            //    {
            //        Name = cell.EditedFormattedValue.ToString(),
            //        Order = this.Context.Tasks.Count == 0 ? 1 : this.Context.Tasks.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    this.Context.Tasks.Add(newTask);
            //    cell.Value = newTask.Name;
            //}
            ////Locations
            if (cell.OwningColumn.Name == this.timeeDataSet.TimeSheetTable.LocationColumn.ColumnName
                 && this.Context.Locations.Any(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())))
            {
                cell.Value = this.Context.Locations.Where(p => p.Name.ToLower().Equals(cell.EditedFormattedValue.ToString().ToLower())).Select(l => l.Name).FirstOrDefault();
            }
            //    && !String.IsNullOrWhiteSpace(cell.EditedFormattedValue.ToString())
            //    && (this.Context.Locations.Where(p => p.Name == cell.EditedFormattedValue.ToString()).Count() < 1))
            //{
            //    var newLocation = new Models.UserConfigurationLocation()
            //    {
            //        Name = cell.EditedFormattedValue.ToString(),
            //        Order = this.Context.Locations.Count == 0 ? 1 : this.Context.Locations.Max(p => p.Order) + 1,
            //        OrderSpecified = true
            //    };
            //    this.Context.Locations.Add(newLocation);
            //    cell.Value = newLocation.Name;
            //}
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
        /// Turn on AutoComplete to grdWorkSummary comboboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;

            }
        }
        /// <summary>
        /// Changing comboboxes Datasource to match selected project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdWorkSummary_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
           
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                var cellValue = ((DataGridView)sender).CurrentCell;
                var taskCell = dgv[e.ColumnIndex + 2, e.RowIndex] as DataGridViewComboBoxCell;
                if (cell == null) return;

                cell.DataSource = Context.Subprojects.Where(s => s.ParentId == Context.Projects.Where(p=>p.Name == cellValue.Value.ToString()).Select(p=>p.Value).FirstOrDefault()).Select(s => s).ToList();
                cell.DisplayMember = "Name";
                taskCell.DataSource = Context.Tasks.Where(s => s.ParentId == Context.Subprojects.Where(p=>p.Name == cell.Value.ToString()).Select(p=>p.Value).FirstOrDefault()).Select(s => s).ToList();
                taskCell.DisplayMember = "Name";
                if (cell.Items.Count == 0)
                {
                    cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                    cell.DataSource = null;
                    cell.Value = "";
                }
            }
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                var cell = dgv[e.ColumnIndex + 1, e.RowIndex] as DataGridViewComboBoxCell;
                var cellValue = ((DataGridView)sender).CurrentCell;
                if (cell == null) return;

                cell.DataSource = Context.Tasks.Where(s => s.ParentId == Context.Subprojects.Where(p => p.Name == cellValue.Value.ToString()).Select(p => p.Value).FirstOrDefault()).Select(s => s).ToList();
                cell.DisplayMember = "Name";
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
        //--Menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutDialog().Show();
        }
        /// <summary>
        /// Dialog for starting count-down alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void countdownAlertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new AlarmDialog(((ToolStripMenuItem)mnu.Items[1]).DropDownItems))
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
        public void AddNewRow(TimeeDataSet.TimeSheetTableRow row = null)
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
            HotkeysService.Instance.RegisterKey(this.hook, currentRowIndex);

            this.timer.Start();
            this.btnPause.Text = "Pause";
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
        /// CTRL + F12 by default -> Quickly create new empty row.
        /// </summary>
        /// <param name="rowIndex"></param>
        private void QuickNewRow()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            TimeeDataSet.TimeSheetTableRow row = this.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
            row.Date = DateTime.Today;
            row.Project = "";
            row.SubProject = "";
            row.Task = "";
            row.Comment = "";
            row.Location = "";
            AddNewRow(row);
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

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubProject.DataSource = Context.Subprojects.Where(s => s.ParentId == Context.Projects.Where(p=>p.Name ==cmbProject.Text).Select(p=>p.Value).FirstOrDefault()).Select(s => s).ToList();
            cmbSubProject.DisplayMember = "Name";

            if (cmbSubProject.Items.Count == 0)
            {
                cmbTask.DataSource = null;
                cmbSubProject.Text = "";
            }
        }

        private void cmbSubProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTask.DataSource = Context.Tasks.Where(s => s.ParentId == Context.Subprojects.Where(p => p.Name == cmbSubProject.Text).Select(p => p.Value).FirstOrDefault()).Select(s => s).ToList();
            cmbTask.DisplayMember = "Name";
        }

        private void hotKeysSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new HotKeysDialog())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    for (int i = 0; i < grdWorkSummary.Rows.Count; i++)
                    {
                        hook.UnregisterLastHotKey();
                    }
                    for (int i = 0; i < grdWorkSummary.Rows.Count; i++)
                    {
                        HotkeysService.Instance.RegisterKey(hook, i);
                    }
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                TimeeDataSet.TimeSheetTableRow row = this.timeeDataSet.TimeSheetTable.NewTimeSheetTableRow();
                row.Comment = this.tbComment.Text;
                row.Date = this.dpWorkDate.Value;
                row.Project = this.cmbProject.Text;
                row.SubProject = this.cmbSubProject.Text;
                row.Task = this.cmbTask.Text;
                row.Time = TimeSpan.Zero;
                row.Location = this.cmbLocations.Text;
                this.AddNewRow(row);
                this.btnPause.Enabled = true;
                this.btnPause.Text = "Pause";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incomplete Data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}