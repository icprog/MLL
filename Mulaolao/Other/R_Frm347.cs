using Mulaolao . Class;
using System;
using System . Windows . Forms;


namespace Mulaolao . Contract
{
    public partial class R_Frm347 : Form
    {
        public R_Frm347( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string r347 = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";
        private void R_Frm347_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            if (r347 == "1")
            {
                this.gridView1.Columns["PJ01"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = true;
                this.gridView1.Columns["PQF04"].Visible = true;
                this.gridView1.Columns["PQV01"].Visible = false;
                this.gridView1.Columns["PQV76"].Visible = false;
                this.gridView1.Columns["PQV77"].Visible = false;
                this.gridView1.Columns["PQV78"].Visible = false;
                this.gridView1.Columns["PQV79"].Visible = false;
                this.gridView1.Columns["PQV80"].Visible = false;
                this.gridView1.Columns["PQV10"].Visible = false;
                this.gridView1.Columns["PQV65"].Visible = false;
                this.gridView1.Columns["PQV64"].Visible = false;
                this.gridView1.Columns["PQV82"].Visible = false;
                this.gridView1.Columns["PQV66"].Visible = false;
                this.gridView1.Columns["PQV81"].Visible = false;
                this.gridView1.Columns["PQV67"].Visible = false;
                this.gridView1.Columns["PQU01"].Visible = false;
                this.gridView1.Columns["PQU97"].Visible = false;
                this.gridView1.Columns["PQU98"].Visible = false;
                this.gridView1.Columns["PQU99"].Visible = false;
                this.gridView1.Columns["PQU100"].Visible = false;
                this.gridView1.Columns["PQU101"].Visible = false;
                this.gridView1.Columns["PQU10"].Visible = false;
                this.gridView1.Columns["PQU12"].Visible = false;
                this.gridView1.Columns["PQU18"].Visible = false;
                this.gridView1.Columns["PQU19"].Visible = false;
                this.gridView1.Columns["PQU104"].Visible = false;
                this.gridView1.Columns["PJ92"].Visible = false;
                this.gridView1.Columns["PJ93"].Visible = false;
                this.gridView1.Columns["PJ94"].Visible = false;
                this.gridView1.Columns["PJ95"].Visible = false;
                this.gridView1.Columns["PJ96"].Visible = false;
                this.gridView1.Columns["PJ09"].Visible = false;
                this.gridView1.Columns["PJ15"].Visible = false;
                this.gridView1.Columns["PJ14"].Visible = false;
                this.gridView1.Columns["PJ97"].Visible = false;
                this.gridView1.Columns["PJ89"].Visible = false;
                this.gridView1.Columns["WX01"].Visible = false;
                this.gridView1.Columns["WX82"].Visible = false;
                this.gridView1.Columns["WX83"].Visible = false;
                this.gridView1.Columns["WX84"].Visible = false;
                this.gridView1.Columns["WX85"].Visible = false;
                this.gridView1.Columns["WX86"].Visible = false;
                this.gridView1.Columns["WX10"].Visible = false;
                this.gridView1.Columns["WX11"].Visible = false;
                this.gridView1.Columns["WX16"].Visible = false;
                this.gridView1.Columns["WX17"].Visible = false;
                this.gridView1.Columns["WX87"].Visible = false;
            }
            else if (r347 == "2")
            {
                this.gridView1.Columns["WX01"].Visible = true;
                this.gridView1.Columns["WX82"].Visible = true;
                this.gridView1.Columns["WX83"].Visible = true;
                this.gridView1.Columns["WX84"].Visible = true;
                this.gridView1.Columns["WX85"].Visible = true;
                this.gridView1.Columns["WX86"].Visible = true;
                this.gridView1.Columns["WX10"].Visible = true;
                this.gridView1.Columns["WX11"].Visible = true;
                this.gridView1.Columns["WX16"].Visible = true;
                this.gridView1.Columns["WX17"].Visible = true;
                this.gridView1.Columns["WX87"].Visible = true;
                this.gridView1.Columns["PQV01"].Visible = false;
                this.gridView1.Columns["PQV76"].Visible = false;
                this.gridView1.Columns["PQV77"].Visible = false;
                this.gridView1.Columns["PQV78"].Visible = false;
                this.gridView1.Columns["PQV79"].Visible = false;
                this.gridView1.Columns["PQV80"].Visible = false;
                this.gridView1.Columns["PQV10"].Visible = false;
                this.gridView1.Columns["PQV65"].Visible = false;
                this.gridView1.Columns["PQV64"].Visible = false;
                this.gridView1.Columns["PQV82"].Visible = false;
                this.gridView1.Columns["PQV66"].Visible = false;
                this.gridView1.Columns["PQV81"].Visible = false;
                this.gridView1.Columns["PQV67"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQU01"].Visible = false;
                this.gridView1.Columns["PQU97"].Visible = false;
                this.gridView1.Columns["PQU98"].Visible = false;
                this.gridView1.Columns["PQU99"].Visible = false;
                this.gridView1.Columns["PQU100"].Visible = false;
                this.gridView1.Columns["PQU101"].Visible = false;
                this.gridView1.Columns["PQU10"].Visible = false;
                this.gridView1.Columns["PQU12"].Visible = false;
                this.gridView1.Columns["PQU18"].Visible = false;
                this.gridView1.Columns["PQU19"].Visible = false;
                this.gridView1.Columns["PQU104"].Visible = false;
                this.gridView1.Columns["PJ01"].Visible = false;
                this.gridView1.Columns["PJ92"].Visible = false;
                this.gridView1.Columns["PJ93"].Visible = false;
                this.gridView1.Columns["PJ94"].Visible = false;
                this.gridView1.Columns["PJ95"].Visible = false;
                this.gridView1.Columns["PJ96"].Visible = false;
                this.gridView1.Columns["PJ09"].Visible = false;
                this.gridView1.Columns["PJ15"].Visible = false;
                this.gridView1.Columns["PJ14"].Visible = false;
                this.gridView1.Columns["PJ97"].Visible = false;
                this.gridView1.Columns["PJ89"].Visible = false;

            }
            else if (r347 == "3")
            {

                this.gridView1.Columns["PQU01"].Visible = true;
                this.gridView1.Columns["PQU97"].Visible = true;
                this.gridView1.Columns["PQU98"].Visible = true;
                this.gridView1.Columns["PQU99"].Visible = true;
                this.gridView1.Columns["PQU100"].Visible = true;
                this.gridView1.Columns["PQU101"].Visible = true;
                this.gridView1.Columns["PQU10"].Visible = true;
                this.gridView1.Columns["PQU12"].Visible = true;
                this.gridView1.Columns["PQU18"].Visible = true;
                this.gridView1.Columns["PQU19"].Visible = true;
                this.gridView1.Columns["PQU104"].Visible = true;
                this.gridView1.Columns["PQV01"].Visible = false;
                this.gridView1.Columns["PQV76"].Visible = false;
                this.gridView1.Columns["PQV77"].Visible = false;
                this.gridView1.Columns["PQV78"].Visible = false;
                this.gridView1.Columns["PQV79"].Visible = false;
                this.gridView1.Columns["PQV80"].Visible = false;
                this.gridView1.Columns["PQV10"].Visible = false;
                this.gridView1.Columns["PQV65"].Visible = false;
                this.gridView1.Columns["PQV64"].Visible = false;
                this.gridView1.Columns["PQV82"].Visible = false;
                this.gridView1.Columns["PQV66"].Visible = false;
                this.gridView1.Columns["PQV81"].Visible = false;
                this.gridView1.Columns["PQV67"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;               
                this.gridView1.Columns["PJ01"].Visible = false;
                this.gridView1.Columns["PJ92"].Visible = false;
                this.gridView1.Columns["PJ93"].Visible = false;
                this.gridView1.Columns["PJ94"].Visible = false;
                this.gridView1.Columns["PJ95"].Visible = false;
                this.gridView1.Columns["PJ96"].Visible = false;
                this.gridView1.Columns["PJ09"].Visible = false;
                this.gridView1.Columns["PJ15"].Visible = false;
                this.gridView1.Columns["PJ14"].Visible = false;
                this.gridView1.Columns["PJ97"].Visible = false;
                this.gridView1.Columns["PJ89"].Visible = false;
                this.gridView1.Columns["WX01"].Visible = false;
                this.gridView1.Columns["WX82"].Visible = false;
                this.gridView1.Columns["WX83"].Visible = false;
                this.gridView1.Columns["WX84"].Visible = false;
                this.gridView1.Columns["WX85"].Visible = false;
                this.gridView1.Columns["WX86"].Visible = false;
                this.gridView1.Columns["WX10"].Visible = false;
                this.gridView1.Columns["WX11"].Visible = false;
                this.gridView1.Columns["WX16"].Visible = false;
                this.gridView1.Columns["WX17"].Visible = false;
                this.gridView1.Columns["WX87"].Visible = false;
            }
            else if (r347 == "4")
            {
                this.gridView1.Columns["PQV01"].Visible = true;
                this.gridView1.Columns["PQV76"].Visible = true;
                this.gridView1.Columns["PQV77"].Visible = true;
                this.gridView1.Columns["PQV78"].Visible = true;
                this.gridView1.Columns["PQV79"].Visible = true;
                this.gridView1.Columns["PQV80"].Visible = true;
                this.gridView1.Columns["PQV10"].Visible = true;
                this.gridView1.Columns["PQV65"].Visible = true;
                this.gridView1.Columns["PQV64"].Visible = true;
                this.gridView1.Columns["PQV82"].Visible = true;
                this.gridView1.Columns["PQV66"].Visible = true;
                this.gridView1.Columns["PQV81"].Visible = true;
                this.gridView1.Columns["PQV67"].Visible = true;
                this.gridView1.Columns["WX01"].Visible = false;
                this.gridView1.Columns["PJ01"].Visible = false;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;
                this.gridView1.Columns["PQU01"].Visible = false;
                this.gridView1.Columns["PQU97"].Visible = false;
                this.gridView1.Columns["PQU98"].Visible = false;
                this.gridView1.Columns["PQU99"].Visible = false;
                this.gridView1.Columns["PQU100"].Visible = false;
                this.gridView1.Columns["PQU101"].Visible = false;
                this.gridView1.Columns["PQU10"].Visible = false;
                this.gridView1.Columns["PQU12"].Visible = false;
                this.gridView1.Columns["PQU18"].Visible = false;
                this.gridView1.Columns["PQU19"].Visible = false;
                this.gridView1.Columns["PQU104"].Visible = false;
                this.gridView1.Columns["PJ92"].Visible = false;
                this.gridView1.Columns["PJ93"].Visible = false;
                this.gridView1.Columns["PJ94"].Visible = false;
                this.gridView1.Columns["PJ95"].Visible = false;
                this.gridView1.Columns["PJ96"].Visible = false;
                this.gridView1.Columns["PJ09"].Visible = false;
                this.gridView1.Columns["PJ15"].Visible = false;
                this.gridView1.Columns["PJ14"].Visible = false;
                this.gridView1.Columns["PJ97"].Visible = false;
                this.gridView1.Columns["PJ89"].Visible = false;
                this.gridView1.Columns["WX82"].Visible = false;
                this.gridView1.Columns["WX83"].Visible = false;
                this.gridView1.Columns["WX84"].Visible = false;
                this.gridView1.Columns["WX85"].Visible = false;
                this.gridView1.Columns["WX86"].Visible = false;
                this.gridView1.Columns["WX10"].Visible = false;
                this.gridView1.Columns["WX11"].Visible = false;
                this.gridView1.Columns["WX16"].Visible = false;
                this.gridView1.Columns["WX17"].Visible = false;
                this.gridView1.Columns["WX87"].Visible = false;
            }
            else if ( r347 == "5" )
            {
                this.gridView1.Columns["PJ01"].Visible = true;
                this.gridView1.Columns["PJ92"].Visible = true;
                this.gridView1.Columns["PJ93"].Visible = true;
                this.gridView1.Columns["PJ94"].Visible = true;
                this.gridView1.Columns["PJ95"].Visible = true;
                this.gridView1.Columns["PJ96"].Visible = true;
                this.gridView1.Columns["PJ09"].Visible = true;
                this.gridView1.Columns["PJ15"].Visible = true;
                this.gridView1.Columns["PJ14"].Visible = true;
                this.gridView1.Columns["PJ97"].Visible = true;
                this.gridView1.Columns["PJ89"].Visible = true;
                this.gridView1.Columns["PQF02"].Visible = false;
                this.gridView1.Columns["PQF04"].Visible = false;              
                this.gridView1.Columns["PQV01"].Visible = false;
                this.gridView1.Columns["PQV76"].Visible = false;
                this.gridView1.Columns["PQV77"].Visible = false;
                this.gridView1.Columns["PQV78"].Visible = false;
                this.gridView1.Columns["PQV79"].Visible = false;
                this.gridView1.Columns["PQV80"].Visible = false;
                this.gridView1.Columns["PQV10"].Visible = false;
                this.gridView1.Columns["PQV65"].Visible = false;
                this.gridView1.Columns["PQV64"].Visible = false;
                this.gridView1.Columns["PQV82"].Visible = false;
                this.gridView1.Columns["PQV66"].Visible = false;
                this.gridView1.Columns["PQV81"].Visible = false;
                this.gridView1.Columns["PQV67"].Visible = false;
                this.gridView1.Columns["PQU01"].Visible = false;
                this.gridView1.Columns["PQU97"].Visible = false;
                this.gridView1.Columns["PQU98"].Visible = false;
                this.gridView1.Columns["PQU99"].Visible = false;
                this.gridView1.Columns["PQU100"].Visible = false;
                this.gridView1.Columns["PQU101"].Visible = false;
                this.gridView1.Columns["PQU10"].Visible = false;
                this.gridView1.Columns["PQU12"].Visible = false;
                this.gridView1.Columns["PQU18"].Visible = false;
                this.gridView1.Columns["PQU19"].Visible = false;
                this.gridView1.Columns["PQU104"].Visible = false;
                this.gridView1.Columns["WX01"].Visible = false;
                this.gridView1.Columns["WX82"].Visible = false;
                this.gridView1.Columns["WX83"].Visible = false;
                this.gridView1.Columns["WX84"].Visible = false;
                this.gridView1.Columns["WX85"].Visible = false;
                this.gridView1.Columns["WX86"].Visible = false;
                this.gridView1.Columns["WX10"].Visible = false;
                this.gridView1.Columns["WX11"].Visible = false;
                this.gridView1.Columns["WX16"].Visible = false;
                this.gridView1.Columns["WX17"].Visible = false;
                this.gridView1.Columns["WX87"].Visible = false;
            }
        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (r347 == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF04" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF02" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PJ01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PJ02" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PJ03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DGA003" ).ToString( );
            }
            else if (r347 == "2")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle,"WX83").ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle,"WX84").ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "WX01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "WX02" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "WX03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DGA003" ).ToString( );
                cn8 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
                cn9 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"WX82").ToString( );
                cn10 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"WX85").ToString( );
                cn11 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"WX86").ToString( );
            }
            else if (r347 == "3")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQU98" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQU99" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQU01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQU02" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQU03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DGA003" ).ToString( );
                cn8 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
                cn9= gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQU97").ToString( );
                cn10= gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQU100").ToString( );
                cn11= gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQU101").ToString( );
            }
            else if (r347 == "4")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQV77" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQV78" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQV01" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQV02" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQV03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DGA003" ).ToString( );
                cn8 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
                cn9 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQV76").ToString( );
                cn10 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQV79").ToString( );
                cn11 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PQV80").ToString( );
            }else if ( r347 == "5" )
            {
                cn1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ93").ToString( );
                cn2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ94").ToString( );
                cn3 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ01").ToString( );
                cn4 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ02").ToString( );
                cn5 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"DBA002").ToString( );
                cn6 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ03").ToString( );
                cn7 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"DGA003").ToString( );
                cn8 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"RES05").ToString( );
                cn9 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ92").ToString( );
                cn10 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ95").ToString( );
                cn11 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle ,"PJ96").ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs(cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11);
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
