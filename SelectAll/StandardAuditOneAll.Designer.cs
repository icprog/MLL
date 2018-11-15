namespace SelectAll
{
    partial class StandardAuditOneAll
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
            this.CB001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CB003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CB002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CB009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupOdd = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lupPro = new DevExpress.XtraEditors.LookUpEdit();
            this.lupNum = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lupUser = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnClear);
            this.splitContainer1.Panel1.Controls.Add(this.lupUser);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.lupNum);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.lupPro);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1253, 486);
            this.splitContainer1.SplitterDistance = 39;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1253, 443);
            this.splitContainer2.SplitterDistance = 412;
            // 
            // userControl11
            // 
            this.userControl11.Size = new System.Drawing.Size(833, 27);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1253, 412);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CB001,
            this.CB003,
            this.CB002,
            this.CB009,
            this.RES05});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // CB001
            // 
            this.CB001.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB001.AppearanceCell.Options.UseFont = true;
            this.CB001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB001.AppearanceHeader.Options.UseFont = true;
            this.CB001.Caption = "单号";
            this.CB001.FieldName = "CB001";
            this.CB001.Name = "CB001";
            this.CB001.Visible = true;
            this.CB001.VisibleIndex = 0;
            // 
            // CB003
            // 
            this.CB003.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB003.AppearanceCell.Options.UseFont = true;
            this.CB003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB003.AppearanceHeader.Options.UseFont = true;
            this.CB003.Caption = "产品名称";
            this.CB003.FieldName = "CB003";
            this.CB003.Name = "CB003";
            this.CB003.Visible = true;
            this.CB003.VisibleIndex = 1;
            // 
            // CB002
            // 
            this.CB002.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB002.AppearanceCell.Options.UseFont = true;
            this.CB002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB002.AppearanceHeader.Options.UseFont = true;
            this.CB002.Caption = "流水号";
            this.CB002.FieldName = "CB002";
            this.CB002.Name = "CB002";
            this.CB002.Visible = true;
            this.CB002.VisibleIndex = 2;
            // 
            // CB009
            // 
            this.CB009.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB009.AppearanceCell.Options.UseFont = true;
            this.CB009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.CB009.AppearanceHeader.Options.UseFont = true;
            this.CB009.Caption = "报审人";
            this.CB009.FieldName = "CB009";
            this.CB009.Name = "CB009";
            this.CB009.Visible = true;
            this.CB009.VisibleIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "单号";
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(52, 11);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.PopupWidth = 100;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(175, 20);
            this.lupOdd.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(252, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "产品名称";
            // 
            // lupPro
            // 
            this.lupPro.Location = new System.Drawing.Point(326, 11);
            this.lupPro.Name = "lupPro";
            this.lupPro.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupPro.Properties.NullText = "";
            this.lupPro.Properties.PopupWidth = 100;
            this.lupPro.Properties.ShowHeader = false;
            this.lupPro.Size = new System.Drawing.Size(175, 20);
            this.lupPro.TabIndex = 4;
            // 
            // lupNum
            // 
            this.lupNum.Location = new System.Drawing.Point(593, 11);
            this.lupNum.Name = "lupNum";
            this.lupNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupNum.Properties.NullText = "";
            this.lupNum.Properties.PopupWidth = 100;
            this.lupNum.Properties.ShowHeader = false;
            this.lupNum.Size = new System.Drawing.Size(175, 20);
            this.lupNum.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(536, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "流水号";
            // 
            // lupUser
            // 
            this.lupUser.Location = new System.Drawing.Point(853, 11);
            this.lupUser.Name = "lupUser";
            this.lupUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupUser.Properties.NullText = "";
            this.lupUser.Properties.PopupWidth = 100;
            this.lupUser.Properties.ShowHeader = false;
            this.lupUser.Size = new System.Drawing.Size(175, 20);
            this.lupUser.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(796, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(51, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "报审人";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1115, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(1034, 8);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 9;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
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
            this.RES05.VisibleIndex = 4;
            // 
            // StandardAuditOneAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 486);
            this.Name = "StandardAuditOneAll";
            this.Text = "StandardAuditOneAll";
            this.Load += new System.EventHandler(this.StandardAuditOneAll_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lupOdd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupPro.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CB001;
        private DevExpress . XtraGrid . Columns . GridColumn CB003;
        private DevExpress . XtraGrid . Columns . GridColumn CB002;
        private DevExpress . XtraGrid . Columns . GridColumn CB009;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LookUpEdit lupOdd;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . LookUpEdit lupNum;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LookUpEdit lupPro;
        private DevExpress . XtraEditors . LookUpEdit lupUser;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private System . Windows . Forms . Button btnQuery;
        private System . Windows . Forms . Button btnClear;
        private DevExpress . XtraGrid . Columns . GridColumn RES05;
    }
}