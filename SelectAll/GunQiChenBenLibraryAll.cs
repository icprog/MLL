using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;
using Mulaolao;

namespace SelectAll
{
    public partial class GunQiChenBenLibraryAll :Form
    {
        public GunQiChenBenLibraryAll ( )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender , PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.OutbandChoiceBll bll = new MulaolaoBll.Bll.OutbandChoiceBll( );
        Dictionary<string ,decimal> strDic=new Dictionary<string, decimal>();
        public string number="",oddNum="";
        public DataTable libraryTable;
        DataTable tableQuery,tableContrast;
        bool result=false;

        private void GunQiChenBenLibraryAll_Load ( object sender , EventArgs e )
        {
            gunQi ( );
        }

        void gunQi ( )
        {
            tableQuery = bll . GetDataTableOfGunQi ( libraryTable ,number ,oddNum );
            addSailsGunQi ( );
            gridControl1 . DataSource = tableQuery;
        }

        void addSailsGunQi ( )
        {

            //if ( libraryTable != null && libraryTable . Rows . Count > 0 )
            //{
            //    if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            //    {
            //        for ( int i = 0 ; i < libraryTable . Rows . Count ; i++ )
            //        {
            //            for ( int l = 0 ; l < tableQuery . Rows . Count ; l++ )
            //            {
            //                if ( libraryTable . Rows [ i ] [ "tOne" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC06" ] . ToString ( ) /*&& libraryTable . Rows [ i ] [ "tTwo" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC04" ] . ToString ( ) && libraryTable . Rows [ i ] [ "tTre" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC05" ] . ToString ( )*/ )
            //                    tableQuery . Rows [ l ] [ "TRE" ] = libraryTable . Compute ( "SUM(tFor)" , "tOne='" + libraryTable . Rows [ i ] [ "tOne" ] . ToString ( ) + "' " ) . ToString ( );
            //             //AND tTwo='" + libraryTable . Rows [ i ] [ "tTwo" ] . ToString ( ) + "' AND tTre='" + libraryTable . Rows [ i ] [ "tTre" ] . ToString ( ) + "'
            //            }
            //        }
            //    }
            //}

            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                for ( int l = 0 ; l < tableQuery . Rows . Count ; l++ )
                {
                    tableQuery . Rows [ l ] [ "TRE" ] = libraryTable . Compute ( "SUM(tFor)" ,null );
                }
            }

            tableContrast = bll . GetDataTableOfGunQiAll ( oddNum );
            if ( tableContrast != null && tableContrast . Rows . Count > 0 )
            {
                if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < tableContrast . Rows . Count ; i++ )
                    {
                        for ( int l = 0 ; l < tableQuery . Rows . Count ; l++ )
                        {
                            if ( tableContrast . Rows [ i ] [ "AD01" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC18" ] . ToString ( ) && tableContrast . Rows [ i ] [ "AD08" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC06" ] . ToString ( )/* && tableContrast . Rows [ i ] [ "AD06" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC04" ] . ToString ( ) && tableContrast . Rows [ i ] [ "AD07" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC05" ] . ToString ( ) && tableContrast . Rows [ i ] [ "AD01" ] . ToString ( ) == tableQuery . Rows [ l ] [ "AC18" ] . ToString ( )*/ )
                            {
                                tableQuery . Rows [ l ] [ "FORE" ] = tableContrast . Rows [ i ] [ "AD12" ] . ToString ( );
                                tableQuery . Rows [ l ] [ "FIV" ] = tableContrast . Rows [ i ] [ "AD12" ] . ToString ( );
                                if ( Convert . ToDecimal ( tableQuery . Rows [ l ] [ "ONE" ] . ToString ( ) ) == 0 && Convert . ToDecimal ( tableQuery . Rows [ l ] [ "FIV" ] . ToString ( ) ) == 0 )
                                    tableQuery . Rows . RemoveAt ( l );
                            }
                        }
                    }
                }
            }

        }

        string cn1="";
        //Sure
        private void button3_Click ( object sender , EventArgs e )
        {
            if ( calculation ( ) == false )
                return;
            if ( calculationS ( ) == false )
                return;
            if ( calculationSe ( ) == false )
                return;

            libraryTable . Clear ( );
            decimal fore = 0, fiv = 0;

            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                fore = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) );
                fiv = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) );

                if ( fore > 0 || fiv>0 )
                    libraryTable . Rows . Add ( new object [ ] { gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) , gridView1 . GetDataRow ( i ) [ "AC06" ] . ToString ( ) , "" , fore } );
            }

            cn1 = "1";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 , libraryTable );
            if ( PassDataBetweenForm != null )
            {
                this . PassDataBetweenForm ( this , args );
            }
            this . Close ( );
        }
        bool calculation ( )
        {
            result = true;
            decimal one = 0, tre = 0, fore = 0, fiv = 0;
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                one = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "ONE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "ONE" ] . ToString ( ) );
                //two = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "TWO" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "TWO" ] . ToString ( ) );
                tre = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "TRE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "TRE" ] . ToString ( ) );
                fore = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) );
                fiv = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FIV" ] . ToString ( ) );
                if ( fore != fiv )
                {
                    if ( fore > tre )
                    {
                        MessageBox . Show ( "出库数量大于使用库存数量,请重新填写" );
                        result = false;
                        break;
                    }
                    if ( fore > one )
                    {
                        MessageBox . Show ( "出库数量大于剩余库存数量,请重新填写" );
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        bool calculationSe ( )
        {
            result = true;
            decimal fore = Convert . ToDecimal ( FORE . SummaryItem . SummaryValue );
            decimal tre = string . IsNullOrEmpty ( gridView1 . GetDataRow ( 0 ) [ "TRE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( 0 ) [ "TRE" ] . ToString ( ) );
            if ( fore > tre )
            {
                MessageBox . Show ( "出库数量多于使用库存数量,请核实" );
                return false;
            }

            return result;
        }

        bool calculationS ( )
        {
            result = true;
            decimal fore = 0, fiv = 0;
            strDic . Clear ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                fore = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "FORE" ] . ToString ( ) );

                //if ( strDic . ContainsKey ( gridView1 . GetDataRow ( i ) [ "AC06" ] . ToString ( ) ) )
                //    strDic [ gridView1 . GetDataRow ( i ) [ "AC06" ] . ToString ( ) ] = strDic [ gridView1 . GetDataRow ( i ) [ "AC06" ] . ToString ( ) ] + fore;
                //else
                //    strDic . Add ( gridView1 . GetDataRow ( i ) [ "AC06" ] . ToString ( ) ,fore );
                if ( fore > 0 )
                {
                    if ( strDic . ContainsKey ( gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) ) )
                        strDic [ gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) ] = strDic [ gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) ] + fore;
                    else
                        strDic . Add ( gridView1 . GetDataRow ( i ) [ "AC18" ] . ToString ( ) ,fore );
                    fiv += fore;
                }
            }

            if ( strDic . Count > 0 )
            {
                for ( int k = 0 ; k < tableQuery . Rows . Count ; k++ )
                {
                    string str = tableQuery . Rows [ k ] [ "AC18" ] . ToString ( );
                    if ( strDic . ContainsKey ( str ) )
                    {
                        string si = strDic [ tableQuery . Rows [ k ] [ "AC18" ] . ToString ( ) ] . ToString ( );
                        string sj = tableQuery . Rows [ k ] [ "TRE" ] . ToString ( );
                        if ( Convert . ToDecimal ( sj ) > 0 )
                        {
                            if ( strDic [ tableQuery . Rows [ k ] [ "AC18" ] . ToString ( ) ] > Convert . ToDecimal ( tableQuery . Rows [ k ] [ "TRE" ] . ToString ( ) ) )
                            {
                                MessageBox . Show ( "出库数量大于使用库存数量,请核实" );
                                result = false;
                                break;
                            }
                            else if ( /*strDic [ tableQuery . Rows [ k ] [ "AC18" ] . ToString ( ) ] < Convert . ToDecimal ( tableQuery . Rows [ k ] [ "TRE" ] . ToString ( ) )*/ Convert . ToDecimal ( tableQuery . Rows [ k ] [ "TRE" ] . ToString ( ) ) > fiv )
                            {
                                MessageBox . Show ( "出库数量小于使用库存数量,请核实" );
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            return result;
        }
        //Cancel
        private void button4_Click ( object sender , EventArgs e )
        {
            cn1 = "2";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 );
            if ( PassDataBetweenForm != null )
            {
                this . PassDataBetweenForm ( this , args );
            }
            this . Close ( );
        }
        private void GunQiChenBenLibraryAll_FormClosing ( object sender ,FormClosingEventArgs e )
        {
        }

        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( Class . LoginUser . UserNum . Equals ( "MLL-0001" ) )
            {
                if ( ( e . ClickedItem ) . Name == "MenuItem" )
                {
                    GunQiChenBenLibraryEditAll al = new GunQiChenBenLibraryEditAll ( );
                    al . StartPosition = FormStartPosition . CenterScreen;
                    al . PassDataBetweenForm += new GunQiChenBenLibraryEditAll . PassDataBetweenFormHandler ( al_Pass );
                    al . ShowDialog ( );
                }
            }
        }

        private void al_Pass ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e . ConTwo == "1" )
            {
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "TRE" ] ,e . ConOne );
                }
            }
        }


    }
}
