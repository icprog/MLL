using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ContractreviewQuery :FormBase
    {
        MulaolaoBll.Bll.ContractreviewBll _bll=null;
        DataTable tableQuery;
        
        public ContractreviewQuery ( string text )
        {
            InitializeComponent ( );

            this . Text = text;
            _bll = new MulaolaoBll . Bll . ContractreviewBll ( );
            tableQuery = new DataTable ( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        private void ContractreviewQuery_Load ( object sender ,EventArgs e )
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
            DataTable table = _bll . getTableOnly ( );
            lupNum . Properties . DataSource = table . DefaultView . ToTable ( true ,"PQF01" );
            lupNum . Properties . DisplayMember = "PQF01";
            lupProName . Properties . DataSource = table . DefaultView . ToTable ( true ,"PQF04" );
            lupProName . Properties . DisplayMember = "PQF04";
            lupCon . Properties . DataSource = table . DefaultView . ToTable ( true ,"HT02" );
            lupCon . Properties . DisplayMember = "HT02";
            lupName . Properties . DataSource = table . DefaultView . ToTable ( true ,"PQF67" );
            lupName . Properties . DisplayMember = "PQF67";
            lupWork . Properties . DataSource = table . DefaultView . ToTable ( true ,"HT66" );
            lupWork . Properties . DisplayMember = "HT66";
        }

        //query
        string strWhere="1=1";
        private void btnOk_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lupCon . Text ) )
                strWhere = strWhere + " AND HT02='" + lupCon . Text + "'";
            if ( !string . IsNullOrEmpty ( lupNum . Text ) )
                strWhere = strWhere + " AND PQF01='" + lupNum . Text + "'";
            if ( !string . IsNullOrEmpty ( lupProName . Text ) )
                strWhere = strWhere + " AND PQF04='" + lupProName . Text + "'";
            if ( !string . IsNullOrEmpty ( lupName . Text ) )
                strWhere = strWhere + " AND PQF67='" + lupName . Text + "'";
            if ( !string . IsNullOrEmpty ( lupWork . Text ) )
                strWhere = strWhere + " AND HT66='" + lupWork . Text + "'";


            pageToDataTable ( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = _bll . GetCount ( strWhere );
            userControl11 . DrawCount ( count );
            pageByChanged ( );
        }
        void pageByChanged ( )
        {
            if ( userControl11 . pageIndex <= 1 )
                tableQuery = _bll . GetDataTableByChange ( strWhere ,0 ,userControl11 . pageSize );
            else
                tableQuery = _bll . GetDataTableByChange ( strWhere ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + 1 ,userControl11 . pageSize * ( userControl11 . pageIndex - 1 ) + userControl11 . pageSize );
            gridControl1 . DataSource = tableQuery;
        }

        string cn1=string.Empty,cn2=string.Empty;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1 . GetFocusedRowCellValue ( "HT64" ) . ToString ( );
            cn2 = gridView1 . GetFocusedRowCellValue ( "RES05" ) . ToString ( );

            this . DialogResult = DialogResult . OK;
        }

        public string getOdd
        {
            get
            {
                return cn1;
            }
        }

        public string getState
        {
            get
            {
                return cn2;
            }
        }

        //clear
        private void btnClear_Click ( object sender ,EventArgs e )
        {
            lupCon . EditValue = lupName . EditValue = lupNum . EditValue = lupProName . EditValue = lupWork . EditValue = null;
        }

    }
}
