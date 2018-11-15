using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class BatchEditNumChoice : Form
    {
        public BatchEditNumChoice ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.ChanPinGaiShanBll bll = new MulaolaoBll.Bll.ChanPinGaiShanBll( );
        public List<string> strList;
        public string num = "";
        DataTable tableQuery;

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void BatchEditNumChoice_Load ( object sender ,EventArgs e )
        {
            query( );
            if ( strList.Count > 0 )
            {
                if ( tableQuery != null && gridView1.RowCount>0 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        foreach ( string str in strList )
                        {
                            if ( gridView1.GetDataRow( i )["PQF01"].ToString( ) == str )
                                gridView1.GetDataRow( i )["check"] = true;
                        }
                    }
                }
            }
        }

        void query ( )
        {
            tableQuery = bll.GetDataTableOfNum( num );
            tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }

        string cn1 = "";
        //Sure
        private void button1_Click ( object sender ,EventArgs e )
        {
            strList.Clear( );
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    strList.Add( gridView1.GetDataRow( i )["PQF01"].ToString( ) );
            }

            if ( strList.Count < 1 )
            {
                MessageBox.Show( "请选择需要批量编辑的流水" );
                return;
            }
            cn1 = "1";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,strList );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        //Cancel
        private void button2_Click ( object sender ,EventArgs e )
        {
            cn1 = "2";
            strList.Clear( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,strList );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
