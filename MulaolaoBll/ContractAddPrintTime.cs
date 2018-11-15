using System . Collections;
using System . Text;
using StudentMgr;

namespace MulaolaoBll
{
    public static class ContractAddPrintTime
    {
        /// <summary>
        /// 增加打印时间到送审界面和采购合同
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="Column">字段名</param>
        /// <param name="oddNum">合同单号</param>
        /// <param name="oddNumColumn">单号字段</param>
        /// <returns></returns>
        public static bool addTimeToContract ( string tableName,string Column,string oddNum ,string oddNumColumn )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_REVIEWS WHERE (RES08!='' OR RES08 IS NOT NULL) AND RES06='{0}'" ,oddNum );
            if ( !SqlHelper . Exists ( strSql . ToString ( ) ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_REVIEWS SET RES08='{0}' WHERE RES06='{1}'" ,Drity . GetDt ( ) ,oddNum );
                SQLString . Add ( strSql . ToString ( ) );
            }
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM {0} WHERE ({1}!='' OR {1} IS NOT NULL) AND {2}='{3}'" ,tableName ,Column ,oddNumColumn ,oddNum );
            if ( !string . IsNullOrEmpty ( strSql . ToString ( ) ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE {0} SET {1}='{2}' WHERE {3}='{4}'" ,tableName ,Column ,Drity . GetDt ( ) ,oddNumColumn ,oddNum );
                SQLString . Add ( strSql . ToString ( ) );
            }

            if ( SQLString . Count > 0 )
                return SqlHelper . ExecuteSqlTran ( SQLString );
            else
                return true;
        }

    }
}
