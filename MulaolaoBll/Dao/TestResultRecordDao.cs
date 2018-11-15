using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class TestResultRecordDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF07,PQF08,DFA003,PQF66 FROM R_PQF A INNER JOIN TPADFA B ON A.PQF11=B.DFA001  INNER JOIN R_REVIEWS C ON A.PQF01=C.RES06 WHERE RES05='执行' ORDER BY PQF01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get base info from r_pqcr
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CR001,CR002,CR003,CR004,CR006,CR011 FROM R_PQCR " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count for condition
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT CR001,CR002,CR003,CR004,CR006,CR011 FROM R_PQCR WHERE {0} ) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqcn by change page
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CR001,CR002,CR003,CR004,CR006,CR011,RES05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER ( " );
            strSql . Append ( "ORDER BY T.CR001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQCR T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON CR001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqcs to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CS001,CS002,CS003,CS004,CS005,CS006,CS007,CS008,CS009,CS010,CS011 FROM R_PQCS " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqct to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableViewOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CT001,CT002,CT003,CT004,CT005,CT006,CT007,CT009,CT010,CT011,CT012,CT013,CT014 FROM R_PQCT " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcr 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . TestResultRecordCREntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CR001,CR002,CR003,CR004,CR005,CR006,CR007,CR008,CR009,CR010,CR011 FROM R_PQCR " );
            strSql . AppendFormat ( "WHERE CR001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . TestResultRecordCREntity getModel ( DataRow row )
        {
            MulaolaoLibrary . TestResultRecordCREntity model = new MulaolaoLibrary . TestResultRecordCREntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row["idx"].ToString()!="" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "CR001" ] != null )
                {
                    model . CR001 = row [ "CR001" ] . ToString ( );
                }
                if ( row [ "CR002" ] != null )
                {
                    model . CR002 = row [ "CR002" ] . ToString ( );
                }
                if ( row [ "CR003" ] != null )
                {
                    model . CR003 = row [ "CR003" ] . ToString ( );
                }
                if ( row [ "CR004" ] != null )
                {
                    model . CR004 = row [ "CR004" ] . ToString ( );
                }
                if ( row [ "CR005" ] != null )
                {
                    model . CR005 = row [ "CR005" ] . ToString ( );
                }
                if ( row [ "CR006" ] != null )
                {
                    model . CR006 = row [ "CR006" ] . ToString ( );
                }
                if ( row [ "CR007" ] != null )
                {
                    model . CR007 = row [ "CR007" ] . ToString ( );
                }
                if ( row [ "CR008" ] != null )
                {
                    model . CR008 = row [ "CR008" ] . ToString ( );
                }
                if ( row [ "CR009" ] != null )
                {
                    model . CR009 = row [ "CR009" ] . ToString ( );
                }
                if ( row [ "CR010" ] != null )
                {
                    model . CR010 = row [ "CR010" ] . ToString ( );
                }
                if ( row [ "CR011" ] != null )
                {
                    model . CR011 = row [ "CR011" ] . ToString ( );
                }
            }

            return model;
        }

        /// <summary>
        /// get max oddNum from r_pqch
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CR001) CR001 FROM R_PQCR " );
            strSql . AppendFormat ( "WHERE CR001 LIKE 'R_418-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CR001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_418-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_418-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_418-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqcr and r_pqcs and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCR " );
            strSql . AppendFormat ( "WHERE CR001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_418" ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCS " );
            strSql . AppendFormat ( "WHERE CS001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_418" ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_418" ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to databse 
        /// </summary>
        /// <param name="table">单身</param>
        /// <param name="_cr">单头</param>
        /// <param name="tableOne">系数</param>
        /// <param name="coeList">系数删除</param>
        /// <param name="bodyList">单身删除</param>
        /// <param name="logins">登录人</param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . TestResultRecordCREntity _cr ,DataTable tableOne ,List<string> coeList,List<string> bodyList,string logins)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( _cr . idx < 1 )
            {
                _cr . CR001 = getOddNum ( );
                add_cr ( SQLString ,strSql ,_cr );
                SQLString . Add ( Drity . DrityOfComparation ( "R_418" ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }
            else
            {
                edit_cr ( SQLString ,strSql ,_cr );
                SQLString . Add ( Drity . DrityOfComparation ( "R_418" ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }


            MulaolaoLibrary . TestResultRecordCSEntity _cs = new MulaolaoLibrary . TestResultRecordCSEntity ( );
            _cs . CS001 = _cr . CR001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CS002" ] . ToString ( ) ) )
                    _cs . CS002 = null;
                else
                    _cs . CS002 = Convert . ToDateTime ( table . Rows [ i ] [ "CS002" ] . ToString ( ) );
                _cs . CS003 = table . Rows [ i ] [ "CS003" ] . ToString ( );
                _cs . CS004 = table . Rows [ i ] [ "CS004" ] . ToString ( );
                _cs . CS005 = table . Rows [ i ] [ "CS005" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CS006" ] . ToString ( ) ) )
                    _cs . CS006 = null;
                else
                    _cs . CS006 = Convert . ToDateTime ( table . Rows [ i ] [ "CS006" ] . ToString ( ) );
                _cs . CS007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CS007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CS007" ] . ToString ( ) );
                _cs . CS008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CS008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CS008" ] . ToString ( ) );
                _cs . CS009 = table . Rows [ i ] [ "CS009" ] . ToString ( );
                _cs . CS010 = table . Rows [ i ] [ "CS010" ] . ToString ( );
                _cs . CS011 = table . Rows [ i ] [ "CS011" ] . ToString ( );
                _cs . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _cs . idx < 1 )
                {
                    add_cs ( SQLString ,strSql ,_cs );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + i ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增单身" ) ,null );
                }
                else
                {
                    edit_cs ( SQLString ,strSql ,_cs );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + i ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"编辑单身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    delete_cs ( SQLString ,strSql ,_cs );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + s ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"删除单身" ) ,null );
                }
            }

            MulaolaoLibrary . TestResultRecordCTEntity _ct = new MulaolaoLibrary . TestResultRecordCTEntity ( );
            for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
            {
                _ct . CT001 = tableOne . Rows [ i ] [ "CT001" ] . ToString ( );
                _ct . CT002 = tableOne . Rows [ i ] [ "CT002" ] . ToString ( );
                _ct . CT003 = tableOne . Rows [ i ] [ "CT003" ] . ToString ( );
                _ct . CT004 = tableOne . Rows [ i ] [ "CT004" ] . ToString ( );
                _ct . CT005 = tableOne . Rows [ i ] [ "CT005" ] . ToString ( );
                _ct . CT006 = tableOne . Rows [ i ] [ "CT006" ] . ToString ( );
                _ct . CT007 = tableOne . Rows [ i ] [ "CT007" ] . ToString ( );
                _ct . CT009 = tableOne . Rows [ i ] [ "CT009" ] . ToString ( );
                _ct . CT010 = tableOne . Rows [ i ] [ "CT010" ] . ToString ( );
                _ct . CT011 = tableOne . Rows [ i ] [ "CT011" ] . ToString ( );
                _ct . CT012 = tableOne . Rows [ i ] [ "CT012" ] . ToString ( );
                _ct . CT013 = tableOne . Rows [ i ] [ "CT013" ] . ToString ( );
                _ct . CT014 = tableOne . Rows [ i ] [ "CT014" ] . ToString ( );
                _ct . idx = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _ct . idx < 1 )
                {
                    add_ct ( SQLString ,strSql ,_ct );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + i ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增系数" ) ,null );
                }
                else
                {
                    edit_ct ( SQLString ,strSql ,_ct );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + i ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"编辑系数" ) ,null );
                }
            }

            if ( coeList . Count > 0 )
            {
                foreach ( string s in coeList )
                {
                    _ct . idx = Convert . ToInt32 ( s );
                    delete_dt ( SQLString ,strSql ,_ct );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_418-" + s ,"产品粘接、组装人员牢固度安全常态抽测结果记录(R_418)" ,logins ,Drity . GetDt ( ) ,_cr . CR001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"删除系数" ) ,null );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void add_cr ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCREntity model )
        {
            strSql = new StringBuilder ( );
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCR(" );
            strSql . Append ( "CR001,CR002,CR003,CR004,CR005,CR006,CR007,CR008,CR009,CR010,CR011)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CR001,@CR002,@CR003,@CR004,@CR005,@CR006,@CR007,@CR008,@CR009,@CR010,@CR011)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CR001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR002", SqlDbType.NVarChar,50),
                    new SqlParameter("@CR003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CR007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR011", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CR001;
            parameters [ 1 ] . Value = model . CR002;
            parameters [ 2 ] . Value = model . CR003;
            parameters [ 3 ] . Value = model . CR004;
            parameters [ 4 ] . Value = model . CR005;
            parameters [ 5 ] . Value = model . CR006;
            parameters [ 6 ] . Value = model . CR007;
            parameters [ 7 ] . Value = model . CR008;
            parameters [ 8 ] . Value = model . CR009;
            parameters [ 9 ] . Value = model . CR010;
            parameters [ 10 ] . Value = model . CR011;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cr ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCREntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQCR SET " );
            strSql . Append ( "CR001=@CR001," );
            strSql . Append ( "CR002=@CR002," );
            strSql . Append ( "CR003=@CR003," );
            strSql . Append ( "CR004=@CR004," );
            strSql . Append ( "CR005=@CR005," );
            strSql . Append ( "CR006=@CR006," );
            strSql . Append ( "CR007=@CR007," );
            strSql . Append ( "CR008=@CR008," );
            strSql . Append ( "CR009=@CR009," );
            strSql . Append ( "CR010=@CR010," );
            strSql . Append ( "CR011=@CR011 " );
            strSql . Append ( "WHERE idx=@idx" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CR001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR002", SqlDbType.NVarChar,50),
                    new SqlParameter("@CR003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CR007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CR011", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CR001;
            parameters [ 1 ] . Value = model . CR002;
            parameters [ 2 ] . Value = model . CR003;
            parameters [ 3 ] . Value = model . CR004;
            parameters [ 4 ] . Value = model . CR005;
            parameters [ 5 ] . Value = model . CR006;
            parameters [ 6 ] . Value = model . CR007;
            parameters [ 7 ] . Value = model . CR008;
            parameters [ 8 ] . Value = model . CR009;
            parameters [ 9 ] . Value = model . CR010;
            parameters [ 10 ] . Value = model . CR011;
            parameters [ 11 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_cs ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCSEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCS(" );
            strSql . Append ( "CS001,CS002,CS003,CS004,CS005,CS006,CS007,CS008,CS009,CS010,CS011)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CS001,@CS002,@CS003,@CS004,@CS005,@CS006,@CS007,@CS008,@CS009,@CS010,@CS011)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CS001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS002", SqlDbType.Date,3),
                    new SqlParameter("@CS003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS004", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS006", SqlDbType.Date,3),
                    new SqlParameter("@CS007", SqlDbType.Int,4),
                    new SqlParameter("@CS008", SqlDbType.Int,4),
                    new SqlParameter("@CS009", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS011", SqlDbType.NVarChar,100)
            };
            parameters [ 0 ] . Value = model . CS001;
            parameters [ 1 ] . Value = model . CS002;
            parameters [ 2 ] . Value = model . CS003;
            parameters [ 3 ] . Value = model . CS004;
            parameters [ 4 ] . Value = model . CS005;
            parameters [ 5 ] . Value = model . CS006;
            parameters [ 6 ] . Value = model . CS007;
            parameters [ 7 ] . Value = model . CS008;
            parameters [ 8 ] . Value = model . CS009;
            parameters [ 9 ] . Value = model . CS010;
            parameters [ 10 ] . Value = model . CS011;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_cs ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCSEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCS set " );
            strSql . Append ( "CS001=@CS001," );
            strSql . Append ( "CS002=@CS002," );
            strSql . Append ( "CS003=@CS003," );
            strSql . Append ( "CS004=@CS004," );
            strSql . Append ( "CS005=@CS005," );
            strSql . Append ( "CS006=@CS006," );
            strSql . Append ( "CS007=@CS007," );
            strSql . Append ( "CS008=@CS008," );
            strSql . Append ( "CS009=@CS009," );
            strSql . Append ( "CS010=@CS010," );
            strSql . Append ( "CS011=@CS011 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CS001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS002", SqlDbType.Date,3),
                    new SqlParameter("@CS003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS004", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS006", SqlDbType.Date,3),
                    new SqlParameter("@CS007", SqlDbType.Int,4),
                    new SqlParameter("@CS008", SqlDbType.Int,4),
                    new SqlParameter("@CS009", SqlDbType.NVarChar,50),
                    new SqlParameter("@CS010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CS011", SqlDbType.NVarChar,100),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CS001;
            parameters [ 1 ] . Value = model . CS002;
            parameters [ 2 ] . Value = model . CS003;
            parameters [ 3 ] . Value = model . CS004;
            parameters [ 4 ] . Value = model . CS005;
            parameters [ 5 ] . Value = model . CS006;
            parameters [ 6 ] . Value = model . CS007;
            parameters [ 7 ] . Value = model . CS008;
            parameters [ 8 ] . Value = model . CS009;
            parameters [ 9 ] . Value = model . CS010;
            parameters [ 10 ] . Value = model . CS011;
            parameters [ 11 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_cs ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCSEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCS " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_ct ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCTEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCT(" );
            strSql . Append ( "CT001,CT002,CT003,CT004,CT005,CT006,CT007,CT009,CT010,CT011,CT012,CT013,CT014)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CT001,@CT002,@CT003,@CT004,@CT005,@CT006,@CT007,@CT009,@CT010,@CT011,@CT012,@CT013,@CT014)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@CT001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CT002", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT003", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT004", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT005", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT006", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT007", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT009", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT010", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT011", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT012", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT013", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT014", SqlDbType.NVarChar,10)
            };
            parameters [ 0 ] . Value = model . CT001;
            parameters [ 1 ] . Value = model . CT002;
            parameters [ 2 ] . Value = model . CT003;
            parameters [ 3 ] . Value = model . CT004;
            parameters [ 4 ] . Value = model . CT005;
            parameters [ 5 ] . Value = model . CT006;
            parameters [ 6 ] . Value = model . CT007;
            parameters [ 7 ] . Value = model . CT009;
            parameters [ 8 ] . Value = model . CT010;
            parameters [ 9 ] . Value = model . CT011;
            parameters [ 10 ] . Value = model . CT012;
            parameters [ 11 ] . Value = model . CT013;
            parameters [ 12 ] . Value = model . CT014;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_ct ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCTEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCT set " );
            strSql . Append ( "CT001=@CT001," );
            strSql . Append ( "CT002=@CT002," );
            strSql . Append ( "CT003=@CT003," );
            strSql . Append ( "CT004=@CT004," );
            strSql . Append ( "CT005=@CT005," );
            strSql . Append ( "CT006=@CT006," );
            strSql . Append ( "CT007=@CT007," );
            strSql . Append ( "CT009=@CT009," );
            strSql . Append ( "CT010=@CT010," );
            strSql . Append ( "CT011=@CT011," );
            strSql . Append ( "CT012=@CT012," );
            strSql . Append ( "CT013=@CT013," );
            strSql . Append ( "CT014=@CT014 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CT001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CT002", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT003", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT004", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT005", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT006", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT007", SqlDbType.NVarChar,100),
                    new SqlParameter("@CT009", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT010", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT011", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT012", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT013", SqlDbType.NVarChar,10),
                    new SqlParameter("@CT014", SqlDbType.NVarChar,10),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CT001;
            parameters [ 1 ] . Value = model . CT002;
            parameters [ 2 ] . Value = model . CT003;
            parameters [ 3 ] . Value = model . CT004;
            parameters [ 4 ] . Value = model . CT005;
            parameters [ 5 ] . Value = model . CT006;
            parameters [ 6 ] . Value = model . CT007;
            parameters [ 7 ] . Value = model . CT009;
            parameters [ 8 ] . Value = model . CT010;
            parameters [ 9 ] . Value = model . CT011;
            parameters [ 10 ] . Value = model . CT012;
            parameters [ 11 ] . Value = model . CT013;
            parameters [ 12 ] . Value = model . CT014;
            parameters [ 13 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_dt ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . TestResultRecordCTEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCT " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
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
        /// get data from r_pqct
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CT001+CT009 CT FROM R_PQCT WHERE  CT009!='' " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT CT001+CT010 FROM R_PQCT WHERE  CT010!='' " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT CT001+CT011 FROM R_PQCT WHERE  CT011!='' " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT CT001+CT012 FROM R_PQCT WHERE  CT012!='' " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT CT001+CT013 FROM R_PQCT WHERE  CT013!='' " );
            strSql . Append ( "UNION " );
            strSql . Append ( "SELECT CT001+CT014 FROM R_PQCT WHERE  CT014!='' " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table from r_pqcr to print info 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CR001,CR009,CR010,CR011,CR008,CR007,CR006,CR005,CR004,CR003,CR002 FROM R_PQCR WHERE CR001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table from r_pqcs to print info
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CS002,CS003,CS004,CS005,CS006,CS007,CS008,CS009,CS010,CS011 FROM R_PQCS WHERE CS001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
