using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Excell
{
    public partial class ExcelExportSettings : Form
    {
        public ExcelExportSettings()
        {
            InitializeComponent();
        }
        public string Person 
        {
            get { return this.txtPerson.Text; }
            set { this.txtPerson.Text = value; }
        }
        public string IsCreative 
        {
            get { return this.cmbIsCreative.Text; }
            set { this.cmbIsCreative.Text = value; }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
