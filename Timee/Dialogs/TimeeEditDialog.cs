using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows.Forms;
using Timee.DAL;
using Timee.Models;

namespace Timee.Dialogs
{
    public partial class TimeeEditDialog : Form
    {
        private readonly static string DISPLAY_MEMBER = 
            ConfigurationManager.AppSettings.Get("DefaultDisplayMember");

        private TimeeContext context;
        private TimeeContext originalContext;
        public TimeeEditDialog(TimeeContext context, TimeeComponentType component)
        {
            InitializeComponent();
            this.context = context;
            
            this.originalContext = (TimeeContext)Extensions.Clone<TimeeContext>(context);

            switch (component)
            {
                case TimeeComponentType.Project:
                    this.tabsComponents.SelectedTab = tabProject;
                 
                    break;
                case TimeeComponentType.Subproject:
                    this.tabsComponents.SelectedTab = tabSubProject;
                    break;
                case TimeeComponentType.Task:
                    this.tabsComponents.SelectedTab = tabTask;
                    break;
                case TimeeComponentType.Location:
                    this.tabsComponents.SelectedTab = tabLocation;
                    break;
                default:
                    break;
            }
            this.compLocationControl.BindData(context.Locations, DISPLAY_MEMBER);
            this.compProjectControl.BindData(context.Projects, DISPLAY_MEMBER);
            this.compSubprojectControl.BindData(context.Subprojects, DISPLAY_MEMBER);
            this.compTaskControl.BindData(context.Tasks, DISPLAY_MEMBER);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            

            context.ResetAllBindings();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TimeeXMLService.Instance.SaveContext(this.originalContext);
            this.Close();
        }
    }
}
