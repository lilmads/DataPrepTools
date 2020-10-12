using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using Microsoft.Office.Interop.Excel;

namespace DataPrepTools
{
    class Format
    {
        #region FORMATTING
        /// <summary>
        /// trim the selected cells (removing leading and trailing spaces)
        /// </summary>
        public static void TrimSelection()
        {
            Application oExcel = ThisAddIn.GetActiveApplication();

            Commands.Updates(oExcel, false);
            foreach (var cell in oExcel.Selection)
            {
                cell.value = oExcel.WorksheetFunction.Trim(cell.value);
            }
            Commands.Updates(oExcel);
        }

        /// <summary>
        /// Format the selection according to the given Column Data Type
        /// </summary>
        /// <param name="format">the format to set </param>
        /// <param name="clmnType">the Excel Column Data Type</param>
        public static void FrmtTXT(string format, XlColumnDataType clmnType)
        {
            Application oExcel = ThisAddIn.GetActiveApplication();

            Commands.Updates(oExcel, false);

            Range range = oExcel.Selection;
            long r = range.Row + range.Rows.Count - 1;

            for (int c = range.Column; c < range.Column + range.Columns.Count; c++)
            {
                Range range0 = (Range)oExcel.Range[oExcel.Cells[range.Row, c], oExcel.Cells[r, c]];

                if (oExcel.WorksheetFunction.CountA(range0, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing) > 0)
                {
                    int[,] myArray = new int[,] { { 1, (int)clmnType } };
                    oExcel.Cells[1, 1].Select();

                    range0.TextToColumns(range0, FieldInfo: myArray);

                    range0.Select();

                    range0.NumberFormat = format;

                    Marshal.ReleaseComObject(range0);
                }
            }

            range.Select();

            Marshal.ReleaseComObject(range);
            Commands.Updates(oExcel);
        }

        public static void ClearFRMT()
        {
            Application oExcel = ThisAddIn.GetActiveApplication();

            Commands.Updates(oExcel, false);

            Range range = oExcel.Selection;
            range.ClearFormats();

            Commands.Updates(oExcel);
        }

        public static void RemoveRows()
        {
        //    Application oExcel = ThisAddIn.GetActiveApplication();

        //    Commands.Updates(oExcel, false);

        //    ///TODO
        //    ///REMOVE TOP THREE ROWS
        //    ///
        //    Range range = oExcel.Range["A1","A3"];
        //    range.EntireRow.Delete(Type.Missing);

        //    Commands.Updates(oExcel);
        }

        #endregion

    }
}
