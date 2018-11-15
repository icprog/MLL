namespace SelectAll
{
    partial class ContractreviewQuery
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
            this.lupNum = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lupProName = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lupCon = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lupWork = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.lupName = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.PQF01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HT64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HT02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HT04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DFA003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HT66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF67 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PQF32 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupCon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.btnOk);
            this.splitContainer1.Panel1.Controls.Add(this.lupName);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.lupWork);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lupCon);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lupProName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lupNum);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1243, 479);
            this.splitContainer1.SplitterDistance = 60;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1243, 415);
            this.splitContainer2.SplitterDistance = 374;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(826, 37);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1243, 374);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.HT64,
            this.PQF01,
            this.PQF04,
            this.HT02,
            this.HT04,
            this.DFA003,
            this.HT66,
            this.PQF67,
            this.PQF31,
            this.PQF32,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // lupNum
            // 
            this.lupNum.Location = new System.Drawing.Point(77, 6);
            this.lupNum.Name = "lupNum";
            this.lupNum.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupNum.Properties.Appearance.Options.UseFont = true;
            this.lupNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNum.Properties.NullText = "";
            this.lupNum.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupNum.Properties.ShowHeader = false;
            this.lupNum.Size = new System.Drawing.Size(154, 22);
            this.lupNum.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "流水号";
            // 
            // lupProName
            // 
            this.lupProName.Location = new System.Drawing.Point(319, 6);
            this.lupProName.Name = "lupProName";
            this.lupProName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupProName.Properties.Appearance.Options.UseFont = true;
            this.lupProName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProName.Properties.NullText = "";
            this.lupProName.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupProName.Properties.ShowHeader = false;
            this.lupProName.Size = new System.Drawing.Size(154, 22);
            this.lupProName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "产品名称";
            // 
            // lupCon
            // 
            this.lupCon.Location = new System.Drawing.Point(544, 6);
            this.lupCon.Name = "lupCon";
            this.lupCon.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupCon.Properties.Appearance.Options.UseFont = true;
            this.lupCon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupCon.Properties.NullText = "";
            this.lupCon.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupCon.Properties.ShowHeader = false;
            this.lupCon.Size = new System.Drawing.Size(154, 22);
            this.lupCon.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(479, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "合同号";
            // 
            // lupWork
            // 
            this.lupWork.Location = new System.Drawing.Point(786, 6);
            this.lupWork.Name = "lupWork";
            this.lupWork.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupWork.Properties.Appearance.Options.UseFont = true;
            this.lupWork.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupWork.Properties.NullText = "";
            this.lupWork.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupWork.Properties.ShowHeader = false;
            this.lupWork.Size = new System.Drawing.Size(154, 22);
            this.lupWork.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(704, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "生产车间";
            // 
            // lupName
            // 
            this.lupName.Location = new System.Drawing.Point(77, 34);
            this.lupName.Name = "lupName";
            this.lupName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupName.Properties.Appearance.Options.UseFont = true;
            this.lupName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupName.Properties.NullText = "";
            this.lupName.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupName.Properties.ShowHeader = false;
            this.lupName.Size = new System.Drawing.Size(154, 22);
            this.lupName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "业务员";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1053, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 25);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(972, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "查询";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // PQF01
            // 
            this.PQF01.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceCell.Options.UseFont = true;
            this.PQF01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF01.AppearanceHeader.Options.UseFont = true;
            this.PQF01.Caption = "流水号";
            this.PQF01.FieldName = "PQF01";
            this.PQF01.Name = "PQF01";
            this.PQF01.Visible = true;
            this.PQF01.VisibleIndex = 1;
            this.PQF01.Width = 86;
            // 
            // PQF04
            // 
            this.PQF04.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceCell.Options.UseFont = true;
            this.PQF04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF04.AppearanceHeader.Options.UseFont = true;
            this.PQF04.Caption = "产品名称";
            this.PQF04.FieldName = "PQF04";
            this.PQF04.Name = "PQF04";
            this.PQF04.Visible = true;
            this.PQF04.VisibleIndex = 2;
            this.PQF04.Width = 86;
            // 
            // HT64
            // 
            this.HT64.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT64.AppearanceCell.Options.UseFont = true;
            this.HT64.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT64.AppearanceHeader.Options.UseFont = true;
            this.HT64.Caption = "单号";
            this.HT64.FieldName = "HT64";
            this.HT64.Name = "HT64";
            this.HT64.Visible = true;
            this.HT64.VisibleIndex = 0;
            this.HT64.Width = 114;
            // 
            // HT02
            // 
            this.HT02.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT02.AppearanceCell.Options.UseFont = true;
            this.HT02.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT02.AppearanceHeader.Options.UseFont = true;
            this.HT02.Caption = "合同号";
            this.HT02.FieldName = "HT02";
            this.HT02.Name = "HT02";
            this.HT02.Visible = true;
            this.HT02.VisibleIndex = 3;
            this.HT02.Width = 86;
            // 
            // HT04
            // 
            this.HT04.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT04.AppearanceCell.Options.UseFont = true;
            this.HT04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT04.AppearanceHeader.Options.UseFont = true;
            this.HT04.Caption = "合同评审日期";
            this.HT04.FieldName = "HT04";
            this.HT04.Name = "HT04";
            this.HT04.Visible = true;
            this.HT04.VisibleIndex = 4;
            this.HT04.Width = 115;
            // 
            // DFA003
            // 
            this.DFA003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DFA003.AppearanceCell.Options.UseFont = true;
            this.DFA003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.DFA003.AppearanceHeader.Options.UseFont = true;
            this.DFA003.Caption = "客户";
            this.DFA003.FieldName = "DFA003";
            this.DFA003.Name = "DFA003";
            this.DFA003.Visible = true;
            this.DFA003.VisibleIndex = 5;
            this.DFA003.Width = 151;
            // 
            // HT66
            // 
            this.HT66.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT66.AppearanceCell.Options.UseFont = true;
            this.HT66.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.HT66.AppearanceHeader.Options.UseFont = true;
            this.HT66.Caption = "生产车间";
            this.HT66.FieldName = "HT66";
            this.HT66.Name = "HT66";
            this.HT66.Visible = true;
            this.HT66.VisibleIndex = 6;
            // 
            // PQF67
            // 
            this.PQF67.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF67.AppearanceCell.Options.UseFont = true;
            this.PQF67.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF67.AppearanceHeader.Options.UseFont = true;
            this.PQF67.Caption = "业务员姓名";
            this.PQF67.FieldName = "PQF67";
            this.PQF67.Name = "PQF67";
            this.PQF67.Visible = true;
            this.PQF67.VisibleIndex = 7;
            this.PQF67.Width = 85;
            // 
            // PQF31
            // 
            this.PQF31.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF31.AppearanceCell.Options.UseFont = true;
            this.PQF31.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF31.AppearanceHeader.Options.UseFont = true;
            this.PQF31.Caption = "合同交货日期";
            this.PQF31.FieldName = "PQF31";
            this.PQF31.Name = "PQF31";
            this.PQF31.Visible = true;
            this.PQF31.VisibleIndex = 8;
            this.PQF31.Width = 100;
            // 
            // PQF32
            // 
            this.PQF32.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF32.AppearanceCell.Options.UseFont = true;
            this.PQF32.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.PQF32.AppearanceHeader.Options.UseFont = true;
            this.PQF32.Caption = "输入ERP日期";
            this.PQF32.FieldName = "PQF32";
            this.PQF32.Name = "PQF32";
            this.PQF32.Visible = true;
            this.PQF32.VisibleIndex = 9;
            this.PQF32.Width = 94;
            // 
            // RES05
            // 
            this.RES05.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceCell.Options.UseFont = true;
            this.RES05.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.RES05.AppearanceHeader.Options.UseFont = true;
            this.RES05.Caption = "执行状态";
            this.RES05.FieldName = "RES05";
            this.RES05.Name = "RES05";
            this.RES05.Visible = true;
            this.RES05.VisibleIndex = 10;
            this.RES05.Width = 86;
            // 
            // ContractreviewQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 479);
            this.Name = "ContractreviewQuery";
            this.Text = "ContractreviewQuery";
            this.Load += new System.EventHandler(this.ContractreviewQuery_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupCon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraEditors . LookUpEdit lupNum;
        private System . Windows . Forms . Label label1;
        private DevExpress . XtraEditors . LookUpEdit lupCon;
        private System . Windows . Forms . Label label3;
        private DevExpress . XtraEditors . LookUpEdit lupProName;
        private System . Windows . Forms . Label label2;
        private DevExpress . XtraEditors . LookUpEdit lupWork;
        private System . Windows . Forms . Label label4;
        private DevExpress . XtraEditors . LookUpEdit lupName;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . Button btnClear;
        private System . Windows . Forms . Button btnOk;
        private DevExpress . XtraGrid . Columns . GridColumn HT64;
        private DevExpress . XtraGrid . Columns . GridColumn PQF01;
        private DevExpress . XtraGrid . Columns . GridColumn PQF04;
        private DevExpress . XtraGrid . Columns . GridColumn HT02;
        private DevExpress . XtraGrid . Columns . GridColumn HT04;
        private DevExpress . XtraGrid . Columns . GridColumn DFA003;
        private DevExpress . XtraGrid . Columns . GridColumn HT66;
        private DevExpress . XtraGrid . Columns . GridColumn PQF67;
        private DevExpress . XtraGrid . Columns . GridColumn PQF31;
        private DevExpress . XtraGrid . Columns . GridColumn PQF32;
        private DevExpress . XtraGrid . Columns . GridColumn RES05;
    }
}