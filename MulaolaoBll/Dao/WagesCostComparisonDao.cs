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
    public class WagesCostComparisonDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTable (int year,int month )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT GZ16,GZ22,GZ01,GZ34,CONVERT(DECIMAL(18,6),SUM(GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14))) GZ,GX04,GZ28,GZ44 FROM R_PQW A LEFT JOIN R_PQAA B ON A.GZ04=B.GX02" );
            strSql.AppendFormat( " WHERE GZ44={0} AND GZ28={1}  AND GZ39='执行'" ,year ,month );
            strSql.Append( " GROUP BY GZ16,GZ22,GZ01,GZ34,GX04,GZ28,GZ44" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert (MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            bool result = false;
            bool over = false;
            DataTable daTable = GetDataTable( _model.UZ002 ,_model.UZ003 );
            Hashtable SQLString = new Hashtable ( );

            if ( daTable . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < daTable . Rows . Count ; i++ )
                {
                    _model . UZ007 = _model . UZ008 = _model . UZ009 = _model . UZ010 = _model . UZ011 = _model . UZ012 = _model . UZ013 = _model . UZ014 = _model . UZ015 = _model . UZ016 = _model . UZ017 = 0;
                    _model . UZ004 = daTable . Rows [ i ] [ "GZ22" ] . ToString ( );
                    _model . UZ005 = daTable . Rows [ i ] [ "GZ01" ] . ToString ( );
                    _model . UZ018 = daTable . Rows [ i ] [ "GZ16" ] . ToString ( );
                    _model . UZ006 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ34" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( daTable . Rows [ i ] [ "GZ34" ] . ToString ( ) );

                    //result = Exists( _model );
                    //if ( result == true )
                    //{
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "白坯" )
                    //    {
                    //        _model.UZ007 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz007( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "砂光" )
                    //    {
                    //        _model.UZ008 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz008( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "粘接" )
                    //    {
                    //        _model.UZ009 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz009( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "组装" )
                    //    {
                    //        _model.UZ010 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz010( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "检验" )
                    //    {
                    //        _model.UZ011 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz011( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "后道辅助" )
                    //    {
                    //        _model.UZ012 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz012( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "包装" )
                    //    {
                    //        _model.UZ013 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz013( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "修理" )
                    //    {
                    //        _model.UZ014 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz014( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "返工" )
                    //    {
                    //        _model.UZ015 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz015( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "样品" )
                    //    {
                    //        _model.UZ016 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz016( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //    if ( daTable.Rows[i]["GX04"].ToString( ) == "杂工" )
                    //    {
                    //        _model.UZ017 = string.IsNullOrEmpty( daTable.Rows[i]["GZ"].ToString( ) ) == true ? 0 : Convert.ToInt32( daTable.Rows[i]["GZ"].ToString( ) );
                    //        result = UpdateUz017( _model );
                    //        if ( result == true )
                    //            over = true;
                    //        else
                    //        {
                    //            over = false;
                    //            return over;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "白坯" )
                        _model . UZ007 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "砂光" )
                        _model . UZ008 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "粘接" )
                        _model . UZ009 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "组装" )
                        _model . UZ010 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "检验" )
                        _model . UZ011 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "后道辅助" )
                        _model . UZ012 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "包装" )
                        _model . UZ013 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "修理" )
                        _model . UZ014 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "返工" )
                        _model . UZ015 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "样品" )
                        _model . UZ016 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    if ( daTable . Rows [ i ] [ "GX04" ] . ToString ( ) == "杂工" )
                        _model . UZ017 = string . IsNullOrEmpty ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daTable . Rows [ i ] [ "GZ" ] . ToString ( ) );
                    //result = Add( _model );
                    //if ( result == false )
                    //{
                    //    result = false;
                    //    return result;
                    //}
                    //else
                    //    result = true;
                    Add ( _model ,SQLString );

                    //}                          
                }

                return SqlHelper . ExecuteSqlTran ( SQLString );
            }
            else
                return false;       
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQUZ" );
            strSql.Append( " WHERE UZ002=@UZ002 AND UZ003=@UZ003 AND UZ005=@UZ005 AND UZ018=@UZ018" );
            SqlParameter[] parameter = {
                new SqlParameter("@UZ002",SqlDbType.Int),
                new SqlParameter("@UZ003",SqlDbType.Int),
                new SqlParameter("@UZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@UZ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.UZ002;
            parameter[1].Value = _model.UZ003;
            parameter[2].Value = _model.UZ005;
            parameter[3].Value = _model.UZ018;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateUz007 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ007='{0}'" ,_model.UZ007 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz008 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ008='{0}'" ,_model.UZ008 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz009 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ009='{0}'" ,_model.UZ009 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz010 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ010='{0}'" ,_model.UZ010 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz011 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ011='{0}'" ,_model.UZ011 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz012 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ012='{0}'" ,_model.UZ012 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz013 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ013='{0}'" ,_model.UZ013 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz014 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ014='{0}'" ,_model.UZ014 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz015 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ015='{0}'" ,_model.UZ015 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz016 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ016='{0}'" ,_model.UZ016 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }
        public bool UpdateUz017 ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQUZ SET " );
            strSql.AppendFormat( "UZ017='{0}'" ,_model.UZ017 );
            strSql.AppendFormat( " WHERE UZ002='{0}'" ,_model.UZ002 );
            strSql.AppendFormat( " AND UZ003='{0}'" ,_model.UZ003 );
            strSql.AppendFormat( " AND UZ005='{0}'" ,_model.UZ005 );
            strSql.AppendFormat( " AND UZ018='{0}'" ,_model.UZ018 );

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public void Add ( MulaolaoLibrary.WagesCostComparisonLibrary _model ,Hashtable SQLString )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQUZ (" );
            strSql.Append( "UZ001,UZ002,UZ003,UZ004,UZ005,UZ006,UZ007,UZ008,UZ009,UZ010,UZ011,UZ012,UZ013,UZ014,UZ015,UZ016,UZ017,UZ018)" );
            strSql.Append( " VALUES (" );
            strSql.AppendFormat( "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')" ,_model.UZ001 ,_model.UZ002 ,_model.UZ003 ,_model.UZ004 ,_model.UZ005 ,_model.UZ006 ,_model.UZ007 ,_model.UZ008 ,_model.UZ009 ,_model.UZ010 ,_model.UZ011 ,_model.UZ012 ,_model.UZ013 ,_model.UZ014 ,_model.UZ015 ,_model.UZ016 ,_model.UZ017 ,_model.UZ018 );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( MulaolaoLibrary.WagesCostComparisonLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQUZ" );
            strSql.Append( " WHERE UZ002=@UZ002 AND UZ003=@UZ003" );
            SqlParameter[] paratemeter = {
                new SqlParameter("@UZ002",SqlDbType.Int),
                new SqlParameter("@UZ003",SqlDbType.Int)
            };
            paratemeter[0].Value = _model.UZ002;
            paratemeter[1].Value = _model.UZ003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,paratemeter );
        }
        public DataTable GetDataTable ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQUZ" );
            strSql.Append( " WHERE UZ001=@UZ001" );
            SqlParameter[] paratemeter = {
                new SqlParameter("@UZ001",SqlDbType.NVarChar,20)
            };
            paratemeter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,paratemeter );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete (string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQUZ" );
            strSql.Append( " WHERE UZ001=@UZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@UZ001",SqlDbType.NVarChar,20)
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
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT UZ001,UZ002,UZ003 FROM R_PQUZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT UZ001,UZ002,UZ003 FROM R_PQUZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT UZ001,UZ002,UZ003 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.UZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQUZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WagesCostComparisonLibrary GetModel ( int idx)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQUZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
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
        public MulaolaoLibrary.WagesCostComparisonLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.WagesCostComparisonLibrary _model = new MulaolaoLibrary.WagesCostComparisonLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["UZ001"] != null && row["UZ001"].ToString( ) != "" )
                    _model.UZ001 = row["UZ001"].ToString( );
                if ( row["UZ002"] != null && row["UZ002"].ToString( ) != "" )
                    _model.UZ002 = int.Parse( row["UZ002"].ToString( ) );
                if ( row["UZ003"] != null && row["UZ003"].ToString( ) != "" )
                    _model.UZ003 = int.Parse( row["UZ003"].ToString( ) );
                if ( row["UZ004"] != null && row["UZ004"].ToString( ) != "" )
                    _model.UZ004 = row["UZ004"].ToString( );
                if ( row["UZ005"] != null && row["UZ005"].ToString( ) != "" )
                    _model.UZ005 = row["UZ005"].ToString( );
                if ( row["UZ006"] != null && row["UZ006"].ToString( ) != "" )
                    _model.UZ006 = int.Parse( row["UZ006"].ToString( ) );
                if ( row["UZ007"] != null && row["UZ007"].ToString( ) != "" )
                    _model.UZ007 = decimal.Parse( row["UZ007"].ToString( ) );
                if ( row["UZ008"] != null && row["UZ008"].ToString( ) != "" )
                    _model.UZ008 = decimal . Parse( row["UZ008"].ToString( ) );
                if ( row["UZ009"] != null && row["UZ009"].ToString( ) != "" )
                    _model.UZ009 = decimal . Parse( row["UZ009"].ToString( ) );
                if ( row["UZ010"] != null && row["UZ010"].ToString( ) != "" )
                    _model.UZ010 = decimal . Parse( row["UZ010"].ToString( ) );
                if ( row["UZ011"] != null && row["UZ011"].ToString( ) != "" )
                    _model.UZ011 = decimal . Parse( row["UZ011"].ToString( ) );
                if ( row["UZ012"] != null && row["UZ012"].ToString( ) != "" )
                    _model.UZ012 = decimal . Parse( row["UZ012"].ToString( ) );
                if ( row["UZ013"] != null && row["UZ013"].ToString( ) != "" )
                    _model.UZ013 = decimal.Parse( row["UZ013"].ToString( ) );
                if ( row["UZ014"] != null && row["UZ014"].ToString( ) != "" )
                    _model.UZ014 = decimal . Parse( row["UZ014"].ToString( ) );
                if ( row["UZ015"] != null && row["UZ015"].ToString( ) != "" )
                    _model.UZ015 = decimal . Parse( row["UZ015"].ToString( ) );
                if ( row["UZ016"] != null && row["UZ016"].ToString( ) != "" )
                    _model.UZ016 = decimal . Parse( row["UZ016"].ToString( ) );
                if ( row["UZ017"] != null && row["UZ017"].ToString( ) != "" )
                    _model.UZ017 = decimal . Parse( row["UZ017"].ToString( ) );
                if ( row["UZ018"] != null && row["UZ018"].ToString( ) != "" )
                    _model.UZ018 = row["UZ018"].ToString( );
            }

            return _model;
        }
    }
}
