using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class TeamLeaderRoutineCheckDao
    {
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DateTime dt)
        {
            ArrayList SQLString = new ArrayList( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQQZ" );
            strSql.AppendFormat( " WHERE QZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );
            strS = new StringBuilder ( );
            strS . Append ( "DELETE FROM R_PQQZC " );
            strS . AppendFormat ( "WHERE QZ002 LIKE '{0}%'" ,dt . ToString ( "yyyy-MM" ) );
            SQLString . Add ( strS );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            //StringBuilder strSql = new StringBuilder( );
            //strSql.Append( "SELECT * FROM R_PQQZ WHERE 1=2" );

            //return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
            using ( SqlConnection conn = new SqlConnection ( SqlHelper . connstr ) )
            {
                conn . Open ( );
                SqlCommand cmd = new SqlCommand ( );
                cmd . Connection = conn;
                SqlTransaction tran = conn . BeginTransaction ( );
                cmd . Transaction = tran;
                try
                {
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        StringBuilder strSql = new StringBuilder ( );
                        MulaolaoLibrary . TeamLeaderRoutineCheckLibrary _model = new MulaolaoLibrary . TeamLeaderRoutineCheckLibrary ( );
                        _model . QZ001 = table . Rows [ 0 ] [ "QZ001" ] . ToString ( );
                        _model . QZ002 = string . IsNullOrEmpty ( table . Rows [ 0 ] [ "QZ002" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( table . Rows [ 0 ] [ "QZ002" ] . ToString ( ) );
                        for ( int i = 0 ; i < table . Rows . Count ; i++ )
                        {
                            _model . QZ005 = table . Rows [ i ] [ "QZ005" ] . ToString ( );
                            if ( _model . QZ005 == "本月" )
                            {
                                _model . QZ003 = table . Rows [ i ] [ "QZ003" ] . ToString ( );
                                _model . QZ004 = table . Rows [ i ] [ "QZ004" ] . ToString ( );
                                _model . QZ006 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ006" ] . ToString ( ) );
                                _model . QZ007 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ007" ] . ToString ( ) );
                                _model . QZ008 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ008" ] . ToString ( ) );
                                _model . QZ009 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ009" ] . ToString ( ) );
                                _model . QZ010 = table . Rows [ i ] [ "QZ010" ] . ToString ( );
                                _model . QZ011 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ011" ] . ToString ( ) );
                                _model . QZ012 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ012" ] . ToString ( ) );
                                _model . QZ013 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ013" ] . ToString ( ) );
                                _model . QZ014 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ014" ] . ToString ( ) );
                                _model . QZ015 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ015" ] . ToString ( ) );
                                _model . QZ016 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ016" ] . ToString ( ) );
                                _model . QZ017 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ017" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ017" ] . ToString ( ) );
                                _model . QZ018 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ018" ] . ToString ( ) );
                                _model . QZ019 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ019" ] . ToString ( ) );
                                _model . QZ020 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ020" ] . ToString ( ) );
                                _model . QZ021 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                                _model . QZ022 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ022" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ022" ] . ToString ( ) );
                                _model . QZ023 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ023" ] . ToString ( ) );
                                _model . QZ024 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ024" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ024" ] . ToString ( ) );
                                _model . QZ025 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ025" ] . ToString ( ) );
                                _model . QZ026 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ026" ] . ToString ( ) );
                                _model . QZ027 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ027" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ027" ] . ToString ( ) );
                                _model . QZ028 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ028" ] . ToString ( ) );
                                _model . QZ029 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ029" ] . ToString ( ) );
                                _model . QZ030 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ030" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ030" ] . ToString ( ) );
                                _model . QZ031 = table . Rows [ i ] [ "QZ031" ] . ToString ( );
                                _model . QZ032 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ032" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( table . Rows [ i ] [ "QZ032" ] . ToString ( ) );
                                _model . QZ033 = table . Rows [ i ] [ "QZ033" ] . ToString ( );
                                _model . QZ034 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ034" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( table . Rows [ i ] [ "QZ034" ] . ToString ( ) );
                                _model . QZ035 = table . Rows [ i ] [ "QZ035" ] . ToString ( );
                                _model . QZ036 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ036" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( table . Rows [ i ] [ "QZ036" ] . ToString ( ) );
                                _model . QZ037 = table . Rows [ i ] [ "QZ037" ] . ToString ( );
                                _model . QZ038 = table . Rows [ i ] [ "QZ038" ] . ToString ( );
                                _model . QZ039 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ039" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ039" ] . ToString ( ) );
                                _model . QZ040 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ040" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ040" ] . ToString ( ) );
                                _model . QZ041 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ041" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ041" ] . ToString ( ) );
                                _model . QZ042 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ042" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ042" ] . ToString ( ) );
                                _model . QZ043 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ043" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( table . Rows [ i ] [ "QZ043" ] . ToString ( ) );
                                _model . QZ044 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ044" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ044" ] . ToString ( ) );
                                _model . QZ045 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ045" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ045" ] . ToString ( ) );
                                _model . QZ046 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ046" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ046" ] . ToString ( ) );
                                _model . QZ047 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ047" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ047" ] . ToString ( ) );
                                _model . QZ048 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ048" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ048" ] . ToString ( ) );
                                _model . QZ049 = string . IsNullOrEmpty ( table . Rows [ i ] [ "QZ049" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( table . Rows [ i ] [ "QZ049" ] . ToString ( ) );
                                UpdateOf ( cmd ,_model ,strSql ,tran ,conn );
                            }
                        }
                    }
                    tran . Commit ( );
                    return true;
                }
                catch
                {
                    tran . Rollback ( );
                    return false;
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }

        void UpdateOf ( SqlCommand cmd ,MulaolaoLibrary . TeamLeaderRoutineCheckLibrary _model ,StringBuilder strSql ,SqlTransaction tran ,SqlConnection conn )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQQZ SET " );
            strSql . Append ( "QZ002=@QZ002," );
            strSql . Append ( "QZ003=@QZ003," );
            strSql . Append ( "QZ004=@QZ004," );
            strSql . Append ( "QZ005=@QZ005," );
            strSql . Append ( "QZ006=@QZ006," );
            strSql . Append ( "QZ007=@QZ007," );
            strSql . Append ( "QZ008=@QZ008," );
            strSql . Append ( "QZ009=@QZ009," );
            strSql . Append ( "QZ011=@QZ011," );
            strSql . Append ( "QZ012=@QZ012," );
            strSql . Append ( "QZ013=@QZ013," );
            strSql . Append ( "QZ014=@QZ014," );
            strSql . Append ( "QZ015=@QZ015," );
            strSql . Append ( "QZ016=@QZ016," );
            strSql . Append ( "QZ017=@QZ017," );
            strSql . Append ( "QZ018=@QZ018," );
            strSql . Append ( "QZ019=@QZ019," );
            strSql . Append ( "QZ020=@QZ020," );
            strSql . Append ( "QZ021=@QZ021," );
            strSql . Append ( "QZ022=@QZ022," );
            strSql . Append ( "QZ023=@QZ023," );
            strSql . Append ( "QZ024=@QZ024," );
            strSql . Append ( "QZ025=@QZ025," );
            strSql . Append ( "QZ026=@QZ026," );
            strSql . Append ( "QZ027=@QZ027," );
            strSql . Append ( "QZ028=@QZ028," );
            strSql . Append ( "QZ029=@QZ029," );
            strSql . Append ( "QZ030=@QZ030," );
            strSql . Append ( "QZ031=@QZ031," );
            strSql . Append ( "QZ032=@QZ032," );
            strSql . Append ( "QZ033=@QZ033," );
            strSql . Append ( "QZ034=@QZ034," );
            strSql . Append ( "QZ035=@QZ035," );
            strSql . Append ( "QZ036=@QZ036," );
            strSql . Append ( "QZ037=@QZ037," );
            strSql . Append ( "QZ038=@QZ038," );
            strSql . Append ( "QZ039=@QZ039," );
            strSql . Append ( "QZ040=@QZ040," );
            strSql . Append ( "QZ041=@QZ041," );
            strSql . Append ( "QZ042=@QZ042," );
            strSql . Append ( "QZ043=@QZ043," );
            strSql . Append ( "QZ044=@QZ044," );
            strSql . Append ( "QZ045=@QZ045," );
            strSql . Append ( "QZ046=@QZ046," );
            strSql . Append ( "QZ047=@QZ047," );
            strSql . Append ( "QZ048=@QZ048," );
            strSql . Append ( "QZ049=@QZ049" );
            strSql . Append ( " WHERE QZ001=@QZ001 AND QZ010=@QZ010" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ002",SqlDbType.Date),
                new SqlParameter("@QZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ006",SqlDbType.Decimal,9),
                new SqlParameter("@QZ007",SqlDbType.Decimal,9),
                new SqlParameter("@QZ008",SqlDbType.Decimal,9),
                new SqlParameter("@QZ009",SqlDbType.Decimal,9),
                new SqlParameter("@QZ010",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ011",SqlDbType.Int),
                new SqlParameter("@QZ012",SqlDbType.Decimal,9),
                new SqlParameter("@QZ013",SqlDbType.Int),
                new SqlParameter("@QZ014",SqlDbType.Decimal,9),
                new SqlParameter("@QZ015",SqlDbType.Decimal,9),
                new SqlParameter("@QZ016",SqlDbType.Int),
                new SqlParameter("@QZ017",SqlDbType.Int),
                new SqlParameter("@QZ018",SqlDbType.Decimal,9),
                new SqlParameter("@QZ019",SqlDbType.Int,9),
                new SqlParameter("@QZ020",SqlDbType.Decimal,9),
                new SqlParameter("@QZ021",SqlDbType.Int),
                new SqlParameter("@QZ022",SqlDbType.Int),
                new SqlParameter("@QZ023",SqlDbType.Int),
                new SqlParameter("@QZ024",SqlDbType.Int),
                new SqlParameter("@QZ025",SqlDbType.Int),
                new SqlParameter("@QZ026",SqlDbType.Int),
                new SqlParameter("@QZ027",SqlDbType.Int),
                new SqlParameter("@QZ028",SqlDbType.Int),
                new SqlParameter("@QZ029",SqlDbType.Int),
                new SqlParameter("@QZ030",SqlDbType.Int),
                new SqlParameter("@QZ031",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ032",SqlDbType.Date),
                new SqlParameter("@QZ033",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ034",SqlDbType.Date),
                new SqlParameter("@QZ035",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ036",SqlDbType.Date),
                new SqlParameter("@QZ037",SqlDbType.NVarChar,255),
                new SqlParameter("@QZ038",SqlDbType.NVarChar,255),
                new SqlParameter("@QZ039",SqlDbType.Int),
                new SqlParameter("@QZ040",SqlDbType.Decimal,9),
                new SqlParameter("@QZ041",SqlDbType.Int),
                new SqlParameter("@QZ042",SqlDbType.Decimal,9),
                new SqlParameter("@QZ043",SqlDbType.Decimal,9),
                new SqlParameter("@QZ044",SqlDbType.Int),
                new SqlParameter("@QZ045",SqlDbType.Int),
                new SqlParameter("@QZ046",SqlDbType.Int),
                new SqlParameter("@QZ047",SqlDbType.Int),
                new SqlParameter("@QZ048",SqlDbType.Int),
                new SqlParameter("@QZ049",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . QZ001;
            parameter [ 1 ] . Value = _model . QZ002;
            parameter [ 2 ] . Value = _model . QZ003;
            parameter [ 3 ] . Value = _model . QZ004;
            parameter [ 4 ] . Value = _model . QZ005;
            parameter [ 5 ] . Value = _model . QZ006;
            parameter [ 6 ] . Value = _model . QZ007;
            parameter [ 7 ] . Value = _model . QZ008;
            parameter [ 8 ] . Value = _model . QZ009;
            parameter [ 9 ] . Value = _model . QZ010;
            parameter [ 10 ] . Value = _model . QZ011;
            parameter [ 11 ] . Value = _model . QZ012;
            parameter [ 12 ] . Value = _model . QZ013;
            parameter [ 13 ] . Value = _model . QZ014;
            parameter [ 14 ] . Value = _model . QZ015;
            parameter [ 15 ] . Value = _model . QZ016;
            parameter [ 16 ] . Value = _model . QZ017;
            parameter [ 17 ] . Value = _model . QZ018;
            parameter [ 18 ] . Value = _model . QZ019;
            parameter [ 19 ] . Value = _model . QZ020;
            parameter [ 20 ] . Value = _model . QZ021;
            parameter [ 21 ] . Value = _model . QZ022;
            parameter [ 22 ] . Value = _model . QZ023;
            parameter [ 23 ] . Value = _model . QZ024;
            parameter [ 24 ] . Value = _model . QZ025;
            parameter [ 25 ] . Value = _model . QZ026;
            parameter [ 26 ] . Value = _model . QZ027;
            parameter [ 27 ] . Value = _model . QZ028;
            parameter [ 28 ] . Value = _model . QZ029;
            parameter [ 29 ] . Value = _model . QZ030;
            parameter [ 30 ] . Value = _model . QZ031;
            parameter [ 31 ] . Value = _model . QZ032;
            parameter [ 32 ] . Value = _model . QZ033;
            parameter [ 33 ] . Value = _model . QZ034;
            parameter [ 34 ] . Value = _model . QZ035;
            parameter [ 35 ] . Value = _model . QZ036;
            parameter [ 36 ] . Value = _model . QZ037;
            parameter [ 37 ] . Value = _model . QZ038;
            parameter [ 38 ] . Value = _model . QZ039;
            parameter [ 39 ] . Value = _model . QZ040;
            parameter [ 40 ] . Value = _model . QZ041;
            parameter [ 41 ] . Value = _model . QZ042;
            parameter [ 42 ] . Value = _model . QZ043;
            parameter [ 43 ] . Value = _model . QZ044;
            parameter [ 44 ] . Value = _model . QZ045;
            parameter [ 45 ] . Value = _model . QZ046;
            parameter [ 46 ] . Value = _model . QZ047;
            parameter [ 47 ] . Value = _model . QZ048;
            parameter [ 48 ] . Value = _model . QZ049;

            cmd . Parameters . Clear ( );
            SqlHelper . PrepareCommand ( cmd ,conn ,tran ,strSql . ToString ( ) ,parameter );
            cmd . CommandText = strSql . ToString ( );
            cmd . ExecuteNonQuery ( );
        }

        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="dateSt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate ( string dateSt ,int year ,int month ,MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            bool result = false;
            DataTable da = GetGenerateDataTable( dateSt ,year ,month );
            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT QZ001,QZ003,QZ004,QZ010 FROM R_PQQZ WHERE QZ001='" + _model.QZ001 + "'" );
            string maxNum = "";
            List<int> strList = new List<int>( );
            if ( da != null && da.Rows.Count > 0 )
            {
                DataTable de = GetDataTableOfCount( dateSt );
                if ( de != null && de.Rows.Count > 0 )
                    result = true;
                ArrayList SQLString = new ArrayList( );
                _model . QZ009 = 0.0013M;
                _model . QZ015 = 0.001M;
                _model . QZ040 = 0.001M;
                _model . QZ011 = 51;
                _model . QZ016 = 31;
                _model . QZ041 = 31;
                _model . QZ012 = 0.028M;
                _model . QZ042 = 0.02M;
                _model . QZ043 = 0.02M;
                _model . QZ017 = 140;
                _model . QZ044 = 90;
                _model . QZ045 = 120;
                _model . QZ018 = 0.3M;
                _model . QZ020 = 0.2M;
                _model . QZ022 = -300;
                _model . QZ024 = -300;
                _model . QZ026 = 20;
                _model . QZ028 = 300;
                _model . QZ030 = -300;
                _model . QZ046 = 0;
                _model . QZ048 = 0;
                //_model . QZ047 = -1000;
                //_model . QZ049 = -100;
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    _model.QZ003 = da.Rows[i]["QZ003"].ToString( );
                    _model.QZ004 = da.Rows[i]["QZ004"].ToString( );
                    if ( result == true )
                    {
                        if ( de.Select( "QD078='" + _model.QZ004 + "'" ).Length > 0 )
                            _model.QZ039 = string.IsNullOrEmpty( de.Select( "QD078='" + _model.QZ004 + "'" )[0]["coun"].ToString( ) ) == true ? 0 : Convert.ToInt32( de.Select( "QD078='" + _model.QZ004 + "'" )[0]["coun"].ToString( ) );
                        else
                            _model.QZ039 = 0;
                    }
                    else
                        _model.QZ039 = 0;
                    _model.QZ005 = "本月";
                    _model.QZ006 = string.IsNullOrEmpty( da.Rows[i]["QZ006"].ToString( ) ) == true ? 0M : Math.Round( Convert.ToDecimal( da.Rows[i]["QZ006"].ToString( ) ) ,1 );
                    _model.QZ007 = string.IsNullOrEmpty( da.Rows[i]["QZ007"].ToString( ) ) == true ? 0M : Math.Round( Convert.ToDecimal( da.Rows[i]["QZ007"].ToString( ) ) ,1 );
                    _model.QZ008 = string.IsNullOrEmpty( da.Rows[i]["QZ008"].ToString( ) ) == true ? 0M : Math.Round( Convert.ToDecimal( da.Rows[i]["QZ008"].ToString( ) ) ,1 );
                    _model.QZ014 = string.IsNullOrEmpty( da.Rows[i]["QZ014"].ToString( ) ) == true ? 0M : Math.Round( Convert.ToDecimal( da.Rows[i]["QZ014"].ToString( ) ) ,1 );
                    _model . QZ027 = numOfCount ( _model . QZ004 ,dateSt );
                    if ( /*Exists( _model )*/ dl != null && dl.Rows.Count > 0 )
                    {
                        if ( dl.Select( "QZ003='" + _model.QZ003 + "' AND QZ004='" + _model.QZ004 + "'" ).Length > 0 )
                        {
                            _model.QZ010 = dl.Select( "QZ003='" + _model.QZ003 + "' AND QZ004='" + _model.QZ004 + "'" )[0]["QZ010"].ToString( );
                            SQLString.Add( UpdateGenerate( _model ) );
                        }
                        else
                        {
                            maxNum = dl.Compute( "MAX(QZ010)" ,null ).ToString( );
                            if ( !string.IsNullOrEmpty( maxNum ) )
                            {
                                if ( Convert.ToInt32( maxNum ) < 9 )
                                    _model.QZ010 = "00" + ( Convert.ToInt32( maxNum ) + 1 );
                                else if ( Convert.ToInt32( maxNum ) >= 9 && Convert.ToInt32( maxNum ) < 99 )
                                    _model.QZ010 = "0" + ( Convert.ToInt32( maxNum ) + 1 );
                                else
                                    _model.QZ010 = ( Convert.ToInt32( maxNum ) + 1 ).ToString( );
                            }
                            else
                            {
                                if ( strList.Count > 0 )
                                {
                                    maxNum = strList.Max( ).ToString( );
                                    if ( Convert.ToInt32( maxNum ) < 9 )
                                        _model.QZ010 = "00" + ( Convert.ToInt32( maxNum ) + 1 );
                                    else if ( Convert.ToInt32( maxNum ) >= 9 && Convert.ToInt32( maxNum ) < 99 )
                                        _model.QZ010 = "0" + ( Convert.ToInt32( maxNum ) + 1 );
                                    else
                                        _model.QZ010 = ( Convert.ToInt32( maxNum ) + 1 ).ToString( );
                                }
                                else
                                    _model.QZ010 = "001";
                                strList.Add( Convert.ToInt32( _model.QZ010 ) );
                                
                            }
                            SQLString . Add ( AddGenerate ( _model ) );
                        }
                    }
                    else
                    {
                        if ( strList.Count > 0 )
                        {
                            maxNum = strList.Max( ).ToString( );
                            if ( Convert.ToInt32( maxNum ) < 9 )
                                _model.QZ010 = "00" + ( Convert.ToInt32( maxNum ) + 1 );
                            else if ( Convert.ToInt32( maxNum ) >= 9 && Convert.ToInt32( maxNum ) < 99 )
                                _model.QZ010 = "0" + ( Convert.ToInt32( maxNum ) + 1 );
                            else
                                _model.QZ010 = ( Convert.ToInt32( maxNum ) + 1 ).ToString( );
                        }
                        else
                            _model.QZ010 = "001";
                        strList.Add( Convert.ToInt32( _model.QZ010 ) );
                        SQLString.Add( AddGenerate( _model ) );
                    }
                }
                result = SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 获取出货批数  每个人每个月每个流水号在本月只能算一批  若之前有出货记录  则本月不计
        /// </summary>
        /// <param name="nameOfPeople"></param>
        /// <param name="dateT"></param>
        /// <returns></returns>
        int numOfCount (string nameOfPeople,string dateT )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) COUN FROM (SELECT DISTINCT AE02 FROM R_PQAE WHERE AE37>0 AND SUBSTRING(CONVERT(VARCHAR(12),AE21,112),0,7)='{0}' AND AE08='{1}' AND AE02 NOT IN (SELECT AE02 FROM R_PQAE WHERE AE37>0 AND SUBSTRING(CONVERT(VARCHAR(12),AE21,112),0,7)<'{0}' AND AE08='{1}')) A" ,dateT ,nameOfPeople );

            DataTable de = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( de != null && de . Rows . Count > 0 )
                return string . IsNullOrEmpty ( de . Rows [ 0 ] [ "COUN" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ 0 ] [ "COUN" ] . ToString ( ) );
            else
                return 0;
        }

        /// <summary>
        /// 前后道468一致  一组组长
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOf (string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT QZ004,QZ008,DBA961 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002" );
            strSql . Append ( " WHERE QZ001=@QZ001 AND QZ008>0" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,parameter );
            ArrayList SQLString = new ArrayList ( );
            if ( da != null && da . Rows . Count > 0 )
            {
                MulaolaoLibrary . TeamLeaderRoutineCheckLibrary _model = new MulaolaoLibrary . TeamLeaderRoutineCheckLibrary ( );
                _model . QZ001 = oddNum;

                string stateOf = "";
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _model . QZ008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ008" ] . ToString ( ) );
                    stateOf = da . Rows [ i ] [ "DBA961" ] . ToString ( ) . Trim ( );
                    if ( !string . IsNullOrEmpty ( stateOf ) )
                        SQLString . Add ( UpdateOfPrice ( _model ,stateOf ) );
                }
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        string UpdateOfPrice ( MulaolaoLibrary . TeamLeaderRoutineCheckLibrary _model,string stateOf )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQQZ SET " );
            strSql . AppendFormat ( "QZ008='{0}'" ,_model . QZ008 );
            strSql . AppendFormat ( " WHERE QZ001='{0}' AND QZ004 IN (SELECT DBA002 FROM TPADBA WHERE DBA961='{1}')" ,_model . QZ001 ,stateOf );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取生成数据
        /// </summary>
        /// <param name="dateSt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetGenerateDataTable ( string dateSt ,int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            /*
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT HD079,ISNULL(SUM(U1),0) U1,HD078 FROM (" );
            strSql.Append( "SELECT HD079,ISNULL(HD022,0)*SUM(ISNULL(HD023,0))+ISNULL(HD024,0)*SUM(ISNULL(HD025,0))+ISNULL(HD026,0)*SUM(ISNULL(HD027,0))+ISNULL(HD028,0)*SUM(ISNULL(HD029,0))+ISNULL(HD030,0)*SUM(ISNULL(HD031,0))+ISNULL(HD032,0)*SUM(ISNULL(HD033,0))+ISNULL(HD034,0)*SUM(ISNULL(HD035,0))+ISNULL(HD036,0)*SUM(ISNULL(HD037,0))+ISNULL(HD038,0)*SUM(ISNULL(HD039,0))+ISNULL(HD040,0)*SUM(ISNULL(HD041,0))+ISNULL(HD042,0)*SUM(ISNULL(HD043,0))+ISNULL(HD044,0)*SUM(ISNULL(HD045,0))+ISNULL(HD046,0)*SUM(ISNULL(HD047,0))+ISNULL(HD048,0)*SUM(ISNULL(HD049,0))+ISNULL(HD050,0)*SUM(ISNULL(HD051,0))+ISNULL(HD052,0)*SUM(ISNULL(HD053,0))+ISNULL(HD054,0)*SUM(ISNULL(HD055,0))+ISNULL(HD056,0)*SUM(ISNULL(HD057,0))+ISNULL(HD058,0)*SUM(ISNULL(HD059,0))+ISNULL(HD060,0)*SUM(ISNULL(HD061,0))+ISNULL(HD062,0)*SUM(ISNULL(HD063,0))+ISNULL(HD064,0)*SUM(ISNULL(HD065,0)) U1,HD078 FROM R_PQBZ " );
            strSql.AppendFormat( " WHERE HD079='{0}'",dateSt );
            strSql.Append( " GROUP BY HD079,HD022,HD024,HD026,HD028,HD030,HD032,HD034,HD036,HD038,HD040,HD042,HD044,HD046,HD048,HD050,HD052,HD054,HD056,HD058,HD060,HD062,HD064,HD078) A GROUP BY HD079,HD078 )" );
            strSql.Append( ",CFT AS(" );
            strSql.Append( "SELECT SUM(ISNULL(HD004,0)) QZ006,count(1) QZ007,SUM(ISNULL(HD005,0)) QZ012,SUM(HD004*HD005*HD008) QZ013,U1 QZ014,HD001 QZ004 FROM R_PQAZ A LEFT JOIN CET ON A.HD002=CET.HD079 AND A.HD001=CET.HD078 " );
            strSql.AppendFormat( " WHERE HD002='{0}'",dateSt );
            strSql.Append( " GROUP BY HD001,U1)" );
            strSql.Append( ",CAT AS(" );
            strSql.Append( "SELECT QD079,ISNULL(QD022,0)*SUM(ISNULL(QD023,0))+ISNULL(QD024,0)*SUM(ISNULL(QD025,0))+ISNULL(QD026,0)*SUM(ISNULL(QD027,0))+ISNULL(QD028,0)*SUM(ISNULL(QD029,0))+ISNULL(QD030,0)*SUM(ISNULL(QD031,0))+ISNULL(QD032,0)*SUM(ISNULL(QD033,0))+ISNULL(QD034,0)*SUM(ISNULL(QD035,0))+ISNULL(QD036,0)*SUM(ISNULL(QD037,0))+ISNULL(QD038,0)*SUM(ISNULL(QD039,0))+ISNULL(QD040,0)*SUM(ISNULL(QD041,0))+ISNULL(QD042,0)*SUM(ISNULL(QD043,0))+ISNULL(QD044,0)*SUM(ISNULL(QD045,0))+ISNULL(QD046,0)*SUM(ISNULL(QD047,0))+ISNULL(QD048,0)*SUM(ISNULL(QD049,0))+ISNULL(QD050,0)*SUM(ISNULL(QD051,0))+ISNULL(QD052,0)*SUM(ISNULL(QD053,0))+ISNULL(QD054,0)*SUM(ISNULL(QD055,0))+ISNULL(QD056,0)*SUM(ISNULL(QD057,0))+ISNULL(QD058,0)*SUM(ISNULL(QD059,0))+ISNULL(QD060,0)*SUM(ISNULL(QD061,0))+ISNULL(QD062,0)*SUM(ISNULL(QD063,0))+ISNULL(QD064,0)*SUM(ISNULL(QD065,0))+ISNULL(QD066,0)*SUM(ISNULL(QD067,0))+ISNULL(QD068,0)*SUM(ISNULL(QD069,0))+ISNULL(QD070,0)*SUM(ISNULL(QD071,0))+ISNULL(QD072,0)*SUM(ISNULL(QD073,0)) U2,QD078 FROM R_PQZB" );
            strSql .AppendFormat( " WHERE QD079='{0}'",dateSt );
            strSql.Append( " GROUP BY QD079,QD022,QD024,QD026,QD028,QD030,QD032,QD034,QD036,QD038,QD040,QD042,QD044,QD046,QD048,QD050,QD052,QD054,QD056,QD058,QD060,QD062,QD064,QD066,QD068,QD070,QD072,QD073,QD078,QD004)" );
            strSql.Append( ",CBT AS (" );
            strSql.Append( "SELECT SUM(ISNULL(QD004,0)) QZ006,COUNT(1) QZ007,SUM(ISNULL(QD005,0)) QZ012,SUM(QD004*QD005*QD008) QZ013,U2 QZ014,QD001 QZ004 FROM R_PQZA A  LEFT JOIN CAT ON A.QD002=CAT.QD079 AND A.QD001=CAT.QD078" );
            strSql.AppendFormat( " WHERE QD002='{0}'",dateSt );
            strSql.Append( "  GROUP BY QD001,U2)" );
            strSql.Append( " ,CDT AS(" );
            strSql.Append( " SELECT ISNULL(SZ006,0) SZ006,SUBSTRING(SZ002,4,5) SZ002 FROM R_PQSZ " );
            strSql.AppendFormat( " WHERE SZ003='{0}' AND SZ008='{1}')" ,year ,month );
            //strSql.Append( " GROUP BY AE08)" );
            //strSql.Append( ",CHT AS(" );
            //strSql.Append( "SELECT GZ16 QZ004,SUM(CONVERT(DECIMAL(18,2),GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) QZ010 FROM R_PQW" );
            //strSql.Append( " WHERE GZ35=@YEAR AND GZ24=@MONTH" );
            //strSql.Append( " GROUP BY GZ16)" );
            strSql.Append( ",CGT AS(" );
            strSql.Append( "SELECT DBA002 QZ004,DAA002 QZ003 FROM TPADBA A LEFT JOIN TPADAA B ON A.DBA005=B.DAA001)" );
            strSql.Append( "SELECT QZ003,A.QZ004,QZ006,CONVERT(DECIMAL(18,1),QZ007) QZ007,CONVERT(DECIMAL(18,1),ISNULL(SZ006,0)) QZ008,CONVERT(DECIMAL(18,1),QZ012) QZ012,CONVERT(DECIMAL(18,1),QZ013) QZ013,CONVERT(DECIMAL(18,1),QZ014) QZ014 FROM (SELECT * FROM CFT UNION SELECT * FROM CBT) A LEFT JOIN CDT ON A.QZ004=CDT.SZ002 LEFT JOIN CGT ON A.QZ004=CGT.QZ004" );
            //SqlParameter[] parameter = {
            //    new SqlParameter("@DATEST",SqlDbType.NVarChar),
            //    new SqlParameter("@YEAR",SqlDbType.Int),
            //    new SqlParameter("@MONTH",SqlDbType.Int)
            //};
            //parameter[0].Value = dateSt;
            //parameter[1].Value = year;
            //parameter[2].Value = month;

            */

            strSql . Append ( "WITH CET AS (SELECT HD079,ISNULL(SUM(U1),0) U1,HD078 FROM (SELECT HD079,(ISNULL(HD022,0)*SUM(ISNULL(HD023,0))+ISNULL(HD024,0)*SUM(ISNULL(HD025,0))+ISNULL(HD026,0)*SUM(ISNULL(HD027,0))+ISNULL(HD028,0)*SUM(ISNULL(HD029,0))+ISNULL(HD030,0)*SUM(ISNULL(HD031,0))+ISNULL(HD032,0)*SUM(ISNULL(HD033,0))+ISNULL(HD034,0)*SUM(ISNULL(HD035,0))+ISNULL(HD036,0)*SUM(ISNULL(HD037,0))+ISNULL(HD038,0)*SUM(ISNULL(HD039,0))+ISNULL(HD040,0)*SUM(ISNULL(HD041,0))+ISNULL(HD042,0)*SUM(ISNULL(HD043,0))+ISNULL(HD044,0)*SUM(ISNULL(HD045,0))+ISNULL(HD046,0)*SUM(ISNULL(HD047,0))+ISNULL(HD048,0)*SUM(ISNULL(HD049,0))+ISNULL(HD050,0)*SUM(ISNULL(HD051,0))+ISNULL(HD052,0)*SUM(ISNULL(HD053,0))+ISNULL(HD054,0)*SUM(ISNULL(HD055,0))+ISNULL(HD056,0)*SUM(ISNULL(HD057,0))+ISNULL(HD058,0)*SUM(ISNULL(HD059,0))+ISNULL(HD060,0)*SUM(ISNULL(HD061,0))+ISNULL(HD062,0)*SUM(ISNULL(HD063,0))+ISNULL(HD064,0)*SUM(ISNULL(HD065,0)))*HD004 U1,HD078 FROM R_PQBZ A INNER JOIN R_PQAZ B ON A.HD078=B.HD001 AND A.HD079=B.HD002 AND A.HD080=B.HD003 " );
            strSql . AppendFormat ( "WHERE HD079='{0}' GROUP BY HD079,HD022,HD024,HD026,HD028,HD030,HD032,HD034,HD036,HD038,HD040,HD042,HD044,HD046,HD048,HD050,HD052,HD054,HD056,HD058,HD060,HD062,HD064,HD078,HD004) A GROUP BY HD079,HD078 " ,dateSt );
            strSql . AppendFormat ( "),CFT AS(SELECT SUM(ISNULL(HD004,0)) QZ006,count(1) QZ007,SUM(ISNULL(HD005,0)) QZ012,SUM(HD004*HD005*HD008) QZ013,U1 QZ014,HD001 QZ004 FROM R_PQAZ A LEFT JOIN CET ON A.HD002=CET.HD079 AND A.HD001=CET.HD078  WHERE HD002='{0}' GROUP BY HD001,U1 " ,dateSt );
            strSql . Append ( "), CAT AS(SELECT QD079,SUM(U2) U2,QD078 FROM (SELECT QD079,(ISNULL(QD022,0)*SUM(ISNULL(QD023,0))+ISNULL(QD024,0)*SUM(ISNULL(QD025,0))+ISNULL(QD026,0)*SUM(ISNULL(QD027,0))+ISNULL(QD028,0)*SUM(ISNULL(QD029,0))+ISNULL(QD030,0)*SUM(ISNULL(QD031,0))+ISNULL(QD032,0)*SUM(ISNULL(QD033,0))+ISNULL(QD034,0)*SUM(ISNULL(QD035,0))+ISNULL(QD036,0)*SUM(ISNULL(QD037,0))+ISNULL(QD038,0)*SUM(ISNULL(QD039,0))+ISNULL(QD040,0)*SUM(ISNULL(QD041,0))+ISNULL(QD042,0)*SUM(ISNULL(QD043,0))+ISNULL(QD044,0)*SUM(ISNULL(QD045,0))+ISNULL(QD046,0)*SUM(ISNULL(QD047,0))+ISNULL(QD048,0)*SUM(ISNULL(QD049,0))+ISNULL(QD050,0)*SUM(ISNULL(QD051,0))+ISNULL(QD052,0)*SUM(ISNULL(QD053,0))+ISNULL(QD054,0)*SUM(ISNULL(QD055,0))+ISNULL(QD056,0)*SUM(ISNULL(QD057,0))+ISNULL(QD058,0)*SUM(ISNULL(QD059,0))+ISNULL(QD060,0)*SUM(ISNULL(QD061,0))+ISNULL(QD062,0)*SUM(ISNULL(QD063,0))+ISNULL(QD064,0)*SUM(ISNULL(QD065,0))+ISNULL(QD066,0)*SUM(ISNULL(QD067,0))+ISNULL(QD068,0)*SUM(ISNULL(QD069,0))+ISNULL(QD070,0)*SUM(ISNULL(QD071,0))+ISNULL(QD072,0)*SUM(ISNULL(QD073,0)))*QD004 U2,QD078 FROM R_PQZB A INNER JOIN R_PQZA B ON A.QD077=B.QD074 AND A.QD078=B.QD001 AND A.QD079=B.QD002 AND A.QD094=B.QD003 " );
            strSql . AppendFormat ( "WHERE QD079='{0}' GROUP BY QD079,QD022,QD024,QD026,QD028,QD030,QD032,QD034,QD036,QD038,QD040,QD042,QD044,QD046,QD048,QD050,QD052,QD054,QD056,QD058,QD060,QD062,QD064,QD066,QD068,QD070,QD072,QD073,QD078,QD004) A GROUP BY QD079,QD078 " ,dateSt );
            strSql . AppendFormat ( "),CBT AS (SELECT SUM(ISNULL(QD004,0)) QZ006,COUNT(1) QZ007,SUM(ISNULL(QD005,0)) QZ012,SUM(QD004*QD005*QD008) QZ013,U2 QZ014,QD001 QZ004 FROM R_PQZA A  LEFT JOIN CAT ON A.QD002=CAT.QD079 AND A.QD001=CAT.QD078 WHERE QD002='{0}' GROUP BY QD001,U2 " ,dateSt );
            strSql . AppendFormat ( ") ,CDT AS( SELECT ISNULL(SZ006,0) SZ006,SUBSTRING(SZ002,4,5) SZ002 FROM R_PQSZ  WHERE SZ003='{0}' AND SZ008='{1}'),CGT AS(SELECT DBA002 QZ004,DAA002 QZ003 FROM TPADBA A LEFT JOIN TPADAA B ON A.DBA005=B.DAA001) " ,year ,month );
            strSql . Append ( "SELECT QZ003,A.QZ004,QZ006,CONVERT(DECIMAL(18,1),QZ007) QZ007,CONVERT(DECIMAL(18,1),ISNULL(SZ006,0)) QZ008,CONVERT(DECIMAL(18,1),QZ012) QZ012,CONVERT(DECIMAL(18,1),QZ013) QZ013,CONVERT(DECIMAL(18,1),QZ014) QZ014 FROM (SELECT * FROM CFT UNION SELECT * FROM CBT) A LEFT JOIN CDT ON A.QZ004=CDT.SZ002 LEFT JOIN CGT ON A.QZ004=CGT.QZ004" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) /*,parameter*/ );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateSt"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCount ( string dateSt )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(" );
            strSql.Append( "SELECT DISTINCT QD021,QD078,DATEDIFF(DAY,ISNULL(QD101,GETDATE()),QD100) QD,QD098-QD103 QH FROM R_PQZB" );
            strSql.Append( " WHERE QD079=@QH079" );
            strSql.Append( "), CFT AS (" );
            strSql.Append( "SELECT DISTINCT HD021,HD078,DATEDIFF(DAY,ISNULL(HD088,GETDATE()),HD085) HD,HD083-HD087 HH FROM R_PQBZ" );
            strSql.Append( " WHERE HD079=@QH079" );
            strSql.Append( ") SELECT QD078,COUNT(1) coun FROM (" );
            strSql.Append( "SELECT QD078,CASE WHEN QD>0 THEN CASE WHEN QH<-10 THEN '-1' ELSE '0' END WHEN QD<0 THEN QD END QD FROM CET ) A WHERE QD<0 GROUP BY QD078" );
            strSql.Append( " UNION " );
            strSql.Append( "SELECT HD078,COUNT(1) coun FROM (SELECT HD078,CASE WHEN HD>0 THEN CASE WHEN HH<-10 THEN '-1' ELSE '0' END WHEN HD<0 THEN HD END HD FROM CFT ) A WHERE HD<0 GROUP BY HD078" );
            SqlParameter[] parameter = {
                new SqlParameter("@QH079",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = dateSt;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQQZ" );
            strSql.Append( " WHERE QZ001=@QZ001 AND QZ002=@QZ002 AND QZ003=@QZ003 AND QZ004=@QZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ002",SqlDbType.Date),
                new SqlParameter("@QZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@QZ004",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.QZ001;
            parameter[1].Value = _model.QZ002;
            parameter[2].Value = _model.QZ003;
            parameter[3].Value = _model.QZ004;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public string UpdateGenerate ( MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQZ SET " );
            strSql . AppendFormat ( "QZ005='{0}'," , _model . QZ005 );
            strSql . AppendFormat ( "QZ006='{0}'," , _model . QZ006 );
            strSql . AppendFormat ( "QZ007='{0}'," , _model . QZ007 );
            strSql . AppendFormat ( "QZ008='{0}'," , _model . QZ008 );
            strSql . AppendFormat ( "QZ009='{0}'," , _model . QZ009 );
            strSql . AppendFormat ( "QZ011='{0}'," , _model . QZ011 ); 
            strSql . AppendFormat ( "QZ012='{0}'," , _model . QZ012 );
            strSql . AppendFormat ( "QZ014='{0}'," , _model . QZ014 );
            strSql . AppendFormat ( "QZ015='{0}'," , _model . QZ015 );
            strSql . AppendFormat ( "QZ016='{0}'," , _model . QZ016 );
            strSql . AppendFormat ( "QZ017='{0}'," , _model . QZ017 );
            strSql . AppendFormat ( "QZ018='{0}'," , _model . QZ018 ); 
            strSql . AppendFormat ( "QZ020='{0}'," , _model . QZ020 );
            strSql . AppendFormat ( "QZ022='{0}'," , _model . QZ022 );
            strSql . AppendFormat ( "QZ024='{0}'," , _model . QZ024 );
            strSql . AppendFormat ( "QZ026='{0}'," , _model . QZ026 );
            strSql . AppendFormat ( "QZ027='{0}'," , _model . QZ027 );
            strSql . AppendFormat ( "QZ028='{0}'," , _model . QZ028 );
            strSql . AppendFormat ( "QZ030='{0}'," , _model . QZ030 );
            strSql . AppendFormat ( "QZ039='{0}'," , _model . QZ039 ); 
            strSql . AppendFormat ( "QZ040='{0}'," , _model . QZ040 ); 
            strSql . AppendFormat ( "QZ041='{0}'," , _model . QZ041 ); 
            strSql . AppendFormat ( "QZ042='{0}'," , _model . QZ042 ); 
            strSql . AppendFormat ( "QZ043='{0}'," , _model . QZ043 );
            strSql . AppendFormat ( "QZ044='{0}'," , _model . QZ044 );
            strSql . AppendFormat ( "QZ045='{0}'," , _model . QZ045 );
            strSql . AppendFormat ( "QZ046='{0}'," ,_model . QZ046 );
            strSql . AppendFormat ( "QZ048='{0}'" ,_model . QZ048 );
            strSql . AppendFormat ( " WHERE QZ001='{0}' AND QZ010='{1}'" , _model . QZ001 , _model . QZ010 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public string AddGenerate ( MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQQZ (" );
            strSql.Append( "QZ001,QZ002,QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,QZ009,QZ010,QZ011,QZ012,QZ013,QZ014,QZ015,QZ016,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,QZ039,QZ040,QZ041,QZ042,QZ043,QZ044,QZ045,QZ046,QZ048,QZ027)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}')" ,_model . QZ001 ,_model . QZ002 ,_model . QZ003 ,_model . QZ004 ,_model . QZ005 ,_model . QZ006 ,_model . QZ007 ,_model . QZ008 ,_model . QZ009 ,_model . QZ010 ,_model . QZ011 ,_model . QZ012 ,_model . QZ013 ,_model . QZ014 ,_model . QZ015 ,_model . QZ016 ,_model . QZ017 ,_model . QZ018 ,_model . QZ020 ,_model . QZ022 ,_model . QZ024 ,_model . QZ026 ,_model . QZ028 ,_model . QZ030 ,_model . QZ039 ,_model . QZ040 ,_model . QZ041 ,_model . QZ042 ,_model . QZ043 ,_model . QZ044 ,_model . QZ045 ,_model . QZ046 ,_model . QZ048 ,_model . QZ027 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,CONVERT(FLOAT,QZ009) QZ009,QZ011,QZ014,CONVERT(FLOAT,QZ012) QZ012,QZ013,QZ017,CONVERT(FLOAT,QZ018) QZ018,QZ019,CONVERT(FLOAT,QZ020) QZ020,QZ021,QZ022,QZ023,QZ024,QZ025,QZ026,QZ027,QZ028,QZ029,QZ030,QZ039,DBA960,CONVERT(FLOAT,QZ015) QZ015,CONVERT(FLOAT,QZ040) QZ040,QZ016,QZ041,CONVERT(FLOAT,QZ042) QZ042,CONVERT(FLOAT,QZ043) QZ043,QZ044,QZ045,ISNULL(QZ046,0) QZ046,ISNULL(QZ047,0) QZ047,ISNULL(QZ048,0) QZ048,ISNULL(QZ049,0) QZ049 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002" );
            strSql.Append( " WHERE QZ001=@QZ001" );
            strSql.Append( " UNION" );
            strSql.Append( " SELECT A.QZ003,A.QZ004,'累计' QZ005,SUM(A.QZ006) QZ006,SUM(A.QZ007) QZ007,SUM(A.QZ008) QZ008,CONVERT(FLOAT,C.QZ009) QZ009,C.QZ011,SUM(A.QZ014) QZ014,CONVERT(FLOAT,C.QZ012) QZ012,SUM(A.QZ013) QZ013,C.QZ017,CONVERT(FLOAT,C.QZ018) QZ018,SUM(A.QZ019) QZ019,CONVERT(FLOAT,C.QZ020) QZ020,SUM(A.QZ021) QZ021,C.QZ022,SUM(A.QZ023) QZ023,C.QZ024,SUM(A.QZ025) QZ025,C.QZ026,SUM(A.QZ027) QZ027,C.QZ028,SUM(A.QZ029) QZ029,C.QZ030,SUM(A.QZ039) QZ039,DBA960,CONVERT(FLOAT,C.QZ015) QZ015,CONVERT(FLOAT,C.QZ040) QZ040,C.QZ016,C.QZ041,CONVERT(FLOAT,C.QZ042) QZ042,CONVERT(FLOAT,C.QZ043) QZ043,C.QZ044,C.QZ045,SUM(ISNULL(QZ046,0)) QZ046,ISNULL(C.QZ047,0) QZ047,SUM(ISNULL(QZ048,0)) QZ048,ISNULL(C.QZ049,0) QZ049 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002 LEFT JOIN (SELECT QZ003,QZ004,QZ009,QZ011,QZ012,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045,QZ047,QZ049 FROM R_PQQZ " );
            strSql . Append ( " WHERE QZ001=@QZ001) C ON A.QZ003=C.QZ003 AND A.QZ004=C.QZ004" );
            strSql .Append( " WHERE QZ002<=(SELECT DISTINCT QZ002 FROM R_PQQZ" );
            strSql.Append( " WHERE QZ001=@QZ001)" );
            strSql . Append ( " GROUP BY A.QZ003,A.QZ004,A.QZ005,C.QZ009,C.QZ011,C.QZ012,C.QZ017,C.QZ018,C.QZ020,C.QZ022,C.QZ024,C.QZ026,C.QZ028,C.QZ030,DBA960,C.QZ015,C.QZ040,C.QZ016,C.QZ041,C.QZ042,C.QZ043,C.QZ044,C.QZ045,C.QZ047,C.QZ049)" );
            strSql.Append( " SELECT idx,QZ001,QZ002,QZ010,QZ031,QZ032,QZ033,QZ034,QZ035,QZ036,QZ037,QZ038,B.* FROM R_PQQZ A LEFT JOIN CET B ON A.QZ003=B.QZ003 AND A.QZ004=B.QZ004" );
            strSql.Append( " WHERE A.QZ001=@QZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetModel ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQQZ" );
            strSql.Append( " WHERE QZ001=@QZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model = new MulaolaoLibrary.TeamLeaderRoutineCheckLibrary( );
            if ( row !=null )
            {
                if ( row [ "QZ001" ] != null && row [ "QZ001" ] . ToString ( ) != "" )
                    _model . QZ001 = row [ "QZ001" ] . ToString ( );
                if ( row["QZ002"] != null && row["QZ002"].ToString( ) != "" )
                    _model.QZ002 = DateTime.Parse( row["QZ002"].ToString( ) );
                if ( row["QZ009"] != null && row["QZ009"].ToString( ) != "" )
                    _model.QZ009 = decimal.Parse( row["QZ009"].ToString( ) );
                if ( row["QZ011"] != null && row["QZ011"].ToString( ) != "" )
                    _model.QZ011 = int.Parse( row["QZ011"].ToString( ) );
                if ( row["QZ015"] != null && row["QZ015"].ToString( ) != "" )
                    _model.QZ015 = decimal.Parse( row["QZ015"].ToString( ) );
                if ( row["QZ016"] != null && row["QZ016"].ToString( ) != "" )
                    _model.QZ016 = int.Parse( row["QZ016"].ToString( ) );
                if ( row["QZ017"] != null && row["QZ017"].ToString( ) != "" )
                    _model.QZ017 = int.Parse( row["QZ017"].ToString( ) );
                if ( row["QZ018"] != null && row["QZ018"].ToString( ) != "" )
                    _model.QZ018 = decimal.Parse( row["QZ018"].ToString( ) );
                if ( row["QZ020"] != null && row["QZ020"].ToString( ) != "" )
                    _model.QZ020 = decimal.Parse( row["QZ020"].ToString( ) );
                if ( row["QZ022"] != null && row["QZ022"].ToString( ) != "" )
                    _model.QZ022 = int.Parse( row["QZ022"].ToString( ) );
                if ( row["QZ024"] != null && row["QZ024"].ToString( ) != "" )
                    _model.QZ024 = int.Parse( row["QZ024"].ToString( ) );
                if ( row["QZ026"] != null && row["QZ026"].ToString( ) != "" )
                    _model.QZ026 = int.Parse( row["QZ026"].ToString( ) );
                if ( row["QZ028"] != null && row["QZ028"].ToString( ) != "" )
                    _model.QZ028 = int.Parse( row["QZ028"].ToString( ) );
                if ( row["QZ030"] != null && row["QZ030"].ToString( ) != "" )
                    _model.QZ030 = int.Parse( row["QZ030"].ToString( ) );
                if ( row["QZ031"] != null && row["QZ031"].ToString( ) != "" )
                    _model.QZ031 = row["QZ031"].ToString( );
                if ( row["QZ032"] != null && row["QZ032"].ToString( ) != "" )
                    _model.QZ032 = DateTime.Parse( row["QZ032"].ToString( ) );
                if ( row["QZ033"] != null && row["QZ033"].ToString( ) != "" )
                    _model.QZ033 = row["QZ033"].ToString( );
                if ( row["QZ034"] != null && row["QZ034"].ToString( ) != "" )
                    _model.QZ034 = DateTime.Parse( row["QZ034"].ToString( ) );
                if ( row["QZ035"] != null && row["QZ035"].ToString( ) != "" )
                    _model.QZ035 = row["QZ035"].ToString( );
                if ( row["QZ036"] != null && row["QZ036"].ToString( ) != "" )
                    _model.QZ036 = DateTime.Parse( row["QZ036"].ToString( ) );
                if ( row["QZ038"] != null && row["QZ038"].ToString( ) != "" )
                    _model.QZ038 = row["QZ038"].ToString( );
            }

            return _model;
        }

        /// <summary>
        /// 编辑系数
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfCoe ( MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQZ SET " );
            strSql.Append( "QZ009=@QZ009," );
            strSql.Append( "QZ011=@QZ011," );
            strSql.Append( "QZ012=@QZ012," );
            strSql.Append( "QZ015=@QZ015," );
            strSql.Append( "QZ016=@QZ016," );
            strSql.Append( "QZ017=@QZ017," );
            strSql.Append( "QZ018=@QZ018," );
            strSql.Append( "QZ020=@QZ020," );
            strSql.Append( "QZ022=@QZ022," );
            strSql.Append( "QZ024=@QZ024," );
            strSql.Append( "QZ026=@QZ026," );
            strSql.Append( "QZ028=@QZ028," );
            strSql.Append( "QZ030=@QZ030," );
            strSql.Append( "QZ040=@QZ040," );
            strSql.Append( "QZ041=@QZ041," );
            strSql.Append( "QZ042=@QZ042," );
            strSql.Append( "QZ043=@QZ043," );
            strSql.Append( "QZ044=@QZ044," );
            strSql.Append( "QZ045=@QZ045," );
            strSql . Append ( "QZ047=@QZ047," );
            strSql . Append ( "QZ049=@QZ049" );
            //strSql .Append( " WHERE QZ001=@QZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@QZ009",SqlDbType.Decimal,9),
                new SqlParameter("@QZ011",SqlDbType.Decimal,9),
                new SqlParameter("@QZ012",SqlDbType.Decimal,9),
                new SqlParameter("@QZ015",SqlDbType.Decimal,9),
                new SqlParameter("@QZ016",SqlDbType.Int),
                new SqlParameter("@QZ017",SqlDbType.Int),
                new SqlParameter("@QZ018",SqlDbType.Decimal,9),
                new SqlParameter("@QZ020",SqlDbType.Decimal),
                new SqlParameter("@QZ022",SqlDbType.Int),
                new SqlParameter("@QZ024",SqlDbType.Int),
                new SqlParameter("@QZ026",SqlDbType.Int),
                new SqlParameter("@QZ028",SqlDbType.Int),
                new SqlParameter("@QZ030",SqlDbType.Int),
                new SqlParameter("@QZ040",SqlDbType.Decimal,9),
                new SqlParameter("@QZ041",SqlDbType.Int),
                new SqlParameter("@QZ042",SqlDbType.Decimal,9),
                new SqlParameter("@QZ043",SqlDbType.Decimal,9),
                new SqlParameter("@QZ044",SqlDbType.Int),
                new SqlParameter("@QZ045",SqlDbType.Int),
                new SqlParameter("@QZ047",SqlDbType.Int),
                new SqlParameter("@QZ049",SqlDbType.Int)//,
                //new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.QZ009;
            parameter[1].Value = _model.QZ011;
            parameter[2].Value = _model.QZ012;
            parameter[3].Value = _model.QZ015;
            parameter[4].Value = _model.QZ016;
            parameter[5].Value = _model.QZ017;
            parameter[6].Value = _model.QZ018;
            parameter[7].Value = _model.QZ020;
            parameter[8].Value = _model.QZ022;
            parameter[9].Value = _model.QZ024;
            parameter[10].Value = _model.QZ026;
            parameter[11].Value = _model.QZ028;
            parameter[12].Value = _model.QZ030;
            parameter[13].Value = _model.QZ040;
            parameter[14].Value = _model.QZ041;
            parameter[15].Value = _model.QZ042;
            parameter[16].Value = _model.QZ043;
            parameter[17].Value = _model.QZ044;
            parameter[18].Value = _model.QZ045;
            parameter [ 19 ] . Value = _model . QZ047;
            parameter [ 20 ] . Value = _model . QZ049;
            //parameter [ 21 ] . Value = _model . QZ001;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                result = true;
                DataTable dl = tableOfAllThisYear ( _model . QZ002 . Year );
                if ( dl != null && dl . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i <= 12 ; i++ )
                    {
                        _model . QZ001 = string . Empty;
                        if ( dl . Select ( "QZ002='" + i + "'" ) . Length > 0 )
                            _model . QZ001 = dl . Select ( "QZ002='" + i + "'" ) [ 0 ] [ "QZ001" ] . ToString ( );
                        if ( _model . QZ001 != string . Empty )
                        {
                            if ( batchEditRatio ( _model . QZ001 ,_model . QZ002 . Year ,i ) == false )
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 获取本年所有的单号,按照月份顺序排序
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        DataTable tableOfAllThisYear ( int year )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT QZ001,MONTH(QZ002) QZ002 FROM R_PQQZ WHERE YEAR(QZ002)={0} ORDER BY MONTH(QZ002)" ,year );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT QZ001,QZ002 FROM R_PQQZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            Object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT QZ001,QZ002,RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY QZ001 DESC)" );
            strSql.Append( "AS Row,T.* FROM R_PQQZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT LEFT JOIN R_REVIEWS ON QZ001=RES06" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT QZ001 FROM R_PQQZ" );


            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetDataTable ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQQZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetModel( da.Rows[0] );
            else
                return null;
        }
        
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetModel ( DataRow row )
        {
            MulaolaoLibrary.TeamLeaderRoutineCheckLibrary model = new MulaolaoLibrary.TeamLeaderRoutineCheckLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["QZ001"] != null && row["QZ001"].ToString( ) != "" )
                    model.QZ001 = row["QZ001"].ToString( );
                if ( row["QZ002"] != null && row["QZ002"].ToString( ) != "" )
                    model.QZ002 = DateTime.Parse( row["QZ002"].ToString( ) );
                if ( row["QZ003"] != null && row["QZ003"].ToString( ) != "" )
                    model.QZ003 = row["QZ003"].ToString( );
                if ( row["QZ004"] != null && row["QZ004"].ToString( ) != "" )
                    model.QZ004 = row["QZ004"].ToString( );
                if ( row["QZ005"] != null && row["QZ005"].ToString( ) != "" )
                    model.QZ005 = row["QZ005"].ToString( );
                if ( row["QZ006"] != null && row["QZ006"].ToString( ) != "" )
                    model.QZ006 = decimal.Parse( row["QZ006"].ToString( ) );
                if ( row["QZ007"] != null && row["QZ007"].ToString( ) != "" )
                    model.QZ007 = decimal.Parse( row["QZ007"].ToString( ) );
                if ( row["QZ008"] != null && row["QZ008"].ToString( ) != "" )
                    model.QZ008 = decimal.Parse( row["QZ008"].ToString( ) );
                if ( row["QZ009"] != null && row["QZ009"].ToString( ) != "" )
                    model.QZ009 = decimal.Parse( row["QZ009"].ToString( ) );
                if ( row["QZ010"] != null && row["QZ010"].ToString( ) != "" )
                    model.QZ010 = row["QZ010"].ToString( );
                if ( row["QZ011"] != null && row["QZ011"].ToString( ) != "" )
                    model.QZ011 = int.Parse( row["QZ011"].ToString( ) );
                if ( row["QZ012"] != null && row["QZ012"].ToString( ) != "" )
                    model.QZ012 = decimal.Parse( row["QZ012"].ToString( ) );
                if ( row["QZ013"] != null && row["QZ013"].ToString( ) != "" )
                    model.QZ013 = int.Parse( row["QZ013"].ToString( ) );
                if ( row["QZ014"] != null && row["QZ014"].ToString( ) != "" )
                    model.QZ014 = decimal.Parse( row["QZ014"].ToString( ) );
                if ( row["QZ015"] != null && row["QZ015"].ToString( ) != "" )
                    model.QZ015 = decimal.Parse( row["QZ015"].ToString( ) );
                if ( row["QZ016"] != null && row["QZ016"].ToString( ) != "" )
                    model.QZ016 = int.Parse( row["QZ016"].ToString( ) );
                if ( row["QZ017"] != null && row["QZ017"].ToString( ) != "" )
                    model.QZ017 = int.Parse( row["QZ017"].ToString( ) );
                if ( row["QZ018"] != null && row["QZ018"].ToString( ) != "" )
                    model.QZ018 = decimal.Parse( row["QZ018"].ToString( ) );
                if ( row["QZ019"] != null && row["QZ019"].ToString( ) != "" )
                    model.QZ019 = int.Parse( row["QZ019"].ToString( ) );
                if ( row["QZ020"] != null && row["QZ020"].ToString( ) != "" )
                    model.QZ020 = decimal.Parse( row["QZ020"].ToString( ) );
                if ( row["QZ021"] != null && row["QZ021"].ToString( ) != "" )
                    model.QZ021 = int.Parse( row["QZ021"].ToString( ) );
                if ( row["QZ022"] != null && row["QZ022"].ToString( ) != "" )
                    model.QZ022 = int.Parse( row["QZ022"].ToString( ) );
                if ( row["QZ023"] != null && row["QZ023"].ToString( ) != "" )
                    model.QZ023 = int.Parse( row["QZ023"].ToString( ) );
                if ( row["QZ024"] != null && row["QZ024"].ToString( ) != "" )
                    model.QZ024 = int.Parse( row["QZ024"].ToString( ) );
                if ( row["QZ025"] != null && row["QZ025"].ToString( ) != "" )
                    model.QZ025 = int.Parse( row["QZ025"].ToString( ) );
                if ( row["QZ026"] != null && row["QZ026"].ToString( ) != "" )
                    model.QZ026 = int.Parse( row["QZ026"].ToString( ) );
                if ( row["QZ027"] != null && row["QZ027"].ToString( ) != "" )
                    model.QZ027 = int.Parse( row["QZ027"].ToString( ) );
                if ( row["QZ028"] != null && row["QZ028"].ToString( ) != "" )
                    model.QZ028 = int.Parse( row["QZ028"].ToString( ) );
                if ( row["QZ029"] != null && row["QZ029"].ToString( ) != "" )
                    model.QZ029 = int.Parse( row["QZ029"].ToString( ) );
                if ( row["QZ030"] != null && row["QZ030"].ToString( ) != "" )
                    model.QZ030 = int.Parse( row["QZ030"].ToString( ) );
                if ( row["QZ031"] != null && row["QZ031"].ToString( ) != "" )
                    model.QZ031 = row["QZ031"].ToString( );
                if ( row["QZ032"] != null && row["QZ032"].ToString( ) != "" )
                    model.QZ032 = DateTime.Parse( row["QZ032"].ToString( ) );
                if ( row["QZ033"] != null && row["QZ033"].ToString( ) != "" )
                    model.QZ033 = row["QZ033"].ToString( );
                if ( row["QZ034"] != null && row["QZ034"].ToString( ) != "" )
                    model.QZ034 = DateTime.Parse( row["QZ034"].ToString( ) );
                if ( row["QZ035"] != null && row["QZ035"].ToString( ) != "" )
                    model.QZ035 = row["QZ035"].ToString( );
                if ( row["QZ036"] != null && row["QZ036"].ToString( ) != "" )
                    model.QZ036 = DateTime.Parse( row["QZ036"].ToString( ) );
                if ( row["QZ037"] != null && row["QZ037"].ToString( ) != "" )
                    model.QZ037 = row["QZ037"].ToString( );
                if ( row["QZ038"] != null && row["QZ038"].ToString( ) != "" )
                    model.QZ038 = row["QZ038"].ToString( );
                if ( row["QZ039"] != null && row["QZ039"].ToString( ) != "" )
                    model.QZ039 = int.Parse( row["QZ039"].ToString( ) );
                if ( row["QZ040"] != null && row["QZ040"].ToString( ) != "" )
                    model.QZ040 = decimal.Parse( row["QZ040"].ToString( ) );
                if ( row["QZ041"] != null && row["QZ041"].ToString( ) != "" )
                    model.QZ041 = int.Parse( row["QZ041"].ToString( ) );
                if ( row["QZ042"] != null && row["QZ042"].ToString( ) != "" )
                    model.QZ042 = decimal.Parse( row["QZ042"].ToString( ) );
                if ( row["QZ043"] != null && row["QZ043"].ToString( ) != "" )
                    model.QZ043 = decimal.Parse( row["QZ043"].ToString( ) );
                if ( row["QZ044"] != null && row["QZ044"].ToString( ) != "" )
                    model.QZ044 = int.Parse( row["QZ044"].ToString( ) );
                if ( row["QZ045"] != null && row["QZ045"].ToString( ) != "" )
                    model.QZ045 = int.Parse( row["QZ045"].ToString( ) );
                if ( row [ "QZ046" ] != null && row [ "QZ046" ] . ToString ( ) != "" )
                    model . QZ046 = int . Parse ( row [ "QZ046" ] . ToString ( ) );
                if ( row [ "QZ047" ] != null && row [ "QZ047" ] . ToString ( ) != "" )
                    model . QZ047 = int . Parse ( row [ "QZ047" ] . ToString ( ) );
                if ( row [ "QZ048" ] != null && row [ "QZ048" ] . ToString ( ) != "" )
                    model . QZ048 = int . Parse ( row [ "QZ048" ] . ToString ( ) );
                if ( row [ "QZ049" ] != null && row [ "QZ049" ] . ToString ( ) != "" )
                    model . QZ049 = int . Parse ( row [ "QZ049" ] . ToString ( ) );
            }

            return model;
        }

        /// <summary>
        /// 编辑利润
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateOfEdit (int idx,int price )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQQZ SET QZ013=@QZ013 WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@QZ013",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = price;
            parameter[1].Value = idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取本月合计
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT QZ001,QZ006,QZ007,QZ008,CASE WHEN DBA960='男' THEN QZ008*QZ009 WHEN DBA960='女' THEN QZ008*QZ015 WHEN DBA960='其他' THEN QZ008*QZ040 ELSE 0 END U22,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ008*QZ009/QZ006 WHEN DBA960='女' THEN QZ008*QZ015/QZ006 WHEN DBA960='其他' THEN QZ008*QZ040/QZ006 ELSE 0 END END U0,CASE WHEN DBA960='男' THEN QZ006*QZ011 WHEN DBA960='女' THEN QZ006*QZ016 WHEN DBA960='其他' THEN QZ006*QZ041 ELSE 0 END U23,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ011 WHEN DBA960='女' THEN QZ016 WHEN DBA960='其他' THEN QZ041 ELSE 0 END END U1,QZ014,CASE WHEN QZ006=0 THEN 0 ELSE QZ014/QZ006 END U4,QZ013,CASE WHEN DBA960='男' THEN QZ013*QZ012 WHEN DBA960='女' THEN QZ013*QZ042 WHEN DBA960='其他' THEN QZ013*QZ043 ELSE 0 END U5,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ013*QZ012/QZ006 WHEN DBA960='女' THEN QZ013*QZ042/QZ006 WHEN DBA960='其他' THEN QZ013*QZ043/QZ006 ELSE 0 END END U6,CASE WHEN DBA960='男' THEN QZ006*QZ017 WHEN DBA960='女' THEN QZ006*QZ044 WHEN DBA960='其他' THEN QZ006*QZ045 ELSE 0 END U7,QZ018,QZ019,QZ020,QZ019*QZ020 U13,QZ021,QZ022,QZ021*QZ022 U14,QZ023,QZ024,QZ023*QZ024 U15,QZ025,QZ026,QZ025*QZ026 U16,QZ027,QZ028,QZ027*QZ028 U17,QZ029,QZ030,QZ029*QZ030+ISNULL(QZ046*QZ047,0)+ISNULL(QZ048*QZ049,0) U18,QZ039,ISNULL(QZ046,0) QZ046,ISNULL(QZ048,0) QZ048 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002 " );
            strSql.Append( " WHERE QZ001=@QZ001)" );
            strSql . Append ( ",CFT AS (" );
            strSql . Append ( "SELECT DISTINCT QZ001,QZ008 FROM R_PQQZ WHERE QZ001=@QZ001" );
            strSql . Append ( "),CHT AS (" );
            //CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN U0+U1+U4+U6 ELSE U0+U1+U4+U6+(U13+U14+U15+U16+U17+U18)/QZ006 END)) U3,
            strSql . Append ( "SELECT QZ001,CONVERT(DECIMAL(18,0),SUM(QZ008)) QZ008 FROM CFT GROUP BY QZ001)" );
            strSql.Append( ",CJT AS (SELECT CONVERT(DECIMAL(18,0),SUM(QZ006)) QZ006,CONVERT(DECIMAL(18,0),SUM(QZ007)) QZ007,B.QZ008,CONVERT(DECIMAL(18,0),SUM(U22)) U22,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U22)/SUM(QZ006) END ) U0,CONVERT(DECIMAL(18,0),SUM(U23)) U23,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U23)/SUM(QZ006) END) U1,CONVERT(DECIMAL(18,0),SUM(QZ014)) QZ014,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(QZ014)/SUM(QZ006) END) U4,CONVERT(DECIMAL(18,0),SUM(QZ013)) QZ013,CONVERT(DECIMAL(18,0),SUM(U5)) U5,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U5)/SUM(QZ006) END) U6,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18)) U24,CONVERT(DECIMAL(18,0),SUM(U7)) U7,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7)) U9,CONVERT(DECIMAL(18,0),SUM(QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U10,CONVERT(DECIMAL(18,0),SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U11,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))/SUM(QZ006) END) U12,CONVERT(DECIMAL(18,0),SUM(QZ019)) QZ019,CONVERT(DECIMAL(18,0),SUM(U13)) U13,CONVERT(DECIMAL(18,0),SUM(QZ021)) QZ021,CONVERT(DECIMAL(18,0),SUM(U14)) U14,CONVERT(DECIMAL(18,0),SUM(QZ023)) QZ023,CONVERT(DECIMAL(18,0),SUM(U15)) U15,CONVERT(DECIMAL(18,0),SUM(QZ025)) QZ025,CONVERT(DECIMAL(18,0),SUM(U16)) U16,CONVERT(DECIMAL(18,0),SUM(QZ027)) QZ027,CONVERT(DECIMAL(18,0),SUM(U17)) U17,CONVERT(DECIMAL(18,0),SUM(QZ029)) QZ029,CONVERT(DECIMAL(18,0),SUM(U18)) U18,CONVERT(DECIMAL(18,0),SUM(U13+U14+U15+U16+U17+U18)) U19,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U13+U14+U15+U16+U17+U18)/SUM(QZ006) END) U20,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7-QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U21,CONVERT(DECIMAL(18,0),SUM(QZ039)) QZ039,SUM(QZ046) QZ046,SUM(QZ048) QZ048 FROM CET A INNER JOIN CHT B ON A.QZ001=B.QZ001 GROUP BY B.QZ008) " );//(DECIMAL(18,0),SUM(U0))
            strSql . Append ( "SELECT *,U0+U1+U4+U6+U20 U3 FROM CJT" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrint (DateTime dtOne )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,0),SUM(QZ006)) QZ006,CONVERT(DECIMAL(18,0),SUM(QZ007)) QZ007,CONVERT(DECIMAL(18,0),SUM(QZ008)/2) QZ008,CONVERT(DECIMAL(18,0),SUM(ISNULL(U22,0))) U22,CONVERT(DECIMAL(18,0),SUM(U0)) U0,CONVERT(DECIMAL(18,0),SUM(U23)) U23,CONVERT(DECIMAL(18,0),SUM(U1)) U1,CONVERT(DECIMAL(18,0),SUM(QZ014)) QZ014,CONVERT(DECIMAL(18,0),SUM(U4)) U4,CONVERT(DECIMAL(18,0),SUM(QZ013)) QZ013,CONVERT(DECIMAL(18,0),SUM(U5)) U5,CONVERT(DECIMAL(18,0),SUM(U6)) U6,CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN U0+U1+U4+U6 ELSE U0+U1+U4+U6+(U13+U14+U15+U16+U17+U18)/QZ006 END)) U3,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18)) U24,CONVERT(DECIMAL(18,0),SUM(U7)) U7,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7)) U9,CONVERT(DECIMAL(18,0),SUM(QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U10,CONVERT(DECIMAL(18,0),SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U11,CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN 0 ELSE (U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))/QZ006 END)) U12,CONVERT(DECIMAL(18,0),SUM(QZ019)) QZ019,CONVERT(DECIMAL(18,0),SUM(U13)) U13,CONVERT(DECIMAL(18,0),SUM(QZ021)) QZ021,CONVERT(DECIMAL(18,0),SUM(U14)) U14,CONVERT(DECIMAL(18,0),SUM(QZ023)) QZ023,CONVERT(DECIMAL(18,0),SUM(U15)) U15,CONVERT(DECIMAL(18,0),SUM(QZ025)) QZ025,CONVERT(DECIMAL(18,0),SUM(U16)) U16,CONVERT(DECIMAL(18,0),SUM(QZ027)) QZ027,CONVERT(DECIMAL(18,0),SUM(U17)) U17,CONVERT(DECIMAL(18,0),SUM(QZ029)) QZ029,CONVERT(DECIMAL(18,0),SUM(U18)) U18,CONVERT(DECIMAL(18,0),SUM(U13+U14+U15+U16+U17+U18)) U19,CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN 0 ELSE (U13+U14+U15+U16+U17+U18)/QZ006 END)) U20,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7-QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U21,CONVERT(DECIMAL(18,0),SUM(QZ039)) QZ039,SUM(QZ046) QZ046,SUM(QZ048) QZ048 FROM   R_PQQZC WHERE QZ002=@QZ002" );
            SqlParameter [ ] paramet = {
                new SqlParameter("@QZ002",SqlDbType.DateTime)
            };
            paramet [ 0 ] . Value = dtOne;


            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,paramet );
        }

        /// <summary>
        /// 获取累计合计
        /// </summary>
        /// <param name="dtOne"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCountSum (string oddNum ,DateTime dtOne)
        {
            StringBuilder strSql = new StringBuilder( );

            if ( batchEditRatio ( oddNum ,dtOne . Year ,dtOne . Month ) == false )
                return null;
            
            strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            //2018-10-10
            //strSql . Append ( "SELECT DISTINCT A.QZ002,A.QZ008 FROM R_PQQZC A RIGHT JOIN R_PQQZ B ON A.QZ004=B.QZ004 AND A.QZ003=B.QZ003 " );
            //strSql . AppendFormat ( "WHERE A.QZ002=@QZ002 AND B.QZ002=@QZ002 AND DBA960='男'" );
            strSql . Append ( "SELECT QZ002,QZ008 FROM R_PQQZC " );
            strSql . AppendFormat ( "WHERE QZ002=@QZ002 AND DBA960='男'" );
            strSql . Append ( "),CFT AS(" );
            //CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN U0+U1+U4+U6 ELSE U0+U1+U4+U6+(U13+U14+U15+U16+U17+U18)/QZ006 END)) U3,
            strSql . Append ( "SELECT QZ002,CONVERT(DECIMAL(18,0),SUM(QZ008)) QZ008 FROM CET GROUP BY QZ002)" );
            strSql . Append ( ",CJT AS (SELECT CONVERT(DECIMAL(18,0),SUM(QZ006)) QZ006,CONVERT(DECIMAL(18,0),SUM(QZ007)) QZ007,B.QZ008,CONVERT(DECIMAL(18,0),SUM(ISNULL(U22,0))) U22,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U22)/SUM(QZ006) END) U0,CONVERT(DECIMAL(18,0),SUM(U23)) U23,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U23)/SUM(QZ006) END) U1,CONVERT(DECIMAL(18,0),SUM(QZ014)) QZ014,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(QZ014)/SUM(QZ006) END) U4,CONVERT(DECIMAL(18,0),SUM(QZ013)) QZ013,CONVERT(DECIMAL(18,0),SUM(U5)) U5,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U5)/SUM(QZ006) END) U6,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18)) U24,CONVERT(DECIMAL(18,0),SUM(U7)) U7,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7)) U9,CONVERT(DECIMAL(18,0),SUM(QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U10,CONVERT(DECIMAL(18,0),SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U11,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))/SUM(QZ006) END) U12,CONVERT(DECIMAL(18,0),SUM(QZ019)) QZ019,CONVERT(DECIMAL(18,0),SUM(U13)) U13,CONVERT(DECIMAL(18,0),SUM(QZ021)) QZ021,CONVERT(DECIMAL(18,0),SUM(U14)) U14,CONVERT(DECIMAL(18,0),SUM(QZ023)) QZ023,CONVERT(DECIMAL(18,0),SUM(U15)) U15,CONVERT(DECIMAL(18,0),SUM(QZ025)) QZ025,CONVERT(DECIMAL(18,0),SUM(U16)) U16,CONVERT(DECIMAL(18,0),SUM(QZ027)) QZ027,CONVERT(DECIMAL(18,0),SUM(U17)) U17,CONVERT(DECIMAL(18,0),SUM(QZ029)) QZ029,CONVERT(DECIMAL(18,0),SUM(U18)) U18,CONVERT(DECIMAL(18,0),SUM(U13+U14+U15+U16+U17+U18)) U19,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U13+U14+U15+U16+U17+U18)/SUM(QZ006) END) U20,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7-QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U21,CONVERT(DECIMAL(18,0),SUM(QZ039)) QZ039,SUM(QZ046) QZ046,SUM(QZ048) QZ048 FROM R_PQQZC A INNER JOIN CFT B ON A.QZ002=B.QZ002 WHERE A.QZ002=@QZ002 GROUP BY B.QZ008)   " );
            strSql . Append ( "SELECT *,U0+U1+U4+U6+U20 U3 FROM CJT" );
            SqlParameter [ ] paramet = {
                new SqlParameter("@QZ002",SqlDbType.DateTime)
            };
            paramet [ 0 ] . Value = dtOne;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) ,paramet );
        }

        bool countOfPqqzc ( DataTable da ,ArrayList SQLString )
        {
            MulaolaoLibrary . TeamLeaderRoutineCheckPqqzc _model = new MulaolaoLibrary . TeamLeaderRoutineCheckPqqzc ( );
            StringBuilder strSql = new StringBuilder ( );
            _model . QZ002 = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "QZ002" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Rows [ 0 ] [ "QZ002" ] . ToString ( ) );
            if ( ExistsOfPqqzc ( _model . QZ002 ) )
                SQLString . Add ( deletePqzzc ( _model . QZ002 ,strSql ) );
            for ( int i = 0 ; i < da . Rows . Count ; i++ )
            {
                _model . QZ003 = da . Rows [ i ] [ "QZ003" ] . ToString ( );
                _model . QZ004 = da . Rows [ i ] [ "QZ004" ] . ToString ( );
                _model . QZ005 = da . Rows [ i ] [ "QZ005" ] . ToString ( );
                da . Rows [ i ] [ "QZ005" ] . ToString ( );
                _model . QZ006 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ006" ] . ToString ( ) );
                _model . QZ007 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ007" ] . ToString ( ) );
                _model . QZ008 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ008" ] . ToString ( ) );
                _model . U22 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U22" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U22" ] . ToString ( ) );
                _model . U0 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                _model . U23 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U23" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U23" ] . ToString ( ) );
                _model . U1 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "U1" ] . ToString ( ) );
                _model . QZ009 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ009" ] . ToString ( ) );
                _model . QZ011 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ011" ] . ToString ( ) );
                _model . QZ014 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ014" ] . ToString ( ) );
                _model . U4 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U4" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U4" ] . ToString ( ) );
                _model . U5 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U5" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U5" ] . ToString ( ) );
                _model . U6 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U6" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U6" ] . ToString ( ) );
                _model . U7 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U7" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U7" ] . ToString ( ) );
                _model . QZ012 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ012" ] . ToString ( ) );
                _model . QZ013 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ013" ] . ToString ( ) );
                _model . QZ017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ017" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ017" ] . ToString ( ) );
                _model . QZ018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ018" ] . ToString ( ) );
                _model . QZ019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ019" ] . ToString ( ) );
                _model . U13 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U13" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U13" ] . ToString ( ) );
                _model . U14 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U14" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( da . Rows [ i ] [ "U14" ] . ToString ( ) );
                _model . U15 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U15" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( da . Rows [ i ] [ "U15" ] . ToString ( ) );
                _model . U16 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U16" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( da . Rows [ i ] [ "U16" ] . ToString ( ) );
                _model . U17 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U17" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( da . Rows [ i ] [ "U17" ] . ToString ( ) );
                _model . U18 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U18" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( da . Rows [ i ] [ "U18" ] . ToString ( ) );
                _model . QZ020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ020" ] . ToString ( ) );
                _model . QZ021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ021" ] . ToString ( ) );
                _model . QZ022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ022" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ022" ] . ToString ( ) );
                _model . QZ023 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ023" ] . ToString ( ) );
                _model . QZ024 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ024" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ024" ] . ToString ( ) );
                _model . QZ025 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ025" ] . ToString ( ) );
                _model . QZ026 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ026" ] . ToString ( ) );
                _model . QZ027 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ027" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ027" ] . ToString ( ) );
                _model . QZ028 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ028" ] . ToString ( ) );
                _model . QZ029 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ029" ] . ToString ( ) );
                _model . QZ030 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ030" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ030" ] . ToString ( ) );
                _model . QZ039 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ039" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ039" ] . ToString ( ) );
                _model . DBA960 = da . Rows [ i ] [ "DBA960" ] . ToString ( );
                _model . QZ015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ015" ] . ToString ( ) );
                _model . QZ040 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ040" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ040" ] . ToString ( ) );
                _model . QZ016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ016" ] . ToString ( ) );
                _model . QZ041 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ041" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ041" ] . ToString ( ) );
                _model . QZ042 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ042" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ042" ] . ToString ( ) );
                _model . QZ043 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ043" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "QZ043" ] . ToString ( ) );
                _model . QZ044 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ044" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ044" ] . ToString ( ) );
                _model . QZ045 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ045" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ045" ] . ToString ( ) );
                _model . QZ046 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ046" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ046" ] . ToString ( ) );
                _model . QZ047 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ047" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ047" ] . ToString ( ) );
                _model . QZ048 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ048" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ048" ] . ToString ( ) );
                _model . QZ049 = string . IsNullOrEmpty ( da . Rows [ i ] [ "QZ049" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "QZ049" ] . ToString ( ) );
                //if ( ExistsOfPqqzc ( _model . QZ004 ,_model . QZ002 ) == true )
                //    SQLString . Add ( updateOfPqqzc ( _model ,strSql ) );
                //else

                SQLString . Add ( addOfPqqzc ( _model ,strSql ) );
            }

            if ( SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                SQLString = new ArrayList ( );
                //_model . QZ002 = string . IsNullOrEmpty ( da . Compute ( "max(QZ002)" ,null ) . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( da . Compute ( "max(QZ002)" ,null ) . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . Append ( "SELECT * FROM R_PQQZC WHERE QZ002=(SELECT MAX(QZ002) QZ002 FROM R_PQQZC WHERE CONVERT(VARCHAR,QZ002,112)>='" + _model . QZ002 . Year . ToString ( ) + "0101" + "'AND CONVERT(VARCHAR,QZ002,112)<'" + _model . QZ002 . ToString ( "yyyyMMdd" ) + "')" );
                DataTable de = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( de != null && de . Rows . Count > 0 )
                {
                    for ( int k = 0 ; k < de . Rows . Count ; k++ )
                    {
                        _model . QZ004 = de . Rows [ k ] [ "QZ004" ] . ToString ( );
                        if ( da . Select ( "QZ004='" + _model . QZ004 + "'" ) . Length < 1 )
                        {
                            //_model . QZ002 = string . IsNullOrEmpty ( de . Rows [ 0 ] [ "QZ002" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( de . Rows [ 0 ] [ "QZ002" ] . ToString ( ) );
                            _model . QZ003 = de . Rows [ k ] [ "QZ003" ] . ToString ( );
                            _model . QZ005 = de . Rows [ k ] [ "QZ005" ] . ToString ( );
                            //da . Rows [ k ] [ "QZ005" ] . ToString ( );
                            _model . QZ006 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ006" ] . ToString ( ) );
                            _model . QZ007 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ007" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ007" ] . ToString ( ) );
                            _model . QZ008 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ008" ] . ToString ( ) );
                            _model . U22 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U22" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U22" ] . ToString ( ) );
                            _model . U0 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U0" ] . ToString ( ) );
                            _model . U23 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U23" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U23" ] . ToString ( ) );
                            _model . U1 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "U1" ] . ToString ( ) );
                            _model . QZ009 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ009" ] . ToString ( ) );
                            _model . QZ011 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ011" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ011" ] . ToString ( ) );
                            _model . QZ014 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ014" ] . ToString ( ) );
                            _model . U4 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U4" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U4" ] . ToString ( ) );
                            _model . U5 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U5" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U5" ] . ToString ( ) );
                            _model . U6 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U6" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U6" ] . ToString ( ) );
                            _model . U7 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U7" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U7" ] . ToString ( ) );
                            _model . QZ012 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ012" ] . ToString ( ) );
                            _model . QZ013 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ013" ] . ToString ( ) );
                            _model . QZ017 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ017" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ017" ] . ToString ( ) );
                            _model . QZ018 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ018" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ018" ] . ToString ( ) );
                            _model . QZ019 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ019" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ019" ] . ToString ( ) );
                            _model . U13 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U13" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "U13" ] . ToString ( ) );
                            _model . U14 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U14" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U14" ] . ToString ( ) );
                            _model . U15 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U15" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U15" ] . ToString ( ) );
                            _model . U16 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U16" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U16" ] . ToString ( ) );
                            _model . U17 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U17" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U17" ] . ToString ( ) );
                            _model . U18 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U18" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U18" ] . ToString ( ) );
                            _model . QZ020 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ020" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ020" ] . ToString ( ) );
                            _model . QZ021 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ021" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ021" ] . ToString ( ) );
                            _model . QZ022 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ022" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ022" ] . ToString ( ) );
                            _model . QZ023 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ023" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ023" ] . ToString ( ) );
                            _model . QZ024 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ024" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ024" ] . ToString ( ) );
                            _model . QZ025 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ025" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ025" ] . ToString ( ) );
                            _model . QZ026 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ026" ] . ToString ( ) );
                            _model . QZ027 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ027" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ027" ] . ToString ( ) );
                            _model . QZ028 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ028" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ028" ] . ToString ( ) );
                            _model . QZ029 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ029" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ029" ] . ToString ( ) );
                            _model . QZ030 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ030" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ030" ] . ToString ( ) );
                            _model . QZ039 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ039" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ039" ] . ToString ( ) );
                            _model . DBA960 = de . Rows [ k ] [ "DBA960" ] . ToString ( );
                            _model . QZ015 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ015" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ015" ] . ToString ( ) );
                            _model . QZ040 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ040" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ040" ] . ToString ( ) );
                            _model . QZ016 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ016" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ016" ] . ToString ( ) );
                            _model . QZ041 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ041" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ041" ] . ToString ( ) );
                            _model . QZ042 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ042" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ042" ] . ToString ( ) );
                            _model . QZ043 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ043" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( de . Rows [ k ] [ "QZ043" ] . ToString ( ) );
                            _model . QZ044 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ044" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ044" ] . ToString ( ) );
                            _model . QZ045 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ045" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ045" ] . ToString ( ) );
                            _model . QZ046 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ046" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ046" ] . ToString ( ) );
                            _model . QZ047 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ047" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ047" ] . ToString ( ) );
                            _model . QZ048 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ048" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ048" ] . ToString ( ) );
                            _model . QZ049 = string . IsNullOrEmpty ( de . Rows [ k ] [ "QZ049" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( de . Rows [ k ] [ "QZ049" ] . ToString ( ) );
                            SQLString . Add ( addOfPqqzc ( _model ,strSql ) );
                        }
                        //else
                        //{
                        //    _model . U18 = string . IsNullOrEmpty ( de . Rows [ k ] [ "U18" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( de . Rows [ k ] [ "U18" ] . ToString ( ) );
                        //    _model . QZ003 = de . Rows [ k ] [ "QZ003" ] . ToString ( );
                        //    _model . QZ004 = de . Rows [ k ] [ "QZ004" ] . ToString ( );
                        //    SQLString . Add ( update ( _model ) );
                        //}
                    }

                    return SqlHelper . ExecuteSqlTran ( SQLString );
                }
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 批量编辑系数时，351所有月份本年的系数都要编辑，所以累计数也要变更
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        bool batchEditRatio ( string oddNum ,int year ,int month )
        {
            StringBuilder strSql = new StringBuilder ( );

            //strSql . Append ( "SELECT C.QZ002,A.QZ003,A.QZ004,'累计' QZ005,SUM(A.QZ006) QZ006,SUM(A.QZ007) QZ007,SUM(A.QZ008) QZ008,SUM(CASE WHEN DBA960='男' THEN QZ008*C.QZ009 WHEN DBA960='女' THEN QZ008*C.QZ015 WHEN DBA960='其他' THEN QZ008*C.QZ040 ELSE 0 END) U22,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN SUM(QZ008*C.QZ009)/SUM(A.QZ006) WHEN DBA960='女' THEN SUM(QZ008*C.QZ015)/SUM(A.QZ006) WHEN DBA960='其他' THEN SUM(QZ008*C.QZ040)/SUM(A.QZ006) ELSE 0 END END U0,SUM(CASE WHEN DBA960='男' THEN A.QZ006*C.QZ011 WHEN DBA960='女' THEN A.QZ006*C.QZ016 WHEN DBA960='其他' THEN A.QZ006*C.QZ041 ELSE 0 END) U23,CASE WHEN C.QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN C.QZ011 WHEN DBA960='女' THEN C.QZ016 WHEN DBA960='其他' THEN C.QZ041 ELSE 0 END END U1,CONVERT(FLOAT,C.QZ009) QZ009,C.QZ011,SUM(A.QZ014) QZ014,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE SUM(A.QZ014)/SUM(A.QZ006) END U4,CASE WHEN DBA960='男' THEN SUM(QZ013*C.QZ012) WHEN DBA960='女' THEN SUM(QZ013*C.QZ042) WHEN DBA960='其他' THEN SUM(QZ013*C.QZ043) ELSE 0 END U5,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN SUM(QZ013*C.QZ012)/SUM(A.QZ006) WHEN DBA960='女' THEN SUM(QZ013*C.QZ042)/SUM(A.QZ006) WHEN DBA960='其他' THEN SUM(QZ013*C.QZ043)/SUM(A.QZ006) ELSE 0 END END U6,CASE WHEN DBA960='男' THEN SUM(A.QZ006*C.QZ017) WHEN DBA960='女' THEN SUM(A.QZ006*C.QZ044) WHEN DBA960='其他' THEN SUM(A.QZ006*C.QZ045) ELSE 0 END U7,CONVERT(FLOAT,C.QZ012) QZ012,SUM(A.QZ013) QZ013,C.QZ017,CONVERT(FLOAT,C.QZ018) QZ018,SUM(A.QZ019) QZ019,SUM(QZ019*C.QZ020) U13,SUM(QZ021*C.QZ022) U14,SUM(QZ023*C.QZ024) U15,SUM(QZ025*C.QZ026) U16,SUM(QZ027*C.QZ028) U17,SUM(QZ029*C.QZ030+ISNULL(QZ046*C.QZ047,0)+ISNULL(QZ048*C.QZ049,0)) U18,CONVERT(FLOAT,C.QZ020) QZ020,SUM(A.QZ021) QZ021,C.QZ022,SUM(A.QZ023) QZ023,C.QZ024,SUM(A.QZ025) QZ025,C.QZ026,SUM(A.QZ027) QZ027,C.QZ028,SUM(A.QZ029) QZ029,C.QZ030,SUM(A.QZ039) QZ039,DBA960,CONVERT(FLOAT,C.QZ015) QZ015,CONVERT(FLOAT,C.QZ040) QZ040,C.QZ016,C.QZ041,CONVERT(FLOAT,C.QZ042) QZ042,CONVERT(FLOAT,C.QZ043) QZ043,C.QZ044,C.QZ045,SUM(ISNULL(QZ046,0)) QZ046,ISNULL(C.QZ047,0) QZ047,SUM(ISNULL(QZ048,0)) QZ048,ISNULL(C.QZ049,0) QZ049 FROM R_PQQZ A " );
            //strSql . Append ( "LEFT JOIN TPADBA B ON A.QZ004=B.DBA002 " );
            //strSql . Append ( "LEFT JOIN (" );
            //strSql . Append ( "SELECT QZ002,QZ003,QZ004,QZ006,QZ009,QZ011,QZ012,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045,QZ047,QZ049 FROM R_PQQZ " );
            //strSql . AppendFormat ( "WHERE QZ001='{0}' " ,oddNum );
            //strSql . Append ( ") C ON A.QZ003=C.QZ003 AND A.QZ004=C.QZ004 " );
            //strSql . Append ( "WHERE A.QZ002<=(SELECT DISTINCT QZ002 FROM R_PQQZ " );
            //strSql . AppendFormat ( "WHERE QZ001='{0}') AND CONVERT(VARCHAR,A.QZ002) LIKE '{1}%' AND C.QZ003 IS NOT NULL  " ,oddNum ,year );
            //strSql . Append ( "GROUP BY C.QZ002,A.QZ003,A.QZ004,A.QZ005,C.QZ009,C.QZ011,C.QZ012,C.QZ017,C.QZ018,C.QZ020,C.QZ022,C.QZ024,C.QZ026,C.QZ028,C.QZ030,DBA960,C.QZ015,C.QZ040,C.QZ016,C.QZ041,C.QZ042,C.QZ043,C.QZ044,C.QZ045,C.QZ047,C.QZ049,C.QZ006" );

            //2018-4-23  吴小毛和吴书松车间合并到王祖汉组  
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT C.QZ002,A.QZ003,A.QZ004,'累计' QZ005,SUM(A.QZ006) QZ006,SUM(A.QZ007) QZ007,SUM(A.QZ008) QZ008,SUM(CASE WHEN DBA960='男' THEN QZ008*C.QZ009 WHEN DBA960='女' THEN QZ008*C.QZ015 WHEN DBA960='其他' THEN QZ008*C.QZ040 ELSE 0 END) U22,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN SUM(QZ008*C.QZ009)/SUM(A.QZ006) WHEN DBA960='女' THEN SUM(QZ008*C.QZ015)/SUM(A.QZ006) WHEN DBA960='其他' THEN SUM(QZ008*C.QZ040)/SUM(A.QZ006) ELSE 0 END END U0,SUM(CASE WHEN DBA960='男' THEN A.QZ006*C.QZ011 WHEN DBA960='女' THEN A.QZ006*C.QZ016 WHEN DBA960='其他' THEN A.QZ006*C.QZ041 ELSE 0 END) U23,CASE WHEN C.QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN C.QZ011 WHEN DBA960='女' THEN C.QZ016 WHEN DBA960='其他' THEN C.QZ041 ELSE 0 END END U1,CONVERT(FLOAT,C.QZ009) QZ009,C.QZ011,SUM(A.QZ014) QZ014,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE SUM(A.QZ014)/SUM(A.QZ006) END U4,CASE WHEN DBA960='男' THEN SUM(QZ013*C.QZ012) WHEN DBA960='女' THEN SUM(QZ013*C.QZ042) WHEN DBA960='其他' THEN SUM(QZ013*C.QZ043) ELSE 0 END U5,CASE WHEN SUM(A.QZ006)=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN SUM(QZ013*C.QZ012)/SUM(A.QZ006) WHEN DBA960='女' THEN SUM(QZ013*C.QZ042)/SUM(A.QZ006) WHEN DBA960='其他' THEN SUM(QZ013*C.QZ043)/SUM(A.QZ006) ELSE 0 END END U6,CASE WHEN DBA960='男' THEN SUM(A.QZ006*C.QZ017) WHEN DBA960='女' THEN SUM(A.QZ006*C.QZ044) WHEN DBA960='其他' THEN SUM(A.QZ006*C.QZ045) ELSE 0 END U7,CONVERT(FLOAT,C.QZ012) QZ012,SUM(A.QZ013) QZ013,C.QZ017,CONVERT(FLOAT,C.QZ018) QZ018,SUM(A.QZ019) QZ019,SUM(QZ019*C.QZ020) U13,SUM(QZ021*C.QZ022) U14,SUM(QZ023*C.QZ024) U15,SUM(QZ025*C.QZ026) U16,SUM(QZ027*C.QZ028) U17,SUM(QZ029*C.QZ030+ISNULL(QZ046*C.QZ047,0)+ISNULL(QZ048*C.QZ049,0)) U18,CONVERT(FLOAT,C.QZ020) QZ020,SUM(A.QZ021) QZ021,C.QZ022,SUM(A.QZ023) QZ023,C.QZ024,SUM(A.QZ025) QZ025,C.QZ026,SUM(A.QZ027) QZ027,C.QZ028,SUM(A.QZ029) QZ029,C.QZ030,SUM(A.QZ039) QZ039,DBA960,CONVERT(FLOAT,C.QZ015) QZ015,CONVERT(FLOAT,C.QZ040) QZ040,C.QZ016,C.QZ041,CONVERT(FLOAT,C.QZ042) QZ042,CONVERT(FLOAT,C.QZ043) QZ043,C.QZ044,C.QZ045,SUM(ISNULL(QZ046,0)) QZ046,ISNULL(C.QZ047,0) QZ047,SUM(ISNULL(QZ048,0)) QZ048,ISNULL(C.QZ049,0) QZ049 FROM R_PQQZ A " );
            strSql . Append ( "LEFT JOIN TPADBA B ON A.QZ004=B.DBA002 " );
            strSql . Append ( "LEFT JOIN (" );
            strSql . Append ( "SELECT QZ002,QZ003,QZ004,QZ006,QZ009,QZ011,QZ012,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045,QZ047,QZ049 FROM R_PQQZ " );
            strSql . AppendFormat ( "WHERE QZ001='{0}' " ,oddNum );
            strSql . Append ( ") C ON A.QZ003=C.QZ003 AND A.QZ004=C.QZ004 " );
            strSql . Append ( "WHERE A.QZ002<=(SELECT DISTINCT QZ002 FROM R_PQQZ " );
            strSql . AppendFormat ( "WHERE QZ001='{0}') AND CONVERT(VARCHAR,A.QZ002) LIKE '{1}%'   " ,oddNum ,year );//AND C.QZ003 IS NOT NULL
            strSql . Append ( "GROUP BY C.QZ002,A.QZ003,A.QZ004,A.QZ005,C.QZ009,C.QZ011,C.QZ012,C.QZ017,C.QZ018,C.QZ020,C.QZ022,C.QZ024,C.QZ026,C.QZ028,C.QZ030,DBA960,C.QZ015,C.QZ040,C.QZ016,C.QZ041,C.QZ042,C.QZ043,C.QZ044,C.QZ045,C.QZ047,C.QZ049,C.QZ006" );
            strSql . Append ( ") ,CFT AS (" );
            strSql . Append ( "SELECT CASE WHEN QZ002 IS NULL THEN (SELECT TOP 1 QZ002 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ002 END QZ002,CASE WHEN QZ002 IS NULL THEN (SELECT TOP 1 QZ003 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ003 END QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,ISNULL(U22,0) U22,ISNULL(U0,0) U0,ISNULL(U23,0) U23,CASE WHEN U1 IS NULL THEN (SELECT TOP 1 U1 FROM CET WHERE QZ004=B.QZ004 AND QZ002 IS NOT NULL) ELSE U1 END U1,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 QZ009 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ009 END QZ009,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 QZ011 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ011 END QZ011,ISNULL(QZ014,0) QZ014,ISNULL(U4,0) U4,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 U5 FROM CET WHERE QZ002 IS NOT NULL) ELSE U5 END U5,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 U6 FROM CET WHERE QZ002 IS NOT NULL) ELSE U6 END U6,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 U7 FROM CET WHERE QZ004=B.QZ004 AND QZ002 IS NOT NULL) ELSE U7 END U7,CASE WHEN QZ009 IS NULL THEN (SELECT TOP 1 QZ012 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ012 END QZ012,ISNULL(QZ013,0) QZ013,CASE WHEN QZ017 IS NULL THEN (SELECT TOP 1 QZ017 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ017 END QZ017,CASE WHEN QZ018 IS NULL THEN (SELECT TOP 1 QZ018 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ018 END QZ018,ISNULL(QZ019,0) QZ019,ISNULL(U13,0) U13,ISNULL(U14,0) U14,ISNULL(U15,0) U15,ISNULL(U16,0) U16,ISNULL(U17,0) U17,ISNULL(U18,0) U18,CASE WHEN QZ020 IS NULL THEN (SELECT TOP 1 QZ020 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ020 END QZ020,ISNULL(QZ021,0) QZ021,CASE WHEN QZ022 IS NULL THEN (SELECT TOP 1 QZ022 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ022 END QZ022,ISNULL(QZ023,0) QZ023,CASE WHEN QZ024 IS NULL THEN (SELECT TOP 1 QZ024 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ024 END QZ024,ISNULL(QZ025,0) QZ025,CASE WHEN QZ026 IS NULL THEN (SELECT TOP 1 QZ026 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ026 END QZ026,ISNULL(QZ027,0) QZ027,CASE WHEN QZ028 IS NULL THEN (SELECT TOP 1 QZ028 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ028 END QZ028,ISNULL(QZ029,0) QZ029,CASE WHEN QZ030 IS NULL THEN (SELECT TOP 1 QZ030 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ030 END QZ030,ISNULL(QZ039,0) QZ039,DBA960,CASE WHEN QZ015 IS NULL THEN (SELECT TOP 1 QZ015 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ015 END QZ015,CASE WHEN QZ040 IS NULL THEN (SELECT TOP 1 QZ040 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ040 END QZ040,CASE WHEN QZ016 IS NULL THEN (SELECT TOP 1 QZ016 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ016 END QZ016,CASE WHEN QZ041 IS NULL THEN (SELECT TOP 1 QZ041 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ041 END QZ041,CASE WHEN QZ042 IS NULL THEN (SELECT TOP 1 QZ042 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ042 END QZ042,CASE WHEN QZ043 IS NULL THEN (SELECT TOP 1 QZ043 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ043 END QZ043,CASE WHEN QZ044 IS NULL THEN (SELECT TOP 1 QZ044 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ044 END QZ044,CASE WHEN QZ045 IS NULL THEN (SELECT TOP 1 QZ045 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ045 END QZ045,ISNULL(QZ046,0) QZ046,CASE WHEN QZ047 IS NULL THEN (SELECT TOP 1 QZ047 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ047 END QZ047,ISNULL(QZ048,0) QZ048,CASE WHEN QZ049 IS NULL THEN (SELECT TOP 1 QZ049 FROM CET WHERE QZ002 IS NOT NULL) ELSE QZ049 END QZ049 FROM CET B" );
            strSql . Append ( ") SELECT QZ002,QZ003,QZ004,QZ005,SUM(QZ006) QZ006,SUM(QZ007) QZ007,SUM(QZ008) QZ008,SUM(U22) U22,SUM(U0) U0,SUM(U23) U23,U1,QZ009,QZ011,SUM(QZ014) QZ014,SUM(U4) U4,U5,U6,U7,QZ012,SUM(QZ013) QZ013,QZ017,QZ018,SUM(QZ019) QZ019,SUM(U13) U13,SUM(U14) U14,SUM(U15) U15,SUM(U16) U16,SUM(U17) U17,SUM(U18) U18,QZ020,SUM(QZ021) QZ021,QZ022,SUM(QZ023) QZ023,QZ024,SUM(QZ025) QZ025,QZ026,SUM(QZ027) QZ027,QZ028,SUM(QZ029) QZ029,QZ030,SUM(QZ039) QZ039,DBA960,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045,SUM(QZ046) QZ046,QZ047,SUM(QZ048) QZ048,QZ049 FROM CFT GROUP BY QZ002,QZ003,QZ004,QZ005,U1,QZ009,QZ011,U5,U6,U7,QZ012,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,DBA960,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045,QZ047,QZ049" );

            DataTable da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( da == null || da . Rows . Count < 1 )
                return false;

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQQZC WHERE YEAR(QZ002)={0} AND MONTH(QZ002)={1}" ,year ,month );
            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );

            ArrayList SQLString = new ArrayList ( );
            if ( countOfPqqzc ( da ,SQLString ) == false )
                return false;
            else
                return true;
        }
        
        string deletePqzzc ( DateTime dt ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQQZC " );
            strSql . AppendFormat ( "WHERE QZ002 like '{0}%'" ,dt . ToString ( "yyyy-MM" ) );

            return strSql . ToString ( );
        }
        string addOfPqqzc ( MulaolaoLibrary . TeamLeaderRoutineCheckPqqzc _model,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQQZC (" );
            strSql . Append ( "QZ002,QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,U22,U0,U23,U1,QZ009,QZ011,QZ014,U4,U5,U6,U7,QZ012,QZ013,QZ017,QZ018,QZ019,U13,U14,U15,U16,U17,U18,QZ020,QZ021,QZ022,QZ023,QZ024,QZ025,QZ026,QZ027,QZ028,QZ029,QZ030,QZ039,DBA960,QZ015,QZ040,QZ016,QZ041,QZ043,QZ044,QZ045,QZ046,QZ047,QZ048,QZ049)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}')" ,_model . QZ002 ,_model . QZ003 ,_model . QZ004 ,_model . QZ005 ,_model . QZ006 ,_model . QZ007 ,_model . QZ008 ,_model . U22 ,_model . U0 ,_model . U23 ,_model . U1 ,_model . QZ009 ,_model . QZ011 ,_model . QZ014 ,_model . U4 ,_model . U5 ,_model . U6 ,_model . U7 ,_model . QZ012 ,_model . QZ013 ,_model . QZ017 ,_model . QZ018 ,_model . QZ019 ,_model . U13 ,_model . U14 ,_model . U15 ,_model . U16 ,_model . U17 ,_model . U18 ,_model . QZ020 ,_model . QZ021 ,_model . QZ022 ,_model . QZ023 ,_model . QZ024 ,_model . QZ025 ,_model . QZ026 ,_model . QZ027 ,_model . QZ028 ,_model . QZ029 ,_model . QZ030 ,_model . QZ039 ,_model . DBA960 ,_model . QZ015 ,_model . QZ040 ,_model . QZ016 ,_model . QZ041  ,_model . QZ043 ,_model . QZ044 ,_model . QZ045 ,_model . QZ046 ,_model . QZ047 ,_model . QZ048 ,_model . QZ049 );

            return strSql . ToString ( );

        }
        string updateOfPqqzc ( MulaolaoLibrary . TeamLeaderRoutineCheckPqqzc _model ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQQZC SET " );
            strSql . AppendFormat ( "QZ003='{0}'," ,_model . QZ003 );
            strSql . AppendFormat ( "QZ005='{0}'," ,_model . QZ005 );
            strSql . AppendFormat ( "QZ006='{0}'," ,_model . QZ006 );
            strSql . AppendFormat ( "QZ007='{0}'," ,_model . QZ007 );
            strSql . AppendFormat ( "QZ008='{0}'," ,_model . QZ008 );
            strSql . AppendFormat ( "U22='{0}'," ,_model . U22 );
            strSql . AppendFormat ( "U0='{0}'," ,_model . U0 );
            strSql . AppendFormat ( "U23='{0}'," ,_model . U23 );
            strSql . AppendFormat ( "U1='{0}'," ,_model . U1 );
            strSql . AppendFormat ( "QZ009='{0}'," ,_model . QZ009 );
            strSql . AppendFormat ( "QZ011='{0}'," ,_model . QZ011 );
            strSql . AppendFormat ( "QZ014='{0}'," ,_model . QZ014 );
            strSql . AppendFormat ( "U4='{0}'," ,_model . U4 );
            strSql . AppendFormat ( "U5='{0}'," ,_model . U5 );
            strSql . AppendFormat ( "U6='{0}'," ,_model . U6 );
            strSql . AppendFormat ( "U7='{0}'," ,_model . U7 );
            strSql . AppendFormat ( "QZ012='{0}'," ,_model . QZ012 );
            strSql . AppendFormat ( "QZ013='{0}'," ,_model . QZ013 );
            strSql . AppendFormat ( "QZ017='{0}'," ,_model . QZ017 );
            strSql . AppendFormat ( "QZ018='{0}'," ,_model . QZ018 );
            strSql . AppendFormat ( "QZ019='{0}'," ,_model . QZ019 );
            strSql . AppendFormat ( "U13='{0}'," ,_model . U13 );
            strSql . AppendFormat ( "U14='{0}'," ,_model . U14 );
            strSql . AppendFormat ( "U15='{0}'," ,_model . U15 );
            strSql . AppendFormat ( "U16='{0}'," ,_model . U16 );
            strSql . AppendFormat ( "U17='{0}'," ,_model . U17 );
            strSql . AppendFormat ( "U18='{0}'," ,_model . U18 );
            strSql . AppendFormat ( "QZ020='{0}'," ,_model . QZ020 );
            strSql . AppendFormat ( "QZ021='{0}'," ,_model . QZ021 );
            strSql . AppendFormat ( "QZ022='{0}'," ,_model . QZ022 );
            strSql . AppendFormat ( "QZ023='{0}'," ,_model . QZ023 );
            strSql . AppendFormat ( "QZ024='{0}'," ,_model . QZ024 );
            strSql . AppendFormat ( "QZ025='{0}'," ,_model . QZ025 );
            strSql . AppendFormat ( "QZ026='{0}'," ,_model . QZ026 );
            strSql . AppendFormat ( "QZ027='{0}'," ,_model . QZ027 );
            strSql . AppendFormat ( "QZ028='{0}'," ,_model . QZ028 );
            strSql . AppendFormat ( "QZ029='{0}'," ,_model . QZ029 );
            strSql . AppendFormat ( "QZ030='{0}'," ,_model . QZ030 );
            strSql . AppendFormat ( "QZ039='{0}'," ,_model . QZ039 );
            strSql . AppendFormat ( "DBA960='{0}'," ,_model . DBA960 );
            strSql . AppendFormat ( "QZ015='{0}'," ,_model . QZ015 );
            strSql . AppendFormat ( "QZ040='{0}'," ,_model . QZ040 );
            strSql . AppendFormat ( "QZ016='{0}'," ,_model . QZ016 );
            strSql . AppendFormat ( "QZ041='{0}'," ,_model . QZ041 );
            strSql . AppendFormat ( "QZ042='{0}'," ,_model . QZ042 );
            strSql . AppendFormat ( "QZ043='{0}'," ,_model . QZ043 );
            strSql . AppendFormat ( "QZ044='{0}'," ,_model . QZ044 );
            strSql . AppendFormat ( "QZ045='{0}'," ,_model . QZ045 );
            strSql . AppendFormat ( "QZ046='{0}'," ,_model . QZ046 );
            strSql . AppendFormat ( "QZ047='{0}'," ,_model . QZ047 );
            strSql . AppendFormat ( "QZ048='{0}'," ,_model . QZ048 );
            strSql . AppendFormat ( "QZ049='{0}'" ,_model . QZ049 );
            strSql . AppendFormat ( " WHERE QZ002='{1}' AND QZ004='{0}'" ,_model . QZ004 ,_model . QZ002 );

            return strSql . ToString ( );
        }
        bool ExistsOfPqqzc ( DateTime dt)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM R_PQQZC" );
            strSql . AppendFormat ( " WHERE QZ002 LIKE '{0}%'" ,dt . ToString ( "yyyy-MM" ) );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        string update (MulaolaoLibrary . TeamLeaderRoutineCheckPqqzc _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQQZC SET " );
            strSql . AppendFormat ( "U18=U18+{0} " ,_model . U18 );
            strSql . AppendFormat ( "WHERE QZ002='{0}' AND QZ003='{1}' AND QZ004='{2}'" ,_model . QZ002 ,_model . QZ003 ,_model . QZ004 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 获取本月分组合计
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGroupSum ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS (" );
            strSql.Append( "SELECT QZ003,QZ006,QZ007,QZ008,CASE WHEN DBA960='男' THEN QZ008*QZ009 WHEN DBA960='女' THEN QZ008*QZ015 WHEN DBA960='其他' THEN QZ008*QZ040 ELSE 0 END U22,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ008*QZ009/QZ006 WHEN DBA960='女' THEN QZ008*QZ015/QZ006 WHEN DBA960='其他' THEN QZ008*QZ040/QZ006 ELSE 0 END END U0,CASE WHEN DBA960='男' THEN QZ006*QZ011 WHEN DBA960='女' THEN QZ006*QZ016 WHEN DBA960='其他' THEN QZ006*QZ041 ELSE 0 END U23,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ011 WHEN DBA960='女' THEN QZ016 WHEN DBA960='其他' THEN QZ041 ELSE 0 END END U1,QZ014,CASE WHEN QZ006=0 THEN 0 ELSE QZ014/QZ006 END U4,QZ013,CASE WHEN DBA960='男' THEN QZ013*QZ012 WHEN DBA960='女' THEN QZ013*QZ042 WHEN DBA960='其他' THEN QZ013*QZ043 ELSE 0 END U5,CASE WHEN QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN QZ013*QZ012/QZ006 WHEN DBA960='女' THEN QZ013*QZ042/QZ006 WHEN DBA960='其他' THEN QZ013*QZ043/QZ006 ELSE 0 END END U6,CASE WHEN DBA960='男' THEN QZ006*QZ017 WHEN DBA960='女' THEN QZ006*QZ044 WHEN DBA960='其他' THEN QZ006*QZ045 ELSE 0 END U7,QZ018,QZ019,QZ020,QZ019*QZ020 U13,QZ021,QZ022,QZ021*QZ022 U14,QZ023,QZ024,QZ023*QZ024 U15,QZ025,QZ026,QZ025*QZ026 U16,QZ027,QZ028,QZ027*QZ028 U17,QZ029,QZ030,QZ029*QZ030 U18,QZ039,ISNULL(QZ046,0) QZ046,ISNULL(QZ048,0) QZ048 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002" );
            strSql.Append( " WHERE QZ001=@QZ001)" );
            strSql . Append ( ",CFT AS (" );
            strSql . AppendFormat ( "SELECT DISTINCT QZ003,QZ008 FROM R_PQQZ WHERE QZ001=@QZ001" );
            strSql . Append ( "),CHT AS (" );
            strSql . Append ( "SELECT QZ003,CONVERT(DECIMAL(18,0),SUM(QZ008)) QZ008 FROM CFT GROUP BY QZ003)" );
            strSql.Append( " SELECT A.QZ003,CONVERT(DECIMAL(18,0),SUM(QZ006)) QZ006,CONVERT(DECIMAL(18,0),SUM(QZ007)) QZ007,B.QZ008,CONVERT(DECIMAL(18,0),SUM(U22)) U22,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U22)/SUM(QZ006) END) U0,CONVERT(DECIMAL(18,0),SUM(U23)) U23,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U23)/SUM(QZ006) END) U1,CONVERT(DECIMAL(18,0),SUM(QZ014)) QZ014,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(QZ014)/SUM(QZ006) END ) U4,CONVERT(DECIMAL(18,0),SUM(QZ013)) QZ013,CONVERT(DECIMAL(18,0),SUM(U5)) U5,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U5)/SUM(QZ006) END ) U6,CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN U0+U1+U4+U6 ELSE U0+U1+U4+U6+(U13+U14+U15+U16+U17+U18)/QZ006 END)) U3,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18)) U24,CONVERT(DECIMAL(18,0),SUM(U7)) U7,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7)) U9,CONVERT(DECIMAL(18,0),SUM(QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U10,CONVERT(DECIMAL(18,0),SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U11,CONVERT(DECIMAL(18,0),CASE WHEN SUM(QZ006)=0 THEN 0 ELSE SUM(U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))/SUM(QZ006) END) U12,CONVERT(DECIMAL(18,0),SUM(QZ019)) QZ019,CONVERT(DECIMAL(18,0),SUM(U13)) U13,CONVERT(DECIMAL(18,0),SUM(QZ021)) QZ021,CONVERT(DECIMAL(18,0),SUM(U14)) U14,CONVERT(DECIMAL(18,0),SUM(QZ023)) QZ023,CONVERT(DECIMAL(18,0),SUM(U15)) U15,CONVERT(DECIMAL(18,0),SUM(QZ025)) QZ025,CONVERT(DECIMAL(18,0),SUM(U16)) U16,CONVERT(DECIMAL(18,0),SUM(QZ027)) QZ027,CONVERT(DECIMAL(18,0),SUM(U17)) U17,CONVERT(DECIMAL(18,0),SUM(QZ029)) QZ029,CONVERT(DECIMAL(18,0),SUM(U18)) U18,CONVERT(DECIMAL(18,0),SUM(U13+U14+U15+U16+U17+U18)) U19,CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN 0 ELSE (U13+U14+U15+U16+U17+U18)/QZ006 END)) U20,CONVERT(DECIMAL(18,0),SUM(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7-QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U21,CONVERT(DECIMAL(18,0),SUM(QZ039)) QZ039,SUM(QZ046) QZ046,SUM(QZ048) QZ048 FROM CET A INNER JOIN CHT B ON A.QZ003=B.QZ003 GROUP BY A.QZ003,B.QZ008" );
            //CONVERT(DECIMAL(18,0),SUM(U0))          CONVERT(DECIMAL(18,0),SUM(U1))   CONVERT(DECIMAL(18,0),SUM(U4))  CONVERT(DECIMAL(18,0),SUM(U6))
            //CONVERT(DECIMAL(18,0),SUM(CASE WHEN QZ006=0 THEN 0 ELSE (U7+QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))/QZ006 END)) U12
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable PrintOne ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT QZ003,QZ004,QZ005,QZ006,QZ007,QZ008,CONVERT(FLOAT,QZ009) QZ009,QZ011,QZ014,CONVERT(FLOAT,QZ012) QZ012,QZ013,QZ017,CONVERT(FLOAT,QZ018) QZ018,QZ019,CONVERT(FLOAT,QZ020) QZ020,QZ021,QZ022,QZ023,QZ024,QZ025,QZ026,QZ027,QZ028,QZ029,QZ030,QZ039,DBA960,CONVERT(FLOAT,QZ015) QZ015,CONVERT(FLOAT,QZ040) QZ040,QZ016,QZ041,CONVERT(FLOAT,QZ042) QZ042,CONVERT(FLOAT,QZ043) QZ043,QZ044,QZ045 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002" );
            strSql . Append ( " WHERE QZ001=@QZ001" );
            strSql . Append ( " UNION" );
            strSql . Append ( " SELECT QZ003,QZ004,'累计' QZ005,SUM(QZ006) QZ006,SUM(QZ007) QZ007,SUM(QZ008) QZ008,CONVERT(FLOAT,QZ009) QZ009,QZ011,SUM(QZ014) QZ014,CONVERT(FLOAT,QZ012) QZ012,SUM(QZ013) QZ013,QZ017,CONVERT(FLOAT,QZ018) QZ018,SUM(QZ019) QZ019,CONVERT(FLOAT,QZ020) QZ020,SUM(QZ021) QZ021,QZ022,SUM(QZ023) QZ023,QZ024,SUM(QZ025) QZ025,QZ026,SUM(QZ027) QZ027,QZ028,SUM(QZ029) QZ029,QZ030,SUM(QZ039) QZ039,DBA960,CONVERT(FLOAT,QZ015) QZ015,CONVERT(FLOAT,QZ040) QZ040,QZ016,QZ041,CONVERT(FLOAT,QZ042) QZ042,CONVERT(FLOAT,QZ043) QZ043,QZ044,QZ045 FROM R_PQQZ A LEFT JOIN TPADBA B ON A.QZ004=B.DBA002 WHERE QZ002<=(SELECT DISTINCT QZ002 FROM R_PQQZ" );
            strSql . Append ( " WHERE QZ001=@QZ001)" );
            strSql . Append ( " GROUP BY QZ003,QZ004,QZ005,QZ009,QZ011,QZ012,QZ017,QZ018,QZ020,QZ022,QZ024,QZ026,QZ028,QZ030,DBA960,QZ015,QZ040,QZ016,QZ041,QZ042,QZ043,QZ044,QZ045)" );
            strSql . Append ( ",CFT AS(" );
            strSql . Append ( "SELECT B.QZ003,B.QZ004,B.QZ005,B.QZ006,B.QZ007,CONVERT(DECIMAL(18,0),B.QZ008) QZ008,CONVERT(DECIMAL(18,0),CASE WHEN DBA960='男' THEN B.QZ008*B.QZ009 WHEN DBA960='女' THEN B.QZ008*B.QZ015 ELSE B.QZ008*B.QZ040 END) U0,CONVERT(DECIMAL(18,1),CASE WHEN B.QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN B.QZ008*B.QZ009/B.QZ006 WHEN DBA960='女' THEN B.QZ008*B.QZ015/B.QZ006 ELSE B.QZ008*B.QZ040/B.QZ006 END END) U1,CONVERT(DECIMAL(18,0),CASE WHEN DBA960='男' THEN B.QZ006*B.QZ011 WHEN DBA960='女' THEN B.QZ006*B.QZ016 ELSE B.QZ006*B.QZ041 END) U2,CONVERT(DECIMAL(18,0),CASE WHEN B.QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN B.QZ006*B.QZ011/B.QZ006 WHEN DBA960='女' THEN B.QZ006*B.QZ016/B.QZ006 ELSE B.QZ006*B.QZ041/B.QZ006 END END) U3,B.QZ014,CONVERT(DECIMAL(18,1),CASE WHEN B.QZ006=0 THEN 0 ELSE B.QZ014/B.QZ006 END) U4,B.QZ013,CONVERT(DECIMAL(18,0),CASE WHEN DBA960='男' THEN B.QZ013*B.QZ012 WHEN DBA960='女' THEN B.QZ013*B.QZ042 ELSE B.QZ013*B.QZ043 END) U5,CONVERT(DECIMAL(18,1),CASE WHEN B.QZ006=0 THEN 0 ELSE CASE WHEN DBA960='男' THEN B.QZ013*B.QZ012/B.QZ006 WHEN DBA960='女' THEN B.QZ013*B.QZ042/B.QZ006 ELSE B.QZ013*B.QZ043/B.QZ006 END END) U6,CONVERT(DECIMAL(18,0),CASE WHEN DBA960='男' THEN B.QZ006*B.QZ017 WHEN DBA960='女' THEN B.QZ006*B.QZ044 ELSE B.QZ006*B.QZ045 END) U7,B.QZ027,B.QZ027*B.QZ028 U8,B.QZ029,B.QZ029*B.QZ030 U9,B.QZ018,B.QZ019*B.QZ020+B.QZ021*B.QZ022+B.QZ023*B.QZ024+B.QZ025*B.QZ026+B.QZ027*B.QZ028+B.QZ029*B.QZ030 U06 FROM R_PQQZ A LEFT JOIN CET B ON A.QZ003=B.QZ003 AND A.QZ004=B.QZ004" );
            strSql . Append ( " WHERE A.QZ001=@QZ001)" );
            strSql . Append ( " SELECT QZ003,QZ004,QZ005,SUM(QZ006) QZ006,SUM(QZ007) QZ007,SUM(QZ008) QZ008,QZ018,SUM(U0) U0,SUM(U1) U1,SUM(U2) U2,SUM(U3) U3,SUM(QZ014) QZ014,SUM(U4) U4,SUM(QZ013) QZ013,SUM(U5) U5,SUM(U6) U6,SUM(U7) U7,SUM(QZ027) QZ027,SUM(U8) U8,SUM(QZ029) QZ029,SUM(U9) U9,CONVERT(DECIMAL(18,1),SUM(CASE WHEN QZ006=0 THEN U1+U3+U4+U6 ELSE U1+U3+U4+U6+U06/QZ006 END)) U00,SUM(U0+U2+QZ014+U5+U06) U01,SUM(U0+U2+QZ014+U5+U06-U7) U02,SUM(QZ018*(U0+U2+QZ014+U5+U06-U7)) U03,SUM(U7+QZ018*(U0+U2+QZ014+U5+U06-U7)) U04,SUM(CONVERT(DECIMAL(18,0),CASE WHEN QZ006=0 THEN 0 ELSE (U7+QZ018*(U0+U2+QZ014+U5+U9-U7))/QZ006 END)) U05,SUM(CONVERT(DECIMAL(18,1),CASE WHEN QZ006=0 THEN 0 ELSE U06/QZ006 END)) U07,SUM(U0+U2+QZ014+U5+U06-U7-QZ018*(U0+U2+QZ014+U5+U06-U7)) U08,SUM(U06) U06 FROM CFT GROUP BY QZ003,QZ004,QZ005,QZ018 ORDER BY QZ003,QZ004,QZ005" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable PrintTwo ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT QZ001,QZ009,QZ015,QZ040,QZ011,QZ016,QZ041,QZ012,QZ042,QZ043,QZ017,QZ044,QZ045,QZ018,QZ020,QZ028,QZ030,QZ031,CONVERT(VARCHAR(20),QZ032,102) QZ032,QZ033,CASE WHEN QZ033='' OR QZ033 IS NULL THEN '' ELSE CONVERT(VARCHAR(20),QZ034,102) END QZ034 FROM R_PQQZ" );
            strSql . Append ( " WHERE QZ001=@QZ001" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@QZ001",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = oddNum;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
        }

    }
}
