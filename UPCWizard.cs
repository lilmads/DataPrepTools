using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using System.Windows.Forms.Integration;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;


namespace DataPrepTools
{   
    public class UPCWizard
    {      
        public static void AccessToDataSet(DataTable excelData, string uniqueField)
        {
            try
            {
                DataSet DtSet = new DataSet("DPT");
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbDataAdapter MyCommand;

                //Create connection to access database and add to table in dataset
                MyConnection = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= 'C:\Space\Database\MillerCoors.mdb' ; Persist Security Info=False;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [MillerCoors Beer Database]", MyConnection);
                MyCommand.TableMappings.Add("Table", "AccessDataTable");
                DataTable accessData1 = DtSet.Tables.Add("AccessData");

                MyCommand.Fill(accessData1);
                MyConnection.Close();

                //create array of excel column headers
                string[] columnsArray = new string[excelData.Columns.Count];
                for (int i = 0; i < excelData.Columns.Count; i++)
                {
                    columnsArray[i] = excelData.Columns[i].ToString();
                }

                //create array of access column headers
                string[] accessFieldsArray = new string[accessData1.Columns.Count];
                for (int i = 0; i < accessData1.Columns.Count; i++)
                {
                    accessFieldsArray[i] = accessData1.Columns[i].ToString();
                }

                //make clone that converts all datatypes to string (for dynamic LINQ)
                DataTable accessData = accessData1.Clone();
                for (int i = 0; i < accessFieldsArray.Length - 1; i++)
                {
                    accessData.Columns[i].DataType = typeof(string);
                }
                foreach (DataRow row in accessData1.Rows)
                {
                    accessData.ImportRow(row);
                }

                //checking to see if there are duplicates between excel column headers and access column headers            
                var duplicates = columnsArray.Intersect(accessFieldsArray, StringComparer.OrdinalIgnoreCase);
                string Intersection = String.Join(", ", duplicates);

                if (Intersection.Length > 1)
                {
                    DialogResult result = MessageBox.Show(
                        "By selecting OK, the UPC Wizard will remove the matching columns from the returnable fields.  " +
                        "\n \n If you would like to change the column headers, hit Cancel. " +
                        "\n \n Matching columns: " + Intersection, "Excel sheet contains column headers that match the Database.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    foreach (var item in duplicates)
                    {
                        accessFieldsArray = Array.FindAll(accessFieldsArray, x => x != item);
                    }
                }

                //values to get back from form                
                string selectedColumn = uniqueField;
                string columnType = null;
                string returnedFields = null;

                //get user input for excel field and fields to return
                using (var form = new WizardFieldSelectionForm(uniqueField, accessFieldsArray))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        columnType = form.ColumnType;
                        returnedFields = form.ReturnedFields;
                    }
                    else
                    {
                        return;
                    }
                }

                //DataProcessing dataProcessing = new DataProcessing();
                //dataProcessing.Show();            
                //dataProcessing.Update();

                DataProcessing dataProcessing = new DataProcessing();
                dataProcessing.Show();
                dataProcessing.Update();
                Commands.UpdatingMessage("UPC WIZARD");

                //add returnFields as columns in excelData      
                string[] newColumns = returnedFields.Split(',');
                for (int i = 0; i < newColumns.Length; i++)
                {
                    string newColumn = newColumns[i];
                    excelData.Columns.Add(newColumn, typeof(String));
                }

                var caseSwitch = columnType;
                switch (caseSwitch)
                {
                    case "UPC":
                        GivenUPC(excelData, accessData, selectedColumn, newColumns);
                        break;

                    case "ID":
                        GivenID(excelData, accessData, selectedColumn, newColumns);
                        break;

                    case "Name":
                        GivenName(excelData, accessData, selectedColumn, newColumns);
                        break;
                }
                //bubble blanks to top                 
                DataView sortDT = new DataView(excelData)
                {
                    Sort = (newColumns[0]) + "," + uniqueField
                };   
                excelData = sortDT.ToTable();

                //Exports dataset back into UPC Wizard tab
                Excel.Workbook excelWorkBook = Globals.ThisAddIn.GetActiveWorkbook();
                Excel.Worksheet excelWorkSheet = excelWorkBook.ActiveSheet;   
                ExportData.ExportDataTableToExcel(excelData, excelWorkSheet);

                Commands.ClearMessage();
                dataProcessing.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public static void GivenID(DataTable excelData, DataTable accessData, string selectedColumn, string[] newColumns)
        {
            int ncl = newColumns.Length;
            var distinctRows = (from DataRow dRow in excelData.Rows
                                select dRow[selectedColumn]).Distinct();

            foreach (var dist in distinctRows)
            {
                string[] results = new string[ncl];

                for (int i = 0; i < ncl; i++)
                {
                    ///QUERY ON VALUE CREATED                                      
                    IEnumerable<string> dbVal = from access in accessData.AsEnumerable()
                                                where access.Field<string>("ID") == dist.ToString()
                                                select access.Field<string>(newColumns[i]);
                    foreach (string value in dbVal)
                    {
                        results[i] = value;
                    }
                }

                //UPDATE ALL COLUMNS in excel data WHERE EXCEL SELECTED COLUMN == DIST              
                var distRow = from excel in excelData.AsEnumerable()
                              where excel.Field<string>(selectedColumn) == dist.ToString()
                              select excel;

                foreach (var row in distRow)
                {
                    for (int i = 0; i < ncl; i++)
                    {
                        row[newColumns[i]] = results[i];
                    }
                }
            }
        }
        public static void GivenUPC(DataTable excelData, DataTable accessData, string selectedColumn, string[] newColumns)
        {
            //UPC fields in DB are: UPC, DIGIT12UPC, DIGIT10UPC, DIGIT11CHECK, DIGIT11UPC, DIGIT11RET, GTIN13DIGIT, GTIN14DIGIT, MC RPL UPC 
            string[] upcfields = { "MC RPL UPC" , "UPC", "DIGIT12UPC", "DIGIT10UPC", "DIGIT11CHECK",
                                    "DIGIT11UPC", "DIGIT11RET", "GTIN13DIGIT", "GTIN14DIGIT"};
            int ncl = newColumns.Length;
            var distinctRows = (from DataRow dRow in excelData.Rows
                                select dRow[selectedColumn]).Distinct();

            foreach (var dist in distinctRows)
            {
                string[] results = new string[ncl];

                for (int i = 0; i < ncl; i++)
                {
                    ///QUERY ON DISTINCT SELECTED FIELD                                   
                    IEnumerable<string> dbVal = from access in accessData.AsEnumerable()
                                                where access.Field<string>(upcfields[0]) == dist.ToString()
                                                || access.Field<string>(upcfields[1]) == dist.ToString()
                                                || access.Field<string>(upcfields[2]) == dist.ToString()
                                                || access.Field<string>(upcfields[3]) == dist.ToString()
                                                || access.Field<string>(upcfields[4]) == dist.ToString()
                                                || access.Field<string>(upcfields[5]) == dist.ToString()
                                                || access.Field<string>(upcfields[6]) == dist.ToString()
                                                || access.Field<string>(upcfields[7]) == dist.ToString()
                                                || access.Field<string>(upcfields[8]) == dist.ToString()
                                                select access.Field<string>(newColumns[i]);
                    foreach (string value in dbVal)
                    {
                        results[i] = value;
                    }
                }

                //UPDATE ALL COLUMNS in excel data WHERE EXCEL SELECTED COLUMN == DIST              
                var distRow = from excel in excelData.AsEnumerable()
                              where excel.Field<string>(selectedColumn) == dist.ToString()
                              select excel;

                foreach (var row in distRow)
                {
                    for (int i = 0; i < ncl; i++)
                    {
                        row[newColumns[i]] = results[i];
                    }
                }
            }
        }


        public static void GivenName(DataTable excelData, DataTable accessData, string selectedColumn, string[] newColumns)
        {
            //Name fields in DB are: Name, Alternative Name, BRAND
            string[] upcfields = { "Name", "Alternative Name", "BRAND" };
            int ncl = newColumns.Length;
            var distinctRows = (from DataRow dRow in excelData.Rows
                                select dRow[selectedColumn]).Distinct();

            foreach (var dist in distinctRows)
            {
                string[] results = new string[ncl];

                for (int i = 0; i < ncl; i++)
                {
                    ///QUERY ON DISTINCT SELECTED FIELD                                   
                    IEnumerable<string> dbVal = from access in accessData.AsEnumerable()
                                                where access.Field<string>(upcfields[0]) == dist.ToString()
                                                || access.Field<string>(upcfields[1]) == dist.ToString()
                                                || access.Field<string>(upcfields[2]) == dist.ToString()
                                                select access.Field<string>(newColumns[i]);
                    foreach (string value in dbVal)
                    {
                        results[i] = value;
                    }
                }

                //UPDATE ALL COLUMNS in excel data WHERE EXCEL SELECTED COLUMN == DIST              
                var distRow = from excel in excelData.AsEnumerable()
                              where excel.Field<string>(selectedColumn) == dist.ToString()
                              select excel;

                foreach (var row in distRow)
                {
                    for (int i = 0; i < ncl; i++)
                    {
                        row[newColumns[i]] = results[i];
                    }
                }
            }
        }
    }
}
