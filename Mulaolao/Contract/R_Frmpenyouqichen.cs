using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentMgr;
using Mulaolao.Class;
using Mulaolao.Other;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Raw_material_cost;
using System.Linq;
using Mulaolao.Contract.yesOrNoPlan;

namespace Mulaolao.Contract
{
    public partial class R_Frmpenyouqichen : FormChild
    {
        MulaolaoLibrary.FrmpenyouqichenEntity _model=null;
        MulaolaoBll .Bll.PenYouQiChenBll _bll =null;

        public R_Frmpenyouqichen (/* Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            _model = new MulaolaoLibrary . FrmpenyouqichenEntity ( );
            _bll = new MulaolaoBll . Bll . PenYouQiChenBll ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        R_Frmpenselect pl = new R_Frmpenselect( );
        R_Frm495 rf4 = new R_Frm495( );
        DataTable de, delj, biao;
        string saves = string.Empty, copy = string.Empty, file =string.Empty, stateOfOdd = string.Empty,weihu=string.Empty;
        Report report = new Report( );
        DataSet RDataSet; Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( );
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( );List<TabPage> pageList = new List<TabPage>( );
        
        /*  519读取数据
        生产工艺、日喷单面单遍板数comboBox13 textBox4、每平方米工资单价comboBox15 textBox6、小工标准日 工资comboBox11 textBox7、老师标准日工资comboBox12 textBox10、日排小工人数comboBox8 textBox11

        填表策划人==开合同人
        */
        
        private void R_Frmpenyouqichen_Load ( object sender ,EventArgs e )
        {
            Power( this );
            
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox15.Enabled = false;

            dateTimePicker1.Enabled = false;
            label45.Visible = false;
            label98.Visible = false;

            //设置行号所在行固定宽度
            this.bandedGridView1.IndicatorWidth = 40;

            //加工工艺
            List<string> jiagong = new List<string>( ) { "水帘机喷涂" ,"静电喷涂" ,"浸漆" ,"封边" ,"涂布" };
            foreach ( string str in jiagong )
            {
                comboBox17.Items.Add( str );
            }

            DataTable dt = SqlHelper.ExecuteDataTable( "SELECT PY02,PY07 FROM R_PQY" );
            //承揽方
            comboBox12.DataSource = dt.DefaultView.ToTable( true ,"PY07" );
            comboBox12.DisplayMember = "PY07";
            //大小板
            //DataTable dr = biao.DefaultView.ToTable( true ,"PY02" );
            comboBox2.DataSource = dt.DefaultView.ToTable( true ,"PY02" );
            comboBox2.DisplayMember = "PY02";

            ProductionWorkshop.workShop( comboBox14 );
        }

        private void R_Frmpenyouqichen_Shown ( object sender ,EventArgs e )
        {
            _model . PY33 = Merges . oddNum;
            if ( !string . IsNullOrEmpty ( _model . PY33 ) )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region 打印  导出
        private void CreateDataSet ( )
        {
            RDataSet = new DataSet( );
            //CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 OR PY10 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 AND PY10 != 0 THEN CONVERT( DECIMAL( 11, 2 ), (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)/PY10) END U10

            DataTable print = SqlHelper . ExecuteDataTable ( "SELECT PY30,PY38,PY31,PY32,PY34,PY01,PY27,CONVERT(NVARCHAR(20),PY03,111) PY03,CONVERT(NVARCHAR(20),PY09,111) PY09,CONVERT(NVARCHAR(20),PY05,111) PY05,PY04,PY06,PY07,CONVERT(NVARCHAR(20),PY08,111) PY08,PY39,CONVERT(NVARCHAR(20),PY40,111) PY40,PY25,PY36,PY10,PY11,PY15,PY12,PY13,PY14,PY18,CONVERT( BIGINT, PY14 * PY18 ) U0,PY16,PY19,CASE WHEN PY12 = 0 OR PY15 = 0 OR PY21 = 0 THEN 0 WHEN PY12 != 0 AND PY15 != 0 AND PY21 != 0 THEN CONVERT( DECIMAL( 11, 2 ), PY13 * PY16 * PY19 / PY12 / PY15 / PY21 / 2 ) END U4,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT( INT, PY13 * PY16 * PY19 * PY10 * PY11 / PY14 / PY18 / PY21 / 2 ) END U5 ,PY20,PY21,PY02,PY23,CASE WHEN PY13!=0 THEN 0 WHEN PY13=0 THEN CONVERT( BIGINT, PY14 * PY18 * PY11 * PY10 * PY12 *PY15* 0.0001 ) END U6,CASE WHEN PY21 = 0 THEN 0 WHEN PY21 != 0 THEN CONVERT( DECIMAL(6,2), 1.0 * PY20/PY21 ) END U7,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY13=0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY13!=0 THEN CONVERT( BIGINT, PY10 * PY11 * PY12 * PY15 / PY14 / PY18 ) END U8,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT( DECIMAL( 11, 0 ),PY20 * PY10 * PY11 * PY12 * PY15 / PY21 / PY14 / PY18) END U9,CONVERT(DECIMAL(11,2),CASE WHEN PY10=0 THEN 0 WHEN PY14*PY18*PY21=0 THEN PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001/PY10 ELSE ((PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)+PY23*PY14*PY18*PY11*PY10*PY12*PY15*0.0001)/PY10 END) U10,CASE WHEN PY21 = 0 OR PY14=0 OR PY18=0 THEN 0  WHEN PY21!=0 AND PY14!=0 AND PY18!=0 THEN CONVERT( DECIMAL( 11, 2 ), (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100)/(PY10*PY11*PY15*PY12/PY14/PY18)) END U11,CONVERT(NVARCHAR(20),CONVERT(decimal(11,2),PY17/100)) PY17,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN CONVERT( INT, (PY13 * PY16 * PY19 * PY10 * PY11 / PY14 / PY18 / PY21 / 2 + PY20 * PY10 * PY11 * PY12 * PY15 / PY21 / PY14 / PY18)*PY17/100)  END U12,CASE WHEN PY14 = 0 OR PY18 = 0 OR PY21 = 0 THEN 0 WHEN PY14 != 0 AND PY18 != 0 AND PY21 != 0 THEN (PY10*PY11*PY15*PY12*PY20/PY21/PY14/PY18+PY13*PY19*PY16*PY10*PY11/PY14/PY18/PY21/2)*(1+PY17/100) END U13, PY23 * PY14 * PY18 * PY11 * PY10 * PY12 *PY15* 0.0001 U14,PY33 FROM R_PQY WHERE PY33 =@PY33" ,new SqlParameter ( "@PY33" ,_model . PY33 ) );
            print.TableName = "R_PQY";
            //prints.TableName = "R_PQYS";
            RDataSet.Tables.Add( print );
            //RDataSet.Tables.Add( prints );
        }
        #endregion

        #region  查询
        void queryContent ( )
        {
            //查找产品
            _model = _bll . getModel ( _model . PY33 );
            if ( _model == null )
                return;

            comboBox14 . Text = _model . PY41;
            textBox1 . Text = _model . PY01;
            comboBox11 . Text = _model . PY30;
            comboBox8 . Text = _model . PY31;
            textBox5 . Text = _model . PY27 . ToString ( );
            textBox2 . Text = _model . PY38;
            comboBox2 . Text = _model . PY02;
            if ( _model . PY03 > DateTime . MinValue && _model . PY03 < DateTime . MaxValue )
                dateTimePicker1 . Value = _model . PY03;
            textBox26 . Text = _model . PY04;
            if ( _model . PY05 > DateTime . MinValue && _model . PY05 < DateTime . MaxValue )
                dateTimePicker2 . Value = _model . PY05;
            textBox8 . Text = _model . PY06;
            comboBox12 . Text = _model . PY07;
            if ( _model . PY08 > DateTime . MinValue && _model . PY08 < DateTime . MaxValue )
                dateTimePicker3 . Value = _model . PY08;
            if ( _model . PY09 > DateTime . MinValue && _model . PY09 < DateTime . MaxValue )
                dateTimePicker4 . Value = _model . PY09;
            textBox15 . Text = _model . PY28;
            textBox3 . Text = _model . PY32;
            textBox9 . Text = _model . PY39;
            if ( _model . PY40 > DateTime . MinValue && _model . PY40 < DateTime . MaxValue )
                dateTimePicker6 . Value = _model . PY40;
            if ( _model . PY34 > DateTime . MinValue && _model . PY34 < DateTime . MaxValue )
                dateTimePicker5 . Value = _model . PY34;
            label98 . Visible = _model . PY37 . Equals ( "复制" ) ? true : false;
            checkBox1 . Checked = _model . PY47 == null ? false : Convert . ToBoolean ( _model . PY47 );

            button9_Click ( null ,null );
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );

            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button6.Enabled = button7.Enabled = false;
            textBox15.Enabled = false;
            dateTimePicker1.Enabled = false;
            saves = "2";
            queryContent( );
        }
        string st = "";
        //查询
        SelectAll.PenYouQiChenAll query = new SelectAll.PenYouQiChenAll( );
        protected override void select ( )
        {
            base.select( );

            st = "1";
            
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.PenYouQiChenAll.PassDataBetweenFormHandler( pl_PassDataBetweenForm );
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( _model.PY33 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        //bom内容查询
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable dp = _bll . getProductInfo ( );
            if ( dp == null || dp . Rows . Count < 0 )
                MessageBox . Show ( "产品BOM表中无信息" );
            else
            {
                dp . Columns . Add ( "check" ,Type . GetType ( "System.Boolean" ) );
                pl . gridControl1 . DataSource = dp;
                pl . str = "1";
                pl . Text = "R_495 信息查询";
                st = "2";
                pl . PassDataBetweenForm += new R_Frmpenselect . PassDataBetweenFomrHandler ( pl_PassDataBetweenForm );
                pl . StartPosition = FormStartPosition . CenterScreen;
                pl . ShowDialog ( );
            }
        }
        //计划查询
        private void button8_Click ( object sender ,EventArgs e )
        {
            DataTable dp = SqlHelper.ExecuteDataTable( "SELECT PQF03,PQF04,PQF06 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dp.Rows.Count < 0 )
                MessageBox.Show( "产品BOM表中无信息" );
            else
            {
                pl.gridControl1.DataSource = dp;
                pl.str = "8";
                pl.Text = "R_495 信息查询";
                st = "3";
                pl.PassDataBetweenForm += new R_Frmpenselect.PassDataBetweenFomrHandler( pl_PassDataBetweenForm );
                pl.StartPosition = FormStartPosition.CenterScreen;
                pl.ShowDialog( );
            }
        }
        //传值       
        private void pl_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( st == "1" )
            {
                _model . PY33 = e . ConOne;
                if ( e . ConTwo == "执行" )
                    label45 . Visible = true;
                else
                    label45 . Visible = false;
            }
            else if ( st == "2" )
            {
                if ( e . ConOne . IndexOf ( "," ) > 0 )
                    textBox1 . Text = string . Join ( "," ,e . ConOne . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
                else
                    textBox1 . Text = e . ConOne;
                _model . PY01 = textBox1 . Text;
                if ( e . ConTwo . IndexOf ( "," ) > 0 )
                    textBox2 . Text = string . Join ( "," ,e . ConTwo . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
                else
                    textBox2 . Text = e . ConTwo;
                _model . PY38 = textBox2 . Text;
                if ( e . ConTre . IndexOf ( "," ) > 0 )
                    comboBox8 . Text = string . Join ( "," ,e . ConTre . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
                else
                    comboBox8 . Text = e . ConTre;
                _model . PY31 = comboBox8 . Text;
                if ( e . ConFor . IndexOf ( "," ) > 0 )
                    comboBox11 . Text = string . Join ( "," ,e . ConFor . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
                else
                    comboBox11 . Text = e . ConFor;
                _model . PY30 = comboBox11 . Text;
                if ( !string . IsNullOrEmpty ( e . ConFiv ) )
                    _model . PY27 = Convert . ToInt64 ( e . ConFiv );
                else
                    _model . PY27 = 0;
                textBox5 . Text = e . ConFiv;
                if ( !string . IsNullOrEmpty ( e . ConSix ) )
                {
                    dateTimePicker1 . Value = Convert . ToDateTime ( e . ConSix );
                    _model . PY03 = Convert . ToDateTime ( e . ConSix );
                }
            }
            else if ( st == "3" )
            {
                textBox1 . Text = "";
                textBox2 . Text = "";
                _model . PY31 = e . ConOne;
                comboBox8 . Text = e . ConOne;
                _model . PY30 = e . ConTwo;
                comboBox11 . Text = e . ConTwo;
                if ( !string . IsNullOrEmpty ( e . ConTre ) )
                    _model . PY27 = Convert . ToInt64 ( e . ConTre );
                else
                    _model . PY27 = 0;
                textBox5 . Text = e . ConTre;
            }
        }
        //工艺查询
        string r519ben = "";
        R_FrmR_519select se = new R_FrmR_519select( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox17 . Text ) )
                MessageBox . Show ( "请选择加工工艺" );
            else
            {
                se . chose = "1";
                DataTable r519;
                if ( comboBox17 . Text . Equals ( "水帘机喷涂" ) )
                {
                    r519 = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQA" );
                    if ( r519 . Rows . Count < 1 )
                        MessageBox . Show ( "没有水帘机喷涂数据" );
                    else
                    {
                        se . zhi = "1";
                        r519ben = "1";
                        se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                        se . StartPosition = FormStartPosition . CenterScreen;
                        se . ShowDialog ( );
                    }
                }
                else if ( comboBox17 . Text . Equals ( "静电喷涂" ) )
                {
                    r519 = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQD" );
                    if ( r519 . Rows . Count < 1 )
                        MessageBox . Show ( "没有静电喷涂数据" );
                    else
                    {
                        se . zhi = "2";
                        r519ben = "2";
                        se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                        se . StartPosition = FormStartPosition . CenterScreen;
                        se . ShowDialog ( );
                    }
                }
                else if ( comboBox17 . Text . Equals ( "浸漆" ) )
                {
                    r519 = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQE" );
                    if ( r519 . Rows . Count < 1 )
                        MessageBox . Show ( "没有浸漆数据" );
                    else
                    {
                        se . zhi = "3";
                        r519ben = "3";
                        se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                        se . StartPosition = FormStartPosition . CenterScreen;
                        se . ShowDialog ( );
                    }
                }
                else if ( comboBox17 . Text . Equals ( "封边" ) )
                {
                    r519 = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQB" );
                    if ( r519 . Rows . Count < 1 )
                        MessageBox . Show ( "没有封边数据" );
                    else
                    {
                        se . zhi = "4";
                        r519ben = "4";
                        se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                        se . StartPosition = FormStartPosition . CenterScreen;
                        se . ShowDialog ( );
                    }
                }
                else if ( comboBox17 . Text . Equals ( "涂布" ) )
                {
                    r519 = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQC" );
                    if ( r519 . Rows . Count < 1 )
                        MessageBox . Show ( "没有涂布数据" );
                    else
                    {
                        se . zhi = "5";
                        r519ben = "5";
                        se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                        se . StartPosition = FormStartPosition . CenterScreen;
                        se . ShowDialog ( );
                    }
                }
            }
        }
        private void se_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( r519ben == "1" )
            {
                textBox7.Text = e.ConOne;
                textBox11.Text = e.ConTwo;
                textBox10.Text = e.ConTre;
                textBox4.Text = e.ConFor;
                textBox14.Text = e.ConFiv;
                textBox13.Text = e.ConSix;
                textBox6.Text = "";
                textBox17.Text = e.ConSev;
            }
            else if ( r519ben == "2" )
            {
                textBox7.Text = e.ConOne;
                textBox11.Text = e.ConTwo;
                textBox10.Text = e.ConTre;
                textBox4.Text = e.ConFor;
                textBox14.Text = e.ConFiv;
                textBox13.Text = e.ConSix;
                textBox6.Text = "";
                textBox17.Text = e.ConSev;
            }
            else if ( r519ben == "3" )
            {
                textBox7.Text = e.ConOne;
                textBox11.Text = e.ConTwo;
                textBox4.Text = e.ConTre;
                textBox14.Text = e.ConFor;
                textBox13.Text = e.ConFiv;
                textBox10.Text = "";
                textBox17.Text = e.ConSix;
            }
            else if ( r519ben == "4" )
            {
                textBox6.Text = e.ConOne;
                textBox14.Text = e.ConTwo;
                textBox13.Text = e.ConTre;
                textBox10.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
                textBox4.Text = "";
                textBox17.Text = e.ConFor;
            }
            else if ( r519ben == "5" )
            {
                textBox7.Text = e.ConOne;
                textBox11.Text = e.ConTwo;
                textBox6.Text = e.ConTre;
                textBox14.Text = e.ConFor;
                textBox13.Text = e.ConFiv;
                textBox10.Text = "";
                textBox4.Text = "";
                textBox17.Text = e.ConSix;
                textBox16.Text = e.ConSev;
            }
        }
        #endregion

        #region 主体      
        //新增
        void orde ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox15.Enabled = false;
            dateTimePicker1.Enabled = false;
            label45.Visible = false;
            saves = "1";
            comboBox8.Enabled = comboBox11.Enabled = false;
            _model.PY33 = oddNumbers.purchaseContract( "SELECT MAX(PY33) PY33 FROM R_PQY" ,"PY33" ,"R_495-" );
        }
        Order od = new Order( );
        string ord = "";
        protected override void add ( )
        {
            base.add( );

            od.StartPosition = FormStartPosition.CenterScreen;
            od.PassDataBetweenForm += new Order.PassDataBetweenFormHandler( od_PassDataBetweenForm );
            od.ShowDialog( );

            if ( ord .Equals( "计划") )
            {
                orde( );
                comboBox8.Enabled = comboBox11.Enabled = true;
                textBox5.Enabled = true;
                button4.Enabled = false;
                button8.Enabled = true;
                //fc.productNumberRthr( comboBox11 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord .Equals( "实际") )
            {
                orde( );

                comboBox8.Enabled = comboBox11.Enabled = false;
                textBox5.Enabled = false;
                button4.Enabled = true;
                button8.Enabled = false;
                //comboBox11.DataSource = null;
                //comboBox11.Items.Clear( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "" )
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                saves = "1";
                _model.PY33 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //删除
        void deles ( )
        {
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saves .Equals( "1") )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = _bll.Delete( "R_495" ,"喷油漆承揽生产加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.PY33 ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败,没有选择单号" );
            else
            {
                MessageBox.Show( "成功删除数据" );

                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );

                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolAdd.Enabled = toolSelect.Enabled =  true;
                toolDelete.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolPrint.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolUpdate.Enabled = toolExport.Enabled = false;

                dateTimePicker1.Enabled = false;
                label45.Visible =label98.Visible= false;
                textBox15.Enabled = false;
            }
        }
        protected override void delete ( )
        {
            base . delete ( );

            if ( label45 . Visible == true )
            {
                if ( Logins . number .Equals( "MLL-0001") )
                    deles ( );
                else
                    MessageBox . Show ( "单号:" + _model . PY33 + "的单据状态为执行,不允许删除" );
            }
            else
                deles ( );
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible==true )
                MessageBox.Show( "单号:" + _model.PY33 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;
                dateTimePicker1.Enabled = false;
                label45.Visible = false;
                textBox15.Enabled = false;
                comboBox8.Enabled = comboBox11.Enabled = false;
                saves = "2";
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                {
                    comboBox8.Enabled = comboBox11.Enabled = true;
                    textBox5.Enabled = true;
                    button4.Enabled = false;
                    button8.Enabled = true;
                }
                else
                {
                    comboBox8.Enabled = comboBox11.Enabled = false;
                    textBox5.Enabled = false;
                    button4.Enabled = true;
                    button8.Enabled = false;
                }
            }
        }
        //送审
        protected override void revirw ( )
        {
            base . revirw ( );

            bool result = false;
            if ( textBox3 . Text . Equals ( "廖灵飞" ) )
                result = true;
            else
                result = false;
            Reviews ( "PY33" ,_model . PY33 ,"R_PQY" ,this ,"" ,"R_495" ,result ,false,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_495"*/ );
            result = false;
            result = sp . reviewImple ( "R_495" ,_model . PY33 );
            if ( result == true )
            {
                label45 . Visible = true;
                try
                {
                    SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQYC" ,"R_PQY" ,"PY33" ,_model . PY33 ) );
                    WriteOfReceivablesTo ( );
                }
                catch { }
            }
            else
                label45 . Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = _bll.GetDataTableOfReceivable( _model.PY33 );
            if ( receiva != null && receiva . Rows . Count > 0 )
            {
                modelAm . AM002 = receiva . Rows [ 0 ] [ "PY01" ] . ToString ( );
                modelAm . AM088 = 0;
                modelAm . AM088 = string . IsNullOrEmpty ( receiva . Compute ( "sum(U14)" ,"PY01='" + modelAm . AM002 + "' and AH18= '喷漆'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(U14)" ,"PY01='" + modelAm . AM002 + "' and AH18= '喷漆'" ) );
                _bll . UpdateOfReceivable ( modelAm ,_model . PY33 );
            }
        }
        //保存
        private void adds ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );

            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;

            toolSave.Enabled = toolCancel.Enabled = false;
            dateTimePicker1.Enabled = false;
            label45.Visible =label98.Visible= false;
            textBox15.Enabled = false;
            copy = "";
            weihu = "";
            saves = "";
        }
        void updates ( )
        {
            //StringBuilder strSql = new StringBuilder( );
            //strSql.AppendFormat( "UPDATE R_PQY SET PY01='{0}',PY02='{1}',PY03='{2}',PY04='{3}',PY05='{4}',PY06='{5}',PY07='{6}',PY08='{7}',PY09='{8}',PY27='{9}',PY28='{10}',PY29='{11}',PY30='{12}',PY31='{13}',PY32='{14}',PY34='{15}',PY37='{16}',PY38='{17}',PY39='{18}',PY40='{19}',PY41='{20}' WHERE PY33='{21}'" ,PY01 ,PY02 ,PY03 ,PY04 ,PY05 ,PY06 ,PY07 ,PY08 ,PY09 ,PY27 ,PY28 ,PY29 ,PY30 ,PY31 ,PY32 ,PY34 ,"" ,PY38 ,PY39 ,PY40 ,PY41 ,PY33 );
            //int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            result = _bll . Update ( _model ,Logins . username ,stateOfOdd );
            if ( result==false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "录入数据成功" );
                //try
                //{
                //    //SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_495" ,"喷油漆承揽生产加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PY33 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                //}
                //catch { }
                //finally {
                adds ( );
            //}
            }
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( comboBox8.Text ) )
                MessageBox.Show( "货号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox8.Text ) )
                    MessageBox.Show( "开合同人不可为空" );
                else
                {
                    _model . PY01 = textBox1 . Text;
                    _model . PY38 = textBox2 . Text;
                    _model . PY27 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToInt32 ( textBox5 . Text );
                    _model . PY02 = comboBox2.Text;
                    _model . PY03 = dateTimePicker1.Value;
                    _model . PY04 = textBox26.Text;
                    _model . PY05 = dateTimePicker2.Value;
                    _model . PY06 = textBox8.Text;
                    _model . PY07 = comboBox12.Text;
                    _model . PY08 = dateTimePicker3.Value;
                    _model . PY09 = dateTimePicker4.Value;
                    _model . PY28 = textBox15.Text;
                    _model . PY29 = string . Empty;
                    _model . PY30 = comboBox11.Text;
                    _model . PY31 = comboBox8.Text;
                    _model . PY32 = textBox3.Text;
                    _model . PY34 = dateTimePicker5.Value;
                    _model . PY39 = textBox9.Text;
                    _model . PY40 = dateTimePicker6.Value;
                    _model . PY41 = comboBox14.Text;
                    _model . PY47 = checkBox1 . Checked;

                    DataTable dr = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT PY29 FROM R_PQY  WHERE PY33=@PY33" ,new SqlParameter ( "@PY33" ,_model . PY33 ) );

                    if ( weihu . Equals ( "1" ) )
                    {
                        if ( string . IsNullOrEmpty ( textBox15 . Text ) )
                        {
                            MessageBox . Show ( "请填写维护信息" );
                            return;
                        }

                        if ( dr == null || dr . Rows . Count < 1 )
                        {
                            MessageBox . Show ( "单号:" + _model . PY33 + "的记录不存在,请核实后再维护" );
                            return;
                        }
                        _model . PY29 = dr . Rows [ 0 ] [ "PY29" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";
                        stateOfOdd = "维护保存";
                        //StringBuilder strSql = new StringBuilder ( );
                        //strSql . AppendFormat ( "UPDATE R_PQY SET PY01='{0}',PY02='{1}',PY03='{2}',PY04='{3}',PY05='{4}',PY06='{5}',PY07='{6}',PY08='{7}',PY09='{8}',PY27='{9}',PY28='{10}',PY29='{11}',PY30='{12}',PY31='{13}',PY32='{14}',PY34='{15}',PY38='{16}',PY39='{17}',PY40='{18}',PY41='{19}' WHERE PY33='{20}'" ,PY01 ,PY02 ,PY03 ,PY04 ,PY05 ,PY06 ,PY07 ,PY08 ,PY09 ,PY27 ,PY28 ,PY29 ,PY30 ,PY31 ,PY32 ,PY34 ,PY38 ,PY39 ,PY40 ,PY41 ,PY33 );
                        //int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        result = _bll . Update ( _model ,Logins . username ,stateOfOdd );
                        if ( result==false )
                            MessageBox . Show ( "录入数据失败" );
                        else
                        {
                            MessageBox . Show ( "录入数据成功" );
                            try
                            {
                                //SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( "R_495" ,"喷油漆承揽生产加工合同" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                                //SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQYC" ,"R_PQY" ,"PY33" ,_model . PY33 ) );
                                WriteOfReceivablesTo ( );
                            }
                            catch { }
                            finally
                            {
                                adds ( );
                                label45 . Visible = true;
                            }
                        }
                    }
                    else
                    {
                        if ( saves == "1" )
                            stateOfOdd = "新增保存";
                        else
                            stateOfOdd = "更改保存";

                        if ( dr . Rows . Count < 1 )
                        {
                            //StringBuilder strSql = new StringBuilder ( );
                            //strSql . AppendFormat ( "INSERT INTO R_PQY (PY01,PY02,PY03,PY04,PY05,PY06,PY07,PY08,PY09,PY27,PY33,PY28,PY29,PY30,PY31,PY32,PY34,PY38,PY39,PY40,PY41) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')" ,PY01 ,PY02 ,PY03 ,PY04 ,PY05 ,PY06 ,PY07 ,PY08 ,PY09 ,PY27 ,PY33 ,PY28 ,PY29 ,PY30 ,PY31 ,PY32 ,PY34 ,PY38 ,PY39 ,PY40 ,PY41 );
                            //int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                            result= _bll . Add ( _model ,Logins . username ,stateOfOdd );
                            if ( result==false )
                                MessageBox . Show ( "录入数据失败" );
                            else
                            {
                                MessageBox . Show ( "成功录入数据" );
                                adds ( );
                            }
                        }
                        else
                        {
                            if ( copy == "1" )
                            {
                                stateOfOdd = "复制保存";
                                //,new SqlParameter( "@PY06" ,PY06 )   AND PY06=@PY06
                                DataTable dyu = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQY WHERE PY33!=@PY33 " ,new SqlParameter ( "@PY33" ,_model . PY33 ) );
                                if ( dyu . Rows . Count < 1 )
                                    updates ( );
                                else
                                {
                                    for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                                    {
                                        if ( ord == "计划" || string . IsNullOrEmpty ( textBox1 . Text ) )
                                        {
                                            if ( dyu . Select ( " PY25='" + bandedGridView1 . GetDataRow ( i ) [ "PY25" ] . ToString ( ) + "' AND PY36='" + bandedGridView1 . GetDataRow ( i ) [ "PY36" ] . ToString ( ) + "' AND PY31='" + _model.PY31 + "'" ) . Length > 0 )
                                            {
                                                if ( Logins . number == "MLL-0001" )
                                                {
                                                    updates ( );
                                                    break;
                                                }
                                                else
                                                {
                                                    //\n\r开合同人:" + PY06 + "
                                                    MessageBox . Show ( "已经存在\n\r货号:" + _model . PY31 + "\n\r零件名称:" + bandedGridView1 . GetDataRow ( i ) [ "PY25" ] . ToString ( ) + "\n\r工序:" + bandedGridView1 . GetDataRow ( i ) [ "PY36" ] . ToString ( ) + "\n\r的记录,请核实后再录入" );
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                updates ( );
                                                break;
                                            }
                                        }
                                        else if ( ord == "实际" || !string . IsNullOrEmpty ( textBox1 . Text ) )
                                        {
                                            if ( dyu . Select ( " PY25='" + bandedGridView1 . GetDataRow ( i ) [ "PY25" ] . ToString ( ) + "' AND PY36='" + bandedGridView1 . GetDataRow ( i ) [ "PY36" ] . ToString ( ) + "' AND PY01='" + _model.PY01 + "'" ) . Length > 0 )
                                            {
                                                if ( Logins . number .Equals( "MLL-0001") )
                                                {
                                                    updates ( );
                                                    break;
                                                }
                                                else
                                                {
                                                    //\n\r开合同人:" + PY06 + "
                                                    MessageBox . Show ( "已经存在\n\r流水号:" + _model.PY31 + "\n\r零件名称:" + bandedGridView1 . GetDataRow ( i ) [ "PY25" ] . ToString ( ) + "\n\r工序:" + bandedGridView1 . GetDataRow ( i ) [ "PY36" ] . ToString ( ) + "\n\r的记录,请核实后再录入" );
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                updates ( );
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                updates ( );
                        }
                    }
                }
            }
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            if ( saves .Equals( "1") && weihu != "1" )
            {
                Ergodic . SpliClear ( spList );
                Ergodic . TablePageEnableClear ( pageList );
                Ergodic . FormEvery ( this );
                gridControl1 . DataSource = null;
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                label45 . Visible = false;

                try
                {
                    _bll . Delete ( "R_495" ,"喷油漆承揽生产加工合同" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,_model . PY33 ,"取消" ,"新增取消" );
                }
                catch
                {
                }
            }
            else if ( saves . Equals ( "2" ) || weihu . Equals ( "1" ) )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            textBox15.Enabled = false;
            dateTimePicker1.Enabled = false;

            label98.Visible = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            saves = "";
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                dateTimePicker1.Enabled = false;
                label45.Visible = true;
                textBox15.Enabled = true;
                weihu = "1";

                if ( string.IsNullOrEmpty( textBox1.Text ) )
                {
                    comboBox8.Enabled = comboBox11.Enabled = true;
                    textBox5.Enabled = true;
                    button4.Enabled = false;
                    button8.Enabled = true;
                }
                else
                {
                    comboBox8.Enabled = comboBox11.Enabled = false;
                    textBox5.Enabled = false;
                    button4.Enabled = true;
                    button8.Enabled = false;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //打印
        protected override void print ( )
        {
            base.print( );
            if ( label45.Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQY" ,"PY44" ,_model . PY33 ,"PY33" );

                file = "";
                file = System.Windows.Forms.Application.StartupPath;
                CreateDataSet( );
                report.Load( file + "\\R_495.frx" );
                //report.Load( Environment.CurrentDirectory + "\\R_495.frx" );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        //导出
        protected override void export ( )
        {
            base.export( );
            //if ( label45.Visible == true )
            //{
            file = "";
            file = System.Windows.Forms.Application.StartupPath;

            CreateDataSet( );
            report.Load( file + "\\R_495.frx" );
            //report.Load( Environment.CurrentDirectory + "\\R_495.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport reports = new XMLExport( );
            reports.Export( report );
            //}
            //else
            //    MessageBox.Show( "非执行单据不能导出" );
        }
        //复制
        protected override void copys ( )
        {
            base.copys( );

            if ( label45.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }
            result = _bll.Copy( "R_495" ,"喷油漆承揽生产加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.PY33 ,"复制" ,stateOfOdd );
            
            if ( result==false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                _model . PY33 = oddNumbers . purchaseContract ( "SELECT MAX(PY33) PY33 FROM R_PQY" ,"PY33" ,"R_495-" );
                stateOfOdd = "更改复制单号";
                result = _bll.CopyAll( "R_495" ,"喷油漆承揽生产加工合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,_model.PY33 ,"复制" ,stateOfOdd );
                if ( result==false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQY WHERE PY33 IS NULL" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    textBox15.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    saves = "1";
                    //ord = "";
                    copy = "1";
                    weihu = "";
                    label45.Visible = false;
                    textBox8 . Text = textBox3 . Text = textBox9 . Text = textBox26 . Text = string . Empty;
                    dateTimePicker2 . Value = dateTimePicker3 . Value = dateTimePicker4 . Value = dateTimePicker5 . Value = dateTimePicker6 . Value = MulaolaoBll . Drity . GetDt ( );
                    queryContent ( );
                    comboBox8.Enabled = comboBox11.Enabled = false;
                    button9_Click( null ,null );
                }
            }
        }
        #endregion

        #region  事件
        void assgion ( )
        {
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY20"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY21"].ToString( ) ) )
                    if ( Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY21"].ToString( ) ) != 0 )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["PY35"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY20"].ToString( ) ) / Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY21"].ToString( ) ) );
                if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY13"].ToString( ) ) )
                {
                    if ( Convert.ToInt32( bandedGridView1.GetDataRow( i )["PY13"].ToString( ) ) == 0 )
                    {
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U14"] ,0 );
                        if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY14"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY18"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY11"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY10"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY12"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY15"].ToString( ) ) )
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY14"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY18"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY11"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY10"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY12"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY15"].ToString( ) ) * Convert.ToDecimal( 0.0001 ) );
                        else
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,0 );
                    }
                    else
                    {
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,0 );
                        if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY14"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY18"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY11"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY10"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY12"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PY15"].ToString( ) ) )
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U14"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY11"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY10"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY12"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY15"].ToString( ) ) / Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY14"].ToString( ) ) / Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PY18"].ToString( ) ) );
                        else
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U14"] ,0 );
                    }
                }
            }
            U34.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( bandedGridView1.Columns["U14"].SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( bandedGridView1.Columns["U7"].SummaryItem.SummaryValue ) / Convert.ToDecimal( bandedGridView1.Columns["U14"].SummaryItem.SummaryValue ) ,2 ).ToString( ) );
            PY23.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( bandedGridView1.Columns["U12"].SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( bandedGridView1.Columns["U26"].SummaryItem.SummaryValue ) / Convert.ToDecimal( bandedGridView1.Columns["U12"].SummaryItem.SummaryValue ) ,3 ).ToString( ) );
            PY35.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( bandedGridView1.Columns["U14"].SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( bandedGridView1.Columns["U19"].SummaryItem.SummaryValue ) / Convert.ToDecimal( bandedGridView1.Columns["U14"].SummaryItem.SummaryValue ) ,2 ).ToString( ) );
            //U20.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["PY10"].ToString( ) ) == true ? 0.ToString( ) : Math.Round( ( Convert.ToDecimal( bandedGridView1.Columns["U24"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["U26"].SummaryItem.SummaryValue ) ) / Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["PY10"].ToString( ) ) ,2 ).ToString( ) );
            U21.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( bandedGridView1.Columns["U26"].SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( bandedGridView1.Columns["U24"].SummaryItem.SummaryValue ) / Convert.ToDecimal( bandedGridView1.Columns["U26"].SummaryItem.SummaryValue ) ,2 ).ToString( ) );
            U23.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( Convert.ToDecimal( bandedGridView1.Columns["U7"].SummaryItem.SummaryValue ) + Convert.ToDecimal( bandedGridView1.Columns["U19"].SummaryItem.SummaryValue ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["PY17"].ToString( ) ) / 100 ,1 ).ToString( ) );
        }
        //货号
        private void comboBox8_TextChanged ( object sender ,EventArgs e )
        {
            _model . PY31 = comboBox8 . Text;
            delj = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS02 PY25 FROM R_PQP WHERE GS48=@GS48 AND GS02!='' UNION SELECT DISTINCT GS07 FROM R_PQP WHERE GS48=@GS48 AND GS07!=''" ,new SqlParameter ( "@GS48" ,_model . PY31 ) );
            every ( );
        }
        void every ( )
        {
            biao = SqlHelper . ExecuteDataTable ( "SELECT idx,PY02,PY07,PY25,PY10,PY11,PY12,PY13,PY14,PY15,PY17,PY18,PY22,PY36 FROM R_PQY WHERE PY31=@PY31" ,new SqlParameter ( "@PY31" ,_model . PY31 ) );
            if ( biao != null && biao . Rows . Count > 0 )
            {
                if ( !string . IsNullOrEmpty ( biao . Rows [ 0 ] [ "idx" ] . ToString ( ) ) )
                    _model . idx = Convert . ToInt32 ( biao . Rows [ 0 ] [ "idx" ] . ToString ( ) );
            }
            if ( delj != null )
                biao.Merge( delj );

            //零件名称
            //DataTable d16 = biao.DefaultView.ToTable( true ,"PY25" );
            comboBox16.DataSource = biao.DefaultView.ToTable( true ,"PY25" );
            comboBox16.DisplayMember = "PY25";
            //产品出货套数
            //DataTable c1 = biao.DefaultView.ToTable( true ,"PY10" );
            comboBox1.DataSource = biao.DefaultView.ToTable( true ,"PY10" );
            comboBox1.DisplayMember = "PY10";
            //每套部件数量
            //DataTable c3 = biao.DefaultView.ToTable( true ,"PY11" );
            comboBox3.DataSource = biao.DefaultView.ToTable( true ,"PY11" );
            comboBox3.DisplayMember = "PY11";
            //每片喷面数
            //DataTable c4 = biao.DefaultView.ToTable( true ,"PY12" );
            comboBox4.DataSource = biao.DefaultView.ToTable( true ,"PY12" );
            comboBox4.DisplayMember = "PY12";
            //片摆.翻.收次数
            //DataTable c5 = biao.DefaultView.ToTable( true ,"PY13" );
            comboBox5.DataSource = biao.DefaultView.ToTable( true ,"PY13" );
            comboBox5.DisplayMember = "PY13";
            //长向摆放个数
            //DataTable c6 = biao.DefaultView.ToTable( true ,"PY14" );
            comboBox6.DataSource = biao.DefaultView.ToTable( true ,"PY14" );
            comboBox6.DisplayMember = "PY14";
            //每片.每面喷.涂遍数
            //DataTable c7 = biao.DefaultView.ToTable( true ,"PY15" );
            comboBox7.DataSource = biao.DefaultView.ToTable( true ,"PY15" );
            comboBox7.DisplayMember = "PY15";
            //管理提成(%)
            //DataTable c9 = biao.DefaultView.ToTable( true ,"PY17" );
            comboBox9.DataSource = biao.DefaultView.ToTable( true ,"PY17" );
            comboBox9.DisplayMember = "PY17";
            //宽向摆放个数
            //DataTable c10 = biao.DefaultView.ToTable( true ,"PY18" );
            comboBox10.DataSource = biao.DefaultView.ToTable( true ,"PY18" );
            comboBox10.DisplayMember = "PY18";



            DataTable gongxu = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PY36 FROM R_PQY" );
            //工序
            comboBox13.DataSource = gongxu;
            comboBox13.DisplayMember = "PY36";

        }
        private void comboBox16_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( comboBox16 . Text ) && biao . Select ( "PY25='" + comboBox16 . Text + "'" ) . Length > 0 )
            {
                DataTable doe = SqlHelper . ExecuteDataTable ( "SELECT idx,PY10,PY11,PY12,PY13,PY14,PY15,PY17,PY18 FROM R_PQY WHERE PY33=@PY33" ,new SqlParameter ( "@PY33" ,_model . PY33 ) );
                if ( doe . Rows . Count > 0 )
                {
                    if ( doe . Select ( "idx='" + _model . idx + "'" ) . Length > 0 )
                    {
                        comboBox1 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY10" ] . ToString ( );
                        comboBox3 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY11" ] . ToString ( );
                        comboBox4 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY12" ] . ToString ( );
                        comboBox5 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY13" ] . ToString ( );
                        comboBox6 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY14" ] . ToString ( );
                        comboBox7 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY15" ] . ToString ( );
                        comboBox9 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY17" ] . ToString ( );
                        comboBox10 . Text = doe . Select ( "idx='" + _model . idx + "'" ) [ 0 ] [ "PY18" ] . ToString ( );
                    }
                }
            }
        }
        //产品出货套数
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {

        }
        //每套部件数量
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //每片喷面数
        private void comboBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //片摆翻收次数
        private void comboBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //长向摆放个数
        private void comboBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        int ax = 0;
        double bx = 0;
        private void comboBox6_TextChanged ( object sender ,EventArgs e )
        {
            if ( comboBox6.Text != "" && DateDayRegise.Num( comboBox6 ) )
            {
                ax = int.Parse( comboBox6.Text );
                textBox12.Text = ( ax * bx ).ToString( );
            }
        }
        private void comboBox6_KeyPress_1 ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //宽向摆放个数
        private void comboBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox10 );
        }
        private void comboBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox10 );
            if ( comboBox10.Text != "" && DateDayRegise.threeOneNum( comboBox10 ) )
            {
                bx = double.Parse( comboBox10.Text );
                textBox12.Text = ( ax * bx ).ToString( );
            }
        }
        private void comboBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox10.Text != "" && !DateDayRegise.threeOneNum( comboBox10 ) )
            {
                this.comboBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
        }
        //管理提成
        private void comboBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox9 );
        }
        private void comboBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox9 );
        }
        private void comboBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox9.Text != "" && !DateDayRegise.foreOneNum( comboBox9 ) )
            {
                this.comboBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void comboBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //规定小工标准日工资
        private void comboBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //窗体关闭
        private void R_Frmpenyouqichen_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //填表策划人
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( textBox26.Text == "" )
            {
                textBox26.Text = Logins.username;
            }
            else if ( textBox26.Text != "" && textBox26.Text == Logins.username )
            {
                textBox26.Text = "";
            }

            dateTimePicker2 . Value = DateTime . Now;
        }
        //开合同人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox8.Text == "" )
            {
                textBox8.Text = Logins.username;
            }
            else if ( textBox8.Text != "" && textBox8.Text == Logins.username )
            {
                textBox8.Text = "";
            }
        }
        //审批人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                textBox3.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox3.Text ) && textBox3.Text == Logins.username )
                textBox3.Text = "";
            dateTimePicker5.Value = MulaolaoBll . Drity . GetDt ( );

        }
        //审核人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox9.Text ) )
                textBox9.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox9.Text ) && textBox9.Text == Logins.username )
                textBox9.Text = "";
            dateTimePicker6.Value = MulaolaoBll . Drity . GetDt ( );

        }
        //老师标准日工资
        private void comboBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void groupBox3_Enter ( object sender ,EventArgs e )
        {

        }
        //日喷单面单遍板数
        private void comboBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //设置行号自增
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        //获取焦点行的列值
        string com17 = "", com16 = "", com13 = "";
        private void bandedGridView1_CustomSummaryCalculate ( object sender ,DevExpress.Data.CustomSummaryEventArgs e )
        {
            //decimal customSumOne = 0, customSumTwo = 0, customSumThr = 0, customSumFor = 0/*, customSumFiv = 0*/;
            //int summaryId = Convert.ToInt32( ( e.Item as DevExpress.XtraGrid.GridSummaryItem ).Tag );
            ////Initialization
            //if ( e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start )
            //{
            //    customSumOne = customSumTwo = customSumThr = customSumFor = /*customSumFiv = 0*/0;
            //}
            ////Calculation
            //decimal u1 = 0, u14 = 0, u34 = 0, u5 = 0, u12 = 0, u26 = 0, u19 = 0, u7 = 0, u24 = 0;
            //object PY10Temp = 0;
            //if ( e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate )
            //{
            //    for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            //    {
            //        object PY13Temp = bandedGridView1.GetDataRow( i )["PY13"];
            //        PY13Temp = ( PY13Temp != DBNull.Value && PY13Temp != null ) ? 0 : PY13Temp;
            //        object PY12Temp = bandedGridView1.GetDataRow( i )["PY12"];
            //        PY12Temp = ( PY12Temp != DBNull.Value && PY12Temp != null ) ? 0 : PY12Temp;
            //        object PY15Temp = bandedGridView1.GetDataRow( i )["PY15"];
            //        PY15Temp = ( PY15Temp != DBNull.Value && PY15Temp != null ) ? 0 : PY15Temp;
            //        PY10Temp = bandedGridView1.GetDataRow( i )["PY10"];
            //        PY10Temp = ( PY10Temp != DBNull.Value && PY10Temp != null ) ? 0 : PY10Temp;
            //        object PY11Temp = bandedGridView1.GetDataRow( i )["PY11"];
            //        PY11Temp = ( PY11Temp != DBNull.Value && PY11Temp != null ) ? 0 : PY11Temp;
            //        object PY14Temp = bandedGridView1.GetDataRow( i )["PY14"];
            //        PY14Temp = ( PY14Temp != DBNull.Value && PY14Temp != null ) ? 0 : PY14Temp;
            //        object PY18Temp = bandedGridView1.GetDataRow( i )["PY18"];
            //        PY18Temp = ( PY18Temp != DBNull.Value && PY18Temp != null ) ? 0 : PY18Temp;
            //        object PY16Temp = bandedGridView1.GetDataRow( i )["PY16"];
            //        PY16Temp = ( PY16Temp != DBNull.Value && PY16Temp != null ) ? 0 : PY16Temp;
            //        object PY19Temp = bandedGridView1.GetDataRow( i )["PY19"];
            //        PY19Temp = ( PY19Temp != DBNull.Value && PY19Temp != null ) ? 0 : PY19Temp;
            //        object PY21Temp = bandedGridView1.GetDataRow( i )["PY21"];
            //        PY21Temp = ( PY21Temp != DBNull.Value && PY21Temp != null ) ? 0 : PY21Temp;
            //        object PY26Temp = bandedGridView1.GetDataRow( i )["PY26"];
            //        PY26Temp = ( PY26Temp != DBNull.Value && PY26Temp != null ) ? 0 : PY26Temp;
            //        object PY35Temp = bandedGridView1.GetDataRow( i )["PY35"];
            //        PY35Temp = ( PY35Temp != DBNull.Value && PY35Temp != null ) ? 0 : PY35Temp;
            //        object PY17Temp = bandedGridView1.GetDataRow( i )["PY17"];
            //        PY17Temp = ( PY17Temp != DBNull.Value && PY17Temp != null ) ? 0 : PY17Temp;
            //        //U14
            //        u14 += Convert.ToDecimal( PY14Temp ) == 0 ? 0 : ( Convert.ToDecimal( PY18Temp ) == 0 ? 0 : Convert.ToDecimal( PY10Temp ) * Convert.ToDecimal( PY11Temp ) * Convert.ToDecimal( PY15Temp ) * Convert.ToDecimal( PY12Temp ) / Convert.ToDecimal( PY14Temp ) / Convert.ToDecimal( PY18Temp ) );
            //        //U7
            //        u7 += Convert.ToDecimal( PY14Temp ) == 0 ? 0 : ( Convert.ToDecimal( PY18Temp ) == 0 ? 0 : ( Convert.ToDecimal( PY21Temp ) == 0 ? 0 : Convert.ToDecimal( PY13Temp ) * Convert.ToDecimal( PY19Temp ) * Convert.ToDecimal( PY16Temp ) * Convert.ToDecimal( PY10Temp ) * Convert.ToDecimal( PY11Temp ) / Convert.ToDecimal( PY14Temp ) / Convert.ToDecimal( PY18Temp ) / Convert.ToDecimal( PY21Temp ) / 2 ) );
            //        //U12
            //        u12 += Convert.ToDecimal( PY11Temp ) * Convert.ToDecimal( PY10Temp ) * Convert.ToDecimal( PY12Temp ) * Convert.ToDecimal( PY15Temp ) * Convert.ToDecimal( PY14Temp ) * Convert.ToDecimal( PY18Temp ) * Convert.ToDecimal( 0.0001 );
            //        //U26
            //        u26 += Convert.ToDecimal( PY26Temp ) * Convert.ToDecimal( PY11Temp ) * Convert.ToDecimal( PY10Temp ) * Convert.ToDecimal( PY12Temp ) * Convert.ToDecimal( PY15Temp ) * Convert.ToDecimal( PY14Temp ) * Convert.ToDecimal( PY18Temp ) * Convert.ToDecimal( 0.0001 );
            //        //U19
            //        u19 += Convert.ToDecimal( PY14Temp ) == 0 ? 0 : ( Convert.ToDecimal( PY18Temp ) == 0 ? 0 : Convert.ToDecimal( PY10Temp ) * Convert.ToDecimal( PY11Temp ) * Convert.ToDecimal( PY15Temp ) * Convert.ToDecimal( PY12Temp ) * Convert.ToDecimal( PY35Temp ) / Convert.ToDecimal( PY14Temp ) / Convert.ToDecimal( PY18Temp ) );
            //        //U24
            //        u24 += ( u7 + u19 ) * ( 1 + Convert.ToDecimal( PY17Temp ) ) * Convert.ToDecimal( 0.01 );
            //    }
            //    customSumOne = u14 == 0 ? 0 : Math.Round( u7 / u14 ,2 );
            //    customSumTwo = u12 == 0 ? 0 : Math.Round( u26 / u12 ,2 );
            //    customSumThr = u14 == 0 ? 0 : Math.Round( u19 / u14 ,2 );
            //    customSumFor = Convert.ToDecimal( PY10Temp ) == 0 ? 0 : Math.Round( ( u24 + u26 ) / Convert.ToDecimal( PY10Temp ) ,2 );
            //    //customSumFiv = u14 = 0 == 0 ? 0 : Math.Round( u24One / u14 ,2 );
            //}
            //if ( e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize )
            //{
            //    switch ( summaryId )
            //    {
            //        case 1:
            //        e.TotalValue = customSumOne;
            //        break;
            //        case 2:
            //        e.TotalValue = customSumTwo;
            //        break;
            //        case 3:
            //        e.TotalValue = customSumThr;
            //        break;
            //        case 4:
            //        e.TotalValue = customSumFor;
            //        break;
            //        //case 5:
            //        //e.TotalValue = customSumFiv;
            //        //break;
            //    }
            //}
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _model . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( );
            }
        }
        void assignMent ( )
        {
            _model = _bll . getModel ( _model . idx );
            if ( _model == null )
                return;
            comboBox1 . Text = _model . PY10 . ToString ( );
            comboBox3 . Text = _model . PY11 . ToString ( );
            comboBox4 . Text = _model . PY12 . ToString ( );
            comboBox5 . Text = _model . PY13 . ToString ( );
            comboBox6 . Text = _model . PY14 . ToString ( );
            comboBox7 . Text = _model . PY15 . ToString ( );
            textBox11 . Text = _model . PY16 . ToString ( );
            comboBox9 . Text = _model . PY17 . ToString ( );
            comboBox10 . Text = _model . PY18 . ToString ( );
            textBox7 . Text = _model . PY19 . ToString ( );
            textBox10 . Text = _model . PY20 . ToString ( );
            textBox4 . Text = _model . PY21 . ToString ( );
            textBox6 . Text = _model . PY23 . ToString ( );
            comboBox17 . Text = _model . PY24 . ToString ( );
            comboBox13 . Text = _model . PY36 . ToString ( );
            textBox13 . Text = _model . PY22 . ToString ( );
            textBox14 . Text = _model . PY26 . ToString ( );
            comboBox16 . Text = _model . PY25 . ToString ( );
            textBox16 . Text = _model . PY42 . ToString ( );
            textBox17 . Text = _model . PY43 . ToString ( );
            com16 = comboBox16 . Text;
            com17 = comboBox17 . Text;
            com13 = comboBox13 . Text;
        }
        //产品名称
        private void comboBox11_SelectedValueChanged ( object sender ,EventArgs e )
        {
            //if ( ord == "计划" || string.IsNullOrEmpty(textBox1.Text))
            //{
            //    if ( !string.IsNullOrEmpty( comboBox11.Text ) )
            //        comboBox8.Text = comboBox11.SelectedValue.ToString( );
            //}
        }
        #endregion

        #region 表格
        //新建
        void build ( )
        {
            _model . PY06 = textBox8 . Text;
            _model . PY10 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt64 ( comboBox1 . Text );
            _model . PY11 = string . IsNullOrEmpty ( comboBox3 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox3 . Text );
            _model . PY12 = string . IsNullOrEmpty ( comboBox4 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox4 . Text );
            _model . PY13 = string . IsNullOrEmpty ( comboBox5 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox5 . Text );
            _model . PY14 = string . IsNullOrEmpty ( comboBox6 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox6 . Text );
            _model . PY15 = string . IsNullOrEmpty ( comboBox7 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox7 . Text );
            _model . PY16 = string . IsNullOrEmpty ( textBox11 . Text ) == true ? 0 : Convert . ToDecimal ( textBox11 . Text );
            _model . PY17 = string . IsNullOrEmpty ( comboBox9 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox9 . Text );
            _model . PY18 = string . IsNullOrEmpty ( comboBox10 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox10 . Text );
            _model . PY19 = string . IsNullOrEmpty ( textBox7 . Text ) == true ? 0 : Convert . ToInt32 ( textBox7 . Text );
            _model . PY20 = string . IsNullOrEmpty ( textBox10 . Text ) == true ? 0 : Convert . ToInt32 ( textBox10 . Text );
            _model . PY21 = string . IsNullOrEmpty ( textBox4 . Text ) == true ? 0 : Convert . ToInt32 ( textBox4 . Text );
            _model . PY22 = textBox13 . Text;
            _model . PY23 = string . IsNullOrEmpty ( textBox6 . Text ) == true ? 0 : Convert . ToDecimal ( textBox6 . Text );
            _model . PY24 = comboBox17 . Text;
            _model . PY25 = comboBox16 . Text;
            _model . PY26 = textBox14 . Text;
            _model . PY31 = comboBox8 . Text;
            _model . PY36 = comboBox13 . Text;
            _model . PY42 = textBox16 . Text;
            _model . PY43 = textBox17 . Text;
        }
        void builds ( )
        {
            if ( label45 . Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            //StringBuilder strSql = new StringBuilder( );
            //strSql.AppendFormat( "INSERT INTO R_PQY (PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY22,PY23,PY24,PY25,PY26,PY33,PY36,PY31,PY43,PY42) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}')" ,PY010 ,PY011 ,PY012 ,PY013 ,PY014 ,PY015 ,PY016 ,PY017 ,PY018 ,PY019 ,PY020 ,PY021 ,PY022 ,PY023 ,PY024 ,PY025 ,PY026 ,PY33 ,PY036 ,PY31 ,PY043 ,PY042 );
            //int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            result = _bll . Insert ( _model ,Logins . username ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "录入数据失败" );
            else
            {
                MessageBox . Show ( "成功录入数据" );

                every ( );
                button9_Click ( null ,null );
                assgion ( );
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox8 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox8 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
                return;
            }
            if ( !string . IsNullOrEmpty ( comboBox1 . Text ) && !string . IsNullOrEmpty ( textBox5 . Text ) )
            {
                if ( Convert . ToInt64 ( comboBox1 . Text ) > Convert . ToInt64 ( textBox5 . Text ) )
                {
                    MessageBox . Show ( "产品出货套数不可以多于产品数量" );
                    return;
                }

                build ( );

                //,new SqlParameter( "@PY24" ,PY024 )  AND PY24=@PY24   
                //DataTable del = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQY WHERE PY01=@PY01 AND PY06=@PY06 AND PY25=@PY25 AND PY36=@PY36" ,new SqlParameter ( "@PY01" ,PY01 ) ,new SqlParameter ( "@PY06" ,PY06 ) ,new SqlParameter ( "@PY25" ,PY025 ) ,new SqlParameter ( "@PY36" ,PY036 ) );
                result = _bll . ExistsBody ( _model );
                if ( result == false )
                    builds ( );
                else
                {
                    if ( _model . PY06 . Equals ( "廖灵飞" ) )
                        builds ( );
                    else
                        MessageBox . Show ( "此单为补开,请联系总经理处理" );
                }
                //MessageBox.Show( "已经存在\n\r单号:" + PY33 + "\n\r零件名称:" + PY025 + "\n\r工序:" + PY036 + "\n\r的记录,请核实后再录入" );
                button9_Click ( null ,null );
            }
        }
        //编辑
        private void upd ( )
        {
            //int nu = bandedGridView1.FocusedRowHandle;
            //DataRow row;
            //if ( saves == "2" )
            //{
            //    row = de.Rows[nu];
            //    row.BeginEdit( );
            //    row["PY10"] = PY010;
            //    row["PY11"] = PY011;
            //    row["PY12"] = PY012;
            //    row["PY13"] = PY013;
            //    row["PY14"] = PY014;
            //    row["PY15"] = PY015;
            //    row["PY16"] = PY016;
            //    row["PY17"] = PY017;
            //    row["PY18"] = PY018;
            //    row["PY19"] = PY019;
            //    row["PY20"] = PY020;
            //    row["PY21"] = PY021;
            //    row["PY22"] = PY022;
            //    row["PY23"] = PY023;
            //    row["PY24"] = PY024;
            //    row["PY25"] = PY025;
            //    row["PY26"] = PY026;
            //    row["PY36"] = PY036;
            //    row.EndEdit( );
            //}
            //else if ( saves == "1" )
            //{
            //    row = hl.Rows[nu];
            //    row.BeginEdit( );
            //    row["PY10"] = PY010;
            //    row["PY11"] = PY011;
            //    row["PY12"] = PY012;
            //    row["PY13"] = PY013;
            //    row["PY14"] = PY014;
            //    row["PY15"] = PY015;
            //    row["PY16"] = PY016;
            //    row["PY17"] = PY017;
            //    row["PY18"] = PY018;
            //    row["PY19"] = PY019;
            //    row["PY20"] = PY020;
            //    row["PY21"] = PY021;
            //    row["PY22"] = PY022;
            //    row["PY23"] = PY023;
            //    row["PY24"] = PY024;
            //    row["PY25"] = PY025;
            //    row["PY26"] = PY026;
            //    row["PY36"] = PY036;
            //    row.EndEdit( );
            //}

            every( );
            button9_Click( null ,null );
            assgion( );
        }
        void edit ( )
        {
            if ( label45 . Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }

            //StringBuilder strSql = new StringBuilder( );
            //strSql . AppendFormat ( "UPDATE R_PQY SET PY10='{0}',PY11='{1}',PY12='{2}',PY13='{3}',PY14='{4}',PY15='{5}',PY16='{6}',PY17='{7}',PY18='{8}',PY19='{9}',PY20='{10}',PY21='{11}',PY22='{12}',PY23='{13}',PY24='{14}',PY25='{15}',PY26='{16}',PY36='{17}',PY42='{18}',PY43='{19}' WHERE PY33='{21}' AND idx='{20}'" , PY010 , PY011 , PY012 , PY013 , PY014 , PY015 , PY016 , PY017 , PY018 , PY019 , PY020 , PY021 , PY022 , PY023 , PY024 , PY025 , PY026 , PY036 , PY042 , PY043 , id , PY33 );
            //int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            result = _bll . Edit ( _model ,Logins . username ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "编辑数据失败" );
            else
            {
                MessageBox . Show ( "编辑数据成功" );

                upd ( );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox8 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox8 . Text ) )
            {
                MessageBox . Show ( "开合同人不可为空" );
            }

            if ( comboBox1 . Text != "" && textBox5 . Text != "" )
            {
                if ( Convert . ToInt64 ( comboBox1 . Text ) > Convert . ToInt64 ( textBox5 . Text ) )
                    MessageBox . Show ( "产品出货套数不可以多于产品数量" );
                else
                {
                    build ( );

                    if ( com16 == _model . PY25 && com13 == _model . PY36 )
                    {
                        //PY33=@PY33 AND PY25=@PY25 AND PY36=@PY36
                        //int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQY SET PY10=@PY10,PY11=@PY11,PY12=@PY12,PY13=@PY13,PY14=@PY14,PY15=@PY15,PY16=@PY16,PY17=@PY17,PY18=@PY18,PY19=@PY19,PY20=@PY20,PY21=@PY21,PY22=@PY22,PY23=@PY23,PY26=@PY26,PY24=@PY24,PY31=@PY31,PY42=@PY42,PY43=@PY43 WHERE PY33=@PY33 AND idx=@idx" /*,new SqlParameter( "@PY33" ,PY33 )*/ ,new SqlParameter ( "@PY10" ,PY010 ) ,new SqlParameter ( "@PY11" ,PY011 ) ,new SqlParameter ( "@PY12" ,PY012 ) ,new SqlParameter ( "@PY13" ,PY013 ) ,new SqlParameter ( "@PY14" ,PY014 ) ,new SqlParameter ( "@PY15" ,PY015 ) ,new SqlParameter ( "@PY16" ,PY016 ) ,new SqlParameter ( "@PY17" ,PY017 ) ,new SqlParameter ( "@PY18" ,PY018 ) ,new SqlParameter ( "@PY19" ,PY019 ) ,new SqlParameter ( "@PY20" ,PY020 ) ,new SqlParameter ( "@PY21" ,PY021 ) ,new SqlParameter ( "@PY22" ,PY022 ) ,new SqlParameter ( "@PY23" ,PY023 ) ,new SqlParameter ( "@PY24" ,PY024 ) ,new SqlParameter ( "@PY42" ,PY042 ) ,new SqlParameter ( "@PY43" ,PY043 ) ,new SqlParameter ( "@PY26" ,PY026 ) ,new SqlParameter ( "@PY36" ,PY036 ) ,new SqlParameter ( "@PY31" ,PY31 ) ,new SqlParameter ( "@idx" ,id ) ,new SqlParameter ( "@PY33" ,PY33 ) );
                        //if ( count < 1 )
                        //    MessageBox . Show ( "编辑数据失败" );
                        //else
                        //{
                        //    MessageBox . Show ( "成功编辑数据" );

                        //    upd ( );
                        //}
                        edit ( );
                    }
                    else
                    {
                        // ,new SqlParameter( "@PY24" ,PY024 )   AND PY24=@PY24
                        //DataTable del = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQY WHERE PY01=@PY01 AND PY06=@PY06 AND PY25=@PY25 AND PY36=@PY36" ,new SqlParameter ( "@PY01" ,PY01 ) ,new SqlParameter ( "@PY06" ,PY06 ) ,new SqlParameter ( "@PY25" ,PY025 ) ,new SqlParameter ( "@PY36" ,PY036 ) );
                        result = _bll . ExistsBody ( _model );
                        if ( result == false )
                            edit ( );
                        else
                        {
                            if ( Logins . username . Equals ( "廖灵飞" ) )
                                edit ( );
                            else
                                MessageBox . Show ( "此单为补开,请联系总经理处理" );
                        }
                        //加工工艺:" + PY024 + "\n\r
                        //MessageBox.Show( "已经存在\n\r单号:" + PY33 + "\n\r零件名称:" + PY025 + "\n\r工艺:" + PY036 + "\n\r的记录,请核实后再编辑" );
                    }
                    button9_Click ( null ,null );
                }
            }
        }
        //批量编辑
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( label45 . Visible == true )
                stateOfOdd = "维护批量编辑";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增批量编辑";
                else
                    stateOfOdd = "更改批量编辑";
            }

            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "产品出货套数不可为空" );
                return;
            }

            _model . PY10 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox1 . Text );
            //StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "UPDATE R_PQY SET PY10='{1}' WHERE PY33='{0}'" ,PY33 ,PY010 );
            //int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            result = _bll . BatchEdit ( _model ,Logins . username ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "编辑数据失败" );
            else
            {
                MessageBox . Show ( "成功编辑数据" );

                button9_Click ( null ,null );
                assgion ( );
            }
        }
        //删除
        private void dele ( )
        {
            //int num = bandedGridView1.FocusedRowHandle;
            //if ( saves == "1" )
            //    hl.Rows.RemoveAt( num );
            //else if ( saves == "2" )
            //    de.Rows.RemoveAt( num );
            every( );
            button9_Click( null ,null );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            if ( label45 . Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            //build ( );
            //StringBuilder strSql = new StringBuilder( );
            //strSql . AppendFormat ( "DELETE FROM R_PQY WHERE PY33='{1}' AND idx={0}" , id , PY33 );
            //int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            result = _bll . Delete ( _model ,Logins . username ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "成功删除数据" );

                dele ( );
            }
        }
        //刷新
        private void button9_Click ( object sender ,EventArgs e )
        {
            //de = SqlHelper.ExecuteDataTable( "SELECT idx,PY02,PY03,PY04,PY05,PY07,PY08,PY09,PY10,PY11,PY12,PY13,PY14,PY15,PY16,PY17,PY18,PY19,PY20,PY21,PY23,PY22,PY24,PY25,PY26,PY35,PY36,PY42,PY43,U12,U14 FROM R_PQY WHERE PY33=@PY33 AND PY25!='' AND PY25 IS NOT NULL ORDER BY idx DESC" ,new SqlParameter( "@PY33" ,PY33 ) );
            de = _bll . getTableToView ( _model . PY33 );
            gridControl1.DataSource = de;
            if ( de != null && de.Rows.Count > 0 )
                assgion( );
        }
        #endregion

    }
}
