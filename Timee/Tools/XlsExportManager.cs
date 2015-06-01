using ClosedXML.Excel;
using System;
using System.Data;

namespace Timee.Tools
{
    public class XlsExportManager
    {
        public void ExportAllEntries(DataRowCollection entries)
        {
            var workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Timee");
            
            // export range
            IXLRange exportRange = worksheet.Range(1, 1, Int16.MaxValue, 7);
            exportRange.FirstRow().Merge();

            // Set header
            IXLRange headerRange = exportRange.Range(1, 1, 1, 7);
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.GreenPigment;

            headerRange.Cell(1, 1).Value = "Timee export";

            // Set titles
            IXLRange titlesRange = exportRange.Range(2, 1, 2, 7);
            titlesRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            titlesRange.Style.Font.Bold = true;

            titlesRange.Cell(1, 1).Value = "Time";
            titlesRange.Cell(1, 2).Value = "Date";
            titlesRange.Cell(1, 3).Value = "Project";
            titlesRange.Cell(1, 4).Value = "SubProject";
            titlesRange.Cell(1, 5).Value = "Task";
            titlesRange.Cell(1, 6).Value = "Location";
            titlesRange.Cell(1, 7).Value = "Comment";


            // Formatting
            IXLRange dateTimeRange = exportRange.Range(3, 1, Int16.MaxValue, 2);
            dateTimeRange.Style.NumberFormat.NumberFormatId = 14;
            
            // Fill data
            IXLRange dataRange = exportRange.Range(3, 1, Int16.MaxValue, 7);

            for(int i = 0; i < entries.Count; i++)
            {
                dataRange.Cell(i + 1, 1).Value = entries[i][0];
                dataRange.Cell(i + 1, 2).Value = entries[i][1];
                dataRange.Cell(i + 1, 3).Value = entries[i][2];
                dataRange.Cell(i + 1, 4).Value = entries[i][3];
                dataRange.Cell(i + 1, 5).Value = entries[i][4];
                dataRange.Cell(i + 1, 6).Value = entries[i][5];
                dataRange.Cell(i + 1, 7).Value = entries[i][6];
            }
            
            // Set borders
            exportRange.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            
            // Column adjustment
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs("Timee.xlsx");
        }
    }
}
