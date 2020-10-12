using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using System.Windows.Forms;
using Remotion.Collections;
using LinqToExcel.Extensions;
using System.Diagnostics;


namespace DataPrepTools
{
    class AOD
    {        
        public static DataTable CombineRows(DataTable excelData)
        {
            //MAKE NEW DATATABLE
            DataTable AODdata = NewTable();

            //GET EACH DISTINCT STORE
            var distinctStores = (from DataRow dRow in excelData.Rows
                                  select dRow["Store Number"]).Distinct();            

            foreach (var store in distinctStores)
            {
                //GET DISTINCT ITEMS FOR STORE
                IEnumerable<string> distinctItems = (excelData.AsEnumerable()
                    .Where(row => row.Field<string>("Store Number") == store.ToString())
                    .Select(row => row.Field<string>("LONG PRODUCT DESCRIPTION"))
                    ).Distinct();

                foreach (var items in distinctItems)
                {
                    //add row and set all values
                    DataRow thisRow = AODdata.NewRow();

                    thisRow["PLANOGRAM ALIAS"] = store;

                    thisRow["UPC"] = (excelData.AsEnumerable()
                        .Where(row =>
                        (row.Field<string>("Store Number") == store.ToString())
                        &&
                        (row.Field<string>("LONG PRODUCT DESCRIPTION") == items))
                        .Select(row => row.Field<string>("MC_DIGIT11UPC(C)"))
                        ).First();

                    thisRow["NAME"] = items;

                    #region Weeks
                    string firstWeek = excelData.AsEnumerable()
                        .Where(row =>
                        (row.Field<string>("Store Number") == store.ToString())
                        &&
                        (row.Field<string>("LONG PRODUCT DESCRIPTION") == items))
                        .Select(row => row.Field<string>("Weeks")
                        ).Min(); 

                    string lastWeek = excelData.AsEnumerable()
                        .Where(row =>
                        (row.Field<string>("Store Number") == store.ToString())
                        &&
                        (row.Field<string>("LONG PRODUCT DESCRIPTION") == items))
                        .Select(row => row.Field<string>("Weeks")
                        ).Max();

                    DateTime dateValue1 = Convert.ToDateTime(firstWeek);
                    DateTime dateValue2 = Convert.ToDateTime(lastWeek);
                    double totalWeeks = ((dateValue2 - dateValue1).TotalDays / 7)+1;

                    #endregion

                    thisRow["DESC 19"] = firstWeek;/*first week*/
                    thisRow["DESC 20"] = lastWeek; /*last week*/
                    thisRow["VALUE 27"] = totalWeeks; /*total weeks*/

                    #region Sales
                    //get and set total sales
                    double sumSales = (excelData.AsEnumerable()
                        .Where(row =>
                        (row.Field<string>("Store Number") == store.ToString())
                        &&
                        (row.Field<string>("LONG PRODUCT DESCRIPTION") == items))
                        .Select(row => row.Field<double>("$")).Sum()
                        );                    
                    #endregion

                    thisRow["VALUE 43"] = "$"+Math.Round(sumSales, 2);

                    #region Units
                    //get and set total units
                    double unitsSum = (excelData.AsEnumerable()
                        .Where(row =>
                        (row.Field<string>("Store Number") == store.ToString())
                        &&
                        (row.Field<string>("LONG PRODUCT DESCRIPTION") == items))
                        .Select(row => row.Field<double>("Units")).Sum()
                        );
                    //int sumUnits = 0;
                    //foreach (var item in unitsString)
                    //{
                    //    int nums = 0;
                    //    Int32.TryParse(item, out nums);
                    //    sumUnits += nums;
                    //}
                    double unitMovement = unitsSum / totalWeeks;
                    #endregion

                    thisRow["UNITS"] = unitsSum;                    
                    thisRow["UNIT MOVEMENT"] = unitMovement;                     
                    thisRow["PRICE"] = "$"+ Math.Round(sumSales / unitsSum, 2);                                      

                    AODdata.Rows.Add(thisRow);
                    AODdata.AcceptChanges();
                    //Debug.WriteLine(items);
                }
                //Debug.WriteLine(store);
            }
            return AODdata;
        }
        public static DataTable NewTable()
        {
            DataTable AODdata = new DataTable("AOD");
            AODdata.Columns.Add("PLANOGRAM ALIAS");
            AODdata.Columns.Add("UPC");
            AODdata.Columns.Add("NAME");
            AODdata.Columns.Add("DESC 19");
            AODdata.Columns.Add("DESC 20");
            AODdata.Columns.Add("VALUE 27");
            AODdata.Columns.Add("VALUE 43");
            AODdata.Columns.Add("UNITS");
            AODdata.Columns.Add("UNIT MOVEMENT");
            AODdata.Columns.Add("PRICE");

            return AODdata;
        }
        public static DataTable CleanWeeks(DataTable newData)
        {
            foreach (var dataRow in newData.AsEnumerable() )
            {
                string value = dataRow.Field<string>("Weeks");

                    value = value.Substring(value.LastIndexOf("W/E") + 4).ToString();
                    dataRow.SetField("Weeks", value);                
            }
            newData.AcceptChanges();
            return newData;
        }
    }
}
