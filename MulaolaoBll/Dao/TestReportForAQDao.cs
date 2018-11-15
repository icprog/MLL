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
    public class TestReportForAQDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF07,PQF08,DFA003,PQF06 FROM R_PQF A INNER JOIN TPADFA B ON A.PQF11=B.DFA001  INNER JOIN R_REVIEWS C ON A.PQF01=C.RES06 WHERE RES05='执行' ORDER BY PQF01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqdb to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DB001,DB002,DB003,DB004,DB005,DB006,DB007,DB008,DB009,DB010 FROM R_PQDB " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ORDER BY DB010" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqda to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestReportForAQDAEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DA001,DA002,DA003,DA004,DA005,DA006,DA007,DA008,DA009,DA010,DA011,DA012,DA013,DA014,DA015,DA016,DA017,DA018,DA019,DA020,DA021 FROM R_PQDA " );
            strSql . Append ( " where DA001=@DA001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DA001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . TestReportForAQDAEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . TestReportForAQDAEntity model = new MulaolaoLibrary . TestReportForAQDAEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "DA001" ] != null )
                {
                    model . DA001 = row [ "DA001" ] . ToString ( );
                }
                if ( row [ "DA002" ] != null )
                {
                    model . DA002 = row [ "DA002" ] . ToString ( );
                }
                if ( row [ "DA003" ] != null )
                {
                    model . DA003 = row [ "DA003" ] . ToString ( );
                }
                if ( row [ "DA004" ] != null )
                {
                    model . DA004 = row [ "DA004" ] . ToString ( );
                }
                if ( row [ "DA005" ] != null )
                {
                    model . DA005 = row [ "DA005" ] . ToString ( );
                }
                if ( row [ "DA006" ] != null && row [ "DA006" ] . ToString ( ) != "" )
                {
                    model . DA006 = int . Parse ( row [ "DA006" ] . ToString ( ) );
                }
                if ( row [ "DA007" ] != null )
                {
                    model . DA007 = row [ "DA007" ] . ToString ( );
                }
                if ( row [ "DA008" ] != null )
                {
                    model . DA008 = row [ "DA008" ] . ToString ( );
                }
                if ( row [ "DA009" ] != null )
                {
                    model . DA009 = row [ "DA009" ] . ToString ( );
                }
                if ( row [ "DA010" ] != null && row [ "DA010" ] . ToString ( ) != "" )
                {
                    model . DA010 = DateTime . Parse ( row [ "DA010" ] . ToString ( ) );
                }
                if ( row [ "DA011" ] != null && row [ "DA011" ] . ToString ( ) != "" )
                {
                    model . DA011 = DateTime . Parse ( row [ "DA011" ] . ToString ( ) );
                }
                if ( row [ "DA012" ] != null && row [ "DA012" ] . ToString ( ) != "" )
                {
                    model . DA012 = DateTime . Parse ( row [ "DA012" ] . ToString ( ) );
                }
                if ( row [ "DA013" ] != null && row [ "DA013" ] . ToString ( ) != "" )
                {
                    model . DA013 = DateTime . Parse ( row [ "DA013" ] . ToString ( ) );
                }
                if ( row [ "DA014" ] != null )
                {
                    model . DA014 = row [ "DA014" ] . ToString ( );
                }
                if ( row [ "DA015" ] != null && row [ "DA015" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DA015" ] . ToString ( ) == "1" ) || ( row [ "DA015" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DA015 = true;
                    }
                    else
                    {
                        model . DA015 = false;
                    }
                }
                if ( row [ "DA016" ] != null && row [ "DA016" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DA016" ] . ToString ( ) == "1" ) || ( row [ "DA016" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DA016 = true;
                    }
                    else
                    {
                        model . DA016 = false;
                    }
                }
                if ( row [ "DA017" ] != null && row [ "DA017" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DA017" ] . ToString ( ) == "1" ) || ( row [ "DA017" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DA017 = true;
                    }
                    else
                    {
                        model . DA017 = false;
                    }
                }
                if ( row [ "DA018" ] != null )
                {
                    model . DA018 = row [ "DA018" ] . ToString ( );
                }
                if ( row [ "DA019" ] != null && row [ "DA019" ] . ToString ( ) != "" )
                {
                    model . DA019 = DateTime . Parse ( row [ "DA019" ] . ToString ( ) );
                }
                if ( row [ "DA020" ] != null )
                {
                    model . DA020 = row [ "DA020" ] . ToString ( );
                }
                if ( row [ "DA021" ] != null && row [ "DA021" ] . ToString ( ) != "" )
                {
                    model . DA021 = DateTime . Parse ( row [ "DA021" ] . ToString ( ) );
                }
            }

            return model;
        }

        /// <summary>
        /// get data from r_pqda for columns
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DA001,DA002,DA003,DA004,DA005 FROM R_PQDA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqda 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT DA001,DA002,DA003,DA004,DA005 FROM R_PQDA WHERE {0} ) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqda to view for by page 
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DA001,DA002,DA003,DA005,DA004,RES05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.DA001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQDA T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON DA001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get max oddNum from r_pqch
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DA001) DA001 FROM R_PQDA " );
            strSql . AppendFormat ( "WHERE DA001 LIKE 'R_142-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "DA001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_142-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_142-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_142-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
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
            strSql . Append ( "DELETE FROM R_PQDA " );
            strSql . AppendFormat ( "WHERE DA001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_142" ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQDB " );
            strSql . AppendFormat ( "WHERE DB001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_142" ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_142" ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqda r_pqdb 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_da"></param>
        /// <param name="bodyList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . TestReportForAQDAEntity _da ,List<string> bodyList ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( _da . idx < 1 )
            {
                _da . DA001 = getOddNum ( );
                add_da ( SQLString ,strSql ,_da );
                SQLString . Add ( Drity . DrityOfComparation ( "R_142" ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,_da . DA001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }
            else
            {
                edit_da ( SQLString ,strSql ,_da );
                SQLString . Add ( Drity . DrityOfComparation ( "R_142" ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,_da . DA001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }

            MulaolaoLibrary . TestReportForAQDBEntity model = new MulaolaoLibrary . TestReportForAQDBEntity ( );
            model . DB001 = _da . DA001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                model . DB002 = table . Rows [ i ] [ "DB002" ] . ToString ( );
                model . DB003 = table . Rows [ i ] [ "DB003" ] . ToString ( );
                model . DB004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB004" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB004" ] . ToString ( ) );
                model . DB005 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB005" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB005" ] . ToString ( ) );
                model . DB006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB006" ] . ToString ( ) );
                model . DB007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB007" ] . ToString ( ) );
                model . DB008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB008" ] . ToString ( ) );
                model . DB009 = table . Rows [ i ] [ "DB009" ] . ToString ( );
                model . DB010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "DB010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DB010" ] . ToString ( ) );
                if ( model . idx < 1 )
                {
                    add_db ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_142" + i ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,_da . DA001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表身" ) ,null );
                }
                else
                {
                    edit_db ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_142" + i ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,_da . DA001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_db ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_142" + model . idx ,"QA测试报告(R_142)" ,logins ,Drity . GetDt ( ) ,_da . DA001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表身" ) ,null );
                }
            }


            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_da ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestReportForAQDAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDA(" );
            strSql . Append ( "DA001,DA002,DA003,DA004,DA005,DA006,DA007,DA008,DA009,DA010,DA011,DA012,DA013,DA014,DA015,DA016,DA017,DA018,DA019,DA020,DA021)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DA001,@DA002,@DA003,@DA004,@DA005,@DA006,@DA007,@DA008,@DA009,@DA010,@DA011,@DA012,@DA013,@DA014,@DA015,@DA016,@DA017,@DA018,@DA019,@DA020,@DA021)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DA003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA006", SqlDbType.Int,4),
                    new SqlParameter("@DA007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA010", SqlDbType.Date,3),
                    new SqlParameter("@DA011", SqlDbType.Date,3),
                    new SqlParameter("@DA012", SqlDbType.Date,3),
                    new SqlParameter("@DA013", SqlDbType.Date,3),
                    new SqlParameter("@DA014", SqlDbType.NVarChar,200),
                    new SqlParameter("@DA015", SqlDbType.Bit,1),
                    new SqlParameter("@DA016", SqlDbType.Bit,1),
                    new SqlParameter("@DA017", SqlDbType.Bit,1),
                    new SqlParameter("@DA018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA019", SqlDbType.Date,3),
                    new SqlParameter("@DA020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA021", SqlDbType.Date,3)
            };
            parameters [ 0 ] . Value = model . DA001;
            parameters [ 1 ] . Value = model . DA002;
            parameters [ 2 ] . Value = model . DA003;
            parameters [ 3 ] . Value = model . DA004;
            parameters [ 4 ] . Value = model . DA005;
            parameters [ 5 ] . Value = model . DA006;
            parameters [ 6 ] . Value = model . DA007;
            parameters [ 7 ] . Value = model . DA008;
            parameters [ 8 ] . Value = model . DA009;
            parameters [ 9 ] . Value = model . DA010;
            parameters [ 10 ] . Value = model . DA011;
            parameters [ 11 ] . Value = model . DA012;
            parameters [ 12 ] . Value = model . DA013;
            parameters [ 13 ] . Value = model . DA014;
            parameters [ 14 ] . Value = model . DA015;
            parameters [ 15 ] . Value = model . DA016;
            parameters [ 16 ] . Value = model . DA017;
            parameters [ 17 ] . Value = model . DA018;
            parameters [ 18 ] . Value = model . DA019;
            parameters [ 19 ] . Value = model . DA020;
            parameters [ 20 ] . Value = model . DA021;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_da ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestReportForAQDAEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDA set " );
            strSql . Append ( "DA001=@DA001," );
            strSql . Append ( "DA002=@DA002," );
            strSql . Append ( "DA003=@DA003," );
            strSql . Append ( "DA004=@DA004," );
            strSql . Append ( "DA005=@DA005," );
            strSql . Append ( "DA006=@DA006," );
            strSql . Append ( "DA007=@DA007," );
            strSql . Append ( "DA008=@DA008," );
            strSql . Append ( "DA009=@DA009," );
            strSql . Append ( "DA010=@DA010," );
            strSql . Append ( "DA011=@DA011," );
            strSql . Append ( "DA012=@DA012," );
            strSql . Append ( "DA013=@DA013," );
            strSql . Append ( "DA014=@DA014," );
            strSql . Append ( "DA015=@DA015," );
            strSql . Append ( "DA016=@DA016," );
            strSql . Append ( "DA017=@DA017," );
            strSql . Append ( "DA018=@DA018," );
            strSql . Append ( "DA019=@DA019," );
            strSql . Append ( "DA020=@DA020," );
            strSql . Append ( "DA021=@DA021 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DA001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DA003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA006", SqlDbType.Int,4),
                    new SqlParameter("@DA007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA010", SqlDbType.Date,3),
                    new SqlParameter("@DA011", SqlDbType.Date,3),
                    new SqlParameter("@DA012", SqlDbType.Date,3),
                    new SqlParameter("@DA013", SqlDbType.Date,3),
                    new SqlParameter("@DA014", SqlDbType.NVarChar,200),
                    new SqlParameter("@DA015", SqlDbType.Bit,1),
                    new SqlParameter("@DA016", SqlDbType.Bit,1),
                    new SqlParameter("@DA017", SqlDbType.Bit,1),
                    new SqlParameter("@DA018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA019", SqlDbType.Date,3),
                    new SqlParameter("@DA020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DA021", SqlDbType.Date,3),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DA001;
            parameters [ 1 ] . Value = model . DA002;
            parameters [ 2 ] . Value = model . DA003;
            parameters [ 3 ] . Value = model . DA004;
            parameters [ 4 ] . Value = model . DA005;
            parameters [ 5 ] . Value = model . DA006;
            parameters [ 6 ] . Value = model . DA007;
            parameters [ 7 ] . Value = model . DA008;
            parameters [ 8 ] . Value = model . DA009;
            parameters [ 9 ] . Value = model . DA010;
            parameters [ 10 ] . Value = model . DA011;
            parameters [ 11 ] . Value = model . DA012;
            parameters [ 12 ] . Value = model . DA013;
            parameters [ 13 ] . Value = model . DA014;
            parameters [ 14 ] . Value = model . DA015;
            parameters [ 15 ] . Value = model . DA016;
            parameters [ 16 ] . Value = model . DA017;
            parameters [ 17 ] . Value = model . DA018;
            parameters [ 18 ] . Value = model . DA019;
            parameters [ 19 ] . Value = model . DA020;
            parameters [ 20 ] . Value = model . DA021;
            parameters [ 21 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_db ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestReportForAQDBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDB(" );
            strSql . Append ( "DB001,DB002,DB003,DB004,DB005,DB006,DB007,DB008,DB009,DB010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DB001,@DB002,@DB003,@DB004,@DB005,@DB006,@DB007,@DB008,@DB009,@DB010)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DB002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DB004", SqlDbType.Int,4),
                    new SqlParameter("@DB005", SqlDbType.Int,4),
                    new SqlParameter("@DB006", SqlDbType.Int,4),
                    new SqlParameter("@DB007", SqlDbType.Int,4),
                    new SqlParameter("@DB008", SqlDbType.Int,4),
                    new SqlParameter("@DB009", SqlDbType.NVarChar,100),
                    new SqlParameter("@DB010", SqlDbType.Int,4)
            };

            parameters [ 0 ] . Value = model . DB001;
            parameters [ 1 ] . Value = model . DB002;
            parameters [ 2 ] . Value = model . DB003;
            parameters [ 3 ] . Value = model . DB004;
            parameters [ 4 ] . Value = model . DB005;
            parameters [ 5 ] . Value = model . DB006;
            parameters [ 6 ] . Value = model . DB007;
            parameters [ 7 ] . Value = model . DB008;
            parameters [ 8 ] . Value = model . DB009;
            parameters [ 9 ] . Value = model . DB010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_db ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestReportForAQDBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDB set " );
            strSql . Append ( "DB001=@DB001," );
            strSql . Append ( "DB002=@DB002," );
            strSql . Append ( "DB003=@DB003," );
            strSql . Append ( "DB004=@DB004," );
            strSql . Append ( "DB005=@DB005," );
            strSql . Append ( "DB006=@DB006," );
            strSql . Append ( "DB007=@DB007," );
            strSql . Append ( "DB008=@DB008," );
            strSql . Append ( "DB009=@DB009," );
            strSql . Append ( "DB010=@DB010 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DB002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DB004", SqlDbType.Int,4),
                    new SqlParameter("@DB005", SqlDbType.Int,4),
                    new SqlParameter("@DB006", SqlDbType.Int,4),
                    new SqlParameter("@DB007", SqlDbType.Int,4),
                    new SqlParameter("@DB008", SqlDbType.Int,4),
                    new SqlParameter("@DB009", SqlDbType.NVarChar,100),
                    new SqlParameter("@DB010", SqlDbType.Int,4),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DB001;
            parameters [ 1 ] . Value = model . DB002;
            parameters [ 2 ] . Value = model . DB003;
            parameters [ 3 ] . Value = model . DB004;
            parameters [ 4 ] . Value = model . DB005;
            parameters [ 5 ] . Value = model . DB006;
            parameters [ 6 ] . Value = model . DB007;
            parameters [ 7 ] . Value = model . DB008;
            parameters [ 8 ] . Value = model . DB009;
            parameters [ 9 ] . Value = model . DB010;
            parameters [ 10 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_db ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestReportForAQDBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQDB " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,DB001,DB002,DB003,DB004,DB005,DB006,DB007,DB008,DB009 FROM R_PQDB WHERE DB001='{0}'" ,oddNum );

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
            strSql . AppendFormat ( "SELECT idx,DA001,DA002,DA003,DA004,DA005,DA006,DA007,DA008,DA009,DA010,DA011,DA012,DA013,DA014,DA015,DA016,DA017,DA018,DA019,DA020,DA021 FROM R_PQDA WHERE DA001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
