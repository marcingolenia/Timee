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

namespace Timee
{
    public partial class TimeeEditDialog : Form
    {
        private TimeeContext context;
        public TimeeEditDialog(TimeeContext context, TimeeComponent component)
        {
            InitializeComponent();
            switch (component)
            {
                case TimeeComponent.Project:
                    this.tabsComponents.SelectedTab = tabProject;
                    break;
                case TimeeComponent.Subproject:
                    this.tabsComponents.SelectedTab = tabSubProject;
                    break;
                case TimeeComponent.Task:
                    this.tabsComponents.SelectedTab = tabTask;
                    break;
                case TimeeComponent.Location:
                    this.tabsComponents.SelectedTab = tabLocation;
                    break;
                default:
                    break;
            }
            this.context = context;
            this.compLocationControl.BindData(context.Locations, "name");
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
