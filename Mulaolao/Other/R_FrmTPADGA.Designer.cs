namespace Mulaolao.Bom
{
    partial class R_FrmTPADGA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
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
        private void InitializeComponent( )
        {
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DGA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA012 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGA011 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(974, 261);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 30;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DGA001,
            this.DGA003,
            this.DGA017,
            this.DGA008,
            this.DGA012,
            this.DGA009,
            this.DGA011});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowHeight = 30;
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // DGA001
            // 
            this.DGA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA001.AppearanceCell.Options.UseFont = true;
            this.DGA001.AppearanceCell.Options.UseTextOptions = true;
            this.DGA001.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA001.AppearanceHeader.Options.UseFont = true;
            this.DGA001.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA001.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA001.Caption = "供应商编号";
            this.DGA001.FieldName = "DGA001";
            this.DGA001.Name = "DGA001";
            this.DGA001.Visible = true;
            this.DGA001.VisibleIndex = 0;
            // 
            // DGA003
            // 
            this.DGA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA003.AppearanceCell.Options.UseFont = true;
            this.DGA003.AppearanceCell.Options.UseTextOptions = true;
            this.DGA003.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA003.AppearanceHeader.Options.UseFont = true;
            this.DGA003.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA003.Caption = "供应商名称";
            this.DGA003.FieldName = "DGA003";
            this.DGA003.Name = "DGA003";
            this.DGA003.Visible = true;
            this.DGA003.VisibleIndex = 1;
            // 
            // DGA017
            // 
            this.DGA017.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA017.AppearanceCell.Options.UseFont = true;
            this.DGA017.AppearanceCell.Options.UseTextOptions = true;
            this.DGA017.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA017.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA017.AppearanceHeader.Options.UseFont = true;
            this.DGA017.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA017.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA017.Caption = "地址";
            this.DGA017.FieldName = "DGA017";
            this.DGA017.Name = "DGA017";
            this.DGA017.Visible = true;
            this.DGA017.VisibleIndex = 2;
            // 
            // DGA008
            // 
            this.DGA008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA008.AppearanceCell.Options.UseFont = true;
            this.DGA008.AppearanceCell.Options.UseTextOptions = true;
            this.DGA008.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA008.AppearanceHeader.Options.UseFont = true;
            this.DGA008.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA008.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA008.Caption = "法人";
            this.DGA008.FieldName = "DGA008";
            this.DGA008.Name = "DGA008";
            this.DGA008.Visible = true;
            this.DGA008.VisibleIndex = 3;
            // 
            // DGA012
            // 
            this.DGA012.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA012.AppearanceCell.Options.UseFont = true;
            this.DGA012.AppearanceCell.Options.UseTextOptions = true;
            this.DGA012.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA012.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA012.AppearanceHeader.Options.UseFont = true;
            this.DGA012.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA012.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA012.Caption = "法人电话";
            this.DGA012.FieldName = "DGA012";
            this.DGA012.Name = "DGA012";
            this.DGA012.Visible = true;
            this.DGA012.VisibleIndex = 4;
            // 
            // DGA009
            // 
            this.DGA009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA009.AppearanceCell.Options.UseFont = true;
            this.DGA009.AppearanceCell.Options.UseTextOptions = true;
            this.DGA009.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA009.AppearanceHeader.Options.UseFont = true;
            this.DGA009.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA009.Caption = "联系人";
            this.DGA009.FieldName = "DGA009";
            this.DGA009.Name = "DGA009";
            this.DGA009.Visible = true;
            this.DGA009.VisibleIndex = 5;
            // 
            // DGA011
            // 
            this.DGA011.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA011.AppearanceCell.Options.UseFont = true;
            this.DGA011.AppearanceCell.Options.UseTextOptions = true;
            this.DGA011.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGA011.AppearanceHeader.Options.UseFont = true;
            this.DGA011.AppearanceHeader.Options.UseTextOptions = true;
            this.DGA011.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DGA011.Caption = "联系电话";
            this.DGA011.FieldName = "DGA011";
            this.DGA011.Name = "DGA011";
            this.DGA011.Visible = true;
            this.DGA011.VisibleIndex = 6;
            // 
            // R_FrmTPADGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 261);
            this.Controls.Add(this.gridControl2);
            this.Name = "R_FrmTPADGA";
            this.Text = "供应商信息";
            this.Load += new System.EventHandler(this.R_FrmTPADGA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl2;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        public DevExpress.XtraGrid.Columns.GridColumn DGA001;
        public DevExpress.XtraGrid.Columns.GridColumn DGA003;
        public DevExpress.XtraGrid.Columns.GridColumn DGA009;
        public DevExpress.XtraGrid.Columns.GridColumn DGA011;
        private DevExpress.XtraGrid.Columns.GridColumn DGA017;
        private DevExpress.XtraGrid.Columns.GridColumn DGA008;
        private DevExpress.XtraGrid.Columns.GridColumn DGA012;
    }
}