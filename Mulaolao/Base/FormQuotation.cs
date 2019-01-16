using DevExpress . XtraEditors;
using Mulaolao . Class;
using Mulaolao . QuoForms;
using MulaolaoBll;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Base
{
    public partial class FormQuotation :FormChild
    {
        MulaolaoLibrary.QuoEntity _quo=null;
        MulaolaoLibrary.QupEntity _qup=null;
        MulaolaoBll.Bll.QuoBll _bll=null;

        MulaolaoLibrary .ChanPinZhiBiaoLibrary r195Model=null;
        MulaolaoLibrary.SiReYiYinContractLibrary r196model = null;
        MulaolaoLibrary .JiaoMiDuContractLibrary r338model=null;
        MulaolaoLibrary.MuCaiContractLibrary r341model=null;
        MulaolaoLibrary . CheMuJianContractLibrary r342model=null;
        MulaolaoLibrary.WuJinContractLibrary r343model=null;
        MulaolaoLibrary .SuLiaoBuQiContractLibrary r347model=null;
        MulaolaoLibrary.WaiXianContractLibrary r349model=null;
        MulaolaoLibrary.YouQiLibrary r339model=null;
        MulaolaoLibrary.GunQiContractLibrary r344model=null;

        DataTable tableView;
        DataRow selectRow;int selectIdx;
        List<string> idxList=new List<string>();
        string state="",strWhere="",conState=string.Empty;

        bool result=false;

        DateTime dt;

        public FormQuotation ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );
            _quo = new MulaolaoLibrary . QuoEntity ( );
            _qup = new MulaolaoLibrary . QupEntity ( );
            controlUnEnable ( );
            InitData ( );
            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,ViewFor } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,ViewFor } );
            dt = Drity . GetDt ( );
        }

        #region Main
        protected override void select ( )
        {
            SelectAll . FormQuotationQuery form = new SelectAll . FormQuotationQuery ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                _quo . QUO001 = form . getOdd;
                if ( _quo . QUO001 == null || _quo . QUO001 == string . Empty )
                    return;
                strWhere = "1=1";
                strWhere = strWhere + " AND QUO001='" + _quo . QUO001 + "'";
               
                _quo = _bll . getModel ( strWhere );
                if ( _quo == null )
                    return;
                setValue ( );
                strWhere = "1=1";
                strWhere += " AND QUR001='" + _quo . QUO001 + "'";
                tableView = _bll . getTableView ( strWhere );
                gridControl1 . DataSource = tableView;

                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolLibrary . Enabled = toolStorage . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            controlClear ( );
            controlEnable ( );
            state = "add";

            _quo . QUO001 = _bll . getOddNum ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;

            base . add ( );
        }
        protected override void update ( )
        {
            controlEnable ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            state = "edit";

            base . update ( );
        }
        protected override void delete ( )
        {
            if ( string . IsNullOrEmpty ( _quo . QUO001 ) )
            {
                MessageBox . Show ( "请选择需要删除的单据" );
                return;
            }

            result = _bll . Delete ( _quo . QUO001 );
            if ( result )
            {
                XtraMessageBox . Show ( "成功删除" );
                controlUnEnable ( );
                controlClear ( );
                toolSelect . Enabled = toolAdd . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            }
            else
                XtraMessageBox . Show ( "删除失败" );


            base . delete ( );
        }
        protected override void save ( )
        {
            if ( getValue ( ) == false )
                return;
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            result = _bll . Save ( _quo ,tableView ,state ,idxList );
            if ( result )
            {
                XtraMessageBox . Show ( "成功保存" );
                idxList . Clear ( );
                controlUnEnable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            controlUnEnable ( );
            if ( state . Equals ( "add" ) )
            {
                controlClear ( );
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
        #endregion

        #region Event
        //类别
        private void txtQUP002_TextChanged ( object sender ,EventArgs e )
        {
            switch ( txtQUP002 . Text )
            {
                case "成品委外":
                txtQUP003 . Text = DicStr . r195;
                break;
                case "热转印":
                txtQUP003 . Text = DicStr . r196;
                break;
                case "装运.代理":
                txtQUP003 . Text = DicStr . r243;
                break;
                case "胶合板":
                txtQUP003 . Text = DicStr . r338;
                break;
                case "密度板":
                txtQUP003 . Text = DicStr . r338;
                break;
                case "木材":
                txtQUP003 . Text = DicStr . r341;
                break;
                case "车木件":
                txtQUP003 . Text = DicStr . r342;
                break;
                case "铁件":
                txtQUP003 . Text = DicStr . r343;
                break;
                case "塑料件":
                txtQUP003 . Text = DicStr . r347;
                break;
                case "喷漆工资":
                txtQUP003 . Text = DicStr . r495;
                break;
                case "油漆款":
                txtQUP003 . Text = DicStr . r339;
                break;
                case "滚漆款":
                txtQUP003 . Text = DicStr . r344;
                break;
                case "包装材料":
                txtQUP003 . Text = DicStr . r349;
                break;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdx = gridView1 . FocusedRowHandle;
            selectRow = gridView1 . GetFocusedDataRow ( );
            if ( selectRow == null )
                return;
            _qup . QUR002 = selectRow [ "QUR002" ] . ToString ( );
            _qup . QUR003 = selectRow [ "QUR003" ] . ToString ( );
            _qup . QUR004 = selectRow [ "QUR004" ] . ToString ( );
            _qup . QUR005 = selectRow [ "QUR005" ] . ToString ( );
            _qup . QUR006 = string . IsNullOrEmpty ( selectRow [ "QUR006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR006" ] );
            _qup . QUR007 = selectRow [ "QUR007" ] . ToString ( );
            _qup . QUR008 = selectRow [ "QUR008" ] . ToString ( );
            _qup . QUR009 = selectRow [ "QUR009" ] . ToString ( );
            _qup . QUR010 = string . IsNullOrEmpty ( selectRow [ "QUR010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR010" ] );
            _qup . QUR011 = string . IsNullOrEmpty ( selectRow [ "QUR011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR011" ] );
            _qup . QUR012 = string . IsNullOrEmpty ( selectRow [ "QUR012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR012" ] );
            _qup . QUR013 = string . IsNullOrEmpty ( selectRow [ "QUR013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR013" ] );
            _qup . QUR014 = string . IsNullOrEmpty ( selectRow [ "QUR014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR014" ] );
            _qup . QUR015 = selectRow [ "QUR015" ] . ToString ( );
            txtQUP002 . Text = _qup . QUR002;
            setValueToModel ( );
        }
        #endregion

        #region Edit
        void setValueToModel ( )
        {
            if ( DicStr . r195 . Equals ( _qup . QUR003 ) )
            {
                r195Model = new MulaolaoLibrary . ChanPinZhiBiaoLibrary ( );
                r195Model . CP06 = _qup . QUR004;
                r195Model . CP07 = _qup . QUR015;
                r195Model . CP09 = _qup . QUR005;
                r195Model . CP10 = Convert . ToDecimal ( _qup . QUR013 );
                r195Model . CP13 = Convert . ToDecimal ( _qup . QUR006 );
            }
            else if ( DicStr . r196 . Equals ( _qup . QUR003 ) )
            {
                r196model = new MulaolaoLibrary . SiReYiYinContractLibrary ( );
                r196model . AH10 = _qup . QUR004;
                r196model . AH18 = _qup . QUR005;
                r196model . AH13 = Convert . ToDecimal ( _qup . QUR006 );
                r196model . AH16 = Convert . ToDecimal ( _qup . QUR013 );
                r196model . AH11 = _qup . QUR015;
            }
            else if ( DicStr . r338 . Equals ( _qup . QUR003 ) )
            {
                r338model = new MulaolaoLibrary . JiaoMiDuContractLibrary ( );
                r338model . JM09 = _qup . QUR004;
                r338model . JM10 = Convert . ToDecimal ( _qup . QUR006 );
                r338model . JM94 = Convert . ToDecimal ( _qup . QUR007 );
                r338model . JM95 = Convert . ToDecimal ( _qup . QUR008 );
                r338model . JM96 = Convert . ToDecimal ( _qup . QUR009 );
                r338model . JM15 = Convert . ToDecimal ( _qup . QUR010 );
                r338model . JM120 = _qup . QUR012;
                r338model . JM11 = Convert . ToDecimal ( _qup . QUR013 );
            }
            else if ( DicStr . r341 . Equals ( _qup . QUR003 ) )
            {
                r341model = new MulaolaoLibrary . MuCaiContractLibrary ( );
                r341model . PQV10 = _qup . QUR004;
                r341model . PQV12 = Convert . ToInt32 ( _qup . QUR006 );
                r341model . PQV71 = Convert . ToDecimal ( _qup . QUR007 );
                r341model . PQV72 = Convert . ToDecimal ( _qup . QUR008 );
                r341model . PQV73 = Convert . ToDecimal ( _qup . QUR009 );
                r341model . PQV64 = Convert . ToDecimal ( _qup . QUR010 );
                r341model . PQV11 = Convert . ToDecimal ( _qup . QUR012 );
            }
            else if ( DicStr . r342 . Equals ( _qup . QUR003 ) )
            {
                r342model = new MulaolaoLibrary . CheMuJianContractLibrary ( );
                r342model . AF015 = _qup . QUR004;
                r342model . AF019 = Convert . ToInt32 ( _qup . QUR006 );
                r342model . AF020 = Convert . ToDecimal ( _qup . QUR007 );
                r342model . AF021 = Convert . ToDecimal ( _qup . QUR008 );
                r342model . AF022 = Convert . ToDecimal ( _qup . QUR009 );
                r342model . AF018 = Convert . ToInt64 ( _qup . QUR010 );
                r342model . AF023 = Convert . ToDecimal ( _qup . QUR013 );
                r342model . AF087 = Convert . ToDecimal ( _qup . QUR012 );
                r342model . AF088 = Convert . ToDecimal ( _qup . QUR014 );
            }
            else if ( DicStr . r343 . Equals ( _qup . QUR003 ) )
            {
                r343model = new MulaolaoLibrary . WuJinContractLibrary ( );
                r343model . PQU10 = _qup . QUR004;
                r343model . PQU12 = _qup . QUR015;
                r343model . PQU13 = _qup . QUR006;
                r343model . PQU16 = _qup . QUR013;
                r343model . PQU18 = _qup . QUR010;
            }
            else if ( DicStr . r347 . Equals ( _qup . QUR003 ) )
            {
                r347model = new MulaolaoLibrary . SuLiaoBuQiContractLibrary ( );
                r347model . PJ09 = _qup . QUR004;
                r347model . PJ89 = _qup . QUR015;
                r347model . PJ11 = _qup . QUR006;
                r347model . PJ12 = _qup . QUR013;
                r347model . PJ97 = _qup . QUR010;
            }
            else if ( DicStr . r349 . Equals ( _qup . QUR003 ) )
            {
                r349model = new MulaolaoLibrary . WaiXianContractLibrary ( );
                r349model . WX10 = _qup . QUR004;
                r349model . WX11 = _qup . QUR015;
                r349model . WX13 = _qup . QUR013;
                r349model . WX14 = _qup . QUR006;
                r349model . WX16 = Convert . ToInt64 ( _qup . QUR010 );
            }
            else if ( DicStr . r339 . Equals ( _qup . QUR003 ) )
            {
                r339model = new MulaolaoLibrary . YouQiLibrary ( );
                r339model . YQ10 = _qup . QUR004;
                r339model . YQ112 = Convert . ToInt32 ( _qup . QUR006 );
                r339model . YQ119 = _qup . QUR005;
                r339model . YQ19 = Convert . ToDecimal ( _qup . QUR010 );
            }
            else if ( DicStr . r344 . Equals ( _qup . QUR003 ) )
            {
                r344model = new MulaolaoLibrary . GunQiContractLibrary ( );
                r344model . MZ016 = _qup . QUR004;
                r344model . MZ018 = _qup . QUR015;
                r344model . MZ021 = Convert . ToInt32 ( _qup . QUR010 );
                r344model . MZ025 = Convert . ToDecimal ( _qup . QUR013 );
                r344model . MZ105 = Convert . ToDecimal ( _qup . QUR016 );
            }
        }
        #endregion

        #region Method
        void InitData ( )
        {
            DataTable tableFor = _bll . getTableFor ( );
            txtQUO010.Properties. DataSource = tableFor;
            txtQUO010 . Properties . DisplayMember = "DBA002";
            txtQUO010 . Properties . ValueMember = "DBA002";
        }
        void controlEnable ( )
        {
            foreach ( Control ct in layoutControl1 . Controls )
            {
                if ( ct . GetType ( ) == typeof ( TextEdit ) )
                {
                    TextEdit td = ct as TextEdit;
                    td . Enabled = true;
                }
                if ( ct . GetType ( ) == typeof ( DateEdit ) )
                {
                    DateEdit td = ct as DateEdit;
                    td . Enabled = true;
                }
                if ( ct . GetType ( ) == typeof ( SimpleButton ) )
                {
                    SimpleButton td = ct as SimpleButton;
                    td . Enabled = true;
                }
                if ( ct . GetType ( ) == typeof ( GridLookUpEdit ) )
                {
                    GridLookUpEdit gl = ct as GridLookUpEdit;
                    gl . Enabled = true;
                }
            }
            foreach ( Control ct in layoutControl2 . Controls )
            {
                if ( ct . GetType ( ) == typeof ( TextEdit ) )
                {
                    TextEdit td = ct as TextEdit;
                    td . Enabled = true;
                }
                if ( ct . GetType ( ) == typeof ( ComboBoxEdit ) )
                {
                    ComboBoxEdit td = ct as ComboBoxEdit;
                    td . Enabled = true;
                }
                if ( ct . GetType ( ) == typeof ( SimpleButton ) )
                {
                    SimpleButton td = ct as SimpleButton;
                    td . Enabled = true;
                }
            }
        }
        void controlUnEnable ( )
        {
            foreach ( Control ct in layoutControl1 . Controls )
            {
                if ( ct . GetType ( ) == typeof ( TextEdit ) )
                {
                    TextEdit td = ct as TextEdit;
                    td . Enabled = false;
                }
                if ( ct . GetType ( ) == typeof ( DateEdit ) )
                {
                    DateEdit td = ct as DateEdit;
                    td . Enabled = false;
                }
                if ( ct . GetType ( ) == typeof ( SimpleButton ) )
                {
                    SimpleButton td = ct as SimpleButton;
                    td . Enabled = false;
                }
                if ( ct . GetType ( ) == typeof ( GridLookUpEdit ) )
                {
                    GridLookUpEdit gl = ct as GridLookUpEdit;
                    gl . Enabled = false;
                }
            }
            foreach ( Control ct in layoutControl2 . Controls )
            {
                if ( ct . GetType ( ) == typeof ( TextEdit ) )
                {
                    TextEdit td = ct as TextEdit;
                    td . Enabled = false;
                }
                if ( ct . GetType ( ) == typeof ( ComboBoxEdit ) )
                {
                    ComboBoxEdit td = ct as ComboBoxEdit;
                    td . Enabled = false;
                }
                if ( ct . GetType ( ) == typeof ( SimpleButton ) )
                {
                    SimpleButton td = ct as SimpleButton;
                    td . Enabled = false;
                }

            }
        }
        void controlClear ( )
        {
            foreach ( Control ct in layoutControl1 . Controls )
            {
                if ( ct . GetType ( ) == typeof ( TextEdit ) )
                {
                    TextEdit td = ct as TextEdit;
                    td . Text = string . Empty;
                }
                if ( ct . GetType ( ) == typeof ( DateEdit ) )
                {
                    DateEdit td = ct as DateEdit;
                    td . Text = string . Empty;
                }
                if ( ct . GetType ( ) == typeof ( ImageEdit ) )
                {
                    ImageEdit td = ct as ImageEdit;
                    td . Image = null;
                }
                if ( ct . GetType ( ) == typeof ( GridLookUpEdit ) )
                {
                    GridLookUpEdit gl = ct as GridLookUpEdit;
                    gl . EditValue = null;
                }
            }
            gridControl1 . DataSource = null;
        }
        bool getValue ( )
        {
            if ( string . IsNullOrEmpty ( txtQUO002 . Text ) )
            {
                XtraMessageBox . Show ( "客户名称不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( txtQUO004 . Text ) )
            {
                XtraMessageBox . Show ( "产品名称不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( txtQUO010 . Text ) )
            {
                XtraMessageBox . Show ( "业务员不可为空" );
                return false;
            }
            int num = 0;
            if ( !string . IsNullOrEmpty ( txtQUO007 . Text ) && int . TryParse ( txtQUO007 . Text ,out num )==false )
            {
                XtraMessageBox . Show ( "数量请输入整数" );
                return false;
            }
            _quo . QUO007 = num;
            if ( string . IsNullOrEmpty ( txtQUO008 . Text ) )
            {
                XtraMessageBox . Show ( "报价日期不可为空" );
                return false;
            }
            _quo . QUO008 = Convert . ToDateTime ( txtQUO008 . Text );

            _quo . QUO002 = txtQUO002 . Text;
            _quo . QUO003 = txtQUO003 . Text;
            _quo . QUO004 = txtQUO004 . Text;
            _quo . QUO005 = txtQUO005 . Text;
            _quo . QUO006 = txtQUO006 . Text;
            _quo . QUO010 = txtQUO010 . Text;

            return true;
        }
        void setValue ( )
        {
            txtQUO002 . Text = _quo . QUO002;
            txtQUO003 . Text = _quo . QUO003;
            txtQUO004 . Text = _quo . QUO004;
            txtQUO005 . Text = _quo . QUO005;
            txtQUO006 . Text = _quo . QUO006;
            txtQUO007 . Text = _quo . QUO007 . ToString ( );
            txtQUO008 . Text = _quo . QUO008 . ToString ( );
            pic . Image = ReadOrWriteImageOfPicutre . ReadPicture ( _quo . QUO009 );
            txtQUO010 . Text = _quo . QUO010;
        }
        #endregion

        #region Click
        private void btnAdd_Click ( object sender ,System . EventArgs e )
        {
            conState = "add";
            getValueQUR ( );
            if ( string . IsNullOrEmpty ( _qup . QUR002 ) )
            {
                XtraMessageBox . Show ( "请选择合同代号和材种" );
                return;
            }
            selectRow = tableView . NewRow ( );
            choiseCon ( );
        }
        private void btnEdit_Click ( object sender ,System . EventArgs e )
        {
            conState = "edit";
            choiseCon ( );
        }
        private void btnDelete_Click ( object sender ,System . EventArgs e )
        {
            if ( selectRow == null )
                return;
            if ( XtraMessageBox . Show ( "确认删除选中内容?" ,"提示" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            {
                _qup . idx = string . IsNullOrEmpty ( selectRow [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( selectRow [ "idx" ] . ToString ( ) );
                if ( _qup . idx > 0 && !idxList . Contains ( _qup . idx . ToString ( ) ) )
                    idxList . Add ( _qup . idx . ToString ( ) );

                tableView . Rows . Remove ( selectRow );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void btnRefresh_Click ( object sender ,System . EventArgs e )
        {
            gridControl1 . RefreshDataSource ( );
        }
        //预览
        private void btnPre_Click ( object sender ,EventArgs e )
        {
            _quo . QUO009 = ReadOrWriteImageOfPicutre . ReadPicture ( pic );
        }
        //删除
        private void btnRemove_Click ( object sender ,EventArgs e )
        {
            pic . Image = null;
            _quo . QUO009 = new byte [ 0 ];
        }
        #endregion

        #region Read
        void getValueQUR ( )
        {
            _qup . QUR002 = txtQUP002 . Text;
            _qup . QUR003 = txtQUP003 . Text;
            _qup . QUR004 = string . Empty;
            _qup . QUR005 = string . Empty;
            _qup . QUR006 = 0M;
            _qup . QUR007 = string . Empty;
            _qup . QUR008 = string . Empty;
            _qup . QUR009 = string . Empty;
            _qup . QUR010 = 0M;
            _qup . QUR011 = 0M;
            _qup . QUR012 = 0M;
            _qup . QUR013 = 0M;
            _qup . QUR014 = 0M;
            _qup . QUR015 = string . Empty;
            _qup . QUR016 = 0;
        }
        void choiseCon ( )
        {
            if ( DicStr . r195 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r195Model = new MulaolaoLibrary . ChanPinZhiBiaoLibrary ( );
                read195 (  );
            }
            else if ( DicStr . r196 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r196model = new MulaolaoLibrary . SiReYiYinContractLibrary ( );
                read196 (  );
            }
            else if ( DicStr . r338 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r338model = new MulaolaoLibrary . JiaoMiDuContractLibrary ( );
                read338 (  );
            }
            else if ( DicStr . r341 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r341model = new MulaolaoLibrary . MuCaiContractLibrary ( );
                read341 (  );
            }
            else if ( DicStr . r342 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r342model = new MulaolaoLibrary . CheMuJianContractLibrary ( );
                read342 (  );
            }
            else if ( DicStr . r343 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r343model = new MulaolaoLibrary . WuJinContractLibrary ( );
                read343 (  );
            }
            else if ( DicStr . r347 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r347model = new MulaolaoLibrary . SuLiaoBuQiContractLibrary ( );
                read347 (  );
            }
            else if ( DicStr . r349 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r349model = new MulaolaoLibrary . WaiXianContractLibrary ( );
                read349 (  );
            }
            else if ( DicStr . r339 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r339model = new MulaolaoLibrary . YouQiLibrary ( );
                read339 (  );
            }
            else if ( DicStr . r344 . Equals ( _qup . QUR003 ) )
            {
                if ( "add" . Equals ( conState ) )
                    r344model = new MulaolaoLibrary . GunQiContractLibrary ( );
                read344 (  );
            }
            gridControl1 . RefreshDataSource ( );
        }
        void read195 (   )
        {
            r195Model . CP14 = dt;
            r195 form = new r195 ( r195Model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r195Model = form . getModel;
                if ( r195Model == null )
                    return;
                _qup . QUR004 = r195Model . CP06;
                _qup . QUR005 = r195Model . CP09;
                _qup . QUR006 = r195Model . CP13;
                _qup . QUR013 = r195Model . CP10;
                _qup . QUR015 = r195Model . CP07;
                _qup . QUR016 = 0;
                editRow (  );
            }
        }
        void read196 (   )
        {
            r196model . AH04 = dt;
            r196 form = new r196 ( r196model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r196model = form . getModel;
                if ( r196model == null )
                    return;
                _qup . QUR004 = r196model . AH10;
                _qup . QUR005 = r196model . AH18;
                _qup . QUR006 = r196model . AH13;
                _qup . QUR013 = r196model . AH16;
                _qup . QUR015 = r196model . AH11;
                _qup . QUR016 = 0;
                editRow (  );
            }
        }
        void read338 (   )
        {
            r338model . JM05 = dt;
            r338 form = new r338 ( r338model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r338model = form . getModel;
                if ( r338model == null )
                    return;
                _qup . QUR004 = r338model . JM09;
                _qup . QUR006 = r338model . JM10;
                _qup . QUR007 = r338model . JM94 . ToString ( );
                _qup . QUR008 = r338model . JM95 . ToString ( );
                _qup . QUR009 = r338model . JM96 . ToString ( );
                _qup . QUR010 = r338model . JM15;
                _qup . QUR012 = r338model . JM120;
                _qup . QUR013 = r338model . JM11;
                _qup . QUR015 = r338model . JM94 + "*" + r338model . JM95 + "*" + r338model . JM96;
                _qup . QUR016 = Convert . ToDecimal ( r338model . JM94 ) * Convert . ToDecimal ( r338model . JM95 ) * Convert . ToDecimal ( r338model . JM96 );
                editRow (  );
            }
        }
        void read341 (   )
        {
            r341model . PQV04 = dt;
            r341 form = new r341 ( r341model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r341model = form . getModel;
                if ( r341model == null )
                    return;
                _qup . QUR004 = r341model . PQV10;
                _qup . QUR006 = r341model . PQV12;
                _qup . QUR007 = r341model . PQV71 . ToString ( );
                _qup . QUR008 = r341model . PQV72 . ToString ( );
                _qup . QUR009 = r341model . PQV73 . ToString ( );
                _qup . QUR010 = r341model . PQV64;
                _qup . QUR012 = r341model . PQV11;
                _qup . QUR015 = r341model . PQV71 + "*" + r341model . PQV72 + "*" + r341model . PQV73;
                _qup . QUR016 = Convert . ToDecimal ( r341model . PQV71 ) * Convert . ToDecimal ( r341model . PQV72 ) * Convert . ToDecimal ( r341model . PQV73 );
                editRow (  );
            }
        }
        void read342 (   )
        {
            r342model . AF009 = dt;
            r342 form = new r342 ( r342model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r342model = form . getModel;
                if ( r342model == null )
                    return;

                _qup . QUR004 = r342model . AF015;
                _qup . QUR006 = r342model . AF019;
                _qup . QUR007 = r342model . AF020 . ToString ( );
                _qup . QUR008 = r342model . AF021 . ToString ( );
                _qup . QUR009 = r342model . AF022 . ToString ( );
                _qup . QUR010 = r342model . AF018;
                _qup . QUR012 = r342model . AF087;
                _qup . QUR013 = r342model . AF023;
                _qup . QUR014 = r342model . AF088;
                _qup . QUR015 = r342model . AF020 + "*" + r342model . AF021 + "*" + r342model . AF022;
                _qup . QUR016 = Convert . ToDecimal ( r342model . AF020 ) * Convert . ToDecimal ( r342model . AF021 ) * Convert . ToDecimal ( r342model . AF022 );
                editRow (  );
            }
        }
        void read343 (   )
        {
            r343model . PQU04 = dt;
            r343 form = new r343 ( r343model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r343model = form . getModel;
                if ( r343model == null )
                    return;

                _qup . QUR004 = r343model . PQU10;
                _qup . QUR015 = r343model . PQU12;
                _qup . QUR006 = r343model . PQU13;
                _qup . QUR013 = r343model . PQU16;
                _qup . QUR010 = r343model . PQU18;
                _qup . QUR016 = 0;
                editRow (  );
            }
        }
        void read347 (   )
        {
            r347model . PJ05 = dt;
            r347 form = new r347 ( r347model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r347model = form . getModel;
                if ( r347model == null )
                    return;

                _qup . QUR004 = r347model . PJ09;
                _qup . QUR015 = r347model . PJ89;
                _qup . QUR006 = r347model . PJ11;
                _qup . QUR013 = r347model . PJ12;
                _qup . QUR010 = r347model . PJ97;
                editRow (  );
            }
        }
        void read349 (   )
        {
            r349model . WX04 = dt;
            r349 form = new r349 ( r349model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r349model = form . getModel;
                if ( r349model == null )
                    return;

                _qup . QUR004 = r349model . WX10;
                _qup . QUR015 = r349model . WX11;
                _qup . QUR013 = r349model . WX13;
                _qup . QUR006 = r349model . WX14;
                _qup . QUR010 = r349model . WX16;
                editRow (  );
            }
        }
        void read339 (   )
        {
            r339model . YQ05 = dt;
            r339 form = new r339 ( r339model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r339model = form . getModel;
                if ( r339model == null )
                    return;

                _qup . QUR004 = r339model . YQ10;
                _qup . QUR006 = r339model . YQ112;
                _qup . QUR005 = r339model . YQ119;
                _qup . QUR010 = r339model . YQ19;
                editRow ( );
            }
        }
        void read344 (   )
        {
            r344model . MZ007 = dt;
            r344 form = new r344 ( r344model );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                r344model = form . getModel;
                if ( r344model == null )
                    return;

                _qup . QUR004 = r344model . MZ016;
                _qup . QUR015 = r344model . MZ018;
                _qup . QUR010 = r344model . MZ021;
                _qup . QUR013 = r344model . MZ025;
                _qup . QUR016 = r344model . MZ105;
                editRow (  );
            }
        }
        void editRow (   )
        {
            if ( "add" . Equals ( conState ) )
            {
                addRow (  );
                tableView . Rows . Add ( selectRow );
            }
            else if ( "edit" . Equals ( conState ) )
            {
                selectRow . BeginEdit ( );
                addRow (  );
                selectRow . EndEdit ( );
            }
        }
        void addRow ( )
        {
            selectRow [ "QUR001" ] = _quo . QUO001;
            selectRow [ "QUR002" ] = _qup . QUR002;
            selectRow [ "QUR003" ] = _qup . QUR003;
            selectRow [ "QUR004" ] = _qup . QUR004;
            selectRow [ "QUR005" ] = _qup . QUR005;
            selectRow [ "QUR006" ] = _qup . QUR006;
            selectRow [ "QUR007" ] = _qup . QUR007;
            selectRow [ "QUR008" ] = _qup . QUR008;
            selectRow [ "QUR009" ] = _qup . QUR009;
            selectRow [ "QUR010" ] = _qup . QUR010;
            selectRow [ "QUR011" ] = _qup . QUR011;
            selectRow [ "QUR012" ] = _qup . QUR012;
            selectRow [ "QUR013" ] = _qup . QUR013;
            selectRow [ "QUR014" ] = _qup . QUR014;
            selectRow [ "QUR015" ] = _qup . QUR015;
            selectRow [ "QUR016" ] = _qup . QUR016;
        }
        #endregion

    }
}