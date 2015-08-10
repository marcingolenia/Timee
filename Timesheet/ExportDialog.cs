using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timesheet
{
    public partial class ExportDialog : Form
    {
        public List<TimesheetService.CreativeStatus> Creative { get; set; }
        public int CreativeId
        {
            get { return this.Creative.Where(c => c.Value == this.cbCreative.Text).Select(c => c.Id).First(); }
        }
        public ExportDialog()
        {
            InitializeComponent();
        }

        private void ExportDialog_Load(object sender, EventArgs e)
        {
            cbCreative.DataSource = this.Creative;
            cbCreative.DisplayMember = "Value";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
