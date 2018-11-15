using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WaiXianAll : FormBase
    {
        public WaiXianAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.WaiXianBll _bll = new MulaolaoBll.Bll.WaiXianBll( );
        DataTable tableQuery, tableOnly;
        public string variable = "", signChan = "";
        
        private void WaiXianAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data Source
        void assignMent ( )
        {
            tableOnly = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"OZ011" );
            lookUpEdit1.Properties.DisplayMember = "OZ011";
            lookUpEdit2.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"OZ001" );
            lookUpEdit2.Properties.DisplayMember = "OZ001";
            lookUpEdit3.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"OZ002" );
            lookUpEdit3.Properties.DisplayMember = "OZ002";
            lookUpEdit4.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"OZ004" );
            lookUpEdit4.Properties.DisplayMember = "OZ004";
            lookUpEdit5.Properties.DataSource = tableOnly.DefaultView.ToTable( true ,"OZ003" );
            lookUpEdit5.Properties.DisplayMember = "OZ003";
            lookUpEdit6.Properties.DataSource = _bll.GetDataTableOfSupplier( );
            lookUpEdit6.Properties.DisplayMember = "DGA003";
            lookUpEdit6.Properties.ValueMember = "OZ014";
            lookUpEdit6.Text = variable;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND OZ011='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND OZ001='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND OZ002='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND OZ004='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND OZ003='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND OZ014='" + lookUpEdit6.EditValue.ToString( ) + "'";

            pageToDataTable( );
        }

        void pageToDataTable ( )
        {
            int count = 0;
            if ( signChan != "1" )
                count = _bll.GetCount( strWhere );
            else
                count = _bll.GetCounts( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signChan != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = _bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = _bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = _bll.GetDataTableByChangeOther( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = _bll.GetDataTableByChangeOther( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            } 
            tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
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
            if ( signChan != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "OZ011" ).ToString( );
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
            int num = gridView1.FocusedRowHandle;
            if ( num >= 0 && num <= gridView1.RowCount - 1 )
            {
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }

        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                }
            }
        }

        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }

        protected override void sure ( )
        {
            base.sure( );

            if ( signChan == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["DGA003"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["OZ001"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["OZ002"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["OZ004"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["OZ003"].ToString( );
                                //if ( string.IsNullOrEmpty( cn6 ) )
                                //    cn6 = gridView1.GetDataRow( i )["CP06"].ToString( );
                                //else
                                //    cn6 += "," + gridView1.GetDataRow( i )["CP06"].ToString( );
                                cn6 = "外箱";
                                //if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP54"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP10"].ToString( ) ) )
                                //    sum += Math.Round( Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) ,1 );
                                if ( sum == 0 )
                                    sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ"].ToString( ) );
                                else
                                    sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ"].ToString( ) ) );
                                cn8 = gridView1.GetDataRow( i )["OZ005"].ToString( );
                                cn9 = gridView1.GetDataRow( i )["OZ011"].ToString( );
                                if ( add.Count < 1 )
                                    add.Add( 0.ToString( ) );
                            }
                        }
                        cn7 = Math.Round( sum ,2 ,MidpointRounding . AwayFromZero ) .ToString( );
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
        List<string> add = new List<string>( );
        bool repeat ( )
        {
            add.Clear( );
            bool result = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    add.Add( gridView1.GetDataRow( i )["OZ011"].ToString( ) );
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


    }
}
