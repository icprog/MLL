using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class R_Frm338 : Form
    {
        public R_Frm338( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string r338 = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";

        private void R_Frm338_Load( object sender, EventArgs e )
        {

        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (r338 == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM101" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM90" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM100" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM02" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "JM04" ).ToString( );
                cn9 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"JM01").ToString( );
                cn10 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM102" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM103" ).ToString( );
            }
            PassDataWinFormEventArgs arge = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, arge );
            }
            this.Close( );
        }
    }
}
