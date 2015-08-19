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

        Configuration configuration;
        static string curDir = AppDomain.CurrentDomain.BaseDirectory;
        private string pluginHintsDir = Path.Combine(curDir, @"Plugins\Hints");
        private string timeeHintsDir = Path.Combine(curDir, @"Hints");
        private List<string> timeeHints;
        private List<string> pluginHints; 
        private int hintsNumber;
        private int pluginHintsNumber;
        public Help()
        {
            InitializeComponent();
            if (!Directory.Exists(pluginHintsDir)) Directory.CreateDirectory(pluginHintsDir);
            if (!Directory.Exists(timeeHintsDir)) Directory.CreateDirectory(timeeHintsDir);

            timeeHints = new List<string>(Directory.GetFiles(timeeHintsDir, "*.html", SearchOption.TopDirectoryOnly));
            pluginHints = new List<string>(Directory.GetFiles(pluginHintsDir, "*.html", SearchOption.TopDirectoryOnly));

            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            wbHints.Url = new Uri(timeeHints.ElementAt(selectedHint-1));
            this.chkGoAway.Checked = !Properties.Settings.Default.ShowHints;

            hintsNumber = timeeHints.Count;
            pluginHintsNumber = pluginHints.Count;

            lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber+pluginHintsNumber);


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
                wbHints.Url = new Uri(timeeHints.ElementAt(selectedHint-1));               
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber+pluginHintsNumber);

            }
            else if (selectedHint < hintsNumber + pluginHintsNumber && selectedHint >= hintsNumber)
            {
                selectedHint++;
                wbHints.Url = new Uri(pluginHints.ElementAt((selectedHint - hintsNumber)-1));
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber + pluginHintsNumber);
            }
        }

        private void linkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedHint > 1)
            {
                if (selectedHint <= hintsNumber+1)
                {
                    selectedHint--;
                    wbHints.Url = new Uri(timeeHints.ElementAt(selectedHint-1));
                    lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber + pluginHintsNumber);
                }
                else
                {
                    selectedHint--;
                    wbHints.Url = new Uri(pluginHints.ElementAt((selectedHint-hintsNumber)));
                    lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint, hintsNumber + pluginHintsNumber);
                }

            }
        }

       
        }
    }

