namespace SelectAll
{
    partial class FormInvenAdSheetQueryAll
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.INA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INA004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.INA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RES05 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1186, 425);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.INA001,
            this.INA003,
            this.INA004,
            this.INA005,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // INA001
            // 
            this.INA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.INA001.AppearanceCell.Options.UseFont = true;
            this.INA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA001.AppearanceHeader.Options.UseFont = true;
            this.INA001.Caption = "单号";
            this.INA001.FieldName = "INA001";
            this.INA001.Name = "INA001";
            this.INA001.Visible = true;
            this.INA001.VisibleIndex = 0;
            // 
            // INA003
            // 
            this.INA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA003.AppearanceCell.Options.UseFont = true;
            this.INA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA003.AppearanceHeader.Options.UseFont = true;
            this.INA003.Caption = "出入库";
            this.INA003.FieldName = "INA003";
            this.INA003.Name = "INA003";
            this.INA003.Visible = true;
            this.INA003.VisibleIndex = 1;
            // 
            // INA004
            // 
            this.INA004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA004.AppearanceCell.Options.UseFont = true;
            this.INA004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA004.AppearanceHeader.Options.UseFont = true;
            this.INA004.Caption = "日期";
            this.INA004.FieldName = "INA004";
            this.INA004.Name = "INA004";
            this.INA004.Visible = true;
            this.INA004.VisibleIndex = 2;
            // 
            // INA005
            // 
            this.INA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA005.AppearanceCell.Options.UseFont = true;
            this.INA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.INA005.AppearanceHeader.Options.UseFont = true;
            this.INA005.Caption = "操作人";
            this.INA005.FieldName = "INA005";
            this.INA005.Name = "INA005";
            this.INA005.Visible = true;
            this.INA005.VisibleIndex = 3;
            // 
            // RES05
            // 
            this.RES05.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RES05.AppearanceCell.Options.UseFont = true;
            this.RES05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RES05.AppearanceHeader.Options.UseFont = true;
            this.RES05.Caption = "执行";
            this.RES05.FieldName = "RES05";
            this.RES05.Name = "RES05";
            this.RES05.Visible = true;
            this.RES05.VisibleIndex = 4;
            // 
            // FormInvenAdSheetQueryAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 425);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormInvenAdSheetQueryAll";
            this.Text = "查询";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn INA001;
        private DevExpress . XtraGrid . Columns . GridColumn INA003;
        private DevExpress . XtraGrid . Columns . GridColumn INA004;
        private DevExpress . XtraGrid . Columns . GridColumn INA005;
        private DevExpress . XtraGrid . Columns . GridColumn RES05;
    }
}