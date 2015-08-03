using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeeBridge
{
   public static class TimeeValues
    {
       public static string MainTasksXml { get; set; }
       public static string PredefineTasksXml { get; set; }
       public static DataTable MainTasks { get; set; }
       public static DataSet MainTasksDataSet { get; set; }
       public static DataTable PredefineTasks { get; set; }
       public static TimeeContext Context { get; set; }
       public static UserConfigurationLocation ContextLocation = new UserConfigurationLocation();
       public static UserConfigurationProject ContextProject = new UserConfigurationProject();
       public static UserConfigurationSubproject ContextSubproject = new UserConfigurationSubproject();
       public static UserConfigurationTask ContextTask = new UserConfigurationTask();

    }
}
