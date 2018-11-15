using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ProductCostSummaryAll : FormBase
    {
        public ProductCostSummaryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        DataTable num, productName, no, contractNum, audit, productionWork, tableQuery;
        
        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;

        private void ProductCostSummaryAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );
            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToChange( );
        }

        //Bind data source
        void assignMent ( )
        {
            DataTable dr = bll.GetDataTableAll( );
            num = dr.DefaultView.ToTable( true ,"AM002" );
            comboBox1.DataSource = num;
            comboBox1.DisplayMember = "AM002";
            comboBox1.Text = "";
            productName = dr.DefaultView.ToTable( true ,"AM003" );
            comboBox2.DataSource = productName;
            comboBox2.DisplayMember = "AM003";
            comboBox2.Text = "";
            no = dr.DefaultView.ToTable( true ,"AM005" );
            comboBox3.DataSource = no;
            comboBox3.DisplayMember = "AM005";
            comboBox3.Text = "";
            contractNum = dr.DefaultView.ToTable( true ,"AM004" );
            comboBox4.DataSource = contractNum;
            comboBox4.DisplayMember = "AM004";
            comboBox4.Text = "";
            audit =dr.DefaultView.ToTable( true ,"AM011" );
            comboBox6.DataSource = audit;
            comboBox6.DisplayMember = "AM011";
            comboBox6.Text = "";
            productionWork = dr.DefaultView.ToTable( true ,"AM009" );
            comboBox7.DataSource = productionWork;
            comboBox7.DisplayMember = "AM009";
            comboBox7.Text = "";
        }

        //queer query
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( num ,comboBox1 ,"AM002" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productName ,comboBox2 ,"AM003" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( no ,comboBox3 ,"AM005" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( contractNum ,comboBox4 ,"AM004" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( audit ,comboBox6 ,"AM011" );
            Cursor = Cursors.Default;
        }
        private void comboBox7_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productionWork ,comboBox7 ,"AM009" );
            Cursor = Cursors.Default;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND AM002='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND AM003='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND AM005='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND AM004='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
                strWhere = strWhere + " AND AM011='" + comboBox6.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                strWhere = strWhere + " AND AM009='" + comboBox7.Text + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND SUBSTRING(CONVERT(VARCHAR,PQF31),0,5)='" + dateEdit1 . Text + "'";
            if ( !string . IsNullOrEmpty ( dateEdit2 . Text ) )
                strWhere = strWhere + " AND SUBSTRING(CONVERT(VARCHAR,PQF13),0,5)='" + dateEdit2 . Text + "'";

            pageToChange ( );
        }

        //Bind data source and pageChange
        void pageToChange ( )
        {
            int count = bll.ProductCostSummaryCount( strWhere );
            userControl11.DrawCount( count );
            pageChange( );
        }
        void pageChange ( )
        {
            try
            {
                //编辑526标记  回写状态AK018为T
                bll.UpdateGetDataTable( );
            }
            catch { }


            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );

            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1 . Text = comboBox2 . Text = comboBox3 . Text = comboBox4 . Text = comboBox6 . Text = comboBox7 . Text = dateEdit1 . Text =dateEdit2.Text= "";
        }

        //Value
        private void gridView1_RowCellClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }
        //checkAll
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
        //unCheckAll
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
        List<string> add = new List<string>( );
        bool repeat ( )
        {
            add.Clear( );
            bool result = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    add.Add( gridView1.GetDataRow( i )["CP03"].ToString( ) );
                }
            }

            foreach ( string str in add )
            {
                for ( int k = add.Count - 1 ; k >= 0 ; k-- )
                {
                    if ( str != add[k] )
                        result = false;
                    else
                        result = true;
                }
            }

            return result;
        }
        protected override void sure ( )
        {
            base.sure( );

            if ( gridView1.RowCount > 0 )
            {
                //    bool result = repeat( );
                //    if ( result == false )
                //        MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                //    else
                //    {
                add.Clear( );
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    {
                        add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                    }
                }
                //PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( add );
                //if ( PassDataBetweenForm != null )
                //{
                //    PassDataBetweenForm( this ,args );
                //}
                //this.Close( );
                //}

                this . DialogResult = DialogResult . OK;
            }
        }
        protected override void cancel ( )
        {
            this . DialogResult = DialogResult . Cancel;

            base . cancel ( );
        }

        public List<string> idxList
        {
            get
            {
                return add;
            }
        }
        
    }
}
