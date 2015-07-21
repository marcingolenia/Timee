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

namespace Timee.Dialogs
{
    public partial class PredefinedTasksDialog : Form
    {

        private event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;
        private event EventHandler<DataGridViewCellEventArgs> btnAddRowClicked;
        public TimeeDataSet.TimeSheetTableRow row { get; set; }

        private DataSet predefinedSet = new PredefinedTasksDataSet();
        public PredefinedTasksDialog()
        {
            InitializeComponent();
        }
        private void PredefinedTasks_Load(object sender, EventArgs e)
        {
           
            StringReader predefinedSetXml = new StringReader(Properties.Settings.Default.PredefinedTasks);
            predefinedSet.ReadXml(predefinedSetXml);
            if (TimeeMain.newPredefinedTasks.Any())
            {
                foreach (var row in TimeeMain.newPredefinedTasks)
                {
                    
                    predefinedSet.Tables[0].Rows.Add(row.ItemArray);

                }
                TimeeMain.newPredefinedTasks.Clear();
            }
                grdPredefinedSummary.DataSource = predefinedSet.Tables[0];
                grdPredefinedSummary.Columns["Remove"].DisplayIndex = 8;
                grdPredefinedSummary.Columns["Add"].DisplayIndex = 7;
                grdPredefinedSummary.Columns["Location"].DisplayIndex = 6;
                grdPredefinedSummary.Columns["Time"].Visible = false;
                grdPredefinedSummary.Columns["Date"].Visible = false;

               
                grdPredefinedSummary.Refresh();

                btnDeleteRowClicked += PredefinedTasks_btnDeleteRowClicked;
                btnAddRowClicked += PredefinedTasks_btnAddRowClicked;
        }
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

         private void PredefinedTasks_btnDeleteRowClicked(object sender, DataGridViewCellEventArgs e)
        {
                 grdPredefinedSummary.Rows.RemoveAt(e.RowIndex);
                 Properties.Settings.Default.PredefinedTasks = this.predefinedSet.GetXml();
        }

            

        private void PredefinedTasks_btnAddRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            TimeeDataSet tmpDataSet = new TimeeDataSet();
            
            var drv = ((DataRowView)grdPredefinedSummary.Rows[e.RowIndex].DataBoundItem).Row;
            TimeeDataSet.TimeSheetTableRow row = tmpDataSet.TimeSheetTable.NewTimeSheetTableRow();
            row.ItemArray = drv.ItemArray;
            
            
            
            this.row = row;

            Properties.Settings.Default.PredefinedTasks = this.predefinedSet.GetXml();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void PredefinedTasks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.PredefinedTasks = this.predefinedSet.GetXml();
        }
    }
}
