using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormQualityFinalInspsction :FormChild
    {
        MulaolaoLibrary.QualityFinalInspsctionDIEntity _di=null;
        MulaolaoLibrary.QualityFinalInspsctionDJEntity _dj=null;
        MulaolaoBll.Bll.QualityFinalInspsctionBll _bll=null;
        DataTable tableView,printOne,printTwo;
        string state=string.Empty;
        bool result=false;
        List<string> bodyList=new List<string>();
        
        public FormQualityFinalInspsction ( )
        { 
            InitializeComponent ( );

            _di = new MulaolaoLibrary . QualityFinalInspsctionDIEntity ( );
            _dj = new MulaolaoLibrary . QualityFinalInspsctionDJEntity ( );
            _bll = new MulaolaoBll . Bll . QualityFinalInspsctionBll ( );
            tableView = new DataTable ( );

            GridViewMoHuSelect . SetFilter ( secView );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            Power ( this );
            UnEnable ( );

            secDI003 . Properties . DataSource = _bll . getSupplier ( );
            secDI003 . Properties . DisplayMember = "PQF04";
            secDI003 . Properties . ValueMember = "PQF01";

        }
        
        #region Main
        protected override void select ( )
        { 
            SelectAll . QualityFinalInspsctionAll from = new SelectAll . QualityFinalInspsctionAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                _di . DI001 = _dj . DJ001 = from . getOddNum;
                setValue ( );

                if ( from . getZX . Equals ( "执行" ) )
                    labZX . Visible = true;
                else
                    labZX . Visible = false;

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolLibrary . Enabled = toolStorage . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
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
        protected override void add ( )
        {
            state = "add";
            _di . DI001 = _dj . DJ001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            txtDI002 . Tag = null;
            setValue ( );
            txtDI024 . Text = "0.1";
            txtDI025 . Text = "0";
            txtDI026 . Text = "1";
            txtDI028 . Text = "1.5";
            txtDI032 . Text = "2.5";

            base . add ( );
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
            result = _bll . Delete ( _di . DI001 ,Logins . username );
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
                _bll . Delete ( _di . DI001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( txtDI002 . Text ) )
            {
                MessageBox . Show ( "流水号不可为空" );
                return;
            }

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            getValue ( );

            result = _bll . Save ( tableView ,_di ,bodyList ,Logins . username );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                bodyList . Clear ( );
                UnEnable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . save ( );
        }
        protected override void export ( )
        {
            printOne = _bll . getPrintOne ( _di . DI001 );
            printOne . TableName = "R_PQDI";
            printTwo = _bll . getPrintTwo ( _di . DI001 );
            printTwo . TableName = "R_PQDJ";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );
            report . Load ( Application . StartupPath + "\\R_101.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "DI001" ,_di .DI001 ,"R_PQDI" ,this ,"" ,"R_101" ,false ,false ,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_101" ,_di . DI001 );

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
        private void secDI003_EditValueChanged ( object sender ,System . EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtDI002 . Text = row [ "PQF01" ] . ToString ( );
                txtDI004 . Text = row [ "PQF03" ] . ToString ( );
                txtDI005 . Text = row [ "PQF06" ] . ToString ( );
                txtDI006 . Text = row [ "PQF07" ] . ToString ( );
                txtDI007 . Text = row [ "PQF08" ] . ToString ( );
                txtDI009 . Text = row [ "PQX25" ] . ToString ( );
            }
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void btnSign_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                if ( string . IsNullOrEmpty ( row [ "DJ006" ] . ToString ( ) ) )
                {
                    row [ "DJ006" ] = Logins . username;
                    gridControl1 . RefreshDataSource ( );
                }
                else if ( row [ "DJ006" ] . ToString ( ) . Equals ( Logins . username ) )
                {
                    row [ "DJ006" ] = string . Empty;
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void gridView1_KeyPress ( object sender ,System . Windows . Forms . KeyPressEventArgs e )
        {
            if ( e . KeyChar == ( char ) Keys . Enter )
            {
                if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                    return;
                DataRow row = gridView1 . GetFocusedDataRow ( );
                if ( row == null )
                    return;
                bodyList . Add ( row [ "idx" ] . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void txtDI008_Leave ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( txtDI008 . Text ) )
            {
                DataTable dt = _bll . getSam ( Convert . ToInt32 ( txtDI008 . Text ) );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    txtDI029 . Text = dt . Rows [ 0 ] [ "CL004" ] . ToString ( );
                    txtDI030 . Text = dt . Rows [ 0 ] [ "CL005" ] . ToString ( );
                    txtDI033 . Text = dt . Rows [ 0 ] [ "CL006" ] . ToString ( );
                    txtDI034 . Text = dt . Rows [ 0 ] [ "CL007" ] . ToString ( );
                }
            }
        }
        private void gridView1_CellValueChanged ( object sender ,DevExpress . XtraGrid . Views . Base . CellValueChangedEventArgs e )
        {

        }
        private void gridView1_CustomRowCellEditForEditing ( object sender ,DevExpress . XtraGrid . Views . Grid . CustomRowCellEditEventArgs e )
        {
            if ( e . RowHandle >= 0 && e . RowHandle <= gridView1 . DataRowCount - 1 )
            {
                string row = gridView1 . GetDataRow ( e . RowHandle ) [ "DJ002" ] . ToString ( );
                if ( e . Column . Name == "DJ008" && !( row . Contains ( "极严重" ) || row . Contains ( "严重" ) || row . Contains ( "轻微" ) ) )
                {
                    e . RepositoryItem = new DevExpress . XtraEditors . Repository . RepositoryItemCheckEdit ( );
                }
            }
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            txtDI002 . Enabled = txtDI004 . Enabled = txtDI005 . Enabled = txtDI006 . Enabled = txtDI007 . Enabled = txtDI008 . Enabled = txtDI009 . Enabled = txtDI011 . Enabled = txtDI024 . Enabled = txtDI025 . Enabled = txtDI026 . Enabled = txtDI027 . Enabled = txtDI028 . Enabled = txtDI029 . Enabled = txtDI030 . Enabled = txtDI031 . Enabled = txtDI032 . Enabled = txtDI033 . Enabled = txtDI034 . Enabled = txtDI035 . Enabled = cmbDI014 . Enabled = dtpDI010 . Enabled = dtpDI012 . Enabled = dtpDI013 . Enabled = dtpDI015 . Enabled = secDI003 . Enabled = rabDI016 . Enabled = rabDI017 . Enabled = rabDI018 . Enabled = rabDI019 . Enabled = rabDI020 . Enabled = rabDI021 . Enabled = rabDI022 . Enabled = rabDI023 . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
            labZX . Visible = false;
        }
        void Enable ( )
        {
            txtDI002 . Enabled = txtDI004 . Enabled = txtDI005 . Enabled = txtDI006 . Enabled = txtDI007 . Enabled = txtDI008 . Enabled = txtDI009 . Enabled = txtDI011 . Enabled = txtDI024 . Enabled = txtDI025 . Enabled = txtDI026 . Enabled = txtDI027 . Enabled = txtDI028 . Enabled = txtDI029 . Enabled = txtDI030 . Enabled = txtDI031 . Enabled = txtDI032 . Enabled = txtDI033 . Enabled = txtDI034 . Enabled = txtDI035 . Enabled = cmbDI014 . Enabled = dtpDI010 . Enabled = dtpDI012 . Enabled = dtpDI013 . Enabled = dtpDI015 . Enabled = secDI003 . Enabled = rabDI016 . Enabled = rabDI017 . Enabled = rabDI018 . Enabled = rabDI019 . Enabled = rabDI020 . Enabled = rabDI021 . Enabled = rabDI022 . Enabled = rabDI023 . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void clearControl ( )
        {
            txtDI002 . Text = txtDI004 . Text = txtDI005 . Text = txtDI006 . Text = txtDI007 . Text = txtDI008 . Text = txtDI009 . Text = txtDI011 . Text = txtDI024 . Text = txtDI025 . Text = txtDI026 . Text = txtDI027 . Text = txtDI028 . Text = txtDI029 . Text = txtDI030 . Text = txtDI031 . Text = txtDI032 . Text = txtDI033 . Text = txtDI034 . Text = txtDI035 . Text = cmbDI014 . Text = string . Empty;
            dtpDI010 . Value = dtpDI012 . Value = dtpDI013 . Value = dtpDI015 . Value = MulaolaoBll . Drity . GetDt ( );
            secDI003 . EditValue = null;
            rabDI016 . Checked = rabDI017 . Checked = rabDI018 . Checked = rabDI019 . Checked = rabDI020 . Checked = rabDI021 . Checked = rabDI022 . Checked = rabDI023 . Checked = false;
            gridControl1 . DataSource = null;
            labZX . Visible = false;
        }
        void setValue ( )
        {
            tableView = _bll . getTableView ( _di . DI001 );
            gridControl1 . DataSource = tableView;
            _di = _bll . getModel ( _di . DI001 );
            if ( _di == null )
                return;
            setValueBody ( );
        }
        void setValueBody ( )
        {
            txtDI002 . Tag = _di . idx;
            secDI003 . EditValue = _di . DI002;
            txtDI002 . Text = _di . DI002;
            txtDI004 . Text = _di . DI004;
            txtDI005 . Text = _di . DI005 . ToString ( );
            txtDI006 . Text = _di . DI006;
            txtDI007 . Text = _di . DI007;
            txtDI008 . Text = _di . DI008 . ToString ( );
            txtDI009 . Text = _di . DI009 . ToString ( );
            txtDI011 . Text = _di . DI011;
            txtDI024 . Text = _di . DI024 . ToString ( );
            txtDI025 . Text = _di . DI025 . ToString ( );
            txtDI026 . Text = _di . DI026 . ToString ( );
            txtDI027 . Text = _di . DI027 . ToString ( );
            txtDI028 . Text = _di . DI028 . ToString ( );
            txtDI029 . Text = _di . DI029 . ToString ( );
            txtDI030 . Text = _di . DI030 . ToString ( );
            txtDI031 . Text = _di . DI031 . ToString ( );
            txtDI032 . Text = _di . DI032 . ToString ( );
            txtDI033 . Text = _di . DI033 . ToString ( );
            txtDI034 . Text = _di . DI034 . ToString ( );
            txtDI035 . Text = _di . DI035 . ToString ( );
            cmbDI014 . Text = _di . DI014;
            rabDI016 . Checked = _di . DI016;
            rabDI017 . Checked = _di . DI017;
            rabDI018 . Checked = _di . DI018;
            rabDI019 . Checked = _di . DI019;
            rabDI020 . Checked = _di . DI020;
            rabDI021 . Checked = _di . DI021;
            rabDI022 . Checked = _di . DI022;
            rabDI023 . Checked = _di . DI023;
            if ( _di . DI010 < DateTime . MaxValue && _di . DI010 > DateTime . MinValue )
                dtpDI010 . Value = Convert . ToDateTime ( _di . DI010 );
            else
                dtpDI010 . Value = MulaolaoBll . Drity . GetDt ( );
            if ( _di . DI012 < DateTime . MaxValue && _di . DI012 > DateTime . MinValue )
                dtpDI012 . Value = Convert . ToDateTime ( _di . DI012 );
            else
                dtpDI012 . Value = MulaolaoBll . Drity . GetDt ( );
            if ( _di . DI013 < DateTime . MaxValue && _di . DI013 > DateTime . MinValue )
                dtpDI013 . Value = Convert . ToDateTime ( _di . DI013 );
            else
                dtpDI013 . Value = MulaolaoBll . Drity . GetDt ( );
            if ( _di . DI015 < DateTime . MaxValue && _di . DI015 > DateTime . MinValue )
                dtpDI015 . Value = Convert . ToDateTime ( _di . DI015 );
            else
                dtpDI015 . Value = MulaolaoBll . Drity . GetDt ( );
        }
        void getValue ( )
        {
            if ( txtDI002 . Tag == null )
                _di . idx = 0;
            else
                _di . idx = Convert . ToInt32 ( txtDI002 . Tag );
            _di . DI003 = secDI003 . Text;
            _di . DI002 = txtDI002 . Text;
            _di . DI004 = txtDI004 . Text;
            _di . DI005 = string . IsNullOrEmpty ( txtDI005 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI005 . Text );
            _di . DI006 = txtDI006 . Text;
            _di . DI007 = txtDI007 . Text;
            _di . DI008 = string . IsNullOrEmpty ( txtDI008 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI008 . Text );
            if ( string . IsNullOrEmpty ( txtDI009 . Text ) )
                _di . DI009 = null;
            else
                _di . DI009 = Convert . ToDateTime ( txtDI009 . Text );
            _di . DI011 = txtDI011 . Text;
            _di . DI024 = string . IsNullOrEmpty ( txtDI024 . Text ) == true ? 0 : Convert . ToDecimal ( txtDI024 . Text );
            _di . DI025 = string . IsNullOrEmpty ( txtDI025 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI025 . Text );
            _di . DI026 = string . IsNullOrEmpty ( txtDI026 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI026 . Text );
            _di . DI027 = string . IsNullOrEmpty ( txtDI027 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI027 . Text );
            _di . DI028 = string . IsNullOrEmpty ( txtDI028 . Text ) == true ? 0 : Convert . ToDecimal ( txtDI028 . Text );
            _di . DI029 = string . IsNullOrEmpty ( txtDI029 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI029 . Text );
            _di . DI030 = string . IsNullOrEmpty ( txtDI030 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI030 . Text );
            _di . DI031 = string . IsNullOrEmpty ( txtDI031 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI031 . Text );
            _di . DI032 = string . IsNullOrEmpty ( txtDI032 . Text ) == true ? 0 : Convert . ToDecimal ( txtDI032 . Text );
            _di . DI033 = string . IsNullOrEmpty ( txtDI033 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI033 . Text );
            _di . DI034 = string . IsNullOrEmpty ( txtDI034 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI034 . Text );
            _di . DI035 = string . IsNullOrEmpty ( txtDI035 . Text ) == true ? 0 : Convert . ToInt32 ( txtDI035 . Text );
            _di . DI014 = cmbDI014 . Text;
            _di . DI016 = rabDI016 . Checked;
            _di . DI017 = rabDI017 . Checked;
            _di . DI018 = rabDI018 . Checked;
            _di . DI019 = rabDI019 . Checked;
            _di . DI020 = rabDI020 . Checked;
            _di . DI021 = rabDI021 . Checked;
            _di . DI022 = rabDI022 . Checked;
            _di . DI023 = rabDI023 . Checked;
            _di . DI010 = dtpDI010 . Value;
            _di . DI012 = dtpDI012 . Value;
            _di . DI013 = dtpDI013 . Value;
            _di . DI015 = dtpDI015 . Value;
        }
        #endregion

    }
}
