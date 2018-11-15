using Mulaolao.Class;
using System;
using System.Windows.Forms;

namespace Mulaolao.Other
{
    public partial class R_Frm412 : Form
    {
        public R_Frm412 ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";

        private void R_Frm412_Load ( object sender ,EventArgs e )
        {

        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF001" ).ToString( );
            cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF002" ).ToString( );
            cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF003" ).ToString( );
            cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF004" ).ToString( );
            cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF005" ).ToString( );
            cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF006" ).ToString( );
            cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
            cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA003" ).ToString( );
            cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF007" ).ToString( );
            cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF008" ).ToString( );
            cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF010" ).ToString( );

            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
