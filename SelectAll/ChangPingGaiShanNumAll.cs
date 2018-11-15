using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ChangPingGaiShanNumAll : Form
    {
        public ChangPingGaiShanNumAll ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1,gridView2 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.ChangPingGaiShanBll _bll = new MulaolaoBll.Bll.ChangPingGaiShanBll( );
        DataTable tableOne, tableTwo;

        private void ChangPingGaiShanNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            GridViewMoHuSelect.SetFilter( gridView2 );
            query( );
        }

        void query ( )
        {
            tableOne = _bll.GetDataTableOfPqf( );
            gridControl1.DataSource = tableOne;
            tableTwo = _bll.GetDataTableSerialNum( );
            gridControl2.DataSource = tableTwo;
        }
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "";

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "HT52" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void gridView2_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            cn1 = gridView2.GetFocusedRowCellValue( "BG001" ).ToString( );
            cn3 = gridView2.GetFocusedRowCellValue( "BG003" ).ToString( );
            cn4 = gridView2.GetFocusedRowCellValue( "BG002" ).ToString( );
            cn5 = gridView2.GetFocusedRowCellValue( "BG004" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
