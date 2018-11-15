using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class JiaomiducontractQueryAll : FormBase
    {
        public JiaomiducontractQueryAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        DataTable oddNum, num, productName, contractNum, no, count, supplier, closecoll, material, outIn, lon, with, hei, query;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "", cn12 = "";

        MulaolaoBll.Bll.JiaomiducontractBll bll = new MulaolaoBll.Bll.JiaomiducontractBll( );
        public string signJiao = "", variable = "";
        
        private void JiaomiducontractQueryAll_Load ( object sender ,EventArgs e )
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
            oddNum = bll.GetDataTable( "JM01" );
            lookUpEdit1.Properties.DataSource = oddNum;
            lookUpEdit1.Properties.DisplayMember = "JM01";
            num = bll.GetDataTable( "JM90" );
            lookUpEdit2.Properties.DataSource = num;
            lookUpEdit2.Properties.DisplayMember = "JM90";
            productName = bll.GetDataTable( "JM100" );
            lookUpEdit3.Properties.DataSource = productName;
            lookUpEdit3.Properties.DisplayMember = "JM100";
            contractNum = bll.GetDataTable( "JM101" );
            lookUpEdit4.Properties.DataSource = contractNum;
            lookUpEdit4.Properties.DisplayMember = "JM101";
            no = bll.GetDataTable( "JM102" );
            lookUpEdit5.Properties.DataSource = no;
            lookUpEdit5.Properties.DisplayMember = "JM102";
            count = bll.GetDataTable( "JM103" );
            lookUpEdit6.Properties.DataSource = count;
            lookUpEdit6.Properties.DisplayMember = "JM103";
            supplier = bll.GetDataTableJoin( );
            lookUpEdit7.Properties.DataSource = supplier;
            lookUpEdit7.Properties.DisplayMember = "DGA002";
            lookUpEdit7.Properties.ValueMember = "JM03";
            lookUpEdit7.Text = variable;
            closecoll = bll.GetDataTable( "JM04" );
            lookUpEdit8.Properties.DataSource = closecoll;
            lookUpEdit8.Properties.DisplayMember = "JM04";
            material = bll.GetDataTable( "JM09" );
            lookUpEdit9.Properties.DataSource = material;
            lookUpEdit9.Properties.DisplayMember = "JM09";
            outIn = bll.GetDataTable( "JM14" );
            lookUpEdit10.Properties.DataSource = outIn;
            lookUpEdit10.Properties.DisplayMember = "JM14";
            lon = bll.GetDataTable( "JM94" );
            lookUpEdit11.Properties.DataSource = lon;
            lookUpEdit11.Properties.DisplayMember = "JM94";
            with = bll.GetDataTable( "JM95" );
            lookUpEdit12.Properties.DataSource = with;
            lookUpEdit12.Properties.DisplayMember = "JM95";
            hei = bll.GetDataTable( "JM96" );
            lookUpEdit13.Properties.DataSource = hei;
            lookUpEdit13.Properties.DisplayMember = "JM96";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND JM01='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND JM90='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND JM100='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND JM101='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND JM102='" + lookUpEdit5.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
                strWhere = strWhere + " AND JM103='" + lookUpEdit6.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit7.Text ) )
            {
                if( supplier.Select( "DGA002='" + lookUpEdit7.Text + "'" ) .Length>0)
                    strWhere = strWhere + " AND JM03='" + supplier.Select( "DGA002='" + lookUpEdit7.Text + "'" )[0]["JM03"].ToString( ) + "'";
            }
                
            if ( !string.IsNullOrEmpty( lookUpEdit8.Text ) )
                strWhere = strWhere + " AND JM04='" + lookUpEdit8.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit9.Text ) )
                strWhere = strWhere + " AND JM09='" + lookUpEdit9.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit10.Text ) )
                strWhere = strWhere + " AND JM14='" + lookUpEdit10.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit11.Text ) )
                strWhere = strWhere + " AND JM94='" + lookUpEdit11.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit12.Text ) )
                strWhere = strWhere + " AND JM95='" + lookUpEdit12.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit13.Text ) )
                strWhere = strWhere + " AND JM96='" + lookUpEdit13.Text + "'";

            pageToDataTable( );

        }

        //Bind data source  and  pagechanged
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signJiao != "1" )
            {
                count = bll.GetJiaomiduCount( strWhere );
            }
            else
            {
                count = bll.GetJiaomiduCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChanged( );
        }
        void pageByChanged ( )
        {
            signOfStorage( );
            if ( signJiao != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    query = bll.GetDataTableByPage( strWhere ,"" ,0 ,userControl11.pageSize );
                else
                    query = bll.GetDataTableByPage( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    query = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
                else
                    query = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            query.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = query;
        }
        void signOfStorage ( )
        {
            bll.signOfStorage( );
        }
        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = lookUpEdit9.EditValue = lookUpEdit10.EditValue = lookUpEdit11.EditValue = lookUpEdit12.EditValue = lookUpEdit13.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = lookUpEdit9.ItemIndex = lookUpEdit10.ItemIndex = lookUpEdit11.ItemIndex = lookUpEdit12.ItemIndex = lookUpEdit13.ItemIndex = -1;
        }

        //value
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signJiao != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM101" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM90" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM100" ).ToString( );
                //cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM02" ).ToString( );
                //cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM04" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM01" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM102" ).ToString( );
                cn12 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"JM103" ).ToString( );

                PassDataWinFormEventArgs arge = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 ,cn11 ,cn12 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,arge );
                }
                this.Close( );
            }
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signJiao == "1" )
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

            if ( signJiao == "1" )
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

            if ( signJiao == "1" )
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
                    list.Add( gridView1.GetDataRow( i )["JM01"].ToString( ) );
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

            if ( signJiao == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["JM01"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["JM90"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["JM100"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["JM101"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["JM102"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["JM103"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["JM09"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["JM09"].ToString( );
                                //if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["JM103"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["JM11"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["JM10"].ToString( ) ) )
                                //    sum += Math.Round( Convert.ToDecimal( gridView1.GetDataRow( i )["JM103"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["JM11"].ToString( ) ) / Convert.ToDecimal( gridView1.GetDataRow( i )["JM10"].ToString( ) ) ,1 );
                                sum += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "U0" ] . ToString ( ) );
                                list.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                            }
                        }
                        cn9 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
                        PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9,list );
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
