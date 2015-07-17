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
    public partial class PredefinedTasks : Form
    {

        public event EventHandler<DataGridViewCellEventArgs> btnDeleteRowClicked;
        public event EventHandler<DataGridViewCellEventArgs> btnAddRowClicked;
        public TimeeDataSet.TimeSheetTableRow row { get; set; }
        public PredefinedTasks()
        {
            InitializeComponent();
        }
        private void PredefinedTasks_Load(object sender, EventArgs e)
        {
            DataTable predefinedTable = new DataTable("Predefined");

            grdPredefinedSummary.AutoGenerateColumns = true;
            DataSet predefinedSet = new DataSet();
            //predefinedSet.Tables.Add(predefinedTable);
            StringReader predefinedSetXml = new StringReader(Properties.Settings.Default.PredefinedTasks);
            predefinedSet.ReadXml(predefinedSetXml);
            grdPredefinedSummary.Visible = false;
            
            if(!(predefinedSet.Tables.Count ==0))
            {
                grdPredefinedSummary.Visible = true;
                predefinedTable = predefinedSet.Tables[0];
                grdPredefinedSummary.DataSource = predefinedTable;
                grdPredefinedSummary.Columns["Remove"].DisplayIndex = 6;
                grdPredefinedSummary.Columns["Add"].DisplayIndex = 5;
                btnDeleteRowClicked += PredefinedTasks_btnDeleteRowClicked;
                btnAddRowClicked += PredefinedTasks_btnAddRowClicked;
            }

 
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
           
                string predefinedTasksXml = Properties.Settings.Default.PredefinedTasks;
                XDocument prefXml = XDocument.Parse(predefinedTasksXml);

                 var predefinedTask = from t in grdPredefinedSummary.Rows.Cast<DataGridViewRow>()
                                 where t.Index == e.RowIndex
                                 select new
                                 {
                                     Project = t.Cells[2].Value,
                                     SubProject = t.Cells[3].Value,
                                     Task = t.Cells[4].Value,
                                     Comment = t.Cells[5].Value,
                                     Location = t.Cells[6].Value   
                                 };


              
                 var elementsToRemove = from element in prefXml.Elements("Root").Elements("PredefinedTask")
                                        where element.Element("Project").Value == predefinedTask.First().Project.ToString()
                                        where element.Element("SubProject").Value == predefinedTask.First().SubProject.ToString()
                                        where element.Element("Task").Value == predefinedTask.First().Task.ToString()
                                        where element.Element("Comment").Value == predefinedTask.First().Comment.ToString()
                                                where element.Element("Location").Value == predefinedTask.First().Location.ToString()
                                       select element;

                  foreach (var el in elementsToRemove)
                     el.Remove();
              //prefXml.Descendants("PredefinedTask")
              //   .Elements("Location")
              //   .Where(x => x.Value == predefinedTask.First().Location.ToString())
              //   .Remove();
                 grdPredefinedSummary.Rows.RemoveAt(e.RowIndex);
                 Properties.Settings.Default.PredefinedTasks = prefXml.ToString();
                Properties.Settings.Default.Save();
        }

            

        private void PredefinedTasks_btnAddRowClicked(object sender, DataGridViewCellEventArgs e)
        {
            TimeeDataSet tmpDataSet = new TimeeDataSet();
            TimeeDataSet.TimeSheetTableRow row = tmpDataSet.TimeSheetTable.NewTimeSheetTableRow();
            var predefinedTask = from t in grdPredefinedSummary.Rows.Cast<DataGridViewRow>()
                                 where t.Index == e.RowIndex
                                 select new
                                 {
                                     Project = t.Cells[2].Value,
                                     SubProject = t.Cells[3].Value,
                                     Task = t.Cells[4].Value,
                                     Comment = t.Cells[5].Value,
                                     Location = t.Cells[6].Value
                                 };
            row.Comment = predefinedTask.First().Comment.ToString();
            row.Date = DateTime.Today;
            row.Project = predefinedTask.First().Project.ToString();
            row.SubProject = predefinedTask.First().SubProject.ToString();
            row.Task = predefinedTask.First().Task.ToString();
            row.Time = TimeSpan.Zero;
            row.Location = predefinedTask.First().Location.ToString();
            this.row = row;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
