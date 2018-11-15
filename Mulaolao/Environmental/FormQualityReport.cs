using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormQualityReport :FormChild
    {
        MulaolaoLibrary.QualityReportDKEntity model=null;
        MulaolaoBll.Bll.QualityReportBll _bll=null;
        string state=string.Empty;bool result=false;
        DataTable printOne;
        
        public FormQualityReport ( )
        {
            InitializeComponent ( );
            
            model = new MulaolaoLibrary . QualityReportDKEntity ( );
            _bll = new MulaolaoBll . Bll . QualityReportBll ( );

            GridViewMoHuSelect . SetFilter ( secView );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            UnEnable ( );
            Power ( this );

            secDK003 . Properties . DataSource = _bll . getTableOfPro ( );
            secDK003 . Properties . DisplayMember = "PQF04";
            secDK003 . Properties . ValueMember = "PQF01";

            DataTable bd = _bll . getTableOfPersonBD ( );
            cmbDK020 . DataSource = bd . Copy ( );
            cmbDK020 . DisplayMember = "DBA002";
            cmbDK021 . DataSource = bd . Copy ( );
            cmbDK021 . DisplayMember = "DBA002";
            cmbDK022 . DataSource = bd . Copy ( );
            cmbDK022 . DisplayMember = "DBA002";
            DataTable pd = _bll . getTableOfPersonBDUser ( );
            cmbDK016 . DataSource = pd . DefaultView . ToTable ( true ,"DK016" );
            cmbDK016 . DisplayMember = "DK016";
            cmbDK018 . DataSource = pd . DefaultView . ToTable ( true ,"DK018" );
            cmbDK018 . DisplayMember = "DK018";
            cmbDK023 . DataSource = pd . DefaultView . ToTable ( true ,"DK023" );
            cmbDK023 . DisplayMember = "DK023";
            cmbDK024 . DataSource = pd . DefaultView . ToTable ( true ,"DK024" );
            cmbDK024 . DisplayMember = "DK024";
            cmbDK025 . DataSource = pd . DefaultView . ToTable ( true ,"DK025" );
            cmbDK025 . DisplayMember = "DK025";
            cmbDK029 . DataSource = pd . DefaultView . ToTable ( true ,"DK029" );
            cmbDK029 . DisplayMember = "DK029";
            cmbDK030 . DataSource = pd . DefaultView . ToTable ( true ,"DK030" );
            cmbDK030 . DisplayMember = "DK030";
            cmbDK031 . DataSource = pd . DefaultView . ToTable ( true ,"DK031" );
            cmbDK031 . DisplayMember = "DK031";
            cmbDK033 . DataSource = pd . DefaultView . ToTable ( true ,"DK033" );
            cmbDK033 . DisplayMember = "DK033";
            cmbDK034 . DataSource = pd . DefaultView . ToTable ( true ,"DK034" );
            cmbDK034 . DisplayMember = "DK034";
            cmbDK036 . DataSource = pd . DefaultView . ToTable ( true ,"DK036" );
            cmbDK036 . DisplayMember = "DK036";
            DataTable pw = _bll . getTableOfPersonPW ( );
            cmbDK026 . DataSource = pw . Copy ( );
            cmbDK026 . DisplayMember = "DBA002";
            cmbDK027 . DataSource = pw . Copy ( );
            cmbDK027 . DisplayMember = "DBA002";
            cmbDK028 . DataSource = pw . Copy ( );
            cmbDK028 . DisplayMember = "DBA002";
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . QualityReportAll from = new SelectAll . QualityReportAll ( this . Text + "查询" );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                model . DK001 = from . getOdd;
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
            model.DK001 = _bll . getOddNum ( );
            Enable ( );
            clearControl ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            txtDK002 . Tag = null;

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
            result = _bll . Delete ( model . DK001 ,Logins . username );
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
            if ( string . IsNullOrEmpty ( txtDK002 . Text ) )
            {
                MessageBox . Show ( "请填写流水等信息" );
                return;
            }

            getValue ( );

            //if ( _bll . Exists ( model . DK001 ,model . DK002 ) )
            //{
            //    MessageBox . Show ( "流水号:" + model . DK002 + "已经存在,不允许重复保存" );
            //    return;
            //}

            result = _bll . Save ( model ,Logins . username ,state);
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
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

            printOne = _bll . printOne ( model . DK001 );
            printOne . TableName = "R_PQDK";

            Report report = new Report ( );
            DataSet RDataSet = new DataSet ( );
            RDataSet . Tables . Add ( printOne );
            report . Load ( Application . StartupPath + "\\R_293.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "DK001" ,model . DK001 ,"R_PQDK" ,this ,"" ,"R_293" ,false ,false,MulaolaoBll . Drity . GetDt ( ) );

            SpecialPowers sp = new SpecialPowers ( );
            labZX . Visible = sp . reviewImple ( "R_293" ,model . DK001 );

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
        protected override void copys ( )
        {
            model.DK001 = _bll . copy ( model . DK001 ,Logins . username );
            if ( !string . IsNullOrEmpty ( model . DK001 ) )
            {
                MessageBox . Show ( "成功复制" );

                state = "edit";
                Enable ( );
                setValue ( );

                labZX . Visible = false;

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
            }
            else
                MessageBox . Show ( "复制失败" );

            base . copys ( );
        }
        #endregion

        #region Event
        private void secDK003_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = secView . GetFocusedDataRow ( );
            if ( row != null )
            {
                txtDK002 . Text = row [ "PQF01" ] . ToString ( );
                txtDK004 . Text = row [ "PQF03" ] . ToString ( );
                txtDK005 . Text = row [ "PQF02" ] . ToString ( );
                txtDK006 . Text = row [ "PQF67" ] . ToString ( );
                txtDK007 . Text = row [ "DFA003" ] . ToString ( );
                txtDK008 . Text = row [ "PQF66" ] . ToString ( );
                dtpDK009 . Text = row [ "PQF31" ] . ToString ( );
                txtDK010 . Text = row [ "PQF06" ] . ToString ( );
            }
        }
        private void txtDK010_TextChanged ( object sender ,EventArgs e )
        {
            textEdit10 . Text = ( string . IsNullOrEmpty ( txtDK010 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK010 . Text ) - ( string . IsNullOrEmpty ( txtDK019 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK019 . Text ) ) ) . ToString ( );
        }
        private void txtDK019_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra ( e );
        }
        private void txtDK019_TextChanged ( object sender ,EventArgs e )
        {
            textEdit10 . Text = ( string . IsNullOrEmpty ( txtDK010 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK010 . Text ) - ( string . IsNullOrEmpty ( txtDK019 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK019 . Text ) ) ) . ToString ( );
        }
        private void txtDK011_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra ( e );
        }
        #endregion

        #region Method
        void UnEnable ( )
        {
            txtDK002 . Enabled = txtDK004 . Enabled = txtDK005 . Enabled = txtDK006 . Enabled = txtDK007 . Enabled = txtDK008 . Enabled = txtDK010 . Enabled = txtDK011 . Enabled = txtDK019 . Enabled = txtDK032 . Enabled = txtDK035 . Enabled = txtDK037 . Enabled = txtDK038 . Enabled = txtDK039 . Enabled = cmbDK016 . Enabled = cmbDK018 . Enabled = cmbDK020 . Enabled = cmbDK021 . Enabled = cmbDK022 . Enabled = cmbDK023 . Enabled = cmbDK024 . Enabled = cmbDK025 . Enabled = cmbDK026 . Enabled = cmbDK027 . Enabled = cmbDK028 . Enabled = cmbDK029 . Enabled = cmbDK030 . Enabled = cmbDK031 . Enabled = cmbDK033 . Enabled = cmbDK034 . Enabled = cmbDK036 . Enabled = dtpDK009 . Enabled = dtpDK012 . Enabled = dtpDK013 . Enabled = dtpDK014 . Enabled = dtpDK015 . Enabled = dtpDK017 . Enabled =secDK003.Enabled=labZX.Visible= false;
        }
        void Enable ( )
        {
            txtDK002 . Enabled = txtDK004 . Enabled = txtDK005 . Enabled = txtDK006 . Enabled = txtDK007 . Enabled = txtDK008 . Enabled = txtDK010 . Enabled = txtDK011 . Enabled = txtDK019 . Enabled = txtDK032 . Enabled = txtDK035 . Enabled = txtDK037 . Enabled = txtDK038 . Enabled = txtDK039 . Enabled = cmbDK016 . Enabled = cmbDK018 . Enabled = cmbDK020 . Enabled = cmbDK021 . Enabled = cmbDK022 . Enabled = cmbDK023 . Enabled = cmbDK024 . Enabled = cmbDK025 . Enabled = cmbDK026 . Enabled = cmbDK027 . Enabled = cmbDK028 . Enabled = cmbDK029 . Enabled = cmbDK030 . Enabled = cmbDK031 . Enabled = cmbDK033 . Enabled = cmbDK034 . Enabled = cmbDK036 . Enabled = dtpDK009 . Enabled = dtpDK012 . Enabled = dtpDK013 . Enabled = dtpDK014 . Enabled = dtpDK015 . Enabled = dtpDK017 . Enabled = secDK003 . Enabled = true;
        }
        void clearControl ( )
        {
            secDK003 . EditValue = null;
            txtDK002 . Text = txtDK004 . Text = txtDK005 . Text = txtDK006 . Text = txtDK007 . Text = txtDK008 . Text = txtDK010 . Text = txtDK011 . Text = txtDK019 . Text = txtDK032 . Text = txtDK035 . Text = txtDK037 . Text = txtDK038 . Text = txtDK039 . Text = cmbDK016 . Text = cmbDK018 . Text = cmbDK020 . Text = cmbDK021 . Text = cmbDK022 . Text = cmbDK023 . Text = cmbDK024 . Text = cmbDK025 . Text = cmbDK026 . Text = cmbDK027 . Text = cmbDK028 . Text = cmbDK029 . Text = cmbDK030 . Text = cmbDK031 . Text = cmbDK033 . Text = cmbDK034 . Text = cmbDK036 . Text = dtpDK009 . Text = string . Empty;
            dtpDK012 . Value = dtpDK013 . Value = dtpDK014 . Value = dtpDK015 . Value = dtpDK017 . Value = MulaolaoBll . Drity . GetDt ( );
            labZX . Visible = false;
        }
        void setValue ( )
        {
            model = _bll . getModel ( model . DK001 );
            if ( model == null )
                return;
            secDK003 . EditValue = model . DK002;
            txtDK002 . Text = model . DK002;
            txtDK002 . Tag = model . idx;
            txtDK004 . Text = model . DK004;
            txtDK005 . Text = model . DK005;
            txtDK006 . Text = model . DK006;
            txtDK007 . Text = model . DK007;
            txtDK008 . Text = model . DK008;
            txtDK010 . Text = model . DK010 . ToString ( );
            txtDK011 . Text = model . DK011 . ToString ( );
            txtDK019 . Text = model . DK019 . ToString ( );
            txtDK032 . Text = model . DK032;
            txtDK035 . Text = model . DK035;
            txtDK037 . Text = model . DK037;
            txtDK038 . Text = model . DK038;
            txtDK039 . Text = model . DK039;
            cmbDK016 . Text = model . DK016;
            cmbDK018 . Text = model . DK018;
            cmbDK020 . Text = model . DK020;
            cmbDK021 . Text = model . DK021;
            cmbDK022 . Text = model . DK022;
            cmbDK023 . Text = model . DK023;
            cmbDK024 . Text = model . DK024;
            cmbDK025 . Text = model . DK025;
            cmbDK026 . Text = model . DK026;
            cmbDK027 . Text = model . DK027;
            cmbDK028 . Text = model . DK028;
            cmbDK029 . Text = model . DK029;
            cmbDK030 . Text = model . DK030;
            cmbDK031 . Text = model . DK031;
            cmbDK033 . Text = model . DK033;
            cmbDK034 . Text = model . DK034;
            cmbDK036 . Text = model . DK036;
            dtpDK009 . Text = model . DK009 . ToString ( );
            if ( model . DK012 > DateTime . MinValue && model . DK012 < DateTime . MaxValue )
                dtpDK012 . Value = Convert . ToDateTime ( model . DK012 );
            if ( model . DK013 > DateTime . MinValue && model . DK013 < DateTime . MaxValue )
                dtpDK013 . Value = Convert . ToDateTime ( model . DK013 );
            if ( model . DK014 > DateTime . MinValue && model . DK014 < DateTime . MaxValue )
                dtpDK014 . Value = Convert . ToDateTime ( model . DK014 );
            if ( model . DK015 > DateTime . MinValue && model . DK015 < DateTime . MaxValue )
                dtpDK015 . Value = Convert . ToDateTime ( model . DK015 );
            if ( model . DK017 > DateTime . MinValue && model . DK017 < DateTime . MaxValue )
                dtpDK017 . Value = Convert . ToDateTime ( model . DK017 );
        }
        void getValue ( )
        {
            model . DK003 = secDK003 . Text;
            model . DK002 = txtDK002 . Text;
            model . idx = txtDK002 . Tag == null ? 0 : Convert . ToInt32 ( txtDK002 . Tag );
            model . DK004 = txtDK004 . Text;
            model . DK005 = txtDK005 . Text;
            model . DK006 = txtDK006 . Text;
            model . DK007 = txtDK007 . Text;
            model . DK008 = txtDK008 . Text;
            model . DK010 = string . IsNullOrEmpty ( txtDK010 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK010 . Text );
            model . DK011 = string . IsNullOrEmpty ( txtDK011 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK011 . Text );
            model . DK019 = string . IsNullOrEmpty ( txtDK019 . Text ) == true ? 0 : Convert . ToInt32 ( txtDK019 . Text );
            model . DK032 = txtDK032 . Text;
            model . DK035 = txtDK035 . Text;
            model . DK037 = txtDK037 . Text;
            model . DK038 = txtDK038 . Text;
            model . DK039 = txtDK039 . Text;
            model . DK016 = cmbDK016 . Text;
            model . DK018 = cmbDK018 . Text;
            model . DK020 = cmbDK020 . Text;
            model . DK021 = cmbDK021 . Text;
            model . DK022 = cmbDK022 . Text;
            model . DK023 = cmbDK023 . Text;
            model . DK024 = cmbDK024 . Text;
            model . DK025 = cmbDK025 . Text;
            model . DK026 = cmbDK026 . Text;
            model . DK027 = cmbDK027 . Text;
            model . DK028 = cmbDK028 . Text;
            model . DK029 = cmbDK029 . Text;
            model . DK030 = cmbDK030 . Text;
            model . DK031 = cmbDK031 . Text;
            model . DK033 = cmbDK033 . Text;
            model . DK034 = cmbDK034 . Text;
            model . DK036 = cmbDK036 . Text;
            if ( string . IsNullOrEmpty ( dtpDK009 . Text ) )
                model . DK009 = null;
            else
                model . DK009 = Convert . ToDateTime ( dtpDK009 . Text );
            if ( string . IsNullOrEmpty ( dtpDK012 . Text ) )
                model . DK012 = null;
            else
                model . DK012 = Convert . ToDateTime ( dtpDK012 . Text );
            if ( string . IsNullOrEmpty ( dtpDK013 . Text ) )
                model . DK013 = null;
            else
                model . DK013 = Convert . ToDateTime ( dtpDK013 . Text );
            if ( string . IsNullOrEmpty ( dtpDK014 . Text ) )
                model . DK014 = null;
            else
                model . DK014 = Convert . ToDateTime ( dtpDK014 . Text );
            if ( string . IsNullOrEmpty ( dtpDK015 . Text ) )
                model . DK015 = null;
            else
                model . DK015 = Convert . ToDateTime ( dtpDK015 . Text );
            if ( string . IsNullOrEmpty ( dtpDK017 . Text ) )
                model . DK017 = null;
            else
                model . DK017 = Convert . ToDateTime ( dtpDK017 . Text );
        }
        #endregion

    }
}






