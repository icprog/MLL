using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormTestResultRecord :FormChild
    {
        MulaolaoLibrary.TestResultRecordCREntity _cr=null;
        MulaolaoLibrary.TestResultRecordCSEntity _cs=null;
        MulaolaoLibrary.TestResultRecordCTEntity _ct=null;
        MulaolaoBll.Bll.TestResultRecordBll _bll=null;
        DataTable tableView,tableViewOne,printOne,printTwo;
        string state=string.Empty;bool result=false;
        List<string> coeList=new List<string>();
        List<string> bodyList=new List<string>();
        
        public FormTestResultRecord ( )
        {
            InitializeComponent ( );

            _cr = new MulaolaoLibrary . TestResultRecordCREntity ( );
            _cs = new MulaolaoLibrary . TestResultRecordCSEntity ( );
            _ct = new MulaolaoLibrary . TestResultRecordCTEntity ( );
            _bll = new MulaolaoBll . Bll . TestResultRecordBll ( );
            tableView = new DataTable ( );
            tableViewOne = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1,gridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            secPro . Properties . DataSource = _bll . getProInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

            reCheckBox . DataSource = _bll . getTableOfNum ( );
            reCheckBox . DisplayMember = "CT";

            tableViewOne = _bll . getTableViewOne ( );
            gridControl2 . DataSource = tableViewOne;

        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . TestResultRecordAll from = new SelectAll . TestResultRecordAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System.Windows.Forms.DialogResult . OK )
            {
                _cr . CR001 = _cs . CS001 = from . getString;
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
            _cr . CR001 = _cs . CS001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            txtUserTre . Text = Logins . username;
            txtNo . Tag = null;

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
            result = _bll . Delete ( _cr . CR001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( txtNum . Text ) )
            {
                MessageBox . Show ( "请选择流水等信息" );
                return;
            }

            getValue ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView ,_cr ,tableViewOne ,coeList ,bodyList ,Logins . username );
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
            printOne = _bll . getPrintOne ( _cr . CR001 );
            printOne . TableName = "R_PQCR";
            printTwo = _bll . getPrintTwo ( _cr . CR001 );
            printTwo . TableName = "R_PQCS";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_418.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CR001" ,_cr . CR001 ,"R_PQCR" ,this ,"" ,"R_418" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_418" ,_cr . CR001 );

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
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CS002" ] ,MulaolaoBll . Drity . GetDt ( ) );
        }
        private void secPro_EditValueChanged ( object sender ,System . EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtNo . Text = row [ "PQF03" ] . ToString ( );
                txtNum . Text = row [ "PQF01" ] . ToString ( );
                txtPD . Text = row [ "PQF66" ] . ToString ( );
                txtCus . Text = row [ "DFA003" ] . ToString ( );
                txtAge . Text = row [ "PQF08" ] . ToString ( );
                txtImp . Text = row [ "PQF07" ] . ToString ( );
            }
        }
        private void txtNum_TextChanged ( object sender ,System . EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( txtNum . Text ) )
            {
                DataTable dt = _bll . getPart ( txtNum . Text );
                luPart . DataSource = dt;
                luPart . DisplayMember = "GS07";
                luPart . ValueMember = "GS07";
            }
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 13 )
            {
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    if ( MessageBox . Show ( "是否删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
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
                    if ( MessageBox . Show ( "是否删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    coeList . Add ( row [ "idx" ] . ToString ( ) );
                    tableViewOne . Rows . Remove ( row );
                    gridControl2 . RefreshDataSource ( );
                }

            }
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secPro . Enabled = txtNo . Enabled = txtNum . Enabled = txtAge . Enabled = txtCus . Enabled = txtImp . Enabled = txtPD . Enabled = txtUserOne . Enabled = txtUserTre . Enabled = txtUserTwo . Enabled =labZX.Visible= false;
            gridView1 . OptionsBehavior . Editable = false;
            gridView2 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            secPro . Enabled = txtNo . Enabled = txtNum . Enabled = txtAge . Enabled = txtCus . Enabled = txtImp . Enabled = txtPD . Enabled = txtUserOne . Enabled = txtUserTre . Enabled = txtUserTwo . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
            gridView2 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            secPro . EditValue = null;
            txtNo . Text = txtNum . Text = txtAge . Text = txtCus . Text = txtImp . Text = txtPD . Text = txtUserOne . Text = txtUserTre . Text = txtUserTwo . Text = string . Empty;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void setValue ( )
        {
            tableView = _bll . getTableView ( " CS001='" + _cs . CS001 + "'" );
            gridControl1 . DataSource = tableView;
            _cr = _bll . getModel ( _cr . CR001 );
            setValueHead ( );
        }
        void setValueHead ( )
        {
            secPro . EditValue = _cr . CR004;
            txtNo . Tag = _cr . idx;
            txtNo . Text = _cr . CR003;
            txtNum . Text = _cr . CR004;
            txtPD . Text = _cr . CR005;
            txtCus . Text = _cr . CR006;
            txtAge . Text = _cr . CR007;
            txtImp . Text = _cr . CR008;
            txtUserOne . Text = _cr . CR009;
            txtUserTwo . Text = _cr . CR010;
            txtUserTre . Text = _cr . CR011;
        }
        void getValue ( )
        {
            if ( txtNo . Tag == null )
                _cr . idx = 0;
            else
                _cr . idx = Convert . ToInt32 ( txtNo . Tag );
            _cr . CR002 = secPro . Text;
            _cr . CR003 = txtNo . Text;
            _cr . CR004 = txtNum . Text;
            _cr . CR005 = txtPD . Text;
            _cr . CR006 = txtCus . Text;
            _cr . CR007 = txtAge . Text;
            _cr . CR008 = txtImp . Text;
            _cr . CR009 = txtUserOne . Text;
            _cr . CR010 = txtUserTwo . Text;
            _cr . CR011 = txtUserTre . Text;
        }
        #endregion

    }
}
