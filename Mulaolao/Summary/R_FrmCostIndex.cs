using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Summary
{
    public partial class R_FrmCostIndex : FormChild
    {
        public R_FrmCostIndex ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GridViewMoHuSelect . SetFilter ( gridView3 );
            GridViewMoHuSelect . SetFilter ( gridView4 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.CostIndexLibrary _model = new MulaolaoLibrary.CostIndexLibrary( );
        MulaolaoLibrary.CostIndexOneLibrary _modelOne = new MulaolaoLibrary.CostIndexOneLibrary( );
        MulaolaoBll.Bll.CostIndexBll _bll = new MulaolaoBll.Bll.CostIndexBll( );
        DataTable tableQuery, tableQueryOne, tableQueryTwo, tableQueryTre; SpecialPowers sp = new SpecialPowers( );
        bool result = false;string sign = "", weihu = "";
        
        private void R_FrmCostIndex_Load ( object sender ,EventArgs e )
        {
            Power( this );
            gridView1.OptionsBehavior.Editable = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
        }

        #region Event
        void assignMent ( )
        {
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                decimal at004Column = string.IsNullOrEmpty( AT004.SummaryItem.SummaryValue.ToString( ) ) == true ? 0 : Convert.ToDecimal( AT004.SummaryItem.SummaryValue.ToString( ) );
                decimal u5Colum = string.IsNullOrEmpty( U5.SummaryItem.SummaryValue.ToString( ) ) == true ? 0 : Convert.ToDecimal( U5.SummaryItem.SummaryValue.ToString( ) );
                U1.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Math.Round( at004Column == 0 ? 0 : Convert.ToDecimal( U0.SummaryItem.SummaryValue ) / at004Column ,4 ) * 100 ).ToString( ) + "%" );
                U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Math.Round( at004Column == 0 ? 0 : Convert.ToDecimal( U2.SummaryItem.SummaryValue ) / at004Column ,4 ) * 100 ).ToString( ) + "%" );
                U6.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round(  at004Column - u5Colum ,4 ).ToString( ) );
                U7.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,at004Column == 0 ? 0.ToString( ) : ( Math.Round( at004Column - u5Colum / at004Column ,4 ) * 100 ).ToString( ) + "%" );
            }
        }
        void assignMents ( )
        {
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                decimal sumOfCheJian = 0M, av3 = 0M, av4 = 0M, aw2 = 0M, aw3 = 0M, ax11 = 0M;
                av3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV003"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV003"].ToString( ) );
                av4 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV004"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV004"].ToString( ) );
                if ( tableQueryTre != null && tableQueryTre.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < gridView4.RowCount ; i++ )
                    {
                        if ( gridView4.GetDataRow( i )["AX002"].ToString( ) != "委外" )
                            sumOfCheJian = sumOfCheJian + ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AX003"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView4.GetDataRow( i )["AX003"].ToString( ) ) );
                    }
                    ax11 = Convert.ToInt32( AX011.SummaryItem.SummaryValue );
                }
                if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
                {
                    aw2 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) );
                    aw3 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) );
                }

                gridView3.SetRowCellValue( 0 ,gridView3.Columns["T1"] ,sumOfCheJian == 0 ? 0 : Math.Round( ( av3 - av4 - aw2 * aw3 - ax11 ) / sumOfCheJian ,4 ) );
            }
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                decimal av3 = 0M, av4 = 0M, aw2 = 0M, aw3 = 0M, b3 = 0M, ax11 = 0M;
                if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
                {
                    av3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV003"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV003"].ToString( ) );
                    av4 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV004"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV004"].ToString( ) );
                    b3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV002"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV002"].ToString( ) );
                }
                aw2 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) );
                aw3 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) );
                ax11 = Convert.ToInt32( AX011.SummaryItem.SummaryValue );

                bandedGridView1.SetRowCellValue( 0 ,bandedGridView1.Columns["T3"] ,av3 - av4 - Math.Round( aw2 * aw3 ) );
                bandedGridView1.SetRowCellValue( 0 ,bandedGridView1.Columns["T4"] ,b3 - aw2 );
                bandedGridView1.SetRowCellValue( 0 ,bandedGridView1.Columns["T6"] ,Math.Round( av3 - av4 - aw2 * aw3 ,0 ) - ax11 );
            }
            if ( tableQueryTre != null && tableQueryTre.Rows.Count > 0 )
            {
                decimal g3 = 0M, f3 = 0M, ax4 = 0M, ax8 = 0M, ax9 = 0M, av3 = 0M, av4 = 0M, aw2 = 0M, aw3 = 0M, ax11 = 0M, ax3 = 0M, sumOfCheJian = 0M;
                if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
                {
                    g3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView3.GetDataRow( 0 )["AV006"].ToString( ) );
                    f3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV005"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView3.GetDataRow( 0 )["AV005"].ToString( ) );
                    av3 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV003"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV003"].ToString( ) );
                    av4 = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV004"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView3.GetDataRow( 0 )["AV004"].ToString( ) );
                }
                if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
                {
                    aw2 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( 0 )["AW002"].ToString( ) );
                    aw3 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["AW003"].ToString( ) );
                }
                ax11 = Convert.ToInt32( AX011.SummaryItem.SummaryValue );
                for ( int i = 0 ; i < gridView4.RowCount ; i++ )
                {
                    ax3 = string.IsNullOrEmpty( gridView4.GetDataRow( i )["AX003"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView4.GetDataRow( i )["AX003"].ToString( ) );
                    ax8 = string.IsNullOrEmpty( gridView4.GetDataRow( i )["AX008"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView4.GetDataRow( i )["AX008"].ToString( ) );
                    ax9 = string.IsNullOrEmpty( gridView4.GetDataRow( i )["AX009"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView4.GetDataRow( i )["AX009"].ToString( ) );
                    if ( gridView4.GetDataRow( i )["AX002"].ToString( ) != "委外" )
                        sumOfCheJian = ( string.IsNullOrEmpty( gridView4.GetDataRow( i )["AX003"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView4.GetDataRow( i )["AX003"].ToString( ) ) );
                    gridView4.SetRowCellValue( i ,gridView4.Columns["T7"] ,Math.Round( ax8 * g3 ,0 ) );
                    gridView4.SetRowCellValue( i ,gridView4.Columns["T8"] ,Math.Round( ax9 * f3 ,0 ) );
                    gridView4.SetRowCellValue( i ,gridView4.Columns["T12"] ,sumOfCheJian == 0 ? 0 : Math.Round( ax3 * ( av3 - av4 - aw2 * aw3 - ax11 ) / sumOfCheJian ,0 ) );
                }
                ax4 = Convert.ToDecimal( AX004.SummaryItem.SummaryValue );
                T7.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( AX008.SummaryItem.SummaryValue ) * g3 ,0 ).ToString( ) );
                T8.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( AX009.SummaryItem.SummaryValue ) * f3 ,0 ).ToString( ) );
                T10.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Math.Round( Convert.ToDecimal( AX010.SummaryItem.SummaryValue ) / Convert.ToDecimal( AX004.SummaryItem.SummaryValue ) ,4 ) * 100 ).ToString( ) + "%" );
                T11.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( AX003.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : ( Math.Round( Convert.ToDecimal( AX011.SummaryItem.SummaryValue ) / Convert.ToDecimal( AX003.SummaryItem.SummaryValue ) ,4 ) * 100 ).ToString( ) + "%" );
                T14.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,ax4 == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( T13.SummaryItem.SummaryValue ) / ax4 ,0 ).ToString( ) );
                T15.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,ax4 == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( AX012.SummaryItem.SummaryValue ) / ax4 ,0 ).ToString( ) );
                T16.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( T13.SummaryItem.SummaryValue ) + Convert.ToDecimal( AX012.SummaryItem.SummaryValue ) ,0 ).ToString( ) );
                T18.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,ax4 == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( T17.SummaryItem.SummaryValue ) / ax4 ,0 ).ToString( ) );
                T19.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( T17.SummaryItem.SummaryValue ) * Convert.ToDecimal( 0.1 ) ,0 ).ToString( ) );
                T20.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( AX005.SummaryItem.SummaryValue ) * Convert.ToDecimal( 0.04 ) ,0 ).ToString( ) );
                T21.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( AX006.SummaryItem.SummaryValue ) * Convert.ToDecimal( 0.05 ) ,0 ).ToString( ) );
                T22.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( AX007.SummaryItem.SummaryValue ) * Convert.ToDecimal( 0.055 ) ,0 ).ToString( ) );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( !string.IsNullOrEmpty( gridView1.GetDataRow( 0 )["AT020"].ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( gridView1.GetDataRow( 0 )["AT020"].ToString( ) );
        }
        private void gridView3_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( !string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV001"].ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( gridView3.GetDataRow( 0 )["AV001"].ToString( ) );
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["AW001"].ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( bandedGridView1.GetDataRow( 0 )["AW001"].ToString( ) );
        }
        private void gridView4_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( !string.IsNullOrEmpty( gridView4.GetDataRow( 0 )["AX001"].ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( gridView4.GetDataRow( 0 )["AX001"].ToString( ) );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            gridControl1 . DataSource = null;
            gridControl1 . RefreshDataSource ( );
            _model .AT001 = oddNumbers.purchaseContract( "SELECT MAX(AT001) AT001 FROM R_PQAT" ,"AT001" ,"R_512-" );

            sign = "1";

            gridView1.OptionsBehavior.Editable = true;
            gridView3.OptionsBehavior.Editable = true;
            gridView4.OptionsBehavior.Editable = true;
            bandedGridView1.OptionsBehavior.Editable = true;
            dateTimePicker1.Enabled = true;
            button1.Enabled = true;

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

                dele( );
        }
        void dele ( )
        {
            #region GridView1
            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
            {
                result = _bll.Delete( _model.AT001 );
                if ( result == true )
                {
                    MessageBox.Show( "成功删除数据" );
                    gridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "删除数据失败" );
                    return;
                }
            }
            #endregion

            #region GridView3
            if ( tabControl1.SelectedTab.Name == "tabPageTre" )
            {
                result = _bll.DeleteTwo( _modelOne.AX001 );
                if ( result == true )
                {
                    MessageBox.Show( "成功删除数据" );
                    gridView3.OptionsBehavior.Editable = false;
                    gridView4.OptionsBehavior.Editable = false;
                    bandedGridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "删除数据失败" );
                    return;
                }
            }
            #endregion

            if ( result == true )
            {
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
                toolAdd.Enabled = toolSelect.Enabled = true;
                gridControl1.DataSource = null;
                tableQuery = null;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
        }
        protected override void update ( )
        {
            base.update( );

            sign = "2";

            gridView1.OptionsBehavior.Editable = true;
            gridView3.OptionsBehavior.Editable = true;
            gridView4.OptionsBehavior.Editable = true;
            bandedGridView1.OptionsBehavior.Editable = true;
            dateTimePicker1.Enabled = true;
            button1.Enabled = true;

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void revirw ( )
        {
            base.revirw( );
        }
        protected override void save ( )
        {
            base.save( );

            gridView1.ClearColumnsFilter( );
            gridView3.ClearColumnsFilter( );
            gridView4.ClearColumnsFilter( );
            bandedGridView1.ClearColumnsFilter( );

            #region GridView1
            gridView1.UpdateCurrentRow( );
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                result = _bll.AddTable( tableQuery );
                if ( result == true )
                {
                    //MessageBox.Show( "保存数据成功" );
                    gridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "保存数据失败,请重试" );
                    return;
                }
            }
            #endregion

            #region GridView3
            gridView3.UpdateCurrentRow( );
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                result = _bll.AddTableOne( tableQueryOne );
                if ( result == true )
                {
                    //MessageBox.Show( "保存数据成功" );
                    gridView3.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "保存数据失败,请重试" );
                    return;
                }
            }
            #endregion

            #region BandedGridView1
            bandedGridView1.UpdateCurrentRow( );
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                result = _bll.AddTableTwo( tableQueryTwo );
                if ( result == true )
                {
                    //MessageBox.Show( "保存数据成功" );
                    bandedGridView1.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "保存数据失败" );
                    return;
                }
            }
            #endregion

            #region GridView4
            gridView4.UpdateCurrentRow( );
            if ( tableQueryTre != null && tableQueryTre.Rows.Count > 0 )
            {
                result = _bll.AddTableTre( tableQueryTre );
                if ( result == true )
                {
                    //MessageBox.Show( "保存数据成功" );
                    gridView4.OptionsBehavior.Editable = false;
                }
                else
                {
                    MessageBox.Show( "保存数据失败" );
                    return;
                }
            }
            #endregion

            if ( result == true )
            {
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;

                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                sign = weihu = "";
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                try
                {
                    result = _bll.Delete( _model.AT001 );
                }
                catch { }
                finally
                {
                    gridView1.OptionsBehavior.Editable = false;
                    bandedGridView1.OptionsBehavior.Editable = false;
                    gridView3.OptionsBehavior.Editable = false;
                    gridView4.OptionsBehavior.Editable = false;
                    dateTimePicker1.Enabled = false;
                    button1.Enabled = false;
                    gridControl1.DataSource = null;
                    toolAdd.Enabled = toolSelect.Enabled =  true;
                    toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                }
            }
            else
            {
                gridView1.OptionsBehavior.Editable = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                gridView3.OptionsBehavior.Editable = false;
                gridView4.OptionsBehavior.Editable = false;
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled =  false;
            }
        }
        protected override void maintain ( )
        {
            base.maintain( );

            //if ( label45.Visible == true )
            //{
            //    gridView1.OptionsBehavior.Editable = false;
            //    dateTimePicker1.Enabled = false;
            //    button1.Enabled = false;
            //    toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            //    toolSave.Enabled = toolCancel.Enabled = true;
            //    weihu = "1";
            //}
            //else
            //    MessageBox.Show( "单据状态为非执行,请更改或删除" );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.CostIndexLibrary( );

            SelectAll.CostIndexAll query = new SelectAll.CostIndexAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.CostIndexAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( _model.AT001 != null )
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.AT001 = e.ConOne;
            //if ( e.ConTwo == "执行" )
            //    label45.Visible = true;
            //else
            //    label45.Visible = false;
        }
        void autoQuery ( )
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView3.OptionsBehavior.Editable = false;
            gridView4.OptionsBehavior.Editable = false;
            bandedGridView1.OptionsBehavior.Editable = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled =toolExport.Enabled= toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            refre( );
        }
        #endregion

        #region Table
        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            //if ( tableQuery!=null && tableQuery.Rows.Count > 0 )
            //{
            //    if ( gridView1.GetDataRow( 0 )["AT020"].ToString( ) != dateTimePicker1.Value.ToString( "yyyy-MM-dd" ) )
            //        dateTimePicker1.Value = string.IsNullOrEmpty( gridView1.GetDataRow( 0 )["AT020"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( gridView1.GetDataRow( 0 )["AT020"].ToString( ) );
            //}
            //if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            //{
            //    if ( gridView3.GetDataRow( 0 )["AV001"].ToString( ) != dateTimePicker1.Value.ToString( "yyyy-MM-dd" ) )
            //        dateTimePicker1.Value = string.IsNullOrEmpty( gridView3.GetDataRow( 0 )["AV001"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( gridView3.GetDataRow( 0 )["AV001"].ToString( ) );
            //}
            
            _model.AT020 = _modelOne.AV001 = _modelOne.AX001 = _modelOne.AW001 = dateTimePicker1.Value;
            if ( tabControl1.SelectedTab.Name == "tabPageOne" || tabControl1.SelectedTab.Name == "tabPageTwo" )
            {
                result = _bll.GetDataTableGenerate( _model );
                if ( result == true )
                {
                    MessageBox.Show( "生成成功" );
                    refre( );
                }
                else
                    MessageBox.Show( "生成失败" );
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTre" )
            {
                result = _bll.GetDataTableGenerate( _modelOne );
                if ( result == true )
                {
                    MessageBox.Show( "生成成功" );
                    refres( );
                }
                else
                    MessageBox.Show( "生成失败" );
            }
           
        }
        void refre ( )
        {
            tableQuery = _bll.GetDataTable( _model.AT001 );
            gridControl1.DataSource = tableQuery;
            gridControl2.DataSource = _bll.GetDataTableTwo( dateTimePicker1.Value.Year );
            assignMent( );
        }
        void refres ( )
        {        
            tableQueryOne = _bll.GetDataTable( _modelOne.AV001 );
            gridControl3.DataSource = tableQueryOne;
            tableQueryTwo = _bll.GetDataTableOne( _modelOne.AW001 );
            gridControl4.DataSource = tableQueryTwo;
            tableQueryTre = _bll.GetDataTableTwo( _modelOne.AX001 );
            gridControl5.DataSource = tableQueryTre;
            assignMents( );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( tabControl1.SelectedTab.Name == "tabPageOne" )
            {
                if ( gridView1.RowCount > 0 )
                {
                    _model.AT001 = gridView1.GetDataRow( 0 )["AT001"].ToString( );
                    refre( );
                }
            }
            else if ( tabControl1.SelectedTab.Name == "tabPageTwo" )
                gridControl2.DataSource = _bll.GetDataTableTwo( dateTimePicker1.Value.Year );
            else
            {
                _modelOne.AV001 = _modelOne.AW001 = _modelOne.AX001 = dateTimePicker1.Value;
                refres( );
            }
        }
        #endregion
    }
}
