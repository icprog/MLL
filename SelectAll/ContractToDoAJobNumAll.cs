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
    public partial class ContractToDoAJobNumAll : Form
    {
        public ContractToDoAJobNumAll ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery; MulaolaoBll.Bll.ContractToDoAJobBll _bll = new MulaolaoBll.Bll.ContractToDoAJobBll( );
        public string no = "";

        private void ContractToDoAJobNumAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            tableQuery = _bll.GetDataTableOfNum( );
            gridControl1.DataSource = tableQuery;
        }

        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQF01" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQF02" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQF03" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "PQF04" ).ToString( );
            cn5 = gridView1.GetFocusedRowCellValue( "PQF05" ).ToString( );
            cn6 = gridView1.GetFocusedRowCellValue( "PQF06" ).ToString( );
            cn7 = gridView1.GetFocusedRowCellValue( "PQF09" ).ToString( );
            cn8 = gridView1.GetFocusedRowCellValue( "PQF10" ).ToString( );
            cn9 = gridView1.GetFocusedRowCellValue( "PQF45" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
