namespace SelectAll
{
    partial class FromSanitationCheckQuery
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
            this.SAC001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SAC003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SAC004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SAC002 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1122, 476);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SAC001,
            this.SAC002,
            this.SAC003,
            this.SAC004});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // SAC001
            // 
            this.SAC001.Caption = "单号";
            this.SAC001.FieldName = "SAC001";
            this.SAC001.Name = "SAC001";
            this.SAC001.Visible = true;
            this.SAC001.VisibleIndex = 0;
            // 
            // SAC003
            // 
            this.SAC003.Caption = "开始日期";
            this.SAC003.FieldName = "SAC003";
            this.SAC003.Name = "SAC003";
            this.SAC003.Visible = true;
            this.SAC003.VisibleIndex = 2;
            // 
            // SAC004
            // 
            this.SAC004.Caption = "结束日期";
            this.SAC004.FieldName = "SAC004";
            this.SAC004.Name = "SAC004";
            this.SAC004.Visible = true;
            this.SAC004.VisibleIndex = 3;
            // 
            // SAC002
            // 
            this.SAC002.Caption = "检查人";
            this.SAC002.FieldName = "SAC002";
            this.SAC002.Name = "SAC002";
            this.SAC002.Visible = true;
            this.SAC002.VisibleIndex = 1;
            // 
            // FromSanitationCheckQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 476);
            this.Controls.Add(this.gridControl1);
            this.Name = "FromSanitationCheckQuery";
            this.Text = "生产部环境卫生、安全检查汇总对比表(R_004)";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn SAC001;
        private DevExpress . XtraGrid . Columns . GridColumn SAC002;
        private DevExpress . XtraGrid . Columns . GridColumn SAC003;
        private DevExpress . XtraGrid . Columns . GridColumn SAC004;
    }
}