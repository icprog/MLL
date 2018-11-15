using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class ZuZhangBomDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQZZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT ZZ001,ZZ002,ZZ003,ZZ004,ZZ005,ZZ006,ZZ007,ZZ008 FROM R_PQZZ WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }
    }
}
