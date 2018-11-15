using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data;

namespace MulaolaoBll.Dao
{
    public class SystemDrityDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable  GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBF" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ); 
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT BF001,BF002 FROM R_PQBF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string tableNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT BF005 FROM R_PQBF" );
            strSql.Append( " WHERE BF001='" + tableNum + "'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
