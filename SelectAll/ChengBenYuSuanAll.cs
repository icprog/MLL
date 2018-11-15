using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ChengBenYuSuanAll : FormBase
    {
        public ChengBenYuSuanAll ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }


        MulaolaoBll.Bll.ChengBenYuHeSuanAllBll bll = new MulaolaoBll.Bll.ChengBenYuHeSuanAllBll( );
        DataTable tableQuery;
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void ChengBenYuSuanAll_Load ( object sender ,EventArgs e )
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
            comboBox6.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN001" );
            comboBox6.DisplayMember = "AN001";
            comboBox1.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN002" );
            comboBox1.DisplayMember = "AN002";
            comboBox2.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN003" );
            comboBox2.DisplayMember = "AN003";
            comboBox3.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN005" );
            comboBox3.DisplayMember = "AN005";
            comboBox4.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN004" );
            comboBox4.DisplayMember = "AN004";
            comboBox7.DataSource = bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN006" );
            comboBox7.DisplayMember = "AN006";
        }
        //fuzzy query
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN001" ) ,comboBox6 ,"AN001" );
            Cursor = Cursors.Default;
        }
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
      {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN002" ) ,comboBox1 ,"AN002" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN003" ) ,comboBox2 ,"AN003" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN005" ) ,comboBox3 ,"AN005" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN004" ) ,comboBox4 ,"AN004" );
            Cursor = Cursors.Default;
        }
        private void comboBox7_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( bll.GetDataTableAll( ).DefaultView.ToTable( true ,"AN006" ) ,comboBox7 ,"AN006" );
            Cursor = Cursors.Default;
        }


        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
                strWhere = strWhere + " AND AN001='" + comboBox6.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND AN002='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND AN003='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND AN005='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND AN004='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                strWhere = strWhere + " AND AN006='" + comboBox7.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = bll.GetChengCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox6.Text = comboBox7.Text = "";
        }

        //Value
        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "AN001" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
