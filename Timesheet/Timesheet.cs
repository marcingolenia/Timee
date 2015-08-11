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
    public class TimesheetExport : TimeeBridge.IPlugins
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
        private List<Project> Projects = new List<Project>();
        private List<Timesheet.TimesheetService.Task> Tasks = new List<TimesheetService.Task>();
        private List<Location> Locations = new List<Location>();
        public void Start()
        {

            this.grdMainTasks.Merge(TimeeBridge.TimeeValues.MainTasksDataSet);
            if (this.grdMainTasks.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Nothing to Export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var dlg = new LoginDialog())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    this.login = dlg.Login;
                    this.password = dlg.Password;
                }
            }
            var record = new TimesheetRecord();

            using (var client = new DataServiceClient())
            {
                try
                {
                    client.ClientCredentials.Windows.ClientCredential.Domain = "LGBSPL";
                    client.ClientCredentials.Windows.ClientCredential.UserName = this.login;
                    client.ClientCredentials.Windows.ClientCredential.Password = this.password;


                    using (var dlg = new ExportDialog())
                    {
                        dlg.Creative = client.GetCreativeStatuses("LGBS").ToList();
                        dlg.ShowDialog();
                        if (dlg.DialogResult == DialogResult.OK)
                        {
                            this.creativeId = dlg.CreativeId;
                        }
                        else
                        {
                            MessageBox.Show("Export Cancelled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unauthorized Login!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < grdMainTasks.Tables[0].Rows.Count; i++)
                {
                    row = (TimeeBridge.TimeeDataSet.TimeSheetTableRow)grdMainTasks.Tables[0].Rows[i];

                    projectId = TimeeBridge.TimeeValues.ContextProjectCollection.Where(p => p.Name == row.Project)
                        .Select(p => Convert.ToInt32(p.Value))
                        .First();
                    if (projectId < 0)
                    {
                        if (this.Projects.Count == 0)
                        {
                            this.Projects = client.GetProjects("LGBS").ToList();
                        }
                        try
                        {
                            projectId = this.Projects.Where(p => p.Name == row.Project).Select(p => p.Id).First();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format("Project: {0} doesn't exist!", row.Project), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    subId = TimeeBridge.TimeeValues.ContextSubprojectCollection.Where(s => s.Parent == row.Project).Where(s => s.Name == row.SubProject)
                        .Select(s => Convert.ToInt32(s.Value))
                        .First();
                    if (subId < 0)
                    {
                        try
                        {
                            subId = client.Alt_GetSubprojectId("LGBS", projectId, row.SubProject);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format("Sub Project: {0} doesn't exist!", row.SubProject), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    taskId = TimeeBridge.TimeeValues.ContextTaskCollection.Where(t => t.Parent == row.SubProject).Where(t => t.Name == row.Task)
                        .Select(t => Convert.ToInt32(t.Value))
                        .First();
                    if (taskId < 0)
                    {
                        if (this.Tasks.Count == 0)
                        {
                            this.Tasks = client.GetAvailableTasks("LGBS", projectId, subId).ToList();
                        }
                        try
                        {
                            taskId = this.Tasks.Where(p => p.Value == row.Task).Select(p => p.Id).First();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format("Task: {0} doesn't exist!", row.Task), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    locationId = TimeeBridge.TimeeValues.ContextLocationCollection.Where(l => l.Name == row.Location)
                        .Select(l => Convert.ToInt32(l.Value))
                        .First();
                    if (locationId < 0)
                    {
                        if (this.Locations.Count == 0)
                        {
                            this.Locations = client.GetLocations("LGBS").ToList();
                        }
                        try
                        {
                            locationId = this.Locations.Where(p => p.Value == row.Location).Select(p => p.Id).First();

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(string.Format("Location: {0} doesn't exist!", row.Location), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    record.Comment = row.Comment;
                    record.ProjectId = projectId;
                    record.PersonId = client.GetCurrentUser("LGBS").Id;
                    record.TaskId = taskId;
                    record.SubprojectId = subId;
                    record.Hours = (decimal)row.Time.Hours + (decimal)row.Time.Minutes / 100;
                    record.LocationId = locationId;
                    record.Date = row.Date;
                    record.CreativeStatusId = this.creativeId;
                    client.Alt_InsertRecords("LGBS", record, 1, false, record.SubprojectName, record.TaskName);
                }
            }
            MessageBox.Show("Export Completed!");
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
                try
                {
                    client.ClientCredentials.Windows.ClientCredential.Domain = "LGBSPL";
                    client.ClientCredentials.Windows.ClientCredential.UserName = this.login;
                    client.ClientCredentials.Windows.ClientCredential.Password = this.password;
                    this.ProjectsList = client.GetProjects("LGBS").ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unauthorized Login!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                using (var dlg = new ImportDialog())
                {
                    dlg.projects = this.ProjectsList;
                    dlg.ShowDialog();


                    if (dlg.DialogResult == DialogResult.OK)
                    {
                        this.ProjectsList = dlg.selectedProjects;
                    }
                    else
                    {
                        MessageBox.Show("Import Cancelled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                try
                {
                    foreach (var project in this.ProjectsList)
                    {
                        TimeeBridge.TimeeValues.ContextProject = new TimeeBridge.UserConfigurationProject();
                        TimeeBridge.TimeeValues.ContextProject.Name = project.Name;
                        TimeeBridge.TimeeValues.ContextProject.Value = project.Id.ToString();
                        TimeeBridge.TimeeValues.ContextProjectCollection.Add(TimeeBridge.TimeeValues.ContextProject);
                        this.SubProjectsList = client.GetAvailableSubprojects("LGBS", project.Id);

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
                catch (Exception e)
                {
                    MessageBox.Show("Nothing to Import!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.login = "";
            this.password = "";
        }

    }
}
