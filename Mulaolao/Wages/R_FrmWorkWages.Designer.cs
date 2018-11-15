namespace Mulaolao.Wages
{
    partial class R_FrmWorkWages
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
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TZ013 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ014 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ003 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ004 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ005 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ006 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ007 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ008 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TZ009 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ010 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ011 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ012 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.F3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.F5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ001 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.TZ002 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.idx = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 461);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 8);
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
            this.dateTimePicker1.Location = new System.Drawing.Point(59, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1264, 411);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.BandPanelRowHeight = 25;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.bandedGridView1.ColumnPanelRowHeight = 45;
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.TZ003,
            this.TZ004,
            this.TZ005,
            this.TZ006,
            this.F1,
            this.TZ007,
            this.TZ008,
            this.F6,
            this.TZ009,
            this.TZ010,
            this.F2,
            this.TZ011,
            this.TZ012,
            this.F7,
            this.F3,
            this.F4,
            this.F5,
            this.TZ013,
            this.TZ014,
            this.TZ001,
            this.TZ002,
            this.idx});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.bandedGridView1_RowClick);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand1.Caption = "天数部分";
            this.gridBand1.Columns.Add(this.TZ013);
            this.gridBand1.Columns.Add(this.TZ014);
            this.gridBand1.Columns.Add(this.TZ003);
            this.gridBand1.Columns.Add(this.TZ004);
            this.gridBand1.Columns.Add(this.TZ005);
            this.gridBand1.Columns.Add(this.TZ006);
            this.gridBand1.Columns.Add(this.F1);
            this.gridBand1.Columns.Add(this.TZ007);
            this.gridBand1.Columns.Add(this.TZ008);
            this.gridBand1.Columns.Add(this.F6);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 709;
            // 
            // TZ013
            // 
            this.TZ013.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TZ013.AppearanceCell.Options.UseFont = true;
            this.TZ013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TZ013.AppearanceHeader.Options.UseFont = true;
            this.TZ013.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ013.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ013.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ013.Caption = "组长";
            this.TZ013.FieldName = "TZ013";
            this.TZ013.Name = "TZ013";
            this.TZ013.Visible = true;
            this.TZ013.Width = 76;
            // 
            // TZ014
            // 
            this.TZ014.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TZ014.AppearanceCell.Options.UseFont = true;
            this.TZ014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TZ014.AppearanceHeader.Options.UseFont = true;
            this.TZ014.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ014.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ014.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ014.Caption = "统计员";
            this.TZ014.FieldName = "TZ014";
            this.TZ014.Name = "TZ014";
            this.TZ014.Visible = true;
            // 
            // TZ003
            // 
            this.TZ003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ003.AppearanceCell.Options.UseFont = true;
            this.TZ003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ003.AppearanceHeader.Options.UseFont = true;
            this.TZ003.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ003.Caption = "生产人姓名";
            this.TZ003.FieldName = "TZ003";
            this.TZ003.Name = "TZ003";
            this.TZ003.Visible = true;
            this.TZ003.Width = 58;
            // 
            // TZ004
            // 
            this.TZ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ004.AppearanceCell.Options.UseFont = true;
            this.TZ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ004.AppearanceHeader.Options.UseFont = true;
            this.TZ004.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ004.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ004.Caption = "男女性别";
            this.TZ004.FieldName = "TZ004";
            this.TZ004.Name = "TZ004";
            this.TZ004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U1", "合计")});
            this.TZ004.Visible = true;
            this.TZ004.Width = 50;
            // 
            // TZ005
            // 
            this.TZ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ005.AppearanceCell.Options.UseFont = true;
            this.TZ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ005.AppearanceHeader.Options.UseFont = true;
            this.TZ005.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ005.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ005.Caption = "本月317考勤天数";
            this.TZ005.FieldName = "TZ005";
            this.TZ005.Name = "TZ005";
            this.TZ005.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ005", "{0:N1}")});
            this.TZ005.Visible = true;
            // 
            // TZ006
            // 
            this.TZ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ006.AppearanceCell.Options.UseFont = true;
            this.TZ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ006.AppearanceHeader.Options.UseFont = true;
            this.TZ006.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ006.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ006.Caption = "本月323已结天数";
            this.TZ006.FieldName = "TZ006";
            this.TZ006.Name = "TZ006";
            this.TZ006.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ006", "{0:N1}")});
            this.TZ006.Visible = true;
            // 
            // F1
            // 
            this.F1.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F1.AppearanceCell.Options.UseFont = true;
            this.F1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F1.AppearanceHeader.Options.UseFont = true;
            this.F1.AppearanceHeader.Options.UseTextOptions = true;
            this.F1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F1.Caption = "本月317未结天数";
            this.F1.FieldName = "F1";
            this.F1.Name = "F1";
            this.F1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "F1", "{0:N1}")});
            this.F1.ToolTip = "[本月317考勤天数] - [本月323已结天数]";
            this.F1.UnboundExpression = "[TZ005] - [TZ006]";
            this.F1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F1.Visible = true;
            // 
            // TZ007
            // 
            this.TZ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ007.AppearanceCell.Options.UseFont = true;
            this.TZ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ007.AppearanceHeader.Options.UseFont = true;
            this.TZ007.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ007.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ007.Caption = "累计317考勤天数";
            this.TZ007.FieldName = "TZ007";
            this.TZ007.Name = "TZ007";
            this.TZ007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ007", "{0:N1}")});
            this.TZ007.Visible = true;
            // 
            // TZ008
            // 
            this.TZ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ008.AppearanceCell.Options.UseFont = true;
            this.TZ008.AppearanceCell.Options.UseTextOptions = true;
            this.TZ008.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ008.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ008.AppearanceHeader.Options.UseFont = true;
            this.TZ008.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ008.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ008.Caption = "累计317已结天数";
            this.TZ008.FieldName = "TZ008";
            this.TZ008.Name = "TZ008";
            this.TZ008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ008", "{0:N1}")});
            this.TZ008.Visible = true;
            // 
            // F6
            // 
            this.F6.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F6.AppearanceCell.Options.UseFont = true;
            this.F6.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F6.AppearanceHeader.Options.UseFont = true;
            this.F6.AppearanceHeader.Options.UseTextOptions = true;
            this.F6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F6.Caption = "累计317未结天数";
            this.F6.FieldName = "F6";
            this.F6.Name = "F6";
            this.F6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "F6", "{0:N1}")});
            this.F6.ToolTip = "[累计317考勤天数] -[累计317已结天数]";
            this.F6.UnboundExpression = "[TZ007] - [TZ008]";
            this.F6.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F6.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand2.Caption = "工资部分";
            this.gridBand2.Columns.Add(this.TZ009);
            this.gridBand2.Columns.Add(this.TZ010);
            this.gridBand2.Columns.Add(this.F2);
            this.gridBand2.Columns.Add(this.TZ011);
            this.gridBand2.Columns.Add(this.TZ012);
            this.gridBand2.Columns.Add(this.F7);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 450;
            // 
            // TZ009
            // 
            this.TZ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ009.AppearanceCell.Options.UseFont = true;
            this.TZ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ009.AppearanceHeader.Options.UseFont = true;
            this.TZ009.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ009.Caption = "本月317考勤工资";
            this.TZ009.FieldName = "TZ009";
            this.TZ009.Name = "TZ009";
            this.TZ009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ009", "{0:N0}")});
            this.TZ009.Visible = true;
            // 
            // TZ010
            // 
            this.TZ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ010.AppearanceCell.Options.UseFont = true;
            this.TZ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ010.AppearanceHeader.Options.UseFont = true;
            this.TZ010.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ010.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ010.Caption = "本月323已结工资";
            this.TZ010.FieldName = "TZ010";
            this.TZ010.Name = "TZ010";
            this.TZ010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ010", "{0:N0}")});
            this.TZ010.Visible = true;
            // 
            // F2
            // 
            this.F2.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F2.AppearanceCell.Options.UseFont = true;
            this.F2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F2.AppearanceHeader.Options.UseFont = true;
            this.F2.AppearanceHeader.Options.UseTextOptions = true;
            this.F2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F2.Caption = "本月317未结工资";
            this.F2.FieldName = "F2";
            this.F2.Name = "F2";
            this.F2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "F2", "{0:N0}")});
            this.F2.ToolTip = "[本月317考勤工资] - [本月323已结工资]";
            this.F2.UnboundExpression = "[TZ009] - [TZ010]";
            this.F2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F2.Visible = true;
            // 
            // TZ011
            // 
            this.TZ011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ011.AppearanceCell.Options.UseFont = true;
            this.TZ011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ011.AppearanceHeader.Options.UseFont = true;
            this.TZ011.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ011.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ011.Caption = "累计317考勤工资";
            this.TZ011.FieldName = "TZ011";
            this.TZ011.Name = "TZ011";
            this.TZ011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ011", "{0:N0}")});
            this.TZ011.Visible = true;
            // 
            // TZ012
            // 
            this.TZ012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ012.AppearanceCell.Options.UseFont = true;
            this.TZ012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TZ012.AppearanceHeader.Options.UseFont = true;
            this.TZ012.AppearanceHeader.Options.UseTextOptions = true;
            this.TZ012.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TZ012.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TZ012.Caption = "累计317已结工资";
            this.TZ012.FieldName = "TZ012";
            this.TZ012.Name = "TZ012";
            this.TZ012.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TZ012", "{0:N0}")});
            this.TZ012.Visible = true;
            // 
            // F7
            // 
            this.F7.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F7.AppearanceCell.Options.UseFont = true;
            this.F7.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F7.AppearanceHeader.Options.UseFont = true;
            this.F7.AppearanceHeader.Options.UseTextOptions = true;
            this.F7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F7.Caption = "累计317未结工资";
            this.F7.FieldName = "F7";
            this.F7.Name = "F7";
            this.F7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "F7", "{0:N0}")});
            this.F7.ToolTip = "[累计317考勤工资] - [累计317已结工资]";
            this.F7.UnboundExpression = "[TZ011] - [TZ012]";
            this.F7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F7.Visible = true;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand3.Caption = "日均工资";
            this.gridBand3.Columns.Add(this.F3);
            this.gridBand3.Columns.Add(this.F4);
            this.gridBand3.Columns.Add(this.F5);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 265;
            // 
            // F3
            // 
            this.F3.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F3.AppearanceCell.Options.UseFont = true;
            this.F3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F3.AppearanceHeader.Options.UseFont = true;
            this.F3.AppearanceHeader.Options.UseTextOptions = true;
            this.F3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F3.Caption = "累计已结日均工资";
            this.F3.DisplayFormat.FormatString = "N2";
            this.F3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.F3.FieldName = "F3";
            this.F3.Name = "F3";
            this.F3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "F3", "{0:N0}")});
            this.F3.ToolTip = "[累计317已结工资] / [累计317已结天数]";
            this.F3.UnboundExpression = "Iif([TZ008]<>0,[TZ012] / [TZ008]  ,0 )";
            this.F3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F3.Visible = true;
            this.F3.Width = 85;
            // 
            // F4
            // 
            this.F4.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F4.AppearanceCell.Options.UseFont = true;
            this.F4.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F4.AppearanceHeader.Options.UseFont = true;
            this.F4.AppearanceHeader.Options.UseTextOptions = true;
            this.F4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F4.Caption = "累计未结日均工资";
            this.F4.DisplayFormat.FormatString = "N2";
            this.F4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.F4.FieldName = "F4";
            this.F4.Name = "F4";
            this.F4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "F4", "{0:N0}")});
            this.F4.ToolTip = "[本月317未结工资] / [本月317未结天数]";
            this.F4.UnboundExpression = "Iif( [F1] <>0, [F2] / [F1] , 0)";
            this.F4.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F4.Visible = true;
            this.F4.Width = 85;
            // 
            // F5
            // 
            this.F5.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F5.AppearanceCell.Options.UseFont = true;
            this.F5.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.F5.AppearanceHeader.Options.UseFont = true;
            this.F5.AppearanceHeader.Options.UseTextOptions = true;
            this.F5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.F5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.F5.Caption = "累计317考勤日均工资";
            this.F5.DisplayFormat.FormatString = "N2";
            this.F5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.F5.FieldName = "F5";
            this.F5.Name = "F5";
            this.F5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "F5", "{0:N1}")});
            this.F5.ToolTip = "[累计317考勤工资] / [累计317考勤天数]";
            this.F5.UnboundExpression = "Iif([TZ007] <>0, [TZ011] / [TZ007] , 0)";
            this.F5.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.F5.Visible = true;
            this.F5.Width = 95;
            // 
            // TZ001
            // 
            this.TZ001.Caption = "年";
            this.TZ001.FieldName = "TZ001";
            this.TZ001.Name = "TZ001";
            // 
            // TZ002
            // 
            this.TZ002.Caption = "月";
            this.TZ002.FieldName = "TZ002";
            this.TZ002.Name = "TZ002";
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(321, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "按年统计";
            // 
            // R_FrmWorkWages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 486);
            this.Controls.Add(this.splitContainer1);
            this.Name = "R_FrmWorkWages";
            this.Text = "工人工资汇总表(R_324)";
            this.Load += new System.EventHandler(this.R_FrmWorkWages_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ003;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ004;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ005;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ006;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ007;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ008;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ009;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ010;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ011;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ012;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn F5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ013;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ014;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ001;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TZ002;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn idx;
        private System . Windows . Forms . Label label2;
    }
}