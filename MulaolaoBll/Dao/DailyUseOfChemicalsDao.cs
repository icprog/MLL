using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;

namespace MulaolaoBll.Dao
{
    public class DailyUseOfChemicalsDao
    {
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.DailyUseOfChemicals _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAG (" );
            strSql.Append( "AG001,AG002,AG003,AG005,AG006,AG007,AG008,AG009,AG010,AG011,AG012,AG013,AG014,AG016,AG019,AG020)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AG001,@AG002,@AG003,@AG005,@AG006,@AG007,@AG008,@AG009,@AG010,@AG011,@AG012,@AG013,@AG014,@AG016,@AG019,@AG020);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@AG001",SqlDbType.NVarChar,20),
                new SqlParameter("@AG002",SqlDbType.NVarChar,20),
                new SqlParameter("@AG003",SqlDbType.Date),
                new SqlParameter("@AG005",SqlDbType.NVarChar,20),
                new SqlParameter("@AG006",SqlDbType.NVarChar,20),
                new SqlParameter("@AG007",SqlDbType.NVarChar,20),
                new SqlParameter("@AG008",SqlDbType.NVarChar,255),
                new SqlParameter("@AG009",SqlDbType.NVarChar,20),
                new SqlParameter("@AG010",SqlDbType.NVarChar,255),
                new SqlParameter("@AG011",SqlDbType.Decimal,3),
                new SqlParameter("@AG012",SqlDbType.Decimal,3),
                new SqlParameter("@AG013",SqlDbType.Decimal,3),
                new SqlParameter("@AG014",SqlDbType.Decimal,3),
                new SqlParameter("@AG016",SqlDbType.NVarChar,20),
                new SqlParameter("@AG019",SqlDbType.NVarChar,10),
                new SqlParameter("@AG020",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.AG001;
            parameter[1].Value = _model.AG002;
            parameter[2].Value = _model.AG003;
            parameter[3].Value = _model.AG005;
            parameter[4].Value = _model.AG006;
            parameter[5].Value = _model.AG007;
            parameter[6].Value = _model.AG008;
            parameter[7].Value = _model.AG009;
            parameter[8].Value = _model.AG010;
            parameter[9].Value = _model.AG011;
            parameter[10].Value = _model.AG012;
            parameter[11].Value = _model.AG013;
            parameter[12].Value = _model.AG014;
            parameter[13].Value = _model.AG016;
            parameter[14].Value = _model.AG019;
            parameter [ 15 ] . Value = _model . AG020;

            return SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.DailyUseOfChemicals _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAG SET " );
            strSql.Append( "AG002=@AG002," );
            strSql.Append( "AG003=@AG003," );
            strSql.Append( "AG005=@AG005," );
            strSql.Append( "AG006=@AG006," );
            strSql.Append( "AG007=@AG007," );
            strSql.Append( "AG008=@AG008," );
            strSql.Append( "AG009=@AG009," );
            strSql.Append( "AG010=@AG010," );
            strSql.Append( "AG011=@AG011," );
            strSql.Append( "AG012=@AG012," );
            strSql.Append( "AG013=@AG013," );
            strSql.Append( "AG014=@AG014," );
            strSql.Append( "AG016=@AG016," );
            strSql.Append( "AG019=@AG019," );
            strSql . Append ( "AG020=@AG020 " );
            strSql .Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AG002",SqlDbType.NVarChar,20),
                new SqlParameter("@AG003",SqlDbType.Date),
                new SqlParameter("@AG005",SqlDbType.NVarChar,20),
                new SqlParameter("@AG006",SqlDbType.NVarChar,20),
                new SqlParameter("@AG007",SqlDbType.NVarChar,20),
                new SqlParameter("@AG008",SqlDbType.NVarChar,255),
                new SqlParameter("@AG009",SqlDbType.NVarChar,20),
                new SqlParameter("@AG010",SqlDbType.NVarChar,255),
                new SqlParameter("@AG011",SqlDbType.Decimal,3),
                new SqlParameter("@AG012",SqlDbType.Decimal,3),
                new SqlParameter("@AG013",SqlDbType.Decimal,3),
                new SqlParameter("@AG014",SqlDbType.Decimal,3),
                new SqlParameter("@AG016",SqlDbType.NVarChar,20),
                new SqlParameter("@AG019",SqlDbType.NVarChar,10),
                new SqlParameter("@AG020",SqlDbType.NVarChar,20),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.AG002;
            parameter[1].Value = _model.AG003;
            parameter[2].Value = _model.AG005;
            parameter[3].Value = _model.AG006;
            parameter[4].Value = _model.AG007;
            parameter[5].Value = _model.AG008;
            parameter[6].Value = _model.AG009;
            parameter[7].Value = _model.AG010;
            parameter[8].Value = _model.AG011;
            parameter[9].Value = _model.AG012;
            parameter[10].Value = _model.AG013;
            parameter[11].Value = _model.AG014;
            parameter[12].Value = _model.AG016;
            parameter[13].Value = _model.AG019;
            parameter [ 14 ] . Value = _model . AG020;
            parameter [15].Value = _model.IDX;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
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
            strSql.Append( "DELETE FROM R_PQAG" );
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
            strSql.Append( "SELECT idx,AG003,AG005,AG006,AG007,AG008,AG009,AG010,AG011,AG012,AG013,AG014,AG016,AG017,AG019,AG020 FROM R_PQAG" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

       /// <summary>
       /// 是否被339领用
       /// </summary>
       /// <param name="num"></param>
       /// <param name="nameOf"></param>
       /// <param name="workOf"></param>
       /// <param name="colorName"></param>
       /// <returns>true:没有  false:有</returns>
        public bool yesOrNo (string num,string nameOf,string workOf,string colorName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT AI013 FROM R_PQAI WHERE AI002=@AI002 AND AI011=@AI011 AND AI003=@AI003 AND AI004=@AI004" );
            SqlParameter[] parameter = {
                new SqlParameter("@AI002",SqlDbType.NVarChar,20),
                new SqlParameter("@AI011",SqlDbType.NVarChar,20),
                new SqlParameter("@AI003",SqlDbType.NVarChar,20),
                new SqlParameter("@AI004",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;
            parameter[1].Value = nameOf;
            parameter[2].Value = workOf;
            parameter[3].Value = colorName;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( string.IsNullOrEmpty( da.Rows[0]["AI013"].ToString( ) ) )
                    return true;
                else
                {
                    if ( da.Rows[0]["AI013"].ToString( ).Trim( ) == "T" )
                        //如果被339领用  则返回false
                        return false;
                    else
                        return true;
                }
            }
            else
                return true;
        }

    }
}
