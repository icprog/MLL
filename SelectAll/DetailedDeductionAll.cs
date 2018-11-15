using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class DetailedDeductionAll : FormBase
    {
        public DetailedDeductionAll ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.DetailedDeductionBll _bll = new MulaolaoBll.Bll.DetailedDeductionBll( );
        DataTable tableQuery;
        string cn1 = "";

        private void DetailedDeductionAll_Load ( object sender ,EventArgs e )
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
            DataTable tableOnly = _bll . GetDataTableOnly ( );
            lookUpEdit1 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"WZ001" );
            lookUpEdit1 . Properties . DisplayMember = "WZ001";
            lookUpEdit2 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"WZ004" );
            lookUpEdit2 . Properties . DisplayMember = "WZ004";
            lookUpEdit3 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"WZ009" );
            lookUpEdit3 . Properties . DisplayMember = "WZ009";
            lookUpEdit4 . Properties . DataSource = tableOnly . DefaultView . ToTable ( true ,"WZ" );
            lookUpEdit4 . Properties . DisplayMember = "WZ";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND WZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND WZ004='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND WZ009='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( textBox1.Text ) )
                strWhere = strWhere + " AND WZ002='" + textBox1.Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit4 . Text ) )
                strWhere = strWhere + " AND WZ002 LIKE '" + lookUpEdit4 . Text + "%'";
            pageToDataTable ( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = -1;
            textBox1.Text = "";
        }

        //Value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "WZ001" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        private void gridView1_Click ( object sender ,EventArgs e )
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

        protected override void sure ( )
        {
            base.sure( );
            byValue( );
        }
        void byValue ( )
        {
            if ( gridView1.RowCount > 0 )
            {
                add.Clear( );
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    {
                        add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                    }
                }
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( "1" ,add );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        //Event
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yyyy-MM-dd" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
    }
}
