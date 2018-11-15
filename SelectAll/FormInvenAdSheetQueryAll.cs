using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using Mulaolao . Class;

namespace SelectAll
{
    public partial class FormInvenAdSheetQueryAll :Form
    {
        MulaolaoBll.Bll.InvenAdSheetBll _bll=null;

        DataTable tableView;
        DataRow row;

        public FormInvenAdSheetQueryAll ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . InvenAdSheetBll ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );

            tableView = _bll . getTableQuery ( );
            gridControl1 . DataSource = tableView;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            row = gridView1 . GetFocusedDataRow ( );
            if ( row!=null )
                this . DialogResult = DialogResult . OK;
        }

        public DataRow getRow
        {
            get
            {
                return row;
            }
        }

    }
}