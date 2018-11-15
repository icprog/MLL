using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ChanPinZhiBaoAll : FormBase
    {
        public ChanPinZhiBaoAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        MulaolaoBll.Dao.ChanPinZhiBaoDao dao = new MulaolaoBll.Dao.ChanPinZhiBaoDao( );
        DataTable oddNum, num, contractNum, productName, no, supplier, materialName, lon, tableQuery;

        public string signChan = "", variable = "";

        private void ChanPinZhiBaoAll_Load ( object sender ,EventArgs e )
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
            oddNum = dao.GetDataTableOnly( "CP03" );
            lookUpEdit1.Properties.DataSource = oddNum;
            lookUpEdit1.Properties.DisplayMember = "CP03";
            num = dao.GetDataTableOnly( "CP01" );
            lookUpEdit2.Properties.DataSource = num;
            lookUpEdit2.Properties.DisplayMember = "CP01";
            contractNum = dao.GetDataTableOnly( "CP52" );
            lookUpEdit3.Properties.DataSource = contractNum;
            lookUpEdit3.Properties.DisplayMember = "CP52";
            productName = dao.GetDataTableOnly( "CP51" );
            lookUpEdit4.Properties.DataSource = productName;
            lookUpEdit4.Properties.DisplayMember = "CP51";
            no = dao.GetDataTableOnly( "CP53" );
            lookUpEdit5.Properties.DataSource = no;
            lookUpEdit5.Properties.DisplayMember = "CP53";
            supplier = dao.GetDataTableOnly( );
            lookUpEdit6.Properties.DataSource = supplier;
            lookUpEdit6.Properties.DisplayMember = "CP44";
            lookUpEdit6 . Properties . ValueMember = "CP59";
            lookUpEdit6.Text = variable;
            materialName = dao.GetDataTableOnly( "CP06" );
            lookUpEdit7.Properties.DataSource = materialName;
            lookUpEdit7.Properties.DisplayMember = "CP06";
            lon = dao.GetDataTableOnly( "CP07" );
            lookUpEdit8.Properties.DataSource = lon;
            lookUpEdit8.Properties.DisplayMember = "CP07";
        }
        
        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
                strWhere = strWhere + " AND CP03='" + lookUpEdit1 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
                strWhere = strWhere + " AND CP01='" + lookUpEdit2 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
                strWhere = strWhere + " AND CP52='" + lookUpEdit3 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit4 . Text ) )
                strWhere = strWhere + " AND CP51='" + lookUpEdit4 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit5 . Text ) )
                strWhere = strWhere + " AND CP53='" + lookUpEdit5 . Text + "'";
            //if ( !string.IsNullOrEmpty( lookUpEdit6.Text ) )
            //    strWhere = strWhere + " AND CP44='" + lookUpEdit6.Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit7 . Text ) )
                strWhere = strWhere + " AND CP06='" + lookUpEdit7 . Text + "'";
            if ( !string . IsNullOrEmpty ( lookUpEdit8 . Text ) )
                strWhere = strWhere + " AND CP07='" + lookUpEdit8 . Text + "'";
            if ( lookUpEdit6 . EditValue != null )
                strWhere = strWhere + " AND (CP59='" + lookUpEdit6 . EditValue . ToString ( ) + "' OR CP44='" + lookUpEdit6 . Text + "')";

            pageToDataTable ( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            if ( signChan != "1" )
            {
                 count = dao.GetChanPinZhiBaoCount( strWhere );
            }
            else
            {
                 count = dao.GetChanPinZhiBaoCountOne( strWhere );
            }
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( signChan != "1" )
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = dao.GetDataTableByPage( strWhere ,"" ,0 ,userControl11.pageSize );
                else
                    tableQuery = dao.GetDataTableByPage( strWhere ,"" ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            else
            {
                if ( userControl11.pageIndex <= 1 )
                    tableQuery = dao.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
                else
                    tableQuery = dao.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            }
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }

        //clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = lookUpEdit6.EditValue = lookUpEdit7.EditValue = lookUpEdit8.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = lookUpEdit6.ItemIndex = lookUpEdit7.ItemIndex = lookUpEdit8.ItemIndex = -1;
        }

        //value
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            if ( signChan != "1" )
            {
                cn1 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP51" ).ToString( );
                cn2 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP01" ).ToString( );
                cn3 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP44" ).ToString( );
                cn4 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP52" ).ToString( );
                cn5 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP53" ).ToString( );
                cn6 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP54" ).ToString( );
                cn7 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"RES05" ).ToString( );
                cn8 = gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"CP03" ).ToString( );

                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }

        
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( signChan == "1" )
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

            if ( signChan == "1" )
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

            if ( signChan == "1" )
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
                for ( int k = add.Count-1 ; k >= 0 ; k-- )
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
            if ( signChan == "1" )
            {
                byValue( );
            }
        }
        void byValue ( )
        {
            if ( gridView1.RowCount > 0 )
            {
                bool result = repeat( );
                if ( result == false )
                    MessageBox.Show( "您没有选择任何内容或者选择的内容不是同一个单号,请核实" );
                else
                {
                    decimal sum = 0;
                    add.Clear( );
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                        {
                            cn1 = gridView1.GetDataRow( i )["CP44"].ToString( );
                            cn2 = gridView1.GetDataRow( i )["CP01"].ToString( );
                            cn3 = gridView1.GetDataRow( i )["CP51"].ToString( );
                            cn4 = gridView1.GetDataRow( i )["CP52"].ToString( );
                            cn5 = gridView1.GetDataRow( i )["CP53"].ToString( );
                            if ( string.IsNullOrEmpty( cn6 ) )
                                cn6 = gridView1.GetDataRow( i )["CP06"].ToString( );
                            else
                                cn6 += "," + gridView1.GetDataRow( i )["CP06"].ToString( );
                            //if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP54"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP13"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["CP10"].ToString( ) ) )
                            //    sum += Math.Round( Convert.ToDecimal( gridView1.GetDataRow( i )["CP54"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP13"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["CP10"].ToString( ) ) ,1 );
                            if ( sum==0 )
                                sum = string.IsNullOrEmpty( gridView1.GetDataRow( i )["U2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U2"].ToString( ) );
                            else
                                sum = sum + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["U2"].ToString( ) ) );
                            cn8 = gridView1.GetDataRow( i )["CP54"].ToString( );
                            cn9 = gridView1.GetDataRow( i )["CP03"].ToString( );
                            add.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                        }
                    }
                    cn7 = Math . Round ( sum ,2 ,MidpointRounding . AwayFromZero ) . ToString ( );
                    PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,add );
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
