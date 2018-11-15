using Mulaolao . Class;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class FormPurchaseDelaySummary :FormChild
    {
        MulaolaoBll.Bll.PurchaseDelaySummaryBll _bll=null;
        string strWhere="1=1";
        DataTable tableView;

        public FormPurchaseDelaySummary ( )
        {
            InitializeComponent ( );
            
            _bll = new MulaolaoBll . Bll . PurchaseDelaySummaryBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            lupName . Properties . DataSource = _bll . getTablePro ( );
            lupName . Properties . DisplayMember = "PQF04";
            lupName . Properties . ValueMember = "PQF01";
        }

        protected override void select ( )
        {
            strWhere = " AND 1=1";
            if ( !string . IsNullOrEmpty ( txtNum . Text ) )
                strWhere = strWhere + " AND PQF01='" + txtNum . Text + "'";
            if ( !string . IsNullOrEmpty ( dtStart . Text ) && !string . IsNullOrEmpty ( dtEnd . Text ) )
                strWhere = strWhere + " AND E.RES04 BETWEEN '" + dtStart.Text + "' AND '" + dtEnd . Text + "'";

            if ( strWhere . Equals ( " AND 1=1" ) )
            {
                MessageBox . Show ( "请选择查询条件" );
                return;
            }

            if ( string . IsNullOrEmpty ( dtStart . Text ) && !string . IsNullOrEmpty ( dtEnd . Text ) )
            {
                MessageBox . Show ( "请选择起始日期" );
                return;
            }

            if ( !string . IsNullOrEmpty ( dtStart . Text ) && string . IsNullOrEmpty ( dtEnd . Text ) )
            {
                MessageBox . Show ( "请选择结束日期" );
                return;
            }

            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;

            base . select ( );
        }

        private void lupName_EditValueChanged ( object sender ,System . EventArgs e )
        {
            DataRow row = searchLookUpEdit1View . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtNum . Text = row [ "PQF01" ] . ToString ( );
                txtNums . Text = row [ "PQF03" ] . ToString ( );
            }
        }

    }
}
