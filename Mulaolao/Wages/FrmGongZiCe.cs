using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Mulaolao.Wages
{
    public partial class FrmGongZiCe : FormChild
    {
        public FrmGongZiCe ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1,gridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.GongZiCeLibrary model = new MulaolaoLibrary.GongZiCeLibrary( );
        MulaolaoBll.Bll.GongZiCeBll bll = new MulaolaoBll.Bll.GongZiCeBll( );
        List<SplitContainer> spList = new List<SplitContainer>( ); SpecialPowers sp = new SpecialPowers( );
        string sav = "", strWhere = "1=1", weihu = "", file = "", idStr = "";
        bool result = false;
        DataTable tableQuery, tableTwo;
        DataSet set;
        DataSet RDataSet; Report report = new Report( ); EcanRMB rmb = new EcanRMB( );
        List<string> idxList = new List<string>( ); 

        private void FrmGongZiCe_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.Add( splitContainer1 );
            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            Ergodic.SpliEnableFalse( spList );
            textBox1.Enabled = false;
            label45.Visible = false;

            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit2.Properties.ShowHeader = false;
            lookUpEdit3.Properties.ShowHeader = false;

            lookUpEdit2 . Properties . DataSource = bll . GetDataTableLeader ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";

            lookUpEdit4 . Properties . DataSource = bll . GetDataTableSta ( );
            lookUpEdit4 . Properties . DisplayMember = "DBA002";

            lookUpEdit1 .Properties.DataSource = bll.GetDataTableWorkShop( );
            lookUpEdit1.Properties.DisplayMember = "DBA002";

            GridViewMoHuSelect.SetFilter( gridView1 );
        }

        private void FrmGongZiCe_Shown ( object sender ,EventArgs e )
        {
            model.EZ001 = Merges.oddNum;
            if ( model.EZ001 != null && model.EZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print Export
        void CreateRDataSet ( )
        {
            file = "";
            file = /*Environment.CurrentDirectory;*/System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_323.frx" );

            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrint( model.EZ001 );
            if ( print != null && print.Rows.Count > 0 )
            {
                string str = print.Rows[0]["EZ"].ToString( );
                string st = rmb.CmycurD( Convert.ToDecimal( print.Rows[0]["EZ"].ToString( ) ) );
                report.SetParameterValue( "Sum" ,print.Rows[0]["EZ"].ToString( ) + "元整" );
                if ( !string.IsNullOrEmpty( print.Rows[0]["EZ"].ToString( ) ) )
                    report.SetParameterValue( "SumTrim" ,rmb.CmycurD( Convert.ToDecimal( print.Rows[0]["EZ"].ToString( ) ) ) );
            }
            DataTable prints = bll.GetDataTablePrints( model.EZ001 );
            print.TableName = "R_PQEZ";
            prints.TableName = "R_PQEZS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region Query
        SelectAll.GongZiCeAll query = new SelectAll.GongZiCeAll( );
        void autoQuery ( )
        {
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            sav = "2";

            strWhere = "1=1";
            strWhere = strWhere + " AND EZ001='" + model.EZ001 + "'";
            refre( );

            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                textBox1.Text = tableQuery.Rows[0]["EZ012"].ToString( );
            }
        }
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.GongZiCeLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.GongZiCeAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( model.EZ001 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.EZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion
        
        #region Event
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox2 );
        }
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox2 );
        }
        private void textBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox2.Text != "" && !DateDay.foreOneNum( textBox2 ) )
            {
                textBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox3 );
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3.Text != "" && !DateDay.foreOneNum( textBox3 ) )
            {
                textBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            
        }
        private void lookUpEdit2_EditValueChanged ( object sender ,EventArgs e )
        {
            lookUpEdit3.Properties.DataSource = bll.GetDataTableLeader( lookUpEdit2.Text );
            lookUpEdit3.Properties.DisplayMember = "DBA002";
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assgien( );
            }
        }
        void assgien ( )
        {
            model = bll.GetModel( model.IDX );
            dateTimePicker1.Value = DateTime.ParseExact( model.EZ004 + MulaolaoBll . Drity . GetDt ( ).ToString( "dd" ) ,"yyyyMMdd" ,System.Globalization.CultureInfo.CurrentCulture );
            textBox2.Text = model.EZ005.ToString( );
            textBox3.Text = model.EZ006.ToString( );
            textBox5.Text = model.EZ007.ToString( );
            textBox4.Text = model.EZ008.ToString( );
            textBox6.Text = model.EZ009.ToString( );
            textBox7.Text = model.EZ010.ToString( );
            lookUpEdit1.Text = model.EZ002;
            lookUpEdit2.Text = model.EZ011;
            lookUpEdit3.Text = model.EZ003;
            lookUpEdit4.Text = model.EZ014;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            Ergodic.SpliEnableTrue( spList );

            model.EZ001 = oddNumbers.purchaseContract( "SELECT MAX(EZ001) EZ001 FROM R_PQEZ" ,"EZ001" ,"R_323-" );
            sav = "1";
            label45.Visible = false;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            textBox1.Enabled = false;
        }
        void dele ( )
        {
            idStr = "''";
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                idStr = idStr + "," + "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
            }
            
            result = false;
            result = bll.DeleteOddNum( model.EZ001 ,idStr );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "删除数据成功" );
                Ergodic.SpliClear( spList );
                gridControl1.DataSource = null;
                Ergodic.SpliEnableFalse( spList );

                toolAdd.Enabled = toolSelect.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;

                label45.Visible = false;
                textBox1.Enabled = false;

                try
                {
                    bll.DeleteReview( model.EZ001 ,"R_323" );
                }
                catch { }
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            result = false;
            result = bll.ExistsReviews( model.EZ001 ,"R_323" );
            if ( result == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单号:" + model.EZ001 + "的单据状态为执行,需要总经理删除" );
            }
            else
                dele( );
        }
        protected override void update ( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReviews( model.EZ001 ,"R_323" );
            if ( result == true )
                MessageBox.Show( "单号:" + model.EZ001 + "的单据状态为执行,不允许更改" );
            else
            {
                sav = "2";
                Ergodic.SpliEnableTrue( spList );

                toolSave.Enabled = toolCancel.Enabled = true;
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                textBox1.Enabled = false;
            }
        }
        protected override void print ( )
        {
            base.print( );

            if ( label45.Visible == true )
            {
                CreateRDataSet( );

                report.RegisterData( RDataSet );
                report.Show( );
        }
            else
                MessageBox.Show( "非执行单据不能打印" );
        }
        protected override void export ( )
        {
            base.export( );

            CreateRDataSet( );

            //file = "";
            //file = System.Windows.Forms.Application.StartupPath;
            //report.Load( file + "\\R_323.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        void state ( )
        {
            toolSave.Enabled = toolCancel.Enabled = false;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            Ergodic.SpliEnableFalse( spList );
            textBox1.Enabled = false;
            weihu = "";
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                if ( weihu == "1" )
                {
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        MessageBox.Show( "维护意见不可为空" );
                    else
                    {
                        DataTable dt = bll.GetDataTableWeiHu( model.EZ001 );
                        model.EZ012 = textBox1.Text;
                        model.EZ013 = dt.Rows[0]["EZ013"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ) + "]";

                        result = false;
                        result = bll.UpdateWeiHu( model );
                        if ( result == false )
                            MessageBox.Show( "维护数据失败" );
                        else
                        {
                            MessageBox.Show( "维护数据成功" );
                            state( );
                        }
                    }
                }
                else
                    state( );
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" && weihu != "1" )
            {
                try
                {
                    idStr = "''";
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        idStr = idStr + "," + "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
                    }
                    bll.DeleteOddNum( model.EZ001 ,idStr );
                }
                catch { }
                finally {
                    Ergodic.SpliClear( spList );
                    gridControl1.DataSource = null;
                    Ergodic.SpliEnableFalse( spList );
                    toolAdd.Enabled = toolSelect.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;

                }
            }
            else if ( sav == "2" || weihu == "1" )
            {
                Ergodic.SpliEnableFalse( spList );
                toolSave.Enabled = toolCancel.Enabled = false;
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            }
            weihu = "";
        }
        protected override void maintain ( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReviews( model.EZ001 ,"R_323" );
            if ( result == true )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                weihu = "1";
                textBox1.Enabled = true;
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "EZ001" ,model.EZ001 ,"R_PQEZ" ,this ,"" ,"R_323" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            result = false;
            result = sp.reviewImple( "R_323" ,model.EZ001 );
            if ( result == true )
            {
                label45.Visible = true;
                try
                {
                    strWhere = "";
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( strWhere == "" )
                            strWhere = gridView1.GetDataRow( i )["idx"].ToString( );
                        else
                            strWhere = strWhere + "," + gridView1.GetDataRow( i )["idx"].ToString( );
                    }
                    if ( !string.IsNullOrEmpty( strWhere ) )
                        result = bll.UpdateWriteTo( strWhere );
                }
                catch { }
            }
            else
                label45.Visible = false;
        }
        #endregion

        #region Table
        void variable ( )
        {
            model . EZ002 = lookUpEdit1 . Text;
            model . EZ003 = lookUpEdit3 . Text;
            model . EZ004 = dateTimePicker1 . Value . ToString ( "yyyyMM" );
            model . EZ005 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToDecimal ( textBox2 . Text );
            model . EZ006 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToDecimal ( textBox3 . Text );
            model . EZ007 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToDecimal ( textBox5 . Text );
            model . EZ008 = string . IsNullOrEmpty ( textBox4 . Text ) == true ? 0 : Convert . ToDecimal ( textBox4 . Text );
            model . EZ009 = string . IsNullOrEmpty ( textBox6 . Text ) == true ? 0 : Convert . ToDecimal ( textBox6 . Text );
            model . EZ010 = string . IsNullOrEmpty ( textBox7 . Text ) == true ? 0 : Convert . ToDecimal ( textBox7 . Text );
            model . EZ011 = lookUpEdit2 . Text;
            model . EZ014 = lookUpEdit4 . Text;
        }
        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "车间主任不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "组长不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit4 . Text ) )
            {
                MessageBox . Show ( "统计员不可为空" );
                return;
            }
            variable ( );

            string year = dateTimePicker1 . Value . ToString ( "yyyy" );
            int mouth = Convert . ToInt32 ( dateTimePicker1 . Value . ToString ( "MM" ) );
            DataTable dt = bll . GetDataTableGenerate ( year ,mouth ,model . EZ002 ,model . EZ011 ,model . EZ014 );
            if ( dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    model . EZ003 = dt . Rows [ i ] [ "GZ02" ] . ToString ( );
                    //if ( dt.Rows[i]["GZ28"].ToString( ).Length ==1 )
                    //    model.EZ004 = dt.Rows[i]["GZ35"].ToString( ) + "0" + dt.Rows[0]["GZ28"].ToString( );
                    //else
                    //    model.EZ004 = dt.Rows[i]["GZ35"].ToString( ) + dt.Rows[i]["GZ28"].ToString( );
                    model . EZ004 = dateTimePicker1 . Value . ToString ( "yyyyMM" );
                    model . EZ005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U0" ] . ToString ( ) );
                    model . EZ006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U1" ] . ToString ( ) );
                    model . EZ007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U2" ] . ToString ( ) );
                    model . EZ008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U3" ] . ToString ( ) );
                    model . EZ009 = 0;
                    model . EZ010 = 0;
                    model . EZ011 = dt . Rows [ i ] [ "GZ16" ] . ToString ( );

                    model . IDX = bll . ExistsUpIn ( model );
                    if ( model . IDX > 0 )
                    {
                        result = bll . ExistsTranUpdate ( model ,year ,mouth );
                        if ( result == false )
                        {
                            MessageBox . Show ( "生成失败" );
                            break;
                        }
                        else if ( i == dt . Rows . Count - 1 )
                        {
                            MessageBox . Show ( "生成成功" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND EZ001='" + model . EZ001 + "'";
                            refre ( );
                        }
                    }
                    else
                    {
                        result = bll . ExistsTranInsert ( model ,year ,mouth );
                        if ( result == false )
                        {
                            MessageBox . Show ( "生成失败" );
                            break;
                        }
                        else if ( i == dt . Rows . Count - 1 )
                        {
                            MessageBox . Show ( "生成成功" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND EZ001='" + model . EZ001 + "'";
                            refre ( );
                        }
                    }
                }
            }
        }
        //Generate this month
        private void button6_Click ( object sender ,EventArgs e )
        {
            bool resultState = true;
            int year = dateTimePicker1 . Value . Year;
            int mouth = dateTimePicker1 . Value . Month;
            DataTable da = bll . GetDataTableGroupBy ( year ,mouth );
            if ( da == null || da . Rows . Count < 1 )
            {
                MessageBox . Show ( "本结算年月在317无记录" );
                return;
            }
            DataTable dt;
            for ( int j = 0 ; j < da . Rows . Count ; j++ )
            {
                model . EZ001 = oddNumbers . purchaseContract ( "SELECT MAX(EZ001) EZ001 FROM R_PQEZ" ,"EZ001" ,"R_323-" );
                model . EZ002 = da . Rows [ j ] [ "GZ30" ] . ToString ( );
                model . EZ011 = da . Rows [ j ] [ "GZ16" ] . ToString ( );
                model . EZ014 = da . Rows [ j ] [ "GZ37" ] . ToString ( );
                dt = bll . GetDataTableGenerate ( year . ToString ( ) ,mouth ,model . EZ002 ,model . EZ011 ,model . EZ014 );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        model . EZ003 = dt . Rows [ i ] [ "GZ02" ] . ToString ( );
                        //if ( dt.Rows[i]["GZ28"].ToString( ).Length ==1 )
                        //    model.EZ004 = dt.Rows[i]["GZ35"].ToString( ) + "0" + dt.Rows[0]["GZ28"].ToString( );
                        //else
                        //    model.EZ004 = dt.Rows[i]["GZ35"].ToString( ) + dt.Rows[i]["GZ28"].ToString( );
                        model . EZ004 = dateTimePicker1 . Value . ToString ( "yyyyMM" );
                        model . EZ005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U0" ] . ToString ( ) );
                        model . EZ006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U1" ] . ToString ( ) );
                        model . EZ007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U2" ] . ToString ( ) );
                        model . EZ008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "U3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "U3" ] . ToString ( ) );
                        model . EZ009 = 0;
                        model . EZ010 = 0;
                        model . EZ011 = dt . Rows [ i ] [ "GZ16" ] . ToString ( );

                        model . IDX = bll . ExistsUpIn ( model );
                        if ( model . IDX > 0 )
                        {
                            result = bll . ExistsTranUpdate ( model ,year . ToString ( ) ,mouth );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成失败" );
                                resultState = false;
                                break;
                            }
                            else if ( i == dt . Rows . Count - 1 )
                            {
                                resultState = true;
                                //MessageBox . Show ( "生成成功" );
                                //strWhere = "1=1";
                                //strWhere = strWhere + " AND EZ001='" + model . EZ001 + "'";
                                //refre ( );
                            }
                        }
                        else
                        {
                            result = bll . ExistsTranInsert ( model ,year . ToString ( ) ,mouth );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成失败" );
                                resultState = false;
                                break;
                            }
                            else if ( i == dt . Rows . Count - 1 )
                            {
                                resultState = true;
                                //MessageBox . Show ( "生成成功" );
                                //strWhere = "1=1";
                                //strWhere = strWhere + " AND EZ001='" + model . EZ001 + "'";
                                //refre ( );
                            }
                        }

                        if ( resultState == false )
                            return;
                    }
                }
                if ( resultState == false )
                    return;
            }

            if ( resultState == true )
            {
                MessageBox . Show ( "生成成功" );
                sav = "2";
            }
        }
        //Build
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                variable( );
                model.IDX = bll.Add( model );
                if ( model.IDX > 0 )
                {
                    MessageBox.Show( "录入数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND EZ001='" + model.EZ001 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
        }
        //Edit
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                MessageBox.Show( "车间主任不可为空" );
            else
            {
                variable( );
                result = false;
                result = bll.UpdateIdx( model );
                if ( result==true )
                {
                    MessageBox.Show( "录入数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND EZ001='" + model.EZ001 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
        }
        //Delete
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            result = false;
            result = bll.Delete( model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                tableQuery.Rows.Remove( tableQuery.Select( "idx='" + model.IDX + "'" )[0] );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button3_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND EZ001='" + model.EZ001 + "'";
            refre( );
        }
        void refre ( )
        {
            set = new DataSet( );
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQuery = bll.GetDataTableAll( strWhere );
            tableQuery.TableName = "PQEZ";
            set.Tables.Add( tableQuery );
            tableTwo = bll.GetDataTableMdi( strWhere );
            tableTwo.TableName = "PQW";
            set.Tables.Add( tableTwo );
            DataRelation ralation = new DataRelation( "R_317" ,set.Tables["PQEZ"].Columns["idx"] ,set.Tables["PQW"].Columns["idx"] );
            set.Relations.Add( ralation );
            gridControl1.DataSource = set.Tables["PQEZ"];
            assign( );
        }
        void assign ( )
        {
            U2.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( EZ005.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( EZ007.SummaryItem.SummaryValue ) / Convert.ToDecimal( EZ005.SummaryItem.SummaryValue ) ,1 ).ToString( ) );
            U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( EZ006.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( EZ008.SummaryItem.SummaryValue ) / Convert.ToDecimal( EZ006.SummaryItem.SummaryValue ) ,1 ).ToString( ) );
        }
        #endregion

    }
}
