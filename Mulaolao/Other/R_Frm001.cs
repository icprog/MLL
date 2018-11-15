using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm001 : Form
    {
        public R_Frm001 ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "";
        public string seleQuery = "";
        private void R_Frm001_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
