using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class PayMentCheckOutAll :Form
    {
        public PayMentCheckOutAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );
        int count = 0;
        string strWhere = "1=1";
        DataTable tableQuery, tableQueryOne, tableQueryTre,tableQueryFor;
        decimal alreadPay = 0M, copyWith = 0M,/*应付前道*/ canCopyWith = 0M;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "";
        public string idxSt = "", supplier = "";
        bool result=false;

        private void PayMentCheckOutAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            GridViewMoHuSelect.SetFilter( gridView5 );
            tableOnly( );
            lookUpEdit1.Text = supplier;
            tableQueryOf( );
            tableQueryOf480 ( );
            //tabPageFor . Parent = null;
        }

        void tableOnly ( )
        {
            lookUpEdit1.Properties.DataSource = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DisplayMember = "AK001";
            DataTable td = _bll.GetDataTableOnlyOfPqez( );
            lookUpEdit2.Properties.DataSource = td.DefaultView.ToTable( true ,"EZ011" );
            lookUpEdit2.Properties.DisplayMember = "EZ011";
            lookUpEdit3.Properties.DataSource = td.DefaultView.ToTable( true ,"EZ004" );
            lookUpEdit3.Properties.DisplayMember = "EZ004";
        }

        void tableQueryOf ( )
        {
            tableQueryTre = _bll.GetDataTableOfTre( );
            tableQueryTre.Columns.Add( "check_one" ,Type.GetType( "System.Boolean" ) );
            gridControl3.DataSource = tableQueryTre;
        }

        void tableQueryOf480 ( )
        {
            tableQueryFor = _bll . GetDataTableOfFor ( );
            tableQueryFor . Columns . Add ( "check_fiv" , Type . GetType ( "System.Boolean" ) );
            gridControl4 . DataSource = tableQueryFor;
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
        private void gridView5_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView5.FocusedRowHandle >= 0 && gridView5.FocusedRowHandle <= gridView5.RowCount - 1 )
            {
                int num = gridView5.FocusedRowHandle;
                if ( gridView5.GetDataRow( num )["check_one"].ToString( ) == "True" )
                {
                    gridView5.GetDataRow( num )["check_one"] = false;
                    if ( count > 0 )
                        count--;
                }
                else
                {
                    gridView5.GetDataRow( num )["check_one"] = true;
                    count++;
                }
            }
        }
        private void gridView6_RowClick ( object sender , DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( gridView6 . FocusedRowHandle >= 0 && gridView6 . FocusedRowHandle <= gridView6 . RowCount - 1 )
            {
                int num = gridView6 . FocusedRowHandle;
                if ( gridView6 . GetDataRow ( num ) [ "check_fiv" ] . ToString ( ) == "True" )
                {
                    gridView6 . GetDataRow ( num ) [ "check_fiv" ] = false;
                    if ( count > 0 )
                        count--;
                }
                else
                {
                    gridView6 . GetDataRow ( num ) [ "check_fiv" ] = true;
                    count++;
                }
            }
        }

        //Cancel
        private void button6_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void button9_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void button15_Click ( object sender , EventArgs e )
        {
            this . Close ( );
        }

        //OK
        private void button5_Click ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            if ( count > 0 )
            {
                checkAll( );
                cn1 = alreadPay.ToString( );
                cn2 = copyWith.ToString( );
                cn3 = canCopyWith.ToString( );
                cn4 = lookUpEdit1.Text;
                cn6 = "1";
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
        void checkAll ( )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    if ( cn5 == "" )
                        cn5 = gridView1.GetDataRow( i )["idx"].ToString( );
                    else
                        cn5 = cn5 + "," + gridView1.GetDataRow( i )["idx"].ToString( );
                    alreadPay += string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK015"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK015"].ToString( ) );
                    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK002"].ToString( ) ) )
                        canCopyWith += string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK011"].ToString( ) );
                    else
                        copyWith += string.IsNullOrEmpty( gridView1.GetDataRow( i )["AK011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["AK011"].ToString( ) );
                }
            }
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
            checkAl( );
            cn1 = lookUpEdit2.Text;
            cn2 = lookUpEdit3.Text + "工人工资";
            cn3 = string . IsNullOrEmpty ( U00 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U00 . SummaryItem . SummaryValue ) ,0 ) . ToString ( );
            cn6 = "2";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        void checkAl ( )
        {
            for ( int i = 0 ; i < gridView4.RowCount ; i++ )
            {
                if ( cn4 == "" )
                    cn4 = gridView4.GetDataRow( i )["idx"].ToString( );
                else
                    cn4 = cn4 + "," + gridView4.GetDataRow( i )["idx"].ToString( );
            }
        }
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( count > 0 )
            {
                if ( boolCheck ( ) == true )
                    return;
                alreadPay = copyWith = 0;
                checka( );
                cn2 = alreadPay.ToString( );
                cn3 = copyWith.ToString( );               
                cn6 = "3";
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
        private void button16_Click ( object sender , EventArgs e )
        {
            if ( count > 0 )
            {
                cn1 = cn2 = cn3 = cn4 = cn5 = cn6 = "";
                //if ( supplierCheck ( ) == false )
                  //  return;
                checkA ( );
                cn1 = alreadPay . ToString ( );
                cn3 = "";
                cn6 = "4";
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 , cn2 , cn3 , cn4 , cn5 , cn6 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm ( this , args );
                }
                this . Close ( );
            }
        }
        void checkA ( )
        {
            for ( int i = 0 ; i < gridView6 . RowCount ; i++ )
            {
                if ( gridView6 . GetDataRow ( i ) [ "check_fiv" ] . ToString ( ) == "True" )
                {
                    if ( cn4 == "" )
                        cn4 = gridView6 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                    else
                        cn4 = cn4 + "," + gridView6 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                    alreadPay += string . IsNullOrEmpty ( gridView6 . GetDataRow ( i ) [ "CQ102" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView6 . GetDataRow ( i ) [ "CQ102" ] . ToString ( ) ) * ( string . IsNullOrEmpty ( gridView6 . GetDataRow ( i ) [ "CQ103" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView6 . GetDataRow ( i ) [ "CQ103" ] . ToString ( ) ) ) * ( string . IsNullOrEmpty ( gridView6 . GetDataRow ( i ) [ "CQ105" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView6 . GetDataRow ( i ) [ "CQ105" ] . ToString ( ) ) );
                }
            }
        }
        bool  supplierCheck ( )
        {
            bool result = true;
            string supplier = "";
            for ( int i = 0 ; i < gridView6 . DataRowCount ; i++ )
            {
                if ( gridView6 . GetDataRow ( i ) [ "check_fiv" ] . ToString ( ) == "True" )
                {
                    cn2= gridView6 . GetDataRow ( i ) [ "CQ114" ] . ToString ( );
                    if ( supplier == "" )
                        supplier = gridView6 . GetDataRow ( i ) [ "CQ114" ] . ToString ( );
                    else
                    {
                        if ( supplier != gridView6 . GetDataRow ( i ) [ "CQ114" ] . ToString ( ) )
                        {
                            MessageBox . Show ( "请选择相同的供应商" );
                            result = false;
                        }
                    }
                }
            }

            return result;
        }

        void checka ( )
        {
            for ( int i = 0 ; i < gridView5.RowCount ; i++ )
            {
                if ( gridView5.GetDataRow( i )["check_one"].ToString( ) == "True" )
                {
                    if ( cn1 == "" )
                        cn1 = gridView5.GetDataRow( i )["kin"].ToString( );
                    else
                        cn1 = cn1 + "," + gridView5.GetDataRow( i )["kin"].ToString( );
                    alreadPay += string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE011"].ToString( ) );
                    copyWith += string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE007"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE007"].ToString( ) ) + ( string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE008"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE008"].ToString( ) ) ) + ( string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE009"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE009"].ToString( ) ) ) + ( string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE010"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE010"].ToString( ) ) ) + ( string.IsNullOrEmpty( gridView5.GetDataRow( i )["BE012"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView5.GetDataRow( i )["BE012"].ToString( ) ) );
                }
            }
        }
        bool boolCheck ( )
        {
            result = false;
            string gys = "";
            for ( int i = 0 ; i < gridView5 . RowCount ; i++ )
            {
                if ( gridView5 . GetDataRow ( i ) [ "check_one" ] . ToString ( ) == "True" )
                {
                    if ( gys == "" )
                        cn4 = gys = gridView5 . GetDataRow ( i ) [ "DGA003" ] . ToString ( );
                    else if ( gys != gridView5 . GetDataRow ( i ) [ "DGA003" ] . ToString ( ) )
                    {
                        MessageBox . Show ( "选择项供应商不一致,请重选" );
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        //Query
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND AK001='" + lookUpEdit1.Text + "'";
            else
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( !string.IsNullOrEmpty( idxSt ) )
                strWhere = strWhere + " AND idx NOT IN (" + idxSt + ")";

            tableQuery = _bll.GetDataTable( strWhere );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( lookUpEdit2.Text ) )
            {
                MessageBox.Show( "组长姓名不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "日期不可为空" );
                return;
            }
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND EZ011='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND EZ004='" + lookUpEdit3.Text + "'";

            tableQueryOne = _bll.GetDataTableOfPqez( strWhere );
            gridControl2.DataSource = tableQueryOne;
        }
        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = null;
            lookUpEdit1.ItemIndex = -1;
        }
        private void button11_Click ( object sender ,EventArgs e )
        {
            lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
        }
        //All
        private void button3_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                gridView1.GetDataRow( i )["check"] = true;
                count++;
            }
        }
        private void button14_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView5.RowCount ; i++ )
            {
                gridView5.GetDataRow( i )["check_one"] = true;
                count++;
            }
        }
        //CancelAll
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
        private void button13_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView5.RowCount ; i++ )
            {
                if ( gridView5.GetDataRow( i )["check_one"].ToString( ) == "True" )
                {
                    gridView5.GetDataRow( i )["check_one"] = false;
                    count = 0;
                }
            }
        }

        //All
        private void button18_Click ( object sender , EventArgs e )
        {
            for ( int i = 0 ; i < gridView6 . RowCount ; i++ )
            {
                gridView6 . GetDataRow ( i ) [ "check_fiv" ] = true;
                count++;
            }
        }
        //CancelAll
        private void button17_Click ( object sender , EventArgs e )
        {
            for ( int i = 0 ; i < gridView6 . RowCount ; i++ )
            {
                if ( gridView6 . GetDataRow ( i ) [ "check_fiv" ] . ToString ( ) == "True" )
                {
                    gridView6 . GetDataRow ( i ) [ "check_fiv" ] = false;
                    count = 0;
                }
            }
        }

    }
}
