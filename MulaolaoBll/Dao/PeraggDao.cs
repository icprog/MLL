using System . Data;
using System . Text;
using StudentMgr;
using System;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class PeraggDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetDataTableRead ( string userName,int year  )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT 'R_376' CA001,'{0}' CA016,MONTH(XZ013) CA002,XZ005 CA003,XZ006 CA004,XZ007 CA005,XZ021 CA006,XZ023 CA007,XZ029 CA008,XZ008 CA011,XZ009 CA012,XZ010 CA013,XZ011 CA014,XZ024 CA015,{1} CA017,XZ030 CA019,XZ031 CA018 FROM R_PQXZ WHERE XZ004='{0}' AND YEAR(XZ013)={1} ORDER BY MONTH(XZ013) " ,userName ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool GeneralTable (  string userName ,int year )
        {
            DataTable table = GetDataTableRead ( userName ,year );
            if ( table == null && table . Rows . Count < 1 )
                return false;

            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . PeraggEntity _model = new MulaolaoLibrary . PeraggEntity ( );

            _model.CA001 = getOdd ( userName );
            if ( string . IsNullOrEmpty ( _model . CA001 ) )
                _model . CA001 = getOdd ( );

            DataTable dt = getTableWhether ( _model . CA001 );

            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . CA002 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA002" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CA002" ] . ToString ( ) );
                _model . CA003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA003" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA003" ] . ToString ( ) );
                _model . CA004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA004" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA004" ] . ToString ( ) );
                _model . CA005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA005" ] . ToString ( ) );
                _model . CA006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA006" ] . ToString ( ) );
                _model . CA007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA007" ] . ToString ( ) );
                _model . CA008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA008" ] . ToString ( ) );
                _model . CA009 = 0;
                _model . CA010 = 0;
                _model . CA011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA011" ] . ToString ( ) );
                _model . CA012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA012" ] . ToString ( ) );
                _model . CA013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA013" ] . ToString ( ) );
                _model . CA014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA014" ] . ToString ( ) );
                _model . CA015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA015" ] . ToString ( ) );
                _model . CA016 = table . Rows [ i ] [ "CA016" ] . ToString ( );
                _model . CA017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA017" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CA017" ] . ToString ( ) );
                _model . CA018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA018" ] . ToString ( ) );
                _model . CA019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CA019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "CA019" ] . ToString ( ) );
                _model . CA020 = 0;

                if ( dt == null || dt . Rows . Count < 1 )
                    add_pqca ( SQLString ,strSql ,_model );
                else
                {
                    if ( dt . Select ( "CA016='" + _model . CA016 + "' AND CA002='" + _model . CA002 + "' AND CA017='" + _model . CA017 + "'" ) . Length > 0 )
                    {
                        _model . idx = string . IsNullOrEmpty ( dt . Select ( "CA016='" + _model . CA016 + "' AND CA002='" + _model . CA002 + "' AND CA017='" + _model . CA017 + "'" ) [ 0 ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Select ( "CA016='" + _model . CA016 + "' AND CA002='" + _model . CA002 + "' AND CA017='" + _model . CA017 + "'" ) [ 0 ] [ "idx" ] . ToString ( ) );
                        edit_pqca ( SQLString ,strSql ,_model );
                    }
                    else
                        add_pqca ( SQLString ,strSql ,_model );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        DataTable getTableWhether ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CA016,CA002,CA017 FROM R_PQCA " );
            strSql . AppendFormat ( "WHERE CA001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_pqca ( Hashtable SQLString,StringBuilder strSql,MulaolaoLibrary.PeraggEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQCA (" );
            strSql . Append ( "CA001,CA002,CA016,CA017,CA003,CA004,CA005,CA006,CA007,CA008,CA009,CA010,CA011,CA012,CA013,CA014,CA015,CA018,CA019,CA020)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@CA001,@CA002,@CA016,@CA017,@CA003,@CA004,@CA005,@CA006,@CA007,@CA008,@CA009,@CA010,@CA011,@CA012,@CA013,@CA014,@CA015,@CA018,@CA019,@CA020)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CA001", SqlDbType.NVarChar,50),
                    new SqlParameter("@CA002", SqlDbType.Int,4),
                    new SqlParameter("@CA016", SqlDbType.NVarChar,50),
                    new SqlParameter("@CA017", SqlDbType.Int,4),
                    new SqlParameter("@CA003", SqlDbType.Decimal,9),
                    new SqlParameter("@CA004", SqlDbType.Decimal,9),
                    new SqlParameter("@CA005", SqlDbType.Decimal,9),
                    new SqlParameter("@CA006", SqlDbType.Decimal,9),
                    new SqlParameter("@CA007", SqlDbType.Decimal,9),
                    new SqlParameter("@CA008", SqlDbType.Decimal,9),
                    new SqlParameter("@CA009", SqlDbType.Decimal,9),
                    new SqlParameter("@CA010", SqlDbType.Decimal,9),
                    new SqlParameter("@CA011", SqlDbType.Decimal,9),
                    new SqlParameter("@CA012", SqlDbType.Decimal,9),
                    new SqlParameter("@CA013", SqlDbType.Decimal,9),
                    new SqlParameter("@CA014", SqlDbType.Decimal,9),
                    new SqlParameter("@CA015", SqlDbType.Decimal,9),
                    new SqlParameter("@CA018", SqlDbType.Decimal,9),
                    new SqlParameter("@CA019", SqlDbType.Decimal,9),
                    new SqlParameter("@CA020", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . CA001;
            parameters [ 1 ] . Value = model . CA002;
            parameters [ 2 ] . Value = model . CA016;
            parameters [ 3 ] . Value = model . CA017;
            parameters [ 4 ] . Value = model . CA003;
            parameters [ 5 ] . Value = model . CA004;
            parameters [ 6 ] . Value = model . CA005;
            parameters [ 7 ] . Value = model . CA006;
            parameters [ 8 ] . Value = model . CA007;
            parameters [ 9 ] . Value = model . CA008;
            parameters [ 10 ] . Value = model . CA009;
            parameters [ 11 ] . Value = model . CA010;
            parameters [ 12 ] . Value = model . CA011;
            parameters [ 13 ] . Value = model . CA012;
            parameters [ 14 ] . Value = model . CA013;
            parameters [ 15 ] . Value = model . CA014;
            parameters [ 16 ] . Value = model . CA015;
            parameters [ 17 ] . Value = model . CA018;
            parameters [ 18 ] . Value = model . CA019;
            parameters [ 19 ] . Value = model . CA020;

            SQLString . Add ( strSql ,parameters );
        }
        
        void edit_pqca ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PeraggEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQCA SET " );
            strSql . Append ( "CA003=@CA003," );
            strSql . Append ( "CA004=@CA004," );
            strSql . Append ( "CA005=@CA005," );
            strSql . Append ( "CA006=@CA006," );
            strSql . Append ( "CA007=@CA007," );
            strSql . Append ( "CA008=@CA008," );
            strSql . Append ( "CA011=@CA011," );
            strSql . Append ( "CA012=@CA012," );
            strSql . Append ( "CA013=@CA013," );
            strSql . Append ( "CA014=@CA014," );
            strSql . Append ( "CA015=@CA015," );
            strSql . Append ( "CA010=@CA010," );
            strSql . Append ( "CA018=@CA018," );
            strSql . Append ( "CA019=@CA019," );
            strSql . Append ( "CA020=@CA020 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CA003", SqlDbType.Decimal,9),
                    new SqlParameter("@CA004", SqlDbType.Decimal,9),
                    new SqlParameter("@CA005", SqlDbType.Decimal,9),
                    new SqlParameter("@CA006", SqlDbType.Decimal,9),
                    new SqlParameter("@CA007", SqlDbType.Decimal,9),
                    new SqlParameter("@CA008", SqlDbType.Decimal,9),
                    new SqlParameter("@CA011", SqlDbType.Decimal,9),
                    new SqlParameter("@CA012", SqlDbType.Decimal,9),
                    new SqlParameter("@CA013", SqlDbType.Decimal,9),
                    new SqlParameter("@CA014", SqlDbType.Decimal,9),
                    new SqlParameter("@CA015", SqlDbType.Decimal,9),
                    new SqlParameter("@CA010", SqlDbType.Decimal,9),
                    new SqlParameter("@CA018", SqlDbType.Decimal,9),
                    new SqlParameter("@CA019", SqlDbType.Decimal,9),
                    new SqlParameter("@CA020", SqlDbType.Decimal,9),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CA003;
            parameters [ 1 ] . Value = model . CA004;
            parameters [ 2 ] . Value = model . CA005;
            parameters [ 3 ] . Value = model . CA006;
            parameters [ 4 ] . Value = model . CA007;
            parameters [ 5 ] . Value = model . CA008;
            parameters [ 6 ] . Value = model . CA011;
            parameters [ 7 ] . Value = model . CA012;
            parameters [ 8 ] . Value = model . CA013;
            parameters [ 9 ] . Value = model . CA014;
            parameters [ 10 ] . Value = model . CA015;
            parameters [ 11 ] . Value = model . CA010;
            parameters [ 12 ] . Value = model . CA018;
            parameters [ 13 ] . Value = model . CA019;
            parameters [ 14 ] . Value = model . CA020;
            parameters [ 15 ] . Value = model . idx;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="userName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,CA001,CA002,CA003,CA004,CA005,CA006,CA008,CA009,CA010,CA011,CA012,CA013,CA014,CA015,CA016,CA017,CA018,CA019,CA020 FROM R_PQCA WHERE 1=2" );

            return SqlHelper . UpdateToSql ( table ,strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 查询已有的单号
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string getOdd ( string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CA001 FROM R_PQCA WHERE CA016='{0}'" ,userName );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CA001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "CA001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 获取新的单号
        /// </summary>
        /// <returns></returns>
        string getOdd ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(CA001) CA001 FROM R_PQCA " );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "CA001" ] . ToString ( ) ) )
                    return "R_376-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "CA001" ] . ToString ( ) . Substring ( 6 ,8 ) . Equals ( Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) ) )
                        return "R_376-" + ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "CA001" ] . ToString ( ) . Substring ( 6 ,11 ) ) + 1 ) . ToString ( );
                    else
                        return "R_376-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return "R_376-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable tableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CA001,CA002,CA003,CA004,CA005,CA006,CA007,CA008,CA009,CA010,CA011,CA012,CA013,CA014,CA015,CA016,CA017,CA018,CA019,CA020,CONVERT(DECIMAL(18,5),CA003/day(dateadd(d,-day(CONVERT(DATE,CONVERT(VARCHAR,CA017)+'-'+CONVERT(VARCHAR,CA002)+'-'+'01')),dateadd(m,1,CONVERT(DATE,CONVERT(VARCHAR,CA017)+'-'+CONVERT(VARCHAR,CA002)+'-'+'01'))))) U0 FROM R_PQCA " );
            strSql . AppendFormat ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT XZ004 FROM R_PQXZ" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable getTableOnly ( string columns )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT {0} FROM R_PQCA ORDER BY {0} DESC" ,columns );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT CA001,CA016,CA017 FROM R_PQCA WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CA001,CA016,CA017 FROM (SELECT ROW_NUMBER() OVER(ORDER BY T.CA001) AS Row ,T.* FROM (SELECT DISTINCT CA001,CA016,CA017 FROM R_PQCA WHERE {0}) T) TT WHERE TT.Row BETWEEN {1} AND {2}" ,strWhere ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCA " );
            strSql . AppendFormat ( "WHERE CA001='{0}'" ,oddNum );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

    }
}
