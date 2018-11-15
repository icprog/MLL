using DevExpress . Data;
using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class YouQicontractAll : FormBase
    {
        public YouQicontractAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.YouQicontractBll bll = new MulaolaoBll.Bll.YouQicontractBll( );
        DataTable oddNum, tableQuery, supplier;
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string signYou = "", variable = "", tableOther = "";
        
        private void YouQicontractAll_Load ( object sender ,EventArgs e )
        {
            if ( signYou . Equals ( "1" ) )
                YQ13 . Visible = YQ134 . Visible = YQ135 . Visible = U11 . Visible = U12 . Visible = YQ14 . Visible = YQ16 . Visible = false;

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
            oddNum = bll.GetDataTable( );
            lookUpEdit1.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ99" );
            lookUpEdit1.Properties.DisplayMember = "YQ99";
            lookUpEdit2.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ03" );
            lookUpEdit2.Properties.DisplayMember = "YQ03";
            lookUpEdit3.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ106" );
            lookUpEdit3.Properties.DisplayMember = "YQ106";
            lookUpEdit4.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ105" );
            lookUpEdit4.Properties.DisplayMember = "YQ105";
            lookUpEdit5.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ107" );
            lookUpEdit5.Properties.DisplayMember = "YQ107";
            supplier = bll.GetDataTableOnly( );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "DGA002";
            lookUpEdit6.Properties.ValueMember = "YQ02";
            lookUpEdit6.Text = variable;
            lookUpEdit7.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ10" );
            lookUpEdit7.Properties.DisplayMember = "YQ10";
            lookUpEdit8.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ11" );
            lookUpEdit8.Properties.DisplayMember = "YQ11";
            lookUpEdit9.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ12" );
            lookUpEdit9.Properties.DisplayMember = "YQ12";
            lookUpEdit10.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ119" );
            lookUpEdit10.Properties.DisplayMember = "YQ119";
        }
      
        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND YQ99='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND YQ03='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND YQ106='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND YQ105='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND YQ107='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                if( supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" ) .Length>0)
                    strWhere = strWhere + " AND YQ02='" + supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" )[0]["YQ02"].ToString( ) + "'";
            }
                
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
                strWhere = strWhere + " AND YQ10='" + lookUpEdit7.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND YQ11='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND YQ12='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND YQ119='" + lookUpEdit10.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;

            if ( signYou != "1" )
                count = bll.GetDataTableCount( strWhere );
            else
                count = bll.GetDataTableCountOne( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
                if ( signYou != "1" )
                {
                    if ( userControl11.pageIndex <= 1 )
                        tableQuery = bll.GetDataTableByChange( strWhere ,"" ,0 ,userControl11.pageSize );
                    else
                        tableQuery = bll.GetDataTableByChange( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
                }
                else
                {
                    if ( userControl11.pageIndex <= 1 )
                        tableQuery = bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
                    else
                        tableQuery = bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
                }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
            caucle ( );
        }

        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            caucle ( );
        }

        void caucle ( )
        {
            if ( signYou . Equals ( "1" ) )
                return;
            int bp = 0, tp = 0;
            decimal dOne = 0, dTwo = 0;
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {               
                if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) ) && Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) ) > 0 )
                {
                    bp++;
                    dOne += Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "YQ134" ] . ToString ( ) );
                }
                if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) ) && Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) ) > 0 )
                {
                    tp++;
                    dTwo += Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "YQ135" ] . ToString ( ) );
                }
            }

            YQ14 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U10 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );
            YQ16 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U1 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U9 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U1 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );

            U11 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) / 2 * Convert . ToDecimal ( 0.85 ) ,2 ) . ToString ( ) );
            U12 . SummaryItem . SetSummary ( SummaryItemType . Custom ,Convert . ToDecimal ( U4 . SummaryItem . SummaryValue ) == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( U1 . SummaryItem . SummaryValue ) / Convert . ToDecimal ( U4 . SummaryItem . SummaryValue ) / 2 ,2 ) . ToString ( ) );

            YQ134 . SummaryItem . SetSummary ( SummaryItemType . Custom ,bp == 0 ? 0 . ToString ( ) : Math . Round ( dOne / bp ,2 ) . ToString ( ) );
            YQ135 . SummaryItem . SetSummary ( SummaryItemType . Custom ,tp == 0 ? 0 . ToString ( ) : Math . Round ( dTwo / tp ,2 ) . ToString ( ) );
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = lookUpEdit10.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = lookUpEdit10.ItemIndex = -1;
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signYou != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ03" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ02" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ105" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ99" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ106" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ107" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"YQ108" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signYou . Equals ( "1" ) )
            {
                if ( gridView1 . FocusedRowHandle >= 0 && gridView1 . FocusedRowHandle <= gridView1 . RowCount - 1 )
                {
                    int num = gridView1 . FocusedRowHandle;
                    if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                        gridView1 . GetDataRow ( num ) [ "check" ] = false;
                    else
                        gridView1 . GetDataRow ( num ) [ "check" ] = true;
                }
            }
        }
        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( signYou == "1" )
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

            if ( signYou == "1" )
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
        List<string> list = new List<string>( );
        bool repeat ( )
        {
            list.Clear( );
            bool resule = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    list.Add( gridView1.GetDataRow( i )["YQ99"].ToString( ) );
            }

            foreach ( string str in list )
            {
                for ( int k = list.Count-1 ; k >=0  ; k-- )
                {
                    if ( str != list[k] )
                    {
                        resule = false;
                        break;
                    }
                    else
                        resule = true;
                }
            }


            return resule;
        }
        protected override void sure ( )
        {
            base.sure( );

            if ( signYou .Equals( "1") )
            {
                if ( gridView1.RowCount > 0 )
                {
                    bool resule = repeat( );
                    if ( resule == false )
                        MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                    else
                    {
                        decimal sum = 0;
                        list.Clear( );
                        for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                        {
                            if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                            {
                                cn1 = gridView1.GetDataRow( i )["YQ99"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["YQ03"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["YQ105"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["YQ106"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["YQ107"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["YQ108"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["YQ10"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["YQ10"].ToString( );
                                if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ13"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ14"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ16"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ108"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ112"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ113"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ114"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ115"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ116"].ToString( ) ) )
                                    //sum += Math.Round( ( Convert.ToDecimal( gridView1.GetDataRow( i )["YQ108"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ112"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ113"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ116"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ14"].ToString( ) ) * Convert.ToDecimal( 0.01 ) / Convert.ToDecimal( gridView1.GetDataRow( i )["YQ114"].ToString( ) ) / Convert.ToDecimal( gridView1.GetDataRow( i )["YQ115"].ToString( ) ) ) + ( Convert.ToDecimal( gridView1.GetDataRow( i )["YQ13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ16"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ108"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ112"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ113"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ114"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ115"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["YQ116"].ToString( ) ) * Convert.ToDecimal( 0.000001 ) ) ,0 );
                                    sum += ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U9"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U9"].ToString( ) ) + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U10"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U10"].ToString( ) ) ) );
                                list.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                            }
                        }
                        cn9 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
                        PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,list );
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
}
