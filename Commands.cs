using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace DataPrepTools
{
    class Commands
    {
        /// <summary>
        /// turn on/off display alerts and screen updating to speed up functionality and reduce screen flicker
        /// </summary>
        /// <param name="xl">Excel Application</param>
        /// <param name="booUpdate">bool determining if turn on or off</param>
        public static void Updates(Application oExcel, bool booUpdate = true)
        {
            if (oExcel.CommandBars.GetEnabledMso("FileNewDefault") == false) System.Windows.Forms.SendKeys.SendWait("{ESC}");   //makes sure that user is not editing cells - will cancel any entry
            oExcel.DisplayAlerts = booUpdate;
            oExcel.ScreenUpdating = booUpdate;
        }

        /// <summary>
        /// Reset the used range to ensure captured data does not include a large number of blank rows
        /// </summary>
        /// <param name="oExcel">Excel Application</param>
        public void ResetUsedrange(Application oExcel)
        {
            Worksheet wksht = oExcel.ActiveWorkbook.ActiveSheet;
            Range ur = null;

            //Determine if the sheet contains both formulas and constants
            try
            {
                ur = oExcel.Union(wksht.UsedRange.SpecialCells(XlCellType.xlCellTypeConstants), wksht.UsedRange.SpecialCells(XlCellType.xlCellTypeFormulas));
            }
            catch (Exception)
            {
                //If both fails, try constants only
                try
                {
                    ur = wksht.UsedRange.SpecialCells(XlCellType.xlCellTypeConstants);
                }
                catch (Exception)
                {
                    //If constants fails then set it to formulas
                    try
                    {
                        ur = wksht.UsedRange.SpecialCells(XlCellType.xlCellTypeFormulas);
                    }
                    catch (Exception)
                    {
                        //If there is still an error then the worksheet is empty
                        if (wksht.UsedRange.Address != "$A$1")
                        {
                            wksht.UsedRange.EntireRow.Hidden = false;
                            wksht.UsedRange.EntireColumn.Hidden = false;
                            double rh = wksht.StandardHeight;
                            if (rh != 12.75)
                            {
                                rh = 12.75;
                            }
                            else
                            {
                                rh = 13;
                            }
                            wksht.UsedRange.EntireColumn.RowHeight = rh;
                            wksht.UsedRange.EntireColumn.ColumnWidth = 10;
                            wksht.UsedRange.EntireRow.Clear();

                            //reset column width which can also cause last cell to be innacurate
                            wksht.UsedRange.EntireColumn.ColumnWidth = wksht.StandardWidth;

                            //reset row height which can also case lastcell to be innacurate
                            if (wksht.StandardWidth < 1)
                            {
                                wksht.UsedRange.EntireRow.RowHeight = 12.75;
                            }
                            else
                            {
                                wksht.UsedRange.EntireRow.RowHeight = wksht.StandardHeight;
                            }
                        }
                        else
                        {
                            ur = null;
                        }
                    }
                }
            }

            if (ur != null)
            {
                int arCount = ur.Areas.Count;
                int i = 0;
                long r = 0;
                long c = 0;

                //determine last column and row that contains data or formula
                foreach (Range ar in ur.Areas)
                {
                    i++;
                    long tr = ar.Range["A1"].Row + ar.Rows.Count - 1;
                    long tc = ar.Range["A1"].Column + ar.Columns.Count - 1;
                    if (tc > c) c = tc;
                    if (tr > r) r = tr;
                }

                oExcel.Application.StatusBar = "Clearing Excess Cells in " + wksht.Name + ", Please Wait...";

                if (r < wksht.Rows.Count)
                {
                    ur = wksht.Rows[r + 1 + ":" + wksht.Rows.Count];
                    ur.EntireRow.Hidden = false;

                    double rh = wksht.StandardHeight;
                    if (rh != 12.75)
                    {
                        rh = 12.75;
                    }
                    else
                    {
                        rh = 13;
                    }
                    ur.EntireRow.RowHeight = rh;

                    //reset row height which can also cause the lastcell to be innacurate
                    if (wksht.StandardHeight < 1)
                    {
                        ur.RowHeight = 12.75;
                    }
                    else
                    {
                        ur.RowHeight = wksht.StandardHeight;
                    }

                    try
                    {
                        Range x = ur.Dependents;
                        ur.Clear();
                    }
                    catch (Exception)
                    {
                        ur.Delete();
                    }
                }

                if (c < wksht.Columns.Count)
                {
                    ur = wksht.Range[wksht.Cells[1, c + 1], wksht.Cells[1, wksht.Columns.Count]].EntireColumn;
                    ur.EntireColumn.Hidden = false;
                    ur.ColumnWidth = 18;

                    //reset column width
                    ur.EntireColumn.ColumnWidth = wksht.StandardWidth;

                    try
                    {
                        Range x = ur.Dependents;
                        ur.Clear();
                    }
                    catch (Exception)
                    {
                        ur.Delete();
                    }
                }
            }

            oExcel.Application.StatusBar = false;
            Commands.Updates(oExcel);
        }

        public static void UpdatingMessage(string ThingRunning)
        {
            Application oExcel = ThisAddIn.GetActiveApplication();
            oExcel.Application.StatusBar = ThingRunning + " is processing. Please Wait...";
        }
        public static void ClearMessage()
        {
            Application oExcel = ThisAddIn.GetActiveApplication();
            oExcel.Application.StatusBar = false;
        }
    }
}
