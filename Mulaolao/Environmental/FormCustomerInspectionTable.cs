using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormCustomerInspectionTable :FormChild
    {
        MulaolaoLibrary.CustomerInspectionTableDMEntity _dm=null;
        MulaolaoBll.Bll.CustomerInspectionTableBll _bll=null;
        
        public FormCustomerInspectionTable ( )
        {
            InitializeComponent ( );
             
            _dm = new MulaolaoLibrary . CustomerInspectionTableDMEntity ( );
            _bll = new MulaolaoBll . Bll . CustomerInspectionTableBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            toolDelete . Enabled = true;
        }
        
        protected override void delete ( )
        {
            bool result = _bll . Delete ( dateTimePicker1 . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                gridControl1 . DataSource = null;
            }
            else
                MessageBox . Show ( "删除失败" );

            base . delete ( );
        }
        
        //读取
        private void button1_Click ( object sender ,EventArgs e )
        {
            bool result = _bll . Read ( dateTimePicker1 . Value . Year );
            if ( result )
            {
                DataTable tableView = _bll . getTableView ( dateTimePicker1 . Value . Year );
                gridControl1 . DataSource = tableView;
            }
            else
                MessageBox . Show ( "读取失败,请重试" );
        }
        private void gridView1_CustomDrawRowFooterCell ( object sender ,DevExpress . XtraGrid . Views . Grid . FooterCellCustomDrawEventArgs e )
        {
            decimal dOne = 0M, dTwo = 0M, dTre = 0M;
            if ( e . Column == this . U0 )
            {
                //([DM006]+[DM009]) * 1.0 / [DM005]
                dOne = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM005 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM005 ) );
                dTwo = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM006 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM006 ) );
                dTre = this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM009 ) == "" ? 0 : Convert . ToDecimal ( this . gridView1 . GetRowFooterCellText ( e . RowHandle ,this . DM009 ) );
                e . Info . DisplayText = dOne == 0 ? ( 0.0 ) . ToString ( ) + "%" : ( Math . Round ( Convert . ToDecimal ( ( dTwo + dTre ) * Convert . ToDecimal ( 1.0 ) / dOne ) * 100 ,1 ) ) . ToString ( ) + "%";
            }
        }

    }
}
