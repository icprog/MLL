namespace Mulaolao.Wages
{
    partial class R_FrmWagesContrastTable
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
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOne = new System.Windows.Forms.TabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.VZ002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ003 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ004 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ007 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ008 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ009 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VZ001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageTwo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageOne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tabPageTwo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1244, 490);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(457, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "按年统计";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(340, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 25);
            this.button3.TabIndex = 4;
            this.button3.Text = "删除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "刷新";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "生成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(60, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(112, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "日期";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOne);
            this.tabControl1.Controls.Add(this.tabPageTwo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1244, 444);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageOne
            // 
            this.tabPageOne.Controls.Add(this.gridControl1);
            this.tabPageOne.Location = new System.Drawing.Point(4, 26);
            this.tabPageOne.Name = "tabPageOne";
            this.tabPageOne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOne.Size = new System.Drawing.Size(1236, 414);
            this.tabPageOne.TabIndex = 0;
            this.tabPageOne.Text = "基本信息";
            this.tabPageOne.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1230, 408);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.ColumnPanelRowHeight = 25;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.VZ002,
            this.VZ003,
            this.VZ004,
            this.VZ005,
            this.VZ006,
            this.VZ007,
            this.VZ008,
            this.VZ009,
            this.VZ001});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // VZ002
            // 
            this.VZ002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ002.AppearanceCell.Options.UseFont = true;
            this.VZ002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ002.AppearanceHeader.Options.UseFont = true;
            this.VZ002.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ002.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ002.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ002.Caption = "结算月份";
            this.VZ002.FieldName = "VZ002";
            this.VZ002.Name = "VZ002";
            this.VZ002.Visible = true;
            this.VZ002.VisibleIndex = 0;
            this.VZ002.Width = 92;
            // 
            // VZ003
            // 
            this.VZ003.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ003.AppearanceCell.Options.UseFont = true;
            this.VZ003.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ003.AppearanceHeader.Options.UseFont = true;
            this.VZ003.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ003.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ003.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ003.Caption = "表号";
            this.VZ003.FieldName = "VZ003";
            this.VZ003.Name = "VZ003";
            this.VZ003.Visible = true;
            this.VZ003.VisibleIndex = 1;
            this.VZ003.Width = 98;
            // 
            // VZ004
            // 
            this.VZ004.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ004.AppearanceCell.Options.UseFont = true;
            this.VZ004.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ004.AppearanceHeader.Options.UseFont = true;
            this.VZ004.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ004.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ004.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ004.Caption = "本月考勤天数";
            this.VZ004.DisplayFormat.FormatString = "N1";
            this.VZ004.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ004.FieldName = "VZ004";
            this.VZ004.Name = "VZ004";
            this.VZ004.Visible = true;
            this.VZ004.VisibleIndex = 2;
            this.VZ004.Width = 146;
            // 
            // VZ005
            // 
            this.VZ005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ005.AppearanceCell.Options.UseFont = true;
            this.VZ005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ005.AppearanceHeader.Options.UseFont = true;
            this.VZ005.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ005.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ005.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ005.Caption = "本月已结天数";
            this.VZ005.DisplayFormat.FormatString = "N1";
            this.VZ005.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ005.FieldName = "VZ005";
            this.VZ005.Name = "VZ005";
            this.VZ005.Visible = true;
            this.VZ005.VisibleIndex = 3;
            this.VZ005.Width = 146;
            // 
            // VZ006
            // 
            this.VZ006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ006.AppearanceCell.Options.UseFont = true;
            this.VZ006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ006.AppearanceHeader.Options.UseFont = true;
            this.VZ006.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ006.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ006.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ006.Caption = "本月已结金额";
            this.VZ006.DisplayFormat.FormatString = "N0";
            this.VZ006.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ006.FieldName = "VZ006";
            this.VZ006.Name = "VZ006";
            this.VZ006.Visible = true;
            this.VZ006.VisibleIndex = 4;
            this.VZ006.Width = 146;
            // 
            // VZ007
            // 
            this.VZ007.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ007.AppearanceCell.Options.UseFont = true;
            this.VZ007.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ007.AppearanceHeader.Options.UseFont = true;
            this.VZ007.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ007.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ007.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ007.Caption = "累计考勤天数";
            this.VZ007.DisplayFormat.FormatString = "N1";
            this.VZ007.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ007.FieldName = "VZ007";
            this.VZ007.Name = "VZ007";
            this.VZ007.Visible = true;
            this.VZ007.VisibleIndex = 5;
            this.VZ007.Width = 146;
            // 
            // VZ008
            // 
            this.VZ008.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ008.AppearanceCell.Options.UseFont = true;
            this.VZ008.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ008.AppearanceHeader.Options.UseFont = true;
            this.VZ008.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ008.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ008.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ008.Caption = "累计已结天数";
            this.VZ008.DisplayFormat.FormatString = "N1";
            this.VZ008.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ008.FieldName = "VZ008";
            this.VZ008.Name = "VZ008";
            this.VZ008.Visible = true;
            this.VZ008.VisibleIndex = 6;
            this.VZ008.Width = 146;
            // 
            // VZ009
            // 
            this.VZ009.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ009.AppearanceCell.Options.UseFont = true;
            this.VZ009.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.VZ009.AppearanceHeader.Options.UseFont = true;
            this.VZ009.AppearanceHeader.Options.UseTextOptions = true;
            this.VZ009.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.VZ009.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.VZ009.Caption = "累计已结金额";
            this.VZ009.DisplayFormat.FormatString = "N0";
            this.VZ009.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VZ009.FieldName = "VZ009";
            this.VZ009.Name = "VZ009";
            this.VZ009.Visible = true;
            this.VZ009.VisibleIndex = 7;
            this.VZ009.Width = 158;
            // 
            // VZ001
            // 
            this.VZ001.Caption = "年";
            this.VZ001.FieldName = "VZ001";
            this.VZ001.Name = "VZ001";
            // 
            // tabPageTwo
            // 
            this.tabPageTwo.Controls.Add(this.label5);
            this.tabPageTwo.Controls.Add(this.label4);
            this.tabPageTwo.Controls.Add(this.label3);
            this.tabPageTwo.Controls.Add(this.label2);
            this.tabPageTwo.Location = new System.Drawing.Point(4, 26);
            this.tabPageTwo.Name = "tabPageTwo";
            this.tabPageTwo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTwo.Size = new System.Drawing.Size(1236, 414);
            this.tabPageTwo.TabIndex = 1;
            this.tabPageTwo.Text = "备注信息";
            this.tabPageTwo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(108, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "324、326备注(2017-1-18)：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(108, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "3、累计考勤按年累计";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(108, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "2、累计按照317结算月份";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(108, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "1、考勤按照317考勤月份";
            // 
            // R_FrmWagesContrastTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 490);
            this.Controls.Add(this.splitContainer1);
            this.Name = "R_FrmWagesContrastTable";
            this.Text = "工资考勤汇总对比表(R_326)";
            this.Load += new System.EventHandler(this.R_FrmWagesContrastTable_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOne.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tabPageTwo.ResumeLayout(false);
            this.tabPageTwo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn VZ002;
        private DevExpress.XtraGrid.Columns.GridColumn VZ003;
        private DevExpress.XtraGrid.Columns.GridColumn VZ004;
        private DevExpress.XtraGrid.Columns.GridColumn VZ005;
        private DevExpress.XtraGrid.Columns.GridColumn VZ006;
        private DevExpress.XtraGrid.Columns.GridColumn VZ007;
        private DevExpress.XtraGrid.Columns.GridColumn VZ008;
        private DevExpress.XtraGrid.Columns.GridColumn VZ009;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.Columns.GridColumn VZ001;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOne;
        private System.Windows.Forms.TabPage tabPageTwo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System . Windows . Forms . Label label6;
    }
}