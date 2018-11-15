using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class PowerDao
    {
        /// <summary>
        /// 获取人员信息和部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA001,DBA002,DAA002 FROM TPADBA A INNER JOIN TPADAA B ON A.DBA005=B.DAA001 WHERE DBA001!='DS' AND DBA006='是' order by DBA002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取程序信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CX01,CX02 FROM R_MLLCXMC WHERE CX01!='R_ALL' ORDER BY CX01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CX02,DBB001,DBB002,DBB003,DBB004,DBB005,DBB006,DBB007,DBB008,DBB009,DBB010,DBB011,DBB012,DBB013,DBB014,DBB015,DBB016,DBB017 FROM R_DBB A,R_MLLCXMC B WHERE A.DBB002=B.CX01 AND DBB001='{0}'" ,userNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_DBB (DBB001,DBB002,DBB003,DBB004,DBB005,DBB006,DBB007,DBB008,DBB009,DBB010,DBB011,DBB012,DBB013,DBB014,DBB015,DBB016,DBB017) " );
            strSql . Append ( "VALUES (@DBB001,@DBB002,@DBB003,@DBB004,@DBB005,@DBB006,@DBB007,@DBB008,@DBB009,@DBB010,@DBB011,@DBB012,@DBB013,@DBB014,@DBB015,@DBB016,@DBB017)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DBB001",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB002",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB003",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB004",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB005",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB006",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB007",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB008",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB009",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB010",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB011",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB012",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB013",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB014",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB015",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB016",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . DBB001;
            parameter [ 1 ] . Value = _model . DBB002;
            parameter [ 2 ] . Value = _model . DBB003;
            parameter [ 3 ] . Value = _model . DBB004;
            parameter [ 4 ] . Value = _model . DBB005;
            parameter [ 5 ] . Value = _model . DBB006;
            parameter [ 6 ] . Value = _model . DBB007;
            parameter [ 7 ] . Value = _model . DBB008;
            parameter [ 8 ] . Value = _model . DBB009;
            parameter [ 9 ] . Value = _model . DBB010;
            parameter [ 10 ] . Value = _model . DBB011;
            parameter [ 11 ] . Value = _model . DBB012;
            parameter [ 12 ] . Value = _model . DBB013;
            parameter [ 13 ] . Value = _model . DBB014;
            parameter [ 14 ] . Value = _model . DBB015;
            parameter [ 15 ] . Value = _model . DBB016;
            parameter [ 16 ] . Value = _model . DBB017;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_DBB SET " );
            strSql . Append ( "DBB003=@DBB003," );
            strSql . Append ( "DBB004=@DBB004," );
            strSql . Append ( "DBB005=@DBB005," );
            strSql . Append ( "DBB006=@DBB006," );
            strSql . Append ( "DBB007=@DBB007," );
            strSql . Append ( "DBB008=@DBB008," );
            strSql . Append ( "DBB009=@DBB009," );
            strSql . Append ( "DBB010=@DBB010," );
            strSql . Append ( "DBB011=@DBB011," );
            strSql . Append ( "DBB012=@DBB012," );
            strSql . Append ( "DBB013=@DBB013," );
            strSql . Append ( "DBB014=@DBB014," );
            strSql . Append ( "DBB015=@DBB015," );
            strSql . Append ( "DBB016=@DBB016," );
            strSql . Append ( "DBB017=@DBB017 " );
            strSql . Append ( "WHERE DBB001=@DBB001 AND " );
            strSql . Append ( "DBB002=@DBB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@DBB001",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB002",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB003",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB004",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB005",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB006",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB007",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB008",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB009",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB010",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB011",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB012",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB013",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB014",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB015",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB016",SqlDbType.NVarChar,20),
                new SqlParameter("@DBB017",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . DBB001;
            parameter [ 1 ] . Value = _model . DBB002;
            parameter [ 2 ] . Value = _model . DBB003;
            parameter [ 3 ] . Value = _model . DBB004;
            parameter [ 4 ] . Value = _model . DBB005;
            parameter [ 5 ] . Value = _model . DBB006;
            parameter [ 6 ] . Value = _model . DBB007;
            parameter [ 7 ] . Value = _model . DBB008;
            parameter [ 8 ] . Value = _model . DBB009;
            parameter [ 9 ] . Value = _model . DBB010;
            parameter [ 10 ] . Value = _model . DBB011;
            parameter [ 11 ] . Value = _model . DBB012;
            parameter [ 12 ] . Value = _model . DBB013;
            parameter [ 13 ] . Value = _model . DBB014;
            parameter [ 14 ] . Value = _model . DBB015;
            parameter [ 15 ] . Value = _model . DBB016;
            parameter [ 16 ] . Value = _model . DBB017;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . PowerEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_DBB WHERE DBB001='{0}' AND DBB002='{1}'" ,_model . DBB001 ,_model . DBB002 );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

    }
}
