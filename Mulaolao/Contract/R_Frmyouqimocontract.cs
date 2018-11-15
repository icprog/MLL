using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Contract;
using Mulaolao . Class;
using Mulaolao . Bom;
using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Schedule_control;
using System . Linq;
using Mulaolao . Other;
using Mulaolao . Raw_material_cost;
using Mulaolao . Contract . DefineFileds;
using Mulaolao . Contract . yesOrNoPlan;
using DevExpress . XtraGrid . Views . Grid;
using DevExpress . Data;
using System . Collections . Generic;
using MulaolaoBll;

namespace Mulaolao.Procedure
{
    public partial class R_Frmyouqimocontract : FormChild
    {
        public R_Frmyouqimocontract ( /*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.YouQicontractBll bll = new MulaolaoBll.Bll.YouQicontractBll( );
        MulaolaoLibrary.YouQiLibrary model = new MulaolaoLibrary.YouQiLibrary( );
        Youqicaigou yq = new Youqicaigou( );
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        R_FrmPQJ pqj = new R_FrmPQJ( );
        string saves = "", copy = "", strWhere = "1=1", weihu = "", numQu = "", stateOfOdd = "", file = "";
        DataTable tab, dtOrd, dpOrd, name;
        DataTable dr = new DataTable( );
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( );
        youqicontract wy = new youqicontract( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( );
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( );
        
        private void R_Frmyouqimocontract_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;


            label24.Visible = false;
            label36.Visible = false;

            name = bll.GetDataTableProson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";
            anOther( );

            if ( Logins.number == "MLL-0001" )
                checkBox16.Visible = true;
            else
                checkBox16.Visible = false;
        }

        private void R_Frmyouqimocontract_Shown ( object sender ,EventArgs e )
        {
            model.YQ99 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( model.YQ99 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print Export
        private void CreateDataSet ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrintOne( model.YQ99 );
            DataTable prints = bll.GetDataTablePrintTwo( model.YQ99 );
            DataTable printes = bll.GetDataTablePrintThr( model.YQ99 );
            print.TableName = "R_PQI";
            prints.TableName = "R_PQIS";
            printes.TableName = "R_PQIES";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
            RDataSet.Tables.Add( printes );
        }
        #endregion

        #region Query
        void queryContent ( )
        {
            if ( model.YQ99 != null && model.YQ99 != "" )
            {
                model = bll.GetMo( model.YQ99 );
                if ( model != null )
                {
                    DataTable gongy = bll.GetDataTableSupp( model.YQ02 );
                    if ( gongy.Rows.Count > 0 )
                    {
                        textBox2.Text = gongy.Rows[0]["DGA003"].ToString( );
                        textBox7.Text = gongy.Rows[0]["DGA017"].ToString( );
                        textBox8.Text = gongy.Rows[0]["DGA008"].ToString( );
                        textBox9.Text = gongy.Rows[0]["DGA012"].ToString( );
                        textBox10.Text = gongy.Rows[0]["DGA009"].ToString( );
                        textBox6.Text = gongy.Rows[0]["DGA011"].ToString( );
                    }

                    lookUpEdit1.Text = name.Select( "DBA001='" + model.YQ01 + "'" ).Length > 0 ? name.Select( "DBA001='" + model.YQ01 + "'" )[0]["DBA002"].ToString( ) : string.Empty;
                    textBox5.Text = name.Select( "DBA001='" + model.YQ01 + "'" ).Length > 0 ? name.Select( "DBA001='" + model.YQ01 + "'" )[0]["DBA028"].ToString( ) : string.Empty;
                    lookUpEdit2.Text = model.YQ124;
                    textBox49.Text = model.YQ03;
                    comboBox2.Text = model.YQ105;
                    textBox50.Text = model.YQ106;
                    comboBox4.Text = model.YQ107;
                    textBox53.Text = model.YQ108.ToString( );
                    if ( model . YQ05 > DateTime . MinValue && model . YQ05 < DateTime . MaxValue )
                        dateTimePicker1 . Value = model . YQ05;
                    else
                        dateTimePicker1 . Value = DateTime . Now;
                    textBox13.Text = model.YQ07;
                    if ( model.YQ08 > DateTime.MinValue && model.YQ08 < DateTime.MaxValue )
                        dateTimePicker2.Value = model.YQ08;
                    else
                        dateTimePicker2 . Value = DateTime . Now;
                    textBox16 .Text = model.YQ09;
                    if ( model.YQ17 > DateTime.MinValue && model.YQ17 < DateTime.MaxValue )
                        dateTimePicker3.Value = model.YQ17;
                    else
                        dateTimePicker3 . Value = DateTime . Now;
                    if ( model.YQ18 > DateTime.MinValue && model.YQ18 < DateTime.MaxValue )
                        dateTimePicker4.Value = model.YQ18;
                    else
                        dateTimePicker4 . Value = DateTime . Now;
                    textBox15 .Text = model.YQ20;
                    textBox14.Text = model.YQ21;
                    textBox17.Text = model.YQ04;
                    checkBox36.Checked = model.YQ22.Trim( ) == "T" ? true : false;
                    checkBox37.Checked = model.YQ23.Trim( ) == "T" ? true : false;
                    checkBox38.Checked = model.YQ24.Trim( ) == "T" ? true : false;
                    checkBox39.Checked = model.YQ25.Trim( ) == "T" ? true : false;
                    checkBox40.Checked = model.YQ26.Trim( ) == "T" ? true : false;
                    comboBox16.Text = model.YQ27;
                    if ( model.YQ28 > DateTime.MinValue && model.YQ28 < DateTime.MaxValue )
                        dateTimePicker5.Value = model.YQ28;
                    else
                        dateTimePicker5 . Value = DateTime . Now;
                    comboBox17 .Text = model.YQ29;
                    if ( model.YQ30 > DateTime.MinValue && model.YQ30 < DateTime.MaxValue )
                        dateTimePicker6.Value = model.YQ30;
                    else
                        dateTimePicker6 . Value = DateTime . Now;
                    textBox26 .Text = model.YQ31;
                    checkBox4.Checked = model.YQ32.Trim( ) == "T" ? true : false;
                    checkBox7.Checked = model.YQ33.Trim( ) == "T" ? true : false;
                    checkBox5.Checked = model.YQ34.Trim( ) == "T" ? true : false;
                    checkBox6.Checked = model.YQ35.Trim( ) == "T" ? true : false;
                    if ( model.YQ36.Trim( ) == "在内" )
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                    else if ( model.YQ36.Trim( ) == "不在内" )
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }
                    if ( model.YQ37.Trim( ) == "有" )
                    {
                        radioButton3.Checked = true;
                        radioButton4.Checked = false;
                    }
                    else if ( model.YQ37.Trim( ) == "没有" )
                    {
                        radioButton3.Checked = false;
                        radioButton4.Checked = true;
                    }
                    else
                    {
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                    }
                    if ( model.YQ38.Trim( ) == "已检测" )
                    {
                        radioButton6.Checked = true;
                        textBox24.Text = model.YQ39;
                        radioButton5.Checked = false;
                    }
                    else if ( model.YQ38.Trim( ) == "未检测" )
                    {
                        radioButton5.Checked = true;
                        radioButton6.Checked = false;
                        textBox24.Text = string.Empty;
                    }
                    else
                    {
                        radioButton5.Checked = false;
                        radioButton6.Checked = false;
                        textBox24.Text = string.Empty;
                    }
                    checkBox1.Checked = model.YQ40.Trim( ) == "T" ? true : false;
                    checkBox2.Checked = model.YQ41.Trim( ) == "T" ? true : false;
                    checkBox3.Checked = model.YQ42.Trim( ) == "T" ? true : false;
                    checkBox8.Checked = model.YQ43.Trim( ) == "T" ? true : false;
                    checkBox10.Checked = model.YQ44.Trim( ) == "T" ? true : false;
                    checkBox9.Checked = model.YQ45.Trim( ) == "T" ? true : false;
                    comboBox18.Text = model.YQ46;
                    if ( model.YQ47 > DateTime.MinValue && model.YQ47 < DateTime.MaxValue )
                        dateTimePicker7.Value = model.YQ47;
                    else
                        dateTimePicker7 . Value = DateTime . Now;
                    comboBox19 .Text = model.YQ48;
                    if ( model.YQ49 > DateTime.MinValue && model.YQ49 < DateTime.MaxValue )
                        dateTimePicker8.Value = model.YQ49;
                    else
                        dateTimePicker8 . Value = DateTime . Now;
                    textBox31 .Text = model.YQ50;
                    textBox30.Text = model.YQ51;
                    checkBox11.Checked = model.YQ52.Trim( ) == "T" ? true : false;
                    checkBox12.Checked = model.YQ53.Trim( ) == "T" ? true : false;
                    checkBox13.Checked = model.YQ54.Trim( ) == "T" ? true : false;
                    textBox1.Text = model.YQ55;
                    checkBox41.Checked = model.YQ102.Trim( ) == "T" ? true : false;
                    checkBox18.Checked = model.YQ56.Trim( ) == "T" ? true : false;
                    checkBox20.Checked = model.YQ57.Trim( ) == "T" ? true : false;
                    checkBox19.Checked = model.YQ58.Trim( ) == "T" ? true : false;
                    checkBox21.Checked = model.YQ59.Trim( ) == "T" ? true : false;
                    string[] str = model.YQ60.Split( ',' );
                    if ( str[0] == "T" )
                    {
                        checkBox15.Checked = true;
                        textBox29.Text = str[1];
                    }
                    else
                    {
                        checkBox15.Checked = false;
                        textBox29.Text = string.Empty;
                    }
                    checkBox14.Checked = model.YQ61.Trim( ) == "T" ? true : false;
                    checkBox16 . Checked = model . YQ123 . Trim ( ) == "T" ? true : false;
                    checkBox17 .Checked = model.YQ62.Trim( ) == "T" ? true : false;
                    checkBox25.Checked = model.YQ63.Trim( ) == "T" ? true : false;
                    checkBox22.Checked = model.YQ64.Trim( ) == "T" ? true : false;
                    checkBox23.Checked = model.YQ65.Trim( ) == "T" ? true : false;
                    checkBox24.Checked = model.YQ66.Trim( ) == "T" ? true : false;
                    checkBox29.Checked = model.YQ67.Trim( ) == "T" ? true : false;
                    checkBox26.Checked = model.YQ68.Trim( ) == "T" ? true : false;
                    checkBox27.Checked = model.YQ69.Trim( ) == "T" ? true : false;
                    checkBox28.Checked = model.YQ70.Trim( ) == "T" ? true : false;
                    checkBox33.Checked = model.YQ71.Trim( ) == "T" ? true : false;
                    checkBox35.Checked = model.YQ72.Trim( ) == "T" ? true : false;
                    checkBox32.Checked = model.YQ73.Trim( ) == "T" ? true : false;
                    checkBox31.Checked = model.YQ74.Trim( ) == "T" ? true : false;
                    checkBox34.Checked = model.YQ75.Trim( ) == "T" ? true : false;
                    checkBox30.Checked = model.YQ76.Trim( ) == "T" ? true : false;
                    textBox33.Text = model.YQ77.ToString( );
                    comboBox5.Text = model.YQ78;
                    if ( model.YQ79 > DateTime.MinValue && model.YQ79 < DateTime.MaxValue )
                        dateTimePicker9.Value = model.YQ79;
                    else
                        dateTimePicker9 . Value = DateTime . Now;
                    if ( model.YQ80.Trim( ) == "合格" )
                        radioButton7.Checked = true;
                    else if ( model.YQ80.Trim( ) == "退货" )
                        radioButton8.Checked = true;
                    else if ( model.YQ80.Trim( ) == "条件接收" )
                    {
                        radioButton9.Checked = true;
                        textBox35.Text = model.YQ81;
                    }
                    textBox36.Text = model.YQ82.ToString( );
                    textBox37.Text = model.YQ83.ToString( );
                    textBox38.Text = model.YQ84.ToString( );
                    textBox41.Text = model.YQ85.ToString( );
                    textBox40.Text = model.YQ86.ToString( );
                    textBox39.Text = model.YQ87.ToString( );
                    textBox44.Text = model.YQ88.ToString( );
                    textBox43.Text = model.YQ89.ToString( );
                    textBox42.Text = model.YQ90.ToString( );
                    textBox45.Text = model.YQ91;
                    textBox46.Text = model.YQ92;
                    if ( model.YQ93 > DateTime.MinValue && model.YQ93 < DateTime.MaxValue )
                        dateTimePicker10.Value = model.YQ93;
                    else
                        dateTimePicker10 . Value = DateTime . Now;
                    textBox47 .Text = model.YQ94;
                    if ( model.YQ95 > DateTime.MinValue && model.YQ95 < DateTime.MaxValue )
                        dateTimePicker11.Value = model.YQ95;
                    else
                        dateTimePicker11 . Value = DateTime . Now;
                    textBox48 .Text = model.YQ96;
                    if ( model.YQ97 > DateTime.MinValue && model.YQ97 < DateTime.MaxValue )
                        dateTimePicker12.Value = model.YQ97;
                    else
                        dateTimePicker12 . Value = DateTime . Now;
                    if ( model.YQ98 > DateTime.MinValue && model.YQ98 < DateTime.MaxValue )
                        dateTimePicker13.Value = model.YQ98;
                    else
                        dateTimePicker13 . Value = DateTime . Now;
                    if ( model.YQ111.Trim( ) == "复制" )
                        label36.Visible = true;
                    else
                        label36.Visible = false;
                    textBox12.Text = model.YQ103;
                    if ( label24.Visible == true )
                        button15.Enabled = true;
                    else
                        button15.Enabled = false;

                    strWhere = "1=1";
                    strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
                    refre( );
                }
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox12.Enabled = false;

            saves = "2";
            queryContent( );
            assignMent( );
        }
        string lio = "";
        //供应方查询
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
            {
                MessageBox.Show( "没有供应商信息" );
            }
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_339 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.YQ02 = e.ConOne;
            textBox2.Text = e.ConTwo;
            textBox7.Text = e.ConSev;
            textBox8.Text = e.ConTre;
            textBox9.Text = e.ConSix;
            textBox10.Text = e.ConFor;
            textBox6.Text = e.ConFiv;
        }
        //流水号查询
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "7";
                lio = "1";
                yq.Text = "R_339 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( lio == "1" )
            {
                if ( e.ConOne.IndexOf( "," ) > 0 )
                    textBox49.Text = string.Join( "," ,e.ConOne.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    textBox49.Text = e.ConOne;
                model.YQ03 = textBox49.Text;
                if ( e.ConTwo.IndexOf( "," ) > 0 )
                    textBox50.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    textBox50.Text = e.ConTwo;
                model.YQ106 = textBox50.Text;
                if ( e.ConTre.IndexOf( "," ) > 0 )
                    comboBox4.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    comboBox4.Text = e.ConTre;
                model.YQ107 = comboBox4.Text;
                if ( e.ConFor.IndexOf( "," ) > 0 )
                    comboBox2.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    comboBox2.Text = e.ConFor;
                model.YQ105 = comboBox2.Text;
                textBox53.Text = e.ConFiv;
                if ( e.ConFiv == "" )
                    model.YQ108 = 0;
                else
                    model.YQ108 = Convert.ToInt64( e.ConFiv );
                if ( e.ConSix.IndexOf( "," ) > 0 )
                    textBox15.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    textBox15.Text = e.ConSix;
                model.YQ20 = textBox15.Text;
                if ( e.ConSev.IndexOf( "," ) > 0 )
                    textBox14.Text = string.Join( "," ,e.ConSev.Split( ',' ).Distinct( ).ToArray( ) );
                else
                    textBox14.Text = e.ConSev;
                model.YQ21 = textBox14.Text;
            }
            else if ( lio == "2" )
            {
                model.YQ03 = e.ConOne;
                textBox49.Text = e.ConOne;
                if ( e.ConTwo == "执行" )
                {
                    label24.Visible = true;

                }
                else
                    label24.Visible = false;
                model.YQ01 = e.ConTre;
                model.YQ105 = e.ConFor;
                comboBox2.Text = e.ConFor;
                model.YQ02 = e.ConSix;
                lookUpEdit1.Text = e.ConFiv;
                textBox2.Text = e.ConSev;
                textBox17.Text = e.ConEgi;
                model.YQ99 = e.ConNin;
                model.YQ106 = e.ConTen;
                textBox50.Text = e.ConTen;
                model.YQ107 = e.ConEleven;
                comboBox4.Text = e.ConEleven;
                if ( e.ConTwelve == "" )
                    model.YQ108 = 0;
                else
                    model.YQ108 = Convert.ToInt64( e.ConTwelve );
                textBox53.Text = e.ConTwelve;
            }
        }
        //计划查询
        planeQuery pq = new planeQuery( );
        private void button16_Click ( object sender ,EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PY30 PQF04,PY31 PQF03,PY27 PQF06 FROM R_PQY WHERE PY01=''" );
            if ( da.Rows.Count > 0 )
            {
                pq.Text = "R_339 信息查询";
                pq.gridControl1.DataSource = da;
                pq.StartPosition = FormStartPosition.CenterScreen;
                pq.PassDataBetweenForm += new planeQuery.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
                pq.ShowDialog( );
            }
            else
                MessageBox.Show( "R_495没有计划订单" );
        }
        void pq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox49.Text = "";
            model.YQ105 = e.ConOne;
            comboBox2.Text = e.ConOne;
            model.YQ107 = e.ConTwo;
            comboBox4.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                model.YQ108 = Convert.ToInt64( e.ConTre );
            else
                model.YQ108 = 0;
            textBox53.Text = e.ConTre;
            textBox50.Text = "";
        }
        //零件查询
        private void button6_Click ( object sender ,EventArgs e )
        {
            DataTable djh = new DataTable( );
            if ( /*ord == "实际" ||*/ !string.IsNullOrEmpty( textBox49.Text ) )
            {
                model.YQ03 = textBox49.Text;
                //新增
                //AND PY36!= ''
                djh = SqlHelper.ExecuteDataTable( "SELECT PY25,PY36,PY24,PY11,PY12,PY14,PY18,PY15,PY02 FROM R_PQY A,R_MLLCXMC C,R_REVIEWS D WHERE A.PY33=D.RES06 AND C.CX01=D.RES01 AND RES05 = '执行' AND CX02 = '喷油漆承揽生产加工合同(R_495)' AND PY01=@PY01 ORDER BY A.idx ASC" ,new SqlParameter( "@PY01" ,model.YQ03 ) );
            }
            else if ( /*ord == "计划" ||*/ string.IsNullOrEmpty( textBox49.Text ) )
            {
                //PY36!= '' AND 
                djh = SqlHelper.ExecuteDataTable( "SELECT PY25,PY36,PY24,PY11,PY12,PY14,PY18,PY15,PY02 FROM R_PQY WHERE PY31=@PY31 AND PY01='' ORDER BY idx ASC" ,new SqlParameter( "@PY31" ,comboBox4.Text ) );
            }
            if ( djh.Rows.Count < 1 )
                MessageBox.Show( "[喷油漆承揽生产加工合同(R_495)]没有已经执行的信息,请录入或送审操作" );
            else
            {
                pqj.gridControl1.DataSource = djh;
                pqj.pj = "1";
                pqj.Text = "R_339 信息查询";
                pqj.PassDataBetweenForm += new R_FrmPQJ.PassDataBetweenFormHandler( pqj_PassDataBetweenForm );
                pqj.StartPosition = FormStartPosition.CenterScreen;
                pqj.ShowDialog( );
            }
        }
        private void pqj_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( string.IsNullOrEmpty( e.ConOne ) )
                model.YQ112 = 0;
            else
                model.YQ112 = Convert.ToInt32( e.ConOne );
            textBox11.Text = e.ConOne;
            if ( string.IsNullOrEmpty( e.ConTwo ) )
                model.YQ113 = 0;
            else
                model.YQ113 = Convert.ToInt32( e.ConTwo );
            textBox20.Text = e.ConTwo;
            if ( string.IsNullOrEmpty( e.ConTre ) )
                model.YQ114 = 0;
            else
                model.YQ114 = Convert.ToInt32( e.ConTre );
            textBox21.Text = e.ConTre;
            if ( string.IsNullOrEmpty( e.ConFor ) )
                model.YQ116 = 0;
            else
                model.YQ116 = Convert.ToInt32( e.ConFor );
            textBox25.Text = e.ConFor;
            if ( string.IsNullOrEmpty( e.ConFiv ) )
                model.YQ115 = 0M;
            else
                model.YQ115 = Convert.ToDecimal( e.ConFiv );
            textBox22.Text = e.ConFiv;
            model.YQ117 = e.ConSix;
            textBox23.Text = e.ConSix;
            model.YQ11 = e.ConSev;
            model.YQ10 = e.ConEgi;
            textBox32.Text = e.ConSev;
            textBox28.Text = e.ConEgi;
            model.YQ119 = e.ConNin;
            textBox54.Text = e.ConNin;
        }
        //查询
        SelectAll.YouQicontractAll query = new SelectAll.YouQicontractAll( );
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.YouQiLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.YouQicontractAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( model.YQ99 == null || model.YQ99 == "" )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.YQ03 = e.ConOne;
            textBox49.Text = e.ConOne;
            if ( e.ConTwo == "执行" )
                label24.Visible = true;
            else
                label24.Visible = false;
            model.YQ02 = e.ConTre;
            model.YQ105 = e.ConFor;
            comboBox2.Text = e.ConFor;
            //YQ02 = e.ConSix;
            //lookUpEdit1.Text = e.ConFiv;
            textBox2.Text = e.ConSev;
            //textBox17.Text = e.ConEgi;
            model.YQ99 = e.ConNin;
            model.YQ106 = e.ConTen;
            textBox50.Text = e.ConTen;
            model.YQ107 = e.ConEleven;
            comboBox4.Text = e.ConEleven;
            if ( e.ConTwelve == "" )
                model.YQ108 = 0;
            else
                model.YQ108 = Convert.ToInt64( e.ConTwelve );
            textBox53.Text = e.ConTwelve;
        }
        //工艺查询
        string r519ben = "";
        private void button17_Click_1 ( object sender ,EventArgs e )
        {
            R_FrmR_519select se = null;
            if ( string . IsNullOrEmpty ( textBox54 . Text ) )
                MessageBox . Show ( "请选择加工工艺" );
            else
            {
                if ( textBox54 . Text . Equals ( "水帘机喷涂" ) )
                {
                    se = new R_FrmR_519select ( "" ,"2" ,"1" );
                    r519ben = "1";
                    se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                    se . StartPosition = FormStartPosition . CenterScreen;
                    se . ShowDialog ( );
                }
                else if ( textBox54 . Text . Equals ( "静电喷涂" ) )
                {
                    se = new R_FrmR_519select ( "" ,"2" ,"2" );
                    r519ben = "2";
                    se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                    se . StartPosition = FormStartPosition . CenterScreen;
                    se . ShowDialog ( );
                }
                else if ( textBox54 . Text . Equals ( "浸漆" ) )
                {
                    se = new R_FrmR_519select ( "" ,"2" ,"3" );
                    r519ben = "3";
                    se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                    se . StartPosition = FormStartPosition . CenterScreen;
                    se . ShowDialog ( );
                }
                else if ( textBox54 . Text . Equals ( "封边" ) )
                {
                    se = new R_FrmR_519select ( "" ,"2" ,"4" );
                    r519ben = "4";
                    se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                    se . StartPosition = FormStartPosition . CenterScreen;
                    se . ShowDialog ( );
                }
                else if ( textBox54 . Text . Equals ( "涂布" ) )
                {
                    se = new R_FrmR_519select ( "" ,"2" ,"5" );
                    r519ben = "5";
                    se . PassDataBetweenForm += new R_FrmR_519select . PassDataBetweenFormHandler ( se_PassDataBetweenForm );
                    se . StartPosition = FormStartPosition . CenterScreen;
                    se . ShowDialog ( );
                }
            }
        }
        private void se_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( r519ben . Equals ( "1" ) )
            {
                textBox51 . Text = e . ConOne;
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox62 . Text = e . ConFiv;
                textBox61 . Text = e . ConSix;
                textBox58 . Text = e . ConSev;
                textBox63 . Text = String . Empty;
            }
            else if ( r519ben . Equals ( "2" ) )
            {
                textBox51 . Text = e . ConOne;
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox62 . Text = e . ConFiv;
                textBox61 . Text = e . ConSix;
                textBox58 . Text = e . ConSev;
                textBox63 . Text = String . Empty;
            }
            else if ( r519ben . Equals ( "3" ) )
            {
                textBox51 . Text = e . ConOne;
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox62 . Text = e . ConFiv;
                textBox61 . Text = e . ConSix;
                textBox63 . Text = String . Empty;
                textBox58 . Text = String . Empty;
            }
            else if ( r519ben . Equals ( "4" ) )
            {
                textBox52 . Text = e . ConOne;
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox62 . Text = e . ConFiv;
                textBox61 . Text = e . ConSix;
                textBox63 . Text = e . ConSev;
                textBox58 . Text = String . Empty;
            }
            else if ( r519ben . Equals ( "5" ) )
            {
                textBox52 . Text = e . ConOne;
                textBox27 . Text = e . ConTwo;
                textBox59 . Text = e . ConTre;
                textBox61 . Text = e . ConEgi;
                textBox60 . Text = e . ConSix;
                textBox62 . Text = e . ConSev;
                textBox63 . Text = e . ConNin;
                textBox58 . Text = String . Empty;
            }
        }
        #endregion

        #region Event
        void anOther ( )
        {
            //button17.Click += new EventHandler( this.button17_Click );
            DataTable dAn = SqlHelper.ExecuteDataTable( "SELECT YQ27,YQ29,YQ46,YQ48,YQ78 FROM R_PQI" );
            comboBox16.DataSource = dAn.DefaultView.ToTable( true ,"YQ27" );
            comboBox16.DisplayMember = "YQ27";
            comboBox17.DataSource = dAn.DefaultView.ToTable( true ,"YQ29" );
            comboBox17.DisplayMember = "YQ29";
            comboBox18.DataSource = dAn.DefaultView.ToTable( true ,"YQ46" );
            comboBox18.DisplayMember = "YQ46";
            comboBox19.DataSource = dAn.DefaultView.ToTable( true ,"YQ48" );
            comboBox19.DisplayMember = "YQ48";
            comboBox5.DataSource = dAn.DefaultView.ToTable( true ,"YQ78" );
            comboBox5.DisplayMember = "YQ78";
        }
        private void every ( )
        {
            DataTable biao = SqlHelper.ExecuteDataTable( "SELECT YQ12,YQ13,YQ15 FROM R_PQI" );
            //每板摆用率
            comboBox3.DataSource = biao.DefaultView.ToTable( true ,"YQ13" );
            comboBox3.DisplayMember = "YQ13";
            comboBox3.Text = "100";
            //textBox59.DataSource = biao.DefaultView.ToTable( true ,"YQ15" );
            //textBox59.DisplayMember = "YQ15";
            comboBox14.DataSource = biao.DefaultView.ToTable( true ,"YQ12" );
            comboBox14.DisplayMember = "YQ12";
        }
        private void comboBox6_TextChanged ( object sender ,EventArgs e )
        {
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT YQ06,YQ12,YQ13,YQ14,YQ15,YQ16,YQ19,YQ108,YQ117,YQ114,YQ115,YQ112,YQ116,YQ113,YQ119,YQ120,YQ121 FROM R_PQI WHERE YQ10=@YQ10 AND YQ11=@YQ11 AND YQ107=@YQ107" ,new SqlParameter( "@YQ10" ,model.YQ10 ) ,new SqlParameter( "@YQ11" ,model.YQ11 ) ,new SqlParameter( "@YQ107" ,model.YQ107 ) );
            if ( del.Rows.Count > 0 )
            {
                textBox27.Text = del.Rows[0]["YQ06"].ToString( );
                comboBox14.Text = del.Rows[0]["YQ12"].ToString( );
                comboBox3.Text = del.Rows[0]["YQ13"].ToString( );
                textBox51.Text = del.Rows[0]["YQ14"].ToString( );
                textBox59.Text = del.Rows[0]["YQ15"].ToString( );
                textBox52.Text = del.Rows[0]["YQ16"].ToString( );
                textBox54.Text = del.Rows[0]["YQ119"].ToString( );
                textBox55.Text = del.Rows[0]["YQ120"].ToString( );
                textBox56.Text = del.Rows[0]["YQ121"].ToString( );
                textBox11.Text = del.Rows[0]["YQ112"].ToString( );
                textBox20.Text = del.Rows[0]["YQ113"].ToString( );
                textBox21.Text = del.Rows[0]["YQ114"].ToString( );
                textBox25.Text = del.Rows[0]["YQ116"].ToString( );
                textBox22.Text = del.Rows[0]["YQ115"].ToString( );
                textBox23.Text = del.Rows[0]["YQ117"].ToString( );
            }
        }
        //计算
        private void button17_Click ( object sender ,EventArgs e )
        {
            model.YQ10 = textBox28.Text;
            model.YQ11 = textBox32.Text;
            model.YQ12 = comboBox14.Text;
            if ( string.IsNullOrEmpty( textBox32.Text ) )
                MessageBox.Show( "工序不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( comboBox14.Text ) )
                    MessageBox.Show( "色号不可为空" );
                else
                {
                    if ( radioButton12.Checked )
                    {
                        dr = SqlHelper.ExecuteDataTable( "SELECT PQK02,SUM(PQK09-PQK10) PQK FROM R_PQK WHERE PQK11=@PQK11 AND PQK17=@PQK17" ,new SqlParameter( "@PQK11" ,model.YQ11 ) ,new SqlParameter( "@PQK17" ,model.YQ12 ) );
                    }
                    else if ( radioButton13.Checked )
                    {
                        dr = SqlHelper.ExecuteDataTable( "SELECT PQK02,SUM(PQK09-PQK31) PQK FROM R_PQK WHERE PQK11=@PQK11 AND PQK17=@PQK17" ,new SqlParameter( "@PQK11" ,model.YQ11 ) ,new SqlParameter( "@PQK17" ,model.YQ12 ) );
                    }
                    if ( dr == null || dr.Rows.Count < 1 )
                        textBox4.Text = "0";
                    else
                    {
                        decimal pqk = 0;
                        for ( int i = 0 ; i < dr.Rows.Count ; i++ )
                        {
                            if ( !string.IsNullOrEmpty( dr.Rows[i]["PQK"].ToString( ) ) )
                                pqk += Convert.ToDecimal( dr.Rows[i]["PQK"].ToString( ) );
                        }
                        textBox4.Text = Math.Round( pqk ,0 ).ToString( );
                    }
                }
            }
        }
        //板算
        private void radioButton12_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox53.Text ) )
                MessageBox.Show( "产品数量不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox59.Text ) )
                    MessageBox.Show( "油漆现价不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( comboBox3.Text ) )
                        MessageBox.Show( "每板摆用率%不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox51.Text ) )
                            MessageBox.Show( "定每板单面.遍漆价不可为空" );
                        else
                        {
                            textBox19.Text = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                            textBox34.Text = "";
                            textBox52.Text = "";
                        }
                    }
                }
            }
        }
        //平米算
        private void radioButton13_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox53.Text ) )
                MessageBox.Show( "产品数量不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox59.Text ) )
                    MessageBox.Show( "油漆现价不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( comboBox3.Text ) )
                        MessageBox.Show( "每板摆用率%不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox52.Text ) )
                            MessageBox.Show( "定每平米漆价不可为空" );
                        else
                        {
                            textBox34.Text = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                            textBox19.Text = "";
                            textBox51.Text = "";
                        }
                    }
                }
            }
        }
        //使用外购  由于板数等不同  所以每套用量也不同
        private void radioButton10_Click ( object sender ,EventArgs e )
        {
            fc.yesOrNo( "" ,textBox32.Text ,comboBox14.Text ,textBox4 ,textBox3 ,textBox53.Text );
        }
        //使用库存
        private void radioButton11_Click ( object sender ,EventArgs e )
        {
            fc.yesOrNo( "" ,textBox32.Text ,comboBox14.Text ,textBox4 ,textBox3 ,textBox53.Text );
        }
        //得到R_525库存
        private void button18_Click ( object sender ,EventArgs e )
        {
            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) && radioButton10.Checked )
            {
                if ( string.IsNullOrEmpty( textBox28.Text ) )
                {
                    MessageBox.Show( "零件名称不可为空" );
                    return;
                }
                if ( string.IsNullOrEmpty( textBox32.Text ) )
                {
                    MessageBox.Show( "工序不可为空" );
                    return;
                }
                if ( string.IsNullOrEmpty( comboBox14.Text ) )
                {
                    MessageBox.Show( "色号不可为空" );
                    return;
                }
                SelectAll.ResidualPaintAll queryAll = new SelectAll.ResidualPaintAll( );
                queryAll.nameOf = textBox28.Text;
                queryAll.workOf = textBox32.Text;
                queryAll.colorName = comboBox14.Text;
                queryAll.PassDataBetweenForm += new SelectAll.ResidualPaintAll.PassDataBetweenFormHandler( queryAll_PassDataBetweenForm );
                queryAll.ShowDialog( );
            }
            else
                MessageBox.Show( "实际外购单据才能使用525剩余库存" );
        }
        private void queryAll_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.YQ133 = e.ConOne;
            model.YQ132 = e.ConTwo;
            model.YQ120 = e.ConTre;
            textBox55.Text = e.ConTre;
            model.YQ121 = e.ConFor;
            textBox56.Text = e.ConFor;
            textBox57.Text = e.ConFiv;
        }
        private void textBox53_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //摆放个数
        private void textBox21_TextChanged ( object sender ,EventArgs e )
        {
            textBox18.Text = Operation.MultiTwoTb( textBox21 ,textBox22 );
        }
        private void textBox22_TextChanged ( object sender ,EventArgs e )
        {
            textBox18.Text = Operation.MultiTwoTb( textBox21 ,textBox22 );
        }
        //供应商 
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA001=@DGA001" ,new SqlParameter( "@DGA001" ,model.YQ02 ) );
            if ( del.Rows.Count > 0 )
            {
                textBox2.Text = del.Rows[0]["DGA003"].ToString( );
                textBox7.Text = del.Rows[0]["DGA017"].ToString( );
                textBox8.Text = del.Rows[0]["DGA008"].ToString( );
                textBox9.Text = del.Rows[0]["DGA012"].ToString( );
                textBox10.Text = del.Rows[0]["DGA009"].ToString( );
                textBox6.Text = del.Rows[0]["DGA011"].ToString( );
            }
        }
        //每板摆用率(%)
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox3 );
        }
        private void comboBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox3 );
        }
        private void comboBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox3.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox3 ) )
            {
                this.comboBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        //油漆现价
        private void comboBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDayRegise.fractionCb( e ,textBox59 );
        }
        private void comboBox11_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox59.Text != "" && !DateDayRegise.foreTwoNum( textBox59 ) )
            {
                this.textBox59.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void comboBox11_TextChanged ( object sender ,EventArgs e )
        {
            //DateDayRegise.textChangeCb( textBox59 );
        }
        //抽查数量
        private void textBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //极严重允许数
        private void textBox36_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox37_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox38_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox41_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox40_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox39_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox44_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox43_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox42_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //联系
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                model.YQ01 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = name.Select( "DBA001='" + model.YQ01 + "'" )[0]["DBA028"].ToString( );
            }
        }
        private void radioButton6_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton6.Checked )
            {
                textBox24.Enabled = true;
            }
            else
            {
                textBox24.Enabled = false;
            }
        }
        private void checkBox15_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( checkBox15.Checked )
            {
                textBox29.Enabled = true;
            }
            else
            {
                textBox29.Enabled = false;
            }
        }
        private void radioButton9_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton9.Checked )
            {
                textBox35.Enabled = true;
            }
            else
            {
                textBox35.Enabled = false;
            }
        }
        string lj = "", gy = "", sh = "";
        private void bandedGridView1_RowClick ( object sender ,RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMe( );
            }
        }
        void assignMe ( )
        {
            model = bll.GetModel( model.IDX );
            if ( model == null )
                return;
            //textBox53.Text = model.YQ108.ToString( );
            textBox27.Text = model.YQ06;
            textBox28.Text = model.YQ10;
            textBox32.Text = model.YQ11;
            comboBox14.Text = model.YQ12;
            comboBox3.Text = model.YQ13.ToString( );
            textBox51.Text = model.YQ14.ToString( );
            textBox59.Text = model.YQ15.ToString( );
            textBox52.Text = model.YQ16.ToString( );
            textBox11.Text = model.YQ112.ToString( );
            textBox20.Text = model.YQ113.ToString( );
            textBox21.Text = model.YQ114.ToString( );
            textBox22.Text = model.YQ115.ToString( );
            textBox25.Text = model.YQ116.ToString( );
            textBox23.Text = model.YQ117;
            textBox54.Text = model.YQ119;
            textBox55.Text = model.YQ120;
            textBox56.Text = model.YQ121;
            textBox60.Text = model.YQ129;
            textBox61.Text = model.YQ130;
            textBox62.Text = model.YQ131;
            if ( model.YQ101.Trim( ) == "库存" )
            {
                radioButton11.Checked = true;

                if ( model.YQ14 > 0 )
                {
                    radioButton12.Checked = true;
                    radioButton12_Click( null ,null );
                }
                else if ( model.YQ16 > 0 )
                {
                    radioButton13.Checked = true;
                    radioButton13_Click( null ,null );
                }
            }
            else if ( model.YQ101.Trim( ) == "外购" )
            {
                radioButton10.Checked = true;
                if ( model.YQ14 > 0 )
                {
                    radioButton12.Checked = true;
                    radioButton12_Click( null ,null );
                }
                else if ( model.YQ16 > 0 )
                {
                    radioButton13.Checked = true;
                    radioButton13_Click( null ,null );
                }
            }
            if ( !string.IsNullOrEmpty( textBox55.Text ) )
            {
                if ( radioButton12.Checked )
                    textBox57.Text = textBox19.Text;
                else if(radioButton13.Checked)
                    textBox57.Text = textBox34.Text;
            }
            textBox58 . Text = model . YQ134 . ToString ( );
            textBox63 . Text = model . YQ135 . ToString ( );
            lj = textBox28.Text;
            gy = textBox32.Text;
            sh = comboBox14.Text;
        }
        //审批人
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( textBox48.Text == "" )
            {
                textBox48.Text = Logins.username;
            }
            else if ( textBox48.Text != "" && textBox48.Text == Logins.username )
            {
                textBox48.Text = "";
            }
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox47.Text == "" )
            {
                textBox47.Text = Logins.username;
            }
            else if ( textBox47.Text != "" && textBox47.Text == Logins.username )
            {
                textBox47.Text = "";
            }
            dateTimePicker11.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //乙方代表
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox46.Text == "" )
            {
                textBox46.Text = Logins.username;
            }
            else if ( textBox46.Text != "" && textBox46.Text == Logins.username )
            {
                textBox46.Text = "";
            }
            dateTimePicker10.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //成本员
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox13.Text == "" )
            {
                textBox13.Text = Logins.username;
            }
            else if ( textBox13.Text != "" && textBox13.Text == Logins.username )
            {
                textBox13.Text = "";
            }

            dateTimePicker2 . Value = DateTime . Now;
        }
        //开合同人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox17.Text == "" )
            {
                textBox17.Text = Logins.username;
                model.YQ04 = textBox17.Text;
                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQI" ,model.YQ04 ,textBox17 ,textBox16 ,"YQ09" );
                if ( str[0] == "" )
                    textBox17.Text = "";
                else
                    model.YQ09 = str[1];
                textBox16.Text = str[1];
            }
            else if ( textBox17.Text != "" && textBox17.Text == Logins.username )
            {
                textBox17.Text = "";
                textBox16.Text = "";
                model.YQ09 = "";
                textBox16.Text = "";
            }

            if ( textBox45.Text == "" )
                textBox45.Text = Logins.username;
            else if ( textBox45.Text != "" && textBox45.Text == Logins.username )
                textBox45.Text = "";

            dateTimePicker1 . Value = DateTime . Now;
        }
        //窗体关闭
        private void R_Frmyouqimocontract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        #endregion

        #region Main
        //add
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            model.YQ02 = "";
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            
            textBox12.Enabled = false;
            comboBox2.Enabled = comboBox4.Enabled = false;
            dateTimePicker2.Enabled = dateTimePicker4.Enabled = dateTimePicker1.Enabled = false;
            saves = "1";
            button15.Enabled = false;
            label24.Visible = label36.Visible = false;

            model.YQ99 = oddNumbers.purchaseContract( "SELECT MAX(AJ001) AJ001 FROM R_PQAJ" ,"AJ001" ,"R_339-" );
        }
        protected override void add ( )
        {
            base.add( );

            od.StartPosition = FormStartPosition.CenterScreen;
            od.PassDataBetweenForm += new Order.PassDataBetweenFormHandler( od_PassDataBetweenForm );
            od.ShowDialog( );

            if ( ord == "计划" )
            {
                orde( );

                comboBox2.Enabled = comboBox4.Enabled = true;
                button16.Enabled = true;
                button5.Enabled = false;
                every( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox2.Enabled = comboBox4.Enabled = false;
                button16.Enabled = false;
                button5.Enabled = true;
                every( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                saves = "1";
                model.YQ99 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //Delete
        void dele ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.DeleteOddNum( model.YQ99 ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );

            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                model.YQ02 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );


                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                textBox12.Enabled = false;
                label36.Visible = label24.Visible = false;
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            result = false;
            if ( model == null )
                return;
            result = bll.ExistsReview( model.YQ99 ,"R_339" );
            if ( result == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单号:" + model.YQ99 + "的单据状态为执行,不允许删除" );
            }
            else
                dele( );
        }
        //Update
        protected override void update ( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReview( model.YQ99 ,"R_339" );
            if ( result == true )
                MessageBox.Show( "单号:" + model.YQ99 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox12.Enabled = false;
                button15.Enabled = false;
                dateTimePicker2.Enabled = dateTimePicker4.Enabled = dateTimePicker1.Enabled = false;
                comboBox2.Enabled = comboBox4.Enabled = false;
                if ( string.IsNullOrEmpty( textBox49.Text ) )
                {
                    comboBox2.Enabled = comboBox4.Enabled = true;
                    button16.Enabled = true;
                    button5.Enabled = false;
                }
                else
                {
                    comboBox2.Enabled = comboBox4.Enabled = false;
                    button16.Enabled = false;
                    button5.Enabled = true;
                }
            }
        }
        //Reviews
        protected override void revirw ( )
        {
            base.revirw( );
            bool result = false, over = false;
            if ( textBox48.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox13.Text ) )
                over = false;
            else
                over = true;
            Reviews( "YQ99" ,model.YQ99 ,"R_PQI" ,this ,model.YQ03 ,"R_339" ,result ,over,null/*,"YQ07" ,"YQ96" ,"R_PQI" ,"YQ99" ,YQ99 ,ord ,textBox49.Text,"R_339" */);
            result = false;
            result = sp.reviewImple( "R_339" ,model.YQ99 );
            if ( result == true )
            {
                label24.Visible = true;
                button15.Enabled = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIC" ,"R_PQI" ,"YQ99" ,model.YQ99 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label24.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfReceviable( model.YQ99 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["YQ03"].ToString( );

                modelAm.AM175 = modelAm.AM178 = modelAm.AM182 = modelAm.AM185 = modelAm.AM188 = modelAm.AM191 = modelAm.AM194 = modelAm.AM197 = modelAm.AM177 = modelAm.AM184 = modelAm.AM190 = modelAm.AM196 = modelAm.AM200 = modelAm.AM203 = modelAm.AM205 = modelAm.AM207 = 0;
                modelAm.AM175 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购'AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='F'" ) );
                modelAm.AM177 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='外购' AND YQ123='T'" ) );
                modelAm.AM188 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='F'" ) );
                modelAm.AM200 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆一类' and YQ101='库存' AND YQ123='T'" ) );
                modelAm.AM178 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购'  AND YQ123='F'" ) );
                modelAm.AM184 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='外购' AND YQ123='T'" ) );
                modelAm.AM191 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='F'" ) );
                modelAm.AM203 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '水性漆二类' and YQ101='库存' AND YQ123='T'" ) );
                modelAm.AM182 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='F'" ) );
                modelAm.AM190 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='外购' AND YQ123='T'" ) );
                modelAm.AM194 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='F'" ) );
                modelAm.AM205 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '硝基漆' and YQ101='库存' AND YQ123='T'" ) );
                modelAm.AM185 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='F'" ) );
                modelAm.AM196 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='外购' AND YQ123='T'" ) );
                modelAm.AM197 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='F'" ) );
                modelAm.AM207 = string.IsNullOrEmpty( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(YQ)" ,"YQ03='" + modelAm.AM002 + "' and YQ12= '香蕉水' and YQ101='库存' AND YQ123='T'" ) );
                bll.UpdateOfReceivable( modelAm ,model.YQ99 );
            }
        }
        //Print
        bool result = false;
        void trueOrFalse ( )
        {
            //计划  流水号空  使用外购   库存  流水号不为空  使用库存
            model.YQ107 = comboBox4.Text;
            if ( ( string.IsNullOrEmpty( textBox49.Text ) && bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox49.Text ) && bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( model.YQ99 ,bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) ,model.YQ107 ,bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) ) == false )
                    {
                        //所有都不等就是没有出或入
                        result = false;
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                        result = true;
                }
            }
        }
        protected override void print ( )
        {
            base.print( );
            //sp.panDuan( "YQ07" ,"YQ96" ,"R_PQI" ,"YQ99" ,YQ99 ,ord ,textBox49.Text ,"R_339");

            //if ( yesOrNoPrint( ) == true )
            //{
            //    MessageBox.Show( "此单据中有使用525库存,不允许打印" );
            //    return;
            //}
            if ( !string.IsNullOrEmpty( textBox49.Text ) && bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "外购" )
            {
                if ( label24.Visible == true )
                {

                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQI" ,"YQ136" ,model . YQ99 ,"YQ99" );

                    CreateDataSet( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_339.frx" );
                    //report.Load( Environment.CurrentDirectory + "\\R_339.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else
                    MessageBox.Show( "非执行单据不能打印" );
            }
            else
            {
                trueOrFalse( );
                if ( result == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQI" ,"YQ136" ,model . YQ99 ,"YQ99" );

                    CreateDataSet ( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_339.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }
        }
        //若使用525库存  则不能打印和导出
        bool yesOrNoPrint ( )
        {
            result = false;
            if ( bandedGridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["YQ120"].ToString( ) ) )
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        //Export
        protected override void export ( )
        {
            base.export( );
            //sp.panDuan( "YQ07" ,"YQ96" ,"R_PQI" ,"YQ99" ,YQ99 ,ord ,textBox49.Text ,"R_339");
            //if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) && radioButton11.Checked )
            //{
            //    if ( label24.Visible == true )
            //    {
            if ( yesOrNoPrint( ) == true )
            {
                MessageBox.Show( "此单据中有使用525库存,不允许打印" );
                return;
            }

            CreateDataSet( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_339.frx" );
            //report.Load( Environment.CurrentDirectory + "\\R_339.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "非执行单据不能导出" );
            //}
            //else
            //{
            //    trueOrFalse( );
            //    if ( result == true )
            //    {
            //        CreateDataSet( );
            //        report.Load( Environment.CurrentDirectory + "\\R_339.frx" );
            //        report.RegisterData( RDataSet );
            //        report.Prepare( );
            //        XMLExport exprots = new XMLExport( );
            //        exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "没有出入库的单据不能导出" );
            //}
        }
        //Save
        void addes ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox12.Enabled = false;
            copy = "";
            saves = "2";
            weihu = "";
            label36.Visible = false;
            button15.Enabled = false;
        }
        void updates ( )
        {
            result = false;
            result = bll.UpdateMain( model );
            if ( result == false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQIC" ,"R_PQI" ,"YQ99" ,model.YQ99 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                addes( );
            }
        }
        void vari ( )
        {
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                model.YQ01 = lookUpEdit1.EditValue.ToString( );
            else
                model.YQ01 = "";
            model.YQ03 = textBox49.Text;
            model.YQ04 = textBox17.Text;
            model.YQ05 = dateTimePicker1.Value;
            model.YQ07 = textBox13.Text;
            model.YQ08 = dateTimePicker2.Value;
            model.YQ09 = textBox16.Text;
            model.YQ17 = dateTimePicker3.Value;
            model.YQ18 = dateTimePicker4.Value;
            model.YQ20 = textBox15.Text;
            model.YQ21 = textBox14.Text;
            model.YQ22 = checkBox36.Checked == true ? "T" : "F";
            model.YQ23 = checkBox37.Checked == true ? "T" : "F";
            model.YQ24 = checkBox38.Checked == true ? "T" : "F";
            model.YQ25 = checkBox39.Checked == true ? "T" : "F";
            model.YQ26 = checkBox40.Checked == true ? "T" : "F";
            model.YQ27 = comboBox16.Text;
            model.YQ28 = dateTimePicker5.Value;
            model.YQ29 = comboBox17.Text;
            model.YQ30 = dateTimePicker6.Value;
            model.YQ31 = textBox26.Text;
            model.YQ32 = checkBox4.Checked == true ? "T" : "F";
            model.YQ33 = checkBox7.Checked == true ? "T" : "F";
            model.YQ34 = checkBox5.Checked == true ? "T" : "F";
            model.YQ35 = checkBox6.Checked == true ? "T" : "F";
            if ( radioButton1.Checked )
                model.YQ36 = "在内";
            else if ( radioButton2.Checked )
                model.YQ36 = "不在内";
            else
                model.YQ36 = string.Empty;
            if ( radioButton3.Checked )
                model.YQ37 = "有";
            else if ( radioButton4.Checked )
                model.YQ37 = "没有";
            else
                model.YQ37 = string.Empty;
            if ( radioButton6.Checked )
            {
                model.YQ38 = "已检测";
                model.YQ39 = textBox24.Text;
            }
            else if ( radioButton5.Checked )
            {
                model.YQ38 = "未检测";
                model.YQ39 = string.Empty;
            }
            else
            {
                model.YQ38 = string.Empty;
                model.YQ39 = string.Empty;
            }
            model.YQ40 = checkBox1.Checked == true ? "T" : "F";
            model.YQ41 = checkBox2.Checked == true ? "T" : "F";
            model.YQ42 = checkBox3.Checked == true ? "T" : "F";
            model.YQ43 = checkBox8.Checked == true ? "T" : "F";
            model.YQ44 = checkBox10.Checked == true ? "T" : "F";
            model.YQ45 = checkBox9.Checked == true ? "T" : "F";
            model.YQ46 = comboBox18.Text;
            model.YQ47 = dateTimePicker7.Value;
            model.YQ48 = comboBox19.Text;
            model.YQ49 = dateTimePicker8.Value;
            model.YQ50 = textBox31.Text;
            model.YQ51 = textBox30.Text;
            model.YQ52 = checkBox11.Checked == true ? "T" : "F";
            model.YQ53 = checkBox12.Checked == true ? "T" : "F";
            model.YQ54 = checkBox13.Checked == true ? "T" : "F";
            model.YQ55 = textBox1.Text;
            model.YQ56 = checkBox18.Checked == true ? "T" : "F";
            model.YQ57 = checkBox20.Checked == true ? "T" : "F";
            model.YQ58 = checkBox19.Checked == true ? "T" : "F";
            model.YQ59 = checkBox21.Checked == true ? "T" : "F";
            model.YQ60 = checkBox15.Checked == true ? "T" + "," + textBox29.Text : "F";
            model.YQ61 = checkBox14.Checked == true ? "T" : "F";
            model.YQ62 = checkBox17.Checked == true ? "T" : "F";
            model.YQ63 = checkBox25.Checked == true ? "T" : "F";
            model.YQ64 = checkBox22.Checked == true ? "T" : "F";
            model.YQ65 = checkBox23.Checked == true ? "T" : "F";
            model.YQ66 = checkBox24.Checked == true ? "T" : "F";
            model.YQ67 = checkBox29.Checked == true ? "T" : "F";
            model.YQ68 = checkBox26.Checked == true ? "T" : "F";
            model.YQ69 = checkBox27.Checked == true ? "T" : "F";
            model.YQ70 = checkBox28.Checked == true ? "T" : "F";
            model.YQ71 = checkBox33.Checked == true ? "T" : "F";
            model.YQ72 = checkBox35.Checked == true ? "T" : "F";
            model.YQ73 = checkBox32.Checked == true ? "T" : "F";
            model.YQ74 = checkBox31.Checked == true ? "T" : "F";
            model.YQ75 = checkBox34.Checked == true ? "T" : "F";
            model.YQ76 = checkBox30.Checked == true ? "T" : "F";
            model.YQ77 = string.IsNullOrEmpty( textBox33.Text ) == true ? 0 : Convert.ToInt64( textBox33.Text );
            model.YQ78 = comboBox5.Text;
            model.YQ79 = dateTimePicker9.Value;
            if ( radioButton7.Checked )
            {
                model.YQ80 = "合格";
                model.YQ81 = string.Empty;
            }
            else if ( radioButton8.Checked )
            {
                model.YQ80 = "退货";
                model.YQ81 = string.Empty;
            }
            else if ( radioButton9.Checked )
            {
                model.YQ80 = "条件接收";
                model.YQ81 = textBox35.Text;
            }
            else
            {
                model.YQ80 = string.Empty;
                model.YQ81 = string.Empty;
            }
            model.YQ82 = string.IsNullOrEmpty( textBox36.Text ) == true ? 0 : Convert.ToInt64( textBox36.Text );
            model.YQ83 = string.IsNullOrEmpty( textBox37.Text ) == true ? 0 : Convert.ToInt64( textBox37.Text );
            model.YQ84 = string.IsNullOrEmpty( textBox38.Text ) == true ? 0 : Convert.ToInt64( textBox38.Text );
            model.YQ85 = string.IsNullOrEmpty( textBox41.Text ) == true ? 0 : Convert.ToInt64( textBox41.Text );
            model.YQ86 = string.IsNullOrEmpty( textBox40.Text ) == true ? 0 : Convert.ToInt64( textBox40.Text );
            model.YQ87 = string.IsNullOrEmpty( textBox39.Text ) == true ? 0 : Convert.ToInt64( textBox39.Text );
            model.YQ88 = string.IsNullOrEmpty( textBox44.Text ) == true ? 0 : Convert.ToInt64( textBox44.Text );
            model.YQ89 = string.IsNullOrEmpty( textBox43.Text ) == true ? 0 : Convert.ToInt64( textBox43.Text );
            model.YQ90 = string.IsNullOrEmpty( textBox42.Text ) == true ? 0 : Convert.ToInt64( textBox42.Text );
            model.YQ91 = textBox45.Text;
            model.YQ92 = textBox46.Text;
            model.YQ93 = dateTimePicker10.Value;
            model.YQ94 = textBox47.Text;
            model.YQ95 = dateTimePicker11.Value;
            model.YQ96 = textBox48.Text;
            model.YQ97 = dateTimePicker12.Value;
            model.YQ98 = dateTimePicker13.Value;
            model.YQ102 = checkBox41.Checked == true ? "T" : "F";
            model.YQ103 = textBox12.Text;
            model.YQ105 = comboBox2.Text;
            model.YQ106 = textBox50.Text;
            model.YQ107 = comboBox4.Text;
            model.YQ108 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
            model.YQ111 = string.Empty;
            model.YQ123 = checkBox16.Checked == true ? "T" : "F";
            model.YQ124 = lookUpEdit2.Text;
        }
        protected override void save ( )
        {
            base.save( );


            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "请选择采购人" );
                return;
            }
            vari( );
            DataTable daw = bll.GetDataTableMain( model.YQ99 );

            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox12.Text ) )
                {
                    MessageBox.Show( "请填写维护意见" );
                    return;
                }
                    model.YQ104 = daw.Rows[0]["YQ104"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    updates( );
            }
            else
            {
                model.YQ104 = string.Empty;
                if ( daw.Rows.Count < 1 )
                {
                    if ( dateTimePicker3.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
                    {
                        MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                        return;
                    }
                    addes( );
                }
                else
                {
                    if ( copy == "1" )
                    {
                        if ( dateTimePicker3.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
                        {
                            MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                            return;
                        }

                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model.YQ02 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        // AND YQ04=@YQ04  ,new SqlParameter( "@YQ04" ,YQ04 )
                        DataTable dyu = bll.GetDataTableCopy( model.YQ99 );
                        if ( dyu.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            int proNum = 0;

                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] );
                                if ( proNum != model . YQ108 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
                                {
                                    if ( dyu.Select( "YQ10='" + bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) + "' AND YQ11='" + bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "' AND YQ12='" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) + "' AND YQ107='" + model.YQ107 + "'" ).Length > 0 )
                                    {
                                        if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + YQ04 + "
                                            MessageBox.Show( "已经存在\n\r货号:" + model.YQ107 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) + "\n\r加工工艺:" + bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "\n\r色号:" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) + "\n\r的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }
                                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
                                {
                                    if ( fc.getInventory( bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) ,bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) ,bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) ) == true )
                                        MessageBox.Show( "零件名称:" + bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) + "\n\r工序:" + bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "\n\r色号.按色号与色板间:" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) + "\n\r在R_525中有剩余油漆,请选择是否使用R_525剩余库存" );

                                    if ( dyu.Select( "YQ10='" + bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) + "' AND YQ11='" + bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "' AND YQ12='" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) + "' AND YQ03='" + model.YQ03 + "'" ).Length > 0 )
                                    {
                                        if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + YQ04 + "
                                            MessageBox.Show( "已经存在\n\r流水号:" + model.YQ03 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["YQ10"].ToString( ) + "\n\r加工工艺:" + bandedGridView1.GetDataRow( i )["YQ11"].ToString( ) + "\n\r色号:" + bandedGridView1.GetDataRow( i )["YQ12"].ToString( ) + "\n\r的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }

                            }

                        }
                    }
                    else
                        updates( );
                }
            }
        }
        //Cancel
        protected override void cancel ( )
        {
            base.cancel( );

            if ( saves == "1" && weihu != "1" || copy == "1" )
            {
                model.YQ02 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolExport.Enabled = toolPrint.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label36.Visible = false;
                try
                {
                    bll.DeleteOddNum( model.YQ99 ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( saves == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            textBox12.Enabled = false;
        }
        //Main
        protected override void maintain ( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReview( model.YQ99 ,"R_339" );
            if ( result == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox12.Enabled = true;

                weihu = "1";
                dateTimePicker2.Enabled = dateTimePicker4.Enabled = dateTimePicker1.Enabled = false;
                label24.Visible = true;
                button15.Enabled = true;
                if ( !string.IsNullOrEmpty( textBox49.Text ) )
                {
                    comboBox2.Enabled = comboBox4.Enabled = false;
                    //textBox53.Enabled = false;
                    button16.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    comboBox2.Enabled = comboBox4.Enabled = true;
                    //textBox53.Enabled = true;
                    button16.Enabled = true;
                    button5.Enabled = false;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //Library
        protected override void library ( )
        {
            base.library( );

            if ( label24.Visible == true )
            {
                if ( string.IsNullOrEmpty( comboBox2.Text ) )
                    MessageBox.Show( "产品名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                        MessageBox.Show( "产品数量不可为空" );
                    else
                    {
                        if ( bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "外购" )
                            MessageBox.Show( "外购订单不可以出库" );
                        else
                        {
                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                result = fc . Library ( comboBox2 . Text ,"" ,textBox49 . Text ,textBox53 . Text ,bandedGridView1 . GetDataRow ( i ) [ "YQ10" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "YQ12" ] . ToString ( ) ,"" ,"" ,"" ,bandedGridView1 . GetDataRow ( i ) [ "YQ15" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "YQ19" ] . ToString ( ) ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,model . YQ99 ,lookUpEdit2 . Text );
                                if ( result == false )
                                {
                                    MessageBox.Show( "出库失败" );
                                    break;
                                }
                                else if ( i == bandedGridView1.RowCount - 1 )
                                    MessageBox.Show( "出库成功" );
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能出库" );
        }
        //Storage
        protected override void storage ( )
        {
            base.storage( );

            if ( label24.Visible == true )
            {
                if ( string.IsNullOrEmpty( comboBox2.Text ) )
                    MessageBox.Show( "产品名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                        MessageBox.Show( "产品数量不可为空" );
                    else
                    {
                        if ( bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "库存" )
                            MessageBox.Show( "库存无法入库,请选择出库或更改状态" );
                        else
                        {
                            if ( bandedGridView1.GetDataRow( 0 )["YQ101"].ToString( ) == "外购" && ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) )
                                MessageBox.Show( "实际订单不允许入库" );
                            else
                            {
                                string costPerSet = "";
                                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                                {
                                    costPerSet = "";
                                    costPerSet = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["YQ109"].ToString( ) ) == true ? 0.ToString( ) : ( Convert.ToDecimal( textBox53.Text ) / Convert.ToDecimal( bandedGridView1.GetDataRow( i )["YQ109"].ToString( ) ) ).ToString( );
                                    result = fc . Storage ( comboBox2 . Text ,"" ,textBox53 . Text ,bandedGridView1 . GetDataRow ( i ) [ "YQ10" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "YQ12" ] . ToString ( ) ,"" ,costPerSet ,"" ,bandedGridView1 . GetDataRow ( i ) [ "YQ15" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "YQ109" ] . ToString ( ) ,textBox17 . Text ,dateTimePicker2 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,model . YQ99 ,bandedGridView1 . GetDataRow ( i ) [ "YQ125" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "YQ126" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox2 . Text ,textBox10 . Text );
                                    if ( result == false )
                                    {
                                        MessageBox.Show( "入库失败" );
                                        break;
                                    }
                                    else if ( i == bandedGridView1.RowCount - 1 )
                                    {
                                        MessageBox.Show( "入库成功" );
                                        try
                                        {
                                            for ( int k = 0 ; k < bandedGridView1.RowCount ; k++ )
                                            {
                                                model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( k )["idx"].ToString( ) );
                                                model.YQ125 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
                                                model.YQ126 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["YQ109"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( k )["YQ109"].ToString( ) );
                                                bll.UpdateStr( model );
                                            }
                                        }
                                        catch { }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能入库" );
        }
        //Copy
        protected override void copys ( )
        {
            base.copys( );

            if ( label24.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.Copy( model.YQ99 ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                model.YQ99 = oddNumbers.purchaseContract( "SELECT MAX(AJ001) AJ001 FROM R_PQAJ" ,"AJ001" ,"R_339-" );
                stateOfOdd = "更改复制单号";
                result = bll.UpdateCo( model.YQ99 ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    bll.DeleteCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    textBox12.Enabled = false;
                    comboBox2.Enabled = comboBox4.Enabled = true;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                    saves = "2";
                    copy = "1";
                    weihu = "";
                    label24.Visible = false;
                    button15.Enabled = false;
                    queryContent( );
                }
            }
        }
        #endregion
        
        #region Table
        //Build
        void adds ( )
        {
            if ( model.YQ02 == null )
                model.YQ02 = "";
            model.YQ03 = textBox49.Text;
            model.YQ09 = textBox16.Text;
            model.YQ106 = textBox50.Text;
            model.YQ105 = comboBox2.Text;
            model.YQ107 = comboBox4.Text;
            model.YQ108 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
            model.YQ06 = textBox27.Text;
            model.YQ10 = textBox28.Text;
            model.YQ11 = textBox32.Text;
            model.YQ12 = comboBox14.Text;
            model.YQ13 = string.IsNullOrEmpty( comboBox3.Text ) == true ? 0 : Convert.ToDecimal( comboBox3.Text );
            model.YQ14 = string.IsNullOrEmpty( textBox51.Text ) == true ? 0 : Convert.ToDecimal( textBox51.Text );
            model.YQ15 = string.IsNullOrEmpty( textBox59.Text ) == true ? 0 : Convert.ToDecimal( textBox59.Text );
            model.YQ16 = string.IsNullOrEmpty( textBox52.Text ) == true ? 0 : Convert.ToDecimal( textBox52.Text );
            if ( radioButton11.Checked )
            {
                model.YQ101 = "库存";
                if ( radioButton12.Checked )
                    model.YQ19 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToDecimal( Math.Round( Convert.ToDecimal( textBox19.Text ) ,1 ) );
                else if ( radioButton13.Checked )
                    model.YQ19 = string.IsNullOrEmpty( textBox34.Text ) == true ? 0 : Convert.ToDecimal( Math.Round( Convert.ToDecimal( textBox34.Text ) ,1 ) );
                model.YQ109 = 0M;
            }
            else if ( radioButton10.Checked )
            {
                model.YQ101 = "外购";
                if ( radioButton12.Checked )
                    model.YQ109 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToDecimal( Math.Round( Convert.ToDecimal( textBox19.Text ) ,1 ) );
                else if ( radioButton13.Checked )
                    model.YQ109 = string.IsNullOrEmpty( textBox34.Text ) == true ? 0 : Convert.ToDecimal( Math.Round( Convert.ToDecimal( textBox34.Text ) ,1 ) );
                model.YQ19 = 0M;
            }
            model.YQ112 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToInt32( textBox11.Text );
            model.YQ113 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToInt32( textBox20.Text );
            model.YQ114 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToInt32( textBox21.Text );
            model.YQ115 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToDecimal( textBox22.Text );
            model.YQ116 = string.IsNullOrEmpty( textBox25.Text ) == true ? 0 : Convert.ToInt32( textBox25.Text );
            model.YQ117 = textBox23.Text;
            model.YQ119 = textBox54.Text;
            model.YQ120 = textBox55.Text;
            model.YQ121 = textBox56.Text;
            model.YQ129 = textBox60.Text;
            model.YQ130 = textBox61.Text;
            model.YQ131 = textBox62.Text;
            model . YQ134 = string . IsNullOrEmpty ( textBox58 . Text ) == true ? 0 : Convert . ToDecimal ( textBox58 . Text );
            model . YQ135 = string . IsNullOrEmpty ( textBox63 . Text ) == true ? 0 : Convert . ToDecimal ( textBox63 . Text );
        }
        void build ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }

            result = bll.Add( model ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,"新建" ,stateOfOdd ,MulaolaoBll . Drity . GetDt ( ) );
            if ( result == false )
                MessageBox.Show( "录入数据失败,请刷新再试" );
            else
            {
                MessageBox.Show( "成功录入数据" );

                every( );
                strWhere = "1=1";
                strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
                refre( );
            }
        }
        void builds ( )
        {
            DataTable da = bll.GetDataTableContrast( model );
            if ( da.Rows.Count > 0 )
            {
                if ( da.Select( "YQ15='" + textBox59.Text + "'" ).Length <= 0 )
                    MessageBox.Show( "油漆现价与计划订单不一致,应为:" + da.Rows[0]["YQ15"].ToString( ) + "" );
                else
                {
                    if ( da.Select( "YQ13='" + comboBox3.Text + "'" ).Length <= 0 )
                        MessageBox.Show( "每板摆用率%与计划订单不一致,应为:" + da.Rows[0]["YQ13"].ToString( ) + "" );
                    else
                        build( );
                }
            }

            else
                build( );
        }
        void outSource ( )
        {
            if ( radioButton11.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                if ( string.IsNullOrEmpty( comboBox3.Text ) )
                    MessageBox.Show( "每板摆用率%不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                        MessageBox.Show( "产品数量不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox59.Text ) )
                            MessageBox.Show( "油漆现价不可为空" );
                        else
                        {
                            if ( !radioButton12.Checked && !radioButton13.Checked )
                                MessageBox.Show( "请选择板算或平米算" );
                            else
                            {
                                string str = "";
                                if ( radioButton12.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                                    if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                    {
                                        if ( radioButton10.Checked )
                                        {
                                            if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                            {
                                                if ( Convert.ToDecimal( textBox19.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                    MessageBox.Show( "外购数量不等于R_525剩余库存量,请核实" );
                                                else
                                                {
                                                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                                        MessageBox.Show( "外购数量有误,请核查" );
                                                    else
                                                        builds( );
                                                }
                                            }
                                            else
                                            {
                                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                                    MessageBox.Show( "外购数量有误,请核查" );
                                                else
                                                    builds( );
                                            }
                                        }
                                        else
                                        {
                                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                                MessageBox.Show( "外购数量有误,请核查" );
                                            else
                                                builds( );
                                        }
                                    }
                                    else
                                        MessageBox.Show( "外购数量不可为空" );
                                }
                                else if ( radioButton13.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );

                                    if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                    {
                                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                            MessageBox.Show( "外购数量有误,请核查" );
                                        else
                                        {
                                            if ( radioButton10.Checked )
                                            {
                                                if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                                {
                                                    if ( Convert.ToDecimal( textBox34.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                        MessageBox.Show( "外购数量不等于R_525库存数量,请核实" );
                                                    else
                                                        builds( );
                                                }
                                                else
                                                    builds( );
                                            }
                                            else
                                                builds( );
                                        }

                                    }
                                    else
                                        MessageBox.Show( "外购数量不可为空" );
                                }
                            }
                        }
                    }
                }
            }
        }
        void outSources ( )
        {
            if ( radioButton11 . Checked )
            {
                MessageBox . Show ( "只能开外购合同" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "每板摆用率%不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox53 . Text ) )
            {
                MessageBox . Show ( "产品数量不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox59 . Text ) )
            {
                MessageBox . Show ( "油漆现价不可为空" );
                return;
            }
            if ( !radioButton12 . Checked && !radioButton13 . Checked )
            {
                MessageBox . Show ( "请选择板算或平米算" );
                return;
            }
            string str = "";
            if ( radioButton12 . Checked )
            {
                str = Math . Round ( Convert . ToDecimal ( Operation . MultiAll ( textBox51 . Text ,comboBox3 . Text ,textBox53 . Text ,textBox11 . Text ,textBox20 . Text ,textBox25 . Text ,textBox59 . Text ,textBox21 . Text ,textBox22 . Text ) ) ,1 ) . ToString ( );
                if ( !string . IsNullOrEmpty ( textBox19 . Text ) )
                {
                    if ( Convert . ToDecimal ( str ) != Convert . ToDecimal ( textBox19 . Text ) )
                    {
                        MessageBox . Show ( "外购数量有误,请核查" );
                        return;
                    }
                    if ( radioButton10 . Checked )
                    {
                        if ( !string . IsNullOrEmpty ( textBox57 . Text ) )
                        {
                            if ( Convert . ToDecimal ( textBox19 . Text ) != Convert . ToDecimal ( textBox57 . Text ) )
                                MessageBox . Show ( "外购数量不等于R_525剩余数量,请核实" );
                            else
                                build ( );
                        }
                        else
                            build ( );
                    }
                    else
                        build ( );
                }
                else
                    MessageBox . Show ( "外购数量不可为空" );
            }
            else if ( radioButton13 . Checked )
            {
                str = Math . Round ( Convert . ToDecimal ( Operation . MultiAllP ( textBox53 . Text ,textBox11 . Text ,textBox21 . Text ,textBox22 . Text ,comboBox3 . Text ,textBox52 . Text ,textBox59 . Text ,textBox25 . Text ,textBox20 . Text ) ) ,1 ) . ToString ( );
                if ( !string . IsNullOrEmpty ( textBox34 . Text ) )
                {
                    if ( Convert . ToDecimal ( str ) != Convert . ToDecimal ( textBox34 . Text ) )
                        MessageBox . Show ( "外购数量有误,请核查" );
                    else
                    {
                        if ( radioButton10 . Checked )
                        {
                            if ( !string . IsNullOrEmpty ( textBox57 . Text ) )
                            {
                                if ( Convert . ToDecimal ( textBox34 . Text ) != Convert . ToDecimal ( textBox57 . Text ) )
                                    MessageBox . Show ( "外购数量不等于R_525剩余数量,请核实" );
                                else
                                    build ( );
                            }
                            else
                                build ( );
                        }
                        else
                            build ( );
                    }

                }
                else
                    MessageBox . Show ( "外购数量不可为空" );
            }
        }
        void plan ( )
        {
            if ( radioButton10.Checked == true )
            {
                if ( Logins.number .Equals( "MLL-0001") )
                {
                    if ( string.IsNullOrEmpty( comboBox3.Text ) )
                        MessageBox.Show( "每板摆用率%不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox53.Text ) )
                            MessageBox.Show( "产品数量不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox59.Text ) )
                                MessageBox.Show( "油漆现价不可为空" );
                            else
                            {
                                if ( !radioButton12.Checked && !radioButton13.Checked )
                                    MessageBox.Show( "请选择板算或平米算" );
                                else
                                {
                                    string str = "";
                                    if ( radioButton12.Checked )
                                    {
                                        str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                                        if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                        {
                                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                                MessageBox.Show( "外购数量有误,请核查" );
                                            else
                                            {
                                                if ( radioButton10.Checked )
                                                {
                                                    if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                                    {
                                                        if ( Convert.ToDecimal( textBox19.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                            MessageBox.Show( "外购数量不等于R_525剩余数量,请核实" );
                                                        else
                                                            build( );
                                                    }
                                                    else
                                                        build( );
                                                }
                                                else
                                                    build( );
                                            }

                                        }
                                        else
                                            MessageBox.Show( "外购数量不可为空" );
                                    }
                                    else if ( radioButton13.Checked )
                                    {
                                        str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                                        if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                        {
                                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                                MessageBox.Show( "外购数量有误,请核查" );
                                            else
                                            {
                                                if ( radioButton10.Checked )
                                                {
                                                    if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                                    {
                                                        if ( Convert.ToDecimal( textBox34.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                            MessageBox.Show( "外购数量不等于R_525剩余数量,请核实" );
                                                        else
                                                            build( );
                                                    }
                                                    else
                                                        build( );
                                                }
                                                else
                                                    build( );
                                            }

                                        }
                                        else
                                            MessageBox.Show( "外购数量不可为空" );
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show( "库存还有数量,需要总经理补开" );
            }
            else
            {
                if ( string.IsNullOrEmpty( comboBox3.Text ) )
                    MessageBox.Show( "每板摆用率%不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                        MessageBox.Show( "产品数量不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox59.Text ) )
                            MessageBox.Show( "油漆现价不可为空" );
                        else
                        {
                            if ( !radioButton12.Checked && !radioButton13.Checked )
                                MessageBox.Show( "请选择板算或平方算" );
                            else
                            {
                                string str = "";
                                if ( radioButton12.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,0 ).ToString( );
                                    if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                    {
                                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                            MessageBox.Show( "出库数量有误,请核查" );
                                        else
                                        {
                                            if ( !string.IsNullOrEmpty( textBox4.Text ) )
                                            {
                                                if ( Convert.ToDecimal( textBox4.Text ) < Convert.ToDecimal( textBox19.Text ) )
                                                    MessageBox.Show( "出库数量必须小于库存数量" );
                                                else
                                                    builds( );
                                            }
                                        }

                                    }
                                    else
                                        MessageBox.Show( "使用库存数量不可为空" );
                                }
                                else if ( radioButton13.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,0 ).ToString( );
                                    if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                    {
                                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                            MessageBox.Show( "出库数量有误,请核查" );
                                        else
                                        {
                                            if ( !string.IsNullOrEmpty( textBox4.Text ) )
                                            {
                                                if ( Convert.ToDecimal( textBox4.Text ) < Convert.ToDecimal( textBox34.Text ) )
                                                    MessageBox.Show( "出库数量必须小于库存数量" );
                                                else
                                                    builds( );
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show( "使用库存数量不可为空" );
                                }
                            }
                        }
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( model.YQ02 ) || string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox53.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox28.Text ) )
            {
                MessageBox.Show( "零件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox14.Text ) )
            {
                MessageBox.Show( "色号.按色号与色板间" );
                return;
            }
            if ( !radioButton10.Checked && !radioButton11.Checked )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }
            if ( !radioButton12.Checked && !radioButton13.Checked )
            {
                MessageBox.Show( "请选择板算或平方算" );
                return;
            }
            adds( );

            if ( string.IsNullOrEmpty( textBox55.Text ) )
            {
                if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) && radioButton10.Checked )
                {
                    if ( string.IsNullOrEmpty( textBox28.Text ) )
                        MessageBox.Show( "零件名称不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox32.Text ) )
                            MessageBox.Show( "工序不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( comboBox14.Text ) )
                                MessageBox.Show( "色号不可为空" );
                            else
                            {
                                if ( fc.getInventory( textBox28 ,textBox32 ,comboBox14 ) == true )
                                    MessageBox.Show( "零件名称:" + textBox28.Text + "\n\r工序:" + textBox32.Text + "\n\r色号.按色号与色板间:" + comboBox14.Text + "\n\r在R_525中有剩余油漆,请选择是否使用R_525剩余库存" );
                            }
                        }
                    }
                }
            }
           

            #region 计划  更改新建  无流水号
            if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = bll.GetDataTableYesOrNoPlan( model );
                //有  继续开  只能开外购  且每张套数  每张单价  原价/m³都必须与第一份计划订单相同
                if ( yesNoAcPlan.Rows.Count > 0 && string.IsNullOrEmpty( yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) == false )
                {
                    DataTable yesNoAdPlan = bll.GetDataTableYesNoAdPlan( yesNoAcPlan.Rows[0]["AC18"].ToString( ) );
                    //有
                    if ( yesNoAdPlan.Rows.Count > 0 && !string.IsNullOrEmpty( yesNoAdPlan.Rows[0]["AD05"].ToString( ) ) )
                    {
                        if ( yesNoAcPlan.Rows[0]["AC03"].ToString( ) == yesNoAdPlan.Rows[0]["AD05"].ToString( ) )
                            outSources( );
                        else
                        {
                            //开合同人是否是MLL-0001
                            if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                                outSource( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    //无  只能开外购
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                            outSource( );
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                }
                //无  只能开外购
                else
                    outSources( );
            }
            #endregion

            #region 实际  更改新建  有流水号
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
            {

                bool result = pc.PlanActual( model.YQ10 ,model.YQ11 + "*" + model.YQ12 ,string.Empty );
                bool vode = pc.PlanInDataBasePaint( model.YQ03 ,model.YQ10 ,model.YQ11 ,model.YQ12 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSources( );
                    else
                    {
                        if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                            outSources( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
                else
                {
                    if ( vode == true )
                        plan( );
                    else
                    {
                        if ( model.YQ09.Length >= 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
            }
            #endregion

        }
        //Edit
        private void up ( )
        {
            //int num = bandedGridView1.FocusedRowHandle;
            //DataRow row;
            //if ( saves == "2" )
            //{
            //    row = tab.Rows[num];
            //    row.BeginEdit( );
            //    row["YQ06"] = YQ6;
            //    row["YQ10"] = YQ010;
            //    row["YQ11"] = YQ011;
            //    row["YQ12"] = YQ012;
            //    row["YQ13"] = YQ013;
            //    row["YQ14"] = YQ014;
            //    row["YQ15"] = YQ015;
            //    row["YQ16"] = YQ016;
            //    row["YQ19"] = YQ019;
            //    row["YQ101"] = YQ0101;
            //    row["YQ109"] = YQ0109;
            //    row["YQ108"] = YQ1080;
            //    row["YQ112"] = YQ0112;
            //    row["YQ113"] = YQ0113;
            //    row["YQ114"] = YQ0114;
            //    row["YQ116"] = YQ0116;
            //    row["YQ115"] = YQ0115;
            //    row["YQ117"] = YQ0117;
            //    row["YQ119"] = YQ0119;
            //    row["YQ120"] = YQ0120;
            //    row["YQ121"] = YQ0121;
            //    row["YQ123"] = YQ0123;
            //    row.EndEdit( );
            //}
            //else if ( saves == "1" )
            //{
            //    row = dry.Rows[num];
            //    row.BeginEdit( );
            //    row["YQ06"] = YQ6;
            //    row["YQ10"] = YQ010;
            //    row["YQ11"] = YQ011;
            //    row["YQ12"] = YQ012;
            //    row["YQ13"] = YQ013;
            //    row["YQ14"] = YQ014;
            //    row["YQ15"] = YQ015;
            //    row["YQ16"] = YQ016;
            //    row["YQ19"] = YQ019;
            //    row["YQ101"] = YQ0101;
            //    row["YQ109"] = YQ0109;
            //    row["YQ108"] = YQ1080;
            //    row["YQ112"] = YQ0112;
            //    row["YQ113"] = YQ0113;
            //    row["YQ114"] = YQ0114;
            //    row["YQ116"] = YQ0116;
            //    row["YQ115"] = YQ0115;
            //    row["YQ117"] = YQ0117;
            //    row["YQ119"] = YQ0119;
            //    row["YQ120"] = YQ0120;
            //    row["YQ121"] = YQ0121;
            //    row["YQ123"] = YQ0123;
            //    row.EndEdit( );
            //}

            every( );
            button13_Click( null ,null );
        }
        void edit ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }

            result = bll.Update( model ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,"编辑" ,stateOfOdd ,MulaolaoBll . Drity . GetDt ( ) );
            if ( result == false )
                MessageBox.Show( "编辑数据失败,请刷新再试" );
            else
            {
                MessageBox.Show( "成功编辑数据" );

                up( );
                strWhere = "1=1";
                strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
                refre( );
            }
        }
        void planOrActual ( )
        {
            if ( string.IsNullOrEmpty( comboBox3.Text ) )
                MessageBox.Show( "每板摆用率%不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox53.Text ) )
                    MessageBox.Show( "产品数量不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox59.Text ) )
                        MessageBox.Show( "油漆现价不可为空" );
                    else
                    {
                        if ( !radioButton12.Checked && !radioButton13.Checked )
                            MessageBox.Show( "请选择板算或平方算" );
                        else
                        {
                            string str = "";
                            if ( radioButton10.Checked )
                            {
                                if ( radioButton12.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                                    if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                    {
                                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                            MessageBox.Show( "外购数量有误,请核查" );
                                        else
                                        {
                                            if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                            {
                                                if ( Convert.ToDecimal( textBox19.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                    MessageBox.Show( "外购数量不等于R_525剩余数量,请核实" );
                                                else
                                                    edit( );
                                            } else
                                                edit( );
                                        }
                                    }
                                    else
                                        MessageBox.Show( "外购数量不可为空" );
                                }
                                else if ( radioButton13.Checked )
                                {
                                    str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                                    if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                    {
                                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                            MessageBox.Show( "外购数量有误,请核查" );
                                        else
                                        {
                                            if ( !string.IsNullOrEmpty( textBox57.Text ) )
                                            {
                                                if ( Convert.ToDecimal( textBox34.Text ) != Convert.ToDecimal( textBox57.Text ) )
                                                    MessageBox.Show( "外购数量不等于R_525剩余数量,请核实" );
                                                else
                                                    edit( );
                                            } else
                                                edit( );
                                        }

                                    }
                                    else
                                        MessageBox.Show( "外购数量不可为空" );
                                }
                            }
                            else if ( radioButton11.Checked )
                            {
                                if ( radioButton12.Checked )
                                {
                                    if ( !string.IsNullOrEmpty( textBox4.Text ) && !string.IsNullOrEmpty( textBox19.Text ) )
                                    {
                                        if ( Convert.ToDecimal( textBox4.Text ) < Math.Round( Convert.ToDecimal( textBox19.Text ) ,0 ) )
                                            MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                                        else
                                        {
                                            str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                                            if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                            {
                                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                                    MessageBox.Show( "出库数量有误,请核查" );
                                                else
                                                {
                                                    if ( Logins.number == "MLL-0001" )
                                                        edit( );
                                                    else
                                                    {
                                                        if ( !string.IsNullOrEmpty( textBox4.Text ) && Convert.ToDecimal( textBox4.Text ) > 0 )
                                                            MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                                        else
                                                            edit( );
                                                    }
                                                }
                                            }
                                            else
                                                MessageBox.Show( "出库数量不可为空" );
                                        }
                                    }
                                }
                                else if ( radioButton13.Checked )
                                {
                                    if ( !string.IsNullOrEmpty( textBox4.Text ) && !string.IsNullOrEmpty( textBox34.Text ) )
                                    {
                                        if ( Convert.ToDecimal( textBox4.Text ) < Math.Round( Convert.ToDecimal( textBox34.Text ) ,0 ) )
                                            MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                                        else
                                        {
                                            str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                                            if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                            {
                                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                                    MessageBox.Show( "出库数量有误,请核查" );
                                                else
                                                {
                                                    if ( Logins.number == "MLL-0001" )
                                                        edit( );
                                                    else
                                                    {
                                                        if ( !string.IsNullOrEmpty( textBox4.Text ) && Convert.ToDecimal( textBox4.Text ) > 0 )
                                                            MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                                        else
                                                            edit( );
                                                    }
                                                }
                                            }
                                            else
                                                MessageBox.Show( "出库数量不可为空" );
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        void edit_One ( )
        {
            if ( label24.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            result = bll.Update( model ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,"编辑" ,stateOfOdd ,MulaolaoBll . Drity . GetDt ( ) );
            if ( result == false )
                MessageBox.Show( "编辑数据失败,请刷新再试" );
            else
            {
                MessageBox.Show( "成功编辑数据" );

                up( );
                strWhere = "1=1";
                strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
                refre( );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox28.Text ) )
            {
                MessageBox.Show( "零件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox32.Text ) )
            {
                MessageBox.Show( "工序不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox14.Text ) )
            {
                MessageBox.Show( "色号.按色号与色板间不可为空" );
                return;
            }
            if ( !radioButton10.Checked && !radioButton11.Checked )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }
            if ( !radioButton12.Checked && !radioButton13.Checked )
            {
                MessageBox.Show( "请选择板算或平方算" );
                return;
            }
            adds( );

            #region
            if ( lj == model.YQ10 && gy == model.YQ11 && sh == model.YQ12 )
            {
                string str = "";
                if ( radioButton10.Checked )
                {
                    if ( radioButton12.Checked )
                    {
                        str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                            MessageBox.Show( "外购数量有误,请核查" );
                        else
                            edit( );
                    }
                    else if ( radioButton13.Checked )
                    {
                        str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                            MessageBox.Show( "外购数量有误,请核查" );
                        else
                            edit( );
                    }
                }
                else if ( radioButton11.Checked )
                {
                    if ( radioButton12.Checked )
                    {
                        if ( !string.IsNullOrEmpty( textBox4.Text ) && !string.IsNullOrEmpty( textBox19.Text ) )
                        {
                            if ( Convert.ToDecimal( textBox4.Text ) < Convert.ToDecimal( textBox19.Text ) )
                                MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                            else
                            {
                                str = Math.Round( Convert.ToDecimal( Operation.MultiAll( textBox51.Text ,comboBox3.Text ,textBox53.Text ,textBox11.Text ,textBox20.Text ,textBox25.Text ,textBox59.Text ,textBox21.Text ,textBox22.Text ) ) ,1 ).ToString( );
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox19.Text ) )
                                    MessageBox.Show( "出库数量有误,请核查" );
                                else
                                {
                                    if ( Logins.number == "MLL-0001" )
                                        edit( );
                                    else
                                    {
                                        if ( !string.IsNullOrEmpty( textBox4.Text ) && Convert.ToDecimal( textBox4.Text ) > 0 )
                                            MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                        else
                                            edit( );
                                    }
                                }
                            }
                        }
                    }
                    else if ( radioButton13.Checked )
                    {
                        if ( !string.IsNullOrEmpty( textBox4.Text ) && !string.IsNullOrEmpty( textBox34.Text ) )
                        {
                            if ( Convert.ToDecimal( textBox4.Text ) < Convert.ToDecimal( textBox34.Text ) )
                                MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                            else
                            {
                                str = Math.Round( Convert.ToDecimal( Operation.MultiAllP( textBox53.Text ,textBox11.Text ,textBox21.Text ,textBox22.Text ,comboBox3.Text ,textBox52.Text ,textBox59.Text ,textBox25.Text ,textBox20.Text ) ) ,1 ).ToString( );
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox34.Text ) )
                                    MessageBox.Show( "出库数量有误,请核查" );
                                else
                                {
                                    if ( Logins.number == "MLL-0001" )
                                        edit( );
                                    else
                                    {
                                        if ( !string.IsNullOrEmpty( textBox4.Text ) && Convert.ToDecimal( textBox4.Text ) > 0 )
                                            MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                        else
                                            edit( );
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            else
            {
                if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
                {
                    DataTable plan = bll.GetDataTablePlan( model );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r工序:" + model.YQ11 + "\n\r色号.按色号与色板间" + model.YQ12 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        planOrActual( );
                    else
                        planOrActual( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
                {
                    //YQ04=@YQ04 AND 
                    DataTable dwo = bll.GetDataTableDwo( model );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["YQ03"].ToString( ).Contains( model.YQ03 ) == true || model.YQ03.Contains( dwo.Rows[k]["YQ03"].ToString( ) ) == true )
                            {
                                if ( model.YQ09.Length > 8 && model.YQ09.Substring( 0 ,8 ) == "MLL-0001" )
                                {
                                    planOrActual( );
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show( "此合同为补开,请联系总经理处理" );
                                    break;
                                }
                            }
                            else if ( k == dwo.Rows.Count - 1 )
                                planOrActual( );
                        }
                    }
                    else
                        planOrActual( );
                }
            }
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;
            if ( label24.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saves == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll.Delete( model.IDX ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,"删除" ,stateOfOdd ,MulaolaoBll . Drity . GetDt ( ) ,model.YQ99 ,model.YQ120 ,model.YQ121 ,model.YQ132 ,model.YQ133 ,textBox28.Text ,textBox32.Text ,comboBox14.Text );
            if ( result==false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );

                //tab.Rows.Remove( tab.Select( "idx='" + model.IDX + "'" )[0] );
                button13_Click ( null , null );
            }
        }
        //Refresh
        private void button13_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
            refre( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tab = bll.GetDataTableAll( model.YQ99 );
            gridControl1.DataSource = tab;
            every( );
            assignMent( );
        }
        void assignMent ( )
        {
            if ( tab != null && tab . Rows . Count > 0 && bandedGridView1 . DataRowCount > 0 )
            {
                int bp = 0, tp = 0;
                decimal dOne = 0, dTwo = 0;
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ16" ] . ToString ( ) ) )
                    {
                        if ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ16" ] ) == 0 )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,0 );
                        else
                        {
                            if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ112" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ113" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ114" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ115" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ116" ] . ToString ( ) ) )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ112" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ113" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ114" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ115" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ116" ] . ToString ( ) ) * Convert . ToDecimal ( 0.0001 ) );
                            else
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,0 );
                        }
                    }
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ14" ] . ToString ( ) ) )
                    {
                        if ( Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ14" ] ) == 0 )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U2" ] ,0 );
                        else
                        {
                            if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ112" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ113" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ114" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ115" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ116" ] . ToString ( ) ) )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U2" ] ,Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ108" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ112" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ116" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ113" ] . ToString ( ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ114" ] . ToString ( ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ115" ] . ToString ( ) ) );
                            else
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U2" ] ,0 );
                        }
                    }
                    if (!string.IsNullOrEmpty( bandedGridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) ) && Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) ) > 0 )
                    {
                        bp++;
                        dOne += Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) );
                    }
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) ) && Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) ) > 0 )
                    {
                        tp++;
                        dTwo += Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) );
                    }
                }
                YQ108 . SummaryItem . SetSummary ( SummaryItemType . Custom ,bandedGridView1 . GetDataRow ( 0 ) [ "YQ108" ] . ToString ( ) );
                YQ14 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( bandedGridView1 . Columns [ "U2" ] . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U10" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . Columns [ "U2" ] . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );
                YQ16 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( bandedGridView1 . Columns [ "U1" ] . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U9" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . Columns [ "U1" ] . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );
                U7 . SummaryItem . SetSummary ( SummaryItemType . Custom ,string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "YQ108" ] . ToString ( ) ) == true ? 0 . ToString ( ) : Math . Round ( ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U9" ] . SummaryItem . SummaryValue ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "U10" ] . SummaryItem . SummaryValue ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "YQ108" ] . ToString ( ) ) ,2 ) . ToString ( ) );
                U8 . SummaryItem . SetSummary ( SummaryItemType . Custom ,string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "YQ108" ] . ToString ( ) ) == true ? 0 . ToString ( ) : Math . Round ( ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U9" ] . SummaryItem . SummaryValue ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "U10" ] . SummaryItem . SummaryValue ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "YQ108" ] . ToString ( ) ) ,2 ) . ToString ( ) );
                U5 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( bandedGridView1 . Columns [ "U2" ] . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U3" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . Columns [ "U2" ] . SummaryItem . SummaryValue ) ,3 ) . ToString ( ) );
                U6 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( bandedGridView1 . Columns [ "U1" ] . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U4" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . Columns [ "U1" ] . SummaryItem . SummaryValue ) ,3 ) . ToString ( ) );
                YQ117 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U9" ] . SummaryItem . SummaryValue ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "U10" ] . SummaryItem . SummaryValue ) ,0 ) . ToString ( ) );

                U11 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) / 2 * Convert . ToDecimal ( 0.85 ) ,2 ) . ToString ( ) );
                U12 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U4 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U1 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U4 . SummaryItem . SummaryValue ) / 2 ,2 ) . ToString ( ) );

                YQ134 . SummaryItem . SetSummary ( SummaryItemType . Custom ,bp == 0 ? 0 . ToString ( ) : Math . Round ( dOne / bp ,2 ) . ToString ( ) );
                YQ135 . SummaryItem . SetSummary ( SummaryItemType . Custom ,tp == 0 ? 0 . ToString ( ) : Math . Round ( dTwo / tp ,2 ) . ToString ( ) );
            }
        }
        //BatchEdit
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button19_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox53.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( string.IsNullOrEmpty( textBox53.Text ) )
                    MessageBox.Show( "产品数量不可为空" );
                else
                {
                    //model.YQ108 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
                    if ( label24.Visible == true )
                        stateOfOdd = "维护批量编辑";
                    else
                    {
                        if ( saves == "1" )
                            stateOfOdd = "新增批量编辑";
                        else
                            stateOfOdd = "更改批量编辑";
                    }
                    result = bll.UpdateBatch( model.YQ99 ,model.YQ108 ,"R_339" ,"油漆（墨）等化学品采购合同书" ,Logins.username ,"批量编辑" ,stateOfOdd ,MulaolaoBll . Drity . GetDt ( )  );
                    if ( result == false )
                        MessageBox.Show( "编辑数据失败" );
                    else
                    {
                        MessageBox.Show( "成功编辑数据" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND YQ99='" + model.YQ99 + "'";
                        refre( );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.YQ108 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //Acture data of arrival
        yanpinSelect ys = new yanpinSelect( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + model.YQ03 + "\n\r物料名称:" + textBox28.Text + "\n\r生产工艺:" + textBox32.Text + "\n\r色号.按色号与色板间:" + comboBox14.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = model.YQ99;
                ys.ysTwo = textBox28.Text;
                ys.ysThr = textBox32.Text;
                ys.ysFou = comboBox14.Text;
                ys.ysFiv = "";
                ys.ysSix = "R_339";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        //写入285
        //string PQK16 = "", PQK01 = "", PQK03 = "", PQK04 = "", PQK35 = "", PQK36 = "", PQK07 = "";
        //decimal /*PQK09 = 0M,*/ PQK18 = 0M, YQ118 = 0M, PQK32 = 0M;
        private void button15_Click ( object sender ,EventArgs e )
        {
            wy.writeTwoEgiFiv( model.YQ99 );
           
            /*
            if ( label24.Visible == true )
            {
                if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
                {
                    if ( string.IsNullOrEmpty( textBox28.Text ) )
                        MessageBox.Show( "物料名称不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox32.Text ) )
                            MessageBox.Show( "生产工艺不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( comboBox14.Text ) )
                                MessageBox.Show( "色号.按色号与色板间不可为空" );
                            else
                            {
                                if ( string.IsNullOrEmpty( textBox49.Text ) )
                                    MessageBox.Show( "流水号不可为空" );
                                else
                                {
                                    int count = 0;
                                    YQ03 = textBox49.Text;
                                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                                        YQ1080 = 0;
                                    else
                                        YQ1080 = Convert.ToInt64( textBox53.Text );
                                    YQ04 = textBox17.Text;
                                    YQ011 = textBox32.Text;
                                    YQ012 = comboBox14.Text;
                                    YQ105 = comboBox2.Text;
                                    YQ107 = comboBox4.Text;
                                    YQ010 = textBox28.Text;
                                    YQ6 = textBox27.Text;
                                    if ( string.IsNullOrEmpty( textBox11.Text ) )
                                        YQ0112 = 0;
                                    else
                                        YQ0112 = Convert.ToInt32( textBox11.Text );
                                    if ( string.IsNullOrEmpty( textBox20.Text ) )
                                        YQ0113 = 0;
                                    else
                                        YQ0113 = Convert.ToInt32( textBox20.Text );
                                    if ( string.IsNullOrEmpty( textBox21.Text ) )
                                        YQ0114 = 0;
                                    else
                                        YQ0114 = Convert.ToInt32( textBox21.Text );
                                    if ( string.IsNullOrEmpty( textBox25.Text ) )
                                        YQ0116 = 0;
                                    else
                                        YQ0116 = Convert.ToInt32( textBox25.Text );
                                    if ( string.IsNullOrEmpty( comboBox3.Text ) )
                                        YQ013 = 0;
                                    else
                                        YQ013 = Convert.ToDecimal( comboBox3.Text );
                                    if ( string.IsNullOrEmpty( textBox51.Text ) )
                                        YQ014 = 0;
                                    else
                                        YQ014 = Convert.ToDecimal( textBox51.Text );
                                    if ( string.IsNullOrEmpty( textBox22.Text ) )
                                        YQ0115 = 0;
                                    else
                                        YQ0115 = Convert.ToDecimal( textBox22.Text );
                                    if ( string.IsNullOrEmpty( textBox52.Text ) )
                                        YQ016 = 0;
                                    else
                                        YQ016 = Convert.ToDecimal( textBox52.Text );
                                    YQ0117 = textBox23.Text;
                                    if ( string.IsNullOrEmpty( textBox59.Text ) )
                                        YQ015 = 0;
                                    else
                                        YQ015 = Convert.ToDecimal( textBox59.Text );
                                    if ( radioButton12.Checked )
                                    {
                                        if ( !string.IsNullOrEmpty( textBox19.Text ) )
                                        {
                                            PQK18 = Math.Round( Convert.ToDecimal( textBox19.Text ) ,4 );
                                            YQ118 = Math.Round( Convert.ToDecimal( textBox19.Text ) ,4 );
                                        }
                                        else
                                            PQK18 = 0;
                                    }
                                    else if ( radioButton13.Checked )
                                    {
                                        if ( !string.IsNullOrEmpty( textBox34.Text ) )
                                        {
                                            PQK32 = Math.Round( Convert.ToDecimal( textBox34.Text ) ,4 );
                                            YQ118 = Math.Round( Convert.ToDecimal( textBox34.Text ) ,4 );
                                        }
                                        else
                                            PQK32 = 0;
                                    }
                                    else
                                        PQK18 = PQK32 = 0;
                                    if ( string.IsNullOrEmpty( textBox53.Text ) )
                                        YQ122 = 0;
                                    else
                                        YQ122 = Convert.ToInt64( textBox53.Text );
                                    PQK35 = textBox55.Text;
                                    PQK36 = textBox56.Text;
                                    DataTable der = SqlHelper.ExecuteDataTable( "SELECT PY07,PY04 FROM R_PQY WHERE PY01=@PY01" ,new SqlParameter( "@PY01" ,YQ03 ) );
                                    if ( der.Rows.Count > 0 )
                                    {
                                        PQK03 = der.Rows[0]["PY07"].ToString( );
                                        PQK04 = der.Rows[0]["PY04"].ToString( );
                                    }
                                    DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQK WHERE PQK02=@PQK02" ,new SqlParameter( "@PQK02" ,YQ03 ) );    
                                    if ( del.Rows.Count < 1 )
                                    {
                                        if ( MessageBox.Show( "确定将\n\r流水号:" + YQ03 + "\n\r零件名称:"+YQ010+"\n\r工序:" + YQ011 + "\n\r色号:" + YQ012 + "\n\r写入R_285?" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                        {
                                            PQK01 = oddNumbers.purchaseContract( "SELECT MAX(PQK01) PQK01 FROM R_PQK" ,"PQK01" ,"R_285-" );
                                            PQK16 = YQ03 + "001";
                                            
                                            count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQK (PQK01,PQK30,PQK16,PQK02,PQK07,PQK12,PQK13,PQK14,PQK15,PQK03,PQK04,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK18,PQK32,PQK35,PQK36) VALUES (@PQK01,@PQK30,@PQK16,@PQK02,@PQK07,@PQK12,@PQK13,@PQK14,@PQK15,@PQK03,@PQK04,@PQK11,@PQK17,@PQK08,@PQK19,@PQK20,@PQK21,@PQK22,@PQK23,@PQK24,@PQK25,@PQK26,@PQK27,@PQK28,@PQK18,@PQK32,@PQK35,@PQK36)" ,new SqlParameter( "@PQK01" ,PQK01 ) ,new SqlParameter( "@PQK30" ,YQ99 ) ,new SqlParameter( "@PQK16" ,PQK16 ) ,new SqlParameter( "@PQK02" ,YQ03 ) ,new SqlParameter( "@PQK07" ,YQ010 ) ,new SqlParameter( "@PQK12" ,YQ105 ) ,new SqlParameter( "@PQK13" ,YQ107 ) ,new SqlParameter( "@PQK14" ,YQ6 ) ,new SqlParameter( "@PQK15" ,"" ) ,new SqlParameter( "@PQK03" ,PQK03 ) ,new SqlParameter( "@PQK04" ,PQK04 ),new SqlParameter( "@PQK11" ,YQ011 ) ,new SqlParameter( "@PQK17" ,YQ012 ) ,new SqlParameter( "@PQK08" ,YQ0114 ) ,new SqlParameter( "@PQK19" ,YQ0115 ) ,new SqlParameter( "@PQK20" ,YQ0112 ) ,new SqlParameter( "@PQK21" ,YQ0116 ) ,new SqlParameter( "@PQK22" ,YQ0113 ) ,new SqlParameter( "@PQK23" ,YQ122 ) ,new SqlParameter( "@PQK24" ,YQ0117 ) ,new SqlParameter( "@PQK25" ,YQ015 ) ,new SqlParameter( "@PQK26" ,YQ014 ) ,new SqlParameter( "@PQK27" ,YQ013 ) ,new SqlParameter( "@PQK28" ,YQ016 ) ,new SqlParameter( "@PQK18" ,PQK18 ) ,new SqlParameter( "@PQK32" ,PQK32 ) ,new SqlParameter( "@PQK35" ,PQK35 ) ,new SqlParameter( "@PQK36" ,PQK36 ) );
                                            if ( count < 1 )
                                                MessageBox.Show( "写入285失败" );
                                            else
                                            {
                                                MessageBox.Show( "写入285成功" );
                                                try
                                                {
                                                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter( "@YQ99" ,YQ99 ) ,new SqlParameter( "@YQ10" ,YQ010 ) ,new SqlParameter( "@YQ11" ,YQ011 ) ,new SqlParameter( "@YQ12" ,YQ012 ) ,new SqlParameter( "@YQ118" ,YQ118 ),new SqlParameter("@YQ122",YQ122) );
                                                }
                                                catch { }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ( del.Select( "PQK07='"+YQ010+"' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" ).Length > 0 )
                                        {
                                            if ( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK30"].ToString( ).Contains( YQ99 ) )
                                            {
                                                DataTable drt = SqlHelper.ExecuteDataTable( "SELECT YQ118,YQ122 FROM R_PQI WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter( "@YQ99" ,YQ99 ) ,new SqlParameter("@YQ10",YQ010),new SqlParameter( "@YQ11" ,YQ011 ) ,new SqlParameter( "@YQ12" ,YQ012 ) );
                                                if ( drt.Rows.Count > 0 )
                                                {
                                                    if ( !string.IsNullOrEmpty( drt.Rows[0]["YQ118"].ToString( ) ) )
                                                    {
                                                        if ( radioButton12.Checked )
                                                        {
                                                            PQK18 = PQK18 - Convert.ToDecimal( drt.Rows[0]["YQ118"].ToString( ) );
                                                            if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK18"].ToString( ) ) )
                                                                PQK18 = PQK18 + Convert.ToDecimal( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK18"].ToString( ) );
                                                        }
                                                        else if ( radioButton13.Checked )
                                                        {
                                                            PQK32 = PQK32 - Convert.ToDecimal( drt.Rows[0]["YQ118"].ToString( ) );
                                                            if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK32"].ToString( ) ) )
                                                                PQK32 = PQK32 + Convert.ToDecimal( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK32"].ToString( ) );
                                                        }  
                                                    }
                                                    if ( !string.IsNullOrEmpty( drt.Rows[0]["YQ122"].ToString( ) ) )
                                                    {
                                                            YQ122 = YQ122 - Convert.ToInt64( drt.Rows[0]["YQ122"].ToString( ) );
                                                            if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK23"].ToString( ) ) )
                                                                YQ122 = YQ122 + Convert.ToInt64( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK23"].ToString( ) );
                                                    }
                                                }
                                                YQ99 = del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK30"].ToString( );
                                            }
                                            else
                                            {
                                                YQ99 = del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK30"].ToString( ) + "," + YQ99;
                                                if ( radioButton12.Checked )
                                                {
                                                    if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK18"].ToString( ) ) )
                                                        PQK18 = PQK18 + Convert.ToDecimal( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK18"].ToString( ) );
                                                }
                                                else if ( radioButton13.Checked )
                                                {
                                                    if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK32"].ToString( ) ) )
                                                        PQK32 = PQK32 + Convert.ToDecimal( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK32"].ToString( ) );
                                                }
                                            }
                                            if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK35"].ToString( ) ) )
                                            {
                                                if ( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK35"].ToString( ).Contains( PQK35 ) == false )
                                                    PQK35 = PQK35 + "," + del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK35"].ToString( );
                                                else
                                                    PQK35 = del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK35"].ToString( );
                                            }
                                            if ( !string.IsNullOrEmpty( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK36"].ToString( ) ) )
                                            {
                                                if ( del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK36"].ToString( ).Contains( PQK36 ) == false )
                                                    PQK36 = PQK36 + "," + del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK36"].ToString( );
                                                else
                                                    PQK36 = del.Select( "PQK07='" + YQ010 + "' AND PQK11='" + YQ011 + "' AND PQK17='" + YQ012 + "'" )[0]["PQK36"].ToString( );
                                            }
                                            
                                            count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK30=@PQK30,PQK12=@PQK12,PQK13=@PQK13,PQK14=@PQK14,PQK15=@PQK15,PQK03=@PQK03,PQK04=@PQK04,PQK08=@PQK08,PQK19=@PQK19,PQK20=@PQK20,PQK21=@PQK21,PQK22=@PQK22,PQK23=@PQK23,PQK24=@PQK24,PQK25=@PQK25,PQK26=@PQK26,PQK27=@PQK27,PQK28=@PQK28,PQK18=@PQK18,PQK32=@PQK32,PQK35=@PQK35,PQK36=@PQK36 WHERE PQK02=@PQK02 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17" ,new SqlParameter( "@PQK30" ,YQ99 ) ,new SqlParameter( "@PQK02" ,YQ03 ) ,new SqlParameter( "@PQK07" ,YQ010 ) ,new SqlParameter( "@PQK12" ,YQ105 ) ,new SqlParameter( "@PQK13" ,YQ107 ) ,new SqlParameter( "@PQK14" ,YQ6 ) ,new SqlParameter( "@PQK15" ,"" ) ,new SqlParameter( "@PQK03" ,PQK03 ) ,new SqlParameter( "@PQK04" ,PQK04 ) ,new SqlParameter( "@PQK11" ,YQ011 ) ,new SqlParameter( "@PQK17" ,YQ012 ) ,new SqlParameter( "@PQK08" ,YQ0114 ) ,new SqlParameter( "@PQK19" ,YQ0115 ) ,new SqlParameter( "@PQK20" ,YQ0112 ) ,new SqlParameter( "@PQK21" ,YQ0116 ) ,new SqlParameter( "@PQK22" ,YQ0113 ) ,new SqlParameter( "@PQK23" ,YQ122 ) ,new SqlParameter( "@PQK24" ,YQ0117 ) ,new SqlParameter( "@PQK25" ,YQ015 ) ,new SqlParameter( "@PQK26" ,YQ014 ) ,new SqlParameter( "@PQK27" ,YQ013 ) ,new SqlParameter( "@PQK28" ,YQ016 ) ,new SqlParameter( "@PQK18" ,PQK18 ) ,new SqlParameter( "@PQK32" ,PQK32 ) ,new SqlParameter( "@PQK35" ,PQK35 ) ,new SqlParameter( "@PQK36" ,PQK36 ) );
                                            if ( count < 1 )
                                                MessageBox.Show( "写入285失败" );
                                            else
                                            {
                                                MessageBox.Show( "写入285成功" );
                                                try
                                                {
                                                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter( "@YQ99" ,YQ99 ) ,new SqlParameter( "@YQ10" ,YQ010 ) ,new SqlParameter( "@YQ11" ,YQ011 ) ,new SqlParameter( "@YQ12" ,YQ012 ) ,new SqlParameter( "@YQ118" ,YQ118 ) ,new SqlParameter( "@YQ122" ,YQ122 ) );
                                                }
                                                catch { }
                                            }
                                        }
                                        else
                                        {
                                            if ( !string.IsNullOrEmpty( del.AsEnumerable( ).Select( t => t.Field<string>( "PQK16" ) ).Max( ) ) )
                                            {
                                                PQK16 = ( Convert.ToInt64( del.AsEnumerable( ).Select( t => t.Field<string>( "PQK16" ) ).Max( ) ) + 1 ).ToString( );
                                                PQK01 = del.Rows[0]["PQK01"].ToString( );
                                                count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQK (PQK01,PQK30,PQK16,PQK02,PQK07,PQK12,PQK13,PQK14,PQK15,PQK03,PQK04,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK18,PQK32,PQK35,PQK36) VALUES (@PQK01,@PQK30,@PQK16,@PQK02,@PQK07,@PQK12,@PQK13,@PQK14,@PQK15,@PQK03,@PQK04,@PQK11,@PQK17,@PQK08,@PQK19,@PQK20,@PQK21,@PQK22,@PQK23,@PQK24,@PQK25,@PQK26,@PQK27,@PQK28,@PQK18,@PQK32,@PQK35,@PQK36)" ,new SqlParameter( "@PQK01" ,PQK01 ) ,new SqlParameter( "@PQK30" ,YQ99 ) ,new SqlParameter( "@PQK16" ,PQK16 ) ,new SqlParameter( "@PQK02" ,YQ03 ) ,new SqlParameter( "@PQK07" ,YQ010 ) ,new SqlParameter( "@PQK12" ,YQ105 ) ,new SqlParameter( "@PQK13" ,YQ107 ) ,new SqlParameter( "@PQK14" ,YQ6 ) ,new SqlParameter( "@PQK15" ,"" ) ,new SqlParameter( "@PQK03" ,PQK03 ) ,new SqlParameter( "@PQK04" ,PQK04 )  ,new SqlParameter( "@PQK11" ,YQ011 ) ,new SqlParameter( "@PQK17" ,YQ012 ) ,new SqlParameter( "@PQK08" ,YQ0114 ) ,new SqlParameter( "@PQK19" ,YQ0115 ) ,new SqlParameter( "@PQK20" ,YQ0112 ) ,new SqlParameter( "@PQK21" ,YQ0116 ) ,new SqlParameter( "@PQK22" ,YQ0113 ) ,new SqlParameter( "@PQK23" ,YQ122 ) ,new SqlParameter( "@PQK24" ,YQ0117 ) ,new SqlParameter( "@PQK25" ,YQ015 ) ,new SqlParameter( "@PQK26" ,YQ014 ) ,new SqlParameter( "@PQK27" ,YQ013 ) ,new SqlParameter( "@PQK28" ,YQ016 ) ,new SqlParameter( "@PQK18" ,PQK18 ) ,new SqlParameter( "@PQK32" ,PQK32 ) ,new SqlParameter( "@PQK35" ,PQK35 ) ,new SqlParameter( "@PQK36" ,PQK36 ) );
                                                if ( count < 1 )
                                                    MessageBox.Show( "写入285失败" );
                                                else
                                                {
                                                    MessageBox.Show( "写入285成功" );
                                                    try
                                                    {
                                                        SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter( "@YQ99" ,YQ99 ) ,new SqlParameter( "@YQ10" ,YQ010 ) ,new SqlParameter( "@YQ11" ,YQ011 ) ,new SqlParameter( "@YQ12" ,YQ012 ) ,new SqlParameter( "@YQ118" ,YQ118 ) ,new SqlParameter( "@YQ122" ,YQ122 ) );
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show( "计划订单不能写入R_285" );
            }
            else
                MessageBox.Show( "非执行订单不能写入R_285" );
            */
        }
        #endregion

    }
}


/*
r12
( Convert.ToDecimal( textBox59.Text (油漆现价)) * Convert.ToDecimal( textBox21.Text (长向摆放个数)) * Convert.ToDecimal( textBox22.Text (宽向摆放个数)) * 100 / Convert.ToDecimal( textBox51.Text (定每板单面.遍漆价)) / Convert.ToDecimal( comboBox3.Text (每板摆用率)) / Convert.ToDecimal( textBox11.Text (每套部件数量)) * Convert.ToDecimal( textBox20.Text (每片喷面数)) * Convert.ToDecimal( textBox25.Text (每片每面喷涂遍数)) ).ToString( )
( Convert.ToDecimal( textBox59.Text ) * Convert.ToDecimal( textBox21.Text ) * Convert.ToDecimal( textBox22.Text ) * 100 / Convert.ToDecimal( textBox51.Text ) / Convert.ToDecimal( comboBox3.Text ) / Convert.ToDecimal( textBox11.Text ) / Convert.ToDecimal( textBox20.Text ) / Convert.ToDecimal( textBox25.Text ) ).ToString( )
Convert.ToDecimal(yqx) * Convert.ToDecimal( cxb) * Convert.ToDecimal( kxb) * 100 / Convert.ToDecimal( bs) / Convert.ToDecimal( mbby) / Convert.ToDecimal( mtbj) * Convert.ToDecimal( mmpt) * Convert.ToDecimal( mppt)
r13
( Convert.ToDecimal( textBox59.Text (油漆现价)) * 100 / Convert.ToDecimal( textBox11.Text (每套部件数量)) / Convert.ToDecimal( textBox21.Text (长向摆放个数)) / Convert.ToDecimal( textBox22.Text (宽向摆放个数)) / Convert.ToDecimal( comboBox3.Text(每板摆用率) ) / Convert.ToDecimal( textBox52.Text(定每平米漆价) ) ).ToString( )
( Convert.ToDecimal( textBox59.Text ) * 100*10000 / Convert.ToDecimal( textBox11.Text ) / Convert.ToDecimal( textBox21.Text ) / Convert.ToDecimal( textBox22.Text ) / Convert.ToDecimal( comboBox3.Text ) / Convert.ToDecimal( textBox52.Text ) ).ToString( )
( Convert.ToDecimal( yqx) * 100 / Convert.ToDecimal( mtbj) / Convert.ToDecimal( cxb) / Convert.ToDecimal( kxb) / Convert.ToDecimal( mbby ) / Convert.ToDecimal( pm ) ).ToString( )
*/







