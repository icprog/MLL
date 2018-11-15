using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;


namespace Mulaolao . Wages
{
    public partial class R_FrmTargetActualWarn : FormChild
    {
        MulaolaoLibrary.TargetActualWarnLibrary _model = null;
        public R_FrmTargetActualWarn ( )
        {
            InitializeComponent( );
            _model = new MulaolaoLibrary . TargetActualWarnLibrary ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        //月完成出货产值只能按某月查询个人或总计。若按全年查则会累计错误。
        /*
         *周家任   1月  ERP:1000  出货：800
         *         2月            出货：200
         *         2月  ERP:2000  出货:1200
         *         3月            出货:800
         *         
         *         以上情况，若查询1和2月  则多出1月的200
        */
        
        
        MulaolaoBll.Bll.TargetActualWarnBll _bll = new MulaolaoBll.Bll.TargetActualWarnBll( );
        bool result = false;
        DataTable tableQuery,tableQueryTotal;
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        
        private void R_FrmTargetActualWarn_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            gridControl1.DataSource = null;

            GridViewMoHuSelect.SetFilter( gridView1 );
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );

            _model.SZ001 = oddNumbers.purchaseContract( "SELECT MAX(SZ001) SZ001 FROM R_PQSZ" ,"SZ001" ,"R_468-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            result = _bll.Delete( _model.SZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除记录" );
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                gridControl1.DataSource = null;
            }
            else
                MessageBox.Show( "删除记录失败" );
        }
        protected override void update ( )
        {
            base.update( );

            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }
        #endregion

        #region Table
        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            //_model = new MulaolaoLibrary . TargetActualWarnLibrary ( );
            _model.SZ003 = dateTimePicker1.Value.Year;
            result = _bll.Generate( _model );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                result = _bll . InsertOfAll ( _model . SZ001 );
                button2_Click( null ,null );
            }
            else
                MessageBox.Show( "生成失败" );
        }
        //Refresh
        private void button2_Click ( object sender ,EventArgs e )
        {
            tableQuery = _bll.GetDataTable( _model.SZ001 );
            gridControl1.DataSource = tableQuery;
            tableQueryTotal = _bll . GetDataTableTotal ( _model . SZ001 );
            gridControl2 . DataSource = tableQueryTotal;
            //assignMent ( );
        }
        void assignMent ( )
        {
            //if ( gridView1 . DataRowCount > 0 )
            //{
            //    U2 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( SZ011 . SummaryItem . SummaryValue ) ) . ToString ( ) );
            //    U3 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( SZ011 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) * 100 ,1 ) . ToString ( ) + "%" );
            //    U4 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( SZ012 . SummaryItem . SummaryValue ) ) . ToString ( ) );
            //    U5 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( SZ012 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( SZ005 . SummaryItem . SummaryValue ) * 100 ,1 ) . ToString ( ) + "%" );
            //    U6 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( SZ004 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( SZ012 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( SZ004 . SummaryItem . SummaryValue ) * 100 ,1 ) . ToString ( ) + "%" );
            //}
       }
        //Edit
        private void button3_Click ( object sender ,EventArgs e )
        {
            //_model = new MulaolaoLibrary . TargetActualWarnLibrary ( );
            _model.SZ004 = string.IsNullOrEmpty( textBox1.Text ) == true ? 0M : Convert.ToDecimal( textBox1.Text );
            result = _bll.UpdateOne( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑" );
                int num = gridView1.FocusedRowHandle;
                button2_Click( null ,null );
                gridView1.FocusedRowHandle = num;
            }
            else
                MessageBox.Show( "编辑失败" );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            SelectAll.TargetActualWarnAll query = new SelectAll.TargetActualWarnAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.TargetActualWarnAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( _model.SZ001 != null )
            {
                button2_Click( null ,null );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model = new MulaolaoLibrary . TargetActualWarnLibrary ( );
            _model.SZ001 = e.ConOne;
        }
        #endregion

        #region Event
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb( textBox1 );
        }
        private void textBox_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1.Text != "" && !DateDayRegise . elevenTwoNumber( textBox1 ) )
            {
                textBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最九两位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( e.RowHandle >= 0 && e.RowHandle <= gridView1 . DataRowCount - 1 )
            {
                DataRow row = gridView1 . GetDataRow ( e . RowHandle );
                if ( row == null )
                    return;
                string emNum = row [ "SZ010" ] . ToString ( ); //gridView1 . GetFocusedRowCellValue ( "SZ010" ) . ToString ( );
                if ( emNum != "总计生产部" && emNum != "总计业务部" )
                {
                    if ( row [ "idx" ] == null )
                        return;
                    string str = row [ "idx" ] . ToString ( );
                    _model . IDX = string . IsNullOrEmpty ( str ) == true ? 0 : Convert . ToInt32 ( str );
                    if ( _model . IDX > 0 )
                        assign ( );
                }
            }
        }
        void assign ( )
        {
            _model = _bll.GetModel( _model.IDX );
            textBox1 . Text = 0 . ToString ( );
            if ( _model == null )
            {
                _model = new MulaolaoLibrary . TargetActualWarnLibrary ( );
                return;
            }
            textBox1.Text = _model.SZ004.ToString( );
        }
        private void gridView1_RowStyle ( object sender ,DevExpress . XtraGrid . Views . Grid . RowStyleEventArgs e )
        {
        }
        private void gridView1_CustomDrawRowFooterCell ( object sender ,DevExpress . XtraGrid . Views . Grid . FooterCellCustomDrawEventArgs e )
        {
            Decimal dOne = 0M, dTwo = 0M, dTre = 0M;
            if ( e . Column == this . U2 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) );
                e . Info . DisplayText = ( dOne - dTwo ) . ToString ( );
            }
            if ( e . Column == this . U3 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
            if ( e . Column == this . U4 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                e . Info . DisplayText = ( dOne - dTwo ) . ToString ( );
            }
            if ( e . Column == this . U5 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
            if ( e . Column == this . U6 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ004 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ004 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
        }
        private void gridView2_CustomDrawRowFooterCell ( object sender ,DevExpress . XtraGrid . Views . Grid . FooterCellCustomDrawEventArgs e )
        {
            Decimal dOne = 0M, dTwo = 0M, dTre = 0M;
            if ( e . Column == this . H6 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) );
                e . Info . DisplayText = ( dOne - dTwo ) . ToString ( );
            }
            if ( e . Column == this . H7 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ011 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
            if ( e . Column == this . H9 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                e . Info . DisplayText = ( dOne - dTwo ) . ToString ( );
            }
            if ( e . Column == this . H10 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
            if ( e . Column == this . H11 )
            {
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ004 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ004 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . SZ012 ) );
                dTre = dOne == 0 ? 0 : Math . Round ( dTwo / dOne * 100 ,1 );
                e . Info . DisplayText = dTre . ToString ( ) + "%";
            }
        }
        #endregion

    }
}
