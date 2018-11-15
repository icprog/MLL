namespace SelectAll
{
    partial class ContractUncollectUnpaidAll
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
            this.AE01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AE03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AE04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AE05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AE06 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1201, 419);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AE01,
            this.AE03,
            this.AE04,
            this.AE05,
            this.AE06});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 20;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // AE01
            // 
            this.AE01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE01.AppearanceCell.Options.UseFont = true;
            this.AE01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE01.AppearanceHeader.Options.UseFont = true;
            this.AE01.AppearanceHeader.Options.UseTextOptions = true;
            this.AE01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AE01.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AE01.Caption = "流水号";
            this.AE01.FieldName = "AE01";
            this.AE01.Name = "AE01";
            this.AE01.Visible = true;
            this.AE01.VisibleIndex = 0;
            // 
            // AE03
            // 
            this.AE03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE03.AppearanceCell.Options.UseFont = true;
            this.AE03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE03.AppearanceHeader.Options.UseFont = true;
            this.AE03.AppearanceHeader.Options.UseTextOptions = true;
            this.AE03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AE03.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AE03.Caption = "产品名称";
            this.AE03.FieldName = "AE03";
            this.AE03.Name = "AE03";
            this.AE03.Visible = true;
            this.AE03.VisibleIndex = 1;
            // 
            // AE04
            // 
            this.AE04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE04.AppearanceCell.Options.UseFont = true;
            this.AE04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE04.AppearanceHeader.Options.UseFont = true;
            this.AE04.AppearanceHeader.Options.UseTextOptions = true;
            this.AE04.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AE04.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AE04.Caption = "合同号";
            this.AE04.FieldName = "AE04";
            this.AE04.Name = "AE04";
            this.AE04.Visible = true;
            this.AE04.VisibleIndex = 2;
            // 
            // AE05
            // 
            this.AE05.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE05.AppearanceCell.Options.UseFont = true;
            this.AE05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE05.AppearanceHeader.Options.UseFont = true;
            this.AE05.AppearanceHeader.Options.UseTextOptions = true;
            this.AE05.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AE05.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AE05.Caption = "货号";
            this.AE05.FieldName = "AE05";
            this.AE05.Name = "AE05";
            this.AE05.Visible = true;
            this.AE05.VisibleIndex = 3;
            // 
            // AE06
            // 
            this.AE06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE06.AppearanceCell.Options.UseFont = true;
            this.AE06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AE06.AppearanceHeader.Options.UseFont = true;
            this.AE06.AppearanceHeader.Options.UseTextOptions = true;
            this.AE06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AE06.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AE06.Caption = "产品数量";
            this.AE06.FieldName = "AE06";
            this.AE06.Name = "AE06";
            this.AE06.Visible = true;
            this.AE06.VisibleIndex = 4;
            // 
            // ContractUncollectUnpaidAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 419);
            this.Controls.Add(this.gridControl1);
            this.Name = "ContractUncollectUnpaidAll";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.ContractUncollectUnpaidAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AE01;
        private DevExpress.XtraGrid.Columns.GridColumn AE03;
        private DevExpress.XtraGrid.Columns.GridColumn AE04;
        private DevExpress.XtraGrid.Columns.GridColumn AE05;
        private DevExpress.XtraGrid.Columns.GridColumn AE06;
    }
}