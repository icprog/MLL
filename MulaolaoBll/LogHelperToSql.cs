using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using MulaolaoBll;

namespace MulaolaoBll
{
    public static class LogHelperToSql
    {
        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        public static void SaveLog ( string cmdText ,string parameters )
        {
            if ( cmdText . Contains ( "R_LOG" ) )
                return;
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_LOG (" );
            strSql . Append ( "LOG001,LOG002,LOG003,LOG004,LOG005,LOG006) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}',GETDATE(),'{2}','{3}','{4}') " ,UserInfoMation . tableName ,UserInfoMation . username ,cmdText . Replace ( "'" ,"''" ) ,parameters ,UserInfoMation . TypeOfOper );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        public static void SaveLog ( string cmdText ,params SqlParameter [ ] parameters )
        {
            if ( cmdText . Contains ( "R_LOG" ) )
                return;
            string param = string . Empty;
            if ( parameters . Length > 0 )
            {
                for ( int i = 0 ; i < parameters . Length ; i++ )
                {
                    if ( param == string . Empty )
                        param = " [ " + parameters [ i ] . ToString ( ) + ":" + parameters [ i ] . Value + " ] ";
                    else
                        param = param + " [ " + parameters [ i ] . ToString ( ) + ":" + parameters [ i ] . Value + " ] ";
                }
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_LOG (" );
            strSql . Append ( "LOG001,LOG002,LOG003,LOG004,LOG005,LOG006) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}',GETDATE(),'{2}','{3}','{4}') " ,UserInfoMation . tableName ,UserInfoMation . username ,cmdText . Replace ( "'" ,"''" ) ,param ,UserInfoMation . TypeOfOper );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 写操作日志到数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        public static void SaveLog ( string cmdText , object [ ] parameters )
        {
            if ( cmdText . Contains ( "R_LOG" ) )
                return;
            string param = string . Empty;
            SqlParameter [ ] parameter = ( SqlParameter [ ] ) parameters;
            if ( parameter . Length > 0 )
            {
                for ( int i = 0 ; i < parameter . Length ; i++ )
                {
                    if ( param == string . Empty )
                        param = " [ " + parameter [ i ] . ToString ( ) + ":" + parameter [ i ] . Value + " ] ";
                    else
                        param = param + " [ " + parameter [ i ] . ToString ( ) + ":" + parameter [ i ] . Value + " ] ";
                }
            }

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_LOG (" );
            strSql . Append ( "LOG001,LOG002,LOG003,LOG004,LOG005,LOG006) " );
            strSql . Append ( "VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}',GETDATE(),'{2}','{3}','{4}') " ,UserInfoMation . tableName ,UserInfoMation . username ,cmdText . Replace ( "'" ,"''" ) ,param ,UserInfoMation . TypeOfOper );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }


    }
}
