using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm495 : Form
    {
        public R_Frm495 ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        //添加一个委托
        public delegate void PassDataBetweenFomrHandler ( object sender ,PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFomrHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        public string str = "";
        private void R_Frm495_Load ( object sender ,EventArgs e )
        {

        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY33" ).ToString( );
            cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY01" ).ToString( );
            cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY30" ).ToString( );
            cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY27" ).ToString( );
            cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY06" ).ToString( );
            cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY38" ).ToString( );
            cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PY31" ).ToString( );
            cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF31" ).ToString( );
            cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }

            this.Close( );
        }
    }
}
