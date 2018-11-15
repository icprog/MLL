using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormStandardAuditFor :FormChild
    {
        MulaolaoLibrary.StandardAuditForCHEntity _ch=null;
        MulaolaoLibrary.StandardAuditForCIEntity _ci=null;
        MulaolaoBll.Bll.StandardAuditForBll _bll=null;
        DataTable tableView,tablePro; string state=string.Empty; bool result=false;
        List<string> strList=new List<string>();
        DataTable printOne,printTwo;
        
        public FormStandardAuditFor ( )
        {
            InitializeComponent ( );

            _ch = new MulaolaoLibrary . StandardAuditForCHEntity ( );
            _ci = new MulaolaoLibrary . StandardAuditForCIEntity ( );
            _bll = new MulaolaoBll . Bll . StandardAuditForBll ( );
            tableView = new DataTable ( );
            tablePro = new DataTable ( );
            printOne = new DataTable ( );
            printTwo = new DataTable ( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            GridViewMoHuSelect . SetFilter ( resPro );
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            Power ( this );
            UnEnable ( );

            tablePro = _bll . getPro ( );
            lupPro . DataSource = tablePro;
            lupPro . DisplayMember = "CI012";
            lupPro . ValueMember = "CI012";

            DataTable dt = _bll . getUser ( );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                DataTable da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH003" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserOne . Properties . Items . Add ( da . Rows [ i ] [ "CH003" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH004" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTwo . Properties . Items . Add ( da . Rows [ i ] [ "CH004" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH005" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserTre . Properties . Items . Add ( da . Rows [ i ] [ "CH005" ] . ToString ( ) );
                }
                da = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH006" );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    cmbUserFor . Properties . Items . Add ( da . Rows [ i ] [ "CH006" ] . ToString ( ) );
                }
            }

        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . StandardAuditForAll from = new SelectAll . StandardAuditForAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _ch . CH001 = _ci . CI001 = from . getOddNum;
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
            _ch . CH001 = _ci . CI001 = _bll . getOddNum ( );
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
            result = _bll . Delete ( _ch . CH001 ,Logins . username );
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
                result = _bll . Save ( tableView ,_ch ,Logins . username );
            else
                result = _bll . Edit ( tableView ,_ch ,Logins . username ,strList );

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
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_487.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CH001" ,_ch . CH001 ,"R_PQCH" ,this ,"" ,"R_487" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_487" ,_ch . CH001 );

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
        private void lupPro_EditValueChanged ( object sender ,System . EventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = bandedGridView1 . ActiveEditor;
            switch ( bandedGridView1 . FocusedColumn . FieldName )
            {
                case "CI012":
                if ( edit . EditValue != null )
                {
                    _ci . CI002 = tablePro . Select ( "CI012='" + edit . EditValue + "'" ) [ 0 ] [ "CI002" ] . ToString ( );
                    _ci . CI003 = tablePro . Select ( "CI012='" + edit . EditValue + "'" ) [ 0 ] [ "CI003" ] . ToString ( );
                    _ci . CI004 = tablePro . Select ( "CI012='" + edit . EditValue + "'" ) [ 0 ] [ "CI004" ] . ToString ( );
                    string sl = tablePro . Select ( "CI012='" + edit . EditValue + "'" ) [ 0 ] [ "CI019" ] . ToString ( );
                    bandedGridView1 . SetFocusedRowCellValue ( bandedGridView1 . Columns [ "CI002" ] ,_ci . CI002 );
                    bandedGridView1 . SetFocusedRowCellValue ( bandedGridView1 . Columns [ "CI003" ] ,_ci . CI003 );
                    bandedGridView1 . SetFocusedRowCellValue ( bandedGridView1 . Columns [ "CI004" ] ,_ci . CI004 );
                    bandedGridView1 . SetFocusedRowCellValue ( bandedGridView1 . Columns [ "CI019" ] ,sl );
                }
                break;
            }
        }
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void repositoryItemButtonEdit1_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ci . CI013 = row [ "CI013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ci . CI013 ) )
                {
                    row [ "CI013" ] = Logins . username;
                    row [ "CI014" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ci . CI013 . Equals ( Logins . username ) )
                {
                    row [ "CI013" ] = string . Empty;
                    row [ "CI014" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit2_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ci . CI015 = row [ "CI015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ci . CI015 ) )
                {
                    row [ "CI015" ] = Logins . username;
                    row [ "CI016" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ci . CI015 . Equals ( Logins . username ) )
                {
                    row [ "CI015" ] = string . Empty;
                    row [ "CI016" ] = DBNull . Value;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void repositoryItemButtonEdit3_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                _ci . CI017 = row [ "CI017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _ci . CI017 ) )
                {
                    row [ "CI017" ] = Logins . username;
                    row [ "CI018" ] = MulaolaoBll . Drity . GetDt ( );
                }
                else if ( _ci . CI017 . Equals ( Logins . username ) )
                {
                    row [ "CI017" ] = string . Empty;
                    row [ "CI018" ] = DBNull . Value;
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
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CI007" ] ,"①②" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CI008" ] ,"①②" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CI009" ] ,"①②" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CI010" ] ,"③" );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CI011" ] ,"③" );
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
             cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled =labZX.Visible= false;
            bandedGridView1 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
             cmbUserOne . Enabled = cmbUserTwo . Enabled = cmbUserTre . Enabled = cmbUserFor . Enabled = true;
            bandedGridView1 . OptionsBehavior . Editable = true;
        }
        void Clear ( )
        {
            cmbUserOne . Text = cmbUserTwo . Text = cmbUserTre . Text = cmbUserFor . Text = string . Empty;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void getValue ( )
        {
            //_ch . CH002 = txtColor . Text;
            _ch . CH003 = cmbUserOne . Text;
            _ch . CH004 = cmbUserTwo . Text;
            _ch . CH005 = cmbUserTre . Text;
            _ch . CH006 = cmbUserFor . Text;
        }
        void getData ( )
        {
            _ch = _bll . getModel ( _ch . CH001 );
            //txtColor . Text = _ch . CH002;
            cmbUserOne . Text = _ch . CH003;
            cmbUserTwo . Text = _ch . CH004;
            cmbUserTre . Text = _ch . CH005;
            cmbUserFor . Text = _ch . CH006;
            tableView = _bll . getView ( " CI001='" + _ch . CH001 + "'" );
            gridControl1 . DataSource = tableView;
        }
        void getPrintTable ( )
        {
            printOne = _bll . getPrintOne ( _ch . CH001 );
            printOne . TableName = "TableOne";
            printTwo = _bll . getPrintTwo ( _ch . CH001 );
            printTwo . TableName = "TableTwo";
        }
        #endregion

    }
}
