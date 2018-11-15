using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_FrmTPADFA : Form
    {
        public R_FrmTPADFA( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        //添加一个委托
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string dfa = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "";
        private void R_FrmTPADFA_Load( object sender, EventArgs e )
        {

        }
        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (dfa == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA001" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA003" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA015" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "DFA016" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PQF02" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1, cn2, cn3, cn4,cn5 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
