using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using FastReport;
using FastReport . Export . Xml;

namespace Mulaolao . Wages
{
    public partial class R_FrmManagePayroll : FormChild
    {
        public R_FrmManagePayroll ( )
        {
            InitializeComponent ( );
            
            this . textBox18 . KeyPress += new KeyPressEventHandler ( this . textBox18_KeyPress );
            this . textBox18 . TextChanged += new EventHandler ( this . textBox18_TextChanged );
            this . textBox18 . LostFocus += new EventHandler ( this . textBox18_LostFocus );
            this . textBox19 . KeyPress += new KeyPressEventHandler ( this . textBox19_KeyPress );
            this . textBox19 . TextChanged += new EventHandler ( this . textBox19_TextChanged );
            this . textBox19 . LostFocus += new EventHandler ( this . textBox19_LostFocus );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ManagePayrollLibrary _model = new MulaolaoLibrary.ManagePayrollLibrary( );
        MulaolaoBll.Bll.ManagePayrollBll _bll = new MulaolaoBll.Bll.ManagePayrollBll( );
        DataTable tableQuery;DataRow row;
        string sign = "", weihu = "", strWhere = "1=1", file = "", strPrintWhere = "";
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        Report report = new Report( );
        DataSet RDataSet = new DataSet( ); EcanRMB rmb = new EcanRMB( );
        int num = 0;
        
        private void R_FrmManagePayroll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GridViewMoHuSelect . SetFilter ( gridView3 );
            GridViewMoHuSelect . SetFilter ( gridView4 );
            Power ( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageFor ,tabPageFiv } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
            label45.Visible =label44.Visible= false;

            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "行政" ,"生产部" } );

            DataTable de= _bll.GetDataTablePersonInCharge( );
            lookUpEdit2.Properties.DataSource = de;
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            lookUpEdit4.Properties.DataSource = de.Copy( );
            lookUpEdit4.Properties.DisplayMember = "DBA002";
            lookUpEdit4.Properties.ValueMember = "DBA001";

            comboBox2.DataSource = _bll.GetDataTableCompany( );
            comboBox2.DisplayMember = "XZ003";
        }

        private void R_FrmManagePayroll_Shown ( object sender ,EventArgs e )
        {
            _model.XZ001 = Merges.oddNum;
            if ( _model.XZ001 != null && _model.XZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print
        void CreatePrint ( string strPrintWhere )
        {
            DataTable print = _bll.GetDataTablePrint( _model.XZ001 ,strPrintWhere );
            DataTable prints = _bll.GetDataTableExport( _model.XZ001 ,strPrintWhere );
            if ( prints != null && prints.Rows.Count > 0 )
            {
                if ( !string.IsNullOrEmpty( prints.Rows[0]["U3"].ToString( ) ) )
                    report.SetParameterValue( "大写合计" ,rmb.CmycurD( Convert.ToDecimal( prints.Rows[0]["U3"].ToString( ) ) ) );
            }
            print.TableName = "R_PQXZ";
            prints.TableName = "R_PQXZS";
            RDataSet.Tables.Clear( );
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        #endregion

        #region Event
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox1 );
        }
        private void textBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1.Text != "" && !DateDayRegise.eightTwoNumber( textBox1 ) )
            {
                textBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多五位,小数部分最多两位,如99999.99,请重新输入" );
            }
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox2 );
        }
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox2 );
        }
        private void textBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox2.Text != "" && !DateDayRegise.fiveTwoNum( textBox2 ) )
            {
                textBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox3 );
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3.Text != "" && !DateDayRegise.fiveTwoNum( textBox3 ) )
            {
                textBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox4 );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDayRegise.sixTwoNumber( textBox4 ) )
            {
                textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox5 );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox5 );
        }
        private void textBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox5.Text != "" && !DateDayRegise.sixTwoNumber( textBox5 ) )
            {
                textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox6 );
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox6 );
        }
        private void textBox6_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox6.Text != "" && !DateDayRegise.sixTwoNumber( textBox6 ) )
            {
                textBox6.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox7 );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox7 );
        }
        private void textBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox7.Text != "" && !DateDayRegise.sixTwoNumber( textBox7 ) )
            {
                textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox12 );
        }
        private void textBox12_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox12 );
        }
        private void textBox12_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox12.Text != "" && !DateDayRegise.sevenTwo( textBox12 ) )
            {
                textBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox17 );
        }
        private void textBox17_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox17 );
        }
        private void textBox17_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox17 . Text != "" && !DateDayRegise . sevenTwo ( textBox17 ) )
            {
                textBox17 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox13 );
        }
        private void textBox13_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox13 );
        }
        private void textBox13_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox13.Text != "" && !DateDayRegise.sevenTwo( textBox13 ) )
            {
                textBox13.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox14 );
        }
        private void textBox14_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox14 );
        }
        private void textBox14_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox14.Text != "" && !DateDayRegise.sevenTwo( textBox14 ) )
            {
                textBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox18 );
        }
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox18 );
        }
        private void textBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox18 . Text != "" && !DateDayRegise . eighteenSixNumber ( textBox18 ) )
            {
                textBox18 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多八位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox19 );
        }
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox19 );
        }
        private void textBox19_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox19 . Text != "" && !DateDayRegise . eighteenSixNumber ( textBox19 ) )
            {
                textBox19 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多八位,小数部分最多两位,如9999.99,请重新输入" );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.DataRowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        string category = "", personInCharge = "", company = "", names = "";
        void assignMent ( )
        {
            _model = _bll . GetModel ( _model . IDX );
            if ( _model == null )
                return;
            lookUpEdit2 . Text = _model . XZ002;
            comboBox2 . Text = _model . XZ003;
            lookUpEdit4 . Text = _model . XZ004;
            textBox1 . Text = _model . XZ005 . ToString ( );
            textBox2 . Text = _model . XZ006 . ToString ( );
            textBox3 . Text = _model . XZ007 . ToString ( );
            textBox4 . Text = _model . XZ008 . ToString ( );
            textBox5 . Text = _model . XZ009 . ToString ( );
            textBox6 . Text = _model . XZ010 . ToString ( );
            textBox7 . Text = _model . XZ011 . ToString ( );
            if ( _model . XZ013 > DateTime . MinValue && _model . XZ013 < DateTime . MaxValue )
                dateTimePicker1 . Value = _model . XZ013;
            textBox12 . Text = _model . XZ021 . ToString ( );
            textBox13 . Text = _model . XZ023 . ToString ( );
            textBox14 . Text = _model . XZ024 . ToString ( );
            comboBox1 . Text = _model . XZ014;
            textBox15 . Text = _model . XZ027;
            textBox16 . Text = _model . XZ028;
            textBox17 . Text = _model . XZ029 . ToString ( );
            textBox18 . Text = _model . XZ030 . ToString ( "f2" );
            textBox19 . Text = _model . XZ031 . ToString ( "f2" );
            checkBox1 . Checked = _model . XZ032;
            category = comboBox1 . Text;
            personInCharge = lookUpEdit2 . Text;
            company = comboBox2 . Text;
            names = lookUpEdit4 . Text;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
            textBox8.Enabled = false;
            sign = "1";

            _model.XZ001 = oddNumbers.purchaseContract( "SELECT MAX(XZ001) XZ001 FROM R_PQXZ" ,"XZ001" ,"R_050-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单据已执行,需要总经理删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            result = _bll.Delete( _model.XZ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除成功" );
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                label45.Visible =label44.Visible= false;
            }
            else
                MessageBox.Show( "删除失败,请重试" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible == true )
                MessageBox.Show( "单据已执行,请维护" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox8.Enabled = false;
            }
        }
        protected override void save ( )
        {
            base.save( );

            _model.XZ017 = textBox9.Text;
            _model.XZ018 = textBox10.Text;
            _model.XZ019 = textBox11.Text;
            _model . XZ020 = dateTimePicker2 . Value;
            _model . XZ013 = dateTimePicker1 . Value;
            DataTable da = _bll.GetDataTableOfWeiHu( _model.XZ001 );
            if ( weihu == "1" )
            {
                if ( da != null && da.Rows.Count > 0 )
                    _model.XZ015 = da.Rows[0]["XZ015"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                else
                    _model.XZ015 = "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                _model.XZ016 = textBox8.Text;
                saveUp( );
            }
            else
            {
                _model.XZ015 = _model.XZ016 = "";
                saveUp( );
            }
        }
        void saveState ( )
        {
            sign = "";
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled =  toolLibrary.Enabled = toolStorage.Enabled = false;
            label44.Visible = false;
        }
        void saveUp ( )
        {
            result = _bll.Update( _model );
            if ( result == true )
            {
                MessageBox.Show( "保存数据成功" );
                saveState( );
            }
            else
                MessageBox.Show( "保存数据失败" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );          
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                sign = weihu = "";
                label45.Visible =label44.Visible= false;
                gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
                try
                {
                    _bll.Delete( _model.XZ001 );
                }
                catch { }
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "XZ001" ,_model.XZ001 ,"R_PQXZ" ,this ,"" ,"R_050" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = sp.reviewImple( "R_050" ,_model.XZ001 );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                Ergodic.TablePageEnableTrue( pageList );
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据状态为非执行,请更改" );
        }
        protected override void print ( )
        {
            base.print( );

            if ( label45.Visible == true )
            {
                strPrintWhere = "1=1";
                file = "";
                file = Application.StartupPath + "\\R_050.frx";
                report.Load( file );
                if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                    strPrintWhere = "1=1";
                else if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
                    strPrintWhere = strPrintWhere + " AND XZ014='行政' AND XZ028='1'";
                else if ( tabControl1.SelectedTab.Name == "tabPageTre" )
                    strPrintWhere = strPrintWhere + " AND XZ014='生产部' AND XZ028='1'";
                else if ( tabControl1.SelectedTab.Name == "tabPageSix" )
                    strPrintWhere = strPrintWhere + " AND XZ028='2'";
                CreatePrint( strPrintWhere );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不允许打印" );
        }
        protected override void export ( )
        {
            base.export( );

            strPrintWhere = "1=1";
            file = "";
            file = Application.StartupPath + "\\R_050.frx";
            report.Load( file );
            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                strPrintWhere = "1=1";
            else if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
                strPrintWhere = strPrintWhere + " AND XZ014='行政' AND XZ028='1'";
            else if ( tabControl1.SelectedTab.Name == "tabPageTre" )
                strPrintWhere = strPrintWhere + " AND XZ014='生产部' AND XZ028='1'";
            else if ( tabControl1.SelectedTab.Name == "tabPageSix" )
                strPrintWhere = strPrintWhere + " AND XZ028='2'";
            CreatePrint( strPrintWhere );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void copys ( )
        {
            base.copys( );
            
            result = _bll.Copy( _model.XZ001 );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                _model.XZ001 = oddNumbers.purchaseContract( "SELECT MAX(XZ001) XZ001 FROM R_PQXZ" ,"XZ001" ,"R_050-" );
                result = _bll.UpdateOfCopy( _model.XZ001 );
                if ( result == false )
                {
                    MessageBox.Show( "复制数据失败,请重试" );
                    _bll.DeleteOfCopy( );
                }
                else
                {
                    MessageBox.Show( "复制数据成功" );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    sign = "1";
                    weihu = "";
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    gridControl1.DataSource = gridControl2.DataSource = gridControl3.DataSource = null;
                    label45.Visible = false;
                    textBox8.Enabled = false;
                    label44.Visible = true;
                    queryContent( );
                }
            }
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model . XZ002 = lookUpEdit2 . Text;
            _model . XZ003 = comboBox2 . Text;
            _model . XZ004 = lookUpEdit4 . Text;
            _model . XZ005 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToDecimal ( textBox1 . Text );
            _model . XZ006 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            _model . XZ007 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );
            _model . XZ008 = string . IsNullOrEmpty ( textBox4 . Text ) == true ? 0 : Convert . ToDecimal ( textBox4 . Text );
            _model . XZ009 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToDecimal ( textBox5 . Text );
            _model . XZ010 = string . IsNullOrEmpty ( textBox6 . Text ) == true ? 0 : Convert . ToDecimal ( textBox6 . Text );
            _model . XZ011 = string . IsNullOrEmpty ( textBox7 . Text ) == true ? 0 : Convert . ToDecimal ( textBox7 . Text );
            _model . XZ012 = "";
            _model . XZ013 = dateTimePicker1 . Value;
            _model . XZ014 = comboBox1 . Text;
            _model . XZ021 = string . IsNullOrEmpty ( textBox12 . Text ) == true ? 0 : Convert . ToDecimal ( textBox12 . Text );
            _model . XZ023 = string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text );
            _model . XZ024 = string . IsNullOrEmpty ( textBox14 . Text ) == true ? 0 : Convert . ToDecimal ( textBox14 . Text );
            _model . XZ027 = textBox15 . Text;
            _model . XZ028 = textBox16 . Text;
            _model . XZ029 = string . IsNullOrEmpty ( textBox17 . Text ) == true ? 0 : Convert . ToDecimal ( textBox17 . Text );
            _model . XZ030 = string . IsNullOrEmpty ( textBox18 . Text ) == true ? 0 : Convert . ToDecimal ( textBox18 . Text );
            _model . XZ031 = string . IsNullOrEmpty ( textBox19 . Text ) == true ? 0 : Convert . ToDecimal ( textBox19 . Text );
            _model . XZ032 = checkBox1 . Checked;
        }
        void rowEdit ( )
        {
            row [ "XZ002" ] = _model . XZ002;
            row [ "XZ003" ] = _model . XZ003;
            row [ "XZ004" ] = _model . XZ004;
            row [ "XZ005" ] = _model . XZ005;
            row [ "XZ006" ] = _model . XZ006;
            row [ "XZ007" ] = _model . XZ007;
            row [ "XZ008" ] = _model . XZ008;
            row [ "XZ009" ] = _model . XZ009;
            row [ "XZ010" ] = _model . XZ010;
            row [ "XZ011" ] = _model . XZ011;
            row [ "XZ012" ] = _model . XZ012;
            row [ "XZ013" ] = _model . XZ013;
            row [ "XZ014" ] = _model . XZ014;
            row [ "XZ021" ] = _model . XZ021;
            row [ "XZ023" ] = _model . XZ023;
            row [ "XZ024" ] = _model . XZ024;
            row [ "XZ027" ] = _model . XZ027;
            row [ "XZ028" ] = _model . XZ028;
            row [ "XZ029" ] = _model . XZ029;
            row [ "XZ030" ] = _model . XZ030;
            row [ "XZ031" ] = _model . XZ031;
            row [ "XZ032" ] = _model . XZ032;
        }
        //Add
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "考核类别不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit2.Text ) )
            {
                MessageBox.Show( "负责人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "单位不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit4.Text ) )
            {
                MessageBox.Show( "姓名不可为空" );
                return;
            }
            variable( );
            result = _bll.Exists( _model );
            if ( result == true )
                MessageBox.Show( "本单已经存在\n\r考核类别:" + _model.XZ014 + "\n\r负责人:" + _model.XZ002 + "\n\r单位:" + _model.XZ003 + "\n\r姓名:" + XZ004 + "\n\r的记录,请核实" );
            else
            {
                _model.IDX = _bll.Add( _model );
                if ( _model.IDX > 0 )
                {
                    MessageBox.Show( "成功录入数据" );
                    if ( tableQuery == null )
                    {
                        strWhere = "1=1";
                        strWhere = strWhere + " AND XZ001='" + _model.XZ001 + "'";
                        button4_Click( null ,null );
                    }
                    else
                    {
                        row = tableQuery.NewRow( );
                        row["idx"] = _model.IDX;
                        rowEdit( );
                        tableQuery.Rows.Add( row );
                    }
                }
                else
                    MessageBox.Show( "录入数据失败,请重试" );
            }
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "考核类别不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit2.Text ) )
            {
                MessageBox.Show( "负责人不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "单位不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit4.Text ) )
            {
                MessageBox.Show( "姓名不可为空" );
                return;
            }
            num = gridView1.FocusedRowHandle;
            variable( );
            if ( category == _model.XZ014 && personInCharge == _model.XZ002 && company == _model.XZ003 && Name == _model.XZ004 )
                editTable( );
            else
            {
                result = _bll.Exists( _model );
                if ( result == true )
                    MessageBox.Show( "本单已经存在\n\r考核类别:" + _model.XZ014 + "\n\r负责人:" + _model.XZ002 + "\n\r单位:" + _model.XZ003 + "\n\r姓名:" + XZ004 + "\n\r的记录,请核实" );
                else
                    editTable( );
            }
        }
        void editTable ( )
        {
            result = _bll.Updates( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                row = tableQuery.Rows[num];
                row.BeginEdit( );
                rowEdit( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败,请重试" );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            result = _bll.Deletes( _model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.RemoveAt( gridView1.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( strWhere == "" )
                strWhere = "1=1";
            tableQuery = _bll.GetDataTable( strWhere ,_model.XZ013 );
            gridControl1.DataSource = tableQuery;
            gridControl2.DataSource = _bll.GetDataTableTwo( strWhere ,_model.XZ013 );
            gridControl3.DataSource = _bll.GetDataTableTre( strWhere ,_model.XZ013 );
            gridControl4.DataSource = _bll.GetDataTableFor( strWhere ,_model.XZ013 );
        }
        //BatchEdit
        private void button8_Click ( object sender ,EventArgs e )
        {
            _model.XZ009 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToDecimal( textBox5.Text );
            result = _bll.BatchEdit( _model.XZ001 ,_model.XZ009 );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                strWhere = "1=1";
                strWhere = strWhere + " AND XZ001='" + _model.XZ001 + "'";
                button4_Click( null ,null );
            }
            else
                MessageBox.Show( "编辑失败,请重试" );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.ManagePayrollLibrary( );
            SelectAll.ManagePayrollAll query = new SelectAll.ManagePayrollAll( );
            query.PassDataBetweenForm += new SelectAll.ManagePayrollAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.ShowDialog( );

            if ( _model.XZ001 != null )
                autoQuery( );
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            sign = "2";
            queryContent( );
        }
        void queryContent ( )
        {
            _model = _bll.GetModel( _model.XZ001 );
            if ( _model == null )
                return;
            textBox9.Text = _model.XZ017;
            textBox10.Text = _model.XZ018;
            textBox11.Text = _model.XZ019;
            if ( _model.XZ020 > DateTime.MinValue && _model.XZ020 < DateTime.MaxValue )
                dateTimePicker2.Value = _model.XZ020;
            if ( _model.XZ013 > DateTime.MinValue && _model.XZ013 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.XZ013;
            textBox8.Text = _model.XZ016;
            strWhere = "1=1";
            strWhere = strWhere + " AND XZ001='" + _model.XZ001 + "'";
            button4_Click( null ,null );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.XZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion

    }
}
