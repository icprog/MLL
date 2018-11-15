using System . Data;
using System . Text;
using StudentMgr;
using System;
using System . Collections;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace MulaolaoBll . Dao
{
    public class StandardAuditForDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getPro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01 CI012,PQF02 CI002,PQF03 CI004,PQF04 CI003,PQF06 CI019 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 AND RES05='执行' ORDER BY PQF01 DESC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get user data from r_pqch
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CH003,CH004,CH005,CH006 FROM R_PQCH " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqch
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditForCHEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CH001,CH002,CH003,CH004,CH005,CH006 FROM R_PQCH WHERE CH001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getDataRow ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . StandardAuditForCHEntity getDataRow ( DataRow row )
        {
            MulaolaoLibrary . StandardAuditForCHEntity model = new MulaolaoLibrary . StandardAuditForCHEntity ( );
            if ( row != null )
            {
                if ( row [ "CH001" ] != null )
                    model . CH001 = row [ "CH001" ] . ToString ( );
                if ( row [ "CH002" ] != null )
                    model . CH002 = row [ "CH002" ] . ToString ( );
                if ( row [ "CH003" ] != null )
                    model . CH003 = row [ "CH003" ] . ToString ( );
                if ( row [ "CH004" ] != null )
                    model . CH004 = row [ "CH004" ] . ToString ( );
                if ( row [ "CH005" ] != null )
                    model . CH005 = row [ "CH005" ] . ToString ( );
                if ( row [ "CH006" ] != null )
                    model . CH006 = row [ "CH006" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// get data from r_pqci to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CI001,CI002,CI003,CI004,CI005,CI006,CI007,CI008,CI009,CI010,CI011,CI012,CI013,CI014,CI015,CI016,CI017,CI018,CI019,CI020,CI021,CI024 FROM R_PQCI " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get max oddNum from r_pqch
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CH001) CH001 FROM R_PQCH " );
            strSql . AppendFormat ( "WHERE CH001 LIKE 'R_487-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CH001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_487-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_487-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_487-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// get one column datasource from r_pqch
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CH001,CH005 FROM R_PQCH ORDER BY CH001,CH005" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get count from r_pqch
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM (SELECT DISTINCT CH001,CH005 FROM R_PQCH WHERE {0}) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data for page from r_pqch
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CH001,CH005,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CH001 DESC )" );
            strSql . Append ( "AS Row,T.* FROM R_PQCH T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON CH001=RES06" );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete data from r_pqch and r_pqci, and write operation to r_pqbi
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCH " );
            strSql . AppendFormat ( "WHERE CH001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_487" ,"包装首件标准样审核确认记录表(R_487)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCI " );
            strSql . AppendFormat ( "WHERE CI001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_487" ,"包装首件标准样审核确认记录表(R_487)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_487" ,"包装首件标准样审核确认记录表(R_487)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditForCHEntity _cf ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _cf . CH001 = getOddNum ( );
            add_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_487" ,"包装首件标准样审核确认记录表(R_487)" ,logins ,Drity . GetDt ( ) ,_cf . CH001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );

            MulaolaoLibrary . StandardAuditForCIEntity _ce = new MulaolaoLibrary . StandardAuditForCIEntity ( );
            _ce . CI001 = _cf . CH001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CI002 = table . Rows [ i ] [ "CI002" ] . ToString ( );
                _ce . CI003 = table . Rows [ i ] [ "CI003" ] . ToString ( );
                _ce . CI004 = table . Rows [ i ] [ "CI004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI005" ] . ToString ( ) ) )
                    _ce . CI005 = null;
                else
                    _ce . CI005 = Convert . ToDateTime ( table . Rows [ i ] [ "CI005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI006" ] . ToString ( ) ) )
                    _ce . CI006 = null;
                else
                    _ce . CI006 = Convert . ToDateTime ( table . Rows [ i ] [ "CI006" ] );
                _ce . CI007 = table . Rows [ i ] [ "CI007" ] . ToString ( );
                _ce . CI008 = table . Rows [ i ] [ "CI008" ] . ToString ( );
                _ce . CI009 = table . Rows [ i ] [ "CI009" ] . ToString ( );
                _ce . CI010 = table . Rows [ i ] [ "CI010" ] . ToString ( );
                _ce . CI011 = table . Rows [ i ] [ "CI011" ] . ToString ( );
                _ce . CI012 = table . Rows [ i ] [ "CI012" ] . ToString ( );
                _ce . CI013 = table . Rows [ i ] [ "CI013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI014" ] . ToString ( ) ) )
                    _ce . CI014 = null;
                else
                    _ce . CI014 = Convert . ToDateTime ( table . Rows [ i ] [ "CI014" ] );
                _ce . CI015 = table . Rows [ i ] [ "CI015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI016" ] . ToString ( ) ) )
                    _ce . CI016 = null;
                else
                    _ce . CI016 = Convert . ToDateTime ( table . Rows [ i ] [ "CI016" ] );
                _ce . CI017 = table . Rows [ i ] [ "CI017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI018" ] . ToString ( ) ) )
                    _ce . CI018 = null;
                else
                    _ce . CI018 = Convert . ToDateTime ( table . Rows [ i ] [ "CI018" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI019" ] . ToString ( ) ) )
                    _ce . CI019 = null;
                else
                    _ce . CI019 = Convert . ToInt32 ( table . Rows [ i ] [ "CI019" ] );
                _ce . CI020 = table . Rows [ i ] [ "CI020" ] . ToString ( );
                _ce . CI021 = table . Rows [ i ] [ "CI021" ] . ToString ( );
                _ce . CI024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CI024" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CI024" ] . ToString ( ) );
                add_pqcg ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditForCHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCH(" );
            strSql . Append ( "CH001,CH003,CH004,CH005,CH006)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CH001,@CH003,@CH004,@CH005,@CH006)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CH001", SqlDbType.NVarChar,20),
                    //new SqlParameter("@CH002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CH004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH006", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . CH001;
            //parameters [ 1 ] . Value = model . CH002;
            parameters [ 1 ] . Value = model . CH003;
            parameters [ 2 ] . Value = model . CH004;
            parameters [ 3 ] . Value = model . CH005;
            parameters [ 4 ] . Value = model . CH006;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditForCIEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCI(" );
            strSql . Append ( "CI001,CI002,CI003,CI004,CI005,CI006,CI007,CI008,CI009,CI010,CI011,CI012,CI013,CI014,CI015,CI016,CI017,CI018,CI019,CI020,CI021,CI024)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CI001,@CI002,@CI003,@CI004,@CI005,@CI006,@CI007,@CI008,@CI009,@CI010,@CI011,@CI012,@CI013,@CI014,@CI015,@CI016,@CI017,@CI018,@CI019,@CI020,@CI021,@CI024)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CI001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI005", SqlDbType.Date,3),
                    new SqlParameter("@CI006", SqlDbType.Date,3),
                    new SqlParameter("@CI007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI014", SqlDbType.Date,3),
                    new SqlParameter("@CI015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI016", SqlDbType.Date,3),
                    new SqlParameter("@CI017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI018", SqlDbType.Date,3),
                    new SqlParameter("@CI019", SqlDbType.Int,4),
                    new SqlParameter("@CI020", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CI024", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CI001;
            parameters [ 1 ] . Value = model . CI002;
            parameters [ 2 ] . Value = model . CI003;
            parameters [ 3 ] . Value = model . CI004;
            parameters [ 4 ] . Value = model . CI005;
            parameters [ 5 ] . Value = model . CI006;
            parameters [ 6 ] . Value = model . CI007;
            parameters [ 7 ] . Value = model . CI008;
            parameters [ 8 ] . Value = model . CI009;
            parameters [ 9 ] . Value = model . CI010;
            parameters [ 10 ] . Value = model . CI011;
            parameters [ 11 ] . Value = model . CI012;
            parameters [ 12 ] . Value = model . CI013;
            parameters [ 13 ] . Value = model . CI014;
            parameters [ 14 ] . Value = model . CI015;
            parameters [ 15 ] . Value = model . CI016;
            parameters [ 16 ] . Value = model . CI017;
            parameters [ 17 ] . Value = model . CI018;
            parameters [ 18 ] . Value = model . CI019;
            parameters [ 19 ] . Value = model . CI020;
            parameters [ 20 ] . Value = model . CI021;
            parameters [ 21 ] . Value = model . CI024;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditForCHEntity _cf ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,_cf . CH001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . StandardAuditForCIEntity _ce = new MulaolaoLibrary . StandardAuditForCIEntity ( );
            _ce . CI001 = _cf . CH001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CI002 = table . Rows [ i ] [ "CI002" ] . ToString ( );
                _ce . CI003 = table . Rows [ i ] [ "CI003" ] . ToString ( );
                _ce . CI004 = table . Rows [ i ] [ "CI004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI005" ] . ToString ( ) ) )
                    _ce . CI005 = null;
                else
                    _ce . CI005 = Convert . ToDateTime ( table . Rows [ i ] [ "CI005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI006" ] . ToString ( ) ) )
                    _ce . CI006 = null;
                else
                    _ce . CI006 = Convert . ToDateTime ( table . Rows [ i ] [ "CI006" ] );
                _ce . CI007 = table . Rows [ i ] [ "CI007" ] . ToString ( );
                _ce . CI008 = table . Rows [ i ] [ "CI008" ] . ToString ( );
                _ce . CI009 = table . Rows [ i ] [ "CI009" ] . ToString ( );
                _ce . CI010 = table . Rows [ i ] [ "CI010" ] . ToString ( );
                _ce . CI011 = table . Rows [ i ] [ "CI011" ] . ToString ( );
                _ce . CI012 = table . Rows [ i ] [ "CI012" ] . ToString ( );
                _ce . CI013 = table . Rows [ i ] [ "CI013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI014" ] . ToString ( ) ) )
                    _ce . CI014 = null;
                else
                    _ce . CI014 = Convert . ToDateTime ( table . Rows [ i ] [ "CI014" ] );
                _ce . CI015 = table . Rows [ i ] [ "CI015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI016" ] . ToString ( ) ) )
                    _ce . CI016 = null;
                else
                    _ce . CI016 = Convert . ToDateTime ( table . Rows [ i ] [ "CI016" ] );
                _ce . CI017 = table . Rows [ i ] [ "CI017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI018" ] . ToString ( ) ) )
                    _ce . CI018 = null;
                else
                    _ce . CI018 = Convert . ToDateTime ( table . Rows [ i ] [ "CI018" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CI019" ] . ToString ( ) ) )
                    _ce . CI019 = null;
                else
                    _ce . CI019 = Convert . ToInt32 ( table . Rows [ i ] [ "CI019" ] );
                _ce . CI020 = table . Rows [ i ] [ "CI020" ] . ToString ( );
                _ce . CI021 = table . Rows [ i ] [ "CI021" ] . ToString ( );
                _ce . CI024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CI024" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CI024" ] . ToString ( ) );
                _ce . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _ce . idx < 1 )
                    add_pqcg ( SQLString ,strSql ,_ce ,logins );
                else
                    edit_pqcg ( SQLString ,strSql ,_ce ,logins );
            }

            foreach ( string s in strList )
            {
                _ce . idx = Convert . ToInt32 ( s );
                delete_pqcg ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditForCHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCH set " );
            strSql . Append ( "CH002=@CH002," );
            strSql . Append ( "CH003=@CH003," );
            strSql . Append ( "CH004=@CH004," );
            strSql . Append ( "CH005=@CH005," );
            strSql . Append ( "CH006=@CH006 " );
            strSql . Append ( " where CH001=@CH001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CH001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CH004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CH006", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . CH001;
            parameters [ 1 ] . Value = model . CH002;
            parameters [ 2 ] . Value = model . CH003;
            parameters [ 3 ] . Value = model . CH004;
            parameters [ 4 ] . Value = model . CH005;
            parameters [ 5 ] . Value = model . CH006;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditForCIEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCI set " );
            strSql . Append ( "CI001=@CI001," );
            strSql . Append ( "CI002=@CI002," );
            strSql . Append ( "CI003=@CI003," );
            strSql . Append ( "CI004=@CI004," );
            strSql . Append ( "CI005=@CI005," );
            strSql . Append ( "CI006=@CI006," );
            strSql . Append ( "CI007=@CI007," );
            strSql . Append ( "CI008=@CI008," );
            strSql . Append ( "CI009=@CI009," );
            strSql . Append ( "CI010=@CI010," );
            strSql . Append ( "CI011=@CI011," );
            strSql . Append ( "CI012=@CI012," );
            strSql . Append ( "CI013=@CI013," );
            strSql . Append ( "CI014=@CI014," );
            strSql . Append ( "CI015=@CI015," );
            strSql . Append ( "CI016=@CI016," );
            strSql . Append ( "CI017=@CI017," );
            strSql . Append ( "CI018=@CI018," );
            strSql . Append ( "CI019=@CI019," );
            strSql . Append ( "CI020=@CI020," );
            strSql . Append ( "CI021=@CI021," );
            strSql . Append ( "CI024=@CI024 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CI001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI005", SqlDbType.Date,3),
                    new SqlParameter("@CI006", SqlDbType.Date,3),
                    new SqlParameter("@CI007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI014", SqlDbType.Date,3),
                    new SqlParameter("@CI015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI016", SqlDbType.Date,3),
                    new SqlParameter("@CI017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI018", SqlDbType.Date,3),
                    new SqlParameter("@CI019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI020", SqlDbType.NVarChar,20),
                    new SqlParameter("@CI021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CI024", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CI001;
            parameters [ 1 ] . Value = model . CI002;
            parameters [ 2 ] . Value = model . CI003;
            parameters [ 3 ] . Value = model . CI004;
            parameters [ 4 ] . Value = model . CI005;
            parameters [ 5 ] . Value = model . CI006;
            parameters [ 6 ] . Value = model . CI007;
            parameters [ 7 ] . Value = model . CI008;
            parameters [ 8 ] . Value = model . CI009;
            parameters [ 9 ] . Value = model . CI010;
            parameters [ 10 ] . Value = model . CI011;
            parameters [ 11 ] . Value = model . CI012;
            parameters [ 12 ] . Value = model . CI013;
            parameters [ 13 ] . Value = model . CI014;
            parameters [ 14 ] . Value = model . CI015;
            parameters [ 15 ] . Value = model . CI016;
            parameters [ 16 ] . Value = model . CI017;
            parameters [ 17 ] . Value = model . CI018;
            parameters [ 18 ] . Value = model . CI019;
            parameters [ 19 ] . Value = model . CI020;
            parameters [ 20 ] . Value = model . CI021;
            parameters [ 21 ] . Value = model . CI024;
            parameters [ 22 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
        }

        void delete_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditForCIEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCI " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CI001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"编辑删除" ) ,null );
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CH001,CH002,CH003,CH004,CH005,CH006 FROM R_PQCH " );
            strSql . AppendFormat ( "WHERE CH001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CI001,CI002,CI003,CI004,CI005,CI006,CI007,CI008,CI009,CI010,CI011,CI012,CI013,CI014,CI015,CI016,CI017,CI018,CI019,CI020,CI021,CI024 FROM R_PQCI  " );
            strSql . AppendFormat ( "WHERE CI001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
