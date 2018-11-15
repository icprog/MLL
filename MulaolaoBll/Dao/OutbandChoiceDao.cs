using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentMgr;

namespace MulaolaoBll.Dao
{
    public class OutbandChoiceDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="number"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public DataTable GetDataTable (string number, DataTable table )
        {
            string str = "", strValue = "";
            if ( table != null )
            {
                for ( int i = 0 ; i < table.Rows.Count ; i++ )
                {
                    if ( str == "" )
                        str = "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    else
                        str = str + "," + "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    if ( strValue == "" )
                        strValue = "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                    else
                        strValue = strValue + "," + "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                }
            }
            StringBuilder strSql = new StringBuilder( );
            // HAVING AC10-SUM(ISNULL(AD12,0))>0
            strSql.AppendFormat( "SELECT AC18,AC02,AC04,AC05,CAST(AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) AS INT) ONE,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) TWO,'' TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC05 IN (" + str + ") AND AC04 IN (" + strValue + ") GROUP BY AC18,AC02,AC04,AC05,AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0) ORDER BY AC02,AC05" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取341入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWood ( DataTable table )
        {
            string str = "", strValue = "";
            if ( table != null )
            {
                for ( int i = 0 ; i < table.Rows.Count ; i++ )
                {
                    if ( str == "" )
                        str = "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    else
                        str = str + "," + "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    if ( strValue == "" )
                        strValue = "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                    else
                        strValue = strValue + "," + "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                }
            }
            StringBuilder strSql = new StringBuilder( );
            //HAVING AC10-SUM(ISNULL(AD12,0))>0
            strSql.AppendFormat( "SELECT AC18,AC02,AC04,AC05,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) TWO,'' TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC05 IN (" + str + ") AND AC04 IN (" + strValue + ") GROUP BY AC18,AC02,AC04,AC05,AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0)  ORDER BY AC02,AC05,ISNULL(AC27,0),ISNULL(AC26,0)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取342入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCheMuJian ( DataTable table,string number )
        {
            string str = "", strValue = "";
            if ( table != null )
            {
                for ( int i = 0 ; i < table.Rows.Count ; i++ )
                {
                    if ( str == "" )
                        str = "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    else
                        str = str + "," + "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    if ( strValue == "" )
                        strValue = "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                    else
                        strValue = strValue + "," + "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                }
            }
            StringBuilder strSql = new StringBuilder( );
            //HAVING AC10-SUM(ISNULL(AD12,0))>0
            strSql.AppendFormat( "SELECT AC18,AC02,AC04,AC05,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) TWO,'' TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC05 IN (" + str + ") AND AC04 IN (" + strValue + ") GROUP BY AC18,AC02,AC04,AC05,AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0)  ORDER BY AC02,AC05" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取343入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfHardWare ( DataTable table ,string number )
        {
            string str = "", strValue = "";
            if ( table != null )
            {
                for ( int i = 0 ; i < table.Rows.Count ; i++ )
                {
                    if ( str == "" )
                        str = "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    else
                        str = str + "," + "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    if ( strValue == "" )
                        strValue = "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                    else
                        strValue = strValue + "," + "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                }
            }
            StringBuilder strSql = new StringBuilder( );
            //HAVING AC10-SUM(ISNULL(AD12,0))>0
            strSql.AppendFormat( "SELECT AC18,AC02,AC04,AC05,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) TWO,'' TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC05 IN (" + str + ") AND AC04 IN (" + strValue + ") GROUP BY AC18,AC02,AC04,AC05,AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0)  ORDER BY AC02,AC05" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取347入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAccess ( DataTable table ,string number )
        {
            string str = "", strValue = "";
            if ( table != null )
            {
                for ( int i = 0 ; i < table.Rows.Count ; i++ )
                {
                    if ( str == "" )
                        str = "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    else
                        str = str + "," + "'" + table.Rows[i]["tOne"].ToString( ) + "'";
                    if ( strValue == "" )
                        strValue = "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                    else
                        strValue = strValue + "," + "'" + table.Rows[i]["tTwo"].ToString( ) + "'";
                }
            }
            StringBuilder strSql = new StringBuilder( );
            //HAVING AC10-SUM(ISNULL(AD12,0))>0
            strSql.AppendFormat( "SELECT AC18,AC02,AC04,AC05,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,AC03+ISNULL(AC26,0)-SUM(ISNULL(AD05,0)+ISNULL(AD20,0)) TWO,'' TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC05 IN (" + str + ") AND AC04 IN (" + strValue + ") GROUP BY AC18,AC02,AC04,AC05,AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0) ORDER BY AC02,AC05" );
            SqlParameter[] parameter = {
                new SqlParameter("@AC02",SqlDbType.NVarChar)
            };
            parameter[0].Value = number;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取337入库记录
        /// </summary>
        /// <param name="dicStr"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunQi ( DataTable table ,string number ,string oddNum )
        {
            //string str = "", strValue = "", strValues = "";
            //if ( table != null )
            //{
            //    for ( int i = 0 ; i < table . Rows . Count ; i++ )
            //    {
            //        if ( str == "" )
            //            str = "'" + table . Rows [ i ] [ "tOne" ] . ToString ( ) + "'";
            //        else if ( !str . Contains ( table . Rows [ i ] [ "tOne" ] . ToString ( ) ) )
            //            str = str + "," + "'" + table . Rows [ i ] [ "tOne" ] . ToString ( ) + "'";
            //        if ( strValue == "" )
            //            strValue = "'" + table . Rows [ i ] [ "tTwo" ] . ToString ( ) + "'";
            //        else if ( !strValue . Contains ( table . Rows [ i ] [ "tTwo" ] . ToString ( ) ) )
            //            strValue = strValue + "," + "'" + table . Rows [ i ] [ "tTwo" ] . ToString ( ) + "'";
            //        if ( strValues == "" )
            //            strValues = "'" + table . Rows [ i ] [ "tTre" ] . ToString ( ) + "'";
            //        else if ( !strValues . Contains ( table . Rows [ i ] [ "tTre" ] . ToString ( ) ) )
            //            strValues = strValues + "," + "'" + table . Rows [ i ] [ "tTre" ] . ToString ( ) + "'";
            //    }
            //}
            StringBuilder strSql = new StringBuilder( );
            //HAVING AC10-SUM(ISNULL(AD12,0))>0  AND AC04 IN (" + strValue + ")  AND AC05 IN (" + strValues + ")   AND AC06 IN (" + str + ")
            //,AC03-SUM(ISNULL(AD05,0)) TWO  
            strSql . Append ( "SELECT AC18,AC05,AC02,AC04,AC06,ONE,SUM(TRE) TRE,SUM(FORE) FORE,SUM(FIV) FIV FROM (" );
            strSql . AppendFormat ( "SELECT AC18,AC05,AC02,AC04,AC06,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,0 TRE,0.0000 FORE,0.0000 FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02='滚漆' GROUP BY AC18,AC02,AC05,AC04,AC06,AC10,AC03,ISNULL(AC27,0) HAVING AC10-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))>0 " );//
            strSql . AppendFormat ( " UNION " );
            strSql . AppendFormat ( "SELECT AC18,AC05,AC02,AC04,AC06,AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) ONE,SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) TRE,SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) FORE,SUM(ISNULL(AD12,0)+ISNULL(AD21,0)) FIV FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02='滚漆' AND AD17='{0}' GROUP BY AC18,AC02,AC05,AC04,AC06,AC10,AC03,ISNULL(AC27,0) ) A GROUP BY AC18,AC05,AC02,AC04,AC06,ONE ORDER BY AC18" ,oddNum );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取338记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfContrast ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM09,JM15,CONVERT(NVARCHAR(20),JM94)+'*'+CONVERT(NVARCHAR(20),JM95)+'*'+CONVERT(NVARCHAR(20),JM96) JM,JM102 FROM R_PQO " );
            strSql.Append( " WHERE JM01=@JM01" );
            SqlParameter[] parameter = {
                new SqlParameter("@JM01",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取341记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuCai ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQV86,PQV67,SUM(PQV64) PQV64 FROM R_PQV" );
            strSql.Append( " WHERE PQV76=@PQV76 GROUP BY PQV86,PQV67" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQV76",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取342记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfChe ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AF004,CONVERT(NVARCHAR(20),AF020)+'*'+CONVERT(NVARCHAR(20),AF021)+'*'+CONVERT(NVARCHAR(20),AF022) AF,AF015,AF018 FROM R_PQAF" );
            strSql.Append( " WHERE AF001=@AF001" );
            SqlParameter[] parameter = {
                new SqlParameter("@AF001",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取343记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfHardware ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQU12,PQU10,PQU18,PQU100 FROM R_PQU" );
            strSql.Append( " WHERE PQU97=@PQU97" );
            SqlParameter[] parameter = {
                new SqlParameter("@PQU97",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取347记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPlastic ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PJ89,PJ09,PJ14,PJ95 FROM R_PQS" );
            strSql.Append( " WHERE PJ92=@PJ92" );
            SqlParameter[] parameter = {
                new SqlParameter("@PJ92",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AD01,AD03,AD06,AD07,CAST(AD12 AS INT) AD12 FROM R_PQAD " );
            strSql.Append( " WHERE AD17=@AD17" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD17",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMuCaiAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AD01,AD06,AD07,SUM(AD12) AD12 FROM R_PQAD" );
            strSql.Append( " WHERE AD17=@AD17" );
            strSql.Append( " GROUP BY AD01,AD06,AD07" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD17",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGunQiAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AD01,AD06,AD07,AD08,SUM(AD12) AD12 FROM R_PQAD" );
            strSql.Append( " WHERE AD17=@AD17" );
            strSql.Append( " GROUP BY AD01,AD06,AD07,AD08" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD17",SqlDbType.NVarChar)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}
