using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class QualityFinalInspsctionAll :FormBase
    {
        MulaolaoBll.Bll.QualityFinalInspsctionBll _bll=null;

        DataTable tableQuery;

        public QualityFinalInspsctionAll ( string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            _bll = new MulaolaoBll . Bll . QualityFinalInspsctionBll ( );
            tableQuery = new DataTable ( );
            this . Text = text;
        }

        private void QualityFinalInspsctionAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DI001" );
            lupOdd . Properties . DisplayMember = "DI001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DI003" );
            lupPro . Properties . DisplayMember = "DI003";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DI002" );
            lupNum . Properties . DisplayMember = "DI002";
            lupNo . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DI004" );
            lupNo . Properties . DisplayMember = "DI004";
            lupPer . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DI011" );
            lupPer . Properties . DisplayMember = "DI011";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND DI001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND DI003='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND DI002='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNo . Text ) )
                strWhere = strWhere + " AND DI004='" + lupNo . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND DI011='" + lupPer . Text + "'";

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
            lupNo . EditValue = lupNum . EditValue = lupOdd . EditValue = lupPer . EditValue = lupPro . EditValue = null;
        }

        string oddNum=string .Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "DI001" ) . ToString ( );
            zx = gridView1 . GetFocusedRowCellValue ( "RES05" ) . ToString ( );
            if ( !string . IsNullOrEmpty ( oddNum ) )
                this . DialogResult = DialogResult . OK;
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
