using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Dialogs
{
    public partial class Help : Form
    {
        private int selectedHint = 1;
        private int hintsNumber = 5;
        Configuration configuration;
        public Help()
        {
            InitializeComponent();
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string curDir = AppDomain.CurrentDomain.BaseDirectory;
            wbHints.Url = new Uri(String.Format("file:///{0}Hints/{1}.html",curDir, selectedHint));
            this.chkGoAway.Checked = !Properties.Settings.Default.ShowHints;
            lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber);

 
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ShowHints = !chkGoAway.Checked;
            Properties.Settings.Default.Save();
        }
        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedHint < hintsNumber)
            {
                selectedHint++;
                wbHints.Url = new Uri(String.Format("file:///D:/LGBS/Projekty/Timee/Timee/Dialogs/Hints/{0}.html", selectedHint));
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber);

            }
        }

        private void linkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedHint > 0)
            {
                selectedHint--;
                wbHints.Url = new Uri(String.Format("file:///D:/LGBS/Projekty/Timee/Timee/Dialogs/Hints/{0}.html", selectedHint));
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber);
            }
        }

       
        }
    }

