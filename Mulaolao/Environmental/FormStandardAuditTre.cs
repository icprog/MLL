using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardAuditTre :FormChild
    {
        MulaolaoLibrary.StandardAuditTreCFEntity _cf=null;
        MulaolaoLibrary.StandardAuditTreCGEntity _cg=null;
        MulaolaoBll.Bll. StandardAuditTreBll _bll=null;
        DataTable tableView; string state=string.Empty; bool result=false;
        List<string> strList=new List<string>();
        DataTable PrintOne,PrintTwo;
        
        public FormStandardAuditTre ( )
        {
            InitializeComponent ( );

            _cf = new MulaolaoLibrary . StandardAuditTreCFEntity ( );
            _cg = new MulaolaoLibrary . StandardAuditTreCGEntity ( );
            _bll = new MulaolaoBll . Bll . StandardAuditTreBll ( );
            tableView = new DataTable ( );
            PrintOne = new DataTable ( );
            PrintTwo = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1  } );
            Power ( this );
            UnEnable ( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            secPro . Properties . DataSource = _bll . getProInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

            DataTable dt = _bll . getUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                DataTable da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CF007" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserOne . Properties . Items . Add ( da . Rows [ i ] [ "CF007" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CF008" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTwo . Properties . Items . Add ( da . Rows [ i ] [ "CF008" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CF009" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTre . Properties . Items . Add ( da . Rows [ i ] [ "CF009" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CF010" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserFor . Properties . Items . Add ( da . Rows [ i ] [ "CF010" ] . ToString ( ) );
                }
            }

        }

        #region Main
        protected override void select ( )
        {
            SelectAll . StandardAuditTreAll from = new SelectAll . StandardAuditTreAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System.Windows.Forms.DialogResult.OK )
            {
                _cf . CF001 = _cg . CG001 = from . getOddNum;
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
            _cf . CF001 = _cg . CG001 = _bll . getOddNum ( );
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
            result = _bll . Delete ( _cf . CF001 ,Logins . username );
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
                result = _bll . Save ( tableView ,_cf ,Logins . username );
            else
                result = _bll . Edit ( tableView ,_cf ,Logins . username ,strList );

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
            getPrintTable ( );

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( PrintOne );
            RDataSet . Tables . Add ( PrintTwo );
            report . Load ( Application . StartupPath + "\\R_484.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CF001" ,_cf . CF001 ,"R_PQCF" ,this ,"" ,"R_484" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_484" ,_cf . CF001 );

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
        private void repositoryItemButtonEdit1_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cg . CG013 = row [ "CG013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cg . CG013 ) )
                {
                    row [ "CG013" ] = Logins . username;
                    row [ "CG014" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cg . CG013 . Equals ( Logins . username ) )
                {
                    row [ "CG013" ] = string . Empty;
                    row [ "CG014" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cg . CG015 = row [ "CG015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cg . CG015 ) )
                {
                    row [ "CG015" ] = Logins . username;
                    row [ "CG016" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cg . CG015 . Equals ( Logins . username ) )
                {
                    row [ "CG015" ] = string . Empty;
                    row [ "CG016" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cg . CG017 = row [ "CG017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cg . CG017 ) )
                {
                    row [ "CG017" ] = Logins . username;
                    row [ "CG018" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cg . CG017 . Equals ( Logins . username ) )
                {
                    row [ "CG017" ] = string . Empty;
                    row [ "CG018" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
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
        private void bandedGridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG007" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG008" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG009" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG010" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG011" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG012" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG019" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG020" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG022" ] ,"①②③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CG023" ] ,"①②③" );
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
            _cf . CF002 = txtNum . Text;
            _cf . CF003 = secPro . Text;
            _cf . CF004 = txtNo . Text;
            _cf . CF005 = string . IsNullOrEmpty ( txtNumer . Text ) == true ? 0 : Convert . ToInt32 ( txtNumer . Text );
            _cf . CF006 = txtColor . Text;
            _cf . CF007 = cmbUserOne . Text;
            _cf . CF008 = cmbUserTwo . Text;
            _cf . CF009 = cmbUserTre . Text;
            _cf . CF010 = cmbUserFor . Text;
        }
        void getData ( )
        {
            _cf = _bll . getModel ( _cf . CF001 );
            secPro . EditValue = _cf . CF002;
            txtNum . Text = _cf . CF002;
            txtNo . Text = _cf . CF004;
            txtNumer . Text = _cf . CF005 . ToString ( );
            txtColor . Text = _cf . CF006;
            cmbUserOne . Text = _cf . CF007;
            cmbUserTwo . Text = _cf . CF008;
            cmbUserTre . Text = _cf . CF009;
            cmbUserFor . Text = _cf . CF010;
            tableView = _bll . getView ( " CG001='" + _cf . CF001 + "'" );
            gridControl1 . DataSource = tableView;
        }
        void getPrintTable ( )
        {
            PrintOne = _bll . getPrintOne ( _cf . CF001 );
            PrintOne . TableName = "TableOne";
            PrintTwo = _bll . getPrintTwo ( _cf . CF001 );
            PrintTwo . TableName = "TableTwo";
        }
        #endregion

    }
}
