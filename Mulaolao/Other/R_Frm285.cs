using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm285 : Form
    {
        MulaolaoBll.Bll.HuaXuePingCiChenBenBll _bll =null;
        DataTable getTableOnly,tableView;

        public R_Frm285 ( )
        {
            InitializeComponent( );

        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "";

        string InitData ( )
        {
            getTableOnly = _bll . getNum ( );

            return string . Empty;
        }

        delegate void IAsyUpdateUI ( );
        void UI ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new IAsyUpdateUI ( delegate ( )
                      {
                          txtNum . Properties . DataSource = _bll . getNum ( );
                          txtNum . Properties . DisplayMember = "PQK02";
                          txtNum . Properties . ValueMember = "PQK02";
                      } ) );
            }
        }

        private void btnClear_Click ( object sender ,EventArgs e )
        {
            txtNum . EditValue = null;
        }

        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            string strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( txtNum . Text ) )
                strWhere = strWhere + " AND PQK02='" + txtNum . Text + "'";

            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;
        }

        private void R_Frm228_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            GridViewMoHuSelect . SetFilter ( View );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,View } );

            _bll = new MulaolaoBll . Bll . HuaXuePingCiChenBenBll ( );

            Func<string> funStr = InitData;
            IAsyncResult result = funStr . BeginInvoke ( new AsyncCallback ( UI ) ,null );

        }

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK01" ).ToString( );
            cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK02" ).ToString( );
            cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK03" ).ToString( );
            cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK04" ).ToString( );
            cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK05" ).ToString( );
            cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK06" ).ToString( );
            cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK12" ).ToString( );
            cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK13" ).ToString( );
            cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQK14" ).ToString( );
            cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
