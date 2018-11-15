using Mulaolao . Class;
using System;
using System . Windows . Forms;

namespace Mulaolao . Bom
{
    public partial class R_FrmTPADGA : Form
    {
        public R_FrmTPADGA( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView2 } );
        }
        //添加一个委托
        public delegate void PassDataBetweenFomrHandler( object sender, PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFomrHandler PassDataBetweenForm;

        private void R_FrmTPADGA_Load( object sender, EventArgs e )
        {

            if (st == "1")
            {
                this.gridView2.Columns["DGA008"].Visible = false;
                this.gridView2.Columns["DGA012"].Visible = false;
                this.gridView2.Columns["DGA017"].Visible = false;
            }
            else if (st == "2")
            {
                this.gridView2.Columns["DGA008"].Visible = true;
                this.gridView2.Columns["DGA012"].Visible = true;
                this.gridView2.Columns["DGA017"].Visible = true;
            }
            else if (st == "3")
            {
                this.gridView2.Columns["DGA008"].Visible = false;
                this.gridView2.Columns["DGA012"].Visible = false;
                this.gridView2.Columns["DGA017"].Visible = true;
            }
            else if (st == "4")
            {
                this.gridView2.Columns["DGA008"].Visible = true;
                this.gridView2.Columns["DGA012"].Visible = false;
                this.gridView2.Columns["DGA017"].Visible = true;
            }
        }
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "";
        public string st = "";
        private void gridView2_DoubleClick( object sender, EventArgs e )
        {
            if (st == "1")
            {
                cn1 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA001" ).ToString( );
                cn2 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA003" ).ToString( );
                cn3 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA009" ).ToString( );
                cn4 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA011" ).ToString( );
            }
            else if (st == "2")
            {
                cn1 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA001" ).ToString( );
                cn2 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA003" ).ToString( );
                cn3 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA008" ).ToString( );
                cn4 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA009" ).ToString( );
                cn5 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA011" ).ToString( );
                cn6 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA012" ).ToString( );
                cn7 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA017" ).ToString( );
            }
            else if (st == "3")
            {
                cn1 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA001" ).ToString( );
                cn2 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA003" ).ToString( );
                cn3 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA009" ).ToString( );
                cn4 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA011" ).ToString( );
                cn5 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA017" ).ToString( );
            }
            else if (st == "4")
            {
                cn1 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA001" ).ToString( );
                cn2 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA003" ).ToString( );
                cn3 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA008" ).ToString( );
                cn4 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA009" ).ToString( );
                cn5 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA011" ).ToString( );
                cn6 = gridView2.GetRowCellValue( gridView2.FocusedRowHandle, "DGA017" ).ToString( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1, cn2, cn3, cn4,cn5,cn6,cn7 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }
            this.Close( );
        }
    }
}
