using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timee.Services
{
    public class AlarmService
    {
        private Timer alarmTimer;
        public DateTime AlarmDuration { get; set; }
        public List<AlarmOption> AlarmOptions { get; set; }
        public ToolStripMenuItem Alarmplugin { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeLeft
        {
            get
            {
                return this.AlarmDuration - DateTime.Now;
            }
        }
        public Form ActivationForm { get; set; }
        public Label RemainingTimeInfoControl { get; set; }

        public AlarmService()
        {
            this.alarmTimer = new System.Windows.Forms.Timer();
            this.alarmTimer.Tick += alarmTimer_Tick;
        }

        private void alarmTimer_Tick(object sender, EventArgs e)
        {
            ProcessNotification();
        }

        public void StartCountDown()
        {
            this.alarmTimer.Enabled = true;
        }
        public void ProcessNotification()
        {
            if (this.RemainingTimeInfoControl != null)
            {
                RemainingTimeInfoControl.Text = this.TimeLeft.ToString(@"hh\:mm\:ss");
            }
            if (TimeLeft <= TimeSpan.Zero)
            {
                this.ActivationForm.Show();
                ActivationForm.WindowState = FormWindowState.Normal;
                alarmTimer.Enabled = false;

                if (AlarmOptions.Contains(AlarmOption.ShowMessage))
                {
                    MessageBox.Show(this.AlarmMessage, "Exit", MessageBoxButtons.OK);
                }
                if (AlarmOptions.Contains(AlarmOption.PlaySound))
                {
                    System.Media.SystemSounds.Hand.Play();
                }
                if (AlarmOptions.Contains(AlarmOption.StartPlugin))
                {
                    PluginsService pluginSelect = new PluginsService();
                    Alarmplugin.Click += new EventHandler(pluginSelect.menuPluginClick);
                    Alarmplugin.PerformClick();
                }
            }
        }
    }

    public enum AlarmOption
    {
        ShowMessage,
        PlaySound,
        StartPlugin
    }
}
