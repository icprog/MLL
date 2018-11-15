using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormSafetyManegerAndControl :FormChild
    {
        MulaolaoLibrary.SafetyManegerAndControlDCEntity _dc=null;
        MulaolaoLibrary.SafetyManegerAndControlDDEntity _dd=null;
        MulaolaoLibrary.SafetyManegerAndControlDEEntity _de=null;
        MulaolaoBll.Bll.SafetyManegerAndControlBll _bll=null;
        DataTable tableView,tableViewOne,printOne,printTwo;
        List<string> bodyList=new List<string>();
        List<string> coeList=new List<string>();
        string state=string.Empty;bool result=false;
        
        public FormSafetyManegerAndControl ( )
        {
            InitializeComponent ( );

            _dc = new MulaolaoLibrary . SafetyManegerAndControlDCEntity ( );
            _dd = new MulaolaoLibrary . SafetyManegerAndControlDDEntity ( );
            _de = new MulaolaoLibrary . SafetyManegerAndControlDEEntity ( );
            _bll = new MulaolaoBll . Bll . SafetyManegerAndControlBll ( );
            tableView = new DataTable ( );
            tableViewOne = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            secDC002 . Properties . DataSource = _bll . getProInfo ( );
            secDC002 . Properties . DisplayMember = "PQF04";
            secDC002 . Properties . ValueMember = "PQF01";

            //tableViewOne = _bll . getTableOfCoefficient ( );
            //gridControl2 . DataSource = tableViewOne;

            resCheckCom . DataSource = _bll . itemNum ( );
            resCheckCom . DisplayMember = "DE002";

        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . SafetyManegerAndControlAll from = new SelectAll . SafetyManegerAndControlAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _dc . DC001 = _dd . DD001 = from . getOddNum;
                setValues ( );

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
            _dc . DC001 = _dd . DD001 = _bll . getOddNum ( );
            Enable ( );
            Clear ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;
            txtDC003 . Tag = null;

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
            result = _bll . Delete ( _dc . DC001 ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                UnEnable ( );
                Clear ( );
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            }
            else
                MessageBox . Show ( "删除失败,请重试" );
        }
        protected override void save ( )
        {
            if ( string . IsNullOrEmpty ( txtDC004 . Text ) )
            {
                MessageBox . Show ( "请选择流水等信息" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbDC009 . Text ) )
            {
                MessageBox . Show ( "管控责任人不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbDC011 . Text ) )
            {
                MessageBox . Show ( "生产监管人不可为空" );
                return;
            }

            getValue ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            //gridView2 . CloseEditor ( );
            //gridView2 . UpdateCurrentRow ( );

            result = _bll . Save ( tableView ,tableViewOne ,_dc ,bodyList ,coeList ,Logins . username );
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
                Clear ( );
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
            printOne = _bll . getPrintOne ( _dc . DC001 );
            printOne . TableName = "R_PQDD";
            printTwo = _bll . getPrintTwo ( _dc . DC001 );
            printTwo . TableName = "R_PQDC";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_429.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "DC001" ,_dc . DC001 ,"R_PQDC" ,this ,"" ,"R_429" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_429" ,_dc . DC001 );

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
            secDC002 . Enabled = txtDC003 . Enabled = txtDC004 . Enabled = txtDC005 . Enabled = txtDC006 . Enabled = txtDC007 . Enabled = txtDC014 . Enabled = dtDC008 . Enabled = cmbDC009 . Enabled = cmbDC010 . Enabled = cmbDC011 . Enabled = cmbDC012 . Enabled = cmbDC013 . Enabled = chDC015 . Enabled = chDC016 . Enabled = chDC017 . Enabled = chDC018 . Enabled = chDC019 . Enabled = chDC020 . Enabled = chDC021 . Enabled = chDC022 . Enabled = chDC023 . Enabled = chDC024 . Enabled = chDC025 . Enabled = chDC026 . Enabled = chDC027 . Enabled = chDC028 . Enabled = chDC029 . Enabled = chDC030 . Enabled = chDC031 . Enabled = chDC032 . Enabled =labZX.Visible= false;
            gridView1 . OptionsBehavior . Editable = false;
            //gridView2 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            secDC002 . Enabled = txtDC003 . Enabled = txtDC004 . Enabled = txtDC005 . Enabled = txtDC006 . Enabled = txtDC007 . Enabled = txtDC014 . Enabled = dtDC008 . Enabled = cmbDC009 . Enabled = cmbDC010 . Enabled = cmbDC011 . Enabled = cmbDC012 . Enabled = cmbDC013 . Enabled = chDC015 . Enabled = chDC016 . Enabled = chDC017 . Enabled = chDC018 . Enabled = chDC019 . Enabled = chDC020 . Enabled = chDC021 . Enabled = chDC022 . Enabled = chDC023 . Enabled = chDC024 . Enabled = chDC025 . Enabled = chDC026 . Enabled = chDC027 . Enabled = chDC028 . Enabled = chDC029 . Enabled = chDC030 . Enabled = chDC031 . Enabled = chDC032 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
            //gridView2 . OptionsBehavior . Editable = true;
        }
        void Clear ( )
        {
            secDC002 . EditValue = null;
            txtDC003 . Text = txtDC004 . Text = txtDC005 . Text = txtDC006 . Text = txtDC007 . Text = txtDC014 . Text = cmbDC009 . Text = cmbDC010 . Text = cmbDC011 . Text = cmbDC012 . Text = cmbDC013 . Text = string . Empty;
            dtDC008 . Value = MulaolaoBll . Drity . GetDt ( );
            gridControl1 . DataSource = null;
            chDC015 . Checked = chDC016 . Checked = chDC017 . Checked = chDC018 . Checked = chDC019 . Checked = chDC020 . Checked = chDC021 . Checked = chDC022 . Checked = chDC023 . Checked = chDC024 . Checked = chDC025 . Checked = chDC026 . Checked = chDC027 . Checked = chDC028 . Checked = chDC029 . Checked = chDC030 . Checked = chDC031 . Checked = chDC032 . Checked =labZX.Visible= false;
        }
        void setValues ( )
        {
            tableView = _bll . getTableView ( " DD001='" + _dd . DD001 + "'" );
            gridControl1 . DataSource = tableView;
            //tableViewOne = _bll . getTableOfCoefficient ( );
            //gridControl2 . DataSource = tableViewOne;
            _dc = _bll . getModel ( _dc . DC001 );
            setValue ( );
        }
        void setValue ( )
        {
            txtDC003 . Tag = _dc . idx;
            secDC002 . EditValue = _dc . DC004;
            txtDC003 . Text = _dc . DC003;
            txtDC004 . Text = _dc . DC004;
            txtDC005 . Text = _dc . DC005 . ToString ( );
            txtDC006 . Text = _dc . DC006;
            txtDC007 . Text = _dc . DC007;
            txtDC014 . Text = _dc . DC014;
            cmbDC009 . Text = _dc . DC009;
            cmbDC010 . Text = _dc . DC010;
            cmbDC011 . Text = _dc . DC011;
            cmbDC012 . Text = _dc . DC012;
            cmbDC013 . Text = _dc . DC013;
            chDC015 . Checked = _dc . DC015;
            chDC016 . Checked = _dc . DC016;
            chDC017 . Checked = _dc . DC017;
            chDC018 . Checked = _dc . DC018;
            chDC019 . Checked = _dc . DC019;
            chDC020 . Checked = _dc . DC020;
            chDC021 . Checked = _dc . DC021;
            chDC022 . Checked = _dc . DC022;
            chDC023 . Checked = _dc . DC023;
            chDC024 . Checked = _dc . DC024;
            chDC025 . Checked = _dc . DC025;
            chDC026 . Checked = _dc . DC026;
            chDC027 . Checked = _dc . DC027;
            chDC028 . Checked = _dc . DC028;
            chDC029 . Checked = _dc . DC029;
            chDC030 . Checked = _dc . DC030;
            chDC031 . Checked = _dc . DC031;
            chDC032 . Checked = _dc . DC032;
            if ( _dc . DC008 > DateTime . MinValue && _dc . DC008 < DateTime . MaxValue )
                dtDC008 . Value = Convert . ToDateTime ( _dc . DC008 );
        }
        void getValue ( )
        {
            if ( txtDC003 . Tag == null )
                _dc . idx = 0;
            else
                _dc . idx = Convert . ToInt32 ( txtDC003 . Tag );
            _dc . DC002 = secDC002 . Text . ToString ( );
            _dc . DC003 = txtDC003 . Text;
            _dc . DC004 = txtDC004 . Text;
            _dc . DC005 = string . IsNullOrEmpty ( txtDC005 . Text ) == true ? 0 : Convert . ToInt32 ( txtDC005 . Text );
            _dc . DC006 = txtDC006 . Text;
            _dc . DC007 = txtDC007 . Text;
            _dc . DC014 = txtDC014 . Text;
            _dc . DC009 = cmbDC009 . Text;
            _dc . DC010 = cmbDC010 . Text;
            _dc . DC011 = cmbDC011 . Text;
            _dc . DC012 = cmbDC012 . Text;
            _dc . DC013 = cmbDC013 . Text;
            _dc . DC008 = dtDC008 . Value;
            _dc . DC015 = chDC015 . Checked;
            _dc . DC016 = chDC016 . Checked;
            _dc . DC017 = chDC017 . Checked;
            _dc . DC018 = chDC018 . Checked;
            _dc . DC019 = chDC019 . Checked;
            _dc . DC020 = chDC020 . Checked;
            _dc . DC021 = chDC021 . Checked;
            _dc . DC022 = chDC022 . Checked;
            _dc . DC023 = chDC023 . Checked;
            _dc . DC024 = chDC024 . Checked;
            _dc . DC025 = chDC025 . Checked;
            _dc . DC026 = chDC026 . Checked;
            _dc . DC027 = chDC027 . Checked;
            _dc . DC028 = chDC028 . Checked;
            _dc . DC029 = chDC029 . Checked;
            _dc . DC030 = chDC030 . Checked;
            _dc . DC031 = chDC031 . Checked;
            _dc . DC032 = chDC032 . Checked;
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
        private void secDC002_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtDC003 . Text = row [ "PQF03" ] . ToString ( );
                txtDC004 . Text = row [ "PQF01" ] . ToString ( );
                txtDC005 . Text = row [ "PQF06" ] . ToString ( );
                txtDC006 . Text = row [ "PQF08" ] . ToString ( );
                txtDC007 . Text = row [ "PQF07" ] . ToString ( );
            }
        }
        private void gridControl1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( e . KeyChar != 13 )
                return;
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
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //if ( e . KeyChar != 13 )
            //    return;
            //DataRow row = gridView2 . GetFocusedDataRow ( );
            //if ( row != null )
            //{
            //    if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
            //        return;
            //    coeList . Add ( row [ "idx" ] . ToString ( ) );
            //    tableViewOne . Rows . Remove ( row );
            //    gridControl2 . RefreshDataSource ( );
            //}
        }
        private void txtDC004_TextChanged ( object sender ,EventArgs e )
        {
            DataTable getPart = _bll . getPart ( txtDC004 . Text );
            luPart . DataSource = getPart;
            luPart . DisplayMember = "GS07";
            luPart . ValueMember = "GS07";
        }
        #endregion

    }
}
