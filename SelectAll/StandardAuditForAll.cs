using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class StandardAuditForAll :FormBase
    {
        MulaolaoBll.Bll.StandardAuditForBll _bll=null;
        DataTable tableQuery;

        public StandardAuditForAll ( string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . StandardAuditForBll ( );
            tableQuery = new DataTable ( );
        }

        private void StandardAuditForAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH001" );
            lupOdd . Properties . DisplayMember = "CH001";
            lupUser . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CH005" );
            lupUser . Properties . DisplayMember = "CH005";
        }

        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND CH001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupUser . Text ) )
                strWhere = strWhere + " AND CH005='" + lupUser . Text + "'";

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
            lupUser . EditValue = lupOdd . EditValue = null;
        }

        string oddNum=string.Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "CH001" ) . ToString ( );
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
