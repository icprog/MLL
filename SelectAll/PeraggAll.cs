using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class PeraggAll :FormBase
    {

        MulaolaoBll.Bll.PeraggBll _bll=null;

        DataTable tableView;

        public PeraggAll (string text )
        {
            InitializeComponent ( );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . PeraggBll ( );
            tableView = new DataTable ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );


        }

        private void PeraggAll_Load ( object sender ,EventArgs e )
        {
            
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
            lupOdd . Properties . DataSource = _bll . getTableOnly ( "CA001" );
            lupOdd . Properties . DisplayMember = "CA001";
            lupUser . Properties . DataSource = _bll . getTableOnly ( "CA016" );
            lupUser . Properties . DisplayMember = "CA016";
            lupYear . Properties . DataSource = _bll . getTableOnly ( "CA017" );
            lupYear . Properties . DisplayMember = "CA017";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupOdd . Text ) )
                strWhere += " AND CA001='" + lupOdd . Text + "'";
            if ( !string . IsNullOrEmpty ( lupUser . Text ) )
                strWhere += " AND CA016='" + lupUser . Text + "'";
            if ( !string . IsNullOrEmpty ( lupYear . Text ) )
                strWhere += " AND CA017='" + lupYear . Text + "'";

            pageToDataTable ( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = _bll . getCount ( strWhere );
            userControl11 . DrawCount ( count );
            pageByChanged ( );
        }
        void pageByChanged ( )
        {
            if ( userControl11 . pageIndex <= 1 )
                tableView = _bll . getTableByChange ( strWhere ,0 ,userControl11 . pageSize );
            else
                tableView = _bll . getTableByChange ( strWhere ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + 1 ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + userControl11 . pageSize );
            gridControl1 . DataSource = tableView;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lupOdd . EditValue = lupUser . EditValue = lupYear . EditValue = null;
        }

        string oddNum=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . RowCount - 1 )
            {
                oddNum = gridView1 . GetFocusedRowCellValue ( "CA001" ) . ToString ( );
                this . DialogResult = System . Windows . Forms . DialogResult . OK;
            }
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
