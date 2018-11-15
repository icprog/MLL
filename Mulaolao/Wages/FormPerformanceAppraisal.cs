
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    //R_PQPE
    public partial class FormPerformanceAppraisal :FormChild
    {
        MulaolaoBll.Bll.PerformanceAppraisalBll _bll=null;
        MulaolaoLibrary.PerformanceAppraisalEntity _model=null;
        
        bool result=false;
        DataTable tableView;
        
        public FormPerformanceAppraisal ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . PerformanceAppraisalBll ( );
            _model = new MulaolaoLibrary . PerformanceAppraisalEntity ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            tableView = new DataTable ( );
            gridView1 . OptionsBehavior . Editable = false;
        }

        protected override void select ( )
        {
            tableView = _bll . getTableView ( dtp . Value . Year );
            gridControl1 . DataSource = tableView;

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;

            base . select ( );
        }
        protected override void update ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;

            base . update ( );
        }
        protected override void save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Edit ( tableView );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolReview . Enabled = toolMaintain . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = true;
            toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = toolPrint . Enabled = toolExport . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;

            base . cancel ( );
        }
        protected override void delete ( )
        {
            result = _bll . Delete ( dtp . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                gridControl1 . DataSource = null;
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                gridView1 . OptionsBehavior . Editable = false;
            }
            else
                MessageBox . Show ( "删除失败" );

            base . delete ( );
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }

        private void btnRead_Click ( object sender ,EventArgs e )
        {
            result = _bll . Generate ( dtp . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "生成成功" );
                select ( );
            }
            else
                MessageBox . Show ( "生成失败" );
        }

    }
}
