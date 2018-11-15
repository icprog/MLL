using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class JiaoMiDuJunHengAll : FormBase
    {
        public JiaoMiDuJunHengAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.JiaoMiDuJunHenTableBll bll = new MulaolaoBll.Bll.JiaoMiDuJunHenTableBll( );
        DataTable onlyQuery, tableQuery;

        private void JiaoMiDuJunHengAll_Load ( object sender ,EventArgs e )
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
            onlyQuery = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = onlyQuery.DefaultView.ToTable( true ,"JZ001" );
            lookUpEdit1.Properties.DisplayMember = "JZ001";
            lookUpEdit2.Properties.DataSource = onlyQuery.DefaultView.ToTable( true ,"JZ004" );
            lookUpEdit2.Properties.DisplayMember = "JZ004";
            lookUpEdit3.Properties.DataSource = onlyQuery.DefaultView.ToTable( true ,"JZ003" );
            lookUpEdit3.Properties.DisplayMember = "JZ003";
            lookUpEdit4.Properties.DataSource = onlyQuery.DefaultView.ToTable( true ,"JZ002" );
            lookUpEdit4.Properties.DisplayMember = "JZ002";
            lookUpEdit5.Properties.DataSource = onlyQuery.DefaultView.ToTable( true ,"JZ005" );
            lookUpEdit5.Properties.DisplayMember = "JZ005";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND JZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND JZ004='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND JZ003='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND JZ002='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND JZ005='" + lookUpEdit5.Text + "'";

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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "JZ001" ).ToString( );
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
