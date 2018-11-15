using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class OtherExpenseStatementNumAll : Form
    {
        public OtherExpenseStatementNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.OtherExpenseStatementBll _bll = new MulaolaoBll.Bll.OtherExpenseStatementBll( );

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;

        private void OtherExpenseStatementNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableOfPqf( );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "DAA002" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

    }
}
