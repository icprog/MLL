using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class YouQiSelectAll : FormBase
    {
        public YouQiSelectAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
         
        MulaolaoBll.Bll.YouQicontractBll bll = new MulaolaoBll.Bll.YouQicontractBll( );
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable oddNum, supplier, tableQuery;
        public string variable = "", signYou = "", sign = "";
        bool result = false;
        
        private void YouQiSelectAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTableOther( );
            lookUpEdit1.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ99" );
            lookUpEdit1.Properties.DisplayMember = "YQ99";
            supplier = bll.GetDataTableOnlyOther( );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "DGA002";
            lookUpEdit6.Properties.ValueMember = "YQ02";
            lookUpEdit6.Text = variable;
            lookUpEdit8.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ119" );
            lookUpEdit8.Properties.DisplayMember = "YQ119";
            lookUpEdit9.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ11" );
            lookUpEdit9.Properties.DisplayMember = "YQ11";
            lookUpEdit10.Properties.DataSource = oddNum.DefaultView.ToTable( true ,"YQ12" );
            lookUpEdit10.Properties.DisplayMember = "YQ12";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND YQ99='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                if ( supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" ).Length > 0 )
                    strWhere = strWhere + " AND YQ02='" + supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" )[0]["YQ02"].ToString( ) + "'";
            }
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND YQ119='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND YQ11='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND YQ12='" + lookUpEdit10.Text + "'";
            if ( !string . IsNullOrEmpty ( textBox1 . Text ) )
                strWhere = strWhere + " AND YQ99 LIKE 'R_337-" + textBox1 . Text + "%'";

            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;

            if ( signYou == "1" )
                count = bll.GetYouQiCountOther( strWhere );
            else
                count = bll.GetYouQiCountOneOther( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            //编辑337入库标记
            //signOfStorage( );

            if ( signYou == "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByChangeOther( strWhere ,"" ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByChangeOther( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByChangeOther( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByChangeOther( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        void signOfStorage ( )
        {
            result = bll.GetDataTableOfStorage( );
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit6.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = lookUpEdit10.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = lookUpEdit10.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( sign != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "YQ99" ).ToString( );
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
                    add.Add( gridView1.GetDataRow( i )["YQ99"].ToString( ) );
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
                            cn1 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                            cn2 = "";
                            cn3 = "";
                            cn4 = "";
                            cn5 = "";
                            if ( string.IsNullOrEmpty( cn6 ) )
                                cn6 = gridView1.GetDataRow( i )["YQ12"].ToString( );
                            else
                            {
                                if(!cn6.Contains( gridView1.GetDataRow( i )["YQ12"].ToString( ) ) )
                                    cn6 += "," + gridView1.GetDataRow( i )["YQ12"].ToString( );
                            }
                            //[YQ109] * [YQ15]
                            decimal yq109 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ109"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["YQ109"].ToString( ) );
                            decimal yq15 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["YQ15"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["YQ15"].ToString( ) );
                            if ( sum == 0 )
                                sum = yq109 * yq15;
                            else
                                sum = sum + yq109 * yq15;
                            cn8 = 0.ToString( );
                            cn9 = gridView1.GetDataRow( i )["YQ99"].ToString( );
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }
                    cn7 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
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
