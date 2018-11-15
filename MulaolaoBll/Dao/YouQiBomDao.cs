using StudentMgr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Dao
{
    public class YouQiBomDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT KZ001,KZ002,KZ003,KZ004,KZ005,KZ006,KZ007,KZ008,KZ009,KZ010,KZ011,KZ012 FROM R_PQKZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQKZ ORDER BY KZ001 DESC" );
            
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="loginsNumber"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public DataTable GetDataTablePower ( string loginsNumber ,string formText )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT B.CX02,DBB001,DBB003,DBB004,DBB005,DBB006,DBB007,DBB008,DBB009,DBB010 FROM R_DBB A,R_MLLCXMC B" );
            strSql.Append( "  WHERE A.DBB002=B.CX01 AND CX02 = @CX02 AND DBB001 = (SELECT DBA001 FROM TPADBA WHERE DBA001 = @DBA001 )" );
            SqlParameter[] parameter = {
                new SqlParameter("@CX02",SqlDbType.NVarChar),
                new SqlParameter("@DBA001",SqlDbType.NVarChar)
            };
            parameter[0].Value = formText;
            parameter[1].Value = loginsNumber;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqa ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQA ORDER BY PQA01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqas ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQA01,PQA02,PQA03,PQA04,PQA05,PQA06,PQA07,PQA08,PQA09,PQA10,PQA11,PQA12 FROM R_PQA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqc ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQC ORDER BY PQC01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqcs ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT PQC01,PQC02,PQC03,PQC04,PQC05,PQC06,PQC07,PQC08,PQC09,PQC11,PQC12,PQC13,PQC14 FROM R_PQC" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqd ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQD ORDER BY PQD01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqe ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQE ORDER BY PQE01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqb ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQB ORDER BY PQB01" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiBomLibrary GetModel (int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQKZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] patameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            patameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,patameter );
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
        public MulaolaoLibrary.YouQiBomLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.YouQiBomLibrary model = new MulaolaoLibrary.YouQiBomLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["KZ001"] != null && row["KZ001"].ToString( ) != "" )
                    model.KZ001 = row["KZ001"].ToString( );
                if ( row["KZ002"] != null && row["KZ002"].ToString( ) != "" )
                    model.KZ002 = row["KZ002"].ToString( );
                if ( row["KZ003"] != null && row["KZ003"].ToString( ) != "" )
                    model.KZ003 = row["KZ003"].ToString( );
                if ( row["KZ004"] != null && row["KZ004"].ToString( ) != "" )
                    model.KZ004 = decimal.Parse( row["KZ004"].ToString( ) );
                if ( row["KZ005"] != null && row["KZ005"].ToString( ) != "" )
                    model.KZ005 = decimal.Parse( row["KZ005"].ToString( ) );
                if ( row["KZ006"] != null && row["KZ006"].ToString( ) != "" )
                    model.KZ006 = decimal.Parse( row["KZ006"].ToString( ) );
                if ( row["KZ007"] != null && row["KZ007"].ToString( ) != "" )
                    model.KZ007 = decimal.Parse( row["KZ007"].ToString( ) );
                if ( row["KZ008"] != null && row["KZ008"].ToString( ) != "" )
                    model.KZ008 = decimal.Parse( row["KZ008"].ToString( ) );
                if ( row["KZ009"] != null && row["KZ009"].ToString( ) != "" )
                    model.KZ009 = decimal.Parse( row["KZ009"].ToString( ) );
                if ( row["KZ010"] != null && row["KZ010"].ToString( ) != "" )
                    model.KZ010 = row["KZ010"].ToString( );
                if ( row["KZ011"] != null && row["KZ011"].ToString( ) != "" )
                    model.KZ011 = row["KZ011"].ToString( );
                if ( row["KZ012"] != null && row["KZ012"].ToString( ) != "" )
                    model.KZ012 = row["KZ012"].ToString( );
            }
            return model;
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQKZ" );
            strSql.Append( " WHERE KZ001=@KZ001 AND KZ002=@KZ002 AND KZ003=@KZ003 AND KZ004=@KZ004 AND KZ005=@KZ005 AND KZ006=@KZ006 AND KZ007=@KZ007 AND KZ008=@KZ008 AND KZ010=@KZ010 AND KZ011=@KZ011 AND KZ012=@KZ012" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ004",SqlDbType.Decimal,5),
                new SqlParameter("@KZ005",SqlDbType.Decimal,4),
                new SqlParameter("@KZ006",SqlDbType.Decimal,4),
                new SqlParameter("@KZ007",SqlDbType.Decimal,4),
                new SqlParameter("@KZ008",SqlDbType.Decimal,4),
                new SqlParameter("@KZ010",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ011",SqlDbType.NVarChar,30),
                new SqlParameter("@KZ012",SqlDbType.NVarChar,30)
            };
            parameter[0].Value = model.KZ001;
            parameter[1].Value = model.KZ002;
            parameter[2].Value = model.KZ003;
            parameter[3].Value = model.KZ004;
            parameter[4].Value = model.KZ005;
            parameter[5].Value = model.KZ006;
            parameter[6].Value = model.KZ007;
            parameter[7].Value = model.KZ008;
            parameter[8].Value = model.KZ010;
            parameter[9].Value = model.KZ011;
            parameter[10].Value = model.KZ012;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQKZ (" );
            strSql.Append( "KZ001,KZ002,KZ003,KZ004,KZ005,KZ006,KZ007,KZ008,KZ010,KZ011,KZ012)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@KZ001,@KZ002,@KZ003,@KZ004,@KZ005,@KZ006,@KZ007,@KZ008,@KZ010,@KZ011,@KZ012);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ004",SqlDbType.Decimal,5),
                new SqlParameter("@KZ005",SqlDbType.Decimal,10),
                new SqlParameter("@KZ006",SqlDbType.Decimal,6),
                new SqlParameter("@KZ007",SqlDbType.Decimal,6),
                new SqlParameter("@KZ008",SqlDbType.Decimal,6),
                //new SqlParameter("@KZ009",SqlDbType.Decimal,6),
                new SqlParameter("@KZ010",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ011",SqlDbType.NVarChar,30),
                new SqlParameter("@KZ012",SqlDbType.NVarChar,30)
            };
            parameter[0].Value = model.KZ001;
            parameter[1].Value = model.KZ002;
            parameter[2].Value = model.KZ003;
            parameter[3].Value = model.KZ004;
            parameter[4].Value = model.KZ005;
            parameter[5].Value = model.KZ006;
            parameter[6].Value = model.KZ007;
            parameter[7].Value = model.KZ008;
            //parameter[8].Value = model.KZ009;
            parameter[8].Value = model.KZ010;
            parameter[9].Value = model.KZ011;
            parameter[10].Value = model.KZ012;

            return SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.YouQiBomLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQKZ SET " );
            strSql.Append( "KZ001=@KZ001," );
            strSql.Append( "KZ002=@KZ002," );
            strSql.Append( "KZ003=@KZ003," );
            strSql.Append( "KZ004=@KZ004," );
            strSql.Append( "KZ005=@KZ005," );
            strSql.Append( "KZ006=@KZ006," );
            strSql.Append( "KZ007=@KZ007," );
            strSql.Append( "KZ008=@KZ008," );
            //strSql.Append( "KZ009=@KZ009," );
            strSql.Append( "KZ010=@KZ010," );
            strSql.Append( "KZ011=@KZ011," );
            strSql.Append( "KZ012=@KZ012" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ004",SqlDbType.Decimal,5),
                new SqlParameter("@KZ005",SqlDbType.Decimal,10),
                new SqlParameter("@KZ006",SqlDbType.Decimal,6),
                new SqlParameter("@KZ007",SqlDbType.Decimal,6),
                new SqlParameter("@KZ008",SqlDbType.Decimal,6),
                //new SqlParameter("@KZ009",SqlDbType.Decimal,6),
                new SqlParameter("@KZ010",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ011",SqlDbType.NVarChar,30),
                new SqlParameter("@KZ012",SqlDbType.NVarChar,30),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.KZ001;
            parameter[1].Value = model.KZ002;
            parameter[2].Value = model.KZ003;
            parameter[3].Value = model.KZ004;
            parameter[4].Value = model.KZ005;
            parameter[5].Value = model.KZ006;
            parameter[6].Value = model.KZ007;
            parameter[7].Value = model.KZ008;
            //parameter[8].Value = model.KZ009;
            parameter[8].Value = model.KZ010;
            parameter[9].Value = model.KZ011;
            parameter[10].Value = model.KZ012;
            parameter[11].Value = model.IDX;

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
            strSql.Append( "DELETE FROM R_PQKZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            int row= SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableGun ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQKZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public bool Exists ( string colorNum ,string type ,string material )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQKZ" );
            strSql.Append( " WHERE KZ001=@KZ001 AND KZ002=@KZ002 AND KZ003=@KZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = colorNum;
            parameter[1].Value = type;
            parameter[2].Value = material;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 批量新建数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool batchAdd ( string colorNum ,string type ,string material ,MulaolaoLibrary.YouQiBomLibrary _model)
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQKZ (KZ004,KZ005,KZ008,KZ009,KZ010,KZ011) SELECT KZ004,KZ005,KZ008,KZ009,KZ010,KZ011 FROM R_PQKZ" );
            strSql.Append( " WHERE KZ001=@KZ001 AND KZ002=@KZ002 AND KZ003=@KZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = colorNum;
            parameter[1].Value = type;
            parameter[2].Value = material;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                StringBuilder strS = new StringBuilder( );
                strS.Append( "UPDATE R_PQKZ SET " );
                strS.Append( "KZ001=@KZ001," );
                strS.Append( "KZ002=@KZ002," );
                strS.Append( "KZ003=@KZ003," );
                strS.Append( "KZ006=@KZ006," );
                strS.Append( "KZ007=@KZ007" );
                strS.Append( " WHERE KZ001 IS NULL AND KZ002 IS NULL AND KZ003 IS NULL" );
                SqlParameter[] paramete = {
                    new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                    new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                    new SqlParameter("@KZ003",SqlDbType.NVarChar,20),
                    new SqlParameter("@KZ006",SqlDbType.NVarChar,20),
                    new SqlParameter("@KZ007",SqlDbType.NVarChar,20)
                };
                paramete[0].Value = _model.KZ001;
                paramete[1].Value = _model.KZ002;
                paramete[2].Value = _model.KZ003;
                paramete[3].Value = _model.KZ006;
                paramete[4].Value = _model.KZ007;

                int rows = SqlHelper.ExecuteNonQuery( strS.ToString( ) ,paramete );
                if ( rows > 0 )
                    result = true;
                else
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQKZ WHERE KZ001 IS NULL AND KZ002 IS NULL AND KZ003 IS NULL" );
                    result = false;
                }
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool batchEdit ( string colorNum ,string type ,string material ,MulaolaoLibrary.YouQiBomLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQKZ SET " );
            strSql.Append( "KZ001=@KZ001," );
            strSql.Append( "KZ002=@KZ002," );
            strSql.Append( "KZ003=@KZ003," );
            strSql.Append( "KZ006=@KZ006," );
            strSql.Append( "KZ007=@KZ007" );
            strSql.Append( " WHERE KZ001=@KZ01 AND KZ002=@KZ02 AND KZ003=@KZ03" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ006",SqlDbType.Decimal,6),
                new SqlParameter("@KZ007",SqlDbType.Decimal,6),
                new SqlParameter("@KZ01",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ02",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ03",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.KZ001;
            parameter[1].Value = _model.KZ002;
            parameter[2].Value = _model.KZ003;
            parameter[3].Value = _model.KZ006;
            parameter[4].Value = _model.KZ007;
            parameter[5].Value = colorNum;
            parameter[6].Value = type;
            parameter[7].Value = material;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="colorNum"></param>
        /// <param name="type"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        public bool batchDelete ( string colorNum ,string type ,string material )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQKZ" );
            strSql.Append( " WHERE KZ001=@KZ001 AND KZ002=@KZ002 AND KZ003=@KZ003" );
            SqlParameter[] parameter = {
                new SqlParameter("@KZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@KZ003",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = colorNum;
            parameter[1].Value = type;
            parameter[2].Value = material;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 根据油漆品牌批量删除滚漆
        /// </summary>
        /// <param name="paintP"></param>
        /// <returns></returns>
        public bool barchDelete ( string paintP )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM R_PQKZ WHERE KZ010=@KZ010" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@KZ010",SqlDbType.NVarChar,20)
            };
            parameter [ 0 ] . Value = paintP;

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePqase ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAS" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
        public DataTable GetDataTablePqases ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT AS002,AS003,AS004,AS005,AS006,AS007,AS008,AS009 FROM R_PQAS" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplie ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT DGA003 AS001 FROM TPADGA" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool ExistsOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQAS" );
            strSql.Append( " WHERE AS001=@AS001 AND AS002=@AS002 AND AS003=@AS003 AND AS006=@AS006 AND AS007=@AS007" );
            SqlParameter[] parameter = {
                new SqlParameter("@AS001",SqlDbType.NVarChar,20),
                new SqlParameter("@AS002",SqlDbType.NVarChar,20),
                new SqlParameter("@AS003",SqlDbType.NVarChar,20),
                new SqlParameter("@AS006",SqlDbType.NVarChar,20),
                new SqlParameter("@AS007",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = _model.AS001;
            parameter[1].Value = _model.AS002;
            parameter[2].Value = _model.AS003;
            parameter[3].Value = _model.AS006;
            parameter[4].Value = _model.AS007;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }
        
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int AddOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQAS (" );
            strSql.Append( "AS001,AS002,AS003,AS004,AS005,AS006,AS007,AS008,AS009)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@AS001,@AS002,@AS003,@AS004,@AS005,@AS006,@AS007,@AS008,@AS009);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@AS001",SqlDbType.NVarChar,20),
                new SqlParameter("@AS002",SqlDbType.NVarChar,20),
                new SqlParameter("@AS003",SqlDbType.NVarChar,20),
                new SqlParameter("@AS004",SqlDbType.NVarChar,20),
                new SqlParameter("@AS005",SqlDbType.NVarChar,20),
                new SqlParameter("@AS006",SqlDbType.NVarChar,20),
                new SqlParameter("@AS007",SqlDbType.NVarChar,20),
                new SqlParameter("@AS008",SqlDbType.NVarChar,20),
                new SqlParameter("@AS009",SqlDbType.Decimal,4)
            };
            parameter[0].Value = _model.AS001;
            parameter[1].Value = _model.AS002;
            parameter[2].Value = _model.AS003;
            parameter[3].Value = _model.AS004;
            parameter[4].Value = _model.AS005;
            parameter[5].Value = _model.AS006;
            parameter[6].Value = _model.AS007;
            parameter[7].Value = _model.AS008;
            parameter[8].Value = _model.AS009;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiBomHupLibrary GetModelSupplie (int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQAS" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( da != null && da.Rows.Count > 0 )
                return GetDataRowSuppli( da.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.YouQiBomHupLibrary GetDataRowSuppli ( DataRow row)
        {
            MulaolaoLibrary.YouQiBomHupLibrary _model = new MulaolaoLibrary.YouQiBomHupLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    _model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["AS001"] != null && row["AS001"].ToString( ) != "" )
                    _model.AS001 = row["AS001"].ToString( );
                if ( row["AS002"] != null && row["AS002"].ToString( ) != "" )
                    _model.AS002 = row["AS002"].ToString( );
                if ( row["AS003"] != null && row["AS003"].ToString( ) != "" )
                    _model.AS003 = row["AS003"].ToString( );
                if ( row["AS004"] != null && row["AS004"].ToString( ) != "" )
                    _model.AS004 = row["AS004"].ToString( );
                if ( row["AS005"] != null && row["AS005"].ToString( ) != "" )
                    _model.AS005 = row["AS005"].ToString( );
                if ( row["AS006"] != null && row["AS006"].ToString( ) != "" )
                    _model.AS006 = row["AS006"].ToString( );
                if ( row["AS007"] != null && row["AS007"].ToString( ) != "" )
                    _model.AS007 = row["AS007"].ToString( );
                if ( row["AS008"] != null && row["AS008"].ToString( ) != "" )
                    _model.AS008 = row["AS008"].ToString( );
                if ( row["AS009"] != null && row["AS009"].ToString( ) != "" )
                    _model.AS009 = decimal.Parse( row["AS009"].ToString( ) );
            }

            return _model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfSupplie ( MulaolaoLibrary.YouQiBomHupLibrary _model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQAS SET " );
            strSql.Append( "AS001=@AS001," );
            strSql.Append( "AS002=@AS002," );
            strSql.Append( "AS003=@AS003," );
            strSql.Append( "AS004=@AS004," );
            strSql.Append( "AS005=@AS005," );
            strSql.Append( "AS006=@AS006," );
            strSql.Append( "AS007=@AS007," );
            strSql.Append( "AS008=@AS008," );
            strSql.Append( "AS009=@AS009" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@AS001",SqlDbType.NVarChar,20),
                new SqlParameter("@AS002",SqlDbType.NVarChar,20),
                new SqlParameter("@AS003",SqlDbType.NVarChar,20),
                new SqlParameter("@AS004",SqlDbType.NVarChar,20),
                new SqlParameter("@AS005",SqlDbType.NVarChar,20),
                new SqlParameter("@AS006",SqlDbType.NVarChar,20),
                new SqlParameter("@AS007",SqlDbType.NVarChar,20),
                new SqlParameter("@AS008",SqlDbType.NVarChar,20),
                new SqlParameter("@AS009",SqlDbType.Decimal,4),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = _model.AS001;
            parameter[1].Value = _model.AS002;
            parameter[2].Value = _model.AS003;
            parameter[3].Value = _model.AS004;
            parameter[4].Value = _model.AS005;
            parameter[5].Value = _model.AS006;
            parameter[6].Value = _model.AS007;
            parameter[7].Value = _model.AS008;
            parameter[8].Value = _model.AS009;
            parameter[9].Value = _model.IDX;

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
        public bool DeleteOfSupplie ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQAS" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("idx",SqlDbType.Int)
            };
            parameter[0].Value = idx;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 胶板是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQJB WHERE QJB001='{0}' AND QJB002='{1}' AND QJB003='{2}' AND QJB009='{3}' AND QJB013='{4}' " ,model . QJB001 ,model . QJB002 ,model . QJB003 ,model . QJB009,model.QJB013 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        public bool ExistsPQJBEdit ( MulaolaoLibrary . PqjbEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQJB WHERE QJB001='{0}' AND QJB002='{1}' AND QJB003='{2}' AND QJB009='{4}' AND QJB013='{5}'  AND idx!={3} " ,model . QJB001 ,model . QJB002 ,model . QJB003 ,model . idx ,model . QJB009 ,model . QJB013 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }


        /// <summary>
        /// 新增胶板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO R_PQJB (" );
            strSql . Append ( "QJB001,QJB002,QJB003,QJB004,QJB005,QJB006,QJB007,QJB008,QJB009,QJB010,QJB011,QJB012,QJB013,QJB014,QJB015,QJB016,QJB017,QJB018,QJB019)" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@QJB001,@QJB002,@QJB003,@QJB004,@QJB005,@QJB006,@QJB007,@QJB008,@QJB009,@QJB010,@QJB011,@QJB012,@QJB013,@QJB014,@QJB015,@QJB016,@QJB017,@QJB018,@QJB019)" );
            strSql . Append ( ";select @@IDENTITY" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QJB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB003", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB004", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB005", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB006", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB007", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB008", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB009", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB010", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB011", SqlDbType.NVarChar,5),
                    new SqlParameter("@QJB012", SqlDbType.NVarChar,200),
                    new SqlParameter("@QJB013", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB014", SqlDbType.NVarChar,50),
                    new SqlParameter("@QJB015", SqlDbType.NVarChar,100),
                    new SqlParameter("@QJB016", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB017", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB018", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB019", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . QJB001;
            parameters [ 1 ] . Value = model . QJB002;
            parameters [ 2 ] . Value = model . QJB003;
            parameters [ 3 ] . Value = model . QJB004;
            parameters [ 4 ] . Value = model . QJB005;
            parameters [ 5 ] . Value = model . QJB006;
            parameters [ 6 ] . Value = model . QJB007;
            parameters [ 7 ] . Value = model . QJB008;
            parameters [ 8 ] . Value = model . QJB009;
            parameters [ 9 ] . Value = model . QJB010;
            parameters [ 10 ] . Value = model . QJB011;
            parameters [ 11 ] . Value = model . QJB012;
            parameters [ 12 ] . Value = model . QJB013;
            parameters [ 13 ] . Value = model . QJB014;
            parameters [ 14 ] . Value = model . QJB015;
            parameters [ 15 ] . Value = model . QJB016;
            parameters [ 16 ] . Value = model . QJB017;
            parameters [ 17 ] . Value = model . QJB018;
            parameters [ 18 ] . Value = model . QJB019;

            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditPQJB ( MulaolaoLibrary . PqjbEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQJB set " );
            strSql . Append ( "QJB001=@QJB001," );
            strSql . Append ( "QJB002=@QJB002," );
            strSql . Append ( "QJB003=@QJB003," );
            strSql . Append ( "QJB004=@QJB004," );
            strSql . Append ( "QJB005=@QJB005," );
            strSql . Append ( "QJB006=@QJB006," );
            strSql . Append ( "QJB007=@QJB007," );
            strSql . Append ( "QJB008=@QJB008," );
            strSql . Append ( "QJB009=@QJB009," );
            strSql . Append ( "QJB010=@QJB010," );
            strSql . Append ( "QJB011=@QJB011," );
            strSql . Append ( "QJB012=@QJB012," );
            strSql . Append ( "QJB013=@QJB013," );
            strSql . Append ( "QJB014=@QJB014," );
            strSql . Append ( "QJB015=@QJB015," );
            strSql . Append ( "QJB016=@QJB016," );
            strSql . Append ( "QJB017=@QJB017," );
            strSql . Append ( "QJB018=@QJB018," );
            strSql . Append ( "QJB019=@QJB019 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QJB001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB002", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB003", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB004", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB005", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB006", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB007", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB008", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB009", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB010", SqlDbType.Decimal,9),
                    new SqlParameter("@QJB011", SqlDbType.NVarChar,5),
                    new SqlParameter("@QJB012", SqlDbType.NVarChar,200),
                    new SqlParameter("@QJB013", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB014", SqlDbType.NVarChar,50),
                    new SqlParameter("@QJB015", SqlDbType.NVarChar,100),
                    new SqlParameter("@QJB016", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB017", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB018", SqlDbType.NVarChar,20),
                    new SqlParameter("@QJB019", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . QJB001;
            parameters [ 1 ] . Value = model . QJB002;
            parameters [ 2 ] . Value = model . QJB003;
            parameters [ 3 ] . Value = model . QJB004;
            parameters [ 4 ] . Value = model . QJB005;
            parameters [ 5 ] . Value = model . QJB006;
            parameters [ 6 ] . Value = model . QJB007;
            parameters [ 7 ] . Value = model . QJB008;
            parameters [ 8 ] . Value = model . QJB009;
            parameters [ 9 ] . Value = model . QJB010;
            parameters [ 10 ] . Value = model . QJB011;
            parameters [ 11 ] . Value = model . QJB012;
            parameters [ 12 ] . Value = model . QJB013;
            parameters [ 13 ] . Value = model . QJB014;
            parameters [ 14 ] . Value = model . QJB015;
            parameters [ 15 ] . Value = model . QJB016;
            parameters [ 16 ] . Value = model . QJB017;
            parameters [ 17 ] . Value = model . QJB018;
            parameters [ 18 ] . Value = model . QJB019;
            parameters [ 19 ] . Value = model . idx;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameters );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 删除胶板数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeletePQJB ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQJB WHERE idx={0}" ,idx );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 获取胶板数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,QJB001,QJB002,QJB003,CONVERT(FLOAT,QJB004) QJB004, CONVERT(FLOAT,QJB005) QJB005,CONVERT(FLOAT,QJB006) QJB006,CONVERT(FLOAT,QJB007) QJB007,CONVERT(FLOAT,QJB008) QJB008,CONVERT(FLOAT,QJB009) QJB009,CONVERT(FLOAT,QJB010) QJB010,QJB011,QJB012,QJB013,QJB014,QJB015,QJB016,QJB017,QJB018,QJB019 FROM R_PQJB ORDER BY QJB001,QJB002,QJB003" );
            
            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 是否存在密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsPQMD ( MulaolaoLibrary.PqmdEntity model)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQMD WHERE QMD001='{0}' AND QMD002='{1}' AND QMD003='{2}' AND QMD012='{3}'" ,model . QMD001 ,model . QMD002 ,model . QMD003 ,model . QMD012 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        public bool ExistsPQMDE ( MulaolaoLibrary . PqmdEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQMD WHERE QMD001='{0}' AND QMD002='{1}' AND QMD003='{2}' AND QMD012='{4}' AND idx!={3}" ,model . QMD001 ,model . QMD002 ,model . QMD003 ,model . idx ,model . QMD012 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新增密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPQMD ( MulaolaoLibrary . PqmdEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into R_PQMD(" );
            strSql . Append ( "QMD001,QMD002,QMD003,QMD004,QMD005,QMD006,QMD007,QMD008,QMD009,QMD010,QMD011,QMD012,QMD013,QMD014,QMD015,QMD016,QMD017,QMD018)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@QMD001,@QMD002,@QMD003,@QMD004,@QMD005,@QMD006,@QMD007,@QMD008,@QMD009,@QMD010,@QMD011,@QMD012,@QMD013,@QMD014,@QMD015,@QMD016,@QMD017,@QMD018)" );
            strSql . Append ( ";select @@IDENTITY" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QMD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD003", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD004", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD005", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD006", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD007", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD008", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD009", SqlDbType.NVarChar,5),
                    new SqlParameter("@QMD010", SqlDbType.NVarChar,200),
                    new SqlParameter("@QMD011", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD012", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD013", SqlDbType.NVarChar,50),
                    new SqlParameter("@QMD014", SqlDbType.NVarChar,100),
                    new SqlParameter("@QMD015", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD016", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD017", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD018", SqlDbType.NVarChar,20)
            };
            parameters [ 0 ] . Value = model . QMD001;
            parameters [ 1 ] . Value = model . QMD002;
            parameters [ 2 ] . Value = model . QMD003;
            parameters [ 3 ] . Value = model . QMD004;
            parameters [ 4 ] . Value = model . QMD005;
            parameters [ 5 ] . Value = model . QMD006;
            parameters [ 6 ] . Value = model . QMD007;
            parameters [ 7 ] . Value = model . QMD008;
            parameters [ 8 ] . Value = model . QMD009;
            parameters [ 9 ] . Value = model . QMD010;
            parameters [ 10 ] . Value = model . QMD011;
            parameters [ 11 ] . Value = model . QMD012;
            parameters [ 12 ] . Value = model . QMD013;
            parameters [ 13 ] . Value = model . QMD014;
            parameters [ 14 ] . Value = model . QMD015;
            parameters [ 15 ] . Value = model . QMD016;
            parameters [ 16 ] . Value = model . QMD017;
            parameters [ 17 ] . Value = model . QMD018;
            return SqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
        }

        /// <summary>
        /// 编辑密度板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditPQMD ( MulaolaoLibrary . PqmdEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update R_PQMD set " );
            strSql . Append ( "QMD001=@QMD001," );
            strSql . Append ( "QMD002=@QMD002," );
            strSql . Append ( "QMD003=@QMD003," );
            strSql . Append ( "QMD004=@QMD004," );
            strSql . Append ( "QMD005=@QMD005," );
            strSql . Append ( "QMD006=@QMD006," );
            strSql . Append ( "QMD007=@QMD007," );
            strSql . Append ( "QMD008=@QMD008," );
            strSql . Append ( "QMD009=@QMD009," );
            strSql . Append ( "QMD010=@QMD010," );
            strSql . Append ( "QMD011=@QMD011," );
            strSql . Append ( "QMD012=@QMD012," );
            strSql . Append ( "QMD013=@QMD013," );
            strSql . Append ( "QMD014=@QMD014," );
            strSql . Append ( "QMD015=@QMD015," );
            strSql . Append ( "QMD016=@QMD016," );
            strSql . Append ( "QMD017=@QMD017," );
            strSql . Append ( "QMD018=@QMD018 " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@QMD001", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD002", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD003", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD004", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD005", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD006", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD007", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD008", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD009", SqlDbType.NVarChar,5),
                    new SqlParameter("@QMD010", SqlDbType.NVarChar,200),
                    new SqlParameter("@QMD011", SqlDbType.Decimal,9),
                    new SqlParameter("@QMD012", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD013", SqlDbType.NVarChar,50),
                    new SqlParameter("@QMD014", SqlDbType.NVarChar,100),
                    new SqlParameter("@QMD015", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD016", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD017", SqlDbType.NVarChar,20),
                    new SqlParameter("@QMD018", SqlDbType.NVarChar,20),
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = model . QMD001;
            parameters [ 1 ] . Value = model . QMD002;
            parameters [ 2 ] . Value = model . QMD003;
            parameters [ 3 ] . Value = model . QMD004;
            parameters [ 4 ] . Value = model . QMD005;
            parameters [ 5 ] . Value = model . QMD006;
            parameters [ 6 ] . Value = model . QMD007;
            parameters [ 7 ] . Value = model . QMD008;
            parameters [ 8 ] . Value = model . QMD009;
            parameters [ 9 ] . Value = model . QMD010;
            parameters [ 10 ] . Value = model . QMD011;
            parameters [ 11 ] . Value = model . QMD012;
            parameters [ 12 ] . Value = model . QMD013;
            parameters [ 13 ] . Value = model . QMD014;
            parameters [ 14 ] . Value = model . QMD015;
            parameters [ 15 ] . Value = model . QMD016;
            parameters [ 16 ] . Value = model . QMD017;
            parameters [ 17 ] . Value = model . QMD018;
            parameters [ 18 ] . Value = model . idx;
            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameters );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeletePQMD ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "delete from R_PQMD " );
            strSql . Append ( " where idx=@idx" );
            SqlParameter [ ] parameters = {
                    new SqlParameter("@idx", SqlDbType.Int,4)
            };
            parameters [ 0 ] . Value = idx;

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) ,parameters );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 获取密度板数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableMd ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT idx,QMD001,QMD002,QMD003,CONVERT(FLOAT,QMD004) QMD004, CONVERT(FLOAT,QMD005) QMD005,CONVERT(FLOAT,QMD006) QMD006,QMD007,QMD008,QMD009,QMD010,QMD011,QMD012,QMD013,QMD014,QMD015,QMD016,QMD017,QMD018 FROM R_PQMD ORDER BY QMD001,QMD002,QMD003" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable getGYS ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DGA001,DGA003,DGA017,DGA008,DGA012,DGA009,DGA011 FROM TPADGA WHERE DGA052='F'" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
