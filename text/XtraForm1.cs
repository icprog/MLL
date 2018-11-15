using System;
using System . Data;
using System . Text;
using StudentMgr;

namespace text
{
    public partial class XtraForm1 :DevExpress . XtraEditors . XtraForm
    {
        public XtraForm1 ( )
        {
            InitializeComponent ( );
        }

        private void XtraForm1_Load ( object sender ,EventArgs e )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT PQX14 FROM R_PQX ORDER BY PQX14 DESC" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            comboBox1 . DataSource = dt;
            comboBox1 . DisplayMember = "PQX14";
            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                comboBoxEdit1 . Properties . Items . Add ( dt . Rows [ i ] [ "PQX14" ] . ToString ( ) );
            }
            lookUpEdit1 . Properties . DataSource = dt;
            lookUpEdit1 . Properties . DisplayMember = "PQX14";

            searchLookUpEdit1 . Properties . DataSource = dt;
            searchLookUpEdit1 . Properties . DisplayMember = "PQX14";

            gridControl1 . DataSource = dt;
        }

        string sx=string.Empty;
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            comboBox1 . Text = row [ "PQX14" ] . ToString ( );
            comboBoxEdit1 . EditValue = row [ "PQX14" ] . ToString ( );
            lookUpEdit1.Text= row [ "PQX14" ] . ToString ( );
            searchLookUpEdit1 . EditValue = row [ "PQX14" ] . ToString ( );
            sx = row [ "PQX14" ] . ToString ( );
            searchLookUpEdit1 . Properties . NullText = sx;
        }

        private void searchLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
           
        }

    }
}