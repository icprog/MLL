using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;

namespace MulaolaoBll.Dao
{
    public class ChangPingGaiShanDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPqf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF01,PQF02,PQF03,PQF04,PQF06,PQF17,HT52,PQF07,PQF08 FROM R_PQF A, TPADAA B, R_REVIEWS C, R_PQL D, R_MLLCXMC E WHERE A.PQF17 = B.DAA001 AND A.PQF01 = D.HT01 AND A.PQF01 = C.RES06 AND C.RES01 = E.CX01 AND C.RES05 = '执行' AND CX02 IN( '合同评审表(R_021)', '订单销售合同(R_001)' ) ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSerialNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT BG001,BG002,BG003,BG004 FROM R_PQBG" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
