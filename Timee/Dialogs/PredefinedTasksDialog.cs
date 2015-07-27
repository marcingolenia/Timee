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
using Timee.DAL;
using Timee.Models;

namespace Timee.Dialogs
{
    public partial class PredefinedTasksDialog : Form
    {

        private event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;
        private event EventHandler<DataGridViewCellEventArgs> btnAddRowClicked;
        public TimeeDataSet.TimeSheetTableRow Row { get; set; }

        public PredefinedTasksDialog(TimeeContext context)
        {
            InitializeComponent();
            StringReader predefinedSetXml = new StringReader(Properties.Settings.Default.PredefinedTasks);
            grdPredefinedSummary.DataSource = context.PredefinedTasks;
        }
        /// <summary>
        /// Initialize PredefinedTasks Table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PredefinedTasks_Load(object sender, EventArgs e)
        {
            grdPredefinedSummary.Columns[timeeDataSet.TimeSheetTable.DateColumn.ColumnName].Visible = false;
            grdPredefinedSummary.Columns[timeeDataSet.TimeSheetTable.TimeColumn.ColumnName].Visible = false;              
            btnDeleteRowClicked += PredefinedTasks_btnDeleteRowClicked;
            btnAddRowClicked += PredefinedTasks_btnAddRowClicked;
        }
        /// <summary>
        /// Trigger btnDeleteRowClicked/btnAddRowClicked event if cell is button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPredefinedSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdPredefinedSummary.Columns[e.ColumnIndex].Name == "Remove")
            {
                btnDeleteRowClicked(sender, e);
            }
            else if (grdPredefinedSummary.Columns[e.ColumnIndex].Name == "Add")
            {

                btnAddRowClicked(sender, e);
            }
        }
        /// <summary>
        /// Handle btnSaveRowClicked custom event for deleting rows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void PredefinedTasks_btnDeleteRowClicked(object sender, DataGridViewCellEventArgs e)
        {
                 grdPredefinedSummary.Rows.RemoveAt(e.RowIndex);
                 Properties.Settings.Default.PredefinedTasks = this.timeeDataSet.GetXml();
        }

         /// <summary>
         /// Handle btnAddRowClicked custom event for adding predefinedTask to Main Table.
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void PredefinedTasks_btnAddRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            this.Row = (TimeeDataSet.TimeSheetTableRow)((DataRowView)grdPredefinedSummary.Rows[e.RowIndex].DataBoundItem).Row;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
