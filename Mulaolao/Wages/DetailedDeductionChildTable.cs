using System;
using System . Collections . Generic;
using System . Data;
using System . Threading . Tasks;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class DetailedDeductionChildTable :Form
    {
        MulaolaoLibrary.DetailedDeductionWYLibrary _wy=null;
        MulaolaoBll.Bll.DetailedDeductionBll _bll =null;
        DataTable tableView;
        List<string> indList=new List<string>();

        public DetailedDeductionChildTable ( int idx )
        {
            InitializeComponent ( );
            
            _wy = new MulaolaoLibrary . DetailedDeductionWYLibrary ( );
            _bll = new MulaolaoBll . Bll . DetailedDeductionBll ( );
            _wy . idx = idx;
            //Task<DataTable> task = new Task<DataTable> ( getTableView ,_wy . idx );
            //task . Start ( );
            tableView = _bll . getTableOf ( Convert . ToInt32 ( idx ) );
            gridControl1 . DataSource = tableView;
        }
        
        DataTable getTableView ( object idx )
        {
            tableView = _bll . getTableOf ( Convert . ToInt32 ( idx ) );
            return tableView;
        }

        private void btnOK_Click ( object sender ,EventArgs e )
        {
            gridView1 . UpdateCurrentRow ( );
            gridView1 . CloseEditor ( );

            bool result = _bll . Save ( tableView ,indList ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void gridView1_ShowingEditor ( object sender ,System . ComponentModel . CancelEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            if ( gridView1 . FocusedColumn . FieldName == "WY002" && (row["WY004"].ToString().Equals("审核") || row [ "WY004" ] . ToString ( ) . Equals ( "执行" ) ) )
            {
                e . Cancel = true;
            }

        }

        private void gridView1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
           
        }

        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "WY001" ] ,_wy . idx );
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null && !( row [ "WY004" ] . ToString ( ) . Equals ( "执行" ) || row [ "WY004" ] . ToString ( ) . Equals ( "审核" ) ) )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                indList . Add ( row [ "idx" ] . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }

    }
}
