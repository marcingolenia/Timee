using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationWindow;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Timee.DAL;
namespace Timee.Services
{
    public class NotificationService
    {
        private static NotificationService _instance;
        PopupNotifier toolTip = new PopupNotifier();
        private NotificationService()
        {
            _instance = this;
        }
        public static NotificationService Instance
        {
            get
            {
                return _instance == null ? new NotificationService() : _instance;
            }
        }
        public void SimpleNotification(string titleText, string contentText, Image icon = null)
        {
            this.toolTip.ContentText = "";
            this.toolTip.TitleText = titleText;
            this.toolTip.Image = icon;
            this.toolTip.ContentText = contentText;
            this.toolTip.Size = new Size(400, 75);

            this.toolTip.Popup();
        }
        /// <summary>
        /// Show possible switches
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ShowTimerSummaryNotification(DataGridView grd)
        {
            int size = 20 * grd.Rows.Count;
            foreach (DataGridViewRow row in grd.Rows)
            {
                var typedRow = (TimeeDataSet.TimeSheetTableRow)(row.DataBoundItem as DataRowView).Row;
                string strRow = string.Format("{0}. {1} | {2} | {3} | {4}", row.Index + 1, typedRow.Project, typedRow.Task, typedRow.Comment, typedRow.Time.ToString("hh':'mm':'ss"));
                this.toolTip.ContentText += Environment.NewLine + strRow;
            }
            this.toolTip.TitleText = "Timee";
            this.toolTip.Delay = 500;
            this.toolTip.ShowCloseButton = true;
            this.toolTip.Size = new Size(500, 20 + size);
            this.toolTip.Popup();
        }
        /// <summary>
        /// Show notification message
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ShowTimerSwitchNotification(int rowIndex, DataGridView grd, TimeeDataSet timeeDataSet)
        {
            var currentRow = grd.Rows[rowIndex];
            if (currentRow != null)
            {
                string projectName = (string)grd.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.ProjectColumn.ColumnName].Value;
                string subProjectName = (string)grd.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.SubProjectColumn.ColumnName].Value;
                string comment = (string)grd.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.CommentColumn.ColumnName].Value;
                TimeSpan time = (TimeSpan)grd.Rows[rowIndex].Cells[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].Value;
                string notificationText = string.Format("Timer has been switched to:{0}{1}. {2} - {3} - '{4}' ({5:hh\\:mm\\:ss}).", new object[] { Environment.NewLine, rowIndex + 1, projectName, subProjectName, comment, time });
                NotificationService.Instance.SimpleNotification("Timee", notificationText);
            }
        }
    }
}
