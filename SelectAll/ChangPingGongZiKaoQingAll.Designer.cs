namespace SelectAll
{
    partial class ChangPingGongZiKaoQingAll
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
            this.PQF01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOne = new System.Windows.Forms.TabPage();
            this.tabPageTwo = new System.Windows.Forms.TabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BG001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BG004 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageOne.SuspendLayout();
            this.tabPageTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(653, 456);
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
            this.PQF06});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // PQF01
            // 
            this.PQF01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF01.AppearanceCell.Options.UseFont = true;
            this.PQF01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF01.AppearanceHeader.Options.UseFont = true;
            this.PQF01.Caption = "流水号";
            this.PQF01.FieldName = "PQF01";
            this.PQF01.Name = "PQF01";
            this.PQF01.Visible = true;
            this.PQF01.VisibleIndex = 0;
            // 
            // PQF04
            // 
            this.PQF04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF04.AppearanceCell.Options.UseFont = true;
            this.PQF04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF04.AppearanceHeader.Options.UseFont = true;
            this.PQF04.Caption = "产品信息";
            this.PQF04.FieldName = "PQF04";
            this.PQF04.Name = "PQF04";
            this.PQF04.Visible = true;
            this.PQF04.VisibleIndex = 1;
            // 
            // PQF03
            // 
            this.PQF03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF03.AppearanceCell.Options.UseFont = true;
            this.PQF03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF03.AppearanceHeader.Options.UseFont = true;
            this.PQF03.Caption = "货号";
            this.PQF03.FieldName = "PQF03";
            this.PQF03.Name = "PQF03";
            this.PQF03.Visible = true;
            this.PQF03.VisibleIndex = 2;
            // 
            // PQF06
            // 
            this.PQF06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF06.AppearanceCell.Options.UseFont = true;
            this.PQF06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PQF06.AppearanceHeader.Options.UseFont = true;
            this.PQF06.Caption = "产品数量";
            this.PQF06.FieldName = "PQF06";
            this.PQF06.Name = "PQF06";
            this.PQF06.Visible = true;
            this.PQF06.VisibleIndex = 3;
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
            this.tabControl1.Size = new System.Drawing.Size(667, 492);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageOne
            // 
            this.tabPageOne.Controls.Add(this.gridControl1);
            this.tabPageOne.Location = new System.Drawing.Point(4, 26);
            this.tabPageOne.Name = "tabPageOne";
            this.tabPageOne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOne.Size = new System.Drawing.Size(659, 462);
            this.tabPageOne.TabIndex = 0;
            this.tabPageOne.Text = "产品信息";
            this.tabPageOne.UseVisualStyleBackColor = true;
            // 
            // tabPageTwo
            // 
            this.tabPageTwo.Controls.Add(this.gridControl2);
            this.tabPageTwo.Location = new System.Drawing.Point(4, 26);
            this.tabPageTwo.Name = "tabPageTwo";
            this.tabPageTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTwo.Size = new System.Drawing.Size(659, 462);
            this.tabPageTwo.TabIndex = 1;
            this.tabPageTwo.Text = "预生产产品";
            this.tabPageTwo.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(3, 3);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(653, 456);
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
            this.BG001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG001.AppearanceHeader.Options.UseFont = true;
            this.BG001.Caption = "预生产流水号";
            this.BG001.FieldName = "BG001";
            this.BG001.Name = "BG001";
            this.BG001.Visible = true;
            this.BG001.VisibleIndex = 0;
            // 
            // BG002
            // 
            this.BG002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG002.AppearanceCell.Options.UseFont = true;
            this.BG002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.BG003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.BG004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BG004.AppearanceHeader.Options.UseFont = true;
            this.BG004.Caption = "产品数量";
            this.BG004.FieldName = "BG004";
            this.BG004.Name = "BG004";
            this.BG004.Visible = true;
            this.BG004.VisibleIndex = 3;
            // 
            // ChangPingGongZiKaoQingAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 492);
            this.Controls.Add(this.tabControl1);
            this.Name = "ChangPingGongZiKaoQingAll";
            this.Text = "信息查询";
            this.Load += new System.EventHandler(this.ChangPingGongZiKaoQingAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageOne.ResumeLayout(false);
            this.tabPageTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOne;
        private System.Windows.Forms.TabPage tabPageTwo;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn PQF01;
        private DevExpress.XtraGrid.Columns.GridColumn PQF04;
        private DevExpress.XtraGrid.Columns.GridColumn PQF03;
        private DevExpress.XtraGrid.Columns.GridColumn PQF06;
        private DevExpress.XtraGrid.Columns.GridColumn BG001;
        private DevExpress.XtraGrid.Columns.GridColumn BG002;
        private DevExpress.XtraGrid.Columns.GridColumn BG003;
        private DevExpress.XtraGrid.Columns.GridColumn BG004;
    }
}