using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ReadyOfNumAll : Form
    {
        public ReadyOfNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        MulaolaoBll.Bll.ReadyOfNumBll _bll = new MulaolaoBll.Bll.ReadyOfNumBll( );
        DataTable tableQuery;

        private void ReadyOfNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableOf( );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
