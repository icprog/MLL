using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class TestResultRecordOneAll :FormBase
    {
        MulaolaoBll.Bll.TestResultRecordOneBll _bll=null;
        DataTable tableQuery;
        
        public TestResultRecordOneAll ( string text )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            _bll = new MulaolaoBll . Bll . TestResultRecordOneBll ( );
            tableQuery = new DataTable ( );

            this . Text = text;
        }

        private void TestResultRecordOneAll_Load ( object sender ,EventArgs e )
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
            lupOdd . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV001" );
            lupOdd . Properties . DisplayMember = "CV001";
            lupPro . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV002" );
            lupPro . Properties . DisplayMember = "CV002";
            lupNum . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV004" );
            lupNum . Properties . DisplayMember = "CV004";
            lupNo . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV003" );
            lupNo . Properties . DisplayMember = "CV003";
            lupSup . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV006" );
            lupSup . Properties . DisplayMember = "CV006";
            lupPer . Properties . DataSource = dt . Copy ( ) . DefaultView . ToTable ( true ,"CV009" );
            lupPer . Properties . DisplayMember = "CV009";
        }

        //query
        string strWhere="1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere = strWhere + " AND CV001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPro . Text ) )
                strWhere = strWhere + " AND CV002='" + lupPro . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND CV004='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNo . Text ) )
                strWhere = strWhere + " AND CV003='" + lupNo . Text + "'";
            if ( !string . IsNullOrEmpty ( lupSup . Text ) )
                strWhere = strWhere + " AND CV006='" + lupSup . Text + "'";
            if ( !string . IsNullOrEmpty ( lupPer . Text ) )
                strWhere = strWhere + " AND CV009='" + lupPer . Text + "'";

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

        string oddNum=string .Empty,zx=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            oddNum = gridView1 . GetFocusedRowCellValue ( "CV001" ) . ToString ( );
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
