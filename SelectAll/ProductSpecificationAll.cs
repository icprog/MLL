using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductSpecificationAll :FormBase
    {
        MulaolaoBll.Bll.ProductSpecificationBll _bll=null; DataTable tableQuery;

        public ProductSpecificationAll ( string text )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . ProductSpecificationBll ( );
            tableQuery = new DataTable ( );
            this . Text = text;
        }

        private void ProductSpecificationAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF001" );
            lupOdd . Properties . DisplayMember = "DF001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF002" );
            lupPro . Properties . DisplayMember = "DF002";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF004" );
            lupNum . Properties . DisplayMember = "DF004";
            lupNo . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF003" );
            lupNo . Properties . DisplayMember = "DF003";
            lupSup . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF008" );
            lupSup . Properties . DisplayMember = "DF008";
            lupPer . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"DF009" );
            lupPer . Properties . DisplayMember = "DF009";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND DF001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND DF002='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND DF004='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNo . Text ) )
                strWhere = strWhere + " AND DF003='" + lupNo . Text + "'";
            if ( !string . IsNullOrEmpty ( lupSup . Text ) )
                strWhere = strWhere + " AND DF008='" + lupSup . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND DF009='" + lupPer . Text + "'";

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
            oddNum = gridView1 . GetFocusedRowCellValue ( "DF001" ) . ToString ( );
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

        //clear
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupOdd . EditValue = lupPro . EditValue = lupNum . EditValue = lupNo . EditValue = lupSup . EditValue = lupPer . EditValue = null;
        }
    }
}
