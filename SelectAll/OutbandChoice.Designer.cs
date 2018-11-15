namespace SelectAll
{
    partial class OutbandChoice
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.AC18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TWO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FORE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FIV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
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
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Size = new System.Drawing.Size(1215, 333);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1215, 284);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.AC18,
            this.AC04,
            this.AC02,
            this.AC05,
            this.ONE,
            this.TWO,
            this.TRE,
            this.FORE,
            this.FIV});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // check
            // 
            this.check.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceCell.Options.UseFont = true;
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.AppearanceHeader.Options.UseTextOptions = true;
            this.check.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.OptionsColumn.AllowEdit = false;
            this.check.Visible = true;
            this.check.VisibleIndex = 0;
            this.check.Width = 39;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            this.AC18.VisibleIndex = 1;
            this.AC18.Width = 159;
            // 
            // AC04
            // 
            this.AC04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceCell.Options.UseFont = true;
            this.AC04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceHeader.Options.UseFont = true;
            this.AC04.AppearanceHeader.Options.UseTextOptions = true;
            this.AC04.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC04.Caption = "材料名称";
            this.AC04.FieldName = "AC04";
            this.AC04.Name = "AC04";
            this.AC04.OptionsColumn.AllowEdit = false;
            this.AC04.Visible = true;
            this.AC04.VisibleIndex = 2;
            this.AC04.Width = 112;
            // 
            // AC02
            // 
            this.AC02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC02.AppearanceCell.Options.UseFont = true;
            this.AC02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC02.AppearanceHeader.Options.UseFont = true;
            this.AC02.AppearanceHeader.Options.UseTextOptions = true;
            this.AC02.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC02.Caption = "货号";
            this.AC02.FieldName = "AC02";
            this.AC02.Name = "AC02";
            this.AC02.OptionsColumn.AllowEdit = false;
            this.AC02.Visible = true;
            this.AC02.VisibleIndex = 3;
            this.AC02.Width = 104;
            // 
            // AC05
            // 
            this.AC05.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceCell.Options.UseFont = true;
            this.AC05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceHeader.Options.UseFont = true;
            this.AC05.AppearanceHeader.Options.UseTextOptions = true;
            this.AC05.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC05.Caption = "规格";
            this.AC05.FieldName = "AC05";
            this.AC05.Name = "AC05";
            this.AC05.OptionsColumn.AllowEdit = false;
            this.AC05.Visible = true;
            this.AC05.VisibleIndex = 4;
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
            this.ONE.VisibleIndex = 8;
            this.ONE.Width = 109;
            // 
            // TWO
            // 
            this.TWO.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TWO.AppearanceCell.Options.UseFont = true;
            this.TWO.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TWO.AppearanceHeader.Options.UseFont = true;
            this.TWO.AppearanceHeader.Options.UseTextOptions = true;
            this.TWO.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.TWO.Caption = "剩余产品数量";
            this.TWO.FieldName = "TWO";
            this.TWO.Name = "TWO";
            this.TWO.OptionsColumn.AllowEdit = false;
            this.TWO.Visible = true;
            this.TWO.VisibleIndex = 7;
            this.TWO.Width = 113;
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
            this.TRE.VisibleIndex = 6;
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
            this.FORE.Visible = true;
            this.FORE.VisibleIndex = 10;
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
            this.FIV.VisibleIndex = 9;
            this.FIV.Width = 110;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1133, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1052, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(960, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(904, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OutbandChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 333);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OutbandChoice";
            this.Text = "出库选择";
            this.Load += new System.EventHandler(this.OutbandChoice_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn AC18;
        private DevExpress.XtraGrid.Columns.GridColumn AC02;
        private DevExpress.XtraGrid.Columns.GridColumn AC05;
        private DevExpress.XtraGrid.Columns.GridColumn ONE;
        private DevExpress.XtraGrid.Columns.GridColumn TWO;
        private DevExpress.XtraGrid.Columns.GridColumn AC04;
        private DevExpress.XtraGrid.Columns.GridColumn TRE;
        private DevExpress.XtraGrid.Columns.GridColumn FORE;
        private DevExpress.XtraGrid.Columns.GridColumn FIV;
    }
}