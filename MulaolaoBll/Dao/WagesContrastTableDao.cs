using StudentMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class WagesContrastTableDao
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            bool result = false;
            ArrayList SQLString = new ArrayList( );
            DataTable tableOne = GetDataTableOne( _model.VZ001 ,_model.VZ002 );
            if ( tableOne != null && tableOne.Rows.Count > 0 )
            {
                _model.VZ003 = "R_317";
                _model.VZ004 = string.IsNullOrEmpty( tableOne.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableOne.Rows[0]["GZ1"].ToString( ) );
                if ( Exists( _model ) )
                    SQLString.Add( EditOne( _model ) );
                else
                    SQLString.Add( AddOne( _model ) );
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableTwo = GetDataTableTwo( _model.VZ001 ,_model.VZ002 );
                if ( tableTwo != null && tableTwo.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_317";
                    _model.VZ005 = string.IsNullOrEmpty( tableTwo.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableTwo.Rows[0]["GZ1"].ToString( ) );
                    _model.VZ006 = string.IsNullOrEmpty( tableTwo.Rows[0]["GZ2"].ToString( ) ) == true ? 0 : Convert. ToDecimal ( tableTwo.Rows[0]["GZ2"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditTwo( _model ) );
                    else
                        SQLString.Add( AddTwo( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableTre = GetDataTableTre( _model.VZ001 ,_model.VZ002 );
                if ( tableTre != null && tableTre.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_317";
                    _model.VZ007 = string.IsNullOrEmpty( tableTre.Rows[0]["GZ3"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableTre.Rows[0]["GZ3"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditTre( _model ) );
                    else
                        SQLString.Add( AddTre( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableFor = GetDataTableFor( _model.VZ001 ,_model.VZ002 );
                if ( tableFor != null && tableFor.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_317";
                    _model.VZ008 = string.IsNullOrEmpty( tableFor.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableFor.Rows[0]["GZ1"].ToString( ) );
                    _model.VZ009 = string.IsNullOrEmpty( tableFor.Rows[0]["GZ2"].ToString( ) ) == true ? 0 : Convert. ToDecimal ( tableFor.Rows[0]["GZ2"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditFor( _model ) );
                    else
                        SQLString.Add( AddFor( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableFiv = GetDataTableFiv( _model.VZ001 ,_model.VZ002 );
                if ( tableFiv != null && tableFiv.Rows.Count > 0 )
                {

                    _model.VZ003 = "R_323";
                    _model.VZ005 = string.IsNullOrEmpty( tableFiv.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableFiv.Rows[0]["GZ1"].ToString( ) );
                    _model.VZ006 = string.IsNullOrEmpty( tableFiv.Rows[0]["GZ2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableFiv.Rows[0]["GZ2"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditFiv( _model ) );
                    else
                        SQLString.Add( AddFiv( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }


            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableSix = GetDataTableSix( _model.VZ001 ,_model.VZ002 );
                if ( tableSix != null && tableSix.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_323";
                    _model.VZ008 = string.IsNullOrEmpty( tableSix.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSix.Rows[0]["GZ1"].ToString( ) );
                    _model.VZ009 = string.IsNullOrEmpty( tableSix.Rows[0]["GZ2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSix.Rows[0]["GZ2"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditSix( _model ) );
                    else
                        SQLString.Add( AddSix( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableSev = GetDataTableSev( _model.VZ001 ,_model.VZ002 );
                if ( tableSev != null && tableSev.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_324";
                    //_model.VZ004 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ1"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSev.Rows[0]["GZ1"].ToString( ) );
                    //_model.VZ005 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ2"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSev.Rows[0]["GZ2"].ToString( ) );
                    //_model.VZ006 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ3"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableSev.Rows[0]["GZ3"].ToString( ) );
                    _model.VZ007 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ4"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSev.Rows[0]["GZ4"].ToString( ) );
                    //_model.VZ008 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ5"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableSev.Rows[0]["GZ5"].ToString( ) );
                    //_model.VZ009 = string.IsNullOrEmpty( tableSev.Rows[0]["GZ6"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableSev.Rows[0]["GZ6"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditSev( _model ) );
                    else
                        SQLString.Add( AddSev( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList ( );
                DataTable tableSevS = GetDataTableSevS ( _model . VZ001 , _model . VZ002 );
                if ( tableSevS != null && tableSevS . Rows . Count > 0 )
                {
                    _model . VZ003 = "R_324";
                    _model . VZ004 = string . IsNullOrEmpty ( tableSevS . Rows [ 0 ] [ "GZ1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableSevS . Rows [ 0 ] [ "GZ1" ] . ToString ( ) );
                    _model . VZ005 = string . IsNullOrEmpty ( tableSevS . Rows [ 0 ] [ "GZ2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableSevS . Rows [ 0 ] [ "GZ2" ] . ToString ( ) );
                    _model . VZ006 = string . IsNullOrEmpty ( tableSevS . Rows [ 0 ] [ "GZ3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableSevS . Rows [ 0 ] [ "GZ3" ] . ToString ( ) );

                    _model . VZ008 = string . IsNullOrEmpty ( tableSevS . Rows [ 0 ] [ "GZ5" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableSevS . Rows [ 0 ] [ "GZ5" ] . ToString ( ) );
                    _model . VZ009 = string . IsNullOrEmpty ( tableSevS . Rows [ 0 ] [ "GZ6" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableSevS . Rows [ 0 ] [ "GZ6" ] . ToString ( ) );
                    if ( Exists ( _model ) )
                        SQLString . Add ( EditSevS ( _model ) );
                    else
                        SQLString . Add ( AddSevS ( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableEgi = GetDataTableEgi( _model.VZ001 ,_model.VZ002 );
                if ( tableEgi != null && tableEgi.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_325";
                    _model.VZ006 = string.IsNullOrEmpty( tableEgi.Rows[0]["UZ"].ToString( ) ) == true ? 0 : Convert. ToDecimal ( tableEgi.Rows[0]["UZ"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditEgi( _model ) );
                    else
                        SQLString.Add( AddEgi( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            if ( SQLString != null && SqlHelper.ExecuteSqlTran( SQLString ) )
            {
                result = true;
                SQLString = new ArrayList( );
                DataTable tableNin = GetDataTableNin( _model.VZ001 ,_model.VZ002 );
                if ( tableNin != null && tableNin.Rows.Count > 0 )
                {
                    _model.VZ003 = "R_325";
                    _model.VZ009 = string.IsNullOrEmpty( tableNin.Rows[0]["UZ"].ToString( ) ) == true ? 0 : Convert. ToDecimal ( tableNin.Rows[0]["UZ"].ToString( ) );
                    if ( Exists( _model ) )
                        SQLString.Add( EditNin( _model ) );
                    else
                        SQLString.Add( AddNin( _model ) );
                }
            }
            else
            {
                result = false;
                return result;
            }

            result = SqlHelper.ExecuteSqlTran( SQLString );

            return result;
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQVZ" );
            strSql.Append( " WHERE VZ001=@VZ001 AND VZ002=@VZ002 AND VZ003=@VZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@VZ001",SqlDbType.Int),
                new SqlParameter("@VZ002",SqlDbType.Int),
                new SqlParameter("@VZ003",SqlDbType.NChar,20)
            };
            parameter[0].Value = _model.VZ001;
            parameter[1].Value = _model.VZ002;
            parameter[2].Value = _model.VZ003;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取本月考勤天数 317
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( int year,int month)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14)) GZ1 FROM R_PQW " );
            strSql.Append( " WHERE GZ35=@GZ35 AND GZ24=@GZ24" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ35",SqlDbType.Int),
                new SqlParameter("@GZ24",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddOne ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ004)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ004 );

            return strSql.ToString( );
        }
        public string EditOne ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ004={0}" ,_model.VZ004 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取本月已结天数  已结金额  317
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(GZ1)) GZ1,SUM(GZ2) GZ2 FROM (SELECT SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) GZ1,CONVERT(DECIMAL(18,6),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ2 FROM R_PQW " );
            strSql.Append( " WHERE GZ44=@GZ44 AND GZ28=@GZ28 AND GZ39='执行'" );
            strSql.Append( " GROUP BY GZ01) A" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ44",SqlDbType.Int),
                new SqlParameter("@GZ28",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddTwo ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ005,VZ006)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3},{4})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ005 ,_model.VZ006 );

            return strSql.ToString( );
        }
        public string EditTwo ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ005={0}," ,_model.VZ005 );
            strSql.AppendFormat( "VZ006={0}" ,_model.VZ006 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取累计已结天数  317
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableTre ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14)) GZ3 FROM R_PQW" );
            strSql.Append( " WHERE GZ35=@GZ44 AND GZ24<=@GZ28" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ44",SqlDbType.Int),
                new SqlParameter("@GZ28",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddTre ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ007)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ007 );

            return strSql.ToString( );
        }
        public string EditTre ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ007={0}" ,_model.VZ007 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取 累计已结天数 累计已结金额  317
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableFor ( int year , int month )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,2),SUM(GZ1)) GZ1,SUM(GZ2) GZ2 FROM (SELECT SUM(GZ09+GZ10+GZ11+GZ12+GZ13+GZ14) GZ1,CONVERT(DECIMAL(18,6),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ2 FROM R_PQW " );
            strSql . AppendFormat ( " WHERE  GZ39='执行' AND GZ44={0} AND GZ28<={1}" , year , month );
            strSql . Append ( " GROUP BY GZ01) A" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        public string AddFor ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ008,VZ009)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3},{4})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ008 ,_model.VZ009 );

            return strSql.ToString( );
        }
        public string EditFor ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ008={0}," ,_model.VZ008 );
            strSql.AppendFormat( "VZ009={0}" ,_model.VZ009 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取本月已结天数 本月已结金额  323
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableFiv ( int year ,int month )
        {
            string ez = "";
            if ( month < 10 )
                ez = year.ToString( ) + "0" + month.ToString( );
            else
                ez = year.ToString( ) + month.ToString( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(EZ005+EZ006)) GZ1,SUM(EZ007+EZ008) GZ2 FROM R_PQEZ" );
            strSql.Append( " WHERE EZ004=@EZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ004",SqlDbType.NVarChar)
            };
            parameter[0].Value = ez;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddFiv ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ005,VZ006)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3},{4})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ005 ,_model.VZ006 );

            return strSql.ToString( );
        }
        public string EditFiv ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ005={0}," ,_model.VZ005 );
            strSql.AppendFormat( "VZ006={0}" ,_model.VZ006 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取累计已结天数 累计已结金额  323
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableSix ( int year ,int month )
        {
            string ez = "";
            if ( month < 10 )
                ez = year.ToString( ) + "0" + month.ToString( );
            else
                ez = year.ToString( ) + month.ToString( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),SUM(EZ005+EZ006)) GZ1,SUM(EZ007+EZ008) GZ2 FROM R_PQEZ" );
            strSql.Append( " WHERE EZ004<=@EZ004  AND SUBSTRING(EZ004,0,5)=@YEAR" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ004",SqlDbType.NVarChar),
                new SqlParameter("@YEAR",SqlDbType.NVarChar)
            };
            parameter[0].Value = ez;
            parameter[1].Value = year.ToString( );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddSix ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ008,VZ009)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3},{4})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ008 ,_model.VZ009 );

            return strSql.ToString( );
        }
        public string EditSix ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ008={0}," ,_model.VZ008 );
            strSql.AppendFormat( "VZ009={0}" ,_model.VZ009 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 324 获取累计考勤天数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableSev ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT CONVERT(DECIMAL(18,2),ISNULL(SUM(TZ007),0)) GZ4 FROM R_PQTZ" );
            strSql.Append( " WHERE TZ001=@TZ001 AND TZ002=@TZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@TZ001",SqlDbType.Int),
                new SqlParameter("@TZ002",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddSev ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ007)" );
            strSql.Append( " VALUES (" );
            strSql . AppendFormat ( "{0},{1},'{2}',{3})" , _model . VZ001 , _model . VZ002 , _model . VZ003 , _model . VZ007 );

            return strSql.ToString( );
        }
        public string EditSev ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            //strSql.AppendFormat( "VZ004={0}," ,_model.VZ004 );
            //strSql.AppendFormat( "VZ005={0}," ,_model.VZ005 );
            //strSql.AppendFormat( "VZ006={0}," ,_model.VZ006 );
            strSql.AppendFormat( "VZ007={0}" ,_model.VZ007 );
            //strSql.AppendFormat( "VZ008={0}," ,_model.VZ008 );
            //strSql.AppendFormat( "VZ009={0}" ,_model.VZ009 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 324 获取累计考勤天数以外的其他内容
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableSevS ( int year , int month )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT CONVERT(DECIMAL(18,2),ISNULL(SUM(TZ005),0)) GZ1,CONVERT(DECIMAL(18,2),ISNULL(SUM(TZ006),0)) GZ2,ISNULL(SUM(TZ010),0) GZ3,CONVERT(DECIMAL(18,2),ISNULL(SUM(TZ008),0)) GZ5,ISNULL(SUM(TZ012),0) GZ6 FROM R_PQTZ" );
            strSql . Append ( " WHERE TZ001=@TZ001 AND TZ002=@TZ002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@TZ001",SqlDbType.Int),
                new SqlParameter("@TZ002",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = year;
            parameter [ 1 ] . Value = month;

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) , parameter );
        }
        public string AddSevS ( MulaolaoLibrary . WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQVZ (" );
            strSql . Append ( "VZ001,VZ002,VZ003,VZ004,VZ005,VZ006,VZ008,VZ009)" );
            strSql . Append ( " VALUES (" );
            strSql . AppendFormat ( "{0},{1},'{2}',{3},{4},{5},{6},{7})" , _model . VZ001 , _model . VZ002 , _model . VZ003 , _model . VZ004 , _model . VZ005 , _model . VZ006  , _model . VZ008 , _model . VZ009 );

            return strSql . ToString ( );
        }
        public string EditSevS ( MulaolaoLibrary . WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQVZ SET " );
            strSql . AppendFormat ( "VZ004={0}," , _model . VZ004 );
            strSql . AppendFormat ( "VZ005={0}," , _model . VZ005 );
            strSql . AppendFormat ( "VZ006={0}," , _model . VZ006 );
            //strSql . AppendFormat ( "VZ007={0}," , _model . VZ007 );
            strSql . AppendFormat ( "VZ008={0}," , _model . VZ008 );
            strSql . AppendFormat ( "VZ009={0}" , _model . VZ009 );
            strSql . AppendFormat ( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" , _model . VZ001 , _model . VZ002 , _model . VZ003 );

            return strSql . ToString ( );
        }

        /// <summary>
        /// 本月已结金额 325
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableEgi ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(ISNULL(UZ007,0)+ISNULL(UZ008,0)+ISNULL(UZ009,0)+ISNULL(UZ010,0)+ISNULL(UZ011,0)+ISNULL(UZ012,0)+ISNULL(UZ013,0)+ISNULL(UZ014,0)+ISNULL(UZ015,0)+ISNULL(UZ016,0)+ISNULL(UZ017,0)) UZ FROM R_PQUZ" );
            strSql.Append( " WHERE UZ002=@UZ002 AND UZ003=@UZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@UZ002",SqlDbType.Int),
                new SqlParameter("@UZ003",SqlDbType.Int)
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddEgi ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ006)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ006 );

            return strSql.ToString( );
        }
        public string EditEgi ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ006={0}" ,_model.VZ006 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 累计已结金额 325
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableNin ( int year ,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUM(ISNULL(UZ007,0)+ISNULL(UZ008,0)+ISNULL(UZ009,0)+ISNULL(UZ010,0)+ISNULL(UZ011,0)+ISNULL(UZ012,0)+ISNULL(UZ013,0)+ISNULL(UZ014,0)+ISNULL(UZ015,0)+ISNULL(UZ016,0)+ISNULL(UZ017,0)) UZ FROM R_PQUZ WHERE UZ002=@UZ002 AND UZ003<=@UZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@UZ002",SqlDbType.Int),
                new SqlParameter("@UZ003",SqlDbType.Int),
            };
            parameter[0].Value = year;
            parameter[1].Value = month;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }
        public string AddNin ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQVZ (" );
            strSql.Append( "VZ001,VZ002,VZ003,VZ009)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "{0},{1},'{2}',{3})" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 ,_model.VZ009 );

            return strSql.ToString( );
        }
        public string EditNin ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQVZ SET " );
            strSql.AppendFormat( "VZ009={0}" ,_model.VZ009 );
            strSql.AppendFormat( " WHERE VZ001={0} AND VZ002={1} AND VZ003='{2}'" ,_model.VZ001 ,_model.VZ002 ,_model.VZ003 );

            return strSql.ToString( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQVZ" );
            strSql.Append( " WHERE VZ001=@VZ001 AND VZ002=@VZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@VZ001",SqlDbType.Int),
                new SqlParameter("@VZ002",SqlDbType.Int)
            };
            parameter[0].Value = _model.VZ001;
            parameter[1].Value = _model.VZ002;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.WagesContrastTableLibrary _model )
        {
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "DELETE FROM R_PQVZ" );
            strSq.Append( " WHERE VZ001=@VZ001 AND VZ002=@VZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@VZ001",SqlDbType.Int),
                new SqlParameter("@VZ002",SqlDbType.Int)
            };
            parameter[0].Value = _model.VZ001;
            parameter[1].Value = _model.VZ002;

            int row = SqlHelper.ExecuteNonQuery( strSq.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }
    }
}
