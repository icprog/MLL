using System;
using System . Text;
using StudentMgr;
using System . Data;
using System . Collections;
using System . Data . SqlClient;

namespace MulaolaoBll . Dao
{
    public class PerformanceAppraisalDao
    {
        /// <summary>
        /// delete data from database 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQPE WHERE PE001='{0}'" ,year );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// generate the data add to database
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Generate ( int year )
        {
            Hashtable SQLString = new Hashtable ( );
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT XZ004,CONVERT(DECIMAL(18,0),CASE WHEN XZ032=1 THEN SUM(XZ007) ELSE SUM(XZ006+XZ007) END) XZ007,CONVERT(DECIMAL(18,0),SUM(XZ006+XZ007)) XZ2,CONVERT(DECIMAL(18,0),SUM(XZ005)/COUNT(XZ005)) XZ,SUM(CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(XZ013),dateadd(m,1,XZ013)))*(XZ006+XZ007))+XZ029+XZ023+XZ021) XZ1 FROM R_PQXZ " );
            strSql . AppendFormat ( "WHERE YEAR(XZ013)={0} AND XZ003 NOT IN ('行政后勤','杂工') " ,year );
            strSql . Append ( "GROUP BY XZ004,XZ032" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                MulaolaoLibrary . PerformanceAppraisalEntity _model = new MulaolaoLibrary . PerformanceAppraisalEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . PE001 = year . ToString ( );
                    _model . PE002 = dt . Rows [ i ] [ "XZ004" ] . ToString ( );
                    _model . PE005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "XZ007" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "XZ007" ] . ToString ( ) );
                    _model . PE006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "XZ2" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "XZ2" ] . ToString ( ) );
                    _model . PE007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "XZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "XZ" ] . ToString ( ) );
                    _model . PE016 = _model . PE018 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "XZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "XZ1" ] . ToString ( ) );
                    _model . PE008 = getPreviousDaySaliary ( Convert . ToInt32 ( _model . PE001 ) - 1 ,_model . PE002 );
                    _model . PE009 = getPreviousMonthSaliary ( Convert . ToInt32 ( _model . PE001 ) - 1 ,_model . PE002 );
                    if ( !Exists ( _model . PE001 ,_model . PE002 ) )
                        gener_pqpe ( SQLString ,strSql ,_model );
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( string year,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQPE " );
            strSql . AppendFormat ( "WHERE PE001='{0}' AND PE002='{1}'" ,year ,userName );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void gener_pqpe ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . PerformanceAppraisalEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQPE (" );
            strSql . Append ( "PE001,PE002,PE005,PE006,PE007,PE008,PE009,PE016,PE018) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PE001,@PE002,@PE005,@PE006,@PE007,@PE008,@PE009,@PE016,@PE018) " );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PE001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PE002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PE005", SqlDbType.Int,4),
                    new SqlParameter("@PE006", SqlDbType.Int,4),
                    new SqlParameter("@PE007", SqlDbType.Decimal,9),
                    new SqlParameter("@PE008", SqlDbType.Decimal,9),
                    new SqlParameter("@PE009", SqlDbType.Decimal,9),
                    new SqlParameter("@PE016", SqlDbType.Decimal,9),
                    new SqlParameter("@PE018", SqlDbType.Decimal,9)
            };
            parameters [ 0 ] . Value = model . PE001;
            parameters [ 1 ] . Value = model . PE002;
            parameters [ 2 ] . Value = model . PE005;
            parameters [ 3 ] . Value = model . PE006;
            parameters [ 4 ] . Value = model . PE007;
            parameters [ 5 ] . Value = model . PE008;
            parameters [ 6 ] . Value = model . PE009;
            parameters [ 7 ] . Value = model . PE016;
            parameters [ 8 ] . Value = model . PE018;

            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// get the data from database to view 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT idx,CASE WHEN PE026 IS NULL OR PE026='' THEN YEAR(GETDATE())*12+MONTH(GETDATE())-YEAR(PE003)*12-MONTH(PE003) ELSE YEAR(PE026)*12+MONTH(PE026)-YEAR(PE003)*12-MONTH(PE003) END PE FROM R_PQPE WHERE PE001='{0}')" ,year );
            strSql . Append ( "SELECT A.idx,PE001,PE002,PE003,CONVERT(VARCHAR,PE/12)+'年'+CONVERT(VARCHAR,PE%12)+'月'  PE004,PE005,PE006,PE007,PE008,PE009,PE010,PE011,PE012,PE013,PE014,PE015,PE016,PE017,PE018,PE019,PE020,PE021,PE022,PE023,PE024,PE025,PE026 FROM R_PQPE  A INNER JOIN CET B ON A.idx=B.idx " );
            strSql . AppendFormat ( "WHERE PE001='{0}' ORDER BY PE002" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . PerformanceAppraisalEntity _model = new MulaolaoLibrary . PerformanceAppraisalEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model . PE001 = table . Rows [ i ] [ "PE001" ] . ToString ( );
                _model . PE002 = table . Rows [ i ] [ "PE002" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PE003" ] . ToString ( ) ) )
                    _model . PE003 = null;
                else
                    _model . PE003 = Convert . ToDateTime ( table . Rows [ i ] [ "PE003" ] . ToString ( ) );
                _model . PE008 = getPreviousDaySaliary ( Convert . ToInt32 ( _model . PE001 ) - 1 ,_model . PE002 );
                _model . PE009 = getPreviousMonthSaliary ( Convert . ToInt32 ( _model . PE001 ) - 1 ,_model . PE002 );
                _model . PE010 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE010" ] . ToString ( ) );
                _model . PE011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE011" ] . ToString ( ) );
                _model . PE012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE012" ] . ToString ( ) );
                _model . PE013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE013" ] . ToString ( ) );
                _model . PE014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE014" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PE014" ] . ToString ( ) );
                _model . PE015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE015" ] . ToString ( ) );
                //_model . PE016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE016" ] . ToString ( ) );
                _model . PE017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE017" ] . ToString ( ) );
                _model . PE018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE018" ] . ToString ( ) );
                _model . PE019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PE019" ] . ToString ( ) );
                _model . PE020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE020" ] . ToString ( ) );
                _model . PE021 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "PE021" ] . ToString ( ) );
                _model . PE022 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE022" ] . ToString ( ) );
                _model . PE023 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE023" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE023" ] . ToString ( ) );
                _model . PE024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE024" ] . ToString ( ) );
                _model . PE025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PE025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PE025" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PE026" ] . ToString ( ) ) )
                    _model . PE026 = null;
                else
                    _model . PE026 = Convert . ToDateTime ( table . Rows [ i ] [ "PE026" ] . ToString ( ) );

                if ( Exists ( _model . idx ) )
                    edit_pqpe ( SQLString ,strSql ,_model );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        decimal getPreviousDaySaliary ( int year,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PE008 FROM R_PQPE " );
            strSql . AppendFormat ( "WHERE PE001='{0}' AND PE002='{1}'" ,year ,userName );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PE008" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "PE008" ] . ToString ( ) );
            }
            else
                return 0;
        }

        decimal getPreviousMonthSaliary ( int year ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PE009 FROM R_PQPE " );
            strSql . AppendFormat ( "WHERE PE001='{0}' AND PE002='{1}'" ,year ,userName );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PE009" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "PE009" ] . ToString ( ) );
            }
            else
                return 0;
        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQPE " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit_pqpe (Hashtable SQLString,StringBuilder strSql,MulaolaoLibrary.PerformanceAppraisalEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQPE set " );
            strSql . Append ( "PE003=@PE003," );
            strSql . Append ( "PE008=@PE008," );
            strSql . Append ( "PE009=@PE009," );
            strSql . Append ( "PE010=@PE010," );
            strSql . Append ( "PE011=@PE011," );
            strSql . Append ( "PE012=@PE012," );
            strSql . Append ( "PE013=@PE013," );
            strSql . Append ( "PE014=@PE014," );
            strSql . Append ( "PE015=@PE015," );
            //strSql . Append ( "PE016=@PE016," );
            strSql . Append ( "PE017=@PE017," );
            strSql . Append ( "PE018=@PE018," );
            strSql . Append ( "PE019=@PE019," );
            strSql . Append ( "PE020=@PE020," );
            strSql . Append ( "PE021=@PE021," );
            strSql . Append ( "PE022=@PE022," );
            strSql . Append ( "PE023=@PE023," );
            strSql . Append ( "PE024=@PE024," );
            strSql . Append ( "PE025=@PE025," );
            strSql . Append ( "PE026=@PE026 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PE003", SqlDbType.Date,3),
                    new SqlParameter("@PE008", SqlDbType.Decimal,9),
                    new SqlParameter("@PE009", SqlDbType.Decimal,9),
                    new SqlParameter("@PE010", SqlDbType.Decimal,9),
                    new SqlParameter("@PE011", SqlDbType.Decimal,12),
                    new SqlParameter("@PE012", SqlDbType.Decimal,9),
                    new SqlParameter("@PE013", SqlDbType.Decimal,12),
                    new SqlParameter("@PE014", SqlDbType.Int,4),
                    new SqlParameter("@PE015", SqlDbType.Decimal,9),
                    //new SqlParameter("@PE016", SqlDbType.Decimal,9),
                    new SqlParameter("@PE017", SqlDbType.Decimal,12),
                    new SqlParameter("@PE018", SqlDbType.Decimal,9),
                    new SqlParameter("@PE019", SqlDbType.Int,4),
                    new SqlParameter("@PE020", SqlDbType.Decimal,9),
                    new SqlParameter("@PE021", SqlDbType.Int,4),
                    new SqlParameter("@PE022", SqlDbType.Decimal,9),
                    new SqlParameter("@PE023", SqlDbType.Decimal,9),
                    new SqlParameter("@PE024", SqlDbType.Decimal,9),
                    new SqlParameter("@PE025", SqlDbType.Decimal,9),
                    new SqlParameter("@PE026", SqlDbType.Date,3),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PE003;
            parameters [ 1 ] . Value = model . PE008;
            parameters [ 2 ] . Value = model . PE009;
            parameters [ 3 ] . Value = model . PE010;
            parameters [ 4 ] . Value = model . PE011;
            parameters [ 5 ] . Value = model . PE012;
            parameters [ 6 ] . Value = model . PE013;
            parameters [ 7 ] . Value = model . PE014;
            parameters [ 8 ] . Value = model . PE015;
            //parameters [ 9 ] . Value = model . PE016;
            parameters [ 9 ] . Value = model . PE017;
            parameters [ 10 ] . Value = model . PE018;
            parameters [ 11 ] . Value = model . PE019;
            parameters [ 12 ] . Value = model . PE020;
            parameters [ 13 ] . Value = model . PE021;
            parameters [ 14 ] . Value = model . PE022;
            parameters [ 15 ] . Value = model . PE023;
            parameters [ 16 ] . Value = model . PE024;
            parameters [ 17 ] . Value = model . PE025;
            parameters [ 18 ] . Value = model . PE026;
            parameters [ 19 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

    }
}
