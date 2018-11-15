namespace SelectAll
{
    partial class PeraggAll
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
            this.CA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA016 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CA017 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lupOdd = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lupUser = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lupYear = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.lupUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.lupYear);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.lupUser);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lupOdd);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.SplitterDistance = 45;
            // 
            // splitContainer2
            // 
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1122, 427);
            this.splitContainer2.SplitterDistance = 386;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1122, 386);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CA001,
            this.CA016,
            this.CA017});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // CA001
            // 
            this.CA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CA001.AppearanceCell.Options.UseFont = true;
            this.CA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA001.AppearanceHeader.Options.UseFont = true;
            this.CA001.Caption = "单号";
            this.CA001.FieldName = "CA001";
            this.CA001.Name = "CA001";
            this.CA001.Visible = true;
            this.CA001.VisibleIndex = 0;
            // 
            // CA016
            // 
            this.CA016.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA016.AppearanceCell.Options.UseFont = true;
            this.CA016.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA016.AppearanceHeader.Options.UseFont = true;
            this.CA016.Caption = "姓名";
            this.CA016.FieldName = "CA016";
            this.CA016.Name = "CA016";
            this.CA016.Visible = true;
            this.CA016.VisibleIndex = 1;
            // 
            // CA017
            // 
            this.CA017.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F);
            this.CA017.AppearanceCell.Options.UseFont = true;
            this.CA017.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F);
            this.CA017.AppearanceHeader.Options.UseFont = true;
            this.CA017.Caption = "年";
            this.CA017.FieldName = "CA017";
            this.CA017.Name = "CA017";
            this.CA017.Visible = true;
            this.CA017.VisibleIndex = 2;
            // 
            // lupOdd
            // 
            this.lupOdd.Location = new System.Drawing.Point(61, 11);
            this.lupOdd.Name = "lupOdd";
            this.lupOdd.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupOdd.Properties.Appearance.Options.UseFont = true;
            this.lupOdd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOdd.Properties.NullText = "";
            this.lupOdd.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupOdd.Properties.ShowHeader = false;
            this.lupOdd.Size = new System.Drawing.Size(222, 22);
            this.lupOdd.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "单号";
            // 
            // lupUser
            // 
            this.lupUser.Location = new System.Drawing.Point(365, 11);
            this.lupUser.Name = "lupUser";
            this.lupUser.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupUser.Properties.Appearance.Options.UseFont = true;
            this.lupUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupUser.Properties.NullText = "";
            this.lupUser.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupUser.Properties.ShowHeader = false;
            this.lupUser.Size = new System.Drawing.Size(86, 22);
            this.lupUser.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "姓名";
            // 
            // lupYear
            // 
            this.lupYear.Location = new System.Drawing.Point(534, 11);
            this.lupYear.Name = "lupYear";
            this.lupYear.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lupYear.Properties.Appearance.Options.UseFont = true;
            this.lupYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupYear.Properties.NullText = "";
            this.lupYear.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.lupYear.Properties.ShowHeader = false;
            this.lupYear.Size = new System.Drawing.Size(86, 22);
            this.lupYear.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "年";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(786, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 16;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PeraggAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 476);
            this.Name = "PeraggAll";
            this.Text = "PeraggAll";
            this.Load += new System.EventHandler(this.PeraggAll_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.lupUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CA001;
        private DevExpress . XtraGrid . Columns . GridColumn CA016;
        private DevExpress . XtraGrid . Columns . GridColumn CA017;
        private DevExpress . XtraEditors . LookUpEdit lupOdd;
        private System . Windows . Forms . Label label1;
        private DevExpress . XtraEditors . LookUpEdit lupUser;
        private System . Windows . Forms . Label label2;
        private DevExpress . XtraEditors . LookUpEdit lupYear;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . Button button2;
        private System . Windows . Forms . Button button1;
    }
}