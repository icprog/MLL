using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Data;
using StudentMgr;
using System . Data . SqlClient;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class SafetyManegerAndControlDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF07,PQF08,PQF06 FROM R_PQF A INNER JOIN R_REVIEWS C ON A.PQF01=C.RES06 WHERE RES05='执行' ORDER BY PQF01" );

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
        /// get data from r_pqce to view
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfCoefficient ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DE001,DE002,DE003 FROM R_PQDE " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get item num from r_pqde
        /// </summary>
        /// <returns></returns>
        public DataTable itemNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DE002 FROM R_PQDE ORDER BY DE002" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqdd to view
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DD001,DD002,DD003,DD004,DD005,DD006,DD007,DD008,DD009,DD010,DD011,DD012,DD013,DD014,DD015,DD016,DD017,DD018,DD019,DD020,DD021,DD022,DD023,DD024,DD025,DD026,DD027,DD028,DD029,DD030,DD031,DD032,DD033,DD034,DD035,DD036,DD037,DD038,DD039,DD040,DD041,DD042,DD043,DD044,DD045,DD046,DD047,DD048,DD049,DD050,DD051,DD052,DD053,DD054,DD055,DD056 FROM R_PQDD " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource from r_pqdc 
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . SafetyManegerAndControlDCEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DC001,DC002,DC003,DC004,DC005,DC006,DC007,DC008,DC009,DC010,DC011,DC012,DC013,DC014,DC015,DC016,DC017,DC018,DC019,DC020,DC021,DC022,DC023,DC024,DC025,DC026,DC027,DC028,DC029,DC030,DC031,DC032 FROM R_PQDC " );
            strSql . Append ( " WHERE DC001=@DC001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DC001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . SafetyManegerAndControlDCEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . SafetyManegerAndControlDCEntity model = new MulaolaoLibrary . SafetyManegerAndControlDCEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "DC001" ] != null )
                {
                    model . DC001 = row [ "DC001" ] . ToString ( );
                }
                if ( row [ "DC002" ] != null )
                {
                    model . DC002 = row [ "DC002" ] . ToString ( );
                }
                if ( row [ "DC003" ] != null )
                {
                    model . DC003 = row [ "DC003" ] . ToString ( );
                }
                if ( row [ "DC004" ] != null )
                {
                    model . DC004 = row [ "DC004" ] . ToString ( );
                }
                if ( row [ "DC005" ] != null && row [ "DC005" ] . ToString ( ) != "" )
                {
                    model . DC005 = int . Parse ( row [ "DC005" ] . ToString ( ) );
                }
                if ( row [ "DC006" ] != null )
                {
                    model . DC006 = row [ "DC006" ] . ToString ( );
                }
                if ( row [ "DC007" ] != null )
                {
                    model . DC007 = row [ "DC007" ] . ToString ( );
                }
                if ( row [ "DC008" ] != null && row [ "DC008" ] . ToString ( ) != "" )
                {
                    model . DC008 = DateTime . Parse ( row [ "DC008" ] . ToString ( ) );
                }
                if ( row [ "DC009" ] != null )
                {
                    model . DC009 = row [ "DC009" ] . ToString ( );
                }
                if ( row [ "DC010" ] != null )
                {
                    model . DC010 = row [ "DC010" ] . ToString ( );
                }
                if ( row [ "DC011" ] != null )
                {
                    model . DC011 = row [ "DC011" ] . ToString ( );
                }
                if ( row [ "DC012" ] != null )
                {
                    model . DC012 = row [ "DC012" ] . ToString ( );
                }
                if ( row [ "DC013" ] != null )
                {
                    model . DC013 = row [ "DC013" ] . ToString ( );
                }
                if ( row [ "DC014" ] != null )
                {
                    model . DC014 = row [ "DC014" ] . ToString ( );
                }
                if ( row [ "DC015" ] != null && row [ "DC015" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC015" ] . ToString ( ) == "1" ) || ( row [ "DC015" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC015 = true;
                    }
                    else
                    {
                        model . DC015 = false;
                    }
                }
                if ( row [ "DC016" ] != null && row [ "DC016" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC016" ] . ToString ( ) == "1" ) || ( row [ "DC016" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC016 = true;
                    }
                    else
                    {
                        model . DC016 = false;
                    }
                }
                if ( row [ "DC017" ] != null && row [ "DC017" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC017" ] . ToString ( ) == "1" ) || ( row [ "DC017" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC017 = true;
                    }
                    else
                    {
                        model . DC017 = false;
                    }
                }
                if ( row [ "DC018" ] != null && row [ "DC018" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC018" ] . ToString ( ) == "1" ) || ( row [ "DC018" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC018 = true;
                    }
                    else
                    {
                        model . DC018 = false;
                    }
                }
                if ( row [ "DC019" ] != null && row [ "DC019" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC019" ] . ToString ( ) == "1" ) || ( row [ "DC019" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC019 = true;
                    }
                    else
                    {
                        model . DC019 = false;
                    }
                }
                if ( row [ "DC020" ] != null && row [ "DC020" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC020" ] . ToString ( ) == "1" ) || ( row [ "DC020" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC020 = true;
                    }
                    else
                    {
                        model . DC020 = false;
                    }
                }
                if ( row [ "DC021" ] != null && row [ "DC021" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC021" ] . ToString ( ) == "1" ) || ( row [ "DC021" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC021 = true;
                    }
                    else
                    {
                        model . DC021 = false;
                    }
                }
                if ( row [ "DC022" ] != null && row [ "DC022" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC022" ] . ToString ( ) == "1" ) || ( row [ "DC022" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC022 = true;
                    }
                    else
                    {
                        model . DC022 = false;
                    }
                }
                if ( row [ "DC023" ] != null && row [ "DC023" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC023" ] . ToString ( ) == "1" ) || ( row [ "DC023" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC023 = true;
                    }
                    else
                    {
                        model . DC023 = false;
                    }
                }
                if ( row [ "DC024" ] != null && row [ "DC024" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC024" ] . ToString ( ) == "1" ) || ( row [ "DC024" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC024 = true;
                    }
                    else
                    {
                        model . DC024 = false;
                    }
                }
                if ( row [ "DC025" ] != null && row [ "DC025" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC025" ] . ToString ( ) == "1" ) || ( row [ "DC025" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC025 = true;
                    }
                    else
                    {
                        model . DC025 = false;
                    }
                }
                if ( row [ "DC026" ] != null && row [ "DC026" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC026" ] . ToString ( ) == "1" ) || ( row [ "DC026" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC026 = true;
                    }
                    else
                    {
                        model . DC026 = false;
                    }
                }
                if ( row [ "DC027" ] != null && row [ "DC027" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC027" ] . ToString ( ) == "1" ) || ( row [ "DC027" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC027 = true;
                    }
                    else
                    {
                        model . DC027 = false;
                    }
                }
                if ( row [ "DC028" ] != null && row [ "DC028" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC028" ] . ToString ( ) == "1" ) || ( row [ "DC028" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC028 = true;
                    }
                    else
                    {
                        model . DC028 = false;
                    }
                }
                if ( row [ "DC029" ] != null && row [ "DC029" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC029" ] . ToString ( ) == "1" ) || ( row [ "DC029" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC029 = true;
                    }
                    else
                    {
                        model . DC029 = false;
                    }
                }
                if ( row [ "DC030" ] != null && row [ "DC030" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC030" ] . ToString ( ) == "1" ) || ( row [ "DC030" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC030 = true;
                    }
                    else
                    {
                        model . DC030 = false;
                    }
                }
                if ( row [ "DC031" ] != null && row [ "DC031" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC031" ] . ToString ( ) == "1" ) || ( row [ "DC031" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC031 = true;
                    }
                    else
                    {
                        model . DC031 = false;
                    }
                }
                if ( row [ "DC032" ] != null && row [ "DC032" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DC032" ] . ToString ( ) == "1" ) || ( row [ "DC032" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DC032 = true;
                    }
                    else
                    {
                        model . DC032 = false;
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// get data from r_pqdc 
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DC001,DC002,DC003,DC004,DC009,DC011 FROM R_PQDC " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqdc
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT DC001,DC002,DC003,DC004,DC009,DC011 FROM R_PQDC WHERE {0} ) A" ,strWhere );

            Object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get data from r_pqdc by page
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DC001,DC002,DC003,DC004,DC009,DC011,RES05 FROM ( " );
            strSql . Append ( "SELECT ROW_NUMBER() OVER( " );
            strSql . Append ( "ORDER BY T.DC001 DESC) " );
            strSql . Append ( "AS ROW,T.* FROM R_PQDC T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( " ) TT LEFT JOIN R_REVIEWS ON DC001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get max oddNum from r_pqdc
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DC001) DC001 FROM R_PQDC " );
            strSql . AppendFormat ( "WHERE DC001 LIKE 'R_429-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "DC001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_429-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_429-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_429-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqdc and r_pqdd and write operation to r_pqbf
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQDC " );
            strSql . AppendFormat ( "WHERE DC001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_429" ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQDD " );
            strSql . AppendFormat ( "WHERE DD001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_429" ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to r_pqdc,r_pqdd,r_pqde
        /// </summary>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <param name="_dc"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable tableOne ,DataTable tableTwo ,MulaolaoLibrary . SafetyManegerAndControlDCEntity _dc ,List<string> bodyList ,List<string> coeList ,string logins )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( _dc . idx > 0 )
            {
                edit_dc ( SQLString ,strSql ,_dc );
                SQLString . Add ( Drity . DrityOfComparation ( "R_429" ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }
            else
            {
                _dc . DC001 = getOddNum ( );
                add_dc ( SQLString ,strSql ,_dc );
                SQLString . Add ( Drity . DrityOfComparation ( "R_429" ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }

            MulaolaoLibrary . SafetyManegerAndControlDDEntity model = new MulaolaoLibrary . SafetyManegerAndControlDDEntity ( );
            model . DD001 = _dc . DC001;
            for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
            {
                model . idx = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD002" ] . ToString ( ) ) )
                    model . DD002 = null;
                else
                    model . DD002 = Convert . ToDateTime ( tableOne . Rows [ i ] [ "DD002" ] . ToString ( ) );
                model . DD003 = tableOne . Rows [ i ] [ "DD003" ] . ToString ( );
                model . DD004 = tableOne . Rows [ i ] [ "DD004" ] . ToString ( );
                model . DD005 = tableOne . Rows [ i ] [ "DD005" ] . ToString ( );
                model . DD006 = tableOne . Rows [ i ] [ "DD006" ] . ToString ( );
                model . DD007 = tableOne . Rows [ i ] [ "DD007" ] . ToString ( );
                model . DD008 = tableOne . Rows [ i ] [ "DD008" ] . ToString ( );
                model . DD009 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "DD009" ] . ToString ( ) );
                model . DD010 = tableOne . Rows [ i ] [ "DD010" ] . ToString ( );
                model . DD011 = tableOne . Rows [ i ] [ "DD011" ] . ToString ( );
                model . DD012 = tableOne . Rows [ i ] [ "DD012" ] . ToString ( );
                model . DD013 = tableOne . Rows [ i ] [ "DD013" ] . ToString ( );
                model . DD014 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD014" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD014" ] . ToString ( ) );
                model . DD015 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD015" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD015" ] . ToString ( ) );
                model . DD016 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD016" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD016" ] . ToString ( ) );
                model . DD017 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD017" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD017" ] . ToString ( ) );
                model . DD018 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD018" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD018" ] . ToString ( ) );
                model . DD019 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD019" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD019" ] . ToString ( ) );
                model . DD020 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD020" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD020" ] . ToString ( ) );
                model . DD021 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD021" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD021" ] . ToString ( ) );
                model . DD022 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD022" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( tableOne . Rows [ i ] [ "DD022" ] . ToString ( ) );
                model . DD023 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "DD023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "DD023" ] . ToString ( ) );
                model . DD024 = tableOne . Rows [ i ] [ "DD024" ] . ToString ( );
                model . DD025 = tableOne . Rows [ i ] [ "DD025" ] . ToString ( );
                model . DD026 = tableOne . Rows [ i ] [ "DD026" ] . ToString ( );
                model . DD027 = tableOne . Rows [ i ] [ "DD027" ] . ToString ( );
                model . DD028 = tableOne . Rows [ i ] [ "DD028" ] . ToString ( );
                model . DD029 = tableOne . Rows [ i ] [ "DD029" ] . ToString ( );
                model . DD030 = tableOne . Rows [ i ] [ "DD030" ] . ToString ( );
                model . DD031 = tableOne . Rows [ i ] [ "DD031" ] . ToString ( );
                model . DD032 = tableOne . Rows [ i ] [ "DD032" ] . ToString ( );
                model . DD033 = tableOne . Rows [ i ] [ "DD033" ] . ToString ( );
                model . DD034 = tableOne . Rows [ i ] [ "DD034" ] . ToString ( );
                model . DD035 = tableOne . Rows [ i ] [ "DD035" ] . ToString ( );
                model . DD036 = tableOne . Rows [ i ] [ "DD036" ] . ToString ( );
                model . DD037 = tableOne . Rows [ i ] [ "DD037" ] . ToString ( );
                model . DD038 = tableOne . Rows [ i ] [ "DD038" ] . ToString ( );
                model . DD039 = tableOne . Rows [ i ] [ "DD039" ] . ToString ( );
                model . DD040 = tableOne . Rows [ i ] [ "DD040" ] . ToString ( );
                model . DD041 = tableOne . Rows [ i ] [ "DD041" ] . ToString ( );
                model . DD042 = tableOne . Rows [ i ] [ "DD042" ] . ToString ( );
                model . DD043 = tableOne . Rows [ i ] [ "DD043" ] . ToString ( );
                model . DD044 = tableOne . Rows [ i ] [ "DD044" ] . ToString ( );
                model . DD045 = tableOne . Rows [ i ] [ "DD045" ] . ToString ( );
                model . DD046 = tableOne . Rows [ i ] [ "DD046" ] . ToString ( );
                model . DD047 = tableOne . Rows [ i ] [ "DD047" ] . ToString ( );
                model . DD048 = tableOne . Rows [ i ] [ "DD048" ] . ToString ( );
                model . DD049 = tableOne . Rows [ i ] [ "DD049" ] . ToString ( );
                model . DD050 = tableOne . Rows [ i ] [ "DD050" ] . ToString ( );
                model . DD051 = tableOne . Rows [ i ] [ "DD051" ] . ToString ( );
                model . DD052 = tableOne . Rows [ i ] [ "DD052" ] . ToString ( );
                model . DD053 = tableOne . Rows [ i ] [ "DD053" ] . ToString ( );
                model . DD054 = tableOne . Rows [ i ] [ "DD054" ] . ToString ( );
                model . DD055 = tableOne . Rows [ i ] [ "DD055" ] . ToString ( );
                model . DD056 = tableOne . Rows [ i ] [ "DD056" ] . ToString ( );
                if ( model . idx > 0 )
                {
                    edit_dd ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_429" + i ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表身" ) ,null );
                }
                else
                {
                    add_dd ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_429" + i ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_dd ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_429" + model.idx ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表身" ) ,null );
                }
            }

            //MulaolaoLibrary . SafetyManegerAndControlDEEntity modelOne = new MulaolaoLibrary . SafetyManegerAndControlDEEntity ( );
            //for ( int i = 0 ; i < tableTwo . Rows . Count ; i++ )
            //{
            //    modelOne . idx = string . IsNullOrEmpty ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTwo . Rows [ i ] [ "idx" ] . ToString ( ) );
            //    modelOne . DE001 = tableTwo . Rows [ i ] [ "DE001" ] . ToString ( );
            //    modelOne . DE002 = tableTwo . Rows [ i ] [ "DE002" ] . ToString ( );
            //    modelOne . DE003 = tableTwo . Rows [ i ] [ "DE003" ] . ToString ( );

            //    if ( modelOne . idx > 0 )
            //    {
            //        edit_de ( SQLString ,strSql ,modelOne );
            //        SQLString . Add ( Drity . DrityOfComparation ( "R_429" + i ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑系数" ) ,null );
            //    }
            //    else
            //    {
            //        add_de ( SQLString ,strSql ,modelOne );
            //        SQLString . Add ( Drity . DrityOfComparation ( "R_429" + i ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增系数" ) ,null );
            //    }
            //}

            //if ( coeList . Count > 0 )
            //{
            //    foreach ( string s in coeList )
            //    {
            //        modelOne . idx = Convert . ToInt32 ( s );
            //        delete_de ( SQLString ,strSql ,modelOne );
            //        SQLString . Add ( Drity . DrityOfComparation ( "R_429" + model . idx ,"产品所用化学物料试产后、量产前抽测安全管控清单(R_429)" ,logins ,Drity . GetDt ( ) ,_dc . DC001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除系数" ) ,null );
            //    }
            //}

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }


        void add_dc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDCEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDC(" );
            strSql . Append ( "DC001,DC002,DC003,DC004,DC005,DC006,DC007,DC008,DC009,DC010,DC011,DC012,DC013,DC014,DC015,DC016,DC017,DC018,DC019,DC020,DC021,DC022,DC023,DC024,DC025,DC026,DC027,DC028,DC029,DC030,DC031,DC032)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DC001,@DC002,@DC003,@DC004,@DC005,@DC006,@DC007,@DC008,@DC009,@DC010,@DC011,@DC012,@DC013,@DC014,@DC015,@DC016,@DC017,@DC018,@DC019,@DC020,@DC021,@DC022,@DC023,@DC024,@DC025,@DC026,@DC027,@DC028,@DC029,@DC030,@DC031,@DC032)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DC003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC005", SqlDbType.Int,4),
                    new SqlParameter("@DC006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC008", SqlDbType.Date,3),
                    new SqlParameter("@DC009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC012", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC013", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC014", SqlDbType.NVarChar,200),
                    new SqlParameter("@DC015", SqlDbType.Bit,1),
                    new SqlParameter("@DC016", SqlDbType.Bit,1),
                    new SqlParameter("@DC017", SqlDbType.Bit,1),
                    new SqlParameter("@DC018", SqlDbType.Bit,1),
                    new SqlParameter("@DC019", SqlDbType.Bit,1),
                    new SqlParameter("@DC020", SqlDbType.Bit,1),
                    new SqlParameter("@DC021", SqlDbType.Bit,1),
                    new SqlParameter("@DC022", SqlDbType.Bit,1),
                    new SqlParameter("@DC023", SqlDbType.Bit,1),
                    new SqlParameter("@DC024", SqlDbType.Bit,1),
                    new SqlParameter("@DC025", SqlDbType.Bit,1),
                    new SqlParameter("@DC026", SqlDbType.Bit,1),
                    new SqlParameter("@DC027", SqlDbType.Bit,1),
                    new SqlParameter("@DC028", SqlDbType.Bit,1),
                    new SqlParameter("@DC029", SqlDbType.Bit,1),
                    new SqlParameter("@DC030", SqlDbType.Bit,1),
                    new SqlParameter("@DC031", SqlDbType.Bit,1),
                    new SqlParameter("@DC032", SqlDbType.Bit,1)
            };
            parameters [ 0 ] . Value = model . DC001;
            parameters [ 1 ] . Value = model . DC002;
            parameters [ 2 ] . Value = model . DC003;
            parameters [ 3 ] . Value = model . DC004;
            parameters [ 4 ] . Value = model . DC005;
            parameters [ 5 ] . Value = model . DC006;
            parameters [ 6 ] . Value = model . DC007;
            parameters [ 7 ] . Value = model . DC008;
            parameters [ 8 ] . Value = model . DC009;
            parameters [ 9 ] . Value = model . DC010;
            parameters [ 10 ] . Value = model . DC011;
            parameters [ 11 ] . Value = model . DC012;
            parameters [ 12 ] . Value = model . DC013;
            parameters [ 13 ] . Value = model . DC014;
            parameters [ 14 ] . Value = model . DC015;
            parameters [ 15 ] . Value = model . DC016;
            parameters [ 16 ] . Value = model . DC017;
            parameters [ 17 ] . Value = model . DC018;
            parameters [ 18 ] . Value = model . DC019;
            parameters [ 19 ] . Value = model . DC020;
            parameters [ 20 ] . Value = model . DC021;
            parameters [ 21 ] . Value = model . DC022;
            parameters [ 22 ] . Value = model . DC023;
            parameters [ 23 ] . Value = model . DC024;
            parameters [ 24 ] . Value = model . DC025;
            parameters [ 25 ] . Value = model . DC026;
            parameters [ 26 ] . Value = model . DC027;
            parameters [ 27 ] . Value = model . DC028;
            parameters [ 28 ] . Value = model . DC029;
            parameters [ 29 ] . Value = model . DC030;
            parameters [ 30 ] . Value = model . DC031;
            parameters [ 31 ] . Value = model . DC032;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dc ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDCEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDC set " );
            strSql . Append ( "DC001=@DC001," );
            strSql . Append ( "DC002=@DC002," );
            strSql . Append ( "DC003=@DC003," );
            strSql . Append ( "DC004=@DC004," );
            strSql . Append ( "DC005=@DC005," );
            strSql . Append ( "DC006=@DC006," );
            strSql . Append ( "DC007=@DC007," );
            strSql . Append ( "DC008=@DC008," );
            strSql . Append ( "DC009=@DC009," );
            strSql . Append ( "DC010=@DC010," );
            strSql . Append ( "DC011=@DC011," );
            strSql . Append ( "DC012=@DC012," );
            strSql . Append ( "DC013=@DC013," );
            strSql . Append ( "DC014=@DC014," );
            strSql . Append ( "DC015=@DC015," );
            strSql . Append ( "DC016=@DC016," );
            strSql . Append ( "DC017=@DC017," );
            strSql . Append ( "DC018=@DC018," );
            strSql . Append ( "DC019=@DC019," );
            strSql . Append ( "DC020=@DC020," );
            strSql . Append ( "DC021=@DC021," );
            strSql . Append ( "DC022=@DC022," );
            strSql . Append ( "DC023=@DC023," );
            strSql . Append ( "DC024=@DC024," );
            strSql . Append ( "DC025=@DC025," );
            strSql . Append ( "DC026=@DC026," );
            strSql . Append ( "DC027=@DC027," );
            strSql . Append ( "DC028=@DC028," );
            strSql . Append ( "DC029=@DC029," );
            strSql . Append ( "DC030=@DC030," );
            strSql . Append ( "DC031=@DC031," );
            strSql . Append ( "DC032=@DC032 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DC001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC002", SqlDbType.NVarChar,50),
                    new SqlParameter("@DC003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC005", SqlDbType.Int,4),
                    new SqlParameter("@DC006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC008", SqlDbType.Date,3),
                    new SqlParameter("@DC009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC012", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC013", SqlDbType.NVarChar,20),
                    new SqlParameter("@DC014", SqlDbType.NVarChar,200),
                    new SqlParameter("@DC015", SqlDbType.Bit,1),
                    new SqlParameter("@DC016", SqlDbType.Bit,1),
                    new SqlParameter("@DC017", SqlDbType.Bit,1),
                    new SqlParameter("@DC018", SqlDbType.Bit,1),
                    new SqlParameter("@DC019", SqlDbType.Bit,1),
                    new SqlParameter("@DC020", SqlDbType.Bit,1),
                    new SqlParameter("@DC021", SqlDbType.Bit,1),
                    new SqlParameter("@DC022", SqlDbType.Bit,1),
                    new SqlParameter("@DC023", SqlDbType.Bit,1),
                    new SqlParameter("@DC024", SqlDbType.Bit,1),
                    new SqlParameter("@DC025", SqlDbType.Bit,1),
                    new SqlParameter("@DC026", SqlDbType.Bit,1),
                    new SqlParameter("@DC027", SqlDbType.Bit,1),
                    new SqlParameter("@DC028", SqlDbType.Bit,1),
                    new SqlParameter("@DC029", SqlDbType.Bit,1),
                    new SqlParameter("@DC030", SqlDbType.Bit,1),
                    new SqlParameter("@DC031", SqlDbType.Bit,1),
                    new SqlParameter("@DC032", SqlDbType.Bit,1),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DC001;
            parameters [ 1 ] . Value = model . DC002;
            parameters [ 2 ] . Value = model . DC003;
            parameters [ 3 ] . Value = model . DC004;
            parameters [ 4 ] . Value = model . DC005;
            parameters [ 5 ] . Value = model . DC006;
            parameters [ 6 ] . Value = model . DC007;
            parameters [ 7 ] . Value = model . DC008;
            parameters [ 8 ] . Value = model . DC009;
            parameters [ 9 ] . Value = model . DC010;
            parameters [ 10 ] . Value = model . DC011;
            parameters [ 11 ] . Value = model . DC012;
            parameters [ 12 ] . Value = model . DC013;
            parameters [ 13 ] . Value = model . DC014;
            parameters [ 14 ] . Value = model . DC015;
            parameters [ 15 ] . Value = model . DC016;
            parameters [ 16 ] . Value = model . DC017;
            parameters [ 17 ] . Value = model . DC018;
            parameters [ 18 ] . Value = model . DC019;
            parameters [ 19 ] . Value = model . DC020;
            parameters [ 20 ] . Value = model . DC021;
            parameters [ 21 ] . Value = model . DC022;
            parameters [ 22 ] . Value = model . DC023;
            parameters [ 23 ] . Value = model . DC024;
            parameters [ 24 ] . Value = model . DC025;
            parameters [ 25 ] . Value = model . DC026;
            parameters [ 26 ] . Value = model . DC027;
            parameters [ 27 ] . Value = model . DC028;
            parameters [ 28 ] . Value = model . DC029;
            parameters [ 29 ] . Value = model . DC030;
            parameters [ 30 ] . Value = model . DC031;
            parameters [ 31 ] . Value = model . DC032;
            parameters [ 32 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_dd ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDD(" );
            strSql . Append ( "DD001,DD002,DD003,DD004,DD005,DD006,DD007,DD008,DD009,DD010,DD011,DD012,DD013,DD014,DD015,DD016,DD017,DD018,DD019,DD020,DD021,DD022,DD023,DD024,DD025,DD026,DD027,DD028,DD029,DD030,DD031,DD032,DD033,DD034,DD035,DD036,DD037,DD038,DD039,DD040,DD041,DD042,DD043,DD044,DD045,DD046,DD047,DD048,DD049,DD050,DD051,DD052,DD053,DD054,DD055,DD056)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DD001,@DD002,@DD003,@DD004,@DD005,@DD006,@DD007,@DD008,@DD009,@DD010,@DD011,@DD012,@DD013,@DD014,@DD015,@DD016,@DD017,@DD018,@DD019,@DD020,@DD021,@DD022,@DD023,@DD024,@DD025,@DD026,@DD027,@DD028,@DD029,@DD030,@DD031,@DD032,@DD033,@DD034,@DD035,@DD036,@DD037,@DD038,@DD039,@DD040,@DD041,@DD042,@DD043,@DD044,@DD045,@DD046,@DD047,@DD048,@DD049,@DD050,@DD051,@DD052,@DD053,@DD054,@DD055,@DD056)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD002", SqlDbType.Date,3),
                    new SqlParameter("@DD003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD009", SqlDbType.Int,4),
                    new SqlParameter("@DD010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD012", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD013", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD014", SqlDbType.Bit,1),
                    new SqlParameter("@DD015", SqlDbType.Bit,1),
                    new SqlParameter("@DD016", SqlDbType.Bit,1),
                    new SqlParameter("@DD017", SqlDbType.Bit,1),
                    new SqlParameter("@DD018", SqlDbType.Bit,1),
                    new SqlParameter("@DD019", SqlDbType.Bit,1),
                    new SqlParameter("@DD020", SqlDbType.Bit,1),
                    new SqlParameter("@DD021", SqlDbType.Bit,1),
                    new SqlParameter("@DD022", SqlDbType.Bit,1),
                    new SqlParameter("@DD023", SqlDbType.Int,4),
                    new SqlParameter("@DD024", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD025", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD026", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD027", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD028", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD029", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD030", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD031", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD032", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD033", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD034", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD035", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD036", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD037", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD038", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD039", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD040", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD041", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD042", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD043", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD044", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD045", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD046", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD047", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD048", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD049", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD050", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD051", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD052", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD053", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD054", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD055", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD056", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . DD001;
            parameters [ 1 ] . Value = model . DD002;
            parameters [ 2 ] . Value = model . DD003;
            parameters [ 3 ] . Value = model . DD004;
            parameters [ 4 ] . Value = model . DD005;
            parameters [ 5 ] . Value = model . DD006;
            parameters [ 6 ] . Value = model . DD007;
            parameters [ 7 ] . Value = model . DD008;
            parameters [ 8 ] . Value = model . DD009;
            parameters [ 9 ] . Value = model . DD010;
            parameters [ 10 ] . Value = model . DD011;
            parameters [ 11 ] . Value = model . DD012;
            parameters [ 12 ] . Value = model . DD013;
            parameters [ 13 ] . Value = model . DD014;
            parameters [ 14 ] . Value = model . DD015;
            parameters [ 15 ] . Value = model . DD016;
            parameters [ 16 ] . Value = model . DD017;
            parameters [ 17 ] . Value = model . DD018;
            parameters [ 18 ] . Value = model . DD019;
            parameters [ 19 ] . Value = model . DD020;
            parameters [ 20 ] . Value = model . DD021;
            parameters [ 21 ] . Value = model . DD022;
            parameters [ 22 ] . Value = model . DD023;
            parameters [ 23 ] . Value = model . DD024;
            parameters [ 24 ] . Value = model . DD025;
            parameters [ 25 ] . Value = model . DD026;
            parameters [ 26 ] . Value = model . DD027;
            parameters [ 27 ] . Value = model . DD028;
            parameters [ 28 ] . Value = model . DD029;
            parameters [ 29 ] . Value = model . DD030;
            parameters [ 30 ] . Value = model . DD031;
            parameters [ 31 ] . Value = model . DD032;
            parameters [ 32 ] . Value = model . DD033;
            parameters [ 33 ] . Value = model . DD034;
            parameters [ 34 ] . Value = model . DD035;
            parameters [ 35 ] . Value = model . DD036;
            parameters [ 36 ] . Value = model . DD037;
            parameters [ 37 ] . Value = model . DD038;
            parameters [ 38 ] . Value = model . DD039;
            parameters [ 39 ] . Value = model . DD040;
            parameters [ 40 ] . Value = model . DD041;
            parameters [ 41 ] . Value = model . DD042;
            parameters [ 42 ] . Value = model . DD043;
            parameters [ 43 ] . Value = model . DD044;
            parameters [ 44 ] . Value = model . DD045;
            parameters [ 45 ] . Value = model . DD046;
            parameters [ 46 ] . Value = model . DD047;
            parameters [ 47 ] . Value = model . DD048;
            parameters [ 48 ] . Value = model . DD049;
            parameters [ 49 ] . Value = model . DD050;
            parameters [ 50 ] . Value = model . DD051;
            parameters [ 51 ] . Value = model . DD052;
            parameters [ 52 ] . Value = model . DD053;
            parameters [ 53 ] . Value = model . DD054;
            parameters [ 54 ] . Value = model . DD055;
            parameters [ 55 ] . Value = model . DD056;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dd ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDD set " );
            strSql . Append ( "DD001=@DD001," );
            strSql . Append ( "DD002=@DD002," );
            strSql . Append ( "DD003=@DD003," );
            strSql . Append ( "DD004=@DD004," );
            strSql . Append ( "DD005=@DD005," );
            strSql . Append ( "DD006=@DD006," );
            strSql . Append ( "DD007=@DD007," );
            strSql . Append ( "DD008=@DD008," );
            strSql . Append ( "DD009=@DD009," );
            strSql . Append ( "DD010=@DD010," );
            strSql . Append ( "DD011=@DD011," );
            strSql . Append ( "DD012=@DD012," );
            strSql . Append ( "DD013=@DD013," );
            strSql . Append ( "DD014=@DD014," );
            strSql . Append ( "DD015=@DD015," );
            strSql . Append ( "DD016=@DD016," );
            strSql . Append ( "DD017=@DD017," );
            strSql . Append ( "DD018=@DD018," );
            strSql . Append ( "DD019=@DD019," );
            strSql . Append ( "DD020=@DD020," );
            strSql . Append ( "DD021=@DD021," );
            strSql . Append ( "DD022=@DD022," );
            strSql . Append ( "DD023=@DD023," );
            strSql . Append ( "DD024=@DD024," );
            strSql . Append ( "DD025=@DD025," );
            strSql . Append ( "DD026=@DD026," );
            strSql . Append ( "DD027=@DD027," );
            strSql . Append ( "DD028=@DD028," );
            strSql . Append ( "DD029=@DD029," );
            strSql . Append ( "DD030=@DD030," );
            strSql . Append ( "DD031=@DD031," );
            strSql . Append ( "DD032=@DD032," );
            strSql . Append ( "DD033=@DD033," );
            strSql . Append ( "DD034=@DD034," );
            strSql . Append ( "DD035=@DD035," );
            strSql . Append ( "DD036=@DD036," );
            strSql . Append ( "DD037=@DD037," );
            strSql . Append ( "DD038=@DD038," );
            strSql . Append ( "DD039=@DD039," );
            strSql . Append ( "DD040=@DD040," );
            strSql . Append ( "DD041=@DD041," );
            strSql . Append ( "DD042=@DD042," );
            strSql . Append ( "DD043=@DD043," );
            strSql . Append ( "DD044=@DD044," );
            strSql . Append ( "DD045=@DD045," );
            strSql . Append ( "DD046=@DD046," );
            strSql . Append ( "DD047=@DD047," );
            strSql . Append ( "DD048=@DD048," );
            strSql . Append ( "DD049=@DD049," );
            strSql . Append ( "DD050=@DD050," );
            strSql . Append ( "DD051=@DD051," );
            strSql . Append ( "DD052=@DD052," );
            strSql . Append ( "DD053=@DD053," );
            strSql . Append ( "DD054=@DD054," );
            strSql . Append ( "DD055=@DD055," );
            strSql . Append ( "DD056=@DD056 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD002", SqlDbType.Date,3),
                    new SqlParameter("@DD003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD009", SqlDbType.Int,4),
                    new SqlParameter("@DD010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD011", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD012", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD013", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD014", SqlDbType.Bit,1),
                    new SqlParameter("@DD015", SqlDbType.Bit,1),
                    new SqlParameter("@DD016", SqlDbType.Bit,1),
                    new SqlParameter("@DD017", SqlDbType.Bit,1),
                    new SqlParameter("@DD018", SqlDbType.Bit,1),
                    new SqlParameter("@DD019", SqlDbType.Bit,1),
                    new SqlParameter("@DD020", SqlDbType.Bit,1),
                    new SqlParameter("@DD021", SqlDbType.Bit,1),
                    new SqlParameter("@DD022", SqlDbType.Bit,1),
                    new SqlParameter("@DD023", SqlDbType.Int,4),
                    new SqlParameter("@DD024", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD025", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD026", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD027", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD028", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD029", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD030", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD031", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD032", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD033", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD034", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD035", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD036", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD037", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD038", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD039", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD040", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD041", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD042", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD043", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD044", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD045", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD046", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD047", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD048", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD049", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD050", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD051", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD052", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD053", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD054", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD055", SqlDbType.NVarChar,20),
                    new SqlParameter("@DD056", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DD001;
            parameters [ 1 ] . Value = model . DD002;
            parameters [ 2 ] . Value = model . DD003;
            parameters [ 3 ] . Value = model . DD004;
            parameters [ 4 ] . Value = model . DD005;
            parameters [ 5 ] . Value = model . DD006;
            parameters [ 6 ] . Value = model . DD007;
            parameters [ 7 ] . Value = model . DD008;
            parameters [ 8 ] . Value = model . DD009;
            parameters [ 9 ] . Value = model . DD010;
            parameters [ 10 ] . Value = model . DD011;
            parameters [ 11 ] . Value = model . DD012;
            parameters [ 12 ] . Value = model . DD013;
            parameters [ 13 ] . Value = model . DD014;
            parameters [ 14 ] . Value = model . DD015;
            parameters [ 15 ] . Value = model . DD016;
            parameters [ 16 ] . Value = model . DD017;
            parameters [ 17 ] . Value = model . DD018;
            parameters [ 18 ] . Value = model . DD019;
            parameters [ 19 ] . Value = model . DD020;
            parameters [ 20 ] . Value = model . DD021;
            parameters [ 21 ] . Value = model . DD022;
            parameters [ 22 ] . Value = model . DD023;
            parameters [ 23 ] . Value = model . DD024;
            parameters [ 24 ] . Value = model . DD025;
            parameters [ 25 ] . Value = model . DD026;
            parameters [ 26 ] . Value = model . DD027;
            parameters [ 27 ] . Value = model . DD028;
            parameters [ 28 ] . Value = model . DD029;
            parameters [ 29 ] . Value = model . DD030;
            parameters [ 30 ] . Value = model . DD031;
            parameters [ 31 ] . Value = model . DD032;
            parameters [ 32 ] . Value = model . DD033;
            parameters [ 33 ] . Value = model . DD034;
            parameters [ 34 ] . Value = model . DD035;
            parameters [ 35 ] . Value = model . DD036;
            parameters [ 36 ] . Value = model . DD037;
            parameters [ 37 ] . Value = model . DD038;
            parameters [ 38 ] . Value = model . DD039;
            parameters [ 39 ] . Value = model . DD040;
            parameters [ 40 ] . Value = model . DD041;
            parameters [ 41 ] . Value = model . DD042;
            parameters [ 42 ] . Value = model . DD043;
            parameters [ 43 ] . Value = model . DD044;
            parameters [ 44 ] . Value = model . DD045;
            parameters [ 45 ] . Value = model . DD046;
            parameters [ 46 ] . Value = model . DD047;
            parameters [ 47 ] . Value = model . DD048;
            parameters [ 48 ] . Value = model . DD049;
            parameters [ 49 ] . Value = model . DD050;
            parameters [ 50 ] . Value = model . DD051;
            parameters [ 51 ] . Value = model . DD052;
            parameters [ 52 ] . Value = model . DD053;
            parameters [ 53 ] . Value = model . DD054;
            parameters [ 54 ] . Value = model . DD055;
            parameters [ 55 ] . Value = model . DD056;
            parameters [ 56 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_dd ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDDEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQDD " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_de ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDE(" );
            strSql . Append ( "DE001,DE002,DE003)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DE001,@DE002,@DE003)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DE001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DE003", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . DE001;
            parameters [ 1 ] . Value = model . DE002;
            parameters [ 2 ] . Value = model . DE003;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_de ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDE set " );
            strSql . Append ( "DE001=@DE001," );
            strSql . Append ( "DE002=@DE002," );
            strSql . Append ( "DE003=@DE003 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DE001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DE002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DE003", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DE001;
            parameters [ 1 ] . Value = model . DE002;
            parameters [ 2 ] . Value = model . DE003;
            parameters [ 3 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_de ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . SafetyManegerAndControlDEEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQDE " );
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
            strSql . AppendFormat ( "SELECT idx,DD001,DD002,DD003,DD004,DD005,DD006,DD007,DD008,DD009,DD010,DD011,DD012,DD013,DD014,DD015,DD016,DD017,DD018,DD019,DD020,DD021,DD022,DD023,DD024,DD025,DD026,DD027,DD028,DD029,DD030,DD031,DD032,DD033,DD034,DD035,DD036,DD037,DD038,DD039,DD040,DD041,DD042,DD043,DD044,DD045,DD046,DD047,DD048,DD049,DD050,DD051,DD052,DD053,DD054,DD055,DD056 FROM R_PQDD WHERE DD001='{0}'" ,oddNum );

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
            strSql . AppendFormat ( "SELECT idx,DC001,DC002,DC003,DC004,DC005,DC006,DC007,DC008,DC009,DC010,DC011,DC012,DC013,DC014 FROM R_PQDC WHERE DC001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
