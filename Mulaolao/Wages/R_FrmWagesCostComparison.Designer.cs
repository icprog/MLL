namespace Mulaolao.Wages
{
    partial class R_FrmWagesCostComparison
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UZ018 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UZ017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1255, 445);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(107, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1255, 393);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.UZ018,
            this.UZ004,
            this.UZ005,
            this.UZ006,
            this.UZ007,
            this.UZ008,
            this.UZ009,
            this.UZ010,
            this.UZ011,
            this.UZ012,
            this.UZ013,
            this.UZ014,
            this.UZ015,
            this.UZ016,
            this.UZ017,
            this.U15,
            this.idx});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // UZ018
            // 
            this.UZ018.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ018.AppearanceCell.Options.UseFont = true;
            this.UZ018.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ018.AppearanceHeader.Options.UseFont = true;
            this.UZ018.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ018.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ018.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ018.Caption = "组长";
            this.UZ018.FieldName = "UZ018";
            this.UZ018.Name = "UZ018";
            this.UZ018.Visible = true;
            this.UZ018.VisibleIndex = 0;
            // 
            // UZ004
            // 
            this.UZ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ004.AppearanceCell.Options.UseFont = true;
            this.UZ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ004.AppearanceHeader.Options.UseFont = true;
            this.UZ004.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ004.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ004.Caption = "产品名称";
            this.UZ004.FieldName = "UZ004";
            this.UZ004.Name = "UZ004";
            this.UZ004.Visible = true;
            this.UZ004.VisibleIndex = 1;
            this.UZ004.Width = 154;
            // 
            // UZ005
            // 
            this.UZ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ005.AppearanceCell.Options.UseFont = true;
            this.UZ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ005.AppearanceHeader.Options.UseFont = true;
            this.UZ005.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ005.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ005.Caption = "流水号";
            this.UZ005.FieldName = "UZ005";
            this.UZ005.Name = "UZ005";
            this.UZ005.Visible = true;
            this.UZ005.VisibleIndex = 2;
            this.UZ005.Width = 89;
            // 
            // UZ006
            // 
            this.UZ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ006.AppearanceCell.Options.UseFont = true;
            this.UZ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ006.AppearanceHeader.Options.UseFont = true;
            this.UZ006.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ006.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ006.Caption = "数量";
            this.UZ006.FieldName = "UZ006";
            this.UZ006.Name = "UZ006";
            this.UZ006.Visible = true;
            this.UZ006.VisibleIndex = 3;
            // 
            // UZ007
            // 
            this.UZ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ007.AppearanceCell.Options.UseFont = true;
            this.UZ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ007.AppearanceHeader.Options.UseFont = true;
            this.UZ007.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ007.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ007.Caption = "白坯工资";
            this.UZ007.DisplayFormat.FormatString = "N0";
            this.UZ007.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ007.FieldName = "UZ007";
            this.UZ007.Name = "UZ007";
            this.UZ007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ007", "{0:N0}")});
            this.UZ007.Visible = true;
            this.UZ007.VisibleIndex = 4;
            // 
            // UZ008
            // 
            this.UZ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ008.AppearanceCell.Options.UseFont = true;
            this.UZ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ008.AppearanceHeader.Options.UseFont = true;
            this.UZ008.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ008.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ008.Caption = "砂光工资";
            this.UZ008.DisplayFormat.FormatString = "N0";
            this.UZ008.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ008.FieldName = "UZ008";
            this.UZ008.Name = "UZ008";
            this.UZ008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ008", "{0:N0}")});
            this.UZ008.Visible = true;
            this.UZ008.VisibleIndex = 5;
            this.UZ008.Width = 79;
            // 
            // UZ009
            // 
            this.UZ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ009.AppearanceCell.Options.UseFont = true;
            this.UZ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ009.AppearanceHeader.Options.UseFont = true;
            this.UZ009.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ009.Caption = "粘接工资";
            this.UZ009.DisplayFormat.FormatString = "N0";
            this.UZ009.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ009.FieldName = "UZ009";
            this.UZ009.Name = "UZ009";
            this.UZ009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ009", "{0:N0}")});
            this.UZ009.Visible = true;
            this.UZ009.VisibleIndex = 6;
            this.UZ009.Width = 81;
            // 
            // UZ010
            // 
            this.UZ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ010.AppearanceCell.Options.UseFont = true;
            this.UZ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ010.AppearanceHeader.Options.UseFont = true;
            this.UZ010.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ010.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ010.Caption = "组装工资";
            this.UZ010.DisplayFormat.FormatString = "N0";
            this.UZ010.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ010.FieldName = "UZ010";
            this.UZ010.Name = "UZ010";
            this.UZ010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ010", "{0:N0}")});
            this.UZ010.Visible = true;
            this.UZ010.VisibleIndex = 7;
            this.UZ010.Width = 79;
            // 
            // UZ011
            // 
            this.UZ011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ011.AppearanceCell.Options.UseFont = true;
            this.UZ011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ011.AppearanceHeader.Options.UseFont = true;
            this.UZ011.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ011.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ011.Caption = "检验工资";
            this.UZ011.DisplayFormat.FormatString = "N0";
            this.UZ011.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ011.FieldName = "UZ011";
            this.UZ011.Name = "UZ011";
            this.UZ011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ011", "{0:N0}")});
            this.UZ011.Visible = true;
            this.UZ011.VisibleIndex = 8;
            this.UZ011.Width = 76;
            // 
            // UZ012
            // 
            this.UZ012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ012.AppearanceCell.Options.UseFont = true;
            this.UZ012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ012.AppearanceHeader.Options.UseFont = true;
            this.UZ012.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ012.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ012.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ012.Caption = "后道辅助工资";
            this.UZ012.DisplayFormat.FormatString = "N0";
            this.UZ012.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ012.FieldName = "UZ012";
            this.UZ012.Name = "UZ012";
            this.UZ012.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ012", "{0:N0}")});
            this.UZ012.Visible = true;
            this.UZ012.VisibleIndex = 9;
            this.UZ012.Width = 113;
            // 
            // UZ013
            // 
            this.UZ013.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ013.AppearanceCell.Options.UseFont = true;
            this.UZ013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ013.AppearanceHeader.Options.UseFont = true;
            this.UZ013.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ013.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ013.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ013.Caption = "包装工资";
            this.UZ013.DisplayFormat.FormatString = "N0";
            this.UZ013.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ013.FieldName = "UZ013";
            this.UZ013.Name = "UZ013";
            this.UZ013.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ013", "{0:N0}")});
            this.UZ013.Visible = true;
            this.UZ013.VisibleIndex = 10;
            // 
            // UZ014
            // 
            this.UZ014.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ014.AppearanceCell.Options.UseFont = true;
            this.UZ014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ014.AppearanceHeader.Options.UseFont = true;
            this.UZ014.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ014.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ014.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ014.Caption = "修理工资";
            this.UZ014.DisplayFormat.FormatString = "N0";
            this.UZ014.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ014.FieldName = "UZ014";
            this.UZ014.Name = "UZ014";
            this.UZ014.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ014", "{0:N0}")});
            this.UZ014.Visible = true;
            this.UZ014.VisibleIndex = 11;
            // 
            // UZ015
            // 
            this.UZ015.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ015.AppearanceCell.Options.UseFont = true;
            this.UZ015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ015.AppearanceHeader.Options.UseFont = true;
            this.UZ015.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ015.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ015.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ015.Caption = "返工工资";
            this.UZ015.DisplayFormat.FormatString = "N0";
            this.UZ015.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ015.FieldName = "UZ015";
            this.UZ015.Name = "UZ015";
            this.UZ015.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ015", "{0:N0}")});
            this.UZ015.Visible = true;
            this.UZ015.VisibleIndex = 12;
            // 
            // UZ016
            // 
            this.UZ016.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ016.AppearanceCell.Options.UseFont = true;
            this.UZ016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ016.AppearanceHeader.Options.UseFont = true;
            this.UZ016.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ016.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ016.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ016.Caption = "样品工资";
            this.UZ016.DisplayFormat.FormatString = "N0";
            this.UZ016.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ016.FieldName = "UZ016";
            this.UZ016.Name = "UZ016";
            this.UZ016.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ016", "{0:N0}")});
            this.UZ016.Visible = true;
            this.UZ016.VisibleIndex = 13;
            // 
            // UZ017
            // 
            this.UZ017.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ017.AppearanceCell.Options.UseFont = true;
            this.UZ017.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.UZ017.AppearanceHeader.Options.UseFont = true;
            this.UZ017.AppearanceHeader.Options.UseTextOptions = true;
            this.UZ017.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.UZ017.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.UZ017.Caption = "杂工工资";
            this.UZ017.DisplayFormat.FormatString = "N0";
            this.UZ017.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.UZ017.FieldName = "UZ017";
            this.UZ017.Name = "UZ017";
            this.UZ017.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UZ017", "{0:N0}")});
            this.UZ017.Visible = true;
            this.UZ017.VisibleIndex = 14;
            // 
            // U15
            // 
            this.U15.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U15.AppearanceCell.Options.UseFont = true;
            this.U15.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U15.AppearanceHeader.Options.UseFont = true;
            this.U15.AppearanceHeader.Options.UseTextOptions = true;
            this.U15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U15.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U15.Caption = "合计";
            this.U15.DisplayFormat.FormatString = "N0";
            this.U15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U15.FieldName = "U15";
            this.U15.Name = "U15";
            this.U15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U15", "{0:N0}")});
            this.U15.ToolTip = "[白坯段工资]+[砂光段工资]+[粘接段工资]+[组装段工资]+[检验段工资]+[后道辅助工资]+[包装工资]+[修理工资]+[返工工资]+[样品工资]+[杂工工" +
    "资]";
            this.U15.UnboundExpression = "[UZ007]+[UZ008]+[UZ009]+[UZ010]+[UZ011]+[UZ012]+[UZ013]+[UZ014]+[UZ015]+[UZ016]+[" +
    "UZ017]";
            this.U15.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U15.Visible = true;
            this.U15.VisibleIndex = 15;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // R_FrmWagesCostComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 470);
            this.Controls.Add(this.splitContainer1);
            this.Name = "R_FrmWagesCostComparison";
            this.Text = "工资成本核算对比表(R_325)";
            this.Load += new System.EventHandler(this.R_FrmWagesCostComparison_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn UZ018;
        private DevExpress.XtraGrid.Columns.GridColumn UZ004;
        private DevExpress.XtraGrid.Columns.GridColumn UZ005;
        private DevExpress.XtraGrid.Columns.GridColumn UZ006;
        private DevExpress.XtraGrid.Columns.GridColumn UZ007;
        private DevExpress.XtraGrid.Columns.GridColumn UZ008;
        private DevExpress.XtraGrid.Columns.GridColumn UZ009;
        private DevExpress.XtraGrid.Columns.GridColumn UZ010;
        private DevExpress.XtraGrid.Columns.GridColumn UZ011;
        private DevExpress.XtraGrid.Columns.GridColumn UZ012;
        private DevExpress.XtraGrid.Columns.GridColumn UZ013;
        private DevExpress.XtraGrid.Columns.GridColumn UZ014;
        private DevExpress.XtraGrid.Columns.GridColumn UZ015;
        private DevExpress.XtraGrid.Columns.GridColumn UZ016;
        private DevExpress.XtraGrid.Columns.GridColumn UZ017;
        private DevExpress.XtraGrid.Columns.GridColumn U15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Columns.GridColumn idx;
    }
}