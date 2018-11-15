using DevExpress . XtraGrid . Views . Grid;
using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormTestResultRecordOne :FormChild
    {
        MulaolaoLibrary.TestResultRecordOneCUEntity _cu=null;
        MulaolaoLibrary.TestResultRecordOneCVEntity _cv=null;
        MulaolaoLibrary.TestResultRecordOneCWEntity _cw=null;
        MulaolaoBll.Bll.TestResultRecordOneBll _bll=null;
        DataTable tableView,tableOneView,printOne,printTwo;
        List<string> bodyList=new List<string>();List<string> coeList=new List<string>();
        string state=string.Empty;bool result=false;
        
        public FormTestResultRecordOne ( )
        {
            InitializeComponent ( );

            _cu = new MulaolaoLibrary . TestResultRecordOneCUEntity ( );
            _cv = new MulaolaoLibrary . TestResultRecordOneCVEntity ( );
            _cw = new MulaolaoLibrary . TestResultRecordOneCWEntity ( );
            _bll = new MulaolaoBll . Bll . TestResultRecordOneBll ( );
            tableView = new DataTable ( );
            tableOneView = new DataTable ( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );

            Power ( this );
            UnEnable ( );

            secCV002 . Properties . DataSource = _bll . getProInfo ( );
            secCV002 . Properties . DisplayMember = "PQF04";
            secCV002 . Properties . ValueMember = "PQF01";

            reCheckBox . DataSource = _bll . getProNum ( );
            reCheckBox . DisplayMember = "CW001";

            tableOneView = _bll . getTableViewOne ( );
            gridControl2 . DataSource = tableOneView;
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . TestResultRecordOneAll from = new SelectAll . TestResultRecordOneAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _cu . CU001 = _cv . CV001 = from . getOddNum;
                setValue ( );

                if ( from . getZX . Equals ( "执行" ) )
                    labZX . Visible = true;
                else
                    labZX . Visible = false;

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolLibrary . Enabled = toolStorage . Enabled = toolMaintain . Enabled = toolcopy . Enabled =toolReview.Enabled= true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            state = "add";
            _cu . CU001 = _cv . CV001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            txtCV003 . Tag = null;

            base . add ( );
        } 
        protected override void update ( )
        {
            if ( labZX . Visible )
                MessageBox . Show ( "单据状态为执行,请维护" );
            else
            {
                state = "edit";
                Enable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
            }

            base . update ( );
        }
        protected override void delete ( )
        {
            if ( labZX . Visible )
            {
                if ( Logins . number . Equals ( "MLL-0001" ) )
                    del ( );
                else
                    MessageBox . Show ( "您无权删除已执行单据" );
            }
            else
                del ( );


            base . delete ( );
        }
        void del ( )
        {
            result = _bll . Delete ( _cv . CV001 ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                UnEnable ( );
                clearControl ( );
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            }
            else
                MessageBox . Show ( "删除失败,请重试" );
        }
        protected override void save ( )
        {
            if ( string . IsNullOrEmpty ( txtCV004 . Text ) )
            {
                MessageBox . Show ( "请选择流水等信息" );
                return;
            }

            getValue ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView ,tableOneView ,_cv ,bodyList ,coeList ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "成功保存" );
                coeList . Clear ( );
                bodyList . Clear ( );
                UnEnable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            UnEnable ( );
            if ( state . Equals ( "add" ) )
            {
                clearControl ( );
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            }
            else if ( state . Equals ( "edit" ) )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . cancel ( );
        }
        protected override void export ( )
        {
            printOne = _bll . getPrintOne ( _cv . CV001 );
            printOne . TableName = "R_PQCU";
            printTwo = _bll . getPrintTwo ( _cv . CV001 );
            printTwo . TableName = "R_PQCV";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_368.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CU001" ,_cu . CU001 ,"R_PQCU" ,this ,"" ,"R_368" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_368" ,_cu . CU001 );

            base . revirw ( );
        }
        protected override void maintain ( )
        {
            if ( labZX . Visible )
            {
                state = "edit";
                Enable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
            }

            base . maintain ( );
        }
        #endregion

        #region Event
        private void secCV002_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtCV003 . Text = row [ "PQF03" ] . ToString ( );
                txtCV004 . Text = row [ "PQF01" ] . ToString ( );
                txtCV005 . Text = row [ "PQF66" ] . ToString ( );
                txtCV006 . Text = row [ "PQF02" ] . ToString ( );
                txtCV007 . Text = row [ "PQF08" ] . ToString ( );
                txtCV008 . Text = row [ "PQF07" ] . ToString ( );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView2_CustomDrawRowIndicator ( object sender ,RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    bodyList . Add ( row [ "idx" ] . ToString ( ) );
                    tableView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView2 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    coeList . Add ( row [ "idx" ] . ToString ( ) );
                    tableOneView . Rows . Remove ( row );
                    gridControl2 . RefreshDataSource ( );
                }
            }
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            GridView view = sender as GridView;
            view . SetRowCellValue ( e . RowHandle ,gridView1 . Columns [ "CU027" ] ,Logins . username );
        }
        private void txtCV004_TextChanged ( object sender ,EventArgs e )
        {
            DataTable dt = _bll . getPart ( txtCV004 . Text );
            luPart . DataSource = dt;
            luPart . DisplayMember = "GS07";
            luPart . ValueMember = "GS07";
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secCV002 . Enabled = txtCV003 . Enabled = txtCV004 . Enabled = txtCV007 . Enabled = txtCV006 . Enabled = txtCV008 . Enabled = txtCV005 . Enabled = txtCV009 . Enabled = txtCV010 . Enabled =labZX.Visible= false;
            gridView1 . OptionsBehavior . Editable = false;
            gridView2 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            secCV002 . Enabled = txtCV003 . Enabled = txtCV004 . Enabled = txtCV007 . Enabled = txtCV006 . Enabled = txtCV008 . Enabled = txtCV005 . Enabled = txtCV009 . Enabled = txtCV010 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
            gridView2 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            secCV002 . EditValue = null;
            txtCV003 . Text = txtCV004 . Text = txtCV007 . Text = txtCV006 . Text = txtCV008 . Text = txtCV005 . Text = txtCV009 . Text = txtCV010 . Text = string . Empty;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void setValue ( )
        {
            tableView = _bll . getTableView ( " CU001='" + _cu . CU001 + "'" );
            gridControl1 . DataSource = tableView;
            tableOneView = _bll . getTableViewOne ( );
            gridControl2 . DataSource = tableOneView;
            _cv = _bll . getModel ( _cv . CV001 );
            setValueHead ( );
        }
        void setValueHead ( )
        {
            secCV002 . EditValue = _cv . CV004;
            txtCV003 . Tag = _cv . idx;
            txtCV003 . Text = _cv . CV003;
            txtCV004 . Text = _cv . CV004;
            txtCV005 . Text = _cv . CV005;
            txtCV006 . Text = _cv . CV006;
            txtCV007 . Text = _cv . CV007;
            txtCV008 . Text = _cv . CV008;
            txtCV009 . Text = _cv . CV009;
            txtCV010 . Text = _cv . CV010;
        }
        void getValue ( )
        {
            if ( txtCV003 . Tag == null )
                _cv . idx = 0;
            else
                _cv . idx = Convert . ToInt32 ( txtCV003 . Tag );
            _cv . CV002 = secCV002 . Text;
            _cv . CV003 = txtCV003 . Text;
            _cv . CV004 = txtCV004 . Text;
            _cv . CV005 = txtCV005 . Text;
            _cv . CV006 = txtCV006 . Text;
            _cv . CV007 = txtCV007 . Text;
            _cv . CV008 = txtCV008 . Text;
            _cv . CV009 = txtCV009 . Text;
            _cv . CV010 = txtCV010 . Text;
        }
        #endregion

    }
}
