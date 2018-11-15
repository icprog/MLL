using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class SiReYiYincontractAll : FormBase
    {
        public SiReYiYincontractAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.SiReYiYincontractBll bll = new MulaolaoBll.Bll.SiReYiYincontractBll( );
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, specificaTions,colorNum,workProcedure, tableQuery;
        public string signSi = "", variable = "";

        private void SiReYiYincontractAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTable( "AH97" );
            lookUpEdit1.Properties.DataSource = oddNum;
            lookUpEdit1.Properties.DisplayMember = "AH97";
            num = bll.GetDataTable( "AH01" );
            lookUpEdit2.Properties.DataSource = num;
            lookUpEdit2.Properties.DisplayMember = "AH01";
            contractNum = bll.GetDataTable( "AH99" );
            lookUpEdit3.Properties.DataSource = contractNum;
            lookUpEdit3.Properties.DisplayMember = "AH99";
            productName = bll.GetDataTable( "AH98" );
            lookUpEdit4.Properties.DataSource = productName;
            lookUpEdit4.Properties.DisplayMember = "AH98";
            no = bll.GetDataTable( "AH100" );
            lookUpEdit5.Properties.DataSource = no;
            lookUpEdit5.Properties.DisplayMember = "AH100";
            supplier = bll.GetDataTable(  );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "AH03";
            lookUpEdit6.Text = variable;
            materialName = bll.GetDataTable( "AH10" );
            lookUpEdit7.Properties.DataSource = materialName;
            lookUpEdit7.Properties.DisplayMember = "AH10";
            specificaTions = bll.GetDataTable( "AH11" );
            lookUpEdit8.Properties.DataSource = specificaTions;
            lookUpEdit8.Properties.DisplayMember = "AH11";
            colorNum = bll.GetDataTable( "AH12" );
            lookUpEdit9.Properties.DataSource = colorNum;
            lookUpEdit9.Properties.DisplayMember = "AH12";
            workProcedure = bll.GetDataTable( "AH18" );
            lookUpEdit10.Properties.DataSource = workProcedure;
            lookUpEdit10.Properties.DisplayMember = "AH18";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND AH97='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND AH01='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND AH99='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND AH98='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND AH100='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND AH03='" + lookUpEdit6.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
                strWhere = strWhere + " AND AH10='" + lookUpEdit7.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND AH11='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND AH12='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND AH18='" + lookUpEdit10.Text + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signSi != "1" )
            {
                count = bll.GetSiReYiYinCount( strWhere );
            }
            else
            {
                count = bll.GetSiReYiYinCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signSi != "1" )
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
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = lookUpEdit10.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = lookUpEdit10.ItemIndex = -1;
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "", cn13 = "", cn14 = "", cn15 = "", cn16 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH97" ).ToString( );
            cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH01" ).ToString( );
            cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH98" ).ToString( );
            cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH100" ).ToString( );
            cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH99" ).ToString( );
            cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH03" ).ToString( );
            cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AH101" ).ToString( );
            cn16 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );

            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 ,cn13 ,cn14 ,cn15 ,cn16 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }

            this.Close( );
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signSi == "1" )
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

            if ( signSi == "1" )
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
        //UnCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( signSi == "1" )
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
        //Sure
        List<string> list = new List<string>( );
        bool repeat ( )
        {
            list.Clear( );
            bool resule = false;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    list.Add( gridView1.GetDataRow( i )["AH97"].ToString( ) );
            }

            foreach ( string str in list )
            {
                for ( int k = list.Count-1 ; k >=0; k-- )
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

            if ( signSi == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["AH97"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["AH01"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["AH98"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["AH99"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["AH100"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["AH03"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["AH101"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["AH10"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["AH10"].ToString( );
                                if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AH16" ] . ToString ( ) ) && !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AH101" ] . ToString ( ) ) && !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AH13" ] . ToString ( ) ) && !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AH14" ] . ToString ( ) ) )
                                    sum += Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AH16" ] . ToString ( ) ) * Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AH101" ] . ToString ( ) ) * Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AH13" ] . ToString ( ) ) * Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AH14" ] . ToString ( ) );
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
