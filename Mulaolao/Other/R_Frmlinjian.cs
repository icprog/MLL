using System;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . Raw_material_cost
{
    public partial class R_Frmlinjian : Form
    {
        public R_Frmlinjian( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        //添加一个委托
        public delegate void PassDataBetweenFormHandler( object sender, PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string lin = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "", cn13 = "", cn14 = "";
        private void R_Frmlinjian_Load( object sender, EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
        }

        private void gridView1_DoubleClick( object sender, EventArgs e )
        {
            if (lin == "1")
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ10" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ11" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ12" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ13" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ14" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ15" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "YQ16" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY10" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY11" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY12" ).ToString( );
                cn11= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY14" ).ToString( );
                cn12= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY15" ).ToString( );
                cn13= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY18" ).ToString( );
                cn14= gridView1.GetRowCellValue( gridView1.FocusedRowHandle, "PY22" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1, cn2, cn3, cn4, cn5, cn6, cn7, cn8, cn9, cn10, cn11, cn12, cn13, cn14 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
