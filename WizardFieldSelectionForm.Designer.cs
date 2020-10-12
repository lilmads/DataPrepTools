namespace DataPrepTools
{
    partial class WizardFieldSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.columnType_Combox = new System.Windows.Forms.ComboBox();
            this.Select_Btn = new System.Windows.Forms.Button();
            this.fieldType_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.returnedFields_Listbox = new System.Windows.Forms.ListBox();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // columnType_Combox
            // 
            this.columnType_Combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnType_Combox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnType_Combox.FormattingEnabled = true;
            this.columnType_Combox.Location = new System.Drawing.Point(39, 101);
            this.columnType_Combox.Margin = new System.Windows.Forms.Padding(4);
            this.columnType_Combox.Name = "columnType_Combox";
            this.columnType_Combox.Size = new System.Drawing.Size(208, 27);
            this.columnType_Combox.TabIndex = 1;
            // 
            // Select_Btn
            // 
            this.Select_Btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Select_Btn.Location = new System.Drawing.Point(40, 499);
            this.Select_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Select_Btn.Name = "Select_Btn";
            this.Select_Btn.Size = new System.Drawing.Size(100, 28);
            this.Select_Btn.TabIndex = 3;
            this.Select_Btn.Text = "Select";
            this.Select_Btn.UseVisualStyleBackColor = true;
            this.Select_Btn.Click += new System.EventHandler(this.Select_Btn_Click);
            // 
            // fieldType_Label
            // 
            this.fieldType_Label.AutoSize = true;
            this.fieldType_Label.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldType_Label.Location = new System.Drawing.Point(36, 75);
            this.fieldType_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fieldType_Label.Name = "fieldType_Label";
            this.fieldType_Label.Size = new System.Drawing.Size(154, 19);
            this.fieldType_Label.TabIndex = 5;
            this.fieldType_Label.Text = "Select Column Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Return Fields";
            // 
            // returnedFields_Listbox
            // 
            this.returnedFields_Listbox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnedFields_Listbox.FormattingEnabled = true;
            this.returnedFields_Listbox.ItemHeight = 19;
            this.returnedFields_Listbox.Location = new System.Drawing.Point(39, 181);
            this.returnedFields_Listbox.Margin = new System.Windows.Forms.Padding(4);
            this.returnedFields_Listbox.Name = "returnedFields_Listbox";
            this.returnedFields_Listbox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.returnedFields_Listbox.Size = new System.Drawing.Size(208, 289);
            this.returnedFields_Listbox.TabIndex = 8;
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Btn.Location = new System.Drawing.Point(148, 499);
            this.Cancel_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(100, 28);
            this.Cancel_Btn.TabIndex = 9;
            this.Cancel_Btn.Text = "Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "FInd and Return Values";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WizardFieldSelectionForm
            // 
            this.AcceptButton = this.Select_Btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Btn;
            this.ClientSize = new System.Drawing.Size(291, 558);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.returnedFields_Listbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fieldType_Label);
            this.Controls.Add(this.Select_Btn);
            this.Controls.Add(this.columnType_Combox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardFieldSelectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UPC WIzard Field Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox columnType_Combox;
        private System.Windows.Forms.Label fieldType_Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox returnedFields_Listbox;
        private System.Windows.Forms.Button Select_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Label label1;
    }
}