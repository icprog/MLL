using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WaiXianNumAll : Form
    {
        public WaiXianNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.WaiXianBll _bll = new MulaolaoBll.Bll.WaiXianBll( );
        DataTable tableQuery;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "";

        private void WaiXianNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableNum( );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "WX83" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "WX01" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "WX84" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "WX85" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "WX82" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
