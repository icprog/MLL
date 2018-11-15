using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;
using System.Data.SqlClient;

namespace MulaolaoBll.Dao
{
    public class ChanPinGonZiKaoQinHuiZongDao
    {
        /// <summary>
        /// 获取317产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct ( )
        { 
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ01,GZ22,GZ23,GZ34 FROM R_PQW A RIGHT JOIN R_PQFZ B ON A.idx=B.FZ002 LEFT JOIN R_PQEZ C ON B.FZ001=C.idx LEFT JOIN R_REVIEWS D ON C.EZ001=D.RES06 AND RES05='执行'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取317车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableHeadOfWorkShop ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ30,GZ31 FROM R_PQW WHERE GZ30 IS NOT NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取317统计员
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableStatistician ( string num)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ37,GZ38 FROM R_PQW" );
            strSql.Append( "  WHERE GZ31=@GZ31 AND GZ37 IS NOT NULL" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ31",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ01,GZ22,GZ16,GZ02,GZ04,GZ08,SUM(GZ09+GZ10+GZ11) GZ,SUM(GZ12+GZ13+GZ14) GZONE,GZ36,GZ06,SUM(GZ25+GZ26) GZTWO,SUM(GZ25*1.0*GZ41) GZTHR FROM R_PQW" );
            strSql.Append( " WHERE " + strWhere );
            strSql . Append ( " AND idx IN (SELECT FZ002 FROM R_PQFZ A LEFT JOIN R_PQEZ B ON A.FZ001=B.idx INNER JOIN R_REVIEWS C ON B.EZ001=C.RES06 AND C.RES05='执行' )" );
            strSql.Append( " GROUP BY GZ01,GZ22,GZ16,GZ02,GZ04,GZ36,GZ06,GZ08" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePrint (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ22,GZ16,GZ02,GZ04,GZ30,GZ37,GZ01,GZ34,GZ28,SUM(GZ09+GZ10+GZ11) GZ,SUM(GZ12+GZ13+GZ14) GZONE,GZ36,GZ06,SUM(GZ25+GZ26) GZTWO,SUM(GZ25) GZTHR,SUM(GZ09+GZ10+GZ11)+SUM(GZ12+GZ13+GZ14) U0,CONVERT(DECIMAL(7,2),GZ06*SUM(GZ25)) U3,CONVERT(DECIMAL(7,2),SUM(GZ12+GZ13+GZ14)*GZ36) U4,CONVERT(DECIMAL(18,2),GZ06*SUM(GZ25)+SUM(GZ12+GZ13+GZ14)*GZ36) U5,CONVERT(DECIMAL(18,0),GZ06*SUM(GZ25)+SUM(GZ12+GZ13+GZ14)*GZ36) U6,CASE WHEN SUM(GZ09+GZ10+GZ11)=0 THEN 0 WHEN SUM(GZ09+GZ10+GZ11)!=0 THEN CONVERT(DECIMAL(18,1),GZ06*SUM(GZ25)/SUM(GZ09+GZ10+GZ11)) END U9 FROM R_PQW " );
            strSql.Append( " WHERE  " + strWhere );
            strSql.AppendFormat( " AND idx IN (SELECT FZ002 FROM R_PQFZ A LEFT JOIN R_PQEZ B ON A.FZ001=B.idx INNER JOIN R_REVIEWS C ON B.EZ001=C.RES06 AND C.RES05='执行')" );
            strSql.Append( " GROUP BY GZ16,GZ02,GZ04,GZ36,GZ06,GZ30,GZ37,GZ01,GZ34,GZ28,GZ22" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
