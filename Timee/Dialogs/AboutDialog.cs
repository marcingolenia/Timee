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
    public partial class AboutDialog : Form
    {
        public bool Hints { get; set; }
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void linkToProject_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.linkToProject.Text);
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            this.chkHints.Checked = (this.Hints) ? true : false;
        }

        private void AboutDialog_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Hints = this.chkHints.Checked ? true : false;
            this.DialogResult = DialogResult.Abort;
        }
    }
}
