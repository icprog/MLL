using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using Mulaolao;

namespace SelectAll
{
    public partial class ContracToDoAJobAll : FormBase
    {
        public ContracToDoAJobAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.ContractToDoAJobBll _bll = new MulaolaoBll.Bll.ContractToDoAJobBll( );
        public string signChan = "", variable = "";
        DataTable tableQuery;

        private void ContracToDoAJobAll_Load ( object sender ,EventArgs e )
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
            DataTable da = _bll.GetDataTableOfOnly( );
            lookUpEdit1.Properties.DataSource = da.DefaultView.ToTable( true ,"BA003" );
            lookUpEdit1.Properties.DisplayMember = "BA003";
            lookUpEdit2.Properties.DataSource = da.DefaultView.ToTable( true ,"BA001" );
            lookUpEdit2.Properties.DisplayMember = "BA001";
            lookUpEdit3.Properties.DataSource = da.DefaultView.ToTable( true ,"BA052" );
            lookUpEdit3.Properties.DisplayMember = "BA052";
            lookUpEdit4.Properties.DataSource = da.DefaultView.ToTable( true ,"BA051" );
            lookUpEdit4.Properties.DisplayMember = "BA051";
            lookUpEdit5.Properties.DataSource = da.DefaultView.ToTable( true ,"BA053" );
            lookUpEdit5.Properties.DisplayMember = "BA053";
            lookUpEdit6.Properties.DataSource = da.DefaultView.ToTable( true ,"BA044" );
            lookUpEdit6.Properties.DisplayMember = "BA044";
            lookUpEdit6.Text = variable;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( lookUpEdit1.EditValue != null )
                strWhere = strWhere + " AND BA003='" + lookUpEdit1.Text + "'";
            if ( lookUpEdit2.EditValue != null )
                strWhere = strWhere + " AND BA001='" + lookUpEdit2.Text + "'";
            if ( lookUpEdit3.EditValue != null )
                strWhere = strWhere + " AND BA052='" + lookUpEdit3.Text + "'";
            if ( lookUpEdit4.EditValue != null )
                strWhere = strWhere + " AND BA051='" + lookUpEdit4.Text + "'";
            if ( lookUpEdit5.EditValue != null )
                strWhere = strWhere + " AND BA053='" + lookUpEdit5.Text + "'";
            if ( lookUpEdit6.EditValue != null )
                strWhere = strWhere + " AND BA044='" + lookUpEdit6.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChange
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
                    tableQuery = _bll.GetDataTableByChanges( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = _bll.GetDataTableByChanges( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = -1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signChan != "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "BA003" ).ToString( );
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
                    add.Add( gridView1.GetDataRow( i )["BA003"].ToString( ) );
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
                    decimal sum = 0;
                    add.Clear( );
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            cn1 = gridView1.GetDataRow( i )["BA044"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["BA001"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["BA051"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["BA052"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["BA053"].ToString( );
                            cn6 = "";
                            if ( sum == 0 )
                                sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["U2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U2"].ToString( ) );
                            else
                                sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U2"].ToString( ) ) );
                            cn8 = gridView1.GetDataRow( i )["BA054"].ToString( );
                            cn9 = gridView1.GetDataRow( i )["BA003"].ToString( );
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
