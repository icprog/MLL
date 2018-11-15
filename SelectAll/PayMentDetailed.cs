using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class PayMentDetailed : Form
    {
        public PayMentDetailed (  )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        //string strWhere = "1=1";
        public string idxSt = "";
         
        DataTable tableQuery;
        int count = 0;
        decimal pay = 0M, payOf = 0M;
        string cn1 = "", cn2 = "", cn3 = "";

        private void PayMentDetailed_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            query( );
        }

        void query ( )
        {
            //if ( !string.IsNullOrEmpty( idxSt ) )
            //    strWhere = strWhere + " AND B.idx NOT IN (" + idxSt + ")";
            tableQuery = _bll.GetDataTableSupplier( );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {

            if ( gridView1 . FocusedRowHandle >= 0 && gridView1 . FocusedRowHandle <= gridView1 . RowCount - 1 )
            {
                int num = gridView1 . FocusedRowHandle;
                if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = false;
                    if ( count > 0 )
                        count--;
                }
                else
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = true;
                    count++;
                }
            }
        }

        //checkAll
        private void button1_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "false" )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                    count++;
                }
            }
        }
        //unChekcAll
        private void button2_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                    count = 0;
                }
            }
        }
        //OK

        private void button3_Click ( object sender ,EventArgs e )
        {
            checkOut ( );
            cn1 = pay . ToString ( );
            cn3 = payOf . ToString ( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . Close ( );
        }
        void checkOut ( )
        {
            //int [ ] rows = gridView1 . GetSelectedRows ( );
            //if ( rows != null )
            //{
            DataRow row;
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                row = gridView1 . GetDataRow ( i );
                if ( row [ "check" ] . ToString ( ) == "True" )
                {
                    pay += string . IsNullOrEmpty ( row [ "WZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ012" ] . ToString ( ) ) + ( string . IsNullOrEmpty ( row [ "WZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ013" ] . ToString ( ) ) ) + ( string . IsNullOrEmpty ( row [ "WZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ014" ] . ToString ( ) ) );
                    payOf += string . IsNullOrEmpty ( row [ "WY002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WY002" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( cn2 ) )
                        cn2 = row [ "idx" ] . ToString ( );
                    else
                        cn2 = cn2 + "," + row [ "idx" ] . ToString ( );
                }
            }
            //}
        }
        //Cancel
        private void button4_Click ( object sender ,EventArgs e )
        {
            //this . DialogResult = DialogResult . Cancel;
        }
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            cn1 = ( string . IsNullOrEmpty ( row [ "WZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ012" ] . ToString ( ) ) + ( string . IsNullOrEmpty ( row [ "WZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ013" ] . ToString ( ) ) ) + ( string . IsNullOrEmpty ( row [ "WZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WZ014" ] . ToString ( ) ) ) ) . ToString ( );
            cn2 = row [ "idx" ] . ToString ( );
            cn3 = ( string . IsNullOrEmpty ( row [ "WY002" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "WY002" ] . ToString ( ) ) ) . ToString ( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . Close ( );
        }

    }
}
