using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;

namespace MulaolaoBll.Dao
{
    public class OtherExpenseStatementDao
    {
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary . OtherExpenseStatementLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM R_PQBE WHERE BE002=@BE002 AND BE007=@BE007 AND BE008=@BE008 AND BE009=@BE009 AND BE010=@BE010 AND BE011=@BE011 AND BE012=@BE012 AND BE016=@BE016" );
            SqlParameter [ ] parameter ={
                new SqlParameter("@BE002",SqlDbType.NVarChar,20),
                new SqlParameter("@BE007",SqlDbType.Decimal,11),
                new SqlParameter("@BE008",SqlDbType.Decimal,11),
                new SqlParameter("@BE009",SqlDbType.Decimal,11),
                new SqlParameter("@BE010",SqlDbType.Decimal,11),
                new SqlParameter("@BE011",SqlDbType.Decimal,11),
                new SqlParameter("@BE012",SqlDbType.Decimal,11),
                new SqlParameter("@BE016",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = _model . BE002;
            parameter [ 1 ] . Value = _model . BE007;
            parameter [ 2 ] . Value = _model . BE008;
            parameter [ 3 ] . Value = _model . BE009;
            parameter [ 4 ] . Value = _model . BE010;
            parameter [ 5 ] . Value = _model . BE011;
            parameter [ 6 ] . Value = _model . BE012;
            parameter [ 7 ] . Value = _model . BE016;

            return SqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Insert ( MulaolaoLibrary . OtherExpenseStatementLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQBE (" );
            strSql . Append ( "BE001,BE002,BE003,BE004,BE005,BE006,BE007,BE008,BE009,BE010,BE011,BE012,BE015,BE016,BE017)" );
            strSql . Append ( " VALUES (" );
            strSql . Append ( "@BE001,@BE002,@BE003,@BE004,@BE005,@BE006,@BE007,@BE008,@BE009,@BE010,@BE011,@BE012,@BE015,@BE016,@BE017);" );
            strSql . Append ( "SELECT SCOPE_IDENTITY();" );
            SqlParameter [ ] parameter ={
                new SqlParameter("@BE001",SqlDbType.NVarChar,20),
                new SqlParameter("@BE002",SqlDbType.NVarChar,20),
                new SqlParameter("@BE003",SqlDbType.NVarChar,20),
                new SqlParameter("@BE004",SqlDbType.NVarChar,20),
                new SqlParameter("@BE005",SqlDbType.Int),
                new SqlParameter("@BE006",SqlDbType.NVarChar,20),
                new SqlParameter("@BE007",SqlDbType.Decimal,11),
                new SqlParameter("@BE008",SqlDbType.Decimal,11),
                new SqlParameter("@BE009",SqlDbType.Decimal,11),
                new SqlParameter("@BE010",SqlDbType.Decimal,11),
                new SqlParameter("@BE011",SqlDbType.Decimal,11),
                new SqlParameter("@BE012",SqlDbType.Decimal,11),
                new SqlParameter("@BE015",SqlDbType.NVarChar,20),
                new SqlParameter("@BE016",SqlDbType.NVarChar,20),
                new SqlParameter("@BE017",SqlDbType.NVarChar,200)
            };
            parameter [ 0 ] . Value = _model . BE001;
            parameter [ 1 ] . Value = _model . BE002;
            parameter [ 2 ] . Value = _model . BE003;
            parameter [ 3 ] . Value = _model . BE004;
            parameter [ 4 ] . Value = _model . BE005;
            parameter [ 5 ] . Value = _model . BE006;
            parameter [ 6 ] . Value = _model . BE007;
            parameter [ 7 ] . Value = _model . BE008;
            parameter [ 8 ] . Value = _model . BE009;
            parameter [ 9 ] . Value = _model . BE010;
            parameter [ 10 ] . Value = _model . BE011;
            parameter [ 11 ] . Value = _model . BE012;
            parameter [ 12 ] . Value = _model . BE015;
            parameter [ 13 ] . Value = _model . BE016;
            parameter [ 14 ] . Value = _model . BE017;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . OtherExpenseStatementLibrary _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQBE SET " );
            strSql . Append ( "BE002=@BE002," );
            strSql . Append ( "BE003=@BE003," );
            strSql . Append ( "BE004=@BE004," );
            strSql . Append ( "BE005=@BE005," );
            strSql . Append ( "BE006=@BE006," );
            strSql . Append ( "BE007=@BE007," );
            strSql . Append ( "BE008=@BE008," );
            strSql . Append ( "BE009=@BE009," );
            strSql . Append ( "BE010=@BE010," );
            strSql . Append ( "BE011=@BE011," );
            strSql . Append ( "BE012=@BE012," );
            strSql . Append ( "BE001=@BE001," );
            strSql . Append ( "BE016=@BE016," );
            strSql . Append ( "BE017=@BE017 " );
            strSql . Append ( " WHERE idx=@idx" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@BE002",SqlDbType.NVarChar,20),
                new SqlParameter("@BE003",SqlDbType.NVarChar,20),
                new SqlParameter("@BE004",SqlDbType.NVarChar,20),
                new SqlParameter("@BE005",SqlDbType.Int),
                new SqlParameter("@BE006",SqlDbType.NVarChar,20),
                new SqlParameter("@BE007",SqlDbType.Decimal,11),
                new SqlParameter("@BE008",SqlDbType.Decimal,11),
                new SqlParameter("@BE009",SqlDbType.Decimal,11),
                new SqlParameter("@BE010",SqlDbType.Decimal,11),
                new SqlParameter("@BE011",SqlDbType.Decimal,11),
                new SqlParameter("@BE012",SqlDbType.Decimal,11),
                new SqlParameter("@BE001",SqlDbType.NVarChar,20),
                new SqlParameter("@BE016",SqlDbType.NVarChar,20),
                new SqlParameter("@BE017",SqlDbType.NVarChar,200),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter [ 0 ] . Value = _model . BE002;
            parameter [ 1 ] . Value = _model . BE003;
            parameter [ 2 ] . Value = _model . BE004;
            parameter [ 3 ] . Value = _model . BE005;
            parameter [ 4 ] . Value = _model . BE006;
            parameter [ 5 ] . Value = _model . BE007;
            parameter [ 6 ] . Value = _model . BE008;
            parameter [ 7 ] . Value = _model . BE009;
            parameter [ 8 ] . Value = _model . BE010;
            parameter [ 9 ] . Value = _model . BE011;
            parameter [ 10 ] . Value = _model . BE012;
            parameter [ 11 ] . Value = _model . BE001;
            parameter [ 12 ] . Value = _model . BE016;
            parameter [ 13 ] . Value = _model . BE017;
            parameter [ 14 ] . Value = _model . idx;
            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBE " );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT *,B.DGA003 FROM R_PQBE A LEFT JOIN TPADGA B ON A.BE016=B.DGA001" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPqf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,DAA002 FROM R_PQF A LEFT JOIN TPADAA B ON A.PQF17=B.DAA001 ORDER BY PQF01 DESC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBE " );
            strSql.Append( " WHERE BE015=@BE015" );
            SqlParameter[] parameter = {
                new SqlParameter("@BE015",SqlDbType.NVarChar,20)
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
            strSql.Append( "SELECT DISTINCT BE015,BE001,BE002,BE003,BE004,BE005,BE006, SUBSTRING(BE002,1,2) BE FROM R_PQBE " );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT idx,BE015,BE001,BE002,BE003,BE004,BE005,BE006 FROM R_PQBE) A " );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取分页数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,BE015,BE001,BE002,BE003,BE004,BE005,BE006,DGA003 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.BE015 DESC" );
            strSql.Append( ")AS ROW,T.* FROM R_PQBE T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT LEFT JOIN TPADGA B ON TT.BE016=B.DGA001" );
            strSql.AppendFormat( " WHERE TT.ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.OtherExpenseStatementLibrary GetDataTable ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBE" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null )
                return GetModel( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.OtherExpenseStatementLibrary GetModel ( DataRow row )
        {
            MulaolaoLibrary.OtherExpenseStatementLibrary model = new MulaolaoLibrary.OtherExpenseStatementLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.idx = int.Parse( row["idx"].ToString( ) );
                if ( row["BE001"] != null && row["BE001"].ToString( ) != "" )
                    model.BE001 = row["BE001"].ToString( );
                if ( row["BE002"] != null && row["BE002"].ToString( ) != "" )
                    model.BE002 = row["BE002"].ToString( );
                if ( row["BE003"] != null && row["BE003"].ToString( ) != "" )
                    model.BE003 = row["BE003"].ToString( );
                if ( row["BE004"] != null && row["BE004"].ToString( ) != "" )
                    model.BE004 = row["BE004"].ToString( );
                if ( row["BE005"] != null && row["BE005"].ToString( ) != "" )
                    model.BE005 = int.Parse( row["BE005"].ToString( ) );
                if ( row["BE006"] != null && row["BE006"].ToString( ) != "" )
                    model.BE006 = row["BE006"].ToString( );
                if ( row["BE007"] != null && row["BE007"].ToString( ) != "" )
                    model.BE007 = decimal.Parse( row["BE007"].ToString( ) );
                if ( row["BE008"] != null && row["BE008"].ToString( ) != "" )
                    model.BE008 = decimal.Parse( row["BE008"].ToString( ) );
                if ( row["BE009"] != null && row["BE009"].ToString( ) != "" )
                    model.BE009 = decimal.Parse( row["BE009"].ToString( ) );
                if ( row["BE010"] != null && row["BE010"].ToString( ) != "" )
                    model.BE010 = decimal.Parse( row["BE010"].ToString( ) );
                if ( row["BE011"] != null && row["BE011"].ToString( ) != "" )
                    model.BE011 = decimal.Parse( row["BE011"].ToString( ) );
                if ( row["BE012"] != null && row["BE012"].ToString( ) != "" )
                    model.BE012 = decimal.Parse( row["BE012"].ToString( ) );
                if ( row["BE015"] != null && row["BE015"].ToString( ) != "" )
                    model.BE015 = row["BE015"].ToString( );
                if ( row["BE016"] != null && row["BE016"].ToString( ) != "" )
                    model.BE016 = row["BE016"].ToString( );
                if ( row [ "BE017" ] != null && row [ "BE017" ] . ToString ( ) != "" )
                    model . BE017 = row [ "BE017" ] . ToString ( );
            }
            return model;
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DGA001,DGA003 FROM TPADGA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTableOf ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT DGA003 FROM TPADGA WHERE DGA001='{0}'",num );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
