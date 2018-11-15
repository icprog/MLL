namespace SelectAll
{
    partial class WaiXianNumAll
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
            this.WX82 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WX83 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WX01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WX85 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WX84 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1198, 416);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BestFitMaxRowCount = 35;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WX82,
            this.WX83,
            this.WX01,
            this.WX85,
            this.WX84,
            this.U1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 25;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // WX82
            // 
            this.WX82.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX82.AppearanceCell.Options.UseFont = true;
            this.WX82.AppearanceCell.Options.UseTextOptions = true;
            this.WX82.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX82.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX82.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX82.AppearanceHeader.Options.UseFont = true;
            this.WX82.AppearanceHeader.Options.UseTextOptions = true;
            this.WX82.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX82.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX82.Caption = "单号";
            this.WX82.FieldName = "WX82";
            this.WX82.Name = "WX82";
            this.WX82.Visible = true;
            this.WX82.VisibleIndex = 0;
            // 
            // WX83
            // 
            this.WX83.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX83.AppearanceCell.Options.UseFont = true;
            this.WX83.AppearanceCell.Options.UseTextOptions = true;
            this.WX83.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX83.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX83.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX83.AppearanceHeader.Options.UseFont = true;
            this.WX83.AppearanceHeader.Options.UseTextOptions = true;
            this.WX83.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX83.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX83.Caption = "产品名称";
            this.WX83.FieldName = "WX83";
            this.WX83.Name = "WX83";
            this.WX83.Visible = true;
            this.WX83.VisibleIndex = 1;
            // 
            // WX01
            // 
            this.WX01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX01.AppearanceCell.Options.UseFont = true;
            this.WX01.AppearanceCell.Options.UseTextOptions = true;
            this.WX01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX01.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX01.AppearanceHeader.Options.UseFont = true;
            this.WX01.AppearanceHeader.Options.UseTextOptions = true;
            this.WX01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX01.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX01.Caption = "流水号";
            this.WX01.FieldName = "WX01";
            this.WX01.Name = "WX01";
            this.WX01.Visible = true;
            this.WX01.VisibleIndex = 2;
            // 
            // WX85
            // 
            this.WX85.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX85.AppearanceCell.Options.UseFont = true;
            this.WX85.AppearanceCell.Options.UseTextOptions = true;
            this.WX85.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX85.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX85.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX85.AppearanceHeader.Options.UseFont = true;
            this.WX85.AppearanceHeader.Options.UseTextOptions = true;
            this.WX85.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX85.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX85.Caption = "货号";
            this.WX85.FieldName = "WX85";
            this.WX85.Name = "WX85";
            this.WX85.Visible = true;
            this.WX85.VisibleIndex = 3;
            // 
            // WX84
            // 
            this.WX84.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX84.AppearanceCell.Options.UseFont = true;
            this.WX84.AppearanceCell.Options.UseTextOptions = true;
            this.WX84.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX84.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX84.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WX84.AppearanceHeader.Options.UseFont = true;
            this.WX84.AppearanceHeader.Options.UseTextOptions = true;
            this.WX84.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WX84.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WX84.Caption = "合同号";
            this.WX84.FieldName = "WX84";
            this.WX84.Name = "WX84";
            this.WX84.Visible = true;
            this.WX84.VisibleIndex = 4;
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceCell.Options.UseTextOptions = true;
            this.U1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.AppearanceHeader.Options.UseTextOptions = true;
            this.U1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U1.Caption = "状态";
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.Visible = true;
            this.U1.VisibleIndex = 5;
            // 
            // WaiXianNumAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 416);
            this.Controls.Add(this.gridControl1);
            this.Name = "WaiXianNumAll";
            this.Text = "流水号查询";
            this.Load += new System.EventHandler(this.WaiXianNumAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn WX83;
        private DevExpress.XtraGrid.Columns.GridColumn WX01;
        private DevExpress.XtraGrid.Columns.GridColumn WX85;
        private DevExpress.XtraGrid.Columns.GridColumn WX84;
        private DevExpress.XtraGrid.Columns.GridColumn WX82;
        private DevExpress.XtraGrid.Columns.GridColumn U1;
    }
}