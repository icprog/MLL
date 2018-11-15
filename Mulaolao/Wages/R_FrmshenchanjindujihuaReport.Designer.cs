namespace Mulaolao . Wages
{
    partial class R_FrmshenchanjindujihuaReport
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PQX29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQX21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1247, 228);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PQX29,
            this.PQX01,
            this.PQX31,
            this.PQX14,
            this.PQX15,
            this.PQX16,
            this.U29,
            this.U2,
            this.U4,
            this.U12,
            this.U8,
            this.U15,
            this.U14,
            this.gridColumn14,
            this.PQX21,
            this.gridColumn16});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // PQX29
            // 
            this.PQX29.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX29.AppearanceCell.Options.UseFont = true;
            this.PQX29.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX29.AppearanceHeader.Options.UseFont = true;
            this.PQX29.Caption = "产品名称";
            this.PQX29.FieldName = "PQX29";
            this.PQX29.Name = "PQX29";
            this.PQX29.Visible = true;
            this.PQX29.VisibleIndex = 0;
            // 
            // PQX01
            // 
            this.PQX01.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX01.AppearanceCell.Options.UseFont = true;
            this.PQX01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX01.AppearanceHeader.Options.UseFont = true;
            this.PQX01.Caption = "流水号";
            this.PQX01.FieldName = "PQX01";
            this.PQX01.Name = "PQX01";
            this.PQX01.Visible = true;
            this.PQX01.VisibleIndex = 1;
            // 
            // PQX31
            // 
            this.PQX31.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX31.AppearanceCell.Options.UseFont = true;
            this.PQX31.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX31.AppearanceHeader.Options.UseFont = true;
            this.PQX31.Caption = "货号";
            this.PQX31.FieldName = "PQX31";
            this.PQX31.Name = "PQX31";
            this.PQX31.Visible = true;
            this.PQX31.VisibleIndex = 2;
            this.PQX31.Width = 59;
            // 
            // PQX14
            // 
            this.PQX14.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX14.AppearanceCell.Options.UseFont = true;
            this.PQX14.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX14.AppearanceHeader.Options.UseFont = true;
            this.PQX14.Caption = "零件名称";
            this.PQX14.FieldName = "PQX14";
            this.PQX14.Name = "PQX14";
            this.PQX14.Visible = true;
            this.PQX14.VisibleIndex = 3;
            this.PQX14.Width = 65;
            // 
            // PQX15
            // 
            this.PQX15.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX15.AppearanceCell.Options.UseFont = true;
            this.PQX15.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX15.AppearanceHeader.Options.UseFont = true;
            this.PQX15.Caption = "工序名称";
            this.PQX15.FieldName = "PQX15";
            this.PQX15.Name = "PQX15";
            this.PQX15.Visible = true;
            this.PQX15.VisibleIndex = 4;
            this.PQX15.Width = 67;
            // 
            // PQX16
            // 
            this.PQX16.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX16.AppearanceCell.Options.UseFont = true;
            this.PQX16.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX16.AppearanceHeader.Options.UseFont = true;
            this.PQX16.Caption = "工序号";
            this.PQX16.FieldName = "PQX16";
            this.PQX16.Name = "PQX16";
            this.PQX16.Visible = true;
            this.PQX16.VisibleIndex = 5;
            this.PQX16.Width = 54;
            // 
            // U29
            // 
            this.U29.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U29.AppearanceCell.Options.UseFont = true;
            this.U29.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U29.AppearanceHeader.Options.UseFont = true;
            this.U29.Caption = "R317读入次数";
            this.U29.FieldName = "U29";
            this.U29.Name = "U29";
            this.U29.Visible = true;
            this.U29.VisibleIndex = 6;
            this.U29.Width = 101;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.Caption = "工序实产周期";
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.Visible = true;
            this.U2.VisibleIndex = 7;
            this.U2.Width = 94;
            // 
            // U4
            // 
            this.U4.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U4.AppearanceCell.Options.UseFont = true;
            this.U4.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U4.AppearanceHeader.Options.UseFont = true;
            this.U4.Caption = "欠投产天数";
            this.U4.FieldName = "U4";
            this.U4.Name = "U4";
            this.U4.Visible = true;
            this.U4.VisibleIndex = 8;
            this.U4.Width = 80;
            // 
            // U12
            // 
            this.U12.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U12.AppearanceCell.Options.UseFont = true;
            this.U12.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U12.AppearanceHeader.Options.UseFont = true;
            this.U12.Caption = "工序积压数量";
            this.U12.FieldName = "U12";
            this.U12.Name = "U12";
            this.U12.Visible = true;
            this.U12.VisibleIndex = 9;
            this.U12.Width = 94;
            // 
            // U8
            // 
            this.U8.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U8.AppearanceCell.Options.UseFont = true;
            this.U8.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U8.AppearanceHeader.Options.UseFont = true;
            this.U8.Caption = "当日欠产量";
            this.U8.FieldName = "U8";
            this.U8.Name = "U8";
            this.U8.Visible = true;
            this.U8.VisibleIndex = 10;
            this.U8.Width = 80;
            // 
            // U15
            // 
            this.U15.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U15.AppearanceCell.Options.UseFont = true;
            this.U15.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U15.AppearanceHeader.Options.UseFont = true;
            this.U15.Caption = "日均欠产量";
            this.U15.FieldName = "U15";
            this.U15.Name = "U15";
            this.U15.Visible = true;
            this.U15.VisibleIndex = 11;
            this.U15.Width = 80;
            // 
            // U14
            // 
            this.U14.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U14.AppearanceCell.Options.UseFont = true;
            this.U14.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U14.AppearanceHeader.Options.UseFont = true;
            this.U14.Caption = "累欠产量";
            this.U14.FieldName = "U14";
            this.U14.Name = "U14";
            this.U14.Visible = true;
            this.U14.VisibleIndex = 12;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridColumn14.AppearanceCell.Options.UseFont = true;
            this.gridColumn14.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridColumn14.AppearanceHeader.Options.UseFont = true;
            this.gridColumn14.Caption = "承担责任元";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Width = 80;
            // 
            // PQX21
            // 
            this.PQX21.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX21.AppearanceCell.Options.UseFont = true;
            this.PQX21.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.PQX21.AppearanceHeader.Options.UseFont = true;
            this.PQX21.Caption = "工序组长";
            this.PQX21.FieldName = "PQX21";
            this.PQX21.Name = "PQX21";
            this.PQX21.Visible = true;
            this.PQX21.VisibleIndex = 13;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.Caption = "备注";
            this.gridColumn16.Name = "gridColumn16";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.layoutControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1247, 461);
            this.splitContainerControl1.SplitterPosition = 228;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chartControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1247, 228);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chartControl1
            // 
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.GridLines.MinorVisible = true;
            xyDiagram1.AxisX.GridLines.Visible = true;
            xyDiagram1.AxisX.Interlaced = true;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Interlaced = true;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(12, 12);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "SeriesOne";
            sideBySideBarSeriesView1.ColorEach = true;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1223, 204);
            this.chartControl1.TabIndex = 4;
            chartTitle1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "组长延误工序数";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1247, 228);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chartControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1227, 208);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // R_FrmshenchanjindujihuaReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 461);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "R_FrmshenchanjindujihuaReport";
            this.Text = "R_046生产延误汇总表(R_048)";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn PQX29;
        private DevExpress . XtraGrid . Columns . GridColumn PQX01;
        private DevExpress . XtraGrid . Columns . GridColumn PQX31;
        private DevExpress . XtraGrid . Columns . GridColumn PQX14;
        private DevExpress . XtraGrid . Columns . GridColumn PQX15;
        private DevExpress . XtraGrid . Columns . GridColumn PQX16;
        private DevExpress . XtraGrid . Columns . GridColumn U29;
        private DevExpress . XtraGrid . Columns . GridColumn U2;
        private DevExpress . XtraGrid . Columns . GridColumn U4;
        private DevExpress . XtraGrid . Columns . GridColumn U12;
        private DevExpress . XtraGrid . Columns . GridColumn U8;
        private DevExpress . XtraGrid . Columns . GridColumn U15;
        private DevExpress . XtraGrid . Columns . GridColumn U14;
        private DevExpress . XtraGrid . Columns . GridColumn gridColumn14;
        private DevExpress . XtraGrid . Columns . GridColumn PQX21;
        private DevExpress . XtraGrid . Columns . GridColumn gridColumn16;
        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraLayout . LayoutControl layoutControl1;
        private DevExpress . XtraLayout . LayoutControlGroup layoutControlGroup1;
        private DevExpress . XtraCharts . ChartControl chartControl1;
        private DevExpress . XtraLayout . LayoutControlItem layoutControlItem1;
    }
}