using StudentMgr;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System;

namespace MulaolaoBll.Dao
{
    public class JiaoMiDuJunHenTableDao
    {
        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JM90,JM100,JM101,JM102,JM103 FROM R_PQO A,R_REVIEWS B WHERE A.JM01=B.RES06 AND RES05='执行' AND JM90!='' AND JM90 IS NOT NULL  AND JM90 NOT IN (SELECT DISTINCT JZ004 FROM R_PQJZ) AND JM07>'2016-07-01'" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableGenerate ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT JM101,JM100,JM90,JM102,JM94,JM95,JM96,JM10,JM15,JM104,JM07,JM16,(SELECT DAA002 FROM TPADAA WHERE DAA001 IN (SELECT DBA005 FROM TPADBA WHERE DBA002=JM108)) JM108,SUM(JM103) JM103 FROM R_PQO" );
            strSql.Append( " WHERE JM90!='' AND JM90 IS NOT NULL AND JM07>='2016-07-01'" );
            strSql.Append( " AND JM90 IN (" + strWhere + ")" );
            strSql.Append( " GROUP BY JM101,JM100,JM90,JM102,JM94,JM95,JM96,JM10,JM15,JM104,JM07,JM108,JM16 ORDER BY JM94,JM95,JM96,JM10,JM90" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQJZ SET " );
            strSql.Append( "JZ011=@JZ011," );
            strSql.Append( "JZ013=@JZ013," );
            strSql.Append( "JZ014=@JZ014," );
            strSql.Append( "JZ017=@JZ017," );
            strSql.Append( "JZ019=@JZ019" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ011",SqlDbType.Int),
                new SqlParameter("@JZ013",SqlDbType.Int),
                new SqlParameter("@JZ014",SqlDbType.Int),
                new SqlParameter("@JZ017",SqlDbType.Date),
                new SqlParameter("@JZ019",SqlDbType.Int),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.JZ011;
            parameter[1].Value = model.JZ013;
            parameter[2].Value = model.JZ014;
            parameter[3].Value = model.JZ017;
            parameter[4].Value = model.JZ019;
            parameter[5].Value = model.IDX;

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
            strSql.Append( "DELETE FROM R_PQJZ" );
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
        public DataTable GetDataTableTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx,JZ002,JZ003,JZ004,JZ005,JZ006,JZ007,JZ008,JZ009,JZ010,JZ011,JZ012,JZ013,JZ014,JZ015,JZ016,JZ017,JZ018,JZ019,CONVERT(VARCHAR(10),JZ007)+'-'+CONVERT(VARCHAR(10),JZ008)+'-'+CONVERT(VARCHAR(10),JZ009)+'-'+CONVERT(VARCHAR(10),JZ012)+'-'+JZ018 G1 FROM R_PQJZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ORDER BY JZ018,JZ007,JZ008,JZ009,JZ012" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsYesOrNo ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQJZ" );
            strSql.Append( " WHERE JZ004=@JZ004 AND JZ007=@JZ007 AND JZ008=@JZ008 AND JZ009=@JZ009 AND JZ012=@JZ012 AND JZ018=@JZ018" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ007",SqlDbType.Decimal,5),
                new SqlParameter("@JZ008",SqlDbType.Decimal,5),
                new SqlParameter("@JZ009",SqlDbType.Decimal,5),
                new SqlParameter("@JZ012",SqlDbType.Decimal,5),
                new SqlParameter("@JZ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.JZ004;
            parameter[1].Value = model.JZ007;
            parameter[2].Value = model.JZ008;
            parameter[3].Value = model.JZ009;
            parameter[4].Value = model.JZ012;
            parameter[5].Value = model.JZ018;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateGener ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQJZ SET " );
            strSql.Append( "JZ006=@JZ006," );
            strSql.Append( "JZ010=@JZ010," );
            strSql.Append( "JZ015=@JZ015," );
            strSql.Append( "JZ016=@JZ016" );
            strSql.Append( " WHERE JZ004=@JZ004" );
            strSql.Append( " AND JZ007=@JZ007" );
            strSql.Append( " AND JZ008=@JZ008" );
            strSql.Append( " AND JZ009=@JZ009" );
            strSql.Append( " AND JZ012=@JZ012" );
            strSql.Append( " AND JZ018=@JZ018" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ006",SqlDbType.BigInt),
                new SqlParameter("@JZ010",SqlDbType.BigInt),
                new SqlParameter("@JZ015",SqlDbType.Date),
                new SqlParameter("@JZ016",SqlDbType.Date),
                new SqlParameter("@JZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ007",SqlDbType.Decimal),
                new SqlParameter("@JZ008",SqlDbType.Decimal),
                new SqlParameter("@JZ009",SqlDbType.Decimal),
                new SqlParameter("@JZ012",SqlDbType.Decimal),
                new SqlParameter("@JZ018",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.JZ006;
            parameter[1].Value = model.JZ010;
            parameter[2].Value = model.JZ015;
            parameter[3].Value = model.JZ016;
            parameter[4].Value = model.JZ004;
            parameter[5].Value = model.JZ007;
            parameter[6].Value = model.JZ008;
            parameter[7].Value = model.JZ009;
            parameter[8].Value = model.JZ012;
            parameter[9].Value = model.JZ018;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertGener ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQJZ ( " );
            strSql.Append( "JZ001,JZ002,JZ003,JZ004,JZ005,JZ006,JZ007,JZ008,JZ009,JZ010,JZ011,JZ012,JZ013,JZ014,JZ018,JZ019)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@JZ001,@JZ002,@JZ003,@JZ004,@JZ005,@JZ006,@JZ007,@JZ008,@JZ009,@JZ010,@JZ011,@JZ012,@JZ013,@JZ014,@JZ018,@JZ019);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ001",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ002",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ003",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ004",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ005",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ006",SqlDbType.BigInt),
                new SqlParameter("@JZ007",SqlDbType.Decimal,5),
                new SqlParameter("@JZ008",SqlDbType.Decimal,5),
                new SqlParameter("@JZ009",SqlDbType.Decimal,5),
                new SqlParameter("@JZ010",SqlDbType.BigInt),
                new SqlParameter("@JZ011",SqlDbType.Int),
                new SqlParameter("@JZ012",SqlDbType.Decimal,5),
                new SqlParameter("@JZ013",SqlDbType.Int),
                new SqlParameter("@JZ014",SqlDbType.Int),
                new SqlParameter("@JZ018",SqlDbType.NVarChar,20),
                new SqlParameter("@JZ019",SqlDbType.Int)
            };
            parameter[0].Value = model.JZ001;
            parameter[1].Value = model.JZ002;
            parameter[2].Value = model.JZ003;
            parameter[3].Value = model.JZ004;
            parameter[4].Value = model.JZ005;
            parameter[5].Value = model.JZ006;
            parameter[6].Value = model.JZ007;
            parameter[7].Value = model.JZ008;
            parameter[8].Value = model.JZ009;
            parameter[9].Value = model.JZ010;
            parameter[10].Value = 0;
            parameter[11].Value = model.JZ012;
            parameter[12].Value = 0;
            parameter[13].Value = 0;
            parameter[14].Value = model.JZ018;
            parameter[15].Value = 0;
            int row = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            if ( row > 0 )
            {
                ArrayList SQLString = new ArrayList( );
                StringBuilder strS = new StringBuilder( );
                if ( model.JZ015 == null )
                    strS.AppendFormat( "UPDATE R_PQJZ SET JZ015=NULL WHERE idx='{0}'" ,row );
                else
                    strS.AppendFormat( "UPDATE R_PQJZ SET JZ015='{0}' WHERE idx='{1}'" ,model.JZ015 ,row );
                SQLString.Add( strS.ToString( ) );
                StringBuilder strSt = new StringBuilder( );
                if ( model.JZ016 == null )
                    strSt.AppendFormat( "UPDATE R_PQJZ SET JZ016=NULL WHERE idx='{0}'" ,row );
                else
                    strSt.AppendFormat( "UPDATE R_PQJZ SET JZ016='{0}' WHERE idx='{1}'" ,model.JZ016 ,row );
                SQLString.Add( strSt.ToString( ) );
                StringBuilder str = new StringBuilder( );
                if ( model.JZ017 == null )
                    str.AppendFormat( "UPDATE R_PQJZ SET JZ017=NULL WHERE idx='{0}'" ,row );
                else
                    str.AppendFormat( "UPDATE R_PQJZ SET JZ017='{0}' WHERE idx='{1}'" ,model.JZ017 ,row );
                SQLString.Add( str.ToString( ) );
                return SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
                return false;
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQJZ" );
            strSql.AppendFormat( " WHERE JZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_REVIEWS" );
            strS.AppendFormat( " WHERE RES01='R_047' AND RES06='{0}'" ,oddNum );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JZ020 FROM R_PQJZ" );
            strSql.Append( " WHERE JZ001=@JZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQJZ SET " );
            strSql.Append( " JZ020=@JZ020," );
            strSql.Append( " JZ021=@JZ021" );
            strSql.Append( " WHERE JZ001=@JZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@JZ020",SqlDbType.NVarChar,2000),
                new SqlParameter("@JZ021",SqlDbType.NVarChar,2000),
                new SqlParameter("@JZ001",SqlDbType.NVarChar,20)
            };
            parameter[0].Value = model.JZ020;
            parameter[1].Value = model.JZ021;
            parameter[2].Value = model.JZ001;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuJunHengTableLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQJZ" );
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
        /// 得到数据实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuJunHengTableLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model = new MulaolaoLibrary.JiaoMiDuJunHengTableLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["JZ001"] != null && row["JZ001"].ToString( ) != "" )
                    model.JZ001 = row["JZ001"].ToString( );
                if ( row["JZ002"] != null && row["JZ002"].ToString( ) != "" )
                    model.JZ002 = row["JZ002"].ToString( );
                if ( row["JZ003"] != null && row["JZ003"].ToString( ) != "" )
                    model.JZ003 = row["JZ003"].ToString( );
                if ( row["JZ004"] != null && row["JZ004"].ToString( ) != "" )
                    model.JZ004 = row["JZ004"].ToString( );
                if ( row["JZ005"] != null && row["JZ005"].ToString( ) != "" )
                    model.JZ005 = row["JZ005"].ToString( );
                if ( row["JZ006"] != null && row["JZ006"].ToString( ) != "" )
                    model.JZ006 = long.Parse( row["JZ006"].ToString( ) );
                if ( row["JZ007"] != null && row["JZ007"].ToString( ) != "" )
                    model.JZ007 = decimal.Parse( row["JZ007"].ToString( ) );
                if ( row["JZ008"] != null && row["JZ008"].ToString( ) != "" )
                    model.JZ008 = decimal.Parse( row["JZ008"].ToString( ) );
                if ( row["JZ009"] != null && row["JZ009"].ToString( ) != "" )
                    model.JZ009 = decimal.Parse( row["JZ009"].ToString( ) );
                if ( row["JZ010"] != null && row["JZ010"].ToString( ) != "" )
                    model.JZ010 = long.Parse( row["JZ010"].ToString( ) );
                if ( row["JZ011"] != null && row["JZ011"].ToString( ) != "" )
                    model.JZ011 = int.Parse( row["JZ011"].ToString( ) );
                if ( row["JZ012"] != null && row["JZ012"].ToString( ) != "" )
                    model.JZ012 = decimal.Parse( row["JZ012"].ToString( ) );
                if ( row["JZ013"] != null && row["JZ013"].ToString( ) != "" )
                    model.JZ013 = int.Parse( row["JZ013"].ToString( ) );
                if ( row["JZ014"] != null && row["JZ014"].ToString( ) != "" )
                    model.JZ014 = int.Parse( row["JZ014"].ToString( ) );
                if ( row["JZ015"] != null && row["JZ015"].ToString( ) != "" )
                    model.JZ015 = DateTime.Parse( row["JZ015"].ToString( ) );
                if ( row["JZ016"] != null && row["JZ016"].ToString( ) != "" )
                    model.JZ016 = DateTime.Parse( row["JZ016"].ToString( ) );
                if ( row["JZ017"] != null && row["JZ017"].ToString( ) != "" )
                    model.JZ017 = DateTime.Parse( row["JZ017"].ToString( ) );
                if ( row["JZ018"] != null && row["JZ018"].ToString( ) != "" )
                    model.JZ018 = row["JZ018"].ToString( );
                if ( row["JZ019"] != null && row["JZ019"].ToString( ) != "" )
                    model.JZ019 = int.Parse( row["JZ019"].ToString( ) );
                if ( row["JZ020"] != null && row["JZ020"].ToString( ) != "" )
                    model.JZ020 = row["JZ020"].ToString( );
                if ( row["JZ021"] != null && row["JZ021"].ToString( ) != "" )
                    model.JZ021 = row["JZ021"].ToString( );
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT JZ001,JZ002,JZ003,JZ004,JZ005 FROM R_PQJZ" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT JZ001,JZ002,JZ003,JZ004,JZ005 FROM R_PQJZ " );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

            Object obj= SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj != null )
                return Convert.ToInt32( obj );
            else
                return 0;
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
            strSql.Append( "SELECT DISTINCT JZ001,JZ002,JZ003,JZ004,JZ005,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=JZ001)) RES05 FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.JZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQJZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
