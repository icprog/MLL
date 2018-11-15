using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class SuLiaoBucontractQueryAll : FormBase
    {
        public SuLiaoBucontractQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.SuLiaoBucontractBll bll = new MulaolaoBll.Bll.SuLiaoBucontractBll( );
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, tableQuery;
        public string signSu = "", variable = "";

        private void SuLiaoBucontractQueryAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTable( "PJ92" );
            comboBox1.DataSource = oddNum;
            comboBox1.DisplayMember = "PJ92";
            comboBox1.Text = "";
            num = bll.GetDataTable( "PJ01" );
            comboBox2.DataSource = num;
            comboBox2.DisplayMember = "PJ01";
            comboBox2.Text = "";
            contractNum = bll.GetDataTable( "PJ94" );
            comboBox3.DataSource = contractNum;
            comboBox3.DisplayMember = "PJ94";
            comboBox3.Text = "";
            productName = bll.GetDataTable( "PJ93" );
            comboBox4.DataSource = productName;
            comboBox4.DisplayMember = "PJ93";
            comboBox4.Text = "";
            no = bll.GetDataTable( "PJ95" );
            comboBox5.DataSource = no;
            comboBox5.DisplayMember = "PJ95";
            comboBox5.Text = "";
            supplier = bll.GetDataTableOnly( );
            comboBox6.DataSource = supplier;
            comboBox6.DisplayMember = "DGA002";
            comboBox6.ValueMember = "PJ03";
            comboBox6.Text = variable;
            materialName = bll.GetDataTable( "PJ09" );
            comboBox7.DataSource = materialName;
            comboBox7.DisplayMember = "PJ09";
            comboBox7.Text = "";
            lon = bll.GetDataTable( "PJ89" );
            comboBox8.DataSource = lon;
            comboBox8.DisplayMember = "PJ89";
            comboBox8.Text = "";
        }
        //queey query
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( oddNum ,comboBox1 ,"PJ92" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( num ,comboBox2 ,"PJ01" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( contractNum ,comboBox3 ,"PJ94" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productName ,comboBox4 ,"PJ93" );
            Cursor = Cursors.Default;
        }
        private void comboBox5_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( no ,comboBox5 ,"PJ95" );
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
            cq.comboboxQuery( materialName ,comboBox7 ,"PJ09" );
            Cursor = Cursors.Default;
        }
        private void comboBox8_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( lon ,comboBox8 ,"PJ89" );
            Cursor = Cursors.Default;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                strWhere = strWhere + " AND PJ92='" + comboBox1.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                strWhere = strWhere + " AND PJ01='" + comboBox2.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                strWhere = strWhere + " AND PJ94='" + comboBox3.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                strWhere = strWhere + " AND PJ93='" + comboBox4.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox5.Text ) )
                strWhere = strWhere + " AND PJ95='" + comboBox5.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox6.Text ) )
            {
                if ( supplier.Select( "DGA002='" + comboBox6.Text + "'" ).Length > 0 )
                    strWhere = strWhere + " AND PJ03='" + supplier.Select( "DGA002='" + comboBox6.Text + "'" )[0]["PJ03"].ToString( ) + "'";
            }
            if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                strWhere = strWhere + " AND PJ09='" + comboBox7.Text + "'";
            if ( !string.IsNullOrEmpty( comboBox8.Text ) )
                strWhere = strWhere + " AND PJ89='" + comboBox8.Text + "'";

            pageToDataTable( );

        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signSu != "1" )
                count = bll.GetSuLiaoBuCount( strWhere );
            else
                count = bll.GetSuLiaoBuCountOne( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            bll.EditStorage( );

            if ( signSu != "1" )
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

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = comboBox4.Text = comboBox5.Text = comboBox6.Text = comboBox7.Text = comboBox8.Text = "";
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signSu != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ93" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ94" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ01" ).ToString( );
                //cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ02" ).ToString( );
                //cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ92" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ95" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PJ96" ).ToString( );
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
            if ( signSu == "1" )
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

            if ( signSu == "1" )
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

            if ( signSu == "1" )
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
                    list.Add( gridView1.GetDataRow( i )["PJ92"].ToString( ) );
            }

            foreach ( string str in list )
            {
                for ( int k = list.Count - 1 ; k >= 0 ; k-- )
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

            if ( signSu == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["PJ92"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["PJ01"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["PJ93"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["PJ94"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["PJ95"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["PJ96"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["PJ09"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["PJ09"].ToString( );
                                //if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ12"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ11"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ96"].ToString( ) ) && gridView1.GetDataRow( i )["PJ10"].ToString( ) != null )
                                //    sum += Math.Round( Convert.ToDecimal( gridView1.GetDataRow( i )["PJ12"].ToString( ) ) * ( Convert.ToDecimal( gridView1.GetDataRow( i )["PJ11"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["PJ96"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["PJ10"].ToString( ) ) ) ,0 );
                                sum += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "U2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "U2" ] . ToString ( ) );
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
