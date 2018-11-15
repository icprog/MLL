using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class QualityTestingNumQuery : Form
    {
        public QualityTestingNumQuery ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        DataTable tableQuery; MulaolaoBll.Bll.QualityTestingBll _bll = new MulaolaoBll.Bll.QualityTestingBll( );
        public string num = "";
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void QualityTestingNumQuery_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableOfNum( );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "", cn3 = "", cn4 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
