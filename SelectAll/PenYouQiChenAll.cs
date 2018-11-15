using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class PenYouQiChenAll : FormBase
    {
        public PenYouQiChenAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.PenYouQiChenBll bll = new MulaolaoBll.Bll.PenYouQiChenBll( );
         
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        DataTable tableQuery;
        public string signChan = "", variable = "";
        private void PenYouQiChenAll_Load ( object sender ,EventArgs e )
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
            searchLookUpEdit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY33" );
            searchLookUpEdit1.Properties.DisplayMember = "PY33";
            searchLookUpEdit2.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY01" );
            searchLookUpEdit2.Properties.DisplayMember = "PY01";
            searchLookUpEdit3.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY38" );
            searchLookUpEdit3.Properties.DisplayMember = "PY38";
            searchLookUpEdit4.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY30" );
            searchLookUpEdit4.Properties.DisplayMember = "PY30";
            searchLookUpEdit5.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY31" );
            searchLookUpEdit5.Properties.DisplayMember = "PY31";
            searchLookUpEdit7.Properties.DataSource = dt.DefaultView.ToTable( true ,"PY06" );
            searchLookUpEdit7.Properties.DisplayMember = "PY06";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( searchLookUpEdit1.Text ) )
                strWhere = strWhere + " AND PY33='" + searchLookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( searchLookUpEdit2.Text ) )
                strWhere = strWhere + " AND PY01='" + searchLookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( searchLookUpEdit3.Text ) )
                strWhere = strWhere + " AND PY38='" + searchLookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( searchLookUpEdit4.Text ) )
                strWhere = strWhere + " AND PY30='" + searchLookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( searchLookUpEdit5.Text ) )
                strWhere = strWhere + " AND PY31='" + searchLookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( searchLookUpEdit7.Text ) )
                strWhere = strWhere + " AND PY06='" + searchLookUpEdit7.Text + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signChan != "1" )
            {
                count = bll.GetCount( strWhere );
            }
            else
            {
                count = bll.GetCoun( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signChan == "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize*10 );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,(userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1)*10 ,(userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize)*10 );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPages( strWhere ,0 ,userControl11.pageSize*10 );
                else
                    tableQuery = bll.GetDataTableByPages( strWhere ,(userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1) * 10 ,(userControl11.pageSize * ( userControl11.pageIndex - 1 )*10 + userControl11.pageSize)*10 );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
            gridView1 . BestFitColumns ( );
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            searchLookUpEdit1.Text = searchLookUpEdit2.Text = searchLookUpEdit3.Text = searchLookUpEdit4.Text = searchLookUpEdit5.Text = searchLookUpEdit7.Text = "";
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signChan != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "PY33" ).ToString( );
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
            if ( signChan == "1" )
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

            if ( signChan == "1" )
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

            if ( signChan == "1" )
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
                    add.Add( gridView1.GetDataRow( i )["PY33"].ToString( ) );
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
            if ( signChan == "1" )
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
                    add.Clear( );
                    decimal sum = 0;
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            cn1 = gridView1.GetDataRow( i )["PY33"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["PY01"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["PY30"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["PY38"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["PY31"].ToString( );
                            cn6 = gridView1.GetDataRow( i )["PY27"].ToString( );
                            if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["U1"].ToString( ) ) )
                                sum = sum + Convert.ToDecimal( gridView1.GetDataRow( i )["U1"].ToString( ) );
                            cn7 = gridView1.GetDataRow( i )["PY07"].ToString( );
                            cn8 = "";
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }

                    cn9 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
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
