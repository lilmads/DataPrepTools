namespace DataPrepTools
{
    partial class DupsFieldSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.storeNum_Combox = new System.Windows.Forms.ComboBox();
            this.uniqueField_Combox = new System.Windows.Forms.ComboBox();
            this.Select_Btn = new System.Windows.Forms.Button();
            this.Cancel_Btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Store Primary Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unique Field ";
            // 
            // storeNum_Combox
            // 
            this.storeNum_Combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeNum_Combox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.storeNum_Combox.FormattingEnabled = true;
            this.storeNum_Combox.Location = new System.Drawing.Point(39, 101);
            this.storeNum_Combox.Margin = new System.Windows.Forms.Padding(4);
            this.storeNum_Combox.MaxDropDownItems = 15;
            this.storeNum_Combox.Name = "storeNum_Combox";
            this.storeNum_Combox.Size = new System.Drawing.Size(208, 27);
            this.storeNum_Combox.TabIndex = 2;
            // 
            // uniqueField_Combox
            // 
            this.uniqueField_Combox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uniqueField_Combox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniqueField_Combox.FormattingEnabled = true;
            this.uniqueField_Combox.Location = new System.Drawing.Point(39, 181);
            this.uniqueField_Combox.Margin = new System.Windows.Forms.Padding(4);
            this.uniqueField_Combox.MaxDropDownItems = 15;
            this.uniqueField_Combox.Name = "uniqueField_Combox";
            this.uniqueField_Combox.Size = new System.Drawing.Size(208, 27);
            this.uniqueField_Combox.TabIndex = 3;
            // 
            // Select_Btn
            // 
            this.Select_Btn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select_Btn.Location = new System.Drawing.Point(39, 260);
            this.Select_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Select_Btn.Name = "Select_Btn";
            this.Select_Btn.Size = new System.Drawing.Size(100, 28);
            this.Select_Btn.TabIndex = 4;
            this.Select_Btn.Text = "Select";
            this.Select_Btn.UseVisualStyleBackColor = true;
            this.Select_Btn.Click += new System.EventHandler(this.Select_Btn_Click);
            // 
            // Cancel_Btn
            // 
            this.Cancel_Btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Btn.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_Btn.Location = new System.Drawing.Point(147, 260);
            this.Cancel_Btn.Margin = new System.Windows.Forms.Padding(4);
            this.Cancel_Btn.Name = "Cancel_Btn";
            this.Cancel_Btn.Size = new System.Drawing.Size(100, 28);
            this.Cancel_Btn.TabIndex = 5;
            this.Cancel_Btn.Text = "Cancel";
            this.Cancel_Btn.UseVisualStyleBackColor = true;
            this.Cancel_Btn.Click += new System.EventHandler(this.Cancel_Btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Identify Duplicate Values";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DupsFieldSelectionForm
            // 
            this.AcceptButton = this.Select_Btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.Cancel_Btn;
            this.ClientSize = new System.Drawing.Size(291, 314);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Cancel_Btn);
            this.Controls.Add(this.Select_Btn);
            this.Controls.Add(this.uniqueField_Combox);
            this.Controls.Add(this.storeNum_Combox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DupsFieldSelectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dups Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox storeNum_Combox;
        private System.Windows.Forms.ComboBox uniqueField_Combox;
        private System.Windows.Forms.Button Select_Btn;
        private System.Windows.Forms.Button Cancel_Btn;
        private System.Windows.Forms.Label label3;
    }
}