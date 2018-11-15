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
    public class GongZiCeDao
    {
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GongZiCeLibrary model)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQEZ" );
            strSql.Append( " WHERE EZ002=@EZ002 AND EZ003=@EZ003 AND EZ004=@EZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ002",SqlDbType.NVarChar),
                new SqlParameter("@EZ003",SqlDbType.NVarChar),
                new SqlParameter("@EZ004",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.EZ002;
            parameter[1].Value = model.EZ003;
            parameter[2].Value = model.EZ004;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQEZ SET " );           
            strSql.Append( "EZ005=@EZ005," );
            strSql.Append( "EZ006=@EZ006," );
            strSql.Append( "EZ007=@EZ007," );
            strSql.Append( "EZ008=@EZ008," );
            strSql.Append( "EZ009=@EZ009," );
            strSql.Append( "EZ010=@EZ010," );
            strSql.Append( "EZ011=@EZ011" );
            strSql.Append( " WHERE EZ002=@EZ002 AND EZ003=@EZ003 AND EZ004=@EZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ002",SqlDbType.NVarChar),
                new SqlParameter("@EZ003",SqlDbType.NVarChar),
                new SqlParameter("@EZ004",SqlDbType.NVarChar),
                new SqlParameter("@EZ005",SqlDbType.Decimal),
                new SqlParameter("@EZ006",SqlDbType.Decimal),
                new SqlParameter("@EZ007",SqlDbType.Decimal),
                new SqlParameter("@EZ008",SqlDbType.Decimal),
                new SqlParameter("@EZ009",SqlDbType.Decimal),
                new SqlParameter("@EZ010",SqlDbType.Decimal),
                new SqlParameter("@EZ011",SqlDbType.NVarChar),
            };
            parameter[0].Value = model.EZ002;
            parameter[1].Value = model.EZ003;
            parameter[2].Value = model.EZ004;
            parameter[3].Value = model.EZ005;
            parameter[4].Value = model.EZ006;
            parameter[5].Value = model.EZ007;
            parameter[6].Value = model.EZ008;
            parameter[7].Value = model.EZ009;
            parameter[8].Value = model.EZ010;
            parameter[9].Value = model.EZ011;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQEZ (" );
            strSql.Append( "EZ001,EZ002,EZ003,EZ004,EZ005,EZ006,EZ007,EZ008,EZ009,EZ010,EZ011,EZ014)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@EZ001,@EZ002,@EZ003,@EZ004,@EZ005,@EZ006,@EZ007,@EZ008,@EZ009,@EZ010,@EZ011,@EZ014);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ002",SqlDbType.NVarChar),
                new SqlParameter("@EZ003",SqlDbType.NVarChar),
                new SqlParameter("@EZ004",SqlDbType.NVarChar),
                new SqlParameter("@EZ005",SqlDbType.Decimal),
                new SqlParameter("@EZ006",SqlDbType.Decimal),
                new SqlParameter("@EZ007",SqlDbType.Decimal),
                new SqlParameter("@EZ008",SqlDbType.Decimal),
                new SqlParameter("@EZ009",SqlDbType.Decimal),
                new SqlParameter("@EZ010",SqlDbType.Decimal),
                new SqlParameter("@EZ011",SqlDbType.NVarChar),
                new SqlParameter("@EZ001",SqlDbType.NVarChar),
                new SqlParameter("@EZ014",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.EZ002;
            parameter[1].Value = model.EZ003;
            parameter[2].Value = model.EZ004;
            parameter[3].Value = model.EZ005;
            parameter[4].Value = model.EZ006;
            parameter[5].Value = model.EZ007;
            parameter[6].Value = model.EZ008;
            parameter[7].Value = model.EZ009;
            parameter[8].Value = model.EZ010;
            parameter[9].Value = model.EZ011;
            parameter[10].Value = model.EZ001;
            parameter[11].Value = model.EZ014;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateIdx ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQEZ SET " );
            strSql.Append( "EZ002=@EZ002," );
            strSql.Append( "EZ003=@EZ003," );
            strSql.Append( "EZ004=@EZ004," );
            strSql.Append( "EZ005=@EZ005," );
            strSql.Append( "EZ006=@EZ006," );
            strSql.Append( "EZ007=@EZ007," );
            strSql.Append( "EZ008=@EZ008," );
            strSql.Append( "EZ009=@EZ009," );
            strSql.Append( "EZ010=@EZ010," );
            strSql.Append( "EZ011=@EZ011," );
            strSql.Append( "EZ014=@EZ014" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ002",SqlDbType.NVarChar),
                new SqlParameter("@EZ003",SqlDbType.NVarChar),
                new SqlParameter("@EZ004",SqlDbType.NVarChar),
                new SqlParameter("@EZ005",SqlDbType.Decimal),
                new SqlParameter("@EZ006",SqlDbType.Decimal),
                new SqlParameter("@EZ007",SqlDbType.Decimal),
                new SqlParameter("@EZ008",SqlDbType.Decimal),
                new SqlParameter("@EZ009",SqlDbType.Decimal),
                new SqlParameter("@EZ010",SqlDbType.Decimal),
                new SqlParameter("@EZ011",SqlDbType.NVarChar),
                new SqlParameter("@EZ014",SqlDbType.NVarChar),
                new SqlParameter("@idx",SqlDbType.Int)
            };
            parameter[0].Value = model.EZ002;
            parameter[1].Value = model.EZ003;
            parameter[2].Value = model.EZ004;
            parameter[3].Value = model.EZ005;
            parameter[4].Value = model.EZ006;
            parameter[5].Value = model.EZ007;
            parameter[6].Value = model.EZ008;
            parameter[7].Value = model.EZ009;
            parameter[8].Value = model.EZ010;
            parameter[9].Value = model.EZ011;
            parameter[10].Value = model.EZ014;
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
            ArrayList SQLString = new ArrayList( );
            StringBuilder sqlSl = new StringBuilder( );
            sqlSl.AppendFormat( "SELECT COUNT(1) FROM R_PQW WHERE GZ39='执行' AND  idx IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001='{0}')" ,idx );
            if ( SqlHelper.Exists( sqlSl.ToString( ) ) == true )
            {
                StringBuilder strSqls = new StringBuilder( );
                strSqls.AppendFormat( "UPDATE R_PQW SET GZ39='' WHERE GZ39='执行' AND idx IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001='{0}')" ,idx );
                SQLString.Add( strSqls.ToString( ) );
            }
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQEZ WHERE idx='{0}'" ,idx );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "DELETE FROM R_PQFZ WHERE FZ001='{0}'" ,idx );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetDataTableGenerate (string year,int mouth,string name,string nameS,string nameT )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "WITH CET AS(SELECT GZ02,SUM(U0) U0,SUM(U1) U1,SUM(U2) U2,SUM(U3) U3,GZ16,GZ28 FROM (SELECT GZ02,CONVERT(DECIMAL(18,2),SUM(GZ09+GZ10+GZ11)) U0,CONVERT(DECIMAL(18,2),SUM(GZ12+GZ13+GZ14)) U1,CONVERT(DECIMAL(18,6),SUM(GZ06*GZ25*GZ41)) U2,CONVERT(DECIMAL(18,6),SUM(GZ36*(GZ12+GZ13+GZ14))) U3 ,GZ16,GZ28 FROM R_PQW" );
            strSql.Append( " WHERE GZ44=@GZ44 AND GZ28=@GZ28 AND GZ30=@GZ30 AND GZ16=@GZ16 AND GZ37=@GZ37 AND idx NOT IN (SELECT FZ002 FROM R_PQFZ)" );
            strSql.Append( " GROUP BY GZ02,GZ16,GZ35,GZ28,GZ01) A GROUP BY GZ02,GZ16,GZ28)" );
            strSql.Append( " SELECT GZ02,U0,U1,U2,U3,GZ16,GZ28 FROM CET" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ44",SqlDbType.Int),
                new SqlParameter("@GZ28",SqlDbType.Int),
                new SqlParameter("@GZ30",SqlDbType.NVarChar),
                new SqlParameter("@GZ16",SqlDbType.NVarChar),
                new SqlParameter("@GZ37",SqlDbType.NVarChar)
            };
            parameter[0].Value = year;
            parameter[1].Value = mouth;
            parameter[2].Value = name;
            parameter[3].Value = nameS;
            parameter[4].Value = nameT;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取本结算年和月的所有车间主任、组长、统计员列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableGroupBy ( int year,int month )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DISTINCT GZ30,GZ16,GZ37 FROM R_PQW WHERE GZ44={0} AND GZ28={1}" ,year ,month );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable GetDataTableIdx ( string year ,int mouth ,string name ,string names)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQW" );
            strSql.Append( " WHERE GZ35=@GZ35 AND GZ24=@GZ24 AND GZ30=@GZ30 AND GZ02=@GZ02" );
            SqlParameter[] parameter = {
                new SqlParameter("@GZ35",SqlDbType.NVarChar),
                new SqlParameter("@GZ24",SqlDbType.Int),
                new SqlParameter("@GZ30",SqlDbType.NVarChar),
                new SqlParameter("@GZ02",SqlDbType.NVarChar)
            };
            parameter[0].Value = year;
            parameter[1].Value = mouth;
            parameter[2].Value = name;
            parameter[3].Value = names;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQEZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReviews ( string oddNum ,string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS " );
            strSql.Append( "WHERE RES01=@RES01 AND RES06=@RES06 AND RES05='执行'" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

           return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string idStr)
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "UPDATE R_PQW SET GZ39='' WHERE idx IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (" + idStr + "))" );
            SQLString.Add( strSq.ToString( ) );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQEZ WHERE EZ001='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.Append( "DELETE FROM R_PQFZ WHERE FZ001 IN (" + idStr + ")" );
            SQLString.Add( strS.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool DeleteReview ( string oddNum ,string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = tableName;
            parameter[1].Value = oddNum;

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
        public DataTable GetDataTableWeiHu ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQEZ" );
            strSql.Append( " WHERE EZ001=@EZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQEZ SET " );
            strSql.Append( "EZ012=@EZ012," );
            strSql.Append( "EZ013=@EZ013" );
            strSql.Append( " WHERE EZ001=@EZ001" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ012",SqlDbType.NVarChar),
                new SqlParameter("@EZ013",SqlDbType.NVarChar),
                new SqlParameter("@EZ001",SqlDbType.NVarChar)
            };
            parameter[0].Value = model.EZ012;
            parameter[1].Value = model.EZ013;
            parameter[2].Value = model.EZ001;

            int row = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkShop ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取组长
        /// </summary>
        /// <param name="workShopName"></param>
        /// <returns></returns>
        public DataTable GetDataTableLeader ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA001,DBA002 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部')) AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)) " );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取员工
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableLeader ( string userName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT DBA002,DBA001 FROM TPADBA WHERE DBA005 IN (SELECT DAA001 FROM TPADAA WHERE DAA002='{0}')  AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL)" ,userName );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSta ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT GZ37 DBA002,GZ38 DBA001 FROM R_PQW WHERE GZ37 IS NOT NULL" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取生产人
        /// </summary>
        /// <param name="workShopName"></param>
        /// <returns></returns>
        public DataTable GetDataTableProduction ( string workShopName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DBA002,DBA001 FROM TPADBA " );
            strSql.Append( "WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002=@DAA002)" );
            SqlParameter[] parameter = {
                new SqlParameter("@DAA002",SqlDbType.NVarChar)
            };

            parameter[0].Value = workShopName;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongZiCeLibrary GetModel ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQEZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRow( dt.Rows[0] );
            else
                return null;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongZiCeLibrary GetDataRow ( DataRow row )
        {
            MulaolaoLibrary.GongZiCeLibrary model = new MulaolaoLibrary.GongZiCeLibrary( );

            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["EZ001"] != null && row["EZ001"].ToString( ) != "" )
                    model.EZ001 = row["EZ001"].ToString( );
                if ( row["EZ002"] != null && row["EZ002"].ToString( ) != "" )
                    model.EZ002 = row["EZ002"].ToString( );
                if ( row["EZ003"] != null && row["EZ003"].ToString( ) != "" )
                    model.EZ003 = row["EZ003"].ToString( );
                if ( row["EZ004"] != null && row["EZ004"].ToString( ) != "" )
                    model.EZ004 = row["EZ004"].ToString( );
                if ( row["EZ005"] != null && row["EZ005"].ToString( ) != "" )
                    model.EZ005 = decimal.Parse( row["EZ005"].ToString( ) );
                if ( row["EZ006"] != null && row["EZ006"].ToString( ) != "" )
                    model.EZ006 = decimal.Parse( row["EZ006"].ToString( ) );
                if ( row["EZ007"] != null && row["EZ007"].ToString( ) != "" )
                    model.EZ007 = decimal . Parse( row["EZ007"].ToString( ) );
                if ( row["EZ008"] != null && row["EZ008"].ToString( ) != "" )
                    model.EZ008 = decimal . Parse( row["EZ008"].ToString( ) );
                if ( row["EZ009"] != null && row["EZ009"].ToString( ) != "" )
                    model.EZ009 = decimal . Parse( row["EZ009"].ToString( ) );
                if ( row["EZ010"] != null && row["EZ010"].ToString( ) != "" )
                    model.EZ010 = decimal . Parse( row["EZ010"].ToString( ) );
                if ( row["EZ011"] != null && row["EZ011"].ToString( ) != "" )
                    model.EZ011 = row["EZ011"].ToString( );
                if ( row["EZ012"] != null && row["EZ012"].ToString( ) != "" )
                    model.EZ012 = row["EZ012"].ToString( );
                if ( row["EZ013"] != null && row["EZ013"].ToString( ) != "" )
                    model.EZ013 = row["EZ013"].ToString( );
                if ( row["EZ014"] != null && row["EZ014"].ToString( ) != "" )
                    model.EZ014 = row["EZ014"].ToString( );
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
            strSql.Append( "SELECT DISTINCT EZ001,EZ002,EZ004 FROM R_PQEZ" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT EZ001,EZ002,EZ004,EZ011 FROM R_PQEZ) A" );

            object obj = SqlHelper.GetSingle( strSql.ToString( ) );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT EZ001,EZ002,EZ004,EZ011,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=EZ001)) RES05,SUM(EZ007+EZ008-EZ009-EZ010) EZ FROM (" );
            strSql.Append( "SELECT ROW_NUMBER() OVER(" );
            strSql.Append( "ORDER BY T.EZ001 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQEZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( ") TT " );
            //strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );
            strSql . Append ( "  GROUP BY EZ001,EZ002,EZ004,EZ011" );
             
            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT SUBSTRING(EZ004,0,5) EZ004,SUBSTRING(EZ004,5,2) EZ04,EZ002,CONVERT(DECIMAL(18,0),SUM(EZ007+EZ008+EZ009-EZ010)) EZ FROM R_PQEZ" );
            strSql.Append( " WHERE EZ001=@EZ001" );
            strSql.Append( " GROUP BY EZ004,EZ002" );
            SqlParameter[] parameter = {
                new SqlParameter("@EZ001",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 获取打印表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrints ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT EZ011,EZ005,EZ006,EZ007,EZ008,CASE WHEN EZ005=0 THEN 0 WHEN EZ005!=0 THEN CONVERT(DECIMAL(18,1),EZ007/EZ005) END EZJJ,CASE WHEN EZ006=0 THEN 0 WHEN EZ006!=0 THEN EZ008/EZ006 END EZJS,EZ009,EZ010,EZ003,EZ007+EZ008+EZ009+EZ010 EZ FROM R_PQEZ " );
            strSql.Append( " WHERE EZ001=@EZ001" );
            SqlParameter[] paramter = {
                new SqlParameter("@EZ001",SqlDbType.NVarChar)
            };

            paramter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,paramter );
        }

        /// <summary>
        /// 是否存在idx
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ExistsUpIn ( MulaolaoLibrary.GongZiCeLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT idx FROM R_PQEZ WHERE EZ002='{0}' AND EZ003='{1}' AND EZ004='{2}' AND EZ011='{3}'" ,model.EZ002 ,model.EZ003 ,model.EZ004 ,model.EZ011 );
            DataTable dr = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( dr.Rows.Count > 0 )
                model.IDX = string.IsNullOrEmpty( dr.Rows[0]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( dr.Rows[0]["idx"].ToString( ) );
            else
                model.IDX = 0;
            return model.IDX;
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <returns></returns>
        public bool ExistsTranUpdate ( MulaolaoLibrary.GongZiCeLibrary model ,string year ,int mouth )
        {
            int id = 0;
            ArrayList SQLString = new ArrayList( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQW " );
            strSql.Append( " WHERE  GZ28=@GZ28 AND GZ30=@GZ30 AND GZ02=@GZ02 AND GZ37=@GZ37" );
            SqlParameter[] parameter = {
                //new SqlParameter("@GZ35",SqlDbType.NVarChar),
                new SqlParameter("@GZ28",SqlDbType.Int),
                new SqlParameter("@GZ30",SqlDbType.NVarChar),
                new SqlParameter("@GZ02",SqlDbType.NVarChar),
                new SqlParameter("@GZ37",SqlDbType.NVarChar)
            };
            //parameter[0].Value = year;
            parameter[0].Value = mouth;
            parameter[1].Value = model.EZ002;
            parameter[2].Value = model.EZ003;
            parameter[3].Value = model.EZ014;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );

            StringBuilder strSqlUp = new StringBuilder( );
            strSqlUp.AppendFormat( "UPDATE R_PQEZ SET EZ005='{0}',EZ006='{1}',EZ007='{2}',EZ008='{3}',EZ009='{4}',EZ010='{5}',EZ011='{6}' WHERE EZ002='{7}' AND EZ003='{8}' AND EZ004='{9}' AND EZ014='{10}'" ,model.EZ005 ,model.EZ006 ,model.EZ007 ,model.EZ008 ,model.EZ009 ,model.EZ010 ,model.EZ011 ,model.EZ002 ,model.EZ003 ,model.EZ004 ,model.EZ014 );
            SQLString.Add( strSqlUp.ToString( ) );

            for ( int i = 0 ; i < da.Rows.Count ; i++ )
            {
                id = string.IsNullOrEmpty( da.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["idx"].ToString( ) );
                StringBuilder strSqlE = new StringBuilder( );
                strSqlE.AppendFormat( "SELECT COUNT(1) FROM R_PQFZ WHERE FZ001='{0}' AND FZ002='{1}'" ,model.IDX ,id );
                if ( SqlHelper.Exists( strSqlE.ToString( ) ) == false )
                {
                    StringBuilder strSqlIn = new StringBuilder( );
                    strSqlIn.AppendFormat( "INSERT INTO R_PQFZ (FZ001,FZ002) VALUES ('{0}','{1}')" ,model.IDX ,id );
                    SQLString.Add( strSqlIn.ToString( ) );
                }
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <returns></returns>
        public bool ExistsTranInsert ( MulaolaoLibrary.GongZiCeLibrary model ,string year ,int mouth )
        {
            int id = 0;
            ArrayList SQLString = new ArrayList( );

            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT idx FROM R_PQW " );
            strSql.Append( " WHERE  GZ28=@GZ28 AND GZ30=@GZ30 AND GZ02=@GZ02 AND GZ37=@GZ37 AND GZ16=@GZ16 AND GZ44=@GZ44" );
            SqlParameter[] parameter = {
                //new SqlParameter("@GZ35",SqlDbType.NVarChar),
                new SqlParameter("@GZ28",SqlDbType.Int),
                new SqlParameter("@GZ30",SqlDbType.NVarChar),
                new SqlParameter("@GZ02",SqlDbType.NVarChar),
                new SqlParameter("@GZ37",SqlDbType.NVarChar),
                new SqlParameter("@GZ16",SqlDbType.NVarChar),
                new SqlParameter("@GZ44",SqlDbType.Int)
            };
            //parameter[0].Value = year;
            parameter[0].Value = mouth;
            parameter[1].Value = model.EZ002;
            parameter[2].Value = model.EZ003;
            parameter[3].Value = model.EZ014;
            parameter[4].Value = model.EZ011;
            parameter [ 5 ] . Value = year;

            DataTable da = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );

            StringBuilder strSqlUp = new StringBuilder( );
            strSqlUp.AppendFormat( "INSERT INTO R_PQEZ(EZ001,EZ002,EZ003,EZ004,EZ005,EZ006,EZ007,EZ008,EZ009,EZ010,EZ011,EZ014) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');SELECT SCOPE_IDENTITY();" ,model.EZ001 ,model.EZ002 ,model.EZ003 ,model.EZ004 ,model.EZ005 ,model.EZ006 ,model.EZ007 ,model.EZ008 ,model.EZ009 ,model.EZ010 ,model.EZ011 ,model.EZ014);

            model.IDX = SqlHelper.ExecuteSqlReturnId( strSqlUp.ToString( ) );
            if ( model.IDX > 0 )
            {
                for ( int i = 0 ; i < da.Rows.Count ; i++ )
                {
                    id = string.IsNullOrEmpty( da.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( da.Rows[i]["idx"].ToString( ) );
                    StringBuilder strSqlE = new StringBuilder( );
                    strSqlE.AppendFormat( "SELECT COUNT(1) FROM R_PQFZ WHERE FZ001='{0}' AND FZ002='{1}'" ,model.IDX ,id );
                    if ( SqlHelper.Exists( strSqlE.ToString( ) ) == false )
                    {
                        StringBuilder strSqlIn = new StringBuilder( );
                        strSqlIn.AppendFormat( "INSERT INTO R_PQFZ (FZ001,FZ002) VALUES ('{0}','{1}')" ,model.IDX ,id );
                        SQLString.Add( strSqlIn.ToString( ) );
                    }
                }
                return SqlHelper.ExecuteSqlTran( SQLString );
            }
            else
              return  false;
        }

        /// <summary>
        /// 回写317数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateWriteTo ( string strWhere )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQW SET " );
            strSql.Append( "GZ39='执行'" );
            strSql.Append( " WHERE idx in (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (" + strWhere + "))" );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strSq = new StringBuilder( );
            strSq.Append( "UPDATE R_REVIEWS SET RES05='执行' WHERE RES06 IN (SELECT DISTINCT GZ29 FROM R_PQW WHERE idx IN (" + strWhere + "))" );
            SQLString.Add( strSq.ToString( ) );

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableMdi (string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT A.idx idx_one,C.idx,GZ01,GZ22,GZ23,GZ34,GZ03,GZ04,GZ24,GZ17,GZ09+GZ10+GZ11+GZ12+GZ13+GZ14 W0,GZ25+GZ26 W1,GZ06*GZ25*GZ41+GZ36*(GZ12+GZ13+GZ14) W2 FROM R_PQW A,R_PQFZ B,R_PQEZ C WHERE A.idx=B.FZ002 AND B.FZ001=C.idx" );
            strSql.Append( " AND " + strWhere );
            strSql.Append( " ORDER BY GZ24,GZ17" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }
    }
}
