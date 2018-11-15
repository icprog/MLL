namespace Mulaolao.Other
{
    partial class R_Frm464Select
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.check = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.AC18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC09 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AC28 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1265, 382);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(431, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 3;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(299, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 2;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消全选";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1265, 342);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 45;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.check,
            this.AC18,
            this.AC16,
            this.AC01,
            this.AC02,
            this.AC04,
            this.AC05,
            this.AC09,
            this.AC03,
            this.AC10,
            this.AC,
            this.AC11,
            this.AC22,
            this.AC24,
            this.AC28});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupRowHeight = 30;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowHeight = 30;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            // 
            // check
            // 
            this.check.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.check.AppearanceHeader.Options.UseFont = true;
            this.check.AppearanceHeader.Options.UseTextOptions = true;
            this.check.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.check.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.check.Caption = "选择";
            this.check.ColumnEdit = this.repositoryItemCheckEdit1;
            this.check.FieldName = "check";
            this.check.Name = "check";
            this.check.Width = 70;
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
            this.AC18.AppearanceCell.Options.UseTextOptions = true;
            this.AC18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC18.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC18.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC18.AppearanceHeader.Options.UseFont = true;
            this.AC18.AppearanceHeader.Options.UseTextOptions = true;
            this.AC18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC18.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC18.Caption = "单号";
            this.AC18.FieldName = "AC18";
            this.AC18.Name = "AC18";
            this.AC18.Visible = true;
            this.AC18.VisibleIndex = 1;
            this.AC18.Width = 126;
            // 
            // AC16
            // 
            this.AC16.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC16.AppearanceCell.Options.UseFont = true;
            this.AC16.AppearanceCell.Options.UseTextOptions = true;
            this.AC16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC16.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC16.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC16.AppearanceHeader.Options.UseFont = true;
            this.AC16.AppearanceHeader.Options.UseTextOptions = true;
            this.AC16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC16.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC16.Caption = "合同";
            this.AC16.FieldName = "AC16";
            this.AC16.Name = "AC16";
            this.AC16.Visible = true;
            this.AC16.VisibleIndex = 2;
            this.AC16.Width = 60;
            // 
            // AC01
            // 
            this.AC01.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC01.AppearanceCell.Options.UseFont = true;
            this.AC01.AppearanceCell.Options.UseTextOptions = true;
            this.AC01.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC01.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC01.AppearanceHeader.Options.UseFont = true;
            this.AC01.AppearanceHeader.Options.UseTextOptions = true;
            this.AC01.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC01.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC01.Caption = "产品名称";
            this.AC01.FieldName = "AC01";
            this.AC01.Name = "AC01";
            this.AC01.Visible = true;
            this.AC01.VisibleIndex = 3;
            this.AC01.Width = 131;
            // 
            // AC02
            // 
            this.AC02.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC02.AppearanceCell.Options.UseFont = true;
            this.AC02.AppearanceCell.Options.UseTextOptions = true;
            this.AC02.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC02.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC02.AppearanceHeader.Options.UseFont = true;
            this.AC02.AppearanceHeader.Options.UseTextOptions = true;
            this.AC02.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC02.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC02.Caption = "货号";
            this.AC02.FieldName = "AC02";
            this.AC02.Name = "AC02";
            this.AC02.Visible = true;
            this.AC02.VisibleIndex = 4;
            this.AC02.Width = 82;
            // 
            // AC04
            // 
            this.AC04.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceCell.Options.UseFont = true;
            this.AC04.AppearanceCell.Options.UseTextOptions = true;
            this.AC04.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC04.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC04.AppearanceHeader.Options.UseFont = true;
            this.AC04.AppearanceHeader.Options.UseTextOptions = true;
            this.AC04.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC04.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC04.Caption = "采购库存物资名称";
            this.AC04.FieldName = "AC04";
            this.AC04.Name = "AC04";
            this.AC04.Visible = true;
            this.AC04.VisibleIndex = 5;
            this.AC04.Width = 155;
            // 
            // AC05
            // 
            this.AC05.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceCell.Options.UseFont = true;
            this.AC05.AppearanceCell.Options.UseTextOptions = true;
            this.AC05.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC05.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC05.AppearanceHeader.Options.UseFont = true;
            this.AC05.AppearanceHeader.Options.UseTextOptions = true;
            this.AC05.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC05.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC05.Caption = "规格";
            this.AC05.FieldName = "AC05";
            this.AC05.Name = "AC05";
            this.AC05.Visible = true;
            this.AC05.VisibleIndex = 6;
            this.AC05.Width = 109;
            // 
            // AC09
            // 
            this.AC09.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC09.AppearanceCell.Options.UseFont = true;
            this.AC09.AppearanceCell.Options.UseTextOptions = true;
            this.AC09.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC09.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC09.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC09.AppearanceHeader.Options.UseFont = true;
            this.AC09.AppearanceHeader.Options.UseTextOptions = true;
            this.AC09.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC09.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC09.Caption = "单价";
            this.AC09.DisplayFormat.FormatString = "N2";
            this.AC09.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.AC09.FieldName = "AC09";
            this.AC09.Name = "AC09";
            this.AC09.Visible = true;
            this.AC09.VisibleIndex = 7;
            this.AC09.Width = 39;
            // 
            // AC03
            // 
            this.AC03.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC03.AppearanceCell.Options.UseFont = true;
            this.AC03.AppearanceCell.Options.UseTextOptions = true;
            this.AC03.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC03.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC03.AppearanceHeader.Options.UseFont = true;
            this.AC03.AppearanceHeader.Options.UseTextOptions = true;
            this.AC03.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC03.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC03.Caption = "库存物料数量";
            this.AC03.FieldName = "AC03";
            this.AC03.Name = "AC03";
            this.AC03.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AC03", "{0:N0}")});
            this.AC03.Visible = true;
            this.AC03.VisibleIndex = 8;
            this.AC03.Width = 95;
            // 
            // AC10
            // 
            this.AC10.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC10.AppearanceCell.Options.UseFont = true;
            this.AC10.AppearanceCell.Options.UseTextOptions = true;
            this.AC10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC10.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC10.AppearanceHeader.Options.UseFont = true;
            this.AC10.AppearanceHeader.Options.UseTextOptions = true;
            this.AC10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC10.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC10.Caption = "剩余产品数量";
            this.AC10.FieldName = "AC10";
            this.AC10.Name = "AC10";
            this.AC10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AC10", "{0}")});
            this.AC10.Visible = true;
            this.AC10.VisibleIndex = 9;
            this.AC10.Width = 93;
            // 
            // AC
            // 
            this.AC.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC.AppearanceCell.Options.UseFont = true;
            this.AC.AppearanceCell.Options.UseTextOptions = true;
            this.AC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC.AppearanceHeader.Options.UseFont = true;
            this.AC.AppearanceHeader.Options.UseTextOptions = true;
            this.AC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC.Caption = "库存金额";
            this.AC.DisplayFormat.FormatString = "N0";
            this.AC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.AC.FieldName = "AC";
            this.AC.Name = "AC";
            this.AC.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AC", "{0:N0}")});
            this.AC.Visible = true;
            this.AC.VisibleIndex = 10;
            this.AC.Width = 62;
            // 
            // AC11
            // 
            this.AC11.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC11.AppearanceCell.Options.UseFont = true;
            this.AC11.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC11.AppearanceHeader.Options.UseFont = true;
            this.AC11.AppearanceHeader.Options.UseTextOptions = true;
            this.AC11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC11.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC11.Caption = "开合同人";
            this.AC11.FieldName = "AC11";
            this.AC11.Name = "AC11";
            this.AC11.Visible = true;
            this.AC11.VisibleIndex = 11;
            this.AC11.Width = 91;
            // 
            // AC22
            // 
            this.AC22.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC22.AppearanceCell.Options.UseFont = true;
            this.AC22.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC22.AppearanceHeader.Options.UseFont = true;
            this.AC22.AppearanceHeader.Options.UseTextOptions = true;
            this.AC22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.AC22.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC22.Caption = "生产车间";
            this.AC22.FieldName = "AC22";
            this.AC22.Name = "AC22";
            this.AC22.Visible = true;
            this.AC22.VisibleIndex = 12;
            // 
            // AC24
            // 
            this.AC24.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC24.AppearanceCell.Options.UseFont = true;
            this.AC24.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC24.AppearanceHeader.Options.UseFont = true;
            this.AC24.AppearanceHeader.Options.UseTextOptions = true;
            this.AC24.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC24.Caption = "是否结账";
            this.AC24.FieldName = "AC24";
            this.AC24.Name = "AC24";
            this.AC24.Visible = true;
            this.AC24.VisibleIndex = 14;
            // 
            // AC28
            // 
            this.AC28.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC28.AppearanceCell.Options.UseFont = true;
            this.AC28.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.AC28.AppearanceHeader.Options.UseFont = true;
            this.AC28.AppearanceHeader.Options.UseTextOptions = true;
            this.AC28.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.AC28.Caption = "供方联系人";
            this.AC28.FieldName = "AC28";
            this.AC28.Name = "AC28";
            this.AC28.Visible = true;
            this.AC28.VisibleIndex = 13;
            // 
            // R_Frm464Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 382);
            this.Controls.Add(this.splitContainer1);
            this.Name = "R_Frm464Select";
            this.Text = "R_Frm464Select";
            this.Load += new System.EventHandler(this.R_Frm464Select_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn AC18;
        private DevExpress.XtraGrid.Columns.GridColumn AC01;
        private DevExpress.XtraGrid.Columns.GridColumn AC02;
        private DevExpress.XtraGrid.Columns.GridColumn AC04;
        private DevExpress.XtraGrid.Columns.GridColumn AC05;
        private DevExpress.XtraGrid.Columns.GridColumn check;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn AC03;
        private DevExpress.XtraGrid.Columns.GridColumn AC09;
        private DevExpress.XtraGrid.Columns.GridColumn AC;
        private DevExpress . XtraGrid . Columns . GridColumn AC16;
        private DevExpress . XtraGrid . Columns . GridColumn AC10;
        private DevExpress . XtraGrid . Columns . GridColumn AC11;
        private DevExpress . XtraGrid . Columns . GridColumn AC22;
        private DevExpress . XtraGrid . Columns . GridColumn AC24;
        private DevExpress . XtraGrid . Columns . GridColumn AC28;
    }
}