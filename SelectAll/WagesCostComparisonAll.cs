using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class WagesCostComparisonAll : FormBase
    {
        public WagesCostComparisonAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;
        MulaolaoBll.Bll.WagesCostComparisonBll _bll = new MulaolaoBll.Bll.WagesCostComparisonBll( );

        private void WagesCostComparisonAll_Load ( object sender ,EventArgs e )
        {
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
            DataTable da = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = da.DefaultView.ToTable( true ,"UZ001" );
            lookUpEdit1.Properties.DisplayMember = "UZ001";
            lookUpEdit2.Properties.DataSource = da.DefaultView.ToTable( true ,"UZ002" );
            lookUpEdit2.Properties.DisplayMember = "UZ002";
            lookUpEdit3.Properties.DataSource = da.DefaultView.ToTable( true ,"UZ003" );
            lookUpEdit3.Properties.DisplayMember = "UZ003";
        }

        //Query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND UZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND UZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND UZ003='" + lookUpEdit3.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
        }

        //Value
        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "UZ001" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

    }
}
