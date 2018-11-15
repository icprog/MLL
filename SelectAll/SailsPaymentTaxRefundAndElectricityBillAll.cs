using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class SailsPaymentTaxRefundAndElectricityBillAll : FormBase
    {
        public SailsPaymentTaxRefundAndElectricityBillAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        MulaolaoBll.Bll.SailsPaymentTaxRefundAndElectricityBillBll _bll = new MulaolaoBll.Bll.SailsPaymentTaxRefundAndElectricityBillBll( );
        DataTable tableQuery,num;

        private void SailsPaymentTaxRefundAndElectricityBillAll_Load ( object sender ,EventArgs e )
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
            num = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = num.DefaultView.ToTable( true ,"NZ001" );
            lookUpEdit1.Properties.DisplayMember = "NZ001";
            lookUpEdit2.Properties.DataSource = num.DefaultView.ToTable( true ,"NZ002" );
            lookUpEdit2.Properties.DisplayMember = "NZ002";
            lookUpEdit3.Properties.DataSource = num.DefaultView.ToTable( true ,"NZ003" );
            lookUpEdit3.Properties.DisplayMember = "NZ003";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND NZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND NZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND NZ003='" + lookUpEdit3.Text + "'";

            pageToDataTable( );
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
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

        //Value
        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "NZ001" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
