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
            
        static List<string> timeeHints = new List<string>(Directory.GetFiles(string.Format("{0}Hints",curDir),"*.html",SearchOption.TopDirectoryOnly));
        static List<string> pluginHints = new List<string>(Directory.GetFiles(string.Format("{0}Plugins\\Hints", curDir), "*.html", SearchOption.TopDirectoryOnly));
        private int  hintsNumber = timeeHints.Count;
        private int pluginHintsNumber = pluginHints.Count;
        public Help()
        {
            InitializeComponent();
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            wbHints.Url = new Uri(timeeHints.ElementAt(selectedHint-1));
            this.chkGoAway.Checked = !Properties.Settings.Default.ShowHints;
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

