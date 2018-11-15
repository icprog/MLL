using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class GongXuGongZiAll : FormBase
    {
        public GongXuGongZiAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        MulaolaoBll.Bll.GongXuGongZiBll bll = new MulaolaoBll.Bll.GongXuGongZiBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable dt, tableQuery;

        private void GongXuGongZiAll_Load ( object sender ,EventArgs e )
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
            dt = bll.GetDataTableOnly( );
            comboBox1.DataSource = dt.DefaultView.ToTable( true ,"DS21" );
            comboBox1.DisplayMember = "DS21";
            comboBox1.Text = "";
            comboBox2.DataSource = dt.DefaultView.ToTable( true ,"DS22" );
            comboBox2.DisplayMember = "DS22";
            comboBox2.Text = "";
            comboBox3.DataSource = dt.DefaultView.ToTable( true ,"DS01" );
            comboBox3.DisplayMember = "DS01";
            comboBox3.Text = "";
            comboBox4.DataSource = dt.DefaultView.ToTable( true ,"DS24" );
            comboBox4.DisplayMember = "DS24";
            comboBox4.Text = "";
            comboBox5.DataSource = dt.DefaultView.ToTable( true ,"DS26" );
            comboBox5.DisplayMember = "DS26";
            comboBox5.Text = "";
            comboBox6.DataSource = dt.DefaultView.ToTable( true ,"DS02" );
            comboBox6.DisplayMember = "DS02";
            comboBox6.Text = "";
        }
        //query queey
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS21" ) ,comboBox1 ,"DS21" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS22" ) ,comboBox2 ,"DS22" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS01" ) ,comboBox3 ,"DS01" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS24" ) ,comboBox4 ,"DS24" );
            Cursor = Cursors.Default;
        }
        private void comboBox5_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS26" ) ,comboBox5 ,"DS26" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( dt.DefaultView.ToTable( true ,"DS02" ) ,comboBox6 ,"DS02" );
            Cursor = Cursors.Default;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND DS21='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND DS22='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND DS01='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND DS24='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox5.Text ) )
                strWhere = strWhere + " AND DS26='" + comboBox5.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
                strWhere = strWhere + " AND DS02='" + comboBox6.Text + "'";

            pageToDataTable( );
        }
        
        ////Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = bll.GetGongXuCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = "";
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "DS21" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "DS24" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
            cn4 = gridView1.GetFocusedRowCellValue( "DS01" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
    }
}
