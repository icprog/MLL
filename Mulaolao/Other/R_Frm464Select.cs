using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace Mulaolao . Other
{
    public partial class R_Frm464Select : Form
    {
        public R_Frm464Select ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        private void R_Frm464Select_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            //gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }
        //全选
        private void button1_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                gridView1.GetDataRow( i )["check"] = true;
            }
        }
        //取消全选
        private void button2_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }
        //确定
        public List<string> all = new List<string>( );
        private void button3_Click ( object sender ,EventArgs e )
        {
            all.Clear( );
            int [ ] rows = gridView1 . GetSelectedRows ( );
            if ( rows . Length > 0 )
            {
                for ( int i = 0 ; i < rows . Length ; i++ )
                {
                    //if ( gridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                    all . Add ( gridView1 . GetRowCellValue ( rows [ i ] ,"AC18" ) . ToString ( ) );
                }
            }
            //for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            //{
            //    if ( gridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
            //        all . Add ( gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) );
            //}
            this .Close( );
        }
        //取消
        private void button4_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.FocusedRowHandle < 0 )
                    gridView1.FocusedRowHandle = 0;
                else
                {
                    if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                        gridView1.GetDataRow( num )["check"] = false;
                    else
                        gridView1.GetDataRow( num )["check"] = true;
                }
            }
            
        }
    }
}
