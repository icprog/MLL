namespace Mulaolao.Contract
{
    partial class R_Frmpenselect
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
                components.Dispose();
            }
            base.Dispose(disposing);
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
            this.PY33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PY06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PY27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YQ06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YQ12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YQ107 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.YQ03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RES05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.DBA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1260, 419);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.PY33,
            this.PQF01,
            this.PQF02,
            this.PQF03,
            this.PQF04,
            this.PQF06,
            this.PY06,
            this.PY27,
            this.YQ06,
            this.PQF31,
            this.YQ12,
            this.YQ107,
            this.YQ03,
            this.DBA002,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceCell.Options.UseTextOptions = true;
            this.check.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.AppearanceHeader.Options.UseTextOptions = true;
            this.check.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // PY33
            // 
            this.PY33.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY33.AppearanceCell.Options.UseFont = true;
            this.PY33.AppearanceCell.Options.UseTextOptions = true;
            this.PY33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY33.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY33.AppearanceHeader.Options.UseFont = true;
            this.PY33.AppearanceHeader.Options.UseTextOptions = true;
            this.PY33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY33.Caption = "单号";
            this.PY33.FieldName = "PY33";
            this.PY33.Name = "PY33";
            this.PY33.Visible = true;
            this.PY33.VisibleIndex = 1;
            this.PY33.Width = 107;
            // 
            // PQF01
            // 
            this.PQF01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceCell.Options.UseFont = true;
            this.PQF01.AppearanceCell.Options.UseTextOptions = true;
            this.PQF01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceHeader.Options.UseFont = true;
            this.PQF01.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF01.Caption = "流水号";
            this.PQF01.FieldName = "PQF01";
            this.PQF01.Name = "PQF01";
            this.PQF01.Visible = true;
            this.PQF01.VisibleIndex = 2;
            this.PQF01.Width = 107;
            // 
            // PQF02
            // 
            this.PQF02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceCell.Options.UseFont = true;
            this.PQF02.AppearanceCell.Options.UseTextOptions = true;
            this.PQF02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceHeader.Options.UseFont = true;
            this.PQF02.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF02.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.Caption = "合同号";
            this.PQF02.FieldName = "PQF02";
            this.PQF02.Name = "PQF02";
            this.PQF02.Visible = true;
            this.PQF02.VisibleIndex = 6;
            this.PQF02.Width = 107;
            // 
            // PQF03
            // 
            this.PQF03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceCell.Options.UseFont = true;
            this.PQF03.AppearanceCell.Options.UseTextOptions = true;
            this.PQF03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceHeader.Options.UseFont = true;
            this.PQF03.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF03.Caption = "货号";
            this.PQF03.FieldName = "PQF03";
            this.PQF03.Name = "PQF03";
            this.PQF03.Visible = true;
            this.PQF03.VisibleIndex = 8;
            this.PQF03.Width = 107;
            // 
            // PQF04
            // 
            this.PQF04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceCell.Options.UseFont = true;
            this.PQF04.AppearanceCell.Options.UseTextOptions = true;
            this.PQF04.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceHeader.Options.UseFont = true;
            this.PQF04.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF04.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF04.Caption = "产品名称";
            this.PQF04.FieldName = "PQF04";
            this.PQF04.Name = "PQF04";
            this.PQF04.Visible = true;
            this.PQF04.VisibleIndex = 4;
            this.PQF04.Width = 107;
            // 
            // PQF06
            // 
            this.PQF06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceCell.Options.UseFont = true;
            this.PQF06.AppearanceCell.Options.UseTextOptions = true;
            this.PQF06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceHeader.Options.UseFont = true;
            this.PQF06.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF06.Caption = "产品数量";
            this.PQF06.FieldName = "PQF06";
            this.PQF06.Name = "PQF06";
            this.PQF06.Visible = true;
            this.PQF06.VisibleIndex = 10;
            this.PQF06.Width = 107;
            // 
            // PY06
            // 
            this.PY06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY06.AppearanceCell.Options.UseFont = true;
            this.PY06.AppearanceCell.Options.UseTextOptions = true;
            this.PY06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY06.AppearanceHeader.Options.UseFont = true;
            this.PY06.AppearanceHeader.Options.UseTextOptions = true;
            this.PY06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY06.Caption = "开合同人";
            this.PY06.FieldName = "PY06";
            this.PY06.Name = "PY06";
            this.PY06.Visible = true;
            this.PY06.VisibleIndex = 12;
            this.PY06.Width = 107;
            // 
            // PY27
            // 
            this.PY27.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY27.AppearanceCell.Options.UseFont = true;
            this.PY27.AppearanceCell.Options.UseTextOptions = true;
            this.PY27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY27.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PY27.AppearanceHeader.Options.UseFont = true;
            this.PY27.AppearanceHeader.Options.UseTextOptions = true;
            this.PY27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PY27.Caption = "产品数量";
            this.PY27.FieldName = "PY27";
            this.PY27.Name = "PY27";
            this.PY27.Visible = true;
            this.PY27.VisibleIndex = 11;
            this.PY27.Width = 107;
            // 
            // YQ06
            // 
            this.YQ06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ06.AppearanceCell.Options.UseFont = true;
            this.YQ06.AppearanceCell.Options.UseTextOptions = true;
            this.YQ06.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ06.AppearanceHeader.Options.UseFont = true;
            this.YQ06.AppearanceHeader.Options.UseTextOptions = true;
            this.YQ06.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ06.Caption = "产品品牌";
            this.YQ06.FieldName = "YQ06";
            this.YQ06.Name = "YQ06";
            this.YQ06.Visible = true;
            this.YQ06.VisibleIndex = 13;
            this.YQ06.Width = 103;
            // 
            // PQF31
            // 
            this.PQF31.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF31.AppearanceCell.Options.UseFont = true;
            this.PQF31.AppearanceCell.Options.UseTextOptions = true;
            this.PQF31.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF31.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF31.AppearanceHeader.Options.UseFont = true;
            this.PQF31.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF31.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF31.Caption = "合同交货日期";
            this.PQF31.DisplayFormat.FormatString = "d";
            this.PQF31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.PQF31.FieldName = "PQF31";
            this.PQF31.Name = "PQF31";
            this.PQF31.Visible = true;
            this.PQF31.VisibleIndex = 7;
            this.PQF31.Width = 119;
            // 
            // YQ12
            // 
            this.YQ12.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ12.AppearanceCell.Options.UseFont = true;
            this.YQ12.AppearanceCell.Options.UseTextOptions = true;
            this.YQ12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ12.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ12.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ12.AppearanceHeader.Options.UseFont = true;
            this.YQ12.AppearanceHeader.Options.UseTextOptions = true;
            this.YQ12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ12.Caption = "产品名称";
            this.YQ12.FieldName = "YQ12";
            this.YQ12.Name = "YQ12";
            this.YQ12.Visible = true;
            this.YQ12.VisibleIndex = 5;
            // 
            // YQ107
            // 
            this.YQ107.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ107.AppearanceCell.Options.UseFont = true;
            this.YQ107.AppearanceCell.Options.UseTextOptions = true;
            this.YQ107.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ107.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ107.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ107.AppearanceHeader.Options.UseFont = true;
            this.YQ107.AppearanceHeader.Options.UseTextOptions = true;
            this.YQ107.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ107.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ107.Caption = "货号";
            this.YQ107.FieldName = "YQ107";
            this.YQ107.Name = "YQ107";
            this.YQ107.Visible = true;
            this.YQ107.VisibleIndex = 9;
            // 
            // YQ03
            // 
            this.YQ03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ03.AppearanceCell.Options.UseFont = true;
            this.YQ03.AppearanceCell.Options.UseTextOptions = true;
            this.YQ03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ03.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.YQ03.AppearanceHeader.Options.UseFont = true;
            this.YQ03.AppearanceHeader.Options.UseTextOptions = true;
            this.YQ03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.YQ03.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.YQ03.Caption = "流水号";
            this.YQ03.FieldName = "YQ03";
            this.YQ03.Name = "YQ03";
            this.YQ03.Visible = true;
            this.YQ03.VisibleIndex = 3;
            // 
            // RES05
            // 
            this.RES05.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceCell.Options.UseFont = true;
            this.RES05.AppearanceCell.Options.UseTextOptions = true;
            this.RES05.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RES05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceHeader.Options.UseFont = true;
            this.RES05.AppearanceHeader.Options.UseTextOptions = true;
            this.RES05.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RES05.Caption = "单据状态";
            this.RES05.FieldName = "RES05";
            this.RES05.Name = "RES05";
            this.RES05.Visible = true;
            this.RES05.VisibleIndex = 15;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // DBA002
            // 
            this.DBA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DBA002.AppearanceCell.Options.UseFont = true;
            this.DBA002.AppearanceCell.Options.UseTextOptions = true;
            this.DBA002.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DBA002.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DBA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DBA002.AppearanceHeader.Options.UseFont = true;
            this.DBA002.AppearanceHeader.Options.UseTextOptions = true;
            this.DBA002.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DBA002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.DBA002.Caption = "业务员";
            this.DBA002.FieldName = "DBA002";
            this.DBA002.Name = "DBA002";
            this.DBA002.Visible = true;
            this.DBA002.VisibleIndex = 14;
            // 
            // R_Frmpenselect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 419);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "R_Frmpenselect";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.R_Frmpenselect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraGrid.Columns.GridColumn PQF01;
        public DevExpress.XtraGrid.Columns.GridColumn PQF02;
        public DevExpress.XtraGrid.Columns.GridColumn PQF03;
        public DevExpress.XtraGrid.Columns.GridColumn PQF04;
        public DevExpress.XtraGrid.Columns.GridColumn PQF06;
        public DevExpress.XtraGrid.Columns.GridColumn PY06;
        private DevExpress.XtraGrid.Columns.GridColumn PY33;
        private DevExpress.XtraGrid.Columns.GridColumn PY27;
        private DevExpress.XtraGrid.Columns.GridColumn YQ06;
        private DevExpress.XtraGrid.Columns.GridColumn PQF31;
        private DevExpress.XtraGrid.Columns.GridColumn RES05;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn YQ12;
        private DevExpress.XtraGrid.Columns.GridColumn YQ107;
        private DevExpress.XtraGrid.Columns.GridColumn YQ03;
        private DevExpress.XtraGrid.Columns.GridColumn DBA002;
    }
}