using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Mulaolao.Wages
{
    public partial class R_FrmPayMent : FormChild
    {
        public R_FrmPayMent ( )
        {
            InitializeComponent( );
            
            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );
        MulaolaoLibrary.PayMentLibrary _model = new MulaolaoLibrary.PayMentLibrary( );
        MulaolaoLibrary.PayMentOneLibrary _modelOne = new MulaolaoLibrary.PayMentOneLibrary( );
        MulaolaoLibrary.QayMentTwoLibrary _modelTwo = new MulaolaoLibrary.QayMentTwoLibrary( );
        MulaolaoLibrary.PayMentTreLibrary _modelTre = new MulaolaoLibrary.PayMentTreLibrary( );
        MulaolaoLibrary.PayMentForLibrary _modelFor = new MulaolaoLibrary.PayMentForLibrary( );
        
        List<string> listOne = new List<string>( );
        int num = 0;
        bool result = false;
        DataTable tableQuery = new DataTable( );
        DataTable tableQueryOne = new DataTable( );
        DataTable tableQueryTwo = new DataTable( );
        DataTable tableQueryTre = new DataTable( );
        DataTable tableQueryFor = new DataTable( );
        DataTable dtSumTable = new DataTable( );
        DataTable tableQueryFiv = new DataTable( );
        DataTable tableQuerySix = new DataTable( );
        string /*strWhere = "1=1",*/ sav = "",strWhereOne=string.Empty,strWhereTwo=string.Empty,strWhereTre=string.Empty,strWhereFore=string.Empty,strWhereFiv=string.Empty,checkWho=string.Empty;
        DateTime dtOne, dtTwo;
        DataRow row;List<string> strTwo=new List<string>();

        private void R_FrmPayMent_Load ( object sender ,EventArgs e )
        {
            Power( this );
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.DataSource = null;
            gridView2.OptionsBehavior.Editable = false;
            gridControl2.DataSource = null;
            bandedGridView1.OptionsBehavior.Editable = false;
            gridControl3.DataSource = null;
            gridView3.OptionsBehavior.Editable = false;
            gridControl4.DataSource = null;
            gridView4.OptionsBehavior.Editable = false;
            gridControl5.DataSource = null;

            DataTable da = _bll.GetDataTableOfHide( );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( da.Rows[0]["YZ029"].ToString( ) == "T" )
                    YZ013.VisibleIndex = YZ015.VisibleIndex = U0.VisibleIndex = U1.VisibleIndex = U2.VisibleIndex = U3.VisibleIndex = AP013.VisibleIndex = AP015.VisibleIndex = U12.VisibleIndex = U13.VisibleIndex = U14.VisibleIndex = U15.VisibleIndex = -1;
                else
                {
                    apOf( );
                    yzof( );
                }
            }

            toolExport . Enabled = true;
        }
        
        private void R_FrmPayMent_Shown ( object sender ,EventArgs e )
        {
            _model.YZ001 = _modelOne.AP001 = _modelTwo.AQ001 = _modelTre.AO001 = _modelFor.AR001 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( Merges.oddNum ) )
            {
                strWhereOne = "1=1";
                strWhereOne = strWhereOne + " AND YZ001='" + _model.YZ001 + "'";
                refre( );
                comboboxItems( );

                strWhereTwo = "1=1";
                strWhereTwo = strWhereTwo + " AND AP001='" + _modelOne.AP001 + "'";
                refreOne( );
                comboboxItemsOne( );

                strWhereTre = "1=1";
                strWhereTre = strWhereTre + " AND AQ001='" + _modelTwo.AQ001 + "'";
                refreTwo( );
                comboboxItemsTwo( );

                strWhereFore = "1=1";
                strWhereFore = strWhereFore + " AND AO001='" + _modelTre.AO001 + "'";
                refreTre( );
                comboboxItemsTre( );

                strWhereFiv = "1=1";
                strWhereFiv = strWhereFiv + " AND AR001='" + _modelFor.AR001 + "'";
                refreFor( );
                comboboxItemsFor( );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                sav = "2";

                if ( tableQuery != null )
                    tabControl1.SelectedTab.Name = "tabPageOne";
                if ( tableQueryOne != null )
                    tabControl1.SelectedTab.Name = "tabPageTwo";
                if ( tableQueryTwo != null )
                    tabControl1.SelectedTab.Name = "tabPageTre";
                if ( tableQueryTre != null )
                    tabControl1.SelectedTab.Name = "tabPageFor";
                if ( tableQueryFor != null )
                    tabControl1.SelectedTab.Name = "tabPageFiv";
            }
            Merges.oddNum = "";
        }
        
        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        private void repositoryItemButtonEdit1_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ022"].ToString( )*/tableQuery.Rows[i]["YZ022"].ToString() ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ022"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ022"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP022"].ToString( )*/ tableQueryOne .Rows[i]["AP022"].ToString()) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP022"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP022"].ToString( );
                    }
                }
            }
            num = gridView1.FocusedRowHandle;
            SelectAll.PayMentCheckOutAll checkOutQuery = new SelectAll.PayMentCheckOutAll( );
            checkOutQuery.StartPosition = FormStartPosition.CenterScreen;
            if ( gridView1.FocusedRowHandle <= tableQuery.Rows.Count && gridView1.FocusedRowHandle>=0)
                checkOutQuery.supplier = gridView1.GetDataRow( gridView1.FocusedRowHandle )["YZ006"].ToString( );
            else
                checkOutQuery.supplier = "";
            checkOutQuery.idxSt = idxSt;
            checkOutQuery.PassDataBetweenForm += new SelectAll.PayMentCheckOutAll.PassDataBetweenFormHandler( checkOutQuery_PassDataBetweenForm );
            checkOutQuery.ShowDialog( );
        }
        private void checkOutQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConSix == "1" )
            {
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ006" ] ,e . ConFor );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ010" ] ,e . ConOne );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ015" ] ,e . ConTwo );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ017" ] ,e . ConTre );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ022" ] ,e . ConFiv );
            }
            if ( e . ConSix == "2" )
            {
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ006" ] ,e . ConOne );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ007" ] ,e . ConTwo );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ010" ] ,0 );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ015" ] ,e . ConTre );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ027" ] ,e . ConFor );
            }
            if ( e . ConSix == "3" )
            {
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ013" ] ,e . ConTwo );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ015" ] ,e . ConTre );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ030" ] ,e . ConOne );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ006" ] ,e . ConFor );
            }
            if ( e . ConSix == "4" )
            {
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ017" ] ,e . ConOne );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ006" ] ,e . ConTwo );
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ032" ] ,e . ConFor );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ023"].ToString( ) */ tableQuery.Rows[i]["YZ023"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ023"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ023"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP023"].ToString( )*/ tableQueryOne.Rows[i]["AP023"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP023"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP023"].ToString( );
                    }
                }
            }
            checkWho = "yz014";
           num = gridView1.FocusedRowHandle;
            SelectAll.PayMentDetailed detailQuery = new SelectAll.PayMentDetailed( );
            detailQuery.StartPosition = FormStartPosition.CenterScreen;
            detailQuery.idxSt = idxSt;
            detailQuery.PassDataBetweenForm += new SelectAll.PayMentDetailed.PassDataBetweenFormHandler( detailQuery_PassDataBetweenForm );
            detailQuery.ShowDialog( );
        }
        private void repositoryItemButtonEdit9_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( /*gridView1.GetDataRow( i )["YZ023"].ToString( ) */ tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( );
                        else
                            idxSt = idxSt + "," + tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne . Rows . Count ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( /*gridView2.GetDataRow( i )["AP023"].ToString( )*/ tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( );
                        else
                            idxSt = idxSt + "," + tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( );
                    }
                }
            }
            checkWho = "yz026";
            num = gridView1 . FocusedRowHandle;
            SelectAll . PayMentDetailed detailQuery = new SelectAll . PayMentDetailed ( );
            detailQuery . StartPosition = FormStartPosition . CenterScreen;
            detailQuery . idxSt = idxSt;
            detailQuery . PassDataBetweenForm += new SelectAll . PayMentDetailed . PassDataBetweenFormHandler ( detailQuery_PassDataBetweenForm );
            detailQuery . ShowDialog ( );
        }
        private void detailQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( checkWho . Equals ( "yz014" ) )
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ014" ] ,e . ConTre );
            else if ( checkWho . Equals ( "yz026" ) )
                gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ026" ] ,e . ConTre );
            gridView1 . SetRowCellValue ( num ,gridView1 . Columns [ "YZ023" ] ,e . ConTwo );
            //gridView1.SetRowCellValue( num ,gridView1.Columns["YZ026"] ,e.ConTre );
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ024"].ToString( )*/ tableQuery.Rows[i]["YZ024"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ024"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ024"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty(/* gridView2.GetDataRow( i )["AP024"].ToString( )*/ tableQueryOne.Rows[i]["AP024"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP024"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP024"].ToString( );
                    }
                }
            }
            num = gridView1.FocusedRowHandle;
            SelectAll.PayMentWages wageQuery = new SelectAll.PayMentWages( );
            wageQuery.StartPosition = FormStartPosition.CenterScreen;
            wageQuery.idxSt = idxSt;
            wageQuery.PassDataBetweenForm += new SelectAll.PayMentWages.PassDataBetweenFormHandler( wageQuery_PassDataBetWeenForm );
            wageQuery.sign = "1";
            wageQuery.ShowDialog( );
        }
        private void wageQuery_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView1.SetRowCellValue( num ,gridView1.Columns["YZ017"] ,e.ConOne );
            gridView1.SetRowCellValue( num ,gridView1.Columns["YZ024"] ,e.ConTwo );
        }
        private void repositoryItemButtonEdit4_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ025"].ToString( )*/ tableQuery.Rows[i]["YZ025"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ025"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ025"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP025"].ToString( )*/ tableQueryOne.Rows[i]["AP025"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP025"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP025"].ToString( );
                    }
                }
            }
            num = gridView1.FocusedRowHandle;
            SelectAll.PayMentWages wageQuerys = new SelectAll.PayMentWages( );
            wageQuerys.StartPosition = FormStartPosition.CenterScreen;
            wageQuerys.idxSt = idxSt;
            wageQuerys.PassDataBetweenForm += new SelectAll.PayMentWages.PassDataBetweenFormHandler( wageQuerys_PassDataBetWeenForm );
            wageQuerys.sign = "2";
            wageQuerys.ShowDialog( );
        }
        private void wageQuerys_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView1.SetRowCellValue( num ,gridView1.Columns["YZ017"] ,e.ConOne );
            gridView1.SetRowCellValue( num ,gridView1.Columns["YZ025"] ,e.ConTwo );
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["YZ001"] ,_model.YZ001 );
            if ( gridView1.RowCount > 0 )
            {
                _model.YZ031 = "";
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( i == 0 )
                        _model.YZ031 = gridView1.GetDataRow( i )["YZ031"].ToString( );
                    else if ( i > 0 && i < gridView1.RowCount  )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ031"].ToString( ) ) && !string.IsNullOrEmpty( _model.YZ031 ) && Convert.ToInt32( gridView1.GetDataRow( i )["YZ031"].ToString( ) ) > Convert.ToInt32( _model.YZ031 ) )
                            _model.YZ031 = gridView1.GetDataRow( i )["YZ031"].ToString( );
                    }
                }

                if ( !string.IsNullOrEmpty( _model.YZ031 ) )
                {
                    _model . YZ031 = ( Convert . ToInt32 ( _model . YZ031 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                    //if ( Convert.ToInt32( _model.YZ031 ) < 9 )
                    //    _model.YZ031 = "00" + ( Convert.ToInt32( _model.YZ031 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _model.YZ031 ) >= 9 && Convert.ToInt32( _model.YZ031 ) < 99 )
                    //    _model.YZ031 = "0" + ( Convert.ToInt32( _model.YZ031 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _model.YZ031 ) > 99 )
                    //    _model.YZ031 = ( Convert.ToInt32( _model.YZ031 ) + 1 ).ToString( );
                    view.SetRowCellValue( e.RowHandle ,view.Columns["YZ031"] ,_model.YZ031 );
                }
                else
                    view.SetRowCellValue( e.RowHandle ,view.Columns["YZ031"] ,"001" );
            }
            else
                view.SetRowCellValue( e.RowHandle ,view.Columns["YZ031"] ,"001" );
        }
        private void repositoryItemComboBox1_SelectedIndexChanged ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedColumn == gridView1.Columns["YZ003"] )
            {
                int num = gridView1.FocusedRowHandle;
                string signone = gridView1.GetDataRow( num )["YZ022"].ToString( );
                string signtwo = gridView1.GetDataRow( num )["YZ023"].ToString( );
                string signtre = gridView1.GetDataRow( num )["YZ024"].ToString( );
                string signFor = gridView1.GetDataRow( num )["YZ025"].ToString( );
                string signFiv = gridView1.GetDataRow( num )["YZ027"].ToString( );
                string signSix = gridView1.GetDataRow( num )["YZ030"].ToString( );
                string signSev = gridView1 . GetDataRow ( num ) [ "YZ032" ] . ToString ( );
                int i = ( ( DevExpress.XtraEditors.ComboBoxEdit ) sender ).SelectedIndex;
                if ( i == 2 )
                {
                    if ( string.IsNullOrEmpty( gridView1.GetDataRow( num )["YZ009"].ToString( ) ) )
                    {
                        MessageBox.Show( "结款日期不可为空" );
                        gridView1.SetRowCellValue( num ,gridView1.Columns["YZ003"] ,"审核" );
                        return;
                    }
                    result = _bll . UpdateStateSe ( signone , signtwo , signtre , signFor , signFiv , signSix , Convert . ToDateTime ( gridView1 . GetDataRow ( num ) [ "YZ009" ] . ToString ( ) ) , signSev );
                    if ( result == false )
                    {
                        MessageBox.Show( "更改状态失败,请重试" );
                        gridView1.SetRowCellValue( num ,gridView1.Columns["YZ003"] ,"审核" );
                    }
                }
                else if ( i == 1 )
                {
                    result = _bll . UpdateState ( signone , signtwo , signtre , signFor , signFiv , "审核" , signSix , signSev );
                }
                else if ( i == 0 )
                {
                    result = _bll . UpdateState ( signone , signtwo , signtre , signFor , signFiv , signSix , signSev );
                }
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            //focusedNum = gridView1.FocusedRowHandle;
        }
        private void gridView1_FocusedRowChanged ( object sender ,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            //if ( gridView1.RowCount < 1 )
            //    return;
            //if ( e.PrevFocusedRowHandle != e.FocusedRowHandle && e.FocusedRowHandle == focusedNum )
            //{

            //}
        }
        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( gridView1.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = gridView1.FocusedRowHandle;
                    gridView1.UpdateCurrentRow( );
                    if ( num >= 0 && num <= tableQuery.Rows.Count - 1 )
                    {
                        _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        //_model.YZ031 = gridView1.GetDataRow( num )["YZ031"].ToString( ).Trim( );
                        if ( gridView1 . GetDataRow ( num ) [ "YZ003" ] . ToString ( ) . Equals ( "执行" ) )
                        {
                            if ( Logins . number . Equals ( "MLL-0001" ) )
                            {
                                if ( MessageBox . Show ( "删除?" ,"此单状态为执行,确认删除?" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
                                {
                                    //gridView1 . DeleteRow ( num );
                                    //tableQuery . Rows . RemoveAt ( num );
                                    tableQuery . Rows . Remove ( tableQuery . Select ( "idx=" + _model . IDX + "" ) [ 0 ] );
                                }
                            }
                            else
                                MessageBox . Show ( "单据状态为执行,您没有权限删除,需要总经理删除" );
                        }
                        else
                        {
                            //gridView1 . DeleteRow ( num );
                            //tableQuery . Rows . RemoveAt ( num );
                            tableQuery . Rows . Remove ( tableQuery . Select ( "idx=" + _model . IDX + "" ) [ 0 ] );
                        }     
                    }
                }
            }
        }
        private void gridView1_ShowingEditor ( object sender ,CancelEventArgs e )
        {
            row = this.gridView1.GetDataRow( this.gridView1.FocusedRowHandle );
            if ( row != null )
            {
                string str = row["YZ003"].ToString( );
                if ( !string.IsNullOrEmpty( str ) && str == "执行" && Logins.number != "MLL-0001" )
                {
                    e.Cancel = true;//该行不可编辑
                }
            }          
        }
        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            //assignOne( );
        }
        void assignOne ( )
        {
            U0.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( YZ013.Summary[0].SummaryValue ) + Convert.ToDecimal( YZ015.Summary[0].SummaryValue ) ).ToString( ) );
            U2.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( /*Convert.ToDecimal( YZ012.Summary[0].SummaryValue ) + Convert.ToDecimal( YZ013.Summary[0].SummaryValue ) +*/ Convert.ToDecimal( U0.Summary[0].SummaryValue ) + Convert.ToDecimal( U1.Summary[0].SummaryValue ) + Convert.ToDecimal( U2.Summary[0].SummaryValue ) + Convert.ToDecimal( U3.Summary[0].SummaryValue ) /*+ Convert.ToDecimal( U28.Summary[0].SummaryValue )*/ ).ToString( ) );
            //U4.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U31.Summary[0].SummaryValue ) + Convert.ToDecimal( U4.Summary[0].SummaryValue ) + Convert.ToDecimal( U5.Summary[0].SummaryValue ) + Convert.ToDecimal( U6.Summary[0].SummaryValue ) + Convert.ToDecimal( U7.Summary[0].SummaryValue ) + Convert.ToDecimal( U8.Summary[0].SummaryValue ) + Convert.ToDecimal( U9.Summary[0].SummaryValue ) + Convert.ToDecimal( U10.Summary[0].SummaryValue ) ).ToString( ) );
            U28.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U28.Summary[0].SummaryValue ) + Convert.ToDecimal( U31.Summary[0].SummaryValue ) + Convert.ToDecimal( U4.Summary[0].SummaryValue ) + Convert.ToDecimal( U5.Summary[0].SummaryValue ) + Convert.ToDecimal( U6.Summary[0].SummaryValue ) + Convert.ToDecimal( U7.Summary[0].SummaryValue ) + Convert.ToDecimal( U8.Summary[0].SummaryValue ) + Convert.ToDecimal( U9.Summary[0].SummaryValue ) + Convert.ToDecimal( U10.Summary[0].SummaryValue ) ).ToString( ) );
            if ( tableQuery.Rows.Count > 0 && !string.IsNullOrEmpty( gridView1.GetDataRow( 0 )["YZ009"].ToString( ) ) )
            {
                dtSumTable = null;
                DateTime dt = Convert.ToDateTime( gridView1.GetDataRow( 0 )["YZ009"].ToString( ) );
                //if ( dt.Month == 12 )
                //{
                //    dtOne = dt.AddDays( 1 - ( dt.Day ) ).AddDays( DateTime.DaysInMonth( dt.Year ,dt.Month ) - 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtSumTable = _bll.GetDataTableSumOne( dtOne ,dtTwo );
                //    dtTableOne( dtSumTable );
                //}
                //else if ( dt.Month == 1 )
                //{
                //    dtOne = dt.AddYears( -1 ).AddMonths( -dt.Month - 1 + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day );
                //    dtSumTable = _bll.GetDataTableSumOne( dtOne ,dtTwo );
                //    dtTableOne( dtSumTable );
                //}
                //else
                //{
                dtOne = new DateTime( dt.Year ,1 ,1 );
                dtTwo = new DateTime( dt.Year ,12 ,31 );
                dtSumTable = _bll.GetDataTableSumOne( dtOne ,dtTwo );
                dtTableOne( dtSumTable );
                //}
            }
        }
        void dtTableOne (DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                YZ011.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ011"].ToString( ) );
                YZ012.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ012"].ToString( ) );
                YZ013.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ013"].ToString( ) );
                YZ014.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ014"].ToString( ) );
                YZ015.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ015"].ToString( ) );
                U28.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U28"].ToString( ) );
                YZ017.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["YZ017"].ToString( ) );
                U31.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U31"].ToString( ) );
                U0.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U0"].ToString( ) );
                U1.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U1"].ToString( ) );
                U2.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U2"].ToString( ) );
                U3.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U3"].ToString( ) );
                U4.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U4"].ToString( ) );
                U5.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U5"].ToString( ) );
                U6.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U6"].ToString( ) );
                U7.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U7"].ToString( ) );
                U8.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U8"].ToString( ) );
                U9.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U9"].ToString( ) );
                U10.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U10"].ToString( ) );
                U11.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U11"].ToString( ) );
                YZ015.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["YZ012"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["YZ013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U0"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U1"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U2"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U3"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U28"].ToString( ) ) ).ToString( ) );
                U31.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["U31"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U4"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U5"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U6"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U7"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U8"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U9"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U10"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U11"].ToString( ) ) ).ToString( ) );

                if ( tableQueryFiv != null && tableQueryFiv.Rows.Count > 0 )
                {
                    decimal d1 = Convert.ToDecimal( YZ013.Summary[0].SummaryValue );
                    decimal d2 = Convert.ToDecimal( YZ015.Summary[0].SummaryValue );
                    decimal d3 = Convert.ToDecimal( U0.Summary[0].SummaryValue );
                    decimal d4 = Convert.ToDecimal( U1.Summary[0].SummaryValue );
                    decimal d5 = Convert.ToDecimal( U2.Summary[0].SummaryValue );
                    decimal d6 = Convert.ToDecimal( U3.Summary[0].SummaryValue );
                    decimal d7 = Convert.ToDecimal( U28.Summary[0].SummaryValue );
                    decimal d8 = Convert.ToDecimal( U31.Summary[0].SummaryValue );
                    decimal d9 = Convert.ToDecimal( U4.Summary[0].SummaryValue );
                    decimal d10 = Convert.ToDecimal( U5.Summary[0].SummaryValue );
                    decimal d11 = Convert.ToDecimal( U6.Summary[0].SummaryValue );
                    decimal d12 = Convert.ToDecimal( U7.Summary[0].SummaryValue );
                    decimal d13 = Convert.ToDecimal( U8.Summary[0].SummaryValue );
                    decimal d14 = Convert.ToDecimal( U9.Summary[0].SummaryValue );
                    decimal d15= Convert.ToDecimal( U10.Summary[0].SummaryValue );
                    decimal d16 = Convert.ToDecimal( U11.Summary[0].SummaryValue );
                    decimal d17 = Convert.ToDecimal( table.Rows[0]["YZ012"].ToString( ) );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F0"] ,d1 + d2 );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F1"] ,d1 + d3 + d4 + d5 + d6 );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F2"] ,d7 + d8 + d9 + d10 + d11 + d12 + d13 + d14 + d15 );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F4"] ,d1 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12 + d13 + d16 + d15 + d14 );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F9"] ,d17 + Convert.ToDecimal( table.Rows[0]["U0"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U1"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U2"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U3"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U28"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U31"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U4"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U5"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U6"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U7"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U8"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U10"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U11"].ToString( ) ) );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F10"] ,Convert.ToDecimal( table.Rows[0]["YZ013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["YZ015"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["YZ017"].ToString( ) ) );
                    DataTable tableF12 = _bll.GetDataTableOfF12( );
                    if ( tableF12 != null && tableF12.Rows.Count > 0 )
                    {
                        if ( string.IsNullOrEmpty( tableF12.Rows[0]["BB"].ToString( ) ) )
                            gridView5.SetRowCellValue( 0 ,gridView5.Columns["F12"] ,0 );
                        else
                            gridView5.SetRowCellValue( 0 ,gridView5.Columns["F12"] ,tableF12.Rows[0]["BB"].ToString( ) );
                    }
                    else
                        gridView5.SetRowCellValue( 0 ,gridView5.Columns["F12"] ,0 );
                    gridView5.SetRowCellValue( 0 ,gridView5.Columns["F13"] ,d16 );

                    if ( tableQueryTre != null && tableQueryTre.Rows.Count > 0 )
                    {
                        decimal a11 = 0M;
                        for ( int i = 0 ; i < tableQueryTre.Rows.Count ; i++ )
                        {
                            if ( tableQueryTre.Rows[i]["AO003"].ToString( ) == "审核" )
                            {
                                a11 = a11 + ( string.IsNullOrEmpty( tableQueryTre.Rows[ i ]["AO011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTre.Rows[i]["AO011"].ToString( ) ) ) + ( string.IsNullOrEmpty( tableQueryTre.Rows[i]["AO012"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTre.Rows[i]["AO012"].ToString( ) ) ) + ( string.IsNullOrEmpty( tableQueryTre.Rows[i]["AO014"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTre.Rows[i]["AO014"].ToString( ) ) );
                            }
                        }
                        gridView5.SetRowCellValue( 0 ,gridView5.Columns["F11"] ,a11.ToString( ) );
                        gridView5.SetRowCellValue( 0 ,gridView5.Columns["F4"] ,d1 + d3 + d4 + d5 + d6 + d7 + d8 + d9 + d10 + d11 + d12 + d13 + d16 + d15 + d14 + a11 );
                    }
                }
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            //回写扣借支款到借款木佬佬还款额
            if ( e . Column . FieldName . Equals ( "YZ003" ) )
            {
                int num = e . RowHandle;
                if ( num >= 0 && num <= gridView1 . DataRowCount - 1 )
                {
                    _model . YZ003 = gridView1 . GetDataRow ( num ) [ "YZ003" ] . ToString ( );
                    if ( _model . YZ003 . Equals ( "审核" ) || _model . YZ003 . Equals ( "执行" ) )
                    {
                        _model . YZ005 = gridView1 . GetDataRow ( num ) [ "YZ005" ] . ToString ( );
                        _model . YZ006 = gridView1 . GetDataRow ( num ) [ "YZ006" ] . ToString ( );
                        _model . YZ021 = gridView1 . GetDataRow ( num ) [ "YZ021" ] . ToString ( );
                        _model . YZ026 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "YZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( num ) [ "YZ026" ] . ToString ( ) );
                        _model . YZ023 = gridView1 . GetDataRow ( num ) [ "YZ023" ] . ToString ( );
                        if ( !string . IsNullOrEmpty ( _model . YZ023 . Trim ( ) ) && _model . YZ026 != 0 )
                        {
                            result = _bll . UpdateJkTo ( _model . YZ005 ,_model . YZ006 ,_model . YZ021 ,_model . YZ026 );
                        }
                    }
                }
            }
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        private void gridView2_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["AP001"] ,_modelOne.AP001 );
            if ( gridView2.RowCount > 0 )
            {
                _modelOne.AP031 = "";
                for ( int i = 0 ; i < gridView2.RowCount ; i++ )
                {
                    if ( i == 0 )
                        _modelOne.AP031 = gridView2.GetDataRow( i )["AP031"].ToString( );
                    else if ( i > 0 && i < gridView2.RowCount  )
                    {
                        if ( !string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP031"].ToString( ) ) && !string.IsNullOrEmpty( _modelOne.AP031 ) && Convert.ToInt32( gridView2.GetDataRow( i )["AP031"].ToString( ) ) > Convert.ToInt32( _modelOne.AP031 ) )
                            _modelOne.AP031 = gridView2.GetDataRow( i )["AP031"].ToString( );
                    }
                }

                if ( !string.IsNullOrEmpty( _modelOne.AP031 ) )
                {
                    _modelOne . AP031 = ( Convert . ToInt32 ( _modelOne . AP031 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                    //if ( Convert.ToInt32( _modelOne.AP031 ) < 9 )
                    //    _modelOne.AP031 = "00" + ( Convert.ToInt32( _modelOne.AP031 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelOne.AP031 ) >= 9 && Convert.ToInt32( _modelOne.AP031 ) < 99 )
                    //    _modelOne.AP031 = "0" + ( Convert.ToInt32( _modelOne.AP031 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelOne.AP031 ) > 99 )
                    //    _modelOne.AP031 = ( Convert.ToInt32( _modelOne.AP031 ) + 1 ).ToString( );
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AP031"] ,_modelOne.AP031 );
                }
                else
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AP031"] ,"001" );
            }
            else
                view.SetRowCellValue( e.RowHandle ,view.Columns["AP031"] ,"001" );
        }
        private void repositoryItemButtonEdit5_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ022"].ToString( )*/ tableQuery.Rows[i]["YZ022"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ022"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ022"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP022"].ToString( )*/ tableQueryOne.Rows[i]["AP022"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP022"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP022"].ToString( );
                    }
                }
            }
            num = gridView2.FocusedRowHandle;
            SelectAll.PayMentCheckOutAll checkOutQuery = new SelectAll.PayMentCheckOutAll( );
            checkOutQuery.StartPosition = FormStartPosition.CenterScreen;
            if ( gridView2.FocusedRowHandle <= tableQueryOne.Rows.Count && gridView2.FocusedRowHandle >= 0 )
                checkOutQuery.supplier = gridView2.GetDataRow( gridView2.FocusedRowHandle )["AP006"].ToString( );
            else
                checkOutQuery.supplier = "";
            checkOutQuery.idxSt = idxSt;
            checkOutQuery.PassDataBetweenForm += new SelectAll.PayMentCheckOutAll.PassDataBetweenFormHandler( checkOutQueryOne_PassDataBetweenForm );
            checkOutQuery.ShowDialog( );
        }
        private void checkOutQueryOne_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConSix == "1" )
            {
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP006" ] ,e . ConFor );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP010" ] ,e . ConOne );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP015" ] ,e . ConTwo );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP017" ] ,e . ConTre );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP022" ] ,e . ConFiv );
            }
            if ( e . ConSix == "2" )
            {
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP006" ] ,e . ConOne );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP007" ] ,e . ConTwo );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP010" ] ,0 );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP015" ] ,e . ConTre );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP027" ] ,e . ConFor );
            }
            if ( e . ConSix == "3" )
            {
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP013" ] ,e . ConTwo );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP015" ] ,e . ConTre );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP030" ] ,e . ConOne );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP006" ] ,e . ConFor );
            }
            if ( e . ConSix == "4" )
            {
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP017" ] ,e . ConOne );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP006" ] ,e . ConTwo );
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP032" ] ,e . ConFor );
            }
        }
        private void repositoryItemButtonEdit6_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ023"].ToString( )*/ tableQuery.Rows[i]["YZ023"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ023"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ023"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP023"].ToString( )*/ tableQueryOne.Rows[i]["AP023"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP023"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP023"].ToString( );
                    }
                }
            }
            checkWho = "ap014";
            num = gridView2.FocusedRowHandle;
            SelectAll.PayMentDetailed detailQuery = new SelectAll.PayMentDetailed( );
            detailQuery.StartPosition = FormStartPosition.CenterScreen;
            detailQuery.idxSt = idxSt;
            detailQuery.PassDataBetweenForm += new SelectAll.PayMentDetailed.PassDataBetweenFormHandler( detailQueryOne_PassDataBetweenForm );
            detailQuery.ShowDialog( );
        }
        private void repositoryItemButtonEdit10_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( /*gridView1.GetDataRow( i )["YZ023"].ToString( )*/ tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( );
                        else
                            idxSt = idxSt + "," + tableQuery . Rows [ i ] [ "YZ023" ] . ToString ( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne . Rows . Count ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( /*gridView2.GetDataRow( i )["AP023"].ToString( )*/ tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( );
                        else
                            idxSt = idxSt + "," + tableQueryOne . Rows [ i ] [ "AP023" ] . ToString ( );
                    }
                }
            }
            checkWho = "ap026";
            num = gridView2 . FocusedRowHandle;
            SelectAll . PayMentDetailed detailQuery = new SelectAll . PayMentDetailed ( );
            detailQuery . StartPosition = FormStartPosition . CenterScreen;
            detailQuery . idxSt = idxSt;
            detailQuery . PassDataBetweenForm += new SelectAll . PayMentDetailed . PassDataBetweenFormHandler ( detailQueryOne_PassDataBetweenForm );
            detailQuery . ShowDialog ( );
        }
        private void detailQueryOne_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( checkWho . Equals ( "ap014" ) )
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP014" ] ,e . ConTre );
            else if ( checkWho . Equals ( "ap026" ) )
                gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP026" ] ,e . ConTre );
            gridView2 . SetRowCellValue ( num ,gridView2 . Columns [ "AP023" ] ,e . ConTwo );
            //gridView2.SetRowCellValue( num ,gridView2.Columns["AP026"] ,e.ConTre );
        }
        private void repositoryItemButtonEdit7_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ024"].ToString( )*/ tableQuery.Rows[i]["YZ024"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ024"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ024"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP024"].ToString( )*/ tableQueryOne.Rows[i]["AP024"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP024"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP024"].ToString( );
                    }
                }
            }
            num = gridView2.FocusedRowHandle;
            SelectAll.PayMentWages wageQuery = new SelectAll.PayMentWages( );
            wageQuery.StartPosition = FormStartPosition.CenterScreen;
            wageQuery.idxSt = idxSt;
            wageQuery.PassDataBetweenForm += new SelectAll.PayMentWages.PassDataBetweenFormHandler( wageQueryOne_PassDataBetWeenForm );
            wageQuery.sign = "3";
            wageQuery.ShowDialog( );
        }
        private void wageQueryOne_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView2.SetRowCellValue( num ,gridView2.Columns["AP017"] ,e.ConOne );
            gridView2.SetRowCellValue( num ,gridView2.Columns["AP024"] ,e.ConTwo );
        }
        private void repositoryItemButtonEdit8_Click ( object sender ,EventArgs e )
        {
            string idxSt = "";
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView1.GetDataRow( i )["YZ025"].ToString( ) */ tableQuery.Rows[i]["YZ025"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQuery.Rows[i]["YZ025"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQuery.Rows[i]["YZ025"].ToString( );
                    }
                }
            }
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( /*gridView2.GetDataRow( i )["AP025"].ToString( )*/ tableQueryOne.Rows[i]["AP025"].ToString( ) ) )
                    {
                        if ( idxSt == "" )
                            idxSt = tableQueryOne.Rows[i]["AP025"].ToString( );
                        else
                            idxSt = idxSt + "," + tableQueryOne.Rows[i]["AP025"].ToString( );
                    }
                }
            }
            num = gridView2.FocusedRowHandle;
            SelectAll.PayMentWages wageQuerys = new SelectAll.PayMentWages( );
            wageQuerys.StartPosition = FormStartPosition.CenterScreen;
            wageQuerys.idxSt = idxSt;
            wageQuerys.PassDataBetweenForm += new SelectAll.PayMentWages.PassDataBetweenFormHandler( wageQuerysOne_PassDataBetWeenForm );
            wageQuerys.sign = "4";
            wageQuerys.ShowDialog( );
        }
        private void wageQuerysOne_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView2.SetRowCellValue( num ,gridView2.Columns["AP017"] ,e.ConOne );
            gridView2.SetRowCellValue( num ,gridView2.Columns["AP025"] ,e.ConTwo );
        }
        private void repositoryItemComboBox8_SelectedIndexChanged ( object sender ,EventArgs e )
        {
            if ( gridView2.FocusedColumn == gridView2.Columns["AP003"] )
            {
                int num = gridView2.FocusedRowHandle;
                string signone = gridView2.GetDataRow( num )["AP022"].ToString( );
                string signtwo = gridView2.GetDataRow( num )["AP023"].ToString( );
                string signtre = gridView2.GetDataRow( num )["AP024"].ToString( );
                string signFor = gridView2.GetDataRow( num )["AP025"].ToString( );
                string signFiv = gridView2.GetDataRow( num )["AP027"].ToString( );
                string signSix = gridView2.GetDataRow( num )["AP030"].ToString( );
                string signSev = gridView2 . GetDataRow ( num ) [ "AP032" ] . ToString ( );
                int i = ( ( DevExpress.XtraEditors.ComboBoxEdit ) sender ).SelectedIndex;
                if ( i==2 )
                {
                    if ( string.IsNullOrEmpty( gridView2.GetDataRow( num )["AP009"].ToString( ) ) )
                    {
                        MessageBox.Show( "结款日期不可为空" );
                        gridView2.SetRowCellValue( num ,gridView2.Columns["AP003"].ToString( ) ,"审核" );
                        return;
                    }
                    result = _bll.UpdateStateSe( signone ,signtwo ,signtre ,signFor ,signFiv ,signSix ,Convert.ToDateTime( gridView2.GetDataRow( num )["AP009"].ToString( ) ) , signSev );
                    if ( result == false )
                    {
                        MessageBox.Show( "更改状态失败,请重试" );
                        gridView2.SetRowCellValue( num ,gridView2.Columns["AP003"].ToString( ) ,"审核" );
                    }
                }
                else if (  i==1 )
                {
                    result = _bll . UpdateState ( signone ,signtwo ,signtre ,signFor ,signFiv ,"审核" ,signSix ,signSev );
                }
                else if ( i == 0  )
                {
                    result = _bll . UpdateState ( signone , signtwo , signtre , signFor , signFiv , signSix , signSev );
                }
            }
        }
        private void gridView2_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( gridView2.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = gridView2.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryOne.Rows.Count - 1 )
                    {
                        _modelOne.IDX = string.IsNullOrEmpty( gridView2.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView2.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        if ( gridView2.GetDataRow( num )["AP003"].ToString( ) == "执行" )
                        {
                            if ( Logins.number == "MLL-0001" )
                            {
                                if ( MessageBox.Show( "删除?" ,"此单状态为执行,确认删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                {
                                    //gridView2.DeleteRow( num );
                                    tableQueryOne . Rows . Remove ( tableQueryOne . Select ( "idx=" + _modelOne . IDX + "" ) [ 0 ] );
                                    //if ( _modelOne.IDX > 0 )
                                    //{
                                    //    tableQueryOne.Rows.RemoveAt( num );
                                    //    if ( tableTwo == "" )
                                    //        tableTwo = _modelOne.IDX.ToString( );
                                    //    else
                                    //        tableTwo = tableTwo + "," + _modelOne.IDX.ToString( );
                                    //}
                                }
                            }
                            else
                                MessageBox.Show( "单据状态为执行,您没有权限删除,需要总经理删除" );
                        }
                        else
                        {
                            //gridView2.DeleteRow( num );
                            tableQueryOne . Rows . Remove ( tableQueryOne . Select ( "idx=" + _modelOne . IDX + "" ) [ 0 ] );
                            //if ( _modelOne.IDX > 0 )
                            //{
                            //    tableQueryOne.Rows.RemoveAt( num );
                            //    if ( tableTwo == "" )
                            //        tableTwo = _modelOne.IDX.ToString( );
                            //    else
                            //        tableTwo = tableTwo + "," + _modelOne.IDX.ToString( );
                            //}
                        }
                    }
                }
            }
        }
        private void gridView2_ShowingEditor ( object sender ,CancelEventArgs e )
        {
            row = this.gridView2.GetDataRow( this.gridView2.FocusedRowHandle );
            if ( row != null )
            {
                string str = row["AP003"].ToString( );
                if ( !string.IsNullOrEmpty( str ) && str == "执行" && Logins.number != "MLL-0001" )
                {
                    e.Cancel = true;//该行不可编辑
                }
            }
        }
        void assignTwo ( )
        {
            U12.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( AP013.Summary[0].SummaryValue ) + Convert.ToDecimal( AP015.Summary[0].SummaryValue ) ).ToString( ) );
            U14.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( /*Convert.ToDecimal( AP012.Summary[0].SummaryValue ) + Convert.ToDecimal( AP013.Summary[0].SummaryValue ) +*/ Convert.ToDecimal( U12.Summary[0].SummaryValue ) + Convert.ToDecimal( U13.Summary[0].SummaryValue ) + Convert.ToDecimal( U14.Summary[0].SummaryValue ) + Convert.ToDecimal( U15.Summary[0].SummaryValue ) /*+ Convert.ToDecimal( U32.Summary[0].SummaryValue )*/ ).ToString( ) );
            //U16.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U33.Summary[0].SummaryValue ) + Convert.ToDecimal( U16.Summary[0].SummaryValue ) + Convert.ToDecimal( U17.Summary[0].SummaryValue ) + Convert.ToDecimal( U18.Summary[0].SummaryValue ) + Convert.ToDecimal( U19.Summary[0].SummaryValue ) + Convert.ToDecimal( U20.Summary[0].SummaryValue ) + Convert.ToDecimal( U21.Summary[0].SummaryValue ) + Convert.ToDecimal( U22.Summary[0].SummaryValue ) ).ToString( ) );
            U32.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U33.Summary[0].SummaryValue ) + Convert.ToDecimal( U16.Summary[0].SummaryValue ) + Convert.ToDecimal( U17.Summary[0].SummaryValue ) + Convert.ToDecimal( U18.Summary[0].SummaryValue ) + Convert.ToDecimal( U19.Summary[0].SummaryValue ) + Convert.ToDecimal( U20.Summary[0].SummaryValue ) + Convert.ToDecimal( U21.Summary[0].SummaryValue ) + Convert.ToDecimal( U22.Summary[0].SummaryValue ) + Convert.ToDecimal( U32.Summary[0].SummaryValue ) ).ToString( ) );
            if ( tableQueryOne.Rows.Count > 0 && !string.IsNullOrEmpty( gridView2.GetDataRow( 0 )["AP009"].ToString( ) ) )
            {
                dtSumTable = null;
                DateTime dt = Convert.ToDateTime( gridView2.GetDataRow( 0 )["AP009"].ToString( ) );
                //if ( dt.Month == 12 )
                //{
                //    dtOne = dt.AddDays( 1 - ( dt.Day ) ).AddDays( DateTime.DaysInMonth( dt.Year ,dt.Month ) - 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtSumTable = _bll.GetDataTableSumTwo( dtOne ,dtTwo );
                //    dtTableTwo( dtSumTable );
                //}
                //else if ( dt.Month == 1 )
                //{
                //    dtOne = dt.AddYears( -1 ).AddMonths( -dt.Month - 1 + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day );
                //    dtSumTable = _bll.GetDataTableSumTwo( dtOne ,dtTwo );
                //    dtTableTwo( dtSumTable );
                //}
                //else
                //{
                //    dtOne = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( +1 );
                dtOne = new DateTime( dt.Year ,1 ,1 );
                dtTwo = new DateTime( dt.Year ,12 ,31 );
                dtSumTable = _bll.GetDataTableSumTwo( dtOne ,dtTwo );
                dtTableTwo( dtSumTable );
                //}
            }
        }
        void dtTableTwo ( DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                AP011.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP011"].ToString( ) );
                AP012.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP012"].ToString( ) );
                AP013.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP013"].ToString( ) );
                AP014.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP014"].ToString( ) );
                AP015.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP015"].ToString( ) );
                U32.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U32"].ToString( ) );
                AP017.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AP017"].ToString( ) );
                U33.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U33"].ToString( ) );
                U25.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U25"].ToString( ) );
                U12.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U12"].ToString( ) );
                U13.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U13"].ToString( ) );
                U14.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U14"].ToString( ) );
                U15.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U15"].ToString( ) );
                U16.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U16"].ToString( ) );
                U17.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U17"].ToString( ) );
                U18.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U18"].ToString( ) );
                U19.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U19"].ToString( ) );
                U20.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U20"].ToString( ) );
                U21.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U21"].ToString( ) );
                U22.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U22"].ToString( ) );
                AP015.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["AP012"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AP013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U12"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U13"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U14"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U15"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U32"].ToString( ) ) ).ToString( ) );
                U33.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["U33"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U16"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U17"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U18"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U19"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U20"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U21"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U22"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U25"].ToString( ) ) ).ToString( ) );
                if ( tableQuerySix != null && tableQuerySix.Rows.Count > 0 )
                {
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H0"] ,Convert.ToDecimal( AP013.Summary[0].SummaryValue ) + Convert.ToDecimal( AP015.Summary[0].SummaryValue ) );
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H1"] ,/*Convert.ToDecimal( AP013.Summary[0].SummaryValue ) +*/ Convert.ToDecimal( U12.Summary[0].SummaryValue ) + Convert.ToDecimal( U13.Summary[0].SummaryValue ) + Convert.ToDecimal( U14.Summary[0].SummaryValue ) + Convert.ToDecimal( U15.Summary[0].SummaryValue ) /*+ Convert.ToDecimal( U32.Summary[0].SummaryValue )*/ );
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H2"] ,Convert.ToDecimal( U33.Summary[0].SummaryValue ) + Convert.ToDecimal( U16.Summary[0].SummaryValue ) + Convert.ToDecimal( U17.Summary[0].SummaryValue ) + Convert.ToDecimal( U18.Summary[0].SummaryValue ) + Convert.ToDecimal( U19.Summary[0].SummaryValue ) + Convert.ToDecimal( U20.Summary[0].SummaryValue ) + Convert.ToDecimal( U21.Summary[0].SummaryValue ) + Convert.ToDecimal( U22.Summary[0].SummaryValue ) /*+ Convert.ToDecimal( U25.Summary[0].SummaryValue )*/ + Convert.ToDecimal( U32.Summary[0].SummaryValue ) );
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H4"] ,Convert.ToDecimal( AP013.Summary[0].SummaryValue ) + Convert.ToDecimal( U12.Summary[0].SummaryValue ) + Convert.ToDecimal( U13.Summary[0].SummaryValue ) + Convert.ToDecimal( U14.Summary[0].SummaryValue ) + Convert.ToDecimal( U15.Summary[0].SummaryValue ) + Convert.ToDecimal( U32.Summary[0].SummaryValue ) + Convert.ToDecimal( U33.Summary[0].SummaryValue ) + Convert.ToDecimal( U16.Summary[0].SummaryValue ) + Convert.ToDecimal( U17.Summary[0].SummaryValue ) + Convert.ToDecimal( U18.Summary[0].SummaryValue ) + Convert.ToDecimal( U19.Summary[0].SummaryValue ) + Convert.ToDecimal( U20.Summary[0].SummaryValue ) + Convert.ToDecimal( U25.Summary[0].SummaryValue ) + Convert.ToDecimal( U22.Summary[0].SummaryValue ) + Convert.ToDecimal( U21.Summary[0].SummaryValue ) );
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H9"] ,Convert.ToDecimal( table.Rows[0]["AP012"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U12"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U13"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U14"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U15"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U32"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U33"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U16"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U17"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U18"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U19"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U20"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U22"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U25"].ToString( ) ) );
                    gridView6.SetRowCellValue( 0 ,gridView6.Columns["H10"] ,Convert.ToDecimal( table.Rows[0]["AP013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AP015"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AP017"].ToString( ) ) );
                    DataTable tableF12 = _bll.GetDataTableOfF12( );
                    if ( tableF12 != null && tableF12.Rows.Count > 0 )
                    {
                        if(string.IsNullOrEmpty( tableF12.Rows[0]["BB"].ToString( ) ) )
                            gridView6.SetRowCellValue( 0 ,gridView6.Columns["H12"] ,0 );
                        else
                            gridView6.SetRowCellValue( 0 ,gridView6.Columns["H12"] ,tableF12.Rows[0]["BB"].ToString( ) );
                    } 
                    else
                        gridView6.SetRowCellValue( 0 ,gridView6.Columns["H12"] ,0 );
                    gridView6 . SetRowCellValue ( 0 , gridView6 . Columns [ "H13" ] , Convert . ToDecimal ( U25 . Summary [ 0 ] . SummaryValue ) );
                    if ( tableQueryFor != null && tableQueryFor.Rows.Count > 0 )
                    {
                        decimal a11 = 0M;
                        for ( int i = 0 ; i < tableQueryFor.Rows.Count ; i++ )
                        {
                            if ( tableQueryFor.Rows[i]["AR003"].ToString( ) == "审核" )
                            {
                                a11 = a11 + ( string.IsNullOrEmpty( tableQueryFor.Rows[i]["AR011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryFor.Rows[i]["AR011"].ToString( ) ) ) + ( string.IsNullOrEmpty( tableQueryFor.Rows[i]["AR012"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryFor.Rows[i]["AR012"].ToString( ) ) ) + ( string.IsNullOrEmpty( tableQueryFor.Rows[i]["AR014"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryFor.Rows[i]["AR014"].ToString( ) ) );
                            }
                        }
                        gridView6.SetRowCellValue( 0 ,gridView6.Columns["H11"] ,a11.ToString( ) );
                        gridView6.SetRowCellValue( 0 ,gridView6.Columns["H4"] ,Convert.ToDecimal( AP013.Summary[0].SummaryValue ) + Convert.ToDecimal( U12.Summary[0].SummaryValue ) + Convert.ToDecimal( U13.Summary[0].SummaryValue ) + Convert.ToDecimal( U14.Summary[0].SummaryValue ) + Convert.ToDecimal( U15.Summary[0].SummaryValue ) + Convert.ToDecimal( U32.Summary[0].SummaryValue ) + Convert.ToDecimal( U33.Summary[0].SummaryValue ) + Convert.ToDecimal( U16.Summary[0].SummaryValue ) + Convert.ToDecimal( U17.Summary[0].SummaryValue ) + Convert.ToDecimal( U18.Summary[0].SummaryValue ) + Convert.ToDecimal( U19.Summary[0].SummaryValue ) + Convert.ToDecimal( U20.Summary[0].SummaryValue ) + Convert.ToDecimal( U25.Summary[0].SummaryValue ) + Convert.ToDecimal( U22.Summary[0].SummaryValue ) + Convert.ToDecimal( U21.Summary[0].SummaryValue ) + a11 );
                    }
                }
            }
        }
        private void gridView2_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            //回写扣借支款到借款木佬佬还款额
            if ( e . Column . FieldName . Equals ( "AP003" ) )
            {
                int num = e . RowHandle;
                if ( num >= 0 && num <= gridView2 . DataRowCount - 1 )
                {
                    _modelOne . AP003 = gridView2 . GetDataRow ( num ) [ "AP003" ] . ToString ( );
                    if ( _modelOne . AP003 . Equals ( "审核" ) || _modelOne . AP003 . Equals ( "执行" ) )
                    {
                        _modelOne . AP005 = gridView2 . GetDataRow ( num ) [ "AP005" ] . ToString ( );
                        _modelOne . AP006 = gridView2 . GetDataRow ( num ) [ "AP006" ] . ToString ( );
                        _modelOne . AP021 = gridView2 . GetDataRow ( num ) [ "AP021" ] . ToString ( );
                        _modelOne . AP026 = string . IsNullOrEmpty ( gridView2 . GetDataRow ( num ) [ "AP026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView2 . GetDataRow ( num ) [ "AP026" ] . ToString ( ) );
                        _modelOne . AP023 = gridView2 . GetDataRow ( num ) [ "AP023" ] . ToString ( );
                        if ( !string . IsNullOrEmpty ( _modelOne . AP023 . Trim ( ) ) && _modelOne . AP026 != 0 )
                        {
                            result = _bll . UpdateJkyTo ( _modelOne . AP005 ,_modelOne . AP006 ,_modelOne . AP021 ,_modelOne . AP026 );
                        }
                    }
                }
            }
        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        private void bandedGridView1_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["AQ001"] ,_modelTwo.AQ001 );
            if ( bandedGridView1.RowCount > 1 )
            {
                _modelTwo.AQ018 = "";
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( i == 0 )
                        _modelTwo.AQ018 = bandedGridView1.GetDataRow( i )["AQ018"].ToString( );
                    else if ( i > 0 && i < bandedGridView1.RowCount-1  )
                    {
                        if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["AQ018"].ToString( ) ) && !string.IsNullOrEmpty( _modelTwo.AQ018 ) && Convert.ToInt32( bandedGridView1.GetDataRow( i )["AQ018"].ToString( ) ) > Convert.ToInt32( _modelTwo.AQ018 ) )
                            _modelTwo.AQ018 = bandedGridView1.GetDataRow( i )["AQ018"].ToString( );
                    }
                }

                if ( !string.IsNullOrEmpty( _modelTwo.AQ018 ) )
                {
                    _modelTwo . AQ018 = ( Convert . ToInt32 ( _modelTwo . AQ018 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                    //if ( Convert.ToInt32( _modelTwo.AQ018 ) < 9 )
                    //    _modelTwo.AQ018 = "00" + ( Convert.ToInt32( _modelTwo.AQ018 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelTwo.AQ018 ) >= 9 && Convert.ToInt32( _modelTwo.AQ018 ) < 99 )
                    //    _modelTwo.AQ018 = "0" + ( Convert.ToInt32( _modelTwo.AQ018 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelTwo.AQ018 ) > 99 )
                    //    _modelTwo.AQ018 = ( Convert.ToInt32( _modelTwo.AQ018 ) + 1 ).ToString( );
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AQ018"] ,_modelTwo.AQ018 );
                }
                else
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AQ018"] ,"001" );
            }
            else
                view.SetRowCellValue( e.RowHandle ,view.Columns["AQ018"] ,"001" );
        }
        private void bandedGridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( bandedGridView1.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = bandedGridView1.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryTwo.Rows.Count - 1 )
                    {
                        _modelTwo.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        if ( bandedGridView1.GetDataRow( num )["AQ003"].ToString( ) == "执行" )
                        {
                            if ( Logins.number == "MLL-0001" )
                            {
                                if ( MessageBox.Show( "删除?" ,"此单状态为执行,确认删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                {
                                    //bandedGridView1.DeleteRow( num );
                                    tableQueryTwo . Rows . Remove ( tableQueryTwo . Select ( "idx=" + _modelTwo . IDX + "" ) [ 0 ] );
                                    //if ( _modelTwo.IDX > 0 )
                                    //{
                                    //    tableQueryTwo.Rows.RemoveAt( num );
                                    //    if ( tableTre == "" )
                                    //        tableTre = _modelTwo.IDX.ToString( );
                                    //    else
                                    //        tableTre = tableTre + "," + _modelTwo.IDX.ToString( );
                                    //}
                                }
                            }
                            else
                                MessageBox.Show( "单据状态为执行,您没有权限删除,需要总经理删除" );
                        }
                        else
                        {
                            //bandedGridView1.DeleteRow( num );
                            tableQueryTwo . Rows . Remove ( tableQueryTwo . Select ( "idx=" + _modelTwo . IDX + "" ) [ 0 ] );
                            //if ( _modelTwo.IDX > 0 )
                            //{
                            //    tableQueryTwo.Rows.RemoveAt( num );
                            //    if ( tableTre == "" )
                            //        tableTre = _modelTwo.IDX.ToString( );
                            //    else
                            //        tableTre = tableTre + "," + _modelTwo.IDX.ToString( );
                            //}
                        }
                    }
                }
            }
        }
        private void bandedGridView1_ShowingEditor ( object sender ,CancelEventArgs e )
        {
            row = this.bandedGridView1.GetDataRow( this.bandedGridView1.FocusedRowHandle );
            if ( row != null )
            {
                string str = row["AQ017"].ToString( );
                if ( !string.IsNullOrEmpty( str ) && str == "执行" && Logins.number != "MLL-0001" )
                {
                    e.Cancel = true;//该行不可编辑
                }
            }
        }
        /*--------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void gridView3_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        private void gridView3_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["AO001"] ,_modelTre.AO001 );
            if ( gridView3.RowCount > 0 )
            {
                _modelTre.AO021 = "";
                for ( int i = 0 ; i < gridView3.RowCount ; i++ )
                {
                    if ( i == 0 )
                        _modelTre.AO021 = gridView3.GetDataRow( i )["AO021"].ToString( );
                    else if ( i > 0 && i < gridView3.RowCount  )
                    {
                        if ( !string.IsNullOrEmpty( gridView3.GetDataRow( i )["AO021"].ToString( ) ) && !string.IsNullOrEmpty( _modelTre.AO021 ) && Convert.ToInt32( gridView3.GetDataRow( i )["AO021"].ToString( ) ) > Convert.ToInt32( _modelTre.AO021 ) )
                            _modelTre.AO021 = gridView3.GetDataRow( i )["AO021"].ToString( );
                    }
                }

                if ( !string.IsNullOrEmpty( _modelTre.AO021 ) )
                {
                    _modelTre . AO021 = ( Convert . ToInt32 ( _modelTre . AO021 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                    //if ( Convert.ToInt32( _modelTre.AO021 ) < 9 )
                    //    _modelTre.AO021 = "00" + ( Convert.ToInt32( _modelTre.AO021 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelTre.AO021 ) >= 9 && Convert.ToInt32( _modelTre.AO021 ) < 99 )
                    //    _modelTre.AO021 = "0" + ( Convert.ToInt32( _modelTre.AO021 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelTre.AO021 ) > 99 )
                    //    _modelTre.AO021 = ( Convert.ToInt32( _modelTre.AO021 ) + 1 ).ToString( );
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AO021"] ,_modelTre.AO021 );
                }
                else
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AO021"] ,"001" );
            }
            else
                view.SetRowCellValue( e.RowHandle ,view.Columns["AO021"] ,"001" );
        }
        private void gridView3_ShowingEditor ( object sender ,CancelEventArgs e )
        {
            row = this.gridView3.GetDataRow( this.gridView3.FocusedRowHandle );
            if ( row != null )
            {
                string str = row["AO003"].ToString( );
                if ( !string.IsNullOrEmpty( str ) && str == "执行" && Logins.number != "MLL-0001" )
                {
                    e.Cancel = true;//该行不可编辑
                }
            }
        }
        private void gridView3_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( gridView3.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = gridView3.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryTre.Rows.Count - 1 )
                    {
                        _modelTre.IDX = string.IsNullOrEmpty( gridView3.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        if ( gridView3.GetDataRow( num )["AO003"].ToString( ) == "执行" )
                        {
                            if ( Logins.number == "MLL-0001" )
                            {
                                if ( MessageBox.Show( "删除?" ,"此单状态为执行,确认删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                {
                                    //gridView3.DeleteRow( num );
                                    tableQueryTre . Rows . Remove ( tableQueryTre . Select ( "idx=" + _modelTre . IDX + "" ) [ 0 ] );
                                    //if ( _modelTre.IDX > 0 )
                                    //{
                                    //    tableQueryTre.Rows.RemoveAt( num );
                                    //    if ( tbaleFor == "" )
                                    //        tbaleFor = _modelTre.IDX.ToString( );
                                    //    else
                                    //        tbaleFor = tbaleFor + "," + _modelTre.IDX.ToString( );
                                    //}
                                }
                            }
                            else
                                MessageBox.Show( "单据状态为执行,您没有权限删除,需要总经理删除" );
                        }
                        else
                        {
                            //gridView3.DeleteRow( num );
                            tableQueryTre . Rows . Remove ( tableQueryTre . Select ( "idx=" + _modelTre . IDX + "" ) [ 0 ] );
                            //if ( _modelTre.IDX > 0 )
                            //{
                            //    tableQueryTre.Rows.RemoveAt( num );
                            //    if ( tbaleFor == "" )
                            //        tbaleFor = _modelTre.IDX.ToString( );
                            //    else
                            //        tbaleFor = tbaleFor + "," + _modelTre.IDX.ToString( );
                            //}
                        }
                    }
                }
            }
        }
        void assignTre ( )
        {
            AO013.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( AO011.Summary[0].SummaryValue ) + Convert.ToDecimal( AO012.Summary[0].SummaryValue ) - Convert.ToDecimal( AO013.Summary[0].SummaryValue ) ).ToString( ) );
            AO018.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U26.Summary[0].SummaryValue ) - Convert.ToDecimal( AO018.Summary[0].SummaryValue ) ).ToString( ) );
            if ( tableQueryTre.Rows.Count > 0 && !string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AO009"].ToString( ) ) )
            {
                dtSumTable = null;
                DateTime dt = Convert.ToDateTime( gridView3.GetDataRow( 0 )["AO009"].ToString( ) );
                //if ( dt.Month == 12 )
                //{
                //    dtOne = dt.AddDays( 1 - ( dt.Day ) ).AddDays( DateTime.DaysInMonth( dt.Year ,dt.Month ) - 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtSumTable = _bll.GetDataTableSumTre( dtOne ,dtTwo );
                //    dtTableTre( dtSumTable );
                //}
                //else if ( dt.Month == 1 )
                //{
                //    dtOne = dt.AddYears( -1 ).AddMonths( -dt.Month - 1 + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day );
                //    dtSumTable = _bll.GetDataTableSumTre( dtOne ,dtTwo );
                //    dtTableTre( dtSumTable );
                //}
                //else
                //{
                //    dtOne = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( +1 );
                dtOne = new DateTime( dt.Year ,1 ,1 );
                dtTwo = new DateTime( dt.Year ,12 ,31 );
                dtSumTable = _bll.GetDataTableSumTre( dtOne ,dtTwo );
                dtTableTre( dtSumTable );
                //}
            }
        }
        void dtTableTre ( DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                AO011.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AO011"].ToString( ) );
                AO012.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AO012"].ToString( ) );
                AO013.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AO013"].ToString( ) );
                AO014.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AO014"].ToString( ) );
                U27.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U27"].ToString( ) );
                U26.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U26"].ToString( ) );
                AO018.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AO018"].ToString( ) );

                AO011.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["AO011"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AO012"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U27"].ToString( ) ) ).ToString( ) );
                AO014.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["AO013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AO018"].ToString( ) ) ).ToString( ) );
            }
        }
        private void repositoryItemComboBox21_Click ( object sender ,EventArgs e )
        {
            num = gridView3 . FocusedRowHandle;
            SelectAll . FormSupplier form = new SelectAll . FormSupplier ( );
            form . StartPosition = FormStartPosition . CenterScreen;
            form . PassDataBetweenForm += new SelectAll . FormSupplier . PassDataBetweenFormHandler ( form_PassDataBetweenForm );
            DialogResult result = form . ShowDialog ( );
        }
        private void form_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView3 . SetRowCellValue ( num ,gridView3 . Columns [ "AO011" ] ,e . ConOne );
            gridView3 . SetRowCellValue ( num ,gridView3 . Columns [ "AO013" ] ,e . ConTwo );
            gridView3 . SetRowCellValue ( num ,gridView3 . Columns [ "AO022" ] ,e . ConTre );
            gridView3 . SetRowCellValue ( num ,gridView3 . Columns [ "AO006" ] ,e . ConFor );
        }
        private void repositoryItemComboBox18_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( gridView3 . FocusedColumn == gridView3 . Columns [ "AO003" ] )
            {
                int num = gridView3 . FocusedRowHandle;
                string signone = gridView3 . GetDataRow ( num ) [ "AO022" ] . ToString ( );
                if ( string . IsNullOrEmpty ( signone ) )
                    return;
                int i = ( ( DevExpress . XtraEditors . ComboBoxEdit ) sender ) . SelectedIndex;
                if ( i == 2 )
                {
                    result = _bll . UpdateState ( signone ,MulaolaoBll . Drity . GetDt ( ) ,"执行" );
                    if ( result == false )
                    {
                        MessageBox . Show ( "更改状态失败,请重试" );
                        gridView3 . SetRowCellValue ( num ,gridView3 . Columns [ "AO003" ] ,"审核" );
                    }
                }
                else if ( i == 1 )
                {
                    result = _bll . UpdateState ( signone ,DateTime . Now ,"审核" );
                }
                else if ( i == 0 )
                {
                    result = _bll . UpdateState ( signone ,DateTime . Now ,"" );
                }
            }
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void gridView4_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
            }
        }
        private void gridView4_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["AR001"] ,_modelFor.AR001 );
            if ( gridView4.RowCount > 0 )
            {
                _modelFor.AR021 = "";
                for ( int i = 0 ; i < gridView4.RowCount ; i++ )
                {
                    if ( i == 0 )
                        _modelFor.AR021 = gridView4.GetDataRow( i )["AR021"].ToString( );
                    else if ( i > 0 && i < gridView4.RowCount  )
                    {
                        if ( !string.IsNullOrEmpty( gridView4.GetDataRow( i )["AR021"].ToString( ) ) && !string.IsNullOrEmpty( _modelFor.AR021 ) && Convert.ToInt32( gridView4.GetDataRow( i )["AR021"].ToString( ) ) > Convert.ToInt32( _modelFor.AR021 ) )
                            _modelFor.AR021 = gridView4.GetDataRow( i )["AR021"].ToString( );
                    }
                }

                if ( !string.IsNullOrEmpty( _modelFor.AR021 ) )
                {
                    _modelFor . AR021 = ( Convert . ToInt32 ( _modelFor . AR021 ) + 1 ) . ToString ( ) . PadLeft ( 3 ,'0' );
                    //if ( Convert.ToInt32( _modelFor.AR021 ) < 9 )
                    //    _modelFor.AR021 = "00" + ( Convert.ToInt32( _modelFor.AR021 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelFor.AR021 ) >= 9 && Convert.ToInt32( _modelFor.AR021 ) < 99 )
                    //    _modelFor.AR021 = "0" + ( Convert.ToInt32( _modelFor.AR021 ) + 1 ).ToString( );
                    //else if ( Convert.ToInt32( _modelFor.AR021 ) > 99 )
                    //    _modelFor.AR021 = ( Convert.ToInt32( _modelFor.AR021 ) + 1 ).ToString( );
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AR021"] ,_modelFor.AR021 );
                }
                else
                    view.SetRowCellValue( e.RowHandle ,view.Columns["AR021"] ,"001" );
            }
            else
                view.SetRowCellValue( e.RowHandle ,view.Columns["AR021"] ,"001" );
        }
        private void gridView4_ShowingEditor ( object sender ,CancelEventArgs e )
        {
            row = this.gridView4.GetDataRow( this.gridView4.FocusedRowHandle );
            if ( row != null )
            {
                string str = row["AR003"].ToString( );
                if ( !string.IsNullOrEmpty( str ) && str == "执行" && Logins.number != "MLL-0001" )
                {
                    e.Cancel = true;//该行不可编辑
                }
            }
        }
        private void gridView4_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( gridView4.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = gridView4.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryFor.Rows.Count - 1 )
                    {
                        _modelFor.IDX = string.IsNullOrEmpty( gridView4.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView4.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        if ( gridView4.GetDataRow( num )["AR003"].ToString( ) == "执行" )
                        {
                            if ( Logins.number == "MLL-0001" )
                            {
                                if ( MessageBox.Show( "删除?" ,"此单状态为执行,确认删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                {
                                    //gridView4.DeleteRow( num );
                                    tableQueryFor . Rows . Remove ( tableQueryFor . Select ( "idx=" + _modelFor . IDX + "" ) [ 0 ] );
                                    //gridView4.DeleteSelectedRows( );
                                    //if ( _modelFor.IDX > 0 )
                                    //{
                                    //    tableQueryFor.Rows.RemoveAt( num );
                                    //    if ( tableFiv == "" )
                                    //        tableFiv = _modelFor.IDX.ToString( );
                                    //    else
                                    //        tableFiv = tableFiv + "," + _modelFor.IDX.ToString( );
                                    //}
                                }
                            }
                            else
                                MessageBox.Show( "单据状态为执行,您没有权限删除,需要总经理删除" );
                        }
                        else
                        {
                            //gridView4.DeleteRow( num );
                            tableQueryFor . Rows . Remove ( tableQueryFor . Select ( "idx=" + _modelFor . IDX + "" ) [ 0 ] );
                            //gridView4.DeleteSelectedRows( );
                            //if ( _modelFor.IDX > 0 )
                            //{
                            //    tableQueryFor.Rows.RemoveAt( num );
                            //    if ( tableFiv == "" )
                            //        tableFiv = _modelFor.IDX.ToString( );
                            //    else
                            //        tableFiv = tableFiv + "," + _modelFor.IDX.ToString( );
                            //}
                        }
                    }
                }
            }
        }
        void assignFor ( )
        {
            AR013.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( AR011.Summary[0].SummaryValue ) + Convert.ToDecimal( AR012.Summary[0].SummaryValue ) - Convert.ToDecimal( AR013.Summary[0].SummaryValue ) ).ToString( ) );
            AR018.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( U30.Summary[0].SummaryValue ) - Convert.ToDecimal( AR018.Summary[0].SummaryValue ) ).ToString( ) );
            if ( tableQueryFor.Rows.Count > 0 && !string.IsNullOrEmpty( gridView4.GetDataRow( 0 )["AR009"].ToString( ) ) )
            {
                dtSumTable = null;
                DateTime dt = Convert.ToDateTime( gridView4.GetDataRow( 0 )["AR009"].ToString( ) );
                //if ( dt.Month == 12 )
                //{
                //    dtOne = dt.AddDays( 1 - ( dt.Day ) ).AddDays( DateTime.DaysInMonth( dt.Year ,dt.Month ) - 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtSumTable = _bll.GetDataTableSumFor( dtOne ,dtTwo );
                //    dtTableFor( dtSumTable );
                //}
                //else if ( dt.Month == 1 )
                //{
                //    dtOne = dt.AddYears( -1 ).AddMonths( -dt.Month - 1 + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day );
                //    dtSumTable = _bll.GetDataTableSumFor( dtOne ,dtTwo );
                //    dtTableFor( dtSumTable );
                //}
                //else
                //{
                //    dtOne = dt.AddMonths( -dt.Month + 1 ).AddDays( -dt.Day + 1 );
                //    dtTwo = dt.AddMonths( +1 );
                dtOne = new DateTime( dt.Year ,1 ,1 );
                dtTwo = new DateTime( dt.Year ,12 ,31 );
                dtSumTable = _bll.GetDataTableSumFor( dtOne ,dtTwo );
                dtTableFor( dtSumTable );
                //}
            }
        }
        void dtTableFor ( DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                AR011.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AR011"].ToString( ) );
                AR012.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AR012"].ToString( ) );
                AR013.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AR013"].ToString( ) );
                AR014.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AR014"].ToString( ) );
                U29.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U29"].ToString( ) );
                U30.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["U30"].ToString( ) );
                AR018.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,table.Rows[0]["AR018"].ToString( ) );

                AR011.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["AR011"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AR012"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["U29"].ToString( ) ) ).ToString( ) );
                AR014.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( table.Rows[0]["AR013"].ToString( ) ) + Convert.ToDecimal( table.Rows[0]["AR018"].ToString( ) ) ).ToString( ) );
            }
        }
        private void repositoryItemComboBox28_Click ( object sender ,EventArgs e )
        {
            num = gridView4 . FocusedRowHandle;
            SelectAll . FormSupplier form = new SelectAll . FormSupplier ( );
            form . StartPosition = FormStartPosition . CenterScreen;
            form . PassDataBetweenForm += new SelectAll . FormSupplier . PassDataBetweenFormHandler ( form_PassDataBetween );
            DialogResult result = form . ShowDialog ( );
        }
        private void form_PassDataBetween ( object sender ,PassDataWinFormEventArgs e )
        {
            gridView4 . SetRowCellValue ( num ,gridView4 . Columns [ "AR011" ] ,e . ConOne );
            gridView4 . SetRowCellValue ( num ,gridView4 . Columns [ "AR013" ] ,e . ConTwo );
            gridView4 . SetRowCellValue ( num ,gridView4 . Columns [ "AR022" ] ,e . ConTre );
            gridView4 . SetRowCellValue ( num ,gridView4 . Columns [ "AR006" ] ,e . ConFor );
        }
        private void repositoryItemComboBox25_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( gridView4 . FocusedColumn == gridView4 . Columns [ "AR003" ] )
            {
                int num = gridView4 . FocusedRowHandle;
                string signone = gridView4 . GetDataRow ( num ) [ "AR022" ] . ToString ( );
                if ( string . IsNullOrEmpty ( signone ) )
                    return;
                int i = ( ( DevExpress . XtraEditors . ComboBoxEdit ) sender ) . SelectedIndex;
                if ( i == 2 )
                {
                    result = _bll . UpdateState ( signone ,DateTime . Now ,"执行" );
                    if ( result == false )
                    {
                        MessageBox . Show ( "更改状态失败,请重试" );
                        gridView4 . SetRowCellValue ( num ,gridView4 . Columns [ "AR003" ] ,"审核" );
                    }
                }
                else if ( i == 1 )
                {
                    result = _bll . UpdateState ( signone ,DateTime . Now ,"审核" );
                }
                else if ( i == 0 )
                {
                    result = _bll . UpdateState ( signone ,DateTime . Now ,"" );
                }
            }
        }
        /*-------------------------------------------------------------------------------------------------------------------------------------------------*/
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e.ClickedItem ).Name == "MenuItemOne" )
            {
                if ( gridView1.DataRowCount > 0 )
                {
                    strWhereOne = "1=1";
                    strWhereOne = strWhereOne + " AND YZ001='" + gridView1.GetDataRow( 0 )["YZ001"].ToString( ) + "'";
                    refre( );
                }
                if ( gridView2.DataRowCount > 0 )
                {
                    strWhereTwo = "1=1";
                    strWhereTwo = strWhereTwo + " AND AP001='" + gridView2.GetDataRow( 0 )["AP001"].ToString( ) + "'";
                    refreOne( );
                }
                if ( bandedGridView1.DataRowCount > 0 )
                {
                    strWhereTre = "1=1";
                    strWhereTre = strWhereTre + " AND AQ001='" + bandedGridView1.GetDataRow( 0 )["AQ001"].ToString( ) + "'";
                    refreTwo( );
                }
                if ( gridView3.DataRowCount > 0 )
                {
                    strWhereFore = "1=1";
                    strWhereFore = strWhereFore + " AND AO001='" + gridView3.GetDataRow( 0 )["AO001"].ToString( ) + "'";
                    refreTre( );
                }
                if ( gridView4.DataRowCount > 0 )
                {
                    strWhereFiv = "1=1";
                    strWhereFiv = strWhereFiv + " AND AR001='" + gridView4.GetDataRow( 0 )["AR001"].ToString( ) + "'";
                    refreFor( );
                }
            }
            if ( ( e.ClickedItem ).Name == "MenuItemTwo" )
            {
                if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                {
                    if ( gridView1.RowCount > 0 )
                    {
                        _model.YZ001 = gridView1.GetDataRow( 0 )["YZ001"].ToString( );
                        try
                        {
                            _bll.UpdateOfReview( _model.YZ001 );
                        }
                        catch { }
                    }
                }
                if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
                {
                    if ( gridView2.RowCount > 0 )
                    {
                        _modelOne.AP001 = gridView2.GetDataRow( 0 )["AP001"].ToString( );
                        try
                        {
                            _bll.UpdateOfReview( _modelOne.AP001 );
                        }
                        catch { }
                    }
                }
                if ( tabControl1.SelectedTab.Name == "tabPageTre" )
                {
                    if ( bandedGridView1.RowCount > 0 )
                    {
                        _modelTwo.AQ001 = bandedGridView1.GetDataRow( 0 )["AQ001"].ToString( );
                        try
                        {
                            _bll.UpdateOfReview( _modelTwo.AQ001 );
                        }
                        catch { }
                    }
                }
                if ( tabControl1.SelectedTab.Name == "tabPageFor" )
                {
                    if ( gridView3.RowCount > 0 )
                    {
                        _modelTre.AO001 = gridView3.GetDataRow( 0 )["AO001"].ToString( );
                        try
                        {
                            _bll.UpdateOfReview( _modelTre.AO001 );
                        }
                        catch { }
                    }
                }
                if ( tabControl1.SelectedTab.Name == "tabPageFiv" )
                {
                    if ( gridView4.RowCount > 0 )
                    {
                        _modelFor.AR001 = gridView4.GetDataRow( 0 )["AR001"].ToString( );
                        try
                        {
                            _bll.UpdateOfReview( _modelFor.AR001 );
                        }
                        catch { }
                    }
                }
            }
            if ( ( e.ClickedItem ).Name == "MenuItemTre" )
            {
                if ( toolSave.Enabled == true )
                {
                    SelectAll.BatchPayMentTimeAll queryAll = new SelectAll.BatchPayMentTimeAll( );
                    queryAll.PassDataBetweenForm += new SelectAll.BatchPayMentTimeAll.PassDataBetweenFormHandler( queryall_PassDataBetWeenForm );
                    queryAll.StartPosition = FormStartPosition.CenterScreen;
                    queryAll.login = Logins.number;
                    if ( tabControl1.SelectedTab.Name == "tabPageOne" )
                    {
                        _model.YZ001 = gridView1.GetDataRow( 0 )["YZ001"].ToString( );
                        queryAll.oddNum = _model.YZ001;
                        queryAll.sign = "1";
                    }
                    if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
                    {
                        _modelOne.AP001 = gridView2.GetDataRow( 0 )["AP001"].ToString( );
                        queryAll.oddNum = _modelOne.AP001;
                        queryAll.sign = "2";
                    }
                    if ( tabControl1 . SelectedTab . Name == "tabPageTre" )
                    {
                        _modelTwo . AQ001 = bandedGridView1 . GetDataRow ( 0 ) [ "AQ001" ] . ToString ( );
                        queryAll . oddNum = _modelTwo . AQ001;
                        queryAll . sign = "3";
                    }
                    if ( tabControl1 . SelectedTab . Name == "tabPageFor" )
                    {
                        _modelTre . AO001 = gridView3 . GetDataRow ( 0 ) [ "AO001" ] . ToString ( );
                        queryAll . oddNum = _modelTre . AO001;
                        queryAll . sign = "4";
                    }
                    if ( tabControl1 . SelectedTab . Name == "tabPageFiv" )
                    {
                        _modelFor . AR001 = gridView4 . GetDataRow ( 0 ) [ "AR001" ] . ToString ( );
                        queryAll . oddNum = _modelFor . AR001;
                        queryAll . sign = "5";
                    }
                    queryAll .ShowDialog( );
                }
            }
            if ( ( e.ClickedItem ).Name == "MenuItemFor" )
            {
                result = _bll.UpdateOfHide( "T" );
                if ( result == true )
                    YZ013.VisibleIndex = YZ015.VisibleIndex = U0.VisibleIndex = U1.VisibleIndex = U2.VisibleIndex = U3.VisibleIndex = AP013.VisibleIndex = AP015.VisibleIndex = U12.VisibleIndex = U13.VisibleIndex = U14.VisibleIndex = U15.VisibleIndex = -1;
                else
                    MessageBox.Show( "隐藏失败,请重试" );
            }
            if ( ( e.ClickedItem ).Name == "MenuItemFiv" )
            {
                result = _bll.UpdateOfHide( "F" );
                if ( result == true )
                {
                    apOf( );
                    yzof( );
                }
                else
                    MessageBox.Show( "取消隐藏失败,请重试" );
            }
        }
        private void queryall_PassDataBetWeenForm (object sender,PassDataWinFormEventArgs e )
        {
            if ( e . ConOne == "1" )
            {
                strTwo . Clear ( );
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    if ( !strTwo . Contains ( gridView1 . GetDataRow ( i ) [ "YZ031" ] . ToString ( ) ) )
                        strTwo . Add ( gridView1 . GetDataRow ( i ) [ "YZ031" ] . ToString ( ) );
                    if ( Logins . number == "MLL-0001" )
                        gridView1 . SetRowCellValue ( i , gridView1 . Columns [ "YZ003" ] , e . ConFor );
                    else
                    {
                        if ( gridView1 . GetDataRow ( i ) [ "YZ003" ] . ToString ( ) != "执行" )
                            gridView1 . SetRowCellValue ( i , gridView1 . Columns [ "YZ003" ] , e . ConFor );
                    }
                }
                for ( int i = gridView1 . RowCount - 1 ; i >= 0 ; i-- )
                {
                    if ( !strTwo . Contains ( gridView1 . GetDataRow ( i ) [ "YZ031" ] . ToString ( ) ) )
                        strTwo . Add ( gridView1 . GetDataRow ( i ) [ "YZ031" ] . ToString ( ) );
                    if ( Logins . number == "MLL-0001" )
                        gridView1 . SetRowCellValue ( i , gridView1 . Columns [ "YZ003" ] , e . ConFor );
                    else
                    {
                        if ( gridView1 . GetDataRow ( i ) [ "YZ003" ] . ToString ( ) != "执行" )
                            gridView1 . SetRowCellValue ( i , gridView1 . Columns [ "YZ003" ] , e . ConFor );
                    }
                }
                if ( e . ConSix == "1" )
                    dtStateOfChange ( Convert . ToDateTime ( e . ConTre ) ,e . ConTwo );
                else if ( e . ConSix == "2" && e . ConFor != string . Empty )
                    stateOfChange ( strTwo ,e . ConFor );
            }
            else if ( e . ConOne == "2" )
            {
                strTwo . Clear ( );
                for ( int i = 0 ; i < gridView2 . RowCount ; i++ )
                {
                    if ( !strTwo . Contains ( gridView2 . GetDataRow ( i ) [ "AP031" ] . ToString ( ) ) )
                        strTwo . Add ( gridView2 . GetDataRow ( i ) [ "AP031" ] . ToString ( ) );
                    if ( Logins . number == "MLL-0001" )
                        gridView2 . SetRowCellValue ( i , gridView2 . Columns [ "AP003" ] , e . ConFor );
                    else
                    {
                        if ( gridView2 . GetDataRow ( i ) [ "AP003" ] . ToString ( ) != "执行" )
                            gridView2 . SetRowCellValue ( i , gridView2 . Columns [ "AP003" ] , e . ConFor );
                    }
                }
                for ( int i = gridView2 . RowCount - 1 ; i >= 0 ; i-- )
                {
                    if ( !strTwo . Contains ( gridView2 . GetDataRow ( i ) [ "AP031" ] . ToString ( ) ) )
                        strTwo . Add ( gridView2 . GetDataRow ( i ) [ "AP031" ] . ToString ( ) );
                    if ( Logins . number == "MLL-0001" )
                        gridView2 . SetRowCellValue ( i , gridView2 . Columns [ "AP003" ] , e . ConFor );
                    else
                    {
                        if ( gridView2 . GetDataRow ( i ) [ "AP003" ] . ToString ( ) != "执行" )
                            gridView2 . SetRowCellValue ( i , gridView2 . Columns [ "AP003" ] , e . ConFor );
                    }
                }
                if ( e . ConSix == "1" )
                    dtStateOfChangeOfAP ( Convert . ToDateTime ( e . ConTre ) , e . ConTwo );
                else if ( e . ConSix == "2" && e . ConFor != string . Empty )
                    stateOfChanges ( strTwo , e . ConFor );
            }
            else if ( e . ConOne == "3" )
            {
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    if ( Logins . number == "MLL-0001" )
                        bandedGridView1 . SetRowCellValue ( i , bandedGridView1 . Columns [ "AQ017" ] , e . ConFor );
                    else
                    {
                        if ( bandedGridView1 . GetDataRow ( i ) [ "AQ017" ] . ToString ( ) != "执行" )
                            bandedGridView1 . SetRowCellValue ( i , bandedGridView1 . Columns [ "AQ017" ] , e . ConFor );
                    }
                }
                for ( int i = bandedGridView1 . RowCount - 1 ; i >= 0 ; i-- )
                {
                    if ( Logins . number == "MLL-0001" )
                        bandedGridView1 . SetRowCellValue ( i , bandedGridView1 . Columns [ "AQ017" ] , e . ConFor );
                    else
                    {
                        if ( bandedGridView1 . GetDataRow ( i ) [ "AQ017" ] . ToString ( ) != "执行" )
                            bandedGridView1 . SetRowCellValue ( i , bandedGridView1 . Columns [ "AQ017" ] , e . ConFor );
                    }
                }
            }
            else if ( e . ConOne == "4" )
            {
                for ( int i = 0 ; i < gridView3 . RowCount ; i++ )
                {
                    if ( !strTwo . Contains ( gridView3 . GetDataRow ( i ) [ "AO021" ] . ToString ( ) ) )
                        strTwo . Add ( gridView3 . GetDataRow ( i ) [ "AO021" ] . ToString ( ) );

                    if ( Logins . number == "MLL-0001" )
                        gridView3 . SetRowCellValue ( i , gridView3 . Columns [ "AO003" ] , e . ConFor );
                    else
                    {
                        if ( gridView3 . GetDataRow ( i ) [ "AO003" ] . ToString ( ) != "执行" )
                            gridView3 . SetRowCellValue ( i , gridView3 . Columns [ "AO003" ] , e . ConFor );
                    }
                }
                for ( int i = gridView3 . RowCount - 1 ; i >= 0 ; i-- )
                {
                    if ( !strTwo . Contains ( gridView3 . GetDataRow ( i ) [ "AO021" ] . ToString ( ) ) )
                        strTwo . Add ( gridView3 . GetDataRow ( i ) [ "AO021" ] . ToString ( ) );

                    if ( Logins . number == "MLL-0001" )
                        gridView3 . SetRowCellValue ( i , gridView3 . Columns [ "AO003" ] , e . ConFor );
                    else
                    {
                        if ( gridView3 . GetDataRow ( i ) [ "AO003" ] . ToString ( ) != "执行" )
                            gridView3 . SetRowCellValue ( i , gridView3 . Columns [ "AO003" ] , e . ConFor );
                    }
                }

                if ( e . ConSix == "1" )
                    dtStateOfChangeOfviewTre ( Convert . ToDateTime ( e . ConTre ) ,e . ConTwo );
                else if ( e . ConSix == "2" && e . ConFor != string . Empty )
                    stateOfChangeviewTre ( strTwo ,e . ConFor );

            }
            else if ( e . ConOne == "5" )
            {
                for ( int i = 0 ; i < gridView4 . RowCount ; i++ )
                {
                    if ( !strTwo . Contains ( gridView4 . GetDataRow ( i ) [ "AR021" ] . ToString ( ) ) )
                        strTwo . Add ( gridView4 . GetDataRow ( i ) [ "AR021" ] . ToString ( ) );

                    if ( Logins . number == "MLL-0001" )
                        gridView4 . SetRowCellValue ( i , gridView4 . Columns [ "AR003" ] , e . ConFor );
                    else
                    {
                        if ( gridView4 . GetDataRow ( i ) [ "AR003" ] . ToString ( ) != "执行" )
                            gridView4 . SetRowCellValue ( i , gridView4 . Columns [ "AR003" ] , e . ConFor );
                    }
                }
                for ( int i = gridView4 . RowCount - 1 ; i >= 0 ; i-- )
                {
                    if ( !strTwo . Contains ( gridView4 . GetDataRow ( i ) [ "AR021" ] . ToString ( ) ) )
                        strTwo . Add ( gridView4 . GetDataRow ( i ) [ "AR021" ] . ToString ( ) );

                    if ( Logins . number == "MLL-0001" )
                        gridView4 . SetRowCellValue ( i , gridView4 . Columns [ "AR003" ] , e . ConFor );
                    else
                    {
                        if ( gridView4 . GetDataRow ( i ) [ "AR003" ] . ToString ( ) != "执行" )
                            gridView4 . SetRowCellValue ( i , gridView4 . Columns [ "AR003" ] , e . ConFor );
                    }
                }

                if ( e . ConSix == "1" )
                    dtStateOfChangeOfviewTre ( Convert . ToDateTime ( e . ConTre ) ,e . ConTwo );
                else if ( e . ConSix == "2" && e . ConFor != string . Empty )
                    stateOfChangeviewTre ( strTwo ,e . ConFor );
            }
        }
        void stateOfChange ( List<string> strList ,string imPlement )
        {
            //批量编辑状态
            gridView1 . ClearColumnsFilter ( );
            _model . YZ001 = gridView1 . GetDataRow ( 0 ) [ "YZ001" ] . ToString ( );
            _bll . UpdateStateOf ( _model . YZ001 , strList , imPlement  );
        }
        void dtStateOfChange ( DateTime dtOne ,string exaMine )
        {
            //批量编辑日期
            gridView1.ClearColumnsFilter( );
            _model.YZ001 = gridView1.GetDataRow( 0 )["YZ001"].ToString( );
            _bll.UpdaetOfDt( _model.YZ001 ,exaMine ,dtOne );
        }
        void stateOfChanges ( List<string> strList ,string imPlement )
        {
            gridView2.ClearColumnsFilter( );
            _modelOne.AP001 = gridView2.GetDataRow( 0 )["AP001"].ToString( );
            _bll . UpdateStateOfs ( _modelOne . AP001 , strList , imPlement );
        }
        void dtStateOfChangeOfAP ( DateTime dtOne ,string exaMine )
        {
            gridView2.ClearColumnsFilter( );
            _modelOne.AP001 = gridView2.GetDataRow( 0 )["AP001"].ToString( );
            _bll.UpdaetOfDtAp( _modelOne.AP001 ,exaMine ,dtOne );
        }
        void stateOfChangeviewTre ( List<string> strList ,string imPlement )
        {
            gridView3 . ClearColumnsFilter ( );
            _modelTre . AO001 = gridView3 . GetDataRow ( 0 ) [ "AO001" ] . ToString ( );
            _bll .UpdateStateOfVirwTre ( _modelTre . AO001 ,strList ,imPlement );
        }
        void dtStateOfChangeOfviewTre ( DateTime dtOne ,string exaMine )
        {
            gridView3 . ClearColumnsFilter ( );
            _modelTre . AO001 = gridView3 . GetDataRow ( 0 ) [ "AO001" ] . ToString ( );
            _bll . UpdaetOfDtViewTre ( _modelTre . AO001 ,exaMine ,dtOne );
        }
        void stateOfChangeviewFor ( List<string> strList ,string imPlement )
        {
            gridView4 . ClearColumnsFilter ( );
            _modelFor . AR001 = gridView4 . GetDataRow ( 0 ) [ "AR001" ] . ToString ( );
            _bll . UpdateStateOfVirwFor ( _modelFor . AR001 ,strList ,imPlement );
        }
        void dtStateOfChangeOfviewFor ( DateTime dtOne ,string exaMine )
        {
            gridView4 . ClearColumnsFilter ( );
            _modelFor . AR001 = gridView4 . GetDataRow ( 0 ) [ "AR001" ] . ToString ( );
            _bll . UpdaetOfDtViewFor ( _modelFor . AR001 ,exaMine ,dtOne );
        }
        void apOf ( )
        {
            YZ003.VisibleIndex = 0;
            YZ004.VisibleIndex = 1;
            YZ005.VisibleIndex = 2;
            YZ028.VisibleIndex = 3;
            YZ021.VisibleIndex = 4;
            YZ006.VisibleIndex = 5;
            YZ007.VisibleIndex = 6;
            YZ008.VisibleIndex = 7;
            YZ009.VisibleIndex = 8;
            YZ010.VisibleIndex = 9;
            YZ011.VisibleIndex = 10;
            YZ013.VisibleIndex = 11;
            YZ012.VisibleIndex = 12;
            YZ014.VisibleIndex = 13;
            YZ026.VisibleIndex = 14;
            YZ015.VisibleIndex = 15;
            U0.VisibleIndex = 16;
            U1.VisibleIndex = 17;
            U2.VisibleIndex = 18;
            U3.VisibleIndex = 19;
            YZ017.VisibleIndex = 20;
            U31.VisibleIndex = 21;
            U28.VisibleIndex = 22;
            U4.VisibleIndex = 23;
            U5.VisibleIndex = 24;
            U6.VisibleIndex = 25;
            U7.VisibleIndex = 26;
            U8.VisibleIndex = 27;
            U9.VisibleIndex = 28;
            U10.VisibleIndex = 29;
            U11.VisibleIndex = 30;
            YZ020.VisibleIndex = 31;
        }
        void yzof ( )
        {
            AP003.VisibleIndex = 0;
            AP004.VisibleIndex = 1;
            AP005.VisibleIndex = 2;
            AP028.VisibleIndex = 3;
            AP021.VisibleIndex = 4;
            AP006.VisibleIndex = 5;
            AP007.VisibleIndex = 6;
            AP008.VisibleIndex = 7;
            AP009.VisibleIndex = 8;
            AP010.VisibleIndex = 9;
            AP011.VisibleIndex = 10;
            AP013.VisibleIndex = 11;
            AP012.VisibleIndex = 12;
            AP014.VisibleIndex = 13;
            AP026.VisibleIndex = 14;
            AP015.VisibleIndex = 15;
            U12.VisibleIndex = 16;
            U13.VisibleIndex = 17;
            U14.VisibleIndex = 18;
            U15.VisibleIndex = 19;
            AP017.VisibleIndex = 20;
            U33.VisibleIndex = 21;
            U32.VisibleIndex = 22;
            U16.VisibleIndex = 23;
            U17.VisibleIndex = 24;
            U18.VisibleIndex = 25;
            U19.VisibleIndex = 26;
            U20.VisibleIndex = 27;
            U21.VisibleIndex = 28;
            U22.VisibleIndex = 29;
            U25.VisibleIndex = 30;
            AP020.VisibleIndex = 31;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            gridView1.OptionsBehavior.Editable = true;
            gridControl1.DataSource = null;

            _model.YZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_231-" );
            comboboxItems( );
            strWhereOne = "1=1";
            strWhereOne = strWhereOne + " AND YZ001='" + _model.YZ001 + "'";
            refre( );

            gridView2.OptionsBehavior.Editable = true;
            gridControl2.DataSource = null;

            _modelOne.AP001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_231-" );
            comboboxItemsOne( );
            strWhereTwo = "1=1";
            strWhereTwo = strWhereTwo + " AND AP001='" + _modelOne.AP001 + "'";
            refreOne( );

            bandedGridView1.OptionsBehavior.Editable = true;
            gridControl3.DataSource = null;

            _modelTwo.AQ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_231-" );
            comboboxItemsTwo( );
            strWhereTre = "1=1";
            strWhereTre = strWhereTre + " AND AQ001='" + _modelTwo.AQ001 + "'";
            refreTwo( );

            gridView3.OptionsBehavior.Editable = true;
            gridControl4.DataSource = null;

            _modelTre.AO001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_231-" );
            comboboxItemsTre( );
            strWhereFore = "1=1";
            strWhereFore = strWhereFore + " AND AO001='" + _modelTre.AO001 + "'";
            refreTre( );

            gridView4.OptionsBehavior.Editable = true;
            gridControl5.DataSource = null;

            _modelFor.AR001 = oddNumbers.purchaseContract( "SELECT MAX(AJ018) AJ018 FROM R_PQAJ" ,"AJ018" ,"R_231-" );
            comboboxItemsFor( );
            strWhereFiv = "1=1";
            strWhereFiv = strWhereFiv + " AND AR001='" + _modelFor.AR001 + "'";
            refreFor( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;

            sav = "1";
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
            {
                for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
                {
                    if ( gridView1.GetDataRow( i )["YZ003"].ToString( ) == "执行" )
                    {
                        if ( Logins.number == "MLL-0001" )
                        {
                            if ( MessageBox.Show( "删除" ,"此单中有已经已经执行的记录,确定删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                dele( );
                        }
                        else
                        {
                            MessageBox.Show( "此单中有已经执行的单据,您无权删除,需要总经理删除" );
                            return;
                        }
                    }
                    else
                        dele( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
            {
                for ( int i = 0 ; i < gridView2.DataRowCount ; i++ )
                {
                    if ( gridView2.GetDataRow( i )["AP003"].ToString( ) == "执行" )
                    {
                        if ( Logins.number == "MLL-0001" )
                        {
                            if ( MessageBox.Show( "删除" ,"此单中有已经已经执行的记录,确定删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                deleOne( );
                        }
                        else
                        {
                            MessageBox.Show( "此单中有已经执行的单据,您无权删除,需要总经理删除" );
                            return;
                        }
                    }
                    else
                        deleOne( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTre" )
            {
                for ( int i = 0 ; i < bandedGridView1.DataRowCount ; i++ )
                {
                    if ( bandedGridView1.GetDataRow( i )["AQ017"].ToString( ) == "执行" )
                    {
                        if ( Logins.number == "MLL-0001" )
                        {
                            if ( MessageBox.Show( "删除" ,"此单中有已经已经执行的记录,确定删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                deleTwo( );
                        }
                        else
                        {
                            MessageBox.Show( "此单中有已经执行的单据,您无权删除,需要总经理删除" );
                            return;
                        }
                    }
                    else
                        deleTwo( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageFor" )
            {
                for ( int i = 0 ; i < gridView3.DataRowCount ; i++ )
                {
                    if ( gridView3.GetDataRow( i )["AO003"].ToString( ) == "执行" )
                    {
                        if ( Logins.number == "MLL-0001" )
                        {
                            if ( MessageBox.Show( "删除" ,"此单中有已经已经执行的记录,确定删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                deleTre( );
                        }
                        else
                        {
                            MessageBox.Show( "此单中有已经执行的单据,您无权删除,需要总经理删除" );
                            return;
                        }
                    }
                    else
                        deleTre( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageFiv" )
            {
                for ( int i = 0 ; i < gridView4.DataRowCount ; i++ )
                {
                    if ( gridView4.GetDataRow( i )["AR003"].ToString( ) == "执行" )
                    {
                        if ( Logins.number == "MLL-0001" )
                        {
                            if ( MessageBox.Show( "删除" ,"此单中有已经已经执行的记录,确定删除?" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                                deleFor( );
                        }
                        else
                        {
                            MessageBox.Show( "此单中有已经执行的单据,您无权删除,需要总经理删除" );
                            return;
                        }
                    }
                    else
                        deleFor( );
                }
            }
        }
        void dele ( )
        {
            result = _bll.Delete( _model.YZ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        void deleOne ( )
        {
            result = _bll.DeleteOne( _modelOne.AP001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridView2.OptionsBehavior.Editable = false;
                gridControl2.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        void deleTwo ( )
        {
            result = _bll.DeleteTwo( _modelTwo.AQ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                bandedGridView1.OptionsBehavior.Editable = false;
                gridControl3.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        void deleTre ( )
        {
            result = _bll.DeleteTre( _modelTre.AO001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridView3.OptionsBehavior.Editable = false;
                gridControl4.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        void deleFor ( )
        {
            result = _bll.DeleteFor( _modelFor.AR001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                gridView4.OptionsBehavior.Editable = false;
                gridControl5.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        protected override void update ( )
        {
            base.update( );
         
            if ( tableQuery == null )
                gridView1.OptionsBehavior.Editable = false;
            else
            {
                if ( tableQuery.Rows.Count > 0 )
                {
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND YZ001='" + _model.YZ001 + "'";
                    refre( );
                }
                gridView1.OptionsBehavior.Editable = true;
                comboboxItems( );
            }
            if ( tableQueryOne == null )
                gridView2.OptionsBehavior.Editable = false;
            else
            {
                if ( tableQueryOne.Rows.Count > 0 )
                {
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND AP001='" + _modelOne.AP001 + "'";
                    refreOne( );
                }

                gridView2.OptionsBehavior.Editable = true;
                comboboxItemsOne( );
            }
            if ( tableQueryTwo == null )
                bandedGridView1.OptionsBehavior.Editable = false;
            else
            {
                if ( tableQueryTwo .Rows.Count>0)
                {
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND AQ001='" + _modelTwo.AQ001 + "'";
                    refreTwo( );
                }
                bandedGridView1.OptionsBehavior.Editable = true;
                comboboxItemsTwo( );
            }
            if ( tableQueryTre == null )
                gridView3.OptionsBehavior.Editable = false;
            else
            {
                if ( tableQueryTre.Rows.Count > 0 )
                {
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND AO001='" + _modelTre.AO001 + "'";
                    refreTre( );
                }
                gridView3.OptionsBehavior.Editable = true;
                comboboxItemsTre( );
            }
            if ( tableQueryFor == null )
                gridView4.OptionsBehavior.Editable = false;
            else
            {
                if ( tableQueryFor.Rows.Count > 0 )
                {

                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND AR001='" + _modelFor.AR001 + "'";
                    refreFor( );
                }
                gridView4.OptionsBehavior.Editable = true;
                comboboxItemsFor( );
            }
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;     
            sav = "2";
        }
        protected override void save ( )
        {
            base.save( );

            gridView1.ClearColumnsFilter( );
            gridView2.ClearColumnsFilter( );
            gridView3.ClearColumnsFilter( );
            gridView4.ClearColumnsFilter( );
            bandedGridView1.ClearColumnsFilter( );

            #region GridViewOne
            gridView1 . CloseEditor ( );
            gridView1.UpdateCurrentRow( );
            tableQuery.AcceptChanges( );
            if ( tableQuery == null || tableQuery.Rows.Count < 1 )
                gridView1.OptionsBehavior.Editable = false;
            else
            {
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ004"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "成本监督人不可为空" );
                    //        gridView1.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ021"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "使用单位(人)不可为空" );
                    //        gridView1.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ006"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "单位名称不可为空" );
                    //        gridView1.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ005"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "成本经办人不可为空" );
                    //        gridView1.FocusedRowHandle = i;
                    //        return;
                    //    }
                    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["YZ009"].ToString( ) ) )
                    {
                        MessageBox.Show( "付款日期不可为空" );
                        gridView1.FocusedRowHandle = i;
                        return;
                    }
                }

                strWhereOne = "1=1";
                strWhereOne = strWhereOne + " AND YZ001='" + gridView1.GetDataRow( 0 )["YZ001"].ToString( ) + "'";
                DataTable dl = _bll.GetDataTableOfAll( strWhereOne );
                if ( tableTheSame( dl ,tableQuery ) )
                {
                    MessageBox.Show( "木佬佬付款保存数据成功" );
                    gridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    result = _bll.Delete256WriteTo241( tableQuery );
                    if ( result == false )
                    {
                        MessageBox.Show( "木佬佬付款保存数据失败,请重试" );
                        return;
                    }
                    result = _bll.Read526To241( tableQuery );
                    if ( result == false )
                    {
                        MessageBox.Show( "木佬佬付款保存数据失败,请重试" );
                        return;
                    }

                    //try
                    //{
                    //    _bll.Deletes( tableOne );
                    //}
                    //catch { }
                    //finally { tableOne = ""; }

                    //result = _bll.AddNew( tableQuery );
                    result = _bll.AddOne( tableQuery );
                    if ( result == true )
                    {
                        MessageBox.Show( "木佬佬付款保存数据成功" );
                        gridView1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        MessageBox.Show( "木佬佬付款保存数据失败,请重试" );
                        return;
                    }
                }
            }
            #endregion

            #region GridViewTwo
            gridView2 . CloseEditor ( );
            gridView2 .UpdateCurrentRow( );
            tableQueryOne.AcceptChanges( );
            if ( tableQueryOne == null || tableQueryOne.Rows.Count < 1 )
                gridView2.OptionsBehavior.Editable = false;
            else
            {
                for ( int i = 0 ; i < tableQueryOne.Rows.Count ; i++ )
                {
                    //    if ( string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP004"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "成本监督人不可为空" );
                    //        gridView2.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //    if ( string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP021"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "使用单位(人)不可为空" );
                    //        gridView2.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //    if ( string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP006"].ToString( ) ) )
                    //    {
                    //        MessageBox.Show( "单位名称不可为空" );
                    //        gridView2.FocusedRowHandle = i;
                    //        return;
                    //    }
                    //if ( string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP005"].ToString( ) ) )
                    //{
                    //    MessageBox.Show( "成本经办人不可为空" );
                    //    gridView2.FocusedRowHandle = i;
                    //    return;
                    //}
                    if ( string.IsNullOrEmpty( gridView2.GetDataRow( i )["AP009"].ToString( ) ) )
                    {
                        MessageBox.Show( "付款日期不可为空" );
                        gridView2.FocusedRowHandle = i;
                        return;
                    }
                }
                strWhereTwo = "1=1";
                strWhereTwo = strWhereTwo + " AND AP001='" + gridView2.GetDataRow( 0 )["AP001"].ToString( ) + "'";
                DataTable dlONE = _bll.GetDataTableOfAllOne( strWhereTwo );
                if ( tableTheSame( dlONE ,tableQueryOne ) )
                {
                    MessageBox.Show( "永灵付款保存数据成功" );
                    gridView2.OptionsBehavior.Editable = false;
                }
                else
                {
                    result = _bll.Delete256WriteTo241AP( tableQueryOne );
                    if ( result == false )
                    {
                        MessageBox.Show( "永灵付款保存数据失败,请重试" );
                        return;
                    }
                    result = _bll.Read526To241AP( tableQueryOne );
                    if ( result == false )
                    {
                        MessageBox.Show( "永灵付款保存数据失败,请重试" );
                        return;
                    }

                    //try
                    //{
                    //    _bll.DeleteOnes( tableTwo );
                    //}
                    //catch { }
                    //finally { tableTwo = ""; }

                    //result = _bll.AddNewOne( tableQueryOne );
                    result = _bll.AddTwo( tableQueryOne );
                    if ( result == true )
                    {
                        MessageBox.Show( "永灵付款保存数据成功" );
                        gridView2.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        MessageBox.Show( "永灵付款保存数据失败,请重试" );
                        return;
                    }
                }
            }
            #endregion

            #region GridViewTre
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 .UpdateCurrentRow( );
            tableQueryTwo.AcceptChanges( );
            if ( tableQueryTwo == null || tableQueryTwo.Rows.Count < 1 )
                bandedGridView1.OptionsBehavior.Editable = false;
            else
            {
                //for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                //{
                //    if ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["AQ002"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "银行不可为空" );
                //        bandedGridView1.FocusedRowHandle = i;
                //        return;
                //    }
                //    if ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["AQ003"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "贷款年月日不可为空" );
                //        bandedGridView1.FocusedRowHandle = i;
                //        return;
                //    }
                //}
                strWhereTre = "1=1";
                strWhereTre = strWhereTre + " AND AQ001='" + bandedGridView1.GetDataRow( 0 )["AQ001"].ToString( ) + "'";
                DataTable dlFOR = _bll.GetDataTableOfAllTwo( strWhereTre );
                if ( tableTheSame( dlFOR ,tableQueryTwo ) )
                {
                    MessageBox.Show( "贷款木佬佬保存数据成功" );
                    bandedGridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    //try
                    //{
                    //    _bll.DeleteTwos( tableTre );
                    //}
                    //catch { }
                    //finally { tableTre = ""; }
                    //result = _bll.AddNewTwo( tableQueryTwo );
                    result = _bll.AddTre( tableQueryTwo );
                    if ( result == true )
                    {
                        MessageBox.Show( "贷款木佬佬保存数据成功" );
                        bandedGridView1.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        MessageBox.Show( "贷款木佬佬保存数据失败,请重试" );
                        return;
                    }
                }
            }
            #endregion

            #region GridViewFor
            gridView3 . CloseEditor ( );
            gridView3 .UpdateCurrentRow( );
            tableQueryTre.AcceptChanges( );
            if ( tableQueryTre == null || tableQueryTre.Rows.Count < 1 )
                gridView3.OptionsBehavior.Editable = false;
            else
            {
                //for ( int i = 0 ; i < tableQueryTre.Rows.Count ; i++ )
                //{
                //    if ( string.IsNullOrEmpty( gridView3.GetDataRow( i )["AO004"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "支.借审批人不可为空" );
                //        gridView3.FocusedRowHandle = i;
                //        return;
                //    }
                //    if ( string.IsNullOrEmpty( gridView3.GetDataRow( i )["AO005"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "支.借经办人不可为空" );
                //        gridView3.FocusedRowHandle = i;
                //        return;
                //    }
                //    if ( string.IsNullOrEmpty( gridView3.GetDataRow( i )["AO006"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "使用单位(人)不可为空" );
                //        gridView3.FocusedRowHandle = i;
                //        return;
                //    }
                //    if ( string.IsNullOrEmpty( gridView3.GetDataRow( i )["AO007"].ToString( ) ) )
                //    {
                //        MessageBox.Show( "借款单位(人)不可为空" );
                //        gridView3.FocusedRowHandle = i;
                //        return;
                //    }
                //}
                strWhereFore = "1=1";
                strWhereFore = strWhereFore + " AND AO001='" + gridView3.GetDataRow( 0 )["AO001"].ToString( ) + "'";
                DataTable dlTWO = _bll.GetDataTableOfAllTre( strWhereFore );
                if ( tableTheSame( dlTWO ,tableQueryTre ) )
                {
                    MessageBox.Show( "借款木佬佬保存数据成功" );
                    gridView3.OptionsBehavior.Editable = false;
                }
                else
                {
                    //try
                    //{
                    //    _bll.DeleteTres( tbaleFor );
                    //}
                    //catch { }
                    //finally { tbaleFor = ""; }
                    //result = _bll.AddNewTre( tableQueryTre );
                    result = _bll.AddFor( tableQueryTre );
                    if ( result == true )
                    {
                        MessageBox.Show( "借款木佬佬保存数据成功" );
                        gridView3.OptionsBehavior.Editable = false;

                    }
                    else
                    {

                        MessageBox.Show( "借款木佬佬保存数据失败,请重试" );
                        return;
                    }
                }
            }
            #endregion

            #region GridViewFiv
            gridView4 . CloseEditor ( );
            gridView4 .UpdateCurrentRow( );
            tableQueryFor.AcceptChanges( );
            if ( tableQueryFor == null || tableQueryFor.Rows.Count < 1 )
            {
                gridView4.OptionsBehavior.Editable = false;
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = false;
                return;
            }
            //for ( int i = 0 ; i < tableQueryFor.Rows.Count ; i++ )
            //{
            //    if ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AR004"].ToString( ) ) )
            //    {
            //        MessageBox.Show( "支.借审批人不可为空" );
            //        gridView4.FocusedRowHandle = i;
            //        return;
            //    }
            //    if ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AR005"].ToString( ) ) )
            //    {
            //        MessageBox.Show( "支.借经办人不可为空" );
            //        gridView4.FocusedRowHandle = i;
            //        return;
            //    }
            //    if ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AR006"].ToString( ) ) )
            //    {
            //        MessageBox.Show( "使用单位(人)不可为空" );
            //        gridView4.FocusedRowHandle = i;
            //        return;
            //    }
            //    if ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AR007"].ToString( ) ) )
            //    {
            //        MessageBox.Show( "借款单位(人)不可为空" );
            //        gridView4.FocusedRowHandle = i;
            //        return;
            //    }
            //}
            strWhereFiv = "1=1";
            strWhereFiv = strWhereFiv + " AND AR001='" + gridView4.GetDataRow( 0 )["AR001"].ToString( ) + "'";
            DataTable dlTRE = _bll.GetDataTableOfAllFor( strWhereFiv );
            if ( tableTheSame( dlTRE ,tableQueryFor ) )
            {
                MessageBox.Show( "借款永灵保存数据成功" );
                gridView4.OptionsBehavior.Editable = false;
            }
            else
            {
                //try
                //{
                //    _bll.DeleteFors( tableFiv );
                //}
                //catch { }
                //finally { tableFiv = ""; }
                //result = _bll.AddNewFor( tableQueryFor );
                result = _bll.AddFiv( tableQueryFor );
                if ( result == true )
                {
                    MessageBox.Show( "借款永灵保存数据成功" );
                    gridView4.OptionsBehavior.Editable = false;

                }
                else
                {
                    MessageBox.Show( "借款永灵保存数据失败,请重试" );
                    return;
                }          
            }
            #endregion
            
            if ( result == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = false;
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" )
            {
                gridControl1.DataSource = null;
                gridView1.OptionsBehavior.Editable = false;
                gridControl2.DataSource = null;
                gridView2.OptionsBehavior.Editable = false;
                gridControl3.DataSource = null;
                bandedGridView1.OptionsBehavior.Editable = false;
                gridView3.OptionsBehavior.Editable = false;
                gridControl4.DataSource = null;
                gridView4.OptionsBehavior.Editable = false;
                gridControl5.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
                gridView2.OptionsBehavior.Editable = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                gridView3.OptionsBehavior.Editable = false;
                gridView4.OptionsBehavior.Editable = false;
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
            }
        }
        void comboboxItems ( )
        {
            repositoryItemComboBox2.Items.Clear( );
            repositoryItemComboBox3.Items.Clear( );
            repositoryItemComboBox4.Items.Clear( );
            repositoryItemComboBox7.Items.Clear( );
            repositoryItemComboBox1.Items.Clear( );
            DataTable da = _bll.GetDataTableCombo( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !repositoryItemComboBox2.Items.Contains( da.Rows[i]["YZ004"].ToString( ) ) )
                        repositoryItemComboBox2.Items.Add( da.Rows[i]["YZ004"].ToString( ) );
                    if ( !repositoryItemComboBox3.Items.Contains( da.Rows[i]["YZ005"].ToString( ) ) )
                        repositoryItemComboBox3.Items.Add( da.Rows[i]["YZ005"].ToString( ) );
                    if ( !repositoryItemComboBox4.Items.Contains( da.Rows[i]["YZ021"].ToString( ) ) )
                        repositoryItemComboBox4.Items.Add( da.Rows[i]["YZ021"].ToString( ) );
                    if ( !repositoryItemComboBox7.Items.Contains( da.Rows[i]["YZ020"].ToString( ) ) )
                        repositoryItemComboBox7.Items.Add( da.Rows[i]["YZ020"].ToString( ) );
                }
            }

            if ( Logins.number == "MLL-0001" )
                repositoryItemComboBox1.Items.AddRange( new string[] { "" ,"审核" ,"执行" } );
            else
                repositoryItemComboBox1.Items.AddRange( new string[] { "" ,"审核" } );
        }
        void comboboxItemsOne ( )
        {
            repositoryItemComboBox8.Items.Clear( );
            repositoryItemComboBox9.Items.Clear( );
            repositoryItemComboBox10.Items.Clear( );
            repositoryItemComboBox12.Items.Clear( );
            repositoryItemComboBox14.Items.Clear( );
            DataTable da = _bll.GetDataTableComboOne( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !repositoryItemComboBox9.Items.Contains( da.Rows[i]["AP004"].ToString( ) ) )
                        repositoryItemComboBox9.Items.Add( da.Rows[i]["AP004"].ToString( ) );
                    if ( !repositoryItemComboBox10.Items.Contains( da.Rows[i]["AP005"].ToString( ) ) )
                        repositoryItemComboBox10.Items.Add( da.Rows[i]["AP005"].ToString( ) );
                    if ( !repositoryItemComboBox11.Items.Contains( da.Rows[i]["AP021"].ToString( ) ) )
                        repositoryItemComboBox11.Items.Add( da.Rows[i]["AP021"].ToString( ) );
                    if ( !repositoryItemComboBox14.Items.Contains( da.Rows[i]["AP020"].ToString( ) ) )
                        repositoryItemComboBox14.Items.Add( da.Rows[i]["AP020"].ToString( ) );
                }
            }

            if ( Logins.number == "MLL-0001" )
                repositoryItemComboBox8.Items.AddRange( new string[] { "" ,"审核" ,"执行" } );
            else
                repositoryItemComboBox8.Items.AddRange( new string[] { "" ,"审核" } );
        }
        void comboboxItemsTwo ( )
        {
            repositoryItemComboBox15.Items.Clear( );
            repositoryItemComboBox16.Items.Clear( );
            repositoryItemComboBox17.Items.Clear( );
            DataTable da = _bll.GetDataTableComboTwo( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !repositoryItemComboBox15.Items.Contains( da.Rows[i]["AQ002"].ToString( ) ) )
                        repositoryItemComboBox15.Items.Add( da.Rows[i]["AQ002"].ToString( ) );
                    if ( !repositoryItemComboBox16.Items.Contains( da.Rows[i]["AQ011"].ToString( ) ) )
                        repositoryItemComboBox16.Items.Add( da.Rows[i]["AQ011"].ToString( ) );
                }
            }

            if ( Logins.number == "MLL-0001" )
                repositoryItemComboBox17.Items.AddRange( new string[] { "" ,"审核" ,"执行" } );
            else
                repositoryItemComboBox17.Items.AddRange( new string[] { "" ,"审核" } );
        }
        void comboboxItemsTre ( )
        {
            repositoryItemComboBox18.Items.Clear( );
            repositoryItemComboBox19.Items.Clear( );
            repositoryItemComboBox20.Items.Clear( );
            repositoryItemComboBox21.Items.Clear( );
            repositoryItemComboBox22.Items.Clear( );
            repositoryItemComboBox23.Items.Clear( );
            repositoryItemComboBox24.Items.Clear( );
            DataTable da = _bll.GetDataTableComboTre( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !repositoryItemComboBox19.Items.Contains( da.Rows[i]["AO004"].ToString( ) ) )
                        repositoryItemComboBox19.Items.Add( da.Rows[i]["AO004"].ToString( ) );
                    if ( !repositoryItemComboBox20.Items.Contains( da.Rows[i]["AO005"].ToString( ) ) )
                        repositoryItemComboBox20.Items.Add( da.Rows[i]["AO005"].ToString( ) );
                    if ( !repositoryItemComboBox21.Items.Contains( da.Rows[i]["AO006"].ToString( ) ) )
                        repositoryItemComboBox21.Items.Add( da.Rows[i]["AO006"].ToString( ) );
                    if ( !repositoryItemComboBox22.Items.Contains( da.Rows[i]["AO007"].ToString( ) ) )
                        repositoryItemComboBox22.Items.Add( da.Rows[i]["AO007"].ToString( ) );
                    if ( !repositoryItemComboBox23.Items.Contains( da.Rows[i]["AO008"].ToString( ) ) )
                        repositoryItemComboBox23.Items.Add( da.Rows[i]["AO008"].ToString( ) );
                    if ( !repositoryItemComboBox24.Items.Contains( da.Rows[i]["AO019"].ToString( ) ) )
                        repositoryItemComboBox24.Items.Add( da.Rows[i]["AO019"].ToString( ) );
                }
            }

            if ( Logins.number == "MLL-0001" )
                repositoryItemComboBox18.Items.AddRange( new string[] { "" ,"审核" ,"执行" } );
            else
                repositoryItemComboBox18.Items.AddRange( new string[] { "" ,"审核" } );
        }
        void comboboxItemsFor ( )
        {
            repositoryItemComboBox26.Items.Clear( );
            repositoryItemComboBox27.Items.Clear( );
            repositoryItemComboBox28.Items.Clear( );
            repositoryItemComboBox29.Items.Clear( );
            repositoryItemComboBox30.Items.Clear( );
            repositoryItemComboBox31.Items.Clear( );
            repositoryItemComboBox25.Items.Clear( );
            DataTable da = _bll.GetDataTableComboFor( );
            if ( da != null && da.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    if ( !repositoryItemComboBox26.Items.Contains( da.Rows[i]["AR004"].ToString( ) ) )
                        repositoryItemComboBox26.Items.Add( da.Rows[i]["AR004"].ToString( ) );
                    if ( !repositoryItemComboBox27.Items.Contains( da.Rows[i]["AR005"].ToString( ) ) )
                        repositoryItemComboBox27.Items.Add( da.Rows[i]["AR005"].ToString( ) );
                    if ( !repositoryItemComboBox28.Items.Contains( da.Rows[i]["AR006"].ToString( ) ) )
                        repositoryItemComboBox28.Items.Add( da.Rows[i]["AR006"].ToString( ) );
                    if ( !repositoryItemComboBox29.Items.Contains( da.Rows[i]["AR007"].ToString( ) ) )
                        repositoryItemComboBox29.Items.Add( da.Rows[i]["AR007"].ToString( ) );
                    if ( !repositoryItemComboBox30.Items.Contains( da.Rows[i]["AR008"].ToString( ) ) )
                        repositoryItemComboBox30.Items.Add( da.Rows[i]["AR008"].ToString( ) );
                    if ( !repositoryItemComboBox31.Items.Contains( da.Rows[i]["AR019"].ToString( ) ) )
                        repositoryItemComboBox31.Items.Add( da.Rows[i]["AR019"].ToString( ) );
                }
            }

            if ( Logins.number == "MLL-0001" )
                repositoryItemComboBox25.Items.AddRange( new string[] { "" ,"审核" ,"执行" } );
            else
                repositoryItemComboBox25.Items.AddRange( new string[] { "" ,"审核" } );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhereOne ) )
                strWhereOne = "1=1";
            tableQuery = _bll.GetDataTableOfAll( strWhereOne );
            gridControl1.DataSource = tableQuery;
            tableQueryFiv = _bll.GetDataTableOfAllFiv( );
            gridControl6.DataSource = tableQueryFiv;
            assignOne( );
        }
        void refreOne ( )
        {
            if ( string.IsNullOrEmpty( strWhereTwo ) )
                strWhereTwo = "1=1";
            tableQueryOne = _bll.GetDataTableOfAllOne( strWhereTwo );
            gridControl2.DataSource = tableQueryOne;
            tableQuerySix = _bll.GetDataTableOfAllSix( );
            gridControl7.DataSource = tableQuerySix;
            assignTwo( );
        }
        void refreTwo ( )
        {
            if ( string.IsNullOrEmpty( strWhereTre ) )
                strWhereTre = "1=1";
            tableQueryTwo = _bll.GetDataTableOfAllTwo( strWhereTre );
            gridControl3.DataSource = tableQueryTwo;
        }
        void refreTre ( )
        {
            if ( string.IsNullOrEmpty( strWhereFore ) )
                strWhereFore = "1=1";
            tableQueryTre = _bll.GetDataTableOfAllTre( strWhereFore );
            gridControl4.DataSource = tableQueryTre;
            assignTre( );
        }
        void refreFor ( )
        {
            if ( string.IsNullOrEmpty( strWhereFiv ) )
                strWhereFiv = "1=1";
            tableQueryFor = _bll.GetDataTableOfAllFor( strWhereFiv );
            gridControl5.DataSource = tableQueryFor;
            assignFor( );
        }
        bool tableTheSame ( DataTable dtOne ,DataTable dtTwo )
        {
            if ( dtOne == null || dtTwo == null )
                return false;
            if ( dtOne.Rows.Count != dtTwo.Rows.Count )
                return false;
            if ( dtOne.Columns.Count != dtTwo.Columns.Count )
                return false;
            for ( int i = 0 ; i < dtOne.Rows.Count ; i++ )
            {
                for ( int j = 0 ; j < dtOne.Columns.Count ; j++ )
                {
                    if ( dtOne.Rows[i][j].ToString( ) != dtTwo.Rows[i][j].ToString( ) )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        protected override void revirw ( )
        {
            base.revirw( );

            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
            {
                Reviews( "YZ001" ,_model.YZ001 ,"R_PQYZ" ,this ,_model.YZ001 ,"R_231" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
                return;
            }
            if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
            {
                Reviews( "AP001" ,_modelOne.AP001 ,"R_PQAP" ,this ,_modelOne.AP001 ,"R_231" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
                return;
            }
            if ( tabControl1.SelectedTab.Name == "tabPageTre" )
            {
                Reviews( "AQ001" ,_modelTwo.AQ001 ,"R_PQAQ" ,this ,_modelTwo.AQ001 ,"R_231" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
                return;
            }
            if ( tabControl1.SelectedTab.Name == "tabPageFor" )
            {
                Reviews( "AO001" ,_modelTre.AO001 ,"R_PQAO" ,this ,_modelTre.AO001 ,"R_231" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
                return;
            }
            if ( tabControl1.SelectedTab.Name == "tabPageFiv" )
            {
                Reviews( "AR001" ,_modelFor.AR001 ,"R_PQAR" ,this ,_modelFor.AR001 ,"R_231" ,false ,false ,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
                return;
            }
        }
        protected override void export ( )
        {
            if ( tabControl1 . SelectedTab . Name == "tabPageOne" )
                ViewExport . ExportToExcel ( this . tabPageOne . Text ,gridControl1 );
            if ( tabControl1 . SelectedTab . Name == "tabPageTwo" )
                ViewExport . ExportToExcel ( this . tabPageTwo . Text ,gridControl2 );
            if ( tabControl1 . SelectedTab . Name == "tabPageFor" )
                ViewExport . ExportToExcel ( this . tabPageTre . Text ,gridControl4 );
            if ( tabControl1 . SelectedTab . Name == "tabPageFiv" )
                ViewExport . ExportToExcel ( this . tabPageFor . Text ,gridControl5 );

            base . export ( );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
            {
                _model = new MulaolaoLibrary.PayMentLibrary( );
                SelectAll.PayMentOneAll queryOne = new SelectAll.PayMentOneAll( );
                //queryOne.StartPosition = FormStartPosition.CenterScreen;
                //queryOne.PassDataBetweenForm += new SelectAll.PayMentOneAll.PassDataBetweenFormHandler( queryOne_PassDataBetweenForm );
                //queryOne.ShowDialog( );
                if ( queryOne . ShowDialog ( ) == DialogResult . OK )
                {
                    strWhereOne = "1=1";
                    strWhereOne = strWhereOne + " AND "+ queryOne . getOdd;
                    _model . YZ001 = queryOne . getOddNum;

                    refre( );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled =toolcopy.Enabled = toolMaintain.Enabled = false;
                    sav = "2";
                    comboboxItems( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
            {
                _modelOne = new MulaolaoLibrary.PayMentOneLibrary( );
                SelectAll.PayMentTwoAll queryTwo = new SelectAll.PayMentTwoAll( );
                //queryTwo.StartPosition = FormStartPosition.CenterScreen;
                //queryTwo.PassDataBetweenForm += new SelectAll.PayMentTwoAll.PassDataBetweenFormHandler( queryTwo_PassDataBetweenForm );
                //queryTwo.ShowDialog( );
                if ( queryTwo . ShowDialog() == DialogResult . OK )
                {
                    strWhereTwo = "1=1";
                    strWhereTwo = strWhereTwo + " AND " + queryTwo . getOdd;
                    _modelOne . AP001 = queryTwo . getOddNum;

                    refreOne( );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                    sav = "2";
                    comboboxItemsOne( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTre" )
            {
                _modelTwo = new MulaolaoLibrary.QayMentTwoLibrary( );
                SelectAll.PayMentTreAll queryTre = new SelectAll.PayMentTreAll( );
                //queryTre.StartPosition = FormStartPosition.CenterScreen;
                //queryTre.PassDataBetweenForm += new SelectAll.PayMentTreAll.PassDataBetweenFormHandler( queryTre_PassDataBetweenForm );
                //queryTre.ShowDialog( );
                if ( queryTre . ShowDialog ( ) == DialogResult . OK )
                {
                    strWhereTre = "1=1";
                    strWhereTre = strWhereTre + " AND " + queryTre.getOdd;

                    _modelTwo . AQ001 = queryTre . getOddNum;

                    refreTwo( );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled =  toolcopy.Enabled = toolMaintain.Enabled = false;
                    sav = "2";
                    comboboxItemsTwo( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageFor" )
            {
                _modelTre = new MulaolaoLibrary.PayMentTreLibrary( );
                SelectAll.PayMentForAll queryFor = new SelectAll.PayMentForAll( );
                //queryFor.StartPosition = FormStartPosition.CenterScreen;
                //queryFor.PassDataBetweenForm += new SelectAll.PayMentForAll.PassDataBetweenFormHandler( queryFor_PassDataBetweenForm );
                //queryFor.ShowDialog( );
                if ( queryFor . ShowDialog ( ) == DialogResult . OK )
                {
                    strWhereFore = "1=1";
                    strWhereFore = strWhereFore + " AND " + queryFor . getOdd;

                    _modelTre . AO001 = queryFor . getOddNum;

                    refreTre( );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                    sav = "2";
                    comboboxItemsTre( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageFiv" )
            {
                _modelFor = new MulaolaoLibrary.PayMentForLibrary( );
                SelectAll.PayMentFivAll queryFiv = new SelectAll.PayMentFivAll( );
                //queryFiv.StartPosition = FormStartPosition.CenterScreen;
                //queryFiv.PassDataBetweenForm += new SelectAll.PayMentFivAll.PassDataBetweenFormHandler( queryFiv_PassDataBetweenForm );
                //queryFiv.ShowDialog( );
                if ( queryFiv . ShowDialog ( ) == DialogResult . OK )
                {
                    strWhereFiv = "1=1";
                    strWhereFiv = strWhereFiv + " AND " + queryFiv . getOdd;

                    _modelFor . AR001 = queryFiv . getOddNum;

                    refreFor( );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolcopy.Enabled = toolMaintain.Enabled = false;
                    sav = "2";
                    comboboxItemsFor( );
                }
            }
        }
        private void queryOne_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.YZ001 = e.ConOne;
        }
        private void queryTwo_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _modelOne.AP001 = e.ConOne;
        }
        private void queryTre_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _modelTwo.AQ001 = e.ConOne;
        }
        private void queryFor_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _modelTre.AO001 = e.ConOne;
        }
        private void queryFiv_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _modelFor.AR001 = e.ConOne;
        }
        #endregion

    }
}
