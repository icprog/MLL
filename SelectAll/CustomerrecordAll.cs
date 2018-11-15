using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class CustomerrecordAll :FormBase
    {
        MulaolaoBll.Bll.CustomerrecordBll _bll=null;
        DataTable tableQuery;

        public CustomerrecordAll ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . CustomerrecordBll ( );
            tableQuery = new DataTable ( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        private void CustomerrecordAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect . SetFilter ( gridView1 );
            assignMent ( );

            userControl11 . OnPageChanged += new EventHandler ( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable ( );
        }

        //Bind data source
        void assignMent ( )
        {
            DataTable dt = _bll . getColumnOnly ( );
            lupOddNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH01" );
            lupOddNum . Properties . DisplayMember = "KH01";
            lupKH02 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH02" );
            lupKH02 . Properties . DisplayMember = "KH02";
            lupKH03 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH03" );
            lupKH03 . Properties . DisplayMember = "KH03";
            lupKH04 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH04" );
            lupKH04 . Properties . DisplayMember = "KH04";
            lupKH05 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"KH05" );
            lupKH05 . Properties . DisplayMember = "KH05";
        }
        
        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOddNum . Text ) )
                strWhere = strWhere + " AND KH01='" + lupOddNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupKH02 . Text ) )
                strWhere = strWhere + " AND KH02='" + lupKH02 . Text + "'";
            if ( !string . IsNullOrEmpty ( lupKH03 . Text ) )
                strWhere = strWhere + " AND KH03='" + lupKH03 . Text + "'";
            if ( !string . IsNullOrEmpty ( lupKH04 . Text ) )
                strWhere = strWhere + " AND KH04='" + lupKH04 . Text + "'";
            if ( !string . IsNullOrEmpty ( lupKH05 . Text ) )
                strWhere = strWhere + " AND KH05='" + lupKH05 . Text + "'";

            pageToDataTable ( );
        }

        //clear
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupOddNum . EditValue = lupKH02 . EditValue = lupKH03 . EditValue = lupKH04 . EditValue = lupKH05 . EditValue = false;
        }

        void pageToDataTable ( )
        {
            int count = _bll . getCount ( strWhere );
            userControl11 . DrawCount ( count );
            pageByChange ( );
        }
        void pageByChange ( )
        {
            if ( userControl11 . pageIndex <= 1 )
                tableQuery = _bll . getDataTableByChange ( strWhere ,0 ,userControl11 . pageSize );
            else
                tableQuery = _bll . getDataTableByChange ( strWhere ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + 1 ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + userControl11 . pageSize );

            gridControl1 . DataSource = tableQuery;
        }

        string oddNum=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "KH01" ) . ToString ( );
            if ( !string . IsNullOrEmpty ( oddNum ) )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string getOddNum
        {
            get
            {
                return oddNum;
            }
        }

    }
}
