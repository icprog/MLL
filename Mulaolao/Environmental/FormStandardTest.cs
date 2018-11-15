using Mulaolao . Class;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardTest :FormChild
    {
        MulaolaoLibrary.StandardTestCLEntity _cl=null;
        MulaolaoLibrary.StandardTestCMEntity _cm=null;
        MulaolaoBll.Bll.StandardTestBll _bll=null;

        DataTable tableViewOne,tableViewTwo;
        List<string> strList=new List<string>(); List<string> strL=new List<string>();
        
        public FormStandardTest ( )
        {
            InitializeComponent ( );

            _cl = new MulaolaoLibrary . StandardTestCLEntity ( );
            _cm = new MulaolaoLibrary . StandardTestCMEntity ( );
            _bll = new MulaolaoBll . Bll . StandardTestBll ( );
            tableViewOne = new DataTable ( );
            tableViewTwo = new DataTable ( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            gridView1 . OptionsBehavior . Editable = false;
            gridView2 . OptionsBehavior . Editable = false;

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );
        }
        
        #region Main
        protected override void select ( )
        {
            tableViewOne = _bll . getViewOne ( );
            gridControl1 . DataSource = tableViewOne;
            tableViewTwo = _bll . getViewTwo ( );
            gridControl2 . DataSource = tableViewTwo;

            base . select ( );
        }
        protected override void add ( )
        {
            gridView1 . OptionsBehavior . Editable = true;
            gridView2 . OptionsBehavior . Editable = true;
           
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;

            base . add ( );
        }
        protected override void save ( )
        {
            bool result = _bll . Save ( tableViewOne ,tableViewTwo ,strList ,strL );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                strList . Clear ( );
                strL . Clear ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
                gridView2 . OptionsBehavior . Editable = false;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
            gridView2 . OptionsBehavior . Editable = false;

            base . cancel ( );
        }
        #endregion

        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                strList . Add ( row [ "idx" ] . ToString ( ) );
                tableViewOne . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                strL . Add ( row [ "idx" ] . ToString ( ) );
                tableViewTwo . Rows . Remove ( row );
                gridControl2 . RefreshDataSource ( );
            }
        }
        #endregion

    }
}
