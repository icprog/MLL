using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using Mulaolao . Class;

namespace Mulaolao . Contract
{
    public partial class FormInvenAdSheet :FormChild
    {
        MulaolaoBll.Bll.InvenAdSheetBll _bll=null;
        MulaolaoLibrary.InvenAdSheetINAEntity model=null;
        MulaolaoLibrary.InvenAdSheetINBEntity body=null;
        DateTime dt;bool result=false;string state=string.Empty,weihu=string.Empty;
        DataTable tableView;
        List<string> idxList=new List<string>();

        public FormInvenAdSheet ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . InvenAdSheetBll ( );
            model = new MulaolaoLibrary . InvenAdSheetINAEntity ( );
            body = new MulaolaoLibrary . InvenAdSheetINBEntity ( );

            toolStrip1 . Items . Remove ( toolPrint );
            toolStrip1 . Items . Remove ( toolExport );
            toolStrip1 . Items . Remove ( toolLibrary );
            toolStrip1 . Items . Remove ( toolStorage );
            toolStrip1 . Items . Remove ( toolcopy );

            controlUnEnable ( );
            dt = MulaolaoBll . Drity . GetDt ( );
            label45 . Visible = false;
        }
        
        #region Main
        protected override void select ( )
        {
            SelectAll . FormInvenAdSheetQueryAll from = new SelectAll . FormInvenAdSheetQueryAll ( );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                DataRow row = from . getRow;
                txtINA001 . Text = row [ "INA001" ] . ToString ( );
                txtINA003 . Text = row [ "INA003" ] . ToString ( );
                txtINA004 . Text = row [ "INA004" ] . ToString ( );
                txtINA005 . Text = row [ "INA005" ] . ToString ( );

                tableView = _bll . getTableView ( txtINA001 . Text );
                gridControl2 . DataSource = tableView;
                gridView2 . BestFitColumns ( );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;

                if ( row [ "RES05" ] == null || row [ "RES05" ] . ToString ( ) == string . Empty )
                {
                    label45 . Visible = false;
                    toolMaintain . Enabled = false;
                }
                else
                    label45 . Visible = true;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            state = "add";
            controlClear ( );
            controlEnable ( );
            txtINA001 . Text = _bll . getCode ( );
            txtINA004 . Text = dt . ToString ( "yyyy-MM-dd" );
            txtINA005 . Text = Logins . username;

            tableView = _bll . getTableView ( txtINA001 . Text );
            gridControl2 . DataSource = tableView;
            gridView2 . BestFitColumns ( );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled =  false;
            toolSave . Enabled = toolCancel . Enabled = true;

            if ( label45 . Visible )
                label45 . Visible = false;

            base . add ( );
        }
        protected override void update ( )
        {
            if ( label45 . Visible )
            {
                MessageBox . Show ( "请维护" );
                return;
            }
            state = "edit";
            controlEnable ( );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;

            base . update ( );
        }
        protected override void delete ( )
        {
            if ( label45 . Visible )
            {
                MessageBox . Show ( "已执行,不允许删除" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtINA001 . Text ) )
            {
                MessageBox . Show ( "请选择需要删除的内容" );
                return ;
            }

            result = _bll . Delete ( txtINA001 . Text );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                controlClear ( );
                controlUnEnable ( );

                toolSelect . Enabled = toolAdd . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                MessageBox . Show ( "删除失败,请重试" );

            base . delete ( );
        }
        protected override void revirw ( )
        {
            Reviews ( "INA001" ,txtINA001 . Text ,"R_INA" ,this ,string . Empty ,"R_465" ,false ,false ,dt );
            SpecialPowers sp = new SpecialPowers ( );
            result = sp . reviewImple ( "R_465" ,txtINA001 . Text );
            if ( result == true )
            {
                label45 . Visible = true;
                toolSelect . Enabled = toolAdd . Enabled = toolMaintain . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled =  toolSave . Enabled = toolCancel . Enabled = false;

                result = _bll . writeTo ( txtINA001 . Text );
                if ( result == false )
                    MessageBox . Show ( "写入464调整数量失败,请维护重新保存写入" );
            }
            else
                label45 . Visible = false;

            base . revirw ( );
        }
        protected override void save ( )
        {
            if ( getValue ( ) == false )
                return;

            if ( state . Equals ( "add" ) )
                result = _bll . Add ( tableView ,model );
            else
                result = _bll . Edit ( tableView ,model ,idxList );

            if ( result )
            {
                MessageBox . Show ( "成功保存" );

                controlUnEnable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = true;
                toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
                if ( label45 . Visible )
                    toolMaintain . Enabled = true;

                tableView = _bll . getTableView ( txtINA001 . Text );
                gridControl2 . DataSource = tableView;
                gridView2 . BestFitColumns ( );

                if ( weihu . Equals ( "1" ) )
                {
                    result = _bll . writeTo ( txtINA001 . Text );
                    if ( result == false )
                        MessageBox . Show ( "写入464调整数量失败,请维护重新保存写入" );
                }
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            if ( state . Equals ( "add" ) )
                controlClear ( );
            controlUnEnable ( );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled =  true;
            toolSave . Enabled = toolCancel . Enabled = toolMaintain . Enabled = false;

            base . cancel ( );
        }
        protected override void maintain ( )
        {
            if ( label45 . Visible )
            {
                controlEnable ( );

                weihu = "1";
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
            }

            base . maintain ( );
        }
        #endregion
        
        #region Event
        private void gridView2_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }
        private void btnCode_ButtonClick ( object sender ,DevExpress . XtraEditors . Controls . ButtonPressedEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( string . IsNullOrEmpty ( txtINA003 . Text ) )
            {
                MessageBox . Show ( "请选择出入库" );
                return;
            }

            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            if ( tableView != null && tableView . Rows . Count > 0 )
            {
                body . INB004 = tableView . Rows [ 0 ] [ "INB004" ] . ToString ( );
                if ( body . INB004 == string . Empty && txtINA003 . Text . Equals ( "出库" ) )
                {
                    MessageBox . Show ( "出入库记录请分开开调整单" );
                    return;
                }
                else if ( body . INB004 != string . Empty && txtINA003 . Text . Equals ( "入库" ) )
                {
                    MessageBox . Show ( "出入库记录请分开开调整单" );
                    return;
                }

            }
           
            Other . FormInvenAdQuery from = new Other . FormInvenAdQuery ( txtINA003 . Text );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                DataRow  rows = from . getRow;
                if ( txtINA003 . Text . Equals ( "出库" ) )
                {
                    if ( row == null )
                    {
                        row = tableView . NewRow ( );
                        row [ "INB002" ] = rows [ "AD01" ];
                        row [ "INB003" ] = rows [ "AD17" ];
                        row [ "INB004" ] = rows [ "AD04" ];
                        row [ "INB005" ] = rows [ "AD02" ];
                        row [ "INB006" ] = rows [ "AD03" ];
                        row [ "INB007" ] = rows [ "AD05" ];
                        row [ "INB008" ] = rows [ "AD06" ];
                        row [ "INB009" ] = rows [ "AD07" ];
                        row [ "INB010" ] = rows [ "AD09" ];
                        row [ "INB011" ] = rows [ "AD11" ];
                        row [ "INB012" ] = rows [ "AD12" ];
                        tableView . Rows . Add ( row );
                    }
                    else
                    {
                        row [ "INB002" ] = rows [ "AD01" ];
                        row [ "INB003" ] = rows [ "AD17" ];
                        row [ "INB004" ] = rows [ "AD04" ];
                        row [ "INB005" ] = rows [ "AD02" ];
                        row [ "INB006" ] = rows [ "AD03" ];
                        row [ "INB007" ] = rows [ "AD05" ];
                        row [ "INB008" ] = rows [ "AD06" ];
                        row [ "INB009" ] = rows [ "AD07" ];
                        row [ "INB010" ] = rows [ "AD09" ];
                        row [ "INB011" ] = rows [ "AD11" ];
                        row [ "INB012" ] = rows [ "AD12" ];
                    }
                }
                else if ( txtINA003 . Text . Equals ( "入库" ) )
                {
                    if ( row == null )
                    {
                        row = tableView . NewRow ( );
                        row [ "INB002" ] = rows [ "AC18" ];
                        row [ "INB003" ] = rows [ "AC16" ];
                        row [ "INB004" ] = string . Empty;
                        row [ "INB005" ] = rows [ "AC01" ];
                        row [ "INB006" ] = rows [ "AC02" ];
                        row [ "INB007" ] = rows [ "AC03" ];
                        row [ "INB008" ] = rows [ "AC04" ];
                        row [ "INB009" ] = rows [ "AC05" ];
                        row [ "INB010" ] = rows [ "AC07" ];
                        row [ "INB011" ] = rows [ "AC09" ];
                        row [ "INB012" ] = rows [ "AC10" ];
                        tableView . Rows . Add ( row );
                    }
                    else
                    {
                        row [ "INB002" ] = rows [ "AC18" ];
                        row [ "INB003" ] = rows [ "AC16" ];
                        row [ "INB004" ] = string . Empty;
                        row [ "INB005" ] = rows [ "AC01" ];
                        row [ "INB006" ] = rows [ "AC02" ];
                        row [ "INB007" ] = rows [ "AC03" ];
                        row [ "INB008" ] = rows [ "AC04" ];
                        row [ "INB009" ] = rows [ "AC05" ];
                        row [ "INB010" ] = rows [ "AC07" ];
                        row [ "INB011" ] = rows [ "AC09" ];
                        row [ "INB012" ] = rows [ "AC10" ];
                    }
                }
            }
            gridControl2 . RefreshDataSource ( );
        }
        private void gridControl2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( e . KeyChar == ( char ) Keys . Enter )
            {
                if ( row == null )
                {
                    MessageBox . Show ( "请选择需要删除的内容" );
                    return;
                }
                if ( MessageBox . Show ( "确认删除?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return;
                body . id = string . IsNullOrEmpty ( row [ "id" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "id" ] );
                if ( body . id > 0 && !idxList . Contains ( body . id . ToString ( ) ) )
                    idxList . Add ( body . id . ToString ( ) );
                tableView . Rows . Remove ( row );
            }
        }
        #endregion

        #region Method
        void controlClear ( )
        {
            txtINA001 . Text = /*txtINA002 . Text =*/ txtINA003 . Text = txtINA004 . Text = txtINA005 . Text = string . Empty;
            gridControl2 . DataSource = null;
        }
        void controlUnEnable ( )
        {
            /*txtINA002 . Enabled =*/ txtINA003 . Enabled = false;
            gridView2 . OptionsBehavior . Editable = false;
            
        }
        void controlEnable ( )
        {
            /*txtINA002 . Enabled =*/ txtINA003 . Enabled = true;
            gridView2 . OptionsBehavior . Editable = true;
        }
        bool getValue ( )
        {
            result = true; 
            if ( string . IsNullOrEmpty ( txtINA003 . Text ) )
            {
                MessageBox . Show ( "请选择出入库" );
                return false;
            }

            model . INA001 = txtINA001 . Text;
            model . INA003 = txtINA003 . Text;
            model . INA004 = Convert . ToDateTime ( txtINA004 . Text );
            model . INA005 = txtINA005 . Text;

            gridView2 . CloseEditor ( );
            gridView2 . UpdateCurrentRow ( );

            if ( tableView == null || tableView . Rows . Count < 1 )
            {
                MessageBox . Show ( "请录入调整单" );
                return false;
            }

            for ( int i = 0 ; i < gridView2 . RowCount ; i++ )
            {
                DataRow row = gridView2 . GetDataRow ( i );
                if ( row == null )
                    continue;
                row . ClearErrors ( );
                if ( row [ "INB013" ] == null || row [ "INB013" ] . ToString ( ) == string . Empty )
                {
                    row . SetColumnError ( "INB013" ,"请录入调整物料数量" );
                    result = false;
                    break;
                }
                //if ( row [ "INB015" ] == null || row [ "INB015" ] . ToString ( ) == string . Empty )
                //{
                //    row . SetColumnError ( "INB015" ,"请录入调整产品数量" );
                //    result = false;
                //    break;
                //}
                if ( row [ "INB014" ] == null || row [ "INB014" ] . ToString ( ) == string . Empty )
                {
                    row . SetColumnError ( "INB014" ,"请选择+/-" );
                    result = false;
                    break;
                }
                if ( row [ "INB016" ] == null || row [ "INB016" ] . ToString ( ) == string . Empty )
                {
                    row . SetColumnError ( "INB016" ,"请选择+/-" );
                    result = false;
                    break;
                }
            }

            return result;
        }
        #endregion

    }
}
