namespace SelectAll
{
    partial class TestResultRecordOneAll
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
            this.CV001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CV002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CV004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CV003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CV006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CV009 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.splitContainer1.Size = new System.Drawing.Size(1247, 476);
            this.splitContainer1.SplitterDistance = 68;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1247, 404);
            this.splitContainer2.SplitterDistance = 363;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(829, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1247, 363);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CV001,
            this.CV002,
            this.CV004,
            this.CV003,
            this.CV006,
            this.CV009,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // CV001
            // 
            this.CV001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV001.AppearanceCell.Options.UseFont = true;
            this.CV001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV001.AppearanceHeader.Options.UseFont = true;
            this.CV001.Caption = "单号";
            this.CV001.FieldName = "CV001";
            this.CV001.Name = "CV001";
            this.CV001.Visible = true;
            this.CV001.VisibleIndex = 0;
            // 
            // CV002
            // 
            this.CV002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV002.AppearanceCell.Options.UseFont = true;
            this.CV002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV002.AppearanceHeader.Options.UseFont = true;
            this.CV002.Caption = "产品名称";
            this.CV002.FieldName = "CV002";
            this.CV002.Name = "CV002";
            this.CV002.Visible = true;
            this.CV002.VisibleIndex = 1;
            // 
            // CV004
            // 
            this.CV004.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV004.AppearanceCell.Options.UseFont = true;
            this.CV004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV004.AppearanceHeader.Options.UseFont = true;
            this.CV004.Caption = "流水号";
            this.CV004.FieldName = "CV004";
            this.CV004.Name = "CV004";
            this.CV004.Visible = true;
            this.CV004.VisibleIndex = 2;
            // 
            // CV003
            // 
            this.CV003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV003.AppearanceCell.Options.UseFont = true;
            this.CV003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV003.AppearanceHeader.Options.UseFont = true;
            this.CV003.Caption = "货号";
            this.CV003.FieldName = "CV003";
            this.CV003.Name = "CV003";
            this.CV003.Visible = true;
            this.CV003.VisibleIndex = 3;
            // 
            // CV006
            // 
            this.CV006.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV006.AppearanceCell.Options.UseFont = true;
            this.CV006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV006.AppearanceHeader.Options.UseFont = true;
            this.CV006.Caption = "合同号";
            this.CV006.FieldName = "CV006";
            this.CV006.Name = "CV006";
            this.CV006.Visible = true;
            this.CV006.VisibleIndex = 4;
            // 
            // CV009
            // 
            this.CV009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV009.AppearanceCell.Options.UseFont = true;
            this.CV009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CV009.AppearanceHeader.Options.UseFont = true;
            this.CV009.Caption = "QC主管";
            this.CV009.FieldName = "CV009";
            this.CV009.Name = "CV009";
            this.CV009.Visible = true;
            this.CV009.VisibleIndex = 5;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(980, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 88;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1061, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 89;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lupPer
            // 
            this.lupPer.Location = new System.Drawing.Point(340, 38);
            this.lupPer.Name = "lupPer";
            this.lupPer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPer.Properties.NullText = "";
            this.lupPer.Properties.PopupWidth = 100;
            this.lupPer.Properties.ShowHeader = false;
            this.lupPer.Size = new System.Drawing.Size(175, 20);
            this.lupPer.TabIndex = 87;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(282, 39);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 16);
            this.labelControl6.TabIndex = 86;
            this.labelControl6.Text = "QC主管";
            // 
            // lupSup
            // 
            this.lupSup.Location = new System.Drawing.Point(75, 38);
            this.lupSup.Name = "lupSup";
            this.lupSup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupSup.Properties.NullText = "";
            this.lupSup.Properties.PopupWidth = 100;
            this.lupSup.Properties.ShowHeader = false;
            this.lupSup.Size = new System.Drawing.Size(175, 20);
            this.lupSup.TabIndex = 85;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(18, 39);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 16);
            this.labelControl5.TabIndex = 84;
            this.labelControl5.Text = "合同号";
            // 
            // lupNo
            // 
            this.lupNo.Location = new System.Drawing.Point(799, 13);
            this.lupNo.Name = "lupNo";
            this.lupNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNo.Properties.NullText = "";
            this.lupNo.Properties.PopupWidth = 100;
            this.lupNo.Properties.ShowHeader = false;
            this.lupNo.Size = new System.Drawing.Size(175, 20);
            this.lupNo.TabIndex = 83;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(759, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 16);
            this.labelControl3.TabIndex = 82;
            this.labelControl3.Text = "货号";
            // 
            // lupNum
            // 
            this.lupNum.Location = new System.Drawing.Point(578, 13);
            this.lupNum.Name = "lupNum";
            this.lupNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNum.Properties.NullText = "";
            this.lupNum.Properties.PopupWidth = 100;
            this.lupNum.Properties.ShowHeader = false;
            this.lupNum.Size = new System.Drawing.Size(175, 20);
            this.lupNum.TabIndex = 81;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(521, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 80;
            this.labelControl2.Text = "流水号";
            // 
            // lupPro
            // 
            this.lupPro.Location = new System.Drawing.Point(340, 13);
            this.lupPro.Name = "lupPro";
            this.lupPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPro.Properties.NullText = "";
            this.lupPro.Properties.PopupWidth = 100;
            this.lupPro.Properties.ShowHeader = false;
            this.lupPro.Size = new System.Drawing.Size(175, 20);
            this.lupPro.TabIndex = 79;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(266, 14);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(68, 16);
            this.labelControl4.TabIndex = 78;
            this.labelControl4.Text = "产品名称";
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(75, 12);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.PopupWidth = 100;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(175, 20);
            this.lupOdd.TabIndex = 77;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(35, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 16);
            this.labelControl1.TabIndex = 76;
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
            // TestResultRecordOneAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 476);
            this.Name = "TestResultRecordOneAll";
            this.Text = "TestResultRecordOneAll";
            this.Load += new System.EventHandler(this.TestResultRecordOneAll_Load);
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
        private DevExpress . XtraGrid . Columns . GridColumn CV001;
        private DevExpress . XtraGrid . Columns . GridColumn CV002;
        private DevExpress . XtraGrid . Columns . GridColumn CV004;
        private DevExpress . XtraGrid . Columns . GridColumn CV003;
        private DevExpress . XtraGrid . Columns . GridColumn CV006;
        private DevExpress . XtraGrid . Columns . GridColumn CV009;
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