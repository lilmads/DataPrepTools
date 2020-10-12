using System.Data;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace DataPrepTools
{
    public partial class Data_Prep
    {     
        
        private void Data_Prep_Load(object sender, RibbonUIEventArgs e)
        {
            
        }

        #region Cleaning
        private void DupsSingleMulti_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            string[] mySheet = new string[1];
            mySheet[0] = Globals.ThisAddIn.Application.ActiveSheet.Name;
            DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet(mySheet);

            if (dtTable != null)
            {
                string uniqueField = global::DataPrepTools.DupsSingleMulti.DupCheck(dtTable);

                if (uniqueField != null)
                {
                    DialogResult results = MessageBox.Show("No duplicates have been found.  Would you like to run the UPC Wizard?", "Launch UPC Wizard", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (results == DialogResult.Yes)
                    {                        
                        UPCWizard.AccessToDataSet(dtTable, uniqueField);
                      
                    }
                }
            }
        }

        private void UPCWizard_Btn_Click(object sender, RibbonControlEventArgs e)
        {            
            string[] mySheet = new string[1]; 
            mySheet[0]= Globals.ThisAddIn.Application.ActiveSheet.Name;
            DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet(mySheet);

            if (dtTable != null)
            {
                string uniqueField = global::DataPrepTools.DupsSingleMulti.DupCheck(dtTable);

                if (uniqueField != null)
                {                    
                    UPCWizard.AccessToDataSet(dtTable, uniqueField);
                }
            }
        }
        #endregion

        #region General
        private void About_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            About popUp = new About();
            popUp.ShowDialog();
        }

        private void GoogleImage_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            string searchString = Globals.ThisAddIn.Application.ActiveCell.Value;
            /*search images for selected field in Google*/
            string stringGoogle = "https://www.google.com/search?hl=en&site=imghp&tbm=isch&source=hp&q=" + searchString;

            System.Diagnostics.Process.Start(stringGoogle);
        }

        private void GoogleText_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            string searchString = Globals.ThisAddIn.Application.ActiveCell.Value;
            /*raw Google search results*/
            string stringGoogle = "http://www.google.com/search?q=" + searchString + "&rls=com.microsoft:en-us&ie=UTF-8&oe=UTF-8&startIndex=&startPage=1";

            System.Diagnostics.Process.Start(stringGoogle);
        }
        #endregion

        #region Formatting
        private void ClearFormatting_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.ClearFRMT();
        }

        private void TrimCells_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.TrimSelection();
        }

        private void General_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("General", Excel.XlColumnDataType.xlGeneralFormat);
        }

        private void Text_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("@", Excel.XlColumnDataType.xlTextFormat);
        }

        private void Number_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("#0.00", Excel.XlColumnDataType.xlGeneralFormat);
        }

        private void Currency_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("$#0.00", Excel.XlColumnDataType.xlGeneralFormat);
        }

        private void Percent_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("#0.00%", Excel.XlColumnDataType.xlGeneralFormat);
        }

        private void TDLinx_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("0000000", Excel.XlColumnDataType.xlGeneralFormat);
        }

        private void JDADate_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            global::DataPrepTools.Format.FrmtTXT("0", Excel.XlColumnDataType.xlGeneralFormat);
        }
        #endregion formatting 

        #region WorkbookActions 
        private void CombineSheets_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            int totalSheets = Globals.ThisAddIn.Application.ActiveWorkbook.Sheets.Count;
            string[] mySheet = new string[totalSheets];

            foreach (Excel.Worksheet sheet in Globals.ThisAddIn.Application.ActiveWorkbook.Sheets)
            {
                mySheet[sheet.Index - 1] = sheet.Name;
            }

            DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet(mySheet);
            
            Globals.ThisAddIn.Application.Worksheets.Add();
            Globals.ThisAddIn.Application.ActiveSheet.Name = "All Sheets";
            Excel.Worksheet newSheet = Globals.ThisAddIn.Application.ActiveSheet;

            ExportData.ExportDataTableToExcel(dtTable, newSheet);
        }

        private void AOD_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            DataProcessing dataProcessing = new DataProcessing();
            dataProcessing.Show();
            dataProcessing.Update();

            Format.RemoveRows();

            string[] mySheet = new string[1];
            mySheet[0] = Globals.ThisAddIn.Application.ActiveSheet.Name;
            DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet(mySheet);

            if (dtTable != null)
            {
                //reformats weeks field
                dtTable = AOD.CleanWeeks(dtTable);
                //excutes the combining of data
                DataTable aodData = AOD.CombineRows(dtTable);
                //adds a new sheet to workbook
                Excel.Worksheet aodSheet = (Excel.Worksheet)Globals.ThisAddIn.Application.Worksheets.Add();
                aodSheet.Name = "AOD Data";

                ExportData.ExportDataTableToExcel(aodData, aodSheet);

                
            }
            dataProcessing.Close();
        }
        #endregion

        #region SolutionDesigners
        private void GlobalSwap_Btn_Click(object sender, RibbonControlEventArgs e)
        {
            //string[] mySheet = new string[1];
            //mySheet[0] = Globals.ThisAddIn.Application.ActiveSheet.Name;
            //System.Data.DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet(mySheet);
            //global::DataPrepTools.GlobalSwaps.FormatSwaps(dtTable);
        }
        #endregion
    }
}
