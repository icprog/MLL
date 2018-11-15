using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Other
{
    public partial class FormInvenAdQuery :DevExpress . XtraEditors . XtraForm
    {
        DataRow row;
        DataTable tableView,tableViewOne;
        string type=string.Empty;

        MulaolaoBll.Bll.InvenAdSheetBll _bll=null;

        public FormInvenAdQuery ( string type )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . InvenAdSheetBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );

            this . type = type;


            tableView = _bll . getTableRK ( );
            gridControl2 . DataSource = tableView;

        }

        public DataRow getRow
        {
            get
            {
                return row;
            }
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( type . Equals ( "出库" ) )
            {
                row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                    this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "请选择入库记录" );
        }

        private void gridView2_Click ( object sender ,EventArgs e )
        {
           
                row = gridView2 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    tableViewOne = _bll . getTableCK ( row [ "AC18" ] . ToString ( ) );
                    gridControl1 . DataSource = tableViewOne;
                }
          
        }

        private void gridView2_DoubleClick ( object sender ,EventArgs e )
        {
            if ( type . Equals ( "入库" ) )
            {
                row = gridView2 . GetFocusedDataRow ( );
                if ( row != null )
                    this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "请选择出库记录" );
        }


    }
}