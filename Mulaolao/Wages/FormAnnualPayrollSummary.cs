using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class FormAnnualPayrollSummary :FormChild
    {
        MulaolaoLibrary.AnnualPayrollSummaryEntity _model=null;
        MulaolaoBll.Bll.AnnualPayrollSummaryBll _bll=null;
        bool result=false;
        DataTable tableView;
        
        public FormAnnualPayrollSummary ( )
        {
            InitializeComponent ( );

            _model = new MulaolaoLibrary . AnnualPayrollSummaryEntity ( );
            _bll = new MulaolaoBll . Bll . AnnualPayrollSummaryBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            //toolStrip1 . Items . Remove ( toolAdd );
            //toolStrip1 . Items . Remove ( toolReview );
            //toolStrip1 . Items . Remove ( toolPrint );
            //toolStrip1 . Items . Remove ( toolExport );
            //toolStrip1 . Items . Remove ( toolMaintain );
            //toolStrip1 . Items . Remove ( toolStorage );
            //toolStrip1 . Items . Remove ( toolLibrary );
            //toolStrip1 . Items . Remove ( toolcopy );

            gridView1 . OptionsBehavior . Editable = false;
        }
        
        protected override void select ( )
        {
            tableView = _bll . getTableView ( dtp . Value . Year );
            gridControl1 . DataSource = tableView;
            assignMent ( );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            gridView1 . OptionsBehavior . Editable = false;

            base . select ( );
        }
        protected override void update ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;

            gridView1 . OptionsBehavior . Editable = true;

            base . update ( );
        }
        protected override void delete ( )
        {
            result = _bll . Delete ( dtp . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;

                gridView1 . OptionsBehavior . Editable = false;
                gridControl1 . DataSource = null;
            }
            else
                MessageBox . Show ( "删除失败" );

            base . delete ( );
        }
        protected override void save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolReview . Enabled = toolMaintain . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            gridView1 . OptionsBehavior . Editable = false;

            base . cancel ( );
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }

        private void btnRead_Click ( object sender ,System . EventArgs e )
        {
            result = _bll . Read ( dtp . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "成功读取" );
                select ( );
            }
            else
                MessageBox . Show ( "读取失败" );
        }

        void assignMent ( )
        {
            if ( gridView1 . DataRowCount > 0 )
            {
                decimal _u6 = Convert . ToDecimal ( U6 . SummaryItem . SummaryValue );
                decimal _u1 = Convert . ToDecimal ( U1 . SummaryItem . SummaryValue );
                decimal _u3 = Convert . ToDecimal ( U3 . SummaryItem . SummaryValue );
                decimal _ps004 = Convert . ToDecimal ( PS004 . SummaryItem . SummaryValue );
                decimal _ps007 = Convert . ToDecimal ( PS007 . SummaryItem . SummaryValue );

                //U10 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_ps007 == 0 ? 0 . ToString ( ) : Math . Round ( _u6 / _ps007 ,2 ) . ToString ( ) );
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_u1 == 0 ? 0 . ToString ( ) : Math . Round ( _u6 / _u1 ,2 ) . ToString ( ) );
                U12 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_ps004 == 0 ? 0 . ToString ( ) : Math . Round ( _u6 / _ps004 ,2 ) . ToString ( ) );
                //U13 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_ps007 == 0 ? 0 . ToString ( ) : Math . Round ( _u3 / _ps007 ,2 ) . ToString ( ) );
                U14 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_u1 == 0 ? 0 . ToString ( ) : Math . Round ( _u3 / _u1 ,2 ) . ToString ( ) );
                U15 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,_ps004 == 0 ? 0 . ToString ( ) : Math . Round ( _u3 / _ps004 ,2 ) . ToString ( ) );
            }
        }

        private void FormAnnualPayrollSummary_Load ( object sender ,EventArgs e )
        {

        }

        private void btnBatchEdit_Click ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetDataRow ( 0 );
            if ( row != null )
            {
                _model . PS016 = string . IsNullOrEmpty ( row [ "PS016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS016" ] . ToString ( ) );
                _model . PS017 = string . IsNullOrEmpty ( row [ "PS017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS017" ] . ToString ( ) );
                _model . PS018 = string . IsNullOrEmpty ( row [ "PS018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS018" ] . ToString ( ) );
                _model . PS019 = string . IsNullOrEmpty ( row [ "PS019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS019" ] . ToString ( ) );
                _model . PS020 = string . IsNullOrEmpty ( row [ "PS020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS020" ] . ToString ( ) );
                _model . PS021 = string . IsNullOrEmpty ( row [ "PS021" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS021" ] . ToString ( ) );
                _model . PS022 = string . IsNullOrEmpty ( row [ "PS022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS022" ] . ToString ( ) );
                _model . PS024 = string . IsNullOrEmpty ( row [ "PS024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS024" ] . ToString ( ) );
                _model . PS025 = string . IsNullOrEmpty ( row [ "PS025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS025" ] . ToString ( ) );
                _model . PS026 = string . IsNullOrEmpty ( row [ "PS026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS026" ] . ToString ( ) );
                _model . PS027 = string . IsNullOrEmpty ( row [ "PS027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PS027" ] . ToString ( ) );
                for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                {
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS016" ] ,_model . PS016 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS017" ] ,_model . PS017 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS018" ] ,_model . PS018 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS019" ] ,_model . PS019 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS020" ] ,_model . PS020 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS021" ] ,_model . PS021 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS022" ] ,_model . PS022 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS024" ] ,_model . PS024 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS025" ] ,_model . PS025 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS026" ] ,_model . PS026 );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "PS027" ] ,_model . PS027 );
                }
            }
        }

    }
}
