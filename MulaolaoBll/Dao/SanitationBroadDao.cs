using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;

namespace MulaolaoBll . Dao
{
    public class SanitationBroadDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public DataTable getTableView ( string dateTime )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DECLARE @SqlStr NVARCHAR (MAX) " );
            strSql . AppendFormat ( "SET @SqlStr='SELECT SAD002,SAD003,SAD004,SAD005,' SELECT @SqlStr=@SqlStr+'SUM(CASE SAD008 WHEN '''+CONVERT(NVARCHAR(20),SAD008)+''' THEN SAD006 ELSE NULL END) AS '''+ QUOTENAME(SAD008)+''',' FROM (SELECT DISTINCT SAD008 FROM R_SAD) AS a SELECT @SqlStr=LEFT(@SqlStr,LEN(@SqlStr)-1)+',SAD009 FROM R_SAD A INNER JOIN R_SAC B ON A.SAD001=B.SAC001 WHERE CONVERT(NVARCHAR(20),SAC003,112)=''{0}'' GROUP BY SAD002,SAD003,SAD004,SAD005,SAD009' EXEC (@SqlStr)" ,dateTime );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取本年所有记录
        /// </summary>
        /// <returns></returns>
        public DataTable getTableGrouper (  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT SAD007,SAD008,MAX(CONVERT(NVARCHAR(20),SAC003,112)) SAC FROM R_SAD A INNER JOIN R_SAC B ON A.SAD001=B.SAC001 GROUP BY SAD007,SAD008" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
