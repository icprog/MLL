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
    public class AnnualPayrollSummaryDao
    {
        /// <summary>
        /// get data from database 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable getTableRead ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS(" );
            strSql . AppendFormat ( "SELECT XZ003,XZ004,COUNT(MONTH(XZ013)) XZ1 FROM R_PQXZ WHERE YEAR(XZ013)={0} GROUP BY XZ003,XZ004" ,year );
            strSql . Append ( ")," );
            strSql . Append ( "CFT AS(" );
            strSql . AppendFormat ( "SELECT DISTINCT XZ003 PS002,XZ004 PS003,YEAR(XZ013) PS001,SUM(XZ006) PS005,SUM(CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(XZ013),dateadd(m,1,XZ013)))*XZ006)) PS006,SUM(XZ007) PS007,SUM(CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(XZ013),dateadd(m,1,XZ013)))*XZ007)) PS008,SUM(XZ021) PS009,SUM(XZ029) PS010,SUM(XZ023) PS011,SUM(CONVERT(DECIMAL(18,5),XZ005/day(dateadd(d,-day(XZ013),dateadd(m,1,XZ013)))*(XZ006+XZ007)+XZ023+XZ021+XZ029-XZ010-XZ008-XZ011-XZ009-XZ024-XZ030-XZ031)) PS013,XZ032 PS028 FROM R_PQXZ WHERE YEAR(XZ013)={0}" ,year );
            strSql . Append ( "GROUP BY XZ003,XZ004,YEAR(XZ013),XZ032 ) SELECT B.*,A.XZ1 PS004 FROM CET A INNER JOIN CFT B ON A.XZ003=B.PS002 AND A.XZ004=B.PS003" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// read data from database
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Read ( int year )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            DataTable dt = getTableRead ( year );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                MulaolaoLibrary . AnnualPayrollSummaryEntity _model = new MulaolaoLibrary . AnnualPayrollSummaryEntity ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    _model . PS001 = dt . Rows [ i ] [ "PS001" ] . ToString ( );
                    _model . PS002 = dt . Rows [ i ] [ "PS002" ] . ToString ( );
                    _model . PS003 = dt . Rows [ i ] [ "PS003" ] . ToString ( );
                    _model . PS004 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS004" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "PS004" ] . ToString ( ) );
                    _model . PS005 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS005" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS005" ] . ToString ( ) );
                    _model . PS006 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS006" ] . ToString ( ) );
                    _model . PS007 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS007" ] . ToString ( ) );
                    _model . PS008 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS008" ] . ToString ( ) );
                    _model . PS009 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS009" ] . ToString ( ) );
                    _model . PS010 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS010" ] . ToString ( ) );
                    _model . PS011 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS011" ] . ToString ( ) );
                    _model . PS013 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ i ] [ "PS013" ] . ToString ( ) );
                    _model . PS028 = string . IsNullOrEmpty ( dt . Rows [ i ] [ "PS028" ] . ToString ( ) ) == true ? false : Convert . ToBoolean ( dt . Rows [ i ] [ "PS028" ] . ToString ( ) );
                    _model . PS012 = getYearSaliary ( year ,_model . PS003 );
                    DataTable da = getPreviousYearSaliary ( _model . PS001 ,_model . PS002 ,_model . PS003 );
                    if ( da != null && da . Rows . Count > 0 )
                    {
                        _model . PS014 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PS014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "PS014" ] . ToString ( ) );
                        _model . PS015 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "PS015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "PS015" ] . ToString ( ) );
                    }
                    else
                        _model . PS014 = _model . PS015 = 0;

                    if ( Exists ( _model . PS001 ,_model . PS002 ,_model . PS003 ) )
                        edit_ps ( SQLString ,strSql ,_model );
                    else
                        add_ps ( SQLString ,strSql ,_model );
                }
            }
            else
                return false;

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        bool Exists ( string year ,string unit ,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQPS " );
            strSql . Append ( "WHERE PS001=@PS001 AND PS002=@PS002 AND PS003=@PS003" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PS001",SqlDbType.NVarChar,50),
                new SqlParameter("@PS002",SqlDbType.NVarChar,50),
                new SqlParameter("@PS003",SqlDbType.NVarChar,50)
            };
            parameter [ 0 ] . Value = year;
            parameter [ 1 ] . Value = unit;
            parameter [ 2 ] . Value = userName;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void edit_ps ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . AnnualPayrollSummaryEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQPS SET " );
            strSql . Append ( "PS004=@PS004," );
            strSql . Append ( "PS005=@PS005," );
            strSql . Append ( "PS006=@PS006," );
            strSql . Append ( "PS007=@PS007," );
            strSql . Append ( "PS008=@PS008," );
            strSql . Append ( "PS009=@PS009," );
            strSql . Append ( "PS010=@PS010," );
            strSql . Append ( "PS011=@PS011," );
            strSql . Append ( "PS012=@PS012," );
            strSql . Append ( "PS013=@PS013," );
            strSql . Append ( "PS014=@PS014," );
            strSql . Append ( "PS015=@PS015," );
            strSql . Append ( "PS028=@PS028 " );
            strSql . Append ( "WHERE PS001=@PS001 AND PS002=@PS002 AND PS003=@PS003" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PS001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS004", SqlDbType.Int,4),
                    new SqlParameter("@PS005", SqlDbType.Decimal,9),
                    new SqlParameter("@PS006", SqlDbType.Decimal,9),
                    new SqlParameter("@PS007", SqlDbType.Decimal,9),
                    new SqlParameter("@PS008", SqlDbType.Decimal,9),
                    new SqlParameter("@PS009", SqlDbType.Decimal,9),
                    new SqlParameter("@PS010", SqlDbType.Decimal,9),
                    new SqlParameter("@PS011", SqlDbType.Decimal,9),
                    new SqlParameter("@PS012", SqlDbType.Decimal,9),
                    new SqlParameter("@PS013", SqlDbType.Decimal,9),
                    new SqlParameter("@PS014", SqlDbType.Decimal,9),
                    new SqlParameter("@PS015", SqlDbType.Decimal,9),
                    new SqlParameter("@PS028", SqlDbType.Bit)
            };
            parameters [ 0 ] . Value = model . PS001;
            parameters [ 1 ] . Value = model . PS002;
            parameters [ 2 ] . Value = model . PS003;
            parameters [ 3 ] . Value = model . PS004;
            parameters [ 4 ] . Value = model . PS005;
            parameters [ 5 ] . Value = model . PS006;
            parameters [ 6 ] . Value = model . PS007;
            parameters [ 7 ] . Value = model . PS008;
            parameters [ 8 ] . Value = model . PS009;
            parameters [ 9 ] . Value = model . PS010;
            parameters [ 10 ] . Value = model . PS011;
            parameters [ 11 ] . Value = model . PS012;
            parameters [ 12 ] . Value = model . PS013;
            parameters [ 13 ] . Value = model . PS014;
            parameters [ 14 ] . Value = model . PS015;
            parameters [ 15 ] . Value = model . PS028;

            SQLString . Add ( strSql ,parameters );
        }

        void add_ps ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . AnnualPayrollSummaryEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQPS(" );
            strSql . Append ( "PS001,PS002,PS003,PS004,PS005,PS006,PS007,PS008,PS009,PS010,PS011,PS012,PS013,PS014,PS015,PS028)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@PS001,@PS002,@PS003,@PS004,@PS005,@PS006,@PS007,@PS008,@PS009,@PS010,@PS011,@PS012,@PS013,@PS014,@PS015,@PS028)" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PS001", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS002", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS003", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS004", SqlDbType.Int,4),
                    new SqlParameter("@PS005", SqlDbType.Decimal,9),
                    new SqlParameter("@PS006", SqlDbType.Decimal,9),
                    new SqlParameter("@PS007", SqlDbType.Decimal,9),
                    new SqlParameter("@PS008", SqlDbType.Decimal,9),
                    new SqlParameter("@PS009", SqlDbType.Decimal,9),
                    new SqlParameter("@PS010", SqlDbType.Decimal,9),
                    new SqlParameter("@PS011", SqlDbType.Decimal,9),
                    new SqlParameter("@PS012", SqlDbType.Decimal,9),
                    new SqlParameter("@PS013", SqlDbType.Decimal,9),
                    new SqlParameter("@PS014", SqlDbType.Decimal,9),
                    new SqlParameter("@PS015", SqlDbType.Decimal,9),
                    new SqlParameter("@PS028", SqlDbType.Bit)
            };
            parameters [ 0 ] . Value = model . PS001;
            parameters [ 1 ] . Value = model . PS002;
            parameters [ 2 ] . Value = model . PS003;
            parameters [ 3 ] . Value = model . PS004;
            parameters [ 4 ] . Value = model . PS005;
            parameters [ 5 ] . Value = model . PS006;
            parameters [ 6 ] . Value = model . PS007;
            parameters [ 7 ] . Value = model . PS008;
            parameters [ 8 ] . Value = model . PS009;
            parameters [ 9 ] . Value = model . PS010;
            parameters [ 10 ] . Value = model . PS011;
            parameters [ 11 ] . Value = model . PS012;
            parameters [ 12 ] . Value = model . PS013;
            parameters [ 13 ] . Value = model . PS014;
            parameters [ 14 ] . Value = model . PS015;
            parameters [ 15 ] . Value = model . PS028;

            SQLString . Add ( strSql ,parameters );
        }

        decimal getYearSaliary (int year,string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PE016+PE010*PE011+PE012*PE013+PE014*PE015+PE010*PE017-PE018 PE FROM R_PQPE " );
            strSql . AppendFormat ( "WHERE PE001='{0}' AND PE002='{1}'" ,year ,userName );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PE" ] . ToString ( ) ) )
                    return 0;
                else
                    return Convert . ToDecimal ( dt . Rows [ 0 ] [ "PE" ] . ToString ( ) );
            }
            else
                return 0;

        }

        DataTable getPreviousYearSaliary (string year,string userName,string unit )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PS014,PS015 FROM R_PQPS " );
            strSql . AppendFormat ( "WHERE PS001='{0}' AND PS002='{1}' AND PS003='{2}'" ,year ,userName ,unit );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// get data from database to view 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTableView (int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,PS001,PS002,PS003,PS004,PS005,PS006,PS007,PS008,PS009,PS010,PS011,PS012,PS013,PS014,PS015,PS016,PS017,PS018,PS019,PS020,PS021,PS022,PS023,PS024,PS025,PS026,PS027,PS028 FROM R_PQPS " );
            strSql . AppendFormat ( "WHERE PS001='{0}' ORDER BY PS002,PS003" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// delete one order
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public bool Delete ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQPS " );
            strSql . AppendFormat ( "WHERE PS001='{0}'" ,year );

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// edit data to database
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( DataTable table )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            MulaolaoLibrary . AnnualPayrollSummaryEntity _model = new MulaolaoLibrary . AnnualPayrollSummaryEntity ( );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _model . idx = string . IsNullOrEmpty ( table . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "idx" ] . ToString ( ) );
                _model . PS016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS016" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS016" ] . ToString ( ) );
                _model . PS017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS017" ] . ToString ( ) );
                _model . PS018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS018" ] . ToString ( ) );
                _model . PS019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS019" ] . ToString ( ) );
                _model . PS020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS020" ] . ToString ( ) );
                _model . PS021 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS021" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS021" ] . ToString ( ) );
                _model . PS022 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS022" ] . ToString ( ) );
                _model . PS023 = table . Rows [ i ] [ "PS023" ] . ToString ( );
                _model . PS024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS024" ] . ToString ( ) );
                _model . PS025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS025" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS025" ] . ToString ( ) );
                _model . PS026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS026" ] . ToString ( ) );
                _model . PS027 = string . IsNullOrEmpty ( table . Rows [ i ] [ "PS027" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "PS027" ] . ToString ( ) );

                if ( Exists ( _model . idx ) )
                    edit ( SQLString ,strSql ,_model );

            }

            return SqlHelper . ExecuteSqlTran ( SQLString );

        }

        bool Exists ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQPS " );
            strSql . AppendFormat ( "WHERE idx={0}" ,idx );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void edit ( Hashtable SQLString ,StringBuilder strSql ,MulaolaoLibrary . AnnualPayrollSummaryEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQPS set " );
            strSql . Append ( "PS016=@PS016," );
            strSql . Append ( "PS017=@PS017," );
            strSql . Append ( "PS018=@PS018," );
            strSql . Append ( "PS019=@PS019," );
            strSql . Append ( "PS020=@PS020," );
            strSql . Append ( "PS021=@PS021," );
            strSql . Append ( "PS022=@PS022," );
            strSql . Append ( "PS023=@PS023," );
            strSql . Append ( "PS024=@PS024," );
            strSql . Append ( "PS025=@PS025," );
            strSql . Append ( "PS026=@PS026," );
            strSql . Append ( "PS027=@PS027 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@PS016", SqlDbType.Decimal,9),
                    new SqlParameter("@PS017", SqlDbType.Decimal,9),
                    new SqlParameter("@PS018", SqlDbType.Decimal,9),
                    new SqlParameter("@PS019", SqlDbType.Decimal,9),
                    new SqlParameter("@PS020", SqlDbType.Decimal,9),
                    new SqlParameter("@PS021", SqlDbType.Decimal,9),
                    new SqlParameter("@PS022", SqlDbType.Decimal,9),
                    new SqlParameter("@PS023", SqlDbType.NVarChar,50),
                    new SqlParameter("@PS024", SqlDbType.Decimal,9),
                    new SqlParameter("@PS025", SqlDbType.Decimal,9),
                    new SqlParameter("@PS026", SqlDbType.Decimal,9),
                    new SqlParameter("@PS027", SqlDbType.Decimal,9),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . PS016;
            parameters [ 1 ] . Value = model . PS017;
            parameters [ 2 ] . Value = model . PS018;
            parameters [ 3 ] . Value = model . PS019;
            parameters [ 4 ] . Value = model . PS020;
            parameters [ 5 ] . Value = model . PS021;
            parameters [ 6 ] . Value = model . PS022;
            parameters [ 7 ] . Value = model . PS023;
            parameters [ 8 ] . Value = model . PS024;
            parameters [ 9 ] . Value = model . PS025;
            parameters [ 10 ] . Value = model . PS026;
            parameters [ 11 ] . Value = model . PS027;
            parameters [ 12 ] . Value = model . idx;

            SQLString . Add ( strSql ,parameters );
        }

    }
}
