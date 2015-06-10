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

namespace Timee.Plugins.LGBSExcelExport
{
    public partial class ExcelExportSettings : Form
    {
        private LGBSExcelExportConfiguration configuration;
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

        public ExcelExportSettings()
        {
            InitializeComponent();

            configuration = LGBSExcelExportConfigurationService.Instance.LoadConfiguration();
            this.cmbIsCreative.DataSource = configuration.IsCreative.Select(e => e.value).ToList();
            this.cmbIsCreative.Text = configuration.Settings.IsCreative.value;
            this.txtPerson.Text = configuration.Settings.Person.value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //UPDATE
            this.configuration.Settings.Person.value = this.Person;
            this.configuration.Settings.IsCreative.value = this.cmbIsCreative.Text;
            LGBSExcelExportConfigurationService.Instance.SaveConfiguration(configuration);
            this.Close();
        }
    }
}
