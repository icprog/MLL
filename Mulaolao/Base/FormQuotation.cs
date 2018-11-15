using DevExpress . XtraEditors;
using Mulaolao . Class;
using Mulaolao . QuoForms;
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

        DataTable tableView;
        DataRow selectRow;int selectIdx;
        List<string> idxList=new List<string>();
        string state="",strWhere="";

        bool result=false;

        public FormQuotation ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );
            _quo = new MulaolaoLibrary . QuoEntity ( );
            _qup = new MulaolaoLibrary . QupEntity ( );
            controlUnEnable ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
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
                txtQUP003 . Text = "R_195";
                break;
                case "热转印":
                txtQUP003 . Text = "R_196";
                break;
                case "装运.代理":
                txtQUP003 . Text = "R_243";
                break;
                case "胶合板":
                txtQUP003 . Text = "R_338";
                break;
                case "密度板":
                txtQUP003 . Text = "R_338";
                break;
                case "木材":
                txtQUP003 . Text = "R_341";
                break;
                case "车木件":
                txtQUP003 . Text = "R_342";
                break;
                case "铁件":
                txtQUP003 . Text = "R_343";
                break;
                case "塑料件":
                txtQUP003 . Text = "R_347";
                break;
                case "喷漆工资":
                txtQUP003 . Text = "R_519.495";
                break;
                case "油漆款":
                txtQUP003 . Text = "R_519.339";
                break;
                case "滚漆款":
                txtQUP003 . Text = "R_519.344";
                break;
                case "包装材料":
                txtQUP003 . Text = "R_349.347";
                break;
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdx = gridView1 . FocusedRowHandle;
               selectRow = gridView1 . GetFocusedDataRow ( );
            if ( selectRow == null )
                return;
            if ( selectRow [ "QUR003" ] . ToString ( ) . Equals ( "R_195" ) )
            {
                r195Model = new MulaolaoLibrary . ChanPinZhiBiaoLibrary ( );
                r195Model . CP06 = selectRow [ "QUR004" ] . ToString ( );
                r195Model . CP07 = selectRow [ "QUR015" ] . ToString ( );
                r195Model . CP09 = selectRow [ "QUR005" ] . ToString ( );
                r195Model . CP11 = string . IsNullOrEmpty ( selectRow [ "QUR013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR013" ] . ToString ( ) );
                r195Model . CP13 = string . IsNullOrEmpty ( selectRow [ "QUR006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( selectRow [ "QUR006" ] . ToString ( ) );
            }
        }
        #endregion

        #region Method
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
            }
            gridControl1 . DataSource = null;
        }
        bool getValue ( )
        {
            if ( string . IsNullOrEmpty ( txtQUO007 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
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
        }
        #endregion

        #region Click
        private void btnAdd_Click ( object sender ,System . EventArgs e )
        {
            DataRow row = null;
            if ( string . IsNullOrEmpty ( txtQUP002 . Text ) )
            {
                XtraMessageBox . Show ( "请选择合同代号和材种" );
                return;
            }
            if ( txtQUP003 . Text . Equals ( "R_195" ) )
            {
                r195Model = new MulaolaoLibrary . ChanPinZhiBiaoLibrary ( );
                r195 form = new r195 ( r195Model );
                if ( form . ShowDialog ( ) == DialogResult . OK )
                {
                    r195Model = form . getModel;
                    if ( r195Model == null )
                        return;
                    row = tableView . NewRow ( );
                    row [ "QUR001" ] = _quo . QUO001;
                    row [ "QUR002" ] = txtQUP002 . Text;
                    row [ "QUR003" ] = txtQUP003 . Text;
                    row [ "QUR004" ] = r195Model . CP06;
                    row [ "QUR005" ] = r195Model . CP09;
                    row [ "QUR006" ] = r195Model . CP13;
                    row [ "QUR007" ] = string . Empty;
                    row [ "QUR008" ] = string . Empty;
                    row [ "QUR009" ] = string . Empty;
                    row [ "QUR010" ] = 0;
                    row [ "QUR011" ] = 0;
                    row [ "QUR012" ] = 0;
                    row [ "QUR013" ] = r195Model . CP11;
                    row [ "QUR014" ] = 0;
                    row [ "QUR015" ] = r195Model . CP07;
                    tableView . Rows . Add ( row );
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        private void btnEdit_Click ( object sender ,System . EventArgs e )
        {
            DataRow row;
            if ( txtQUP003 . Text . Equals ( "R_195" ) )
            {
                r195 form = new r195 ( r195Model );
                if ( form . ShowDialog ( ) == DialogResult . OK )
                {
                    r195Model = form . getModel;
                    if ( r195Model == null )
                        return;
                    row = tableView . Rows [ selectIdx ];
                    row . BeginEdit ( );
                    row [ "QUR002" ] = txtQUP002 . Text;
                    row [ "QUR003" ] = txtQUP003 . Text;
                    row [ "QUR004" ] = r195Model . CP06;
                    row [ "QUR005" ] = r195Model . CP09;
                    row [ "QUR006" ] = r195Model . CP13;
                    row [ "QUR007" ] = string . Empty;
                    row [ "QUR008" ] = string . Empty;
                    row [ "QUR009" ] = string . Empty;
                    row [ "QUR010" ] = 0;
                    row [ "QUR011" ] = 0;
                    row [ "QUR012" ] = 0;
                    row [ "QUR013" ] = r195Model . CP11;
                    row [ "QUR014" ] = 0;
                    row [ "QUR015" ] = r195Model . CP07;
                    row . EndEdit ( );
                    gridControl1 . RefreshDataSource ( );
                }
            }
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

    }
}