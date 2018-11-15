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
    public class FeedTestDao
    {
        /// <summary>
        /// get supplier from tpadga
        /// </summary>
        /// <returns></returns>
        public DataTable getSupplier ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DGA001,DGA003 FROM TPADGA" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get product info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF06 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 WHERE RES05='执行' " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get part from contract for num
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getPart ( string num ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT 'R_338' TAB,idx,JM09 ONE,CONVERT(VARCHAR,JM94)+'*'+CONVERT(VARCHAR,JM95)+'*'+CONVERT(VARCHAR,JM96) TWO,JM10 TRE FROM R_PQO WHERE JM90='{0}' AND idx NOT IN (SELECT CP002 FROM R_PQCP WHERE CP001='R_338' AND CP006='{1}') " ,num ,oddNum );
            strSql . Append ( " UNION " );
            strSql . AppendFormat ( "SELECT 'R_343' TAB,idx,PQU10,PQU12,PQU13 FROM R_PQU WHERE PQU01='{0}' AND idx NOT IN (SELECT CP002 FROM R_PQCP WHERE CP001='R_343' AND CP006='{1}')  " ,num ,oddNum );
            strSql . Append ( " UNION " );
            strSql . AppendFormat ( "SELECT 'R_347' TAB,idx,PJ09,PJ89,PJ11 FROM R_PQS WHERE PJ01='{0}' AND idx NOT IN (SELECT CP002 FROM R_PQCP WHERE CP001='R_347' AND CP006='{1}') " ,num ,oddNum );
            strSql . Append ( " UNION " );
            strSql . AppendFormat ( "SELECT 'R_349' TAB,idx,WX10,WX11,WX14 FROM R_PQT WHERE WX01='{0}'  AND idx NOT IN (SELECT CP002 FROM R_PQCP WHERE CP001='R_349' AND CP006='{1}') " ,num ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get sampling from baseISO 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getSam ( int num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT CL003,CL004,CL005,CL006,CL007 FROM R_PQCL WHERE {0} between CL001 and CL002 order by CL001" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get column from r_pqcn
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CN001,CN003,CN005,CN004,CN012,DGA003,CN002 FROM R_PQCN A INNER JOIN TPADGA B ON A.CN002=B.DGA001 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqcn
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT CN001,CN002,CN003,CN004,CN005,CN012 FROM R_PQCN WHERE {0}) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj != null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqbn by change
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT CN001,DGA003 CN002,CN003,CN004,CN005,CN012,RES05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.CN001 DESC)" );
            strSql . Append ( "AS Row,T.* FROM R_PQCN T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT INNER JOIN TPADGA B ON TT.CN002=B.DGA001 LEFT JOIN R_REVIEWS ON CN001=RES06 " );
            strSql . AppendFormat ( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqco for oddnum to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,CO002,CO003,CO004,CO005,CO006,CO007,CO008,CO009,CO010,CO011 FROM R_PQCO " );
            strSql . AppendFormat ( "WHERE {0} ORDER BY CO010" ,strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqcn
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . FeedTestCNEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CN001,CN002,CN003,CN004,CN005,CN006,CN007,CN008,CN009,CN010,CN011,CN012,CN013,CN014,CN015,CN016,CN017,CN018,CN019,CN020,CN021,CN022,CN023,CN024,CN025,CN026,CN027,CN028,CN029,CN030,CN031 FROM R_PQCN " );
            strSql . AppendFormat ( "WHERE CN001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . FeedTestCNEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . FeedTestCNEntity model = new MulaolaoLibrary . FeedTestCNEntity ( );

            if ( row != null )
            {
                if ( row [ "CN001" ] != null )
                {
                    model . CN001 = row [ "CN001" ] . ToString ( );
                }
                if ( row [ "CN002" ] != null )
                {
                    model . CN002 = row [ "CN002" ] . ToString ( );
                }
                if ( row [ "CN003" ] != null )
                {
                    model . CN003 = row [ "CN003" ] . ToString ( );
                }
                if ( row [ "CN004" ] != null )
                {
                    model . CN004 = row [ "CN004" ] . ToString ( );
                }
                if ( row [ "CN005" ] != null )
                {
                    model . CN005 = row [ "CN005" ] . ToString ( );
                }
                if ( row [ "CN006" ] != null && row [ "CN006" ] . ToString ( ) != "" )
                {
                    model . CN006 = int . Parse ( row [ "CN006" ] . ToString ( ) );
                }
                if ( row [ "CN007" ] != null && row [ "CN007" ] . ToString ( ) != "" )
                {
                    model . CN007 = DateTime . Parse ( row [ "CN007" ] . ToString ( ) );
                }
                if ( row [ "CN008" ] != null && row [ "CN008" ] . ToString ( ) != "" )
                {
                    model . CN008 = DateTime . Parse ( row [ "CN008" ] . ToString ( ) );
                }
                //if ( row [ "CN009" ] != null )
                //{
                //    model . CN009 = row [ "CN009" ] . ToString ( );
                //}
                if ( row [ "CN010" ] != null )
                {
                    model . CN010 = row [ "CN010" ] . ToString ( );
                }
                if ( row [ "CN011" ] != null && row [ "CN011" ] . ToString ( ) != "" )
                {
                    model . CN011 = DateTime . Parse ( row [ "CN011" ] . ToString ( ) );
                }
                if ( row [ "CN012" ] != null )
                {
                    model . CN012 = row [ "CN012" ] . ToString ( );
                }
                //if ( row [ "CN013" ] != null && row [ "CN013" ] . ToString ( ) != "" )
                //{
                //    model . CN013 = int . Parse ( row [ "CN013" ] . ToString ( ) );
                //}
                if ( row [ "CN014" ] != null )
                {
                    model . CN014 = row [ "CN014" ] . ToString ( );
                }
                if ( row [ "CN015" ] != null && row [ "CN015" ] . ToString ( ) != "" )
                {
                    model . CN015 = decimal . Parse ( row [ "CN015" ] . ToString ( ) );
                }
                if ( row [ "CN016" ] != null && row [ "CN016" ] . ToString ( ) != "" )
                {
                    model . CN016 = int . Parse ( row [ "CN016" ] . ToString ( ) );
                }
                if ( row [ "CN017" ] != null && row [ "CN017" ] . ToString ( ) != "" )
                {
                    model . CN017 = int . Parse ( row [ "CN017" ] . ToString ( ) );
                }
                if ( row [ "CN018" ] != null && row [ "CN018" ] . ToString ( ) != "" )
                {
                    model . CN018 = int . Parse ( row [ "CN018" ] . ToString ( ) );
                }
                if ( row [ "CN019" ] != null && row [ "CN019" ] . ToString ( ) != "" )
                {
                    model . CN019 = decimal . Parse ( row [ "CN019" ] . ToString ( ) );
                }
                if ( row [ "CN020" ] != null && row [ "CN020" ] . ToString ( ) != "" )
                {
                    model . CN020 = int . Parse ( row [ "CN020" ] . ToString ( ) );
                }
                if ( row [ "CN021" ] != null && row [ "CN021" ] . ToString ( ) != "" )
                {
                    model . CN021 = int . Parse ( row [ "CN021" ] . ToString ( ) );
                }
                if ( row [ "CN022" ] != null && row [ "CN022" ] . ToString ( ) != "" )
                {
                    model . CN022 = int . Parse ( row [ "CN022" ] . ToString ( ) );
                }
                if ( row [ "CN023" ] != null && row [ "CN023" ] . ToString ( ) != "" )
                {
                    model . CN023 = decimal . Parse ( row [ "CN023" ] . ToString ( ) );
                }
                if ( row [ "CN024" ] != null && row [ "CN024" ] . ToString ( ) != "" )
                {
                    model . CN024 = int . Parse ( row [ "CN024" ] . ToString ( ) );
                }
                if ( row [ "CN025" ] != null && row [ "CN025" ] . ToString ( ) != "" )
                {
                    model . CN025 = int . Parse ( row [ "CN025" ] . ToString ( ) );
                }
                if ( row [ "CN026" ] != null && row [ "CN026" ] . ToString ( ) != "" )
                {
                    model . CN026 = int . Parse ( row [ "CN026" ] . ToString ( ) );
                }
                if ( row [ "CN027" ] != null && row [ "CN027" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "CN027" ] . ToString ( ) == "1" ) || ( row [ "CN027" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . CN027 = true;
                    }
                    else
                    {
                        model . CN027 = false;
                    }
                }
                if ( row [ "CN028" ] != null && row [ "CN028" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "CN028" ] . ToString ( ) == "1" ) || ( row [ "CN028" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . CN028 = true;
                    }
                    else
                    {
                        model . CN028 = false;
                    }
                }
                if ( row [ "CN029" ] != null )
                {
                    model . CN029 = row [ "CN029" ] . ToString ( );
                }
                if ( row [ "CN030" ] != null && row [ "CN030" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "CN030" ] . ToString ( ) == "1" ) || ( row [ "CN030" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . CN030 = true;
                    }
                    else
                    {
                        model . CN030 = false;
                    }
                }
                if ( row [ "CN031" ] != null && row [ "CN031" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "CN031" ] . ToString ( ) == "1" ) || ( row [ "CN031" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . CN031 = true;
                    }
                    else
                    {
                        model . CN031 = false;
                    }
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
            strSql . Append ( "SELECT MAX(CN001) CN001 FROM R_PQCN " );
            strSql . AppendFormat ( "WHERE CN001 LIKE 'R_044-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "CN001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_044-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_044-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_044-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqcN and r_pqc0 AND r_pqcp, and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCN " );
            strSql . AppendFormat ( "WHERE CN001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_044" ,"IQC进料检验报告(R_044)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCO " );
            strSql . AppendFormat ( "WHERE CO001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_044" ,"IQC进料检验报告(R_044)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCP " );
            strSql . AppendFormat ( "WHERE CP006='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_044" ,"IQC进料检验报告(R_044)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_REVIEWS " );
            strSql . AppendFormat ( "WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_044" ,"IQC进料检验报告(R_044)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqcn r_pqco r_pqcp
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cn"></param>
        /// <param name="ModelCp"></param>
        /// <returns></returns>
        public bool Save ( DataTable table,MulaolaoLibrary. FeedTestCNEntity _cn ,List<MulaolaoLibrary . FeedTestCPEntity> ModelCp )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            MulaolaoLibrary . FeedTestCOEntity _co = new MulaolaoLibrary . FeedTestCOEntity ( );
            _cn . CN001 = _co . CO001 = getOddNum ( );
            add_cn ( SQLString ,strSql ,_cn );

            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _co . CO002 = table . Rows [ i ] [ "CO002" ] . ToString ( );
                _co . CO003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO003" ] . ToString ( ) );
                _co . CO004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO004" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO004" ] . ToString ( ) );
                _co . CO005 = table . Rows [ i ] [ "CO005" ] . ToString ( );
                _co . CO006 = table . Rows [ i ] [ "CO006" ] . ToString ( );
                _co . CO007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO007" ] . ToString ( ) );
                _co . CO008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO008" ] . ToString ( ) );
                _co . CO009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO009" ] . ToString ( ) );
                _co . CO010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO010" ] . ToString ( ) );
                _co . CO011 = table . Rows [ i ] [ "CO011" ] . ToString ( );
                add_co ( SQLString ,strSql ,_co );
            }

            foreach ( MulaolaoLibrary . FeedTestCPEntity cp in ModelCp )
            {
                cp . CP001 = _cn . CN001;
                add_cp ( SQLString ,strSql ,cp );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_cn ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCNEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCN(" );
            strSql . Append ( "CN001,CN002,CN003,CN004,CN005,CN006,CN007,CN008,CN010,CN011,CN012,CN014,CN015,CN016,CN017,CN018,CN019,CN020,CN021,CN022,CN023,CN024,CN025,CN026,CN027,CN028,CN029)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CN001,@CN002,@CN003,@CN004,@CN005,@CN006,@CN007,@CN008,@CN010,@CN011,@CN012,@CN014,@CN015,@CN016,@CN017,@CN018,@CN019,@CN020,@CN021,@CN022,@CN023,@CN024,@CN025,@CN026,@CN027,@CN028,@CN029)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CN001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN006", SqlDbType.Int,4),
                    new SqlParameter("@CN007", SqlDbType.Date,3),
                    new SqlParameter("@CN008", SqlDbType.Date,3),
                    //new SqlParameter("@CN009", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN010", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN011", SqlDbType.Date,3),
                    new SqlParameter("@CN012", SqlDbType.NVarChar,20),
                    //new SqlParameter("@CN013", SqlDbType.Int,4),
                    new SqlParameter("@CN014", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN015", SqlDbType.Decimal,9),
                    new SqlParameter("@CN016", SqlDbType.Int,4),
                    new SqlParameter("@CN017", SqlDbType.Int,4),
                    new SqlParameter("@CN018", SqlDbType.Int,4),
                    new SqlParameter("@CN019", SqlDbType.Decimal,9),
                    new SqlParameter("@CN020", SqlDbType.Int,4),
                    new SqlParameter("@CN021", SqlDbType.Int,4),
                    new SqlParameter("@CN022", SqlDbType.Int,4),
                    new SqlParameter("@CN023", SqlDbType.Decimal,9),
                    new SqlParameter("@CN024", SqlDbType.Int,4),
                    new SqlParameter("@CN025", SqlDbType.Int,4),
                    new SqlParameter("@CN026", SqlDbType.Int,4),
                    new SqlParameter("@CN027", SqlDbType.Bit,1),
                    new SqlParameter("@CN028", SqlDbType.Bit,1),
                    new SqlParameter("@CN029", SqlDbType.NVarChar,500)
            };
            parameters [ 0 ] . Value = model . CN001;
            parameters [ 1 ] . Value = model . CN002;
            parameters [ 2 ] . Value = model . CN003;
            parameters [ 3 ] . Value = model . CN004;
            parameters [ 4 ] . Value = model . CN005;
            parameters [ 5 ] . Value = model . CN006;
            parameters [ 6 ] . Value = model . CN007;
            parameters [ 7 ] . Value = model . CN008;
            //parameters [ 8 ] . Value = model . CN009;
            parameters [ 8 ] . Value = model . CN010;
            parameters [ 9 ] . Value = model . CN011;
            parameters [ 10 ] . Value = model . CN012;
            //parameters [ 12 ] . Value = model . CN013;
            parameters [ 11 ] . Value = model . CN014;
            parameters [ 12 ] . Value = model . CN015;
            parameters [ 13 ] . Value = model . CN016;
            parameters [ 14 ] . Value = model . CN017;
            parameters [ 15 ] . Value = model . CN018;
            parameters [ 16 ] . Value = model . CN019;
            parameters [ 17 ] . Value = model . CN020;
            parameters [ 18 ] . Value = model . CN021;
            parameters [ 19 ] . Value = model . CN022;
            parameters [ 20 ] . Value = model . CN023;
            parameters [ 21 ] . Value = model . CN024;
            parameters [ 22 ] . Value = model . CN025;
            parameters [ 23 ] . Value = model . CN026;
            parameters [ 24 ] . Value = model . CN027;
            parameters [ 25 ] . Value = model . CN028;
            parameters [ 26 ] . Value = model . CN029;

            SQLString . Add ( strSql ,parameters );
        }

        void add_co ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCOEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCO(" );
            strSql . Append ( "CO001,CO002,CO003,CO004,CO005,CO006,CO007,CO008,CO009,CO010,CO011)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CO001,@CO002,@CO003,@CO004,@CO005,@CO006,@CO007,@CO008,@CO009,@CO010,@CO011)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CO001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO002", SqlDbType.NVarChar,200),
                    new SqlParameter("@CO003", SqlDbType.Int,4),
                    new SqlParameter("@CO004", SqlDbType.Int,4),
                    new SqlParameter("@CO005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO006", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO007", SqlDbType.Int,4),
                    new SqlParameter("@CO008", SqlDbType.Int,4),
                    new SqlParameter("@CO009", SqlDbType.Int,4),
                    new SqlParameter("@CO010", SqlDbType.Int,4),
                    new SqlParameter("@CO011", SqlDbType.NVarChar,1000)
            };
            parameters [ 0 ] . Value = model . CO001;
            parameters [ 1 ] . Value = model . CO002;
            parameters [ 2 ] . Value = model . CO003;
            parameters [ 3 ] . Value = model . CO004;
            parameters [ 4 ] . Value = model . CO005;
            parameters [ 5 ] . Value = model . CO006;
            parameters [ 6 ] . Value = model . CO007;
            parameters [ 7 ] . Value = model . CO008;
            parameters [ 8 ] . Value = model . CO009;
            parameters [ 9 ] . Value = model . CO010;
            parameters [ 10 ] . Value = model . CO011;

            SQLString . Add ( strSql ,parameters );
        }

        void add_cp ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCPEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQCP(" );
            strSql . Append ( "CP001,CP002,CP003,CP004,CP005,CP006)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@CP001,@CP002,@CP003,@CP004,@CP005,@CP006)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CP001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP002", SqlDbType.Int,4),
                    new SqlParameter("@CP003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP005", SqlDbType.Decimal,9),
                    new SqlParameter("@CP006", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . CP001;
            parameters [ 1 ] . Value = model . CP002;
            parameters [ 2 ] . Value = model . CP003;
            parameters [ 3 ] . Value = model . CP004;
            parameters [ 4 ] . Value = model . CP005;
            parameters [ 5 ] . Value = model . CP006;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// edit data to r_pqcn r_pqco r_pqcp
        /// </summary>
        /// <param name="table"></param>
        /// <param name="_cn"></param>
        /// <param name="ModelCp"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . FeedTestCNEntity _cn ,List<MulaolaoLibrary . FeedTestCPEntity> ModelCp,List<string> strList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            edit_cn ( SQLString ,strSql ,_cn );
            
            MulaolaoLibrary . FeedTestCOEntity _co = new MulaolaoLibrary . FeedTestCOEntity ( );
            _co . CO001 = _cn . CN001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _co . CO002 = table . Rows [ i ] [ "CO002" ] . ToString ( );
                _co . CO003 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO003" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO003" ] . ToString ( ) );
                _co . CO004 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO004" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO004" ] . ToString ( ) );
                _co . CO005 = table . Rows [ i ] [ "CO005" ] . ToString ( );
                _co . CO006 = table . Rows [ i ] [ "CO006" ] . ToString ( );
                _co . CO007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO007" ] . ToString ( ) );
                _co . CO008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO008" ] . ToString ( ) );
                _co . CO009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO009" ] . ToString ( ) );
                _co . CO010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "CO010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "CO010" ] . ToString ( ) );
                _co . CO011 = table . Rows [ i ] [ "CO011" ] . ToString ( );
                _co . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _co . idx > 0 )
                    edit_co ( SQLString ,strSql ,_co );
                else
                    add_co ( SQLString ,strSql ,_co );
            }

            if ( strList . Count > 0 )
            {
                foreach ( string s in strList )
                {
                    _co . idx = Convert . ToInt32 ( s );
                    delete_co ( SQLString ,strSql ,_co );
                }
            }

            DataTable ta = getCP ( _cn . CN001 );
            foreach ( MulaolaoLibrary . FeedTestCPEntity cp in ModelCp )
            {
                cp . CP001 = _cn . CN001;
                if ( cp . idx == 0 )
                    delete_cp ( SQLString ,strSql ,cp );
                else
                {
                    if ( Exists ( cp . idx ) )
                        edit_cp ( SQLString ,strSql ,cp );
                }
            }

            if ( ta != null && ta . Rows . Count > 0 )
            {
                MulaolaoLibrary . FeedTestCPEntity cp = new MulaolaoLibrary . FeedTestCPEntity ( );
                cp . CP001 = _cn . CN001;
                for ( int i = 0 ; i < ta . Rows . Count ; i++ )
                {
                    bool result = false;
                    cp . idx = string . IsNullOrEmpty ( ta . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( ta . Rows [ i ] [ "idx" ] . ToString ( ) );
                    if ( cp . idx > 0 )
                    {
                        foreach ( MulaolaoLibrary . FeedTestCPEntity cpM in ModelCp )
                        {
                            if ( cp . idx == cpM . idx )
                            {
                                result = true;
                                break;
                            }
                        }

                        if ( result == false )
                            delete_cp ( SQLString ,strSql ,cp );
                    }
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit_cn ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCNEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCN set " );
            strSql . Append ( "CN002=@CN002," );
            strSql . Append ( "CN003=@CN003," );
            strSql . Append ( "CN004=@CN004," );
            strSql . Append ( "CN005=@CN005," );
            strSql . Append ( "CN006=@CN006," );
            strSql . Append ( "CN007=@CN007," );
            strSql . Append ( "CN008=@CN008," );
            strSql . Append ( "CN009=@CN009," );
            strSql . Append ( "CN010=@CN010," );
            strSql . Append ( "CN011=@CN011," );
            strSql . Append ( "CN012=@CN012," );
            strSql . Append ( "CN013=@CN013," );
            strSql . Append ( "CN014=@CN014," );
            strSql . Append ( "CN015=@CN015," );
            strSql . Append ( "CN016=@CN016," );
            strSql . Append ( "CN017=@CN017," );
            strSql . Append ( "CN018=@CN018," );
            strSql . Append ( "CN019=@CN019," );
            strSql . Append ( "CN020=@CN020," );
            strSql . Append ( "CN021=@CN021," );
            strSql . Append ( "CN022=@CN022," );
            strSql . Append ( "CN023=@CN023," );
            strSql . Append ( "CN024=@CN024," );
            strSql . Append ( "CN025=@CN025," );
            strSql . Append ( "CN026=@CN026," );
            strSql . Append ( "CN027=@CN027," );
            strSql . Append ( "CN030=@CN030," );
            strSql . Append ( "CN028=@CN028," );
            strSql . Append ( "CN031=@CN031," );
            strSql . Append ( "CN029=@CN029 " );
            strSql . Append ( " where CN001=@CN001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CN001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN002", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN003", SqlDbType.NVarChar,50),
                    new SqlParameter("@CN004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN006", SqlDbType.Int,4),
                    new SqlParameter("@CN007", SqlDbType.Date,3),
                    new SqlParameter("@CN008", SqlDbType.Date,3),
                    new SqlParameter("@CN009", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN010", SqlDbType.NVarChar,200),
                    new SqlParameter("@CN011", SqlDbType.Date,3),
                    new SqlParameter("@CN012", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN013", SqlDbType.Int,4),
                    new SqlParameter("@CN014", SqlDbType.NVarChar,20),
                    new SqlParameter("@CN015", SqlDbType.Decimal,9),
                    new SqlParameter("@CN016", SqlDbType.Int,4),
                    new SqlParameter("@CN017", SqlDbType.Int,4),
                    new SqlParameter("@CN018", SqlDbType.Int,4),
                    new SqlParameter("@CN019", SqlDbType.Decimal,9),
                    new SqlParameter("@CN020", SqlDbType.Int,4),
                    new SqlParameter("@CN021", SqlDbType.Int,4),
                    new SqlParameter("@CN022", SqlDbType.Int,4),
                    new SqlParameter("@CN023", SqlDbType.Decimal,9),
                    new SqlParameter("@CN024", SqlDbType.Int,4),
                    new SqlParameter("@CN025", SqlDbType.Int,4),
                    new SqlParameter("@CN026", SqlDbType.Int,4),
                    new SqlParameter("@CN027", SqlDbType.Bit,1),
                    new SqlParameter("@CN030", SqlDbType.Bit,1),
                    new SqlParameter("@CN028", SqlDbType.Bit,1),
                    new SqlParameter("@CN031", SqlDbType.Bit,1),
                    new SqlParameter("@CN029", SqlDbType.NVarChar,500)
            };
            parameters [ 0 ] . Value = model . CN001;
            parameters [ 1 ] . Value = model . CN002;
            parameters [ 2 ] . Value = model . CN003;
            parameters [ 3 ] . Value = model . CN004;
            parameters [ 4 ] . Value = model . CN005;
            parameters [ 5 ] . Value = model . CN006;
            parameters [ 6 ] . Value = model . CN007;
            parameters [ 7 ] . Value = model . CN008;
            parameters [ 8 ] . Value = model . CN009;
            parameters [ 9 ] . Value = model . CN010;
            parameters [ 10 ] . Value = model . CN011;
            parameters [ 11 ] . Value = model . CN012;
            parameters [ 12 ] . Value = model . CN013;
            parameters [ 13 ] . Value = model . CN014;
            parameters [ 14 ] . Value = model . CN015;
            parameters [ 15 ] . Value = model . CN016;
            parameters [ 16 ] . Value = model . CN017;
            parameters [ 17 ] . Value = model . CN018;
            parameters [ 18 ] . Value = model . CN019;
            parameters [ 19 ] . Value = model . CN020;
            parameters [ 20 ] . Value = model . CN021;
            parameters [ 21 ] . Value = model . CN022;
            parameters [ 22 ] . Value = model . CN023;
            parameters [ 23 ] . Value = model . CN024;
            parameters [ 24 ] . Value = model . CN025;
            parameters [ 25 ] . Value = model . CN026;
            parameters [ 26 ] . Value = model . CN027;
            parameters [ 27 ] . Value = model . CN030;
            parameters [ 28 ] . Value = model . CN028;
            parameters [ 29 ] . Value = model . CN031;
            parameters [ 30 ] . Value = model . CN029;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_co ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCOEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCO set " );
            strSql . Append ( "CO001=@CO001," );
            strSql . Append ( "CO002=@CO002," );
            strSql . Append ( "CO003=@CO003," );
            strSql . Append ( "CO004=@CO004," );
            strSql . Append ( "CO005=@CO005," );
            strSql . Append ( "CO006=@CO006," );
            strSql . Append ( "CO007=@CO007," );
            strSql . Append ( "CO008=@CO008," );
            strSql . Append ( "CO009=@CO009," );
            strSql . Append ( "CO010=@CO010," );
            strSql . Append ( "CO011=@CO011 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CO001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO002", SqlDbType.NVarChar,200),
                    new SqlParameter("@CO003", SqlDbType.Int,4),
                    new SqlParameter("@CO004", SqlDbType.Int,4),
                    new SqlParameter("@CO005", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO006", SqlDbType.NVarChar,20),
                    new SqlParameter("@CO007", SqlDbType.Int,4),
                    new SqlParameter("@CO008", SqlDbType.Int,4),
                    new SqlParameter("@CO009", SqlDbType.Int,4),
                    new SqlParameter("@CO010", SqlDbType.Int,4),
                    new SqlParameter("@CO011", SqlDbType.NVarChar,1000),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CO001;
            parameters [ 1 ] . Value = model . CO002;
            parameters [ 2 ] . Value = model . CO003;
            parameters [ 3 ] . Value = model . CO004;
            parameters [ 4 ] . Value = model . CO005;
            parameters [ 5 ] . Value = model . CO006;
            parameters [ 6 ] . Value = model . CO007;
            parameters [ 7 ] . Value = model . CO008;
            parameters [ 8 ] . Value = model . CO009;
            parameters [ 9 ] . Value = model . CO010;
            parameters [ 10 ] . Value = model . CO011;
            parameters [ 11 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_co ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCOEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQCO " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        void delete_cp ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCPEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQCP WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQCP WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_cp ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . FeedTestCPEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQCP set " );
            strSql . Append ( "CP001=@CP001," );
            strSql . Append ( "CP002=@CP002," );
            strSql . Append ( "CP003=@CP003," );
            strSql . Append ( "CP004=@CP004," );
            strSql . Append ( "CP005=@CP005," );
            strSql . Append ( "CP006=@CP006 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@CP001", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP002", SqlDbType.Int,4),
                    new SqlParameter("@CP003", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP004", SqlDbType.NVarChar,20),
                    new SqlParameter("@CP005", SqlDbType.Decimal,9),
                    new SqlParameter("@CP006", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . CP001;
            parameters [ 1 ] . Value = model . CP002;
            parameters [ 2 ] . Value = model . CP003;
            parameters [ 3 ] . Value = model . CP004;
            parameters [ 4 ] . Value = model . CP005;
            parameters [ 5 ] . Value = model . CP006;
            parameters [ 6 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        DataTable getCP ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx FROM R_PQCP WHERE CP006='{0}'" ,oddNum );

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
            strSql . AppendFormat ( "SELECT CN001,CN002,DGA003,CN003,CN004,CN005,CN006,CN007,CN008,CN009,CN010,CN011,CN012,CN013,CN014,CN015,CN016,CN017,CN018,CN019,CN020,CN021,CN022,CN023,CN024,CN025,CN026,CN027,CN028,CN029,CN030,CN031 FROM R_PQCN A LEFT JOIN TPADGA B ON A.CN002=B.DGA001 WHERE CN001='{0}'" ,oddNum );

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
            strSql . AppendFormat ( "SELECT idx,CO002,CO003,CO004,CO005,CO006,CO007,CO008,CO009 FROM R_PQCO WHERE CO001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
