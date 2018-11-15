using StudentMgr;
using System;
using System . Data;
using System . Text;

namespace MulaolaoBll
{
    public class Drity
    {
        /// <summary>
        /// 备份执行数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableNames"></param>
        /// <param name="oddNumName"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public static string DrityOfCopy ( string tableName ,string tableNames ,string oddNumName ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO " + tableName + " SELECT * FROM " + tableNames + " WHERE  " + oddNumName + "='{0}'" ,oddNum );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 记录操作
        /// </summary>
        /// <param name="tableNum">表号</param>
        /// <param name="tableName">表名</param>
        /// <param name="logins">操作人</param>
        /// <param name="dtOne">操作时间</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strS">SQL语句</param>
        /// <param name="stateOf">操作状态</param>
        /// <param name="stateOfOdd">状态</param>
        public static string DrityOfComparation ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string strS ,string stateOf ,string stateOfOdd )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBF (" );
            strSql . Append ( "BF001,BF002,BF003,BF004,BF005,BF006,BF007,BF008)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,tableNum ,tableName ,logins ,dtOne ,oddNum ,strS ,stateOf ,stateOfOdd );

            return strSql . ToString ( );
        }

        public static DateTime GetDt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

    }
}
