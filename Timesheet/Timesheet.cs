using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timesheet.TimesheetService;

namespace Timesheet
{

    [Export(typeof(TimeeBridge.IPlugins))]
    [ExportMetadata("Name", "Export to Timesheet")]
    [ExportMetadata("Return", "None")]
    [ExportMetadata("Group", "Timesheet")]
    public class TimesheetExport :TimeeBridge.IPlugins
    {
            private string login;
            private string password;

            private int projectId;
            private int subId;
            private int taskId;
            private int locationId;
            private int creativeId;
            private TimeeBridge.TimeeDataSet grdMainTasks = new TimeeBridge.TimeeDataSet();
            private TimeeBridge.TimeeDataSet.TimeSheetTableRow row;
        public void Start()
        {

            this.grdMainTasks.Merge(TimeeBridge.TimeeValues.MainTasksDataSet);
            using (var dlg = new LoginDialog())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    this.login = dlg.Login;
                    this.password = dlg.Password;
                }
            }
            using (var client = new DataServiceClient())
            {
                client.ClientCredentials.Windows.ClientCredential.Domain = "LGBSPL";
                client.ClientCredentials.Windows.ClientCredential.UserName = this.login;
                client.ClientCredentials.Windows.ClientCredential.Password = this.password;
                
            for (int i = 0; i < grdMainTasks.Tables[0].Rows.Count; i++)
            {
                row = (TimeeBridge.TimeeDataSet.TimeSheetTableRow)grdMainTasks.Tables[0].Rows[i];
                    try
                    {

                        

                        projectId = TimeeBridge.TimeeValues.ContextProjectCollection.Where(p => p.Name == row.Project)
                            .Select(p => Convert.ToInt32(p.Value))
                            .First();

                        subId = TimeeBridge.TimeeValues.ContextSubprojectCollection.Where(p=> p.Parent == row.Project).Where(p => p.Name == row.SubProject)
                            .Select(p => Convert.ToInt32(p.Value))
                            .First();

                        taskId = TimeeBridge.TimeeValues.ContextTaskCollection.Where(t => t.Parent == row.SubProject).Where(t => t.Name == row.Task)
                            .Select(t => Convert.ToInt32(t.Value))
                            .First();

                        locationId = TimeeBridge.TimeeValues.ContextLocationCollection.Where(l => l.Name == row.Location)
                            .Select(l => Convert.ToInt32(l.Value))
                            .First();

                        var record = new TimesheetRecord();
                        record.Comment = row.Comment;
                        record.ProjectId = projectId;
                        record.PersonId = client.GetCurrentUser("LGBS").Id;
                        record.TaskId = taskId;
                        record.SubprojectId = subId;
                        record.Hours = Math.Round(Math.Round((decimal)row.Time.TotalMinutes / 60, 2) * 4, MidpointRounding.ToEven) / 4;
                        record.LocationId = locationId;
                        //record.StatusId = client.GetStatuses("LGBS").First().Id;
                        record.Date = row.Date;
                        record.CreativeStatusId = client.GetCreativeStatuses("LGBS").First().Id;
                        client.Alt_InsertRecords("LGBS", record, 1, false, record.SubprojectName, record.TaskName);
                        MessageBox.Show("Export Completed!");



                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Unauthorized Login!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            this.grdMainTasks.Clear();
            this.login = "";
            this.password = "";
        }
    }
    [Export(typeof(TimeeBridge.IPlugins))]
    [ExportMetadata("Name", "Import from Timesheet")]
    [ExportMetadata("Return", "Context")]
    [ExportMetadata("Group", "Timesheet")]
    public class TimesheetImport : TimeeBridge.IPlugins
    {
        private string login;
        private string password;
        private List<Project> ProjectsList = new List<Project>();
        private Subproject[] SubProjectsList;
        private Location[] LocationsList;
        private Timesheet.TimesheetService.Task[] TasksList;
        public void Start()
        {
            using (var dlg = new LoginDialog())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    this.login = dlg.Login;
                    this.password = dlg.Password;
                }
            }
            using (var client = new DataServiceClient())
            {
                client.ClientCredentials.Windows.ClientCredential.Domain = "LGBSPL";
                client.ClientCredentials.Windows.ClientCredential.UserName = this.login;
                client.ClientCredentials.Windows.ClientCredential.Password = this.password;
                this.ProjectsList = client.GetProjects("LGBS").ToList();

                using (var dlg = new ImportDialog())
                {
                    dlg.projects = this.ProjectsList;
                    dlg.ShowDialog();


                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.ProjectsList = dlg.selectedProjects;
                    }
                }

                
                foreach (var project in this.ProjectsList)
                {
                    TimeeBridge.TimeeValues.ContextProject = new TimeeBridge.UserConfigurationProject();
                    TimeeBridge.TimeeValues.ContextProject.Name = project.Name;
                    TimeeBridge.TimeeValues.ContextProject.Value = project.Id.ToString();
                    TimeeBridge.TimeeValues.ContextProjectCollection.Add(TimeeBridge.TimeeValues.ContextProject);
                    this.SubProjectsList = client.GetAvailableSubprojects("LGBS",project.Id);

                    foreach (var subProject in SubProjectsList)
                    {
                        TimeeBridge.TimeeValues.ContextSubproject = new TimeeBridge.UserConfigurationSubproject();
                        TimeeBridge.TimeeValues.ContextSubproject.Name = subProject.Name;
                        TimeeBridge.TimeeValues.ContextSubproject.Value = subProject.Id.ToString();
                        TimeeBridge.TimeeValues.ContextSubproject.Parent = project.Name;
                        TimeeBridge.TimeeValues.ContextSubprojectCollection.Add(TimeeBridge.TimeeValues.ContextSubproject);
                        this.TasksList = client.GetAvailableTasks("LGBS", project.Id, subProject.Id);

                        foreach (var task in TasksList)
                        {
                                TimeeBridge.TimeeValues.ContextTask = new TimeeBridge.UserConfigurationTask();
                                TimeeBridge.TimeeValues.ContextTask.Name = task.Value;
                                TimeeBridge.TimeeValues.ContextTask.Value = task.Id.ToString();
                                TimeeBridge.TimeeValues.ContextTask.Parent = subProject.Name;
                                TimeeBridge.TimeeValues.ContextTaskCollection.Add(TimeeBridge.TimeeValues.ContextTask);
                        }
                    }

                }
                this.LocationsList = client.GetLocations("LGBS");
                foreach (var location in LocationsList)
	            {
                 TimeeBridge.TimeeValues.ContextLocation = new TimeeBridge.UserConfigurationLocation();
                 TimeeBridge.TimeeValues.ContextLocation.Name = location.Value;
                 TimeeBridge.TimeeValues.ContextLocation.Value = location.Id.ToString();
                 TimeeBridge.TimeeValues.ContextLocationCollection.Add(TimeeBridge.TimeeValues.ContextLocation);
	            }
                
            }
            this.login = "";
            this.password = "";
        }
        
    }
}
