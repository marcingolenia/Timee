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


       public static UserConfigurationLocation ContextLocation = new UserConfigurationLocation();
       public static UserConfigurationProject ContextProject = new UserConfigurationProject();
       public static UserConfigurationSubproject ContextSubproject = new UserConfigurationSubproject();
       public static UserConfigurationTask ContextTask = new UserConfigurationTask();

       public static List<UserConfigurationLocation> ContextLocationCollection = new List<UserConfigurationLocation>();
       public static List<UserConfigurationProject> ContextProjectCollection = new List<UserConfigurationProject>();
       public static List<UserConfigurationSubproject> ContextSubprojectCollection = new List<UserConfigurationSubproject>();
       public static List<UserConfigurationTask> ContextTaskCollection = new List<UserConfigurationTask>();

    }
}
