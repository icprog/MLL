using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using StudentMgr;
using System.Data.SqlClient;
using System.Collections;

namespace MulaolaoBll.Dao
{
    public class WorkWagesDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( int year,int month,string yearMonth)
        {
            /*
            SELECT A.GZ16 U12,A.GZ37 U11,A.U0,CONVERT(DECIMAL(6,1),ISNULL(U2,0)) U2,CONVERT(DECIMAL(18,1),ISNULL(U4,0)) U4,CONVERT(DECIMAL(18,1),ISNULL(U7,0)) U7,CONVERT(DECIMAL(18,1),ISNULL(U9,0)) U9,CONVERT(DECIMAL(18,1),ISNULL(U3,0)) U3,CONVERT(DECIMAL(18,1),ISNULL(U5,0)) U5,CONVERT(DECIMAL(18,1),ISNULL(U8,0)) U8,CONVERT(DECIMAL(18,1),ISNULL(U10,0)) U10 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U2,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U7  FROM R_PQW WHERE GZ24=@GZ24 AND GZ35=@GZ35 GROUP BY GZ02,GZ16,GZ37) A LEFT JOIN (SELECT GZ16,GZ37,U0,SUM(U4) U4,SUM(U9) U9 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U4,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U9,CONVERT(VARCHAR(10),GZ35)+CASE WHEN GZ24<10 THEN '0'+CONVERT(VARCHAR(10),GZ24) ELSE CONVERT(VARCHAR(10),GZ24) END GZ24 FROM R_PQW GROUP BY GZ02,GZ35,GZ24,GZ16,GZ37) B WHERE GZ24<=@GZ GROUP BY U0,GZ16,GZ37) C ON A.U0=C.U0 AND A.GZ16=C.GZ16 AND A.GZ37=C.GZ37 LEFT JOIN (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U3,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U8 FROM R_PQW WHERE idx in (SELECT FZ002 FROM R_PQFZ A1 LEFT JOIN R_PQEZ A2 ON A1.FZ001=A2.idx LEFT JOIN R_REVIEWS A3 ON A2.EZ001=A3.RES06 AND RES05='执行') AND GZ24=@GZ24 AND GZ35=@GZ35 GROUP BY GZ16,GZ37,GZ02) D ON A.GZ16=D.GZ16 AND A.GZ37=D.GZ37 AND A.U0=D.U0 LEFT JOIN (SELECT GZ16,GZ37,U0,SUM(U5) U5,SUM(U10) U10 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U5,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U10,CONVERT(VARCHAR(10),GZ35)+CASE WHEN GZ24<10 THEN '0'+CONVERT(VARCHAR(10),GZ24) ELSE CONVERT(VARCHAR(10),GZ24) END GZ24 FROM R_PQW WHERE idx in (SELECT FZ002 FROM R_PQFZ A1 LEFT JOIN R_PQEZ A2 ON A1.FZ001=A2.idx LEFT JOIN R_REVIEWS A3 ON A2.EZ001=A3.RES06 AND RES05='执行') GROUP BY GZ02,GZ35,GZ24,GZ16,GZ37) B WHERE GZ24<=@GZ GROUP BY U0,GZ16,GZ37) E ON A.U0=E.U0 AND A.GZ16=E.GZ16 AND A.GZ37=E.GZ37
            */
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.GZ16 U12,A.GZ37 U11,A.U0,CONVERT(DECIMAL(6,1),ISNULL(U2,0)) U2,CONVERT(DECIMAL(18,1),ISNULL(U4,0)) U4,CONVERT(DECIMAL(18,1),ISNULL(U7,0)) U7,CONVERT(DECIMAL(18,1),ISNULL(U9,0)) U9,CONVERT(DECIMAL(18,1),ISNULL(U3,0)) U3,CONVERT(DECIMAL(18,1),ISNULL(U5,0)) U5,CONVERT(DECIMAL(18,1),ISNULL(U8,0)) U8,CONVERT(DECIMAL(18,1),ISNULL(U10,0)) U10 FROM " );
            strSql.Append( "(SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U2,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U7  FROM R_PQW " );
            strSql.Append( " WHERE GZ24=@GZ24 AND GZ35=@GZ35 " );
            strSql.Append( " GROUP BY GZ02,GZ16,GZ37) A " );
            strSql.Append( " LEFT JOIN " );
            strSql.Append( " (SELECT GZ16,GZ37,U0,SUM(U4) U4,SUM(U9) U9 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U4,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U9,CONVERT(VARCHAR(10),GZ35)+CASE WHEN GZ24<10 THEN '0'+CONVERT(VARCHAR(10),GZ24) ELSE CONVERT(VARCHAR(10),GZ24) END GZ24 FROM R_PQW " );
            strSql.Append( " GROUP BY GZ02,SGZ35,GZ24,GZ16,GZ37) B " );
            strSql.Append( " WHERE GZ24<=@GZ " );
            strSql.Append( " GROUP BY U0,GZ16,GZ37) C" );
            strSql.Append( " ON A.U0=C.U0 AND A.GZ16=C.GZ16 AND A.GZ37=C.GZ37" );
            strSql.Append( " LEFT JOIN " );
            strSql.Append( " (SELECT EZ011,EZ014,EZ003,SUM(EZ005+EZ006) U3,SUM(EZ007+EZ008) U8 FROM R_PQEZ " );
            strSql.Append( " WHERE EZ004=@GZ" );
            strSql.Append( " GROUP BY EZ011,EZ014,EZ003) D " );
            strSql.Append( " ON A.GZ16=D.EZ011 AND A.GZ37=D.EZ014 AND A.U0=D.EZ003 " );
            strSql.Append( " LEFT JOIN" );
            strSql.Append( " (SELECT EZ011,EZ014,EZ003,SUM(EZ005+EZ006) U5,SUM(EZ007+EZ008) U10 FROM R_PQEZ  " );
            strSql.Append( " WHERE EZ004<=@GZ " );
            strSql.Append( " GROUP BY EZ011,EZ014,EZ003) E " );
            strSql.Append( " ON A.U0=E.EZ003 AND A.GZ16=E.EZ011 AND A.GZ37=E.EZ014" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ35",SqlDbType.Int),
                new SqlParameter("@GZ",SqlDbType.NVarChar)
            };
            parameter[0].Value = month;
            parameter[1].Value = year;
            parameter[2].Value = yearMonth;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( string yearMonth )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT C.GZ16 U12,C.GZ37 U11,C.U0,CONVERT(DECIMAL(18,1),ISNULL(U4,0)) U4,CONVERT(DECIMAL(18,1),ISNULL(U9,0)) U9,CONVERT(DECIMAL(18,1),ISNULL(U5,0)) U5,CONVERT(DECIMAL(18,1),ISNULL(U10,0)) U10 FROM " );
            strSql.Append( " (SELECT GZ16,GZ37,U0,SUM(U4) U4,SUM(U9) U9 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U4,SUM(GZ06*GZ25+GZ36*(GZ12+GZ13+GZ14)) U9,CONVERT(VARCHAR(10),GZ35)+CASE WHEN GZ24<10 THEN '0'+CONVERT(VARCHAR(10),GZ24) ELSE CONVERT(VARCHAR(10),GZ24) END GZ24 FROM R_PQW " );
            strSql.Append( " GROUP BY GZ02,GZ35,GZ24,GZ16,GZ37) B " );
            strSql.Append( " WHERE GZ24<=@GZ " );
            strSql.Append( " GROUP BY U0,GZ16,GZ37) C" );
            strSql.Append( " LEFT JOIN " );
            strSql.Append( " (SELECT EZ011,EZ014,EZ003,SUM(EZ005+EZ006) U5,SUM(EZ007+EZ008) U10 FROM R_PQEZ " );
            strSql.Append( " WHERE EZ004<=@GZ " );
            strSql.Append( " GROUP BY EZ011,EZ014,EZ003) E " );
            strSql.Append( " ON A.U0=E.EZ003 AND A.GZ16=E.EZ011 AND A.GZ37=E.EZ014" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ",SqlDbType.NVarChar)
            };
            parameter[0].Value = yearMonth;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public bool Exists ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQW" );
            strSql.Append( " WHERE GZ24=@GZ24 AND GZ35=@GZ35" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ35",SqlDbType.Int)
            };
            parameter[0].Value = month;
            parameter[1].Value = year;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQTZ" );
            strSql.Append( " WHERE TZ001=@TZ001 AND TZ002=@TZ002 AND TZ003=@TZ003 AND TZ013=@TZ013 AND TZ014=@TZ014" );
            SqlParameter[] parameter = {
                new SqlParameter("@TZ001",SqlDbType.Int),
                new SqlParameter("@TZ002",SqlDbType.Int),
                new SqlParameter("@TZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@TZ013",SqlDbType.NVarChar,20),
                new SqlParameter("@TZ014",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.TZ001;
            parameter[1].Value = _model.TZ002;
            parameter[2].Value = _model.TZ003;
            parameter[3].Value = _model.TZ013;
            parameter[4].Value = _model.TZ014;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 317本月考勤和工资
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableOne ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            ArrayList SQLString = new ArrayList( );
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ16,GZ37,U0,SUM(U2) U2,SUM(U7) U7 FROM (SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U2,SUM(CONVERT(DECIMAL(18,6),GZ06*GZ25*GZ41)+CONVERT(DECIMAL(18,6),GZ36*(GZ12+GZ13+GZ14))) U7  FROM R_PQW  " );
            strSql.Append( " WHERE GZ24=@GZ24 AND GZ35=@GZ35 " );
            //strSql . Append ( " WHERE GZ44=@GZ44 AND GZ28=@GZ28" );
            strSql.Append( " GROUP BY GZ02,GZ16,GZ37,GZ01) A GROUP BY GZ16,GZ37,U0 " );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ35",SqlDbType.Int)
            };
            parameter[0].Value = _model.TZ002;
            parameter[1].Value = _model.TZ001;

            DataTable tableOne = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( tableOne.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableOne.Rows.Count ; i++ )
                {
                    _model.TZ003 = tableOne.Rows[i]["U0"].ToString( );
                    _model.TZ005 = string.IsNullOrEmpty( tableOne.Rows[i]["U2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableOne.Rows[i]["U2"].ToString( ) );
                    _model.TZ009 = string.IsNullOrEmpty( tableOne.Rows[i]["U7"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableOne.Rows[i]["U7"].ToString( ) );
                    _model.TZ013 = tableOne.Rows[i]["GZ16"].ToString( );
                    _model.TZ014 = tableOne.Rows[i]["GZ37"].ToString( );
                    result = Exists( _model );
                    if ( result == true )
                        SQLString.Add( UpdateOne( _model ) );
                    else
                        SQLString.Add( AddOne( _model ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }
        
        public string AddOne ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQTZ (" );
            strSql.Append( "TZ001,TZ002,TZ003,TZ005,TZ009,TZ013,TZ014,TZ015)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,_model.TZ001 ,_model.TZ002 ,_model.TZ003 ,_model.TZ005 ,_model.TZ009 ,_model.TZ013 ,_model.TZ014 ,_model.TZ015 );

            return strSql.ToString( );
        }
        public string UpdateOne ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQTZ SET " );
            strSql.AppendFormat( "TZ005='{0}'," ,_model.TZ005 );
            strSql.AppendFormat( "TZ009='{0}'" ,_model.TZ009 );
            strSql.AppendFormat( " WHERE TZ001='{0}'" ,_model.TZ001 );
            strSql.AppendFormat( " AND TZ002='{0}'" ,_model.TZ002 );
            strSql.AppendFormat( " AND TZ003='{0}'" ,_model.TZ003 );
            strSql.AppendFormat( " AND TZ013='{0}'" ,_model.TZ013 );
            strSql.AppendFormat( " AND TZ014='{0}'" ,_model.TZ014 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 317本月以及本月以前的考勤和工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableTwo ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ16,GZ37,GZ02 U0,CONVERT(DECIMAL(18,2),SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14)) U4,SUM(CONVERT(DECIMAL(18,6),GZ06*GZ25*GZ41)+CONVERT(DECIMAL(18,6),GZ36*(GZ12+GZ13+GZ14))) U9 FROM R_PQW " );
            strSql.Append( " WHERE GZ24<=@GZ24 AND GZ35=@GZ35" );
            strSql.Append( " GROUP BY GZ16,GZ37,GZ02" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ35",SqlDbType.Int)
            };
            parameter[0].Value = _model.TZ002;
            parameter[1].Value = _model.TZ001;

            DataTable tableTwo = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
                      
            if ( tableTwo.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableTwo.Rows.Count ; i++ )
                {
                    _model.TZ003 = tableTwo.Rows[i]["U0"].ToString( );
                    _model.TZ007 = string.IsNullOrEmpty( tableTwo.Rows[i]["U4"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableTwo.Rows[i]["U4"].ToString( ) );
                    _model.TZ011 = string.IsNullOrEmpty( tableTwo.Rows[i]["U9"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableTwo.Rows[i]["U9"].ToString( ) );
                    _model.TZ013 = tableTwo.Rows[i]["GZ16"].ToString( );
                    _model.TZ014 = tableTwo.Rows[i]["GZ37"].ToString( );
                    result = Exists( _model );
                    if ( result == true )
                        SQLString.Add( UpdateTwo( _model ) );
                    else
                        SQLString.Add( AddTwo( _model ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public string AddTwo ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQTZ (" );
            strSql.Append( "TZ001,TZ002,TZ003,TZ007,TZ011,TZ013,TZ014,TZ015)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,_model.TZ001 ,_model.TZ002 ,_model.TZ003 ,_model.TZ007 ,_model.TZ011 ,_model.TZ013 ,_model.TZ014 ,_model.TZ015 );

            return strSql.ToString( );
        }
        public string UpdateTwo ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQTZ SET " );
            strSql.AppendFormat( "TZ007='{0}'," ,_model.TZ007 );
            strSql.AppendFormat( "TZ011='{0}'" ,_model.TZ011 );
            strSql.AppendFormat( " WHERE TZ001='{0}'" ,_model.TZ001 );
            strSql.AppendFormat( " AND TZ002='{0}'" ,_model.TZ002 );
            strSql.AppendFormat( " AND TZ003='{0}'" ,_model.TZ003 );
            strSql.AppendFormat( " AND TZ013='{0}'" ,_model.TZ013 );
            strSql.AppendFormat( " AND TZ014='{0}'" ,_model.TZ014 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 323本月考勤及工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableTre ( MulaolaoLibrary.WorkWagesLibrary _model ,string yearMonth )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT EZ011,EZ014,EZ003,SUM(EZ005+EZ006) U3,SUM(EZ007+EZ008) U8 FROM R_PQEZ" );
            strSql.Append( " WHERE EZ004=@EZ004" );
            strSql.Append( " GROUP BY EZ011,EZ014,EZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ004",SqlDbType.NVarChar)
            };
            parameter[0].Value = yearMonth;

            DataTable tableTre = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( tableTre . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableTre . Rows . Count ; i++ )
                {
                    _model . TZ003 = tableTre . Rows [ i ] [ "EZ003" ] . ToString ( );
                    _model . TZ006 = string . IsNullOrEmpty ( tableTre . Rows [ i ] [ "U3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableTre . Rows [ i ] [ "U3" ] . ToString ( ) );
                    _model . TZ010 = string . IsNullOrEmpty ( tableTre . Rows [ i ] [ "U8" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableTre . Rows [ i ] [ "U8" ] . ToString ( ) );
                    _model . TZ013 = tableTre . Rows [ i ] [ "EZ011" ] . ToString ( );
                    _model . TZ014 = tableTre . Rows [ i ] [ "EZ014" ] . ToString ( );
                    result = Exists ( _model );
                    if ( result == true )
                        SQLString . Add ( UpdateTre ( _model ) );
                    else
                        SQLString . Add ( AddTre ( _model ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public string AddTre ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQTZ (" );
            strSql.Append( "TZ001,TZ002,TZ003,TZ006,TZ010,TZ013,TZ014,TZ015)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,_model.TZ001 ,_model.TZ002 ,_model.TZ003 ,_model.TZ006 ,_model.TZ010 ,_model.TZ013 ,_model.TZ014 ,_model.TZ015 );

            return strSql.ToString( );
        }
        public string UpdateTre ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQTZ SET " );
            strSql.AppendFormat( "TZ006='{0}'," ,_model.TZ006 );
            strSql.AppendFormat( "TZ010='{0}'" ,_model.TZ010 );
            strSql.AppendFormat( " WHERE TZ001='{0}'" ,_model.TZ001 );
            strSql.AppendFormat( " AND TZ002='{0}'" ,_model.TZ002 );
            strSql.AppendFormat( " AND TZ003='{0}'" ,_model.TZ003 );
            strSql.AppendFormat( " AND TZ013='{0}'" ,_model.TZ013 );
            strSql.AppendFormat( " AND TZ014='{0}'" ,_model.TZ014 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 323本月以及本月以前的考勤和工资  317累计已结天数和工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableFor ( MulaolaoLibrary.WorkWagesLibrary _model, string yearMonth )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ16,GZ37,GZ02 U0,SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) U4,CONVERT(DECIMAL(18,6),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) U9 FROM R_PQW WHERE GZ39='执行'" );
            strSql.Append( " AND GZ44=@GZ44 AND GZ28<=@GZ28" );
            strSql.Append( " GROUP BY GZ02,GZ16,GZ37 ORDER BY GZ16" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ44",SqlDbType.Int),
                new SqlParameter("@GZ28",SqlDbType.Int)
            };
            parameter[0].Value = _model.TZ001;
            parameter[1].Value = _model.TZ002;

            DataTable tableFor = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( tableFor.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < tableFor.Rows.Count ; i++ )
                {
                    _model.TZ003 = tableFor.Rows[i]["U0"].ToString( );
                    _model.TZ008 = string.IsNullOrEmpty( tableFor.Rows[i]["U4"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableFor.Rows[i]["U4"].ToString( ) );
                    _model.TZ012 = string.IsNullOrEmpty( tableFor.Rows[i]["U9"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableFor.Rows[i]["U9"].ToString( ) );
                    _model.TZ013 = tableFor.Rows[i]["GZ16"].ToString( );
                    _model.TZ014 = tableFor.Rows[i]["GZ37"].ToString( );
                    result = Exists( _model );
                    if ( result == true )
                        SQLString.Add( UpdateFor( _model ) );
                    else
                        SQLString.Add( AddFor( _model ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        public string AddFor ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQTZ (" );
            strSql.Append( "TZ001,TZ002,TZ003,TZ008,TZ012,TZ013,TZ014,TZ015)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')" ,_model.TZ001 ,_model.TZ002 ,_model.TZ003 ,_model.TZ008 ,_model.TZ012 ,_model.TZ013 ,_model.TZ014 ,_model.TZ015 );

            return strSql.ToString( );
        }
        public string UpdateFor ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQTZ SET " );
            strSql.AppendFormat( "TZ008='{0}'," ,_model.TZ008 );
            strSql.AppendFormat( "TZ012='{0}'" ,_model.TZ012 );
            strSql.AppendFormat( " WHERE TZ001='{0}'" ,_model.TZ001 );
            strSql.AppendFormat( " AND TZ002='{0}'" ,_model.TZ002 );
            strSql.AppendFormat( " AND TZ003='{0}'" ,_model.TZ003 );
            strSql.AppendFormat( " AND TZ013='{0}'" ,_model.TZ013 );
            strSql.AppendFormat( " AND TZ014='{0}'" ,_model.TZ014 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQTZ" );
            strSql.Append( " WHERE TZ015=@TZ015" );
            SqlParameter[] parameter = {
                new SqlParameter("@TZ015",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTables ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQTZ" );
            strSql.Append( " WHERE TZ015=@TZ015" );
            SqlParameter[] parameter = {
                new SqlParameter("@TZ015",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT TZ001,TZ002,TZ015 FROM R_PQTZ" );
            strSql.Append( " ORDER BY TZ015 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT TZ015,TZ001,TZ002 FROM R_PQTZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT TZ001,TZ002,TZ015 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.TZ015 DESC)" );
            strSql.Append( " AS Row,T.* FROM R_PQTZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.AppendFormat( ") TT LEFT JOIN R_REVIEWS A ON TT.TZ015=A.RES06 ORDER BY TZ001,TZ002 " ,startIndex ,endIndex );//WHERE TT.Row BETWEEN {0} AND {1}

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WorkWagesLibrary GetModel ( int idx)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQTZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WorkWagesLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.WorkWagesLibrary _model = new MulaolaoLibrary.WorkWagesLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["TZ001"] != null && row["TZ001"].ToString( ) != "" )
                    _model.TZ001 = int.Parse( row["TZ001"].ToString( ) );
                if ( row["TZ002"] != null && row["TZ002"].ToString( ) != "" )
                    _model.TZ002 = int.Parse( row["TZ002"].ToString( ) );
                if ( row["TZ003"] != null && row["TZ003"].ToString( ) != "" )
                    _model.TZ003 = row["TZ003"].ToString( );
                if ( row["TZ004"] != null && row["TZ004"].ToString( ) != "" )
                    _model.TZ004 = row["TZ004"].ToString( );
                if ( row["TZ005"] != null && row["TZ005"].ToString( ) != "" )
                    _model.TZ005 = decimal.Parse( row["TZ005"].ToString( ) );
                if ( row["TZ006"] != null && row["TZ006"].ToString( ) != "" )
                    _model.TZ006 = decimal.Parse( row["TZ006"].ToString( ) );
                if ( row["TZ007"] != null && row["TZ007"].ToString( ) != "" )
                    _model.TZ007 = decimal.Parse( row["TZ007"].ToString( ) );
                if ( row["TZ008"] != null && row["TZ008"].ToString( ) != "" )
                    _model.TZ008 = decimal.Parse( row["TZ008"].ToString( ) );
                if ( row["TZ009"] != null && row["TZ009"].ToString( ) != "" )
                    _model.TZ009 = decimal . Parse( row["TZ009"].ToString( ) );
                if ( row["TZ010"] != null && row["TZ010"].ToString( ) != "" )
                    _model.TZ010 = decimal . Parse( row["TZ010"].ToString( ) );
                if ( row["TZ011"] != null && row["TZ011"].ToString( ) != "" )
                    _model.TZ011 = decimal . Parse( row["TZ011"].ToString( ) );
                if ( row["TZ012"] != null && row["TZ012"].ToString( ) != "" )
                    _model.TZ012 = decimal . Parse( row["TZ012"].ToString( ) );
                if ( row["TZ013"] != null && row["TZ013"].ToString( ) != "" )
                    _model.TZ013 = row["TZ013"].ToString( );
                if ( row["TZ014"] != null && row["TZ014"].ToString( ) != "" )
                    _model.TZ014 = row["TZ014"].ToString( );
                if ( row["TZ015"] != null && row["TZ015"].ToString( ) != "" )
                    _model.TZ015 = row["TZ015"].ToString( );
            }

            return _model;
        }
    }
}
