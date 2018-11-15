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
    public class ProductSpecificationDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getProInfo ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF03,PQF04,PQF06,PQF31 FROM R_PQF A INNER JOIN R_REVIEWS C ON A.PQF01=C.RES06 WHERE RES05='执行' ORDER BY PQF01" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get basic data
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfCoefficient ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DH001,DH002,DH003 FROM R_PQDH ORDER BY DH001,DH002 " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get data from r_pqfc 
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DF001,DF002,DF003,DF004,DF008,DF009 FROM R_PQDF " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get the quantity according to the conditions
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT DF001,DF002,DF003,DF004,DF008,DF009 FROM R_PQDF WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// paging to get data
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DF001,DF002,DF003,DF004,DF008,DF009,RES05 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER(" );
            strSql . Append ( "ORDER BY T.DF001 DESC)" );
            strSql . Append ( " AS ROW,T.* FROM R_PQDF T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON DF001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get datasource
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . ProductSpecificationDFEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DF001,DF002,DF003,DF004,DF005,DF006,DF007,DF008,DF009,DF010,DF011,DF012,DF013,DF014,DF015,DF016,DF017,DF018,DF019,DF020,DF021,DF022,DF023,DF024,DF025,DF026,DF027,DF028,DF029,DF030,DF031,DF032,DF033,DF034,DF035,DF036,DF037,DF038,DF039,DF040,DF041,DF042,DF043,DF044,DF045,DF046,DF047,DF048,DF049,DF050,DF051,DF052,DF053,DF054,DF055,DF056,DF057,DF058,DF059,DF060,DF061,DF062,DF063,DF064,DF065,DF066,DF067,DF068,DF069 FROM R_PQDF " );
            strSql . AppendFormat ( "WHERE DF001='{0}'" ,oddNum );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . ProductSpecificationDFEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . ProductSpecificationDFEntity model = new MulaolaoLibrary . ProductSpecificationDFEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "DF001" ] != null )
                {
                    model . DF001 = row [ "DF001" ] . ToString ( );
                }
                if ( row [ "DF002" ] != null )
                {
                    model . DF002 = row [ "DF002" ] . ToString ( );
                }
                if ( row [ "DF003" ] != null )
                {
                    model . DF003 = row [ "DF003" ] . ToString ( );
                }
                if ( row [ "DF004" ] != null )
                {
                    model . DF004 = row [ "DF004" ] . ToString ( );
                }
                if ( row [ "DF005" ] != null && row [ "DF005" ] . ToString ( ) != "" )
                {
                    model . DF005 = int . Parse ( row [ "DF005" ] . ToString ( ) );
                }
                if ( row [ "DF006" ] != null && row [ "DF006" ] . ToString ( ) != "" )
                {
                    model . DF006 = DateTime . Parse ( row [ "DF006" ] . ToString ( ) );
                }
                if ( row [ "DF007" ] != null && row [ "DF007" ] . ToString ( ) != "" )
                {
                    model . DF007 = int . Parse ( row [ "DF007" ] . ToString ( ) );
                }
                if ( row [ "DF008" ] != null )
                {
                    model . DF008 = row [ "DF008" ] . ToString ( );
                }
                if ( row [ "DF009" ] != null )
                {
                    model . DF009 = row [ "DF009" ] . ToString ( );
                }
                if ( row [ "DF010" ] != null )
                {
                    model . DF010 = row [ "DF010" ] . ToString ( );
                }
                if ( row [ "DF011" ] != null && row [ "DF011" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF011" ] . ToString ( ) == "1" ) || ( row [ "DF011" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF011 = true;
                    }
                    else
                    {
                        model . DF011 = false;
                    }
                }
                if ( row [ "DF012" ] != null && row [ "DF012" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF012" ] . ToString ( ) == "1" ) || ( row [ "DF012" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF012 = true;
                    }
                    else
                    {
                        model . DF012 = false;
                    }
                }
                if ( row [ "DF013" ] != null && row [ "DF013" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF013" ] . ToString ( ) == "1" ) || ( row [ "DF013" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF013 = true;
                    }
                    else
                    {
                        model . DF013 = false;
                    }
                }
                if ( row [ "DF014" ] != null && row [ "DF014" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF014" ] . ToString ( ) == "1" ) || ( row [ "DF014" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF014 = true;
                    }
                    else
                    {
                        model . DF014 = false;
                    }
                }
                if ( row [ "DF015" ] != null && row [ "DF015" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF015" ] . ToString ( ) == "1" ) || ( row [ "DF015" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF015 = true;
                    }
                    else
                    {
                        model . DF015 = false;
                    }
                }
                if ( row [ "DF016" ] != null && row [ "DF016" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF016" ] . ToString ( ) == "1" ) || ( row [ "DF016" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF016 = true;
                    }
                    else
                    {
                        model . DF016 = false;
                    }
                }
                if ( row [ "DF017" ] != null && row [ "DF017" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF017" ] . ToString ( ) == "1" ) || ( row [ "DF017" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF017 = true;
                    }
                    else
                    {
                        model . DF017 = false;
                    }
                }
                if ( row [ "DF018" ] != null && row [ "DF018" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF018" ] . ToString ( ) == "1" ) || ( row [ "DF018" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF018 = true;
                    }
                    else
                    {
                        model . DF018 = false;
                    }
                }
                if ( row [ "DF019" ] != null && row [ "DF019" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF019" ] . ToString ( ) == "1" ) || ( row [ "DF019" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF019 = true;
                    }
                    else
                    {
                        model . DF019 = false;
                    }
                }
                if ( row [ "DF020" ] != null && row [ "DF020" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF020" ] . ToString ( ) == "1" ) || ( row [ "DF020" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF020 = true;
                    }
                    else
                    {
                        model . DF020 = false;
                    }
                }
                if ( row [ "DF021" ] != null && row [ "DF021" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF021" ] . ToString ( ) == "1" ) || ( row [ "DF021" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF021 = true;
                    }
                    else
                    {
                        model . DF021 = false;
                    }
                }
                if ( row [ "DF022" ] != null && row [ "DF022" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF022" ] . ToString ( ) == "1" ) || ( row [ "DF022" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF022 = true;
                    }
                    else
                    {
                        model . DF022 = false;
                    }
                }
                if ( row [ "DF023" ] != null && row [ "DF023" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF023" ] . ToString ( ) == "1" ) || ( row [ "DF023" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF023 = true;
                    }
                    else
                    {
                        model . DF023 = false;
                    }
                }
                if ( row [ "DF024" ] != null && row [ "DF024" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF024" ] . ToString ( ) == "1" ) || ( row [ "DF024" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF024 = true;
                    }
                    else
                    {
                        model . DF024 = false;
                    }
                }
                if ( row [ "DF025" ] != null && row [ "DF025" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF025" ] . ToString ( ) == "1" ) || ( row [ "DF025" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF025 = true;
                    }
                    else
                    {
                        model . DF025 = false;
                    }
                }
                if ( row [ "DF026" ] != null && row [ "DF026" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF026" ] . ToString ( ) == "1" ) || ( row [ "DF026" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF026 = true;
                    }
                    else
                    {
                        model . DF026 = false;
                    }
                }
                if ( row [ "DF027" ] != null && row [ "DF027" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF027" ] . ToString ( ) == "1" ) || ( row [ "DF027" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF027 = true;
                    }
                    else
                    {
                        model . DF027 = false;
                    }
                }
                if ( row [ "DF028" ] != null && row [ "DF028" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF028" ] . ToString ( ) == "1" ) || ( row [ "DF028" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF028 = true;
                    }
                    else
                    {
                        model . DF028 = false;
                    }
                }
                if ( row [ "DF029" ] != null && row [ "DF029" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF029" ] . ToString ( ) == "1" ) || ( row [ "DF029" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF029 = true;
                    }
                    else
                    {
                        model . DF029 = false;
                    }
                }
                if ( row [ "DF030" ] != null && row [ "DF030" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF030" ] . ToString ( ) == "1" ) || ( row [ "DF030" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF030 = true;
                    }
                    else
                    {
                        model . DF030 = false;
                    }
                }
                if ( row [ "DF031" ] != null && row [ "DF031" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF031" ] . ToString ( ) == "1" ) || ( row [ "DF031" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF031 = true;
                    }
                    else
                    {
                        model . DF031 = false;
                    }
                }
                if ( row [ "DF032" ] != null && row [ "DF032" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF032" ] . ToString ( ) == "1" ) || ( row [ "DF032" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF032 = true;
                    }
                    else
                    {
                        model . DF032 = false;
                    }
                }
                if ( row [ "DF033" ] != null && row [ "DF033" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF033" ] . ToString ( ) == "1" ) || ( row [ "DF033" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF033 = true;
                    }
                    else
                    {
                        model . DF033 = false;
                    }
                }
                if ( row [ "DF034" ] != null && row [ "DF034" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF034" ] . ToString ( ) == "1" ) || ( row [ "DF034" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF034 = true;
                    }
                    else
                    {
                        model . DF034 = false;
                    }
                }
                if ( row [ "DF035" ] != null && row [ "DF035" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF035" ] . ToString ( ) == "1" ) || ( row [ "DF035" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF035 = true;
                    }
                    else
                    {
                        model . DF035 = false;
                    }
                }
                if ( row [ "DF036" ] != null && row [ "DF036" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF036" ] . ToString ( ) == "1" ) || ( row [ "DF036" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF036 = true;
                    }
                    else
                    {
                        model . DF036 = false;
                    }
                }
                if ( row [ "DF037" ] != null && row [ "DF037" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF037" ] . ToString ( ) == "1" ) || ( row [ "DF037" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF037 = true;
                    }
                    else
                    {
                        model . DF037 = false;
                    }
                }
                if ( row [ "DF038" ] != null && row [ "DF038" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF038" ] . ToString ( ) == "1" ) || ( row [ "DF038" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF038 = true;
                    }
                    else
                    {
                        model . DF038 = false;
                    }
                }
                if ( row [ "DF039" ] != null && row [ "DF039" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF039" ] . ToString ( ) == "1" ) || ( row [ "DF039" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF039 = true;
                    }
                    else
                    {
                        model . DF039 = false;
                    }
                }
                if ( row [ "DF040" ] != null && row [ "DF040" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF040" ] . ToString ( ) == "1" ) || ( row [ "DF040" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF040 = true;
                    }
                    else
                    {
                        model . DF040 = false;
                    }
                }
                if ( row [ "DF041" ] != null && row [ "DF041" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF041" ] . ToString ( ) == "1" ) || ( row [ "DF041" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF041 = true;
                    }
                    else
                    {
                        model . DF041 = false;
                    }
                }
                if ( row [ "DF042" ] != null && row [ "DF042" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF042" ] . ToString ( ) == "1" ) || ( row [ "DF042" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF042 = true;
                    }
                    else
                    {
                        model . DF042 = false;
                    }
                }
                if ( row [ "DF043" ] != null && row [ "DF043" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF043" ] . ToString ( ) == "1" ) || ( row [ "DF043" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF043 = true;
                    }
                    else
                    {
                        model . DF043 = false;
                    }
                }
                if ( row [ "DF044" ] != null && row [ "DF044" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF044" ] . ToString ( ) == "1" ) || ( row [ "DF044" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF044 = true;
                    }
                    else
                    {
                        model . DF044 = false;
                    }
                }
                if ( row [ "DF045" ] != null && row [ "DF045" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF045" ] . ToString ( ) == "1" ) || ( row [ "DF045" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF045 = true;
                    }
                    else
                    {
                        model . DF045 = false;
                    }
                }
                if ( row [ "DF046" ] != null && row [ "DF046" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF046" ] . ToString ( ) == "1" ) || ( row [ "DF046" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF046 = true;
                    }
                    else
                    {
                        model . DF046 = false;
                    }
                }
                if ( row [ "DF047" ] != null && row [ "DF047" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF047" ] . ToString ( ) == "1" ) || ( row [ "DF047" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF047 = true;
                    }
                    else
                    {
                        model . DF047 = false;
                    }
                }
                if ( row [ "DF048" ] != null && row [ "DF048" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF048" ] . ToString ( ) == "1" ) || ( row [ "DF048" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF048 = true;
                    }
                    else
                    {
                        model . DF048 = false;
                    }
                }
                if ( row [ "DF049" ] != null && row [ "DF049" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF049" ] . ToString ( ) == "1" ) || ( row [ "DF049" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF049 = true;
                    }
                    else
                    {
                        model . DF049 = false;
                    }
                }
                if ( row [ "DF050" ] != null && row [ "DF050" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF050" ] . ToString ( ) == "1" ) || ( row [ "DF050" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF050 = true;
                    }
                    else
                    {
                        model . DF050 = false;
                    }
                }
                if ( row [ "DF051" ] != null && row [ "DF051" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF051" ] . ToString ( ) == "1" ) || ( row [ "DF051" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF051 = true;
                    }
                    else
                    {
                        model . DF051 = false;
                    }
                }
                if ( row [ "DF052" ] != null && row [ "DF052" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF052" ] . ToString ( ) == "1" ) || ( row [ "DF052" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF052 = true;
                    }
                    else
                    {
                        model . DF052 = false;
                    }
                }
                if ( row [ "DF053" ] != null && row [ "DF053" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF053" ] . ToString ( ) == "1" ) || ( row [ "DF053" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF053 = true;
                    }
                    else
                    {
                        model . DF053 = false;
                    }
                }
                if ( row [ "DF054" ] != null && row [ "DF054" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF054" ] . ToString ( ) == "1" ) || ( row [ "DF054" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF054 = true;
                    }
                    else
                    {
                        model . DF054 = false;
                    }
                }
                if ( row [ "DF055" ] != null && row [ "DF055" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF055" ] . ToString ( ) == "1" ) || ( row [ "DF055" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF055 = true;
                    }
                    else
                    {
                        model . DF055 = false;
                    }
                }
                if ( row [ "DF056" ] != null && row [ "DF056" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF056" ] . ToString ( ) == "1" ) || ( row [ "DF056" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF057" ] != null && row [ "DF057" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF057" ] . ToString ( ) == "1" ) || ( row [ "DF057" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF058" ] != null && row [ "DF058" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF058" ] . ToString ( ) == "1" ) || ( row [ "DF058" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF059" ] != null && row [ "DF059" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF059" ] . ToString ( ) == "1" ) || ( row [ "DF059" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF060" ] != null && row [ "DF060" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF060" ] . ToString ( ) == "1" ) || ( row [ "DF060" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF061" ] != null && row [ "DF061" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF061" ] . ToString ( ) == "1" ) || ( row [ "DF061" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF062" ] != null && row [ "DF062" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF062" ] . ToString ( ) == "1" ) || ( row [ "DF062" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF063" ] != null && row [ "DF063" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF063" ] . ToString ( ) == "1" ) || ( row [ "DF063" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF064" ] != null && row [ "DF064" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF064" ] . ToString ( ) == "1" ) || ( row [ "DF064" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF065" ] != null && row [ "DF065" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF065" ] . ToString ( ) == "1" ) || ( row [ "DF065" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF066" ] != null && row [ "DF066" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF066" ] . ToString ( ) == "1" ) || ( row [ "DF066" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF067" ] != null && row [ "DF067" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF067" ] . ToString ( ) == "1" ) || ( row [ "DF067" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF068" ] != null && row [ "DF068" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF068" ] . ToString ( ) == "1" ) || ( row [ "DF068" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
                if ( row [ "DF069" ] != null && row [ "DF069" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "DF069" ] . ToString ( ) == "1" ) || ( row [ "DF069" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . DF056 = true;
                    }
                    else
                    {
                        model . DF056 = false;
                    }
                }
            }

            return model;

        }

        /// <summary>
        /// get datatable to view
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableView ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,DG001,DG002,DG003,DG004,DG005,DG006,DG007,ISNULL((SELECT SUM(DG007) FROM R_PQDG A WHERE A.DG002<B.DG002 AND A.DG001='{0}'),0)  DG008,DG009,ISNULL((SELECT SUM(DG009) FROM R_PQDG A WHERE A.DG002<B.DG002 AND A.DG001='{0}'),0) DG010,DG011,DG012,DG014,DG015,DG017,DG018,DG019,DG020,DG021 FROM R_PQDG B WHERE DG001='{0}' " ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }


        /// <summary>
        /// get max oddNum from r_pqdc
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DF001) DF001 FROM R_PQDF " );
            strSql . AppendFormat ( "WHERE DF001 LIKE 'R_366-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "DF001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_366-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_366-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_366-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from table
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDF WHERE DF001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_366" ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDG WHERE DG001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_366" ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_366" ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// save data to database
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableOne"></param>
        /// <param name="_df"></param>
        /// <param name="logins"></param>
        /// <param name="bodyList"></param>
        /// <param name="coeList"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,DataTable tableOne ,MulaolaoLibrary . ProductSpecificationDFEntity _df ,string logins ,List<string> bodyList ,List<string> coeList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            if ( _df . idx > 0 )
            {
                edit_df ( SQLString ,strSql ,_df );
                SQLString . Add ( Drity . DrityOfComparation ( "R_366" ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_df . DF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }
            else
            {
                _df . DF001 = getOddNum ( );
                add_df ( SQLString ,strSql ,_df );
                SQLString . Add ( Drity . DrityOfComparation ( "R_366" ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_df . DF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }

            MulaolaoLibrary . ProductSpecificationDGEntity model = new MulaolaoLibrary . ProductSpecificationDGEntity ( );
            model . DG001 = _df . DF001;
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "DG002" ] . ToString ( ) ) )
                    model . DG002 = null;
                else
                    model . DG002 = Convert . ToDateTime ( table . Rows [ i ] [ "DG002" ] . ToString ( ) );
                model . DG003 = table . Rows [ i ] [ "DG003" ] . ToString ( );
                model . DG004 = table . Rows [ i ] [ "DG004" ] . ToString ( );
                model . DG005 = table . Rows [ i ] [ "DG005" ] . ToString ( );
                model . DG006 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG006" ] . ToString ( ) );
                model . DG007 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG007" ] . ToString ( ) );
                model . DG008 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG008" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG008" ] . ToString ( ) );
                model . DG009 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG009" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG009" ] . ToString ( ) );
                model . DG010 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG010" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG010" ] . ToString ( ) );
                model . DG011 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG011" ] . ToString ( ) );
                model . DG012 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG012" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG012" ] . ToString ( ) );
                //model . DG013 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG013" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG013" ] . ToString ( ) );
                model . DG014 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "DG014" ] . ToString ( ) );
                model . DG015 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "DG015" ] . ToString ( ) );
                //model . DG016 = String . IsNullOrEmpty ( table . Rows [ i ] [ "DG016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "DG016" ] . ToString ( ) );
                model . DG017 = table . Rows [ i ] [ "DG017" ] . ToString ( );
                model . DG018 = table . Rows [ i ] [ "DG018" ] . ToString ( );
                model . DG019 = table . Rows [ i ] [ "DG019" ] . ToString ( );
                model . DG020 = table . Rows [ i ] [ "DG020" ] . ToString ( );
                model . DG021 = table . Rows [ i ] [ "DG021" ] . ToString ( );
                model . idx = String . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( model . idx > 0 )
                {
                    edit_dg ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + i ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_df . DF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表身" ) ,null );
                }
                else
                {
                    add_dg ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + i ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_df . DF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表身" ) ,null );
                }
            }

            if ( bodyList . Count > 0 )
            {
                foreach ( string s in bodyList )
                {
                    model . idx = Convert . ToInt32 ( s );
                    delete_dg ( SQLString ,strSql ,model );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + model . idx ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_df . DF001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除表身" ) ,null );
                }
            }

            /*
            MulaolaoLibrary . ProductSpecificationDHEntity _dh = new MulaolaoLibrary . ProductSpecificationDHEntity ( );
            for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
            {
                _dh . DH001 = tableOne . Rows [ i ] [ "DH001" ] . ToString ( );
                _dh . DH002 = tableOne . Rows [ i ] [ "DH002" ] . ToString ( );
                _dh . DH003 = tableOne . Rows [ i ] [ "DH003" ] . ToString ( );
                _dh . idx = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "idx" ] . ToString ( ) );
                if ( _dh . idx > 0 )
                {
                    edit_dh ( SQLString ,strSql ,_dh );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + i ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_dh . DH001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑系数" ) ,null );
                }
                else
                {
                    add_dh ( SQLString ,strSql ,_dh );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + i ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_dh . DH001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增系数" ) ,null );
                }
            }

            if ( coeList . Count > 0 )
            {
                foreach ( string s in coeList )
                {
                    _dh . idx = Convert . ToInt32 ( s );
                    delete_dh ( SQLString ,strSql ,_dh );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_366" + _dh . idx ,"产品各部件检验规程及作业指导表(R_366)" ,logins ,Drity . GetDt ( ) ,_dh . DH001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除系数" ) ,null );
                }
            }
            */

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_df ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDFEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDF(" );
            strSql . Append ( "DF001,DF002,DF003,DF004,DF005,DF006,DF007,DF008,DF009,DF010,DF011,DF012,DF013,DF014,DF015,DF016,DF017,DF018,DF019,DF020,DF021,DF022,DF023,DF024,DF025,DF026,DF027,DF028,DF029,DF030,DF031,DF032,DF033,DF034,DF035,DF036,DF037,DF038,DF039,DF040,DF041,DF042,DF043,DF044,DF045,DF046,DF047,DF048,DF049,DF050,DF051,DF052,DF053,DF054,DF055,DF056,DF057,DF058,DF059,DF060,DF061,DF062,DF063,DF064,DF065,DF066,DF067,DF068,DF069)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DF001,@DF002,@DF003,@DF004,@DF005,@DF006,@DF007,@DF008,@DF009,@DF010,@DF011,@DF012,@DF013,@DF014,@DF015,@DF016,@DF017,@DF018,@DF019,@DF020,@DF021,@DF022,@DF023,@DF024,@DF025,@DF026,@DF027,@DF028,@DF029,@DF030,@DF031,@DF032,@DF033,@DF034,@DF035,@DF036,@DF037,@DF038,@DF039,@DF040,@DF041,@DF042,@DF043,@DF044,@DF045,@DF046,@DF047,@DF048,@DF049,@DF050,@DF051,@DF052,@DF053,@DF054,@DF055,@DF056,@DF057,@DF058,@DF059,@DF060,@DF061,@DF062,@DF063,@DF064,@DF065,@DF066,@DF067,@DF068,@DF069)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DF001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF005", SqlDbType.Int,4),
                    new SqlParameter("@DF006", SqlDbType.Date,3),
                    new SqlParameter("@DF007", SqlDbType.Int,4),
                    new SqlParameter("@DF008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF011", SqlDbType.Bit,1),
                    new SqlParameter("@DF012", SqlDbType.Bit,1),
                    new SqlParameter("@DF013", SqlDbType.Bit,1),
                    new SqlParameter("@DF014", SqlDbType.Bit,1),
                    new SqlParameter("@DF015", SqlDbType.Bit,1),
                    new SqlParameter("@DF016", SqlDbType.Bit,1),
                    new SqlParameter("@DF017", SqlDbType.Bit,1),
                    new SqlParameter("@DF018", SqlDbType.Bit,1),
                    new SqlParameter("@DF019", SqlDbType.Bit,1),
                    new SqlParameter("@DF020", SqlDbType.Bit,1),
                    new SqlParameter("@DF021", SqlDbType.Bit,1),
                    new SqlParameter("@DF022", SqlDbType.Bit,1),
                    new SqlParameter("@DF023", SqlDbType.Bit,1),
                    new SqlParameter("@DF024", SqlDbType.Bit,1),
                    new SqlParameter("@DF025", SqlDbType.Bit,1),
                    new SqlParameter("@DF026", SqlDbType.Bit,1),
                    new SqlParameter("@DF027", SqlDbType.Bit,1),
                    new SqlParameter("@DF028", SqlDbType.Bit,1),
                    new SqlParameter("@DF029", SqlDbType.Bit,1),
                    new SqlParameter("@DF030", SqlDbType.Bit,1),
                    new SqlParameter("@DF031", SqlDbType.Bit,1),
                    new SqlParameter("@DF032", SqlDbType.Bit,1),
                    new SqlParameter("@DF033", SqlDbType.Bit,1),
                    new SqlParameter("@DF034", SqlDbType.Bit,1),
                    new SqlParameter("@DF035", SqlDbType.Bit,1),
                    new SqlParameter("@DF036", SqlDbType.Bit,1),
                    new SqlParameter("@DF037", SqlDbType.Bit,1),
                    new SqlParameter("@DF038", SqlDbType.Bit,1),
                    new SqlParameter("@DF039", SqlDbType.Bit,1),
                    new SqlParameter("@DF040", SqlDbType.Bit,1),
                    new SqlParameter("@DF041", SqlDbType.Bit,1),
                    new SqlParameter("@DF042", SqlDbType.Bit,1),
                    new SqlParameter("@DF043", SqlDbType.Bit,1),
                    new SqlParameter("@DF044", SqlDbType.Bit,1),
                    new SqlParameter("@DF045", SqlDbType.Bit,1),
                    new SqlParameter("@DF046", SqlDbType.Bit,1),
                    new SqlParameter("@DF047", SqlDbType.Bit,1),
                    new SqlParameter("@DF048", SqlDbType.Bit,1),
                    new SqlParameter("@DF049", SqlDbType.Bit,1),
                    new SqlParameter("@DF050", SqlDbType.Bit,1),
                    new SqlParameter("@DF051", SqlDbType.Bit,1),
                    new SqlParameter("@DF052", SqlDbType.Bit,1),
                    new SqlParameter("@DF053", SqlDbType.Bit,1),
                    new SqlParameter("@DF054", SqlDbType.Bit,1),
                    new SqlParameter("@DF055", SqlDbType.Bit,1),
                    new SqlParameter("@DF056", SqlDbType.Bit,1),
                    new SqlParameter("@DF057", SqlDbType.Bit,1),
                    new SqlParameter("@DF058", SqlDbType.Bit,1),
                    new SqlParameter("@DF059", SqlDbType.Bit,1),
                    new SqlParameter("@DF060", SqlDbType.Bit,1),
                    new SqlParameter("@DF061", SqlDbType.Bit,1),
                    new SqlParameter("@DF062", SqlDbType.Bit,1),
                    new SqlParameter("@DF063", SqlDbType.Bit,1),
                    new SqlParameter("@DF064", SqlDbType.Bit,1),
                    new SqlParameter("@DF065", SqlDbType.Bit,1),
                    new SqlParameter("@DF066", SqlDbType.Bit,1),
                    new SqlParameter("@DF067", SqlDbType.Bit,1),
                    new SqlParameter("@DF068", SqlDbType.Bit,1),
                    new SqlParameter("@DF069", SqlDbType.Bit,1)
            };
            parameters [ 0 ] . Value = model . DF001;
            parameters [ 1 ] . Value = model . DF002;
            parameters [ 2 ] . Value = model . DF003;
            parameters [ 3 ] . Value = model . DF004;
            parameters [ 4 ] . Value = model . DF005;
            if ( model . DF006 != null )
                parameters [ 5 ] . Value = model . DF006;
            else
                parameters [ 5 ] . Value = DBNull . Value;
            parameters [ 6 ] . Value = model . DF007;
            parameters [ 7 ] . Value = model . DF008;
            parameters [ 8 ] . Value = model . DF009;
            parameters [ 9 ] . Value = model . DF010;
            parameters [ 10 ] . Value = model . DF011;
            parameters [ 11 ] . Value = model . DF012;
            parameters [ 12 ] . Value = model . DF013;
            parameters [ 13 ] . Value = model . DF014;
            parameters [ 14 ] . Value = model . DF015;
            parameters [ 15 ] . Value = model . DF016;
            parameters [ 16 ] . Value = model . DF017;
            parameters [ 17 ] . Value = model . DF018;
            parameters [ 18 ] . Value = model . DF019;
            parameters [ 19 ] . Value = model . DF020;
            parameters [ 20 ] . Value = model . DF021;
            parameters [ 21 ] . Value = model . DF022;
            parameters [ 22 ] . Value = model . DF023;
            parameters [ 23 ] . Value = model . DF024;
            parameters [ 24 ] . Value = model . DF025;
            parameters [ 25 ] . Value = model . DF026;
            parameters [ 26 ] . Value = model . DF027;
            parameters [ 27 ] . Value = model . DF028;
            parameters [ 28 ] . Value = model . DF029;
            parameters [ 29 ] . Value = model . DF030;
            parameters [ 30 ] . Value = model . DF031;
            parameters [ 31 ] . Value = model . DF032;
            parameters [ 32 ] . Value = model . DF033;
            parameters [ 33 ] . Value = model . DF034;
            parameters [ 34 ] . Value = model . DF035;
            parameters [ 35 ] . Value = model . DF036;
            parameters [ 36 ] . Value = model . DF037;
            parameters [ 37 ] . Value = model . DF038;
            parameters [ 38 ] . Value = model . DF039;
            parameters [ 39 ] . Value = model . DF040;
            parameters [ 40 ] . Value = model . DF041;
            parameters [ 41 ] . Value = model . DF042;
            parameters [ 42 ] . Value = model . DF043;
            parameters [ 43 ] . Value = model . DF044;
            parameters [ 44 ] . Value = model . DF045;
            parameters [ 45 ] . Value = model . DF046;
            parameters [ 46 ] . Value = model . DF047;
            parameters [ 47 ] . Value = model . DF048;
            parameters [ 48 ] . Value = model . DF049;
            parameters [ 49 ] . Value = model . DF050;
            parameters [ 50 ] . Value = model . DF051;
            parameters [ 51 ] . Value = model . DF052;
            parameters [ 52 ] . Value = model . DF053;
            parameters [ 53 ] . Value = model . DF054;
            parameters [ 54 ] . Value = model . DF055;
            parameters [ 55 ] . Value = model . DF056;
            parameters [ 56 ] . Value = model . DF057;
            parameters [ 57 ] . Value = model . DF058;
            parameters [ 58 ] . Value = model . DF059;
            parameters [ 59 ] . Value = model . DF060;
            parameters [ 60 ] . Value = model . DF061;
            parameters [ 61 ] . Value = model . DF062;
            parameters [ 62 ] . Value = model . DF063;
            parameters [ 63 ] . Value = model . DF064;
            parameters [ 64 ] . Value = model . DF065;
            parameters [ 65 ] . Value = model . DF066;
            parameters [ 66 ] . Value = model . DF067;
            parameters [ 67 ] . Value = model . DF068;
            parameters [ 68 ] . Value = model . DF069;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_df ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDFEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDF set " );
            strSql . Append ( "DF001=@DF001," );
            strSql . Append ( "DF002=@DF002," );
            strSql . Append ( "DF003=@DF003," );
            strSql . Append ( "DF004=@DF004," );
            strSql . Append ( "DF005=@DF005," );
            strSql . Append ( "DF006=@DF006," );
            strSql . Append ( "DF007=@DF007," );
            strSql . Append ( "DF008=@DF008," );
            strSql . Append ( "DF009=@DF009," );
            strSql . Append ( "DF010=@DF010," );
            strSql . Append ( "DF011=@DF011," );
            strSql . Append ( "DF012=@DF012," );
            strSql . Append ( "DF013=@DF013," );
            strSql . Append ( "DF014=@DF014," );
            strSql . Append ( "DF015=@DF015," );
            strSql . Append ( "DF016=@DF016," );
            strSql . Append ( "DF017=@DF017," );
            strSql . Append ( "DF018=@DF018," );
            strSql . Append ( "DF019=@DF019," );
            strSql . Append ( "DF020=@DF020," );
            strSql . Append ( "DF021=@DF021," );
            strSql . Append ( "DF022=@DF022," );
            strSql . Append ( "DF023=@DF023," );
            strSql . Append ( "DF024=@DF024," );
            strSql . Append ( "DF025=@DF025," );
            strSql . Append ( "DF026=@DF026," );
            strSql . Append ( "DF027=@DF027," );
            strSql . Append ( "DF028=@DF028," );
            strSql . Append ( "DF029=@DF029," );
            strSql . Append ( "DF030=@DF030," );
            strSql . Append ( "DF031=@DF031," );
            strSql . Append ( "DF032=@DF032," );
            strSql . Append ( "DF033=@DF033," );
            strSql . Append ( "DF034=@DF034," );
            strSql . Append ( "DF035=@DF035," );
            strSql . Append ( "DF036=@DF036," );
            strSql . Append ( "DF037=@DF037," );
            strSql . Append ( "DF038=@DF038," );
            strSql . Append ( "DF039=@DF039," );
            strSql . Append ( "DF040=@DF040," );
            strSql . Append ( "DF041=@DF041," );
            strSql . Append ( "DF042=@DF042," );
            strSql . Append ( "DF043=@DF043," );
            strSql . Append ( "DF044=@DF044," );
            strSql . Append ( "DF045=@DF045," );
            strSql . Append ( "DF046=@DF046," );
            strSql . Append ( "DF047=@DF047," );
            strSql . Append ( "DF048=@DF048," );
            strSql . Append ( "DF049=@DF049," );
            strSql . Append ( "DF050=@DF050," );
            strSql . Append ( "DF051=@DF051," );
            strSql . Append ( "DF052=@DF052," );
            strSql . Append ( "DF053=@DF053," );
            strSql . Append ( "DF054=@DF054," );
            strSql . Append ( "DF055=@DF055," );
            strSql . Append ( "DF056=@DF056," );
            strSql . Append ( "DF057=@DF057," );
            strSql . Append ( "DF058=@DF058," );
            strSql . Append ( "DF059=@DF059," );
            strSql . Append ( "DF060=@DF060," );
            strSql . Append ( "DF061=@DF061," );
            strSql . Append ( "DF062=@DF062," );
            strSql . Append ( "DF063=@DF063," );
            strSql . Append ( "DF064=@DF064," );
            strSql . Append ( "DF065=@DF065," );
            strSql . Append ( "DF066=@DF066," );
            strSql . Append ( "DF067=@DF067," );
            strSql . Append ( "DF068=@DF068," );
            strSql . Append ( "DF069=@DF069 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DF001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF005", SqlDbType.Int,4),
                    new SqlParameter("@DF006", SqlDbType.Date,3),
                    new SqlParameter("@DF007", SqlDbType.Int,4),
                    new SqlParameter("@DF008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF009", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF010", SqlDbType.NVarChar,20),
                    new SqlParameter("@DF011", SqlDbType.Bit,1),
                    new SqlParameter("@DF012", SqlDbType.Bit,1),
                    new SqlParameter("@DF013", SqlDbType.Bit,1),
                    new SqlParameter("@DF014", SqlDbType.Bit,1),
                    new SqlParameter("@DF015", SqlDbType.Bit,1),
                    new SqlParameter("@DF016", SqlDbType.Bit,1),
                    new SqlParameter("@DF017", SqlDbType.Bit,1),
                    new SqlParameter("@DF018", SqlDbType.Bit,1),
                    new SqlParameter("@DF019", SqlDbType.Bit,1),
                    new SqlParameter("@DF020", SqlDbType.Bit,1),
                    new SqlParameter("@DF021", SqlDbType.Bit,1),
                    new SqlParameter("@DF022", SqlDbType.Bit,1),
                    new SqlParameter("@DF023", SqlDbType.Bit,1),
                    new SqlParameter("@DF024", SqlDbType.Bit,1),
                    new SqlParameter("@DF025", SqlDbType.Bit,1),
                    new SqlParameter("@DF026", SqlDbType.Bit,1),
                    new SqlParameter("@DF027", SqlDbType.Bit,1),
                    new SqlParameter("@DF028", SqlDbType.Bit,1),
                    new SqlParameter("@DF029", SqlDbType.Bit,1),
                    new SqlParameter("@DF030", SqlDbType.Bit,1),
                    new SqlParameter("@DF031", SqlDbType.Bit,1),
                    new SqlParameter("@DF032", SqlDbType.Bit,1),
                    new SqlParameter("@DF033", SqlDbType.Bit,1),
                    new SqlParameter("@DF034", SqlDbType.Bit,1),
                    new SqlParameter("@DF035", SqlDbType.Bit,1),
                    new SqlParameter("@DF036", SqlDbType.Bit,1),
                    new SqlParameter("@DF037", SqlDbType.Bit,1),
                    new SqlParameter("@DF038", SqlDbType.Bit,1),
                    new SqlParameter("@DF039", SqlDbType.Bit,1),
                    new SqlParameter("@DF040", SqlDbType.Bit,1),
                    new SqlParameter("@DF041", SqlDbType.Bit,1),
                    new SqlParameter("@DF042", SqlDbType.Bit,1),
                    new SqlParameter("@DF043", SqlDbType.Bit,1),
                    new SqlParameter("@DF044", SqlDbType.Bit,1),
                    new SqlParameter("@DF045", SqlDbType.Bit,1),
                    new SqlParameter("@DF046", SqlDbType.Bit,1),
                    new SqlParameter("@DF047", SqlDbType.Bit,1),
                    new SqlParameter("@DF048", SqlDbType.Bit,1),
                    new SqlParameter("@DF049", SqlDbType.Bit,1),
                    new SqlParameter("@DF050", SqlDbType.Bit,1),
                    new SqlParameter("@DF051", SqlDbType.Bit,1),
                    new SqlParameter("@DF052", SqlDbType.Bit,1),
                    new SqlParameter("@DF053", SqlDbType.Bit,1),
                    new SqlParameter("@DF054", SqlDbType.Bit,1),
                    new SqlParameter("@DF055", SqlDbType.Bit,1),
                    new SqlParameter("@DF056", SqlDbType.Bit,1),
                    new SqlParameter("@DF057", SqlDbType.Bit,1),
                    new SqlParameter("@DF058", SqlDbType.Bit,1),
                    new SqlParameter("@DF059", SqlDbType.Bit,1),
                    new SqlParameter("@DF060", SqlDbType.Bit,1),
                    new SqlParameter("@DF061", SqlDbType.Bit,1),
                    new SqlParameter("@DF062", SqlDbType.Bit,1),
                    new SqlParameter("@DF063", SqlDbType.Bit,1),
                    new SqlParameter("@DF064", SqlDbType.Bit,1),
                    new SqlParameter("@DF065", SqlDbType.Bit,1),
                    new SqlParameter("@DF066", SqlDbType.Bit,1),
                    new SqlParameter("@DF067", SqlDbType.Bit,1),
                    new SqlParameter("@DF068", SqlDbType.Bit,1),
                    new SqlParameter("@DF069", SqlDbType.Bit,1),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DF001;
            parameters [ 1 ] . Value = model . DF002;
            parameters [ 2 ] . Value = model . DF003;
            parameters [ 3 ] . Value = model . DF004;
            parameters [ 4 ] . Value = model . DF005;
            if ( model . DF006 != null )
                parameters [ 5 ] . Value = model . DF006;
            else
                parameters [ 5 ] . Value = DBNull . Value;
            parameters [ 6 ] . Value = model . DF007;
            parameters [ 7 ] . Value = model . DF008;
            parameters [ 8 ] . Value = model . DF009;
            parameters [ 9 ] . Value = model . DF010;
            parameters [ 10 ] . Value = model . DF011;
            parameters [ 11 ] . Value = model . DF012;
            parameters [ 12 ] . Value = model . DF013;
            parameters [ 13 ] . Value = model . DF014;
            parameters [ 14 ] . Value = model . DF015;
            parameters [ 15 ] . Value = model . DF016;
            parameters [ 16 ] . Value = model . DF017;
            parameters [ 17 ] . Value = model . DF018;
            parameters [ 18 ] . Value = model . DF019;
            parameters [ 19 ] . Value = model . DF020;
            parameters [ 20 ] . Value = model . DF021;
            parameters [ 21 ] . Value = model . DF022;
            parameters [ 22 ] . Value = model . DF023;
            parameters [ 23 ] . Value = model . DF024;
            parameters [ 24 ] . Value = model . DF025;
            parameters [ 25 ] . Value = model . DF026;
            parameters [ 26 ] . Value = model . DF027;
            parameters [ 27 ] . Value = model . DF028;
            parameters [ 28 ] . Value = model . DF029;
            parameters [ 29 ] . Value = model . DF030;
            parameters [ 30 ] . Value = model . DF031;
            parameters [ 31 ] . Value = model . DF032;
            parameters [ 32 ] . Value = model . DF033;
            parameters [ 33 ] . Value = model . DF034;
            parameters [ 34 ] . Value = model . DF035;
            parameters [ 35 ] . Value = model . DF036;
            parameters [ 36 ] . Value = model . DF037;
            parameters [ 37 ] . Value = model . DF038;
            parameters [ 38 ] . Value = model . DF039;
            parameters [ 39 ] . Value = model . DF040;
            parameters [ 40 ] . Value = model . DF041;
            parameters [ 41 ] . Value = model . DF042;
            parameters [ 42 ] . Value = model . DF043;
            parameters [ 43 ] . Value = model . DF044;
            parameters [ 44 ] . Value = model . DF045;
            parameters [ 45 ] . Value = model . DF046;
            parameters [ 46 ] . Value = model . DF047;
            parameters [ 47 ] . Value = model . DF048;
            parameters [ 48 ] . Value = model . DF049;
            parameters [ 49 ] . Value = model . DF050;
            parameters [ 50 ] . Value = model . DF051;
            parameters [ 51 ] . Value = model . DF052;
            parameters [ 52 ] . Value = model . DF053;
            parameters [ 53 ] . Value = model . DF054;
            parameters [ 54 ] . Value = model . DF055;
            parameters [ 55 ] . Value = model . DF056;
            parameters [ 56 ] . Value = model . DF057;
            parameters [ 57 ] . Value = model . DF058;
            parameters [ 58 ] . Value = model . DF059;
            parameters [ 59 ] . Value = model . DF060;
            parameters [ 60 ] . Value = model . DF061;
            parameters [ 61 ] . Value = model . DF062;
            parameters [ 62 ] . Value = model . DF063;
            parameters [ 63 ] . Value = model . DF064;
            parameters [ 64 ] . Value = model . DF065;
            parameters [ 65 ] . Value = model . DF066;
            parameters [ 66 ] . Value = model . DF067;
            parameters [ 67 ] . Value = model . DF068;
            parameters [ 68 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDGEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDG set " );
            strSql . Append ( "DG001=@DG001," );
            strSql . Append ( "DG002=@DG002," );
            strSql . Append ( "DG003=@DG003," );
            strSql . Append ( "DG004=@DG004," );
            strSql . Append ( "DG005=@DG005," );
            strSql . Append ( "DG006=@DG006," );
            strSql . Append ( "DG007=@DG007," );
            strSql . Append ( "DG008=@DG008," );
            strSql . Append ( "DG009=@DG009," );
            strSql . Append ( "DG010=@DG010," );
            strSql . Append ( "DG011=@DG011," );
            strSql . Append ( "DG012=@DG012," );
            //strSql . Append ( "DG013=@DG013," );
            strSql . Append ( "DG014=@DG014," );
            strSql . Append ( "DG015=@DG015," );
            //strSql . Append ( "DG016=@DG016," );
            strSql . Append ( "DG017=@DG017," );
            strSql . Append ( "DG018=@DG018," );
            strSql . Append ( "DG019=@DG019," );
            strSql . Append ( "DG020=@DG020," );
            strSql . Append ( "DG021=@DG021 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DG001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG002", SqlDbType.Date,3),
                    new SqlParameter("@DG003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG006", SqlDbType.Int,4),
                    new SqlParameter("@DG007", SqlDbType.Int,4),
                    new SqlParameter("@DG008", SqlDbType.Int,4),
                    new SqlParameter("@DG009", SqlDbType.Int,4),
                    new SqlParameter("@DG010", SqlDbType.Int,4),
                    new SqlParameter("@DG011", SqlDbType.Int,4),
                    new SqlParameter("@DG012", SqlDbType.Int,4),
                    //new SqlParameter("@DG013", SqlDbType.Int,4),
                    new SqlParameter("@DG014", SqlDbType.Int,4),
                    new SqlParameter("@DG015", SqlDbType.Decimal,9),
                    //new SqlParameter("@DG016", SqlDbType.Decimal,9),
                    new SqlParameter("@DG017", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG019", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG021", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DG001;
            parameters [ 1 ] . Value = model . DG002;
            parameters [ 2 ] . Value = model . DG003;
            parameters [ 3 ] . Value = model . DG004;
            parameters [ 4 ] . Value = model . DG005;
            parameters [ 5 ] . Value = model . DG006;
            parameters [ 6 ] . Value = model . DG007;
            parameters [ 7 ] . Value = model . DG008;
            parameters [ 8 ] . Value = model . DG009;
            parameters [ 9 ] . Value = model . DG010;
            parameters [ 10 ] . Value = model . DG011;
            parameters [ 11 ] . Value = model . DG012;
            //parameters [ 12 ] . Value = model . DG013;
            parameters [ 12 ] . Value = model . DG014;
            parameters [ 13 ] . Value = model . DG015;
            //parameters [ 15 ] . Value = model . DG016;
            parameters [ 14 ] . Value = model . DG017;
            parameters [ 15 ] . Value = model . DG018;
            parameters [ 16 ] . Value = model . DG019;
            parameters [ 17 ] . Value = model . DG020;
            parameters [ 18 ] . Value = model . DG021;
            parameters [ 19 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void add_dg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDGEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDG(" );
            strSql . Append ( "DG001,DG002,DG003,DG004,DG005,DG006,DG007,DG008,DG009,DG010,DG011,DG012,DG014,DG015,DG017,DG018,DG019,DG020,DG021)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DG001,@DG002,@DG003,@DG004,@DG005,@DG006,@DG007,@DG008,@DG009,@DG010,@DG011,@DG012,@DG014,@DG015,@DG017,@DG018,@DG019,@DG020,@DG021)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DG001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG002", SqlDbType.Date,3),
                    new SqlParameter("@DG003", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG006", SqlDbType.Int,4),
                    new SqlParameter("@DG007", SqlDbType.Int,4),
                    new SqlParameter("@DG008", SqlDbType.Int,4),
                    new SqlParameter("@DG009", SqlDbType.Int,4),
                    new SqlParameter("@DG010", SqlDbType.Int,4),
                    new SqlParameter("@DG011", SqlDbType.Int,4),
                    new SqlParameter("@DG012", SqlDbType.Int,4),
                    //new SqlParameter("@DG013", SqlDbType.Int,4),
                    new SqlParameter("@DG014", SqlDbType.Int,4),
                    new SqlParameter("@DG015", SqlDbType.Decimal,9),
                    //new SqlParameter("@DG016", SqlDbType.Decimal,9),
                    new SqlParameter("@DG017", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG019", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DG021", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . DG001;
            if ( model . DG002 != null )
                parameters [ 1 ] . Value = model . DG002;
            else
                parameters [ 1 ] . Value = DBNull . Value;
            parameters [ 2 ] . Value = model . DG003;
            parameters [ 3 ] . Value = model . DG004;
            parameters [ 4 ] . Value = model . DG005;
            parameters [ 5 ] . Value = model . DG006;
            parameters [ 6 ] . Value = model . DG007;
            parameters [ 7 ] . Value = model . DG008;
            parameters [ 8 ] . Value = model . DG009;
            parameters [ 9 ] . Value = model . DG010;
            parameters [ 10 ] . Value = model . DG011;
            parameters [ 11 ] . Value = model . DG012;
            //parameters [ 12 ] . Value = model . DG013;
            parameters [ 12 ] . Value = model . DG014;
            parameters [ 13 ] . Value = model . DG015;
            //parameters [ 15 ] . Value = model . DG016;
            parameters [ 14 ] . Value = model . DG017;
            parameters [ 15 ] . Value = model . DG018;
            parameters [ 16 ] . Value = model . DG019;
            parameters [ 17 ] . Value = model . DG020;
            parameters [ 18 ] . Value = model . DG021;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_dg ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDGEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQDG " );
            strSql . AppendFormat ( " where idx={0} " ,model . idx );
            SQLString . Add ( strSql ,null );
        }

        void add_dh ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDH(" );
            strSql . Append ( "DH001,DH002,DH003)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DH001,@DH002,@DH003)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DH001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DH002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DH003", SqlDbType.NVarChar,50)
            };
            parameters [ 0 ] . Value = model . DH001;
            parameters [ 1 ] . Value = model . DH002;
            parameters [ 2 ] . Value = model . DH003;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dh ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDH set " );
            strSql . Append ( "DH001=@DH001," );
            strSql . Append ( "DH002=@DH002," );
            strSql . Append ( "DH003=@DH003 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DH001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DH002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DH003", SqlDbType.NVarChar,50),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . DH001;
            parameters [ 1 ] . Value = model . DH002;
            parameters [ 2 ] . Value = model . DH003;
            parameters [ 3 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

        void delete_dh ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . ProductSpecificationDHEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQDH " );
            strSql . AppendFormat ( "WHERE idx={0}" ,model . idx );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// get part from r_pqp
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTablePart ( string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GS07,CAST(GS10 as float) GS10 FROM (SELECT GS07,GS10 FROM R_PQP WHERE GS01='{0}' AND GS07 IS NOT NULL AND GS07!='' UNION SELECT GS35,0 FROM R_PQP WHERE GS01='{0}' AND  GS35 IS NOT NULL AND GS35!='' UNION SELECT GS56,GS59 FROM R_PQP WHERE GS01='{0}' AND  GS56 IS NOT NULL AND GS56!='') A ORDER BY GS07" ,num );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from r_pqdh
        /// </summary>
        /// <returns></returns>
        public DataTable getTableCheck ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DH002 FROM R_PQDH " );

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
            strSql . AppendFormat ( "SELECT idx,DG001,DG002,DG003,DG004,DG005,DG006,DG007,ISNULL((SELECT SUM(DG007) FROM R_PQDG A WHERE A.DG002<B.DG002 AND A.DG001='{0}'),0)  DG008,DG009,ISNULL((SELECT SUM(DG009) FROM R_PQDG A WHERE A.DG002<B.DG002 AND A.DG001='{0}'),0) DG010,DG011,DG012,DG014,DG015,DG017,DG018,DG019,DG020,DG021,DG006-DG010-DG012+DG014 U0,CASE WHEN DG008=0 THEN 0 ELSE CONVERT(DECIMAL(18,1),DG010*1.0/DG008) END U1 FROM R_PQDG B WHERE DG001='{0}' " ,oddNum );

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
            strSql . AppendFormat ( "SELECT idx,DF001,DF002,DF003,DF004,DF005,DF006,DF007,DF008,DF009,DF010 FROM R_PQDF WHERE DF001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
