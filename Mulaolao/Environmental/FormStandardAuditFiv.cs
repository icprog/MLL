using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardAuditFiv :FormChild
    {
        MulaolaoLibrary.StandardAuditFivCJEntity _cj=null;
        MulaolaoLibrary.StandardAuditFivCKEntity _ck=null;
        MulaolaoBll.Bll.StandardAuditFivBll _bll=null;
        DataTable tableView,printOne,printTwo; string state=string.Empty; bool result=false;
        List<string> strList=new List<string>();

        public FormStandardAuditFiv ( )
        {
            InitializeComponent ( );

            _cj = new MulaolaoLibrary . StandardAuditFivCJEntity ( );
            _ck = new MulaolaoLibrary . StandardAuditFivCKEntity ( );
            _bll = new MulaolaoBll . Bll . StandardAuditFivBll ( );
            tableView = new DataTable ( );
            printOne = new DataTable ( );
            printTwo = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1   } );
            Power ( this );
            UnEnable ( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            secPro . Properties . DataSource = _bll . getProInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

            DataTable dt = _bll . getUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                DataTable da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ007" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserOne . Properties . Items . Add ( da . Rows [ i ] [ "CJ007" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ008" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTwo . Properties . Items . Add ( da . Rows [ i ] [ "CJ008" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ009" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTre . Properties . Items . Add ( da . Rows [ i ] [ "CJ009" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ010" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserFor . Properties . Items . Add ( da . Rows [ i ] [ "CJ010" ] . ToString ( ) );
                }
            }
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . StandardAuditFivAll from = new SelectAll . StandardAuditFivAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _cj . CJ001 = _ck . CK001 = from . getOddNum;
                getData ( );
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
            _cj . CJ001 = _ck . CK001 = _bll . getOddNum ( );
            Enable ( );
            Clear ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getView ( "1=2" );
            gridControl1 . DataSource = tableView;

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
            result = _bll . Delete ( _cj . CJ001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( secPro . Text ) )
            {
                MessageBox . Show ( "产品名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbUserTre . Text ) )
            {
                MessageBox . Show ( "报审人不可为空" );
                return;
            }

            getValue ( );

            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );
            if ( tableView == null || tableView . Rows . Count < 1 )
                return;

            if ( state . Equals ( "add" ) )
                result = _bll . Save ( tableView ,_cj ,Logins . username );
            else
                result = _bll . Edit ( tableView ,_cj ,Logins . username ,strList );

            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                strList . Clear ( );
                UnEnable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

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
            getTablePrint ( );

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_489.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CJ001" ,_cj . CJ001 ,"R_PQCJ" ,this ,"" ,"R_489" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_489" ,_cj . CJ001 );

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
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void bandedGridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK007" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK008" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK009" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK010" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK011" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK012" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CK022" ] ,"①②③" );
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                strList . Add ( row [ "idx" ] . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit1_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ck . CK013 = row [ "CK013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ck . CK013 ) )
                {
                    row [ "CK013" ] = Logins . username;
                    row [ "CK014" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ck . CK013 . Equals ( Logins . username ) )
                {
                    row [ "CK013" ] = string . Empty;
                    row [ "CK014" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ck . CK015 = row [ "CK015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ck . CK015 ) )
                {
                    row [ "CK015" ] = Logins . username;
                    row [ "CK016" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ck . CK015 . Equals ( Logins . username ) )
                {
                    row [ "CK015" ] = string . Empty;
                    row [ "CK016" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ck . CK017 = row [ "CK017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ck . CK017 ) )
                {
                    row [ "CK017" ] = Logins . username;
                    row [ "CK018" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ck . CK017 . Equals ( Logins . username ) )
                {
                    row [ "CK017" ] = string . Empty;
                    row [ "CK018" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void secPro_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtNum . Text = row [ "PQF01" ] . ToString ( );
                txtNo . Text = row [ "PQF03" ] . ToString ( );
                txtNumer . Text = row [ "PQF06" ] . ToString ( );
            }
            if ( string . IsNullOrEmpty ( secPro . Text ) )
                txtNum . Text = txtNo . Text = txtNumer . Text = string . Empty;
        }
        private void txtNum_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( txtNum . Text ) )
            {
                DataTable dt = _bll . getPart ( txtNum . Text );
                lupPart . DataSource = dt;
                lupPart . DisplayMember = "GS07";
                lupPart . ValueMember = "GS07";
            }
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secPro . Enabled = txtColor . Enabled = cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled =labZX.Visible= false;
            bandedGridView1 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            secPro . Enabled = txtColor . Enabled = cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled = true;
            bandedGridView1 . OptionsBehavior . Editable = true;
        }
        void Clear ( )
        {
            secPro . Text = txtColor . Text = cmbUserOne . Text = cmbUserTwo . Text = cmbUserTre . Text = cmbUserFor . Text = string . Empty;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void getValue ( )
        {
            _cj . CJ002 = txtNum . Text;
            _cj . CJ003 = secPro . Text;
            _cj . CJ004 = txtNo . Text;
            _cj . CJ005 = string . IsNullOrEmpty ( txtNumer . Text ) == true ? 0 : Convert . ToInt32 ( txtNumer . Text );
            _cj . CJ006 = txtColor . Text;
            _cj . CJ007 = cmbUserOne . Text;
            _cj . CJ008 = cmbUserTwo . Text;
            _cj . CJ009 = cmbUserTre . Text;
            _cj . CJ010 = cmbUserFor . Text;
        }
        void getData ( )
        {
            _cj = _bll . getModel ( _cj . CJ001 );
            secPro . EditValue = _cj . CJ002;
            txtNum . Text = _cj . CJ002;
            txtNo . Text = _cj . CJ004;
            txtNumer . Text = _cj . CJ005 . ToString ( );
            txtColor . Text = _cj . CJ006;
            cmbUserOne . Text = _cj . CJ007;
            cmbUserTwo . Text = _cj . CJ008;
            cmbUserTre . Text = _cj . CJ009;
            cmbUserFor . Text = _cj . CJ010;
            tableView = _bll . getView ( " CK001='" + _cj . CJ001 + "'" );
            gridControl1 . DataSource = tableView;
        }
        void getTablePrint ( )
        {
            printOne = _bll . getTablePrintOne ( _cj . CJ001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . getTablePrintTwo ( _cj . CJ001 );
            printTwo . TableName = "TableTwo";
        }
        #endregion

    }
}
