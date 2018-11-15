namespace SelectAll
{
    partial class ChangPingGaiShanNumAll
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOne = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PQF01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HT52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageTwo = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BG001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF07 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF08 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabPageTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOne);
            this.tabControl1.Controls.Add(this.tabPageTwo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1218, 478);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageOne
            // 
            this.tabPageOne.Controls.Add(this.gridControl1);
            this.tabPageOne.Location = new System.Drawing.Point(4, 26);
            this.tabPageOne.Name = "tabPageOne";
            this.tabPageOne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOne.Size = new System.Drawing.Size(1210, 448);
            this.tabPageOne.TabIndex = 0;
            this.tabPageOne.Text = "产品信息";
            this.tabPageOne.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1204, 442);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PQF01,
            this.PQF04,
            this.PQF03,
            this.PQF02,
            this.PQF06,
            this.PQF17,
            this.HT52,
            this.PQF07,
            this.PQF08});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // PQF01
            // 
            this.PQF01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceCell.Options.UseFont = true;
            this.PQF01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceHeader.Options.UseFont = true;
            this.PQF01.Caption = "流水号";
            this.PQF01.FieldName = "PQF01";
            this.PQF01.Name = "PQF01";
            this.PQF01.Visible = true;
            this.PQF01.VisibleIndex = 0;
            // 
            // PQF04
            // 
            this.PQF04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceCell.Options.UseFont = true;
            this.PQF04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceHeader.Options.UseFont = true;
            this.PQF04.Caption = "产品名称";
            this.PQF04.FieldName = "PQF04";
            this.PQF04.Name = "PQF04";
            this.PQF04.Visible = true;
            this.PQF04.VisibleIndex = 1;
            // 
            // PQF03
            // 
            this.PQF03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceCell.Options.UseFont = true;
            this.PQF03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF03.AppearanceHeader.Options.UseFont = true;
            this.PQF03.Caption = "货号";
            this.PQF03.FieldName = "PQF03";
            this.PQF03.Name = "PQF03";
            this.PQF03.Visible = true;
            this.PQF03.VisibleIndex = 3;
            // 
            // PQF06
            // 
            this.PQF06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceCell.Options.UseFont = true;
            this.PQF06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF06.AppearanceHeader.Options.UseFont = true;
            this.PQF06.Caption = "产品数量";
            this.PQF06.FieldName = "PQF06";
            this.PQF06.Name = "PQF06";
            this.PQF06.Visible = true;
            this.PQF06.VisibleIndex = 4;
            // 
            // PQF17
            // 
            this.PQF17.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF17.AppearanceHeader.Options.UseFont = true;
            this.PQF17.Caption = "生产部门编号";
            this.PQF17.FieldName = "PQF17";
            this.PQF17.Name = "PQF17";
            // 
            // HT52
            // 
            this.HT52.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.HT52.AppearanceCell.Options.UseFont = true;
            this.HT52.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.HT52.AppearanceHeader.Options.UseFont = true;
            this.HT52.Caption = "生产部门";
            this.HT52.FieldName = "HT52";
            this.HT52.Name = "HT52";
            this.HT52.Visible = true;
            this.HT52.VisibleIndex = 5;
            // 
            // tabPageTwo
            // 
            this.tabPageTwo.Controls.Add(this.gridControl2);
            this.tabPageTwo.Location = new System.Drawing.Point(4, 26);
            this.tabPageTwo.Name = "tabPageTwo";
            this.tabPageTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTwo.Size = new System.Drawing.Size(1210, 448);
            this.tabPageTwo.TabIndex = 1;
            this.tabPageTwo.Text = "预生产产品信息";
            this.tabPageTwo.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(3, 3);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1204, 442);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 25;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BG001,
            this.BG002,
            this.BG003,
            this.BG004});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
            // 
            // BG001
            // 
            this.BG001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG001.AppearanceCell.Options.UseFont = true;
            this.BG001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.BG001.AppearanceHeader.Options.UseFont = true;
            this.BG001.Caption = "流水号";
            this.BG001.FieldName = "BG001";
            this.BG001.Name = "BG001";
            this.BG001.Visible = true;
            this.BG001.VisibleIndex = 0;
            // 
            // BG002
            // 
            this.BG002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG002.AppearanceCell.Options.UseFont = true;
            this.BG002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.BG002.AppearanceHeader.Options.UseFont = true;
            this.BG002.Caption = "产品名称";
            this.BG002.FieldName = "BG002";
            this.BG002.Name = "BG002";
            this.BG002.Visible = true;
            this.BG002.VisibleIndex = 1;
            // 
            // BG003
            // 
            this.BG003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG003.AppearanceCell.Options.UseFont = true;
            this.BG003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.BG003.AppearanceHeader.Options.UseFont = true;
            this.BG003.Caption = "货号";
            this.BG003.FieldName = "BG003";
            this.BG003.Name = "BG003";
            this.BG003.Visible = true;
            this.BG003.VisibleIndex = 2;
            // 
            // BG004
            // 
            this.BG004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG004.AppearanceCell.Options.UseFont = true;
            this.BG004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.BG004.AppearanceHeader.Options.UseFont = true;
            this.BG004.Caption = "产品数量";
            this.BG004.FieldName = "BG004";
            this.BG004.Name = "BG004";
            this.BG004.Visible = true;
            this.BG004.VisibleIndex = 3;
            // 
            // PQF02
            // 
            this.PQF02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceCell.Options.UseFont = true;
            this.PQF02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.PQF02.AppearanceHeader.Options.UseFont = true;
            this.PQF02.Caption = "合同号";
            this.PQF02.FieldName = "PQF02";
            this.PQF02.Name = "PQF02";
            this.PQF02.Visible = true;
            this.PQF02.VisibleIndex = 2;
            // 
            // PQF07
            // 
            this.PQF07.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF07.AppearanceCell.Options.UseFont = true;
            this.PQF07.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF07.AppearanceHeader.Options.UseFont = true;
            this.PQF07.Caption = "目的国";
            this.PQF07.FieldName = "PQF07";
            this.PQF07.Name = "PQF07";
            this.PQF07.Visible = true;
            this.PQF07.VisibleIndex = 6;
            // 
            // PQF08
            // 
            this.PQF08.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF08.AppearanceCell.Options.UseFont = true;
            this.PQF08.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF08.AppearanceHeader.Options.UseFont = true;
            this.PQF08.Caption = "年龄段";
            this.PQF08.FieldName = "PQF08";
            this.PQF08.Name = "PQF08";
            this.PQF08.Visible = true;
            this.PQF08.VisibleIndex = 7;
            // 
            // ChangPingGaiShanNumAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 478);
            this.Controls.Add(this.tabControl1);
            this.Name = "ChangPingGaiShanNumAll";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.ChangPingGaiShanNumAll_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabPageTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOne;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn PQF01;
        private DevExpress.XtraGrid.Columns.GridColumn PQF04;
        private DevExpress.XtraGrid.Columns.GridColumn PQF03;
        private DevExpress.XtraGrid.Columns.GridColumn PQF06;
        private DevExpress.XtraGrid.Columns.GridColumn PQF17;
        private DevExpress.XtraGrid.Columns.GridColumn HT52;
        private System.Windows.Forms.TabPage tabPageTwo;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn BG001;
        private DevExpress.XtraGrid.Columns.GridColumn BG002;
        private DevExpress.XtraGrid.Columns.GridColumn BG003;
        private DevExpress.XtraGrid.Columns.GridColumn BG004;
        private DevExpress.XtraGrid.Columns.GridColumn PQF02;
        private DevExpress.XtraGrid.Columns.GridColumn PQF07;
        private DevExpress.XtraGrid.Columns.GridColumn PQF08;
    }
}