using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class CheJianZhuRenKaoHeAll : FormBase
    {
        public CheJianZhuRenKaoHeAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.CheJianZhuRenKaoHeBll bll = new MulaolaoBll.Bll.CheJianZhuRenKaoHeBll( );
        DataTable queryTable;

        private void CheJianZhuRenKaoHeAll_Load ( object sender ,EventArgs e )
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
            DataTable dt = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"CZ006" );
            lookUpEdit1.Properties.DisplayMember = "CZ006";
            lookUpEdit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"CZ001" );
            lookUpEdit1.Properties.DisplayMember = "CZ001";
            lookUpEdit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"CZ002" );
            lookUpEdit1.Properties.DisplayMember = "CZ002";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + "AND CZ006='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + "AND CZ001='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + "AND CZ002='" + lookUpEdit3.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                queryTable = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                queryTable = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = queryTable;
        }


        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit3.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit1.ItemIndex = -1;
        }


        //value
        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "CZ006" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
