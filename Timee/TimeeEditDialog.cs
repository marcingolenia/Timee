using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.Models;
using System.Reflection;
using System.Configuration;

namespace Timee
{
    public partial class TimeeEditDialog : Form
    {
        private readonly static string DISPLAY_MEMBER = 
            ConfigurationManager.AppSettings.Get("DefaultDisplayMember");

        private TimeeContext context;
        public TimeeEditDialog(TimeeContext context, TimeeComponentType component)
        {
            InitializeComponent();
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
            this.context = context;
            this.compLocationControl.BindData(context.Locations, DISPLAY_MEMBER);
            // and next right here
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            context.Locations.ResetBindings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}
