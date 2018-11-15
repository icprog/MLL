using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class ZuZhangGongZiKaoHeAll : FormBase
    {
        public ZuZhangGongZiKaoHeAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll bll = new MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll( );
        DataTable tableQuery;

        private void ZuZhangGongZiKaoHeAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );
            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
            lookUpEdit1.Properties.ShowHeader = false;
            lookUpEdit2.Properties.ShowHeader = false;
            lookUpEdit3.Properties.ShowHeader = false;
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageByChange( );
        }
        
        //Bind data source
        void assignMent ( )
        {
            DataTable da = bll.GetDataTableSign( );
            lookUpEdit1.Properties.DataSource = da.DefaultView.ToTable( true ,"QD074" );
            lookUpEdit1.Properties.DisplayMember = "QD074";
            lookUpEdit2.Properties.DataSource = da.DefaultView.ToTable( true ,"QD001" );
            lookUpEdit2.Properties.DisplayMember = "QD001";
            lookUpEdit3.Properties.DataSource = da.DefaultView.ToTable( true ,"QD002" );
            lookUpEdit3.Properties.DisplayMember = "QD002";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND QD074='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND QD001='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND QD002='" + lookUpEdit3.Text + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            count = bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue =lookUpEdit3.EditValue= null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex =lookUpEdit3.ItemIndex= -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "QD074" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "QD001" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "QD002" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
