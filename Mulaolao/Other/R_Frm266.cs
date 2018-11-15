using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm266 : Form
    {
        public R_Frm266 ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string test = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "",cn13="";
        private void R_Frm266_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            if ( test == "1" )
            {
                gridView1.Columns["AG001"].Visible = false;
                gridView1.Columns["idx"].Visible = false;
                gridView1.Columns["YQ107"].Visible = true;
                gridView1.Columns["YQ108"].Visible = true;
                gridView1.Columns["YQ04"].Visible = true;
                gridView1.Columns["YQ05"].Visible = true;
                gridView1.Columns["AI"].Visible = true;
            }
            else if ( test == "3" )
            {
                gridView1.Columns["AG001"].Visible = true;
                gridView1.Columns["idx"].Visible = true;
                gridView1.Columns["YQ107"].Visible = false;
                gridView1.Columns["YQ108"].Visible = false;
                gridView1.Columns["YQ04"].Visible = false;
                gridView1.Columns["YQ05"].Visible = false;
                gridView1.Columns["AI"].Visible = false;
            }
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( test == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI002" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ107" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ108" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ04" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ05" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI003" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI004" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI006" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI010" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI005" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI011" ).ToString( );
                cn13 = gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"AI014" ) . ToString ( );
            }
            else if ( test == "3" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AG001" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"idx" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI002" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI003" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI004" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI006" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI010" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AI011" ).ToString( );
            }
            PassDataWinFormEventArgs arge = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 ,cn13 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,arge );
            }
            this.Close( );
        }
    }
}
