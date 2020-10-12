using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

using excel = Microsoft.Office.Interop.Excel;
using LinqToExcel;
using LinqToExcel.Extensions;

namespace DataPrepTools
{
    class CreateDataSet
    {
        public static DataTable ExcelToDataSet(string[] mySheet)
        {
            string myPath = Globals.ThisAddIn.Application.ActiveWorkbook.FullName;
            string myFile = Globals.ThisAddIn.Application.ActiveWorkbook.Name;

            excel.Workbook excelWorkBook = Globals.ThisAddIn.GetActiveWorkbook();

            try 
            {
                excelWorkBook.Save();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            


            DataSet DtSet = new DataSet("DPT");
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            try
            {             

                //Checking to see if file is on sharepoint or not, then filling datatable in new dataset
                if (myPath.Contains("my.sharepoint.com"))
                {
                    //GET USER'S ID
                    int firstStringPosition = myPath.IndexOf("personal/") + 9;
                    int secondStringPosition = myPath.IndexOf("_millercoors");
                    string myUserID = myPath.Substring(firstStringPosition, secondStringPosition - firstStringPosition);

                    //CREATE LOCAL PATH TO ACTIVE SHAREPOINT DESKTOP FILE
                    string desktopPath = string.Format(@"C:\Users\{0}\OneDrive - Molson Coors Brewing Company\Desktop\{1}", myUserID, myFile);

                    MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + desktopPath + "'; Extended Properties=\"Excel 12.0 Xml; HDR = YES\";");
                }
                else
                {
                    MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= '" + myPath + "'; Extended Properties=\"Excel 12.0 Xml; HDR = YES\";");
                }

                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + mySheet[0] + "$]", MyConnection);

                MyCommand.TableMappings.Add("Table", "ExcelDataTable");
                DataTable excelData = DtSet.Tables.Add("ExcelData");
                MyCommand.Fill(excelData);

                foreach (DataColumn col in excelData.Columns)
                    col.ColumnName = col.ColumnName.Trim();

                //for combining all sheets                
                if (mySheet.Length > 1)
                {
                    //make clone that converts all datatypes to string (for mismatched datatypes on merge)
                    DataTable excelData2 = excelData.Clone();
                    for (int i = 0; i < excelData.Columns.Count; i++)
                    {
                        excelData2.Columns[i].DataType = typeof(string);
                    }
                    foreach (DataRow row in excelData.Rows)
                    {
                        excelData2.ImportRow(row);
                    }
                    excelData2.PrimaryKey = null;

                    //make datatable of the next sheet
                    DataTable tempData = DtSet.Tables.Add("TempData");
                    for (int i = 1; i < mySheet.Length; i++)
                    {
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + mySheet[i] + "$]", MyConnection);
                        MyCommand.Fill(tempData);

                        //convert tempData to strings
                        DataTable tempData2 = tempData.Clone();
                        for (int j = 0; j < tempData.Columns.Count; j++)
                        {
                            tempData2.Columns[j].DataType = typeof(string);
                        }
                        foreach (DataRow row in tempData.Rows)
                        {
                            tempData2.ImportRow(row);
                        }
                        tempData2.PrimaryKey = null;

                        //merge tables and clear tempdata and tempdata2 (clone)
                        excelData2.Merge(tempData2);
                        tempData.Clear();
                        tempData.Columns.Clear();
                        tempData2.Clear();
                        tempData2.Columns.Clear();
                    }
                    MyConnection.Close();
                    return excelData2;
                }
                else
                {

                    for (int i = excelData.Rows.Count - 1; i >= 0; i--)
                    {
                        if (excelData.Rows[i][1] == DBNull.Value)
                        {
                            excelData.Rows[i].Delete();
                        }
                    }
                    MyConnection.Close();
                    excelData.AcceptChanges();
                    return excelData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Data Prep Tool can't identify a useable file path for this document." +
                    "Try saving this document to your local machine or accessable drives.");
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
