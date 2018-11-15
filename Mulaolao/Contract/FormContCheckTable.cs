using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class FormContCheckTable :FormChild
    {
        MulaolaoBll.Bll.ContCheckTablBll _bll=null;
        MulaolaoLibrary.ContCheckTableEntity _model=null;
        DataTable tableView;
        
        public FormContCheckTable ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            GridViewMoHuSelect . SetFilter ( gridView1 );

            _bll = new MulaolaoBll . Bll . ContCheckTablBll ( );
            _model = new MulaolaoLibrary . ContCheckTableEntity ( );
            toolAdd . Text = "查询全部";
        }
        
        private void FormContCheckTable_Load ( object sender ,System . EventArgs e )
        {
             toolcopy . Visible =   toolLibrary . Visible = toolMaintain . Visible = toolPrint . Visible = toolReview . Visible =  toolStorage . Visible = toolUpdate . Visible =  toolCancel . Visible = false;

            toolExport . Enabled = toolSave . Enabled = toolDelete . Enabled = toolAdd . Enabled = true;

            cmb . Properties . Items . Clear ( );
            cmb . Properties . Items . AddRange ( new string [ ] { "R_195" ,"R_196" ,"R_199" ,"R_337" ,"R_338" ,"R_339" ,"R_341" ,"R_342" ,"R_343" ,"R_344" ,"R_347" ,"R_349" ,"R_495" ,"R_505" } );
        }

        protected override void add ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择年" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmb . Text ) )
            {
                MessageBox . Show ( "请选择合同" );
                return;
            }
            int year = string . IsNullOrEmpty ( dateEdit1 . Text ) == true ? 0 : Convert . ToInt32 ( dateEdit1 . Text );
            string tableNum = cmb . Text;
            tableView = _bll . getTable ( year ,true,tableNum);
            gridControl1 . DataSource = tableView;

            base . add ( );
        }

        protected override void select ( )
        {
            if ( string . IsNullOrEmpty ( dateEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择年" );
                return;
            }
            //if ( string . IsNullOrEmpty ( cmb . Text ) )
            //{
            //    MessageBox . Show ( "请选择合同" );
            //    return;
            //}
            int year = string . IsNullOrEmpty ( dateEdit1 . Text ) == true ? 0 : Convert . ToInt32 ( dateEdit1 . Text );
            string tableNum = cmb . Text;
            tableView = _bll . getTable ( year ,false ,tableNum );
            gridControl1 . DataSource = tableView;

            base . select ( );
        }

        protected override void save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            bool result = _bll . Update ( tableView );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }

        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }

        protected override void delete ( )
        {
            bool result = _bll . Delete ( _model );
            if ( result )
                MessageBox . Show ( "成功删除" );
            else
                MessageBox . Show ( "删除失败" );

            base . delete ( );
        }

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _model . EA001 = row [ "CP03" ] . ToString ( );
                _model . EA002 = row [ "CP01" ] . ToString ( );
            }
        }


    }
}
