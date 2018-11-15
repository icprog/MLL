namespace SelectAll
{
    partial class GunQiChenBenLibraryAll
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AC18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC06 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FORE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1195, 354);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 28);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // MenuItem
            // 
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(190, 24);
            this.MenuItem.Text = "编辑使用出库数量";
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AC18,
            this.AC06,
            this.AC04,
            this.AC05,
            this.ONE,
            this.TRE,
            this.FORE,
            this.FIV});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // AC18
            // 
            this.AC18.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC18.AppearanceCell.Options.UseFont = true;
            this.AC18.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC18.AppearanceHeader.Options.UseFont = true;
            this.AC18.AppearanceHeader.Options.UseTextOptions = true;
            this.AC18.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC18.Caption = "R_464单号";
            this.AC18.FieldName = "AC18";
            this.AC18.Name = "AC18";
            this.AC18.OptionsColumn.AllowEdit = false;
            this.AC18.Visible = true;
            this.AC18.VisibleIndex = 0;
            this.AC18.Width = 159;
            // 
            // AC06
            // 
            this.AC06.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC06.AppearanceCell.Options.UseFont = true;
            this.AC06.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC06.AppearanceHeader.Options.UseFont = true;
            this.AC06.AppearanceHeader.Options.UseTextOptions = true;
            this.AC06.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC06.Caption = "油漆品牌";
            this.AC06.FieldName = "AC06";
            this.AC06.Name = "AC06";
            this.AC06.OptionsColumn.AllowEdit = false;
            this.AC06.Visible = true;
            this.AC06.VisibleIndex = 1;
            this.AC06.Width = 104;
            // 
            // AC04
            // 
            this.AC04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceCell.Options.UseFont = true;
            this.AC04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceHeader.Options.UseFont = true;
            this.AC04.AppearanceHeader.Options.UseTextOptions = true;
            this.AC04.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC04.Caption = "色名";
            this.AC04.FieldName = "AC04";
            this.AC04.Name = "AC04";
            this.AC04.OptionsColumn.AllowEdit = false;
            this.AC04.Visible = true;
            this.AC04.VisibleIndex = 2;
            this.AC04.Width = 112;
            // 
            // AC05
            // 
            this.AC05.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceCell.Options.UseFont = true;
            this.AC05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceHeader.Options.UseFont = true;
            this.AC05.AppearanceHeader.Options.UseTextOptions = true;
            this.AC05.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC05.Caption = "色号";
            this.AC05.FieldName = "AC05";
            this.AC05.Name = "AC05";
            this.AC05.OptionsColumn.AllowEdit = false;
            this.AC05.Visible = true;
            this.AC05.VisibleIndex = 3;
            this.AC05.Width = 132;
            // 
            // ONE
            // 
            this.ONE.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.ONE.AppearanceCell.Options.UseFont = true;
            this.ONE.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.ONE.AppearanceHeader.Options.UseFont = true;
            this.ONE.Caption = "剩余库存数量";
            this.ONE.FieldName = "ONE";
            this.ONE.Name = "ONE";
            this.ONE.OptionsColumn.AllowEdit = false;
            this.ONE.Visible = true;
            this.ONE.VisibleIndex = 5;
            this.ONE.Width = 109;
            // 
            // TRE
            // 
            this.TRE.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TRE.AppearanceCell.Options.UseFont = true;
            this.TRE.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TRE.AppearanceHeader.Options.UseFont = true;
            this.TRE.AppearanceHeader.Options.UseTextOptions = true;
            this.TRE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TRE.Caption = "使用库存数量";
            this.TRE.FieldName = "TRE";
            this.TRE.Name = "TRE";
            this.TRE.OptionsColumn.AllowEdit = false;
            this.TRE.Visible = true;
            this.TRE.VisibleIndex = 4;
            this.TRE.Width = 110;
            // 
            // FORE
            // 
            this.FORE.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.FORE.AppearanceCell.Options.UseFont = true;
            this.FORE.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.FORE.AppearanceHeader.Options.UseFont = true;
            this.FORE.AppearanceHeader.Options.UseTextOptions = true;
            this.FORE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.FORE.Caption = "出库数量";
            this.FORE.FieldName = "FORE";
            this.FORE.Name = "FORE";
            this.FORE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FORE", "{0:0.0000}")});
            this.FORE.Visible = true;
            this.FORE.VisibleIndex = 7;
            this.FORE.Width = 90;
            // 
            // FIV
            // 
            this.FIV.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.FIV.AppearanceCell.Options.UseFont = true;
            this.FIV.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.FIV.AppearanceHeader.Options.UseFont = true;
            this.FIV.AppearanceHeader.Options.UseTextOptions = true;
            this.FIV.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.FIV.Caption = "上次出库数量";
            this.FIV.FieldName = "FIV";
            this.FIV.Name = "FIV";
            this.FIV.OptionsColumn.AllowEdit = false;
            this.FIV.Visible = true;
            this.FIV.VisibleIndex = 6;
            this.FIV.Width = 110;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Size = new System.Drawing.Size(1195, 398);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1117, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 7;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1036, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 6;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GunQiChenBenLibraryAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 398);
            this.Controls.Add(this.splitContainer1);
            this.Name = "GunQiChenBenLibraryAll";
            this.Text = "滚漆出库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GunQiChenBenLibraryAll_FormClosing);
            this.Load += new System.EventHandler(this.GunQiChenBenLibraryAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn AC18;
        private DevExpress . XtraGrid . Columns . GridColumn AC04;
        private DevExpress . XtraGrid . Columns . GridColumn AC06;
        private DevExpress . XtraGrid . Columns . GridColumn AC05;
        private DevExpress . XtraGrid . Columns . GridColumn ONE;
        private DevExpress . XtraGrid . Columns . GridColumn TRE;
        private DevExpress . XtraGrid . Columns . GridColumn FORE;
        private DevExpress . XtraGrid . Columns . GridColumn FIV;
        private DevExpress . XtraEditors . Repository . RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . Button button4;
        private System . Windows . Forms . Button button3;
        private System . Windows . Forms . ContextMenuStrip contextMenuStrip1;
        private System . Windows . Forms . ToolStripMenuItem MenuItem;
    }
}