using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using Mulaolao;

namespace SelectAll
{
    public partial class CheckOutQueryAll : FormBase
    {
        public CheckOutQueryAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        DataTable oddNum, supplier, num, contractNum, no, productName, tableQuery;

        MulaolaoBll.Bll.CheckOutBll bll = new MulaolaoBll.Bll.CheckOutBll( );

        private void CheckOutQueryAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged (object sender,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assignMent ( )
        {
            DataTable tableOnly = bll . GetDataTableOnly ( );
            oddNum = tableOnly . DefaultView . ToTable ( true ,"AK014" );
            comboBox1.DataSource = oddNum;
            comboBox1.DisplayMember = "AK014";
            comboBox1.Text = "";
            supplier = tableOnly . DefaultView . ToTable ( true ,"AK001" );
            comboBox2 .DataSource = supplier;
            comboBox2.DisplayMember = "AK001";
            comboBox2.Text = "";
            num = tableOnly . DefaultView . ToTable ( true ,"AK002" );
            comboBox3 .DataSource = num;
            comboBox3.DisplayMember = "AK002";
            comboBox3.Text = "";
            contractNum = tableOnly . DefaultView . ToTable ( true ,"AK004" );
            comboBox4 .DataSource = contractNum;
            comboBox4.DisplayMember = "AK004";
            comboBox4.Text = "";
            no = tableOnly . DefaultView . ToTable ( true ,"AK005" );
            comboBox5 .DataSource = no;
            comboBox5.DisplayMember = "AK005";
            comboBox5.Text = "";
            productName = tableOnly . DefaultView . ToTable ( true ,"AK006" );
            comboBox6 .DataSource = productName;
            comboBox6.DisplayMember = "AK006";
            comboBox6.Text = "";
            cmbYear . DataSource = tableOnly . DefaultView . ToTable ( true ,"AK" );
            cmbYear . DisplayMember = "AK";
            cmbYear . Text = string . Empty;
        }

        //fuzzy query
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( oddNum ,comboBox1 ,"AK014" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( supplier ,comboBox2 ,"AK001" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( num ,comboBox3 ,"AK002" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( contractNum ,comboBox4 ,"AK004" );
            Cursor = Cursors.Default;
        }
        private void comboBox5_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( no ,comboBox5 ,"AK005" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productName ,comboBox6 ,"AK006" );
            Cursor = Cursors.Default;
        }

        //query
        string strWhere = "1=1";
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND AK014='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND AK001='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND AK002='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND AK004='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox5.Text ) )
                strWhere = strWhere + " AND AK005='" + comboBox5.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
                strWhere = strWhere + " AND AK006='" + comboBox6.Text + "'";
            if ( !string . IsNullOrEmpty ( cmbYear . Text ) )
                strWhere = strWhere + " AND AK002 LIKE '" + cmbYear . Text + "%'";

            pageToDataTable( );
        }
        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            try
            {
                bll.DeleteOfCheck( );
            }
            catch { }
            int count = bll.GetCheckOutCount( strWhere );
            userControl11.DrawCount( count );
            pageByChanged( );
        }
        void pageByChanged ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetListByPage( strWhere ,"" ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetListByPage( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        //clear
        private void button6_Click ( object sender ,EventArgs e )
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = "";
        }
        //value
        //check
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            } 
        }
        //Check All
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                }
            }
        }
        //Deselect All
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                        gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }
        //sure
        List<string> list = new List<string>( );
        protected override void sure ( )
        {
            base.sure( );

            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["idx"].ToString( ) ) )
                    {
                        list.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                    }
                }
            }

            if ( list.Count > 0 )
            {
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( list );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
            else
                this.Close( );
        }
    }
}
