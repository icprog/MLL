using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardAuditTwo :FormChild
    {
        MulaolaoLibrary.StandardAuditTwoCDEntity _cd=null;
        MulaolaoLibrary.StandardAuditTwoCEEntity _ce=null;
        MulaolaoBll.Bll. StandardAuditTwoBll _bll=null;
        DataTable tableView;string state=string.Empty;bool result=false;
        List<string> strList=new List<string>();
        DataTable tablePrintOne,tablePrintTwo;
        
        public FormStandardAuditTwo ( )
        {
            InitializeComponent ( );

            _cd = new MulaolaoLibrary . StandardAuditTwoCDEntity ( );
            _ce = new MulaolaoLibrary . StandardAuditTwoCEEntity ( );
            _bll = new MulaolaoBll . Bll . StandardAuditTwoBll ( );
            tableView = new DataTable ( );
            tablePrintOne = new DataTable ( );
            tablePrintTwo = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            secPro . Properties . DataSource = _bll . getProInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

            DataTable dt = _bll . getUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                DataTable da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CD007" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserOne . Properties . Items . Add ( da . Rows [ i ] [ "CD007" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CD008" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTwo . Properties . Items . Add ( da . Rows [ i ] [ "CD008" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CD009" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTre . Properties . Items . Add ( da . Rows [ i ] [ "CD009" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CD010" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserFor . Properties . Items . Add ( da . Rows [ i ] [ "CD010" ] . ToString ( ) );
                }
            }

        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . StandardAuditTwoAll from = new SelectAll . StandardAuditTwoAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _cd . CD001 = _ce . CE001 = from . getOddNum;
                getData ( );

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
            _cd . CD001 = _ce . CE001 = _bll . getOddNum ( );
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
                result = _bll . Save ( tableView ,_cd ,Logins . username );
            else
                result = _bll . Edit ( tableView ,_cd ,Logins . username ,strList );

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
            result = _bll . Delete ( _cd . CD001 ,Logins . username );
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
        protected override void export ( )
        {
            getPrintTable ( );

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( tablePrintOne );
            RDataSet . Tables . Add ( tablePrintTwo );
            report . Load ( Application . StartupPath + "\\R_483.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CD001" ,_cd . CD001 ,"R_PQCD" ,this ,"" ,"R_483" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_483" ,_cd . CD001 );

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
                _ce . CE013 = row [ "CE013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ce . CE013 ) )
                {
                    row [ "CE013" ] = Logins . username;
                    row [ "CE014" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ce . CE013 . Equals ( Logins . username ) )
                {
                    row [ "CE013" ] = string . Empty;
                    row [ "CE014" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ce . CE015 = row [ "CE015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ce . CE015 ) )
                {
                    row [ "CE015" ] = Logins . username;
                    row [ "CE016" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ce . CE015 . Equals ( Logins . username ) )
                {
                    row [ "CE015" ] = string . Empty;
                    row [ "CE016" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ce . CE017 = row [ "CE017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ce . CE017 ) )
                {
                    row [ "CE017" ] = Logins . username;
                    row [ "CE018" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ce . CE017 . Equals ( Logins . username ) )
                {
                    row [ "CE017" ] = string . Empty;
                    row [ "CE018" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit4_Click ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ce . CE019 = row [ "CE019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ce . CE019 ) )
                {
                    row [ "CE019" ] = Logins . username;
                    row [ "CE020" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ce . CE019 . Equals ( Logins . username ) )
                {
                    row [ "CE019" ] = string . Empty;
                    row [ "CE020" ] = DBNull . Value;
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
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE007" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE008" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE009" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE010" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE011" ] ,"①④" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE012" ] ,"④" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE022" ] ,"②" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CE023" ] ,"③" );
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secPro . Enabled = txtColor . Enabled = cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled = false;
            bandedGridView1 . OptionsBehavior . Editable = labZX . Visible = false;
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
            _cd . CD002 = txtNum . Text;
            _cd . CD003 = secPro . Text;
            _cd . CD004 = txtNo . Text;
            _cd . CD005 = string . IsNullOrEmpty ( txtNumer . Text ) == true ? 0 : Convert . ToInt32 ( txtNumer . Text );
            _cd . CD006 = txtColor . Text;
            _cd . CD007 = cmbUserOne . Text;
            _cd . CD008 = cmbUserTwo . Text;
            _cd . CD009 = cmbUserTre . Text;
            _cd . CD010 = cmbUserFor . Text;
        }
        void getData ( )
        {
            _cd = _bll . getModel ( _cd . CD001 );
            secPro . EditValue = _cd . CD002;
            txtNum . Text = _cd . CD002;
            txtNo . Text = _cd . CD004;
            txtNumer . Text = _cd . CD005 . ToString ( );
            txtColor . Text = _cd . CD006;
            cmbUserOne . Text = _cd . CD007;
            cmbUserTwo . Text = _cd . CD008;
            cmbUserTre . Text = _cd . CD009;
            cmbUserFor . Text = _cd . CD010;
            tableView = _bll . getView ( " CE001='" + _cd . CD001 + "'" );
            gridControl1 . DataSource = tableView;
        }
        void getPrintTable ( )
        {
            tablePrintOne = _bll . getPrintTableOne ( _cd . CD001 );
            tablePrintOne . TableName = "TableOne";
            tablePrintTwo = _bll . getPrintTableTwo ( _cd . CD001 );
            tablePrintTwo . TableName = "TableTwo";
        }
        #endregion

    }
}
