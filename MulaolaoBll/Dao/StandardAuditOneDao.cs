using System;
using System . Data;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data . SqlClient;
using System . Collections . Generic;

namespace MulaolaoBll . Dao
{
    public class StandardAuditOneDao
    {
        /// <summary>
        /// get data from r_pqcc to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CC001,CC002,CC003,CC004,CC005,CC006,CC007,CC008,CC009,CC010,CC011,CC012,CC013,CC014,CC015,CC016,CC017,CC018,CC019,CC020,CC021 FROM R_PQCC " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcb
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . StandardAuditOneCBEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CB001,CB002,CB003,CB004,CB005,CB006,CB007,CB008,CB009,CB010 FROM R_PQCB WHERE CB001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getDataRow ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . StandardAuditOneCBEntity getDataRow ( DataRow row )
        {
            MulaolaoLibrary . StandardAuditOneCBEntity model = new MulaolaoLibrary . StandardAuditOneCBEntity ( );
            if ( row != null )
            {
                if ( row [ "CB001" ] != null )
                    model . CB001 = row [ "CB001" ] . ToString ( );
                if ( row [ "CB002" ] != null )
                    model . CB002 = row [ "CB002" ] . ToString ( );
                if ( row [ "CB003" ] != null )
                    model . CB003 = row [ "CB003" ] . ToString ( );
                if ( row [ "CB004" ] != null )
                    model . CB004 = row [ "CB004" ] . ToString ( );
                if ( row [ "CB005" ] != null && row [ "CB005" ] . ToString ( ) != string . Empty )
                    model . CB005 = int . Parse ( row [ "CB005" ] . ToString ( ) );
                if ( row [ "CB006" ] != null )
                    model . CB006 = row [ "CB006" ] . ToString ( );
                if ( row [ "CB007" ] != null )
                    model . CB007 = row [ "CB007" ] . ToString ( );
                if ( row [ "CB008" ] != null )
                    model . CB008 = row [ "CB008" ] . ToString ( );
                if ( row [ "CB009" ] != null )
                    model . CB009 = row [ "CB009" ] . ToString ( );
                if ( row [ "CB010" ] != null )
                    model . CB010 = row [ "CB010" ] . ToString ( );
            }

            return model;
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
        /// get max oddNum from r_pqcb
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(CB001) CB001 FROM R_PQCB " );
            strSql . AppendFormat ( "WHERE CB001 LIKE 'R_482-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CB001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_482-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_482-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_482-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
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
            strSql . Append ( "DELETE FROM R_PQCC " );
            strSql . AppendFormat ( "WHERE CC001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCB " );
            strSql . AppendFormat ( "WHERE CB001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcb and r_pqcc
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,MulaolaoLibrary . StandardAuditOneCBEntity _cb ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            _cb . CB001 = getOddNum ( );
            add_pqcb ( SQLString ,strSql ,_cb );
            SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,_cb . CB001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
            
            MulaolaoLibrary . StandardAuditOneCCEntity _cc = new MulaolaoLibrary . StandardAuditOneCCEntity ( );
            _cc . CC001 = _cb . CB001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _cc . CC002 = table . Rows [ i ] [ "CC002" ] . ToString ( );
                _cc . CC003 = table . Rows [ i ] [ "CC003" ] . ToString ( );
                _cc . CC004 = table . Rows [ i ] [ "CC004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC005" ] . ToString ( ) ) )
                    _cc . CC005 = null;
                else
                    _cc . CC005 = Convert . ToDateTime ( table . Rows [ i ] [ "CC005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC006" ] . ToString ( ) ) )
                    _cc . CC006 = null;
                else
                    _cc . CC006 = Convert . ToDateTime ( table . Rows [ i ] [ "CC006" ] );
                _cc . CC007 = table . Rows [ i ] [ "CC007" ] . ToString ( );
                _cc . CC008 = table . Rows [ i ] [ "CC008" ] . ToString ( );
                _cc . CC009 = table . Rows [ i ] [ "CC009" ] . ToString ( );
                _cc . CC010 = table . Rows [ i ] [ "CC010" ] . ToString ( );
                _cc . CC011 = table . Rows [ i ] [ "CC011" ] . ToString ( );
                _cc . CC012 = table . Rows [ i ] [ "CC012" ] . ToString ( );
                _cc . CC013 = table . Rows [ i ] [ "CC013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC014" ] . ToString ( ) ) )
                    _cc . CC014 = null;
                else
                    _cc . CC014 = Convert . ToDateTime ( table . Rows [ i ] [ "CC014" ] );
                _cc . CC015 = table . Rows [ i ] [ "CC015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC016" ] . ToString ( ) ) )
                    _cc . CC016 = null;
                else
                    _cc . CC016 = Convert . ToDateTime ( table . Rows [ i ] [ "CC016" ] );
                _cc . CC017 = table . Rows [ i ] [ "CC017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC018" ] . ToString ( ) ) )
                    _cc . CC018 = null;
                else
                    _cc . CC018 = Convert . ToDateTime ( table . Rows [ i ] [ "CC018" ] );
                _cc . CC019 = table . Rows [ i ] [ "CC019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC020" ] . ToString ( ) ) )
                    _cc . CC020 = null;
                else
                    _cc . CC020 = Convert . ToDateTime ( table . Rows [ i ] [ "CC020" ] );
                _cc . CC021 = table . Rows [ i ] [ "CC021" ] . ToString ( );
                add_pqcc ( SQLString ,strSql ,_cc ,logins );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        void add_pqcb ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditOneCBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCB(" );
            strSql . Append ( "CB001,CB002,CB003,CB004,CB005,CB006,CB007,CB008,CB009,CB010)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CB001,@CB002,@CB003,@CB004,@CB005,@CB006,@CB007,@CB008,@CB009,@CB010)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CB004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB005", SqlDbType.Int,4),
                    new SqlParameter("@CB006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CB007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CB001;
            parameters [ 1 ] . Value = model . CB002;
            parameters [ 2 ] . Value = model . CB003;
            parameters [ 3 ] . Value = model . CB004;
            parameters [ 4 ] . Value = model . CB005;
            parameters [ 5 ] . Value = model . CB006;
            parameters [ 6 ] . Value = model . CB007;
            parameters [ 7 ] . Value = model . CB008;
            parameters [ 8 ] . Value = model . CB009;
            parameters [ 9 ] . Value = model . CB010;

            SQLString . Add ( strSql ,parameters );
        }

        void add_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditOneCCEntity model ,string logins)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCC(" );
            strSql . Append ( "CC001,CC002,CC003,CC004,CC005,CC006,CC007,CC008,CC009,CC010,CC011,CC012,CC013,CC014,CC015,CC016,CC017,CC018,CC019,CC020,CC021)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CC001,@CC002,@CC003,@CC004,@CC005,@CC006,@CC007,@CC008,@CC009,@CC010,@CC011,@CC012,@CC013,@CC014,@CC015,@CC016,@CC017,@CC018,@CC019,@CC020,@CC021)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC005", SqlDbType.Date,3),
                    new SqlParameter("@CC006", SqlDbType.Date,3),
                    new SqlParameter("@CC007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC014", SqlDbType.Date,3),
                    new SqlParameter("@CC015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC016", SqlDbType.Date,3),
                    new SqlParameter("@CC017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC018", SqlDbType.Date,3),
                    new SqlParameter("@CC019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC020", SqlDbType.Date,3),
                    new SqlParameter("@CC021", SqlDbType.NVarChar,100)
            };
            parameters [ 0 ] . Value = model . CC001;
            parameters [ 1 ] . Value = model . CC002;
            parameters [ 2 ] . Value = model . CC003;
            parameters [ 3 ] . Value = model . CC004;
            parameters [ 4 ] . Value = model . CC005;
            parameters [ 5 ] . Value = model . CC006;
            parameters [ 6 ] . Value = model . CC007;
            parameters [ 7 ] . Value = model . CC008;
            parameters [ 8 ] . Value = model . CC009;
            parameters [ 9 ] . Value = model . CC010;
            parameters [ 10 ] . Value = model . CC011;
            parameters [ 11 ] . Value = model . CC012;
            parameters [ 12 ] . Value = model . CC013;
            parameters [ 13 ] . Value = model . CC014;
            parameters [ 14 ] . Value = model . CC015;
            parameters [ 15 ] . Value = model . CC016;
            parameters [ 16 ] . Value = model . CC017;
            parameters [ 17 ] . Value = model . CC018;
            parameters [ 18 ] . Value = model . CC019;
            parameters [ 19 ] . Value = model . CC020;
            parameters [ 20 ] . Value = model . CC021;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增" ) ,null );
        }

        /// <summary>
        /// edit data from r_pqcb and r_pqcc to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cb"></param>
        /// <param name="logins"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . StandardAuditOneCBEntity _cb ,string logins ,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_pqcb ( SQLString ,strSql ,_cb );
            SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,_cb . CB001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );

            MulaolaoLibrary . StandardAuditOneCCEntity _cc = new MulaolaoLibrary . StandardAuditOneCCEntity ( );
            _cc . CC001 = _cb . CB001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _cc . CC002 = table . Rows [ i ] [ "CC002" ] . ToString ( );
                _cc . CC003 = table . Rows [ i ] [ "CC003" ] . ToString ( );
                _cc . CC004 = table . Rows [ i ] [ "CC004" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC005" ] . ToString ( ) ) )
                    _cc . CC005 = null;
                else
                    _cc . CC005 = Convert . ToDateTime ( table . Rows [ i ] [ "CC005" ] );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC006" ] . ToString ( ) ) )
                    _cc . CC006 = null;
                else
                    _cc . CC006 = Convert . ToDateTime ( table . Rows [ i ] [ "CC006" ] );
                _cc . CC007 = table . Rows [ i ] [ "CC007" ] . ToString ( );
                _cc . CC008 = table . Rows [ i ] [ "CC008" ] . ToString ( );
                _cc . CC009 = table . Rows [ i ] [ "CC009" ] . ToString ( );
                _cc . CC010 = table . Rows [ i ] [ "CC010" ] . ToString ( );
                _cc . CC011 = table . Rows [ i ] [ "CC011" ] . ToString ( );
                _cc . CC012 = table . Rows [ i ] [ "CC012" ] . ToString ( );
                _cc . CC013 = table . Rows [ i ] [ "CC013" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC014" ] . ToString ( ) ) )
                    _cc . CC014 = null;
                else
                    _cc . CC014 = Convert . ToDateTime ( table . Rows [ i ] [ "CC014" ] );
                _cc . CC015 = table . Rows [ i ] [ "CC015" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC016" ] . ToString ( ) ) )
                    _cc . CC016 = null;
                else
                    _cc . CC016 = Convert . ToDateTime ( table . Rows [ i ] [ "CC016" ] );
                _cc . CC017 = table . Rows [ i ] [ "CC017" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC018" ] . ToString ( ) ) )
                    _cc . CC018 = null;
                else
                    _cc . CC018 = Convert . ToDateTime ( table . Rows [ i ] [ "CC018" ] );
                _cc . CC019 = table . Rows [ i ] [ "CC019" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "CC020" ] . ToString ( ) ) )
                    _cc . CC020 = null;
                else
                    _cc . CC020 = Convert . ToDateTime ( table . Rows [ i ] [ "CC020" ] );
                _cc . CC021 = table . Rows [ i ] [ "CC021" ] . ToString ( );
                _cc . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _cc . idx < 1 )
                    add_pqcc ( SQLString ,strSql ,_cc ,logins );
                else
                    edit_pqcc ( SQLString ,strSql ,_cc ,logins );
            }

            foreach ( string s in strList )
            {
                _cc . idx = Convert . ToInt32 ( s );
                delete_pqcc ( SQLString ,strSql ,_cc ,logins );            
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_pqcb ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditOneCBEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCB set " );
            strSql . Append ( "CB002=@CB002," );
            strSql . Append ( "CB003=@CB003," );
            strSql . Append ( "CB004=@CB004," );
            strSql . Append ( "CB005=@CB005," );
            strSql . Append ( "CB006=@CB006," );
            strSql . Append ( "CB007=@CB007," );
            strSql . Append ( "CB008=@CB008," );
            strSql . Append ( "CB009=@CB009," );
            strSql . Append ( "CB010=@CB010 " );
            strSql . Append ( " where CB001=@CB001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CB004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB005", SqlDbType.Int,4),
                    new SqlParameter("@CB006", SqlDbType.NVarChar,50),
                    new SqlParameter("@CB007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CB010", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CB001;
            parameters [ 1 ] . Value = model . CB002;
            parameters [ 2 ] . Value = model . CB003;
            parameters [ 3 ] . Value = model . CB004;
            parameters [ 4 ] . Value = model . CB005;
            parameters [ 5 ] . Value = model . CB006;
            parameters [ 6 ] . Value = model . CB007;
            parameters [ 7 ] . Value = model . CB008;
            parameters [ 8 ] . Value = model . CB009;
            parameters [ 9 ] . Value = model . CB010;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditOneCCEntity model,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCC set " );
            strSql . Append ( "CC001=@CC001," );
            strSql . Append ( "CC002=@CC002," );
            strSql . Append ( "CC003=@CC003," );
            strSql . Append ( "CC004=@CC004," );
            strSql . Append ( "CC005=@CC005," );
            strSql . Append ( "CC006=@CC006," );
            strSql . Append ( "CC007=@CC007," );
            strSql . Append ( "CC008=@CC008," );
            strSql . Append ( "CC009=@CC009," );
            strSql . Append ( "CC010=@CC010," );
            strSql . Append ( "CC011=@CC011," );
            strSql . Append ( "CC012=@CC012," );
            strSql . Append ( "CC013=@CC013," );
            strSql . Append ( "CC014=@CC014," );
            strSql . Append ( "CC015=@CC015," );
            strSql . Append ( "CC016=@CC016," );
            strSql . Append ( "CC017=@CC017," );
            strSql . Append ( "CC018=@CC018," );
            strSql . Append ( "CC019=@CC019," );
            strSql . Append ( "CC020=@CC020," );
            strSql . Append ( "CC021=@CC021 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC005", SqlDbType.Date,3),
                    new SqlParameter("@CC006", SqlDbType.Date,3),
                    new SqlParameter("@CC007", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC008", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC009", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC010", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC011", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC013", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC014", SqlDbType.Date,3),
                    new SqlParameter("@CC015", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC016", SqlDbType.Date,3),
                    new SqlParameter("@CC017", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC018", SqlDbType.Date,3),
                    new SqlParameter("@CC019", SqlDbType.NVarChar,20),
                    new SqlParameter("@CC020", SqlDbType.Date,3),
                    new SqlParameter("@CC021", SqlDbType.NVarChar,100),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CC001;
            parameters [ 1 ] . Value = model . CC002;
            parameters [ 2 ] . Value = model . CC003;
            parameters [ 3 ] . Value = model . CC004;
            parameters [ 4 ] . Value = model . CC005;
            parameters [ 5 ] . Value = model . CC006;
            parameters [ 6 ] . Value = model . CC007;
            parameters [ 7 ] . Value = model . CC008;
            parameters [ 8 ] . Value = model . CC009;
            parameters [ 9 ] . Value = model . CC010;
            parameters [ 10 ] . Value = model . CC011;
            parameters [ 11 ] . Value = model . CC012;
            parameters [ 12 ] . Value = model . CC013;
            parameters [ 13 ] . Value = model . CC014;
            parameters [ 14 ] . Value = model . CC015;
            parameters [ 15 ] . Value = model . CC016;
            parameters [ 16 ] . Value = model . CC017;
            parameters [ 17 ] . Value = model . CC018;
            parameters [ 18 ] . Value = model . CC019;
            parameters [ 19 ] . Value = model . CC020;
            parameters [ 20 ] . Value = model . CC021;
            parameters [ 21 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑" ) ,null );
        }

        void delete_pqcc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . StandardAuditOneCCEntity model ,string logins )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQCC " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
            //SQLString . Add ( Drity . DrityOfComparation ( "R_482" ,"滚、喷、涂漆生产首件标准样审核确认记录表(R_482)" ,logins ,Drity . GetDt ( ) ,model . CC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"编辑删除" ) ,null );
        }

        /// <summary>
        /// get one column datasource from r_pqcb
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CB001,CB002,CB003,CB009 FROM R_PQCB ORDER BY CB001,CB002,CB003,CB009" );

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
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM (SELECT DISTINCT CB001,CB002,CB003,CB009 FROM R_PQCB WHERE {0}) A" ,strWhere );

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
        public DataTable getDataTableByChange ( string strWhere,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CB001,CB002,CB003,CB009,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CB001 DESC )" );
            strSql . Append ( "AS Row,T.* FROM R_PQCB T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON CB001=RES06" );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get user data from r_pqcb
        /// </summary>
        /// <returns></returns>
        public DataTable getUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CB007,CB008,CB009,CB010 FROM R_PQCB " );

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
            strSql . Append ( "SELECT CB001,CB002,CB003,CB004,CB005,CB006,CB007,CB008,CB009,CB010 FROM R_PQCB " );
            strSql . AppendFormat ( "WHERE CB001='{0}'" ,oddNum );

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
            strSql . Append ( "SELECT CC002,CC003,CC004,CC005,CC006,CC007,CC008,CC009,CC010,CC011,CC012,CC013,CC015,CC017,CC019,CC021 FROM R_PQCC " );
            strSql . AppendFormat ( "WHERE CC001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
