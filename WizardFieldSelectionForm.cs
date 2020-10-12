using System;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;

namespace DataPrepTools
{
    public partial class WizardFieldSelectionForm : Form
    {
        
        public string SelectedColumn { get; set; }
        public string ColumnType { get; set; }
        public string ReturnedFields { get; set; }

        public WizardFieldSelectionForm(string uniqueFIeld, string[] accessFieldsArray)
        {
            InitializeComponent();
            string[] fieldType = new string[] {"ID","Name","UPC"};

           

            fieldType_Label.Text = uniqueFIeld +"is a(n): ";
            columnType_Combox.DataSource = fieldType;
            columnType_Combox.SelectedIndex = -1;           
            returnedFields_Listbox.DataSource = accessFieldsArray;
            returnedFields_Listbox.SelectedIndex = -1;
        }

        private void Select_Btn_Click(object sender, EventArgs e)
        {
            //processFormInput();       
            this.ColumnType = columnType_Combox.Text;
            this.ReturnedFields = String.Join(",", returnedFields_Listbox.SelectedItems.Cast<string>());
            
            this.Close();
            
            
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.SelectedColumn = null;
            this.ColumnType = null;
            this.ReturnedFields = null;

            this.Close();
           
        }

    }
}
