using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormFeedTest :FormChild
    {
        MulaolaoLibrary.FeedTestCNEntity _cn=null;
        MulaolaoLibrary.FeedTestCOEntity _co=null;
        List<MulaolaoLibrary.FeedTestCPEntity> ModelCp=new List<MulaolaoLibrary.FeedTestCPEntity>();
        MulaolaoBll.Bll.FeedTestBll _bll=null;
        DataTable tableView,printOne,printTwo;string state=string.Empty;bool result=false;
        List<string> strList=new List<string>();
        
        public FormFeedTest ( )
        {
            InitializeComponent ( );

            _cn = new MulaolaoLibrary . FeedTestCNEntity ( );
            _co = new MulaolaoLibrary . FeedTestCOEntity ( );
            _bll = new MulaolaoBll . Bll . FeedTestBll ( );
            tableView = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            lupSup . Properties . DataSource = _bll . getSupplier ( );
            lupSup . Properties . DisplayMember = "DGA003";
            lupSup . Properties . ValueMember = "DGA001";

            secPro . Properties . DataSource = _bll . getProductInfo ( );
            secPro . Properties . DisplayMember = "PQF04";
            secPro . Properties . ValueMember = "PQF01";

        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . FeedTestAll from = new SelectAll . FeedTestAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _cn . CN001 = _co . CO001 = from . getOddNum;
                if ( from . getZX . Equals ( "执行" ) )
                    labZX . Visible = true;
                else
                    labZX . Visible = false;
                setValue ( );

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolLibrary . Enabled = toolStorage . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            state = "add";
            _cn . CN001 = _co . CO001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getView ( "1=2" );
            gridControl1 . DataSource = tableView;
            txtIQC . Text = Logins . username;
            txtCri . Text = "0.1";
            txtCriYes . Text = "0";
            txtCriNo . Text = "1";
            txtGrave . Text = "1.5";
            txtSin . Text = "2.5";

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
            result = _bll . Delete ( _cn . CN001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( lupSup . Text ) )
            {
                MessageBox . Show ( "供应商不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtNum . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }
            getValue ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            if ( state . Equals ( "add" ) )
                result = _bll . Save ( tableView ,_cn ,ModelCp );
            else
                result = _bll . Edit ( tableView ,_cn ,ModelCp ,strList );

            if ( result )
            {
                MessageBox . Show ( "成功保存" );
                strList . Clear ( );
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
            getPrintTable ( );

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_044.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "CN001" ,_cn . CN001 ,"R_PQCN" ,this ,"" ,"R_044" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_044" ,_cn . CN001 );

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
            lupSup . Enabled = secPro . Enabled = dtOne . Enabled = dtTwo . Enabled = dtTre . Enabled = txtQC . Enabled = resuYes . Enabled = resuNo . Enabled = rioNo . Enabled = radYes . Enabled = memoRemark . Enabled = labZX . Visible = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        void Enable ( )
        {
            lupSup . Enabled = secPro . Enabled = dtOne . Enabled = dtTwo . Enabled = dtTre . Enabled = txtQC . Enabled = resuYes . Enabled = resuNo . Enabled = rioNo . Enabled = radYes . Enabled = memoRemark . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            lupSup . EditValue = secPro . EditValue = null;
            dtOne . Value = dtTwo . Value = dtTre . Value = MulaolaoBll . Drity . GetDt ( );
            txtQC . Text = memoRemark . Text = txtCri . Text = txtCriNo . Text = txtCriResu . Text = txtCriYes . Text = txtGraNo . Text = txtGraResu . Text = txtGrave . Text = txtGraYes . Text = txtIQC . Text = txtNo . Text = txtNum . Text =txtProNum . Text = txtQC . Text = txtSin . Text = txtSinNo . Text = txtSinResu . Text = txtSinYes . Text = string . Empty;
            resuYes . Checked = resuNo . Checked = rioNo . Checked = radYes . Checked = false;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void setValue ( )
        {
            tableView = _bll . getView ( " CO001='" + _cn . CN001 + "'" );
            gridControl1 . DataSource = tableView;
            if ( gridView1 . DataRowCount > 0 )
            {
                _co . CO002 = gridView1 . GetDataRow ( 0 ) [ "CO002" ] . ToString ( );
                _co . CO003 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( 0 ) [ "CO003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( 0 ) [ "CO003" ] . ToString ( ) );
            }
            _cn = _bll . getModel ( _cn . CN001 );
            setValueHead ( );
        }
        void setValueHead ( )
        {
            lupSup . EditValue = _cn . CN002;
            secPro . EditValue = _cn . CN005;
            txtNo . Text = _cn . CN004;
            txtNum . Text = _cn . CN005;
            txtProNum . Text = _cn . CN006 . ToString ( );
            dtOne . Value = _cn . CN007;
            dtTwo . Value = _cn . CN008;
            //txtPart . Text = _cn . CN009;
            txtIQC . Text = _cn . CN012;
            //txtBJ . Text = _cn . CN013 . ToString ( );
            txtQC . Text = _cn . CN014;
            dtTre . Value = _cn . CN011;
            txtCri . Text = _cn . CN015 . ToString ( );
            txtCriNo . Text = _cn . CN017 . ToString ( );
            txtCriYes . Text = _cn . CN016 . ToString ( );
            txtCriResu . Text = _cn . CN018 . ToString ( );
            txtGrave . Text = _cn . CN019 . ToString ( );
            txtGraYes . Text = _cn . CN020 . ToString ( );
            txtGraNo . Text = _cn . CN021 . ToString ( );
            txtGraResu . Text = _cn . CN022 . ToString ( );
            txtSin . Text = _cn . CN023 . ToString ( );
            txtSinYes . Text = _cn . CN024 . ToString ( );
            txtSinNo . Text = _cn . CN025 . ToString ( );
            txtSinResu . Text = _cn . CN026 . ToString ( );
            resuYes . Checked = _cn . CN027;
            resuNo . Checked = _cn . CN030;
            radYes . Checked = _cn . CN028;
            rioNo . Checked = _cn . CN031;
            memoRemark . Text = _cn . CN029;
        }
        void getValue ( )
        {
            txtCriResu . Text = CO007 . SummaryItem . SummaryValue . ToString ( );
            txtGraResu . Text = CO008 . SummaryItem . SummaryValue . ToString ( );
            txtSinResu . Text = CO009 . SummaryItem . SummaryValue . ToString ( );
            _cn . CN002 = lupSup . EditValue . ToString ( );
            _cn . CN003 = secPro . Text;
            _cn . CN004 = txtNo . Text;
            _cn . CN005 = txtNum . Text;
            _cn . CN006 = string . IsNullOrEmpty ( txtProNum . Text ) == true ? 0 : Convert . ToInt32 ( txtProNum . Text );
            _cn . CN007 = dtOne . Value;
            _cn . CN008 = dtTwo . Value;
            //_cn . CN009 = txtPart . Text;
            _cn . CN012 = txtIQC . Text;
            //_cn . CN013 = string . IsNullOrEmpty ( txtBJ . Text ) == true ? 0 : Convert . ToInt32 ( txtBJ . Text );
            _cn . CN014 = txtQC . Text;
            _cn . CN011 = dtTre . Value;
            _cn . CN015 = string . IsNullOrEmpty ( txtCri . Text ) == true ? 0 : Convert . ToDecimal ( txtCri . Text );
            _cn . CN016 = string . IsNullOrEmpty ( txtCriYes . Text ) == true ? 0 : Convert . ToInt32 ( txtCriYes . Text );
            _cn . CN017 = string . IsNullOrEmpty ( txtCriNo . Text ) == true ? 0 : Convert . ToInt32 ( txtCriNo . Text );
            _cn . CN018 = string . IsNullOrEmpty ( txtCriResu . Text ) == true ? 0 : Convert . ToInt32 ( txtCriResu . Text );
            _cn . CN019 = string . IsNullOrEmpty ( txtGrave . Text ) == true ? 0 : Convert . ToDecimal ( txtGrave . Text );
            _cn . CN020 = string . IsNullOrEmpty ( txtGraYes . Text ) == true ? 0 : Convert . ToInt32 ( txtGraYes . Text );
            _cn . CN021 = string . IsNullOrEmpty ( txtGraNo . Text ) == true ? 0 : Convert . ToInt32 ( txtGraNo . Text );
            _cn . CN022 = string . IsNullOrEmpty ( txtGraResu . Text ) == true ? 0 : Convert . ToInt32 ( txtGraResu . Text );
            _cn . CN023 = string . IsNullOrEmpty ( txtSin . Text ) == true ? 0 : Convert . ToDecimal ( txtSin . Text );
            _cn . CN024 = string . IsNullOrEmpty ( txtSinYes . Text ) == true ? 0 : Convert . ToInt32 ( txtSinYes . Text );
            _cn . CN025 = string . IsNullOrEmpty ( txtSinNo . Text ) == true ? 0 : Convert . ToInt32 ( txtSinNo . Text );
            _cn . CN026 = string . IsNullOrEmpty ( txtSinResu . Text ) == true ? 0 : Convert . ToInt32 ( txtSinResu . Text );
            _cn . CN027 = resuYes . Checked == true ? true : false;
            _cn . CN030 = resuNo . Checked == true ? true : false;
            _cn . CN028 = radYes . Checked == true ? true : false;
            _cn . CN031 = rioNo . Checked == true ? true : false;
            _cn . CN029 = memoRemark . Text;
        }
        void getPrintTable ( )
        {
            printOne = _bll . getPrintOne ( _cn . CN001 );
            printOne . TableName = "R_PQCN";
            printTwo = _bll . getPrintTwo ( _cn . CN001 );
            printTwo . TableName = "R_PQCO";
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
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CO010" ] ,view . DataRowCount + 1 );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CO011" ] ,_co . CO011 );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CO002" ] ,_co . CO002 );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CO003" ] ,_co . CO003 );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "CO004" ] ,_co . CO004 );
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = gridView1 . ActiveEditor;
            switch ( gridView1 . FocusedColumn . FieldName )
            {
                case "CO007":
                txtCriResu . Text = CO007 . SummaryItem . SummaryValue . ToString ( );
                break;
                case "CO008":
                txtGraResu . Text = CO008 . SummaryItem . SummaryValue . ToString ( );
                break;
                case "CO009":
                txtSinResu . Text = CO009 . SummaryItem . SummaryValue . ToString ( );
                break;
                case "CO003":
                if ( edit . Text != null )
                {
                    DataTable dt = _bll . getSam ( _co . CO003 );
                    if ( dt != null && dt . Rows . Count > 0 )
                    {
                        _co . CO004 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CL003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "CL003" ] . ToString ( ) );
                        //gridView1 . SetRowCellValue ( e . RowHandle ,gridView1 . Columns [ "CO004" ] ,dt . Rows [ 0 ] [ "CL003" ] . ToString ( ) );
                        txtGraYes . Text = dt . Rows [ 0 ] [ "CL004" ] . ToString ( );
                        txtGraNo . Text = dt . Rows [ 0 ] [ "CL005" ] . ToString ( );
                        txtSinYes . Text = dt . Rows [ 0 ] [ "CL006" ] . ToString ( );
                        txtSinNo . Text = dt . Rows [ 0 ] [ "CL007" ] . ToString ( );
                    }
                }
                txtCriResu . Text = CO007 . SummaryItem . SummaryValue . ToString ( );
                txtGraResu . Text = CO008 . SummaryItem . SummaryValue . ToString ( );
                txtSinResu . Text = CO009 . SummaryItem . SummaryValue . ToString ( );
                break;            
            }
        }
        private void secPro_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtNo . Text = row [ "PQF03" ] . ToString ( );
                txtNum . Text = row [ "PQF01" ] . ToString ( );
                txtProNum . Text = row [ "PQF06" ] . ToString ( );
            }
            if ( this . Text == string . Empty )
                txtNo . Text = txtNum . Text = txtProNum . Text = string . Empty;
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                strList . Add ( row [ "idx" ] . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void gridView1_RowCellClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowCellClickEventArgs e )
        {
            if ( e . Column . FieldName == "CO011" )
            {
                if ( string . IsNullOrEmpty ( txtNum . Text ) )
                {
                    MessageBox . Show ( "请选择流水号" );
                    return;
                }
                SelectAll . FeedTestPartAll from = new SelectAll . FeedTestPartAll ( "零部件查询" ,txtNum . Text ,_cn . CN001 );
                if ( from . ShowDialog ( ) == DialogResult . OK )
                {
                    _co . CO011 = _co . CO002 = string . Empty;
                    _co . CO003 = 0;
                    ModelCp = from . getModel;
                    if ( ModelCp != null )
                    {
                        decimal dOne = 0;
                        foreach ( MulaolaoLibrary . FeedTestCPEntity cp in ModelCp )
                        {
                            if ( string . IsNullOrEmpty ( _co . CO011 ) )
                                _co . CO011 = cp . CP003;
                            else
                                _co . CO011 = _co . CO011 + " | " + cp . CP003;
                            dOne += cp . CP005;
                            if ( string . IsNullOrEmpty ( _co . CO002 ) )
                                _co . CO002 = cp . CP004;
                            else
                                _co . CO002 = _co . CO002 + " | " + cp . CP004;
                        }
                        //txtBJ . Text = Math . Round ( dOne ,0 ) . ToString ( );
                        _co . CO003 = string . IsNullOrEmpty ( txtProNum . Text ) == true ? 0 : ( Int32 ) Math . Round ( Convert . ToInt32 ( txtProNum . Text ) * dOne ,0 );
                        gridView1 . SetRowCellValue ( e . RowHandle ,"CO011" ,_co . CO011 );
                        gridView1 . SetRowCellValue ( e . RowHandle ,"CO002" ,_co . CO002 );
                        gridView1 . SetRowCellValue ( e . RowHandle ,"CO003" ,_co . CO003 );
                    }
                }
            }
        }
        #endregion

    }
}
