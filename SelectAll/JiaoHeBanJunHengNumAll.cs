using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class JiaoHeBanJunHengNumAll : Form
    {
        public JiaoHeBanJunHengNumAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.JiaoMiDuJunHenTableBll bll = new MulaolaoBll.Bll.JiaoMiDuJunHenTableBll( );
        DataTable tableQuery;
        List<string> listCount = new List<string>( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void JiaoHeBanJunHengNumAll_Load ( object sender ,EventArgs e )
        {
            query( );
        }

        void query ( )
        {
            tableQuery = bll.GetDataTableNum( );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
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

        private void gridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                if ( MessageBox.Show( "确认生成?" ,"生成" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            listCount.Add( gridView1.GetDataRow( i )["JM90"].ToString( ) );
                        }
                    }
                    if ( listCount.Count < 1 )
                        return;
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( listCount );
                    if ( PassDataBetweenForm != null )
                    {
                        PassDataBetweenForm( this ,args );
                    }
                    this.Close( );
                }
            }
        }
    }
}
