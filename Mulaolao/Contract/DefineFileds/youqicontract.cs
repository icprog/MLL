using Mulaolao.Class;
using StudentMgr;
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mulaolao.Contract.DefineFileds
{
    public class youqicontract
    {
        MulaolaoLibrary.HuaXuePiCiChenBen hxp = new MulaolaoLibrary.HuaXuePiCiChenBen( );

        /// <summary>
        /// R_339写入285
        /// </summary>
        /// <param name="oddNum"></param>
        public void writeTwoEgiFiv ( string oddNum )
        {
            try
            {
                decimal lastTimePartNum = 0, lastTimeProductNum = 0;
                //bool result = false;
                int count = 0;
                DataTable dl = new DataTable ( );
                DataTable da = SqlHelper . ExecuteDataTable ( "SELECT YQ03,YQ06,YQ10,YQ11,YQ12,YQ13,YQ14,YQ15,YQ16,YQ101,YQ105,YQ107,YQ108,YQ109,YQ112,YQ113,YQ114,YQ115,YQ116,YQ117,YQ118,YQ120,YQ121,YQ122,(SELECT TOP 1 PY07 FROM R_PQY WHERE YQ03=PY01) PY07,(SELECT TOP 1 PY04 FROM R_PQY WHERE YQ03=PY01) PY04 FROM R_PQI WHERE YQ99 = @YQ99 AND YQ99 LIKE 'R_339%'" ,new SqlParameter ( "@YQ99" ,oddNum ) );
                if ( da . Rows . Count < 1 )
                    MessageBox . Show ( "请重新查询" );
                else
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ03" ] . ToString ( ) ) && da . Rows [ i ] [ "YQ101" ] . ToString ( ) == "外购" && !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) ) )
                        {
                            hxp . PQK02 = da . Rows [ i ] [ "YQ03" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ108" ] . ToString ( ) ) )
                                hxp . PQK23 = Convert . ToInt64 ( da . Rows [ i ] [ "YQ108" ] . ToString ( ) );
                            else
                                hxp . PQK23 = 0;
                            lastTimeProductNum = hxp . PQK23;
                            hxp . PQK11 = da . Rows [ i ] [ "YQ11" ] . ToString ( );
                            hxp . PQK17 = da . Rows [ i ] [ "YQ12" ] . ToString ( );
                            hxp . PQK12 = da . Rows [ i ] [ "YQ105" ] . ToString ( );
                            hxp . PQK13 = da . Rows [ i ] [ "YQ107" ] . ToString ( );
                            hxp . PQK07 = da . Rows [ i ] [ "YQ10" ] . ToString ( );
                            hxp . PQK14 = da . Rows [ i ] [ "YQ06" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ112" ] . ToString ( ) ) )
                                hxp . PQK20 = Convert . ToInt32 ( da . Rows [ i ] [ "YQ112" ] . ToString ( ) );
                            else
                                hxp . PQK20 = 0;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ113" ] . ToString ( ) ) )
                                hxp . PQK22 = Convert . ToInt32 ( da . Rows [ i ] [ "YQ113" ] . ToString ( ) );
                            else
                                hxp . PQK22 = 0;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ114" ] . ToString ( ) ) )
                                hxp . PQK08 = Convert . ToInt32 ( da . Rows [ i ] [ "YQ114" ] . ToString ( ) );
                            else
                                hxp . PQK08 = 0;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ116" ] . ToString ( ) ) )
                                hxp . PQK21 = Convert . ToInt32 ( da . Rows [ i ] [ "YQ116" ] . ToString ( ) );
                            else
                                hxp . PQK21 = 0;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ13" ] . ToString ( ) ) )
                                hxp . PQK27 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ13" ] . ToString ( ) );
                            else
                                hxp . PQK27 = 0M;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) ) )
                                hxp . PQK26 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) );
                            else
                                hxp . PQK26 = 0M;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ115" ] . ToString ( ) ) )
                                hxp . PQK19 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ115" ] . ToString ( ) );
                            else
                                hxp . PQK19 = 0M;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) ) )
                                hxp . PQK28 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) );
                            else
                                hxp . PQK28 = 0M;
                            hxp . PQK24 = da . Rows [ i ] [ "YQ117" ] . ToString ( );
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ15" ] . ToString ( ) ) )
                                hxp . PQK25 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ15" ] . ToString ( ) );
                            else
                                hxp . PQK25 = 0M;
                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) ) )
                            {
                                if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) ) && Convert . ToDecimal ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) ) > 0 )
                                {
                                    hxp . PQK18 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) );
                                    hxp . PQK32 = 0;
                                    lastTimePartNum = hxp . PQK18;
                                }
                                else if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) ) && Convert . ToDecimal ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) ) > 0 )
                                {
                                    hxp . PQK18 = 0;
                                    hxp . PQK32 = Convert . ToDecimal ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) );
                                    lastTimePartNum = hxp . PQK32;
                                }
                            }
                            else
                                hxp . PQK18 = hxp . PQK32 = 0M;

                            hxp . PQK35 = da . Rows [ i ] [ "YQ120" ] . ToString ( );
                            hxp . PQK36 = da . Rows [ i ] [ "YQ121" ] . ToString ( );
                            hxp . PQK03 = da . Rows [ i ] [ "PY07" ] . ToString ( );
                            //495填表策划人
                            hxp . PQK04 = da . Rows [ i ] [ "PY04" ] . ToString ( );
                            hxp . PQK30 = oddNum;

                            dl = SqlHelper . ExecuteDataTable ( "SELECT PQK02,PQK07,PQK11,PQK17,PQK18,PQK23,PQK32,PQK30,PQK35,PQK36,PQK16,PQK01 FROM R_PQK WHERE PQK02=@PQK02" ,new SqlParameter ( "@PQK02" ,hxp . PQK02 ) );
                            if ( dl . Rows . Count < 1 )
                            {
                                hxp . PQK01 = oddNumbers . purchaseContract ( "SELECT MAX(PQK01) PQK01 FROM R_PQK" ,"PQK01" ,"R_285-" );
                                hxp . PQK16 = hxp . PQK02 + "001";
                                count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQK (PQK01,PQK30,PQK16,PQK02,PQK07,PQK12,PQK13,PQK14,PQK15,PQK03,PQK04,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK18,PQK32,PQK35,PQK36) VALUES (@PQK01,@PQK30,@PQK16,@PQK02,@PQK07,@PQK12,@PQK13,@PQK14,@PQK15,@PQK03,@PQK04,@PQK11,@PQK17,@PQK08,@PQK19,@PQK20,@PQK21,@PQK22,@PQK23,@PQK24,@PQK25,@PQK26,@PQK27,@PQK28,@PQK18,@PQK32,@PQK35,@PQK36)" ,new SqlParameter ( "@PQK01" ,hxp . PQK01 ) ,new SqlParameter ( "@PQK30" ,hxp . PQK30 ) ,new SqlParameter ( "@PQK16" ,hxp . PQK16 ) ,new SqlParameter ( "@PQK02" ,hxp . PQK02 ) ,new SqlParameter ( "@PQK07" ,hxp . PQK07 ) ,new SqlParameter ( "@PQK12" ,hxp . PQK12 ) ,new SqlParameter ( "@PQK13" ,hxp . PQK13 ) ,new SqlParameter ( "@PQK14" ,hxp . PQK14 ) ,new SqlParameter ( "@PQK15" ,"" ) ,new SqlParameter ( "@PQK03" ,hxp . PQK03 ) ,new SqlParameter ( "@PQK04" ,hxp . PQK04 ) ,new SqlParameter ( "@PQK11" ,hxp . PQK11 ) ,new SqlParameter ( "@PQK17" ,hxp . PQK17 ) ,new SqlParameter ( "@PQK08" ,hxp . PQK08 ) ,new SqlParameter ( "@PQK19" ,hxp . PQK19 ) ,new SqlParameter ( "@PQK20" ,hxp . PQK20 ) ,new SqlParameter ( "@PQK21" ,hxp . PQK21 ) ,new SqlParameter ( "@PQK22" ,hxp . PQK22 ) ,new SqlParameter ( "@PQK23" ,hxp . PQK23 ) ,new SqlParameter ( "@PQK24" ,hxp . PQK24 ) ,new SqlParameter ( "@PQK25" ,hxp . PQK25 ) ,new SqlParameter ( "@PQK26" ,hxp . PQK26 ) ,new SqlParameter ( "@PQK27" ,hxp . PQK27 ) ,new SqlParameter ( "@PQK28" ,hxp . PQK28 ) ,new SqlParameter ( "@PQK18" ,hxp . PQK18 ) ,new SqlParameter ( "@PQK32" ,hxp . PQK32 ) ,new SqlParameter ( "@PQK35" ,hxp . PQK35 ) ,new SqlParameter ( "@PQK36" ,hxp . PQK36 ) );
                                if ( count > 0 )
                                    SqlHelper . ExecuteNonQuery ( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter ( "@YQ118" ,lastTimePartNum ) ,new SqlParameter ( "@YQ122" ,lastTimeProductNum ) ,new SqlParameter ( "@YQ99" ,oddNum ) ,new SqlParameter ( "@YQ10" ,hxp . PQK07 ) ,new SqlParameter ( "@YQ11" ,hxp . PQK11 ) ,new SqlParameter ( "@YQ12" ,hxp . PQK17 ) );
                            }
                            else
                            {
                                hxp . PQK01 = dl . Select ( "PQK02='" + hxp . PQK02 + "'" ) [ 0 ] [ "PQK01" ] . ToString ( );
                                if ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) . Length > 0 )
                                {
                                    //if ( !dl . Select ( "PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK30" ] . ToString ( ) . Contains ( oddNum ) )
                                    //    hxp . PQK30 = dl . Select ( "PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK30" ] . ToString ( ) + "," + oddNum;
                                    //else
                                    //    hxp . PQK30 = dl . Select ( "PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK30" ] . ToString ( );

                                    if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ109" ] . ToString ( ) ) )
                                    {
                                        if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) ) && Convert . ToDecimal ( da . Rows [ i ] [ "YQ14" ] . ToString ( ) ) > 0 )
                                        {
                                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ118" ] . ToString ( ) ) )
                                                hxp . PQK18 = hxp . PQK18 - Convert . ToDecimal ( da . Rows [ i ] [ "YQ118" ] . ToString ( ) );
                                            if ( !string . IsNullOrEmpty ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK18" ] . ToString ( ) ) )
                                                hxp . PQK18 = hxp . PQK18 + Convert . ToDecimal ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK18" ] . ToString ( ) );
                                            hxp . PQK32 = 0;
                                        }
                                        else if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) ) && Convert . ToDecimal ( da . Rows [ i ] [ "YQ16" ] . ToString ( ) ) > 0 )
                                        {
                                            hxp . PQK18 = 0;
                                            if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ118" ] . ToString ( ) ) )
                                                hxp . PQK32 = hxp . PQK32 - Convert . ToDecimal ( da . Rows [ i ] [ "YQ118" ] . ToString ( ) );
                                            if ( !string . IsNullOrEmpty ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK32" ] . ToString ( ) ) )
                                                hxp . PQK32 = hxp . PQK32 + Convert . ToDecimal ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK32" ] . ToString ( ) );
                                        }
                                    }
                                    if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "YQ122" ] . ToString ( ) ) )
                                        hxp . PQK23 = hxp . PQK23 - Convert . ToInt64 ( da . Rows [ i ] [ "YQ122" ] . ToString ( ) );
                                    if ( !string . IsNullOrEmpty ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK23" ] . ToString ( ) ) )
                                        hxp . PQK23 = hxp . PQK23 + Convert . ToInt64 ( dl . Select ( "PQK30='" + hxp . PQK30 + "' AND PQK07='" + hxp . PQK07 + "' AND PQK11='" + hxp . PQK11 + "' AND PQK17='" + hxp . PQK17 + "'" ) [ 0 ] [ "PQK23" ] . ToString ( ) );
                                    count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQK SET PQK18=@PQK18,PQK32=@PQK32,PQK23=@PQK23,PQK04=@PQK04 WHERE PQK01=@PQK01 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17 AND PQK30=@PQK30" ,new SqlParameter ( "@PQK30" ,hxp . PQK30 ) ,new SqlParameter ( "@PQK18" ,hxp . PQK18 ) ,new SqlParameter ( "@PQK32" ,hxp . PQK32 ) ,new SqlParameter ( "@PQK23" ,hxp . PQK23 ) ,new SqlParameter ( "@PQK01" ,hxp . PQK01 ) ,new SqlParameter ( "@PQK07" ,hxp . PQK07 ) ,new SqlParameter ( "@PQK11" ,hxp . PQK11 ) ,new SqlParameter ( "@PQK17" ,hxp . PQK17 ) ,new SqlParameter ( "@PQK04" ,hxp . PQK04 ) );
                                    if ( count > 0 )
                                        SqlHelper . ExecuteNonQuery ( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter ( "@YQ118" ,lastTimePartNum ) ,new SqlParameter ( "@YQ122" ,lastTimeProductNum ) ,new SqlParameter ( "@YQ99" ,oddNum ) ,new SqlParameter ( "@YQ10" ,hxp . PQK07 ) ,new SqlParameter ( "@YQ11" ,hxp . PQK11 ) ,new SqlParameter ( "@YQ12" ,hxp . PQK17 ) );
                                }
                                else
                                {
                                    hxp . PQK16 = ( Convert . ToInt64 ( dl . AsEnumerable ( ) . Select ( t => t . Field<string> ( "PQK16" ) ) . Max ( ) ) + 1 ) . ToString ( );
                                    count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQK (PQK01,PQK30,PQK16,PQK02,PQK07,PQK12,PQK13,PQK14,PQK15,PQK03,PQK04,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK18,PQK32,PQK35,PQK36) VALUES (@PQK01,@PQK30,@PQK16,@PQK02,@PQK07,@PQK12,@PQK13,@PQK14,@PQK15,@PQK03,@PQK04,@PQK11,@PQK17,@PQK08,@PQK19,@PQK20,@PQK21,@PQK22,@PQK23,@PQK24,@PQK25,@PQK26,@PQK27,@PQK28,@PQK18,@PQK32,@PQK35,@PQK36)" ,new SqlParameter ( "@PQK01" ,hxp . PQK01 ) ,new SqlParameter ( "@PQK30" ,hxp . PQK30 ) ,new SqlParameter ( "@PQK16" ,hxp . PQK16 ) ,new SqlParameter ( "@PQK02" ,hxp . PQK02 ) ,new SqlParameter ( "@PQK07" ,hxp . PQK07 ) ,new SqlParameter ( "@PQK12" ,hxp . PQK12 ) ,new SqlParameter ( "@PQK13" ,hxp . PQK13 ) ,new SqlParameter ( "@PQK14" ,hxp . PQK14 ) ,new SqlParameter ( "@PQK15" ,"" ) ,new SqlParameter ( "@PQK03" ,hxp . PQK03 ) ,new SqlParameter ( "@PQK04" ,hxp . PQK04 ) ,new SqlParameter ( "@PQK11" ,hxp . PQK11 ) ,new SqlParameter ( "@PQK17" ,hxp . PQK17 ) ,new SqlParameter ( "@PQK08" ,hxp . PQK08 ) ,new SqlParameter ( "@PQK19" ,hxp . PQK19 ) ,new SqlParameter ( "@PQK20" ,hxp . PQK20 ) ,new SqlParameter ( "@PQK21" ,hxp . PQK21 ) ,new SqlParameter ( "@PQK22" ,hxp . PQK22 ) ,new SqlParameter ( "@PQK23" ,hxp . PQK23 ) ,new SqlParameter ( "@PQK24" ,hxp . PQK24 ) ,new SqlParameter ( "@PQK25" ,hxp . PQK25 ) ,new SqlParameter ( "@PQK26" ,hxp . PQK26 ) ,new SqlParameter ( "@PQK27" ,hxp . PQK27 ) ,new SqlParameter ( "@PQK28" ,hxp . PQK28 ) ,new SqlParameter ( "@PQK18" ,hxp . PQK18 ) ,new SqlParameter ( "@PQK32" ,hxp . PQK32 ) ,new SqlParameter ( "@PQK35" ,hxp . PQK35 ) ,new SqlParameter ( "@PQK36" ,hxp . PQK36 ) );
                                    if ( count > 0 )
                                        SqlHelper . ExecuteNonQuery ( "UPDATE R_PQI SET YQ118=@YQ118,YQ122=@YQ122 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter ( "@YQ118" ,lastTimePartNum ) ,new SqlParameter ( "@YQ122" ,lastTimeProductNum ) ,new SqlParameter ( "@YQ99" ,oddNum ) ,new SqlParameter ( "@YQ10" ,hxp . PQK07 ) ,new SqlParameter ( "@YQ11" ,hxp . PQK11 ) ,new SqlParameter ( "@YQ12" ,hxp . PQK17 ) );
                                    //result = false;
                                }
                            }
                        }
                        if ( count < 1 )
                        {
                            MessageBox . Show ( "写入失败" );
                            //return;
                        }
                        else if ( i == da . Rows . Count - 1 )
                            MessageBox . Show ( "成功写入R_285" );
                    }
                }
            }
            catch ( Exception ex )
            {
                AutoUpdate . LogHelper . WriteLog ( ex . Message + " \n\r" + ex . StackTrace );
                throw new Exception ( ex . Message );
            }

            //if ( result == false )
            //{
            //if ( count < 1 )
            //    MessageBox.Show( "写入R_285失败" );
            //else
            //    MessageBox.Show( "成功写入R_285" );
            //}
        }
    }
}
