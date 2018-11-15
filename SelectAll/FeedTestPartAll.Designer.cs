namespace SelectAll
{
    partial class FeedTestPartAll
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
            this.ONE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TWO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TAB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idx = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(988, 414);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_KeyPress);
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TAB,
            this.idx,
            this.ONE,
            this.TWO,
            this.TRE});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ONE
            // 
            this.ONE.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ONE.AppearanceCell.Options.UseFont = true;
            this.ONE.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.ONE.AppearanceHeader.Options.UseFont = true;
            this.ONE.Caption = "零件名称";
            this.ONE.FieldName = "ONE";
            this.ONE.Name = "ONE";
            this.ONE.Visible = true;
            this.ONE.VisibleIndex = 2;
            this.ONE.Width = 267;
            // 
            // TWO
            // 
            this.TWO.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TWO.AppearanceCell.Options.UseFont = true;
            this.TWO.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TWO.AppearanceHeader.Options.UseFont = true;
            this.TWO.Caption = "零件规格";
            this.TWO.FieldName = "TWO";
            this.TWO.Name = "TWO";
            this.TWO.Visible = true;
            this.TWO.VisibleIndex = 3;
            this.TWO.Width = 267;
            // 
            // TRE
            // 
            this.TRE.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TRE.AppearanceCell.Options.UseFont = true;
            this.TRE.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TRE.AppearanceHeader.Options.UseFont = true;
            this.TRE.Caption = "零件数量";
            this.TRE.FieldName = "TRE";
            this.TRE.Name = "TRE";
            this.TRE.Visible = true;
            this.TRE.VisibleIndex = 4;
            this.TRE.Width = 275;
            // 
            // TAB
            // 
            this.TAB.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TAB.AppearanceCell.Options.UseFont = true;
            this.TAB.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            this.TAB.AppearanceHeader.Options.UseFont = true;
            this.TAB.Caption = "表";
            this.TAB.FieldName = "TAB";
            this.TAB.Name = "TAB";
            this.TAB.Visible = true;
            this.TAB.VisibleIndex = 1;
            this.TAB.Width = 126;
            // 
            // idx
            // 
            this.idx.Caption = "编号";
            this.idx.FieldName = "idx";
            this.idx.Name = "idx";
            // 
            // FeedTestPartAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 414);
            this.Controls.Add(this.gridControl1);
            this.Name = "FeedTestPartAll";
            this.Text = "FeedTestPartAll";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn ONE;
        private DevExpress . XtraGrid . Columns . GridColumn TWO;
        private DevExpress . XtraGrid . Columns . GridColumn TRE;
        private DevExpress . XtraGrid . Columns . GridColumn TAB;
        private DevExpress . XtraGrid . Columns . GridColumn idx;
    }
}