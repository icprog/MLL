using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class StandardAuditOneAll :FormBase
    {
        MulaolaoBll.Bll.StandardAuditOneBll _bll=null;
        DataTable tableQuery;

        public StandardAuditOneAll (string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . StandardAuditOneBll ( );
            tableQuery = new DataTable ( );
        }
        
        private void StandardAuditOneAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB001" );
            lupOdd . Properties . DisplayMember = "CB001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB003" );
            lupPro . Properties . DisplayMember = "CB003";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB002" );
            lupNum . Properties . DisplayMember = "CB002";
            lupUser . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CB009" );
            lupUser . Properties . DisplayMember = "CB009";
        }
        //QUERY
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND CB001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND CB003='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND CB002='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupUser . Text ) )
                strWhere = strWhere + " AND CB009='" + lupUser . Text + "'";

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
            lupUser . EditValue = lupPro . EditValue = lupOdd . EditValue = lupNum . EditValue = null;
        }

        string oddNum=string.Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "CB001" ) . ToString ( );
            zx = gridView1 . GetFocusedRowCellValue ( "RES05" ) . ToString ( );
            if ( oddNum != string . Empty )
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
