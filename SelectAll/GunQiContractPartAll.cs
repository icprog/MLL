using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GunQiContractPartAll : Form
    {
        public GunQiContractPartAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        MulaolaoBll.Bll.GunQiContractBll bll = new MulaolaoBll.Bll.GunQiContractBll( );
        public string num = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "";

        private void GunQiContractPartAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            query( );
        }

        void query ( )
        {
            DataTable tableQuery = bll.DataTablePart( num );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "LZ015" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "LZ016" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "LZ017" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "LZ018" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "LZ019" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "LZ020" ).ToString( );
            cn7 = gridView1.GetFocusedRowCellValue( "LZ021" ).ToString( );
            cn8 = gridView1.GetFocusedRowCellValue( "LZ022" ).ToString( );
            cn9 = gridView1.GetFocusedRowCellValue( "LZ031" ).ToString( );
            cn10 = gridView1.GetFocusedRowCellValue( "LZ032" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
