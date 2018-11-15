using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class StandardAuditFivAll :FormBase
    {
        MulaolaoBll.Bll.StandardAuditFivBll _bll=null;
        DataTable tableQuery;

        public StandardAuditFivAll ( string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . StandardAuditFivBll ( );
            tableQuery = new DataTable ( );

        }

        private void StandardAuditFivAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ001" );
            lupOdd . Properties . DisplayMember = "CJ001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ003" );
            lupPro . Properties . DisplayMember = "CJ003";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ002" );
            lupNum . Properties . DisplayMember = "CJ002";
            lupUser . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CJ009" );
            lupUser . Properties . DisplayMember = "CJ009";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND CJ001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND CJ003='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND CJ002='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupUser . Text ) )
                strWhere = strWhere + " AND CJ009='" + lupUser . Text + "'";

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

        string oddNum=string.Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "CJ001" ) . ToString ( );
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
