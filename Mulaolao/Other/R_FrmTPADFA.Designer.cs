namespace Mulaolao.Other
{
    partial class R_FrmTPADFA
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
            this.PQF02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DFA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DFA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DFA015 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DFA016 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1254, 261);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PQF02,
            this.DFA001,
            this.DFA003,
            this.DFA015,
            this.DFA016});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // PQF02
            // 
            this.PQF02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQF02.AppearanceCell.Options.UseFont = true;
            this.PQF02.AppearanceCell.Options.UseTextOptions = true;
            this.PQF02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PQF02.AppearanceHeader.Options.UseFont = true;
            this.PQF02.AppearanceHeader.Options.UseTextOptions = true;
            this.PQF02.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PQF02.Caption = "合同号";
            this.PQF02.FieldName = "PQF02";
            this.PQF02.Name = "PQF02";
            this.PQF02.Visible = true;
            this.PQF02.VisibleIndex = 0;
            // 
            // DFA001
            // 
            this.DFA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA001.AppearanceCell.Options.UseFont = true;
            this.DFA001.AppearanceCell.Options.UseTextOptions = true;
            this.DFA001.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA001.AppearanceHeader.Options.UseFont = true;
            this.DFA001.AppearanceHeader.Options.UseTextOptions = true;
            this.DFA001.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA001.Caption = "客户编号";
            this.DFA001.FieldName = "DFA001";
            this.DFA001.Name = "DFA001";
            this.DFA001.Visible = true;
            this.DFA001.VisibleIndex = 1;
            // 
            // DFA003
            // 
            this.DFA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA003.AppearanceCell.Options.UseFont = true;
            this.DFA003.AppearanceCell.Options.UseTextOptions = true;
            this.DFA003.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA003.AppearanceHeader.Options.UseFont = true;
            this.DFA003.AppearanceHeader.Options.UseTextOptions = true;
            this.DFA003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA003.Caption = "客户名称";
            this.DFA003.FieldName = "DFA003";
            this.DFA003.Name = "DFA003";
            this.DFA003.Visible = true;
            this.DFA003.VisibleIndex = 2;
            // 
            // DFA015
            // 
            this.DFA015.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA015.AppearanceCell.Options.UseFont = true;
            this.DFA015.AppearanceCell.Options.UseTextOptions = true;
            this.DFA015.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA015.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA015.AppearanceHeader.Options.UseFont = true;
            this.DFA015.AppearanceHeader.Options.UseTextOptions = true;
            this.DFA015.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA015.Caption = "联系人";
            this.DFA015.FieldName = "DFA015";
            this.DFA015.Name = "DFA015";
            this.DFA015.Visible = true;
            this.DFA015.VisibleIndex = 3;
            // 
            // DFA016
            // 
            this.DFA016.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA016.AppearanceCell.Options.UseFont = true;
            this.DFA016.AppearanceCell.Options.UseTextOptions = true;
            this.DFA016.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFA016.AppearanceHeader.Options.UseFont = true;
            this.DFA016.AppearanceHeader.Options.UseTextOptions = true;
            this.DFA016.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DFA016.Caption = "联系电话";
            this.DFA016.FieldName = "DFA016";
            this.DFA016.Name = "DFA016";
            this.DFA016.Visible = true;
            this.DFA016.VisibleIndex = 4;
            // 
            // R_FrmTPADFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 261);
            this.Controls.Add(this.gridControl1);
            this.Name = "R_FrmTPADFA";
            this.Text = "客户查询";
            this.Load += new System.EventHandler(this.R_FrmTPADFA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DFA001;
        private DevExpress.XtraGrid.Columns.GridColumn DFA003;
        private DevExpress.XtraGrid.Columns.GridColumn DFA015;
        private DevExpress.XtraGrid.Columns.GridColumn DFA016;
        private DevExpress.XtraGrid.Columns.GridColumn PQF02;
    }
}