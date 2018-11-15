using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardAuditOne :FormChild
    {
        MulaolaoLibrary.StandardAuditOneCBEntity _cb=null;
        MulaolaoLibrary.StandardAuditOneCCEntity _cc=null;
        MulaolaoBll.Bll.StandardAuditOneBll _bll=null;
        DataTable tableView,printOne,printTwo;string state=string.Empty;bool result=false;
        List<string> strList=new List<string>();
        
        public FormStandardAuditOne ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            _cb = new MulaolaoLibrary . StandardAuditOneCBEntity ( );
            _cc = new MulaolaoLibrary . StandardAuditOneCCEntity ( );
            _bll = new MulaolaoBll . Bll . StandardAuditOneBll ( );
            tableView = new DataTable ( );
            printOne = new DataTable ( );
            printTwo = new DataTable ( );

            Power ( this );
            UnEnable ( );

            secPro . Properties . DataSource = _bll . getProInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

            DataTable dt = _bll . getUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                DataTable da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB007" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserOne . Properties . Items . Add ( da . Rows [ i ] [ "CB007" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB008" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTwo . Properties . Items . Add ( da . Rows [ i ] [ "CB008" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB009" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTre . Properties . Items . Add ( da . Rows [ i ] [ "CB009" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB010" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserFor . Properties . Items . Add ( da . Rows [ i ] [ "CB010" ] . ToString ( ) );
                }
            }
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . StandardAuditOneAll from = new SelectAll . StandardAuditOneAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _cb . CB001 = _cc . CC001 = from . getOddNum;
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
            _cc . CC001 = _cb . CB001 = _bll . getOddNum ( );
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
                result = _bll . Save ( tableView ,_cb ,Logins . username );
            else
                result = _bll . Edit ( tableView ,_cb ,Logins . username ,strList );

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
            result = _bll . Delete ( _cb . CB001 ,Logins . username );
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
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_482.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CB001" ,_cb . CB001 ,"R_PQCB" ,this ,"" ,"R_482" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_482" ,_cb . CB001 );

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
        private void secPro_EditValueChanged ( object sender ,System . EventArgs e )
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
        private void txtNum_TextChanged ( object sender ,System . EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( txtNum . Text ) )
            {
                DataTable dt = _bll . getPart ( txtNum . Text );
                lupPart . DataSource = dt;
                lupPart . DisplayMember = "GS07";
                lupPart . ValueMember = "GS07";
            }
        }
        private void repositoryItemButtonEdit1_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cc . CC013 = row [ "CC013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cc . CC013 ) )
                {
                    row [ "CC013" ] = Logins . username;
                    row [ "CC014" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cc . CC013 . Equals ( Logins . username ) )
                {
                    row [ "CC013" ] = string . Empty;
                    row [ "CC014" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cc . CC015 = row [ "CC015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cc . CC015 ) )
                {
                    row [ "CC015" ] = Logins . username;
                    row [ "CC016" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cc . CC015 . Equals ( Logins . username ) )
                {
                    row [ "CC015" ] = string . Empty;
                    row [ "CC016" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cc . CC017 = row [ "CC017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cc . CC017 ) )
                {
                    row [ "CC017" ] = Logins . username;
                    row [ "CC018" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cc . CC017 . Equals ( Logins . username ) )
                {
                    row [ "CC017" ] = string . Empty;
                    row [ "CC018" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit4_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _cc . CC019 = row [ "CC019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _cc . CC019 ) )
                {
                    row [ "CC019" ] = Logins . username;
                    row [ "CC020" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _cc . CC019 . Equals ( Logins . username ) )
                {
                    row [ "CC019" ] = string . Empty;
                    row [ "CC020" ] = DBNull . Value;
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
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC007" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC008" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC009" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC010" ] ,"①" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC011" ] ,"③④" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CC012" ] ,"②" );
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            secPro . Enabled = txtColor . Enabled = cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled = false;
            bandedGridView1 . OptionsBehavior . Editable = false;
            labZX . Visible = false;
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
            _cb . CB002 = txtNum . Text;
            _cb . CB003 = secPro . Text;
            _cb . CB004 = txtNo . Text;
            _cb . CB005 = string . IsNullOrEmpty ( txtNumer . Text ) == true ? 0 : Convert . ToInt32 ( txtNumer . Text );
            _cb . CB006 = txtColor . Text;
            _cb . CB007 = cmbUserOne . Text;
            _cb . CB008 = cmbUserTwo . Text;
            _cb . CB009 = cmbUserTre . Text;
            _cb . CB010 = cmbUserFor . Text;
        }
        void getData ( )
        {
            _cb = _bll . getModel ( _cb . CB001 );
            secPro . EditValue = _cb . CB002;
            txtNum . Text = _cb . CB002;
            txtNo . Text = _cb . CB004;
            txtNumer . Text = _cb . CB005 . ToString ( );
            txtColor . Text = _cb . CB006;
            cmbUserOne . Text = _cb . CB007;
            cmbUserTwo . Text = _cb . CB008;
            cmbUserTre . Text = _cb . CB009;
            cmbUserFor . Text = _cb . CB010;
            tableView = _bll . getView ( " CC001='" + _cb . CB001 + "'" );
            gridControl1 . DataSource = tableView;
        }
        void getPrintTable ( )
        {           
            printOne = _bll . getPrintOne ( _cb . CB001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . getPrintTwo ( _cb . CB001 );
            printTwo . TableName = "TableTwo";
        }
        #endregion

    }
}
