using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataPrepTools
{
    class DupsSingleMulti
    {              
        public static string DupCheck(DataTable excelData)
        {
            //values to get back from form
            string storeNum = null;
            string uniqueField = null;

            //create array of excel column headers
            string[] columnsArray = new string[excelData.Columns.Count];
            for (int i = 0; i < excelData.Columns.Count; i++)
            {
                columnsArray[i] = excelData.Columns[i].ToString();
            }

            //get user input for store number and unique field
            using (var form = new DupsFieldSelectionForm(columnsArray))
            {
                var result = form.ShowDialog();
                if (result != DialogResult.OK) /* I don't think this is the "right" way to do this */
                {
                    storeNum = form.StoreNumber;
                    uniqueField = form.UniqueColumn;
                }
            }
            
            if (storeNum != null && uniqueField != null)
            {
                DataProcessing dataProcessing = new DataProcessing();
                dataProcessing.Show();
                dataProcessing.Update();

                //change fields in checkfordups to match original string names 
                bool ContainsDups = false;

                if (columnsArray.Contains("Dups"))
                {
                    excelData.Columns.Remove("Dups");
                }
                excelData.Columns.Add("Dups");

                //double sort excelData by the store number and unique field 
                DataView sortDT = new DataView(excelData);
                sortDT.Sort = storeNum + "," + uniqueField;

                string previousValue = null;

                for (int i = 0; i < excelData.Rows.Count; i++)
                {
                    //check if selectedColumn value == previousValue.  If yes, add "dup" to Dup column
                    if (sortDT[i][uniqueField].ToString() == previousValue)
                    {
                        sortDT[i]["Dups"] = "DUP";
                        sortDT[i - 1]["Dups"] = "DUP";
                        ContainsDups = true;
                    }

                    //set previous value to 
                    previousValue = sortDT[i][uniqueField].ToString();
                }

                if (ContainsDups == true)
                {
                    MessageBox.Show("Duplicates have been found.  Please remove duplicates.");
                    sortDT.Sort = "Dups DESC," + storeNum + "," + uniqueField;
                    excelData = sortDT.ToTable();

                    Excel.Workbook excelWorkBook = Globals.ThisAddIn.GetActiveWorkbook();
                    Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;   
                    ExportData.ExportDataTableToExcel(excelData, excelWorkSheet);

                    dataProcessing.Close();
                    return null;
                }

                else
                {
                    excelData.Columns.Remove("Dups");
                    dataProcessing.Close();
                    return uniqueField;
                }
            }

            else return null;
        }        
    }
}
