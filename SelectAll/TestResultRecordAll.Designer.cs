namespace SelectAll
{
    partial class TestResultRecordAll
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
            this.CR001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CR002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CR004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CR003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CR006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CR011 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lupPer = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lupSup = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lupNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lupNum = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lupPro = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lupOdd = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.RES05 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupSup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.lupPer);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainer1.Panel1.Controls.Add(this.lupSup);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainer1.Panel1.Controls.Add(this.lupNo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.lupNum);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.lupPro);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1229, 476);
            this.splitContainer1.SplitterDistance = 68;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1229, 404);
            this.splitContainer2.SplitterDistance = 363;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(817, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1229, 363);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CR001,
            this.CR002,
            this.CR004,
            this.CR003,
            this.CR006,
            this.CR011,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // CR001
            // 
            this.CR001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR001.AppearanceCell.Options.UseFont = true;
            this.CR001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR001.AppearanceHeader.Options.UseFont = true;
            this.CR001.Caption = "单号";
            this.CR001.FieldName = "CR001";
            this.CR001.Name = "CR001";
            this.CR001.Visible = true;
            this.CR001.VisibleIndex = 0;
            // 
            // CR002
            // 
            this.CR002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR002.AppearanceCell.Options.UseFont = true;
            this.CR002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR002.AppearanceHeader.Options.UseFont = true;
            this.CR002.Caption = "产品名称";
            this.CR002.FieldName = "CR002";
            this.CR002.Name = "CR002";
            this.CR002.Visible = true;
            this.CR002.VisibleIndex = 1;
            // 
            // CR004
            // 
            this.CR004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR004.AppearanceCell.Options.UseFont = true;
            this.CR004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR004.AppearanceHeader.Options.UseFont = true;
            this.CR004.Caption = "流水号";
            this.CR004.FieldName = "CR004";
            this.CR004.Name = "CR004";
            this.CR004.Visible = true;
            this.CR004.VisibleIndex = 2;
            // 
            // CR003
            // 
            this.CR003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR003.AppearanceCell.Options.UseFont = true;
            this.CR003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR003.AppearanceHeader.Options.UseFont = true;
            this.CR003.Caption = "货号";
            this.CR003.FieldName = "CR003";
            this.CR003.Name = "CR003";
            this.CR003.Visible = true;
            this.CR003.VisibleIndex = 3;
            // 
            // CR006
            // 
            this.CR006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR006.AppearanceCell.Options.UseFont = true;
            this.CR006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR006.AppearanceHeader.Options.UseFont = true;
            this.CR006.Caption = "客户";
            this.CR006.FieldName = "CR006";
            this.CR006.Name = "CR006";
            this.CR006.Visible = true;
            this.CR006.VisibleIndex = 4;
            // 
            // CR011
            // 
            this.CR011.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR011.AppearanceCell.Options.UseFont = true;
            this.CR011.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CR011.AppearanceHeader.Options.UseFont = true;
            this.CR011.Caption = "检测人";
            this.CR011.FieldName = "CR011";
            this.CR011.Name = "CR011";
            this.CR011.Visible = true;
            this.CR011.VisibleIndex = 5;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(964, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 74;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1045, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 75;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupPer
            // 
            this.lupPer.Location = new System.Drawing.Point(324, 38);
            this.lupPer.Name = "lupPer";
            this.lupPer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPer.Properties.NullText = "";
            this.lupPer.Properties.PopupWidth = 100;
            this.lupPer.Properties.ShowHeader = false;
            this.lupPer.Size = new System.Drawing.Size(175, 20);
            this.lupPer.TabIndex = 73;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(267, 39);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(51, 16);
            this.labelControl6.TabIndex = 72;
            this.labelControl6.Text = "检测人";
            // 
            // lupSup
            // 
            this.lupSup.Location = new System.Drawing.Point(59, 38);
            this.lupSup.Name = "lupSup";
            this.lupSup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupSup.Properties.NullText = "";
            this.lupSup.Properties.PopupWidth = 100;
            this.lupSup.Properties.ShowHeader = false;
            this.lupSup.Size = new System.Drawing.Size(175, 20);
            this.lupSup.TabIndex = 71;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(19, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(34, 16);
            this.labelControl5.TabIndex = 70;
            this.labelControl5.Text = "客户";
            // 
            // lupNo
            // 
            this.lupNo.Location = new System.Drawing.Point(783, 13);
            this.lupNo.Name = "lupNo";
            this.lupNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNo.Properties.NullText = "";
            this.lupNo.Properties.PopupWidth = 100;
            this.lupNo.Properties.ShowHeader = false;
            this.lupNo.Size = new System.Drawing.Size(175, 20);
            this.lupNo.TabIndex = 69;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(743, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 68;
            this.labelControl3.Text = "货号";
            // 
            // lupNum
            // 
            this.lupNum.Location = new System.Drawing.Point(562, 13);
            this.lupNum.Name = "lupNum";
            this.lupNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNum.Properties.NullText = "";
            this.lupNum.Properties.PopupWidth = 100;
            this.lupNum.Properties.ShowHeader = false;
            this.lupNum.Size = new System.Drawing.Size(175, 20);
            this.lupNum.TabIndex = 67;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(505, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "流水号";
            // 
            // lupPro
            // 
            this.lupPro.Location = new System.Drawing.Point(324, 13);
            this.lupPro.Name = "lupPro";
            this.lupPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPro.Properties.NullText = "";
            this.lupPro.Properties.PopupWidth = 100;
            this.lupPro.Properties.ShowHeader = false;
            this.lupPro.Size = new System.Drawing.Size(175, 20);
            this.lupPro.TabIndex = 65;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(250, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 16);
            this.labelControl4.TabIndex = 64;
            this.labelControl4.Text = "产品名称";
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(59, 12);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.PopupWidth = 100;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(175, 20);
            this.lupOdd.TabIndex = 63;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 16);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "单号";
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
            this.RES05.VisibleIndex = 6;
            // 
            // TestResultRecordAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 476);
            this.Name = "TestResultRecordAll";
            this.Text = "TestResultRecordAll";
            this.Load += new System.EventHandler(this.TestResultRecordAll_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lupPer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupSup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CR001;
        private DevExpress . XtraGrid . Columns . GridColumn CR002;
        private DevExpress . XtraGrid . Columns . GridColumn CR004;
        private DevExpress . XtraGrid . Columns . GridColumn CR003;
        private DevExpress . XtraGrid . Columns . GridColumn CR006;
        private DevExpress . XtraGrid . Columns . GridColumn CR011;
        private System . Windows . Forms . Button btnQuery;
        private System . Windows . Forms . Button btnClear;
        private DevExpress . XtraEditors . LookUpEdit lupPer;
        private DevExpress . XtraEditors . LabelControl labelControl6;
        private DevExpress . XtraEditors . LookUpEdit lupSup;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . LookUpEdit lupNo;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LookUpEdit lupNum;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LookUpEdit lupPro;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private DevExpress . XtraEditors . LookUpEdit lupOdd;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraGrid . Columns . GridColumn RES05;
    }
}