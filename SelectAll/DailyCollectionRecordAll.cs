
using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class DailyCollectionRecordAll : FormBase
    {
        public DailyCollectionRecordAll ( )
        {
            InitializeComponent( );
            
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        DataTable num, productName, no, contractNum, audit, productionWork, tableQuery,salesMan;
        
        MulaolaoBll.Bll.DailyCollectionRecordBll bll = new MulaolaoBll.Bll.DailyCollectionRecordBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        public string signQuery = "";

        private void DailyCollectionRecordAll_Load ( object sender ,EventArgs e )
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
            DataTable dt = bll . GetDataTableAll ( );
            num = dt . DefaultView.ToTable( true ,"AE02" );
            DataView dataView = num.DefaultView;
            dataView.Sort = ( "AE02 ASC" );
            comboBox1.DataSource = dataView.ToTable( );
            comboBox1.DisplayMember = "AE02";
            comboBox1.Text = "";

            productName = dt . DefaultView.ToTable( true ,"AE03" );
            lookUpEdit2 . Properties . DataSource = productName;
            lookUpEdit2 . Properties . DisplayMember = "AE03";

            no = dt . DefaultView.ToTable( true ,"AE05" );
            comboBox3.DataSource = no;
            comboBox3.DisplayMember = "AE05";
            comboBox3.Text = "";
            contractNum = dt . DefaultView.ToTable( true ,"AE04" );
            comboBox4.DataSource = contractNum;
            comboBox4.DisplayMember = "AE04";
            comboBox4.Text = "";
            audit = dt . DefaultView.ToTable( true ,"AE07" );
            comboBox6.DataSource = audit;
            comboBox6.DisplayMember = "AE07";
            comboBox6.Text = "";
            productionWork = dt . DefaultView.ToTable( true ,"AE08" );
            comboBox7.DataSource = productionWork;
            comboBox7.DisplayMember = "AE08";
            comboBox7.Text = "";
            salesMan = dt . DefaultView . ToTable ( true ,"AE09" );
            comboBox8 . DataSource = salesMan;
            comboBox8 . DisplayMember = "AE09";
            comboBox8 . Text = "";
            comboBox5 .Items.Clear( );
            comboBox5.Items.AddRange( new string[] { "订货日期" ,"登记日期" ,"评审日期" ,"ERP发货日期" ,"约定收款日期" ,"实际发货日期" ,"实际收款日期" ,"开票日期" ,"客检日期" ,"预收时间" } );
        }

        //queer query
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( num ,comboBox1 ,"AE02" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( no ,comboBox3 ,"AE05" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( contractNum ,comboBox4 ,"AE04" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( audit ,comboBox6 ,"AE07" );
            Cursor = Cursors.Default;
        }
        private void comboBox7_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( productionWork ,comboBox7 ,"AE08" );
            Cursor = Cursors.Default;
        }
        private void comboBox8_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox ( );
            cq . comboboxQuery ( salesMan ,comboBox8 ,"AE09" );
            Cursor = Cursors . Default;
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( comboBox1 . Text ) )
                strWhere = strWhere + " AND AE02='" + comboBox1 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
                strWhere = strWhere + " AND AE03='" + lookUpEdit2 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox3 . Text ) )
                strWhere = strWhere + " AND AE05='" + comboBox3 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox4 . Text ) )
                strWhere = strWhere + " AND AE04='" + comboBox4 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox6 . Text ) )
                strWhere = strWhere + " AND AE07='" + comboBox6 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox7 . Text ) )
                strWhere = strWhere + " AND AE08='" + comboBox7 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox5 . Text ) )
            {
                if ( comboBox5 . Text . Equals ( "订货日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE14)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE14)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE14)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE14 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "登记日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE15)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE15)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE15)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE15 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "评审日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE16)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE16)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE16)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE16 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "ERP发货日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE17)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE17)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE17)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE17 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "约定收款日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE18)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE18)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE18)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE18 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "实际发货日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE21)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE21)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE21)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE21 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "实际收款日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE22)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE22)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE22)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE22 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "开票日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE23)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE23)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE23)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE23 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "客检日期" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE32)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE32)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE32)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE32 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
                if ( comboBox5 . Text . Equals ( "预收时间" ) )
                {
                    if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                    {
                        strWhere = strWhere + " AND YEAR(AE24)=" + dateTimePicker2 . Value . Year + "";
                        if ( !string . IsNullOrEmpty ( textBox3 . Text ) && Convert . ToInt32 ( textBox3 . Text ) > 0 )
                            strWhere += " AND MONTH(AE24)>=" + textBox3 . Text + "";
                        if ( !string . IsNullOrEmpty ( textBox4 . Text ) && Convert . ToInt32 ( textBox4 . Text ) > 0 )
                            strWhere += " AND MONTH(AE24)<=" + textBox4 . Text + "";
                    }
                    else if ( string . IsNullOrEmpty ( textBox2 . Text ) )
                        strWhere = strWhere + " AND AE24 LIKE '" + dateTimePicker1 . Value . ToString ( "yyyy-MM" ) + "%'";
                }
            }

            pageToChange ( );
        }

        //Bind data source and pageChange
        void pageToChange ( )
        {
            int count = bll.GetDailyCollectionRecordCount( strWhere );
            userControl11.DrawCount( count );
            pageChange( );
        }
        void pageChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByChange( strWhere ,"" ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByChange( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );

            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1 . Text = comboBox3 . Text = comboBox4 . Text = comboBox5 . Text = comboBox6 . Text = comboBox7 . Text = textBox1 . Text = comboBox8 . Text = textBox3 . Text = textBox4 . Text = "";
            lookUpEdit2 . EditValue = null;
        }

        //
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yyyy年MM月" );
            textBox2.Text = "";
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else
                e.Handled = true;
        }
        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            textBox2.Text = dateTimePicker2.Value.ToString( "yyyy年" );
            textBox1.Text = "";
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {

        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar != '\b' )//这是允许输入退格键  
            {
                if ( ( e . KeyChar < '0' ) || ( e . KeyChar > '9' ) )//这是允许输入0-9数字  
                {
                    e . Handled = true;
                }
            }
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar != '\b' )//这是允许输入退格键  
            {
                if ( ( e . KeyChar < '0' ) || ( e . KeyChar > '9' ) )//这是允许输入0-9数字  
                {
                    e . Handled = true;
                }
            }
        }

        private void lookUpEdit1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e . KeyChar == 8 )
                lookUpEdit2 . EditValue = null;
            else
                e . Handled = true;
        }


        string cn1 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signQuery == "1" )
            {
                cn1 = gridView1.GetFocusedRowCellValue( "AE02" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
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

            if ( signQuery != "1" )
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

            if ( signQuery != "1" )
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
        protected override void sure ( )
        {
            base.sure( );

            if ( signQuery != "1" )
            {
                list.Clear( );

                if ( gridView1.RowCount > 0 )
                {
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
                    }

                    this.Close( );
                }
            }
        }
    }
}
