using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class PayMentTreAll : FormBase
    {
        public PayMentTreAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        //public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //public event PassDataBetweenFormHandler PassDataBetweenForm;

        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );

        DataTable tableQuery;

        private void PayMentTreAll_Load ( object sender ,EventArgs e )
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
            DataTable da = _bll.GetDataTableOnlyOne( );
            lookUpEdit1.Properties.DataSource = da.DefaultView.ToTable( true ,"AQ001" );
            lookUpEdit1.Properties.DisplayMember = "AQ001";
            lookUpEdit2.Properties.DataSource = da.DefaultView.ToTable( true ,"AQ002" );
            lookUpEdit2.Properties.DisplayMember = "AQ002";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND AQ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND AQ002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( textBox1.Text ) )
                strWhere = strWhere + " AND AQ003='" + dateTimePicker1.Value + "'";
            pageToDataTable( );
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = -1;
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            count = _bll.GetCountTwo( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByChangeTwo( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByChangeTwo( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //Value
        string cn1 = "",cn2="";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 =cn2= gridView1.GetFocusedRowCellValue( "AQ001" ).ToString( );
            cn1 = "AQ001='" + cn1 + "'";
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string getOdd
        {
            get
            {
                return cn1;
            }
        }

        public string getOddNum
        {
            get
            {
                return cn2;
            }
        }

        protected override void sure ( )
        {
            cn1 = string . Empty;
            string oddNum = string . Empty;
            int [ ] rows = gridView1 . GetSelectedRows ( );
            for ( int i = 0 ; i < rows . Length ; i++ )
            {
                oddNum = gridView1 . GetDataRow ( i ) [ "AQ001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( cn1 ) )
                    cn1 = "'" + oddNum + "'";
                else if ( !cn1 . Contains ( oddNum ) )
                    cn1 = cn1 + "," + "'" + oddNum + "'";
            }

            if ( !string . IsNullOrEmpty ( cn1 ) )
                cn1 = "AQ001 IN (" + cn1 + ")";

            this . DialogResult = System . Windows . Forms . DialogResult . OK;
            base . sure ( );
        }

    }
}
