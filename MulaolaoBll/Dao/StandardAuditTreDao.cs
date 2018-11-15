using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class StandardAuditTreDao
    {
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
        /// get user data from r_pqcf
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CF007,CF008,CF009,CF010 FROM R_PQCF " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get one column datasource from r_pqcf
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CF001,CF002,CF003,CF009 FROM R_PQCF ORDER BY CF001,CF002,CF003,CF009" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqcf
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM (SELECT DISTINCT CF001,CF002,CF003,CF009 FROM R_PQCF WHERE {0}) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data for page from r_pqcf
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CF001,CF002,CF003,CF009,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CF001 DESC )" );
            strSql . Append ( "AS Row,T.* FROM R_PQCF T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON CF001=RES06" );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditTreCFEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CF001,CF002,CF003,CF004,CF005,CF006,CF007,CF008,CF009,CF010 FROM R_PQCF WHERE CF001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getDataRow ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . StandardAuditTreCFEntity getDataRow ( DataRow row )
        {
            MulaolaoLibrary . StandardAuditTreCFEntity model = new MulaolaoLibrary . StandardAuditTreCFEntity ( );
            if ( row != null )
            {
                if ( row [ "CF001" ] != null )
                    model . CF001 = row [ "CF001" ] . ToString ( );
                if ( row [ "CF002" ] != null )
                    model . CF002 = row [ "CF002" ] . ToString ( );
                if ( row [ "CF003" ] != null )
                    model . CF003 = row [ "CF003" ] . ToString ( );
                if ( row [ "CF004" ] != null )
                    model . CF004 = row [ "CF004" ] . ToString ( );
                if ( row [ "CF005" ] != null && row [ "CF005" ] . ToString ( ) != string . Empty )
                    model . CF005 = int . Parse ( row [ "CF005" ] . ToString ( ) );
                if ( row [ "CF006" ] != null )
                    model . CF006 = row [ "CF006" ] . ToString ( );
                if ( row [ "CF007" ] != null )
                    model . CF007 = row [ "CF007" ] . ToString ( );
                if ( row [ "CF008" ] != null )
                    model . CF008 = row [ "CF008" ] . ToString ( );
                if ( row [ "CF009" ] != null )
                    model . CF009 = row [ "CF009" ] . ToString ( );
                if ( row [ "CF010" ] != null )
                    model . CF010 = row [ "CF010" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// get data from r_pqcg to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CG001,CG002,CG003,CG004,CG005,CG006,CG007,CG008,CG009,CG010,CG011,CG012,CG013,CG014,CG015,CG016,CG017,CG018,CG019,CG020,CG021,CG022,CG023 FROM R_PQCG " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get max oddNum from r_pqcf
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CF001) CF001 FROM R_PQCF " );
            strSql . AppendFormat ( "WHERE CF001 LIKE 'R_484-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CF001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_484-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_484-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_484-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqcf and r_pqcg, and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCF " );
            strSql . AppendFormat ( "WHERE CF001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCG " );
            strSql . AppendFormat ( "WHERE CG001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditTreCFEntity _cf ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _cf . CF001 = getOddNum ( );
            add_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,_cf . CF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );

            MulaolaoLibrary . StandardAuditTreCGEntity _ce = new MulaolaoLibrary . StandardAuditTreCGEntity ( );
            _ce . CG001 = _cf . CF001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CG002 = table . Rows [ i ] [ "CG002" ] . ToString ( );
                _ce . CG003 = table . Rows [ i ] [ "CG003" ] . ToString ( );
                _ce . CG004 = table . Rows [ i ] [ "CG004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG005" ] . ToString ( ) ) )
                    _ce . CG005 = null;
                else
                    _ce . CG005 = Convert . ToDateTime ( table . Rows [ i ] [ "CG005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG006" ] . ToString ( ) ) )
                    _ce . CG006 = null;
                else
                    _ce . CG006 = Convert . ToDateTime ( table . Rows [ i ] [ "CG006" ] );
                _ce . CG007 = table . Rows [ i ] [ "CG007" ] . ToString ( );
                _ce . CG008 = table . Rows [ i ] [ "CG008" ] . ToString ( );
                _ce . CG009 = table . Rows [ i ] [ "CG009" ] . ToString ( );
                _ce . CG010 = table . Rows [ i ] [ "CG010" ] . ToString ( );
                _ce . CG011 = table . Rows [ i ] [ "CG011" ] . ToString ( );
                _ce . CG012 = table . Rows [ i ] [ "CG012" ] . ToString ( );
                _ce . CG013 = table . Rows [ i ] [ "CG013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG014" ] . ToString ( ) ) )
                    _ce . CG014 = null;
                else
                    _ce . CG014 = Convert . ToDateTime ( table . Rows [ i ] [ "CG014" ] );
                _ce . CG015 = table . Rows [ i ] [ "CG015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG016" ] . ToString ( ) ) )
                    _ce . CG016 = null;
                else
                    _ce . CG016 = Convert . ToDateTime ( table . Rows [ i ] [ "CG016" ] );
                _ce . CG017 = table . Rows [ i ] [ "CG017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG018" ] . ToString ( ) ) )
                    _ce . CG018 = null;
                else
                    _ce . CG018 = Convert . ToDateTime ( table . Rows [ i ] [ "CG018" ] );
                _ce . CG019 = table . Rows [ i ] [ "CG019" ] . ToString ( );
                _ce . CG020 = table . Rows [ i ] [ "CG020" ] . ToString ( );
                _ce . CG021 = table . Rows [ i ] [ "CG021" ] . ToString ( );
                _ce . CG022 = table . Rows [ i ] [ "CG022" ] . ToString ( );
                _ce . CG023 = table . Rows [ i ] [ "CG023" ] . ToString ( );
                add_pqcg ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTreCFEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCF(" );
            strSql . Append ( "CF001,CF002,CF003,CF004,CF005,CF006,CF007,CF008,CF009,CF010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CF001,@CF002,@CF003,@CF004,@CF005,@CF006,@CF007,@CF008,@CF009,@CF010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CF001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CF004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF005", SqlDbType.Int,4),
                    new SqlParameter("@CF006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CF007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CF001;
            parameters [ 1 ] . Value = model . CF002;
            parameters [ 2 ] . Value = model . CF003;
            parameters [ 3 ] . Value = model . CF004;
            parameters [ 4 ] . Value = model . CF005;
            parameters [ 5 ] . Value = model . CF006;
            parameters [ 6 ] . Value = model . CF007;
            parameters [ 7 ] . Value = model . CF008;
            parameters [ 8 ] . Value = model . CF009;
            parameters [ 9 ] . Value = model . CF010;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTreCGEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCG(" );
            strSql . Append ( "CG001,CG002,CG003,CG004,CG005,CG006,CG007,CG008,CG009,CG010,CG011,CG012,CG013,CG014,CG015,CG016,CG017,CG018,CG019,CG020,CG021,CG022,CG023)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CG001,@CG002,@CG003,@CG004,@CG005,@CG006,@CG007,@CG008,@CG009,@CG010,@CG011,@CG012,@CG013,@CG014,@CG015,@CG016,@CG017,@CG018,@CG019,@CG020,@CG021,@CG022,@CG023)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CG001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG005", SqlDbType.Date,3),
                    new SqlParameter("@CG006", SqlDbType.Date,3),
                    new SqlParameter("@CG007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG014", SqlDbType.Date,3),
                    new SqlParameter("@CG015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG016", SqlDbType.Date,3),
                    new SqlParameter("@CG017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG018", SqlDbType.Date,3),
                    new SqlParameter("@CG019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG020", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CG022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG023", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CG001;
            parameters [ 1 ] . Value = model . CG002;
            parameters [ 2 ] . Value = model . CG003;
            parameters [ 3 ] . Value = model . CG004;
            parameters [ 4 ] . Value = model . CG005;
            parameters [ 5 ] . Value = model . CG006;
            parameters [ 6 ] . Value = model . CG007;
            parameters [ 7 ] . Value = model . CG008;
            parameters [ 8 ] . Value = model . CG009;
            parameters [ 9 ] . Value = model . CG010;
            parameters [ 10 ] . Value = model . CG011;
            parameters [ 11 ] . Value = model . CG012;
            parameters [ 12 ] . Value = model . CG013;
            parameters [ 13 ] . Value = model . CG014;
            parameters [ 14 ] . Value = model . CG015;
            parameters [ 15 ] . Value = model . CG016;
            parameters [ 16 ] . Value = model . CG017;
            parameters [ 17 ] . Value = model . CG018;
            parameters [ 18 ] . Value = model . CG019;
            parameters [ 19 ] . Value = model . CG020;
            parameters [ 20 ] . Value = model . CG021;
            parameters [ 21 ] . Value = model . CG022;
            parameters [ 22 ] . Value = model . CG023;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CG001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditTreCFEntity _cf ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,_cf . CF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . StandardAuditTreCGEntity _ce = new MulaolaoLibrary . StandardAuditTreCGEntity ( );
            _ce . CG001 = _cf . CF001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CG002 = table . Rows [ i ] [ "CG002" ] . ToString ( );
                _ce . CG003 = table . Rows [ i ] [ "CG003" ] . ToString ( );
                _ce . CG004 = table . Rows [ i ] [ "CG004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG005" ] . ToString ( ) ) )
                    _ce . CG005 = null;
                else
                    _ce . CG005 = Convert . ToDateTime ( table . Rows [ i ] [ "CG005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG006" ] . ToString ( ) ) )
                    _ce . CG006 = null;
                else
                    _ce . CG006 = Convert . ToDateTime ( table . Rows [ i ] [ "CG006" ] );
                _ce . CG007 = table . Rows [ i ] [ "CG007" ] . ToString ( );
                _ce . CG008 = table . Rows [ i ] [ "CG008" ] . ToString ( );
                _ce . CG009 = table . Rows [ i ] [ "CG009" ] . ToString ( );
                _ce . CG010 = table . Rows [ i ] [ "CG010" ] . ToString ( );
                _ce . CG011 = table . Rows [ i ] [ "CG011" ] . ToString ( );
                _ce . CG012 = table . Rows [ i ] [ "CG012" ] . ToString ( );
                _ce . CG013 = table . Rows [ i ] [ "CG013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG014" ] . ToString ( ) ) )
                    _ce . CG014 = null;
                else
                    _ce . CG014 = Convert . ToDateTime ( table . Rows [ i ] [ "CG014" ] );
                _ce . CG015 = table . Rows [ i ] [ "CG015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG016" ] . ToString ( ) ) )
                    _ce . CG016 = null;
                else
                    _ce . CG016 = Convert . ToDateTime ( table . Rows [ i ] [ "CG016" ] );
                _ce . CG017 = table . Rows [ i ] [ "CG017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CG018" ] . ToString ( ) ) )
                    _ce . CG018 = null;
                else
                    _ce . CG018 = Convert . ToDateTime ( table . Rows [ i ] [ "CG018" ] );
                _ce . CG019 = table . Rows [ i ] [ "CG019" ] . ToString ( );
                _ce . CG020 = table . Rows [ i ] [ "CG020" ] . ToString ( );
                _ce . CG021 = table . Rows [ i ] [ "CG021" ] . ToString ( );
                _ce . CG022 = table . Rows [ i ] [ "CG022" ] . ToString ( );
                _ce . CG023 = table . Rows [ i ] [ "CG023" ] . ToString ( );
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

        void edit_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTreCFEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCF set " );
            strSql . Append ( "CF002=@CF002," );
            strSql . Append ( "CF003=@CF003," );
            strSql . Append ( "CF004=@CF004," );
            strSql . Append ( "CF005=@CF005," );
            strSql . Append ( "CF006=@CF006," );
            strSql . Append ( "CF007=@CF007," );
            strSql . Append ( "CF008=@CF008," );
            strSql . Append ( "CF009=@CF009," );
            strSql . Append ( "CF010=@CF010 " );
            strSql . Append ( " where CF001=@CF001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CF001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CF004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF005", SqlDbType.Int,4),
                    new SqlParameter("@CF006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CF007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CF010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CF001;
            parameters [ 1 ] . Value = model . CF002;
            parameters [ 2 ] . Value = model . CF003;
            parameters [ 3 ] . Value = model . CF004;
            parameters [ 4 ] . Value = model . CF005;
            parameters [ 5 ] . Value = model . CF006;
            parameters [ 6 ] . Value = model . CF007;
            parameters [ 7 ] . Value = model . CF008;
            parameters [ 8 ] . Value = model . CF009;
            parameters [ 9 ] . Value = model . CF010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTreCGEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCG set " );
            strSql . Append ( "CG001=@CG001," );
            strSql . Append ( "CG002=@CG002," );
            strSql . Append ( "CG003=@CG003," );
            strSql . Append ( "CG004=@CG004," );
            strSql . Append ( "CG005=@CG005," );
            strSql . Append ( "CG006=@CG006," );
            strSql . Append ( "CG007=@CG007," );
            strSql . Append ( "CG008=@CG008," );
            strSql . Append ( "CG009=@CG009," );
            strSql . Append ( "CG010=@CG010," );
            strSql . Append ( "CG011=@CG011," );
            strSql . Append ( "CG012=@CG012," );
            strSql . Append ( "CG013=@CG013," );
            strSql . Append ( "CG014=@CG014," );
            strSql . Append ( "CG015=@CG015," );
            strSql . Append ( "CG016=@CG016," );
            strSql . Append ( "CG017=@CG017," );
            strSql . Append ( "CG018=@CG018," );
            strSql . Append ( "CG019=@CG019," );
            strSql . Append ( "CG020=@CG020," );
            strSql . Append ( "CG021=@CG021," );
            strSql . Append ( "CG022=@CG022," );
            strSql . Append ( "CG023=@CG023 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CG001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG005", SqlDbType.Date,3),
                    new SqlParameter("@CG006", SqlDbType.Date,3),
                    new SqlParameter("@CG007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG014", SqlDbType.Date,3),
                    new SqlParameter("@CG015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG016", SqlDbType.Date,3),
                    new SqlParameter("@CG017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG018", SqlDbType.Date,3),
                    new SqlParameter("@CG019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG020", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CG022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CG023", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CG001;
            parameters [ 1 ] . Value = model . CG002;
            parameters [ 2 ] . Value = model . CG003;
            parameters [ 3 ] . Value = model . CG004;
            parameters [ 4 ] . Value = model . CG005;
            parameters [ 5 ] . Value = model . CG006;
            parameters [ 6 ] . Value = model . CG007;
            parameters [ 7 ] . Value = model . CG008;
            parameters [ 8 ] . Value = model . CG009;
            parameters [ 9 ] . Value = model . CG010;
            parameters [ 10 ] . Value = model . CG011;
            parameters [ 11 ] . Value = model . CG012;
            parameters [ 12 ] . Value = model . CG013;
            parameters [ 13 ] . Value = model . CG014;
            parameters [ 14 ] . Value = model . CG015;
            parameters [ 15 ] . Value = model . CG016;
            parameters [ 16 ] . Value = model . CG017;
            parameters [ 17 ] . Value = model . CG018;
            parameters [ 18 ] . Value = model . CG019;
            parameters [ 19 ] . Value = model . CG020;
            parameters [ 20 ] . Value = model . CG021;
            parameters [ 21 ] . Value = model . CG022;
            parameters [ 22 ] . Value = model . CG023;
            parameters [ 23 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CG001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
        }

        void delete_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditTreCGEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCG " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CG001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"编辑删除" ) ,null );
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
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne (string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CF001,CF002,CF003,CF004,CF005,CF006,CF007,CF008,CF009,CF010 FROM R_PQCF " );
            strSql . AppendFormat ( "WHERE CF001='{0}'" ,oddNum );

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
            strSql . Append ( "SELECT CG001,CG002,CG003,CG004,CG005,CG006,CG007,CG008,CG009,CG010,CG011,CG012,CG013,CG014,CG015,CG016,CG017,CG018,CG019,CG020,CG021,CG022,CG023 FROM R_PQCG " );
            strSql . AppendFormat ( "WHERE CG001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
