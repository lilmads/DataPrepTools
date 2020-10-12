using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using LinqToExcel;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DataPrepTools
{
    class GlobalSwaps
    {
        public static void FormatSwaps(DataTable dtTable) 
        {
            //need to move this to button
            //DataTable dtTable = global::DataPrepTools.CreateDataSet.ExcelToDataSet();

            ///TODO       
            ///CHECK FOR COLUMNS LABELED "DBKEY" AND "STATUS" - done
            ///REMOVE ALL ROWS WHERE STATUS = HISTORIC OR ANALYSIS - done
            ///SURROUND EACH DBKEY VALUE WITH SINGLE QUOTES - done
            ///ADD NEW TABLE OF OUTPUT - done
            ///FOR EACH STATUS 
            ///-ADD STATUS TO ROW
            ///-MAKE A STRING OF 99 ROWS SEPERATED BY COMMAS
            ///-ADD STRING ROWS TO NEW TABLE 
            ///

            //CHECK FOR COLUMNS LABELED "DBKEY" AND "STATUS" - done
            DataColumnCollection columns = dtTable.Columns;
            bool containsStatus = columns.Contains("STATUS");
            bool containsDbkey = columns.Contains("DBKEY");

            if (containsDbkey == false || containsStatus == false)
            {
                MessageBox.Show("You're missing columns labeled \"STATUS\" and/or \"DBKEY\". \nPlease add these headers, then try running Global Swaps again.");
                return;
            }
            else;

            //REMOVE ALL ROWS WHERE STATUS = HISTORIC OR ANALYSIS 
            //SURROUND EACH DBKEY VALUE WITH SINGLE QUOTES
            dtTable.Columns.Add("dbk", typeof(string));

            foreach (DataRow dr in dtTable.Rows) 
            {
                if (dr["status"].ToString() == "Historic" || dr["status"].ToString() == "Analysis")
                    dr.Delete();
                else 
                {
                    dr["dbk"] = "'" + dr["dbkey"] + "'";
                }
            }
            dtTable.AcceptChanges();

            //ADD NEW TABLE OF OUTPUT 
            DataTable output = new DataTable();            
            output.Columns.Add("Filter Value");

            //create a list FOR EACH STATUS 
            var distStatus = dtTable.AsEnumerable()
                .Select(s =>  s.Field<string>("status"))
                .Distinct().ToList();

            ///for each item in list
            ///-ADD STATUS TO ROW
            ///-MAKE A STRING OF 99 ROWS SEPERATED BY COMMAS
            ///-ADD STRING ROWS TO NEW TABLE 
            ///

            foreach (var item in distStatus) 
            {
                output.Rows.Add(item);

                string[] values = new string[99];
                
                var statusCount = dtTable.AsEnumerable()
                .Where(s => s.Field<string>("status") == item)
                .Count();

                //ONLY WORKS FOR THE FIRST SET OF J 
                for (int i = 0; i < statusCount - 1; i = i+99) 
                {
                    for (int j = 0; j <99; j++)
                    {
                        values[j] += dtTable.Rows[i]["dbk"];
                    }
                    string value = string.Join(",", values);
                    output.Rows.Add(value);
                    values = null;
                    
                }

                
            }

            Debug.WriteLine("You're here");
            
        }
    }
}
