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
    public class QualityReportDao
    {
        /// <summary>
        /// get pro info from r_pqf
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPro ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PQF01,PQF04,PQF02,PQF03,PQF31,PQF06,PQF67,DFA003,PQF66 FROM R_PQF A LEFT JOIN TPADFA B ON A.PQF11=B.DFA001 ORDER BY PQF01 DESC" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// get datatable from r_pqdk
        /// </summary>
        /// <returns></returns>
        public DataTable getColumnOnly ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DK001,DK002,DK003,DK004,DK006 FROM R_PQDK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get count from r_pqdk
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM (SELECT DISTINCT DK001,DK002,DK003,DK004 FROM R_PQDK WHERE {0}) A" ,strWhere );

            object obj = SqlHelper . GetSingle ( strSql . ToString ( ) );
            if ( obj == null )
                return 0;
            else
                return Convert . ToInt32 ( obj );
        }

        /// <summary>
        /// get table by one by page
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere,int startIndex,int endIndex )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DK001,DK002,DK003,DK004,RES05,DK008,DK038,DK006 FROM (" );
            strSql . Append ( "SELECT ROW_NUMBER() OVER (" );
            strSql . Append ( "ORDER BY T.DK001 DESC)" );
            strSql . Append ( " AS ROW,T.* FROM R_PQDK T " );
            strSql . Append ( "WHERE " + strWhere );
            strSql . Append ( ") TT LEFT JOIN R_REVIEWS ON DK001=RES06 " );
            strSql . AppendFormat ( "WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data list from r_pqdk
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QualityReportDKEntity getModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,DK001,DK002,DK003,DK004,DK005,DK006,DK007,DK008,DK009,DK010,DK011,DK012,DK013,DK014,DK015,DK016,DK017,DK018,DK019,DK020,DK021,DK022,DK023,DK024,DK025,DK026,DK027,DK028,DK029,DK030,DK031,DK032,DK033,DK034,DK035,DK036,DK037,DK038,DK039 FROM R_PQDK " );
            strSql . Append ( " where DK001=@DK001" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DK001", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = oddNum;

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameters );
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MulaolaoLibrary . QualityReportDKEntity getModel ( DataRow row )
        {
            MulaolaoLibrary . QualityReportDKEntity model = new MulaolaoLibrary . QualityReportDKEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null && row [ "idx" ] . ToString ( ) != "" )
                {
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                }
                if ( row [ "DK001" ] != null )
                {
                    model . DK001 = row [ "DK001" ] . ToString ( );
                }
                if ( row [ "DK002" ] != null )
                {
                    model . DK002 = row [ "DK002" ] . ToString ( );
                }
                if ( row [ "DK003" ] != null )
                {
                    model . DK003 = row [ "DK003" ] . ToString ( );
                }
                if ( row [ "DK004" ] != null )
                {
                    model . DK004 = row [ "DK004" ] . ToString ( );
                }
                if ( row [ "DK005" ] != null )
                {
                    model . DK005 = row [ "DK005" ] . ToString ( );
                }
                if ( row [ "DK006" ] != null )
                {
                    model . DK006 = row [ "DK006" ] . ToString ( );
                }
                if ( row [ "DK007" ] != null )
                {
                    model . DK007 = row [ "DK007" ] . ToString ( );
                }
                if ( row [ "DK008" ] != null )
                {
                    model . DK008 = row [ "DK008" ] . ToString ( );
                }
                if ( row [ "DK009" ] != null && row [ "DK009" ] . ToString ( ) != "" )
                {
                    model . DK009 = DateTime . Parse ( row [ "DK009" ] . ToString ( ) );
                }
                if ( row [ "DK010" ] != null && row [ "DK010" ] . ToString ( ) != "" )
                {
                    model . DK010 = int . Parse ( row [ "DK010" ] . ToString ( ) );
                }
                if ( row [ "DK011" ] != null && row [ "DK011" ] . ToString ( ) != "" )
                {
                    model . DK011 = int . Parse ( row [ "DK011" ] . ToString ( ) );
                }
                if ( row [ "DK012" ] != null && row [ "DK012" ] . ToString ( ) != "" )
                {
                    model . DK012 = DateTime . Parse ( row [ "DK012" ] . ToString ( ) );
                }
                if ( row [ "DK013" ] != null && row [ "DK013" ] . ToString ( ) != "" )
                {
                    model . DK013 = DateTime . Parse ( row [ "DK013" ] . ToString ( ) );
                }
                if ( row [ "DK014" ] != null && row [ "DK014" ] . ToString ( ) != "" )
                {
                    model . DK014 = DateTime . Parse ( row [ "DK014" ] . ToString ( ) );
                }
                if ( row [ "DK015" ] != null && row [ "DK015" ] . ToString ( ) != "" )
                {
                    model . DK015 = DateTime . Parse ( row [ "DK015" ] . ToString ( ) );
                }
                if ( row [ "DK016" ] != null )
                {
                    model . DK016 = row [ "DK016" ] . ToString ( );
                }
                if ( row [ "DK017" ] != null && row [ "DK017" ] . ToString ( ) != "" )
                {
                    model . DK017 = DateTime . Parse ( row [ "DK017" ] . ToString ( ) );
                }
                if ( row [ "DK018" ] != null )
                {
                    model . DK018 = row [ "DK018" ] . ToString ( );
                }
                if ( row [ "DK019" ] != null && row [ "DK019" ] . ToString ( ) != "" )
                {
                    model . DK019 = int . Parse ( row [ "DK019" ] . ToString ( ) );
                }
                if ( row [ "DK020" ] != null )
                {
                    model . DK020 = row [ "DK020" ] . ToString ( );
                }
                if ( row [ "DK021" ] != null )
                {
                    model . DK021 = row [ "DK021" ] . ToString ( );
                }
                if ( row [ "DK022" ] != null )
                {
                    model . DK022 = row [ "DK022" ] . ToString ( );
                }
                if ( row [ "DK023" ] != null )
                {
                    model . DK023 = row [ "DK023" ] . ToString ( );
                }
                if ( row [ "DK024" ] != null )
                {
                    model . DK024 = row [ "DK024" ] . ToString ( );
                }
                if ( row [ "DK025" ] != null )
                {
                    model . DK025 = row [ "DK025" ] . ToString ( );
                }
                if ( row [ "DK026" ] != null )
                {
                    model . DK026 = row [ "DK026" ] . ToString ( );
                }
                if ( row [ "DK027" ] != null )
                {
                    model . DK027 = row [ "DK027" ] . ToString ( );
                }
                if ( row [ "DK028" ] != null )
                {
                    model . DK028 = row [ "DK028" ] . ToString ( );
                }
                if ( row [ "DK029" ] != null )
                {
                    model . DK029 = row [ "DK029" ] . ToString ( );
                }
                if ( row [ "DK030" ] != null )
                {
                    model . DK030 = row [ "DK030" ] . ToString ( );
                }
                if ( row [ "DK031" ] != null )
                {
                    model . DK031 = row [ "DK031" ] . ToString ( );
                }
                if ( row [ "DK032" ] != null )
                {
                    model . DK032 = row [ "DK032" ] . ToString ( );
                }
                if ( row [ "DK033" ] != null )
                {
                    model . DK033 = row [ "DK033" ] . ToString ( );
                }
                if ( row [ "DK034" ] != null )
                {
                    model . DK034 = row [ "DK034" ] . ToString ( );
                }
                if ( row [ "DK035" ] != null )
                {
                    model . DK035 = row [ "DK035" ] . ToString ( );
                }
                if ( row [ "DK036" ] != null )
                {
                    model . DK036 = row [ "DK036" ] . ToString ( );
                }
                if ( row [ "DK037" ] != null )
                {
                    model . DK037 = row [ "DK037" ] . ToString ( );
                }
                if ( row [ "DK038" ] != null )
                {
                    model . DK038 = row [ "DK038" ] . ToString ( );
                }
                if ( row [ "DK039" ] != null )
                {
                    model . DK039 = row [ "DK039" ] . ToString ( );
                }
            }

            return model;
        }

        /// <summary>
        /// get max oddNum from r_pqdJ
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(DK001) DK001 FROM R_PQDK " );
            strSql . AppendFormat ( "WHERE DK001 LIKE 'R_293-{0}%'" ,Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string oddNum = dt . Rows [ 0 ] [ "DK001" ] . ToString ( );
                if ( string . IsNullOrEmpty ( oddNum ) )
                    return "R_293-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
                else
                {
                    oddNum = "R_293-" + ( Convert . ToInt64 ( oddNum . Substring ( 6 ,12 ) ) + 1 ) . ToString ( );
                    return oddNum;
                }
            }
            else
                return "R_293-" + Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "0001";
        }

        /// <summary>
        /// delete data from r_pqdk
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQDK WHERE DK001='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_REVIEWS WHERE RES06='{0}'" ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) ,oddNum ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除" ) );

            return SqlHelper . ExecuteSqlTran ( SQLString );
          
        }

        /// <summary>
        /// add data to r_pqdk
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . QualityReportDKEntity model ,string logins ,string state)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( state . Equals ( "edit" ) )
            {
                edit_dk ( SQLString ,strSql ,model );
                SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) ,model . DK001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑表头" ) ,null );
            }
            else
            {
                model . DK001 = getOddNum ( );
                add_dk ( SQLString ,strSql ,model );
                SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) ,model . DK001 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增表头" ) ,null );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_dk ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityReportDKEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQDK(" );
            strSql . Append ( "DK001,DK002,DK003,DK004,DK005,DK006,DK007,DK008,DK009,DK010,DK011,DK012,DK013,DK014,DK015,DK016,DK017,DK018,DK019,DK020,DK021,DK022,DK023,DK024,DK025,DK026,DK027,DK028,DK029,DK030,DK031,DK032,DK033,DK034,DK035,DK036,DK037,DK038,DK039)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@DK001,@DK002,@DK003,@DK004,@DK005,@DK006,@DK007,@DK008,@DK009,@DK010,@DK011,@DK012,@DK013,@DK014,@DK015,@DK016,@DK017,@DK018,@DK019,@DK020,@DK021,@DK022,@DK023,@DK024,@DK025,@DK026,@DK027,@DK028,@DK029,@DK030,@DK031,@DK032,@DK033,@DK034,@DK035,@DK036,@DK037,@DK038,@DK039)" );

            SqlParameter [ ] parameters = {
                    new SqlParameter("@DK001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DK004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK009", SqlDbType.Date,3),
                    new SqlParameter("@DK010", SqlDbType.Int,4),
                    new SqlParameter("@DK011", SqlDbType.Int,4),
                    new SqlParameter("@DK012", SqlDbType.Date,3),
                    new SqlParameter("@DK013", SqlDbType.Date,3),
                    new SqlParameter("@DK014", SqlDbType.Date,3),
                    new SqlParameter("@DK015", SqlDbType.Date,3),
                    new SqlParameter("@DK016", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK017", SqlDbType.Date,3),
                    new SqlParameter("@DK018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK019", SqlDbType.Int,4),
                    new SqlParameter("@DK020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK021", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK022", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK023", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK024", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK025", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK026", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK027", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK028", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK029", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK030", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK031", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK032", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK033", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK034", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK035", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK036", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK037", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK038", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK039", SqlDbType.NVarChar,100)
            };
            parameters [ 0 ] . Value = model . DK001;
            parameters [ 1 ] . Value = model . DK002;
            parameters [ 2 ] . Value = model . DK003;
            parameters [ 3 ] . Value = model . DK004;
            parameters [ 4 ] . Value = model . DK005;
            parameters [ 5 ] . Value = model . DK006;
            parameters [ 6 ] . Value = model . DK007;
            parameters [ 7 ] . Value = model . DK008;
            parameters [ 8 ] . Value = model . DK009;
            parameters [ 9 ] . Value = model . DK010;
            parameters [ 10 ] . Value = model . DK011;
            parameters [ 11 ] . Value = model . DK012;
            parameters [ 12 ] . Value = model . DK013;
            parameters [ 13 ] . Value = model . DK014;
            parameters [ 14 ] . Value = model . DK015;
            parameters [ 15 ] . Value = model . DK016;
            parameters [ 16 ] . Value = model . DK017;
            parameters [ 17 ] . Value = model . DK018;
            parameters [ 18 ] . Value = model . DK019;
            parameters [ 19 ] . Value = model . DK020;
            parameters [ 20 ] . Value = model . DK021;
            parameters [ 21 ] . Value = model . DK022;
            parameters [ 22 ] . Value = model . DK023;
            parameters [ 23 ] . Value = model . DK024;
            parameters [ 24 ] . Value = model . DK025;
            parameters [ 25 ] . Value = model . DK026;
            parameters [ 26 ] . Value = model . DK027;
            parameters [ 27 ] . Value = model . DK028;
            parameters [ 28 ] . Value = model . DK029;
            parameters [ 29 ] . Value = model . DK030;
            parameters [ 30 ] . Value = model . DK031;
            parameters [ 31 ] . Value = model . DK032;
            parameters [ 32 ] . Value = model . DK033;
            parameters [ 33 ] . Value = model . DK034;
            parameters [ 34 ] . Value = model . DK035;
            parameters [ 35 ] . Value = model . DK036;
            parameters [ 36 ] . Value = model . DK037;
            parameters [ 37 ] . Value = model . DK038;
            parameters [ 38 ] . Value = model . DK039;

            SQLString . Add ( strSql ,parameters );
        }

        void edit_dk ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . QualityReportDKEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQDK set " );
            
            strSql . Append ( "DK002=@DK002," );
            strSql . Append ( "DK003=@DK003," );
            strSql . Append ( "DK004=@DK004," );
            strSql . Append ( "DK005=@DK005," );
            strSql . Append ( "DK006=@DK006," );
            strSql . Append ( "DK007=@DK007," );
            strSql . Append ( "DK008=@DK008," );
            strSql . Append ( "DK009=@DK009," );
            strSql . Append ( "DK010=@DK010," );
            strSql . Append ( "DK011=@DK011," );
            strSql . Append ( "DK012=@DK012," );
            strSql . Append ( "DK013=@DK013," );
            strSql . Append ( "DK014=@DK014," );
            strSql . Append ( "DK015=@DK015," );
            strSql . Append ( "DK016=@DK016," );
            strSql . Append ( "DK017=@DK017," );
            strSql . Append ( "DK018=@DK018," );
            strSql . Append ( "DK019=@DK019," );
            strSql . Append ( "DK020=@DK020," );
            strSql . Append ( "DK021=@DK021," );
            strSql . Append ( "DK022=@DK022," );
            strSql . Append ( "DK023=@DK023," );
            strSql . Append ( "DK024=@DK024," );
            strSql . Append ( "DK025=@DK025," );
            strSql . Append ( "DK026=@DK026," );
            strSql . Append ( "DK027=@DK027," );
            strSql . Append ( "DK028=@DK028," );
            strSql . Append ( "DK029=@DK029," );
            strSql . Append ( "DK030=@DK030," );
            strSql . Append ( "DK031=@DK031," );
            strSql . Append ( "DK032=@DK032," );
            strSql . Append ( "DK033=@DK033," );
            strSql . Append ( "DK034=@DK034," );
            strSql . Append ( "DK035=@DK035," );
            strSql . Append ( "DK036=@DK036," );
            strSql . Append ( "DK037=@DK037," );
            strSql . Append ( "DK038=@DK038," );
            strSql . Append ( "DK039=@DK039 " );
            strSql . Append ( " where DK001=@DK001 " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@DK001", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK002", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK003", SqlDbType.NVarChar,50),
                    new SqlParameter("@DK004", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK005", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK006", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK007", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK008", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK009", SqlDbType.Date,3),
                    new SqlParameter("@DK010", SqlDbType.Int,4),
                    new SqlParameter("@DK011", SqlDbType.Int,4),
                    new SqlParameter("@DK012", SqlDbType.Date,3),
                    new SqlParameter("@DK013", SqlDbType.Date,3),
                    new SqlParameter("@DK014", SqlDbType.Date,3),
                    new SqlParameter("@DK015", SqlDbType.Date,3),
                    new SqlParameter("@DK016", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK017", SqlDbType.Date,3),
                    new SqlParameter("@DK018", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK019", SqlDbType.Int,4),
                    new SqlParameter("@DK020", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK021", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK022", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK023", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK024", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK025", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK026", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK027", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK028", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK029", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK030", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK031", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK032", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK033", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK034", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK035", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK036", SqlDbType.NVarChar,20),
                    new SqlParameter("@DK037", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK038", SqlDbType.NVarChar,100),
                    new SqlParameter("@DK039", SqlDbType.NVarChar,100)
            };
            parameters [ 0 ] . Value = model . DK001;
            parameters [ 1 ] . Value = model . DK002;
            parameters [ 2 ] . Value = model . DK003;
            parameters [ 3 ] . Value = model . DK004;
            parameters [ 4 ] . Value = model . DK005;
            parameters [ 5 ] . Value = model . DK006;
            parameters [ 6 ] . Value = model . DK007;
            parameters [ 7 ] . Value = model . DK008;
            parameters [ 8 ] . Value = model . DK009;
            parameters [ 9 ] . Value = model . DK010;
            parameters [ 10 ] . Value = model . DK011;
            parameters [ 11 ] . Value = model . DK012;
            parameters [ 12 ] . Value = model . DK013;
            parameters [ 13 ] . Value = model . DK014;
            parameters [ 14 ] . Value = model . DK015;
            parameters [ 15 ] . Value = model . DK016;
            parameters [ 16 ] . Value = model . DK017;
            parameters [ 17 ] . Value = model . DK018;
            parameters [ 18 ] . Value = model . DK019;
            parameters [ 19 ] . Value = model . DK020;
            parameters [ 20 ] . Value = model . DK021;
            parameters [ 21 ] . Value = model . DK022;
            parameters [ 22 ] . Value = model . DK023;
            parameters [ 23 ] . Value = model . DK024;
            parameters [ 24 ] . Value = model . DK025;
            parameters [ 25 ] . Value = model . DK026;
            parameters [ 26 ] . Value = model . DK027;
            parameters [ 27 ] . Value = model . DK028;
            parameters [ 28 ] . Value = model . DK029;
            parameters [ 29 ] . Value = model . DK030;
            parameters [ 30 ] . Value = model . DK031;
            parameters [ 31 ] . Value = model . DK032;
            parameters [ 32 ] . Value = model . DK033;
            parameters [ 33 ] . Value = model . DK034;
            parameters [ 34 ] . Value = model . DK035;
            parameters [ 35 ] . Value = model . DK036;
            parameters [ 36 ] . Value = model . DK037;
            parameters [ 37 ] . Value = model . DK038;
            parameters [ 38 ] . Value = model . DK039;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// get business table from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonBD ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='业务部')" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get user from this table
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonBDUser ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT DK023,DK024,DK025,DK029,DK030,DK031,DK016,DK018,DK033,DK034,DK036 FROM R_PQDK" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get production department from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTabbleOfPersonPD ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002 FROM TPADBA WHERE DBA005 LIKE '%'+(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')+'%'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get production workshop from tpadba
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPersonPW ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL))" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get table for print
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT idx,DK001,DK002,DK003,DK004,DK005,DK006,DK007,DK008,DK009,DK010,DK011,DK012,DK013,DK014,DK015,DK016,DK017,DK018,DK019,DK020,DK021,DK022,DK023,DK024,DK025,DK026,DK027,DK028,DK029,DK030,DK031,DK032,DK033,DK034,DK035,DK036,DK037,DK038,DK039 FROM R_PQDK WHERE DK001='{0}'" ,oddNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string oddNum ,string num )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT count(1) FROM R_PQDK WHERE DK002='{0}' AND DK001!='{1}'" ,num ,oddNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public string copy ( string oddNum ,string logins )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "INSERT INTO R_PQDK (DK002,DK003,DK004,DK005,DK006,DK007,DK008,DK009,DK010,DK011,DK012,DK013,DK014,DK015,DK016,DK017,DK018,DK019,DK020,DK021,DK022,DK023,DK024,DK025,DK026,DK027,DK028,DK029,DK030,DK031,DK032,DK033,DK034,DK035,DK036,DK037,DK038,DK039) SELECT DK002,DK003,DK004,DK005,DK006,DK007,DK008,DK009,DK010,DK011,DK012,DK013,DK014,DK015,DK016,DK017,DK018,DK019,DK020,DK021,DK022,DK023,DK024,DK025,DK026,DK027,DK028,DK029,DK030,DK031,DK032,DK033,DK034,DK035,DK036,DK037,DK038,DK039 FROM R_PQDK WHERE DK001='{0}' " ,oddNum );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) ,oddNum  ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"复制" ,"复制" ) );
            strSql = new StringBuilder ( );
            string odN = getOddNum ( );
            strSql . AppendFormat ( "UPDATE R_PQDK SET DK001='{0}' WHERE DK001 IS NULL" ,odN );
            SQLString . Add ( strSql . ToString ( ) );
            SQLString . Add ( Drity . DrityOfComparation ( "R_293" ,"客检产品质量报告(R_293)" ,logins ,Drity . GetDt ( ) , odN ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"复制" ,"复制" ) );

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
                return odN;
            else
                return string . Empty;
        }

    }
}
