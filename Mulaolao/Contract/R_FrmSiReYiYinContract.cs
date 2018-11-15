using Mulaolao . Class;
using StudentMgr;
using System;
using System . Data;
using System . Windows . Forms;
using System . Data . SqlClient;
using Mulaolao . Schedule_control;
using Mulaolao . Base;
using FastReport;
using FastReport . Export . Xml;
using System . Linq;
using DevExpress . XtraGrid . Views . Grid;
using DevExpress . Data;
using System . Collections . Generic;
using Mulaolao . Bom;

namespace Mulaolao . Contract
{
    public partial class R_FrmSiReYiYinContract :FormChild
    {
        public R_FrmSiReYiYinContract ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( new GridView [ ] { gridView1 ,View1 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,View1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.SiReYiYinContractLibrary model = new MulaolaoLibrary.SiReYiYinContractLibrary( );
        MulaolaoBll.Bll.SiReYiYincontractBll bll = new MulaolaoBll.Bll.SiReYiYincontractBll( );
        string sign = "", weihu = "", copy = "", file = "", strWhere = "1=1", numQu = "", stateOfOdd = "";
        DataTable tableSele, desx, db, dls, dl;
        Report report = new Report( );
        DataSet RDataSet;
        SpecialPowers sp = new SpecialPowers( );
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( );
        
        private void R_FrmSiReYiYinContract_Load ( object sender ,EventArgs e )
        {
            Power ( this );

            spList . Clear ( );
            spList . AddRange ( new SplitContainer [ ] { splitContainer1 ,splitContainer2 } );
            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableFalse ( spList );
            pageList . Clear ( );
            pageList . AddRange ( new TabPage [ ] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableFalse ( pageList );

            Ergodic . FormEvery ( this );
            gridControl1 . DataSource = null;

            label3 . Visible = false;
            label9 . Visible = false;
            textBox4 . Enabled = false;

            db = bll . GetDataTableCont ( );
            lookUpEdit1 . Properties . DataSource = db;
            lookUpEdit1 . Properties . ValueMember = "DBA001";
            lookUpEdit1 . Properties . DisplayMember = "DBA002";

            lookUpEdit2 . Properties . DataSource = bll . GetDataTableWork ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";

            //if ( Logins.number == "MLL-0001" || Logins.number == "MLL-0007" || Logins.number == "MLL-0008" )
            //    checkBox16.Visible = true;
            //else
            //    checkBox16.Visible = false;
            if ( Logins . number == "MLL-0001" )
                checkBox15 . Visible = true;
            else
                checkBox15 . Visible = false;
        }

        private void R_FrmSiReYiYinContract_Shown ( object sender ,EventArgs e )
        {
            model . AH97 = Merges . oddNum;
            if ( !string . IsNullOrEmpty ( model . AH97 ) )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region Print Export
        void createRDataSet ( )
        {
            RDataSet = new DataSet ( );
            DataTable print = bll . GetDataTablePrintOne ( model . AH97 );
            DataTable prints = bll . GetDataTablePrintTwo ( model . AH97 );
            print . TableName = "R_PQAH";
            prints . TableName = "R_PQAHS";
            RDataSet . Tables . Add ( print );
            RDataSet . Tables . Add ( prints );
        }
        #endregion

        #region Query     
        void queryContent ( )
        {
            if ( model . AH97 != null && model . AH97 != "" )
            {
                model = bll . GetModel ( model . AH97 );
                if ( model != null )
                {
                    lookUpEdit1 . Text = db . Select ( "DBA001='" + model . AH02 + "'" ) . Length > 0 ? db . Select ( "DBA001='" + model . AH02 + "'" ) [ 0 ] [ "DBA002" ] . ToString ( ) : string . Empty;
                    textBox5 . Text = db . Select ( "DBA001='" + model . AH02 + "'" ) . Length > 0 ? db . Select ( "DBA001='" + model . AH02 + "'" ) [ 0 ] [ "DBA028" ] . ToString ( ) : string . Empty;

                    #region
                    if ( string . IsNullOrEmpty ( model . AH114 ) )
                    {
                        textBox7 . Text = model . AH03;
                        textBox8 . Text = model . AH106;
                        textBox9 . Text = model . AH107;
                        textBox10 . Text = model . AH108;
                        textBox11 . Text = model . AH109;
                    }
                    else
                    {
                        DataTable supplier = bll . GetDataTableOfSupplier ( model . AH114 );
                        if ( supplier != null && supplier . Rows . Count > 0 )
                        {
                            textBox7 . Text = supplier . Rows [ 0 ] [ "DGA003" ] . ToString ( );
                            textBox8 . Text = supplier . Rows [ 0 ] [ "DGA017" ] . ToString ( );
                            textBox9 . Text = supplier . Rows [ 0 ] [ "DGA008" ] . ToString ( );
                            textBox10 . Text = supplier . Rows [ 0 ] [ "DGA009" ] . ToString ( );
                            textBox11 . Text = supplier . Rows [ 0 ] [ "DGA011" ] . ToString ( );
                        }
                        else
                            textBox7 . Text = textBox8 . Text = textBox9 . Text = textBox10 . Text = textBox11 . Text = "";
                    }
                    textBox6 . Text = model . AH98;
                    textBox53 . Text = model . AH101 . ToString ( );
                    textBox49 . Text = model . AH01;
                    textBox50 . Text = model . AH99;
                    textBox3 . Text = model . AH100;
                    dateTimePicker14 . Value = model . AH04;
                    textBox17 . Text = model . AH05;
                    dateTimePicker1 . Value = model . AH06;
                    textBox13 . Text = model . AH07;
                    dateTimePicker2 . Value = model . AH08;
                    textBox16 . Text = model . AH09;
                    textBox15 . Text = model . AH24;
                    textBox18 . Text = model . AH25;
                    checkBox36 . Checked = model . AH26 . Trim ( ) == "T" ? true : false;
                    checkBox38 . Checked = model . AH27 . Trim ( ) == "T" ? true : false;
                    checkBox39 . Checked = model . AH28 . Trim ( ) == "T" ? true : false;
                    checkBox40 . Checked = model . AH29 . Trim ( ) == "T" ? true : false;
                    comboBox16 . Text = model . AH30;
                    dateTimePicker5 . Value = model . AH31;
                    checkBox4 . Checked = model . AH32 . Trim ( ) == "T" ? true : false;
                    checkBox7 . Checked = model . AH33 . Trim ( ) == "T" ? true : false;
                    checkBox5 . Checked = model . AH34 . Trim ( ) == "T" ? true : false;
                    checkBox6 . Checked = model . AH35 . Trim ( ) == "T" ? true : false;
                    checkBox1 . Checked = model . AH36 . Trim ( ) == "T" ? true : false;
                    checkBox2 . Checked = model . AH37 . Trim ( ) == "T" ? true : false;
                    checkBox3 . Checked = model . AH38 . Trim ( ) == "T" ? true : false;
                    checkBox8 . Checked = model . AH39 . Trim ( ) == "T" ? true : false;
                    checkBox9 . Checked = model . AH40 . Trim ( ) == "T" ? true : false;
                    checkBox10 . Checked = model . AH41 . Trim ( ) == "T" ? true : false;
                    checkBox41 . Checked = model . AH42 . Trim ( ) == "T" ? true : false;
                    textBox26 . Text = model . AH43;
                    textBox1 . Text = model . AH44;
                    textBox16 . Text = model . AH45;
                    dateTimePicker6 . Value = model . AH46;
                    textBox18 . Text = model . AH47;
                    dateTimePicker7 . Value = model . AH48;
                    checkBox11 . Checked = model . AH49 . Trim ( ) == "T" ? true : false;
                    checkBox12 . Checked = model . AH50 . Trim ( ) == "T" ? true : false;
                    checkBox13 . Checked = model . AH51 . Trim ( ) == "T" ? true : false;
                    checkBox14 . Checked = model . AH52 . Trim ( ) == "T" ? true : false;
                    checkBox17 . Checked = model . AH53 . Trim ( ) == "T" ? true : false;
                    checkBox21 . Checked = model . AH54 . Trim ( ) == "T" ? true : false;
                    checkBox26 . Checked = model . AH55 . Trim ( ) == "T" ? true : false;
                    checkBox27 . Checked = model . AH56 . Trim ( ) == "T" ? true : false;
                    checkBox19 . Checked = model . AH57 . Trim ( ) == "T" ? true : false;
                    checkBox24 . Checked = model . AH58 . Trim ( ) == "T" ? true : false;
                    checkBox30 . Checked = model . AH59 . Trim ( ) == "T" ? true : false;
                    checkBox33 . Checked = model . AH60 . Trim ( ) == "T" ? true : false;
                    checkBox35 . Checked = model . AH61 . Trim ( ) == "T" ? true : false;
                    checkBox32 . Checked = model . AH62 . Trim ( ) == "T" ? true : false;
                    checkBox31 . Checked = model . AH63 . Trim ( ) == "T" ? true : false;
                    checkBox34 . Checked = model . AH64 . Trim ( ) == "T" ? true : false;
                    textBox30 . Text = model . AH65;
                    if ( model . AH66 == radioButton1 . Text )
                        radioButton1 . Checked = true;
                    else if ( model . AH66 == radioButton2 . Text )
                        radioButton2 . Checked = true;
                    if ( model . AH67 == radioButton3 . Text )
                        radioButton3 . Checked = true;
                    else if ( model . AH67 == radioButton4 . Text )
                        radioButton4 . Checked = false;
                    if ( model . AH68 == radioButton6 . Text )
                    {
                        radioButton6 . Checked = true;
                        textBox24 . Text = model . AH69;
                    }
                    else if ( model . AH68 == radioButton5 . Text )
                    {
                        radioButton5 . Checked = true;
                        textBox24 . Text = "";
                    }
                    textBox31 . Text = model . AH70;
                    dateTimePicker8 . Value = model . AH71;
                    textBox33 . Text = model . AH72 . ToString ( );
                    if ( model . AH73 == radioButton7 . Text )
                    {
                        radioButton7 . Checked = true;
                        textBox35 . Text = model . AH76;
                    }
                    else if ( model . AH73 == radioButton8 . Text )
                        radioButton8 . Checked = true;
                    else if ( model . AH73 == radioButton9 . Text )
                        radioButton9 . Checked = true;
                    comboBox5 . Text = model . AH74;
                    dateTimePicker9 . Value = model . AH75;
                    textBox36 . Text = model . AH77 . ToString ( );
                    textBox37 . Text = model . AH78 . ToString ( );
                    textBox38 . Text = model . AH79 . ToString ( );
                    textBox41 . Text = model . AH80 . ToString ( );
                    textBox40 . Text = model . AH81 . ToString ( );
                    textBox39 . Text = model . AH82 . ToString ( );
                    textBox44 . Text = model . AH83 . ToString ( );
                    textBox43 . Text = model . AH84 . ToString ( );
                    textBox42 . Text = model . AH85 . ToString ( );
                    textBox12 . Text = model . AH86;
                    textBox45 . Text = model . AH87;
                    textBox46 . Text = model . AH88;
                    dateTimePicker10 . Value = model . AH89;
                    textBox47 . Text = model . AH90;
                    dateTimePicker11 . Value = model . AH91;
                    textBox48 . Text = model . AH92;
                    dateTimePicker12 . Value = model . AH93;
                    dateTimePicker13 . Value = model . AH94;
                    textBox4 . Text = model . AH95;
                    lookUpEdit2 . Text = model . AH112;
                    checkBox15 . Checked = model . AH111 . Trim ( ) == "T" ? true : false;
                    textBox7 . Tag = model . AH114;
                    #endregion

                    strWhere = "1=1";
                    strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                    refre ( );
                }
            }
        }
        void autoQuery ( )
        {
            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableFalse ( pageList );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            textBox4 . Enabled = false;

            sign = "2";
            queryContent ( );
        }
        SelectAll.SiReYiYincontractAll query = new SelectAll.SiReYiYincontractAll( );
        protected override void select ( )
        {
            base . select ( );

            model = new MulaolaoLibrary . SiReYiYinContractLibrary ( );
            query . StartPosition = FormStartPosition . CenterScreen;
            query . PassDataBetweenForm += new SelectAll . SiReYiYincontractAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            query . ShowDialog ( );

            if ( model . AH97 == null || model . AH97 == "" )
                MessageBox . Show ( "您没有选择任何内容" );
            else
                autoQuery ( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model . AH97 = e . ConOne;
            model . AH01 = e . ConTwo;
            textBox49 . Text = e . ConTwo;
            model . AH98 = e . ConTre;
            textBox6 . Text = e . ConTre;
            model . AH100 = e . ConFor;
            textBox3 . Text = e . ConFor;
            model . AH99 = e . ConFiv;
            textBox50 . Text = e . ConFiv;
            if ( !string . IsNullOrEmpty ( e . ConEgi ) )
                model . AH101 = Convert . ToInt64 ( e . ConEgi );
            else
                model . AH101 = 0;
            textBox53 . Text = e . ConEgi;
            if ( e . ConSixteen == "执行" )
                label3 . Visible = true;
            else
                label3 . Visible = false;
        }
        //Query num
        R_Frm369 fr = new R_Frm369( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable dr = bll . GetDataTableNum ( );
            if ( dr . Rows . Count < 1 )
                return;
            else
            {
                dr . Columns . Add ( "check" ,Type . GetType ( "System.Boolean" ) );
                fr . gridControl1 . DataSource = dr;
                fr . r369 = "3";
                fr . Text = "R_196 信息查询";
                fr . PassDataBetweenForm += new R_Frm369 . PassDataBetweenFormHandler ( fr_PassDataBetweenForm );
                fr . StartPosition = FormStartPosition . CenterScreen;
                fr . ShowDialog ( );
            }
        }
        private void fr_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConOne . IndexOf ( "," ) > 0 )
                textBox49 . Text = string . Join ( "," ,e . ConOne . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox49 . Text = e . ConOne;
            model . AH01 = textBox49 . Text;
            if ( e . ConTwo . IndexOf ( "," ) > 0 )
                textBox50 . Text = string . Join ( "," ,e . ConTwo . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox50 . Text = e . ConTwo;
            model . AH99 = textBox50 . Text;
            if ( e . ConTre . IndexOf ( "," ) > 0 )
                textBox3 . Text = string . Join ( "," ,e . ConTre . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox3 . Text = e . ConTre;
            model . AH100 = textBox3 . Text;
            if ( e . ConFor . IndexOf ( "," ) > 0 )
                textBox6 . Text = string . Join ( "," ,e . ConFor . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox6 . Text = e . ConFor;
            model . AH98 = textBox6 . Text;
            if ( string . IsNullOrEmpty ( e . ConFiv ) )
                model . AH101 = 0;
            else
                model . AH101 = Convert . ToInt64 ( e . ConFiv );
            textBox53 . Text = e . ConFiv;
            if ( e . ConSix . IndexOf ( "," ) > 0 )
                textBox15 . Text = string . Join ( "," ,e . ConSix . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox15 . Text = e . ConSix;
            model . AH24 = textBox15 . Text;
            if ( e . ConSev . IndexOf ( "," ) > 0 )
                textBox18 . Text = string . Join ( "," ,e . ConSev . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox18 . Text = e . ConSev;
            model . AH25 = textBox18 . Text;
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            R_FrmTPADGA tpadga = new R_FrmTPADGA ( );
            DataTable did = bll . GetDataOfSuppiler ( );
            tpadga . gridControl2 . DataSource = did;
            tpadga . st = "2";
            tpadga . Text = "R_196 供应商查询";
            tpadga . PassDataBetweenForm += new R_FrmTPADGA . PassDataBetweenFomrHandler ( tpadga_PassDataBetweenForm );
            tpadga . StartPosition = FormStartPosition . CenterScreen;
            tpadga . ShowDialog ( );
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model . AH114 = e . ConOne;
            textBox7 . Tag = model . AH114 . ToString ( );
            textBox7 . Text = e . ConTwo;
            textBox8 . Text = e . ConSev;
            textBox9 . Text = e . ConTre;
            textBox10 . Text = e . ConFor;
            textBox11 . Text = e . ConFiv;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base . add ( );

            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableTrue ( spList );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableTrue ( pageList );
            Ergodic . FormEvery ( this );
            gridControl1 . DataSource = null;
            dateTimePicker1 . Enabled = dateTimePicker2 . Enabled = dateTimePicker4 . Enabled = false;
            textBox4 . Enabled = false;
            sign = "1";
            label3 . Visible = false;
            model . AH97 = oddNumbers . purchaseContract ( "SELECT MAX(AJ010) AJ010 FROM R_PQAJ" ,"AJ010" ,"R_196-" );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
        }
        protected override void update ( )
        {
            base . update ( );

            if ( label3 . Visible == true )
                MessageBox . Show ( "单号:" + model . AH97 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic . SpliEnableTrue ( spList );
                Ergodic . TablePageEnableTrue ( pageList );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;

                label3 . Visible = false;
                textBox4 . Enabled = false;
                dateTimePicker1 . Enabled = dateTimePicker2 . Enabled = dateTimePicker4 . Enabled = false;
            }
        }
        void dele ( )
        {
            stateOfOdd = "";
            if ( label3 . Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll . DeleteOddNum ( model . AH97 ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins . username ,DateTime . Now ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "成功删除数据" );
                Ergodic . TablePageEnableClear ( pageList );
                Ergodic . TablePageEnableFalse ( pageList );
                Ergodic . SpliClear ( spList );
                Ergodic . SpliEnableFalse ( spList );
                Ergodic . FormEvery ( this );
                gridControl1 . DataSource = null;

                toolSelect . Enabled = toolAdd . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                sign = "";
                weihu = "";
                label3 . Visible = label9 . Visible = false;
            }
        }
        protected override void delete ( )
        {
            base . delete ( );

            if ( label3 . Visible == true )
            {
                if ( Logins . number == "MLL-0001" )
                    dele ( );
                else
                    MessageBox . Show ( "单号:" + model . AH97 + "的单据状态为执行,需要总经理删除" );
            }
            else
                dele ( );
        }
        protected override void print ( )
        {
            base . print ( );

            if ( label3 . Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQAH" ,"AH115" ,model . AH97 ,"AH97" );

                file = "";
                file = System . Windows . Forms . Application . StartupPath;
                createRDataSet ( );
                report . Load ( file + "\\R_196.frx" );
                report . RegisterData ( RDataSet );
                report . Show ( );
            }
            else
                MessageBox . Show ( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base . export ( );

            file = "";
            file = System . Windows . Forms . Application . StartupPath;
            
            createRDataSet ( );
            report . Load ( file + "\\R_196.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

        }
        protected override void revirw ( )
        {
            base . revirw ( );

            bool over = false;
            if ( !string . IsNullOrEmpty ( textBox13 . Text ) )
                over = true;
            else
                over = false;
            Reviews ( "AH97" ,model . AH97 ,"R_PQAH" ,this ,"" ,"R_196" ,false ,over ,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_196"*/ );
            over = false;
            over = sp . reviewImple ( "R_196" ,model . AH97 );
            if ( over == true )
            {
                label3 . Visible = true;
                try
                {
                    SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQAHC" ,"R_PQAH" ,"AH97" ,model . AH97 ) );
                    WriteOfReceivablesTo ( );
                }
                catch { }
            }
            else
                label3 . Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary . ProductCostSummaryLibrary modelAm = new MulaolaoLibrary . ProductCostSummaryLibrary ( );
            receiva = bll . GetDataTableOfRecevable ( model . AH97 );
            if ( receiva != null && receiva . Rows . Count > 0 )
            {
                modelAm . AM002 = receiva . Rows [ 0 ] [ "AH01" ] . ToString ( );
                modelAm . AM108 = modelAm . AM110 = modelAm . AM111 = modelAm . AM115 = modelAm . AM070 = modelAm . AM072 = modelAm . AM074 = modelAm . AM076 = modelAm . AM078 = modelAm . AM080 = modelAm . AM082 = modelAm . AM084 = modelAm . AM086 = modelAm . AM088 = modelAm . AM090 = modelAm . AM092 = 0;
                modelAm . AM070 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' AND AH18= '雕刻'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '雕刻'" ) );
                modelAm . AM072 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '绕锯'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '绕锯'" ) );
                modelAm . AM074 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '夹料'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '夹料'" ) );
                modelAm . AM076 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '擦砂皮'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '擦砂皮'" ) );
                modelAm . AM078 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' AND AH18= '丝印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '丝印'" ) );
                modelAm . AM080 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '走台印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '走台印'" ) );
                modelAm . AM082 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '移印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '移印'" ) );
                modelAm . AM084 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '热转印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '热转印'" ) );
                modelAm . AM086 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '烫印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '烫印'" ) );
                modelAm . AM088 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '喷漆'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '喷漆'" ) );
                modelAm . AM090 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '冲压'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '冲压'" ) );
                modelAm . AM092 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '手工剪切、其它'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '手工剪切、其它'" ) );
                modelAm . AM111 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='T' AND AH111='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='T'  AND AH111='F'" ) );
                modelAm . AM108 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外'  AND AH113='F'  AND AH111='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外'  AND AH113='F'  AND AH111='F'" ) );
                modelAm . AM110 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='F'  AND AH111='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='F'  AND AH111='T'" ) );
                modelAm . AM115 = string . IsNullOrEmpty ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='T'  AND AH111='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(AH)" ,"AH01='" + modelAm . AM002 + "' and AH18= '委外' AND AH113='T'  AND AH111='T'" ) );
                result = bll . UpdateOfRecevable ( modelAm ,model . AH97 );
            }
        }
        void variables ( )
        {
            model . AH114 = textBox7 . Tag . ToString ( );
            model . AH01 = textBox49 . Text;
            model . AH02 = lookUpEdit1 . EditValue . ToString ( );
            model . AH03 = textBox7 . Text;
            model . AH04 = dateTimePicker14 . Value;
            model . AH05 = textBox17 . Text;
            model . AH06 = dateTimePicker1 . Value;
            model . AH07 = textBox13 . Text;
            model . AH08 = dateTimePicker2 . Value;
            model . AH09 = textBox16 . Text;
            model . AH24 = textBox15 . Text;
            model . AH25 = textBox18 . Text;
            model . AH26 = checkBox36 . Checked == true ? "T" : "F";
            model . AH27 = checkBox38 . Checked == true ? "T" : "F";
            model . AH28 = checkBox39 . Checked == true ? "T" : "F";
            model . AH29 = checkBox40 . Checked == true ? "T" : "F";
            model . AH30 = comboBox16 . Text;
            model . AH31 = dateTimePicker5 . Value;
            model . AH32 = checkBox4 . Checked == true ? "T" : "F";
            model . AH33 = checkBox7 . Checked == true ? "T" : "F";
            model . AH34 = checkBox5 . Checked == true ? "T" : "F";
            model . AH35 = checkBox6 . Checked == true ? "T" : "F";
            model . AH36 = checkBox1 . Checked == true ? "T" : "F";
            model . AH37 = checkBox2 . Checked == true ? "T" : "F";
            model . AH38 = checkBox3 . Checked == true ? "T" : "F";
            model . AH39 = checkBox8 . Checked == true ? "T" : "F";
            model . AH40 = checkBox9 . Checked == true ? "T" : "F";
            model . AH41 = checkBox10 . Checked == true ? "T" : "F";
            model . AH42 = checkBox41 . Checked == true ? "T" : "F";
            model . AH43 = textBox26 . Text;
            model . AH44 = textBox1 . Text;
            model . AH45 = textBox16 . Text;
            model . AH46 = dateTimePicker6 . Value;
            model . AH47 = textBox18 . Text;
            model . AH48 = dateTimePicker7 . Value;
            model . AH49 = checkBox11 . Checked == true ? "T" : "F";
            model . AH50 = checkBox12 . Checked == true ? "T" : "F";
            model . AH51 = checkBox13 . Checked == true ? "T" : "F";
            model . AH52 = checkBox14 . Checked == true ? "T" : "F";
            model . AH53 = checkBox17 . Checked == true ? "T" : "F";
            model . AH54 = checkBox21 . Checked == true ? "T" : "F";
            model . AH55 = checkBox26 . Checked == true ? "T" : "F";
            model . AH56 = checkBox27 . Checked == true ? "T" : "F";
            model . AH57 = checkBox19 . Checked == true ? "T" : "F";
            model . AH58 = checkBox24 . Checked == true ? "T" : "F";
            model . AH59 = checkBox30 . Checked == true ? "T" : "F";
            model . AH60 = checkBox33 . Checked == true ? "T" : "F";
            model . AH61 = checkBox35 . Checked == true ? "T" : "F";
            model . AH62 = checkBox32 . Checked == true ? "T" : "F";
            model . AH63 = checkBox31 . Checked == true ? "T" : "F";
            model . AH64 = checkBox34 . Checked == true ? "T" : "F";
            model . AH65 = textBox30 . Text;
            if ( radioButton1 . Checked )
                model . AH66 = radioButton1 . Text;
            else if ( radioButton2 . Checked )
                model . AH66 = radioButton2 . Text;
            else
                model . AH66 = "";
            if ( radioButton3 . Checked )
                model . AH67 = radioButton3 . Text;
            else if ( radioButton4 . Checked )
                model . AH67 = radioButton4 . Text;
            else
                model . AH67 = "";
            if ( radioButton6 . Checked )
            {
                model . AH68 = radioButton6 . Text;
                model . AH69 = textBox24 . Text;
            }
            else if ( radioButton5 . Checked )
            {
                model . AH68 = radioButton5 . Text;
                model . AH69 = "";
            }
            else
            {
                model . AH68 = "";
                model . AH69 = "";
            }
            model . AH70 = textBox31 . Text;
            model . AH71 = dateTimePicker8 . Value;
            model . AH72 = string . IsNullOrEmpty ( textBox33 . Text ) == true ? 0 : Convert . ToInt64 ( textBox33 . Text );
            if ( radioButton7 . Checked )
            {
                model . AH73 = radioButton7 . Text;
                model . AH76 = textBox35 . Text;
            }
            else if ( radioButton8 . Checked )
            {
                model . AH73 = radioButton8 . Text;
                model . AH76 = "";
            }
            else if ( radioButton9 . Checked )
            {
                model . AH73 = radioButton9 . Text;
                model . AH76 = "";
            }
            else
            {
                model . AH73 = "";
                model . AH76 = "";
            }
            model . AH74 = comboBox5 . Text;
            model . AH75 = dateTimePicker9 . Value;
            model . AH77 = string . IsNullOrEmpty ( textBox36 . Text ) == true ? 0 : Convert . ToInt64 ( textBox36 . Text );
            model . AH78 = string . IsNullOrEmpty ( textBox37 . Text ) == true ? 0 : Convert . ToInt64 ( textBox37 . Text );
            model . AH79 = string . IsNullOrEmpty ( textBox38 . Text ) == true ? 0 : Convert . ToInt64 ( textBox38 . Text );
            model . AH80 = string . IsNullOrEmpty ( textBox41 . Text ) == true ? 0 : Convert . ToInt64 ( textBox41 . Text );
            model . AH81 = string . IsNullOrEmpty ( textBox40 . Text ) == true ? 0 : Convert . ToInt64 ( textBox40 . Text );
            model . AH82 = string . IsNullOrEmpty ( textBox39 . Text ) == true ? 0 : Convert . ToInt64 ( textBox39 . Text );
            model . AH83 = string . IsNullOrEmpty ( textBox44 . Text ) == true ? 0 : Convert . ToInt64 ( textBox44 . Text );
            model . AH84 = string . IsNullOrEmpty ( textBox43 . Text ) == true ? 0 : Convert . ToInt64 ( textBox43 . Text );
            model . AH85 = string . IsNullOrEmpty ( textBox42 . Text ) == true ? 0 : Convert . ToInt64 ( textBox42 . Text );
            model . AH86 = textBox12 . Text;
            model . AH87 = textBox45 . Text;
            model . AH88 = textBox46 . Text;
            model . AH89 = dateTimePicker10 . Value;
            model . AH90 = textBox47 . Text;
            model . AH91 = dateTimePicker11 . Value;
            model . AH92 = textBox48 . Text;
            model . AH93 = dateTimePicker12 . Value;
            model . AH94 = dateTimePicker13 . Value;
            model . AH95 = textBox4 . Text;
            model . AH98 = textBox6 . Text;
            model . AH99 = textBox50 . Text;
            model . AH100 = textBox3 . Text;
            model . AH101 = string . IsNullOrEmpty ( textBox53 . Text ) == true ? 0 : Convert . ToInt64 ( textBox53 . Text );
            model . AH106 = textBox8 . Text;
            model . AH107 = textBox9 . Text;
            model . AH108 = textBox10 . Text;
            model . AH109 = textBox11 . Text;
            model . AH110 = "";
            model . AH111 = checkBox15 . Checked == true ? "T" : "F";
            model . AH112 = lookUpEdit2 . Text;
            //model.AH113 = checkBox16.Checked == true ? "T" : "F";
        }
        void state ( )
        {
            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableFalse ( pageList );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            copy = "";
            weihu = "";
            label9 . Visible = false;
        }
        void sa ( )
        {
            result = false;
            result = bll . UpdataWeiHu ( model ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins . username ,DateTime . Now ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "录入数据失败" );
            else
            {
                MessageBox . Show ( "录入数据成功" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQAHC" ,"R_PQAH" ,"AH97" ,model . AH97 ) );
                        WriteOfReceivablesTo ( );
                    }
                    catch { }
                }
                state ( );
            }
        }
        protected override void save ( )
        {
            base . save ( );

            if ( string . IsNullOrEmpty ( textBox49 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox16 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择采购人" );
                return;
            }        
            if ( textBox7 . Tag == null )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
            variables ( );
            DataTable dt = bll . GetDataTableAll ( model . AH97 );
            if ( weihu == "1" )
            {
                if ( string . IsNullOrEmpty ( textBox4 . Text ) )
                {
                    MessageBox . Show ( "请填写维护意见" );
                    return;
                }
                if ( dt . Rows . Count < 1 )
                {
                    MessageBox . Show ( "单号:" + model . AH97 + "的记录不存在,请核实后再维护" );
                    return;
                }
                stateOfOdd = "维护保存";
                model . AH96 = dt . Rows [ 0 ] [ "AH96" ] . ToString ( ) + "[" + Logins . username + DateTime . Now . ToString ( "yyyyMMdd" ) + "]";

                sa ( );
            }
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                model . AH96 = "";
                if ( dt . Rows . Count > 0 )
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model . AH114 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";
                        DataTable del = bll . GetDataTableAnOther ( model . AH97 );
                        if ( del . Rows . Count < 1 )
                            sa ( );
                        else
                        {
                            int proNum = 0;
                            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AH101" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "AH101" ] );
                                if ( proNum != model . AH101 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( del . Select ( "AH01='" + model . AH01 + "' AND AH10='" + gridView1 . GetDataRow ( i ) [ "AH10" ] . ToString ( ) + "' AND AH11='" + gridView1 . GetDataRow ( i ) [ "AH11" ] . ToString ( ) + "'  AND AH12='" + gridView1 . GetDataRow ( i ) [ "AH12" ] . ToString ( ) + "' AND AH18='" + gridView1 . GetDataRow ( i ) [ "AH18" ] . ToString ( ) + "'" ) . Length > 0 )
                                {
                                    if ( model . AH09 . Length > 8 && model . AH09 . Substring ( 0 ,8 ) == "MLL-0001" )
                                    {
                                        sa ( );
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                                        break;
                                    }
                                }
                                else
                                {
                                    sa ( );
                                    break;
                                }
                            }
                        }
                    }
                    else
                        sa ( );
                }
                else
                    state ( );
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
                label9.Visible = toolLibrary.Enabled = toolStorage.Enabled = false;
                sign = "";
                copy = "";
                try
                {
                    bll.DeleteOddNum( model.AH97 ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( sign == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label3.Visible == true )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                textBox4.Enabled = true;

                weihu = "1";
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( label3.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }
            result = false;
            result = bll.UpdateAdd( model.AH97 ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                stateOfOdd = "复制更改单号";
                model.AH97 = oddNumbers.purchaseContract( "SELECT MAX(AJ010) AJ010 FROM R_PQAJ" ,"AJ010" ,"R_196-" );
                result = false;
                result = bll.UpdateAdds( model.AH97 ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result==false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    bll.DeleteAdd( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox4.Enabled = false;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                    sign = "1";
                    copy = "1";
                    weihu = "";
                    label3.Visible = false;
                    label9.Visible = true;
                    queryContent( );
                }
            }
        }
        #endregion
        
        #region Event
        private void textBox49_TextChanged ( object sender ,EventArgs e )
        {
            model.AH01 = textBox49.Text;
          
            every( );
        }
        void every ( )
        {
            desx = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 AH10,GS08 AH11,GS09 AH21,GS10 AH13 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS34=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS07!='' AND GS01=@GS01 " ,new SqlParameter ( "@GS01" ,model . AH01 ) );

            dl = SqlHelper.ExecuteDataTable( "SELECT AH10,AH11,AH12,AH13,AH14,AH15,AH16,AH17,AH18,AH19,AH20,AH21 FROM R_PQAH WHERE AH01=@AH01" ,new SqlParameter( "@AH01" ,model.AH01 ) );
            if ( desx != null )
                dl.Merge( desx );
            dls = dl . DefaultView . ToTable ( true ,"AH10" ,"AH11" );
            txtPart . Properties . DataSource = dls;
            txtPart . Properties . DisplayMember = "AH10";
            txtPart . Properties . ValueMember = "AH10";
            //textBox14.DataSource = dl.DefaultView.ToTable( true ,"AH11" );
            //textBox14.DisplayMember = "AH11";
            comboBox14.DataSource = dl.DefaultView.ToTable( true ,"AH12" );
            comboBox14.DisplayMember = "AH12";
            comboBox2.DataSource = dl.DefaultView.ToTable( true ,"AH13" );
            comboBox2.DisplayMember = "AH13";
            comboBox3.DataSource = dl.DefaultView.ToTable( true ,"AH14" );
            comboBox3.DisplayMember = "AH14";
            comboBox7.DataSource = dl.DefaultView.ToTable( true ,"AH16" );
            comboBox7.DisplayMember = "AH16";
            comboBox8.DataSource = dl.DefaultView.ToTable( true ,"AH17" );
            comboBox8.DisplayMember = "AH17";
            comboBox4.DataSource = dl.DefaultView.ToTable( true ,"AH18" );
            comboBox4.DisplayMember = "AH18";
            comboBox12.DataSource = dl.DefaultView.ToTable( true ,"AH19" );
            comboBox12.DisplayMember = "AH19";
            comboBox6.DataSource = dl.DefaultView.ToTable( true ,"AH21" );
            comboBox6.DisplayMember = "AH21";
        }
        //物料名称
        private void comboBox21_SelectedIndexChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( txtPart.Text ) && dl.Select( "AH10='" + txtPart.Text + "'" ).Length > 0 )
            {
                textBox14.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH11"].ToString( );
                comboBox6.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH21"].ToString( );
                comboBox2.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH13"].ToString( );
                comboBox14.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH12"].ToString( );
                comboBox3.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH14"].ToString( );
                textBox2.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH15"].ToString( );
                comboBox7.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH16"].ToString( );
                comboBox8.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH17"].ToString( );
                comboBox4.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH18"].ToString( );
                comboBox12.Text = dl.Select( "AH10='" + txtPart.Text + "'" )[0]["AH19"].ToString( );
            }
        }
        //乙方
        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            //DataTable de = SqlHelper.ExecuteDataTable( "SELECT AH106,AH107,AH108,AH109 FROM R_PQAH WHERE AH03=@AH03" ,new SqlParameter( "@AH03" ,textBox7.Text ) );
            //if ( de.Rows.Count > 0 )
            //{
            //    comboBox9.Text = de.Rows[0]["AH106"].ToString( );
            //    comboBox10.Text = de.Rows[0]["AH107"].ToString( );
            //    comboBox13.Text = de.Rows[0]["AH108"].ToString( );
            //    comboBox19.Text = de.Rows[0]["AH109"].ToString( );
            //}
        }
        //联系人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                model.AH02 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = db.Select( "DBA001='" + model.AH02 + "'" )[0]["DBA028"].ToString( );
            }

            //DataTable dli = SqlHelper.ExecuteDataTable( "SELECT DBA028 FROM TPADBA WHERE DBA001=@DBA001" ,new SqlParameter( "@DBA001" ,model.AH02 ) );
            //if ( dli.Rows.Count < 1 )
            //    textBox5.Text = "";
            //else
            //    textBox5.Text = dli.Rows[0]["DBA028"].ToString( );
        }
        //每套部件数量
        private void comboBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox2 );
        }
        private void comboBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox2 );
        }
        private void comboBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox2.Text != "" && !DateDayRegise.sixFour( comboBox2 ) )
            {
                this.comboBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多四位,如99.9999,请重新输入" );
            }
        }
        //丝.热.移印/色价数
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //现价
        private void comboBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox7 );
        }
        private void comboBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox7 );
        }
        private void comboBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox7.Text != "" && !DateDayRegise.sixFour( comboBox7 ) )
            {
                this.comboBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多四位,如99.9999,请重新输入" );
            }
        }
        //预付款
        private void comboBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //抽查数量
        private void textBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //AQL
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
        //审批人
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox48.Text ) )
                textBox48.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox48.Text ) && textBox48.Text == Logins.username )
                textBox48.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox47.Text ) )
                textBox47.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox47.Text ) && textBox47.Text == Logins.username )
                textBox47.Text = "";
            dateTimePicker11.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //乙方
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox46.Text ) )
                textBox46.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox46.Text ) && textBox46.Text == Logins.username )
                textBox46.Text = "";
            dateTimePicker10.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //甲方
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox45.Text ) )
                textBox45.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox45.Text ) && textBox45.Text == Logins.username )
                textBox45.Text = "";
        }
        //开合同人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox17.Text ) )
            {
                textBox17.Text = Logins.username;
                model.AH05 = textBox17.Text;
                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQAH" ,model.AH05 ,textBox17 ,textBox16 ,"AH09" );
                if ( str[0] == "" )
                    textBox17.Text = "";
                else
                    model.AH09 = str[1];
                textBox16.Text = model.AH09;
            }
            else if ( !string.IsNullOrEmpty( textBox17.Text ) && textBox17.Text == Logins.username )
            {
                textBox17.Text = "";
                model.AH05 = "";
                textBox16.Text = "";
                model.AH09 = "";
            }

            if ( string.IsNullOrEmpty( textBox45.Text ) )
                textBox45.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox45.Text ) && textBox45.Text == Logins.username )
                textBox45.Text = "";

            dateTimePicker1 . Value = DateTime . Now;
        }
        //成本员
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox13.Text ) )
                textBox13.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox13.Text ) && textBox13.Text == Logins.username )
                textBox13.Text = "";
            dateTimePicker2 . Value = DateTime . Now;
        }
        //表
        string ah10 = "", ah11 = "", ah12 = "", ah18 = "";
        private void gridView1_RowCellClick ( object sender ,RowCellClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    model.idx = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assign( );
                    //dateTimePicker4.Value = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "AH23" ).ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( gridView1.GetFocusedRowCellValue( "AH23" ).ToString( ) );
                } 
            }
        }
        void assign ( )
        {
            model = bll.GetMode( model.idx );
            txtPart.Text = model.AH10.ToString( );
            textBox14.Text = model.AH11;
            comboBox14.Text = model.AH12;
            comboBox2.Text = model.AH13.ToString( );
            comboBox3.Text = model.AH14.ToString( );
            textBox2.Text = model.AH15.ToString( );
            comboBox7.Text = model.AH16.ToString( );
            comboBox8.Text = model.AH17.ToString( );
            comboBox4.Text = model.AH18;
            comboBox12.Text = model.AH19;
            comboBox6.Text = model.AH21;
            if ( model.AH22>DateTime.MinValue && model.AH22<DateTime.MaxValue )
                dateTimePicker3.Value = model.AH22;
            if ( model.AH23 > DateTime.MinValue && model.AH23 < DateTime.MaxValue )
                dateTimePicker4.Value = model.AH23;  
            ah10 = txtPart.Text;
            ah11 = textBox14.Text;
            ah12 = comboBox14.Text;
            ah18 = comboBox4.Text;
        }
        //decimal customSum = 0;
        private void gridView1_CustomSummaryCalculate ( object sender ,DevExpress.Data.CustomSummaryEventArgs e )
        {
            //int summaryId = Convert.ToInt32( ( e.Item as GridSummaryItem ).Tag );
            //GridView gridView = sender as GridView;
            ////Initialization
            //if ( e.SummaryProcess == CustomSummaryProcess.Start )
            //{
            //    customSum = 0;
            //}
            ////Calculation
            //if ( e.SummaryProcess == CustomSummaryProcess.Calculate )
            //{
            //    decimal sum = 0;
            //    object AH101Temp = 0;
            //    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            //    {
            //        object AH16Temp = gridView1.GetDataRow( i )["AH16"];
            //        AH16Temp = ( AH16Temp == DBNull.Value || AH16Temp == null ) ? 0 : AH16Temp;
            //        object AH13Temp = gridView1.GetDataRow( i )["AH13"];
            //        AH13Temp = ( AH13Temp == DBNull.Value || AH13Temp == null ) ? 0 : AH13Temp;
            //        object AH14Temp = gridView1.GetDataRow( i )["AH14"];
            //        AH14Temp = ( AH14Temp == DBNull.Value || AH14Temp == null ) ? 0 : AH14Temp;
            //        object AH17Temp = gridView1.GetDataRow( i )["AH17"];
            //        AH17Temp = ( AH17Temp == DBNull.Value || AH17Temp == null ) ? 0 : AH17Temp;
            //        AH101Temp = gridView1.GetDataRow( i )["AH101"];
            //        AH101Temp = ( AH101Temp == DBNull.Value || AH101Temp == null ) ? 0 : AH101Temp;
            //        sum += Convert.ToDecimal( AH16Temp ) * Convert.ToDecimal( AH101Temp ) * Convert.ToDecimal( AH13Temp ) * Convert.ToDecimal( AH14Temp ) - Convert.ToDecimal( AH17Temp );
            //    }
            //    customSum = Convert.ToDecimal( AH101Temp ) == 0 ? 0 : Math.Round( sum / Convert.ToDecimal( AH101Temp ) ,4 );
            //}
            //if ( e.SummaryProcess == CustomSummaryProcess.Finalize )
            //{
            //    if ( summaryId == 1 )
            //        e.TotalValue = customSum;
            //}
        }
        private void R_FrmSiReYiYinContract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) || string.IsNullOrEmpty( txtPart.Text ) )
                textBox2.Text = "0";
            else
                previousOfPrice( );
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) || string.IsNullOrEmpty( txtPart.Text ) )
                textBox2.Text = "0";
            else
                previousOfPrice( );

            if ( txtPart . EditValue != null )
                textBox14 . Text = dl . Select ( "AH10='" + txtPart . EditValue . ToString ( ) + "'" ) [ 0 ] [ "AH11" ] . ToString ( );
            else
                textBox14 . Text = string . Empty;
        }
        void previousOfPrice ( )
        {
            DataTable dp = bll.GetDataTableOfPrice( textBox3.Text ,txtPart.Text );
            if ( dp != null && dp.Rows.Count > 0 )
                textBox2.Text = dp.Rows[0]["AH16"].ToString( );
            else
                textBox2.Text = "0";
        }
        private void txtPart_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View1 . GetFocusedDataRow ( );
            if ( row == null )
            {
                if ( dls != null && dls . Rows . Count > 0 && dls . Select ( "AH10='" + txtPart . Text + "'" ) . Length > 0 )
                    row = dls . Select ( "AH10='" + txtPart . Text + "'" ) [ 0 ];
                if ( row == null )
                    textBox2 . Text = "0";
                else
                    previousOfPrice ( );
            }
            else
                previousOfPrice ( );

            if ( row != null )
                textBox14 . Text = row [ "AH11" ] . ToString ( );
            else
                textBox14 . Text = string . Empty;
        }
        #endregion

        #region Table
        void variable ( )
        {
            model . AH01 = textBox49 . Text;
            model . AH10 = txtPart . Text;
            model . AH11 = textBox14 . Text;
            model . AH12 = comboBox14 . Text;
            model . AH13 = string . IsNullOrEmpty ( comboBox2 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox2 . Text );
            model . AH14 = string . IsNullOrEmpty ( comboBox3 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox3 . Text );
            model . AH15 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            model . AH16 = string . IsNullOrEmpty ( comboBox7 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox7 . Text );
            model . AH17 = string . IsNullOrEmpty ( comboBox8 . Text ) == true ? 0 : Convert . ToInt64 ( comboBox8 . Text );
            model . AH18 = comboBox4 . Text;
            model . AH19 = comboBox12 . Text;
            model . AH21 = comboBox6 . Text;
            model . AH22 = dateTimePicker3 . Value;
            model . AH23 = dateTimePicker4 . Value;
            model . AH101 = string . IsNullOrEmpty ( textBox53 . Text ) == true ? 0 : Convert . ToInt64 ( textBox53 . Text );
            if ( textBox7 . Tag != null )
                model . AH114 = textBox7 . Tag . ToString ( );
        }
        //Build
        private void button1_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox49 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtPart . Text ) )
            {
                MessageBox . Show ( "物料或部件名称不可为空" );
                return;
            }
            if ( dateTimePicker3 . Value < DateTime . Now . AddDays ( 5 ) )
            {
                MessageBox . Show ( "约定供期必须在当天的基础上延迟5天" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox16 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            variable ( );
            if ( string . IsNullOrEmpty ( model.AH114 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
           
            stateOfOdd = "";
            if ( label3 . Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            result = false;
            result = bll . ExistsAdd ( model );
            if ( result == false )
            {
                result = bll . Add ( model , "R_196" , "丝.热.移印(化学品)承揽加工合同书" , Logins . username , DateTime . Now , "新建" , stateOfOdd );
                if ( result == false )
                    MessageBox . Show ( "录入数据失败,请刷新再试" );
                else
                {
                    MessageBox . Show ( "成功录入数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                    refre ( );
                    model . AH01 = textBox49 . Text;
                    every ( );
                }
            }
            else
            {
                if ( Logins . number . Equals ( "MLL-0001" ) )
                {
                    result = bll . Add ( model ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins . username ,DateTime . Now ,"新建" ,stateOfOdd );
                    if ( result == false )
                        MessageBox . Show ( "录入数据失败,请刷新再试" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                        refre ( );
                        model . AH01 = textBox49 . Text;
                        every ( );
                    }
                }
                else
                    MessageBox . Show ( "此单为超补,需要总经理处理" );
            }
        }
        //Edit
        void edit ( )
        {
            model.AH01 = textBox49.Text;
            every( );
        }
        private void button2_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox49 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtPart . Text ) )
            {
                MessageBox . Show ( "物料或部件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox16 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            variable ( );
            if ( string . IsNullOrEmpty ( model . AH114 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
           
            if ( label3 . Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }
            if ( model . AH10 == ah10 && model . AH11 == ah11 && model . AH12 == ah12 && model . AH18 == ah18 )
            {
                result = false;
                result = bll . Update ( model , "R_196" , "丝.热.移印(化学品)承揽加工合同书" , Logins . username , DateTime . Now , "编辑" , stateOfOdd );
                if ( result == false )
                    MessageBox . Show ( "编辑数据失败,请刷新再试" );
                else
                {
                    MessageBox . Show ( "成功编辑数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                    refre ( );
                    edit ( );
                }
            }
            else
            {
                result = false;
                result = bll . ExistsAdd ( model );
                if ( result == false )
                {
                    result = false;
                    result = bll . Update ( model , "R_196" , "丝.热.移印(化学品)承揽加工合同书" , Logins . username , DateTime . Now , "编辑" , stateOfOdd );
                    if ( result == false )
                        MessageBox . Show ( "编辑数据失败,请刷新再试" );
                    else
                    {
                        MessageBox . Show ( "成功编辑数据" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                        refre ( );
                        edit ( );
                    }
                }
                else
                {
                    if ( Logins.number.Equals( "MLL-0001") )
                    {
                        result = false;
                        result = bll . Update ( model , "R_196" , "丝.热.移印(化学品)承揽加工合同书" , Logins . username , DateTime . Now , "编辑" , stateOfOdd );
                        if ( result == false )
                            MessageBox . Show ( "编辑数据失败,请刷新再试" );
                        else
                        {
                            MessageBox . Show ( "成功编辑数据" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND AH97='" + model . AH97 + "'";
                            refre ( );
                            edit ( );
                        }
                    }
                    else
                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                }
            }
        }
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button4_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox53.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( label3.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( sign == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }
                //model.AH101 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
                result = false;
                result = bll.UpdateBatch( model ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd );
                if ( result == false )
                    MessageBox.Show( "编辑数据失败,请刷新再试" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AH97='" + model.AH97 + "'";
                    refre( );
                    edit( );
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.AH101 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;
            if ( label3.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sign == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.Delete( model.idx ,"R_196" ,"丝.热.移印(化学品)承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd ,model.AH97 );
            if ( result==false )
                MessageBox.Show( "删除数据失败,请刷新再试" );
            else
            {
                MessageBox.Show( "删除数据成功" );

                //tableSele.Rows.Remove( tableSele.Select( "idx='" + model.idx + "'" )[0] );
                button13_Click ( null , null );
            }
        }
        //Refresh        
        private void button13_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND AH97='" + model.AH97 + "'";
            refre( );
            model . AH01 = textBox49 . Text;
            every ( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableSele = bll.GetDataTableTable( strWhere );
            gridControl1.DataSource = tableSele;
            assignMent ( );
        }
        void assignMent ( )
        {
            if ( gridView1 . DataRowCount > 0 )
            {
                U0 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( gridView1 . GetDataRow ( 0 ) [ "AH101" ] . ToString ( ) ) ,4 ) . ToString ( ) );
            }
        }
        //date
        yanpinSelect ys = new yanpinSelect( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + textBox49.Text + "\n\r物料或部件名称:" + txtPart.Text + "\n\r按图纸或样板:" + textBox14.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = model.AH97;
                ys.ysTwo = txtPart.Text;
                ys.ysThr = textBox14.Text;
                ys.ysFou = "";
                ys.ysFiv = "";
                ys.ysSix = "R_196";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion

    }
}
