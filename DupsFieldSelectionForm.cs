using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace DataPrepTools
{
    public partial class DupsFieldSelectionForm : Form
    {
        public string StoreNumber { get; set; }
        public string UniqueColumn { get; set; }

        public DupsFieldSelectionForm(string[] columnsArray)
        {
            InitializeComponent();
            storeNum_Combox.DataSource = columnsArray.ToArray();
            storeNum_Combox.SelectedIndex = -1;
            uniqueField_Combox.DataSource = columnsArray.ToArray();
            uniqueField_Combox.SelectedIndex = -1;
        }

        private void Select_Btn_Click(object sender, EventArgs e)
        {
            this.StoreNumber = storeNum_Combox.Text;
            this.UniqueColumn = uniqueField_Combox.Text;

            if (StoreNumber == UniqueColumn)
            {
                MessageBox.Show("Your unique field and store number columns cannot be the same column.  Please redo your selection.");
            }

            else
                this.Close();
        }

        private void Cancel_Btn_Click(object sender, EventArgs e)
        {
            this.StoreNumber = null;
            this.UniqueColumn = null;

            this.Close();
        }
    }
}
