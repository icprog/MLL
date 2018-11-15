using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class WaiXiancontractAll : FormBase
    {
        public WaiXiancontractAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.WaiXiancontractBll bll = new MulaolaoBll.Bll.WaiXiancontractBll( );
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, tableQuery;
        public string signWai = "", variable = "";

        private void WaiXiancontractAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 ,gridView8 ,gridview9 } );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data Source
        void assignMent ( )
        {
            oddNum = bll.GetDataTable( "WX82" );
            txtWX82.Properties.DataSource = oddNum;
            txtWX82 . Properties . DisplayMember = "WX82";
            txtWX82 . Properties . ValueMember = "WX82";
            num = bll.GetDataTable( "WX01" );
            txtWX01.Properties.DataSource = num;
            txtWX01 . Properties . DisplayMember = "WX01";
            txtWX01 . Properties . ValueMember = "WX01";
            contractNum = bll.GetDataTable( "WX84" );
            txtWX84.Properties.DataSource = contractNum;
            txtWX84 . Properties . DisplayMember = "WX84";
            txtWX84 . Properties . ValueMember = "WX84";
            no = bll.GetDataTable( "WX85" );
            txtWX85.Properties.DataSource = no;
            txtWX85 . Properties . DisplayMember = "WX85";
            txtWX85 . Properties . ValueMember = "WX85";
            productName = bll.GetDataTable( "WX83" );
            txtWX83.Properties.DataSource = productName;
            txtWX83 . Properties . DisplayMember = "WX83";
            txtWX83 . Properties . ValueMember = "WX83";
            supplier = bll.GetDataTableOnly( );
            txtWX03.Properties.DataSource = supplier;
            txtWX03 .Properties. DisplayMember = "DGA002";
            txtWX03.Properties.ValueMember = "WX03";
            materialName = bll.GetDataTable( "WX10" );
            txtWX10.Properties.DataSource = materialName;
            txtWX10 . Properties . DisplayMember = "WX10";
            txtWX10 . Properties . ValueMember = "WX10";
            lon = bll.GetDataTable( "WX11" );
            txtWX011.Properties.DataSource = lon;
            txtWX011.Properties.DisplayMember = "WX11";
            txtWX011 . Properties . ValueMember = "WX11";
        }
        
        //query
        string strWhere = "1=1";
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( txtWX82.Text ) )
                strWhere = strWhere + " AND WX82='" + txtWX82 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX03.Text ) )
            {
                if ( supplier.Select( "DGA002='" + txtWX03 . Text + "'" ).Length > 0 )
                    strWhere = strWhere + " AND WX03='" + supplier.Select( "DGA002='" + txtWX03 . Text + "'" )[0]["WX03"].ToString( ) + "'";
            }
            if ( !string.IsNullOrEmpty( txtWX01.Text ) )
                strWhere = strWhere + " AND WX01='" + txtWX01 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX84 . Text ) )
                strWhere = strWhere + " AND WX84='" + txtWX84 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX85.Text ) )
                strWhere = strWhere + " AND WX85='" + txtWX85 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX83.Text ) )
                strWhere = strWhere + " AND WX83='" + txtWX83 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX10.Text ) )
                strWhere = strWhere + " AND WX10='" + txtWX10 . Text + "'";
            if ( !string.IsNullOrEmpty( txtWX011.Text ) )
                strWhere = strWhere + " AND WX11='" + txtWX011 . Text + "'";

            pageToDataTable( );
        }


        void assginContrac ( )
        {
            decimal val = 0.0001M;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["WX10"].ToString( ) == "双瓦外箱" || gridView1.GetDataRow( i )["WX10"].ToString( ) == "小箱式" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["WX27"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,val );
                }
                else if ( gridView1.GetDataRow( i )["WX10"].ToString( ) == "牙膏式" || gridView1.GetDataRow( i )["WX10"].ToString( ) == "插口式" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,val );
                }
                else if ( gridView1.GetDataRow( i )["WX10"].ToString( ) == "折叠式" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,Convert.ToDecimal( 1.5 ) * Convert.ToDecimal( gridView1.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,val );
                }
                else if ( gridView1.GetDataRow( i )["WX10"].ToString( ) == "天盖" || gridView1.GetDataRow( i )["WX10"].ToString( ) == "地盖" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( gridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,val );
                }
                else
                {
                    gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,val );
                    gridView1.SetRowCellValue( i ,gridView1.Columns["U4"] ,val );
                }
            }
            gridView1.FocusedRowHandle = 0;
        }
        //Bind data source and pageChanged
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signWai != "1" )
            {
                count = bll.GetWaiXianCount( strWhere );
            }
            else
            {
                count = bll.GetWaiXianCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signWai != "1" )
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
            assginContrac( );
        }


        //clear
        private void button6_Click ( object sender ,EventArgs e )
        {
            txtWX82 . EditValue = txtWX03 . EditValue = txtWX01 . EditValue = txtWX84 . EditValue = txtWX85 . EditValue = txtWX83 . EditValue = txtWX10 . EditValue = txtWX011 . EditValue = null;
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "", cn11 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signWai != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX83" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX84" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX01" ).ToString( );
                //cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX02" ).ToString( );
                //cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DBA002" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX03" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"DGA002" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn9 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX82" ).ToString( );
                cn10 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX85" ).ToString( );
                cn11 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"WX86" ).ToString( );

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
            if ( signWai == "1" )
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

            if ( signWai == "1" )
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

            if ( signWai == "1" )
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
                    list.Add( gridView1.GetDataRow( i )["WX82"].ToString( ) );
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

            if ( signWai == "1" )
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
                                cn1 = gridView1.GetDataRow( i )["WX82"].ToString( );
                                cn2 = gridView1.GetDataRow( i )["WX01"].ToString( );
                                cn3 = gridView1.GetDataRow( i )["WX83"].ToString( );
                                cn4 = gridView1.GetDataRow( i )["WX84"].ToString( );
                                cn5 = gridView1.GetDataRow( i )["WX85"].ToString( );
                                cn6 = gridView1.GetDataRow( i )["WX86"].ToString( );
                                cn7 = gridView1.GetDataRow( i )["DGA002"].ToString( );
                                if ( string.IsNullOrEmpty( cn8 ) )
                                    cn8 = gridView1.GetDataRow( i )["WX10"].ToString( );
                                else
                                    cn8 += "," + gridView1.GetDataRow( i )["WX10"].ToString( );
                                if ( gridView1.GetDataRow( i )["U3"].ToString( ) != null && gridView1.GetDataRow( i )["U4"].ToString( ) != null && gridView1.GetDataRow( i )["WX23"].ToString( ) != null && gridView1.GetDataRow( i )["WX24"].ToString( ) != null && gridView1.GetDataRow( i )["WX25"].ToString( ) != null && gridView1.GetDataRow( i )["WX26"].ToString( ) != null && gridView1.GetDataRow( i )["WX13"].ToString( ) != null && gridView1.GetDataRow( i )["WX15"].ToString( ) != null )
                                    sum +=  ( Convert.ToDecimal( gridView1.GetDataRow( i )["U3"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["U4"].ToString( ) ) * Convert.ToDecimal( 0.0001 ) + ( Convert.ToDecimal( gridView1.GetDataRow( i )["WX23"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX24"].ToString( ) ) ) * ( Convert.ToDecimal( gridView1.GetDataRow( i )["WX25"].ToString( ) ) + Convert.ToDecimal( gridView1.GetDataRow( i )["WX26"].ToString( ) ) ) * Convert.ToDecimal( 0.0001 ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["WX13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["WX15"].ToString( ) );
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
