namespace Mulaolao . Contract
{
    partial class FormContCheckTable
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.cmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CP03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CP01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RES04 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.U2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 25);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.cmb);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.dateEdit1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1229, 425);
            this.splitContainerControl1.SplitterPosition = 43;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // cmb
            // 
            this.cmb.Location = new System.Drawing.Point(212, 12);
            this.cmb.Name = "cmb";
            this.cmb.Properties.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb.Properties.Appearance.Options.UseFont = true;
            this.cmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb.Size = new System.Drawing.Size(173, 20);
            this.cmb.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(178, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "合同";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(32, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "yyyy";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.EditFormat.FormatString = "yyyy";
            this.dateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "yyyy";
            this.dateEdit1.Size = new System.Drawing.Size(115, 20);
            this.dateEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "年";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1229, 377);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CP03,
            this.CP01,
            this.RES04,
            this.AK,
            this.EA005,
            this.U2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // CP03
            // 
            this.CP03.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CP03.AppearanceCell.Options.UseFont = true;
            this.CP03.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CP03.AppearanceHeader.Options.UseFont = true;
            this.CP03.Caption = "合同单号";
            this.CP03.FieldName = "CP03";
            this.CP03.Name = "CP03";
            this.CP03.Visible = true;
            this.CP03.VisibleIndex = 0;
            this.CP03.Width = 202;
            // 
            // CP01
            // 
            this.CP01.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CP01.AppearanceCell.Options.UseFont = true;
            this.CP01.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.CP01.AppearanceHeader.Options.UseFont = true;
            this.CP01.Caption = "流水号";
            this.CP01.FieldName = "CP01";
            this.CP01.Name = "CP01";
            this.CP01.Visible = true;
            this.CP01.VisibleIndex = 1;
            this.CP01.Width = 202;
            // 
            // RES04
            // 
            this.RES04.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RES04.AppearanceCell.Options.UseFont = true;
            this.RES04.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.RES04.AppearanceHeader.Options.UseFont = true;
            this.RES04.Caption = "执行时间";
            this.RES04.FieldName = "RES04";
            this.RES04.Name = "RES04";
            this.RES04.OptionsColumn.AllowEdit = false;
            this.RES04.Visible = true;
            this.RES04.VisibleIndex = 3;
            this.RES04.Width = 227;
            // 
            // AK
            // 
            this.AK.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AK.AppearanceCell.Options.UseFont = true;
            this.AK.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.AK.AppearanceHeader.Options.UseFont = true;
            this.AK.Caption = "结账状态";
            this.AK.FieldName = "AK";
            this.AK.Name = "AK";
            this.AK.OptionsColumn.AllowEdit = false;
            this.AK.Visible = true;
            this.AK.VisibleIndex = 4;
            this.AK.Width = 198;
            // 
            // EA005
            // 
            this.EA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EA005.AppearanceCell.Options.UseFont = true;
            this.EA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.EA005.AppearanceHeader.Options.UseFont = true;
            this.EA005.Caption = "是否打印";
            this.EA005.FieldName = "EA005";
            this.EA005.Name = "EA005";
            this.EA005.Visible = true;
            this.EA005.VisibleIndex = 5;
            this.EA005.Width = 141;
            // 
            // U2
            // 
            this.U2.AppearanceCell.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceCell.Options.UseFont = true;
            this.U2.AppearanceHeader.Font = new System.Drawing.Font("宋体", 10.5F);
            this.U2.AppearanceHeader.Options.UseFont = true;
            this.U2.Caption = "结算款";
            this.U2.FieldName = "U2";
            this.U2.Name = "U2";
            this.U2.OptionsColumn.AllowEdit = false;
            this.U2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U2", "{0:N2}")});
            this.U2.Visible = true;
            this.U2.VisibleIndex = 2;
            this.U2.Width = 125;
            // 
            // FormContCheckTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 450);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "FormContCheckTable";
            this.Text = "采购合同结账状况表(R_513)";
            this.Load += new System.EventHandler(this.FormContCheckTable_Load);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraEditors . SplitContainerControl splitContainerControl1;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn CP03;
        private DevExpress . XtraGrid . Columns . GridColumn RES04;
        private DevExpress . XtraGrid . Columns . GridColumn AK;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . DateEdit dateEdit1;
        private DevExpress . XtraGrid . Columns . GridColumn CP01;
        private DevExpress . XtraGrid . Columns . GridColumn EA005;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private DevExpress . XtraEditors . ComboBoxEdit cmb;
        private DevExpress . XtraGrid . Columns . GridColumn U2;
    }
}