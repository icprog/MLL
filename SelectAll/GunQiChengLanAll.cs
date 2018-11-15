using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GunQiChengLanAll : FormBase
    {
        public GunQiChengLanAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.GunQiChengLanJiaGongBll bll = new MulaolaoBll.Bll.GunQiChengLanJiaGongBll( );
        DataTable tableQuery, tableOnly;
        public string sign = "";

        private void GunQiChengLanAll_Load ( object sender ,EventArgs e )
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
            tableOnly = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"LZ001" );
            lookUpEdit1.Properties.DisplayMember = "LZ001";
            lookUpEdit2.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"LZ002" );
            lookUpEdit2.Properties.DisplayMember = "LZ002";
            lookUpEdit3.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"LZ003" );
            lookUpEdit3.Properties.DisplayMember = "LZ003";
            lookUpEdit4.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"LZ004" );
            lookUpEdit4.Properties.DisplayMember = "LZ004";
            lookUpEdit5.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"LZ005" );
            lookUpEdit5.Properties.DisplayMember = "LZ005";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND LZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND LZ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND LZ003='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND LZ004='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND LZ005='" + lookUpEdit5.Text + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( sign != "1" )
                count = bll.GetCount( strWhere );
            if ( sign == "1" )
                count = bll.GetCounts( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( sign != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            if ( sign == "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPages( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPages( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";

        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( sign != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "LZ001" ).ToString( );
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
            if ( sign == "1" )
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

            if ( sign == "1" )
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

            if ( sign == "1" )
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
                    add.Add( gridView1.GetDataRow( i )["LZ001"].ToString( ) );
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
            if ( sign == "1" )
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
                            cn1 = gridView1.GetDataRow( i )["LZ013"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["LZ002"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["LZ003"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["LZ004"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["LZ005"].ToString( );
                            cn6 = "";
                            if ( sum == 0 )
                                sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["LZ0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["LZ0"].ToString( ) );
                            else
                                sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["LZ0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["LZ0"].ToString( ) ) );
                            cn8 = gridView1.GetDataRow( i )["LZ006"].ToString( );
                            cn9 = gridView1.GetDataRow( i )["LZ001"].ToString( );
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }
                    cn7 = sum.ToString( );
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
