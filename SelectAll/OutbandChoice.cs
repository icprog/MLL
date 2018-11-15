using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class OutbandChoice : Form
    {
        public OutbandChoice ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public Dictionary<string ,string> strDic;
        public DataTable libraryTable;
        public string number = "", sign = "", oddNum = "";
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.OutbandChoiceBll bll = new MulaolaoBll.Bll.OutbandChoiceBll( );
        DataTable tableQuery, tableContrast; //int count = 0;
        
        private void OutbandChoice_Load ( object sender ,EventArgs e )
        {
            button1.Visible = button2.Visible = false;
            if ( sign == "R_338" )
                query( );
            if ( sign == "R_341" )
                queryMuCai( );
            if ( sign == "R_342" )
                queryCheMuJian( );
            if ( sign == "R_343" )
                queryHardWare( );
            if ( sign == "R_347" )
                queryAccess( );
            if ( sign == "R_337" )
            {
                gunQi( );
                gridView1.Columns["AC02"].Caption = "油漆品牌";
                gridView1.Columns["AC04"].Caption = "色名";
                gridView1.Columns["AC05"].Caption = "色号";
            }
        }

        void query ( )
        {
            tableQuery = bll.GetDataTable( number ,libraryTable );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            addSails( );
            gridControl1.DataSource = tableQuery;
        }

        void queryMuCai ( )
        {
            tableQuery = bll.GetDataTableOfWood( libraryTable );
            addSails( );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }
        
        void queryCheMuJian ( )
        {
            tableQuery = bll.GetDataTableOfCheMuJian( libraryTable ,number );
            addSails( );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }

        void queryHardWare ( )
        {
            tableQuery = bll.GetDataTableOfHardWare( libraryTable ,number );
            addSails( );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }

        void queryAccess ( )
        {
            tableQuery = bll.GetDataTableOfAccess( libraryTable ,number );
            addSails( );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }

        void addSails ( )
        {
            if ( libraryTable != null && libraryTable.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < libraryTable.Rows.Count ; i++ )
                    {
                        for ( int l = 0 ; l < tableQuery.Rows.Count ; l++ )
                        {
                            if ( libraryTable.Rows[i]["tOne"].ToString( ) == tableQuery.Rows[l]["AC05"].ToString( ) && libraryTable.Rows[i]["tTwo"].ToString( ) == tableQuery.Rows[l]["AC04"].ToString( ) )
                                tableQuery.Rows[l]["TRE"] = libraryTable.Compute( "SUM(tTre)" ,"tOne='" + libraryTable.Rows[i]["tOne"].ToString( ) + "' AND tTwo='" + libraryTable.Rows[i]["tTwo"].ToString( ) + "'" ).ToString( );
                        }
                    }
                }
            }
            if ( sign != "R_341")
            {
                tableContrast = bll.GetDataTableOf( oddNum );
                if ( tableContrast != null && tableContrast.Rows.Count > 0 )
                {
                    if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                    {
                        for ( int i = 0 ; i < tableContrast.Rows.Count ; i++ )
                        {
                            for ( int l = 0 ; l < tableQuery.Rows.Count ; l++ )
                            {
                                if ( tableContrast.Rows[i]["AD07"].ToString( ) == tableQuery.Rows[l]["AC05"].ToString( ) && tableContrast.Rows[i]["AD06"].ToString( ) == tableQuery.Rows[l]["AC04"].ToString( ) && tableContrast.Rows[i]["AD01"].ToString( ) == tableQuery.Rows[l]["AC18"].ToString( ) )
                                {
                                    tableQuery.Rows[l]["FORE"] = tableContrast.Rows[i]["AD12"].ToString( );
                                    tableQuery.Rows[l]["FIV"] = tableContrast.Rows[i]["AD12"].ToString( );
                                    if ( Convert.ToDecimal( tableQuery.Rows[l]["ONE"].ToString( ) ) == 0 && Convert.ToDecimal( tableQuery.Rows[l]["FIV"].ToString( ) ) == 0 )
                                        tableQuery.Rows.RemoveAt( l );
                                }
                            }
                        }
                    }
                }
            }
            if ( sign == "R_341" )
            {
                tableContrast = bll.GetDataTableOfMuCaiAll( oddNum );
                if ( tableContrast != null && tableContrast.Rows.Count > 0 )
                {
                    if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                    {
                        for ( int i = 0 ; i < tableContrast.Rows.Count ; i++ )
                        {
                            for ( int l = 0 ; l < tableQuery.Rows.Count ; l++ )
                            {
                                if ( tableContrast.Rows[i]["AD07"].ToString( ) == tableQuery.Rows[l]["AC05"].ToString( ) && tableContrast.Rows[i]["AD06"].ToString( ) == tableQuery.Rows[l]["AC04"].ToString( ) && tableContrast.Rows[i]["AD01"].ToString( ) == tableQuery.Rows[l]["AC18"].ToString( ) )
                                {
                                    tableQuery.Rows[l]["FORE"] = tableContrast.Rows[i]["AD12"].ToString( );
                                    tableQuery.Rows[l]["FIV"] = tableContrast.Rows[i]["AD12"].ToString( );
                                    if ( Convert.ToDecimal( tableQuery.Rows[l]["ONE"].ToString( ) ) == 0 && Convert.ToDecimal( tableQuery.Rows[l]["FIV"].ToString( ) ) == 0 )
                                        tableQuery.Rows.RemoveAt( l );
                                }
                            }
                        }
                    }
                }
            }
        }

        void gunQi ( )
        {
            tableQuery = bll . GetDataTableOfGunQi ( libraryTable ,number ,oddNum );
            addSailsGunQi( );
            //tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }
        
        void addSailsGunQi ( )
        {
            if ( libraryTable != null && libraryTable.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < libraryTable.Rows.Count ; i++ )
                    {
                        for ( int l = 0 ; l < tableQuery.Rows.Count ; l++ )
                        {
                            if ( libraryTable.Rows[i]["tOne"].ToString( ) == tableQuery.Rows[l]["AC02"].ToString( ) && libraryTable.Rows[i]["tTwo"].ToString( ) == tableQuery.Rows[l]["AC04"].ToString( ) && libraryTable.Rows[i]["tTre"].ToString( ) == tableQuery.Rows[l]["AC05"].ToString( ) )
                                tableQuery.Rows[l]["TRE"] = libraryTable.Compute( "SUM(tFor)" ,"tOne='" + libraryTable.Rows[i]["tOne"].ToString( ) + "' AND tTwo='" + libraryTable.Rows[i]["tTwo"].ToString( ) + "' AND tTre='" + libraryTable.Rows[i]["tTre"].ToString( ) + "'" ).ToString( );
                        }
                    }
                }
            }
            tableContrast = bll.GetDataTableOfGunQiAll( oddNum );
            if ( tableContrast != null && tableContrast.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableContrast.Rows.Count ; i++ )
                    {
                        for ( int l = 0 ; l < tableQuery.Rows.Count ; l++ )
                        {
                            if ( tableContrast.Rows[i]["AD08"].ToString( ) == tableQuery.Rows[l]["AC02"].ToString( ) && tableContrast.Rows[i]["AD06"].ToString( ) == tableQuery.Rows[l]["AC04"].ToString( ) && tableContrast.Rows[i]["AD07"].ToString( ) == tableQuery.Rows[l]["AC05"].ToString( ) && tableContrast.Rows[i]["AD01"].ToString( ) == tableQuery.Rows[l]["AC18"].ToString( ) )
                            {
                                tableQuery.Rows[l]["FORE"] = tableContrast.Rows[i]["AD12"].ToString( );
                                tableQuery.Rows[l]["FIV"] = tableContrast.Rows[i]["AD12"].ToString( );
                                if ( Convert.ToDecimal( tableQuery.Rows[l]["ONE"].ToString( ) ) == 0 && Convert.ToDecimal( tableQuery.Rows[l]["FIV"].ToString( ) ) == 0 )
                                    tableQuery.Rows.RemoveAt( l );
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                }
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }
        //Sure
        string cn1 = "";
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( conTrasts( ) == false )
                return;

            if ( sign == "R_337" )
            {
                if ( conTrast( ) == false )
                    return;
            }
            else
            {
                if ( conTrastse( ) == false )
                    return;
            }
            libraryTable.Clear( );
            if ( sign != "R_337" )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["FORE"].ToString( ) ) && Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > 0 )
                        libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) + gridView1.GetDataRow( i )["AC04"].ToString( ) ,gridView1.GetDataRow( i )["FORE"].ToString( ) } );
                }
            }
            else
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["FORE"].ToString( ) ) && Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > 0 )
                        libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) + gridView1.GetDataRow( i )["AC04"].ToString( ) + gridView1.GetDataRow( i )["AC02"].ToString( ) ,"" ,gridView1.GetDataRow( i )["FORE"].ToString( ) } );
                    if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) ) && Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) ) > 0 )
                        libraryTable . Rows . Add ( new object [ ] { gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "AC05" ] . ToString ( ) + gridView1 . GetDataRow ( i ) [ "AC04" ] . ToString ( ) + gridView1 . GetDataRow ( i ) [ "AC02" ] . ToString ( ) ,"" ,gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) } );
                }
            }

            //strDic = new Dictionary<string ,string>( );
            //for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            //{
            //    if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
            //    {

            //        count++;
            //        if ( sign == "R_338" )
            //            strDic.Add( gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) );
            //        if ( sign == "R_341" )
            //            strDic.Add( gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC04"].ToString( ) + gridView1.GetDataRow( i )["AC05"].ToString( ) );
            //        if ( sign == "R_342" )
            //            strDic.Add( gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) + gridView1.GetDataRow( i )["AC04"].ToString( ) );
            //        if ( sign == "R_343" )
            //            strDic.Add( gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) + gridView1.GetDataRow( i )["AC04"].ToString( ) );
            //        if ( sign == "R_347" )
            //            strDic.Add( gridView1.GetDataRow( i )["AC18"].ToString( ) ,gridView1.GetDataRow( i )["AC05"].ToString( ) + gridView1.GetDataRow( i )["AC04"].ToString( ) );
            //    }  
            //}
            //if ( count > 0 )
            //{
            cn1 = "1";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,libraryTable );
            if ( PassDataBetweenForm != null )
            {
                this.PassDataBetweenForm( this ,args );
            }
            this.Close( );
            //}
            //else
            //{
            //    MessageBox.Show( "请选择出库对象" );
            //    return;
            //}
        }
        //Cancel
        private void button4_Click ( object sender ,EventArgs e )
        {
            strDic = new Dictionary<string ,string>( );
            cn1 = "2";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,strDic );
            if ( PassDataBetweenForm != null )
            {
                this.PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }

        bool conTrast ( )
        {
            bool result = false;
            string names = "", speci = "", colorNum = "";
            decimal count = 0M;
            gridView1.UpdateCurrentRow( );
            if ( libraryTable != null && libraryTable.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < libraryTable.Rows.Count ; i++ )
                    {
                        speci = libraryTable.Rows[i]["tOne"].ToString( );
                        names = libraryTable.Rows[i]["tTwo"].ToString( );
                        colorNum = libraryTable.Rows[i]["tTre"].ToString( );
                        count = Convert.ToDecimal( libraryTable.Compute( "sum(tFor)" ,"tOne='" + speci + "' AND tTwo='" + names + "' AND tTre='" + colorNum + "'" ).ToString( ) );
                        if ( tableQuery.Select( "AC02='" + speci + "' AND AC04='" + names + "' AND AC05='" + colorNum + "'" ).Length > 0 )
                        {
                            if ( ( string.IsNullOrEmpty( tableQuery.Compute( "sum(FORE)" ,"AC02='" + speci + "' and AC04= '" + names + "' and AC05= '" + colorNum + "' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQuery.Compute( "sum(FORE)" ,"AC02='" + speci + "' and  AC04= '" + names + "' and AC05= '" + colorNum + "'" ) ) ) > count )
                            {
                                MessageBox.Show( "色名:" + names + "\n\r油漆品牌:" + speci + "\n\r色号:"+ colorNum + "\n\r的出库数量大于使用库存数量,请重新填写出库数量" );
                                result = false;
                                break;
                            }
                            if ( ( string.IsNullOrEmpty( tableQuery.Compute( "sum(FORE)" ,"AC02='" + speci + "' and AC04= '" + names + "'  and AC05= '" + colorNum + "'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQuery.Compute( "sum(FORE)" ,"AC02='" + speci + "' and  AC04= '" + names + "' and AC05= '" + colorNum + "'" ) ) ) < count )
                            {
                                MessageBox.Show( "色名:" + names + "\n\r油漆品牌:" + speci + "\n\r色号:" + colorNum + "\n\r的出库数量小于使用库存数量,请重新填写出库数量" );
                                result = false;
                                break;
                            }
                        }
                        if ( i == libraryTable.Rows.Count - 1 )
                            result = true;
                    }
                }
                else
                {
                    MessageBox.Show( "请选择出库对象" );
                    result = false;
                }
            }
            else
            {
                MessageBox.Show( "请选择出库对象" );
                result = false;
            }

            return result;
        }

        bool conTrasts ( )
        {
            bool result = false;
            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["ONE"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["FORE"].ToString( ) )   )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["FIV"].ToString( ) ) )
                        {
                            if ( Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > Convert.ToDecimal( gridView1.GetDataRow( i )["FIV"].ToString( ) ) )
                            {
                                if ( Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > Convert.ToDecimal( gridView1.GetDataRow( i )["ONE"].ToString( ) ) )
                                {
                                    MessageBox.Show( "出库数量大于剩余库存数量,请重新填写出库数量" );
                                    result = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if ( Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > Convert.ToDecimal( gridView1.GetDataRow( i )["ONE"].ToString( ) ) )
                            {
                                MessageBox.Show( "出库数量大于剩余库存数量,请重新填写出库数量" );
                                result = false;
                                break;
                            }
                        }
                    }
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["TRE"].ToString( ) ) && !string.IsNullOrEmpty( gridView1.GetDataRow( i )["FORE"].ToString( ) ) )
                    {
                        if ( Convert.ToDecimal( gridView1.GetDataRow( i )["FORE"].ToString( ) ) > Convert.ToDecimal( gridView1.GetDataRow( i )["TRE"].ToString( ) ) )
                        {
                            MessageBox.Show( "出库数量大于使用库存数量,请重新填写出库数量" );
                            result = false;
                            break;
                        }
                    }
                    if ( i == gridView1.RowCount - 1 )
                        result = true;
                }
            }
            else
            {
                MessageBox.Show( "请选择出库对象" );
                result = false;
            }
            return result;
        }

        bool conTrastse ( )
        {
            bool result = false;
            string names = "", speci = "";
            decimal count = 0M;
            gridView1.UpdateCurrentRow( );
            if ( libraryTable != null && libraryTable.Rows.Count > 0 )
            {
                if ( tableQuery != null && tableQuery.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < libraryTable.Rows.Count ; i++ )
                    {
                        speci = libraryTable.Rows[i]["tOne"].ToString( );
                        names = libraryTable.Rows[i]["tTwo"].ToString( );
                        count = Convert.ToDecimal( libraryTable.Compute( "sum(tTre)" ,"tOne='" + speci + "' AND tTwo='" + names + "'" ).ToString( ) );
                        if ( tableQuery.Select( "AC05='" + speci + "' AND AC04='" + names + "'" ).Length > 0 )
                        {
                            if ( ( string.IsNullOrEmpty( tableQuery.Compute( "sum(FORE)" ,"AC05='" + speci + "' and AC04= '" + names + "' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQuery.Compute( "sum(FORE)" ,"AC05='" + speci + "' and  AC04= '" + names + "'" ) ) ) > count )
                            {
                                MessageBox.Show( "名称:" + names + "\n\r规格:" + speci + "\n\r的出库数量大于使用库存数量,请重新填写出库数量" );
                                result = false;
                                break;
                            }
                            if ( ( string.IsNullOrEmpty( tableQuery.Compute( "sum(FORE)" ,"AC05='" + speci + "' and AC04= '" + names + "' " ).ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQuery.Compute( "sum(FORE)" ,"AC05='" + speci + "' and  AC04= '" + names + "'" ) ) ) < count )
                            {
                                MessageBox.Show( "名称:" + names + "\n\r规格:" + speci + "\n\r的出库数量小于使用库存数量,请重新填写出库数量" );
                                result = false;
                                break;
                            }
                        }
                        if ( i == libraryTable.Rows.Count - 1 )
                            result = true;
                    }
                }
                else
                {
                    MessageBox.Show( "请选择出库对象" );
                    result = false;
                }
            }
            else
            {
                MessageBox.Show( "请选择出库对象" );
                result = false;
            }

            return result;
        }

    }
}
