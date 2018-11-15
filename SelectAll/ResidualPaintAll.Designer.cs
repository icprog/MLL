namespace SelectAll
{
    partial class ResidualPaintAll
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
            this.AI001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1237, 406);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AI001,
            this.AI002,
            this.AI011,
            this.AI003,
            this.AI004,
            this.AI005,
            this.AI006,
            this.AI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // AI001
            // 
            this.AI001.Caption = "单号";
            this.AI001.FieldName = "AI001";
            this.AI001.Name = "AI001";
            // 
            // AI002
            // 
            this.AI002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI002.AppearanceCell.Options.UseFont = true;
            this.AI002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI002.AppearanceHeader.Options.UseFont = true;
            this.AI002.Caption = "流水号";
            this.AI002.FieldName = "AI002";
            this.AI002.Name = "AI002";
            this.AI002.Visible = true;
            this.AI002.VisibleIndex = 0;
            this.AI002.Width = 154;
            // 
            // AI011
            // 
            this.AI011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI011.AppearanceCell.Options.UseFont = true;
            this.AI011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI011.AppearanceHeader.Options.UseFont = true;
            this.AI011.Caption = "零件名称";
            this.AI011.FieldName = "AI011";
            this.AI011.Name = "AI011";
            this.AI011.Visible = true;
            this.AI011.VisibleIndex = 1;
            this.AI011.Width = 154;
            // 
            // AI003
            // 
            this.AI003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI003.AppearanceCell.Options.UseFont = true;
            this.AI003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI003.AppearanceHeader.Options.UseFont = true;
            this.AI003.Caption = "工序";
            this.AI003.FieldName = "AI003";
            this.AI003.Name = "AI003";
            this.AI003.Visible = true;
            this.AI003.VisibleIndex = 2;
            this.AI003.Width = 135;
            // 
            // AI004
            // 
            this.AI004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI004.AppearanceCell.Options.UseFont = true;
            this.AI004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI004.AppearanceHeader.Options.UseFont = true;
            this.AI004.Caption = "色号.按色号与色板间";
            this.AI004.FieldName = "AI004";
            this.AI004.Name = "AI004";
            this.AI004.Visible = true;
            this.AI004.VisibleIndex = 3;
            this.AI004.Width = 194;
            // 
            // AI005
            // 
            this.AI005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI005.AppearanceCell.Options.UseFont = true;
            this.AI005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI005.AppearanceHeader.Options.UseFont = true;
            this.AI005.Caption = "供方批号";
            this.AI005.FieldName = "AI005";
            this.AI005.Name = "AI005";
            this.AI005.Visible = true;
            this.AI005.VisibleIndex = 4;
            this.AI005.Width = 143;
            // 
            // AI006
            // 
            this.AI006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI006.AppearanceCell.Options.UseFont = true;
            this.AI006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI006.AppearanceHeader.Options.UseFont = true;
            this.AI006.Caption = "生产批号";
            this.AI006.FieldName = "AI006";
            this.AI006.Name = "AI006";
            this.AI006.Visible = true;
            this.AI006.VisibleIndex = 5;
            this.AI006.Width = 143;
            // 
            // AI
            // 
            this.AI.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI.AppearanceCell.Options.UseFont = true;
            this.AI.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AI.AppearanceHeader.Options.UseFont = true;
            this.AI.Caption = "剩余库存量";
            this.AI.FieldName = "AI";
            this.AI.Name = "AI";
            this.AI.Visible = true;
            this.AI.VisibleIndex = 6;
            this.AI.Width = 155;
            // 
            // ResidualPaintAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 406);
            this.Controls.Add(this.gridControl1);
            this.Name = "ResidualPaintAll";
            this.Text = "R_525剩余库存";
            this.Load += new System.EventHandler(this.ResidualPaintAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AI001;
        private DevExpress.XtraGrid.Columns.GridColumn AI002;
        private DevExpress.XtraGrid.Columns.GridColumn AI011;
        private DevExpress.XtraGrid.Columns.GridColumn AI003;
        private DevExpress.XtraGrid.Columns.GridColumn AI004;
        private DevExpress.XtraGrid.Columns.GridColumn AI005;
        private DevExpress.XtraGrid.Columns.GridColumn AI006;
        private DevExpress.XtraGrid.Columns.GridColumn AI;
    }
}