using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class PayMentTwoAll : FormBase
    {
        public PayMentTwoAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        //public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.PayMentBll _bll = new MulaolaoBll.Bll.PayMentBll( );
        DataTable tableQuery;

        private void PayMentTwoAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assignMent ( )
        {
            lookUpEdit1.Properties.DataSource = _bll.GetDataTableOfOddNumOne( );
            lookUpEdit1.Properties.DisplayMember = "AP001";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND AP001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( textBox1.Text ) )
                strWhere = strWhere + " AND AP009='" + dateTimePicker1.Value + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = _bll.GetCountOne( strWhere );
            userControl11.DrawCount( count );
            pageByChanged( );
        }
        void pageByChanged ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByChangeOne( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByChangeOne( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yyyy年MM月dd日" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = null;
            lookUpEdit1.ItemIndex = -1;
            textBox1.Text = "";
        }

        string cn1 = "",cn2="";
        //Value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 =cn2= gridView1.GetFocusedRowCellValue( "AP001" ).ToString( );
            cn1 = "AP001='" + cn1 + "'";
            this . DialogResult = DialogResult . OK;
        }

        public string getOdd 
        {
            get
            {
                return cn1;
            }
        }

        public string getOddNum
        {
            get
            {
                return cn2;
            }
        }

        protected override void sure ( )
        {
            cn1 = string . Empty;
            string oddNum = string . Empty;
            int [ ] rows = gridView1 . GetSelectedRows ( );
            for ( int i = 0 ; i < rows . Length ; i++ )
            {
                oddNum = gridView1 . GetDataRow ( i ) [ "AP001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( cn1 ) )
                    cn1 = "'" + oddNum + "'";
                else if ( !cn1 . Contains ( oddNum ) )
                    cn1 = cn1 + "," + "'" + oddNum + "'";
            }

            if ( !string . IsNullOrEmpty ( cn1 ) )
                cn1 = "AP001 IN (" + cn1 + ")";

            this . DialogResult = DialogResult . OK;

            base . sure ( );
        }

    }
}
