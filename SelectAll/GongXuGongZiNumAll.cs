using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GongXuGongZiNumAll : Form
    {
        public GongXuGongZiNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.GongXuGongZiBll bll = new MulaolaoBll.Bll.GongXuGongZiBll( );
        DataTable tableOne, tableTwo;

        private void GongXuGongZiNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            GridViewMoHuSelect.SetFilter( gridView2 );
            query( );
        }

        void query ( )
        {
            tableOne = bll.GetDataTableNum( );
            gridControl1.DataSource = tableOne;
            tableTwo = bll.GetDataTableSeriableNum( );
            gridControl2.DataSource = tableTwo;
        }
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "DAA002" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "PQF31" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void gridView2_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            cn1 = gridView2.GetFocusedRowCellValue( "BG001" ).ToString( );
            cn2 = gridView2.GetFocusedRowCellValue( "BG002" ).ToString( );
            cn3 = gridView2.GetFocusedRowCellValue( "BG003" ).ToString( );
            cn4 = gridView2.GetFocusedRowCellValue( "BG004" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
