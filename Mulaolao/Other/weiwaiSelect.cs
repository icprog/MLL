using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Contract
{
    public partial class weiwaiSelect : Form
    {
        public weiwaiSelect( )
        {
            InitializeComponent();
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "", cn13 = "", cn14 = "", cn15 = "", cn16 = "";
        public string wea = "";
        private void weiwaiSelect_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            if ( wea == "1" )
            {
                gridView1.Columns["CP03"].Visible = true;
                gridView1.Columns["CP51"].Visible = true;
                gridView1.Columns["CP01"].Visible = true;
                gridView1.Columns["CP44"].Visible = true;
                gridView1.Columns["DBA002"].Visible = true;
                gridView1.Columns["CP52"].Visible = true;
                gridView1.Columns["CP53"].Visible = true;
                gridView1.Columns["CP54"].Visible = true;
                gridView1.Columns["AH97"].Visible = false;
                gridView1.Columns["AH01"].Visible = false;
                gridView1.Columns["AH98"].Visible = false;
                gridView1.Columns["AH100"].Visible = false;
                gridView1.Columns["AH99"].Visible = false;
                gridView1.Columns["AH03"].Visible = false;
                gridView1.Columns["AH05"].Visible = false;
                gridView1.Columns["AH10"].Visible = false;
            }
            else if ( wea == "2" )
            {
                gridView1.Columns["CP03"].Visible = false;
                gridView1.Columns["CP51"].Visible = false;
                gridView1.Columns["CP01"].Visible = false;
                gridView1.Columns["CP44"].Visible = false;
                gridView1.Columns["DBA002"].Visible = false;
                gridView1.Columns["CP52"].Visible = false;
                gridView1.Columns["CP53"].Visible = false;
                gridView1.Columns["CP54"].Visible = false;
                gridView1.Columns["AH97"].Visible = true;
                gridView1.Columns["AH01"].Visible = true;
                gridView1.Columns["AH98"].Visible = true;
                gridView1.Columns["AH100"].Visible = true;
                gridView1.Columns["AH99"].Visible = true;
                gridView1.Columns["AH03"].Visible = true;
                gridView1.Columns["AH05"].Visible = true;
                gridView1.Columns["AH10"].Visible = true;
            }
        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if ( wea == "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP51" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP44" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP52" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP53" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP54" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP45" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP46" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP47" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP48" ).ToString( );
                cn13 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA028" ).ToString( );
                cn14 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP03" ).ToString( );
                cn15 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            }
            else if ( wea == "2" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH97" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH98" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH100" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH99" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH05" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH101" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH02" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA028" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH106" ).ToString( );
                cn13 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH107" ).ToString( );
                cn14 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH108" ).ToString( );
                cn15 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH109" ).ToString( );
                cn16 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 ,cn13 ,cn14 ,cn15 ,cn16 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
