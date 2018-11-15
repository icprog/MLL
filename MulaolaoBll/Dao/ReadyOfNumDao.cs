using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentMgr;
using System.Data.SqlClient;

namespace MulaolaoBll.Dao
{
    public class ReadyOfNumDao
    {
        /// <summary>
        /// 获取最大流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT MAX(BG001) BG FROM R_PQBG" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Delete (string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQBG" );
            strSql.Append( " WHERE BG001=@BG001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BG001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row == 0 )
                return false;
            else
                return true;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBG" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOf ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQF04,PQF03 FROM R_PQF" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary.ReadyOfNumLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            if ( SqlHelper.Exists( "SELECT BG001 FROM R_PQBG WHERE BG001='"+_model.BG001+"'" ) == true )
            {
                strSql.Append( "UPDATE R_PQBG SET " );
                strSql.Append( "BG002=@BG002," );
                strSql.Append( "BG003=@BG003," );
                strSql.Append( "BG004=@BG004" );
                strSql.Append( " WHERE BG001=@BG001" );
            }
            else
            {
                strSql.Append( "INSERT INTO R_PQBG (" );
                strSql.Append( "BG001,BG002,BG003,BG004)" );
                strSql.Append( " VALUES (" );
                strSql.Append( "@BG001,@BG002,@BG003,@BG004)" );
                
            }
            SqlParameter[] parameter = {
                    new SqlParameter("@BG001",SqlDbType.NVarChar,20),
                    new SqlParameter("@BG002",SqlDbType.NVarChar,20),
                    new SqlParameter("@BG003",SqlDbType.NVarChar,20),
                    new SqlParameter("@BG004",SqlDbType.Int)
                };
            parameter[0].Value = _model.BG001;
            parameter[1].Value = _model.BG002;
            parameter[2].Value = _model.BG003;
            parameter[3].Value = _model.BG004;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ReadyOfNumLibrary GetModel ( string num )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQBG" );
            strSql.Append( " WHERE BG001=@BG001" );
            SqlParameter[] parameter = {
                new SqlParameter("@BG001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = num;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRow( da.Rows[0] );
            else
                return null;
        }

        public MulaolaoLibrary.ReadyOfNumLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.ReadyOfNumLibrary model = new MulaolaoLibrary.ReadyOfNumLibrary( );

            if ( row != null )
            {
                if ( row["BG001"] != null && row["BG001"].ToString( ) != "" )
                    model.BG001 = row["BG001"].ToString( );
                if ( row["BG002"] != null && row["BG002"].ToString( ) != "" )
                    model.BG002 = row["BG002"].ToString( );
                if ( row["BG003"] != null && row["BG003"].ToString( ) != "" )
                    model.BG003 = row["BG003"].ToString( );
                if ( row["BG004"] != null && row["BG004"].ToString( ) != "" )
                    model.BG004 = int.Parse( row["BG004"].ToString( ) );
            }

            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOf ( MulaolaoLibrary.ReadyOfNumLibrary model)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQBG" );
            strSql.Append( " WHERE BG002=@BG002 AND BG003=@BG003 AND BG004=@BG004" );
            SqlParameter[] parameter = {
                new SqlParameter("@BG002",SqlDbType.NVarChar,20),
                new SqlParameter("@BG003",SqlDbType.NVarChar,20),
                new SqlParameter("@BG004",SqlDbType.Int)
            };
            parameter[0].Value = model.BG002;
            parameter[1].Value = model.BG003;
            parameter[2].Value = model.BG004;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
    }
}
