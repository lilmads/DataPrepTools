using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


using System.Reflection;
using LinqToExcel;
using Microsoft.Office.Interop.Excel;

namespace DataPrepTools
{
    class ExportData
    {
        public static void ExportDataTableToExcel(System.Data.DataTable excelData, Worksheet excelWorkSheet)
        {
            Application oExcel = ThisAddIn.GetActiveApplication();
            excelWorkSheet.Cells.ClearContents();
            excelWorkSheet.Cells.ClearFormats();
            Commands.Updates(oExcel, false);

            string[,] dump = new string[excelData.Rows.Count + 1, excelData.Columns.Count];


            for (int i = 0; i < excelData.Columns.Count; i++)
            {
                dump[0, i] = excelData.Columns[i].ColumnName;
            }
            for (int j = 1; j < excelData.Rows.Count + 1; j++)
            {
                for (int k = 0; k < excelData.Columns.Count; k++)
                {
                    dump[j, k] = excelData.Rows[j - 1].ItemArray[k].ToString();
                }
            }

            Excel.Range excelCellrange;
            excelCellrange = excelWorkSheet.Range[excelWorkSheet.Cells[1, 1], excelWorkSheet.Cells[excelData.Rows.Count + 1, excelData.Columns.Count]];
            excelCellrange.Value = dump;

            Commands.Updates(oExcel);
            excelData.Clear();
            return;
        }
    }
}
