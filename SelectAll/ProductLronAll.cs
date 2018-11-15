using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;
using System . Collections . Generic;
using Mulaolao;

namespace SelectAll
{
    public partial class ProductLronAll : Form
    {
        public ProductLronAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string num = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        Dictionary<string ,string> dicIdx = new Dictionary<string ,string>( );
        //RepositoryItemComboBox combobox = new RepositoryItemComboBox( );

        private void ProductLronAll_Load ( object sender ,EventArgs e )
        {
            //combobox.Items.Clear( );
            repositoryItemComboBox1.Items.AddRange( new string[] { "塑料件" ,"包装辅料" ,"其它材料" } );
            //PJ.ColumnEdit = combobox;
            query( );
        }

        void query ( )
        {
            DataTable daQuery = bll.GetDataTablePqsTwo( num );
            gridControl1.DataSource = daQuery;      
        }

        private void ValueAll ( )
        {
            dicIdx.Clear( );
            decimal AccountsPayablePlastic = 0, AlreadyPaidPlastic = 0, AccountsPayableOther = 0, AlreadyPaidOther = 0,
            AccountsPayableAccessories = 0, AlreadyPaidAccessories = 0;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["PJ"].ToString( ) == "塑料件" )
                {
                    if ( !dicIdx.ContainsKey( gridView1.GetDataRow( i )["idx"].ToString( ) ) )
                        dicIdx.Add( gridView1.GetDataRow( i )["idx"].ToString( ) ,gridView1.GetDataRow( i )["PJ"].ToString( ) );
                    else
                        dicIdx[gridView1.GetDataRow( i )["idx"].ToString( )] = gridView1.GetDataRow( i )["PJ"].ToString( );
                    AccountsPayablePlastic = AccountsPayablePlastic + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["PQ"].ToString( ) ) );
                    AlreadyPaidPlastic = AlreadyPaidPlastic + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK"].ToString( ) ) );
                    cn3 = gridView1.GetDataRow( i )["PJ100"].ToString( );
                }
                else if ( gridView1.GetDataRow( i )["PJ"].ToString( ) == "包装辅料" )
                {
                    if ( !dicIdx.ContainsKey( gridView1.GetDataRow( i )["idx"].ToString( ) ) )
                        dicIdx.Add( gridView1.GetDataRow( i )["idx"].ToString( ) ,gridView1.GetDataRow( i )["PJ"].ToString( ) );
                    else
                        dicIdx[gridView1.GetDataRow( i )["idx"].ToString( )] = gridView1.GetDataRow( i )["PJ"].ToString( );
                    AccountsPayableAccessories = AccountsPayableAccessories + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["PQ"].ToString( ) ) );
                    AlreadyPaidAccessories = AlreadyPaidAccessories + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK"].ToString( ) ) );
                    cn6 = gridView1.GetDataRow( i )["PJ100"].ToString( );
                }
                else if ( gridView1.GetDataRow( i )["PJ"].ToString( ) == "其它材料" )
                {
                    if ( !dicIdx.ContainsKey( gridView1.GetDataRow( i )["idx"].ToString( ) ) )
                        dicIdx.Add( gridView1.GetDataRow( i )["idx"].ToString( ) ,gridView1.GetDataRow( i )["PJ"].ToString( ) );
                    else
                        dicIdx[gridView1.GetDataRow( i )["idx"].ToString( )] = gridView1.GetDataRow( i )["PJ"].ToString( );
                    AccountsPayableOther = AccountsPayableOther + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["PQ"].ToString( ) ) );
                    AlreadyPaidOther = AlreadyPaidOther + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK"].ToString( ) ) );
                    cn9 = gridView1.GetDataRow( i )["PJ100"].ToString( );
                }
            }
            cn1 = AccountsPayablePlastic.ToString( );
            cn2 = AlreadyPaidPlastic.ToString( );
            cn4 = AccountsPayableAccessories.ToString( );
            cn5 = AlreadyPaidAccessories.ToString( );
            cn7 = AccountsPayableOther.ToString( );
            cn8 = AlreadyPaidOther.ToString( );
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            for ( int k = 0 ; k < gridView1.RowCount ; k++ )
            {
                if ( gridView1.GetDataRow( k )["PJ"].ToString( ) == "" )
                {
                    MessageBox.Show( "类别有选项没选择内容,请选择" );
                    break;
                }
                else
                {
                    ValueAll( );
                    try
                    {
                        bll.UpdateOfSign( dicIdx );
                    }
                    catch { }

                    
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
                    if ( PassDataBetweenForm != null )
                    {
                        PassDataBetweenForm( this ,args );
                    }
                    this.Close( );
                }
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
    }
}
