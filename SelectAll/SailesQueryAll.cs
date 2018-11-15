using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;

namespace SelectAll
{
    public partial class SailesQueryAll : FormBase
    {
        public SailesQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        DataTable num, productName, no, contractNum, audit, customer, productionWork;
        DataTable tableQuery = new DataTable( );
        MulaolaoBll.Bll.SailesBll bll = new MulaolaoBll.Bll.SailesBll( );

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "";
        public string numPqfOne = "";

        private void SailesQueryAll_Load ( object sender ,EventArgs e )
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
            if ( numPqfOne != "1" )
            {
                num = bll.GetList( "PQF01" );
            }
            else
            {
                num = bll.GetListPql( );
            }
            lookUpEdit1.Properties.DataSource = num;
            lookUpEdit1.Properties.DisplayMember = "PQF01";
            productName = bll.GetList( "PQF04" );
            lookUpEdit2.Properties.DataSource = productName;
            lookUpEdit2.Properties.DisplayMember = "PQF04";
            no = bll.GetList( "PQF03" );
            lookUpEdit3.Properties.DataSource = no;
            lookUpEdit3.Properties.DisplayMember = "PQF03";
            contractNum = bll.GetList( "PQF02" );
            lookUpEdit4.Properties.DataSource = contractNum;
            lookUpEdit4.Properties.DisplayMember = "PQF02";
            audit = bll.GetListJoin( );
            lookUpEdit5.Properties.DataSource = audit;
            lookUpEdit5.Properties.DisplayMember = "DBA002";
            lookUpEdit5.Properties.ValueMember = "PQF55";
            customer = bll.GetListJoinCustomer( );
            lookUpEdit6.Properties.DataSource = customer;
            lookUpEdit6.Properties.DisplayMember = "DFA003";
            lookUpEdit6.Properties.ValueMember = "PQF11";
            productionWork = bll.GetListProductionWork( );
            lookUpEdit7.Properties.DataSource = productionWork;
            lookUpEdit7.Properties.DisplayMember = "PQF66";
            lookUpEdit7.Properties.ValueMember = "PQF17";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
                strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND PQF01='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND PQF04='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND PQF03='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND PQF02='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
            {
                if ( audit.Select( "DBA002='" + lookUpEdit5.Text + "'" ).Length > 0 )
                {
                    strWhere = strWhere + " AND PQF55='" + audit.Select( "DBA002='" + lookUpEdit5.Text + "'" )[0]["PQF55"].ToString( ) + "'";
                }
            }
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                if ( customer.Select( "DFA003='" + lookUpEdit6.Text + "'" ).Length > 0 )
                {
                    strWhere = strWhere + " AND PQF11='" + customer.Select( "DFA003='" + lookUpEdit6.Text + "'" )[0]["PQF11"].ToString( ) + "'";
                }
            }
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
            {
                //if( productionWork .Select( "PQF66='"+ lookUpEdit7.Text+"'" ).Length>0)
                //strWhere = strWhere + " AND PQF17='" + productionWork.Select( "PQF66='" + lookUpEdit7.Text + "'" )[0]["PQF17"].ToString( ) + "'";
                strWhere = strWhere + " AND PQF66='" + lookUpEdit7 . Text + "'";
            }
            
            pageToDataTable( );
        }
        //Bind data source  and  pagechanged
        void pageToDataTable ( )
        {
           int count = bll.GetSailesCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );           
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,"" ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = -1;
        }
        //value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQF01" ).ToString( );
            cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }

        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                }
            }
        }
        //unCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }
        //sure
        List<string> idList = new List<string>( );
        protected override void sure ( )
        {
            base.sure( );

            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    idList.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                }
            }

            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( idList );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
