using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class StandardAuditFivDao
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
        /// get user data from r_pqcj
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CJ007,CJ008,CJ009,CJ010 FROM R_PQCJ " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get one column datasource from r_pqcj
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CJ001,CJ002,CJ003,CJ009 FROM R_PQCJ ORDER BY CJ001,CJ002,CJ003,CJ009" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqcj
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM (SELECT DISTINCT CJ001,CJ002,CJ003,CJ009 FROM R_PQCJ WHERE {0}) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data for page from r_pqcj
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CJ001,CJ002,CJ003,CJ009,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CJ001 DESC )" );
            strSql . Append ( "AS Row,T.* FROM R_PQCJ T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON CJ001=RES06" );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcj
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditFivCJEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CJ001,CJ002,CJ003,CJ004,CJ005,CJ006,CJ007,CJ008,CJ009,CJ010 FROM R_PQCJ WHERE CJ001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getDataRow ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . StandardAuditFivCJEntity getDataRow ( DataRow row )
        {
            MulaolaoLibrary . StandardAuditFivCJEntity model = new MulaolaoLibrary . StandardAuditFivCJEntity ( );
            if ( row != null )
            {
                if ( row [ "CJ001" ] != null )
                    model . CJ001 = row [ "CJ001" ] . ToString ( );
                if ( row [ "CJ002" ] != null )
                    model . CJ002 = row [ "CJ002" ] . ToString ( );
                if ( row [ "CJ003" ] != null )
                    model . CJ003 = row [ "CJ003" ] . ToString ( );
                if ( row [ "CJ004" ] != null )
                    model . CJ004 = row [ "CJ004" ] . ToString ( );
                if ( row [ "CJ005" ] != null && row [ "CJ005" ] . ToString ( ) != string . Empty )
                    model . CJ005 = int . Parse ( row [ "CJ005" ] . ToString ( ) );
                if ( row [ "CJ006" ] != null )
                    model . CJ006 = row [ "CJ006" ] . ToString ( );
                if ( row [ "CJ007" ] != null )
                    model . CJ007 = row [ "CJ007" ] . ToString ( );
                if ( row [ "CJ008" ] != null )
                    model . CJ008 = row [ "CJ008" ] . ToString ( );
                if ( row [ "CJ009" ] != null )
                    model . CJ009 = row [ "CJ009" ] . ToString ( );
                if ( row [ "CJ010" ] != null )
                    model . CJ010 = row [ "CJ010" ] . ToString ( );
            }

            return model;
        }

        /// <summary>
        /// get data from r_pqck to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CK001,CK002,CK003,CK004,CK005,CK006,CK007,CK008,CK009,CK010,CK011,CK012,CK013,CK014,CK015,CK016,CK017,CK018,CK021,CK022 FROM R_PQCK " );
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
            strSql . Append ( "SELECT MAX(CJ001) CJ001 FROM R_PQCJ " );
            strSql . AppendFormat ( "WHERE CJ001 LIKE 'R_489-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CJ001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_489-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_489-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_489-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
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
            strSql . Append ( "DELETE FROM R_PQCJ " );
            strSql . AppendFormat ( "WHERE CJ001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_489" ,"电脑雕刻生产首件样审核确认记录表(R_489)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCK " );
            strSql . AppendFormat ( "WHERE CK001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_489" ,"电脑雕刻生产首件样审核确认记录表(R_489)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_489" ,"电脑雕刻生产首件样审核确认记录表(R_489)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditFivCJEntity _cf ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _cf . CJ001 = getOddNum ( );
            add_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_484" ,"动力段生产首件量.检具审核确认记录表(R_484)" ,logins ,Drity . GetDt ( ) ,_cf . CJ001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );

            MulaolaoLibrary . StandardAuditFivCKEntity _ce = new MulaolaoLibrary . StandardAuditFivCKEntity ( );
            _ce . CK001 = _cf . CJ001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CK002 = table . Rows [ i ] [ "CK002" ] . ToString ( );
                _ce . CK003 = table . Rows [ i ] [ "CK003" ] . ToString ( );
                _ce . CK004 = table . Rows [ i ] [ "CK004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK005" ] . ToString ( ) ) )
                    _ce . CK005 = null;
                else
                    _ce . CK005 = Convert . ToDateTime ( table . Rows [ i ] [ "CK005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK006" ] . ToString ( ) ) )
                    _ce . CK006 = null;
                else
                    _ce . CK006 = Convert . ToDateTime ( table . Rows [ i ] [ "CK006" ] );
                _ce . CK007 = table . Rows [ i ] [ "CK007" ] . ToString ( );
                _ce . CK008 = table . Rows [ i ] [ "CK008" ] . ToString ( );
                _ce . CK009 = table . Rows [ i ] [ "CK009" ] . ToString ( );
                _ce . CK010 = table . Rows [ i ] [ "CK010" ] . ToString ( );
                _ce . CK011 = table . Rows [ i ] [ "CK011" ] . ToString ( );
                _ce . CK012 = table . Rows [ i ] [ "CK012" ] . ToString ( );
                _ce . CK013 = table . Rows [ i ] [ "CK013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK014" ] . ToString ( ) ) )
                    _ce . CK014 = null;
                else
                    _ce . CK014 = Convert . ToDateTime ( table . Rows [ i ] [ "CK014" ] );
                _ce . CK015 = table . Rows [ i ] [ "CK015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK016" ] . ToString ( ) ) )
                    _ce . CK016 = null;
                else
                    _ce . CK016 = Convert . ToDateTime ( table . Rows [ i ] [ "CK016" ] );
                _ce . CK017 = table . Rows [ i ] [ "CK017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK018" ] . ToString ( ) ) )
                    _ce . CK018 = null;
                else
                    _ce . CK018 = Convert . ToDateTime ( table . Rows [ i ] [ "CK018" ] );
                _ce . CK021 = table . Rows [ i ] [ "CK021" ] . ToString ( );
                _ce . CK022 = table . Rows [ i ] [ "CK022" ] . ToString ( );
                add_pqcg ( SQLString ,strSql ,_ce ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditFivCJEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCJ(" );
            strSql . Append ( "CJ001,CJ002,CJ003,CJ004,CJ005,CJ006,CJ007,CJ008,CJ009,CJ010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CJ001,@CJ002,@CJ003,@CJ004,@CJ005,@CJ006,@CJ007,@CJ008,@CJ009,@CJ010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CJ001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CJ004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ005", SqlDbType.Int,4),
                    new SqlParameter("@CJ006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CJ007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CJ001;
            parameters [ 1 ] . Value = model . CJ002;
            parameters [ 2 ] . Value = model . CJ003;
            parameters [ 3 ] . Value = model . CJ004;
            parameters [ 4 ] . Value = model . CJ005;
            parameters [ 5 ] . Value = model . CJ006;
            parameters [ 6 ] . Value = model . CJ007;
            parameters [ 7 ] . Value = model . CJ008;
            parameters [ 8 ] . Value = model . CJ009;
            parameters [ 9 ] . Value = model . CJ010;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditFivCKEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCK(" );
            strSql . Append ( "CK001,CK002,CK003,CK004,CK005,CK006,CK007,CK008,CK009,CK010,CK011,CK012,CK013,CK014,CK015,CK016,CK017,CK018,CK021,CK022)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CK001,@CK002,@CK003,@CK004,@CK005,@CK006,@CK007,@CK008,@CK009,@CK010,@CK011,@CK012,@CK013,@CK014,@CK015,@CK016,@CK017,@CK018,@CK021,@CK022)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CK001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK005", SqlDbType.Date,3),
                    new SqlParameter("@CK006", SqlDbType.Date,3),
                    new SqlParameter("@CK007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK014", SqlDbType.Date,3),
                    new SqlParameter("@CK015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK016", SqlDbType.Date,3),
                    new SqlParameter("@CK017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK018", SqlDbType.Date,3),
                    new SqlParameter("@CK021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CK022", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CK001;
            parameters [ 1 ] . Value = model . CK002;
            parameters [ 2 ] . Value = model . CK003;
            parameters [ 3 ] . Value = model . CK004;
            parameters [ 4 ] . Value = model . CK005;
            parameters [ 5 ] . Value = model . CK006;
            parameters [ 6 ] . Value = model . CK007;
            parameters [ 7 ] . Value = model . CK008;
            parameters [ 8 ] . Value = model . CK009;
            parameters [ 9 ] . Value = model . CK010;
            parameters [ 10 ] . Value = model . CK011;
            parameters [ 11 ] . Value = model . CK012;
            parameters [ 12 ] . Value = model . CK013;
            parameters [ 13 ] . Value = model . CK014;
            parameters [ 14 ] . Value = model . CK015;
            parameters [ 15 ] . Value = model . CK016;
            parameters [ 16 ] . Value = model . CK017;
            parameters [ 17 ] . Value = model . CK018;
            parameters [ 18 ] . Value = model . CK021;
            parameters [ 19 ] . Value = model . CK022;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CK001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditFivCJEntity _cf ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqcf ( SQLString ,strSql ,_cf );
            SQLString . Add ( Drity . DrityOfComparation ( "R_489" ,"电脑雕刻生产首件样审核确认记录表(R_489)" ,logins ,Drity . GetDt ( ) ,_cf . CJ001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . StandardAuditFivCKEntity _ce = new MulaolaoLibrary . StandardAuditFivCKEntity ( );
            _ce . CK001 = _cf . CJ001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _ce . CK002 = table . Rows [ i ] [ "CK002" ] . ToString ( );
                _ce . CK003 = table . Rows [ i ] [ "CK003" ] . ToString ( );
                _ce . CK004 = table . Rows [ i ] [ "CK004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK005" ] . ToString ( ) ) )
                    _ce . CK005 = null;
                else
                    _ce . CK005 = Convert . ToDateTime ( table . Rows [ i ] [ "CK005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK006" ] . ToString ( ) ) )
                    _ce . CK006 = null;
                else
                    _ce . CK006 = Convert . ToDateTime ( table . Rows [ i ] [ "CK006" ] );
                _ce . CK007 = table . Rows [ i ] [ "CK007" ] . ToString ( );
                _ce . CK008 = table . Rows [ i ] [ "CK008" ] . ToString ( );
                _ce . CK009 = table . Rows [ i ] [ "CK009" ] . ToString ( );
                _ce . CK010 = table . Rows [ i ] [ "CK010" ] . ToString ( );
                _ce . CK011 = table . Rows [ i ] [ "CK011" ] . ToString ( );
                _ce . CK012 = table . Rows [ i ] [ "CK012" ] . ToString ( );
                _ce . CK013 = table . Rows [ i ] [ "CK013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK014" ] . ToString ( ) ) )
                    _ce . CK014 = null;
                else
                    _ce . CK014 = Convert . ToDateTime ( table . Rows [ i ] [ "CK014" ] );
                _ce . CK015 = table . Rows [ i ] [ "CK015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK016" ] . ToString ( ) ) )
                    _ce . CK016 = null;
                else
                    _ce . CK016 = Convert . ToDateTime ( table . Rows [ i ] [ "CK016" ] );
                _ce . CK017 = table . Rows [ i ] [ "CK017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CK018" ] . ToString ( ) ) )
                    _ce . CK018 = null;
                else
                    _ce . CK018 = Convert . ToDateTime ( table . Rows [ i ] [ "CK018" ] );
                _ce . CK021 = table . Rows [ i ] [ "CK021" ] . ToString ( );
                _ce . CK022 = table . Rows [ i ] [ "CK022" ] . ToString ( );
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

        void edit_pqcf ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditFivCJEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCJ set " );
            strSql . Append ( "CJ002=@CJ002," );
            strSql . Append ( "CJ003=@CJ003," );
            strSql . Append ( "CJ004=@CJ004," );
            strSql . Append ( "CJ005=@CJ005," );
            strSql . Append ( "CJ006=@CJ006," );
            strSql . Append ( "CJ007=@CJ007," );
            strSql . Append ( "CJ008=@CJ008," );
            strSql . Append ( "CJ009=@CJ009," );
            strSql . Append ( "CJ010=@CJ010 " );
            strSql . Append ( " where CJ001=@CJ001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CJ001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CJ004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ005", SqlDbType.Int,4),
                    new SqlParameter("@CJ006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CJ007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CJ010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CJ001;
            parameters [ 1 ] . Value = model . CJ002;
            parameters [ 2 ] . Value = model . CJ003;
            parameters [ 3 ] . Value = model . CJ004;
            parameters [ 4 ] . Value = model . CJ005;
            parameters [ 5 ] . Value = model . CJ006;
            parameters [ 6 ] . Value = model . CJ007;
            parameters [ 7 ] . Value = model . CJ008;
            parameters [ 8 ] . Value = model . CJ009;
            parameters [ 9 ] . Value = model . CJ010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditFivCKEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCK set " );
            strSql . Append ( "CK001=@CK001," );
            strSql . Append ( "CK002=@CK002," );
            strSql . Append ( "CK003=@CK003," );
            strSql . Append ( "CK004=@CK004," );
            strSql . Append ( "CK005=@CK005," );
            strSql . Append ( "CK006=@CK006," );
            strSql . Append ( "CK007=@CK007," );
            strSql . Append ( "CK008=@CK008," );
            strSql . Append ( "CK009=@CK009," );
            strSql . Append ( "CK010=@CK010," );
            strSql . Append ( "CK011=@CK011," );
            strSql . Append ( "CK012=@CK012," );
            strSql . Append ( "CK013=@CK013," );
            strSql . Append ( "CK014=@CK014," );
            strSql . Append ( "CK015=@CK015," );
            strSql . Append ( "CK016=@CK016," );
            strSql . Append ( "CK017=@CK017," );
            strSql . Append ( "CK018=@CK018," );
            strSql . Append ( "CK021=@CK021," );
            strSql . Append ( "CK022=@CK022 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CK001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK005", SqlDbType.Date,3),
                    new SqlParameter("@CK006", SqlDbType.Date,3),
                    new SqlParameter("@CK007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK014", SqlDbType.Date,3),
                    new SqlParameter("@CK015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK016", SqlDbType.Date,3),
                    new SqlParameter("@CK017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CK018", SqlDbType.Date,3),
                    new SqlParameter("@CK021", SqlDbType.NVarChar,100),
                    new SqlParameter("@CK022", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CK001;
            parameters [ 1 ] . Value = model . CK002;
            parameters [ 2 ] . Value = model . CK003;
            parameters [ 3 ] . Value = model . CK004;
            parameters [ 4 ] . Value = model . CK005;
            parameters [ 5 ] . Value = model . CK006;
            parameters [ 6 ] . Value = model . CK007;
            parameters [ 7 ] . Value = model . CK008;
            parameters [ 8 ] . Value = model . CK009;
            parameters [ 9 ] . Value = model . CK010;
            parameters [ 10 ] . Value = model . CK011;
            parameters [ 11 ] . Value = model . CK012;
            parameters [ 12 ] . Value = model . CK013;
            parameters [ 13 ] . Value = model . CK014;
            parameters [ 14 ] . Value = model . CK015;
            parameters [ 15 ] . Value = model . CK016;
            parameters [ 16 ] . Value = model . CK017;
            parameters [ 17 ] . Value = model . CK018;
            parameters [ 18 ] . Value = model . CK021;
            parameters [ 19 ] . Value = model . CK022;
            parameters [ 20 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CK001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
        }

        void delete_pqcg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditFivCKEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCK " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CK001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"编辑删除" ) ,null );
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
        public DataTable getTablePrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CJ001,CJ002,CJ003,CJ004,CJ005,CJ006,CJ007,CJ008,CJ009,CJ010 FROM R_PQCJ " );
            strSql . AppendFormat ( "WHERE CJ001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get a list of printed data
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTablePrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CK001,CK002,CK003,CK004,CK005,CK006,CK007,CK008,CK009,CK010,CK011,CK012,CK013,CK014,CK015,CK016,CK017,CK018,CK021,CK022 FROM R_PQCK " );
            strSql . AppendFormat ( "WHERE CK001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
