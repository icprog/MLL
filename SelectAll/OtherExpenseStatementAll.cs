using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;

namespace SelectAll
{
    public partial class OtherExpenseStatementAll : FormBase
    {
        public OtherExpenseStatementAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        DataTable tableQuery; MulaolaoBll.Bll.OtherExpenseStatementBll _bll = new MulaolaoBll.Bll.OtherExpenseStatementBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void OtherExpenseStatementAll_Load ( object sender ,EventArgs e )
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
            DataTable da = _bll . GetDataTableOnly ( );
            lookUpEdit1 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE015" );
            lookUpEdit1 . Properties . DisplayMember = "BE015";
            lookUpEdit2 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE001" );
            lookUpEdit2 . Properties . DisplayMember = "BE001";
            lookUpEdit3 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE002" );
            lookUpEdit3 . Properties . DisplayMember = "BE002";
            lookUpEdit4 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE004" );
            lookUpEdit4 . Properties . DisplayMember = "BE004";
            lookUpEdit5 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE003" );
            lookUpEdit5 . Properties . DisplayMember = "BE003";
            lookUpEdit6 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE006" );
            lookUpEdit6 . Properties . DisplayMember = "BE006";
            lookUpEdit7 . Properties . DataSource = da . DefaultView . ToTable ( true ,"BE" );
            lookUpEdit7 . Properties . DisplayMember = "BE";
        }
        //query
        string strWhere = "1=1";
        private void button2_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND BE015='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND BE001='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND BE002='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND BE004='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND BE003='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND BE006='" + lookUpEdit6.Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit7 . Text ) )
                strWhere = strWhere + " AND BE002 LIKE '" + lookUpEdit7 . Text + "%'";

            pageToDataTable ( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChanged( );
        }
        void pageByChanged ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button1_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = -1;
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = null;
        }

        //Value
        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "BE015" ).ToString( );
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string getOdd
        {
            get
            {
                return cn1;
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            if ( gridView1 . FocusedRowHandle >= 0 && gridView1 . FocusedRowHandle <= gridView1 . RowCount - 1 )
            {
                int num = gridView1 . FocusedRowHandle;
                if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                    gridView1 . GetDataRow ( num ) [ "check" ] = false;
                else
                    gridView1 . GetDataRow ( num ) [ "check" ] = true;
            }
        }

        protected override void checkAll ( )
        {
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = true;
            }

            base . checkAll ( );
        }
        protected override void unCheckAll ( )
        {
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = false;
            }

            base . unCheckAll ( );
        }

        List<string> add = new List<string>( );
        protected override void sure ( )
        {
            byValue ( );
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
            base . sure ( );
        }
        void byValue ( )
        {
            if ( gridView1 . RowCount > 0 )
            {
                add . Clear ( );
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    if ( gridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                    {
                        add . Add ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    }
                }
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( "1" ,add );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm ( this ,args );
                }
                this . Close ( );
            }
        }

        public List<string> getAdd
        {
            get
            {
                return add;
            }
        }

    }
}
