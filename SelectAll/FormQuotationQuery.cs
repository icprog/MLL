using System;
using System . Data;
using Mulaolao;
using Mulaolao . Class;

namespace SelectAll
{
    public partial class FormQuotationQuery :FormBase
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        DataTable tableQuery;

        public FormQuotationQuery ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        private void FormQuotationQuery_Load ( object sender ,EventArgs e )
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
            DataTable dt = _bll . getTableOnlyColumn ( );
            txtQUO001 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO001" );
            txtQUO001 . Properties . DisplayMember = "QUO001";
            txtQUO001 . Properties . ValueMember = "QUO001";
            txtQUO002 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO002" );
            txtQUO002 . Properties . DisplayMember = "QUO002";
            txtQUO001 . Properties . ValueMember = "QUO002";
            txtQUO003 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO003" );
            txtQUO003 . Properties . DisplayMember = "QUO003";
            txtQUO001 . Properties . ValueMember = "QUO003";
            txtQUO004 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO004" );
            txtQUO004 . Properties . DisplayMember = "QUO004";
            txtQUO001 . Properties . ValueMember = "QUO004";
            txtQUO005 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO005" );
            txtQUO005 . Properties . DisplayMember = "QUO005";
            txtQUO001 . Properties . ValueMember = "QUO005";
            txtQUO006 . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"QUO006" );
            txtQUO006 . Properties . DisplayMember = "QUO006";
            txtQUO001 . Properties . ValueMember = "QUO006";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( txtQUO001 . Text ) )
                strWhere += " AND QUO001='" + txtQUO001 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtQUO002 . Text ) )
                strWhere += " AND QUO002='" + txtQUO002 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtQUO003 . Text ) )
                strWhere += " AND QUO003='" + txtQUO003 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtQUO004 . Text ) )
                strWhere += " AND QUO004='" + txtQUO004 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtQUO005 . Text ) )
                strWhere += " AND QUO005='" + txtQUO005 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtQUO006 . Text ) )
                strWhere += " AND QUO006='" + txtQUO006 . Text + "'";

            pageToDataTable ( );

        }

        //clear
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            txtQUO001 . Text = txtQUO002 . Text = txtQUO003 . Text = txtQUO004 . Text = txtQUO005 . Text = txtQUO006 . Text = string . Empty;
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
            oddNum = gridView1 . GetFocusedRowCellValue ( "QUO001" ) . ToString ( );
            if ( !string . IsNullOrEmpty ( oddNum ) )
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string getOdd
        {
            get
            {
                return oddNum;
            }
        }

    }

}