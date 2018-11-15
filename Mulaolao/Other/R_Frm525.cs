using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm525 : Form
    {
        public R_Frm525 ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "",cn12="";
        public string sign = "";
        private void R_Frm525_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            if ( sign == "1" )
            {
                gridView1.Columns["AI001"].Visible = false;
                gridView1.Columns["PQK02"].Visible = true;
                gridView1.Columns["PQF04"].Visible = true;
                gridView1.Columns["PQK07"].Visible = true;
                gridView1.Columns["PQK11"].Visible = true;
                gridView1.Columns["PQK17"].Visible = true;
                gridView1.Columns["PQK35"].Visible = true;
                gridView1.Columns["PQK36"].Visible = true;
                gridView1.Columns["PQK09"].Visible = true;
                gridView1.Columns["BS"].Visible = true;
                gridView1.Columns["PFS"].Visible = true;
                gridView1.Columns["RES05"].Visible = false;
                gridView1.Columns["PQK02"].VisibleIndex = 0;
                gridView1.Columns["PQF04"].VisibleIndex = 1;
                gridView1.Columns["AI012"].VisibleIndex = 2;
                gridView1.Columns["PQK07"].VisibleIndex = 3;
                gridView1.Columns["PQK11"].VisibleIndex = 4;
                gridView1.Columns["PQK17"].VisibleIndex = 5;
                gridView1.Columns["PQK35"].VisibleIndex = 6;
                gridView1.Columns["PQK36"].VisibleIndex = 7;
                gridView1.Columns["PQK09"].VisibleIndex = 8;
                gridView1.Columns["PQK37"].VisibleIndex = 9;
                gridView1.Columns["BS"].VisibleIndex = 10;
                gridView1.Columns["PFS"].VisibleIndex = 11;
            }
            else if ( sign == "2" )
            {
                gridView1.Columns["AI001"].Visible = true;
                gridView1.Columns["PQK02"].Visible = true;
                gridView1.Columns["PQK07"].Visible = true;
                gridView1.Columns["PQK11"].Visible = true;
                gridView1.Columns["PQK17"].Visible = true;
                gridView1.Columns["PQK35"].Visible = false;
                gridView1.Columns["PQK36"].Visible = false;
                gridView1.Columns["PQK09"].Visible = false;
                gridView1.Columns["PQK37"].Visible = false;
                gridView1.Columns["PQF04"].Visible = false;
                gridView1.Columns["BS"].Visible = false;
                gridView1.Columns["PFS"].Visible = false;
                gridView1.Columns["RES05"].Visible = true;
                gridView1.Columns["AI001"].VisibleIndex = 0;
                gridView1.Columns["PQK02"].VisibleIndex = 1;
                gridView1.Columns["AI012"].VisibleIndex = 3;
                gridView1.Columns["PQK07"].VisibleIndex = 4;
                gridView1.Columns["PQK11"].VisibleIndex = 5;
                gridView1.Columns["PQK17"].VisibleIndex = 6;
                gridView1.Columns["RES05"].VisibleIndex = 7;
            }
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( sign == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK02" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK11" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK17" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK09" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"BS" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PFS" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK35" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK36" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK07" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK37" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI012" ).ToString( );
                cn12 = gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQK30" ) . ToString ( );
            }
            else if ( sign == "2" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI001" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK11" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK17" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK07" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI012" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
