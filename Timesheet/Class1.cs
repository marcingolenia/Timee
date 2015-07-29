using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timesheet.TimesheetService;

namespace Timesheet
{
    public class TimesheetPlugin
    {
        
        public void test()//Some example calls;
        {
            TimesheetService.DataServiceClient dc = new TimesheetService.DataServiceClient();
            dc.ClientCredentials.UserName.UserName = @"LGBSPL\test";
            dc.ClientCredentials.UserName.Password = "test";
            
            var r = dc.GetProjects("LGBS");
        }
    }
}
