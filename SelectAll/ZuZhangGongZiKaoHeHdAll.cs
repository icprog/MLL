using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class ZuZhangGongZiKaoHeHdAll : FormBase
    {
        public ZuZhangGongZiKaoHeHdAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model = new MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary( );
        MulaolaoBll.Bll.ZuZhangGongZiKaoHdBll bll = new MulaolaoBll.Bll.ZuZhangGongZiKaoHdBll( ); public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;


        private void ZuZhangGongZiKaoHeHdAll_Load ( object sender ,EventArgs e )
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
            DataTable dt = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"HD074" );
            lookUpEdit1.Properties.DisplayMember = "HD074";
            lookUpEdit2.Properties.DataSource = dt.DefaultView.ToTable( true ,"HD001" );
            lookUpEdit2.Properties.DisplayMember = "HD001";
            lookUpEdit3.Properties.DataSource = dt.DefaultView.ToTable( true ,"HD002" );
            lookUpEdit3.Properties.DisplayMember = "HD002";
        }

        //query queey
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND HD074='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND HD001='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND HD002='" + lookUpEdit3.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = bll.GetZuZhangCount( strWhere );
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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "HD074" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "HD002" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "HD094" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
