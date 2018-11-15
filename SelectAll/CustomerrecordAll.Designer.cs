namespace SelectAll
{
    partial class CustomerrecordAll
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
            this.KH01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH05 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KH03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lupOddNum = new DevExpress.XtraEditors.LookUpEdit();
            this.lupKH02 = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lupKH05 = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lupKH04 = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lupKH03 = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH02.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH05.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH04.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH03.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.lupKH03);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lupKH04);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lupKH05);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lupKH02);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lupOddNum);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1245, 476);
            this.splitContainer1.SplitterDistance = 68;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1245, 404);
            this.splitContainer2.SplitterDistance = 363;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(827, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1245, 363);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KH01,
            this.KH02,
            this.KH05,
            this.KH04,
            this.KH03});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // KH01
            // 
            this.KH01.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KH01.AppearanceCell.Options.UseFont = true;
            this.KH01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KH01.AppearanceHeader.Options.UseFont = true;
            this.KH01.Caption = "单号";
            this.KH01.FieldName = "KH01";
            this.KH01.Name = "KH01";
            this.KH01.Visible = true;
            this.KH01.VisibleIndex = 0;
            // 
            // KH02
            // 
            this.KH02.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KH02.AppearanceCell.Options.UseFont = true;
            this.KH02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.KH02.AppearanceHeader.Options.UseFont = true;
            this.KH02.Caption = "样品名称";
            this.KH02.FieldName = "KH02";
            this.KH02.Name = "KH02";
            this.KH02.Visible = true;
            this.KH02.VisibleIndex = 1;
            // 
            // KH05
            // 
            this.KH05.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KH05.AppearanceCell.Options.UseFont = true;
            this.KH05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.KH05.AppearanceHeader.Options.UseFont = true;
            this.KH05.Caption = "产品名称";
            this.KH05.FieldName = "KH05";
            this.KH05.Name = "KH05";
            this.KH05.Visible = true;
            this.KH05.VisibleIndex = 2;
            // 
            // KH04
            // 
            this.KH04.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KH04.AppearanceCell.Options.UseFont = true;
            this.KH04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.KH04.AppearanceHeader.Options.UseFont = true;
            this.KH04.Caption = "产品货号";
            this.KH04.FieldName = "KH04";
            this.KH04.Name = "KH04";
            this.KH04.Visible = true;
            this.KH04.VisibleIndex = 3;
            // 
            // KH03
            // 
            this.KH03.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KH03.AppearanceCell.Options.UseFont = true;
            this.KH03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.KH03.AppearanceHeader.Options.UseFont = true;
            this.KH03.Caption = "合同号";
            this.KH03.FieldName = "KH03";
            this.KH03.Name = "KH03";
            this.KH03.Visible = true;
            this.KH03.VisibleIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "单号";
            // 
            // lupOddNum
            // 
            this.lupOddNum.Location = new System.Drawing.Point(76, 11);
            this.lupOddNum.Name = "lupOddNum";
            this.lupOddNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupOddNum.Properties.Appearance.Options.UseFont = true;
            this.lupOddNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOddNum.Properties.NullText = "";
            this.lupOddNum.Properties.ShowHeader = false;
            this.lupOddNum.Size = new System.Drawing.Size(196, 20);
            this.lupOddNum.TabIndex = 1;
            // 
            // lupKH02
            // 
            this.lupKH02.Location = new System.Drawing.Point(360, 11);
            this.lupKH02.Name = "lupKH02";
            this.lupKH02.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupKH02.Properties.Appearance.Options.UseFont = true;
            this.lupKH02.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupKH02.Properties.NullText = "";
            this.lupKH02.Properties.ShowHeader = false;
            this.lupKH02.Size = new System.Drawing.Size(136, 20);
            this.lupKH02.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "样品名称";
            // 
            // lupKH05
            // 
            this.lupKH05.Location = new System.Drawing.Point(584, 11);
            this.lupKH05.Name = "lupKH05";
            this.lupKH05.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupKH05.Properties.Appearance.Options.UseFont = true;
            this.lupKH05.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupKH05.Properties.NullText = "";
            this.lupKH05.Properties.ShowHeader = false;
            this.lupKH05.Size = new System.Drawing.Size(136, 20);
            this.lupKH05.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "产品名称";
            // 
            // lupKH04
            // 
            this.lupKH04.Location = new System.Drawing.Point(808, 11);
            this.lupKH04.Name = "lupKH04";
            this.lupKH04.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupKH04.Properties.Appearance.Options.UseFont = true;
            this.lupKH04.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupKH04.Properties.NullText = "";
            this.lupKH04.Properties.ShowHeader = false;
            this.lupKH04.Size = new System.Drawing.Size(136, 20);
            this.lupKH04.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(726, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "产品货号";
            // 
            // lupKH03
            // 
            this.lupKH03.Location = new System.Drawing.Point(76, 37);
            this.lupKH03.Name = "lupKH03";
            this.lupKH03.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lupKH03.Properties.Appearance.Options.UseFont = true;
            this.lupKH03.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupKH03.Properties.NullText = "";
            this.lupKH03.Properties.ShowHeader = false;
            this.lupKH03.Size = new System.Drawing.Size(136, 20);
            this.lupKH03.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "合同号";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(950, 9);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 76;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1031, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 77;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // CustomerrecordAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 476);
            this.Name = "CustomerrecordAll";
            this.Text = "CustomerrecordAll";
            this.Load += new System.EventHandler(this.CustomerrecordAll_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lupOddNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH02.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH05.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH04.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupKH03.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn KH01;
        private DevExpress . XtraGrid . Columns . GridColumn KH02;
        private DevExpress . XtraGrid . Columns . GridColumn KH05;
        private DevExpress . XtraGrid . Columns . GridColumn KH04;
        private DevExpress . XtraGrid . Columns . GridColumn KH03;
        private System . Windows . Forms . Label label1;
        private DevExpress . XtraEditors . LookUpEdit lupOddNum;
        private DevExpress . XtraEditors . LookUpEdit lupKH02;
        private System . Windows . Forms . Label label2;
        private DevExpress . XtraEditors . LookUpEdit lupKH05;
        private System . Windows . Forms . Label label3;
        private DevExpress . XtraEditors . LookUpEdit lupKH04;
        private System . Windows . Forms . Label label4;
        private DevExpress . XtraEditors . LookUpEdit lupKH03;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . Button btnQuery;
        private System . Windows . Forms . Button btnClear;
    }
}