using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class QualityTestingQueryAll : Form
    {
        public QualityTestingQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        DataTable tableQuery; MulaolaoBll.Bll.QualityTestingBll _bll = new MulaolaoBll.Bll.QualityTestingBll( );
        public string num = "";
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        private void QualityTestingQueryAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableOfLj( num );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "DS03" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "DS04" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
