using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;
using System . Collections . Generic;
using FastReport;
using FastReport . Export . Xml;
using System . ComponentModel;
using Mulaolao . Other;

namespace Mulaolao . Raw_material_cost
{
    public partial class R_Frmgongxugongzi :FormChild
    {
        public R_Frmgongxugongzi (/*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoLibrary.GongXuGongZiLibrary model = new MulaolaoLibrary.GongXuGongZiLibrary( );
        MulaolaoBll.Bll.GongXuGongZiBll bll = new MulaolaoBll.Bll.GongXuGongZiBll( );
        bool result = false;
        string strWhere = "1=1", weihu = "", sav = "", numCount = "", stateOfOdd = "";
        DateTime dt;
        DataTable partTable, gx;

        gongxugongzi gz = new gongxugongzi( );
        DataTable tableQuery,printOne,printTwo;

        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        List<DataRow> rows=new List<DataRow>();
        Report report = new Report( );
        DataSet RDataSet;

        private void R_Frmgongxugongzi_Load ( object sender ,EventArgs e )
        {
            Power ( this );

            spList . Clear ( );
            spList . Add ( splitContainer1 );
            Ergodic . SpliClear ( spList );
            Ergodic . SpliEnableFalse ( spList );
            gridControl1 . DataSource = null;
            pageList . AddRange ( new TabPage [ ] { tabPageOne ,tabPageTwo ,tabPageTre } );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableFalse ( pageList );

            label107 . Visible = label44 . Visible = false;

            lookUpEdit4 . Properties . ShowHeader = false;

            readColumn ( );
            //lookUpEdit1.Properties.ValueMember = "GX03";
        }

        private void R_Frmgongxugongzi_Shown ( object sender ,EventArgs e )
        {
            model . DS21 = Merges . oddNum;
            if ( model . DS21 != null && model . DS21 != "" )
                assignMentQuery ( );
            Merges . oddNum = "";
        }

        #region  Query
        string chx = "";
        SelectAll.GongXuGongZiAll query = new SelectAll.GongXuGongZiAll( );
        void assignMentQuery ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            strWhere = "1=1";
            strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
            refresh ( );

            if ( tableQuery . Rows . Count > 0 )
            {
                model . Idx = string . IsNullOrEmpty ( tableQuery . Rows [ 0 ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQuery . Rows [ 0 ] [ "idx" ] . ToString ( ) );
                assignMent ( );
            }

            //limit( );
        }
        void limit ( )
        {
            //如果生产部门和操作人是不会自己   复制之后就不能操作
            DataTable da = bll . GetDataTableLimit ( Logins . username ,textBox4 . Text );
            if ( da == null || da . Rows . Count < 1 )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolcopy . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = false;
            }
        }
        protected override void select ( )
        {
            base . select ( );

            chx = "4";
            query . StartPosition = FormStartPosition . CenterScreen;
            query . PassDataBetweenForm += new SelectAll . GongXuGongZiAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            query . ShowDialog ( );

            if ( string . IsNullOrEmpty ( model . DS21 ) )
                MessageBox . Show ( "您没有选择任何内容" );
            else
            {
                Ergodic . FormEverySpliEnableFalse ( this );



                sav = "2";

                assignMentQuery ( );
            }
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( chx == "1" )
            {
                //if ( e.ConOne.IndexOf( "," ) > 0 )
                //    textBox1.Text = string.Join( "," ,e.ConOne.Split( ',' ).Distinct( ).ToArray( ) );
                //else
                textBox1 . Text = e . ConTre;
                model . DS22 = e . ConTre;
                //if ( e.ConTwo.IndexOf( "," ) > 0 )
                //    textBox18.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
                //else
                textBox18 . Text = e . ConOne;
                model . DS01 = e . ConOne;
                //if ( e.ConTre.IndexOf( "," ) > 0 )
                //    textBox2.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
                //else
                textBox2 . Text = e . ConTwo;
                model . DS24 = e . ConTwo;
                textBox3 . Text = e . ConFor;
                if ( string . IsNullOrEmpty ( e . ConFor ) )
                    model . DS25 = 0;
                else
                    model . DS25 = Convert . ToInt64 ( e . ConFor );
                //if ( e.ConFiv.IndexOf( "," ) > 0 )
                //    textBox4.Text = string.Join( "," ,e.ConFiv.Split( ',' ).Distinct( ).ToArray( ) );
                //else
                textBox4 . Text = e . ConFiv;
                model . DS26 = e . ConFiv;
                //if ( e.ConSix.IndexOf( "," ) > 0 )
                //{
                //    string[] str = e.ConSix.Split( ',' );
                //    dateTimePicker1.Value = Convert.ToDateTime( str[0] );
                //}
                //else if ( !string.IsNullOrEmpty( e.ConSix ) )
                //    dateTimePicker1.Value = Convert.ToDateTime( e.ConSix );
                if ( string . IsNullOrEmpty ( e . ConSix ) )
                    dateTimePicker1 . Value = MulaolaoBll . Drity . GetDt ( );
                else
                    dateTimePicker1 . Value = Convert . ToDateTime ( e . ConSix );
                model . DS27 = dateTimePicker1 . Value;
            }
            else if ( chx == "2" )
            {
                model . DS02 = e . ConOne;
                textBox10 . Text = e . ConOne;
                textBox7 . Text = e . ConTwo;
                if ( e . ConTwo != "" )
                {
                    model . DS18 = Convert . ToDecimal ( e . ConTwo );
                }
            }
            else if ( chx == "4" )
            {
                textBox18 . Text = e . ConFor;
                model . DS21 = e . ConOne;
                model . DS24 = e . ConTwo;
                textBox2 . Text = e . ConTwo;
                if ( e . ConTre == "执行" )
                    label107 . Visible = true;
                else
                    label107 . Visible = false;
            }
        }
        //num query
        private void button4_Click ( object sender ,EventArgs e )
        {
            SelectAll . GongXuGongZiNumAll queryNum = new SelectAll . GongXuGongZiNumAll ( );
            queryNum . StartPosition = FormStartPosition . CenterScreen;
            chx = "1";
            queryNum . PassDataBetweenForm += new SelectAll . GongXuGongZiNumAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            queryNum . ShowDialog ( );
            //DataTable lius = bll.GetDataTableNum( );
            //if (lius.Rows.Count < 1)
            //    MessageBox.Show( "没有产品信息" );
            //else
            //{
            //    lius.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
            //    gz.gridControl1.DataSource = lius;
            //    gz.gonxu = "2";
            //    chx = "1";
            //    gz.Text = "R_436 信息查询";
            //    gz.PassDataBetweenForm += new gongxugongzi.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            //    gz.StartPosition = FormStartPosition.CenterScreen;
            //    gz.ShowDialog( );
            //}
        }
        //gongduan query
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable gond = bll . GetDataTableWorkShop ( model . DS24 );
            if ( gond . Rows . Count < 1 )
                MessageBox . Show ( "产品每套成本改善控制表(R_509)表中没有材质工段等信息" );
            else
            {
                gz . gridControl1 . DataSource = gond;
                gz . gonxu = "3";
                chx = "2";
                gz . Text = "R_436 信息查询";
                gz . PassDataBetweenForm += new gongxugongzi . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
                gz . StartPosition = FormStartPosition . CenterScreen;
                gz . ShowDialog ( );
            }
        }
        //dingrichangliang query
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
                MessageBox . Show ( "请选择零件名称" );
            else
            {
                if ( !string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
                {
                    model . DS03 = textBox5 . Text;
                    model . DS01 = textBox18 . Text;
                    model . DS04 = lookUpEdit1 . Text;
                    DataTable dinri = bll . GetDataTableDing ( model . DS03 ,model . DS01 ,model . DS04 );
                    if ( dinri . Rows . Count < 1 )
                        MessageBox . Show ( "产品工资考勤表(R_317)没有实日产量等信息" );
                    else
                    {
                        gz . gridControl1 . DataSource = dinri;
                        gz . gonxu = "4";
                        chx = "3";
                        gz . Text = "R_436 信息查询";
                        gz . PassDataBetweenForm += new gongxugongzi . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
                        gz . StartPosition = FormStartPosition . CenterScreen;
                        gz . ShowDialog ( );
                    }
                }
            }
        }
        #endregion

        #region Event
        string ds3 = "", ds4 = "";
        //表
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( bandedGridView1 . FocusedRowHandle >= 0 && bandedGridView1 . FocusedRowHandle <= bandedGridView1 . RowCount - 1 )
            {
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "idx" ) . ToString ( ) ) )
                {
                    model . Idx = Convert . ToInt32 ( bandedGridView1 . GetFocusedRowCellValue ( "idx" ) . ToString ( ) );
                    assignMent ( );
                }
            }
        }
        void assignMent ( )
        {
            model = bll . GetModel ( model . Idx );
            textBox18 . Text = model . DS01;
            textBox10 . Text = model . DS02;
            textBox5 . Text = model . DS29 . ToString ( );
            //gridLookUpEdit1 . Text = model . DS03;
            textBox6 . Text = model . DS03;
            textBox15 . Text = model . DS06 . ToString ( );
            textBox9 . Text = model . DS09;
            lookUpEdit4 . Text = model . DS10;
            textBox12 . Text = model . DS11;
            dateTimePicker2 . Value = string . IsNullOrEmpty ( model . DS12 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert . ToDateTime ( model . DS12 );
            textBox13 . Text = model . DS13;
            dateTimePicker3 . Value = string . IsNullOrEmpty ( model . DS14 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert . ToDateTime ( model . DS14 );
            textBox7 . Text = model . DS18 . ToString ( );
            textBox14 . Text = model . DS19;
            textBox1 . Text = model . DS22;
            textBox2 . Text = model . DS24;
            textBox3 . Text = model . DS25 . ToString ( );
            textBox4 . Text = model . DS26;
            dateTimePicker1 . Value = string . IsNullOrEmpty ( model . DS27 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . DS27;
            lookUpEdit1 . Text = model . DS04;
            textBox11 . Text = model . DS05 . ToString ( );

            ds3 = model . DS03;
            ds4 = model . DS04;
        }
        //定日工资额
        private void textBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        //定日产量
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        //窗体
        private void R_Frmgongxugongzi_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave . Enabled )
            {
                cancel ( );
            }
        }
        //填表人签字
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox12 . Text == "" )
            {
                textBox12 . Text = Logins . username;
            }
            else if ( textBox12 . Text != "" && textBox12 . Text == Logins . username )
            {
                textBox12 . Text = "";
            }
        }
        //审批人签字
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox13 . Text == "" )
            {
                textBox13 . Text = Logins . username;
            }
            else if ( textBox13 . Text != "" && textBox13 . Text == Logins . username )
            {
                textBox13 . Text = "";
            }
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            textBox8 . Text = Math . Round ( Convert . ToDecimal ( Operation . DivisionTc ( textBox11 ,textBox15 ) ) ,4 ) . ToString ( );
        }
        private void textBox11_TextChanged ( object sender ,EventArgs e )
        {
            textBox8 . Text = Math . Round ( Convert . ToDecimal ( Operation . DivisionTc ( textBox11 ,textBox15 ) ) ,4 ) . ToString ( );
        }
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            model . DS01 = textBox18 . Text;
            //零件名称==》509
            partTable = bll . GetDataTableWorkShops ( model . DS01 );
            gridLookUpEdit1 . Properties . DataSource = partTable;
            gridLookUpEdit1 . Properties . DisplayMember = "GZ03";
            gridLookUpEdit1 . Properties . ValueMember = "GZ03";
        }
        private void btnPart_Click ( object sender ,EventArgs e )
        {
            FormGonXuGonXi from = new FormGonXuGonXi ( partTable );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                rows = from . getRows;
                textBox6 . Text = textBox5 . Text = string . Empty;
                foreach ( DataRow row in rows )
                {
                    textBox6 . Text = textBox6 . Text + " " + row [ "GZ03" ] . ToString ( );
                    textBox5 . Text = textBox5 . Text + " " + row [ "GS10" ] . ToString ( );
                }
            }
        }
        private void gridLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View1 . GetFocusedDataRow ( );
            if ( row == null )
                return;

            //if ( gridLookUpEdit1 . EditValue == null || string . IsNullOrEmpty ( gridLookUpEdit1 . EditValue . ToString ( ) ) )
            //    return;
            //if ( gridLookUpEdit1 . EditValue != null && partTable . Select ( "idx='" + gridLookUpEdit1 . EditValue . ToString ( ) + "'" ) . Length > 0 )
            //    textBox5 . Text = partTable . Select ( "idx='" + gridLookUpEdit1 . EditValue . ToString ( ) + "'" ) [ 0 ] [ "GS10" ] . ToString ( );
            textBox5 . Text = row [ "GS10" ] . ToString ( );
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( gx != null && lookUpEdit1 . Text != "" && gx . Select ( "GX02='" + lookUpEdit1 . Text + "'" ) . Length > 0 )
                textBox11 . Text = gx . Select ( "GX02='" + lookUpEdit1 . Text + "'" ) [ 0 ] [ "GX03" ] . ToString ( );
        }
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( toolSave . Enabled == true )
            {
                cancel ( );
            }

            base . OnClosing ( e );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base . add ( );

            Ergodic . SpliClear ( spList );
            gridControl1 . DataSource = null;
            Ergodic . SpliEnableTrue ( spList );
            Ergodic . TablePageEnableClear ( pageList );
            Ergodic . TablePageEnableTrue ( pageList );

            sav = "1";
            dateTimePicker1 . Enabled = false;
            label107 . Visible = label44 . Visible = false;

            model . DS21 = oddNumbers . purchaseContract ( "SELECT MAX(AJ014) AJ014 FROM R_PQAJ" ,"AJ014" ,"R_436-" );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            textBox12 . Text = Logins . username;
        }
        protected override void delete ( )
        {
            base . delete ( );

            if ( MessageBox . Show ( "确认删除?" ,"确认" ,MessageBoxButtons . OKCancel ,MessageBoxIcon . Question ) == DialogResult . OK )
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else if ( sav == "2" )
                    stateOfOdd = "更改删除";
                else if ( sav == "3" )
                    stateOfOdd = "复制删除";
                result = bll . ExistsReview ( model . DS21 ,this . Text );

                if ( result == true )
                    MessageBox . Show ( "单号:" + model . DS21 + "的单据状态为执行,不允许删除" );
                else
                {
                    result = false;
                    result = bll . DeleteOddNum ( model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
                    if ( result == false )
                        MessageBox . Show ( "删除数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功删除数据" );
                        Ergodic . SpliClear ( spList );
                        gridControl1 . DataSource = null;
                        Ergodic . SpliEnableFalse ( spList );
                        Ergodic . TablePageEnableClear ( pageList );
                        Ergodic . TablePageEnableFalse ( pageList );
                        label44 . Visible = label107 . Visible = false;
                        toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                        toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = false;
                    }
                }
            }
        }
        protected override void update ( )
        {
            base . update ( );

            result = false;
            result = bll . ExistsReview ( model . DS21 ,this . Text );
            if ( result == true )
                MessageBox . Show ( "单号:" + model . DS21 + "的单据状态为执行,不允许更改" );
            else
            {
                sav = "2";
                Ergodic . SpliEnableTrue ( spList );
                Ergodic . TablePageEnableTrue ( pageList );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
                toolPrint . Enabled = toolExport . Enabled = toolSave . Enabled = toolCancel . Enabled = true;

                label107 . Visible = false;
            }
        }
        protected override void revirw ( )
        {
            base . revirw ( );

            Reviews ( "DS21" ,model . DS21 ,"R_PQR" ,this ,"" ,"R_436" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) /*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_436"*/ );
        }
        void adds ( )
        {
            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableFalse ( pageList );
            weihu = sav = "";
            label44 . Visible = false;
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
        }
        protected override void save ( )
        {
            base . save ( );

            if ( string . IsNullOrEmpty ( textBox18 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox12 . Text ) )
            {
                MessageBox . Show ( "填表人不可为空" );
                return;
            }
            model . DS10 = lookUpEdit4 . Text;
            model . DS11 = textBox12 . Text;
            model . DS12 = dateTimePicker2 . Value;
            model . DS13 = textBox13 . Text;
            model . DS14 = dateTimePicker3 . Value;
            model . DS01 = textBox18 . Text;
            model . DS22 = textBox1 . Text;
            model . DS24 = textBox2 . Text;
            model . DS25 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToInt64 ( textBox3 . Text );
            model . DS26 = textBox4 . Text;
            model . DS27 = dateTimePicker1 . Value;
            DataTable saves = bll . GetDataTableAll ( model . DS21 );
            if ( weihu . Equals ( "1" ) )
            {
                if ( string . IsNullOrEmpty ( textBox14 . Text ) )
                {
                    MessageBox . Show ( "请输入维护意见" );
                    return;
                }
                if ( saves . Rows . Count < 1 )
                    MessageBox . Show ( "单号:" + model . DS21 + "的记录不存在,请核实后再维护" );
                else
                {
                    model . DS19 = textBox14 . Text;
                    model . DS20 = saves . Rows [ 0 ] [ "DS20" ] . ToString ( ) + "[" + Logins . username + System . DateTime . Now . ToString ( "yyyyMMdd" ) + "]";

                    result = false;
                    result = bll . UpdateWei ( model );
                    if ( result == false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );

                        adds ( );
                    }
                }
            }
            else
            {
                if ( ( sav . Equals ( "1" ) || sav . Equals ( "3" ) ) && bll . Exists ( model . DS01 ,model . DS21 ) )
                {
                    MessageBox . Show ( "流水号:" + model . DS01 + "已经存在,请核实" );
                    return;
                }

                if ( sav . Equals ( "1" ) )
                    stateOfOdd = "新增保存";
                else if ( sav . Equals ( "2" ) )
                    stateOfOdd = "更改保存";
                else if ( sav . Equals ( "3" ) )
                    stateOfOdd = "复制保存";
                if ( sav . Equals ( "3" ) )
                {
                    model . DS01 = textBox18 . Text;
                    try
                    {
                        result = bll . UpdateLJ ( model . DS01 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,DateTime . Now ,"保存" ,stateOfOdd ,model . DS21 );
                    }
                    catch { }
                }
                if ( saves . Rows . Count > 0 )
                {
                    result = false;

                    if ( !Logins . number . Equals ( "MLL-0001" ) && bll . ExistsUserAndNum ( model ) )
                    {
                        MessageBox . Show ( "流水号:" + model . DS01 + "您已经生成单据,请查询编辑" );
                        return;
                    }
                    result = bll . UpdateOther ( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,DateTime . Now ,"保存" ,stateOfOdd );

                    if ( result == false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );

                        adds ( );
                    }
                }
                else
                {
                    MessageBox . Show ( "录入数据失败" );
                    adds ( );
                }
            }
        }
        protected override void cancel ( )
        {
            base . cancel ( );

            if ( sav . Equals ( "1" ) && weihu != "1" || sav . Equals ( "3" ) )
            {
                try
                {
                    result = bll . DeleteOddNum ( model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
                finally
                {
                    Ergodic . SpliClear ( spList );
                    Ergodic . TablePageEnableClear ( pageList );
                    gridControl1 . DataSource = null;
                    label44 . Visible = false;

                    toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                    toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = false;
                }
            }
            else if ( sav . Equals ( "2" ) || weihu . Equals ( "1" ) )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = true;
                toolReview . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
            }

            Ergodic . SpliEnableFalse ( spList );
            Ergodic . TablePageEnableFalse ( pageList );
            textBox14 . Enabled = false;
        }
        protected override void maintain ( )
        {
            base . maintain ( );

            result = false;
            result = bll . ExistsReview ( model . DS21 ,this . Text );
            if ( result == true )
            {
                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = false;
                toolCancel . Enabled = toolSave . Enabled = true;

                Ergodic . SpliEnableTrue ( spList );
                Ergodic . TablePageEnableTrue ( pageList );

                dateTimePicker1 . Enabled = false;
                label107 . Visible = true;

                weihu = "1";
            }
            else
                MessageBox . Show ( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void copys ( )
        {
            base . copys ( );

            if ( sav . Equals ( "1" ) )
                stateOfOdd = "新增复制";
            else if ( sav . Equals ( "2" ) )
                stateOfOdd = "更改复制";

            result = bll . Copy ( model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox . Show ( "复制失败,请重试" );
            else
            {
                if ( sav . Equals ( "1" ) )
                    stateOfOdd = "新增复制更改单号";
                else if ( sav . Equals ( "2" ) )
                    stateOfOdd = "更改复制更改单号";
                model . DS21 = oddNumbers . purchaseContract ( "SELECT MAX(AJ014) AJ014 FROM R_PQAJ" ,"AJ014" ,"R_436-" );
                result = bll . CopyUpdate ( model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox . Show ( "复制失败,请重试" );
                    bll . DeleteCopy ( );
                }
                else
                {

                    Ergodic . SpliEnableTrue ( spList );
                    Ergodic . TablePageEnableTrue ( pageList );
                    gridControl1 . DataSource = null;
                    label107 . Visible = false;
                    weihu = "";
                    sav = "3";
                    label44 . Visible = true;
                    assignMentQuery ( );

                    toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolUpdate . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                    toolSave . Enabled = toolCancel . Enabled = true;
                }
            }
        }
        protected override void print ( )
        {
            printOrExport ( );
            report . Load ( Application . StartupPath + "\\R_436.frx" );
            report . RegisterData ( RDataSet );
            report . Show ( );

            base . print ( );
        }
        protected override void export ( )
        {
            report . Load ( Application . StartupPath + "\\R_436.frx" );

            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        void printOrExport ( )
        {
            RDataSet = new DataSet ( );
            printOne = bll . getPrintOne ( model . DS21 );
            printOne . TableName = "R_PQR";
            printTwo = bll . getPrintTwo ( model . DS21 );
            printTwo . TableName = "R_PQDS";

            RDataSet . Tables . AddRange ( new DataTable [ ] { printOne ,printTwo } );
        }
        #endregion

        #region Table
        //Add
        void build ( )
        {
            model . DS01 = textBox18 . Text;
            model . DS02 = textBox10 . Text;
            //model . DS03 = gridLookUpEdit1 . Text;
           
            model . DS04 = lookUpEdit1 . Text;
            model . DS05 = string . IsNullOrEmpty ( textBox11 . Text ) == true ? 0 : Convert . ToInt64 ( textBox11 . Text );
            model . DS06 = string . IsNullOrEmpty ( textBox15 . Text ) == true ? 0 : Convert . ToInt64 ( textBox15 . Text );
            model . DS09 = textBox9 . Text;
            model . DS18 = string . IsNullOrEmpty ( textBox7 . Text ) == true ? 0 : Convert . ToDecimal ( textBox7 . Text );
            model . DS22 = textBox1 . Text;
            model . DS24 = textBox2 . Text;
            model . DS25 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToInt64 ( textBox3 . Text );
            model . DS26 = textBox4 . Text;
            model . DS27 = dateTimePicker1 . Value;
            
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox18 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            if ( string . IsNullOrEmpty ( textBox5 . Text ) )
            {
                MessageBox . Show ( "请选择零件名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择或填写工序" );
                return;
            }
            build ( );

            if ( rows . Count < 1 )
            {
                MessageBox . Show ( "请选择零件信息" );
                return;
            }

            foreach ( DataRow row in rows )
            {
                model . DS03 = row [ "GZ03" ] . ToString ( );
                model . DS29 = string . IsNullOrEmpty ( row [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "GS10" ] );
                result = bll . Exists ( model );
                if ( result == true )
                {
                    MessageBox . Show ( "单号:" + model . DS21 + "\n\r零件名称:" + model . DS03 + "\n\r工序:" + model . DS04 + "\n\r的数据已经存在,请核实后再录入" );
                    continue;
                }

                //}
                //result = bll . Exists ( model );
                //if ( result == true )
                //    MessageBox . Show ( "单号:" + model . DS21 + "\n\r零件名称:" + model . DS03 + "\n\r工序:" + model . DS04 + "\n\r的数据已经存在,请核实后再录入" );
                //else
                //{
                if ( sav == "1" )
                    stateOfOdd = "新增新建";
                else if ( sav == "2" )
                    stateOfOdd = "更改新建";
                else if ( sav == "3" )
                    stateOfOdd = "复制新建";
                result = bll . Add ( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
               
                //if ( result == true )
                //{
                //    //MessageBox . Show ( "成功录入数据" );
                //    strWhere = "1=1";
                //    strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
                //    //dt = dateTimePicker4.Value;
                //    refresh ( );
                //}
                //else
                //    MessageBox . Show ( "录入数据失败" );
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
            //dt = dateTimePicker4.Value;
            refresh ( );

            if ( result == false )
                MessageBox . Show ( "录入数据失败" );

        }
        //Delete
        private void button2_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( sav == "1" )
                stateOfOdd = "新增删除";
            else if ( sav == "2" )
                stateOfOdd = "更改删除";
            else if ( sav == "3" )
                stateOfOdd = "复制删除";
            result = bll.Delete( model.Idx ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd ,model.DS21 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.Remove( tableQuery.Select( "idx='" + model.Idx + "'" )[0] );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Edit
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox18 . Text ) )
                MessageBox . Show ( "请选择流水号" );
            else
            {
                if ( string . IsNullOrEmpty ( textBox5 . Text ) )
                    MessageBox . Show ( "请选择零件名称" );
                else
                {
                    if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
                        MessageBox . Show ( "请选择或填写工序" );
                    else
                    {
                        build ( );
                        model . DS29 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToInt32 ( textBox5 . Text );
                        model . DS03 = textBox6 . Text;
                        if ( sav . Equals ( "1" ) )
                            stateOfOdd = "新增编辑";
                        else if ( sav . Equals ( "2" ) )
                            stateOfOdd = "更改编辑";
                        else if ( sav . Equals ( "3" ) )
                            stateOfOdd = "复制编辑";
                        if ( model . DS03 . Equals ( ds3 ) && model . DS04 . Equals ( ds4 ) )
                        {
                            result = false;
                            result = bll . Update ( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,DateTime . Now ,"编辑" ,stateOfOdd );
                            if ( result == true )
                            {
                                MessageBox . Show ( "成功编辑数据" );
                                strWhere = "1=1";
                                strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
                                //dt = dateTimePicker4.Value;
                                refresh ( );
                            }
                            else
                                MessageBox . Show ( "编辑数据失败" );
                        }
                        else
                        {
                            result = false;
                            result = bll . Exists ( model );
                            if ( result == false )
                            {
                                result = false;
                                result = bll . Update ( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,DateTime . Now ,"编辑" ,stateOfOdd );
                                if ( result == true )
                                {
                                    MessageBox . Show ( "成功编辑数据" );
                                    strWhere = "1=1";
                                    strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
                                    //dt = dateTimePicker4.Value;
                                    refresh ( );
                                }
                                else
                                    MessageBox . Show ( "编辑数据失败" );
                            }
                            else
                                MessageBox . Show ( "单号:" + model . DS21 + "\n\r零件名称:" + model . DS03 + "\n\r工序:" + model . DS04 + "\n\r的数据已经存在,请核实后再编辑" );
                        }
                    }
                }
            }
        }
        //Generate
        void builds ( )
        {
            model.DS01 = textBox18.Text;
            model.DS02 = textBox10.Text;
            model.DS06 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToInt64( textBox15.Text );
            model.DS09 = textBox9.Text;
            model.DS18 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToDecimal( textBox7.Text );
            model.DS22 = textBox1.Text;
            model.DS24 = textBox2.Text;
            model.DS25 = string.IsNullOrEmpty( textBox3.Text ) == true ? 0 : Convert.ToInt64( textBox3.Text );
            model.DS26 = textBox4.Text;
            model.DS27 = dateTimePicker1.Value;
        }
        private void button6_Click_1 ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox18.Text ) )
            {
                builds( );
                if ( string.IsNullOrEmpty( textBox18.Text ) )
                    return;
                string[] str = textBox18.Text.Split( new char[] { ',' } );
                if ( str.Length > 0 )
                {
                    foreach ( string s in str )
                    {
                        if ( numCount == "" )
                            numCount = "'" + s + "'";
                        else
                            numCount = numCount + "," + "'" + s + "'";
                    }
                }
                if ( numCount == "" )
                    return;
                if ( sav == "1" )
                    stateOfOdd = "新增生成";
                else if ( sav == "2" )
                    stateOfOdd = "更改生成";
                else if ( sav == "3" )
                    stateOfOdd = "复制生成";
                DataTable dr = bll.GetDataTableGen( numCount );
                if ( dr != null && dr.Rows.Count > 0 )
                {
                    DataTable de = bll.GetDataTableLocal( numCount );
                    if ( de != null && de.Rows.Count > 0 )
                    {
                        model.DS21 = de.Rows[0]["DS21"].ToString( );
                        for ( int i = 0 ; i < dr.Rows.Count ; i++ )
                        {
                           
                            model.DS03 = dr.Rows[i]["GZ03"].ToString( );
                            model.DS04 = dr.Rows[i]["GZ04"].ToString( );
                            model.DS05 = string.IsNullOrEmpty( dr.Rows[i]["GX03"].ToString( ) ) == true ? 0 : Convert.ToInt64( dr.Rows[i]["GX03"].ToString( ) );
                            model.DS28 = string.IsNullOrEmpty( dr.Rows[i]["GZ40"].ToString( ) ) == true ? 0 : Convert.ToInt32( dr.Rows[i]["GZ40"].ToString( ) );
                            if ( de.Select( "DS03='" + model.DS03 + "' AND DS04='" + model.DS04 + "'" ).Length <= 0 )
                            {
                                result = bll.Add( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"生成" ,stateOfOdd );
                                if ( result==false )
                                {
                                    MessageBox.Show( "生成失败" );
                                    break;
                                }
                                else if ( i == dr.Rows.Count - 1 )
                                {
                                    MessageBox.Show( "生成成功" );
                                    strWhere = "1=1";
                                    strWhere = strWhere + " AND DS21='" + model.DS21 + "'";
                                    refresh( );
                                }
                            }
                            else
                            {
                                if ( i == dr.Rows.Count - 1 )
                                {
                                    MessageBox.Show( "生成成功" );
                                    strWhere = "1=1";
                                    strWhere = strWhere + " AND DS21='" + model.DS21 + "'";
                                    refresh( );
                                }
                            }
                        }
                    }
                    else
                    {
                        model.DS21 = oddNumbers.purchaseContract( "SELECT MAX(AJ014) AJ014 FROM R_PQAJ" ,"AJ014" ,"R_436-" );
                        for ( int i = 0 ; i < dr.Rows.Count ; i++ )
                        {
                            model.DS03 = dr.Rows[i]["GZ03"].ToString( );
                            model.DS04 = dr.Rows[i]["GZ04"].ToString( );
                            model.DS05 = string.IsNullOrEmpty( dr.Rows[i]["GX03"].ToString( ) ) == true ? 0 : Convert.ToInt64( dr.Rows[i]["GX03"].ToString( ) );
                            model.DS28 = string.IsNullOrEmpty( dr.Rows[i]["GZ40"].ToString( ) ) == true ? 0 : Convert.ToInt32( dr.Rows[i]["GZ40"].ToString( ) );
                            result = bll.Add( model ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"生成" ,stateOfOdd );
                            if ( result == false )
                            {
                                MessageBox.Show( "生成失败" );
                                break;
                            }
                            else if ( i == dr.Rows.Count - 1 )
                            {
                                MessageBox.Show( "生成成功" );
                                strWhere = "1=1";
                                strWhere = strWhere + " AND DS21='" + model.DS21 + "'";
                                refresh( );
                            }
                        }
                    }
                }
                else
                    MessageBox.Show( "317中无此流水号的记录" );
            }
        }
        //Refresh
        private void button9_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND DS21='" + model.DS21 + "'";
            refresh( );
            readColumn ( );
        }
        void refresh ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            numCount = "";
            if ( string.IsNullOrEmpty( textBox18.Text ) )
                numCount = "''";
            else
            {
                string[] str = textBox18.Text.Split( new char[] { ',' } );
                if ( str.Length > 0 )
                {
                    foreach ( string s in str )
                    {
                        if ( numCount == "" )
                            numCount = "'" + s + "'";
                        else
                            numCount = numCount + "," + "'" + s + "'";
                    }
                }
            }
            if ( numCount == "" )
                numCount = "''";
            if ( numCount == "''" )
                tableQuery = bll.GetDataTable( strWhere );
            else
                tableQuery = bll.GetDataTable( strWhere ,numCount );
            gridControl1.DataSource = tableQuery;
            assignMnet ( );
        }
        void assignMnet ( )
        {
            if ( bandedGridView1 . RowCount > 0 )
            {
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( S . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( D0 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( S . SummaryItem . SummaryValue ) ,1 ) . ToString ( ) );
                U1 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( S . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( D2 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( S . SummaryItem . SummaryValue ) ,1 ) . ToString ( ) );
            }
        }
        void readColumn ( )
        {
            //接受单位
            lookUpEdit4 . Properties . DataSource = bll . GetDataTableCheJian ( );
            lookUpEdit4 . Properties . DisplayMember = "DBA002";
            lookUpEdit4 . Properties . ValueMember = "DBA001";
            
            //工序名称==》工序BOM
            gx = bll . GetDataTableBom ( );
            lookUpEdit1 . Properties . DataSource = gx;
            lookUpEdit1 . Properties . DisplayMember = "GX02";

            model . DS01 = textBox18 . Text;
            //零件名称==》509
            partTable = bll . GetDataTableWorkShops ( model . DS01 );
            gridLookUpEdit1 . Properties . DataSource = partTable;
            gridLookUpEdit1 . Properties . DisplayMember = "GZ03";
            gridLookUpEdit1 . Properties . ValueMember = "GZ03";
        }
        //batch
        private void btnBatch_Click ( object sender ,EventArgs e )
        {
            model . DS03 = gridLookUpEdit1 . Text;
            model . DS01 = textBox18 . Text;
            model . DS04 = lookUpEdit1 . Text;
            model . DS20 = Logins . username;

            SelectAll . FormGongXuBatch from = new SelectAll . FormGongXuBatch ( partTable ,gx ,model );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                //if ( sav . Equals ( "1" ) )
                //    stateOfOdd = "新增编辑";
                //else if ( sav . Equals ( "2" ) )
                //    stateOfOdd = "更改编辑";
                //else if ( sav . Equals ( "3" ) )
                //    stateOfOdd = "复制编辑";
                //string part = from . getStr;
                //result = bll . Batch ( textBox18 . Text ,model . DS21 ,"R_436" ,"产品定时、定量、定额工序工资明细表" ,Logins . username ,DateTime . Now ,"批量编辑" ,stateOfOdd ,part ,gridLookUpEdit1 . Text );
                //if ( result )
                //{
                //    MessageBox . Show ( "成功编辑" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND DS21='" + model . DS21 + "'";
                    //dt = dateTimePicker4.Value;
                    refresh ( );
                //}
                //else
                //    MessageBox . Show ( "编辑失败" );
            }
        }
        #endregion

    }
}
