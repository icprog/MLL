using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormTestReportForAQ :FormChild
    {
        MulaolaoLibrary.TestReportForAQDAEntity _da=null;
        MulaolaoLibrary.TestReportForAQDBEntity _db=null;
        MulaolaoBll.Bll.TestReportForAQBll _bll=null;
        DataTable tableView,printOne,printTwo;
        List<string> bodyList=new List<string>();
        string state=string.Empty; bool result=false;
        
        public FormTestReportForAQ ( )
        {
            InitializeComponent ( );

            _da = new MulaolaoLibrary . TestReportForAQDAEntity ( );
            _db = new MulaolaoLibrary . TestReportForAQDBEntity ( );
            _bll = new MulaolaoBll . Bll . TestReportForAQBll ( );
            tableView = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            secDA002 . Properties . DataSource = _bll . getProInfo ( );
            secDA002 . Properties . DisplayMember = "PQF04";
            secDA002 . Properties . ValueMember = "PQF01";
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . TestReportForAQAll from = new SelectAll . TestReportForAQAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _da . DA001 = _db . DB001 = from . getStr;
                setValues ( );

                if ( from . getZX . Equals ( "执行" ) )
                    labZX . Visible = true;
                else
                    labZX . Visible = false;

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolLibrary . Enabled = toolStorage . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            state = "add";
            _da . DA001 = _db . DB001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            txtDA003 . Tag = null;

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
            result = _bll . Delete ( _da . DA001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( txtDA004 . Text ) )
            {
                MessageBox . Show ( "请选择流水等信息" );
                return;
            }

            getValue ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView  ,_da ,bodyList ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "成功保存" );
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
            printOne = _bll . getPrintOne ( _da . DA001 );
            printOne . TableName = "R_PQDB";
            printTwo = _bll . getPrintTwo ( _da . DA001 );
            printTwo . TableName = "R_PQDA";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_142.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "DA001" ,_da . DA001 ,"R_PQDA" ,this ,"" ,"R_142" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_142" ,_da . DA001 );

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

        #region Method
        void UnEnable ( )
        {
            secDA002 . Enabled = txtDA003 . Enabled = txtDA004 . Enabled = txtDA005 . Enabled = txtDA006 . Enabled = txtDA007 . Enabled = txtDA008 . Enabled = txtDA009 . Enabled =txtDA014.Enabled= dtDA010 . Enabled = dtDA011 . Enabled = dtDA012 . Enabled = dtDA013 . Enabled = cmbDA018 . Enabled = dtDA019 . Enabled = cmbDA020 . Enabled = dtDA021 . Enabled = raDA015 . Enabled = raDA016 . Enabled = raDA017 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
            labZX . Visible = false;
        }
        void Enable ( )
        {
            secDA002 . Enabled = txtDA003 . Enabled = txtDA004 . Enabled = txtDA005 . Enabled = txtDA006 . Enabled = txtDA007 . Enabled = txtDA008 . Enabled = txtDA009 . Enabled = txtDA014 . Enabled = dtDA010 . Enabled = dtDA011 . Enabled = dtDA012 . Enabled = dtDA013 . Enabled = cmbDA018 . Enabled = dtDA019 . Enabled = cmbDA020 . Enabled = dtDA021 . Enabled = raDA015 . Enabled = raDA016 . Enabled = raDA017 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            secDA002 . EditValue = null;
            txtDA003 . Text = txtDA004 . Text = txtDA014 . Text = txtDA005 . Text = txtDA006 . Text = txtDA007 . Text = txtDA008 . Text = txtDA009 . Text = cmbDA018 . Text = cmbDA020 . Text = string . Empty;
            dtDA010 . Value = dtDA011 . Value = dtDA012 . Value = dtDA013 . Value = dtDA021 . Value = dtDA019 . Value = MulaolaoBll . Drity . GetDt ( );
            raDA015 . Checked = raDA016 . Checked = raDA017 . Checked = false;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void setValues ( )
        {
            tableView = _bll . getTableView ( "DB001='" + _db . DB001 + "'" );
            gridControl1 . DataSource = tableView;
            _da = _bll . getModel ( _da . DA001 );
            setValue ( );
        }
        void setValue ( )
        {
            txtDA003 . Tag = _da . idx;
            secDA002 . EditValue = _da . DA004;
            txtDA003 . Text = _da . DA003;
            txtDA004 . Text = _da . DA004;
            txtDA005 . Text = _da . DA005;
            txtDA006 . Text = _da . DA006 . ToString ( );
            txtDA007 . Text = _da . DA007;
            txtDA008 . Text = _da . DA008;
            txtDA009 . Text = _da . DA009;
            txtDA014 . Text = _da . DA014;
            if ( _da . DA010 > DateTime . MinValue && _da . DA010 < DateTime . MaxValue )
                dtDA010 . Value = Convert . ToDateTime ( _da . DA010 );
            if ( _da . DA011 > DateTime . MinValue && _da . DA011 < DateTime . MaxValue )
                dtDA011 . Value = Convert . ToDateTime ( _da . DA011 );
            if ( _da . DA012 > DateTime . MinValue && _da . DA012 < DateTime . MaxValue )
                dtDA012 . Value = Convert . ToDateTime ( _da . DA012 );
            if ( _da . DA013 > DateTime . MinValue && _da . DA013 < DateTime . MaxValue )
                dtDA013 . Value = Convert . ToDateTime ( _da . DA013 );
            if ( _da . DA019 > DateTime . MinValue && _da . DA019 < DateTime . MaxValue )
                dtDA019 . Value = Convert . ToDateTime ( _da . DA019 );
            if ( _da . DA021 > DateTime . MinValue && _da . DA021 < DateTime . MaxValue )
                dtDA021 . Value = Convert . ToDateTime ( _da . DA021 );
            raDA015 . Checked = _da . DA015;
            raDA016 . Checked = _da . DA016;
            raDA016 . Checked = _da . DA017;
            cmbDA018 . Text = _da . DA018;
            cmbDA020 . Text = _da . DA020;
        }
        void getValue ( )
        {
            if ( txtDA003 . Tag == null )
                _da . idx = 0;
            else
                _da . idx = Convert . ToInt32 ( txtDA003 . Tag );
            _da . DA002 = secDA002 . Text;
            _da . DA003 = txtDA003 . Text;
            _da . DA004 = txtDA004 . Text;
            _da . DA005 = txtDA005 . Text;
            _da . DA006 = string . IsNullOrEmpty ( txtDA006 . Text ) == true ? 0 : Convert . ToInt32 ( txtDA006 . Text );
            _da . DA007 = txtDA007 . Text;
            _da . DA008 = txtDA008 . Text;
            _da . DA009 = txtDA009 . Text;
            _da . DA014 = txtDA014 . Text;
            _da . DA010 = dtDA010 . Value;
            _da . DA011 = dtDA011 . Value;
            _da . DA012 = dtDA012 . Value;
            _da . DA013 = dtDA013 . Value;
            _da . DA019 = dtDA019 . Value;
            _da . DA021 = dtDA021 . Value;
            _da . DA015 = raDA015 . Checked;
            _da . DA016 = raDA016 . Checked;
            _da . DA017 = raDA016 . Checked;
            _da . DA018 = cmbDA018 . Text;
            _da . DA020 = cmbDA020 . Text;
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
        private void secDA002_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtDA003 . Text = row [ "PQF03" ] . ToString ( );
                txtDA004 . Text = row [ "PQF01" ] . ToString ( );
                txtDA005 . Text = row [ "DFA003" ] . ToString ( );
                txtDA006 . Text = row [ "PQF06" ] . ToString ( );
                txtDA007 . Text = row [ "PQF08" ] . ToString ( );
                txtDA008 . Text = row [ "PQF07" ] . ToString ( );
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
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "DB010" ] ,( gridView1 . DataRowCount + 1 ) . ToString ( ) );
        }
        #endregion

    }
}
