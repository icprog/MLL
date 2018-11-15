using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmWorkWages:FormChild
    {
        public R_FrmWorkWages ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        

        MulaolaoBll.Bll.WorkWagesBll _bll = new MulaolaoBll.Bll.WorkWagesBll( );
        MulaolaoLibrary.WorkWagesLibrary _model = new MulaolaoLibrary.WorkWagesLibrary( );
        
        bool result = false;
        DataTable tableQuery;

        private void R_FrmWorkWages_Load ( object sender ,EventArgs e )
        {
            Power( this );
            GridViewMoHuSelect.SetFilter( bandedGridView1 );
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
            gridControl1.DataSource = null;
        }
        
        #region Table
        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            _model.TZ001 = dateTimePicker1.Value.Year;
            _model.TZ002 = dateTimePicker1.Value.Month;
            string yearMonth = dateTimePicker1.Value.ToString( "yyyyMM" );
            result = _bll.GetDataTableOne( _model );
            if ( result == true )
                refre( );
            else
                MessageBox.Show( "317本月考勤和工资生成数据失败" );
            result = _bll.GetDataTableTwo( _model );
            if ( result == true )
                refre( );
            else
                MessageBox.Show( "317累计考勤和工资生成数据失败" );
            result = _bll.GetDataTableTre( _model ,yearMonth );
            if ( result == true )
                refre( );
            else
                MessageBox.Show( "323本月考勤和工资生成数据失败" );
            result = _bll.GetDataTableFor( _model ,yearMonth );
            if ( result == true )
                refre( );
            else
                MessageBox.Show( "317累计已结考勤和工资生成数据失败" );
        }
        void refre ( )
        {
            tableQuery = _bll.GetDataTables( _model.TZ015 );
            gridControl1.DataSource = tableQuery;
            assignMnet( );
        }
        void assignMnet ( )
        {
            F3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( TZ006.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( TZ010.SummaryItem.SummaryValue ) / Convert.ToDecimal( TZ006.SummaryItem.SummaryValue ) ,1 ).ToString( ) );
            F4.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( F1.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( F2.SummaryItem.SummaryValue ) / Convert.ToDecimal( F1.SummaryItem.SummaryValue ) ,1 ).ToString( ) );
            F5.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( TZ007.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( TZ011.SummaryItem.SummaryValue ) / Convert.ToDecimal( TZ007.SummaryItem.SummaryValue ) ,1 ).ToString( ) );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            _model.TZ015 = oddNumbers.purchaseContract( "SELECT MAX(TZ015) TZ015 FROM R_PQTZ" ,"TZ015" ,"R_324-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            dateTimePicker1.Enabled = true;
            button1.Enabled = true;
            gridControl1.DataSource = null;
        }
        protected override void delete ( )
        {
            base.delete( );

            result = _bll.Delete( _model.TZ015 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled =  true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            dateTimePicker1.Enabled = true;
            button1.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.WorkWagesLibrary( );
            SelectAll.WorkWagesAll work = new SelectAll.WorkWagesAll( );
            work.PassDataBetweenForm += new SelectAll.WorkWagesAll.PassDataBetweenFormHandler( work_PassDataBetweenForm );
            work.StartPosition = FormStartPosition.CenterScreen;
            work.ShowDialog( );
            if ( _model.TZ015 != null )
            {
                tableQuery = _bll.GetDataTables( _model.TZ015 );
                gridControl1.DataSource = tableQuery;
                assignMnet( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolcopy.Enabled = false;
                dateTimePicker1.Enabled = false;
                button1.Enabled = false;
            }
        }
        private void work_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.TZ015 = e.ConOne;
        }
        #endregion

        #region Event
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assign( );
            }
        }
        void assign ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( !string.IsNullOrEmpty( _model.TZ001.ToString( ) ) && !string.IsNullOrEmpty( _model.TZ002.ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( _model.TZ001.ToString( ) + "年" + _model.TZ002.ToString( ) + "月" + "01" + "日" );
        }
        #endregion

    }
}
