using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmWagesCostComparison : FormChild
    {
        public R_FrmWagesCostComparison ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoBll.Bll.WagesCostComparisonBll _bll = new MulaolaoBll.Bll.WagesCostComparisonBll( );
        MulaolaoLibrary.WagesCostComparisonLibrary _model = new MulaolaoLibrary.WagesCostComparisonLibrary( );
        DataTable tableQuery;
        bool result = false;
        
        private void R_FrmWagesCostComparison_Load ( object sender ,EventArgs e )
        {
            Power( this );
            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            gridControl1.DataSource = null;
        }
        
        #region Table
        //Generate
        private void button1_Click ( object sender ,EventArgs e )
        {
            _model.UZ002 = dateTimePicker1.Value.Year;
            _model.UZ003 = dateTimePicker1.Value.Month;
            result = _bll.Insert( _model );
            if ( result == true )
            {
                MessageBox.Show( "生成数据成功" );
                tableQuery = _bll.GetDataTable( _model );
                gridControl1.DataSource = tableQuery;
            }
            else
                MessageBox.Show( "生成数据失败" );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            button1.Enabled = true;
            dateTimePicker1.Enabled = true;
            gridControl1.DataSource = null;
            _model.UZ001 = oddNumbers.purchaseContract( "SELECT MAX(UZ001) UZ001 FROM R_PQUZ" ,"UZ001" ,"R_" );
        }
        protected override void delete ( )
        {
            base.delete( );

            result = _bll.Delete( _model.UZ001 );
            if ( result == true )
            {
                button1.Enabled = false;
                dateTimePicker1.Enabled = false;
                gridControl1.DataSource = null;
                toolAdd.Enabled = toolSelect.Enabled =  true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            button1.Enabled = true;
            dateTimePicker1.Enabled = true;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled =  true;
            toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;

        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.WagesCostComparisonLibrary( );
            SelectAll.WagesCostComparisonAll query = new SelectAll.WagesCostComparisonAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.WagesCostComparisonAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( _model.UZ001 != null )
            {
                tableQuery = _bll.GetDataTable( _model.UZ001 );
                gridControl1.DataSource = tableQuery;
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolExport . Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                button1.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.UZ001 = e.ConOne;
        }
        #endregion

        #region
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.DataRowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( !string.IsNullOrEmpty( _model.UZ002.ToString( ) ) && !string.IsNullOrEmpty( _model.UZ003.ToString( ) ) )
                dateTimePicker1.Value = Convert.ToDateTime( _model.UZ002.ToString( ) + "年" + _model.UZ003.ToString( ) + "月" + "01日" );
        }
        #endregion
    }
}
