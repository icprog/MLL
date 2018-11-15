using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;
using Mulaolao;

namespace SelectAll
{
    public partial class FrmchanpingaishanQuery :FormBase
    {
        MulaolaoBll.Bll.ChanPinGaiShanBll bll;
        DataTable tableQuery;

        public FrmchanpingaishanQuery ( )
        {
            InitializeComponent ( );
            bll = new MulaolaoBll . Bll . ChanPinGaiShanBll ( );
            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View1 ,View2 ,View3 ,View4 ,gridView4 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView4 } );

            assignMent ( );

            userControl11 . OnPageChanged += new EventHandler ( userControl11_OnPageChanged );

        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable ( );
        }

        void assignMent ( )
        {
            DataTable tableOnly = bll . getOnly ( );
            txtGS01 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"GS01" );
            txtGS01 . Properties . DisplayMember = "GS01";
            txtGS34 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"GS34" );
            txtGS34 . Properties . DisplayMember = "GS34";
            txtGS47 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"GS47" );
            txtGS47 . Properties . DisplayMember = "GS47";
            txtGS48 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"GS48" );
            txtGS48 . Properties . DisplayMember = "GS48";
        }

        string strWhere = "1=1";
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( txtGS01 . Text ) )
                strWhere = strWhere + " AND GS01='" + txtGS01 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtGS34 . Text ) )
                strWhere = strWhere + " AND GS34='" + txtGS34 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtGS47 . Text ) )
                strWhere = strWhere + " AND GS47='" + txtGS47 . Text + "'";
            if ( !string . IsNullOrEmpty ( txtGS48 . Text ) )
                strWhere = strWhere + " AND GS48='" + txtGS48 . Text + "'";

            pageToDataTable ( );
        }

        private void btnClear_Click ( object sender ,EventArgs e )
        {
            txtGS01 . EditValue = txtGS34 . EditValue = txtGS47 . EditValue = txtGS48 . EditValue = null;
        }

        void pageToDataTable ( )
        {
            int count = bll . getCount ( strWhere );
            userControl11 . DrawCount ( count );
            pageByChange ( );
        }

        void pageByChange ( )
        {
            if ( userControl11 . pageIndex <= 1 )
                tableQuery = bll . GetDataTableByChange ( strWhere ,0 ,userControl11 . pageSize );
            else
                tableQuery = bll . GetDataTableByChange ( strWhere ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + 1 ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + userControl11 . pageSize );

            gridControl1 . DataSource = tableQuery;
        }

        DataRow row;
        private void gridView4_DoubleClick ( object sender ,EventArgs e )
        {
            row = gridView4 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            this . DialogResult = DialogResult . OK;
        }

        public DataRow getRow
        {
            get
            {
                return row;
            }
        }

    }
}