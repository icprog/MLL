using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class DuanLiaoAll : FormBase
    {
        public DuanLiaoAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.DaunLiaoBll bll = new MulaolaoBll.Bll.DaunLiaoBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableOnly, tableQuery;
        public string signDuan = "";

        private void DuanLiaoAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );

            assignMent( );
            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind and datasource
        void assignMent ( )
        {
            tableOnly = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"IZ001" );
            lookUpEdit1.Properties.DisplayMember = "IZ001";
            lookUpEdit2.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"IZ002" );
            lookUpEdit2.Properties.DisplayMember = "IZ002";
            lookUpEdit3.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"IZ004" );
            lookUpEdit3.Properties.DisplayMember = "IZ004";
            lookUpEdit4.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"IZ003" );
            lookUpEdit4.Properties.DisplayMember = "IZ003";
            lookUpEdit5.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"IZ034" );
            lookUpEdit5.Properties.DisplayMember = "IZ034";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND IZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND IZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND IZ004='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND IZ003='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND IZ034='" + lookUpEdit5.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageToChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signDuan != "1" )
                count = bll.GetCount( strWhere );
            else
                count = bll.GetCountAll( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signDuan != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByChangeAll( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByChangeAll( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signDuan != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "IZ001" ).ToString( );
                cn2 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }            
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signDuan == "1" )
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
        }
        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( signDuan == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        gridView1.GetDataRow( i )["check"] = true;
                    }
                }
            }
        }
        //unCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( signDuan == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        gridView1.GetDataRow( i )["check"] = false;
                    }
                }
            }
        }
        //sure
        List<string> add = new List<string>( );
        bool repeat ( )
        {
            add.Clear( );
            bool result = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    add.Add( gridView1.GetDataRow( i )["IZ001"].ToString( ) );
                }
            }

            foreach ( string str in add )
            {
                for ( int k = add.Count - 1 ; k >= 0 ; k-- )
                {
                    if ( str != add[k] )
                        result = false;
                    else
                        result = true;
                }
            }

            return result;
        }
        protected override void sure ( )
        {
            base.sure( );
            if ( signDuan == "1" )
            {
                byValue( );
            }
        }
        void byValue ( )
        {
            if ( gridView1.RowCount > 0 )
            {
                bool result = repeat( );
                if ( result == false )
                    MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                else
                {
                    decimal sum = 0;
                    add.Clear( );
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            cn1 = gridView1.GetDataRow( i )["IZ035"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["IZ002"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["IZ004"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["IZ003"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["IZ034"].ToString( );
                            if ( string.IsNullOrEmpty( cn6 ) ) 
                                cn6 = gridView1.GetDataRow( i )["IZ008"].ToString( );
                            else
                                cn6 += "," + gridView1.GetDataRow( i )["IZ008"].ToString( );
                            if ( sum == 0 )
                                sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["U0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U0"].ToString( ) );
                            else
                                sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U0"].ToString( ) ) );
                            cn8 = gridView1.GetDataRow( i )["IZ005"].ToString( );
                            cn9 = gridView1.GetDataRow( i )["IZ001"].ToString( );
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }
                    cn7 = Math . Round ( sum ,2,MidpointRounding . AwayFromZero ) . ToString ( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,add );
                    if ( PassDataBetweenForm != null )
                    {
                        PassDataBetweenForm( this ,args );
                    }
                    this.Close( );
                }
            }
        }
    }
}
