namespace Mulaolao . Environmental
{
    partial class FormCustomerInspectionTable
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
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DB00401 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DM009 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.button1);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1250, 430);
            this.splitContainerControl1.SplitterPosition = 40;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(252, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "读 取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "yyyy年";
            this.dateTimePicker1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 23);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "填报日期";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1250, 385);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idx,
            this.DM002,
            this.DM003,
            this.DM004,
            this.DM005,
            this.DM006,
            this.U0,
            this.DM007,
            this.DB00401,
            this.DM008,
            this.DM009});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DM005", this.DM005, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DM006", this.DM006, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "U0", this.U0, "{0:P1}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DM007", this.DM007, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DM008", this.DM008, "{0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DM009", this.DM009, "{0}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DM002, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.DM004, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.CustomDrawRowFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridView1_CustomDrawRowFooterCell);
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // DM002
            // 
            this.DM002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM002.AppearanceCell.Options.UseFont = true;
            this.DM002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM002.AppearanceHeader.Options.UseFont = true;
            this.DM002.Caption = "客户";
            this.DM002.FieldName = "DM002";
            this.DM002.Name = "DM002";
            this.DM002.Visible = true;
            this.DM002.VisibleIndex = 0;
            this.DM002.Width = 231;
            // 
            // DM003
            // 
            this.DM003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM003.AppearanceCell.Options.UseFont = true;
            this.DM003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM003.AppearanceHeader.Options.UseFont = true;
            this.DM003.Caption = "班组长";
            this.DM003.FieldName = "DM003";
            this.DM003.Name = "DM003";
            this.DM003.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM003.Visible = true;
            this.DM003.VisibleIndex = 1;
            this.DM003.Width = 175;
            // 
            // DM004
            // 
            this.DM004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM004.AppearanceCell.Options.UseFont = true;
            this.DM004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM004.AppearanceHeader.Options.UseFont = true;
            this.DM004.Caption = "月份";
            this.DM004.FieldName = "DM004";
            this.DM004.Name = "DM004";
            this.DM004.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.DM004.Visible = true;
            this.DM004.VisibleIndex = 0;
            this.DM004.Width = 60;
            // 
            // DM005
            // 
            this.DM005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM005.AppearanceCell.Options.UseFont = true;
            this.DM005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM005.AppearanceHeader.Options.UseFont = true;
            this.DM005.Caption = "出货批次";
            this.DM005.FieldName = "DM005";
            this.DM005.Name = "DM005";
            this.DM005.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM005.Visible = true;
            this.DM005.VisibleIndex = 2;
            this.DM005.Width = 175;
            // 
            // DM006
            // 
            this.DM006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM006.AppearanceCell.Options.UseFont = true;
            this.DM006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM006.AppearanceHeader.Options.UseFont = true;
            this.DM006.Caption = "直通批次";
            this.DM006.FieldName = "DM006";
            this.DM006.Name = "DM006";
            this.DM006.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM006.Visible = true;
            this.DM006.VisibleIndex = 3;
            this.DM006.Width = 175;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.Caption = "直通率%";
            this.U0.DisplayFormat.FormatString = "P1";
            this.U0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.OptionsColumn.AllowEdit = false;
            this.U0.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.U0.ToolTip = "([直通批次] + [条件接收]) * 1.0 / [出货批次]";
            this.U0.UnboundExpression = "([DM006]+[DM009]) * 1.0 / [DM005]";
            this.U0.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.U0.Visible = true;
            this.U0.VisibleIndex = 4;
            this.U0.Width = 175;
            // 
            // DM007
            // 
            this.DM007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM007.AppearanceCell.Options.UseFont = true;
            this.DM007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DM007.AppearanceHeader.Options.UseFont = true;
            this.DM007.Caption = "二次过批";
            this.DM007.FieldName = "DM007";
            this.DM007.Name = "DM007";
            this.DM007.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM007.Visible = true;
            this.DM007.VisibleIndex = 5;
            this.DM007.Width = 189;
            // 
            // DB00401
            // 
            this.DB00401.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DB00401.AppearanceCell.Options.UseFont = true;
            this.DB00401.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DB00401.AppearanceHeader.Options.UseFont = true;
            this.DB00401.Caption = "月份";
            this.DB00401.FieldName = "DM004";
            this.DB00401.Name = "DB00401";
            this.DB00401.Visible = true;
            this.DB00401.VisibleIndex = 0;
            this.DB00401.Width = 62;
            // 
            // DM008
            // 
            this.DM008.Caption = "退货";
            this.DM008.FieldName = "DM008";
            this.DM008.Name = "DM008";
            this.DM008.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM008.Visible = true;
            this.DM008.VisibleIndex = 6;
            this.DM008.Width = 53;
            // 
            // DM009
            // 
            this.DM009.Caption = "条件接收";
            this.DM009.FieldName = "DM009";
            this.DM009.Name = "DM009";
            this.DM009.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.DM009.Visible = true;
            this.DM009.VisibleIndex = 7;
            this.DM009.Width = 74;
            // 
            // FormCustomerInspectionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 455);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormCustomerInspectionTable";
            this.Text = "各车间产品客检一次性通过统计表(R_473)";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private System . Windows . Forms . DateTimePicker dateTimePicker1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn DM002;
        private DevExpress . XtraGrid . Columns . GridColumn DM003;
        private DevExpress . XtraGrid . Columns . GridColumn DM004;
        private DevExpress . XtraGrid . Columns . GridColumn DM005;
        private DevExpress . XtraGrid . Columns . GridColumn DM006;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn DM007;
        private System . Windows . Forms . Button button1;
        private DevExpress . XtraGrid . Columns . GridColumn DB00401;
        private DevExpress . XtraGrid . Columns . GridColumn DM008;
        private DevExpress . XtraGrid . Columns . GridColumn DM009;
    }
}