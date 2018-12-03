using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Mulaolao.Contract;
using Mulaolao.Class;
using StudentMgr;
using FastReport;
using FastReport.Export.Xml;
using System.Linq;
using System.Collections.Generic;
using Mulaolao.Bom;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmchanpinzhibiao :FormChild
    {
        public R_Frmchanpinzhibiao ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ChanPinZhiBiaoLibrary model = new MulaolaoLibrary.ChanPinZhiBiaoLibrary( );
        MulaolaoBll.Dao.ChanPinZhiBaoDao dao = new MulaolaoBll.Dao.ChanPinZhiBaoDao( );
        Report report = new Report( ); SpecialPowers sp = new SpecialPowers( );
        DataTable dia, desx, dl, de; DataSet RDataSet;
        string copy = "", strWhere = "1=1", sav = "", weihu = "", file = "", numQu = "", stateOfOdd = "";
        bool result = false;
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        
        private void R_Frmchanpinzhibiao_Load ( object sender ,EventArgs e )
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

            textBox3 . Enabled = false;
            label45 . Visible = false;
            label46 . Visible = false;

            dia = dao . GetDataTableCon ( );
            lookUpEdit1 . Properties . DataSource = dia;
            lookUpEdit1 . Properties . ValueMember = "DBA001";
            lookUpEdit1 . Properties . DisplayMember = "DBA002";

            lookUpEdit2 . Properties . DataSource = dao . GetDataTableWork ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";

            if ( Logins . number == "MLL-0001" || Logins . number == "MLL-0007" || Logins . number == "MLL-0008" )
                checkBox18 . Visible = true;
            else
                checkBox18 . Visible = false;

            if ( Logins . number == "MLL-0001" )
                checkBox17 . Visible = true;
            else
                checkBox17 . Visible = false;
        }
        
        private void R_Frmchanpinzhibiao_Shown ( object sender ,EventArgs e )
        {
            model . CP03 = Merges . oddNum;
            if ( model . CP03 != null && model . CP03 != "" )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region Print Export
        private void CreateDateSet ( )
        {
            RDataSet = new DataSet ( );

            DataTable print = dao . GetDataTablePrintOne ( model . CP03 );
            DataTable prints = dao . GetDataTablePrintTwo ( model . CP03 );
            print . TableName = "R_PQQ";
            prints . TableName = "R_PQQS";
            RDataSet . Tables . Add ( print );
            RDataSet . Tables . Add ( prints );
        }
        #endregion

        #region Query
        void queryContent ( )
        {
            if ( model . CP03 != null && model . CP03 != "" )
            {
                model = dao . GetMo ( model . CP03 );

                if ( model != null )
                {
                    lookUpEdit1 . Text = dia . Select ( "DBA001='" + model . CP02 + "'" ) . Length > 0 ? dia . Select ( "DBA001='" + model . CP02 + "'" ) [ 0 ] [ "DBA002" ] . ToString ( ) : string . Empty;
                    textBox7 . Text = dia . Select ( "DBA001='" + model . CP02 + "'" ) . Length > 0 ? dia . Select ( "DBA001='" + model . CP02 + "'" ) [ 0 ] [ "DBA028" ] . ToString ( ) : string . Empty;
                    textBox4 . Tag = model . CP59;
                    if ( string . IsNullOrEmpty ( model . CP59 ) )
                    {
                        textBox4 . Text = model . CP44;
                        textBox5 . Text = model . CP45;
                        textBox6 . Text = model . CP46;
                        textBox8 . Text = model . CP47;
                        textBox12 . Text = model . CP48;
                    }
                    else
                    {
                        DataTable supplier = dao . GetDataTableOfSu ( model . CP59 );
                        if ( supplier != null && supplier . Rows . Count > 0 )
                        {
                            textBox4 . Text = supplier . Rows [ 0 ] [ "DGA003" ] . ToString ( );
                            textBox5 . Text = supplier . Rows [ 0 ] [ "DGA017" ] . ToString ( );
                            textBox6 . Text = supplier . Rows [ 0 ] [ "DGA008" ] . ToString ( );
                            textBox8 . Text = supplier . Rows [ 0 ] [ "DGA009" ] . ToString ( );
                            textBox12 . Text = supplier . Rows [ 0 ] [ "DGA011" ] . ToString ( );
                        }
                        else
                            textBox4 . Text = textBox5 . Text = textBox6 . Text = textBox8 . Text = textBox12 . Text = "";
                    }
                    textBox1 . Text = model . CP01;
                    textBox10 . Text = model . CP51;
                    textBox9 . Text = model . CP52;
                    textBox11 . Text = model . CP53;
                    textBox13 . Text = model . CP54 . ToString ( );
                    comboBox5 . Text = model . CP05;
                    textBox2 . Text = model . CP04;
                    checkBox1 . Checked = model . CP15 . Trim ( ) == "T" ? true : false;
                    checkBox2 . Checked = model . CP16 . Trim ( ) == "T" ? true : false;
                    checkBox3 . Checked = model . CP17 . Trim ( ) == "T" ? true : false;
                    if ( model . CP18 . Trim ( ) == "T" )
                    {
                        checkBox4 . Checked = true;
                        textBox20 . Text = model . CP19 . ToString ( );
                    }
                    else
                    {
                        checkBox4 . Checked = false;
                        textBox20 . Text = "";
                    }
                    checkBox5 . Checked = model . CP20 . Trim ( ) == "T" ? true : false;
                    checkBox6 . Checked = model . CP21 . Trim ( ) == "T" ? true : false;
                    checkBox7 . Checked = model . CP22 . Trim ( ) == "T" ? true : false;
                    checkBox8 . Checked = model . CP23 . Trim ( ) == "T" ? true : false;
                    checkBox9 . Checked = model . CP24 . Trim ( ) == "T" ? true : false;
                    checkBox10 . Checked = model . CP25 . Trim ( ) == "T" ? true : false;
                    checkBox11 . Checked = model . CP26 . Trim ( ) == "T" ? true : false;
                    checkBox12 . Checked = model . CP27 . Trim ( ) == "T" ? true : false;
                    checkBox13 . Checked = model . CP28 . Trim ( ) == "T" ? true : false;
                    checkBox14 . Checked = model . CP29 . Trim ( ) == "T" ? true : false;
                    checkBox15 . Checked = model . CP30 . Trim ( ) == "T" ? true : false;
                    checkBox16 . Checked = model . CP31 . Trim ( ) == "T" ? true : false;
                    checkBox17 . Checked = model . CP56 . Trim ( ) == "T" ? true : false;
                    textBox23 . Text = model . CP32;
                    dateTimePicker2 . Value = string . IsNullOrEmpty ( model . CP33 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP33;
                    textBox26 . Text = model . CP34;
                    dateTimePicker3 . Value = string . IsNullOrEmpty ( model . CP35 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP35;
                    textBox28 . Text = model . CP36;
                    dateTimePicker4 . Value = string . IsNullOrEmpty ( model . CP37 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP37;
                    textBox30 . Text = model . CP38;
                    dateTimePicker5 . Value = string . IsNullOrEmpty ( model . CP39 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP39;
                    textBox32 . Text = model . CP40;
                    dateTimePicker6 . Value = string . IsNullOrEmpty ( model . CP41 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP41;
                    textBox34 . Text = model . CP42;
                    dateTimePicker7 . Value = string . IsNullOrEmpty ( model . CP43 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . CP43;
                    textBox3 . Text = model . CP49;
                    label46 . Visible = model . CP55 . Trim ( ) == "复制" ? true : false;
                    lookUpEdit2 . Text = model . CP57;
                    lookUpEdit1 . Text = dia . Select ( "DBA001='" + model . CP02 + "'" ) . Length > 0 == true ? dia . Select ( "DBA001='" + model . CP02 + "'" ) [ 0 ] [ "DBA002" ] . ToString ( ) : string . Empty;
                    checkBox18 . Checked = model . CP58 . Trim ( ) == "T" ? true : false;

                    strWhere = "1=1";
                    strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                    refre ( );
                }
            }
        }
        void autoQuery ( )
        {
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableFalse ( pageList );
            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableFalse ( spList );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            textBox3 . Enabled = false;
            sav = "2";
            queryContent ( );
        }
        SelectAll.ChanPinZhiBaoAll query = new SelectAll.ChanPinZhiBaoAll( );
        protected override void select ( )
        {
            base . select ( );

            model = new MulaolaoLibrary . ChanPinZhiBiaoLibrary ( );
            query . StartPosition = FormStartPosition . CenterScreen;
            query . PassDataBetweenForm += new SelectAll . ChanPinZhiBaoAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            query . ShowDialog ( );

            if ( model . CP03 == null /*|| model.CP03 ==""*/ )
                MessageBox . Show ( "您没有选择任何信息" );
            else
                autoQuery ( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox10 . Text = e . ConOne;
            model . CP51 = e . ConOne;
            model . CP01 = e . ConTwo;
            textBox1 . Text = e . ConTwo;
            model . CP44 = e . ConTre;
            textBox4 . Text = e . ConTre;
            model . CP52 = e . ConFor;
            textBox9 . Text = e . ConFor;
            model . CP53 = e . ConFiv;
            textBox11 . Text = e . ConFiv;
            if ( !string . IsNullOrEmpty ( e . ConSix ) )
                model . CP54 = Convert . ToInt64 ( e . ConSix );
            else
                model . CP54 = 0;
            textBox13 . Text = e . ConSix;
            if ( e . ConSev == "执行" )
                label45 . Visible = true;
            else
                label45 . Visible = false;
            model . CP03 = e . ConEgi;
        }
        R_Frmpenselect ps = new R_Frmpenselect( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable ls = dao . GetDataTableNum ( );
            {
                ls . Columns . Add ( "check" ,System . Type . GetType ( "System.Boolean" ) );
                ps . gridControl1 . DataSource = ls;
                ps . str = "6";
                ps . Text = "R_195 信息查询";
                ps . StartPosition = FormStartPosition . CenterScreen;
                ps . PassDataBetweenForm += new R_Frmpenselect . PassDataBetweenFomrHandler ( ps_PassDataBetweenForm );
                ps . ShowDialog ( );
            }
        }
        private void ps_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConOne . IndexOf ( "," ) > 0 )
                textBox1 . Text = string . Join ( "," ,e . ConOne . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox1 . Text = e . ConOne;
            model . CP01 = textBox1 . Text;
            //字符串是否包含某个字符
            if ( e . ConTwo . IndexOf ( "," ) > 0 )
                //去除字符串中重复的内容(中间是某个符号隔开的)
                textBox9 . Text = string . Join ( "," ,e . ConTwo . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox9 . Text = e . ConTwo;
            model . CP52 = textBox9 . Text;
            if ( e . ConTre . IndexOf ( "," ) > 0 )
                textBox11 . Text = string . Join ( "," ,e . ConTre . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox11 . Text = e . ConTre;
            model . CP53 = textBox11 . Text;
            if ( e . ConFor . IndexOf ( "," ) > 0 )
                textBox10 . Text = string . Join ( "," ,e . ConFor . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox10 . Text = e . ConFor;
            model . CP51 = textBox10 . Text;

            model . CP54 = 0;
            if ( !string . IsNullOrEmpty ( e . ConFiv ) )
                model . CP54 = Convert . ToInt64 ( e . ConFiv );
            else
                model . CP54 = 0;
            textBox13 . Text = e . ConFiv;
        }
        R_FrmPQP pqp = new R_FrmPQP( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            DataTable wl = dao . GetDataTablePqp ( );
            if ( wl . Rows . Count < 1 )
                MessageBox . Show ( "[产品每套成本改善控制表(R_509)]没有已经执行的信息,请录入或送审操作" );
            else
            {
                wl . Columns . Add ( "check" ,Type . GetType ( "System.Boolean" ) );
                pqp . gridControl1 . DataSource = wl;
                pqp . pqstr = "3";
                pqp . Text = "R_195 信息查询";
                pqp . PassDataBetweenForm += new R_FrmPQP . PassDataBetweenFormHandler ( pqp_PassDataBetweenForm );
                pqp . StartPosition = FormStartPosition . CenterScreen;
                pqp . ShowDialog ( );
            }
        }
        private void pqp_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model . CP06 = e . ConOne;
            lookUpEdit3 . Text = e . ConOne;
            model . CP07 = e . ConTwo;
            textBox14 . Text = e . ConTwo;
            comboBox14 . Text = e . ConTre;
            model . CP08 = e . ConFor;
        }
        private void button13_Click ( object sender ,EventArgs e )
        {
            R_FrmTPADGA tpadga = new R_FrmTPADGA ( );
            DataTable did = dao . GetDataTableOfSupplier ( );
            tpadga . gridControl2 . DataSource = did;
            tpadga . st = "2";
            tpadga . Text = "R_195 供应商查询";
            tpadga . PassDataBetweenForm += new R_FrmTPADGA . PassDataBetweenFomrHandler ( tpadga_PassDataBetweenForm );
            tpadga . StartPosition = FormStartPosition . CenterScreen;
            tpadga . ShowDialog ( );
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model . CP59 = e . ConOne;
            textBox4 . Tag = e . ConOne;
            textBox4 . Tag = e . ConOne . ToString ( );
            textBox4 . Text = e . ConTwo;
            textBox5 . Text = e . ConSev;
            textBox6 . Text = e . ConTre;
            textBox8 . Text = e . ConFor;
            textBox12 . Text = e . ConFiv;
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

            textBox3 . Enabled = false;
            label45 . Visible = false;
            label46 . Visible = false;
            dateTimePicker2 . Enabled = dateTimePicker3 . Enabled = dateTimePicker4 . Enabled = dateTimePicker5 . Enabled = dateTimePicker6 . Enabled = dateTimePicker7 . Enabled = false;

            sav = "1";

            model . CP03 = oddNumbers . purchaseContract ( "SELECT MAX(AJ009) AJ009 FROM R_PQAJ" ,"AJ009" ,"R_195-" );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
        }
        void dele ( )
        {
            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableFalse ( pageList );

            Ergodic . FormEvery ( this );
            gridControl1 . DataSource = null;
            toolSelect . Enabled = toolAdd . Enabled = true;
            toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;

            label45 . Visible = false;
            label46 . Visible = false;
            textBox3 . Enabled = false;

            weihu = "";
            copy = "";
            sav = "";

            try
            {
                dao . DeleteReview ( model . CP03 ,"R_195" );
            }
            catch { }
        }
        protected override void delete ( )
        {
            base . delete ( );

            stateOfOdd = "";
            if ( label45 . Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            if ( label45 . Visible == true )
            {
                if ( Logins . number == "MLL-0001" )
                {
                    WriteOfReceivablesTo ( "-" );
                    result = false;
                    result = dao . DeleteOddNum ( model . CP03 ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
                    if ( result == true )
                    {
                        MessageBox . Show ( "成功删除数据" );
                        dele ( );
                    }
                    else
                        MessageBox . Show ( "删除数据失败" );
                }
                else
                    MessageBox . Show ( "单号:" + model . CP03 + "的单据状态为执行,需要总经理删除" );
            }
            else
            {
                result = false;
                result = dao . DeleteOddNum ( model . CP03 ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
                if ( result == true )
                {
                    MessageBox . Show ( "成功删除数据" );
                    dele ( );
                }
                else
                    MessageBox . Show ( "删除数据失败" );
            }
        }
        protected override void update ( )
        {
            base . update ( );

            if ( label45 . Visible == true )
                MessageBox . Show ( "单号:" + model . CP03 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic . SpliEnableTrue ( spList );
                Ergodic . TablePageEnableTrue ( pageList );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
                textBox3 . Enabled = false;
                dateTimePicker2 . Enabled = dateTimePicker3 . Enabled = dateTimePicker4 . Enabled = dateTimePicker5 . Enabled = dateTimePicker6 . Enabled = dateTimePicker7 . Enabled = false;
            }
        }
        protected override void revirw ( )
        {
            base . revirw ( );
            
            bool over = false;
            if ( !string . IsNullOrEmpty ( textBox26 . Text ) )
                over = true;
            else
                over = false;

            Reviews ( "CP03" ,model . CP03 ,"R_PQQ" ,this ,"" ,"R_195" ,false ,over ,null/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            over = false;
            over = sp . reviewImple ( "R_195" ,model . CP03 );
            if ( over == true )
            {
                label45 . Visible = true;
                try
                {
                    SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQQC" ,"R_PQQ" ,"CP03" ,model . CP03 ) );
                    WriteOfReceivablesTo ( "+" );
                }
                catch { }
            }
            else
                label45 . Visible = false;
        }
        void WriteOfReceivablesTo (string oper )
        {
            DataTable receiva;
            MulaolaoLibrary . ProductCostSummaryLibrary modelAm = new MulaolaoLibrary . ProductCostSummaryLibrary ( );
            receiva = dao . receivableOf ( model . CP03 );
            if ( receiva != null && receiva . Rows . Count > 0 )
            {
                modelAm . AM002 = receiva . Rows [ 0 ] [ "CP01" ] . ToString ( );

                modelAm . AM108 = modelAm . AM111 = modelAm . AM110 = modelAm . AM115 = 0;
                modelAm . AM108 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(CP)" ,"CP56='F' AND CP58='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(CP)" ,"CP56='F' AND CP58='F'" ) . ToString ( ) );
                modelAm . AM110 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(CP)" ,"CP56='T' AND CP58='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(CP)" ,"CP56='T' AND CP58='F'" ) . ToString ( ) );
                modelAm . AM111 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(CP)" ,"CP56='F' AND CP58='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(CP)" ,"CP56='F' AND CP58='T'" ) . ToString ( ) );
                modelAm . AM115 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(CP)" ,"CP56='T' AND CP58='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(CP)" ,"CP56='T' AND CP58='T'" ) . ToString ( ) );

                dao . UpdateOfOutSource ( modelAm ,oper );
            }
            else
            {
                receiva = dao . receivableOfOther ( model . CP03 );
                if ( receiva != null && receiva . Rows . Count > 0 )
                {
                    modelAm . AM070 = modelAm . AM072 = modelAm . AM074 = modelAm . AM076 = modelAm . AM078 = modelAm . AM080 = modelAm . AM082 = modelAm . AM084 = modelAm . AM086 = modelAm . AM088 = modelAm . AM090 = modelAm . AM092 = 0;
                    modelAm . AM002 = receiva . Rows [ 0 ] [ "CP01" ] . ToString ( );
                    modelAm . AM070 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '雕刻'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '雕刻'" ) );
                    modelAm . AM072 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '绕锯'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '绕锯'" ) );
                    modelAm . AM074 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '夹料'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '夹料'" ) );
                    modelAm . AM076 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '擦砂皮'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '擦砂皮'" ) );
                    modelAm . AM078 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '丝印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '丝印'" ) );
                    modelAm . AM080 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '走台印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '走台印'" ) );
                    modelAm . AM082 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '移印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '移印'" ) );
                    modelAm . AM084 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '热转印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '热转印'" ) );
                    modelAm . AM086 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '烫印'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '烫印'" ) );
                    modelAm . AM088 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '喷漆'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '喷漆'" ) );
                    modelAm . AM090 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '冲压'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '冲压'" ) );
                    modelAm . AM092 = string . IsNullOrEmpty ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '手工剪切、其它'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(CP)" ,"CP01='" + modelAm . AM002 + "' and CP09= '手工剪切、其它'" ) );
                    dao . UpdateOfOther ( modelAm ,oper );
                }
            }
        }
        protected override void print ( )
        {
            base . print ( );


            if ( label45 . Visible == true )
            {
                MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQQ" ,"CP60" ,model . CP03 ,"CP03" );

                CreateDateSet ( );
                file = "";
                file = /*Environment.CurrentDirectory;*/System . Windows . Forms . Application . StartupPath;
                report . Load ( file + "\\R_195.frx" );
                report . RegisterData ( RDataSet );
                report . Show ( );
            }
            else
                MessageBox . Show ( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base . export ( );
            //if ( label45.Visible == true )
            //{
            CreateDateSet ( );
            file = "";
            file = System . Windows . Forms . Application . StartupPath;
            report . Load ( file + "\\R_195.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );
            //}else
            //    MessageBox.Show( "非执行单据不能导出" );
        }
        void variable_All ( )
        {
            model . CP01 = textBox1 . Text;
            model . CP02 = lookUpEdit1 . EditValue . ToString ( );
            model . CP04 = textBox2 . Text;
            model . CP05 = comboBox5 . Text;
            model . CP15 = checkBox1 . Checked == true ? "T" : "F";
            model . CP16 = checkBox2 . Checked == true ? "T" : "F";
            model . CP17 = checkBox3 . Checked == true ? "T" : "F";
            if ( checkBox4 . Checked )
            {
                model . CP18 = "T";
                model . CP19 = string . IsNullOrEmpty ( textBox20 . Text ) == true ? 0 : Convert . ToInt32 ( textBox20 . Text );
            }
            else
            {
                model . CP18 = "F";
                model . CP19 = 0;
            }
            model . CP20 = checkBox5 . Checked == true ? "T" : "F";
            model . CP21 = checkBox6 . Checked == true ? "T" : "F";
            model . CP22 = checkBox7 . Checked == true ? "T" : "F";
            model . CP23 = checkBox8 . Checked == true ? "T" : "F";
            model . CP24 = checkBox9 . Checked == true ? "T" : "F";
            model . CP25 = checkBox10 . Checked == true ? "T" : "F";
            model . CP26 = checkBox11 . Checked == true ? "T" : "F";
            model . CP27 = checkBox12 . Checked == true ? "T" : "F";
            model . CP28 = checkBox13 . Checked == true ? "T" : "F";
            model . CP29 = checkBox14 . Checked == true ? "T" : "F";
            model . CP30 = checkBox15 . Checked == true ? "T" : "F";
            model . CP31 = checkBox16 . Checked == true ? "T" : "F";
            model . CP32 = textBox23 . Text;
            model . CP33 = dateTimePicker2 . Value;
            model . CP34 = textBox26 . Text;
            model . CP35 = dateTimePicker3 . Value;
            model . CP36 = textBox28 . Text;
            model . CP37 = dateTimePicker4 . Value;
            model . CP38 = textBox30 . Text;
            model . CP39 = dateTimePicker5 . Value;
            model . CP40 = textBox32 . Text;
            model . CP41 = dateTimePicker6 . Value;
            model . CP42 = textBox34 . Text;
            model . CP43 = dateTimePicker7 . Value;
            model . CP44 = textBox4 . Text;
            model . CP45 = textBox5 . Text;
            model . CP46 = textBox6 . Text;
            model . CP47 = textBox8 . Text;
            model . CP48 = textBox12 . Text;
            model . CP49 = textBox3 . Text;
            model . CP51 = textBox10 . Text;
            model . CP52 = textBox9 . Text;
            model . CP53 = textBox11 . Text;
            model . CP54 = string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToInt64 ( textBox13 . Text );
            model . CP55 = "";
            model . CP56 = checkBox17 . Checked == true ? "T" : "F";
            model . CP57 = lookUpEdit2 . Text;
            model . CP58 = checkBox18 . Checked == true ? "T" : "F";
            model . CP59 = textBox4 . Tag . ToString ( );
        }
        void saves ( )
        {
            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableFalse ( pageList );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            copy = "";
            weihu = "";
            label46 . Visible = false;
            textBox3 . Enabled = false;
        }
        void cop ( )
        {
            result = false;
            result = dao . UpdateOther ( model ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "录入数据失败" );
            else
            {
                MessageBox . Show ( "成功录入数据" );

                saves ( );
            }
        }
        protected override void save ( )
        {
            base . save ( );

            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }

            if ( string . IsNullOrEmpty ( textBox4 . Text ) )
            {
                MessageBox . Show ( "乙方名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox2 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }

            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择联系人" );
                return;
            }
            variable_All ( );
            if ( string . IsNullOrEmpty ( model . CP59 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return ;
            }
            DataTable der = dao . GetDataTableAll ( model . CP03 );
            if ( weihu == "1" )
            {
                if ( string . IsNullOrEmpty ( textBox3 . Text ) )
                    MessageBox . Show ( "维护意见不可为空" );
                else
                {
                    if ( der . Rows . Count < 1 )
                        MessageBox . Show ( "单号: " + model . CP03 + "的记录不存在, 请核实后再维护" );
                    else
                    {
                        stateOfOdd = "维护保存";
                        model . CP50 = der . Rows [ 0 ] [ "CP50" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";

                        cop ( );
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQQC" ,"R_PQQ" ,"CP03" ,model . CP03 ) );
                            //WriteOfReceivablesTo ( "+" );
                        }
                        catch { }
                    }
                }
            }
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                model . CP50 = "";
                if ( der . Rows . Count > 0 )
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model . CP59 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";
                        DataTable dl = dao . GetDataTableCopy ( model . CP03 );
                        if ( dl . Rows . Count < 1 )
                            cop ( );
                        else
                        {
                            int proNum = 0;
                            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "CP54" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "CP54" ] );
                                if ( proNum != model . CP54 )
                                {
                                    MessageBox . Show ( "产品数量和产品总套数不一致,请核实" );
                                    break;
                                }
                                if ( dl . Select ( "CP01='" + model . CP01 + "' AND CP06='" + gridView1 . GetDataRow ( i ) [ "CP06" ] . ToString ( ) + "' AND CP07='" + gridView1 . GetDataRow ( i ) [ "CP07" ] . ToString ( ) + "' AND CP09='" + gridView1 . GetDataRow ( i ) [ "CP09" ] . ToString ( ) + "'" ) . Length > 0 )
                                {
                                    if ( model . CP04 . Length > 8 && model . CP04 . Substring ( 0 ,8 ) == "MLL-0001" )
                                    {
                                        cop ( );
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox . Show ( "此单为超补,需要总经理处理" );
                                        break;
                                    }
                                }
                                else if ( i == gridView1 . RowCount - 1 )
                                {
                                    cop ( );
                                    break;
                                }
                            }
                        }
                    }
                    else
                        cop ( );
                }
                else
                    saves ( );
            }
        }
        protected override void cancel( )
        {
            base.cancel( );

            if (sav == "1" && weihu!="1")
            {
                try
                {
                    dao.DeleteOddNum( model.CP03 ,"R_195" ,"" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch
                { }
                finally
                {
                    Ergodic.SpliClear( spList );
                    Ergodic.TablePageEnableClear( pageList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    toolSelect.Enabled = toolAdd.Enabled =  true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled =toolcopy.Enabled= toolPrint.Enabled = toolExport.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                    label46.Visible = false;
                    label45.Visible = false;
                    weihu = "";
                    copy = "";
                    sav = "";
                    textBox3.Enabled = false;
                }
            }
            else if (sav == "2" || weihu =="1")
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled =toolcopy.Enabled=toolMaintain.Enabled=toolLibrary.Enabled=toolStorage.Enabled= true;
                toolSave.Enabled = toolCancel.Enabled = false;
                textBox3.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void maintain( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                textBox3.Enabled = true;
                dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker4.Enabled = dateTimePicker5.Enabled = dateTimePicker6.Enabled = dateTimePicker7.Enabled = false;

                weihu = "1";
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void copys ( )
        {
            base.copys( );

            if ( label45.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sav .Equals( "1") )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = dao.UpdateCopy( model.CP03 ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result==false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                model.CP03 = oddNumbers.purchaseContract( "SELECT MAX(AJ009) AJ009 FROM R_PQAJ" ,"AJ009" ,"R_195-" );
                result = dao.UpdateCopyUp( model.CP03 ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,"复制更改单号" );
                if ( result==false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    dao.DeleteCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolcopy.Enabled =toolLibrary.Enabled=toolStorage.Enabled= false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox3.Enabled = false;
                    sav = "1";
                    copy = "1";
                    weihu = "";
                    label45.Visible = false;
                    label46.Visible = true;
                    queryContent( );
                }
            }
        }
        #endregion

        #region Event 
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            model.CP01 = textBox1.Text;
           
            table( );
            getWorkProce ( );
        }
        void table ()
        {
            desx = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 CP06,GS08 CP07,GS09 CP08,GS10 CP13 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS34=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS07!='' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,model . CP01 ) );

            dl = SqlHelper . ExecuteDataTable ( "SELECT CP06,CP07,CP08,CP13,CP10,CP11,CP12,CP09 FROM R_PQQ WHERE CP01=@CP01" ,new SqlParameter ( "@CP01" ,model . CP01 ) );
            if ( desx != null )
                dl . Merge ( desx );
            //内价不含税
            comboBox1 .DataSource = dl.DefaultView.ToTable( true ,"CP10" );
            comboBox1.DisplayMember = "CP10";
            //外价含税
            comboBox2.DataSource = dl.DefaultView.ToTable( true ,"CP11" );
            comboBox2.DisplayMember = "CP11";
            //预付款
            comboBox6.DataSource = dl.DefaultView.ToTable( true ,"CP12" );
            comboBox6.DisplayMember = "CP12";
            //工序名称
            comboBox3.DataSource = dl.DefaultView.ToTable( true ,"CP09" );
            comboBox3.DisplayMember = "CP09";
            lookUpEdit3.Properties.DataSource = dl.DefaultView.ToTable( true ,"CP06","CP07" );
            lookUpEdit3 . Properties . DisplayMember = "CP06";
            lookUpEdit3 . Properties . ValueMember = "CP06";
            //textBox14 .DataSource = dl.DefaultView.ToTable( true ,"CP07" );
            //textBox14.DisplayMember = "CP07";
            comboBox15.DataSource = dl.DefaultView.ToTable( true ,"CP08" );
            comboBox15.DisplayMember = "CP08";
            comboBox14.DataSource = dl.DefaultView.ToTable( true ,"CP13" );
            comboBox14.DisplayMember = "CP13";
        }
        void getWorkProce ( )
        {
            //获取合同编号是195的工序名称
            DataTable tableWorkProce = dao . getTableWorkProce ( model . CP01 );
            comboBox3 . DataSource = tableWorkProce;
            comboBox3 . DisplayMember = "GS35";
        }
        private void comboBox7_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) && dl.Select( "CP06='" + lookUpEdit3.Text + "'" ).Length > 0 )
            {
                textBox14.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP07"].ToString( );
                comboBox15.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP08"].ToString( );
                comboBox14.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP13"].ToString( );
                comboBox1.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP10"].ToString( );
                comboBox2.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP11"].ToString( );
                comboBox6.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP12"].ToString( );
                comboBox3.Text = dl.Select( "CP06='" + lookUpEdit3.Text + "'" )[0]["CP09"].ToString( );
            }
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit3 . EditValue == null )
                textBox14 . Text = string . Empty;
            else
                textBox14 . Text = dl . Select ( "CP06='" + lookUpEdit3 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "CP07" ] . ToString ( );
        }
        //Table
        string wp = "", ge = "", gx = "";
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    model.IDX = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    tableAssign( );
                }
            }
        }
        void tableAssign ( )
        {
            model = dao . GetModel ( model . IDX );
            if ( model == null )
                return;
            textBox14 . Text = model . CP07;
            comboBox3 . Text = model . CP09;
            comboBox15 . Text = model . CP08;
            comboBox1 . Text = model . CP10 . ToString ( );
            comboBox2 . Text = model . CP11 . ToString ( );
            comboBox6 . Text = model . CP12 . ToString ( );
            comboBox14 . Text = model . CP13 . ToString ( );
            //if ( model.CP14.ToString( ) != "0001/1/1 0:00:00" && model.CP14.ToString( ) != "0001-1-1 0:00:00" && model.CP14.ToString( ) != "0001.1.1 0:00:00" )
            if ( model . CP14 > DateTime . MinValue && model . CP14 < DateTime . MaxValue )
                dateTimePicker1 . Value = model . CP14;
            //textBox13.Text = model.CP54.ToString( );
            lookUpEdit3 . Text = model . CP06;
            wp = lookUpEdit3 . Text;
            ge = textBox14 . Text;
            gx = comboBox3 . Text;
        }
        //second party
        private void textBox4_SelectedValueChanged ( object sender ,EventArgs e )
        {
            //DataTable yf = SqlHelper.ExecuteDataTable( "SELECT DISTINCT CP44,CP45,CP46,CP47,CP48 FROM R_PQQ WHERE CP44=@CP44" ,new SqlParameter( "@CP44" ,textBox4.Text ) );

        }     
        //exclusive of tax
        private void comboBox1_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb(e ,comboBox1);
        }
        private void comboBox1_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb(comboBox1);
        }
        private void comboBox1_LostFocus( object sender, EventArgs e )
        {
            if (comboBox1.Text != "" && !DateDayRegise.eightFourNumber( comboBox1 ))
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多四位,如9999.9999,请重新输入" );
            }
        }
        //Tax
        private void comboBox2_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb(e ,comboBox2);
        }
        private void comboBox2_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb(comboBox2);
        }
        private void comboBox2_LostFocus( object sender, EventArgs e )
        {
            if (comboBox2.Text != "" && !DateDayRegise.eightFourNumber( comboBox2 ))
            {
                this.comboBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多四位,如9999.9999,请重新输入" );
            }
        }
        //advance charge
        private void comboBox6_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra(e);
        }
        //contacts
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                model.CP02 = lookUpEdit1.EditValue.ToString( );
                textBox7.Text = dia.Select( "DBA001='" + model.CP02 + "'" )[0]["DBA028"].ToString( );
            }
        }
        //form closing
        private void R_Frmchanpinzhibiao_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                cancel( );
            }
        }
        //close colleagus
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty(textBox1.Text ) )
                MessageBox.Show("流水号不可为空");
            else
            {
                if ( textBox23.Text == "" )
                {
                    textBox23.Text = Logins.username;
                    model.CP32 = textBox23.Text;

                    string[] str = new string[2];
                    str = oddNumbers.contractBatch( "R_PQQ" ,model.CP32 ,textBox23 ,textBox2 ,"CP04" );
                    if ( str[0] == "" )
                        textBox23.Text = "";
                    else
                        model.CP04 = str[1];
                    textBox2.Text = str[1];
                }
                else if ( textBox23.Text != "" && textBox23.Text == Logins.username )
                {
                    textBox23.Text = "";
                    model.CP32 = "";
                    model.CP04 = "";
                    textBox2.Text = "";
                }
                dateTimePicker2.Value = MulaolaoBll . Drity . GetDt ( );
            }
        }
        //cost edit
        private void button8_Click( object sender, EventArgs e )
        {
            if (textBox26.Text == "")
            {
                textBox26.Text = Logins.username;
            }
            else if (textBox26.Text != "" && textBox26.Text == Logins.username)
            {
                textBox26.Text = "";
            }
            dateTimePicker3.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //approved person
        private void button10_Click( object sender, EventArgs e )
        {
            if (textBox30.Text == "")
            {
                textBox30.Text = Logins.username;
            }
            else if (textBox30.Text != "" && textBox30.Text == Logins.username)
            {
                textBox30.Text = "";
            }
            dateTimePicker5.Value = MulaolaoBll . Drity . GetDt ( );
        }
        private void button7_Click( object sender, EventArgs e )
        {
            if (textBox34.Text == "")
            {
                textBox34.Text = Logins.username;
            }
            else if (textBox34.Text != "" && textBox34.Text == Logins.username)
            {
                textBox34.Text = "";
            }

            dateTimePicker7.Value = MulaolaoBll . Drity . GetDt ( );
        }
        private void button9_Click( object sender, EventArgs e )
        {
            if (textBox28.Text == "")
            {
                textBox28.Text = Logins.username;
            }
            else if (textBox28.Text != "" && textBox28.Text == Logins.username)
            {
                textBox28.Text = "";
            }
            dateTimePicker4.Value = MulaolaoBll . Drity . GetDt ( );
        }
        private void button11_Click( object sender, EventArgs e )
        {
            if (textBox32.Text == "")
            {
                textBox32.Text = Logins.username;
            }
            else if (textBox32.Text != "" && textBox32.Text == Logins.username)
            {
                textBox32.Text = "";
            }
            dateTimePicker6.Value = MulaolaoBll . Drity . GetDt ( );
        }
        #endregion

        #region Table
        //Build
        void variable ()
        {
            model.CP01 = textBox1.Text;
            model.CP06 = lookUpEdit3.Text;
            model.CP07 = textBox14.Text;
            model.CP09 = comboBox3.Text;
            model.CP08 = comboBox15.Text;
            model.CP10 = string.IsNullOrEmpty( comboBox1.Text ) == true ? 0 : Convert.ToDecimal( comboBox1.Text );
            model.CP11 = string.IsNullOrEmpty( comboBox2.Text ) == true ? 0 : Convert.ToDecimal( comboBox2.Text );
            model.CP12 = string.IsNullOrEmpty( comboBox6.Text ) == true ? 0 : Convert.ToInt64( comboBox6.Text );
            model.CP13 = string.IsNullOrEmpty( comboBox14.Text ) == true ? 0 : Convert.ToDecimal( comboBox14.Text );
            model.CP14 = dateTimePicker1.Value;
            model.CP54 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt64( textBox13.Text );
            if ( textBox4 . Tag != null )
                model . CP59 = textBox4 . Tag . ToString ( );
            //CP006 = lookUpEdit3.Text;
            //CP007 = textBox14.Text;
            //CP009 = comboBox3.Text;
            //CP8 = comboBox15.Text;
            //if ( comboBox1.Text == "" )
            //    CP010 = 0M;
            //else
            //    CP010 = Convert.ToDecimal(comboBox1.Text);
            //if ( comboBox2.Text == "" )
            //    CP011 = 0M;
            //else
            //    CP011 = Convert.ToDecimal(comboBox2.Text);
            //if ( comboBox6.Text == "" )
            //    CP012 = 0;
            //else
            //    CP012 = Convert.ToInt64(comboBox6.Text);
            //CP014 = dateTimePicker1.Value;
            //if ( comboBox14.Text == "" )
            //    CP013 = 0;
            //else
            //    CP013 = Convert.ToDecimal(comboBox14.Text);
            //CP056 = checkBox17.Checked == true ? "T" : "F";
            //if ( string.IsNullOrEmpty( textBox13.Text ) )
            //    CP054 = 0;
            //else
            //    CP054 = Convert.ToInt64( textBox13.Text );
        }
        private void button1_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "物品名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "工序名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox2 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            variable ( );
            if ( string . IsNullOrEmpty ( model . CP59 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
          
            stateOfOdd = "";
            if ( label45 . Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }

            result = false;
            result = dao . Exists ( model );
            if ( result == false )
            {
                result = dao . Add ( model , "R_195" , "产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" , Logins . username , DateTime . Now , "新建" , stateOfOdd );
                if ( result == true )
                {
                    MessageBox . Show ( "成功录入数据" );

                    table ( );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                    refre ( );
                }
                else
                    MessageBox . Show ( "录入数据失败" );
            }
            else
            {
                if ( Logins . number .Equals( "MLL-0001") )
                {
                    result = dao . Add ( model ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins . username ,DateTime . Now ,"新建" ,stateOfOdd );
                    if ( result == true )
                    {
                        MessageBox . Show ( "成功录入数据" );

                        table ( );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                        refre ( );
                    }
                    else
                        MessageBox . Show ( "录入数据失败" );
                }
                else
                    MessageBox . Show ( "此单为超补,需要总经理处理" );
            }
        }
        //Delete
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            stateOfOdd = "";
            if ( label45.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            //int num = gridView1 . FocusedRowHandle;
            result = dao.Delete( model.IDX ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.CP03 ,"删除" ,stateOfOdd );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                button12_Click ( null , null );
            }
            else
                MessageBox.Show( "删除数据失败" );
            //int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQQ WHERE idx=@idx" , /*new SqlParameter( "@CP03", CP03 ), new SqlParameter( "@CP06", CP006 ), new SqlParameter( "@CP07", CP007 ) */new SqlParameter( "@idx" ,id ) );
            //if ( count < 1 )
            //{
            //    MessageBox.Show( "删除数据失败" );
            //}
            //else
            //{
            //    MessageBox.Show( "删除数据成功" );

            //    table( );
            //    button12_Click( null ,null );
            //}
        }
        //Edit
        private void up ()
        {
            table( );
        }
        private void button3_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "物品名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "工序名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox2 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            variable ( );
            if ( string . IsNullOrEmpty ( model . CP59 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }

            stateOfOdd = "";
            if ( label45 . Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }

            if ( model . CP06 == wp && model . CP09 == gx )//&& model . CP07 == ge 
            {
                result = false;
                result = dao . Update ( model , "R_195" , "产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" , Logins . username , DateTime . Now , "编辑" , stateOfOdd );
                if ( result == true )
                {
                    MessageBox . Show ( "成功录入数据" );

                    up ( );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                    refre ( );
                }
                else
                    MessageBox . Show ( "录入数据失败" );
            }
            else
            {
                result = false;
                result = dao . Exists ( model );
                if ( result == true )
                {
                    if ( Logins . number . Equals ( "MLL-0001" ) )
                    {
                        result = false;
                        result = dao . Update ( model ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins . username ,DateTime . Now ,"编辑" ,stateOfOdd );
                        if ( result == true )
                        {
                            MessageBox . Show ( "成功录入数据" );

                            up ( );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                            refre ( );
                        }
                        else
                            MessageBox . Show ( "录入数据失败" );
                    }
                    else
                        MessageBox . Show ( "此单为补开,需要总经理处理" );
                }
                else
                {
                    result = false;
                    result = dao . Update ( model , "R_195" , "产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" , Logins . username , DateTime . Now , "编辑" , stateOfOdd );
                    if ( result == true )
                    {
                        MessageBox . Show ( "成功录入数据" );

                        up ( );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND CP03='" + model . CP03 + "'";
                        refre ( );
                    }
                    else
                        MessageBox . Show ( "录入数据失败" );
                }
            }
        }
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button6_Click_1 ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox13.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                stateOfOdd = "";
                if ( label45.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( sav == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }

                result = dao.UpdateBatch( model ,"R_195" ,"产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd );
                if ( result == true )
                {
                    MessageBox.Show( "成功录入数据" );

                    //up( );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND CP03='" + model.CP03 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.CP54 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //Refresh
        private void button12_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND CP03='" + model.CP03 + "'";
            refre( );
            model . CP01 = textBox1 . Text;
            table ( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            de = dao.GetDataTable( strWhere );
            gridControl1.DataSource = de;
            assignMent( );
        }
        void assignMent ( )
        {
            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP10"].ToString( ) ) && Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) != 0 )
                    {
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Math.Round( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) ,4 ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,Math.Round( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP54"].ToString( ) ) == true ? ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? 0 : -Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) : ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) == true ? ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? 0 : -Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) : ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) : Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) - Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) ) ,2 ) );
                    }
                    else
                    {
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Math.Round( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP11"].ToString( ) ) ,4 ) );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,Math.Round( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP54"].ToString( ) ) == true ? ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? 0 : -Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) : ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) == true ? ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? 0 : -Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) : ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP12"].ToString( ) ) == true ? Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP11"].ToString( ) ) : Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP11"].ToString( ) ) - Convert.ToDecimal( gridView1.GetDataRow( i )["CP12"].ToString( ) ) ) ) ,2 ) );
                    }
                }


                U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( gridView1.Columns["U4"].SummaryItem.SummaryValue ) / Convert.ToDecimal( gridView1.GetDataRow( 0 )["CP54"] ) ,4 ).ToString( ) );
            }
        }
        #endregion

    }
}
