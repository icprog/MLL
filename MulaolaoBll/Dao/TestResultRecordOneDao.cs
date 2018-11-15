using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class TestResultRecordOneDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF07,PQF08,PQF02,PQF66 FROM R_PQF A INNER JOIN R_REVIEWS C ON A.PQF01=C.RES06 WHERE RES05='执行' ORDER BY PQF01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get proNun from r_pqcw
        /// </summary>
        /// <returns></returns>
        public DataTable getProNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CW001 FROM R_PQCW" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqcv
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CV001,CV002,CV003,CV004,CV006,CV009 FROM R_PQCV " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqcv
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT CV001,CV002,CV003,CV004,CV006,CV009 FROM R_PQCV WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj != null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqcv
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CV001,CV002,CV003,CV004,CV006,CV009,RES05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER( " );
            strSql . Append ( "ORDER BY T.CV001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQCV T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON CV001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqcu to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CU001,CU002,CU003,CU004,CU005,CU006,CU007,CU008,CU009,CU010,CU011,CU012,CU013,CU014,CU015,CU016,CU017,CU018,CU019,CU020,CU021,CU022,CU023,CU024,CU025,CU026,CU027,CU028 FROM R_PQCU " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqcv 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestResultRecordOneCVEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CV001,CV002,CV003,CV004,CV005,CV006,CV007,CV008,CV009,CV010 FROM R_PQCV " );
            strSql . Append ( " WHERE CV001=@CV001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CV001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . TestResultRecordOneCVEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . TestResultRecordOneCVEntity model = new MulaolaoLibrary . TestResultRecordOneCVEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "CV001" ] != null )
                {
                    model . CV001 = row [ "CV001" ] . ToString ( );
                }
                if ( row [ "CV002" ] != null )
                {
                    model . CV002 = row [ "CV002" ] . ToString ( );
                }
                if ( row [ "CV003" ] != null )
                {
                    model . CV003 = row [ "CV003" ] . ToString ( );
                }
                if ( row [ "CV004" ] != null )
                {
                    model . CV004 = row [ "CV004" ] . ToString ( );
                }
                if ( row [ "CV005" ] != null )
                {
                    model . CV005 = row [ "CV005" ] . ToString ( );
                }
                if ( row [ "CV006" ] != null )
                {
                    model . CV006 = row [ "CV006" ] . ToString ( );
                }
                if ( row [ "CV007" ] != null )
                {
                    model . CV007 = row [ "CV007" ] . ToString ( );
                }
                if ( row [ "CV008" ] != null )
                {
                    model . CV008 = row [ "CV008" ] . ToString ( );
                }
                if ( row [ "CV009" ] != null )
                {
                    model . CV009 = row [ "CV009" ] . ToString ( );
                }
                if ( row [ "CV010" ] != null )
                {
                    model . CV010 = row [ "CV010" ] . ToString ( );
                }
            }

            return model;

        }

        /// <summary>
        /// get data from r_pqcw to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CW001,CW002 FROM R_PQCW ORDER BY CW001" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get max oddNum from r_pqch
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CV001) CV001 FROM R_PQCV " );
            strSql . AppendFormat ( "WHERE CV001 LIKE 'R_368-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CV001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_368-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_368-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_368-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqcu and r_pqcv and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCV " );
            strSql . AppendFormat ( "WHERE CV001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_368" ,"粘接定期测试记录表(R_368)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCU " );
            strSql . AppendFormat ( "WHERE CU001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_368" ,"粘接定期测试记录表(R_368)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_368" ,"粘接定期测试记录表(R_368)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcv r_pqcu r_pqcw
        /// </summary>
        /// <param name="tableOnt"></param>
        /// <param name="tableTwo"></param>
        /// <param name="_cv"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOnt ,DataTable tableTwo ,MulaolaoLibrary . TestResultRecordOneCVEntity _cv ,List<string> bodyList ,List<string> coeList ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( _cv . idx < 1 )
            {
                _cv . CV001 = getOddNum ( );
                add_cv ( SQLString ,strSql ,_cv );
                SQLString . Add ( Drity . DrityOfComparation ( "R_368" ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,_cv . CV001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }
            else
            {
                edit_cv ( SQLString ,strSql ,_cv );
                SQLString . Add ( Drity . DrityOfComparation ( "R_368" ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,_cv . CV001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }

            MulaolaoLibrary . TestResultRecordOneCUEntity model = new MulaolaoLibrary . TestResultRecordOneCUEntity ( );
            model . CU001 = _cv . CV001;
            for ( int i = 0 ; i < tableOnt . Rows . Count ; i++ )
            {
                model . CU002 = tableOnt . Rows [ i ] [ "CU002" ] . ToString ( );
                model . CU003 = tableOnt . Rows [ i ] [ "CU003" ] . ToString ( );
                model . CU004 = tableOnt . Rows [ i ] [ "CU004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU005" ] . ToString ( ) ) )
                    model . CU005 = null;
                else
                    model . CU005 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU005" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU006" ] . ToString ( ) ) )
                    model . CU006 = null;
                else
                    model . CU006 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU006" ] . ToString ( ) );
                model . CU007 = tableOnt . Rows [ i ] [ "CU007" ] . ToString ( );
                model . CU008 = tableOnt . Rows [ i ] [ "CU008" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU009" ] . ToString ( ) ) )
                    model . CU009 = null;
                else
                    model . CU009 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU009" ] . ToString ( ) );
                model . CU010 = tableOnt . Rows [ i ] [ "CU010" ] . ToString ( );
                model . CU028 = tableOnt . Rows [ i ] [ "CU028" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU011" ] . ToString ( ) ) )
                    model . CU011 = null;
                else
                    model . CU011 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU011" ] . ToString ( ) );
                model . CU012 = tableOnt . Rows [ i ] [ "CU012" ] . ToString ( );
                model . CU013 = tableOnt . Rows [ i ] [ "CU013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU014" ] . ToString ( ) ) )
                    model . CU014 = null;
                else
                    model . CU014 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU014" ] . ToString ( ) );
                model . CU015 = tableOnt . Rows [ i ] [ "CU015" ] . ToString ( );
                model . CU016 = tableOnt . Rows [ i ] [ "CU016" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU017" ] . ToString ( ) ) )
                    model . CU017 = null;
                else
                    model . CU017 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU017" ] . ToString ( ) );
                model . CU018 = tableOnt . Rows [ i ] [ "CU018" ] . ToString ( );
                model . CU019 = tableOnt . Rows [ i ] [ "CU019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU020" ] . ToString ( ) ) )
                    model . CU020 = null;
                else
                    model . CU020 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU020" ] . ToString ( ) );
                model . CU021 = tableOnt . Rows [ i ] [ "CU021" ] . ToString ( );
                model . CU022 = tableOnt . Rows [ i ] [ "CU022" ] . ToString ( );
                if ( string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "CU023" ] . ToString ( ) ) )
                    model . CU023 = null;
                else
                    model . CU023 = Convert . ToDateTime ( tableOnt . Rows [ i ] [ "CU023" ] . ToString ( ) );
                model . CU024 = tableOnt . Rows [ i ] [ "CU024" ] . ToString ( );
                model . CU025 = tableOnt . Rows [ i ] [ "CU025" ] . ToString ( );
                model . CU026 = tableOnt . Rows [ i ] [ "CU026" ] . ToString ( );
                model . CU027 = tableOnt . Rows [ i ] [ "CU027" ] . ToString ( );
                model . idx = string . IsNullOrEmpty ( tableOnt . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOnt . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( model . idx < 1 )
                {
                    add_cu ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + i ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增单身" ) ,null );
                }
                else
                {
                    edit_cu ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + i ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑单身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_cu ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + model.idx ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除单身" ) ,null );
                }
            }

            MulaolaoLibrary . TestResultRecordOneCWEntity _cw = new MulaolaoLibrary . TestResultRecordOneCWEntity ( );
            for ( int i = 0 ; i < tableTwo . Rows . Count ; i++ )
            {
                _cw . idx = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) );
                _cw . CW001 = tableTwo . Rows [ i ] [ "CW001" ] . ToString ( );
                _cw . CW002 = tableTwo . Rows [ i ] [ "CW002" ] . ToString ( );

                if ( _cw . idx > 0 )
                {
                    edit_cw ( SQLString ,strSql ,_cw );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + i ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑系数" ) ,null );
                }
                else
                {
                    add_cw ( SQLString ,strSql ,_cw );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + i ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增系数" ) ,null );
                }
            }

            if ( coeList . Count > 0 )
            {
                foreach ( string s in coeList )
                {
                    _cw . idx = Convert . ToInt32 ( s );
                    delete_cw ( SQLString ,strSql ,_cw );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_368-" + _cw . idx ,"粘接(R_368)" ,logins ,Drity . GetDt ( ) ,model . CU001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除系数" ) ,null );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_cv ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCVEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCV(" );
            strSql . Append ( "CV001,CV002,CV003,CV004,CV005,CV006,CV007,CV008,CV009,CV010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CV001,@CV002,@CV003,@CV004,@CV005,@CV006,@CV007,@CV008,@CV009,@CV010)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CV001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV006", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CV001;
            parameters [ 1 ] . Value = model . CV002;
            parameters [ 2 ] . Value = model . CV003;
            parameters [ 3 ] . Value = model . CV004;
            parameters [ 4 ] . Value = model . CV005;
            parameters [ 5 ] . Value = model . CV006;
            parameters [ 6 ] . Value = model . CV007;
            parameters [ 7 ] . Value = model . CV008;
            parameters [ 8 ] . Value = model . CV009;
            parameters [ 9 ] . Value = model . CV010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cv ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCVEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCV set " );
            strSql . Append ( "CV001=@CV001," );
            strSql . Append ( "CV002=@CV002," );
            strSql . Append ( "CV003=@CV003," );
            strSql . Append ( "CV004=@CV004," );
            strSql . Append ( "CV005=@CV005," );
            strSql . Append ( "CV006=@CV006," );
            strSql . Append ( "CV007=@CV007," );
            strSql . Append ( "CV008=@CV008," );
            strSql . Append ( "CV009=@CV009," );
            strSql . Append ( "CV010=@CV010 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CV001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV006", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CV010", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CV001;
            parameters [ 1 ] . Value = model . CV002;
            parameters [ 2 ] . Value = model . CV003;
            parameters [ 3 ] . Value = model . CV004;
            parameters [ 4 ] . Value = model . CV005;
            parameters [ 5 ] . Value = model . CV006;
            parameters [ 6 ] . Value = model . CV007;
            parameters [ 7 ] . Value = model . CV008;
            parameters [ 8 ] . Value = model . CV009;
            parameters [ 9 ] . Value = model . CV010;
            parameters [ 10 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_cu ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCUEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCU(" );
            strSql . Append ( "CU001,CU002,CU003,CU004,CU005,CU006,CU007,CU008,CU009,CU010,CU028,CU011,CU012,CU013,CU014,CU015,CU016,CU017,CU018,CU019,CU020,CU021,CU022,CU023,CU024,CU025,CU026,CU027)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CU001,@CU002,@CU003,@CU004,@CU005,@CU006,@CU007,@CU008,@CU009,@CU010,@CU028,@CU011,@CU012,@CU013,@CU014,@CU015,@CU016,@CU017,@CU018,@CU019,@CU020,@CU021,@CU022,@CU023,@CU024,@CU025,@CU026,@CU027)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CU001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU005", SqlDbType.Date,3),
                    new SqlParameter("@CU006", SqlDbType.Date,3),
                    new SqlParameter("@CU007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU009", SqlDbType.Date,3),
                    new SqlParameter("@CU010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU028", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU011", SqlDbType.Date,3),
                    new SqlParameter("@CU012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU014", SqlDbType.Date,3),
                    new SqlParameter("@CU015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU016", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU017", SqlDbType.Date,3),
                    new SqlParameter("@CU018", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU020", SqlDbType.Date,3),
                    new SqlParameter("@CU021", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU023", SqlDbType.Date,3),
                    new SqlParameter("@CU024", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU025", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU026", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU027", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CU001;
            parameters [ 1 ] . Value = model . CU002;
            parameters [ 2 ] . Value = model . CU003;
            parameters [ 3 ] . Value = model . CU004;
            parameters [ 4 ] . Value = model . CU005;
            parameters [ 5 ] . Value = model . CU006;
            parameters [ 6 ] . Value = model . CU007;
            parameters [ 7 ] . Value = model . CU008;
            parameters [ 8 ] . Value = model . CU009;
            parameters [ 9 ] . Value = model . CU010;
            parameters [ 10 ] . Value = model . CU028;
            parameters [ 11 ] . Value = model . CU011;
            parameters [ 12 ] . Value = model . CU012;
            parameters [ 13 ] . Value = model . CU013;
            parameters [ 14 ] . Value = model . CU014;
            parameters [ 15 ] . Value = model . CU015;
            parameters [ 16 ] . Value = model . CU016;
            parameters [ 17 ] . Value = model . CU017;
            parameters [ 18 ] . Value = model . CU018;
            parameters [ 19 ] . Value = model . CU019;
            parameters [ 20 ] . Value = model . CU020;
            parameters [ 21 ] . Value = model . CU021;
            parameters [ 22 ] . Value = model . CU022;
            parameters [ 23 ] . Value = model . CU023;
            parameters [ 24 ] . Value = model . CU024;
            parameters [ 25 ] . Value = model . CU025;
            parameters [ 26 ] . Value = model . CU026;
            parameters [ 27 ] . Value = model . CU027;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cu ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCUEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCU set " );
            strSql . Append ( "CU001=@CU001," );
            strSql . Append ( "CU002=@CU002," );
            strSql . Append ( "CU003=@CU003," );
            strSql . Append ( "CU004=@CU004," );
            strSql . Append ( "CU005=@CU005," );
            strSql . Append ( "CU006=@CU006," );
            strSql . Append ( "CU007=@CU007," );
            strSql . Append ( "CU008=@CU008," );
            strSql . Append ( "CU009=@CU009," );
            strSql . Append ( "CU010=@CU010," );
            strSql . Append ( "CU028=@CU028," );
            strSql . Append ( "CU011=@CU011," );
            strSql . Append ( "CU012=@CU012," );
            strSql . Append ( "CU013=@CU013," );
            strSql . Append ( "CU014=@CU014," );
            strSql . Append ( "CU015=@CU015," );
            strSql . Append ( "CU016=@CU016," );
            strSql . Append ( "CU017=@CU017," );
            strSql . Append ( "CU018=@CU018," );
            strSql . Append ( "CU019=@CU019," );
            strSql . Append ( "CU020=@CU020," );
            strSql . Append ( "CU021=@CU021," );
            strSql . Append ( "CU022=@CU022," );
            strSql . Append ( "CU023=@CU023," );
            strSql . Append ( "CU024=@CU024," );
            strSql . Append ( "CU025=@CU025," );
            strSql . Append ( "CU026=@CU026," );
            strSql . Append ( "CU027=@CU027 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CU001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU005", SqlDbType.Date,3),
                    new SqlParameter("@CU006", SqlDbType.Date,3),
                    new SqlParameter("@CU007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU009", SqlDbType.Date,3),
                    new SqlParameter("@CU010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU028", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU011", SqlDbType.Date,3),
                    new SqlParameter("@CU012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU014", SqlDbType.Date,3),
                    new SqlParameter("@CU015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU016", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU017", SqlDbType.Date,3),
                    new SqlParameter("@CU018", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU020", SqlDbType.Date,3),
                    new SqlParameter("@CU021", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU022", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU023", SqlDbType.Date,3),
                    new SqlParameter("@CU024", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU025", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU026", SqlDbType.NVarChar,20),
                    new SqlParameter("@CU027", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CU001;
            parameters [ 1 ] . Value = model . CU002;
            parameters [ 2 ] . Value = model . CU003;
            parameters [ 3 ] . Value = model . CU004;
            parameters [ 4 ] . Value = model . CU005;
            parameters [ 5 ] . Value = model . CU006;
            parameters [ 6 ] . Value = model . CU007;
            parameters [ 7 ] . Value = model . CU008;
            parameters [ 8 ] . Value = model . CU009;
            parameters [ 9 ] . Value = model . CU010;
            parameters [ 10 ] . Value = model . CU028;
            parameters [ 11 ] . Value = model . CU011;
            parameters [ 12 ] . Value = model . CU012;
            parameters [ 13 ] . Value = model . CU013;
            parameters [ 14 ] . Value = model . CU014;
            parameters [ 15 ] . Value = model . CU015;
            parameters [ 16 ] . Value = model . CU016;
            parameters [ 17 ] . Value = model . CU017;
            parameters [ 18 ] . Value = model . CU018;
            parameters [ 19 ] . Value = model . CU019;
            parameters [ 20 ] . Value = model . CU020;
            parameters [ 21 ] . Value = model . CU021;
            parameters [ 22 ] . Value = model . CU022;
            parameters [ 23 ] . Value = model . CU023;
            parameters [ 24 ] . Value = model . CU024;
            parameters [ 25 ] . Value = model . CU025;
            parameters [ 26 ] . Value = model . CU026;
            parameters [ 27 ] . Value = model . CU027;
            parameters [ 28 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_cu ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCUEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCU " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cw ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCWEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCW set " );
            strSql . Append ( "CW001=@CW001," );
            strSql . Append ( "CW002=@CW002 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CW001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CW002", SqlDbType.NVarChar,50),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CW001;
            parameters [ 1 ] . Value = model . CW002;
            parameters [ 2 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_cw ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCWEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCW(" );
            strSql . Append ( "CW001,CW002)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CW001,@CW002)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CW001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CW002", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . CW001;
            parameters [ 1 ] . Value = model . CW002;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_cw ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordOneCWEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCW " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( SQLString ,parameters );
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
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,CU001,CU002,CU003,CU004,CU005,CU006,CU007,CU008,CU009,CU010,CU011,CU012,CU013,CU014,CU015,CU016,CU017,CU018,CU019,CU020,CU021,CU022,CU023,CU024,CU025,CU026,CU027,CU028 FROM R_PQCU WHERE CU001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,CV001,CV002,CV003,CV004,CV005,CV006,CV007,CV008,CV009,CV010 FROM R_PQCV WHERE CV001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
