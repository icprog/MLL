using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WuJinContractQueryAll : FormBase
    {
        public WuJinContractQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.WuJincontractBll bll = new MulaolaoBll.Bll.WuJincontractBll( );
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, tableQuery;
        public string signWuJin = "", variable = "";

        private void WuJinContractQueryAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTableOnly( "PQU97" );
            comboBox1.DataSource = oddNum;
            comboBox1.DisplayMember = "PQU97";
            comboBox1.Text = "";
            num = bll.GetDataTableOnly( "PQU01" );
            comboBox2.DataSource = num;
            comboBox2.DisplayMember = "PQU01";
            comboBox2.Text = "";
            contractNum = bll.GetDataTableOnly( "PQU99" );
            comboBox3.DataSource = contractNum;
            comboBox3.DisplayMember = "PQU99";
            comboBox3.Text = "";
            productName = bll.GetDataTableOnly( "PQU98" );
            comboBox4.DataSource = productName;
            comboBox4.DisplayMember = "PQU98";
            comboBox4.Text = "";
            no = bll.GetDataTableOnly( "PQU100" );
            comboBox5.DataSource = no;
            comboBox5.DisplayMember = "PQU100";
            comboBox5.Text = "";
            supplier = bll.GetDataTableSupplied( );
            comboBox6.DataSource = supplier;
            comboBox6.DisplayMember = "DGA002";
            comboBox6.ValueMember = "PQU03";
            comboBox6.Text = variable;
            materialName = bll.GetDataTableOnly( "PQU10" );
            comboBox7.DataSource = materialName;
            comboBox7.DisplayMember = "PQU10";
            comboBox7.Text = "";
            lon = bll.GetDataTableOnly( "PQU12" );
            comboBox8.DataSource = lon;
            comboBox8.DisplayMember = "PQU12";
            comboBox8.Text = "";
        }
        //queey query
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( oddNum ,comboBox1 ,"PQU97" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( num ,comboBox2 ,"PQU01" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( contractNum ,comboBox3 ,"PQU99" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productName ,comboBox4 ,"PQU98" );
            Cursor = Cursors.Default;
        }
        private void comboBox5_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( no ,comboBox5 ,"PQU100" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( supplier ,comboBox6 ,"DGA002" );
            Cursor = Cursors.Default;
        }
        private void comboBox7_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( materialName ,comboBox7 ,"PQU10" );
            Cursor = Cursors.Default;
        }
        private void comboBox8_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( lon ,comboBox8 ,"PQU12" );
            Cursor = Cursors.Default;
        }
        
        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND PQU97='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND PQU01='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND PQU99='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND PQU98='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox5.Text ) )
                strWhere = strWhere + " AND PQU100='" + comboBox5.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
            {
                if ( supplier.Select( "DGA002='" + comboBox6.Text + "'" ) .Length>0 )
                    strWhere = strWhere + " AND PQU03='" + supplier.Select( "DGA002='" + comboBox6.Text + "'" )[0]["PQU03"].ToString( ) + "'";
            }
               
            if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                strWhere = strWhere + " AND PQU10='" + comboBox7.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox8.Text ) )
                strWhere = strWhere + " AND PQU12='" + comboBox8.Text + "'";


            pageToDataTable( );
        }
        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signWuJin != "1" )
            {
                 count = bll.GetWuJinCount( strWhere );
            }
            else
            {
                count = bll.GetWuJinCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            signOfStorage( );
            if ( signWuJin != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,"" ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }
        void signOfStorage ( )
        {
            bll.EditStorage( );
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = comboBox7.Text = comboBox8.Text = "";
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signWuJin != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU98" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU99" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU01" ).ToString( );
                //cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU02" ).ToString( );
                //cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU97" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU100" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQU101" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signWuJin == "1" )
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
        }

        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( signWuJin == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                            gridView1.GetDataRow( i )["check"] = true;
                    }
                }
            }
        }
        //unCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( signWuJin == "1" )
            {
                if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                            gridView1.GetDataRow( i )["check"] = false;
                    }
                }
            }
        }
        //sure
        List<string> list = new List<string>( );
        bool repeat ( )
        {
            list.Clear( );
            bool resule = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    list.Add( gridView1.GetDataRow( i )["PQU97"].ToString( ) );
            }

            foreach ( string str in list )
            {
                for ( int k = list.Count-1 ; k >=0  ; k-- )
                {
                    if ( str != list[k] )
                    {
                        resule = false;
                        break;
                    }
                    else
                        resule = true;
                }
            }


            return resule;
        }
        protected override void sure ( )
        {
            base.sure( );

            if ( signWuJin == "1" )
            {
                if ( gridView1.RowCount > 0 )
                {
                    bool resule = repeat( );
                    if ( resule == false )
                        MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                    else
                    {
                        decimal sum = 0;
                        list.Clear( );
                        for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                        {
                            if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                            {
                                cn1 = gridView1.GetDataRow( i )["PQU97"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["PQU01"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["PQU98"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["PQU99"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["PQU100"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["PQU101"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["PQU10"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["PQU10"].ToString( );
                                //if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQU16"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQU101"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQU13"].ToString( ) ) && gridView1.GetDataRow( i )["PQU13"].ToString( ) != null )
                                //    sum += Math.Round( Convert.ToDecimal( gridView1.GetDataRow( i )["PQU16"].ToString( ) ) * ( Convert.ToDecimal( gridView1.GetDataRow( i )["PQU101"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["PQU13"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["PQU14"].ToString( ) ) ) ,1 );
                                sum += String . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "U1" ] . ToString ( ) );
                                list.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                            }
                        }
                        cn9 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
                        PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,list );
                        if ( PassDataBetweenForm != null )
                        {
                            PassDataBetweenForm( this ,args );
                        }
                        this.Close( );
                    }
                }
            }
        }
    }
}
