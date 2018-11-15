using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class FormWages :FormChild
    {
        MulaolaoBll.Bll.WagesBll _bll=null;
        MulaolaoLibrary.WagesEntity _model=null;
        DataTable tableView;
        string strWhere="1=1";
        bool result=false;
        
        public FormWages ( )
        {
            InitializeComponent ( );

            _model = new MulaolaoLibrary . WagesEntity ( );
            _bll = new MulaolaoBll . Bll . WagesBll ( );

            toolSave . Enabled = true;
            toolExport . Enabled = true;
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( secPro . Text ) )
                strWhere = strWhere + " AND A.AM002='" + secPro . EditValue . ToString ( ) + "'";
            else if ( !string . IsNullOrEmpty ( date . Text ) )
                strWhere = strWhere + " AND PQF31='" + date . Text + "'";

            result = _bll . Save ( strWhere );
            if ( result )
            {
                MessageBox . Show ( "生成成功" );
                select ( );
            }
            else
                MessageBox . Show ( "生成失败" );
        }

        protected override void select ( )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( secPro . Text ) )
                strWhere = strWhere + " AND EC002='" + secPro . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( date . Text ) )
                strWhere = strWhere + " AND EC005='" + date . Text  + "'";

            tableView = _bll . getTabelView ( strWhere );
            gridControl1 . DataSource = tableView;

            base . select ( );
        }
        protected override void save ( )
        {

            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );

            result = _bll . Edit ( tableView );
            if ( result )
                MessageBox . Show ( "成功保存" );
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }
        private void FormWages_Load ( object sender ,EventArgs e )
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
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND CONVERT(VARCHAR,EC005) LIKE '" + dateEdit1 . Text + "%'";

            tableView = _bll . getTabelView ( strWhere );
            gridControl1 . DataSource = tableView;
        }

    }
}
