namespace Mulaolao . Base
{
    partial class FormUserInfo
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
            this.label3 = new System.Windows.Forms.Label();
            this.glUser = new System.Windows.Forms.ComboBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.Sex = new System.Windows.Forms.ComboBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.Tel = new System.Windows.Forms.TextBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.departNum = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.departName = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.userName = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.userNum = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.TabPageOne = new DevExpress.XtraTab.XtraTabPage();
            this.TabPageTwo = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DBA001 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA005 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DAA002 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA960 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA961 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA028 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA006 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DBA043 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.departName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.TabPageOne.SuspendLayout();
            this.TabPageTwo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1040, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 72);
            this.label3.TabIndex = 96;
            this.label3.Text = "注\r\n\r\n销";
            // 
            // glUser
            // 
            this.glUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.glUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.glUser.FormattingEnabled = true;
            this.glUser.Location = new System.Drawing.Point(804, 64);
            this.glUser.Name = "glUser";
            this.glUser.Size = new System.Drawing.Size(116, 22);
            this.glUser.TabIndex = 15;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(702, 67);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(96, 16);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "是否管理人员";
            // 
            // Sex
            // 
            this.Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Sex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Sex.FormattingEnabled = true;
            this.Sex.Location = new System.Drawing.Point(544, 21);
            this.Sex.Name = "Sex";
            this.Sex.Size = new System.Drawing.Size(95, 22);
            this.Sex.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(496, 67);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(32, 16);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "组号";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(496, 24);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 16);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "性别";
            // 
            // Tel
            // 
            this.Tel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tel.Location = new System.Drawing.Point(804, 21);
            this.Tel.Name = "Tel";
            this.Tel.Size = new System.Drawing.Size(116, 26);
            this.Tel.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(750, 24);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "手机号";
            // 
            // departNum
            // 
            this.departNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departNum.Location = new System.Drawing.Point(328, 64);
            this.departNum.Name = "departNum";
            this.departNum.ReadOnly = true;
            this.departNum.Size = new System.Drawing.Size(116, 26);
            this.departNum.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(258, 67);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "部门编号";
            // 
            // departName
            // 
            this.departName.Location = new System.Drawing.Point(328, 21);
            this.departName.Name = "departName";
            this.departName.Properties.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departName.Properties.Appearance.Options.UseFont = true;
            this.departName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.departName.Properties.NullText = "";
            this.departName.Properties.ShowHeader = false;
            this.departName.Size = new System.Drawing.Size(116, 22);
            this.departName.TabIndex = 5;
            this.departName.EditValueChanged += new System.EventHandler(this.departName_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(258, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "部门名称";
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(107, 64);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(116, 26);
            this.userName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(37, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "用户姓名";
            // 
            // userNum
            // 
            this.userNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNum.Location = new System.Drawing.Point(107, 21);
            this.userNum.Name = "userNum";
            this.userNum.ReadOnly = true;
            this.userNum.Size = new System.Drawing.Size(116, 26);
            this.userNum.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(37, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户编号";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 25);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.TabPageOne;
            this.xtraTabControl1.Size = new System.Drawing.Size(1203, 432);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.TabPageOne,
            this.TabPageTwo});
            // 
            // TabPageOne
            // 
            this.TabPageOne.Appearance.Header.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.TabPageOne.Appearance.Header.Options.UseFont = true;
            this.TabPageOne.Controls.Add(this.textBox1);
            this.TabPageOne.Controls.Add(this.label3);
            this.TabPageOne.Controls.Add(this.labelControl1);
            this.TabPageOne.Controls.Add(this.glUser);
            this.TabPageOne.Controls.Add(this.userNum);
            this.TabPageOne.Controls.Add(this.labelControl8);
            this.TabPageOne.Controls.Add(this.labelControl2);
            this.TabPageOne.Controls.Add(this.userName);
            this.TabPageOne.Controls.Add(this.Sex);
            this.TabPageOne.Controls.Add(this.labelControl3);
            this.TabPageOne.Controls.Add(this.labelControl7);
            this.TabPageOne.Controls.Add(this.departName);
            this.TabPageOne.Controls.Add(this.labelControl6);
            this.TabPageOne.Controls.Add(this.labelControl4);
            this.TabPageOne.Controls.Add(this.Tel);
            this.TabPageOne.Controls.Add(this.departNum);
            this.TabPageOne.Controls.Add(this.labelControl5);
            this.TabPageOne.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabPageOne.Name = "TabPageOne";
            this.TabPageOne.Size = new System.Drawing.Size(1197, 401);
            this.TabPageOne.Text = "基础信息";
            // 
            // TabPageTwo
            // 
            this.TabPageTwo.Appearance.Header.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabPageTwo.Appearance.Header.Options.UseFont = true;
            this.TabPageTwo.Controls.Add(this.gridControl1);
            this.TabPageTwo.Name = "TabPageTwo";
            this.TabPageTwo.Size = new System.Drawing.Size(1197, 401);
            this.TabPageTwo.Text = "详细信息";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1197, 401);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DBA001,
            this.DBA002,
            this.DBA005,
            this.DAA002,
            this.DBA960,
            this.DBA961,
            this.DBA028,
            this.DBA006,
            this.DBA043});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // DBA001
            // 
            this.DBA001.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA001.AppearanceCell.Options.UseFont = true;
            this.DBA001.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA001.AppearanceHeader.Options.UseFont = true;
            this.DBA001.Caption = "用户编号";
            this.DBA001.FieldName = "DBA001";
            this.DBA001.Name = "DBA001";
            this.DBA001.Visible = true;
            this.DBA001.VisibleIndex = 0;
            this.DBA001.Width = 125;
            // 
            // DBA002
            // 
            this.DBA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA002.AppearanceCell.Options.UseFont = true;
            this.DBA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA002.AppearanceHeader.Options.UseFont = true;
            this.DBA002.Caption = "用户姓名";
            this.DBA002.FieldName = "DBA002";
            this.DBA002.Name = "DBA002";
            this.DBA002.Visible = true;
            this.DBA002.VisibleIndex = 1;
            this.DBA002.Width = 125;
            // 
            // DBA005
            // 
            this.DBA005.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA005.AppearanceCell.Options.UseFont = true;
            this.DBA005.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA005.AppearanceHeader.Options.UseFont = true;
            this.DBA005.Caption = "部门编号";
            this.DBA005.FieldName = "DBA005";
            this.DBA005.Name = "DBA005";
            this.DBA005.Visible = true;
            this.DBA005.VisibleIndex = 2;
            this.DBA005.Width = 125;
            // 
            // DAA002
            // 
            this.DAA002.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DAA002.AppearanceCell.Options.UseFont = true;
            this.DAA002.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DAA002.AppearanceHeader.Options.UseFont = true;
            this.DAA002.Caption = "部门姓名";
            this.DAA002.FieldName = "DAA002";
            this.DAA002.Name = "DAA002";
            this.DAA002.Visible = true;
            this.DAA002.VisibleIndex = 3;
            this.DAA002.Width = 125;
            // 
            // DBA960
            // 
            this.DBA960.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA960.AppearanceCell.Options.UseFont = true;
            this.DBA960.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA960.AppearanceHeader.Options.UseFont = true;
            this.DBA960.Caption = "性别";
            this.DBA960.FieldName = "DBA960";
            this.DBA960.Name = "DBA960";
            this.DBA960.Visible = true;
            this.DBA960.VisibleIndex = 4;
            this.DBA960.Width = 125;
            // 
            // DBA961
            // 
            this.DBA961.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA961.AppearanceCell.Options.UseFont = true;
            this.DBA961.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA961.AppearanceHeader.Options.UseFont = true;
            this.DBA961.Caption = "组号";
            this.DBA961.FieldName = "DBA961";
            this.DBA961.Name = "DBA961";
            this.DBA961.Visible = true;
            this.DBA961.VisibleIndex = 5;
            this.DBA961.Width = 125;
            // 
            // DBA028
            // 
            this.DBA028.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA028.AppearanceCell.Options.UseFont = true;
            this.DBA028.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA028.AppearanceHeader.Options.UseFont = true;
            this.DBA028.Caption = "手机号";
            this.DBA028.FieldName = "DBA028";
            this.DBA028.Name = "DBA028";
            this.DBA028.Visible = true;
            this.DBA028.VisibleIndex = 6;
            this.DBA028.Width = 152;
            // 
            // DBA006
            // 
            this.DBA006.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA006.AppearanceCell.Options.UseFont = true;
            this.DBA006.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA006.AppearanceHeader.Options.UseFont = true;
            this.DBA006.Caption = "是否管理人员";
            this.DBA006.FieldName = "DBA006";
            this.DBA006.Name = "DBA006";
            this.DBA006.Visible = true;
            this.DBA006.VisibleIndex = 7;
            this.DBA006.Width = 123;
            // 
            // DBA043
            // 
            this.DBA043.AppearanceCell.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA043.AppearanceCell.Options.UseFont = true;
            this.DBA043.AppearanceHeader.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.DBA043.AppearanceHeader.Options.UseFont = true;
            this.DBA043.Caption = "注销";
            this.DBA043.FieldName = "DBA043";
            this.DBA043.Name = "DBA043";
            this.DBA043.Visible = true;
            this.DBA043.VisibleIndex = 8;
            this.DBA043.Width = 53;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(544, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(95, 26);
            this.textBox1.TabIndex = 97;
            // 
            // FormUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 457);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormUserInfo";
            this.Text = "人员信息(R_003)";
            this.Load += new System.EventHandler(this.FormUserInfo_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.departName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.TabPageOne.ResumeLayout(false);
            this.TabPageOne.PerformLayout();
            this.TabPageTwo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System . Windows . Forms . TextBox userName;
        private DevExpress . XtraEditors . LabelControl labelControl2;
        private System . Windows . Forms . TextBox userNum;
        private DevExpress . XtraEditors . LabelControl labelControl1;
        private DevExpress . XtraEditors . LabelControl labelControl3;
        private DevExpress . XtraEditors . LookUpEdit departName;
        private System . Windows . Forms . TextBox departNum;
        private DevExpress . XtraEditors . LabelControl labelControl4;
        private System . Windows . Forms . TextBox Tel;
        private DevExpress . XtraEditors . LabelControl labelControl5;
        private DevExpress . XtraEditors . LabelControl labelControl6;
        private DevExpress . XtraEditors . LabelControl labelControl7;
        private System . Windows . Forms . ComboBox Sex;
        private System . Windows . Forms . ComboBox glUser;
        private DevExpress . XtraEditors . LabelControl labelControl8;
        private System . Windows . Forms . Label label3;
        private DevExpress . XtraTab . XtraTabControl xtraTabControl1;
        private DevExpress . XtraTab . XtraTabPage TabPageOne;
        private DevExpress . XtraTab . XtraTabPage TabPageTwo;
        private DevExpress . XtraGrid . GridControl gridControl1;
        private DevExpress . XtraGrid . Views . Grid . GridView gridView1;
        private DevExpress . XtraGrid . Columns . GridColumn DBA001;
        private DevExpress . XtraGrid . Columns . GridColumn DBA002;
        private DevExpress . XtraGrid . Columns . GridColumn DBA005;
        private DevExpress . XtraGrid . Columns . GridColumn DAA002;
        private DevExpress . XtraGrid . Columns . GridColumn DBA960;
        private DevExpress . XtraGrid . Columns . GridColumn DBA961;
        private DevExpress . XtraGrid . Columns . GridColumn DBA028;
        private DevExpress . XtraGrid . Columns . GridColumn DBA006;
        private DevExpress . XtraGrid . Columns . GridColumn DBA043;
        private System . Windows . Forms . TextBox textBox1;
    }
}