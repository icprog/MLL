using Mulaolao;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WarehouseReceiptLibr :Form
    {
        MulaolaoBll.Bll.WarehouseReceiptBll _bll=null;
        DataTable tableView;bool result=false;
        string userNum=string.Empty;

        public WarehouseReceiptLibr ( string userNum )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . WarehouseReceiptBll ( );
            tableView = new DataTable ( );

            DataTable dt = _bll . GetDataTableUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    cmbUser . Items . Add ( dt . Rows [ i ] [ "WAS013" ] . ToString ( ) );
                }
            }
            this . userNum = userNum;
        }
        
        private void WarehouseReceiptLibr_Load ( object sender ,EventArgs e )
        {         
            tableView = _bll . getTableView ( userNum );
            gridControl2 . DataSource = tableView;
            DataTable dt = _bll . getTableUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    cmbPerson . Items . Add ( dt . Rows [ i ] [ "WAS009" ] . ToString ( ) );
                }
            }
        }
        
        //确定
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( checkView ( ) == false )
                return;

            result = _bll . Library ( tableView ,dateTimePicker2 . Value );
            if ( result )
            {
                MessageBox . Show ( "成功出库" );
                this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "出库失败" );
        }

        bool checkView ( )
        {
            result = true;
            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            DataRow row;
            MulaolaoLibrary . WarehouseReceiptWASEntity _was = new MulaolaoLibrary . WarehouseReceiptWASEntity ( );
            for ( int i = 0 ; i < gridView2 . DataRowCount ; i++ )
            {
                row = gridView2 . GetDataRow ( i );
                _was . WAS006 = string . IsNullOrEmpty ( row [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "U0" ] . ToString ( ) );
                _was . WAS008 = string . IsNullOrEmpty ( row [ "WAR006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WAR006" ] . ToString ( ) );
                _was . WAS001 = row [ "U3" ] . ToString ( );
                _was . WAS007 = string . IsNullOrEmpty ( row [ "WAR009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WAR009" ] . ToString ( ) );
                _was . WAS009 = row [ "U1" ] . ToString ( );
                row . ClearErrors ( );
                if ( !string . IsNullOrEmpty ( _was . WAS009 ) && string . IsNullOrEmpty ( _was . WAS001 ) )
                {
                    row . SetColumnError ( "U3" ,"不可为空" );
                    result = false;
                    break;
                }
                //if ( _was . WAS006 <= 0 )
                //{
                //    row . SetColumnError ( "U0" ,"数量必须大于0" );
                //    result = false;
                //    break;
                //}
                if ( _was . WAS008 < _was . WAS006 )
                {
                    row . SetColumnError ( "U0" ,"数量大于剩余数量" );
                    result = false;
                    break;
                }
                //if ( _was . WAS007 <= 0 )
                //{
                //    row . SetColumnError ( "WAR009" ,"单价必须大于0" );
                //    result = false;
                //    break;
                //}
            }

            return result;
        }

    }
}
