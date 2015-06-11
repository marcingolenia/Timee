using ClosedXML.Excel;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Timee.DAL;

namespace Timee.Plugins.LGBSExcelExport
{
    public class XlsExportManager
    {
        public void ExportAllEntries(DataRowCollection entries)
        {
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
            var conf = LGBSExcelExportConfigurationService.Instance.LoadConfiguration();
            IXLRange dataRange = exportRange.Range(3, 1, Int16.MaxValue, 9);

            for(int i = 0; i < entries.Count; i++)
            {
                var row = (TimeeDataSet.TimeSheetTableRow)entries[i];
                dataRange.Cell(i + 1, 1).Value = row.Date;
                dataRange.Cell(i + 1, 2).Value = conf.Settings.Person.value;
                dataRange.Cell(i + 1, 3).Value = Math.Round(row.Time.TotalMinutes / 60, 2);
                dataRange.Cell(i + 1, 4).Value = row.Project;
                dataRange.Cell(i + 1, 5).Value = row.SubProject;
                dataRange.Cell(i + 1, 6).Value = row.Task;
                dataRange.Cell(i + 1, 7).Value = row.Comment;
                dataRange.Cell(i + 1, 8).Value = conf.Settings.IsCreative.value;
                dataRange.Cell(i + 1, 9).Value = row.Location;
            }
            
            // Set borders
            exportRange.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            
            // Column adjustment
            worksheet.Columns().AdjustToContents();

            using(var dlg = new SaveFileDialog())
            {
                dlg.Filter = "(*.xlsx) Excel | *.xlsx";
                dlg.AddExtension = true;
                dlg.ShowDialog();
                try
                {
                    workbook.SaveAs(dlg.FileName);
                }
                catch(IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }       
        }
    }
}
