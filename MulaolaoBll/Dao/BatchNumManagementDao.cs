using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class BatchNumManagementDao
    {
        /// <summary>
        /// 获取464供方批号
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="colorNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableStock (string procedure,string colorNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AC15 FROM R_PQAC WHERE AC18 IN (SELECT AD01 FROM R_PQAD WHERE AC18=AD01 AND AC04=AD06 AND AC05=AD07 AND AD06=@AD06 AND AD07=@AD07 GROUP BY AD01 HAVING AC03+ISNULL(AC26,0)-SUM(AD05+ISNULL(AD20,0))>0 )" );
            SqlParameter[] parameter = {
                new SqlParameter("@AD06",SqlDbType.NVarChar,20),
                new SqlParameter("@AD07",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = procedure;
            parameter[1].Value = colorNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
    }
}

