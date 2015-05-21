using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timee.Models
{
    [Serializable]
    public class TimeeContext
    {
        public BindingList<Models.UserConfigurationLocation> Locations { get; set; }
        public BindingList<Models.UserConfigurationProject> Projects { get; set; }
        public BindingList<Models.UserConfigurationSubproject> Subprojects { get; set; }
        public BindingList<Models.UserConfigurationTask> Tasks { get; set; }
    }
}
