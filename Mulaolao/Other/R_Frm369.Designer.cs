namespace Mulaolao.Base
{
    partial class R_Frm369
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.KH24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CP001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF08 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
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
            this.gridControl1.Size = new System.Drawing.Size(1240, 469);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.KH24,
            this.KH01,
            this.KH49,
            this.KH50,
            this.PQF04,
            this.CP001,
            this.PQF01,
            this.PQF02,
            this.PQF03,
            this.PQF06,
            this.PQF07,
            this.PQF08});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceCell.Options.UseTextOptions = true;
            this.check.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.check.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
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
            this.check.Width = 63;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // KH24
            // 
            this.KH24.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH24.AppearanceCell.Options.UseFont = true;
            this.KH24.AppearanceCell.Options.UseTextOptions = true;
            this.KH24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH24.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH24.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH24.AppearanceHeader.Options.UseFont = true;
            this.KH24.AppearanceHeader.Options.UseTextOptions = true;
            this.KH24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH24.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH24.Caption = "合同号";
            this.KH24.FieldName = "KH24";
            this.KH24.Name = "KH24";
            this.KH24.Visible = true;
            this.KH24.VisibleIndex = 1;
            this.KH24.Width = 83;
            // 
            // KH01
            // 
            this.KH01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH01.AppearanceCell.Options.UseFont = true;
            this.KH01.AppearanceCell.Options.UseTextOptions = true;
            this.KH01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH01.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH01.AppearanceHeader.Options.UseFont = true;
            this.KH01.AppearanceHeader.Options.UseTextOptions = true;
            this.KH01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH01.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH01.Caption = "样品名称";
            this.KH01.FieldName = "KH01";
            this.KH01.Name = "KH01";
            this.KH01.Visible = true;
            this.KH01.VisibleIndex = 2;
            this.KH01.Width = 83;
            // 
            // KH49
            // 
            this.KH49.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH49.AppearanceCell.Options.UseFont = true;
            this.KH49.AppearanceCell.Options.UseTextOptions = true;
            this.KH49.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH49.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH49.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH49.AppearanceHeader.Options.UseFont = true;
            this.KH49.AppearanceHeader.Options.UseTextOptions = true;
            this.KH49.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH49.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH49.Caption = "客户名称";
            this.KH49.FieldName = "KH49";
            this.KH49.Name = "KH49";
            this.KH49.Visible = true;
            this.KH49.VisibleIndex = 3;
            this.KH49.Width = 83;
            // 
            // KH50
            // 
            this.KH50.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH50.AppearanceCell.Options.UseFont = true;
            this.KH50.AppearanceCell.Options.UseTextOptions = true;
            this.KH50.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH50.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH50.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.KH50.AppearanceHeader.Options.UseFont = true;
            this.KH50.AppearanceHeader.Options.UseTextOptions = true;
            this.KH50.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.KH50.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.KH50.Caption = "业务员";
            this.KH50.FieldName = "KH50";
            this.KH50.Name = "KH50";
            this.KH50.Visible = true;
            this.KH50.VisibleIndex = 4;
            this.KH50.Width = 83;
            // 
            // PQF04
            // 
            this.PQF04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceCell.Options.UseFont = true;
            this.PQF04.AppearanceCell.Options.UseTextOptions = true;
            this.PQF04.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF04.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceHeader.Options.UseFont = true;
            this.PQF04.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF04.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF04.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF04.Caption = "产品名称";
            this.PQF04.FieldName = "PQF04";
            this.PQF04.Name = "PQF04";
            this.PQF04.Visible = true;
            this.PQF04.VisibleIndex = 6;
            this.PQF04.Width = 83;
            // 
            // CP001
            // 
            this.CP001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.CP001.AppearanceCell.Options.UseFont = true;
            this.CP001.AppearanceCell.Options.UseTextOptions = true;
            this.CP001.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CP001.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CP001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.CP001.AppearanceHeader.Options.UseFont = true;
            this.CP001.AppearanceHeader.Options.UseTextOptions = true;
            this.CP001.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CP001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.CP001.Caption = "流水号";
            this.CP001.FieldName = "CP001";
            this.CP001.Name = "CP001";
            this.CP001.Visible = true;
            this.CP001.VisibleIndex = 5;
            this.CP001.Width = 83;
            // 
            // PQF01
            // 
            this.PQF01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceCell.Options.UseFont = true;
            this.PQF01.AppearanceCell.Options.UseTextOptions = true;
            this.PQF01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF01.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceHeader.Options.UseFont = true;
            this.PQF01.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF01.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF01.Caption = "流水号";
            this.PQF01.FieldName = "PQF01";
            this.PQF01.Name = "PQF01";
            this.PQF01.Visible = true;
            this.PQF01.VisibleIndex = 7;
            this.PQF01.Width = 83;
            // 
            // PQF02
            // 
            this.PQF02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceCell.Options.UseFont = true;
            this.PQF02.AppearanceCell.Options.UseTextOptions = true;
            this.PQF02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceHeader.Options.UseFont = true;
            this.PQF02.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF02.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF02.Caption = "合同号";
            this.PQF02.FieldName = "PQF02";
            this.PQF02.Name = "PQF02";
            this.PQF02.Visible = true;
            this.PQF02.VisibleIndex = 8;
            this.PQF02.Width = 83;
            // 
            // PQF03
            // 
            this.PQF03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceCell.Options.UseFont = true;
            this.PQF03.AppearanceCell.Options.UseTextOptions = true;
            this.PQF03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF03.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceHeader.Options.UseFont = true;
            this.PQF03.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF03.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF03.Caption = "货号";
            this.PQF03.FieldName = "PQF03";
            this.PQF03.Name = "PQF03";
            this.PQF03.Visible = true;
            this.PQF03.VisibleIndex = 9;
            this.PQF03.Width = 83;
            // 
            // PQF06
            // 
            this.PQF06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceCell.Options.UseFont = true;
            this.PQF06.AppearanceCell.Options.UseTextOptions = true;
            this.PQF06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF06.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceHeader.Options.UseFont = true;
            this.PQF06.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF06.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF06.Caption = "产品数量";
            this.PQF06.FieldName = "PQF06";
            this.PQF06.Name = "PQF06";
            this.PQF06.Visible = true;
            this.PQF06.VisibleIndex = 10;
            this.PQF06.Width = 83;
            // 
            // PQF07
            // 
            this.PQF07.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF07.AppearanceCell.Options.UseFont = true;
            this.PQF07.AppearanceCell.Options.UseTextOptions = true;
            this.PQF07.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF07.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF07.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF07.AppearanceHeader.Options.UseFont = true;
            this.PQF07.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF07.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF07.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF07.Caption = "输入国";
            this.PQF07.FieldName = "PQF07";
            this.PQF07.Name = "PQF07";
            this.PQF07.Visible = true;
            this.PQF07.VisibleIndex = 11;
            this.PQF07.Width = 83;
            // 
            // PQF08
            // 
            this.PQF08.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF08.AppearanceCell.Options.UseFont = true;
            this.PQF08.AppearanceCell.Options.UseTextOptions = true;
            this.PQF08.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF08.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF08.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF08.AppearanceHeader.Options.UseFont = true;
            this.PQF08.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF08.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF08.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.PQF08.Caption = "年龄段";
            this.PQF08.FieldName = "PQF08";
            this.PQF08.Name = "PQF08";
            this.PQF08.Visible = true;
            this.PQF08.VisibleIndex = 12;
            this.PQF08.Width = 102;
            // 
            // R_Frm369
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 469);
            this.Controls.Add(this.gridControl1);
            this.Name = "R_Frm369";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.R_Frm369_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn KH24;
        private DevExpress.XtraGrid.Columns.GridColumn KH01;
        private DevExpress.XtraGrid.Columns.GridColumn KH49;
        private DevExpress.XtraGrid.Columns.GridColumn KH50;
        private DevExpress.XtraGrid.Columns.GridColumn PQF04;
        private DevExpress.XtraGrid.Columns.GridColumn CP001;
        private DevExpress.XtraGrid.Columns.GridColumn PQF01;
        private DevExpress.XtraGrid.Columns.GridColumn PQF02;
        private DevExpress.XtraGrid.Columns.GridColumn PQF03;
        private DevExpress.XtraGrid.Columns.GridColumn PQF06;
        private DevExpress.XtraGrid.Columns.GridColumn PQF07;
        private DevExpress.XtraGrid.Columns.GridColumn PQF08;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}