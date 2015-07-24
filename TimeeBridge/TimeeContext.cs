using System.ComponentModel;

namespace TimeeBridge
{
    public class TimeeContext
    {
        public BindingList<UserConfigurationLocation> Locations { get; set; }
        public BindingList<UserConfigurationProject> Projects { get; set; }
        public BindingList<UserConfigurationSubproject> Subprojects { get; set; }
        public BindingList<UserConfigurationTask> Tasks { get; set; }

        public void ResetAllBindings()
        {
            this.Locations.ResetBindings();
            this.Projects.ResetBindings();
            this.Subprojects.ResetBindings();
            this.Tasks.ResetBindings();
        }
    }
}
