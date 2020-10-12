namespace DataPrepTools
{
    partial class Data_Prep : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Data_Prep()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataPrep = this.Factory.CreateRibbonTab();
            this.projectActionsGroup = this.Factory.CreateRibbonGroup();
            this.formattingGroup = this.Factory.CreateRibbonGroup();
            this.upcsGroup = this.Factory.CreateRibbonGroup();
            this.generalGroup = this.Factory.CreateRibbonGroup();
            this.GlobalSwap_Btn = this.Factory.CreateRibbonButton();
            this.solutionGroup = this.Factory.CreateRibbonGroup();
            this.CombineSheets_Btn = this.Factory.CreateRibbonButton();
            this.AOD_Btn = this.Factory.CreateRibbonButton();
            this.ClearFormatting_Btn = this.Factory.CreateRibbonButton();
            this.TrimCells_Btn = this.Factory.CreateRibbonButton();
            this.General_Btn = this.Factory.CreateRibbonButton();
            this.Text_Btn = this.Factory.CreateRibbonButton();
            this.Number_Btn = this.Factory.CreateRibbonButton();
            this.Currency_Btn = this.Factory.CreateRibbonButton();
            this.Percent_Btn = this.Factory.CreateRibbonButton();
            this.TDLinx_Btn = this.Factory.CreateRibbonButton();
            this.JDADate_Btn = this.Factory.CreateRibbonButton();
            this.DupsSingleMulti_Btn = this.Factory.CreateRibbonButton();
            this.UPCWizard_Btn = this.Factory.CreateRibbonButton();
            this.GoogleText_Btn = this.Factory.CreateRibbonButton();
            this.GoogleImage_Btn = this.Factory.CreateRibbonButton();
            this.About_Btn = this.Factory.CreateRibbonButton();
            this.DataPrep.SuspendLayout();
            this.projectActionsGroup.SuspendLayout();
            this.formattingGroup.SuspendLayout();
            this.upcsGroup.SuspendLayout();
            this.generalGroup.SuspendLayout();
            this.solutionGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataPrep
            // 
            this.DataPrep.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.DataPrep.Groups.Add(this.projectActionsGroup);
            this.DataPrep.Groups.Add(this.formattingGroup);
            this.DataPrep.Groups.Add(this.upcsGroup);
            this.DataPrep.Groups.Add(this.generalGroup);
            this.DataPrep.Groups.Add(this.solutionGroup);
            this.DataPrep.Label = "Data Prep";
            this.DataPrep.Name = "DataPrep";
            // 
            // projectActionsGroup
            // 
            this.projectActionsGroup.Items.Add(this.AOD_Btn);
            this.projectActionsGroup.Items.Add(this.CombineSheets_Btn);
            this.projectActionsGroup.Label = "Workbook Actions";
            this.projectActionsGroup.Name = "projectActionsGroup";
            // 
            // formattingGroup
            // 
            this.formattingGroup.Items.Add(this.ClearFormatting_Btn);
            this.formattingGroup.Items.Add(this.Currency_Btn);
            this.formattingGroup.Items.Add(this.General_Btn);
            this.formattingGroup.Items.Add(this.JDADate_Btn);
            this.formattingGroup.Items.Add(this.Number_Btn);
            this.formattingGroup.Items.Add(this.Percent_Btn);
            this.formattingGroup.Items.Add(this.TDLinx_Btn);
            this.formattingGroup.Items.Add(this.Text_Btn);
            this.formattingGroup.Items.Add(this.TrimCells_Btn);
            this.formattingGroup.Label = "Cell Formatting";
            this.formattingGroup.Name = "formattingGroup";
            // 
            // upcsGroup
            // 
            this.upcsGroup.Items.Add(this.UPCWizard_Btn);
            this.upcsGroup.Items.Add(this.DupsSingleMulti_Btn);
            this.upcsGroup.Label = "Data Cleaning";
            this.upcsGroup.Name = "upcsGroup";
            // 
            // generalGroup
            // 
            this.generalGroup.Items.Add(this.About_Btn);
            this.generalGroup.Items.Add(this.GoogleImage_Btn);
            this.generalGroup.Items.Add(this.GoogleText_Btn);
            this.generalGroup.Label = "General";
            this.generalGroup.Name = "generalGroup";
            // 
            // GlobalSwap_Btn
            // 
            this.GlobalSwap_Btn.Label = "@ Global Swaps";
            this.GlobalSwap_Btn.Name = "GlobalSwap_Btn";
            this.GlobalSwap_Btn.Visible = false;
            this.GlobalSwap_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GlobalSwap_Btn_Click);
            // 
            // solutionGroup
            // 
            this.solutionGroup.Items.Add(this.GlobalSwap_Btn);
            this.solutionGroup.Label = "Solution Designer Corner";
            this.solutionGroup.Name = "solutionGroup";
            this.solutionGroup.Visible = false;
            // 
            // CombineSheets_Btn
            // 
            this.CombineSheets_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_layers_50;
            this.CombineSheets_Btn.Label = "Combine All";
            this.CombineSheets_Btn.Name = "CombineSheets_Btn";
            this.CombineSheets_Btn.ShowImage = true;
            this.CombineSheets_Btn.SuperTip = "Combine all sheets within active workbook.";
            this.CombineSheets_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.CombineSheets_Btn_Click);
            // 
            // AOD_Btn
            // 
            this.AOD_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_workflow_50;
            this.AOD_Btn.Label = "AOD ";
            this.AOD_Btn.Name = "AOD_Btn";
            this.AOD_Btn.ShowImage = true;
            this.AOD_Btn.SuperTip = "Create AOD Data tab from AOD report.";
            this.AOD_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AOD_Btn_Click);
            // 
            // ClearFormatting_Btn
            // 
            this.ClearFormatting_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_broom_50;
            this.ClearFormatting_Btn.Label = "Clear Formatting";
            this.ClearFormatting_Btn.Name = "ClearFormatting_Btn";
            this.ClearFormatting_Btn.ShowImage = true;
            this.ClearFormatting_Btn.SuperTip = "Clear the formatting associated with selected cells.";
            this.ClearFormatting_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ClearFormatting_Btn_Click);
            // 
            // TrimCells_Btn
            // 
            this.TrimCells_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_barber_scissors_50;
            this.TrimCells_Btn.Label = "Trim Cells";
            this.TrimCells_Btn.Name = "TrimCells_Btn";
            this.TrimCells_Btn.ShowImage = true;
            this.TrimCells_Btn.SuperTip = "Removes spaces before and after cell content.";
            this.TrimCells_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TrimCells_Btn_Click);
            // 
            // General_Btn
            // 
            this.General_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_broom_50;
            this.General_Btn.Label = "General";
            this.General_Btn.Name = "General_Btn";
            this.General_Btn.ShowImage = true;
            this.General_Btn.SuperTip = "Formats selection as General.";
            this.General_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.General_Btn_Click);
            // 
            // Text_Btn
            // 
            this.Text_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_text_50;
            this.Text_Btn.Label = "Text";
            this.Text_Btn.Name = "Text_Btn";
            this.Text_Btn.ShowImage = true;
            this.Text_Btn.SuperTip = "Formats selection as Text. ";
            this.Text_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Text_Btn_Click);
            // 
            // Number_Btn
            // 
            this.Number_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_hashtag_50;
            this.Number_Btn.Label = "Number";
            this.Number_Btn.Name = "Number_Btn";
            this.Number_Btn.ShowImage = true;
            this.Number_Btn.SuperTip = "Formats selection as a Number. ";
            this.Number_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Number_Btn_Click);
            // 
            // Currency_Btn
            // 
            this.Currency_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_us_dollar_50;
            this.Currency_Btn.Label = "Currency";
            this.Currency_Btn.Name = "Currency_Btn";
            this.Currency_Btn.ShowImage = true;
            this.Currency_Btn.SuperTip = "Formats selection as a Currency.";
            this.Currency_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Currency_Btn_Click);
            // 
            // Percent_Btn
            // 
            this.Percent_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_percentage_50;
            this.Percent_Btn.Label = "Percent";
            this.Percent_Btn.Name = "Percent_Btn";
            this.Percent_Btn.ShowImage = true;
            this.Percent_Btn.SuperTip = "Formats selection as a Percent.";
            this.Percent_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Percent_Btn_Click);
            // 
            // TDLinx_Btn
            // 
            this.TDLinx_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_marker_50;
            this.TDLinx_Btn.Label = "TDLinx";
            this.TDLinx_Btn.Name = "TDLinx_Btn";
            this.TDLinx_Btn.ShowImage = true;
            this.TDLinx_Btn.SuperTip = "Formats selection as TDLinx.  ";
            this.TDLinx_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.TDLinx_Btn_Click);
            // 
            // JDADate_Btn
            // 
            this.JDADate_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_calendar_50;
            this.JDADate_Btn.Label = "JDA Date";
            this.JDADate_Btn.Name = "JDADate_Btn";
            this.JDADate_Btn.ShowImage = true;
            this.JDADate_Btn.SuperTip = "Formats selection as JDA Date.";
            this.JDADate_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.JDADate_Btn_Click);
            // 
            // DupsSingleMulti_Btn
            // 
            this.DupsSingleMulti_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_clone_50;
            this.DupsSingleMulti_Btn.Label = "Dups";
            this.DupsSingleMulti_Btn.Name = "DupsSingleMulti_Btn";
            this.DupsSingleMulti_Btn.ShowImage = true;
            this.DupsSingleMulti_Btn.SuperTip = "Locates duplication.";
            this.DupsSingleMulti_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DupsSingleMulti_Btn_Click);
            // 
            // UPCWizard_Btn
            // 
            this.UPCWizard_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_fantasy_50;
            this.UPCWizard_Btn.Label = "UPC WIzard";
            this.UPCWizard_Btn.Name = "UPCWizard_Btn";
            this.UPCWizard_Btn.ShowImage = true;
            this.UPCWizard_Btn.SuperTip = "Finds products in Beer Database.";
            this.UPCWizard_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.UPCWizard_Btn_Click);
            // 
            // GoogleText_Btn
            // 
            this.GoogleText_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_google_50;
            this.GoogleText_Btn.Label = "Google Text";
            this.GoogleText_Btn.Name = "GoogleText_Btn";
            this.GoogleText_Btn.ShowImage = true;
            this.GoogleText_Btn.SuperTip = "Opens Google Web Search results associated with the selected cell.";
            this.GoogleText_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GoogleText_Btn_Click);
            // 
            // GoogleImage_Btn
            // 
            this.GoogleImage_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_google_50;
            this.GoogleImage_Btn.Label = "Google Image";
            this.GoogleImage_Btn.Name = "GoogleImage_Btn";
            this.GoogleImage_Btn.ShowImage = true;
            this.GoogleImage_Btn.SuperTip = "Opens Google Images associated with the selected cell.";
            this.GoogleImage_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GoogleImage_Btn_Click);
            // 
            // About_Btn
            // 
            this.About_Btn.Image = global::DataPrepTools.Properties.Resources.icons8_info_50;
            this.About_Btn.Label = "About Data Prep";
            this.About_Btn.Name = "About_Btn";
            this.About_Btn.ShowImage = true;
            this.About_Btn.SuperTip = "Release notes for this Data Prep tool.  ";
            this.About_Btn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.About_Btn_Click);
            // 
            // Data_Prep
            // 
            this.Name = "Data_Prep";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.DataPrep);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Data_Prep_Load);
            this.DataPrep.ResumeLayout(false);
            this.DataPrep.PerformLayout();
            this.projectActionsGroup.ResumeLayout(false);
            this.projectActionsGroup.PerformLayout();
            this.formattingGroup.ResumeLayout(false);
            this.formattingGroup.PerformLayout();
            this.upcsGroup.ResumeLayout(false);
            this.upcsGroup.PerformLayout();
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            this.solutionGroup.ResumeLayout(false);
            this.solutionGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab DataPrep;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup projectActionsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup formattingGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup upcsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup generalGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton CombineSheets_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ClearFormatting_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TrimCells_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AOD_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton General_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Text_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Number_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Currency_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Percent_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton TDLinx_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton JDADate_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton UPCWizard_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton About_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GoogleImage_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GoogleText_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DupsSingleMulti_Btn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup solutionGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GlobalSwap_Btn;
    }

    partial class ThisRibbonCollection
    {
        internal Data_Prep Data_Prep
        {
            get { return this.GetRibbon<Data_Prep>(); }
        }
    }
}
