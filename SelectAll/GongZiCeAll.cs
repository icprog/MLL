using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class GongZiCeAll : FormBase
    {
        public GongZiCeAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;
        
        MulaolaoBll.Bll.GongZiCeBll bll = new MulaolaoBll.Bll.GongZiCeBll( );

        private void GongZiCeAll_Load ( object sender ,EventArgs e )
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
            DataTable da = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = da.DefaultView.ToTable( true ,"EZ001" );
            lookUpEdit1.Properties.DisplayMember = "EZ001";
            lookUpEdit2.Properties.DataSource = da.DefaultView.ToTable( true ,"EZ002" );
            lookUpEdit2.Properties.DisplayMember = "EZ002";
            lookUpEdit3.Properties.DataSource = da.DefaultView.ToTable( true ,"EZ004" );
            lookUpEdit3.Properties.DisplayMember = "EZ004";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND EZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND EZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND EZ004='" + lookUpEdit3.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChanged( );
        }
        void pageByChanged ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
        }

        //value
        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "EZ001" ).ToString( );
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
