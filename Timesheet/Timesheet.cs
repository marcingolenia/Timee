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
    public class TimesheetPlugin :TimeeBridge.IPlugins
    {
            private string login;
            private string password;
            private TimeeBridge.TimeeDataSet grdMainTasks = new TimeeBridge.TimeeDataSet();
            private TimeeBridge.TimeeDataSet.TimeSheetTableRow row = new TimeeBridge.TimeeDataSet.TimeSheetTableRow();
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
                try
                {
                   
                    var r = client.GetProjects("LGBS");


                    foreach (var project in r)
                    {
                        if(project.Name == "LGBS | Timesheet")
                        {
                            int subId = client.Alt_GetSubprojectId("LGBS", project.Id, "Timee");
                           int taskId = client.GetAvailableTasks("LGBS", project.Id, subId).First().Id;
                           var record = new TimesheetRecord();
                            var subProject = client.Alt_GetAvailableSubprojects("LGBS",project.Id);
                            foreach(var sub in subProject){
                                if(sub.Id == subId){
                                    record.SubprojectName = sub.Name;
                                }
                            }
                           record.Comment = "TestTimee";
                           record.ProjectId = project.Id;
                           record.ProjectName = project.Name;
                           record.PersonId = client.GetCurrentUser("LGBS").Id;
                           record.PersonName = client.GetCurrentUser("LGBS").Name;
                           record.TaskId = taskId;
                            record.SubprojectId = subId;
                           record.TaskName = client.GetAvailableTasks("LGBS", project.Id, subId).First().Value;
                           record.Hours = 8;
                           record.LocationId = client.GetLocations("LGBS").First().Id;
                           record.LocationName = client.GetLocations("LGBS").First().Value;
                           record.StatusId = client.GetStatuses("LGBS").First().Id;
                           record.StatusName = client.GetStatuses("LGBS").First().Value;
                           record.Date = DateTime.Today;
                           record.CreativeStatusId = client.GetCreativeStatuses("LGBS").First().Id;
                           record.CreativeStatusName = client.GetCreativeStatuses("LGBS").First().Value;
                          //var test =  client.Alt_GetTimesheetRecord("LGBS", 1);
                           client.Alt_InsertRecords("LGBS", record, 1, false, record.SubprojectName, record.TaskName);
                          // MessageBox.Show(client.GetRecentProjects("LGBS").First().Name);
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unauthorized Login!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }


        }
    }
}
