using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormProductSpecification :FormChild
    {
        MulaolaoLibrary.ProductSpecificationDFEntity _df=null;
        MulaolaoLibrary.ProductSpecificationDGEntity _dg=null;
        MulaolaoLibrary .ProductSpecificationDHEntity _dh=null;

        MulaolaoBll.Bll.ProductSpecificationBll _bll=null;
        DataTable tableView,tableViewOne,printOne,printTwo,getPart;
        string state=string.Empty;bool result=false;
        List<string> bodyList=new List<string>();
        List<string> coeList=new List<string>();
        
        public FormProductSpecification ( )
        {
            InitializeComponent ( );

            _df = new MulaolaoLibrary . ProductSpecificationDFEntity ( );
            _dg = new MulaolaoLibrary . ProductSpecificationDGEntity ( );
            _dh = new MulaolaoLibrary . ProductSpecificationDHEntity ( );

            _bll = new MulaolaoBll . Bll . ProductSpecificationBll ( );
            tableView = new DataTable ( );
            tableViewOne = new DataTable ( );
            printOne = new DataTable ( );
            printTwo = new DataTable ( );
            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );


            secDF002 . Properties . DataSource = _bll . getProInfo ( );
            secDF002 . Properties . DisplayMember = "PQF04";
            secDF002 . Properties . ValueMember = "PQF01";

            //tableViewOne = _bll . getTableOfCoefficient ( );
            //gridControl2 . DataSource = tableViewOne;

            resCheckCom . DataSource = _bll . getTableCheck ( );
            resCheckCom . DisplayMember = "DH002";
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . ProductSpecificationAll from = new SelectAll . ProductSpecificationAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _df . DF001 = _dg . DG001 = from . getOddNum;
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
            _df . DF001 = _dg . DG001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "''" );
            gridControl1 . DataSource = tableView;
            txtDF003 . Tag = null;

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
            result = _bll . Delete ( _df . DF001 ,Logins . username );
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
        protected override void save ( )
        {
            if ( string . IsNullOrEmpty ( txtDF004 . Text ) )
            {
                MessageBox . Show ( "请选择流水等信息" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbDF008 . Text ) )
            {
                MessageBox . Show ( "QC组长(审核)不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbDF009 . Text ) )
            {
                MessageBox . Show ( "QC(检验)员不可为空" );
                return;
            }
            getValue ( );

            result = _bll . Save ( tableView ,tableViewOne ,_df ,Logins . username ,bodyList ,coeList );
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
        protected override void export ( )
        {
            printOne = _bll . getPrintOne ( _df . DF001 );
            printOne . TableName = "R_PQDG";
            printTwo = _bll . getPrintTwo ( _df . DF001 );
            printTwo . TableName = "R_PQDF";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_366.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "DF001" ,_df . DF001 ,"R_PQDF" ,this ,"" ,"R_366" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_366" ,_df . DF001 );

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
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void gridView1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == ( char ) Keys . Enter )
            {
                if ( MessageBox . Show ( "确定删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row != null )
                {
                    bodyList . Add ( row [ "idx" ] . ToString ( ) );
                    tableView . Rows . Remove ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void gridView2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //if ( e . KeyChar == ( char ) Keys . Enter )
            //{
            //    if ( MessageBox . Show ( "确定删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
            //        return;
            //    DataRow row = gridView2 . GetFocusedDataRow ( );
            //    if ( row != null )
            //    {
            //        coeList . Add ( row [ "idx" ] . ToString ( ) );
            //        tableViewOne . Rows . Remove ( row );
            //        gridControl2 . RefreshDataSource ( );
            //    }
            //}
        }
        private void secDF002_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtDF003 . Text = row [ "PQF03" ] . ToString ( );
                txtDF004 . Text = row [ "PQF01" ] . ToString ( );
                txtDF005 . Text = row [ "PQF06" ] . ToString ( );
                txtDF006 . Text = row [ "PQF31" ] . ToString ( );
            }
        }
        private void txtDF004_TextChanged ( object sender ,EventArgs e )
        {
            getPart = _bll . getTablePart ( txtDF004 . Text );
            luPart . DataSource = getPart;
            luPart . DisplayMember = "GS07";
            luPart . ValueMember = "GS07";
        }
        private void luPart_EditValueChanged ( object sender ,EventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = gridView1 . ActiveEditor;
            switch ( gridView1 . FocusedColumn . FieldName )
            {
                case "DG003":
                string str = getPart . Select ( "GS07='" + edit . EditValue + "'" ) [ 0 ] [ "GS10" ] . ToString ( );
                gridView1 . SetFocusedRowCellValue ( gridView1 . Columns [ "DG006" ] ,str );
                break;
            }
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secDF002 . Enabled = txtDF003 . Enabled = txtDF004 . Enabled = txtDF005 . Enabled = txtDF006 . Enabled = txtDF007 . Enabled = cmbDF008 . Enabled = cmbDF009 . Enabled = cmbDF010 . Enabled = chDF011 . Enabled = chDF012 . Enabled = chDF013 . Enabled = chDF014 . Enabled = chDF015 . Enabled = chDF016 . Enabled = chDF017 . Enabled = chDF018 . Enabled = chDF019 . Enabled = chDF020 . Enabled = chDF021 . Enabled = chDF022 . Enabled = chDF023 . Enabled = chDF024 . Enabled = chDF025 . Enabled = chDF026 . Enabled = chDF027 . Enabled = chDF028 . Enabled = chDF029 . Enabled = chDF030 . Enabled = chDF031 . Enabled = chDF032 . Enabled = chDF033 . Enabled = chDF034 . Enabled = chDF035 . Enabled = chDF036 . Enabled = chDF037 . Enabled = chDF038 . Enabled = chDF039 . Enabled = chDF040 . Enabled = chDF041 . Enabled = chDF042 . Enabled = chDF043 . Enabled = chDF044 . Enabled = chDF045 . Enabled = chDF046 . Enabled = chDF047 . Enabled = chDF048 . Enabled = chDF049 . Enabled = chDF050 . Enabled = chDF051 . Enabled = chDF052 . Enabled = chDF053 . Enabled = chDF054 . Enabled = chDF055 . Enabled = chDF056 . Enabled = labZX . Visible = chDF057 . Enabled = chDF058 . Enabled = chDF059 . Enabled = chDF060 . Enabled = chDF061 . Enabled = chDF062 . Enabled = chDF063 . Enabled = chDF064 . Enabled = chDF065 . Enabled = chDF066 . Enabled = chDF067 . Enabled = chDF068 . Enabled = chDF069 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            secDF002 . Enabled = txtDF003 . Enabled = txtDF004 . Enabled = txtDF005 . Enabled = txtDF006 . Enabled = txtDF007 . Enabled = cmbDF008 . Enabled = cmbDF009 . Enabled = cmbDF010 . Enabled = chDF011 . Enabled = chDF012 . Enabled = chDF013 . Enabled = chDF014 . Enabled = chDF015 . Enabled = chDF016 . Enabled = chDF017 . Enabled = chDF018 . Enabled = chDF019 . Enabled = chDF020 . Enabled = chDF021 . Enabled = chDF022 . Enabled = chDF023 . Enabled = chDF024 . Enabled = chDF025 . Enabled = chDF026 . Enabled = chDF027 . Enabled = chDF028 . Enabled = chDF029 . Enabled = chDF030 . Enabled = chDF031 . Enabled = chDF032 . Enabled = chDF033 . Enabled = chDF034 . Enabled = chDF035 . Enabled = chDF036 . Enabled = chDF037 . Enabled = chDF038 . Enabled = chDF039 . Enabled = chDF040 . Enabled = chDF041 . Enabled = chDF042 . Enabled = chDF043 . Enabled = chDF044 . Enabled = chDF045 . Enabled = chDF046 . Enabled = chDF047 . Enabled = chDF048 . Enabled = chDF049 . Enabled = chDF050 . Enabled = chDF051 . Enabled = chDF052 . Enabled = chDF053 . Enabled = chDF054 . Enabled = chDF055 . Enabled = chDF056 . Enabled = chDF057 . Enabled = chDF058 . Enabled = chDF059 . Enabled = chDF060 . Enabled = chDF061 . Enabled = chDF062 . Enabled = chDF063 . Enabled = chDF064 . Enabled = chDF065 . Enabled = chDF066 . Enabled = chDF067 . Enabled = chDF068 . Enabled = chDF069 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            secDF002 . EditValue = null;
            txtDF003 . Text = txtDF004 . Text = txtDF005 . Text = txtDF006 . Text = txtDF007 . Text = cmbDF008 . Text = cmbDF009 . Text = cmbDF010 . Text = string . Empty;
            gridControl1 . DataSource = null;
            chDF011 . Checked = chDF012 . Checked = chDF013 . Checked = chDF014 . Checked = chDF015 . Checked = chDF016 . Checked = chDF017 . Checked = chDF018 . Checked = chDF019 . Checked = chDF020 . Checked = chDF021 . Checked = chDF022 . Checked = chDF023 . Checked = chDF024 . Checked = chDF025 . Checked = chDF026 . Checked = chDF027 . Checked = chDF028 . Checked = chDF029 . Checked = chDF030 . Checked = chDF031 . Checked = chDF032 . Checked = chDF033 . Checked = chDF034 . Checked = chDF035 . Checked = chDF036 . Checked = chDF037 . Checked = chDF038 . Checked = chDF039 . Checked = chDF040 . Checked = chDF041 . Checked = chDF042 . Checked = chDF043 . Checked = chDF044 . Checked = chDF045 . Checked = chDF046 . Checked = chDF047 . Checked = chDF048 . Checked = chDF049 . Checked = chDF050 . Checked = chDF051 . Checked = chDF052 . Checked = chDF053 . Checked = chDF054 . Checked = chDF055 . Checked = chDF056 . Checked = labZX . Visible = chDF057 . Checked = chDF058 . Checked = chDF059 . Checked = chDF060 . Checked = chDF061 . Checked = chDF062 . Checked = chDF063 . Checked = chDF064 . Checked = chDF065 . Checked = chDF066 . Checked = chDF067 . Checked = chDF068 . Checked = chDF069 . Checked = false;
        }
        void setValue ( )
        {
            _df = _bll . getModel ( _df . DF001 );
            if ( _df == null ) return;
            setValueHead ( );

            tableView = _bll . getTableView ( _df . DF001 );
            gridControl1 . DataSource = tableView;
        }
        void setValueHead ( )
        {
            txtDF003 . Tag = _df . idx;
            secDF002 . EditValue = _df . DF004;
            txtDF003 . Text = _df . DF003;
            txtDF004 . Text = _df . DF004;
            txtDF005 . Text = _df . DF005 . ToString ( );
            txtDF006 . Text = _df . DF006 . ToString ( );
            txtDF007 . Text = _df . DF007 . ToString ( );
            cmbDF008 . Text = _df . DF008;
            cmbDF009 . Text = _df . DF009;
            cmbDF010 . Text = _df . DF010;
            chDF011 . Checked = _df . DF011;
            chDF012 . Checked = _df . DF012;
            chDF013 . Checked = _df . DF013;
            chDF014 . Checked = _df . DF014;
            chDF015 . Checked = _df . DF015;
            chDF016 . Checked = _df . DF016;
            chDF017 . Checked = _df . DF017;
            chDF018 . Checked = _df . DF018;
            chDF019 . Checked = _df . DF019;
            chDF020 . Checked = _df . DF020;
            chDF021 . Checked = _df . DF021;
            chDF022 . Checked = _df . DF022;
            chDF023 . Checked = _df . DF023;
            chDF024 . Checked = _df . DF024;
            chDF025 . Checked = _df . DF025;
            chDF026 . Checked = _df . DF026;
            chDF027 . Checked = _df . DF027;
            chDF028 . Checked = _df . DF028;
            chDF029 . Checked = _df . DF029;
            chDF030 . Checked = _df . DF030;
            chDF031 . Checked = _df . DF031;
            chDF032 . Checked = _df . DF032;
            chDF033 . Checked = _df . DF033;
            chDF034 . Checked = _df . DF034;
            chDF035 . Checked = _df . DF035;
            chDF036 . Checked = _df . DF036;
            chDF037 . Checked = _df . DF037;
            chDF038 . Checked = _df . DF038;
            chDF039 . Checked = _df . DF039;
            chDF040 . Checked = _df . DF040;
            chDF041 . Checked = _df . DF041;
            chDF042 . Checked = _df . DF042;
            chDF043 . Checked = _df . DF043;
            chDF044 . Checked = _df . DF044;
            chDF045 . Checked = _df . DF045;
            chDF046 . Checked = _df . DF046;
            chDF047 . Checked = _df . DF047;
            chDF048 . Checked = _df . DF048;
            chDF049 . Checked = _df . DF049;
            chDF050 . Checked = _df . DF050;
            chDF051 . Checked = _df . DF051;
            chDF052 . Checked = _df . DF052;
            chDF053 . Checked = _df . DF053;
            chDF054 . Checked = _df . DF054;
            chDF055 . Checked = _df . DF055;
            chDF056 . Checked = _df . DF056;
            chDF057 . Checked = _df . DF057;
            chDF058 . Checked = _df . DF058;
            chDF059 . Checked = _df . DF059;
            chDF060 . Checked = _df . DF060;
            chDF061 . Checked = _df . DF061;
            chDF062 . Checked = _df . DF062;
            chDF063 . Checked = _df . DF063;
            chDF064 . Checked = _df . DF064;
            chDF065 . Checked = _df . DF065;
            chDF066 . Checked = _df . DF066;
            chDF067 . Checked = _df . DF067;
            chDF068 . Checked = _df . DF068;
            chDF069 . Checked = _df . DF069;
        }
        void getValue ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            //gridView2 . CloseEditor ( );
            //gridView2 . UpdateCurrentRow ( );

            _df . idx = txtDF003 . Tag == null ? 0 : Convert . ToInt32 ( txtDF003 . Tag . ToString ( ) );
            _df . DF002 = secDF002 . Text;
            _df . DF003 = txtDF003 . Text;
            _df . DF004 = txtDF004 . Text;
            _df . DF005 = string . IsNullOrEmpty ( txtDF005 . Text ) == true ? 0 : Convert . ToInt32 ( txtDF005 . Text );
            if ( !string . IsNullOrEmpty ( txtDF006 . Text ) )
                _df . DF006 = Convert . ToDateTime ( txtDF006 . Text );
            _df . DF007 = string . IsNullOrEmpty ( txtDF007 . Text ) == true ? 0 : Convert . ToInt32 ( txtDF007 . Text );
            _df . DF008 = cmbDF008 . Text;
            _df . DF009 = cmbDF009 . Text;
            _df . DF010 = cmbDF010 . Text;
            _df . DF011 = chDF011 . Checked;
            _df . DF012 = chDF012 . Checked;
            _df . DF013 = chDF013 . Checked;
            _df . DF014 = chDF014 . Checked;
            _df . DF015 = chDF015 . Checked;
            _df . DF016 = chDF016 . Checked;
            _df . DF017 = chDF017 . Checked;
            _df . DF018 = chDF018 . Checked;
            _df . DF019 = chDF019 . Checked;
            _df . DF020 = chDF020 . Checked;
            _df . DF021 = chDF021 . Checked;
            _df . DF022 = chDF022 . Checked;
            _df . DF023 = chDF023 . Checked;
            _df . DF024 = chDF024 . Checked;
            _df . DF025 = chDF025 . Checked;
            _df . DF026 = chDF026 . Checked;
            _df . DF027 = chDF027 . Checked;
            _df . DF028 = chDF028 . Checked;
            _df . DF029 = chDF029 . Checked;
            _df . DF030 = chDF030 . Checked;
            _df . DF031 = chDF031 . Checked;
            _df . DF032 = chDF032 . Checked;
            _df . DF033 = chDF033 . Checked;
            _df . DF034 = chDF034 . Checked;
            _df . DF035 = chDF035 . Checked;
            _df . DF036 = chDF036 . Checked;
            _df . DF037 = chDF037 . Checked;
            _df . DF038 = chDF038 . Checked;
            _df . DF039 = chDF039 . Checked;
            _df . DF040 = chDF040 . Checked;
            _df . DF041 = chDF041 . Checked;
            _df . DF042 = chDF042 . Checked;
            _df . DF043 = chDF043 . Checked;
            _df . DF044 = chDF044 . Checked;
            _df . DF045 = chDF045 . Checked;
            _df . DF046 = chDF046 . Checked;
            _df . DF047 = chDF047 . Checked;
            _df . DF048 = chDF048 . Checked;
            _df . DF049 = chDF049 . Checked;
            _df . DF050 = chDF050 . Checked;
            _df . DF051 = chDF051 . Checked;
            _df . DF052 = chDF052 . Checked;
            _df . DF053 = chDF053 . Checked;
            _df . DF054 = chDF054 . Checked;
            _df . DF055 = chDF055 . Checked;
            _df . DF056 = chDF056 . Checked;
            _df . DF057 = chDF057 . Checked;
            _df . DF058 = chDF058 . Checked;
            _df . DF059 = chDF059 . Checked;
            _df . DF060 = chDF060 . Checked;
            _df . DF061 = chDF061 . Checked;
            _df . DF062 = chDF062 . Checked;
            _df . DF063 = chDF063 . Checked;
            _df . DF064 = chDF064 . Checked;
            _df . DF065 = chDF065 . Checked;
            _df . DF066 = chDF066 . Checked;
            _df . DF067 = chDF067 . Checked;
            _df . DF068 = chDF068 . Checked;
            _df . DF069 = chDF069 . Checked;
        }
        #endregion

    }
}
