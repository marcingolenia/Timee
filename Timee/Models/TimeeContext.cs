﻿using System.ComponentModel;

namespace Timee.Models
{
    public class TimeeContext
    {
        public BindingList<Models.UserConfigurationLocation> Locations { get; set; }
        public BindingList<Models.UserConfigurationProject> Projects { get; set; }
        public BindingList<Models.UserConfigurationSubproject> Subprojects { get; set; }
        public BindingList<Models.UserConfigurationTask> Tasks { get; set; }

        public void ResetAllBindings()
        {
            this.Locations.ResetBindings();
            this.Projects.ResetBindings();
            this.Subprojects.ResetBindings();
            this.Tasks.ResetBindings();
        }
    }
}
