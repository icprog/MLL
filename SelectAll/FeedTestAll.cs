using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class FeedTestAll :FormBase
    {
        MulaolaoBll.Bll.FeedTestBll _bll=null;
        DataTable tableQuery;

        public FeedTestAll ( string text )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . FeedTestBll ( );
            tableQuery = new DataTable ( );
            this . Text = text;
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        private void FeedTestAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CN001" );
            lupOdd . Properties . DisplayMember = "CN001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CN003" );
            lupPro . Properties . DisplayMember = "CN003";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CN005" );
            lupNum . Properties . DisplayMember = "CN005";
            lupNo . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CN004" );
            lupNo . Properties . DisplayMember = "CN004";
            lupSup . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,new string [ ] { "DGA003" ,"CN002" } );
            lupSup . Properties . DisplayMember = "DGA003";
            lupSup . Properties . ValueMember = "CN002";
            lupPer . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CN012" );
            lupPer . Properties . DisplayMember = "CN012";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND CN001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND CN003='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND CN005='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNo . Text ) )
                strWhere = strWhere + " AND CN004='" + lupNo . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND CN012='" + lupPer . Text + "'";
            if ( !string . IsNullOrEmpty ( lupSup . Text ) )
                strWhere = strWhere + " AND CN002='" + lupSup . EditValue . ToString ( ) + "'";

            pageToDataTable ( );
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

        //clear
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupNo . EditValue = lupNum . EditValue = lupOdd . EditValue = lupPer . EditValue = lupPro . EditValue = lupSup . EditValue = null;
        }

        string oddNum=string.Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "CN001" ) . ToString ( );
            zx = gridView1 . GetFocusedRowCellValue ( "RES05" ) . ToString ( );
            if ( oddNum != string . Empty )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string getOddNum
        {
            get
            {
                return oddNum;
            }
        }

        public string getZX
        {
            get
            {
                return zx;
            }
        }

    }
}
