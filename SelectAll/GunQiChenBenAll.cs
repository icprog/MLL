using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class GunQiChenBenAll : FormBase
    {
        DataTable tableQuery,tableOnly;

        public GunQiChenBenAll ( )
        {
            InitializeComponent( );

            tableQuery = new DataTable ( );
            tableOnly = new DataTable ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.GunQiChenBenBll _bll = new MulaolaoBll.Bll.GunQiChenBenBll( );
        
        private void GunQiChenBenAll_Load ( object sender ,EventArgs e )
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
            tableOnly = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"PZ001" );
            lookUpEdit1.Properties.DisplayMember = "PZ001";
            lookUpEdit2.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"PZ002" );
            lookUpEdit2.Properties.DisplayMember = "PZ002";
            lookUpEdit3.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"PZ003" );
            lookUpEdit3.Properties.DisplayMember = "PZ003";
            lookUpEdit4.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"PZ005" );
            lookUpEdit4.Properties.DisplayMember = "PZ005";
            lookUpEdit5.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"PZ004" );
            lookUpEdit5.Properties.DisplayMember = "PZ004";
        }

        //query
        string strWhere = "1=1";
        private void button2_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND PZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND PZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND PZ003='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND PZ005='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND PZ004='" + lookUpEdit5.Text + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND SUBSTRING(CONVERT(VARCHAR,PZ007),0,5)='" + dateEdit1 . Text + "'";

            pageToDataTable ( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            //_bll.Delete( );

            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
            assign( );
        }
        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            assign( );
        }
        void assign ( )
        {
            decimal dOne = Convert.ToDecimal( U0.SummaryItem.SummaryValue );
            decimal dTwo = Convert.ToDecimal( U1.SummaryItem.SummaryValue );
            decimal dTre = Convert.ToDecimal( U5.SummaryItem.SummaryValue );
            decimal resu = dOne == 0 ? 0 : Math . Round ( Math . Round ( ( dOne - dTwo - dTre ) / dOne , 3 ) * 100 , 1 );
            U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( dOne - dTwo - dTre ).ToString( ) );
            U4.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,dOne == 0 ? 0.ToString( ) : resu.ToString( ) + "%" );
        }

        //Value
        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PZ001" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        //Clear
        private void button1_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
            dateEdit1 . Text = string . Empty;
        }
    }
}
