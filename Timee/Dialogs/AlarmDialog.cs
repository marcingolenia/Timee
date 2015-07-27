using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Dialogs
{
    public partial class AlarmDialog : Form
    {
        public DateTime AlarmDuration { get; set; }
        public List<AlarmOption> AlarmOptions { get; set; }
        public string AlarmMessage { get; set; }
        public AlarmDialog()
        {
            InitializeComponent();         
        }
        private void AlarmDialog_Load(object sender, EventArgs e)
        {
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
            AlarmDuration = dtpAlarmDuration.Value;
            AlarmOptions = grbAlarmOptions.Controls.OfType<CheckBox>()
                           .Where(chk => chk.Checked)
                           .Select(chk => (AlarmOption)chk.TabIndex).ToList();
            if (AlarmOptions.Count > 0)
            {
                AlarmMessage = txtMessage.Text;
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
    }

    public enum AlarmOption
    {
        ShowMessage,
        SoundOnly
    }
}
