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
                var projects = client.GetProjects("LGBS");
                
            for (int i = 0; i < grdMainTasks.Tables[0].Rows.Count; i++)
            {
                row = (TimeeBridge.TimeeDataSet.TimeSheetTableRow)grdMainTasks.Tables[0].Rows[i];
                    try
                    {

                        

                        projectId = projects.Where(p => p.Name == row.Project)
                            .Select(p => p.Id)
                            .First();

                        subId = client.Alt_GetSubprojectId("LGBS", projectId, row.SubProject);

                        var tasks = client.GetAvailableTasks("LGBS", projectId, subId);

                        taskId = tasks.Where(t => t.Value == row.Task)
                            .Select(t => t.Id)
                            .First();

                        var locations = client.GetLocations("LGBS");

                        locationId = locations.Where(l => l.Value == row.Location)
                            .Select(l => l.Id)
                            .First();

                        var record = new TimesheetRecord();
                        record.Comment = row.Comment;
                        record.ProjectId = projectId;
                        record.PersonId = client.GetCurrentUser("LGBS").Id;
                        record.TaskId = taskId;
                        record.SubprojectId = subId;
                        record.Hours = Math.Round(Math.Round((decimal)row.Time.TotalMinutes / 60, 2) * 4, MidpointRounding.ToEven) / 4; 
                        record.LocationId = client.GetLocations("LGBS").First().Id;
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
        private Project[] ProjectsList {get; set;}
        private Subproject[] SubProjectsList;
        private Location[] LocationsList;
        private Timesheet.TimesheetService.Task[] TasksList;

        private Dictionary<string, int> Projects;
        private Dictionary<int, KeyValuePair<string, string>> SubProjects;
        private Dictionary<int, KeyValuePair<string, string>> Tasks;
        private Dictionary<string, int> Locations;
        public void Start()
        {
            Projects = new Dictionary<string, int>();
            Locations = new Dictionary<string,int>();
            SubProjects = new Dictionary<int, KeyValuePair<string, string>>();
            Tasks = new Dictionary<int, KeyValuePair<string, string>>();

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
                this.ProjectsList = client.GetProjects("LGBS");

                using (var dlg = new ImportDialog())
                {
                    dlg.projects = this.ProjectsList;
                    dlg.ShowDialog();


                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.Projects = dlg.Projects;
                    }
                }

                
                foreach (var project in this.Projects)
                {
                    TimeeBridge.TimeeValues.ContextProject = new TimeeBridge.UserConfigurationProject();
                    TimeeBridge.TimeeValues.ContextProject.Name = project.Key;
                    TimeeBridge.TimeeValues.ContextProject.Value = project.Value.ToString();
                    TimeeBridge.TimeeValues.ContextProjectCollection.Add(TimeeBridge.TimeeValues.ContextProject);
                    this.SubProjectsList = client.GetAvailableSubprojects("LGBS",project.Value);

                    foreach (var subProject in SubProjectsList)
                    {
                        TimeeBridge.TimeeValues.ContextSubproject = new TimeeBridge.UserConfigurationSubproject();
                        TimeeBridge.TimeeValues.ContextSubproject.Name = subProject.Name;
                        TimeeBridge.TimeeValues.ContextSubproject.Value = subProject.Id.ToString();
                        TimeeBridge.TimeeValues.ContextSubproject.Parent = project.Key;
                        TimeeBridge.TimeeValues.ContextSubprojectCollection.Add(TimeeBridge.TimeeValues.ContextSubproject);
                        this.TasksList = client.GetAvailableTasks("LGBS", project.Value, subProject.Id);

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
                //Projects.Keys.DefaultIfEmpty("");

                //SubProjects.Keys.DefaultIfEmpty("");
                

                //TimeeBridge.TimeeValues.ContextTask.Name = Tasks.Keys.FirstOrDefault();
                //TimeeBridge.TimeeValues.ContextTask.Value = Tasks.Values.FirstOrDefault().ToString();
                //Locations.Keys.DefaultIfEmpty("");
               
           

            Locations.Clear();
            Projects.Clear();
            SubProjects.Clear();
            Tasks.Clear();
        }
        
    }
}
