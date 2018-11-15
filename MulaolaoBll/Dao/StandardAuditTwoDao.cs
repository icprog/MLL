using System;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace MulaolaoBll . Dao
{
    public class StandardAuditTwoDao
    {
        /// <summary>
        /// get max oddNum from r_pqcb
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CD001) CD001 FROM R_PQCD " );
            strSql . AppendFormat ( "WHERE CD001 LIKE 'R_483-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CD001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_483-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_483-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_483-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// get data from r_pqcc to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CE001,CE002,CE003,CE004,CE005,CE006,CE007,CE008,CE009,CE010,CE011,CE012,CE013,CE014,CE015,CE016,CE017,CE018,CE019,CE020,CE021,CE022,CE023 FROM R_PQCE " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from r_pqcb and r_pqcc, and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCD " );
            strSql . AppendFormat ( "WHERE CD001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_483" ,"丝、移、热印生产首件标准样审核确认记录表(R_483)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCE " );
            strSql . AppendFormat ( "WHERE CE001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_483" ,"丝、移、热印生产首件标准样审核确认记录表(R_483)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_483" ,"丝、移、热印生产首件标准样审核确认记录表(R_483)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditTwoCDEntity _cd ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _cd . CD001 = getOddNum ( );
            add_pqcb ( SQLString ,strSql ,_cd );
            SQLString . Add ( Drity . DrityOfComparation ( "R_483" ,"丝、移、热印生产首件标准样审核确认记录表(R_483)" ,logins ,Drity . GetDt ( ) ,_cd . CD001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );

            MulaolaoLibrary . StandardAuditTwoCEEntity _ce = new MulaolaoLibrary . StandardAuditTwoCEEntity ( );
            _ce . CE001 = _cd . CD001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CE002 = table . Rows [ i ] [ "CE002" ] . ToString ( );
                _ce . CE003 = table . Rows [ i ] [ "CE003" ] . ToString ( );
                _ce . CE004 = table . Rows [ i ] [ "CE004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE005" ] . ToString ( ) ) )
                    _ce . CE005 = null;
                else
                    _ce . CE005 = Convert . ToDateTime ( table . Rows [ i ] [ "CE005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE006" ] . ToString ( ) ) )
                    _ce . CE006 = null;
                else
                    _ce . CE006 = Convert . ToDateTime ( table . Rows [ i ] [ "CE006" ] );
                _ce . CE007 = table . Rows [ i ] [ "CE007" ] . ToString ( );
                _ce . CE008 = table . Rows [ i ] [ "CE008" ] . ToString ( );
                _ce . CE009 = table . Rows [ i ] [ "CE009" ] . ToString ( );
                _ce . CE010 = table . Rows [ i ] [ "CE010" ] . ToString ( );
                _ce . CE011 = table . Rows [ i ] [ "CE011" ] . ToString ( );
                _ce . CE012 = table . Rows [ i ] [ "CE012" ] . ToString ( );
                _ce . CE013 = table . Rows [ i ] [ "CE013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE014" ] . ToString ( ) ) )
                    _ce . CE014 = null;
                else
                    _ce . CE014 = Convert . ToDateTime ( table . Rows [ i ] [ "CE014" ] );
                _ce . CE015 = table . Rows [ i ] [ "CE015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE016" ] . ToString ( ) ) )
                    _ce . CE016 = null;
                else
                    _ce . CE016 = Convert . ToDateTime ( table . Rows [ i ] [ "CE016" ] );
                _ce . CE017 = table . Rows [ i ] [ "CE017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE018" ] . ToString ( ) ) )
                    _ce . CE018 = null;
                else
                    _ce . CE018 = Convert . ToDateTime ( table . Rows [ i ] [ "CE018" ] );
                _ce . CE019 = table . Rows [ i ] [ "CE019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE020" ] . ToString ( ) ) )
                    _ce . CE020 = null;
                else
                    _ce . CE020 = Convert . ToDateTime ( table . Rows [ i ] [ "CE020" ] );
                _ce . CE021 = table . Rows [ i ] [ "CE021" ] . ToString ( );
                _ce . CE022 = table . Rows [ i ] [ "CE022" ] . ToString ( );
                _ce . CE023 = table . Rows [ i ] [ "CE023" ] . ToString ( );
                add_pqcc ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_pqcb ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTwoCDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCD(" );
            strSql . Append ( "CD001,CD002,CD003,CD004,CD005,CD006,CD007,CD008,CD009,CD010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CD001,@CD002,@CD003,@CD004,@CD005,@CD006,@CD007,@CD008,@CD009,@CD010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CD004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD005", SqlDbType.Int,4),
                    new SqlParameter("@CD006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CD001;
            parameters [ 1 ] . Value = model . CD002;
            parameters [ 2 ] . Value = model . CD003;
            parameters [ 3 ] . Value = model . CD004;
            parameters [ 4 ] . Value = model . CD005;
            parameters [ 5 ] . Value = model . CD006;
            parameters [ 6 ] . Value = model . CD007;
            parameters [ 7 ] . Value = model . CD008;
            parameters [ 8 ] . Value = model . CD009;
            parameters [ 9 ] . Value = model . CD010;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTwoCEEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCE(" );
            strSql . Append ( "CE001,CE002,CE003,CE004,CE005,CE006,CE007,CE008,CE009,CE010,CE011,CE012,CE013,CE014,CE015,CE016,CE017,CE018,CE019,CE020,CE021,CE022,CE023)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CE001,@CE002,@CE003,@CE004,@CE005,@CE006,@CE007,@CE008,@CE009,@CE010,@CE011,@CE012,@CE013,@CE014,@CE015,@CE016,@CE017,@CE018,@CE019,@CE020,@CE021,@CE022,@CE023)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CE001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE005", SqlDbType.Date,3),
                    new SqlParameter("@CE006", SqlDbType.Date,3),
                    new SqlParameter("@CE007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE014", SqlDbType.Date,3),
                    new SqlParameter("@CE015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE016", SqlDbType.Date,3),
                    new SqlParameter("@CE017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE018", SqlDbType.Date,3),
                    new SqlParameter("@CE019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE020", SqlDbType.Date,3),
                    new SqlParameter("@CE021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CE022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE023", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CE001;
            parameters [ 1 ] . Value = model . CE002;
            parameters [ 2 ] . Value = model . CE003;
            parameters [ 3 ] . Value = model . CE004;
            parameters [ 4 ] . Value = model . CE005;
            parameters [ 5 ] . Value = model . CE006;
            parameters [ 6 ] . Value = model . CE007;
            parameters [ 7 ] . Value = model . CE008;
            parameters [ 8 ] . Value = model . CE009;
            parameters [ 9 ] . Value = model . CE010;
            parameters [ 10 ] . Value = model . CE011;
            parameters [ 11 ] . Value = model . CE012;
            parameters [ 12 ] . Value = model . CE013;
            parameters [ 13 ] . Value = model . CE014;
            parameters [ 14 ] . Value = model . CE015;
            parameters [ 15 ] . Value = model . CE016;
            parameters [ 16 ] . Value = model . CE017;
            parameters [ 17 ] . Value = model . CE018;
            parameters [ 18 ] . Value = model . CE019;
            parameters [ 19 ] . Value = model . CE020;
            parameters [ 20 ] . Value = model . CE021;
            parameters [ 21 ] . Value = model . CE022;
            parameters [ 22 ] . Value = model . CE023;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CE001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditTwoCDEntity _cd ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqcb ( SQLString ,strSql ,_cd );
            SQLString . Add ( Drity . DrityOfComparation ( "R_483" ,"丝、移、热印生产首件标准样审核确认记录表(R_483)" ,logins ,Drity . GetDt ( ) ,_cd . CD001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . StandardAuditTwoCEEntity _ce = new MulaolaoLibrary . StandardAuditTwoCEEntity ( );
            _ce . CE001 = _cd . CD001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CE002 = table . Rows [ i ] [ "CE002" ] . ToString ( );
                _ce . CE003 = table . Rows [ i ] [ "CE003" ] . ToString ( );
                _ce . CE004 = table . Rows [ i ] [ "CE004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE005" ] . ToString ( ) ) )
                    _ce . CE005 = null;
                else
                    _ce . CE005 = Convert . ToDateTime ( table . Rows [ i ] [ "CE005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE006" ] . ToString ( ) ) )
                    _ce . CE006 = null;
                else
                    _ce . CE006 = Convert . ToDateTime ( table . Rows [ i ] [ "CE006" ] );
                _ce . CE007 = table . Rows [ i ] [ "CE007" ] . ToString ( );
                _ce . CE008 = table . Rows [ i ] [ "CE008" ] . ToString ( );
                _ce . CE009 = table . Rows [ i ] [ "CE009" ] . ToString ( );
                _ce . CE010 = table . Rows [ i ] [ "CE010" ] . ToString ( );
                _ce . CE011 = table . Rows [ i ] [ "CE011" ] . ToString ( );
                _ce . CE012 = table . Rows [ i ] [ "CE012" ] . ToString ( );
                _ce . CE013 = table . Rows [ i ] [ "CE013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE014" ] . ToString ( ) ) )
                    _ce . CE014 = null;
                else
                    _ce . CE014 = Convert . ToDateTime ( table . Rows [ i ] [ "CE014" ] );
                _ce . CE015 = table . Rows [ i ] [ "CE015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE016" ] . ToString ( ) ) )
                    _ce . CE016 = null;
                else
                    _ce . CE016 = Convert . ToDateTime ( table . Rows [ i ] [ "CE016" ] );
                _ce . CE017 = table . Rows [ i ] [ "CE017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE018" ] . ToString ( ) ) )
                    _ce . CE018 = null;
                else
                    _ce . CE018 = Convert . ToDateTime ( table . Rows [ i ] [ "CE018" ] );
                _ce . CE019 = table . Rows [ i ] [ "CE019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CE020" ] . ToString ( ) ) )
                    _ce . CE020 = null;
                else
                    _ce . CE020 = Convert . ToDateTime ( table . Rows [ i ] [ "CE020" ] );
                _ce . CE021 = table . Rows [ i ] [ "CE021" ] . ToString ( );
                _ce . CE022 = table . Rows [ i ] [ "CE022" ] . ToString ( );
                _ce . CE023 = table . Rows [ i ] [ "CE023" ] . ToString ( );
                _ce . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _ce . idx < 1 )
                    add_pqcc ( SQLString ,strSql ,_ce ,logins );
                else
                    edit_pqcc ( SQLString ,strSql ,_ce ,logins );
            }

            foreach ( string s in strList )
            {
                _ce . idx = Convert . ToInt32 ( s );
                delete_pqcc ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pqcb ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTwoCDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCD set " );
            strSql . Append ( "CD002=@CD002," );
            strSql . Append ( "CD003=@CD003," );
            strSql . Append ( "CD004=@CD004," );
            strSql . Append ( "CD005=@CD005," );
            strSql . Append ( "CD006=@CD006," );
            strSql . Append ( "CD007=@CD007," );
            strSql . Append ( "CD008=@CD008," );
            strSql . Append ( "CD009=@CD009," );
            strSql . Append ( "CD010=@CD010 " );
            strSql . Append ( " where CD001=@CD001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CD004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD005", SqlDbType.Int,4),
                    new SqlParameter("@CD006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CD010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CD001;
            parameters [ 1 ] . Value = model . CD002;
            parameters [ 2 ] . Value = model . CD003;
            parameters [ 3 ] . Value = model . CD004;
            parameters [ 4 ] . Value = model . CD005;
            parameters [ 5 ] . Value = model . CD006;
            parameters [ 6 ] . Value = model . CD007;
            parameters [ 7 ] . Value = model . CD008;
            parameters [ 8 ] . Value = model . CD009;
            parameters [ 9 ] . Value = model . CD010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTwoCEEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCE set " );
            strSql . Append ( "CE001=@CE001," );
            strSql . Append ( "CE002=@CE002," );
            strSql . Append ( "CE003=@CE003," );
            strSql . Append ( "CE004=@CE004," );
            strSql . Append ( "CE005=@CE005," );
            strSql . Append ( "CE006=@CE006," );
            strSql . Append ( "CE007=@CE007," );
            strSql . Append ( "CE008=@CE008," );
            strSql . Append ( "CE009=@CE009," );
            strSql . Append ( "CE010=@CE010," );
            strSql . Append ( "CE011=@CE011," );
            strSql . Append ( "CE012=@CE012," );
            strSql . Append ( "CE013=@CE013," );
            strSql . Append ( "CE014=@CE014," );
            strSql . Append ( "CE015=@CE015," );
            strSql . Append ( "CE016=@CE016," );
            strSql . Append ( "CE017=@CE017," );
            strSql . Append ( "CE018=@CE018," );
            strSql . Append ( "CE019=@CE019," );
            strSql . Append ( "CE020=@CE020," );
            strSql . Append ( "CE021=@CE021," );
            strSql . Append ( "CE022=@CE022," ); 
            strSql . Append ( "CE023=@CE023 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CE001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE005", SqlDbType.Date,3),
                    new SqlParameter("@CE006", SqlDbType.Date,3),
                    new SqlParameter("@CE007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE014", SqlDbType.Date,3),
                    new SqlParameter("@CE015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE016", SqlDbType.Date,3),
                    new SqlParameter("@CE017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE018", SqlDbType.Date,3),
                    new SqlParameter("@CE019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE020", SqlDbType.Date,3),
                    new SqlParameter("@CE021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CE022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CE023", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CE001;
            parameters [ 1 ] . Value = model . CE002;
            parameters [ 2 ] . Value = model . CE003;
            parameters [ 3 ] . Value = model . CE004;
            parameters [ 4 ] . Value = model . CE005;
            parameters [ 5 ] . Value = model . CE006;
            parameters [ 6 ] . Value = model . CE007;
            parameters [ 7 ] . Value = model . CE008;
            parameters [ 8 ] . Value = model . CE009;
            parameters [ 9 ] . Value = model . CE010;
            parameters [ 10 ] . Value = model . CE011;
            parameters [ 11 ] . Value = model . CE012;
            parameters [ 12 ] . Value = model . CE013;
            parameters [ 13 ] . Value = model . CE014;
            parameters [ 14 ] . Value = model . CE015;
            parameters [ 15 ] . Value = model . CE016;
            parameters [ 16 ] . Value = model . CE017;
            parameters [ 17 ] . Value = model . CE018;
            parameters [ 18 ] . Value = model . CE019;
            parameters [ 19 ] . Value = model . CE020;
            parameters [ 20 ] . Value = model . CE021;
            parameters [ 21 ] . Value = model . CE022;
            parameters [ 22 ] . Value = model . CE023;
            parameters [ 23 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CE001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
        }

        void delete_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTwoCEEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCE " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CE001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"编辑删除" ) ,null );
        }

        /// <summary>
        /// get product info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF06 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 AND RES05='执行' ORDER BY PQF01 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get user data from r_pqcb
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CD007,CD008,CD009,CD010 FROM R_PQCD " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get product parts from r_pqp
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPart ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GS07  FROM (SELECT GS07 FROM R_PQP WHERE GS01='{0}' AND GS07 IS NOT NULL AND GS07!='' UNION SELECT GS35 FROM R_PQP WHERE GS01='{0}' AND  GS35 IS NOT NULL AND GS35!='' UNION SELECT GS56 FROM R_PQP WHERE GS01='{0}' AND  GS56 IS NOT NULL AND GS56!='') A ORDER BY GS07" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get one column datasource from r_pqcb
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CD001,CD002,CD003,CD009 FROM R_PQCD ORDER BY CD001,CD002,CD003,CD009" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get count from r_pqcb
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM (SELECT DISTINCT CD001,CD002,CD003,CD009 FROM R_PQCD WHERE {0}) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data for page from r_pqcb
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CD001,CD002,CD003,CD009,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CD001 DESC )" );
            strSql . Append ( "AS Row,T.* FROM R_PQCD T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON CD001=RES06" );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcb
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditTwoCDEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CD001,CD002,CD003,CD004,CD005,CD006,CD007,CD008,CD009,CD010 FROM R_PQCD WHERE CD001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getDataRow ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . StandardAuditTwoCDEntity getDataRow ( DataRow row )
        {
            MulaolaoLibrary . StandardAuditTwoCDEntity model = new MulaolaoLibrary . StandardAuditTwoCDEntity ( );
            if ( row != null )
            {
                if ( row [ "CD001" ] != null )
                    model . CD001 = row [ "CD001" ] . ToString ( );
                if ( row [ "CD002" ] != null )
                    model . CD002 = row [ "CD002" ] . ToString ( );
                if ( row [ "CD003" ] != null )
                    model . CD003 = row [ "CD003" ] . ToString ( );
                if ( row [ "CD004" ] != null )
                    model . CD004 = row [ "CD004" ] . ToString ( );
                if ( row [ "CD005" ] != null && row [ "CD005" ] . ToString ( ) != string . Empty )
                    model . CD005 = int . Parse ( row [ "CD005" ] . ToString ( ) );
                if ( row [ "CD006" ] != null )
                    model . CD006 = row [ "CD006" ] . ToString ( );
                if ( row [ "CD007" ] != null )
                    model . CD007 = row [ "CD007" ] . ToString ( );
                if ( row [ "CD008" ] != null )
                    model . CD008 = row [ "CD008" ] . ToString ( );
                if ( row [ "CD009" ] != null )
                    model . CD009 = row [ "CD009" ] . ToString ( );
                if ( row [ "CD010" ] != null )
                    model . CD010 = row [ "CD010" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTableOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CD001,CD002,CD003,CD004,CD005,CD006,CD007,CD008,CD009,CD010 FROM R_PQCD " );
            strSql . AppendFormat ( "WHERE CD001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTableTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CE001,CE002,CE003,CE004,CE005,CE006,CE007,CE008,CE009,CE010,CE011,CE012,CE013,CE014,CE015,CE016,CE017,CE018,CE019,CE020,CE021,CE022,CE023 FROM R_PQCE " );
            strSql . AppendFormat ( "WHERE CE001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
