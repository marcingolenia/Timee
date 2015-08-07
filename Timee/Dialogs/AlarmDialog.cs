using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timee.Services;

namespace Timee.Dialogs
{
    public partial class AlarmDialog : Form
    {
        public AlarmService AlarmService { get; set; }
        private ToolStripItemCollection plugins;
        public AlarmDialog(ToolStripItemCollection plugins)
        {
            InitializeComponent();
            this.AlarmService = new AlarmService();
            this.plugins = plugins;
        }
        private void AlarmDialog_Load(object sender, EventArgs e)
        {
            parseMenuItems(plugins);
            dtpAlarmDuration.CustomFormat = "H'h' mm'm'";
            dtpAlarmDuration.Value = DateTime.Today.AddHours(8);
        }
        /// <summary>
        /// Checking if any checkbox were checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            AlarmService.AlarmDuration = DateTime.Now.Add(dtpAlarmDuration.Value.TimeOfDay);
            AlarmService.AlarmOptions = grbAlarmOptions.Controls.OfType<CheckBox>()
                           .Where(chk => chk.Checked)
                           .Select(chk => (AlarmOption)chk.TabIndex).ToList();
            if (AlarmService.AlarmOptions.Count > 0)
            {
                AlarmService.AlarmMessage = txtMessage.Text;
                AlarmService.Alarmplugin = (ToolStripMenuItem)cbPlugins.SelectedItem;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("At least one option must be selected to start.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void parseMenuItems(ToolStripItemCollection toolStripItemCollection)
        {
            foreach (ToolStripMenuItem theToolStripMenuItem in toolStripItemCollection)
            {
                // add the Item itself: you get a blank entry
                // in the ComboBox, so we use the Text property
                

                if (theToolStripMenuItem.HasDropDownItems)
                {
                    parseMenuItems(theToolStripMenuItem.DropDownItems);
                }
                else cbPlugins.Items.Add(theToolStripMenuItem);
            }
            cbPlugins.DisplayMember = "Name";

        }
    }
}
