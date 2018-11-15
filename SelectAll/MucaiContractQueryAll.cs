using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class MucaiContractQueryAll : FormBase
    {
        public MucaiContractQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        MulaolaoBll.Bll.MucaiContractBll bll = new MulaolaoBll.Bll.MucaiContractBll( );
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, with, hei, tableQuery;
        public string signMu = "", variable = "";

        private void MucaiContractQueryAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assginMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged (object sender,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assginMent ( )
        {
            oddNum = bll.GetDataTableOnly( "PQV76" );
            lookUpEdit1.Properties.DataSource = oddNum;
            lookUpEdit1.Properties.DisplayMember = "PQV76";
            num = bll.GetDataTableOnly( "PQV01" );
            lookUpEdit2.Properties.DataSource = num;
            lookUpEdit2.Properties.DisplayMember = "PQV01";
            contractNum = bll.GetDataTableOnly( "PQV78" );
            lookUpEdit3.Properties.DataSource = contractNum;
            lookUpEdit3.Properties.DisplayMember = "PQV78";
            productName = bll.GetDataTableOnly( "PQV77" );
            lookUpEdit4.Properties.DataSource = productName;
            lookUpEdit4.Properties.DisplayMember = "PQV77";
            no = bll.GetDataTableOnly( "PQV79" );
            lookUpEdit5.Properties.DataSource = no;
            lookUpEdit5.Properties.DisplayMember = "PQV79";
            supplier = bll.GetDataTableSupplied( );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "DGA002";
            lookUpEdit6.Properties.ValueMember = "PQV03";
            lookUpEdit6.Text = variable;
            materialName = bll.GetDataTableOnly( "PQV10" );
            lookUpEdit7.Properties.DataSource = materialName;
            lookUpEdit7.Properties.DisplayMember = "PQV10";
            lon = bll.GetDataTableOnly( "PQV66" );
            lookUpEdit8.Properties.DataSource = lon;
            lookUpEdit8.Properties.DisplayMember = "PQV66";
            with = bll.GetDataTableOnly( "PQV81" );
            lookUpEdit9.Properties.DataSource = with;
            lookUpEdit9.Properties.DisplayMember = "PQV81";
            hei = bll.GetDataTableOnly( "PQV67" );
            lookUpEdit10.Properties.DataSource = hei;
            lookUpEdit10.Properties.DisplayMember = "PQV67";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND PQV76='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND PQV01='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND PQV78='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND PQV77='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND PQV79='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            {
                if ( supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" ).Length > 0 )
                    strWhere = strWhere + " AND PQV03='" + supplier.Select( "DGA002='" + lookUpEdit6.Text + "'" )[0]["PQV03"].ToString( ) + "'";
            }
                
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
                strWhere = strWhere + " AND PQV10='" + lookUpEdit7.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND PQV66='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND PQV81='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND PQV67='" + lookUpEdit10.Text + "'";

            pageToDataTable( );
        }

        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signMu != "1" )
            {
                 count = bll.GetMucaiCount( strWhere );
            }
            else
            {
                count = bll.GetMucaiCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            signOfStorage( );
            if ( signMu != "1" )
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
            bll.EditStroageMark( );
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit10.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = lookUpEdit10.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = lookUpEdit10.ItemIndex = -1;
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signMu != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV77" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV78" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV01" ).ToString( );
                //cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV02" ).ToString( );
                //cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV76" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV79" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQV80" ).ToString( );

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
            if ( signMu == "1" )
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

            if ( signMu == "1" )
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

            if ( signMu == "1" )
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
                    list.Add( gridView1.GetDataRow( i )["PQV76"].ToString( ) );
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

            if ( signMu == "1" )
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
                        decimal p11 = 0, p66 = 0, p81 = 0, p67 = 0, p13 = 0;
                        //decimal x1 = 0;
                        for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                        {
                            p11 =  p66 =  p81 =  p67 = p13 = 0;
                            //x1 = 0;
                            if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                            {
                                cn1 = gridView1.GetDataRow( i )["PQV76"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["PQV01"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["PQV77"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["PQV78"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["PQV79"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["PQV80"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["PQV10"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["PQV10"].ToString( );
                                //p11 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQV11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQV11" ] . ToString ( ) );
                                //p66 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQV66" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQV66" ] . ToString ( ) );
                                //p81 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQV81" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQV81" ] . ToString ( ) );
                                //p67 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQV67" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQV67" ] . ToString ( ) );
                                //p13 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQV13" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQV13" ] . ToString ( ) );
                                //[PQV11] * [PQV66] * [PQV81] * [PQV67] * [PQV13]
                                //x1 = decimal . Round ( p11 * p66 * p81 * p67 * p13 ,0 );
                                sum += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "U0" ] . ToString ( ) );
                                list .Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
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
