using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class QualityReportAll :FormBase
    {
        MulaolaoBll.Bll.QualityReportBll _bll=null;
        DataTable tableQuery;

        public QualityReportAll ( string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            _bll = new MulaolaoBll . Bll . QualityReportBll ( );
            tableQuery = new DataTable ( );
            this . Text = text;
        }
        
        private void QualityReportAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DK001" );
            lupOdd . Properties . DisplayMember = "DK001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DK003" );
            lupPro . Properties . DisplayMember = "DK003";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DK002" );
            lupNum . Properties . DisplayMember = "DK002";
            lupNo . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DK004" );
            lupNo . Properties . DisplayMember = "DK004";
            txtDK006 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DK006" );
            txtDK006 . Properties . DisplayMember = "DK006";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND DK001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND DK003='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND DK002='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNo . Text ) )
                strWhere = strWhere + " AND DK004='" + lupNo . Text + "'";
            if ( !string . IsNullOrEmpty ( txtDK006 . Text ) )
                strWhere = strWhere + " AND DK006='" + txtDK006 . Text + "'";

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
            lupNo . EditValue = lupNum . EditValue = lupOdd . EditValue = lupPro . EditValue = null;
        }

        string oddNum=string.Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "DK001" ) . ToString ( );
            zx = gridView1 . GetFocusedRowCellValue ( "RES05" ) . ToString ( );
            if ( !string . IsNullOrEmpty ( oddNum ) )
                this . DialogResult = DialogResult . OK;
        }

        public string getOdd
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
