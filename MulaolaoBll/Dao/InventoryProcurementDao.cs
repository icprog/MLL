using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class InventoryProcurementDao
    {
        /// <summary>
        /// 入库的
        /// </summary>
        /// <returns></returns>
        public bool UpdateJZ ( )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(SELECT AK003,SUM(AK011) AK011 FROM R_PQAK WHERE AK003 NOT LIKE 'R_195%' AND AK003 NOT LIKE 'R_196%' AND AK003 NOT LIKE 'R_199%' AND AK003 NOT LIKE 'R_339%' AND AK003 NOT LIKE 'R_344%' AND AK003 NOT LIKE 'R_495%' AND AK003 NOT LIKE 'R_505%' GROUP BY AK003)" );
            strSql . Append ( ",CFT AS(SELECT AC16,SUM(AC09*(AC10+ISNULL(AC27,0))) AC FROM R_PQAC WHERE (AC24='未结' OR AC24='未结完' OR AC24='' OR AC24 IS NULL) GROUP BY AC16" );
            strSql . Append ( "),CHT AS (SELECT AC16,CONVERT(FLOAT,AC-AK011) KC FROM CFT A LEFT JOIN CET B ON A.AC16=B.AK003) " );
            strSql . Append ( "UPDATE R_PQAC SET AC24=(SELECT CASE WHEN KC IS NULL THEN '未结' WHEN KC<=100 OR KC>=-100 THEN '已结' ELSE '未结完' END KC1 FROM CHT  A WHERE A.AC16=CHT.AC16  ) FROM CHT WHERE R_PQAC.AC16=CHT.AC16 " );
            SQLString . Add ( strSql );
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAC SET AC24='已结' WHERE LEN(AC16)>17" );
            SQLString . Add ( strSql );
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 出库的
        /// </summary>
        /// <returns></returns>
        public bool UpdateADJZ ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(SELECT AK003,SUM(AK011) AK011 FROM R_PQAK WHERE AK003 NOT LIKE 'R_195%' AND AK003 NOT LIKE 'R_196%' AND AK003 NOT LIKE 'R_199%' AND AK003 NOT LIKE 'R_339%' AND AK003 NOT LIKE 'R_495%' AND AK003 NOT LIKE 'R_505%' GROUP BY AK003) " );
            strSql . Append ( ",CFT AS(SELECT AD17,SUM((AD05+ISNULL(AD20,0))*AD11) AC FROM R_PQAD WHERE (AD19='未结' OR AD19='未结完' OR AD19='' OR AD19 IS NULL) GROUP BY AD17),CHT AS (" );
            strSql . Append ( "SELECT AD17,AC,AK011,CONVERT(FLOAT,AC-AK011) KC FROM CFT A LEFT JOIN CET B ON A.AD17=B.AK003) " );
            strSql . Append ( "UPDATE R_PQAD SET AD19=(SELECT CASE WHEN KC IS NULL THEN '未结' WHEN KC<=100 OR KC>=-100 THEN '已结' ELSE '未结完' END KC1 FROM CHT  A WHERE A.AD17=CHT.AD17 ) FROM CHT WHERE R_PQAD.AD17=CHT.AD17 " );
            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

    }
}
