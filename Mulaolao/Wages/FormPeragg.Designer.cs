namespace Mulaolao . Wages
{
    partial class FormPeragg
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
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnBatchEdit = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.lupPerson = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA018 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA019 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA020 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lupPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnBatchEdit);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRead);
            this.splitContainerControl1.Panel1.Controls.Add(this.dtp);
            this.splitContainerControl1.Panel1.Controls.Add(this.label12);
            this.splitContainerControl1.Panel1.Controls.Add(this.lupPerson);
            this.splitContainerControl1.Panel1.Controls.Add(this.label2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1242, 448);
            this.splitContainerControl1.SplitterPosition = 48;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnBatchEdit
            // 
            this.btnBatchEdit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatchEdit.Location = new System.Drawing.Point(488, 10);
            this.btnBatchEdit.Name = "btnBatchEdit";
            this.btnBatchEdit.Size = new System.Drawing.Size(94, 26);
            this.btnBatchEdit.TabIndex = 31;
            this.btnBatchEdit.Text = "批量编辑";
            this.btnBatchEdit.UseVisualStyleBackColor = true;
            this.btnBatchEdit.Click += new System.EventHandler(this.btnBatchEdit_Click);
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.Location = new System.Drawing.Point(421, 10);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(61, 26);
            this.btnRead.TabIndex = 30;
            this.btnRead.Text = "读取";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "yyyy年";
            this.dtp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(274, 8);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(78, 26);
            this.dtp.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(228, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "日期";
            // 
            // lupPerson
            // 
            this.lupPerson.Location = new System.Drawing.Point(58, 9);
            this.lupPerson.Name = "lupPerson";
            this.lupPerson.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupPerson.Properties.Appearance.Options.UseFont = true;
            this.lupPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPerson.Properties.NullText = "";
            this.lupPerson.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupPerson.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupPerson.Properties.ShowHeader = false;
            this.lupPerson.Size = new System.Drawing.Size(149, 22);
            this.lupPerson.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "姓名";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1242, 395);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CA002,
            this.CA003,
            this.U0,
            this.U1,
            this.CA004,
            this.U2,
            this.CA005,
            this.U3,
            this.U4,
            this.U5,
            this.CA006,
            this.CA007,
            this.CA008,
            this.U6,
            this.CA009,
            this.CA010,
            this.CA020,
            this.U7,
            this.U8,
            this.U9,
            this.CA011,
            this.CA012,
            this.CA013,
            this.CA014,
            this.CA015,
            this.CA018,
            this.CA019,
            this.U10,
            this.U11,
            this.CA001,
            this.CA016,
            this.CA017});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CA002
            // 
            this.CA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA002.AppearanceCell.Options.UseFont = true;
            this.CA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA002.AppearanceHeader.Options.UseFont = true;
            this.CA002.AppearanceHeader.Options.UseTextOptions = true;
            this.CA002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA002.Caption = "月份";
            this.CA002.FieldName = "CA002";
            this.CA002.Name = "CA002";
            this.CA002.OptionsColumn.AllowEdit = false;
            this.CA002.Visible = true;
            this.CA002.VisibleIndex = 0;
            this.CA002.Width = 49;
            // 
            // CA003
            // 
            this.CA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA003.AppearanceCell.Options.UseFont = true;
            this.CA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA003.AppearanceHeader.Options.UseFont = true;
            this.CA003.AppearanceHeader.Options.UseTextOptions = true;
            this.CA003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA003.Caption = "基本月工资";
            this.CA003.DisplayFormat.FormatString = "N2";
            this.CA003.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CA003.FieldName = "CA003";
            this.CA003.Name = "CA003";
            this.CA003.OptionsColumn.AllowEdit = false;
            this.CA003.Visible = true;
            this.CA003.VisibleIndex = 1;
            this.CA003.Width = 65;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.AppearanceHeader.Options.UseTextOptions = true;
            this.U0.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U0.Caption = "标准日工资";
            this.U0.DisplayFormat.FormatString = "N2";
            this.U0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.OptionsColumn.AllowEdit = false;
            this.U0.Visible = true;
            this.U0.VisibleIndex = 2;
            this.U0.Width = 62;
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.AppearanceHeader.Options.UseTextOptions = true;
            this.U1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U1.Caption = "实发日工资";
            this.U1.DisplayFormat.FormatString = "N2";
            this.U1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.OptionsColumn.AllowEdit = false;
            this.U1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U1", "{0:N2}")});
            this.U1.ToolTip = "[合计应发工资] / [天数小计] ";
            this.U1.UnboundExpression = "Iif(IsNullOrEmpty([U4]), 0, [U6] / [U4])";
            this.U1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U1.Visible = true;
            this.U1.VisibleIndex = 3;
            this.U1.Width = 63;
            // 
            // CA004
            // 
            this.CA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA004.AppearanceCell.Options.UseFont = true;
            this.CA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA004.AppearanceHeader.Options.UseFont = true;
            this.CA004.AppearanceHeader.Options.UseTextOptions = true;
            this.CA004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA004.Caption = "节假日/晚班";
            this.CA004.FieldName = "CA004";
            this.CA004.Name = "CA004";
            this.CA004.OptionsColumn.AllowEdit = false;
            this.CA004.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA004", "{0:N2}")});
            this.CA004.Visible = true;
            this.CA004.VisibleIndex = 4;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.AppearanceHeader.Options.UseTextOptions = true;
            this.U2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U2.Caption = "节假日/晚班工资";
            this.U2.DisplayFormat.FormatString = "N2";
            this.U2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.OptionsColumn.AllowEdit = false;
            this.U2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U2", "{0:N2}")});
            this.U2.ToolTip = "[标准日工资] * [节假日/晚班]";
            this.U2.UnboundExpression = "[U0] * [CA004]";
            this.U2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U2.Visible = true;
            this.U2.VisibleIndex = 5;
            // 
            // CA005
            // 
            this.CA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA005.AppearanceCell.Options.UseFont = true;
            this.CA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA005.AppearanceHeader.Options.UseFont = true;
            this.CA005.AppearanceHeader.Options.UseTextOptions = true;
            this.CA005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA005.Caption = "出勤日";
            this.CA005.FieldName = "CA005";
            this.CA005.Name = "CA005";
            this.CA005.OptionsColumn.AllowEdit = false;
            this.CA005.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA005", "{0:N2}")});
            this.CA005.Visible = true;
            this.CA005.VisibleIndex = 6;
            this.CA005.Width = 57;
            // 
            // U3
            // 
            this.U3.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U3.AppearanceCell.Options.UseFont = true;
            this.U3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U3.AppearanceHeader.Options.UseFont = true;
            this.U3.AppearanceHeader.Options.UseTextOptions = true;
            this.U3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U3.Caption = "出勤工资";
            this.U3.DisplayFormat.FormatString = "N2";
            this.U3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U3.FieldName = "U3";
            this.U3.Name = "U3";
            this.U3.OptionsColumn.AllowEdit = false;
            this.U3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U3", "{0:N2}")});
            this.U3.ToolTip = "[标准日工资] * [出勤日]";
            this.U3.UnboundExpression = "[U0] * [CA005]";
            this.U3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U3.Visible = true;
            this.U3.VisibleIndex = 7;
            // 
            // U4
            // 
            this.U4.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U4.AppearanceCell.Options.UseFont = true;
            this.U4.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U4.AppearanceHeader.Options.UseFont = true;
            this.U4.AppearanceHeader.Options.UseTextOptions = true;
            this.U4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U4.Caption = "天数小计";
            this.U4.DisplayFormat.FormatString = "N2";
            this.U4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U4.FieldName = "U4";
            this.U4.Name = "U4";
            this.U4.OptionsColumn.AllowEdit = false;
            this.U4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U4", "{0:N2}")});
            this.U4.ToolTip = "[出勤日] + [节假日/晚班]";
            this.U4.UnboundExpression = "[CA005] + [CA004]";
            this.U4.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U4.Visible = true;
            this.U4.VisibleIndex = 8;
            // 
            // U5
            // 
            this.U5.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U5.AppearanceCell.Options.UseFont = true;
            this.U5.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U5.AppearanceHeader.Options.UseFont = true;
            this.U5.AppearanceHeader.Options.UseTextOptions = true;
            this.U5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U5.Caption = "应发工资";
            this.U5.DisplayFormat.FormatString = "N2";
            this.U5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U5.FieldName = "U5";
            this.U5.Name = "U5";
            this.U5.OptionsColumn.AllowEdit = false;
            this.U5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U5", "{0:N2}")});
            this.U5.ToolTip = "[标准日工资] * [天数小计]";
            this.U5.UnboundExpression = "[U0] * [U4]";
            this.U5.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U5.Visible = true;
            this.U5.VisibleIndex = 9;
            // 
            // CA006
            // 
            this.CA006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA006.AppearanceCell.Options.UseFont = true;
            this.CA006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA006.AppearanceHeader.Options.UseFont = true;
            this.CA006.AppearanceHeader.Options.UseTextOptions = true;
            this.CA006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA006.Caption = "其他工资";
            this.CA006.FieldName = "CA006";
            this.CA006.Name = "CA006";
            this.CA006.OptionsColumn.AllowEdit = false;
            this.CA006.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA006", "{0:N2}")});
            this.CA006.Visible = true;
            this.CA006.VisibleIndex = 10;
            this.CA006.Width = 57;
            // 
            // CA007
            // 
            this.CA007.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA007.AppearanceCell.Options.UseFont = true;
            this.CA007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA007.AppearanceHeader.Options.UseFont = true;
            this.CA007.AppearanceHeader.Options.UseTextOptions = true;
            this.CA007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA007.Caption = "考核工资";
            this.CA007.FieldName = "CA007";
            this.CA007.Name = "CA007";
            this.CA007.OptionsColumn.AllowEdit = false;
            this.CA007.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA007", "{0:N2}")});
            this.CA007.Visible = true;
            this.CA007.VisibleIndex = 11;
            this.CA007.Width = 57;
            // 
            // CA008
            // 
            this.CA008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA008.AppearanceCell.Options.UseFont = true;
            this.CA008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA008.AppearanceHeader.Options.UseFont = true;
            this.CA008.AppearanceHeader.Options.UseTextOptions = true;
            this.CA008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA008.Caption = "预发工资";
            this.CA008.FieldName = "CA008";
            this.CA008.Name = "CA008";
            this.CA008.OptionsColumn.AllowEdit = false;
            this.CA008.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA008", "{0:N2}")});
            this.CA008.Visible = true;
            this.CA008.VisibleIndex = 12;
            this.CA008.Width = 53;
            // 
            // U6
            // 
            this.U6.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U6.AppearanceCell.Options.UseFont = true;
            this.U6.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U6.AppearanceHeader.Options.UseFont = true;
            this.U6.AppearanceHeader.Options.UseTextOptions = true;
            this.U6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U6.Caption = "合计应发工资";
            this.U6.DisplayFormat.FormatString = "N2";
            this.U6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U6.FieldName = "U6";
            this.U6.Name = "U6";
            this.U6.OptionsColumn.AllowEdit = false;
            this.U6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U6", "{0:N2}")});
            this.U6.ToolTip = "[应发工资]+ [其他工资] + [预发工资] + [考核工资]";
            this.U6.UnboundExpression = "[U5] + [CA006] + [CA008] + [CA007]";
            this.U6.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U6.Visible = true;
            this.U6.VisibleIndex = 13;
            // 
            // CA009
            // 
            this.CA009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA009.AppearanceCell.Options.UseFont = true;
            this.CA009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA009.AppearanceHeader.Options.UseFont = true;
            this.CA009.AppearanceHeader.Options.UseTextOptions = true;
            this.CA009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA009.Caption = "养老";
            this.CA009.FieldName = "CA009";
            this.CA009.Name = "CA009";
            this.CA009.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA009", "{0:N2}")});
            this.CA009.Visible = true;
            this.CA009.VisibleIndex = 14;
            // 
            // CA010
            // 
            this.CA010.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA010.AppearanceCell.Options.UseFont = true;
            this.CA010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA010.AppearanceHeader.Options.UseFont = true;
            this.CA010.AppearanceHeader.Options.UseTextOptions = true;
            this.CA010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA010.Caption = "医疗";
            this.CA010.FieldName = "CA010";
            this.CA010.Name = "CA010";
            this.CA010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA010", "{0:N2}")});
            this.CA010.Visible = true;
            this.CA010.VisibleIndex = 15;
            // 
            // U7
            // 
            this.U7.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U7.AppearanceCell.Options.UseFont = true;
            this.U7.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U7.AppearanceHeader.Options.UseFont = true;
            this.U7.AppearanceHeader.Options.UseTextOptions = true;
            this.U7.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U7.Caption = "月小计福利";
            this.U7.DisplayFormat.FormatString = "N2";
            this.U7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U7.FieldName = "U7";
            this.U7.Name = "U7";
            this.U7.OptionsColumn.AllowEdit = false;
            this.U7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U7", "{0:N2}")});
            this.U7.ToolTip = "[养老] + [医疗] + [失业、生育、工伤]";
            this.U7.UnboundExpression = "[CA009] + [CA010]+[CA020]";
            this.U7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U7.Visible = true;
            this.U7.VisibleIndex = 17;
            // 
            // U8
            // 
            this.U8.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U8.AppearanceCell.Options.UseFont = true;
            this.U8.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U8.AppearanceHeader.Options.UseFont = true;
            this.U8.AppearanceHeader.Options.UseTextOptions = true;
            this.U8.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U8.Caption = "合计工资(含五险公司缴纳部分)";
            this.U8.DisplayFormat.FormatString = "N2";
            this.U8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U8.FieldName = "U8";
            this.U8.Name = "U8";
            this.U8.OptionsColumn.AllowEdit = false;
            this.U8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U8", "{0:N2}")});
            this.U8.ToolTip = "[合计应发工资] + [月小计福利]";
            this.U8.UnboundExpression = "[U6] + [U7]";
            this.U8.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U8.Visible = true;
            this.U8.VisibleIndex = 18;
            this.U8.Width = 105;
            // 
            // U9
            // 
            this.U9.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U9.AppearanceCell.Options.UseFont = true;
            this.U9.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U9.AppearanceHeader.Options.UseFont = true;
            this.U9.AppearanceHeader.Options.UseTextOptions = true;
            this.U9.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U9.Caption = "合计日均工资";
            this.U9.DisplayFormat.FormatString = "N2";
            this.U9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U9.FieldName = "U9";
            this.U9.Name = "U9";
            this.U9.OptionsColumn.AllowEdit = false;
            this.U9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U9", "{0:N2}")});
            this.U9.ToolTip = "[合计工资(含养老医疗)] / [天数小计]";
            this.U9.UnboundExpression = "Iif(IsNullOrEmpty([U4]), 0, [U8] / [U4])";
            this.U9.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U9.Visible = true;
            this.U9.VisibleIndex = 19;
            // 
            // CA011
            // 
            this.CA011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA011.AppearanceCell.Options.UseFont = true;
            this.CA011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA011.AppearanceHeader.Options.UseFont = true;
            this.CA011.AppearanceHeader.Options.UseTextOptions = true;
            this.CA011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA011.Caption = "扣公积金";
            this.CA011.FieldName = "CA011";
            this.CA011.Name = "CA011";
            this.CA011.OptionsColumn.AllowEdit = false;
            this.CA011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA011", "{0:N2}")});
            this.CA011.Visible = true;
            this.CA011.VisibleIndex = 20;
            // 
            // CA012
            // 
            this.CA012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA012.AppearanceCell.Options.UseFont = true;
            this.CA012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA012.AppearanceHeader.Options.UseFont = true;
            this.CA012.AppearanceHeader.Options.UseTextOptions = true;
            this.CA012.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA012.Caption = "扣养老";
            this.CA012.FieldName = "CA012";
            this.CA012.Name = "CA012";
            this.CA012.OptionsColumn.AllowEdit = false;
            this.CA012.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA012", "{0:N2}")});
            this.CA012.Visible = true;
            this.CA012.VisibleIndex = 21;
            this.CA012.Width = 61;
            // 
            // CA013
            // 
            this.CA013.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA013.AppearanceCell.Options.UseFont = true;
            this.CA013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA013.AppearanceHeader.Options.UseFont = true;
            this.CA013.AppearanceHeader.Options.UseTextOptions = true;
            this.CA013.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA013.Caption = "扣个税";
            this.CA013.FieldName = "CA013";
            this.CA013.Name = "CA013";
            this.CA013.OptionsColumn.AllowEdit = false;
            this.CA013.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA013", "{0:N2}")});
            this.CA013.Visible = true;
            this.CA013.VisibleIndex = 22;
            this.CA013.Width = 58;
            // 
            // CA014
            // 
            this.CA014.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA014.AppearanceCell.Options.UseFont = true;
            this.CA014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA014.AppearanceHeader.Options.UseFont = true;
            this.CA014.AppearanceHeader.Options.UseTextOptions = true;
            this.CA014.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA014.Caption = "扣其它款";
            this.CA014.FieldName = "CA014";
            this.CA014.Name = "CA014";
            this.CA014.OptionsColumn.AllowEdit = false;
            this.CA014.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA014", "{0:N2}")});
            this.CA014.Visible = true;
            this.CA014.VisibleIndex = 23;
            // 
            // CA015
            // 
            this.CA015.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA015.AppearanceCell.Options.UseFont = true;
            this.CA015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA015.AppearanceHeader.Options.UseFont = true;
            this.CA015.AppearanceHeader.Options.UseTextOptions = true;
            this.CA015.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA015.Caption = "扣支借款";
            this.CA015.FieldName = "CA015";
            this.CA015.Name = "CA015";
            this.CA015.OptionsColumn.AllowEdit = false;
            this.CA015.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA015", "{0:N2}")});
            this.CA015.Visible = true;
            this.CA015.VisibleIndex = 24;
            // 
            // CA018
            // 
            this.CA018.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA018.AppearanceCell.Options.UseFont = true;
            this.CA018.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA018.AppearanceHeader.Options.UseFont = true;
            this.CA018.AppearanceHeader.Options.UseTextOptions = true;
            this.CA018.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA018.Caption = "失业";
            this.CA018.FieldName = "CA018";
            this.CA018.Name = "CA018";
            this.CA018.OptionsColumn.AllowEdit = false;
            this.CA018.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA018", "{0:0.00}")});
            this.CA018.Visible = true;
            this.CA018.VisibleIndex = 26;
            this.CA018.Width = 44;
            // 
            // CA019
            // 
            this.CA019.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA019.AppearanceCell.Options.UseFont = true;
            this.CA019.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA019.AppearanceHeader.Options.UseFont = true;
            this.CA019.Caption = "医疗";
            this.CA019.FieldName = "CA019";
            this.CA019.Name = "CA019";
            this.CA019.OptionsColumn.AllowEdit = false;
            this.CA019.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA019", "{0:0.00}")});
            this.CA019.Visible = true;
            this.CA019.VisibleIndex = 25;
            this.CA019.Width = 44;
            // 
            // U10
            // 
            this.U10.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U10.AppearanceCell.Options.UseFont = true;
            this.U10.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U10.AppearanceHeader.Options.UseFont = true;
            this.U10.AppearanceHeader.Options.UseTextOptions = true;
            this.U10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U10.Caption = "扣款小计";
            this.U10.DisplayFormat.FormatString = "N2";
            this.U10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U10.FieldName = "U10";
            this.U10.Name = "U10";
            this.U10.OptionsColumn.AllowEdit = false;
            this.U10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U10", "{0:N2}")});
            this.U10.ToolTip = "[扣个税] + [扣公积金] + [扣其它款] + [扣养老] + [扣支借款] + [失业] + [医疗]";
            this.U10.UnboundExpression = "[CA013] + [CA011] + [CA014] + [CA012] + [CA015] + [CA018] + [CA010]";
            this.U10.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U10.Visible = true;
            this.U10.VisibleIndex = 27;
            // 
            // U11
            // 
            this.U11.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.U11.AppearanceCell.Options.UseFont = true;
            this.U11.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.U11.AppearanceHeader.Options.UseFont = true;
            this.U11.AppearanceHeader.Options.UseTextOptions = true;
            this.U11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U11.Caption = "实发工资";
            this.U11.DisplayFormat.FormatString = "N2";
            this.U11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U11.FieldName = "U11";
            this.U11.Name = "U11";
            this.U11.OptionsColumn.AllowEdit = false;
            this.U11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U11", "{0:N2}")});
            this.U11.ToolTip = "[合计应发工资] - [扣款小计]";
            this.U11.UnboundExpression = "[U6] - [U10]";
            this.U11.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U11.Visible = true;
            this.U11.VisibleIndex = 28;
            // 
            // CA001
            // 
            this.CA001.Caption = "单号";
            this.CA001.FieldName = "CA001";
            this.CA001.Name = "CA001";
            // 
            // CA016
            // 
            this.CA016.Caption = "月";
            this.CA016.FieldName = "CA016";
            this.CA016.Name = "CA016";
            // 
            // CA017
            // 
            this.CA017.Caption = "年";
            this.CA017.FieldName = "CA017";
            this.CA017.Name = "CA017";
            // 
            // CA020
            // 
            this.CA020.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA020.AppearanceCell.Options.UseFont = true;
            this.CA020.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA020.AppearanceHeader.Options.UseFont = true;
            this.CA020.AppearanceHeader.Options.UseTextOptions = true;
            this.CA020.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CA020.Caption = "失业、生育、工伤";
            this.CA020.FieldName = "CA020";
            this.CA020.Name = "CA020";
            this.CA020.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CA020", "{0:0.00}")});
            this.CA020.Visible = true;
            this.CA020.VisibleIndex = 16;
            // 
            // FormPeragg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 473);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormPeragg";
            this.Text = "管理人员个人工资汇总表(R_376)";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lupPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CA002;
        private DevExpress . XtraGrid . Columns . GridColumn CA003;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn U1;
        private DevExpress . XtraGrid . Columns . GridColumn CA004;
        private DevExpress . XtraGrid . Columns . GridColumn U2;
        private DevExpress . XtraGrid . Columns . GridColumn CA005;
        private DevExpress . XtraGrid . Columns . GridColumn U3;
        private DevExpress . XtraGrid . Columns . GridColumn U4;
        private DevExpress . XtraGrid . Columns . GridColumn U5;
        private DevExpress . XtraGrid . Columns . GridColumn CA006;
        private DevExpress . XtraGrid . Columns . GridColumn CA007;
        private DevExpress . XtraGrid . Columns . GridColumn CA008;
        private DevExpress . XtraGrid . Columns . GridColumn U6;
        private DevExpress . XtraGrid . Columns . GridColumn CA009;
        private DevExpress . XtraGrid . Columns . GridColumn CA010;
        private DevExpress . XtraGrid . Columns . GridColumn U7;
        private DevExpress . XtraGrid . Columns . GridColumn U8;
        private DevExpress . XtraGrid . Columns . GridColumn U9;
        private DevExpress . XtraGrid . Columns . GridColumn CA011;
        private DevExpress . XtraGrid . Columns . GridColumn CA012;
        private DevExpress . XtraGrid . Columns . GridColumn CA013;
        private DevExpress . XtraGrid . Columns . GridColumn CA014;
        private DevExpress . XtraGrid . Columns . GridColumn CA015;
        private DevExpress . XtraGrid . Columns . GridColumn U10;
        private DevExpress . XtraGrid . Columns . GridColumn U11;
        private DevExpress . XtraEditors . LookUpEdit lupPerson;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . DateTimePicker dtp;
        private System . Windows . Forms . Label label12;
        private System . Windows . Forms . Button btnRead;
        private DevExpress . XtraGrid . Columns . GridColumn CA001;
        private DevExpress . XtraGrid . Columns . GridColumn CA016;
        private DevExpress . XtraGrid . Columns . GridColumn CA017;
        private System . Windows . Forms . Button btnBatchEdit;
        private DevExpress . XtraGrid . Columns . GridColumn CA018;
        private DevExpress . XtraGrid . Columns . GridColumn CA019;
        private DevExpress . XtraGrid . Columns . GridColumn CA020;
    }
}