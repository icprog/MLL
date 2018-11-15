namespace SelectAll
{
    partial class FormSupplier
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ010 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button15);
            this.splitContainer1.Panel1.Controls.Add(this.button16);
            this.splitContainer1.Panel1.Controls.Add(this.button17);
            this.splitContainer1.Panel1.Controls.Add(this.button18);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1211, 464);
            this.splitContainer1.SplitterDistance = 47;
            this.splitContainer1.TabIndex = 0;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button15.Location = new System.Drawing.Point(270, 12);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 25);
            this.button15.TabIndex = 19;
            this.button15.Text = "取消";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button16.Location = new System.Drawing.Point(189, 12);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 25);
            this.button16.TabIndex = 18;
            this.button16.Text = "确定";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button17.Location = new System.Drawing.Point(93, 12);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(90, 25);
            this.button17.TabIndex = 17;
            this.button17.Text = "取消全选";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button18.Location = new System.Drawing.Point(12, 12);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 25);
            this.button18.TabIndex = 16;
            this.button18.Text = "全选";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1211, 413);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.idx,
            this.WZ002,
            this.WZ003,
            this.WZ004,
            this.WZ005,
            this.WZ007,
            this.WZ006,
            this.WZ008,
            this.WZ009,
            this.WZ010,
            this.WZ011,
            this.WZ012,
            this.WZ013,
            this.WZ014,
            this.U0,
            this.WZ016,
            this.WZ015,
            this.WZ,
            this.U1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 41;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // WZ002
            // 
            this.WZ002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ002.AppearanceCell.Options.UseFont = true;
            this.WZ002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ002.AppearanceHeader.Options.UseFont = true;
            this.WZ002.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ002.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ002.Caption = "登记日期";
            this.WZ002.FieldName = "WZ002";
            this.WZ002.Name = "WZ002";
            this.WZ002.Visible = true;
            this.WZ002.VisibleIndex = 2;
            this.WZ002.Width = 94;
            // 
            // WZ003
            // 
            this.WZ003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ003.AppearanceCell.Options.UseFont = true;
            this.WZ003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ003.AppearanceHeader.Options.UseFont = true;
            this.WZ003.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ003.Caption = "车间主任";
            this.WZ003.FieldName = "WZ003";
            this.WZ003.Name = "WZ003";
            this.WZ003.Visible = true;
            this.WZ003.VisibleIndex = 3;
            // 
            // WZ004
            // 
            this.WZ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ004.AppearanceCell.Options.UseFont = true;
            this.WZ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ004.AppearanceHeader.Options.UseFont = true;
            this.WZ004.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ004.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ004.Caption = "供应商";
            this.WZ004.FieldName = "WZ004";
            this.WZ004.Name = "WZ004";
            this.WZ004.Visible = true;
            this.WZ004.VisibleIndex = 4;
            // 
            // WZ005
            // 
            this.WZ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ005.AppearanceCell.Options.UseFont = true;
            this.WZ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ005.AppearanceHeader.Options.UseFont = true;
            this.WZ005.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ005.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ005.Caption = "采购员/经办人";
            this.WZ005.FieldName = "WZ005";
            this.WZ005.Name = "WZ005";
            this.WZ005.Visible = true;
            this.WZ005.VisibleIndex = 5;
            this.WZ005.Width = 126;
            // 
            // WZ007
            // 
            this.WZ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ007.AppearanceCell.Options.UseFont = true;
            this.WZ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ007.AppearanceHeader.Options.UseFont = true;
            this.WZ007.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ007.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ007.Caption = "产品货号";
            this.WZ007.FieldName = "WZ007";
            this.WZ007.Name = "WZ007";
            this.WZ007.Visible = true;
            this.WZ007.VisibleIndex = 6;
            // 
            // WZ006
            // 
            this.WZ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ006.AppearanceCell.Options.UseFont = true;
            this.WZ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ006.AppearanceHeader.Options.UseFont = true;
            this.WZ006.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ006.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ006.Caption = "流水号";
            this.WZ006.FieldName = "WZ006";
            this.WZ006.Name = "WZ006";
            this.WZ006.Visible = true;
            this.WZ006.VisibleIndex = 7;
            // 
            // WZ008
            // 
            this.WZ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ008.AppearanceCell.Options.UseFont = true;
            this.WZ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ008.AppearanceHeader.Options.UseFont = true;
            this.WZ008.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ008.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ008.Caption = "产品名称";
            this.WZ008.FieldName = "WZ008";
            this.WZ008.Name = "WZ008";
            this.WZ008.Visible = true;
            this.WZ008.VisibleIndex = 8;
            // 
            // WZ009
            // 
            this.WZ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ009.AppearanceCell.Options.UseFont = true;
            this.WZ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ009.AppearanceHeader.Options.UseFont = true;
            this.WZ009.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ009.Caption = "物品、工序名称";
            this.WZ009.FieldName = "WZ009";
            this.WZ009.Name = "WZ009";
            this.WZ009.Visible = true;
            this.WZ009.VisibleIndex = 9;
            this.WZ009.Width = 146;
            // 
            // WZ010
            // 
            this.WZ010.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ010.AppearanceCell.Options.UseFont = true;
            this.WZ010.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ010.AppearanceHeader.Options.UseFont = true;
            this.WZ010.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ010.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ010.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ010.Caption = "合同应付款";
            this.WZ010.FieldName = "WZ010";
            this.WZ010.Name = "WZ010";
            this.WZ010.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WZ010", "{0:N2}")});
            this.WZ010.Visible = true;
            this.WZ010.VisibleIndex = 10;
            this.WZ010.Width = 112;
            // 
            // WZ011
            // 
            this.WZ011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ011.AppearanceCell.Options.UseFont = true;
            this.WZ011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ011.AppearanceHeader.Options.UseFont = true;
            this.WZ011.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ011.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ011.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ011.Caption = "预支借款";
            this.WZ011.FieldName = "WZ011";
            this.WZ011.Name = "WZ011";
            this.WZ011.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WZ011", "{0:N2}")});
            this.WZ011.Visible = true;
            this.WZ011.VisibleIndex = 11;
            // 
            // WZ012
            // 
            this.WZ012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ012.AppearanceCell.Options.UseFont = true;
            this.WZ012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ012.AppearanceHeader.Options.UseFont = true;
            this.WZ012.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ012.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ012.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ012.Caption = "材料款";
            this.WZ012.FieldName = "WZ012";
            this.WZ012.Name = "WZ012";
            this.WZ012.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WZ012", "{0:N2}")});
            this.WZ012.Visible = true;
            this.WZ012.VisibleIndex = 13;
            // 
            // WZ013
            // 
            this.WZ013.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ013.AppearanceCell.Options.UseFont = true;
            this.WZ013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ013.AppearanceHeader.Options.UseFont = true;
            this.WZ013.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ013.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ013.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ013.Caption = "责任款";
            this.WZ013.FieldName = "WZ013";
            this.WZ013.Name = "WZ013";
            this.WZ013.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WZ013", "{0:N2}")});
            this.WZ013.Visible = true;
            this.WZ013.VisibleIndex = 14;
            // 
            // WZ014
            // 
            this.WZ014.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ014.AppearanceCell.Options.UseFont = true;
            this.WZ014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ014.AppearanceHeader.Options.UseFont = true;
            this.WZ014.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ014.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ014.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ014.Caption = "其他";
            this.WZ014.FieldName = "WZ014";
            this.WZ014.Name = "WZ014";
            this.WZ014.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WZ014", "{0:N2}")});
            this.WZ014.Visible = true;
            this.WZ014.VisibleIndex = 15;
            this.WZ014.Width = 60;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.AppearanceHeader.Options.UseTextOptions = true;
            this.U0.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U0.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U0.Caption = "扣款合计";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U0", "{0:N2}")});
            this.U0.ToolTip = "[责任款] + [其他] + [材料款]";
            this.U0.UnboundExpression = "[WZ013] + [WZ014] + [WZ012]";
            this.U0.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U0.Visible = true;
            this.U0.VisibleIndex = 12;
            // 
            // WZ016
            // 
            this.WZ016.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ016.AppearanceCell.Options.UseFont = true;
            this.WZ016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ016.AppearanceHeader.Options.UseFont = true;
            this.WZ016.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ016.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ016.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ016.Caption = "是否扣款";
            this.WZ016.FieldName = "WZ016";
            this.WZ016.Name = "WZ016";
            this.WZ016.ToolTip = "[材料款] + [其他] + [责任款]";
            this.WZ016.UnboundExpression = "[WZ012] + [WZ014] + [WZ013]";
            this.WZ016.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.WZ016.Visible = true;
            this.WZ016.VisibleIndex = 1;
            // 
            // WZ015
            // 
            this.WZ015.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ015.AppearanceCell.Options.UseFont = true;
            this.WZ015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ015.AppearanceHeader.Options.UseFont = true;
            this.WZ015.AppearanceHeader.Options.UseTextOptions = true;
            this.WZ015.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WZ015.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WZ015.Caption = "备注";
            this.WZ015.FieldName = "WZ015";
            this.WZ015.Name = "WZ015";
            this.WZ015.Visible = true;
            this.WZ015.VisibleIndex = 18;
            this.WZ015.Width = 313;
            // 
            // WZ
            // 
            this.WZ.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ.AppearanceCell.Options.UseFont = true;
            this.WZ.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ.AppearanceHeader.Options.UseFont = true;
            this.WZ.Caption = "扣款累计";
            this.WZ.DisplayFormat.FormatString = "N2";
            this.WZ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.WZ.FieldName = "WZ";
            this.WZ.Name = "WZ";
            this.WZ.Visible = true;
            this.WZ.VisibleIndex = 16;
            this.WZ.Width = 81;
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.Caption = "未扣款";
            this.U1.DisplayFormat.FormatString = "N2";
            this.U1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.ToolTip = "[扣款合计] - [扣款累计]";
            this.U1.UnboundExpression = "[U0] - [WZ]";
            this.U1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U1.Visible = true;
            this.U1.VisibleIndex = 17;
            this.U1.Width = 67;
            // 
            // FormSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 464);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSupplier";
            this.Text = "R_244扣款选择";
            this.Load += new System.EventHandler(this.FormSupplier_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . Button button15;
        private System . Windows . Forms . Button button16;
        private System . Windows . Forms . Button button17;
        private System . Windows . Forms . Button button18;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn WZ002;
        private DevExpress . XtraGrid . Columns . GridColumn WZ003;
        private DevExpress . XtraGrid . Columns . GridColumn WZ004;
        private DevExpress . XtraGrid . Columns . GridColumn WZ005;
        private DevExpress . XtraGrid . Columns . GridColumn WZ007;
        private DevExpress . XtraGrid . Columns . GridColumn WZ006;
        private DevExpress . XtraGrid . Columns . GridColumn WZ008;
        private DevExpress . XtraGrid . Columns . GridColumn WZ009;
        private DevExpress . XtraGrid . Columns . GridColumn WZ010;
        private DevExpress . XtraGrid . Columns . GridColumn WZ011;
        private DevExpress . XtraGrid . Columns . GridColumn WZ012;
        private DevExpress . XtraGrid . Columns . GridColumn WZ013;
        private DevExpress . XtraGrid . Columns . GridColumn WZ014;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn WZ016;
        private DevExpress . XtraGrid . Columns . GridColumn WZ015;
        private DevExpress . XtraGrid . Columns . GridColumn check;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn WZ;
        private DevExpress . XtraGrid . Columns . GridColumn U1;
    }
}