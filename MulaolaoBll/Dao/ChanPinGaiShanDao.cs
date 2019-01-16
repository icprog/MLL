using StudentMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class ChanPinGaiShanDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQU10 GS07 FROM R_PQU " );
            strSql.Append( " WHERE PQU100=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT PQV10 FROM R_PQV " );
            strSql.Append( " WHERE PQV79=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT YQ10 FROM R_PQI " );
            strSql.Append( " WHERE YQ107=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT JM09 FROM R_PQO " );
            strSql.Append( " WHERE JM102=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT CP06 FROM R_PQQ " );
            strSql.Append( " WHERE CP53=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT PJ09 FROM R_PQS " );
            strSql.Append( " WHERE PJ95=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT WX10 FROM R_PQT " );
            strSql.Append( " WHERE WX85=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT AF015 FROM R_PQAF " );
            strSql.Append( " WHERE AF004=@ODD " );
            strSql.Append( " UNION SELECT DISTINCT AH10 FROM R_PQAH " );
            strSql.Append( " WHERE AH100=@ODD" );

            SqlParameter[] parameter = {
                new SqlParameter("@ODD",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOn ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT WX10 GS56 FROM R_PQT" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( string number )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06 FROM R_PQF" );
            strSql.Append( " WHERE PQF03=@PQF03" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQF03",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNumOf (string str )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06 FROM R_PQF" );
            strSql.Append( " WHERE PQF01 IN ("+str+")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( )  );
        }

        /// <summary>
        /// 获取材料
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMaterial ( string str )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS02,'' GS2,GS04,0.0000 GS4,GS05,0.00 GS5,GS07,'' GS7,GS08,'' GS8,GS10,0.0000 GS010,GS11,0.000 GS011,GS51,0.000 GS051 FROM R_PQP" );
            strSql.Append( " WHERE GS02!='' AND GS01 IN (" + str + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取工段
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAccess ( string str )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS35,'' GS035,GS36,0.0000 GS036,GS37,0.00 GS037 FROM R_PQP" );
            strSql.Append( " WHERE GS35 IS NOT NULL AND GS35!='' AND GS01 IN (" + str + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取辅料
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWorkShop ( string str )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GS52,'' GS052,GS53,0.0000 GS053,GS54,0.0000 GS054,GS56,'' GS056,GS57,'' GS057,GS59,0 GS059,GS60,0.0000 GS060,GS61,0.0000 GS061 FROM R_PQP" );
            strSql.Append( " WHERE GS52 IS NOT NULL AND GS52!='' AND GS01 IN (" + str + ")" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="gs34"></param>
        /// <returns></returns>
        public DataTable printTableOne ( string gs34 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS46,GS47,GS48,GS01,GS49 GS049,GS50,GS03,GS02,GS49,GS04,GS05,GS04-D.U7 U0,D.U7,GS04-GS05 U1,GS05*GS49*GS10 U2,GS49*(GS04-D.U7) U3,GS49*GS10 U4,GS07,GS08,GS09,GS10,GS11,GS10*GS11 U5,GS51,GS13,GS49*(GS04-D.U7)*GS13 U6,GS14,GS15,GS16,GS17,GS18,CONVERT(NVARCHAR(20),GS19,111) GS19,(SELECT DGA003 FROM TPADGA WHERE GS20 = DGA001 ) DGA003 ,(SELECT DGA011 FROM TPADGA WHERE GS20 = DGA001 ) DGA011 FROM R_PQP A,(SELECT GS02 U0 ,SUM( GS10 * GS11 ) U7 FROM R_PQP GROUP BY GS02 ) D WHERE GS34=@GS34 AND A.GS02 = D.U0 AND GS02!='' AND GS02 IS NOT NULL ORDER BY GS02" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS34",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = gs34;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        public DataTable printTableTwo (  string gs34)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS35,GS36,GS37,GS36-GS37 U10,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45 FROM R_PQP WHERE GS34=@GS34 AND GS35 IS NOT NULL AND GS35!=''" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS34",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = gs34;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        public DataTable printTableTre ( string gs34 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS52,GS49,GS61,GS53,GS54,GS53-D.U11 U9,D.U11,GS53-GS54 U12,GS54*GS49*GS59 U13,GS49*(GS53-D.U11) U14,GS49*GS59 U15,GS56 ,GS57 ,GS58 ,GS59 ,GS60 ,GS59 * GS60 U16 ,GS69 ,GS69 * GS49 * ( GS53 - D.U11 ) U17 ,GS62 ,GS63 ,GS64 ,GS65 ,GS66 ,CONVERT(NVARCHAR(20),GS67,111) GS67 ,( SELECT DGA003 FROM TPADGA WHERE GS68 = DGA001 ) DGA003 ,( SELECT DGA011 FROM TPADGA WHERE GS68 = DGA001 ) DGA011,GS61 FROM R_PQP A, ( SELECT GS52 U0 ,SUM( GS59 * GS60 ) U11 FROM R_PQP GROUP BY GS52 ) D  WHERE GS34=@GS34 AND A.GS52 = D.U0 AND GS52!= '' AND GS52 IS NOT NULL ORDER BY GS52" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS34",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = gs34;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        public DataTable printTableFor ( string gs34 )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GS22,GS23,GS24,GS25,GS26,GS27,GS28,GS29,GS30,GS31 FROM R_PQP WHERE GS34=@GS34" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS34",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = gs34;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

       /// <summary>
       /// 批量编辑
       /// </summary>
       /// <param name="tableOne"></param>
       /// <param name="tableTwo"></param>
       /// <param name="tableTre"></param>
       /// <param name="idxList"></param>
       /// <returns></returns>
        public bool Update ( DataTable tableOne ,DataTable tableTwo ,DataTable tableTre,List<string> idxList )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            string str = "";
            foreach ( string s in idxList )
            {
                if ( str == "" )
                    str = "'" + s + "'";
                else
                    str = str + "," + "'" + s + "'";
            }
            #region
            if ( tableOne != null && tableOne.Rows.Count > 0 )
            {
                string gs2 = "", gs02 = "", gs7 = "", gs07 = "", gs8 = "", gs08 = "";
                for ( int i = 0 ; i < tableOne.Rows.Count ; i++ )
                {
                     gs2 = tableOne.Rows[i]["GS2"].ToString( );
                     gs02 = tableOne.Rows[i]["GS02"].ToString( );
                     gs7 = tableOne.Rows[i]["GS7"].ToString( );
                     gs07 = tableOne.Rows[i]["GS07"].ToString( );
                     gs8 = tableOne.Rows[i]["GS8"].ToString( );
                     gs08 = tableOne.Rows[i]["GS08"].ToString( );
                    if (!string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                    {
                        strSql = new StringBuilder( );
                        strSql.AppendFormat( "UPDATE R_PQP SET GS02='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs2 ,gs02 ,gs07 ,gs08 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                            strSql.AppendFormat( "UPDATE R_PQP SET GS07='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs7 ,gs2 ,gs07 ,gs08 );
                        else
                            strSql.AppendFormat( "UPDATE R_PQP SET GS07='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs7 ,gs02 ,gs07 ,gs08 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                                strSql.AppendFormat( "UPDATE R_PQP SET GS08='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs8 ,gs2 ,gs7 ,gs08 );
                            else
                                strSql.AppendFormat( "UPDATE R_PQP SET GS08='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs8 ,gs2 ,gs07 ,gs08 );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                                strSql.AppendFormat( "UPDATE R_PQP SET GS08='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs8 ,gs02 ,gs7 ,gs08 );
                            else
                                strSql.AppendFormat( "UPDATE R_PQP SET GS08='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,gs8 ,gs02 ,gs07 ,gs08 );
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableOne.Rows[i]["GS4"].ToString( ) ) && !string.IsNullOrEmpty( tableOne.Rows[i]["GS04"].ToString( ) ) && Convert.ToDecimal( tableOne.Rows[i]["GS4"].ToString( ) )>0 && Convert.ToDecimal( tableOne.Rows[i]["GS04"].ToString( ) ) != Convert.ToDecimal( tableOne.Rows[i]["GS4"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                {
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs2 ,gs7 ,gs8 );
                                }
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs2 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs2 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs2 ,gs07 ,gs08 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs02 ,gs7 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs02 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs02 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS04='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS4"].ToString( ) ,gs02 ,gs07 ,gs08 );
                            }
                        }

                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableOne.Rows[i]["GS5"].ToString( ) ) && !string.IsNullOrEmpty( tableOne.Rows[i]["GS05"].ToString( ) ) && Convert.ToDecimal( tableOne.Rows[i]["GS5"].ToString( ) ) > 0 && Convert.ToDecimal( tableOne.Rows[i]["GS05"].ToString( ) ) != Convert.ToDecimal( tableOne.Rows[i]["GS5"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                {
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs2 ,gs7 ,gs8 );
                                }
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs2 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs2 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs2 ,gs07 ,gs08 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs02 ,gs7 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs02 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs02 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS05='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS5"].ToString( ) ,gs02 ,gs07 ,gs08 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableOne.Rows[i]["GS010"].ToString( ) ) && !string.IsNullOrEmpty( tableOne.Rows[i]["GS10"].ToString( ) ) && Convert.ToDecimal( tableOne.Rows[i]["GS010"].ToString( ) ) > 0 && Convert.ToDecimal( tableOne.Rows[i]["GS10"].ToString( ) ) != Convert.ToDecimal( tableOne.Rows[i]["GS010"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                {
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs2 ,gs7 ,gs8 );
                                }
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs2 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs2 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs2 ,gs07 ,gs08 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs02 ,gs7 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs02 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs02 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS10='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS010"].ToString( ) ,gs02 ,gs07 ,gs08 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableOne.Rows[i]["GS011"].ToString( ) ) && !string.IsNullOrEmpty( tableOne.Rows[i]["GS11"].ToString( ) ) && Convert.ToDecimal( tableOne.Rows[i]["GS011"].ToString( ) ) > 0 && Convert.ToDecimal( tableOne.Rows[i]["GS11"].ToString( ) ) != Convert.ToDecimal( tableOne.Rows[i]["GS011"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                {
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs2 ,gs7 ,gs8 );
                                }
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs2 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs2 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs2 ,gs07 ,gs08 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs02 ,gs7 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs02 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs02 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS11='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS011"].ToString( ) ,gs02 ,gs07 ,gs08 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableOne.Rows[i]["GS051"].ToString( ) ) && !string.IsNullOrEmpty( tableOne.Rows[i]["GS51"].ToString( ) ) && Convert.ToDecimal( tableOne.Rows[i]["GS051"].ToString( ) ) > 0 && Convert.ToDecimal( tableOne.Rows[i]["GS51"].ToString( ) ) != Convert.ToDecimal( tableOne.Rows[i]["GS051"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs2 ) && gs02 != gs2 )
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                {
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs2 ,gs7 ,gs8 );
                                }
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs2 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs2 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs2 ,gs07 ,gs08 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs7 ) && gs07 != gs7 )
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs02 ,gs7 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs02 ,gs7 ,gs08 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs8 ) && gs08 != gs8 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs02 ,gs07 ,gs8 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS51='{0}' WHERE GS01 IN (" + str + ") AND GS02='{1}' AND GS07='{2}' AND GS08='{3}'" ,tableOne.Rows[i]["GS051"].ToString( ) ,gs02 ,gs07 ,gs08 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                }
            }
            #endregion

            #region
            if ( tableTwo != null && tableTwo.Rows.Count > 0 )
            {
                string gs35 = "", gs035 = "";
                for ( int k = 0 ; k < tableTwo.Rows.Count ; k++ )
                {
                    gs35 = tableTwo.Rows[k]["GS35"].ToString( );
                    gs035 = tableTwo.Rows[k]["GS035"].ToString( );
                    if ( !string.IsNullOrEmpty( gs035 ) && gs35 != gs035 )
                    {
                        strSql = new StringBuilder( );
                        strSql.AppendFormat( "UPDATE R_PQP SET GS35='{0}' WHERE GS01 IN (" + str + ") AND GS35='{1}'" ,gs035 ,gs35 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTwo.Rows[k]["GS036"].ToString( ) ) && !string.IsNullOrEmpty( tableTwo.Rows[k]["GS36"].ToString( ) ) && Convert.ToDecimal( tableTwo.Rows[k]["GS036"].ToString( ) ) > 0 && Convert.ToDecimal( tableTwo.Rows[k]["GS36"].ToString( ) ) != Convert.ToDecimal( tableTwo.Rows[k]["GS036"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs035 ) && gs35 != gs035 )
                            strSql.AppendFormat( "UPDATE R_PQP SET GS36='{0}' WHERE GS01 IN (" + str + ") AND GS35='{1}'" ,tableTwo.Rows[k]["GS036"].ToString( ) ,gs035 );
                        else
                            strSql.AppendFormat( "UPDATE R_PQP SET GS36='{0}' WHERE GS01 IN (" + str + ") AND GS35='{1}'" ,tableTwo.Rows[k]["GS036"].ToString( ) ,gs35 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTwo.Rows[k]["GS037"].ToString( ) ) && !string.IsNullOrEmpty( tableTwo.Rows[k]["GS37"].ToString( ) ) && Convert.ToDecimal( tableTwo.Rows[k]["GS037"].ToString( ) ) > 0 && Convert.ToDecimal( tableTwo.Rows[k]["GS37"].ToString( ) ) != Convert.ToDecimal( tableTwo.Rows[k]["GS037"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs035 ) && gs35 != gs035 )
                            strSql.AppendFormat( "UPDATE R_PQP SET GS37='{0}' WHERE GS01 IN (" + str + ") AND GS35='{1}'" ,tableTwo.Rows[k]["GS037"].ToString( ) ,gs035 );
                        else
                            strSql.AppendFormat( "UPDATE R_PQP SET GS37='{0}' WHERE GS01 IN (" + str + ") AND GS35='{1}'" ,tableTwo.Rows[k]["GS037"].ToString( ) ,gs35 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                }
            }
            #endregion

            #region
            if ( tableTre != null && tableTre.Rows.Count > 0 )
            {
                string gs52 = "", gs052 = "", gs56 = "", gs056 = "", gs57 = "", gs057 = "";
                for ( int l = 0 ; l < tableTre.Rows.Count ; l++ )
                {
                    gs52 = tableTre.Rows[l]["GS52"].ToString( );
                    gs052 = tableTre.Rows[l]["GS052"].ToString( );
                    gs56 = tableTre.Rows[l]["GS56"].ToString( );
                    gs056 = tableTre.Rows[l]["GS056"].ToString( );
                    gs57 = tableTre.Rows[l]["GS57"].ToString( );
                    gs057 = tableTre.Rows[l]["GS057"].ToString( );
                    if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                    {
                        strSql = new StringBuilder( );
                        strSql.AppendFormat( "UPDATE R_PQP SET GS52='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs052 ,gs52 ,gs56 ,gs57 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                            strSql.AppendFormat( "UPDATE R_PQP SET GS56='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs056 ,gs052 ,gs56 ,gs57 );
                        else
                            strSql.AppendFormat( "UPDATE R_PQP SET GS56='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs056 ,gs52 ,gs56 ,gs57 );
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                                strSql.AppendFormat( "UPDATE R_PQP SET GS57='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs057 ,gs052 ,gs056 ,gs57 );
                            else
                                strSql.AppendFormat( "UPDATE R_PQP SET GS57='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs057 ,gs052 ,gs56 ,gs57 );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                                strSql.AppendFormat( "UPDATE R_PQP SET GS57='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs057 ,gs52 ,gs056 ,gs57 );
                            else
                                strSql.AppendFormat( "UPDATE R_PQP SET GS57='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,gs057 ,gs52 ,gs56 ,gs57 );
                        }
                           
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTre.Rows[l]["GS053"].ToString( ) ) && !string.IsNullOrEmpty( tableTre.Rows[l]["GS53"].ToString( ) ) && Convert.ToDecimal( tableTre.Rows[l]["GS053"].ToString( ) ) > 0 && Convert.ToDecimal( tableTre.Rows[l]["GS53"].ToString( ) ) != Convert.ToDecimal( tableTre.Rows[l]["GS053"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs052 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs052 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs052 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs052 ,gs56 ,gs57 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs52 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs52 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs52 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS53='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS053"].ToString( ) ,gs52 ,gs56 ,gs57 );
                            }
                        }
                            
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTre.Rows[l]["GS054"].ToString( ) ) && !string.IsNullOrEmpty( tableTre.Rows[l]["GS54"].ToString( ) ) && Convert.ToDecimal( tableTre.Rows[l]["GS054"].ToString( ) ) > 0 && Convert.ToDecimal( tableTre.Rows[l]["GS54"].ToString( ) ) != Convert.ToDecimal( tableTre.Rows[l]["GS054"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs052 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs052 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs052 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs052 ,gs56 ,gs57 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs52 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs52 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs52 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS54='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS054"].ToString( ) ,gs52 ,gs56 ,gs57 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTre.Rows[l]["GS059"].ToString( ) ) && !string.IsNullOrEmpty( tableTre.Rows[l]["GS59"].ToString( ) ) && Convert.ToDecimal( tableTre.Rows[l]["GS059"].ToString( ) ) > 0 && Convert.ToDecimal( tableTre.Rows[l]["GS59"].ToString( ) ) != Convert.ToDecimal( tableTre.Rows[l]["GS059"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs052 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs052 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs052 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs052 ,gs56 ,gs57 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs52 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs52 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs52 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS59='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS059"].ToString( ) ,gs52 ,gs56 ,gs57 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTre.Rows[l]["GS060"].ToString( ) ) && !string.IsNullOrEmpty( tableTre.Rows[l]["GS60"].ToString( ) ) && Convert.ToDecimal( tableTre.Rows[l]["GS060"].ToString( ) ) > 0 && Convert.ToDecimal( tableTre.Rows[l]["GS60"].ToString( ) ) != Convert.ToDecimal( tableTre.Rows[l]["GS060"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs052 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs052 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs052 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs052 ,gs56 ,gs57 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs52 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs52 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs52 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS60='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS060"].ToString( ) ,gs52 ,gs56 ,gs57 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                    if ( !string.IsNullOrEmpty( tableTre.Rows[l]["GS061"].ToString( ) ) && !string.IsNullOrEmpty( tableTre.Rows[l]["GS61"].ToString( ) ) && Convert.ToDecimal( tableTre.Rows[l]["GS061"].ToString( ) ) > 0 && Convert.ToDecimal( tableTre.Rows[l]["GS61"].ToString( ) ) != Convert.ToDecimal( tableTre.Rows[l]["GS061"].ToString( ) ) )
                    {
                        strSql = new StringBuilder( );
                        if ( !string.IsNullOrEmpty( gs052 ) && gs52 != gs052 )
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs052 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs052 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs052 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs052 ,gs56 ,gs57 );
                            }
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( gs056 ) && gs56 != gs056 )
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs52 ,gs056 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs52 ,gs056 ,gs57 );
                            }
                            else
                            {
                                if ( !string.IsNullOrEmpty( gs057 ) && gs57 != gs057 )
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs52 ,gs56 ,gs057 );
                                else
                                    strSql.AppendFormat( "UPDATE R_PQP SET GS61='{0}' WHERE GS01 IN (" + str + ") AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,tableTre.Rows[l]["GS061"].ToString( ) ,gs52 ,gs56 ,gs57 );
                            }
                        }
                        SQLString.Add( strSql.ToString( ) );
                    }
                }
            }
            #endregion

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="gs34"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string gs34,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQP WHERE GS34='{0}'" ,gs34 );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_509" ,"产品每套成本改善控制表(R_509)" ,logins ,DateTime . Now ,gs34 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02='产品每套成本改善控制表(R_509)') AND RES06='{0}'" ,gs34 );
            SQLString . Add ( Drity . DrityOfComparation ( "R_509" ,"产品每套成本改善控制表(R_509)" ,logins ,DateTime . Now ,gs34 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ChanPinGaiShanEntity _model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS01=@GS01,GS46=@GS46,GS47=@GS47,GS48=@GS48,GS49=@GS49,GS50=@GS50,GS03=@GS03,GS22=@GS22,GS23=@GS23,GS24=@GS24,GS25=@GS25,GS26=@GS26,GS27=@GS27,GS28=@GS28,GS29=@GS29,GS30=@GS30,GS31=@GS31,GS32=@GS32,GS33=@GS33 WHERE GS34=@GS34" );
            SqlParameter [ ] parameter = {
                new SqlParameter ( "@GS34" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS03" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS22" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS23" ,SqlDbType.Date ) ,
                new SqlParameter ( "@GS24" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS25" ,SqlDbType.Date  ) ,
                new SqlParameter ( "@GS26" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS27" ,SqlDbType.Date ) ,
                new SqlParameter ( "@GS28" ,SqlDbType.NVarChar) ,
                new SqlParameter ( "@GS29" ,SqlDbType.Date) ,
                new SqlParameter ( "@GS30" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS31" ,SqlDbType.Int) ,
                new SqlParameter ( "@GS32" ,SqlDbType.NVarChar) ,
                new SqlParameter ( "@GS33" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS46" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS47" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS48" ,SqlDbType.NVarChar) ,
                new SqlParameter ( "@GS49" ,SqlDbType.BigInt) ,
                new SqlParameter ( "@GS50" ,SqlDbType.NVarChar ) ,
                new SqlParameter ( "@GS01" ,SqlDbType.NVarChar )
            };
            parameter [ 0 ] . Value = _model . GS34;
            parameter [ 1 ] . Value = _model . GS03;
            parameter [ 2 ] . Value = _model . GS22;
            parameter [ 3 ] . Value = _model . GS23;
            parameter [ 4 ] . Value = _model . GS24;
            parameter [ 5 ] . Value = _model . GS25;
            parameter [ 6 ] . Value = _model . GS26;
            parameter [ 7 ] . Value = _model . GS27;
            parameter [ 8 ] . Value = _model . GS28;
            parameter [ 9 ] . Value = _model . GS29;
            parameter [ 10 ] . Value = _model . GS30;
            parameter [ 11 ] . Value = _model . GS31;
            parameter [ 12 ] . Value = _model . GS32;
            parameter [ 13 ] . Value = _model . GS33;
            parameter [ 14 ] . Value = _model . GS46;
            parameter [ 15 ] . Value = _model . GS47;
            parameter [ 16 ] . Value = _model . GS48;
            parameter [ 17 ] . Value = _model . GS49;
            parameter [ 18 ] . Value = _model . GS50;
            parameter [ 19 ] . Value = _model . GS01;
            SQLString . Add ( strSql . ToString ( ) ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (GS01,GS03,GS22,GS23,GS24,GS25,GS26,GS27,GS28,GS29,GS30,GS31,GS32,GS33,GS34,GS46,GS47,GS48,GS49,GS50) VALUES (@GS01,@GS03,@GS22,@GS23,@GS24,@GS25,@GS26,@GS27,@GS28,@GS29,@GS30,@GS31,@GS32,@GS33,@GS34,@GS46,@GS47,@GS48,@GS49,@GS50)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@GS01", SqlDbType.NVarChar,100),
                    new SqlParameter("@GS03", SqlDbType.VarChar,4),
                    new SqlParameter("@GS22", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS23", SqlDbType.Date,3),
                    new SqlParameter("@GS24", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS25", SqlDbType.Date,3),
                    new SqlParameter("@GS26", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS27", SqlDbType.Date,3),
                    new SqlParameter("@GS28", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS29", SqlDbType.Date,3),
                    new SqlParameter("@GS30", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS31", SqlDbType.Int,4),
                    new SqlParameter("@GS32", SqlDbType.NVarChar,255),
                    new SqlParameter("@GS33", SqlDbType.NVarChar,-1),
                    new SqlParameter("@GS34", SqlDbType.NVarChar,20),
                    new SqlParameter("@GS46", SqlDbType.NVarChar,100),
                    new SqlParameter("@GS47", SqlDbType.NVarChar,100),
                    new SqlParameter("@GS48", SqlDbType.NVarChar,100),
                    new SqlParameter("@GS49", SqlDbType.BigInt,8),
                    new SqlParameter("@GS50", SqlDbType.NVarChar,100)
                };
            parameters [ 0 ] . Value = model . GS01;
            parameters [ 1 ] . Value = model . GS03;
            parameters [ 2 ] . Value = model . GS22;
            parameters [ 3 ] . Value = model . GS23;
            parameters [ 4 ] . Value = model . GS24;
            parameters [ 5 ] . Value = model . GS25;
            parameters [ 6 ] . Value = model . GS26;
            parameters [ 7 ] . Value = model . GS27;
            parameters [ 8 ] . Value = model . GS28;
            parameters [ 9 ] . Value = model . GS29;
            parameters [ 10 ] . Value = model . GS30;
            parameters [ 11 ] . Value = model . GS31;
            parameters [ 12 ] . Value = model . GS32;
            parameters [ 13 ] . Value = model . GS33;
            parameters [ 14 ] . Value = model . GS34;
            parameters [ 15 ] . Value = model . GS46;
            parameters [ 16 ] . Value = model . GS47;
            parameters [ 17 ] . Value = model . GS48;
            parameters [ 18 ] . Value = model . GS49;
            parameters [ 19 ] . Value = model . GS50;
            SQLString . Add ( strSql ,parameters );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 复制保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (GS34,GS46,GS47,GS48,GS49,GS02,GS03,GS04,GS05,GS06,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,GS22,GS23,GS24,GS25,GS26,GS28,GS29,GS32,GS33,GS35,GS36,GS37,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS51,GS52,GS53,GS54,GS56,GS57,GS58,GS59,GS60,GS61,GS62,GS63,GS64,GS65,GS66,GS67,GS68,GS69,GS70,GS71) VALUES (@GS34,@GS46,@GS47,@GS48,@GS49,@GS02,@GS03,@GS04,@GS05,@GS06,@GS07,@GS08,@GS09,@GS10,@GS11,@GS13,@GS14,@GS15,@GS16,@GS17,@GS18,@GS19,@GS20,@GS22,@GS23,@GS24,@GS25,@GS26,@GS28,@GS29,@GS32,@GS33,@GS35,@GS36,@GS37,@GS39,@GS40,@GS41,@GS42,@GS43,@GS44,@GS45,@GS51,@GS52,@GS53,@GS54,@GS56,@GS57,@GS58,@GS59,@GS60,@GS61,@GS62,@GS63,@GS64,@GS65,@GS66,@GS67,@GS68,@GS69,@GS70,@GS71)" );
            SqlParameter [ ] parameter = {
                new SqlParameter( "@GS34" ,model.GS34 ),
                new SqlParameter( "@GS46" ,model.GS46 ) ,
                new SqlParameter( "@GS47" ,model.GS47 ) ,
                new SqlParameter( "@GS48" ,model.GS48 ) ,
                new SqlParameter( "@GS49" ,model.GS49 ) ,
                new SqlParameter( "@GS02" ,model.GS02 ) ,
                new SqlParameter( "@GS03" ,model.GS03 ) ,
                new SqlParameter( "@GS04" ,model.GS04 ) ,
                new SqlParameter( "@GS05" ,model.GS05 ) ,
                new SqlParameter( "@GS06" ,model.GS06 ) ,
                new SqlParameter( "@GS07" ,model.GS07 ) ,
                new SqlParameter( "@GS08" ,model.GS08 ) ,
                new SqlParameter( "@GS09" ,model.GS09 ) ,
                new SqlParameter( "@GS10" ,model.GS10 ) ,
                new SqlParameter( "@GS11" ,model.GS11 ) ,
                new SqlParameter( "@GS13" ,model.GS13 ) ,
                new SqlParameter( "@GS14" ,model.GS14 ) ,
                new SqlParameter( "@GS15" ,model.GS15 ) ,
                new SqlParameter( "@GS16" ,model.GS16 ) ,
                new SqlParameter( "@GS17" ,model.GS17 ) ,
                new SqlParameter( "@GS18" ,model.GS18 ) ,
                new SqlParameter( "@GS19" ,model.GS19 ) ,
                new SqlParameter( "@GS20" ,model.GS20 ) ,
                new SqlParameter( "@GS22" ,model.GS22 ) ,
                new SqlParameter( "@GS23" ,model.GS23 ) ,
                new SqlParameter( "@GS24" ,model.GS24 ) ,
                new SqlParameter( "@GS25" ,model.GS25 ) ,
                new SqlParameter( "@GS26" ,model.GS26 ) ,
                new SqlParameter( "@GS28" ,model.GS28 ) ,
                new SqlParameter( "@GS29" ,model.GS29 ) ,
                new SqlParameter( "@GS32" ,model.GS32 ) ,
                new SqlParameter( "@GS33" ,model.GS33 ) ,
                new SqlParameter( "@GS35" ,model.GS35 ) ,
                new SqlParameter( "@GS36" ,model.GS36 ) ,
                new SqlParameter( "@GS37" ,model.GS37 ) ,
                new SqlParameter( "@GS39" ,model.GS39 ) ,
                new SqlParameter( "@GS40" ,model.GS40 ) ,
                new SqlParameter( "@GS41" ,model.GS41 ) ,
                new SqlParameter( "@GS42" ,model.GS42 ) ,
                new SqlParameter( "@GS43" ,model.GS43 ) ,
                new SqlParameter( "@GS44" ,model.GS44 ) ,
                new SqlParameter( "@GS45" ,model.GS45 ) ,
                new SqlParameter( "@GS51" ,model.GS51 ) ,
                new SqlParameter( "@GS52" ,model.GS52 ) ,
                new SqlParameter( "@GS53" ,model.GS53 ) ,
                new SqlParameter( "@GS54" ,model.GS54 ) ,
                new SqlParameter( "@GS56" ,model.GS56 ) ,
                new SqlParameter( "@GS57" ,model.GS57 ) ,
                new SqlParameter( "@GS58" ,model.GS58 ) ,
                new SqlParameter( "@GS59" ,model.GS59 ) ,
                new SqlParameter( "@GS60" ,model.GS60 ) ,
                new SqlParameter( "@GS61" ,model.GS61 ) ,
                new SqlParameter( "@GS62" ,model.GS62 ) ,
                new SqlParameter( "@GS63" ,model.GS63 ) ,
                new SqlParameter( "@GS64" ,model.GS64 ) ,
                new SqlParameter( "@GS65" ,model.GS65 ) ,
                new SqlParameter( "@GS66" ,model.GS66 ) ,
                new SqlParameter( "@GS67" ,model.GS67 ) ,
                new SqlParameter( "@GS68" ,model.GS68 ) ,
                new SqlParameter( "@GS69" ,model.GS69 ) ,
                new SqlParameter ( "@GS70" ,model.GS70 ) ,
                new SqlParameter ( "@GS71" ,model.GS71 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQP WHERE GS34='{0}' AND GS02='{1}' AND GS07='{2}' AND GS20='{3}' AND GS08='{4}' AND GS71='{5}'" ,model . GS34 ,model . GS02 ,model . GS07 ,model . GS20 ,model . GS08 ,model . GS71 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (GS34,GS02,GS04,GS05,GS07,GS08,GS09,GS10,GS11,GS13,GS14,GS15,GS16,GS17,GS18,GS19,GS20,GS49,GS51,GS70,GS71,GS78) VALUES (@GS34,@GS02,@GS04,@GS05,@GS07,@GS08,@GS09,@GS10,@GS11,@GS13,@GS14,@GS15,@GS16,@GS17,@GS18,@GS19,@GS20,@GS49,@GS51,@GS70,@GS71,@GS78)" );
            SqlParameter [ ] parameter = {
                new SqlParameter ( "@GS34" ,model.GS34 ) ,
                new SqlParameter ( "@GS02" ,model.GS02 ) ,
                new SqlParameter ( "@GS04" ,model.GS04 ) ,
                new SqlParameter ( "@GS05" ,model.GS05 ) ,
                new SqlParameter ( "@GS07" ,model.GS07 ) ,
                new SqlParameter ( "@GS08" ,model.GS08 ) ,
                new SqlParameter ( "@GS09" ,model.GS09 ) ,
                new SqlParameter ( "@GS10" ,model.GS10 ) ,
                new SqlParameter ( "@GS11" ,model.GS11 ) ,
                new SqlParameter ( "@GS13" ,model.GS13 ) ,
                new SqlParameter ( "@GS14" ,model.GS14 ) ,
                new SqlParameter ( "@GS15" ,model.GS15 ) ,
                new SqlParameter ( "@GS16" ,model.GS16 ) ,
                new SqlParameter ( "@GS17" ,model.GS17 ) ,
                new SqlParameter ( "@GS18" ,model.GS18 ) ,
                new SqlParameter ( "@GS19" ,model.GS19 ) ,
                new SqlParameter ( "@GS20" ,model.GS20 ) ,
                new SqlParameter ( "@GS49" ,model.GS49 ) ,
                new SqlParameter ( "@GS51" ,model.GS51 ) ,
                new SqlParameter ( "@GS70" ,model.GS70 ) ,
                new SqlParameter ( "@GS71" ,model.GS71 ),
                new SqlParameter ( "@GS78" ,model.GS78 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQP SET GS02=@GS2,GS04=@GS04,GS05=@GS05,GS07=@GS7,GS08=@GS08,GS09=@GS09,GS10=@GS10,GS11=@GS11,GS13=@GS13,GS14=@GS14,GS15=@GS15,GS16=@GS16,GS17=@GS17,GS18=@GS18,GS19=@GS19,GS20=@GS20,GS51=@GS51,GS70=@GS70,GS71=@GS71,GS78=@GS78 WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter ( "@GS02" ,model.GS02 ) ,
                new SqlParameter ( "@GS04" ,model.GS04 ) ,
                new SqlParameter ( "@GS05" ,model.GS05 ) ,
                new SqlParameter ( "@GS07" ,model.GS07 ) ,
                new SqlParameter ( "@GS08" ,model.GS08 ) ,
                new SqlParameter ( "@GS09" ,model.GS09 ) ,
                new SqlParameter ( "@GS10" ,model.GS10 ) ,
                new SqlParameter ( "@GS11" ,model.GS11 ) ,
                new SqlParameter ( "@GS13" ,model.GS13 ) ,
                new SqlParameter ( "@GS14" ,model.GS14 ) ,
                new SqlParameter ( "@GS15" ,model.GS15 ) ,
                new SqlParameter ( "@GS16" ,model.GS16 ) ,
                new SqlParameter ( "@GS17" ,model.GS17 ) ,
                new SqlParameter ( "@GS18" ,model.GS18 ) ,
                new SqlParameter ( "@GS19" ,model.GS19 ) ,
                new SqlParameter ( "@GS51" ,model.GS51 ) ,
                new SqlParameter ( "@idx" ,model.idx ) ,
                new SqlParameter ( "@GS2" ,model.GS02 ) ,
                new SqlParameter ( "@GS7" ,model.GS07 ) ,
                new SqlParameter ( "@GS20" ,model.GS20 ) ,
                new SqlParameter ( "@GS70" ,model.GS70 ) ,
                new SqlParameter ( "@GS71" ,model.GS71 ),
                new SqlParameter ( "@GS78" ,model.GS78 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQP WHERE idx={0}" ,model . idx );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQP WHERE GS34='{0}' AND GS35='{1}' AND GS75='{2}' AND GS76='{3}' " ,model . GS34 ,model . GS35 ,model . GS75 ,model . GS76 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (GS34,GS35,GS36,GS37,GS38,GS39,GS40,GS41,GS42,GS43,GS44,GS45,GS72,GS74,GS75,GS76) VALUES (@GS34,@GS35,@GS36,@GS37,@GS38,@GS39,@GS40,@GS41,@GS42,@GS43,@GS44,@GS45,@GS72,@GS74,@GS75,@GS76)" );
            SqlParameter [ ] parameter = {
                new SqlParameter( "@GS34" ,model.GS34 ) ,
                new SqlParameter( "@GS35" ,model.GS35 ) ,
                new SqlParameter( "@GS36" ,model.GS36 ) ,
                new SqlParameter( "@GS37" ,model.GS37 ) ,
                new SqlParameter( "@GS38" ,model.GS38 ) ,
                new SqlParameter( "@GS39" ,model.GS39 ) ,
                new SqlParameter( "@GS40" ,model.GS40 ) ,
                new SqlParameter( "@GS41" ,model.GS41 ) ,
                new SqlParameter( "@GS42" ,model.GS42 ) ,
                new SqlParameter( "@GS43" ,model.GS43 ) ,
                new SqlParameter( "@GS44" ,model.GS44 ) ,
                new SqlParameter( "@GS45" ,model.GS45 ),
                new SqlParameter( "@GS72" ,model.GS72 ),
                new SqlParameter( "@GS74" ,model.GS74 ),
                new SqlParameter( "@GS75" ,model.GS75 ),
                new SqlParameter( "@GS76" ,model.GS76 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQP SET GS35=@GS35,GS36=@GS36,GS37=@GS37,GS38=@GS38,GS39=@GS39,GS40=@GS40,GS41=@GS41,GS42=@GS42,GS43=@GS43,GS44=@GS44,GS45=@GS45,GS72=@GS72,GS74=@GS74,GS75=@GS75,GS76=@GS76 WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter( "@GS36" ,model.GS36 ) ,
                new SqlParameter( "@GS37" ,model.GS37 ) ,
                new SqlParameter( "@GS38" ,model.GS38 ) ,
                new SqlParameter( "@GS39" ,model.GS39 ) ,
                new SqlParameter( "@GS40" ,model.GS40 ) ,
                new SqlParameter( "@GS41" ,model.GS41 ) ,
                new SqlParameter( "@GS42" ,model.GS42 ) ,
                new SqlParameter( "@GS43" ,model.GS43 ) ,
                new SqlParameter( "@GS44" ,model.GS44 ) ,
                new SqlParameter( "@GS45" ,model.GS45 ) ,
                new SqlParameter ( "@idx" ,model.idx ) ,
                new SqlParameter ( "@GS35" ,model.GS35 ),
                new SqlParameter ( "@GS72" ,model.GS72 ),
                new SqlParameter ( "@GS74" ,model.GS74 ),
                new SqlParameter ( "@GS75" ,model.GS75 ),
                new SqlParameter ( "@GS76" ,model.GS76 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT * FROM R_PQP WHERE GS34='{0}' AND GS52='{1}' AND GS56='{2}' AND GS57='{3}' AND GS68='{4}'" ,model . GS34 ,model . GS52 ,model . GS56 ,model . GS57 ,model . GS68 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildTre ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (GS34,GS52,GS49,GS53,GS54,GS55,GS56,GS57,GS58,GS59,GS60,GS61,GS69,GS62,GS63,GS64,GS65,GS66,GS67,GS68,GS77) VALUES (@GS34,@GS52,@GS49,@GS53,@GS54,@GS55,@GS56,@GS57,@GS58,@GS59,@GS60,@GS61,@GS69,@GS62,@GS63,@GS64,@GS65,@GS66,@GS67,@GS68,@GS77)" );
            SqlParameter [ ] parameter = {
                new SqlParameter( "@GS34" ,model.GS34 ) ,
                new SqlParameter( "@GS52" ,model.GS52 ) ,
                new SqlParameter( "@GS53" ,model.GS53 ) ,
                new SqlParameter( "@GS54" ,model.GS54 ) ,
                new SqlParameter( "@GS55" ,model.GS55 ) ,
                new SqlParameter( "@GS56" ,model.GS56 ) ,
                new SqlParameter( "@GS57" ,model.GS57 ) ,
                new SqlParameter( "@GS58" ,model.GS58 ) ,
                new SqlParameter( "@GS59" ,model.GS59 ) ,
                new SqlParameter( "@GS60" ,model.GS60 ) ,
                new SqlParameter( "@GS61" ,model.GS61 ) ,
                new SqlParameter( "@GS69" ,model.GS69 ) ,
                new SqlParameter( "@GS62" ,model.GS62 ) ,
                new SqlParameter( "@GS63" ,model.GS63 ) ,
                new SqlParameter( "@GS64" ,model.GS64 ) ,
                new SqlParameter( "@GS65" ,model.GS65 ) ,
                new SqlParameter( "@GS66" ,model.GS66 ) ,
                new SqlParameter( "@GS67" ,model.GS67 ) ,
                new SqlParameter( "@GS68" ,model.GS68 ) ,
                new SqlParameter( "@GS49" ,model.GS49 ),
                new SqlParameter( "@GS77" ,model.GS77 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditTre ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQP SET GS52=@GS52,GS53=@GS53,GS54=@GS54,GS55=@GS55,GS56=@GS56,GS57=@GS57,GS58=@GS58,GS59=@GS59,GS60=@GS60,GS61=@GS61,GS68=@GS68,GS69=@GS69,GS62=@GS62,GS63=@GS63,GS64=@GS64,GS65=@GS65,GS66=@GS66,GS67=@GS67,GS77=@GS77 WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter ( "@GS53" ,model.GS53 ) ,
                new SqlParameter ( "@GS54" ,model.GS54 ) ,
                new SqlParameter ( "@GS55" ,model.GS55 ) ,
                new SqlParameter ( "@GS58" ,model.GS58 ) ,
                new SqlParameter ( "@GS59" ,model.GS59 ) ,
                new SqlParameter ( "@GS60" ,model.GS60 ) ,
                new SqlParameter ( "@GS61" ,model.GS61 ) ,
                new SqlParameter ( "@GS69" ,model.GS69 ) ,
                new SqlParameter ( "@GS62" ,model.GS62 ) ,
                new SqlParameter ( "@GS63" ,model.GS63 ) ,
                new SqlParameter ( "@GS64" ,model.GS64 ) ,
                new SqlParameter ( "@GS65" ,model.GS65 ) ,
                new SqlParameter ( "@GS66" ,model.GS66 ) ,
                new SqlParameter ( "@GS67" ,model.GS67 ) ,
                new SqlParameter ( "@idx" ,model.idx ) ,
                new SqlParameter ( "@GS52" ,model.GS52 ) ,
                new SqlParameter ( "@GS56" ,model.GS56 ) ,
                new SqlParameter ( "@GS68" ,model.GS68 ) ,
                new SqlParameter ( "@GS57" ,model.GS57 ),
                new SqlParameter ( "@GS77" ,model.GS77 )
            };
            SQLString . Add ( strSql ,parameter );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在流水
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsNum ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQP WHERE GS34!='{0}' AND GS01='{1}'" ,model . GS34 ,model . GS01 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }


        //批量新增
        public DataTable tableOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS71,GS70,GS02,GS04,GS05,GS07,GS08,GS10,GS11,GS51 FROM R_PQP WHERE 1=2" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable tableTwo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS35,GS36,GS37 FROM R_PQP WHERE 1=2" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        public DataTable tableTre ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GS52,GS53,GS54,GS56,GS57,GS59,GS60,GS61 FROM R_PQP WHERE 1=2" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="tableQueryTwo"></param>
        /// <param name="tableQueryTre"></param>
        /// <param name="tableQueryFor"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool BatchAdd ( DataTable tableQueryTwo ,DataTable tableQueryTre ,DataTable tableQueryFor ,List<string> idxList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            foreach ( string idx in idxList )
            {
                MulaolaoLibrary . ChanPinGaiShanEntity _model = new MulaolaoLibrary . ChanPinGaiShanEntity ( );
                _model . GS01 = idx;
                DataTable dt= getOddNum ( _model . GS01 );
                _model . GS34 = dt . Rows [ 0 ] [ "GS34" ] . ToString ( );
                if ( string . IsNullOrEmpty ( _model . GS34 ) )
                    return false;
                _model . GS03 = dt . Rows [ 0 ] [ "GS03" ] . ToString ( );
                _model . GS46 = dt . Rows [ 0 ] [ "GS46" ] . ToString ( );
                _model . GS47 = dt . Rows [ 0 ] [ "GS47" ] . ToString ( );
                _model . GS48 = dt . Rows [ 0 ] [ "GS48" ] . ToString ( );
                _model . GS49 = string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "GS49" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( dt . Rows [ 0 ] [ "GS49" ] . ToString ( ) );
                for ( int i = 0 ; i < tableQueryTwo . Rows . Count ; i++ )
                {
                    _model . GS71 = tableQueryTwo . Rows [ i ] [ "GS71" ] . ToString ( );
                    _model . GS70 = tableQueryTwo . Rows [ i ] [ "GS70" ] . ToString ( );
                    _model . GS02 = tableQueryTwo . Rows [ i ] [ "GS02" ] . ToString ( );
                    _model . GS04 = string . IsNullOrEmpty ( tableQueryTwo . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTwo . Rows [ i ] [ "GS04" ] . ToString ( ) );
                    _model . GS05 = string . IsNullOrEmpty ( tableQueryTwo . Rows [ i ] [ "GS05" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTwo . Rows [ i ] [ "GS05" ] . ToString ( ) );
                    _model . GS07 = tableQueryTwo . Rows [ i ] [ "GS07" ] . ToString ( );
                    _model . GS08 = tableQueryTwo . Rows [ i ] [ "GS08" ] . ToString ( );
                    _model . GS10 = string . IsNullOrEmpty ( tableQueryTwo . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTwo . Rows [ i ] [ "GS10" ] . ToString ( ) );
                    _model . GS11 = string . IsNullOrEmpty ( tableQueryTwo . Rows [ i ] [ "GS11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTwo . Rows [ i ] [ "GS11" ] . ToString ( ) );
                    _model . GS51 = string . IsNullOrEmpty ( tableQueryTwo . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTwo . Rows [ i ] [ "GS51" ] . ToString ( ) );
                    if ( ExistsOneAdd ( _model ) == false )
                        Add ( SQLString ,strSql ,_model );
                }
                for ( int i = 0 ; i < tableQueryTre . Rows . Count ; i++ )
                {
                    _model . GS35 = tableQueryTre . Rows [ i ] [ "GS35" ] . ToString ( );
                    _model . GS36 = string . IsNullOrEmpty ( tableQueryTre . Rows [ i ] [ "GS36" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTre . Rows [ i ] [ "GS36" ] . ToString ( ) );
                    _model . GS37 = string . IsNullOrEmpty ( tableQueryTre . Rows [ i ] [ "GS37" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryTre . Rows [ i ] [ "GS37" ] . ToString ( ) );
                    if ( ExistsTwoAdd ( _model ) == false )
                        AddOne ( SQLString ,strSql ,_model );
                }
                for ( int i = 0 ; i < tableQueryFor . Rows . Count ; i++ )
                {
                    _model . GS52 = tableQueryFor . Rows [ i ] [ "GS52" ] . ToString ( );
                    _model . GS53 = string . IsNullOrEmpty ( tableQueryFor . Rows [ i ] [ "GS53" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryFor . Rows [ i ] [ "GS53" ] . ToString ( ) );
                    _model . GS54 = string . IsNullOrEmpty ( tableQueryFor . Rows [ i ] [ "GS54" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryFor . Rows [ i ] [ "GS54" ] . ToString ( ) );
                    _model . GS56 = tableQueryFor . Rows [ i ] [ "GS56" ] . ToString ( );
                    _model . GS57 = tableQueryFor . Rows [ i ] [ "GS57" ] . ToString ( );
                    _model . GS59 = string . IsNullOrEmpty ( tableQueryFor . Rows [ i ] [ "GS59" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableQueryFor . Rows [ i ] [ "GS59" ] . ToString ( ) );
                    _model . GS60 = string . IsNullOrEmpty ( tableQueryFor . Rows [ i ] [ "GS60" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryFor . Rows [ i ] [ "GS60" ] . ToString ( ) );
                    _model . GS61 = string . IsNullOrEmpty ( tableQueryFor . Rows [ i ] [ "GS61" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQueryFor . Rows [ i ] [ "GS61" ] . ToString ( ) );

                    if ( ExistsTreAdd ( _model ) == false )
                        AddTwo ( SQLString ,strSql ,_model );
                }

            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        DataTable  getOddNum ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GS34,GS46,GS47,GS48,GS49,GS03 FROM R_PQP WHERE GS01='{0}'" ,num );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            return dt;
        }

        bool ExistsOneAdd ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQP WHERE GS34='{0}' AND GS02='{1}' AND GS07='{2}'" ,model . GS34 ,model . GS02 ,model . GS07  );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void Add ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (" );
            strSql . Append ( "GS01,GS02,GS04,GS05,GS07,GS08,GS10,GS11,GS34,GS51,GS70,GS71,GS03,GS46,GS47,GS48,GS49) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@GS01,@GS02,@GS04,@GS05,@GS07,@GS08,@GS10,@GS11,@GS34,@GS51,@GS70,@GS71,@GS03,@GS46,@GS47,@GS48,@GS49) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS01", SqlDbType.NVarChar,100),
                new SqlParameter("@GS02", SqlDbType.NVarChar,20),
                new SqlParameter("@GS04", SqlDbType.Decimal,9),
                new SqlParameter("@GS05", SqlDbType.Decimal,5),
                new SqlParameter("@GS07", SqlDbType.NVarChar,20),
                new SqlParameter("@GS08", SqlDbType.NVarChar,20),
                new SqlParameter("@GS10", SqlDbType.Decimal,5),
                new SqlParameter("@GS11", SqlDbType.Decimal,9),
                new SqlParameter("@GS34", SqlDbType.NVarChar,20),
                new SqlParameter("@GS51", SqlDbType.Decimal,9),
                new SqlParameter("@GS70", SqlDbType.NVarChar,50),
                new SqlParameter("@GS71", SqlDbType.NVarChar,50),
                new SqlParameter("@GS03", SqlDbType.VarChar,4),
                new SqlParameter("@GS46", SqlDbType.NVarChar,100),
                new SqlParameter("@GS47", SqlDbType.NVarChar,100),
                new SqlParameter("@GS48", SqlDbType.NVarChar,100),
                new SqlParameter("@GS49", SqlDbType.BigInt,8)
            };
            parameter [ 0 ] . Value = model . GS01;
            parameter [ 1 ] . Value = model . GS02;
            parameter [ 2 ] . Value = model . GS04;
            parameter [ 3 ] . Value = model . GS05;
            parameter [ 4 ] . Value = model . GS07;
            parameter [ 5 ] . Value = model . GS08;
            parameter [ 6 ] . Value = model . GS10;
            parameter [ 7 ] . Value = model . GS11;
            parameter [ 8 ] . Value = model . GS34;
            parameter [ 9 ] . Value = model . GS51;
            parameter [ 10 ] . Value = model . GS70;
            parameter [ 11 ] . Value = model . GS71;
            parameter [ 12 ] . Value = model . GS03;
            parameter [ 13 ] . Value = model . GS46;
            parameter [ 14 ] . Value = model . GS47;
            parameter [ 15 ] . Value = model . GS48;
            parameter [ 16 ] . Value = model . GS49;
            SQLString . Add ( strSql ,parameter );
        }

        bool ExistsTwoAdd ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQP WHERE GS34='{0}' AND GS02='{1}' AND GS35='{2}'" ,model . GS34 ,model . GS02 ,model . GS35 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void AddOne ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (" );
            strSql . Append ( "GS01,GS34,GS35,GS36,GS37,GS03,GS46,GS47,GS48,GS49) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@GS01,@GS34,@GS35,@GS36,@GS37,@GS03,@GS46,@GS47,@GS48,@GS49) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS01", SqlDbType.NVarChar,100),
                new SqlParameter("@GS34", SqlDbType.NVarChar,20),
                new SqlParameter("@GS35", SqlDbType.NVarChar,20),
                new SqlParameter("@GS36", SqlDbType.Decimal,5),
                new SqlParameter("@GS37", SqlDbType.Decimal,5),
                new SqlParameter("@GS03", SqlDbType.VarChar,4),
                new SqlParameter("@GS46", SqlDbType.NVarChar,100),
                new SqlParameter("@GS47", SqlDbType.NVarChar,100),
                new SqlParameter("@GS48", SqlDbType.NVarChar,100),
                new SqlParameter("@GS49", SqlDbType.BigInt,8)
            };
            parameter [ 0 ] . Value = model . GS01;
            parameter [ 1 ] . Value = model . GS34;
            parameter [ 2 ] . Value = model . GS35;
            parameter [ 3 ] . Value = model . GS36;
            parameter [ 4 ] . Value = model . GS37;
            parameter [ 5 ] . Value = model . GS03;
            parameter [ 6 ] . Value = model . GS46;
            parameter [ 7 ] . Value = model . GS47;
            parameter [ 8 ] . Value = model . GS48;
            parameter [ 9 ] . Value = model . GS49;
            SQLString . Add ( strSql ,parameter );
        }

        bool ExistsTreAdd (MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQP WHERE GS34='{0}' AND GS52='{1}' AND GS56='{2}' AND GS57='{3}'" ,model . GS34 ,model . GS52 ,model . GS56 ,model . GS57 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void AddTwo ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQP (" );
            strSql . Append ( "GS01,GS34,GS52,GS53,GS54,GS56,GS57,GS59,GS60,GS61,GS03,GS46,GS47,GS48,GS49) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@GS01,@GS34,@GS52,@GS53,@GS54,@GS56,@GS57,@GS59,@GS60,@GS61,@GS03,@GS46,@GS47,@GS48,@GS49) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@GS01", SqlDbType.NVarChar,100),
                new SqlParameter("@GS34", SqlDbType.NVarChar,20),
                new SqlParameter("@GS52", SqlDbType.NVarChar,20),
                new SqlParameter("@GS53", SqlDbType.Decimal,5),
                new SqlParameter("@GS54", SqlDbType.Decimal,5),
                new SqlParameter("@GS56", SqlDbType.NVarChar,20),
                new SqlParameter("@GS57", SqlDbType.NVarChar,20),
                new SqlParameter("@GS59", SqlDbType.Int,4),
                new SqlParameter("@GS60", SqlDbType.Decimal,9),
                new SqlParameter("@GS61", SqlDbType.Decimal,5),
                new SqlParameter("@GS03", SqlDbType.VarChar,4),
                new SqlParameter("@GS46", SqlDbType.NVarChar,100),
                new SqlParameter("@GS47", SqlDbType.NVarChar,100),
                new SqlParameter("@GS48", SqlDbType.NVarChar,100),
                new SqlParameter("@GS49", SqlDbType.BigInt,8)
            };
            parameter [ 0 ] . Value = model . GS01;
            parameter [ 1 ] . Value = model . GS34;
            parameter [ 2 ] . Value = model . GS52;
            parameter [ 3 ] . Value = model . GS53;
            parameter [ 4 ] . Value = model . GS54;
            parameter [ 5 ] . Value = model . GS56;
            parameter [ 6 ] . Value = model . GS57;
            parameter [ 7 ] . Value = model . GS59;
            parameter [ 8 ] . Value = model . GS60;
            parameter [ 9 ] . Value = model . GS61;
            parameter [ 10 ] . Value = model . GS03;
            parameter [ 11 ] . Value = model . GS46;
            parameter [ 12 ] . Value = model . GS47;
            parameter [ 13 ] . Value = model . GS48;
            parameter [ 14 ] . Value = model . GS49;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT GS34,GS01,GS47,GS48,GS46,GS49,GS03,GS50 FROM R_PQP WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY T.GS34 DESC)AS Row,* FROM (SELECT DISTINCT GS34,GS01,GS47,GS48,GS46,GS49,GS03,GS50,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=GS34)) RES05 FROM R_PQP WHERE {0}) T) TT WHERE TT.Row BETWEEN {1} AND {2} ORDER BY GS01 DESC" ,strWhere ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public DataTable getOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GS34,GS01,GS47,GS48 FROM R_PQP " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
