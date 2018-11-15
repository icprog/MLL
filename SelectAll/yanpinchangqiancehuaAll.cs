using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class yanpinchangqiancehuaAll : FormBase
    {
        public yanpinchangqiancehuaAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.yanpinchangqiancehuaBll _bll = new MulaolaoBll.Bll.yanpinchangqiancehuaBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;

        private void yanpinchangqiancehuaAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToChange( );
        }

        //Bind data source
        void assignMent ( )
        {
            DataTable table = _bll.GetDataTableOfOnly( );
            lookUpEdit1.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ01" );
            lookUpEdit1.Properties.DisplayMember = "CQ01";
            lookUpEdit2.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ02" );
            lookUpEdit2.Properties.DisplayMember = "CQ02";
            lookUpEdit3.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ03" );
            lookUpEdit3.Properties.DisplayMember = "CQ03";
            lookUpEdit4.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ04" );
            lookUpEdit4.Properties.DisplayMember = "CQ04";
            lookUpEdit5.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ99" );
            lookUpEdit5.Properties.DisplayMember = "CQ99";
            lookUpEdit6.Properties.DataSource = table.DefaultView.ToTable( true ,"CQ100" );
            lookUpEdit6.Properties.DisplayMember = "CQ100";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND CQ01='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND CQ02='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND CQ03='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND CQ04='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND CQ99='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND CQ100='" + lookUpEdit6.Text + "'";

            pageToChange( );
        }

        //Bind data source and pageChange
        void pageToChange ( )
        {
            int count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageChange( );
        }
        void pageChange ( )
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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "CQ01" ).ToString( );
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
