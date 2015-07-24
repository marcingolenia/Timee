using ClosedXML.Excel;
using System.Xml;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using Excel = Microsoft.Office.Interop.Excel;

namespace Excell
{
    [Export(typeof(TimeeBridge.IExcell))]
    [ExportMetadata("Name", "Export to Excell")]
    [ExportMetadata("Type", "ExcellExport")]
    public class ExcellExport : TimeeBridge.IExcell
    {
        private string IsCreative { get; set; }
        private string Person { get; set; }

        public void ExportFromExcell(string xml)
        {
            using (var dlg = new ExcelExportSettings())
            {
                dlg.ShowDialog();
                if (dlg.DialogResult == DialogResult.OK)
                {
                    this.IsCreative = dlg.IsCreative;
                    this.Person = dlg.Person;
                }
            }
            StringReader tmpXml = new StringReader(xml);
            DataSet ds = new DataSet();
            ds.ReadXml(tmpXml);
            DataRowCollection entries = ds.Tables[0].Rows;

            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Timee");

            // export range
            IXLRange exportRange = worksheet.Range(1, 1, Int16.MaxValue, 9);
            exportRange.FirstRow().Merge();

            // Set header
            IXLRange headerRange = exportRange.Range(1, 1, 1, 9);
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.GreenPigment;

            headerRange.Cell(1, 1).Value = "Timee export";

            // Set titles
            IXLRange titlesRange = exportRange.Range(2, 1, 2, 9);
            titlesRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titlesRange.Style.Font.Bold = true;

            titlesRange.Cell(1, 1).Value = "Date";
            titlesRange.Cell(1, 2).Value = "Person";
            titlesRange.Cell(1, 3).Value = "Hours";
            titlesRange.Cell(1, 4).Value = "Project";
            titlesRange.Cell(1, 5).Value = "SubProject";
            titlesRange.Cell(1, 6).Value = "Task";
            titlesRange.Cell(1, 7).Value = "Comment";
            titlesRange.Cell(1, 8).Value = "Is creative";
            titlesRange.Cell(1, 9).Value = "Location";



            // Formatting
            IXLRange dateTimeRange = exportRange.Range(3, 1, Int16.MaxValue, 2);
            dateTimeRange.Style.NumberFormat.NumberFormatId = 14;

            // Fill data
            IXLRange dataRange = exportRange.Range(3, 1, Int16.MaxValue, 9);

            for (int i = 0; i < entries.Count; i++)
            {
                var row = entries[i];
                dataRange.Cell(i + 1, 1).Value = Convert.ToDateTime(row.ItemArray[0]).Date;
                dataRange.Cell(i + 1, 2).Value = Person;
                //Round to Quarters
                dataRange.Cell(i + 1, 3).Value = Math.Round(Math.Round(XmlConvert.ToTimeSpan(row.ItemArray[6].ToString()).TotalMinutes / 60, 2) * 4, MidpointRounding.ToEven) / 4;
                dataRange.Cell(i + 1, 4).Value = row.ItemArray[1];
                dataRange.Cell(i + 1, 5).Value = row.ItemArray[2];
                dataRange.Cell(i + 1, 6).Value = row.ItemArray[3];
                dataRange.Cell(i + 1, 7).Value = row.ItemArray[4];
                dataRange.Cell(i + 1, 8).Value = IsCreative;
                dataRange.Cell(i + 1, 9).Value = row.ItemArray[5];
            }

            // Set borders
            exportRange.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            // Column adjustment
            worksheet.Columns().AdjustToContents();

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "(*.xlsx) Excel | *.xlsx";
                dlg.AddExtension = true;
                dlg.ShowDialog();
                try
                {
                    if (!String.IsNullOrWhiteSpace(dlg.FileName))
                    {
                        workbook.SaveAs(dlg.FileName);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable ImportToExcell(DataTable source)
        {
            throw new NotImplementedException();
        }
    }

        [Export(typeof(TimeeBridge.IExcell))]
        [ExportMetadata("Name", "Import to Excell")]
        [ExportMetadata("Type", "ExcellImport")]
    public class ExcellImport : TimeeBridge.IExcell
    {
            string fileName { get; set; }
            TimeeBridge.TimeeDataSet excellDataSet = new TimeeBridge.TimeeDataSet();
        public DataTable ImportToExcell(DataTable source)
        {

            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "(*.xlsx) Excel | *.xlsx";
                dlg.AddExtension = true;
                dlg.ShowDialog();
                try
                {
                    if (!String.IsNullOrWhiteSpace(dlg.FileName))
                    {
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                this.fileName = dlg.FileName;

            }
            var workbook = new XLWorkbook(this.fileName);
            var worksheet = workbook.Worksheet(1);

            // export range
            IXLRange exportRange = worksheet.Range(1, 1, Int16.MaxValue, 9);
            exportRange.FirstRow().Merge();

            // Fill data
            IXLRange dataRange = exportRange.Range(3, 1, Int16.MaxValue, 9);
            //StringReader tmpXml = new StringReader(xml);
            //DataSet ds = new DataSet();
            //ds.ReadXml(tmpXml);
            int i = 3;
            do{
                var row = excellDataSet.TimeSheetTable.NewTimeSheetTableRow();
                row.Date = Convert.ToDateTime(worksheet.Row(i).Cell(1).Value).Date;
                // dataRange.Cell(i + 1, 2).Value = Person;
                //Round to Quarters
                row.Time = TimeSpan.Zero;
                row.Project = worksheet.Row(i).Cell(4).Value.ToString();
                row.SubProject = worksheet.Row(i).Cell(5).Value.ToString();
                row.Task = worksheet.Row(i).Cell(6).Value.ToString();
                row.Comment = worksheet.Row(i).Cell(9).Value.ToString();
                // dataRange.Cell(i + 1, 8).Value = IsCreative;
                row.Location = worksheet.Row(i).Cell(7).Value.ToString();
                source.Rows.Add(row.ItemArray);
                i++;
            } while(!worksheet.Row(i).IsEmpty());
            
            //this.newXml = ds.GetXml();
            return source;
        }


        public void ExportFromExcell(string xml)
        {
            throw new NotImplementedException();
        }
    }
    
}
