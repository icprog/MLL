using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Environmental
{
    public partial class FormSanitationCheck :FormChild
    {
        MulaolaoLibrary.SanitationCheckHeaderEntity header=null;
        MulaolaoLibrary.SanitationCheckBodyEntity body=null;
        MulaolaoBll.Bll.SanitationCheckBll _bll=null;

        DataTable tableView;
        
        string state=string.Empty,columnName=string.Empty;
        bool result=false;
        int num=0;
        
        List<string> idxList=new List<string>();

        public FormSanitationCheck ( )
        {
            InitializeComponent ( );

            header = new MulaolaoLibrary . SanitationCheckHeaderEntity ( );
            body = new MulaolaoLibrary . SanitationCheckBodyEntity ( );
            _bll = new MulaolaoBll . Bll . SanitationCheckBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,View1 ,View2 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,View1 ,View2 } );

            toolStrip1 . Items . Remove ( toolReview );
            toolStrip1 . Items . Remove ( toolMaintain );
            toolStrip1 . Items . Remove ( toolLibrary );
            toolStrip1 . Items . Remove ( toolStorage );
            toolStrip1 . Items . Remove ( toolcopy );

            controlClear ( );
            controlUnEnable ( );

            Edit1 . DataSource = _bll . getTableWork ( );
            Edit1 . DisplayMember = "DAA002";
            Edit1 . ValueMember = "DAA002";

            Edit2 . DataSource = _bll . getTableGroup ( );
            Edit2 . DisplayMember = "DAA002";
            Edit2 . ValueMember = "DAA002";
        }

        #region Main
        protected override void select ( )
        {
            SelectAll . FromSanitationCheckQuery from = new SelectAll . FromSanitationCheckQuery ( );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                header . SAC001 = from . getCode;

                DataTable table = _bll . getTableQuery ( header . SAC001 );
                if ( table == null || table . Rows . Count < 1 )
                    return;
                txtUser . Text = table . Rows [ 0 ] [ "SAC002" ] . ToString ( );
                dtStart.Text = table . Rows [ 0 ] [ "SAC003" ] . ToString ( );
                dtEnt . Text = table . Rows [ 0 ] [ "SAC004" ] . ToString ( );

                tableView = _bll . getTableView ( header . SAC001 );
                gridControl1 . DataSource = tableView;

                toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = toolSelect . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }

            base . select ( );
        }
        protected override void add ( )
        {
            state = "add";

            toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = toolSelect . Enabled =toolPrint.Enabled=toolExport.Enabled= false;
            toolSave . Enabled = toolCancel . Enabled = true;

            controlEnable ( );
            controlClear ( );

            header.SAC001 = _bll . getCode ( );

            tableView = _bll . getTableView ( "1=2" );
            gridControl1 . DataSource = tableView;

            base . add ( );
        }
        protected override void update ( )
        {
            state = "edit";

            toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = toolSelect . Enabled= toolPrint . Enabled = toolExport . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            controlEnable ( );

            base . update ( );
        }
        protected override void delete ( )
        {
            result = _bll . Delete ( header . SAC001 );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                controlClear ( );
                controlUnEnable ( );
                toolAdd . Enabled = toolSelect . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = false;
            }
            else
                MessageBox . Show ( "删除失败" );

            base . delete ( );
        }
        protected override void save ( )
        {
            if ( getValue ( ) == false )
                return;

            if ( state . Equals ( "add" ) )
                result = _bll . Save ( header ,tableView );
            else
                result = _bll . Edit ( header ,tableView ,idxList );

            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                controlUnEnable ( );
                toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = toolSelect . Enabled =toolPrint.Enabled=toolExport.Enabled= true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            if ( state . Equals ( "add" ) )
                controlClear ( );
            controlUnEnable ( );
            toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = toolSelect . Enabled =toolPrint.Enabled=toolExport.Enabled= true;
            toolSave . Enabled = toolCancel . Enabled = false;

            base . cancel ( );
        }
        protected override void print ( )
        {
            base . print ( );
        }
        protected override void export ( )
        {
            base . export ( );
        }
        #endregion

        #region Method
        void controlUnEnable ( )
        {
            btn . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
        }
        void controlEnable ( )
        {
            btn . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
        }
        void controlClear ( )
        {
            txtUser . Text =  string . Empty;
            gridControl1 . DataSource = null;
        }
        bool getValue ( )
        {
            if ( string . IsNullOrEmpty ( txtUser . Text ) )
            {
                MessageBox . Show ( "请签字" );
                return false;
            }
            header . SAC002 = txtUser . Text;
            header . SAC003 = dtStart . Value;
            header . SAC004 = dtEnt . Value;

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            if ( tableView == null || tableView . Rows . Count < 1 )
            {
                MessageBox . Show ( "请录入" );
                return false;
            }


            return true;
        }
        #endregion

        #region Event
        private void btn_Click ( object sender ,EventArgs e )
        {
            if ( txtUser . Text . Equals ( Logins . username ) )
                txtUser . Text = string . Empty;
            else if ( txtUser . Text == string . Empty )
                txtUser . Text = Logins . username;
               
        }
        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "SAD005" ] ,10 );
        }
        private void gridControl1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
            {
                MessageBox . Show ( "请选择需要删除的内容" );
                return;
            }
            if ( e . KeyChar == ( char ) Keys . Enter && toolSave . Enabled == true )
            {
                if ( MessageBox . Show ( "确认删除?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return;
                body . idx = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] );
                if ( body . idx > 0 && !idxList . Contains ( body . idx . ToString ( ) ) )
                    idxList . Add ( body . idx . ToString ( ) );
                tableView . Rows . Remove ( row );
                gridControl1 . RefreshDataSource ( );
            }
        }
        private void gridView1_PopupMenuShowing ( object sender ,DevExpress . XtraGrid . Views . Grid . PopupMenuShowingEventArgs e )
        {
            gridControl1 . ContextMenuStrip = null;
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            DevExpress . XtraGrid . Views . Grid . ViewInfo . GridHitInfo hitInfo = view . CalcHitInfo ( e . Point );
            num = hitInfo . RowHandle;
            if ( num < 0 || num > gridView1 . DataRowCount - 1 )
                return;
            DataRow row = gridView1 . GetDataRow ( num );
            columnName = hitInfo . Column . Name;
            if ( row != null &&  hitInfo . Column . Name == "SAD019" )
            {
                gridControl1 . ContextMenuStrip = contextMenuStrip1;
                if ( gridView1 . OptionsBehavior . Editable == false )
                {
                    contextMenuStrip1 . Items [ 0 ] . Visible = false;
                    contextMenuStrip1 . Items [ 1 ] . Visible = false;
                }
                else
                {
                    contextMenuStrip1 . Items [ 0 ] . Visible = true;
                    contextMenuStrip1 . Items [ 1 ] . Visible = true;
                }
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            num = e . RowHandle;
        }
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );

            //导入
            if ( e . ClickedItem == ( ( ContextMenuStrip ) sender ) . Items [ 0 ] )
            {
                if ( columnName . Equals ( "SAD019" ) )
                {
                    byte [ ] bytes = ReadOrWriteImageOfPicutre . ReadColumn ( );
                    if ( bytes != null )
                    {
                        DataRow row = tableView . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "SAD019" ] = bytes;
                        row . EndEdit ( );
                    }
                }
            }
            //删除
            if ( e . ClickedItem == ( ( ContextMenuStrip ) sender ) . Items [ 1 ] )
            {
                DataRow row = tableView . Rows [ num ];
                row . BeginEdit ( );
                row [ "SAD019" ] = null;
                row . EndEdit ( );
            }
        }
        #endregion
    }
}


//DECLARE @SQL NVARCHAR ( MAX);
//SELECT @SQL=ISNULL(@SQL+',','')+QUOTENAME(SAD008) FROM R_SAD GROUP BY SAD008
//DECLARE @STR NVARCHAR ( MAX)
//SET @STR='
//SELECT* FROM ( SELECT SAD001 ,SAD002,SAD003,SAD004,SAD005,SAD006,SAD007,SAD008,SAD009 FROM R_SAD) A PIVOT ( MAX(SAD006) FOR SAD008 IN ('+@SQL+')) AS T'
//EXEC ( @STR)


