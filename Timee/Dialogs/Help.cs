using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Dialogs
{
    public partial class Help : Form
    {
        private int selectedHint = 0;
        public List<string> Hints = new List<string>();
        Configuration configuration;
        public Help()
        {
            InitializeComponent();
            configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            this.chkGoAway.Checked = Boolean.Parse(configuration.AppSettings.Settings["HideHints"].Value);
            InitHints();
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            configuration.AppSettings.Settings["HideHints"].Value = chkGoAway.Checked ? Boolean.TrueString : Boolean.FalseString;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedHint < Hints.Count-1)
            {
                selectedHint++;
                txtHint.Text = Hints[selectedHint];
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint + 1, Hints.Count);

            }
        }

        private void linkPrev_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedHint > 0)
            {
                selectedHint--;
                txtHint.Text = Hints[selectedHint];
                lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint + 1, Hints.Count);
            }
        }

        private void InitHints()
        {
            this.Hints.Add(@"You can drag a row over another one to add its counted time to another one! 

Just start a drag by holding left mouse on row header. (Left side of the grid)");      


            this.Hints.Add(@"There are shortcuts which can help you work with Timee faster.
CTRL + F1 (F2,F3 till F10) Will switch time counting to corresponding row number, even if Timee is in system tray.

CTRL + F11 will show you some summary with rows number. This will help you to switch between tasks without even opening Timee from system tray.

CTR + F12 will open time from system tray (if needed) and add new row with automatic focus in Project column. Just type in!

We are looking forward to make this feature configurable.");

            this.Hints.Add(@"You can double click on a row header to switch time counting fast between choosen tasks.

Also we wanted to make the grid quickly editable. Try to switch between column using Tab Key. If you will reach last column and press Tab again new row will be created.");

            this.Hints.Add(@"All data (Locations, Projects etc...) edited in dialog will be saved if you'll press OK button. All additional data which you will enter into grid will be lost upon exiting the Application. Feel free to be fast, but remember to add all values which you want to keep via edit dialog.");

            this.Hints.Add(@"Please go to about dialog and open github project page and go to ''Issues'' to see what you should expect in next version (Look vor Version2 Milestone).
You can also see this on our board - https://waffle.io/marcingolenia/timee

Meanwhile you can let me know about your ideas by sending me an e-mail: ma.golenia@lgbs.pl");
            txtHint.Text = Hints[selectedHint];
            lblCurrentHint.Text = String.Format("{0} of {1}", selectedHint + 1, Hints.Count);
        }
    }
}
