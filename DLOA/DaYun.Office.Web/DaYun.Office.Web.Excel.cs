using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;


namespace DaYun.Office.Web
{
    public static class Excel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">本地路径</param>
        /// <returns></returns>
      public static  StringBuilder getTabHtml(string fileName)
        {

            StringBuilder sb = new StringBuilder();

            HSSFWorkbook wb = new HSSFWorkbook(new FileStream(fileName, FileMode.Open));
            string tabPattern = @"<li role=""presentation"" {2}><a href=""#Sheet{0}"" aria-controls=""Sheet{0}"" role=""tab"" data-toggle=""tab"">{1}</a></li>";
            sb.Append(@"<ul class=""nav nav-tabs"" role=""tablist"">");
            for (int i = 0; i < wb.NumberOfSheets; i++)
            {
                sb.Append(string.Format(tabPattern, i, wb.GetSheetAt(i).SheetName, (i == 0) ? @"class=""active""" : string.Empty));
            }
            sb.Append(@"</ul><div class=""tab-content"">");
            string tabContentPattern = @"<div role=""tabpanel"" class=""tab-pane{2}"" id=""Sheet{0}"">{1}</div>";

            for (int i = 0; i < wb.NumberOfSheets; i++)
            {
                sb.Append(string.Format(tabContentPattern, i, SheetToTable(wb, i), (i == 0) ? " active" : string.Empty));
            }

            sb.Append("</div>");
            return sb;
        }

        
    static    StringBuilder SheetToTable(IWorkbook workBook, int sheetIndex)
        {

            StringBuilder table = new StringBuilder();
            ISheet sheet = workBook.GetSheetAt(sheetIndex);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            int allRows = sheet.LastRowNum + 1;

            IRow row;

            table.Append("<table class='table table-bordered table-hover'>");

            for (int j = 0; j < allRows; j++)
            {

                row = sheet.GetRow(j);
                if (row == null)
                {
                    table.Append("<tr><td class='text-muted active'>" + (j + 1) + "</td></tr>");
                    continue;
                }
                table.Append("<tr><td class='text-muted'>" + (j + 1) + "</td>");
                int colspan = 0, rowspan = 0;
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);

                    if (cell == null)
                    {
                        continue;
                    }
                    else
                    {
                        int fontSize = 5 + cell.CellStyle.GetFont(workBook).FontHeightInPoints;
                        if (isMergeCell(sheet, j + 1, i + 1, out rowspan, out colspan))
                        {
                            if (rowspan > 1 || colspan > 1)
                            {
                                table.Append("<td style='font-size:" + fontSize + "px;' class='text-center' rowspan='" + rowspan + "' colspan='" + colspan + "'>" + cell.ToString() + "</td>");
                                rowspan = 1;
                                colspan = 1;
                            }
                        }
                        else
                        {
                            table.Append("<td  style='font-size:" + fontSize + "px;' >" + cell.ToString() + "</td>");
                        }
                    }
                }
                table.Append("</tr>");
            }
            table.Append("</table>");
            return table;
        }


     public static StringBuilder  ToTable(string fileName, int sheetIndex)
        {

            StringBuilder table = new StringBuilder();
            HSSFWorkbook wb = new HSSFWorkbook(new FileStream(fileName, FileMode.Open));
            ISheet sht = wb.GetSheetAt(sheetIndex);
            System.Collections.IEnumerator rows = sht.GetRowEnumerator();
            int allRows = sht.LastRowNum + 1;
            IRow row;
            table.Append("<table class='table table-bordered table-hover'>");

            for (int j = 0; j < allRows; j++)
            {
                row = (HSSFRow)sht.GetRow(j);
                if (row == null)
                {
                    table.Append("<tr><td class='text-muted active'>" + (j + 1) + "</td></tr>");
                    continue;
                }
                table.Append("<tr><td class='text-muted'>" + (j + 1) + "</td>");
                int colspan = 0, rowspan = 0;
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);

                    if (cell == null)
                    {
                        continue;
                    }
                    else
                    {
                        int fontSize = 5 + cell.CellStyle.GetFont(wb).FontHeightInPoints;
                        if (isMergeCell(sht, j + 1, i + 1, out rowspan, out colspan))
                        {
                            if (rowspan > 1 || colspan > 1)
                            {
                                table.Append("<td style='font-size:" + fontSize + ";' class='text-center' rowspan='" + rowspan + "' colspan='" + colspan + "'>" + cell.ToString() + "</td>");
                                rowspan = 1;
                                colspan = 1;
                            }
                        }
                        else
                        {
                            table.Append("<td  style='font-size:" + fontSize + ";' >" + cell.ToString() + "</td>");
                        }
                    }
                }
                table.Append("</tr>");
            }
            table.Append("</table>");
            return table;



        }

        // 判断合并单元格重载
        // 调用时要在输出变量前加 out
        static bool isMergeCell(ISheet sheet, int rowNum, int colNum, out int rowSpan, out int colSpan)
        {
            bool result = false;
            rowSpan = 0;
            colSpan = 0;
            if ((rowNum < 1) || (colNum < 1)) return result;
            int rowIndex = rowNum - 1;
            int colIndex = colNum - 1;
            int regionsCount = sheet.NumMergedRegions;
            rowSpan = 1;
            colSpan = 1;
            for (int i = 0; i < regionsCount; i++)
            {
                CellRangeAddress range = sheet.GetMergedRegion(i);
                sheet.IsMergedRegion(range);
                if (range.FirstRow == rowIndex && range.FirstColumn == colIndex)
                {
                    rowSpan = range.LastRow - range.FirstRow + 1;
                    colSpan = range.LastColumn - range.FirstColumn + 1;
                    break;
                }
            }
            try
            {
                result = sheet.GetRow(rowIndex).GetCell(colIndex).IsMergedCell;
            }
            catch
            {
            }
            return result;
        }
    }
}
