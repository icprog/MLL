﻿using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class CheMuJiancontractQueryAll : FormBase
    {
        public CheMuJiancontractQueryAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        MulaolaoBll.Bll.CheMuJiancontractBll bll = new MulaolaoBll.Bll.CheMuJiancontractBll( );

        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, with, hei, tableQuery;

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";
        public string signChe = "", variable = "";

        private void CheMuJiancontractQueryAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTableOnly( "AF001" );
            lookUpEdit1.Properties.DataSource = oddNum;
            lookUpEdit1.Properties.DisplayMember = "AF001";
            num = bll.GetDataTableOnly( "AF002" );
            lookUpEdit2.Properties.DataSource = num;
            lookUpEdit2.Properties.DisplayMember = "AF002";
            contractNum = bll.GetDataTableOnly( "AF005" );
            lookUpEdit3.Properties.DataSource = contractNum;
            lookUpEdit3.Properties.DisplayMember = "AF005";
            productName = bll.GetDataTableOnly( "AF003" );
            lookUpEdit4.Properties.DataSource = productName;
            lookUpEdit4.Properties.DisplayMember = "AF003";
            no = bll.GetDataTableOnly( "AF004" );
            lookUpEdit5.Properties.DataSource = no;
            lookUpEdit5.Properties.DisplayMember = "AF004";
            supplier = bll.GetDataTableSupplied( );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "DGA002";
            lookUpEdit6.Properties.ValueMember = "AF008";
            lookUpEdit6.Text = variable;
            materialName = bll.GetDataTableOnly( "AF015" );
            lookUpEdit7.Properties.DataSource = materialName;
            lookUpEdit7.Properties.DisplayMember = "AF015";
            lon = bll.GetDataTableOnly( "AF020" );
            lookUpEdit8.Properties.DataSource = lon;
            lookUpEdit8.Properties.DisplayMember = "AF020";
            with = bll.GetDataTableOnly( "AF021" );
            lookUpEdit9.Properties.DataSource = with;
            lookUpEdit9.Properties.DisplayMember = "AF021";
            hei = bll.GetDataTableOnly( "AF022" );
            lookUpEdit10.Properties.DataSource = hei;
            lookUpEdit10.Properties.DisplayMember = "AF022";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND AF001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND AF002='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND AF005='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND AF003='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND AF004='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                if ( supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" ).Length > 0 )
                    strWhere = strWhere + " AND AF008='" + supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" )[0]["AF008"].ToString( ) + "'";
            }
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
                strWhere = strWhere + " AND AF015='" + lookUpEdit7.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND AF020='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND AF021='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND AF022='" + lookUpEdit10.Text + "'";

            pageToDataTable( );
        }
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signChe != "1" )
                count = bll.GetCheMuJianCount( strWhere );
            else
                count = bll.GetCheMuJianCountOne( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            signOfStorage( );
            if ( signChe != "1" )
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
            lookUpEdit1.EditValue = lookUpEdit10.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = "";
            lookUpEdit1.ItemIndex = lookUpEdit10.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = -1;
        }

        //value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signChe != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF001" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF002" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF003" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF004" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF005" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF006" ).ToString( );
                //cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                //cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF007" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF008" ).ToString( );
                //cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"AF010" ).ToString( );

                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signChe == "1" )
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

            if ( signChe == "1" )
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

            if ( signChe == "1" )
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
                    list.Add( gridView1.GetDataRow( i )["AF001"].ToString( ) );
            }

            foreach ( string str in list )
            {
                for ( int k = list.Count-1 ; k >=0 ; k-- )
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

            if ( signChe == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["AF001"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["AF002"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["AF003"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["AF005"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["AF004"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["AF006"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["AF015"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["AF015"].ToString( );
                                if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AF023" ] . ToString ( ) ) && !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AF006" ] . ToString ( ) ) && !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AF019" ] . ToString ( ) ) )
                                    sum += Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AF023" ] . ToString ( ) ) * Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AF006" ] . ToString ( ) ) * Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AF019" ] . ToString ( ) );
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