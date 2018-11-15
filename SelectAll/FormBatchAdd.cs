using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FormBatchAdd :Form
    {
        MulaolaoBll.Bll.ChanPinGaiShanBll bll =null; List<string> idxList = new List<string>( );

        DataTable tableQueryOne, tableQueryTwo, tableQueryTre, tableQueryFor;

        public FormBatchAdd ( string number )
        {
            InitializeComponent ( );

            this . textBox1 . Text = number;
            bll = new MulaolaoBll . Bll . ChanPinGaiShanBll ( );

            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in gridView1 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in gridView2 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in gridView3 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in gridView4 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
        }

        //确定
        private void btnSure_Click ( object sender ,EventArgs e )
        {
            gridView2 . ClearColumnsFilter ( );
            gridView2 . UpdateCurrentRow ( );
            gridView3 . ClearColumnsFilter ( );
            gridView3 . UpdateCurrentRow ( );
            gridView4 . ClearColumnsFilter ( );
            gridView4 . UpdateCurrentRow ( );
            idxList . Clear ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                idxList . Add ( gridView1 . GetDataRow ( i ) [ "PQF01" ] . ToString ( ) );
            }

            bool result = bll . BatchAdd ( tableQueryTwo ,tableQueryTre ,tableQueryFor ,idxList );
            if ( result == true )
            {
                MessageBox . Show ( "成功批量添加" );
                this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "批量添加失败" );
        }
        //取消
        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }
        //choise the nums
        private void btnChoise_Click ( object sender ,EventArgs e )
        {
            if ( gridView1 . DataRowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                {
                    idxList . Add ( gridView1 . GetDataRow ( i ) [ "PQF01" ] . ToString ( ) );
                }
            }
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "货号不可为空" );
                return;
            }
            SelectAll . BatchEditNumChoice batCho = new BatchEditNumChoice ( );
            batCho . StartPosition = FormStartPosition . CenterScreen;
            batCho . strList = idxList;
            batCho . num = textBox1 . Text;
            batCho . PassDataBetweenForm += new BatchEditNumChoice . PassDataBetweenFormHandler ( barcho_PassDataBetweenForm );
            idxList . Clear ( );
            batCho . ShowDialog ( );

            if ( idxList . Count > 0 )
            {
                string str = "";
                foreach ( string s in idxList )
                {
                    if ( str == "" )
                        str = "'" + s + "'";
                    else
                        str = str + "," + "'" + s + "'";
                }
                tableQueryOne = bll . GetDataTableOfNumOf ( str );
                gridControl1 . DataSource = tableQueryOne;
                tableQueryTwo = bll . tableOne ( );
                gridControl2 . DataSource = tableQueryTwo;
                tableQueryTre = bll . tableTwo ( );
                gridControl3 . DataSource = tableQueryTre;
                tableQueryFor = bll . tableTre ( );
                gridControl4 . DataSource = tableQueryFor;
            }
        }
        private void barcho_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConOne == "1" )
                idxList = e . List;
            else if ( e . ConOne == "2" )
                idxList . Clear ( );
        }
        private void repositoryItemComboBox1_EditValueChanged ( object sender ,EventArgs e )
        {
            DevExpress . XtraEditors . BaseEdit edit = gridView2 . ActiveEditor;
            if ( gridView2 . FocusedColumn . FieldName == "GS71" )
            {
                string result = string . Empty;
                switch ( edit.EditValue.ToString() )
                {
                    case "成品委外":
                    result = "R_195";
                    break;
                    case "热转印":
                    result = "R_196";
                    break;
                    case "装运.代理":
                    result = "R_243";
                    break;
                    case "胶合板":
                    result = "R_338";
                    break;
                    case "密度板":
                    result = "R_338";
                    break;
                    case "木材":
                    result = "R_341";
                    break;
                    case "车木件":
                    result = "R_342";
                    break;
                    case "铁件":
                    result = "R_343";
                    break;
                    case "塑料件":
                    result = "R_347";
                    break;
                    case "喷漆工资":
                    result = "R_519.495";
                    break;
                    case "油漆款":
                    result = "R_519.339";
                    break;
                    case "滚漆款":
                    result = "R_519.344";
                    break;
                    case "包装材料":
                    result = "R_349.347";
                    break;
                    case "/":
                    result = "/";
                    break;
                }
                gridView2 . SetFocusedRowCellValue ( "GS70" ,result );
            }
        }
    }
}
