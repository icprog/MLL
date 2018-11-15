using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class ChanPinGongZiKaoQinReportDao
    {
        /// <summary>
        /// 获取生产车间组长
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGroupLeader ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产车间员工姓名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( string name )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001 FROM TPADBA" );
            strSql.Append( " WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002=@DAA002)  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );
            SqlParameter[] parameter = {
                new SqlParameter("@DAA002",SqlDbType.NVarChar)
            };
            parameter[0].Value = name;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取317产品
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableProduct (string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ01,GZ22 FROM R_PQW" );
            strSql.Append( " WHERE GZ33=@GZ33" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ33",SqlDbType.NVarChar)
            };
            parameter[0].Value = num;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取报表内容
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableReport ( string strWhere)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,GZ01,GZ02,GZ03,GZ04,GZ05,GZ06,GZ07,GZ08,GZ09,GZ10,GZ11,GZ12,GZ13,GZ14,GZ16,GZ17,GZ18,GZ22,GZ23,GZ24,GZ25,GZ26,GZ27,GZ28,GZ29,GZ30,GZ31,GZ32,GZ33,GZ34 FROM R_PQW" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY GZ24 DESC,GZ17 DESC,GZ04" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
