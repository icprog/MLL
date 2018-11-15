using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GunQiContractAll : FormBase
    {
        public GunQiContractAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.GunQiContractBll bll = new MulaolaoBll.Bll.GunQiContractBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableOnly, tableQuery;
        public string sign = "";
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        
        private void GunQiContractAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assignMent ( )
        {
            tableOnly = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ001" );
            lookUpEdit1.Properties.DisplayMember = "MZ001";
            lookUpEdit2.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ002" );
            lookUpEdit2.Properties.DisplayMember = "MZ002";
            lookUpEdit3.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ003" );
            lookUpEdit3.Properties.DisplayMember = "MZ003";
            lookUpEdit4.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ004" );
            lookUpEdit4.Properties.DisplayMember = "MZ004";
            lookUpEdit5.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ005" );
            lookUpEdit5.Properties.DisplayMember = "MZ005";
            lookUpEdit6.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"MZ019" );
            lookUpEdit6.Properties.DisplayMember = "MZ019";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND MZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND MZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND MZ003='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND MZ004='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND MZ005='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND MZ019='" + lookUpEdit6.Text + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND SUBSTRING(CONVERT(VARCHAR,MZ007),0,5)='" + dateEdit1 . Text + "'";

            pageToDataTable ( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( sign != "1" )
                count = bll.GetCount( strWhere );
            if(sign=="1")
                count = bll.GetCounts( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( sign != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPages( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPages( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
            assign ( );
        }

        void assign ( )
        {
            //([MZ0] - [MZ1] - [MZ2]) / [MZ0]
            MZ3 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Convert . ToDecimal ( MZ0 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( (Convert . ToDecimal ( MZ0 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( MZ1 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( MZ2 . SummaryItem . SummaryValue ) ) / Convert . ToDecimal ( MZ0 . SummaryItem . SummaryValue ) * 100 ,2 ) . ToString ( ) + "%" );
        }

        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            assign ( );
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
            dateEdit1 . Text = string . Empty;
        }

        //Value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( sign != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "MZ001" ).ToString( );
                cn2 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }


        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( sign == "1" )
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
        }

        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( sign == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        gridView1.GetDataRow( i )["check"] = true;
                    }
                }
            }
        }
        //unCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( sign == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        gridView1.GetDataRow( i )["check"] = false;
                    }
                }
            }
        }
        //sure
        List<string> add = new List<string>( );
        bool repeat ( )
        {
            add.Clear( );
            bool result = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    add.Add( gridView1.GetDataRow( i )["MZ001"].ToString( ) );
                }
            }

            foreach ( string str in add )
            {
                for ( int k = add.Count - 1 ; k >= 0 ; k-- )
                {
                    if ( str != add[k] )
                        result = false;
                    else
                        result = true;
                }
            }

            return result;
        }
        protected override void sure ( )
        {
            base.sure( );
            if ( sign == "1" )
            {
                byValue( );
            }
        }
        void byValue ( )
        {
            if ( gridView1.RowCount > 0 )
            {
                bool result = repeat( );
                if ( result == false )
                    MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                else
                {
                    decimal sum = 0;
                    add.Clear( );
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            cn1 = gridView1.GetDataRow( i )["MZ014"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["MZ002"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["MZ003"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["MZ004"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["MZ005"].ToString( );
                            cn6 = "";
                            if ( sum == 0 )
                                sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["MZ0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["MZ0"].ToString( ) ) + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["MZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["MZ1"].ToString( ) ) );
                            else
                                sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["MZ0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["MZ0"].ToString( ) ) ) + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["MZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["MZ1"].ToString( ) ) );
                            cn8 = gridView1.GetDataRow( i )["MZ006"].ToString( );
                            cn9 = gridView1.GetDataRow( i )["MZ001"].ToString( );
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }
                    cn7 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,add );
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
