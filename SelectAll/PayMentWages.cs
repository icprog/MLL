using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class PayMentWages : Form
    {
        public PayMentWages ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string strWhere = "1=1";
        DataTable tableQuery; MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );
        MulaolaoLibrary.ManagePayrollLibrary _model = new MulaolaoLibrary.ManagePayrollLibrary( );
        int count = 0;
        decimal pay = 0M;
        string cn1 = "", cn2 = "";
        public string sign = "", idxSt = "";
        
        private void PayMentWages_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
        }

        //Query
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "日期不可为空" );
                return;
            }
            if ( !string.IsNullOrEmpty( idxSt ) )
                strWhere = strWhere + " AND idx NOT IN (" + idxSt + ")";
            _model.XZ013 = dateTimePicker1.Value;
            if ( sign == "1" )
                strWhere = strWhere + " AND XZ014='生产部' AND XZ028='1'";              
            else if ( sign == "2" )
                strWhere = strWhere + " AND XZ014='行政' AND XZ028='1'";
            else if ( sign == "3" )
                strWhere = strWhere + " AND XZ014='生产部' AND XZ028='2'";
            else if ( sign == "4" )
                strWhere = strWhere + " AND XZ014='行政' AND XZ028='2'";
            tableQuery = _bll.GetDataTableOfPay( _model.XZ013 ,strWhere );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            textBox1.Text = "";
        }
        //checkAll
        private void button3_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                gridView1.GetDataRow( i )["check"] = true;
                count++;
            }
        }
        //unCheckAll
        private void button4_Click ( object sender ,EventArgs e )
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
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( count > 0 )
            {
                checkOut( );
                cn1 = Math.Round( pay ,2 ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
        void checkOut ( )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                DataRow row = gridView1 . GetDataRow ( i );
                if ( row [ "check"].ToString( ) == "True" )
                {
                    pay += ( string . IsNullOrEmpty ( row [ "U3" ] . ToString ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( row [ "U3" ] . ToString ( ) ) ,2 ) );

                    if ( cn2 == "" )
                        cn2 = gridView1.GetDataRow( i )["idx"].ToString( );
                    else
                        cn2 = cn2 + "," + gridView1.GetDataRow( i )["idx"].ToString( );
                }
            }
        }
        //Cancel
        private void button6_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                {
                    gridView1.GetDataRow( num )["check"] = false;
                    if ( count > 0 )
                        count--;
                }
                else
                {
                    gridView1.GetDataRow( num )["check"] = true;
                    count++;
                }
            }
        }

        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yyyy年MM月" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
    }
}
