using Mulaolao;
using Mulaolao . Class;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    //R_PQEB

    public partial class FormMaterial :FormChild
    {
        MulaolaoBll.Bll.MaterialBLL _bll=null;
        MulaolaoLibrary.MaterialEntity _entity=null;
        bool result=false;
        DataTable tableView;
        string strWhere="1=1";
        
        public FormMaterial ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . MaterialBLL ( );
            _entity = new MulaolaoLibrary . MaterialEntity ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;


            toolSave . Enabled = true;
            toolExport . Enabled = true;
        }

        protected override void select ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( secPro . Text ) )
                strWhere = strWhere + " AND EB002='" + secPro . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( date . Text ) )
                strWhere = strWhere + " AND EB005='" + date . Text + "'";

            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;

            base . select ( );
        }

        protected override void save ( )
        {
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );

            result = _bll . Edit ( tableView );
            if ( result )
            {
                MessageBox . Show ( "成功保存" );
                select ( );
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }

        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }

        private void button1_Click ( object sender ,System . EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( secPro . Text ) )
                strWhere = strWhere + " AND A.AM002='" + secPro . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( date . Text ) )
                strWhere = strWhere + " AND PQF31='" + date . Text + "'";

            result = _bll . Save ( strWhere ,secPro . Text );
            if ( result )
            {
                MessageBox . Show ( "生成成功" );
                select ( );
            }
            else
                MessageBox . Show ( "生成失败" );
        }

        private void FormMaterial_Load ( object sender ,System . EventArgs e )
        {
            secPro . Properties . DataSource = _bll . getPro ( );
            secPro . Properties . DisplayMember = "AM003";
            secPro . Properties . ValueMember = "AM002";
        }

        private void secPro_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == ( char ) Keys . Back )
            {
                secPro . EditValue = null;
            }
        }

        private void date_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == ( char ) Keys . Back )
            {
                date . EditValue = null;
            }
        }

        private void btnQuery_Click ( object sender ,System . EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND CONVERT(VARCHAR,EB005) LIKE '" + dateEdit1 . Text + "%'";

            tableView = _bll . getTableView ( strWhere );
            gridControl1 . DataSource = tableView;

        }
    }
}
