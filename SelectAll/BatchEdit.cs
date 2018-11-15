using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace SelectAll
{
    public partial class BatchEdit : Form
    {
        public BatchEdit ( )
        {
            InitializeComponent( );


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

        MulaolaoBll.Bll.ChanPinGaiShanBll bll = new MulaolaoBll.Bll.ChanPinGaiShanBll( );
        public string number = "";
        List<string> idxList = new List<string>( );
        private void BatchEdit_Load ( object sender ,EventArgs e )
        {
            textBox1.Text = number;
        }
        DataTable tableQueryOne, tableQueryTwo, tableQueryTre, tableQueryFor;
        
        //choice the num
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.DataRowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
                {
                    idxList.Add( gridView1.GetDataRow( i )["PQF01"].ToString( ) );
                }
            }
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            SelectAll.BatchEditNumChoice batCho = new BatchEditNumChoice( );
            batCho.StartPosition = FormStartPosition.CenterScreen;
            batCho.strList = idxList;
            batCho.num = textBox1.Text;
            batCho.PassDataBetweenForm += new BatchEditNumChoice.PassDataBetweenFormHandler( barcho_PassDataBetweenForm );
            idxList.Clear( );
            batCho.ShowDialog( );

            if ( idxList.Count > 0 )
            {
                string str = "";
                foreach ( string s in idxList )
                {
                    if ( str == "" )
                        str = "'" + s + "'";
                    else
                        str = str + "," + "'" + s + "'";
                }
                tableQueryOne = bll.GetDataTableOfNumOf( str );
                gridControl1.DataSource = tableQueryOne;
                tableQueryTwo = bll.GetDataTableOfMaterial( str );
                gridControl2.DataSource = tableQueryTwo;
                tableQueryTre = bll.GetDataTableOfAccess( str );
                gridControl3.DataSource = tableQueryTre;
                tableQueryFor = bll.GetDataTableOfWorkShop( str );
                gridControl4.DataSource = tableQueryFor;
            }
        }
        private void barcho_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.ConOne == "1" )
                idxList = e.List;
            else if ( e.ConOne == "2" )
                idxList.Clear( );
        }

        //Sure
        private void button2_Click ( object sender ,EventArgs e )
        {
            gridView2.ClearColumnsFilter( );
            gridView2.UpdateCurrentRow( );
            gridView3.ClearColumnsFilter( );
            gridView3.UpdateCurrentRow( );
            gridView4.ClearColumnsFilter( );
            gridView4.UpdateCurrentRow( );
            idxList.Clear( );
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                idxList.Add( gridView1.GetDataRow( i )["PQF01"].ToString( ) );
            }

            bool result = bll.Update( tableQueryTwo ,tableQueryTre ,tableQueryFor ,idxList );
            if ( result == true )
            {
                MessageBox.Show( "成功批量编辑" );
                this.Close( );
            }
            else
                MessageBox.Show( "批量编辑失败,请重试" );
        }
        //Cancel
        private void button3_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

    }
}
