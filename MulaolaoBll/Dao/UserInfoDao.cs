using System;
using System . Text;
using StudentMgr;
using System . Data;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class UserInfoDao
    {
        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        public string getUserNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CONVERT(INT,SUBSTRING(DBA001,5,LEN(DBA001)-4))) DBA001 FROM TPADBA WHERE DBA001 LIKE 'MLL-%'" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT DBA001 FROM TPADBA WHERE DBA001 LIKE '%{0}%'" ,dt . Rows [ 0 ] [ "DBA001" ] . ToString ( ) );

                dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    string num = dt . Rows [ 0 ] [ "DBA001" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( num ) )
                        return "MLL-9000";
                    else
                        return "MLL-" + ( Convert . ToInt32 ( num . Substring ( 4 ,4 ) ) + 1 ) . ToString ( );
                }
                else
                    return "MLL-9000";
            }
            else
                return "MLL-9000";
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableDepart ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DAA001,DAA002 FROM TPADAA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA001,DBA002,DBA005,DBA006,B.DAA002,DBA028,DBA043,DBA960,DBA961 FROM TPADBA A INNER JOIN TPADAA B ON A.DBA005=B.DAA001 WHERE DBA001!='DS'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool Delete ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM TPADBA WHERE DBA001='{0}'" ,userNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . UserInfoEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO TPADBA (" );
            strSql . Append ( "DBA001,DBA002,DBA005,DBA006,DBA028,DBA043,DBA960) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@DBA001,@DBA002,@DBA005,@DBA006,@DBA028,@DBA043,@DBA960) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DBA001",SqlDbType.NVarChar),
                new SqlParameter("@DBA002",SqlDbType.NVarChar),
                new SqlParameter("@DBA005",SqlDbType.NVarChar),
                new SqlParameter("@DBA006",SqlDbType.NVarChar),
                new SqlParameter("@DBA028",SqlDbType.NVarChar),
                new SqlParameter("@DBA043",SqlDbType.NVarChar),
                new SqlParameter("@DBA960",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = _model . DBA001;
            parameter [ 1 ] . Value = _model . DBA002;
            parameter [ 2 ] . Value = _model . DBA005;
            parameter [ 3 ] . Value = _model . DBA006;
            parameter [ 4 ] . Value = _model . DBA028;
            parameter [ 5 ] . Value = _model . DBA043;
            parameter [ 6 ] . Value = _model . DBA960;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . UserInfoEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE TPADBA SET " );
            strSql . Append ( "DBA002=@DBA002," );
            strSql . Append ( "DBA005=@DBA005," );
            strSql . Append ( "DBA006=@DBA006," );
            strSql . Append ( "DBA028=@DBA028," );
            strSql . Append ( "DBA960=@DBA960 " );
            strSql . Append ( " WHERE DBA001=@DBA001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DBA001",SqlDbType.NVarChar),
                new SqlParameter("@DBA002",SqlDbType.NVarChar),
                new SqlParameter("@DBA005",SqlDbType.NVarChar),
                new SqlParameter("@DBA006",SqlDbType.NVarChar),
                new SqlParameter("@DBA028",SqlDbType.NVarChar),
                new SqlParameter("@DBA960",SqlDbType.NVarChar)
            };
            parameter [ 0 ] . Value = _model . DBA001;
            parameter [ 1 ] . Value = _model . DBA002;
            parameter [ 2 ] . Value = _model . DBA005;
            parameter [ 3 ] . Value = _model . DBA006;
            parameter [ 4 ] . Value = _model . DBA028;
            parameter [ 5 ] . Value = _model . DBA960;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        } 

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public bool Exists ( string userName ,string tel ,string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM TPADBA WHERE DBA002='{0}' AND DBA028='{1}' AND DBA001!='{2}'" ,userName ,tel ,userNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在此员工
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool Exists ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM TPADBA WHERE DBA001='{0}'" ,userNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 注销或反注销
        /// </summary>
        /// <param name="userNu"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool EditConell ( string userNu ,string state )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE TPADBA SET DBA043='{0}' WHERE DBA001='{1}'" ,state ,userNu );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}
