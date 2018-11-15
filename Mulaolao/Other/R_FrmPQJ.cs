using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class R_FrmPQJ : Form
    {
        public R_FrmPQJ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        public string pj = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void R_FrmPQJ_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( this.gridView1 );
        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (pj == "1")
            {
                cn1 = gridView1.GetFocusedRowCellValue( "PY11" ).ToString( );
                cn2 = gridView1.GetFocusedRowCellValue( "PY12" ).ToString( );
                cn3 = gridView1.GetFocusedRowCellValue( "PY14" ).ToString( );
                cn4 = gridView1.GetFocusedRowCellValue( "PY15" ).ToString( );
                cn5 = gridView1.GetFocusedRowCellValue( "PY18" ).ToString( );
                cn6 = gridView1.GetFocusedRowCellValue( "PY02" ).ToString( );
                cn7 = gridView1.GetFocusedRowCellValue( "PY36" ).ToString( );
                cn8 = gridView1.GetFocusedRowCellValue( "PY25" ).ToString( );
                cn9 = gridView1.GetFocusedRowCellValue( "PY24" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
