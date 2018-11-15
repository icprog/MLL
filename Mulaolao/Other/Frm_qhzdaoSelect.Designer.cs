namespace Mulaolao.Other
{
    partial class Frm_qhzdaoSelect
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
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U5 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(1059, 326);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 30;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.U0,
            this.U1,
            this.U2,
            this.U3,
            this.U4,
            this.U5});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceCell.Options.UseTextOptions = true;
            this.U0.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.AppearanceHeader.Options.UseTextOptions = true;
            this.U0.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U0.Caption = "组长编号";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceCell.Options.UseTextOptions = true;
            this.U1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.AppearanceHeader.Options.UseTextOptions = true;
            this.U1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.Caption = "组长姓名";
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.Visible = true;
            this.U1.VisibleIndex = 0;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceCell.Options.UseTextOptions = true;
            this.U2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.AppearanceHeader.Options.UseTextOptions = true;
            this.U2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U2.Caption = "考察日期";
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.Visible = true;
            this.U2.VisibleIndex = 1;
            // 
            // U3
            // 
            this.U3.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U3.AppearanceCell.Options.UseFont = true;
            this.U3.AppearanceCell.Options.UseTextOptions = true;
            this.U3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U3.AppearanceHeader.Options.UseFont = true;
            this.U3.AppearanceHeader.Options.UseTextOptions = true;
            this.U3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U3.Caption = "单号";
            this.U3.FieldName = "U3";
            this.U3.Name = "U3";
            // 
            // U4
            // 
            this.U4.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U4.AppearanceCell.Options.UseFont = true;
            this.U4.AppearanceCell.Options.UseTextOptions = true;
            this.U4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U4.Caption = "车间主任编号";
            this.U4.FieldName = "U4";
            this.U4.Name = "U4";
            // 
            // U5
            // 
            this.U5.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U5.AppearanceCell.Options.UseFont = true;
            this.U5.AppearanceCell.Options.UseTextOptions = true;
            this.U5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U5.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.U5.AppearanceHeader.Options.UseFont = true;
            this.U5.AppearanceHeader.Options.UseTextOptions = true;
            this.U5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U5.Caption = "车间主任姓名";
            this.U5.FieldName = "U5";
            this.U5.Name = "U5";
            this.U5.Visible = true;
            this.U5.VisibleIndex = 2;
            // 
            // Frm_qhzdaoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 326);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm_qhzdaoSelect";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.Frm_qhzdaoSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn U0;
        private DevExpress.XtraGrid.Columns.GridColumn U1;
        private DevExpress.XtraGrid.Columns.GridColumn U2;
        private DevExpress.XtraGrid.Columns.GridColumn U3;
        private DevExpress.XtraGrid.Columns.GridColumn U4;
        private DevExpress.XtraGrid.Columns.GridColumn U5;
    }
}