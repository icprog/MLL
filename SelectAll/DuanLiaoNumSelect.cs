using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class DuanLiaoNumSelect : Form
    {
        public DuanLiaoNumSelect ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.DaunLiaoBll bll = new MulaolaoBll.Bll.DaunLiaoBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "";
        DataTable tableQuery;

        private void DuanLiaoNumSelect_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            Query( );
        }

        void Query ( )
        {
            tableQuery = bll.GetDataTableNum( );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
                cn2 = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
                cn3 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
                cn4 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
                cn5 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
    }
}
