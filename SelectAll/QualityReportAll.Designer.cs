namespace SelectAll
{
    partial class QualityReportAll
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
            this.DK001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DK003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DK002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DK004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RES05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DK008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DK038 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lupNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lupNum = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lupPro = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lupOdd = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.DK006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDK006 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.View1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDK006.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.lupNo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.lupNum);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.lupPro);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.txtDK006);
            this.splitContainer1.Size = new System.Drawing.Size(1228, 476);
            this.splitContainer1.SplitterDistance = 68;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1228, 404);
            this.splitContainer2.SplitterDistance = 363;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(816, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1228, 363);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DK001,
            this.DK003,
            this.DK002,
            this.DK004,
            this.RES05,
            this.DK008,
            this.DK038,
            this.DK006});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // DK001
            // 
            this.DK001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK001.AppearanceCell.Options.UseFont = true;
            this.DK001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK001.AppearanceHeader.Options.UseFont = true;
            this.DK001.Caption = "单号";
            this.DK001.FieldName = "DK001";
            this.DK001.Name = "DK001";
            this.DK001.Visible = true;
            this.DK001.VisibleIndex = 0;
            this.DK001.Width = 143;
            // 
            // DK003
            // 
            this.DK003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK003.AppearanceCell.Options.UseFont = true;
            this.DK003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK003.AppearanceHeader.Options.UseFont = true;
            this.DK003.Caption = "产品名称";
            this.DK003.FieldName = "DK003";
            this.DK003.Name = "DK003";
            this.DK003.Visible = true;
            this.DK003.VisibleIndex = 1;
            this.DK003.Width = 143;
            // 
            // DK002
            // 
            this.DK002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK002.AppearanceCell.Options.UseFont = true;
            this.DK002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK002.AppearanceHeader.Options.UseFont = true;
            this.DK002.Caption = "流水号";
            this.DK002.FieldName = "DK002";
            this.DK002.Name = "DK002";
            this.DK002.Visible = true;
            this.DK002.VisibleIndex = 2;
            this.DK002.Width = 143;
            // 
            // DK004
            // 
            this.DK004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK004.AppearanceCell.Options.UseFont = true;
            this.DK004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK004.AppearanceHeader.Options.UseFont = true;
            this.DK004.Caption = "货号";
            this.DK004.FieldName = "DK004";
            this.DK004.Name = "DK004";
            this.DK004.Visible = true;
            this.DK004.VisibleIndex = 3;
            this.DK004.Width = 143;
            // 
            // RES05
            // 
            this.RES05.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceCell.Options.UseFont = true;
            this.RES05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceHeader.Options.UseFont = true;
            this.RES05.Caption = "执行";
            this.RES05.FieldName = "RES05";
            this.RES05.Name = "RES05";
            this.RES05.Visible = true;
            this.RES05.VisibleIndex = 7;
            this.RES05.Width = 70;
            // 
            // DK008
            // 
            this.DK008.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK008.AppearanceCell.Options.UseFont = true;
            this.DK008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK008.AppearanceHeader.Options.UseFont = true;
            this.DK008.Caption = "生产车间";
            this.DK008.FieldName = "DK008";
            this.DK008.Name = "DK008";
            this.DK008.Visible = true;
            this.DK008.VisibleIndex = 4;
            this.DK008.Width = 143;
            // 
            // DK038
            // 
            this.DK038.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK038.AppearanceCell.Options.UseFont = true;
            this.DK038.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK038.AppearanceHeader.Options.UseFont = true;
            this.DK038.Caption = "客户意见";
            this.DK038.FieldName = "DK038";
            this.DK038.Name = "DK038";
            this.DK038.Visible = true;
            this.DK038.VisibleIndex = 5;
            this.DK038.Width = 192;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(974, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 82;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1055, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 83;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupNo
            // 
            this.lupNo.Location = new System.Drawing.Point(793, 13);
            this.lupNo.Name = "lupNo";
            this.lupNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNo.Properties.NullText = "";
            this.lupNo.Properties.PopupWidth = 100;
            this.lupNo.Properties.ShowHeader = false;
            this.lupNo.Size = new System.Drawing.Size(175, 20);
            this.lupNo.TabIndex = 81;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(753, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 80;
            this.labelControl3.Text = "货号";
            // 
            // lupNum
            // 
            this.lupNum.Location = new System.Drawing.Point(572, 13);
            this.lupNum.Name = "lupNum";
            this.lupNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNum.Properties.NullText = "";
            this.lupNum.Properties.PopupWidth = 100;
            this.lupNum.Properties.ShowHeader = false;
            this.lupNum.Size = new System.Drawing.Size(175, 20);
            this.lupNum.TabIndex = 79;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(515, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 78;
            this.labelControl2.Text = "流水号";
            // 
            // lupPro
            // 
            this.lupPro.Location = new System.Drawing.Point(334, 13);
            this.lupPro.Name = "lupPro";
            this.lupPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPro.Properties.NullText = "";
            this.lupPro.Properties.PopupWidth = 100;
            this.lupPro.Properties.ShowHeader = false;
            this.lupPro.Size = new System.Drawing.Size(175, 20);
            this.lupPro.TabIndex = 77;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(260, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 16);
            this.labelControl4.TabIndex = 76;
            this.labelControl4.Text = "产品名称";
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(69, 12);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.PopupWidth = 100;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(175, 20);
            this.lupOdd.TabIndex = 75;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(29, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 16);
            this.labelControl1.TabIndex = 74;
            this.labelControl1.Text = "单号";
            // 
            // DK006
            // 
            this.DK006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK006.AppearanceCell.Options.UseFont = true;
            this.DK006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DK006.AppearanceHeader.Options.UseFont = true;
            this.DK006.Caption = "业务员";
            this.DK006.FieldName = "DK006";
            this.DK006.Name = "DK006";
            this.DK006.Visible = true;
            this.DK006.VisibleIndex = 6;
            this.DK006.Width = 98;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 16);
            this.labelControl5.TabIndex = 84;
            this.labelControl5.Text = "业务员";
            // 
            // txtDK006
            // 
            this.txtDK006.Location = new System.Drawing.Point(69, 38);
            this.txtDK006.Name = "txtDK006";
            this.txtDK006.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.txtDK006.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDK006.Properties.NullText = "";
            this.txtDK006.Properties.PopupFormSize = new System.Drawing.Size(100, 0);
            this.txtDK006.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.txtDK006.Properties.View = this.View1;
            this.txtDK006.Size = new System.Drawing.Size(175, 20);
            this.txtDK006.TabIndex = 85;
            // 
            // View1
            // 
            this.View1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.View1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.View1.Name = "View1";
            this.View1.OptionsBehavior.Editable = false;
            this.View1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.View1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "业务员";
            this.gridColumn1.FieldName = "DK006";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // QualityReportAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 476);
            this.Name = "QualityReportAll";
            this.Text = "QualityReportAll";
            this.Load += new System.EventHandler(this.QualityReportAll_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDK006.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn DK001;
        private DevExpress . XtraGrid . Columns . GridColumn DK003;
        private DevExpress . XtraGrid . Columns . GridColumn DK002;
        private DevExpress . XtraGrid . Columns . GridColumn DK004;
        private System . Windows . Forms . Button btnQuery;
        private System . Windows . Forms . Button btnClear;
        private DevExpress . XtraEditors . LookUpEdit lupNo;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LookUpEdit lupNum;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LookUpEdit lupPro;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LookUpEdit lupOdd;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraGrid . Columns . GridColumn RES05;
        private DevExpress . XtraGrid . Columns . GridColumn DK008;
        private DevExpress . XtraGrid . Columns . GridColumn DK038;
        private DevExpress . XtraGrid . Columns . GridColumn DK006;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . SearchLookUpEdit txtDK006;
        private DevExpress . XtraGrid . Views . Grid . GridView View1;
        private DevExpress . XtraGrid . Columns . GridColumn gridColumn1;
    }
}