namespace Mulaolao . Environmental
{
    partial class FormSanitationBroad
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
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.SAD002 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SAD003 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SAD004 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SAD005 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.SAD009 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gb1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gb11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1215, 453);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.BandPanelRowHeight = 20;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gb1,
            this.gb2,
            this.gb3,
            this.gb4,
            this.gb5,
            this.gb6,
            this.gb7,
            this.gb8,
            this.gb9,
            this.gb10,
            this.gb11});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.SAD002,
            this.SAD003,
            this.SAD004,
            this.SAD005,
            this.SAD009});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsView.AllowCellMerge = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SAD002
            // 
            this.SAD002.Caption = "检查区域";
            this.SAD002.FieldName = "SAD002";
            this.SAD002.Name = "SAD002";
            this.SAD002.Visible = true;
            this.SAD002.Width = 112;
            // 
            // SAD003
            // 
            this.SAD003.Caption = "检查项目";
            this.SAD003.FieldName = "SAD003";
            this.SAD003.Name = "SAD003";
            this.SAD003.Visible = true;
            this.SAD003.Width = 112;
            // 
            // SAD004
            // 
            this.SAD004.Caption = "检查现场内容";
            this.SAD004.FieldName = "SAD004";
            this.SAD004.Name = "SAD004";
            this.SAD004.Visible = true;
            this.SAD004.Width = 111;
            // 
            // SAD005
            // 
            this.SAD005.Caption = "评分标准";
            this.SAD005.FieldName = "SAD005";
            this.SAD005.Name = "SAD005";
            this.SAD005.Visible = true;
            this.SAD005.Width = 61;
            // 
            // SAD009
            // 
            this.SAD009.Caption = "现状及存在问题描述";
            this.SAD009.FieldName = "SAD009";
            this.SAD009.Name = "SAD009";
            this.SAD009.Visible = true;
            this.SAD009.Width = 132;
            // 
            // gb1
            // 
            this.gb1.Columns.Add(this.SAD002);
            this.gb1.Columns.Add(this.SAD003);
            this.gb1.Columns.Add(this.SAD004);
            this.gb1.Columns.Add(this.SAD005);
            this.gb1.Columns.Add(this.SAD009);
            this.gb1.Name = "gb1";
            this.gb1.VisibleIndex = 0;
            this.gb1.Width = 528;
            // 
            // gb2
            // 
            this.gb2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb2.AppearanceHeader.Options.UseFont = true;
            this.gb2.AppearanceHeader.Options.UseTextOptions = true;
            this.gb2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb2.Caption = "gb2";
            this.gb2.Name = "gb2";
            this.gb2.Visible = false;
            this.gb2.VisibleIndex = -1;
            this.gb2.Width = 66;
            // 
            // gb3
            // 
            this.gb3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb3.AppearanceHeader.Options.UseFont = true;
            this.gb3.AppearanceHeader.Options.UseTextOptions = true;
            this.gb3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb3.Caption = "gb3";
            this.gb3.Name = "gb3";
            this.gb3.Visible = false;
            this.gb3.VisibleIndex = -1;
            this.gb3.Width = 66;
            // 
            // gb4
            // 
            this.gb4.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb4.AppearanceHeader.Options.UseFont = true;
            this.gb4.AppearanceHeader.Options.UseTextOptions = true;
            this.gb4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb4.Caption = "gb4";
            this.gb4.Name = "gb4";
            this.gb4.Visible = false;
            this.gb4.VisibleIndex = -1;
            this.gb4.Width = 66;
            // 
            // gb5
            // 
            this.gb5.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb5.AppearanceHeader.Options.UseFont = true;
            this.gb5.AppearanceHeader.Options.UseTextOptions = true;
            this.gb5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb5.Caption = "gb5";
            this.gb5.Name = "gb5";
            this.gb5.Visible = false;
            this.gb5.VisibleIndex = -1;
            this.gb5.Width = 66;
            // 
            // gb6
            // 
            this.gb6.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb6.AppearanceHeader.Options.UseFont = true;
            this.gb6.AppearanceHeader.Options.UseTextOptions = true;
            this.gb6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb6.Caption = "gb6";
            this.gb6.Name = "gb6";
            this.gb6.Visible = false;
            this.gb6.VisibleIndex = -1;
            this.gb6.Width = 66;
            // 
            // gb7
            // 
            this.gb7.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb7.AppearanceHeader.Options.UseFont = true;
            this.gb7.AppearanceHeader.Options.UseTextOptions = true;
            this.gb7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb7.Caption = "gb7";
            this.gb7.Name = "gb7";
            this.gb7.Visible = false;
            this.gb7.VisibleIndex = -1;
            this.gb7.Width = 66;
            // 
            // gb8
            // 
            this.gb8.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb8.AppearanceHeader.Options.UseFont = true;
            this.gb8.AppearanceHeader.Options.UseTextOptions = true;
            this.gb8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb8.Caption = "gb8";
            this.gb8.Name = "gb8";
            this.gb8.Visible = false;
            this.gb8.VisibleIndex = -1;
            this.gb8.Width = 66;
            // 
            // gb9
            // 
            this.gb9.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb9.AppearanceHeader.Options.UseFont = true;
            this.gb9.AppearanceHeader.Options.UseTextOptions = true;
            this.gb9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb9.Caption = "gb9";
            this.gb9.Name = "gb9";
            this.gb9.Visible = false;
            this.gb9.VisibleIndex = -1;
            this.gb9.Width = 66;
            // 
            // gb10
            // 
            this.gb10.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb10.AppearanceHeader.Options.UseFont = true;
            this.gb10.AppearanceHeader.Options.UseTextOptions = true;
            this.gb10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb10.Caption = "gb10";
            this.gb10.Name = "gb10";
            this.gb10.Visible = false;
            this.gb10.VisibleIndex = -1;
            this.gb10.Width = 66;
            // 
            // gb11
            // 
            this.gb11.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.gb11.AppearanceHeader.Options.UseFont = true;
            this.gb11.AppearanceHeader.Options.UseTextOptions = true;
            this.gb11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gb11.Caption = "gb11";
            this.gb11.Name = "gb11";
            this.gb11.Visible = false;
            this.gb11.VisibleIndex = -1;
            this.gb11.Width = 75;
            // 
            // FormSanitationBroad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 453);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormSanitationBroad";
            this.Text = "生产部环境卫生、安全检查汇总对比表";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridView bandedGridView1;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridColumn SAD002;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridColumn SAD003;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridColumn SAD004;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridColumn SAD005;
        private DevExpress . XtraGrid . Views . BandedGrid . BandedGridColumn SAD009;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb1;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb2;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb3;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb4;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb5;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb6;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb7;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb8;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb9;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb10;
        private DevExpress . XtraGrid . Views . BandedGrid . GridBand gb11;
    }
}