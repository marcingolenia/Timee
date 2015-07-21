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
        public List<AlarmOption> alarmOptions = new List<AlarmOption>();
        public AlarmDialog()
        {
            InitializeComponent();         
        }
        private void AlarmDialog_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "HH,mm,ss";
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00);
        }
        /// <summary>
        /// Checking if any checkbox were checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            AlarmDuration = dateTimePicker1.Value;
            var options = (from option in grbAlarmOptions.Controls.OfType<CheckBox>()
                          where (option.Checked)
                          select(option.TabIndex));
            if (options.Any())
            {

                foreach (var cb in options)
                {
                    if (cb == 0)
                    {
                        alarmOptions.Add(AlarmOption.ShowMessage);
                    }
                    else if (cb == 1)
                    {
                        alarmOptions.Add(AlarmOption.SoundOnly);
                    }
                }
                DialogResult = DialogResult.OK;
            }
                
            else
            {
                MessageBox.Show("Check at least one option","Error", MessageBoxButtons.OK);
            }
       
        }

    }

    public enum AlarmOption
    {
        SoundOnly,
        ShowMessage,
    }
}
