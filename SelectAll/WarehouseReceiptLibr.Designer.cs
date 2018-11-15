namespace SelectAll
{
    partial class WarehouseReceiptLibr
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button7 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAR004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAR005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAR006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U0 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WAR009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbUser = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.U1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupUser = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.cmbPerson = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button7);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl13);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1233, 401);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.Location = new System.Drawing.Point(274, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(62, 26);
            this.button7.TabIndex = 48;
            this.button7.Text = "确定";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Location = new System.Drawing.Point(84, 9);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(151, 26);
            this.dateTimePicker2.TabIndex = 32;
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(10, 14);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(68, 16);
            this.labelControl13.TabIndex = 31;
            this.labelControl13.Text = "领用日期";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lupUser,
            this.cmbUser,
            this.cmbPerson});
            this.gridControl2.Size = new System.Drawing.Size(1233, 351);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.ColumnPanelRowHeight = 25;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idx,
            this.WAR001,
            this.WAR004,
            this.WAR005,
            this.WAR006,
            this.U0,
            this.WAR009,
            this.U3,
            this.U1,
            this.U2});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowHeight = 25;
            // 
            // idx
            // 
            this.idx.Caption = "入库编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // WAR001
            // 
            this.WAR001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR001.AppearanceCell.Options.UseFont = true;
            this.WAR001.AppearanceCell.Options.UseTextOptions = true;
            this.WAR001.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR001.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR001.AppearanceHeader.Options.UseFont = true;
            this.WAR001.AppearanceHeader.Options.UseTextOptions = true;
            this.WAR001.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR001.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR001.Caption = "物料类别";
            this.WAR001.FieldName = "WAR001";
            this.WAR001.Name = "WAR001";
            this.WAR001.OptionsColumn.AllowEdit = false;
            this.WAR001.Visible = true;
            this.WAR001.VisibleIndex = 0;
            this.WAR001.Width = 88;
            // 
            // WAR004
            // 
            this.WAR004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR004.AppearanceCell.Options.UseFont = true;
            this.WAR004.AppearanceCell.Options.UseTextOptions = true;
            this.WAR004.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR004.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR004.AppearanceHeader.Options.UseFont = true;
            this.WAR004.AppearanceHeader.Options.UseTextOptions = true;
            this.WAR004.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR004.Caption = "物料名称";
            this.WAR004.FieldName = "WAR004";
            this.WAR004.Name = "WAR004";
            this.WAR004.OptionsColumn.AllowEdit = false;
            this.WAR004.Visible = true;
            this.WAR004.VisibleIndex = 1;
            this.WAR004.Width = 78;
            // 
            // WAR005
            // 
            this.WAR005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR005.AppearanceCell.Options.UseFont = true;
            this.WAR005.AppearanceCell.Options.UseTextOptions = true;
            this.WAR005.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR005.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR005.AppearanceHeader.Options.UseFont = true;
            this.WAR005.AppearanceHeader.Options.UseTextOptions = true;
            this.WAR005.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR005.Caption = "规格";
            this.WAR005.FieldName = "WAR005";
            this.WAR005.Name = "WAR005";
            this.WAR005.OptionsColumn.AllowEdit = false;
            this.WAR005.Visible = true;
            this.WAR005.VisibleIndex = 2;
            // 
            // WAR006
            // 
            this.WAR006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR006.AppearanceCell.Options.UseFont = true;
            this.WAR006.AppearanceCell.Options.UseTextOptions = true;
            this.WAR006.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR006.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR006.AppearanceHeader.Options.UseFont = true;
            this.WAR006.AppearanceHeader.Options.UseTextOptions = true;
            this.WAR006.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR006.Caption = "剩余数量";
            this.WAR006.FieldName = "WAR006";
            this.WAR006.Name = "WAR006";
            this.WAR006.OptionsColumn.AllowEdit = false;
            this.WAR006.Visible = true;
            this.WAR006.VisibleIndex = 3;
            // 
            // U0
            // 
            this.U0.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceCell.Options.UseFont = true;
            this.U0.AppearanceCell.Options.UseTextOptions = true;
            this.U0.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U0.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U0.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U0.AppearanceHeader.Options.UseFont = true;
            this.U0.AppearanceHeader.Options.UseTextOptions = true;
            this.U0.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U0.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U0.Caption = "领用数量";
            this.U0.FieldName = "U0";
            this.U0.Name = "U0";
            this.U0.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WAS006", "{0:0}")});
            this.U0.Visible = true;
            this.U0.VisibleIndex = 4;
            this.U0.Width = 78;
            // 
            // WAR009
            // 
            this.WAR009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR009.AppearanceCell.Options.UseFont = true;
            this.WAR009.AppearanceCell.Options.UseTextOptions = true;
            this.WAR009.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR009.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.WAR009.AppearanceHeader.Options.UseFont = true;
            this.WAR009.AppearanceHeader.Options.UseTextOptions = true;
            this.WAR009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WAR009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.WAR009.Caption = "现单价";
            this.WAR009.FieldName = "WAR009";
            this.WAR009.Name = "WAR009";
            this.WAR009.Visible = true;
            this.WAR009.VisibleIndex = 5;
            // 
            // U3
            // 
            this.U3.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U3.AppearanceCell.Options.UseFont = true;
            this.U3.AppearanceCell.Options.UseTextOptions = true;
            this.U3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U3.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U3.AppearanceHeader.Options.UseFont = true;
            this.U3.AppearanceHeader.Options.UseTextOptions = true;
            this.U3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U3.Caption = "部门";
            this.U3.ColumnEdit = this.cmbUser;
            this.U3.FieldName = "U3";
            this.U3.Name = "U3";
            this.U3.Visible = true;
            this.U3.VisibleIndex = 6;
            // 
            // cmbUser
            // 
            this.cmbUser.AutoHeight = false;
            this.cmbUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUser.Name = "cmbUser";
            // 
            // U1
            // 
            this.U1.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U1.AppearanceCell.Options.UseFont = true;
            this.U1.AppearanceCell.Options.UseTextOptions = true;
            this.U1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U1.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U1.AppearanceHeader.Options.UseFont = true;
            this.U1.AppearanceHeader.Options.UseTextOptions = true;
            this.U1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U1.Caption = "领用人";
            this.U1.ColumnEdit = this.cmbPerson;
            this.U1.FieldName = "U1";
            this.U1.Name = "U1";
            this.U1.Visible = true;
            this.U1.VisibleIndex = 7;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceCell.Options.UseTextOptions = true;
            this.U2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.AppearanceHeader.Options.UseTextOptions = true;
            this.U2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.U2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.U2.Caption = "用途";
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.Visible = true;
            this.U2.VisibleIndex = 8;
            this.U2.Width = 287;
            // 
            // lupUser
            // 
            this.lupUser.AutoHeight = false;
            this.lupUser.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupUser.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("U1", 200, "领用人")});
            this.lupUser.Name = "lupUser";
            this.lupUser.NullText = "";
            this.lupUser.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lupUser.PopupWidth = 200;
            // 
            // cmbPerson
            // 
            this.cmbPerson.AutoHeight = false;
            this.cmbPerson.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPerson.Name = "cmbPerson";
            // 
            // WarehouseReceiptLibr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 401);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WarehouseReceiptLibr";
            this.Text = "辅料出库";
            this.Load += new System.EventHandler(this.WarehouseReceiptLibr_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . DateTimePicker dateTimePicker2;
        private DevExpress . XtraEditors . LabelControl labelControl13;
        private System . Windows . Forms . Button button7;
        private DevExpress . XtraGrid . GridControl gridControl2;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView2;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
        private DevExpress . XtraGrid . Columns . GridColumn WAR001;
        private DevExpress . XtraGrid . Columns . GridColumn WAR004;
        private DevExpress . XtraGrid . Columns . GridColumn WAR005;
        private DevExpress . XtraGrid . Columns . GridColumn U0;
        private DevExpress . XtraGrid . Columns . GridColumn WAR009;
        private DevExpress . XtraGrid . Columns . GridColumn U1;
        private DevExpress . XtraGrid . Columns . GridColumn U2;
        private DevExpress . XtraEditors . Repository . RepositoryItemLookUpEdit lupUser;
        private DevExpress . XtraGrid . Columns . GridColumn WAR006;
        private DevExpress . XtraGrid . Columns . GridColumn U3;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbUser;
        private DevExpress . XtraEditors . Repository . RepositoryItemComboBox cmbPerson;
    }
}