namespace Mulaolao . Environmental
{
    partial class FormStandardTest
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageOne = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CL001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CL007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TabPageTwo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CM001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CM007 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.TabPageOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.TabPageTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 25);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.TabPageOne;
            this.xtraTabControl1.Size = new System.Drawing.Size(1241, 408);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageOne,
            this.TabPageTwo});
            // 
            // TabPageOne
            // 
            this.TabPageOne.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageOne.Appearance.Header.Options.UseFont = true;
            this.TabPageOne.Controls.Add(this.gridControl1);
            this.TabPageOne.Name = "TabPageOne";
            this.TabPageOne.Size = new System.Drawing.Size(1235, 379);
            this.TabPageOne.Text = "GB2828标准外来物资抽样方法";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1235, 379);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CL001,
            this.CL002,
            this.CL003,
            this.CL004,
            this.CL005,
            this.CL006,
            this.CL007});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // CL001
            // 
            this.CL001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CL001.AppearanceCell.Options.UseFont = true;
            this.CL001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CL001.AppearanceHeader.Options.UseFont = true;
            this.CL001.Caption = "批量范围头";
            this.CL001.FieldName = "CL001";
            this.CL001.Name = "CL001";
            this.CL001.Visible = true;
            this.CL001.VisibleIndex = 0;
            // 
            // CL002
            // 
            this.CL002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL002.AppearanceCell.Options.UseFont = true;
            this.CL002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL002.AppearanceHeader.Options.UseFont = true;
            this.CL002.Caption = "批量范围尾";
            this.CL002.FieldName = "CL002";
            this.CL002.Name = "CL002";
            this.CL002.Visible = true;
            this.CL002.VisibleIndex = 1;
            // 
            // CL003
            // 
            this.CL003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL003.AppearanceCell.Options.UseFont = true;
            this.CL003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL003.AppearanceHeader.Options.UseFont = true;
            this.CL003.Caption = "抽检数";
            this.CL003.FieldName = "CL003";
            this.CL003.Name = "CL003";
            this.CL003.Visible = true;
            this.CL003.VisibleIndex = 2;
            // 
            // CL004
            // 
            this.CL004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL004.AppearanceCell.Options.UseFont = true;
            this.CL004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL004.AppearanceHeader.Options.UseFont = true;
            this.CL004.Caption = "严重AQL允许数";
            this.CL004.FieldName = "CL004";
            this.CL004.Name = "CL004";
            this.CL004.Visible = true;
            this.CL004.VisibleIndex = 3;
            // 
            // CL005
            // 
            this.CL005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL005.AppearanceCell.Options.UseFont = true;
            this.CL005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL005.AppearanceHeader.Options.UseFont = true;
            this.CL005.Caption = "严重AQL拒收数";
            this.CL005.FieldName = "CL005";
            this.CL005.Name = "CL005";
            this.CL005.Visible = true;
            this.CL005.VisibleIndex = 4;
            // 
            // CL006
            // 
            this.CL006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL006.AppearanceCell.Options.UseFont = true;
            this.CL006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL006.AppearanceHeader.Options.UseFont = true;
            this.CL006.Caption = "轻度AQL允许数";
            this.CL006.FieldName = "CL006";
            this.CL006.Name = "CL006";
            this.CL006.Visible = true;
            this.CL006.VisibleIndex = 5;
            // 
            // CL007
            // 
            this.CL007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CL007.AppearanceCell.Options.UseFont = true;
            this.CL007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CL007.AppearanceHeader.Options.UseFont = true;
            this.CL007.Caption = "轻度AQL拒收数";
            this.CL007.FieldName = "CL007";
            this.CL007.Name = "CL007";
            this.CL007.Visible = true;
            this.CL007.VisibleIndex = 6;
            // 
            // TabPageTwo
            // 
            this.TabPageTwo.Appearance.Header.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageTwo.Appearance.Header.Options.UseFont = true;
            this.TabPageTwo.Controls.Add(this.gridControl2);
            this.TabPageTwo.Name = "TabPageTwo";
            this.TabPageTwo.Size = new System.Drawing.Size(1235, 379);
            this.TabPageTwo.Text = "GB2828标准品质检验抽样方法";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1235, 379);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl2_KeyPress);
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 25;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CM001,
            this.CM002,
            this.CM003,
            this.CM004,
            this.CM005,
            this.CM006,
            this.CM007});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.IndicatorWidth = 35;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView2_CustomDrawRowIndicator);
            // 
            // CM001
            // 
            this.CM001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CM001.AppearanceCell.Options.UseFont = true;
            this.CM001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CM001.AppearanceHeader.Options.UseFont = true;
            this.CM001.Caption = "批量范围头";
            this.CM001.FieldName = "CM001";
            this.CM001.Name = "CM001";
            this.CM001.Visible = true;
            this.CM001.VisibleIndex = 0;
            // 
            // CM002
            // 
            this.CM002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM002.AppearanceCell.Options.UseFont = true;
            this.CM002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM002.AppearanceHeader.Options.UseFont = true;
            this.CM002.Caption = "批量范围尾";
            this.CM002.FieldName = "CM002";
            this.CM002.Name = "CM002";
            this.CM002.Visible = true;
            this.CM002.VisibleIndex = 1;
            // 
            // CM003
            // 
            this.CM003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM003.AppearanceCell.Options.UseFont = true;
            this.CM003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM003.AppearanceHeader.Options.UseFont = true;
            this.CM003.Caption = "抽检数";
            this.CM003.FieldName = "CM003";
            this.CM003.Name = "CM003";
            this.CM003.Visible = true;
            this.CM003.VisibleIndex = 2;
            // 
            // CM004
            // 
            this.CM004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM004.AppearanceCell.Options.UseFont = true;
            this.CM004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM004.AppearanceHeader.Options.UseFont = true;
            this.CM004.Caption = "严重AQL允许数";
            this.CM004.FieldName = "CM004";
            this.CM004.Name = "CM004";
            this.CM004.Visible = true;
            this.CM004.VisibleIndex = 3;
            // 
            // CM005
            // 
            this.CM005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM005.AppearanceCell.Options.UseFont = true;
            this.CM005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM005.AppearanceHeader.Options.UseFont = true;
            this.CM005.Caption = "严重AQL拒收数";
            this.CM005.FieldName = "CM005";
            this.CM005.Name = "CM005";
            this.CM005.Visible = true;
            this.CM005.VisibleIndex = 4;
            // 
            // CM006
            // 
            this.CM006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM006.AppearanceCell.Options.UseFont = true;
            this.CM006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM006.AppearanceHeader.Options.UseFont = true;
            this.CM006.Caption = "轻度AQL允许数";
            this.CM006.FieldName = "CM006";
            this.CM006.Name = "CM006";
            this.CM006.Visible = true;
            this.CM006.VisibleIndex = 5;
            // 
            // CM007
            // 
            this.CM007.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CM007.AppearanceCell.Options.UseFont = true;
            this.CM007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CM007.AppearanceHeader.Options.UseFont = true;
            this.CM007.Caption = "轻度AQL拒收数";
            this.CM007.FieldName = "CM007";
            this.CM007.Name = "CM007";
            this.CM007.Visible = true;
            this.CM007.VisibleIndex = 6;
            // 
            // FormStandardTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 433);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormStandardTest";
            this.Text = "检验标准基础数据(R_043)";
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.TabPageOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.TabPageTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraTab . XtraTabControl xtraTabControl1;
        private DevExpress . XtraTab . XtraTabPage TabPageOne;
        private DevExpress . XtraTab . XtraTabPage TabPageTwo;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CL001;
        private DevExpress . XtraGrid . Columns . GridColumn CL002;
        private DevExpress . XtraGrid . Columns . GridColumn CL003;
        private DevExpress . XtraGrid . Columns . GridColumn CL004;
        private DevExpress . XtraGrid . Columns . GridColumn CL005;
        private DevExpress . XtraGrid . Columns . GridColumn CL006;
        private DevExpress . XtraGrid . Columns . GridColumn CL007;
        private DevExpress . XtraGrid . GridControl gridControl2;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView2;
        private DevExpress . XtraGrid . Columns . GridColumn CM001;
        private DevExpress . XtraGrid . Columns . GridColumn CM002;
        private DevExpress . XtraGrid . Columns . GridColumn CM003;
        private DevExpress . XtraGrid . Columns . GridColumn CM004;
        private DevExpress . XtraGrid . Columns . GridColumn CM005;
        private DevExpress . XtraGrid . Columns . GridColumn CM006;
        private DevExpress . XtraGrid . Columns . GridColumn CM007;
    }
}