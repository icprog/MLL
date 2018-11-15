namespace SelectAll
{
    partial class PayMentDetailed
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.WY001 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.WZ015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WY002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ013 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WZ014 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1233, 437);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.WY001,
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
            this.WZ015,
            this.WY002,
            this.idx,
            this.WZ012,
            this.WZ013,
            this.WZ014,
            this.U0});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.AppearanceHeader.Options.UseTextOptions = true;
            this.check.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.check.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 52;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // WY001
            // 
            this.WY001.Caption = "244扣款编号";
            this.WY001.FieldName = "WY001";
            this.WY001.Name = "WY001";
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
            this.WZ002.VisibleIndex = 1;
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
            this.WZ003.VisibleIndex = 2;
            this.WZ003.Width = 78;
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
            this.WZ004.VisibleIndex = 3;
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
            this.WZ005.VisibleIndex = 4;
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
            this.WZ007.VisibleIndex = 5;
            this.WZ007.Width = 78;
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
            this.WZ006.VisibleIndex = 6;
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
            this.WZ008.VisibleIndex = 7;
            this.WZ008.Width = 78;
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
            this.WZ009.VisibleIndex = 8;
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
            this.WZ010.VisibleIndex = 9;
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
            this.WZ011.VisibleIndex = 10;
            this.WZ011.Width = 78;
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
            this.WZ015.VisibleIndex = 16;
            this.WZ015.Width = 300;
            // 
            // WY002
            // 
            this.WY002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WY002.AppearanceCell.Options.UseFont = true;
            this.WY002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WY002.AppearanceHeader.Options.UseFont = true;
            this.WY002.Caption = "本次扣款金额";
            this.WY002.DisplayFormat.FormatString = "N2";
            this.WY002.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.WY002.FieldName = "WY002";
            this.WY002.Name = "WY002";
            this.WY002.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WY002", "{0:N2}")});
            this.WY002.Visible = true;
            this.WY002.VisibleIndex = 15;
            this.WY002.Width = 112;
            // 
            // idx
            // 
            this.idx.Caption = "本次扣款编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // WZ012
            // 
            this.WZ012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ012.AppearanceCell.Options.UseFont = true;
            this.WZ012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ012.AppearanceHeader.Options.UseFont = true;
            this.WZ012.Caption = "材料款";
            this.WZ012.FieldName = "WZ012";
            this.WZ012.Name = "WZ012";
            this.WZ012.Visible = true;
            this.WZ012.VisibleIndex = 12;
            // 
            // WZ013
            // 
            this.WZ013.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ013.AppearanceCell.Options.UseFont = true;
            this.WZ013.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ013.AppearanceHeader.Options.UseFont = true;
            this.WZ013.Caption = "责任款";
            this.WZ013.FieldName = "WZ013";
            this.WZ013.Name = "WZ013";
            this.WZ013.Visible = true;
            this.WZ013.VisibleIndex = 13;
            // 
            // WZ014
            // 
            this.WZ014.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ014.AppearanceCell.Options.UseFont = true;
            this.WZ014.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WZ014.AppearanceHeader.Options.UseFont = true;
            this.WZ014.Caption = "其它";
            this.WZ014.FieldName = "WZ014";
            this.WZ014.Name = "WZ014";
            this.WZ014.Visible = true;
            this.WZ014.VisibleIndex = 14;
            this.WZ014.Width = 54;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.Caption = "扣款合计";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.ToolTip = "[材料款] + [责任款] + [其它]";
            this.U0.UnboundExpression = "[WZ012] + [WZ013] + [WZ014]";
            this.U0.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U0.Visible = true;
            this.U0.VisibleIndex = 11;
            this.U0.Width = 80;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 485);
            this.splitContainer1.SplitterDistance = 44;
            this.splitContainer1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(93, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(255, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PayMentDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 485);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PayMentDetailed";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.PayMentDetailed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn WY001;
        private DevExpress.XtraGrid.Columns.GridColumn WZ002;
        private DevExpress.XtraGrid.Columns.GridColumn WZ003;
        private DevExpress.XtraGrid.Columns.GridColumn WZ004;
        private DevExpress.XtraGrid.Columns.GridColumn WZ005;
        private DevExpress.XtraGrid.Columns.GridColumn WZ007;
        private DevExpress.XtraGrid.Columns.GridColumn WZ006;
        private DevExpress.XtraGrid.Columns.GridColumn WZ008;
        private DevExpress.XtraGrid.Columns.GridColumn WZ009;
        private DevExpress.XtraGrid.Columns.GridColumn WZ010;
        private DevExpress.XtraGrid.Columns.GridColumn WZ011;
        private DevExpress.XtraGrid.Columns.GridColumn WZ015;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn WY002;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn WZ012;
        private DevExpress . XtraGrid . Columns . GridColumn WZ013;
        private DevExpress . XtraGrid . Columns . GridColumn WZ014;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
    }
}