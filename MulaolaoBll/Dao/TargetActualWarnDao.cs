using System;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Text;
using StudentMgr;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class TargetActualWarnDao
    {
        /// <summary>
        /// 获取组长  ERP发货款
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( int year)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CFT AS(" );
            strSql.Append( "SELECT DISTINCT AE02,AE08,AE19,MONTH(AE17) AE17,YEAR(AE17) AE1 FROM R_PQAE)" );
            strSql.Append( "SELECT AE08,SUM(AE19) AE19,AE17,AE1 FROM CFT" );
            strSql.Append( " WHERE AE1=@AE1 AND AE08 IN " );
            strSql.Append( "(SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,AE17,AE1 " );
            SqlParameter[] parmaeter = {
                new SqlParameter("@AE1",SqlDbType.Int)
            };
            parmaeter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parmaeter ); 
        }

        /// <summary>
        /// 获取组长  实际发货
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableProductAc ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AE08,YEAR(AE21) AE2,MONTH(AE21) AE21," );
            //strSql.Append( "CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE FROM R_PQAE WHERE YEAR(AE21)=@AE2 " );
            strSql . Append ( "CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE FROM R_PQAE WHERE YEAR(AE21)=@AE2 " );
            strSql .Append( "AND AE08 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN " );
            strSql.Append( "(SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A " );
            strSql.Append( "LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,MONTH(AE21),YEAR(AE21) " );
            SqlParameter[] parmaeter = {
                new SqlParameter("@AE2",SqlDbType.Int)
            };
            parmaeter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parmaeter );
        }

        /// <summary>
        /// 获取业务员 ERP
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableSaleMan ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CFT AS(" );
            strSql.Append( " SELECT DISTINCT AE02,AE09,AE19,MONTH(AE17) AE17,YEAR(AE17) AE1 FROM R_PQAE" );
            strSql.Append( " )" );
            strSql.Append( " SELECT AE09,SUM(AE19) AE19,AE17,AE1 FROM CFT" );
            strSql.Append( " WHERE AE1=@AE1" );
            strSql.Append( " GROUP BY AE09,AE17,AE1" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE1",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取业务员  实际
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableSaleManAc ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT AE09,MONTH(AE21) AE21,YEAR(AE21) AE2,CONVERT(DECIMAL(18,2),ISNULL(SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END),0)) AE " );
            strSql . Append ( "SELECT AE09,MONTH(AE21) AE21,YEAR(AE21) AE2,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE " );
            strSql .Append( " FROM R_PQAE" );
            strSql.Append( " WHERE YEAR(AE21)=@AE2" );
            strSql.Append( " GROUP BY AE09,YEAR(AE21),MONTH(AE21)" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE2",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取车间主任 ERP
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkShop ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH tab AS(SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')))" );
            //strSql.Append( " ,CET AS (" );
            strSql.Append( " SELECT AE08,SUM(AE19) AE19,AE17 FROM (SELECT DISTINCT AE02,CASE WHEN DBA005=DAA001 THEN DAA002 ELSE AE08 END AE08,AE19,MONTH(AE17) AE17 FROM R_PQAE A1 LEFT JOIN TPADBA A2 ON A1.AE08=A2.DBA002 LEFT JOIN tab A3 ON A2.DBA005=A3.DAA001" );
            strSql.Append( " WHERE YEAR(AE17)=@AE17 " );
            strSql.Append( " ) A WHERE AE08 IN (SELECT DAA002 FROM tab) GROUP BY AE08,AE17" );
            //strSql.Append( " ),CFT AS" );
            //strSql.Append( " ( SELECT AE08,SUM(AE) AE,AE21 FROM (" );
            //strSql.Append( " SELECT DISTINCT AE02,CASE WHEN DBA005=DAA001 THEN DAA002 ELSE AE08 END AE08,ISNULL(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END,0) AE,MONTH(AE21) AE21 FROM R_PQAE A1 LEFT JOIN TPADBA A2 ON A1.AE08=A2.DBA002 LEFT JOIN tab A3 ON A2.DBA005=A3.DAA001" );
            //strSql.Append( " WHERE YEAR(AE21)=@AE17" );
            //strSql.Append( " ) A WHERE AE08 IN (SELECT DAA002 FROM tab) GROUP BY AE08,AE21 )" );
            //strSql.Append( " SELECT A.*,CONVERT(DECIMAL(18,2),AE) AE FROM CET A LEFT JOIN CFT B ON A.AE08=B.AE08 AND A.AE17=B.AE21 GROUP BY A.AE08,A.AE19,A.AE17,AE ORDER BY A.AE17" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE17",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );            
        }

        /// <summary>
        /// 获取车间主任  实际
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkShopAc ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH tab AS(SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')))" );
            //strSql.Append( " ,CET AS (" );
            //strSql.Append( " SELECT AE08,SUM(AE19) AE19,AE17 FROM (SELECT DISTINCT AE02,CASE WHEN DBA005=DAA001 THEN DAA002 ELSE AE08 END AE08,AE19,MONTH(AE17) AE17 FROM R_PQAE A1 LEFT JOIN TPADBA A2 ON A1.AE08=A2.DBA002 LEFT JOIN tab A3 ON A2.DBA005=A3.DAA001" );
            //strSql.Append( " WHERE YEAR(AE17)=@AE17 " );
            //strSql.Append( " ) A WHERE AE08 IN (SELECT DAA002 FROM tab) GROUP BY AE08,AE17" );
            //strSql.Append( " ),CFT AS(" );
            strSql.Append( "  SELECT AE08,SUM(AE) AE,AE21 FROM (" );
            //strSql.Append( " SELECT DISTINCT AE02,CASE WHEN DBA005=DAA001 THEN DAA002 ELSE AE08 END AE08,SUM(ISNULL(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END,0)) AE,MONTH(AE21) AE21 FROM R_PQAE A1 LEFT JOIN TPADBA A2 ON A1.AE08=A2.DBA002 LEFT JOIN tab A3 ON A2.DBA005=A3.DAA001" );
            strSql . Append ( " SELECT DISTINCT AE02,CASE WHEN DBA005=DAA001 THEN DAA002 ELSE AE08 END AE08,SUM(ISNULL(AE37,0)*ISNULL(AE12,0)) AE,MONTH(AE21) AE21 FROM R_PQAE A1 LEFT JOIN TPADBA A2 ON A1.AE08=A2.DBA002 LEFT JOIN tab A3 ON A2.DBA005=A3.DAA001" );
            strSql .Append( " WHERE YEAR(AE21)=@AE17 GROUP BY AE02,DBA005,DAA001,DAA002,AE08,DBA002,MONTH(AE21)" );
            strSql.Append( " ) A WHERE AE08 IN (SELECT DAA002 FROM tab) GROUP BY AE08,AE21" );
            //strSql.Append( "  )SELECT A.*,CONVERT(DECIMAL(18,2),AE) AE FROM CET A LEFT JOIN CFT B ON A.AE08=B.AE08 AND A.AE17=B.AE21 GROUP BY A.AE08,A.AE19,A.AE17,AE ORDER BY A.AE17" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE17",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取其它人信息 ERP
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT DISTINCT AE02,AE08,AE19,YEAR(AE17) AE17YEAR,MONTH(AE17) AE17MONTH FROM R_PQAE WHERE YEAR(AE17)=@AE1" );
            strSql.Append( " AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))) " );
            //strSql.Append( ",CGT AS( " );
            strSql.Append( "SELECT AE08,SUM(AE19) AE19,AE17YEAR,AE17MONTH FROM CET GROUP BY AE08,AE17YEAR,AE17MONTH" );
            //strSql.Append( "),CFT AS (SELECT AE08,CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END AE12,YEAR(AE21) AE21YEAR,MONTH(AE21) AE21MONTH FROM R_PQAE" );
            //strSql.Append( " WHERE YEAR(AE21)=@AE1" );
            //strSql.Append( "  AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))),CHT AS(SELECT AE08,ISNULL(CONVERT(DECIMAL(18,2),SUM(AE12)),0) AE12,AE21YEAR,AE21MONTH FROM CFT GROUP BY AE08,AE21YEAR,AE21MONTH)" );
            //strSql.Append( " SELECT A.AE08,A.AE19,ISNULL(B.AE12,0) AE12,A.AE17MONTH,A.AE17YEAR FROM CGT A LEFT JOIN CHT B ON A.AE08=B.AE08 AND A.AE17YEAR=B.AE21YEAR AND A.AE17MONTH=B.AE21MONTH" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE1",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取其它人信息 实际
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableOtherAc ( int year )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (SELECT DISTINCT AE02,AE08,AE19,YEAR(AE17) AE17YEAR,MONTH(AE17) AE17MONTH FROM R_PQAE WHERE YEAR(AE17)=@AE1" );
            strSql.Append( " AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) " );
            //strSql.Append( "),CGT AS( " );
            //strSql.Append( "SELECT AE08,SUM(AE19) AE19,AE17YEAR,AE17MONTH FROM CET GROUP BY AE08,AE17YEAR,AE17MONTH" );
            //strSql.Append( "),CFT AS (SELECT AE08,CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END AE12,YEAR(AE21) AE21YEAR,MONTH(AE21) AE21MONTH FROM R_PQAE" );
            strSql . Append ( "),CFT AS (SELECT AE08,ISNULL(AE37,0)*ISNULL(AE12,0) AE12,YEAR(AE21) AE21YEAR,MONTH(AE21) AE21MONTH FROM R_PQAE" );
            strSql .Append( " WHERE YEAR(AE21)=@AE1" );
            strSql.Append( "  AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')))" );
            //strSql.Append( ",CHT AS(" );
            strSql.Append( " SELECT AE08,ISNULL(CONVERT(DECIMAL(18,2),SUM(AE12)),0) AE12,AE21YEAR,AE21MONTH FROM CFT GROUP BY AE08,AE21YEAR,AE21MONTH" );
            //strSql.Append( " )" );
            //strSql.Append( " SELECT A.AE08,A.AE19,ISNULL(B.AE12,0) AE12,A.AE17MONTH,A.AE17YEAR FROM CGT A LEFT JOIN CHT B ON A.AE08=B.AE08 AND A.AE17YEAR=B.AE21YEAR AND A.AE17MONTH=B.AE21MONTH" );
            SqlParameter[] parameter = {
                new SqlParameter("@AE1",SqlDbType.Int)
            };
            parameter[0].Value = year;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 交货日期在本月和本月以前完成的交货产值 生产部
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableJhS ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE  " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            //strSql . Append ( "AND SUBSTRING(CONVERT(VARCHAR,AE21,112),1,6)<=SUBSTRING(CONVERT(VARCHAR,AE17,112),1,6) AND AE08 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN  (SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );
            strSql . Append ( "AND AE21<=AE17 AND AE08 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN  (SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0} " ,year );
            //strSql . Append ( "AND SUBSTRING(CONVERT(VARCHAR,AE21,112),1,6)<=SUBSTRING(CONVERT(VARCHAR,AE17,112),1,6) AND  AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) GROUP BY AE08,YEAR(AE17),MONTH(AE17) ORDER BY AE08" );
            strSql . Append ( "AND AE21<=AE17 AND  AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) GROUP BY AE08,YEAR(AE17),MONTH(AE17) ORDER BY AE08" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 交货日期在本月和本月以前完成的交货产值 车间主任
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableJhSZ ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH tab AS(" );
            strSql . Append ( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))) " );
            strSql . Append ( "SELECT DAA002,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE A INNER JOIN TPADBA B ON A.AE08=B.DBA002 INNER JOIN tab C ON B.DBA005=C.DAA001 " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0} " ,year );
            strSql . Append ( "AND AE21<=AE17 GROUP BY DAA002,YEAR(AE17),MONTH(AE17) " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT DAA002,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE A INNER JOIN TPADBA B ON A.AE08=B.DBA002 INNER JOIN tab C ON B.DBA005=C.DAA001 " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0} " ,year );
            strSql . Append ( "AND AE21<=AE17 GROUP BY DAA002,YEAR(AE17),MONTH(AE17) " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 交货日期在本月和本月以前完成的交货产值 业务部
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableJhY ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AE09,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE   " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0} " ,year );
            //strSql . Append ( "AND SUBSTRING(CONVERT(VARCHAR,AE21,112),1,6)<=SUBSTRING(CONVERT(VARCHAR,AE17,112),1,6) GROUP BY AE09,YEAR(AE17),MONTH(AE17) ORDER BY AE09" );
            strSql . Append ( "AND AE21<=AE17 GROUP BY AE09,YEAR(AE17),MONTH(AE17) ORDER BY AE09" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 本月接单到目前为止所有完成交货的产值 生产部
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableQS ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE  " );
            //strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            //strSql . Append ( "AND AE08 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN  (SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );
            //strSql . Append ( "UNION " );
            //strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(CASE WHEN AE12=0 THEN AE37*AE10*AE11 ELSE AE37*AE12 END)) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE  " );
            //strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            //strSql . Append ( "AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );

            strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE  " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            strSql . Append ( "AND AE08 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN  (SELECT B.DAA001 FROM (SELECT DBA001,DBA002,DBA005 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT AE08,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE  " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            strSql . Append ( "AND AE08 NOT IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT B.DAA001 FROM (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) A LEFT JOIN TPADAA B ON A.DBA002=B.DAA002)) AND AE08 NOT IN ( SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) GROUP BY AE08,YEAR(AE17),MONTH(AE17) " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 本月接单到目前为止所有完成交货的产值 车间主任
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableQSZ ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH tab AS(SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))) " );
            strSql . Append ( "SELECT DAA002,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE A INNER JOIN TPADBA B ON A.AE08=B.DBA002 INNER JOIN tab C ON B.DBA005=C.DAA001 " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            strSql . Append ( " GROUP BY DAA002,YEAR(AE17),MONTH(AE17) " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT DAA002,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE A INNER JOIN TPADBA B ON A.AE08=B.DBA002 INNER JOIN tab C ON B.DBA005=C.DAA001 " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0}" ,year );
            strSql . Append ( " GROUP BY DAA002,YEAR(AE17),MONTH(AE17) " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 本月接单到目前为止所有完成交货的产值 业务部
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableQY ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT AE09,CONVERT(DECIMAL(18,2),SUM(ISNULL(AE37,0)*ISNULL(AE12,0))) AE,YEAR(AE17) YE,MONTH(AE17) MO FROM R_PQAE   " );
            strSql . AppendFormat ( "WHERE YEAR(AE17)={0} " ,year );
            strSql . Append ( " GROUP BY AE09,YEAR(AE17),MONTH(AE17) ORDER BY AE09" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="yaer"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public bool Exists ( string name ,int yaer ,int month ,string px )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQSZ" );
            strSql . Append ( " WHERE SZ002=@SZ002 AND SZ003=@SZ003 AND SZ008=@SZ008 AND SZ010=@SZ010" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@SZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@SZ008",SqlDbType.NVarChar,20),
                new SqlParameter("@SZ010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = name;
            parameter [ 1 ] . Value = yaer;
            parameter [ 2 ] . Value = month;
            parameter [ 3 ] . Value = px;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public string Insert ( MulaolaoLibrary.TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQSZ (" );
            strSql.Append( "SZ001,SZ002,SZ003,SZ004,SZ005,SZ006,SZ007,SZ008,SZ009,SZ010,SZ011,SZ012)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')" ,_model . SZ001 ,_model . SZ002 ,_model . SZ003 ,_model . SZ004 ,_model . SZ005 ,_model . SZ006 ,_model . SZ007 ,_model . SZ008 ,_model . SZ009 ,_model . SZ010 ,_model . SZ011 ,_model . SZ012 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public string Update ( MulaolaoLibrary . TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQSZ SET " );
            strSql . AppendFormat ( "SZ005='{0}'," ,_model . SZ005 );
            strSql . AppendFormat ( "SZ006='{0}'" ,_model . SZ006 );
            strSql . AppendFormat ( " WHERE SZ002='{0}'" ,_model . SZ002 );
            strSql . AppendFormat ( " AND SZ003='{0}'" ,_model . SZ003 );
            strSql . AppendFormat ( " AND SZ008='{0}'" ,_model . SZ008 );
            strSql . AppendFormat ( " AND SZ010='{0}'" ,_model . SZ010 );

            return strSql . ToString ( );
        }

        public string UpdateAc ( MulaolaoLibrary . TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQSZ SET " );
            strSql . AppendFormat ( "SZ006='{0}'" ,_model . SZ006 );
            strSql . AppendFormat ( " WHERE SZ002='{0}'" ,_model . SZ002 );
            strSql . AppendFormat ( " AND SZ003='{0}'" ,_model . SZ003 );
            strSql . AppendFormat ( " AND SZ008='{0}'" ,_model . SZ008 );
            strSql . AppendFormat ( " AND SZ010='{0}'" ,_model . SZ010 );

            return strSql . ToString ( );
        }

        public string UpdateAc11 ( MulaolaoLibrary . TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQSZ SET " );
            strSql . AppendFormat ( "SZ011='{0}'" ,_model . SZ011 );
            strSql . AppendFormat ( " WHERE SZ002='{0}'" ,_model . SZ002 );
            strSql . AppendFormat ( " AND SZ003='{0}'" ,_model . SZ003 );
            strSql . AppendFormat ( " AND SZ008='{0}'" ,_model . SZ008 );
            strSql . AppendFormat ( " AND SZ010='{0}'" ,_model . SZ010 );

            return strSql . ToString ( );
        }

        public string UpdateAc12 ( MulaolaoLibrary . TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQSZ SET " );
            strSql . AppendFormat ( "SZ012='{0}'" ,_model . SZ012 );
            strSql . AppendFormat ( " WHERE SZ002='{0}'" ,_model . SZ002 );
            strSql . AppendFormat ( " AND SZ003='{0}'" ,_model . SZ003 );
            strSql . AppendFormat ( " AND SZ008='{0}'" ,_model . SZ008 );
            strSql . AppendFormat ( " AND SZ010='{0}'" ,_model . SZ010 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 生成记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate ( MulaolaoLibrary.TargetActualWarnLibrary _model )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQSZ SET SZ005=0,SZ006=0,SZ011=0,SZ012=0 WHERE SZ003='{0}'" ,_model . SZ003 );
            SQLString . Add ( strSql . ToString ( ) );

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) == false )
                return false;

            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAE SET AE08=PQF66 FROM R_PQF A INNER JOIN R_PQAE B ON A.PQF01=B.AE02 WHERE AE08=''" );
            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );

            DataTable tableProduct = GetDataTableProduct( _model.SZ003 );
            if ( tableProduct.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableProduct . Rows . Count ; i++ )
                {
                    _model . SZ002 = "[0]" + tableProduct . Rows [ i ] [ "AE08" ] . ToString ( );
                    _model . SZ010 = "组长";
                    _model . SZ004 = 0;
                    _model . SZ005 = string . IsNullOrEmpty ( tableProduct . Rows [ i ] [ "AE19" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( tableProduct . Rows [ i ] [ "AE19" ] . ToString ( ) );
                    _model . SZ006 = 0;
                    _model . SZ007 = "本月";
                    _model . SZ008 = string . IsNullOrEmpty ( tableProduct . Rows [ i ] [ "AE17" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableProduct . Rows [ i ] [ "AE17" ] . ToString ( ) );
                    _model . SZ009 = "0";
                    _model . SZ011 = _model . SZ012 = 0;

                    result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                    if ( result == true )
                        SQLString . Add ( Update ( _model ) );
                    else
                        SQLString . Add ( Insert ( _model ) );
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableProductAc = GetDataTableProductAc( _model.SZ003 );
                if ( tableProductAc.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableProductAc.Rows.Count ; i++ )
                    {
                        _model.SZ002 = "[0]" + tableProductAc.Rows[i]["AE08"].ToString( );
                        _model.SZ010 = "组长";
                        _model.SZ004 = 0;
                        _model.SZ005 = 0;
                        _model.SZ006 = string.IsNullOrEmpty( tableProductAc.Rows[i]["AE"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableProductAc.Rows[i]["AE"].ToString( ) );
                        _model.SZ007 = "本月";
                        _model.SZ008 = string.IsNullOrEmpty( tableProductAc.Rows[i]["AE21"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableProductAc.Rows[i]["AE21"].ToString( ) );
                        _model.SZ009 = "0";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists( _model.SZ002 ,_model.SZ003 ,_model.SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString.Add( UpdateAc( _model ) );
                        else
                            SQLString.Add( Insert( _model ) );
                    }
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableSaleMan = GetDataTableSaleMan( _model.SZ003 );
                if ( tableSaleMan.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableSaleMan.Rows.Count ; i++ )
                    {
                        _model.SZ002 = "[2]" + tableSaleMan.Rows[i]["AE09"].ToString( );
                        _model.SZ010 = "业务员";
                        _model.SZ004 = 0;
                        _model.SZ005 = string.IsNullOrEmpty( tableSaleMan.Rows[i]["AE19"].ToString( ) ) == true ? 0M : Convert.ToDecimal( tableSaleMan.Rows[i]["AE19"].ToString( ) );
                        _model.SZ006 = 0;
                        _model.SZ007 = "本月";
                        _model.SZ008 = string.IsNullOrEmpty( tableSaleMan.Rows[i]["AE17"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableSaleMan.Rows[i]["AE17"].ToString( ) );
                        _model.SZ009 = "1";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists( _model.SZ002 ,_model.SZ003 ,_model.SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString.Add( Update( _model ) );
                        else
                            SQLString.Add( Insert( _model ) );
                    }
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableSaleManAc = GetDataTableSaleManAc( _model.SZ003 );
                if ( tableSaleManAc.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableSaleManAc.Rows.Count ; i++ )
                    {
                        _model.SZ002 = "[2]" + tableSaleManAc.Rows[i]["AE09"].ToString( );
                        _model.SZ010 = "业务员";
                        _model.SZ004 = 0;
                        _model.SZ005 = 0;
                        _model.SZ006 = string.IsNullOrEmpty( tableSaleManAc.Rows[i]["AE"].ToString( ) ) == true ? 0M : Convert.ToDecimal( tableSaleManAc.Rows[i]["AE"].ToString( ) );
                        _model.SZ007 = "本月";
                        _model.SZ008 = string.IsNullOrEmpty( tableSaleManAc.Rows[i]["AE21"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableSaleManAc.Rows[i]["AE21"].ToString( ) );
                        _model.SZ009 = "1";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists( _model.SZ002 ,_model.SZ003 ,_model.SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString.Add( UpdateAc( _model ) );
                        else
                            SQLString.Add( Insert( _model ) );
                    }
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableWorkShop = GetDataTableWorkShop( _model.SZ003 );
                if ( tableWorkShop.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableWorkShop . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[1]" + tableWorkShop . Rows [ i ] [ "AE08" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = string . IsNullOrEmpty ( tableWorkShop . Rows [ i ] [ "AE19" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( tableWorkShop . Rows [ i ] [ "AE19" ] . ToString ( ) );
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ008 = string . IsNullOrEmpty ( tableWorkShop . Rows [ i ] [ "AE17" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableWorkShop . Rows [ i ] [ "AE17" ] . ToString ( ) );
                        _model . SZ009 = "2";
                        _model . SZ010 = "车间主任";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( Update ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableWorkShopAc = GetDataTableWorkShopAc( _model.SZ003 );
                if ( tableWorkShopAc.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableWorkShopAc.Rows.Count ; i++ )
                    {
                        _model.SZ002 = "[1]" + tableWorkShopAc.Rows[i]["AE08"].ToString( );                 
                        _model.SZ004 = 0;
                        _model.SZ005 = 0;
                        _model.SZ006 = string.IsNullOrEmpty( tableWorkShopAc.Rows[i]["AE"].ToString( ) ) == true ? 0M : Convert.ToDecimal( tableWorkShopAc.Rows[i]["AE"].ToString( ) );
                        _model.SZ007 = "本月";
                        _model.SZ008 = string.IsNullOrEmpty( tableWorkShopAc.Rows[i]["AE21"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableWorkShopAc.Rows[i]["AE21"].ToString( ) );
                        _model.SZ009 = "2";
                        _model . SZ010 = "车间主任";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists( _model.SZ002 ,_model.SZ003 ,_model.SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString.Add( UpdateAc( _model ) );
                        else
                            SQLString.Add( Insert( _model ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) == true )
            {
                SQLString = new ArrayList ( );
                DataTable tableOther = GetDataTableOther ( _model . SZ003 );
                if ( tableOther . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < tableOther . Rows . Count ; i++ )
                    {
                        if ( tableOther . Rows [ i ] [ "AE08" ] . ToString ( ) .Equals( "委外") )
                        {
                            _model . SZ002 = "[0]" + tableOther . Rows [ i ] [ "AE08" ] . ToString ( );
                            _model . SZ010 = "组长";
                        }
                        else
                        {
                            _model . SZ002 = "[3]" + tableOther . Rows [ i ] [ "AE08" ] . ToString ( );
                            _model . SZ010 = "其它";
                        }
                        _model . SZ004 = 0;
                        _model . SZ005 = string . IsNullOrEmpty ( tableOther . Rows [ i ] [ "AE19" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( tableOther . Rows [ i ] [ "AE19" ] . ToString ( ) );
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ008 = string . IsNullOrEmpty ( tableOther . Rows [ i ] [ "AE17MONTH" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOther . Rows [ i ] [ "AE17MONTH" ] . ToString ( ) );
                        _model . SZ009 = "3";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( Update ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                    for ( int j = 0 ; j < tableOther . Rows . Count ; j++ )
                    {
                        if ( tableOther . Rows [ j ] [ "AE08" ] . ToString ( ) . Equals ( "委外" ) )
                        {
                            _model . SZ002 = "[1]" + tableOther . Rows [ j ] [ "AE08" ] . ToString ( );
                            _model . SZ010 = "车间主任";
                            _model . SZ004 = 0;
                            _model . SZ005 = string . IsNullOrEmpty ( tableOther . Rows [ j ] [ "AE19" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( tableOther . Rows [ j ] [ "AE19" ] . ToString ( ) );
                            _model . SZ006 = 0;
                            _model . SZ007 = "本月";
                            _model . SZ008 = string . IsNullOrEmpty ( tableOther . Rows [ j ] [ "AE17MONTH" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOther . Rows [ j ] [ "AE17MONTH" ] . ToString ( ) );
                            _model . SZ009 = "2";
                            _model . SZ011 = _model . SZ012 = 0;

                            result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                            if ( result == true )
                                SQLString . Add ( Update ( _model ) );
                            else
                                SQLString . Add ( Insert ( _model ) );
                        }
                    }
                }
            }
            if ( SqlHelper.ExecuteSqlTran( SQLString ) == true )
            {
                SQLString = new ArrayList( );
                DataTable tableOtherAc = GetDataTableOtherAc( _model.SZ003 );
                if ( tableOtherAc.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < tableOtherAc.Rows.Count ; i++ )
                    {
                        if ( tableOtherAc.Rows[i]["AE08"].ToString( ) == "委外" )
                        {
                            _model.SZ002 = "[0]" + tableOtherAc.Rows[i]["AE08"].ToString( );
                            _model.SZ010 = "组长";
                        }
                        else
                        {
                            _model.SZ002 = "[3]" + tableOtherAc.Rows[i]["AE08"].ToString( );
                            _model.SZ010 = "其它";
                        }
                        _model.SZ004 = 0;
                        _model.SZ005 = 0;
                        _model.SZ006 = string.IsNullOrEmpty( tableOtherAc.Rows[i]["AE12"].ToString( ) ) == true ? 0M : Convert.ToDecimal( tableOtherAc.Rows[i]["AE12"].ToString( ) );
                        _model.SZ007 = "本月";
                        _model.SZ008 = string.IsNullOrEmpty( tableOtherAc.Rows[i]["AE21MONTH"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableOtherAc.Rows[i]["AE21MONTH"].ToString( ) );
                        _model.SZ009 = "3";
                        _model . SZ011 = _model . SZ012 = 0;

                        result = Exists( _model.SZ002 ,_model.SZ003 ,_model.SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString.Add( UpdateAc( _model ) );
                        else
                            SQLString.Add( Insert( _model ) );
                    }
                    for ( int j = 0 ; j < tableOtherAc . Rows . Count ; j++ )
                    {
                        if ( tableOtherAc . Rows [ j ] [ "AE08" ] . ToString ( ) . Equals ( "委外" ) )
                        {
                            _model . SZ002 = "[1]" + tableOtherAc . Rows [ j ] [ "AE08" ] . ToString ( );
                            _model . SZ010 = "车间主任";
                            _model . SZ004 = 0;
                            _model . SZ005 = 0;
                            _model . SZ006 = string . IsNullOrEmpty ( tableOtherAc . Rows [ j ] [ "AE12" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( tableOtherAc . Rows [ j ] [ "AE12" ] . ToString ( ) );
                            _model . SZ007 = "本月";
                            _model . SZ008 = string . IsNullOrEmpty ( tableOtherAc . Rows [ j ] [ "AE21MONTH" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOtherAc . Rows [ j ] [ "AE21MONTH" ] . ToString ( ) );
                            _model . SZ009 = "2";
                            _model . SZ011 = _model . SZ012 = 0;

                            result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                            if ( result == true )
                                SQLString . Add ( UpdateAc ( _model ) );
                            else
                                SQLString . Add ( Insert ( _model ) );
                        }
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableJhS ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[0]" + dtOne . Rows [ i ] [ "AE08" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "0";
                        _model . SZ010 = "组长";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );
                        _model . SZ012 = 0;

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc11 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                    for ( int j = 0 ; j < dtOne . Rows . Count ; j++ )
                    {
                        if ( dtOne . Rows [ j ] [ "AE08" ] . ToString ( ) . Equals ( "委外" ) )
                        {
                            _model . SZ002 = "[1]" + dtOne . Rows [ j ] [ "AE08" ] . ToString ( );
                            _model . SZ004 = 0;
                            _model . SZ005 = 0;
                            _model . SZ006 = 0;
                            _model . SZ007 = "本月";
                            _model . SZ009 = "2";
                            _model . SZ010 = "车间主任";
                            _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ j ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ j ] [ "MO" ] . ToString ( ) );
                            _model . SZ011 = string . IsNullOrEmpty ( dtOne . Rows [ j ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ j ] [ "AE" ] . ToString ( ) );
                            _model . SZ012 = 0;

                            result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                            if ( result == true )
                                SQLString . Add ( UpdateAc11 ( _model ) );
                            else
                                SQLString . Add ( Insert ( _model ) );
                        }
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableJhY ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[2]" + dtOne . Rows [ i ] [ "AE09" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "1";
                        _model . SZ010 = "业务员";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );
                        _model . SZ012 = 0;

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc11 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableQS ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[0]" + dtOne . Rows [ i ] [ "AE08" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "0";
                        _model . SZ010 = "组长";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = 0;
                        _model . SZ012 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc12 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                    for ( int j = 0 ; j < dtOne . Rows . Count ; j++ )
                    {
                        if ( dtOne . Rows [ j ] [ "AE08" ] . ToString ( ) . Equals ( "委外" ) )
                        {
                            _model . SZ002 = "[1]" + dtOne . Rows [ j ] [ "AE08" ] . ToString ( );
                            _model . SZ004 = 0;
                            _model . SZ005 = 0;
                            _model . SZ006 = 0;
                            _model . SZ007 = "本月";
                            _model . SZ009 = "2";
                            _model . SZ010 = "车间主任";
                            _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ j ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ j ] [ "MO" ] . ToString ( ) );
                            _model . SZ011 = 0;
                            _model . SZ012 = string . IsNullOrEmpty ( dtOne . Rows [ j ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ j ] [ "AE" ] . ToString ( ) );

                            result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                            if ( result == true )
                                SQLString . Add ( UpdateAc12 ( _model ) );
                            else
                                SQLString . Add ( Insert ( _model ) );
                        }
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableQY ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[2]" + dtOne . Rows [ i ] [ "AE09" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "1";
                        _model . SZ010 = "业务员";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = 0;
                        _model . SZ012 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc12 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableJhSZ ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[1]" + dtOne . Rows [ i ] [ "DAA002" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "2";
                        _model . SZ010 = "车间主任";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );
                        _model . SZ012 = 0;

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc11 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                }
            }
            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                DataTable dtOne = GetDataTableQSZ ( _model . SZ003 );
                if ( dtOne . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dtOne . Rows . Count ; i++ )
                    {
                        _model . SZ002 = "[1]" + dtOne . Rows [ i ] [ "DAA002" ] . ToString ( );
                        _model . SZ004 = 0;
                        _model . SZ005 = 0;
                        _model . SZ006 = 0;
                        _model . SZ007 = "本月";
                        _model . SZ009 = "0";
                        _model . SZ010 = "车间主任";
                        _model . SZ008 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dtOne . Rows [ i ] [ "MO" ] . ToString ( ) );
                        _model . SZ011 = 0;
                        _model . SZ012 = string . IsNullOrEmpty ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dtOne . Rows [ i ] [ "AE" ] . ToString ( ) );

                        result = Exists ( _model . SZ002 ,_model . SZ003 ,_model . SZ008 ,_model . SZ010 );
                        if ( result == true )
                            SQLString . Add ( UpdateAc12 ( _model ) );
                        else
                            SQLString . Add ( Insert ( _model ) );
                    }
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 包括所有月份
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool InsertOfAll ( string oddNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SZ002,SZ003,SZ007,SZ008,SZ009,SZ010 FROM R_PQSZ " );
            strSql . Append ( " WHERE SZ001=@SZ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            if ( da != null && da . Rows . Count > 0 )
            {
                MulaolaoLibrary . TargetActualWarnLibrary _model = new MulaolaoLibrary . TargetActualWarnLibrary ( );
                List<string> strList = new List<string> ( );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . SZ001 = oddNum;
                    _model . SZ003 = string . IsNullOrEmpty ( da . Rows [ i ] [ "SZ003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "SZ003" ] . ToString ( ) );
                    _model . SZ004 = 0;
                    _model . SZ005 = 0;
                    _model . SZ006 = 0;
                    _model . SZ007 = da . Rows [ i ] [ "SZ007" ] . ToString ( );
                    _model . SZ009 = da . Rows [ i ] [ "SZ009" ] . ToString ( );
                    _model . SZ010 = da . Rows [ i ] [ "SZ010" ] . ToString ( );
                    if ( i == 0 )
                    {
                        _model . SZ002 = da . Rows [ i ] [ "SZ002" ] . ToString ( );
                        strList . Add ( _model . SZ002 );
                        for ( int k = 1 ; k < 13 ; k++ )
                        {
                            _model . SZ008 = k;
                            if ( da . Select ( "SZ002='" + _model . SZ002 + "' AND SZ008='" + _model . SZ008 + "'" ) . Length < 1 )
                            {
                                SQLString . Add ( Insert ( _model ) );
                            }
                        }
                    }
                    else
                    {
                        _model . SZ002 = da . Rows [ i ] [ "SZ002" ] . ToString ( );
                        if ( !strList . Contains ( _model . SZ002 ) )
                        {
                            strList . Add ( _model . SZ002 );
                            for ( int k = 1 ; k < 13 ; k++ )
                            {
                                _model . SZ008 = k;
                                if ( da . Select ( "SZ002='" + _model . SZ002 + "' AND SZ008='" + _model . SZ008 + "'" ) . Length < 1 )
                                {
                                    SQLString . Add ( Insert ( _model ) );
                                }
                            }
                        }
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT * FROM R_PQSZ" );
            //strSql.Append( " WHERE SZ001=@SZ001" );
            //strSql.Append( " ORDER BY SZ009" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@SZ001",SqlDbType.NVarChar,20)
            //};
            //parameter[0].Value = oddNum;
            strSql . Append ( "WITH CET AS (SELECT 0 idx,SZ001,SUBSTRING(SZ002,0,4) SZ002,SZ003,SZ004,SZ005,SZ006,SZ007,SZ008,CASE WHEN SUBSTRING(SZ002,0,4)='[0]' THEN 4 ELSE 5 END SZ009,CASE WHEN SZ010='组长' THEN '总计生产部' WHEN SZ010='业务员' THEN '总计业务部' END SZ010,SZ011,SZ012 FROM R_PQSZ WHERE SUBSTRING(SZ002,0,4)!='[1]'" );
            strSql . Append ( " AND SZ001=@SZ001) " );
            strSql . Append ( " SELECT idx,SZ001,SZ002,SZ003,SUM(SZ004) SZ004,SUM(SZ005) SZ005,SUM(SZ006) SZ006,SZ007,SZ008,SZ009,SZ010,SUM(SZ011) SZ011,SUM(SZ012) SZ012 FROM CET GROUP BY idx,SZ001,SZ002,SZ003,SZ007,SZ008,SZ009,SZ010" );
            strSql . Append ( " UNION" );
            strSql . Append ( " SELECT idx,SZ001,SZ002,SZ003,SZ004,SZ005,SZ006,SZ007,SZ008,SZ009,SZ010,SZ011,SZ012 FROM R_PQSZ" );
            strSql . Append ( " WHERE SZ001=@SZ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            return SqlHelper .ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        public DataTable GetDataTableTotal ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );

            strSql . Append ( "WITH CET AS (SELECT 0 idx,SZ001,SUBSTRING(SZ002,0,4) SZ002,SZ003,SZ004,SZ005,SZ006,SZ007,SZ008,CASE WHEN SUBSTRING(SZ002,0,4)='[0]' THEN 4 ELSE 5 END SZ009,CASE WHEN SZ010='组长' THEN '总计生产部' WHEN SZ010='业务员' THEN '总计业务部' END SZ010,SZ011,SZ012 FROM R_PQSZ WHERE SUBSTRING(SZ002,0,4)!='[1]'" );
            strSql . Append ( " AND SZ001=@SZ001) " );
            strSql . Append ( " ,CFT AS(SELECT idx,SZ001,SZ002,SZ003,SUM(SZ004) SZ004,SUM(SZ005) SZ005,SUM(SZ006) SZ006,SZ007,SZ008,SZ009,SZ010,SUM(SZ011) SZ011,SUM(SZ012) SZ012 FROM CET GROUP BY idx,SZ001,SZ002,SZ003,SZ007,SZ008,SZ009,SZ010" );
            strSql . Append ( " UNION" );
            strSql . Append ( " SELECT idx,SZ001,SZ002,SZ003,SZ004,SZ005,SZ006,SZ007,SZ008,SZ009,SZ010,SZ011,SZ012 FROM R_PQSZ" );
            strSql . Append ( " WHERE SZ001=@SZ001)" );
            strSql . Append ( "SELECT SZ010,SZ002,SUM(SZ004) SZ004,SUM(SZ005) SZ005,SUM(SZ006) SZ006,SUM(SZ011) SZ011,SUM(SZ012) SZ012,SUM(SZ005-SZ011) U2,CONVERT(DECIMAL(18,3),CASE WHEN SUM(SZ005)=0 THEN 0 ELSE SUM(SZ011)/SUM(SZ005) END) U3,SUM(SZ005-SZ012) U4,CONVERT(DECIMAL(18,3),CASE WHEN SUM(SZ005)=0 THEN 0 ELSE SUM(SZ012)/SUM(SZ005) END) U5,CONVERT(DECIMAL(18,3),CASE WHEN SUM(SZ004)=0 THEN 0 ELSE SUM(SZ011)/SUM(SZ004) END) U6,SUM(SZ004-SZ011) U0 FROM CFT GROUP BY SZ010 ,SZ002 ORDER BY SZ010 DESC" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@SZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQSZ" );
            strSql.Append( " WHERE SZ001=@SZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@SZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT SZ001,SZ003 FROM R_PQSZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            Object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT SZ001,SZ003 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.SZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQSZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ")TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT SZ001,SZ003 FROM R_PQSZ" );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOne ( MulaolaoLibrary.TargetActualWarnLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQSZ SET " );
            strSql.Append( "SZ004=@SZ004" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@SZ004",SqlDbType.Decimal,11),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.SZ004;
            parameter[1].Value = _model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.TargetActualWarnLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQSZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.TargetActualWarnLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.TargetActualWarnLibrary _model = new MulaolaoLibrary.TargetActualWarnLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = Convert.ToInt32( row["idx"].ToString( ) );
                if ( row["SZ001"] != null && row["SZ001"].ToString( ) != "" )
                    _model.SZ001 = row["SZ001"].ToString( );
                if ( row["SZ002"] != null && row["SZ002"].ToString( ) != "" )
                    _model.SZ002 = row["SZ002"].ToString( );
                if ( row["SZ003"] != null && row["SZ003"].ToString( ) != "" )
                    _model.SZ003 = int.Parse( row["SZ003"].ToString( ) );
                if ( row["SZ004"] != null && row["SZ004"].ToString( ) != "" )
                    _model.SZ004 = decimal.Parse( row["SZ004"].ToString( ) );
                if ( row["SZ005"] != null && row["SZ005"].ToString( ) != "" )
                    _model.SZ005 = decimal.Parse( row["SZ005"].ToString( ) );
                if ( row["SZ006"] != null && row["SZ006"].ToString( ) != "" )
                    _model.SZ006 = decimal.Parse( row["SZ006"].ToString( ) );
                if ( row["SZ007"] != null && row["SZ007"].ToString( ) != "" )
                    _model.SZ007 = row["SZ007"].ToString( );
                if ( row["SZ008"] != null && row["SZ008"].ToString( ) != "" )
                    _model.SZ008 = int.Parse( row["SZ008"].ToString( ) );
            }
            return _model;
        }

        
    }
}
