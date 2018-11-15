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
    public class CheJianZhuRenKaoHeDao
    {
        /// <summary>
        /// 获取车间主任姓名
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableDirecTor ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA002 IN (SELECT DBA002 FROM TPADBA WHERE DBA005=(SELECT DAA001 FROM TPADAA WHERE DAA002='生产部'))" );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQCZ (" );
            strSql.Append( "CZ001,CZ002,CZ003,CZ004,CZ005,CZ006)" );
            strSql.Append( " VALUES (" );
            strSql.Append( " @CZ001,@CZ002,@CZ003,@CZ004,@CZ005,@CZ006);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@CZ001",SqlDbType.NVarChar),
                new SqlParameter("@CZ002",SqlDbType.NVarChar),
                new SqlParameter("@CZ003",SqlDbType.NVarChar),
                new SqlParameter("@CZ004",SqlDbType.Decimal),
                new SqlParameter("@CZ005",SqlDbType.Decimal),
                new SqlParameter("@CZ006",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.CZ001;
            parameter[1].Value = model.CZ002;
            parameter[2].Value = model.CZ003;
            parameter[3].Value = model.CZ004;
            parameter[4].Value = model.CZ005;
            parameter[5].Value = model.CZ006;

            int idx = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQCZ SET " );
            strSql.Append( "CZ001=@CZ001," );
            strSql.Append( "CZ002=@CZ002," );
            strSql.Append( "CZ003=@CZ003," );
            strSql.Append( "CZ004=@CZ004," );
            strSql.Append( "CZ005=@CZ005" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@CZ001",SqlDbType.NVarChar),
                new SqlParameter("@CZ002",SqlDbType.NVarChar),
                new SqlParameter("@CZ003",SqlDbType.NVarChar),
                new SqlParameter("@CZ004",SqlDbType.Decimal),
                new SqlParameter("@CZ005",SqlDbType.Decimal),
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = model.CZ001;
            parameter[1].Value = model.CZ002;
            parameter[2].Value = model.CZ003;
            parameter[3].Value = model.CZ004;
            parameter[4].Value = model.CZ005;
            parameter[5].Value = model.IDX;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQCZ WHERE idx={0}" ,model.IDX );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strD = new StringBuilder( );
            strD.AppendFormat( "SELECT COUNT(1) FROM R_PQDZ WHERE DZ001='{0}' AND DZ002='{1}' AND DZ003='{2}' AND DZ004='{3}'" ,model.CZ006 ,model.CZ001 ,model.CZ002 ,model.CZ003 );
            if ( SqlHelper.Exists( strSql.ToString( ) ) == true )
            {
                StringBuilder strSqlDz = new StringBuilder( );
                strSqlDz.AppendFormat( "DELETE FROM R_PQDZ WHERE DZ001='{0}' AND DZ002='{1}' AND DZ003='{2}' AND DZ004='{3}'" ,model.CZ006 ,model.CZ001 ,model.CZ002 ,model.CZ003 );
                SQLString.Add( strSqlDz.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表  表一
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQCZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据列表  表二
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQDZ" );
            strSql.Append( " WHERE " + strWhere );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary GetModelCz ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQCZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
            if ( dt.Rows.Count > 0 )
                return GetDataRowCz( dt.Rows[0] );
            else
                return null; 
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary GetDataRowCz ( DataRow row )
        {
            MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model = new MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary( );
            if ( row != null )
            {
                if ( row["idx"] != null && row["idx"].ToString( ) != "" )
                    model.IDX = int.Parse( row["idx"].ToString( ) );
                if ( row["CZ001"] != null && row["CZ001"].ToString( ) != "" )
                    model.CZ001 = row["CZ001"].ToString( );
                if ( row["CZ002"] != null && row["CZ002"].ToString( ) != "" )
                    model.CZ002 = row["CZ002"].ToString( );
                if ( row["CZ003"] != null && row["CZ003"].ToString( ) != "" )
                    model.CZ003 = row["CZ003"].ToString( );
                if ( row["CZ004"] != null && row["CZ004"].ToString( ) != "" )
                    model.CZ004 = decimal.Parse( row["CZ004"].ToString( ) );
                if ( row["CZ005"] != null && row["CZ005"].ToString( ) != "" )
                    model.CZ005 = decimal.Parse( row["CZ005"].ToString( ) );
                if ( row["CZ006"] != null && row["CZ006"].ToString( ) != "" )
                    model.CZ006 = row["CZ006"].ToString( );
            }

            return model;
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string tableName )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_REVIEWS" );
            strSql.Append( " WHERE RES01=@RES01 AND RES06=@RES06 AND RES05='执行'" );
            SqlParameter[] parameter = {
                new SqlParameter("@RES01",SqlDbType.NVarChar),
                new SqlParameter("@RES06",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;
            parameter[1].Value = tableName;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum )
        {
            ArrayList SQLString = new ArrayList( );
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "DELETE FROM R_PQCZ WHERE CZ006='{0}'" ,oddNum );
            SQLString.Add( strSql.ToString( ) );
            StringBuilder strS = new StringBuilder( );
            strS.AppendFormat( "SELECT COUNT(1) FROM R_PQDZ WHERE DZ001='{0}'" ,oddNum );
            if ( SqlHelper.Exists( strS.ToString( ) ) == true )
            {
                StringBuilder strD = new StringBuilder( );
                strD.AppendFormat( "DELETE FROM R_PQDZ WHERE DZ001='{0}'" ,oddNum );
                SQLString.Add( strD.ToString( ) );
            }

            return SqlHelper.ExecuteSqlTran( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTabbleExists ( string oddNum )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQCZ" );
            strSql.Append( " WHERE CZ006=@CZ006" );
            SqlParameter[] parameter = {
                new SqlParameter("@CZ006",SqlDbType.NVarChar)
            };

            parameter[0].Value = oddNum;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 更改维护意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQCZ SET " );
            strSql.Append( "CZ001=@CZ001," );
            strSql.Append( "CZ002=@CZ002," );
            strSql.Append( "CZ003=@CZ003," );
            strSql.Append( "CZ004=@CZ004," );
            strSql.Append( "CZ005=@CZ005," );
            strSql.Append( "CZ007=@CZ007," );
            strSql.Append( "CZ008=@CZ008" );
            strSql.Append( " WHERE CZ006=@CZ006" );

            SqlParameter[] parameter = {
                new SqlParameter("@CZ001",SqlDbType.NVarChar),
                new SqlParameter("@CZ002",SqlDbType.NVarChar),
                new SqlParameter("@CZ003",SqlDbType.NVarChar),
                new SqlParameter("@CZ004",SqlDbType.Decimal),
                new SqlParameter("@CZ005",SqlDbType.Decimal),
                new SqlParameter("@CZ006",SqlDbType.NVarChar),
                new SqlParameter("@CZ007",SqlDbType.NVarChar),
                new SqlParameter("@CZ008",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.CZ001;
            parameter[1].Value = model.CZ002;
            parameter[2].Value = model.CZ003;
            parameter[3].Value = model.CZ004;
            parameter[4].Value = model.CZ005;
            parameter[5].Value = model.CZ006;
            parameter[6].Value = model.CZ007;
            parameter[7].Value = model.CZ008;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteDz ( int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "DELETE FROM R_PQDZ" );
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
        /// 是否存在一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdx (int idx )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT COUNT(1) FROM R_PQDZ" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int)
            };

            parameter[0].Value = idx;

            return SqlHelper.Exists( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTwo ( MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "INSERT INTO R_PQDZ (" );
            strSql.Append( "DZ001,DZ002,DZ003,DZ004,DZ005,DZ006,DZ007,DZ008,DZ009,DZ010,DZ011,DZ012,DZ013,DZ014,DZ015,DZ016,DZ017,DZ018,DZ019,DZ020,DZ021,DZ022,DZ023,DZ024,DZ025,DZ026,DZ027,DZ028,DZ029,DZ030,DZ031,DZ032,DZ033,DZ034,DZ035,DZ036,DZ037,DZ038,DZ039,DZ040,DZ041,DZ042,DZ043,DZ044,DZ045,DZ046,DZ047,DZ048,DZ049,DZ050,DZ051,DZ052,DZ053,DZ054,DZ055,DZ056,DZ057,DZ058,DZ059,DZ060,DZ061,DZ062,DZ063,DZ064,DZ065,DZ066,DZ067,DZ068,DZ069,DZ070,DZ071,DZ072,DZ073,DZ074,DZ075,DZ076,DZ077)" );
            strSql.Append( " VALUES (" );
            strSql.Append( "@DZ001,@DZ002,@DZ003,@DZ004,@DZ005,@DZ006,@DZ007,@DZ008,@DZ009,@DZ010,@DZ011,@DZ012,@DZ013,@DZ014,@DZ015,@DZ016,@DZ017,@DZ018,@DZ019,@DZ020,@DZ021,@DZ022,@DZ023,@DZ024,@DZ025,@DZ026,@DZ027,@DZ028,@DZ029,@DZ030,@DZ031,@DZ032,@DZ033,@DZ034,@DZ035,@DZ036,@DZ037,@DZ038,@DZ039,@DZ040,@DZ041,@DZ042,@DZ043,@DZ044,@DZ045,@DZ046,@DZ047,@DZ048,@DZ049,@DZ050,@DZ051,@DZ052,@DZ053,@DZ054,@DZ055,@DZ056,@DZ057,@DZ058,@DZ059,@DZ060,@DZ061,@DZ062,@DZ063,@DZ064,@DZ065,@DZ066,@DZ067,@DZ068,@DZ069,@DZ070,@DZ071,@DZ072,@DZ073,@DZ074,@DZ075,@DZ076,@DZ077);" );
            strSql.Append( "SELECT SCOPE_IDENTITY();" );
            SqlParameter[] parameter = {
                new SqlParameter("@DZ001",SqlDbType.NVarChar),
                new SqlParameter("@DZ002",SqlDbType.NVarChar),
                new SqlParameter("@DZ003",SqlDbType.NVarChar),
                new SqlParameter("@DZ004",SqlDbType.NVarChar),
                new SqlParameter("@DZ005",SqlDbType.NVarChar),
                new SqlParameter("@DZ006",SqlDbType.NVarChar),
                new SqlParameter("@DZ007",SqlDbType.NVarChar),
                new SqlParameter("@DZ008",SqlDbType.Decimal),
                new SqlParameter("@DZ009",SqlDbType.DateTime),
                new SqlParameter("@DZ010",SqlDbType.DateTime),
                new SqlParameter("@DZ011",SqlDbType.DateTime),
                new SqlParameter("@DZ012",SqlDbType.DateTime),
                new SqlParameter("@DZ013",SqlDbType.Int),
                new SqlParameter("@DZ014",SqlDbType.DateTime),
                new SqlParameter("@DZ015",SqlDbType.Decimal),
                new SqlParameter("@DZ016",SqlDbType.Decimal),
                new SqlParameter("@DZ017",SqlDbType.Decimal),
                new SqlParameter("@DZ018",SqlDbType.Decimal),
                new SqlParameter("@DZ019",SqlDbType.Decimal),
                new SqlParameter("@DZ020",SqlDbType.Decimal),
                new SqlParameter("@DZ021",SqlDbType.Int),
                new SqlParameter("@DZ022",SqlDbType.Int),
                new SqlParameter("@DZ023",SqlDbType.Int),
                new SqlParameter("@DZ024",SqlDbType.Int),
                new SqlParameter("@DZ025",SqlDbType.Int),
                new SqlParameter("@DZ026",SqlDbType.Int),
                new SqlParameter("@DZ027",SqlDbType.Int),
                new SqlParameter("@DZ028",SqlDbType.Int),
                new SqlParameter("@DZ029",SqlDbType.Int),
                new SqlParameter("@DZ030",SqlDbType.Int),
                new SqlParameter("@DZ031",SqlDbType.Int),
                new SqlParameter("@DZ032",SqlDbType.Int),
                new SqlParameter("@DZ033",SqlDbType.Int),
                new SqlParameter("@DZ034",SqlDbType.Int),
                new SqlParameter("@DZ035",SqlDbType.Int),
                new SqlParameter("@DZ036",SqlDbType.Int),
                new SqlParameter("@DZ037",SqlDbType.Int),
                new SqlParameter("@DZ038",SqlDbType.Int),
                new SqlParameter("@DZ039",SqlDbType.Int),
                new SqlParameter("@DZ040",SqlDbType.Int),
                new SqlParameter("@DZ041",SqlDbType.Int),
                new SqlParameter("@DZ042",SqlDbType.Int),
                new SqlParameter("@DZ043",SqlDbType.Int),
                new SqlParameter("@DZ044",SqlDbType.Int),
                new SqlParameter("@DZ045",SqlDbType.Int),
                new SqlParameter("@DZ046",SqlDbType.Int),
                new SqlParameter("@DZ047",SqlDbType.Int),
                new SqlParameter("@DZ048",SqlDbType.Int),
                new SqlParameter("@DZ049",SqlDbType.NVarChar),
                new SqlParameter("@DZ050",SqlDbType.NVarChar),
                new SqlParameter("@DZ051",SqlDbType.Int),
                new SqlParameter("@DZ052",SqlDbType.NVarChar),
                new SqlParameter("@DZ053",SqlDbType.Int),
                new SqlParameter("@DZ054",SqlDbType.NVarChar),
                new SqlParameter("@DZ055",SqlDbType.Int),
                new SqlParameter("@DZ056",SqlDbType.NVarChar),
                new SqlParameter("@DZ057",SqlDbType.Int),
                new SqlParameter("@DZ058",SqlDbType.Int),
                new SqlParameter("@DZ059",SqlDbType.Int),
                new SqlParameter("@DZ060",SqlDbType.Int),
                new SqlParameter("@DZ061",SqlDbType.Int),
                new SqlParameter("@DZ062",SqlDbType.Int),
                new SqlParameter("@DZ063",SqlDbType.Int),
                new SqlParameter("@DZ064",SqlDbType.Int),
                new SqlParameter("@DZ065",SqlDbType.Int),
                new SqlParameter("@DZ066",SqlDbType.Int),
                new SqlParameter("@DZ067",SqlDbType.Int),
                new SqlParameter("@DZ068",SqlDbType.Int),
                new SqlParameter("@DZ069",SqlDbType.Int),
                new SqlParameter("@DZ070",SqlDbType.Int),
                new SqlParameter("@DZ071",SqlDbType.Int),
                new SqlParameter("@DZ072",SqlDbType.Int),
                new SqlParameter("@DZ073",SqlDbType.Int),
                new SqlParameter("@DZ074",SqlDbType.Int),
                new SqlParameter("@DZ075",SqlDbType.Int),
                new SqlParameter("@DZ076",SqlDbType.Int),
                new SqlParameter("@DZ077",SqlDbType.Int)
            };

            parameter[0].Value = model.DZ001;
            parameter[1].Value = model.DZ002;
            parameter[2].Value = model.DZ003;
            parameter[3].Value = model.DZ004;
            parameter[4].Value = model.DZ005;
            parameter[5].Value = model.DZ006;
            parameter[6].Value = model.DZ007;
            parameter[7].Value = model.DZ008;
            parameter[8].Value = model.DZ009;
            parameter[9].Value = model.DZ010;
            parameter[10].Value = model.DZ011;
            parameter[11].Value = model.DZ012;
            parameter[12].Value = model.DZ013;
            parameter[13].Value = model.DZ014;
            parameter[14].Value = model.DZ015;
            parameter[15].Value = model.DZ016;
            parameter[16].Value = model.DZ017;
            parameter[17].Value = model.DZ018;
            parameter[18].Value = model.DZ019;
            parameter[19].Value = model.DZ020;
            parameter[20].Value = model.DZ021;
            parameter[21].Value = model.DZ022;
            parameter[22].Value = model.DZ023;
            parameter[23].Value = model.DZ024;
            parameter[24].Value = model.DZ025;
            parameter[25].Value = model.DZ026;
            parameter[26].Value = model.DZ027;
            parameter[27].Value = model.DZ028;
            parameter[28].Value = model.DZ029;
            parameter[29].Value = model.DZ030;
            parameter[30].Value = model.DZ031;
            parameter[31].Value = model.DZ032;
            parameter[32].Value = model.DZ033;
            parameter[33].Value = model.DZ034;
            parameter[34].Value = model.DZ035;
            parameter[35].Value = model.DZ036;
            parameter[36].Value = model.DZ037;
            parameter[37].Value = model.DZ038;
            parameter[38].Value = model.DZ039;
            parameter[39].Value = model.DZ040;
            parameter[40].Value = model.DZ041;
            parameter[41].Value = model.DZ042;
            parameter[42].Value = model.DZ043;
            parameter[43].Value = model.DZ044;
            parameter[44].Value = model.DZ045;
            parameter[45].Value = model.DZ046;
            parameter[46].Value = model.DZ047;
            parameter[47].Value = model.DZ048;
            parameter[48].Value = model.DZ049;
            parameter[49].Value = model.DZ050;
            parameter[50].Value = model.DZ051;
            parameter[51].Value = model.DZ052;
            parameter[52].Value = model.DZ053;
            parameter[53].Value = model.DZ054;
            parameter[54].Value = model.DZ055;
            parameter[55].Value = model.DZ056;
            parameter[56].Value = model.DZ057;
            parameter[57].Value = model.DZ058;
            parameter[58].Value = model.DZ059;
            parameter[59].Value = model.DZ060;
            parameter[60].Value = model.DZ061;
            parameter[61].Value = model.DZ062;
            parameter[62].Value = model.DZ063;
            parameter[63].Value = model.DZ064;
            parameter[64].Value = model.DZ065;
            parameter[65].Value = model.DZ066;
            parameter[66].Value = model.DZ067;
            parameter[67].Value = model.DZ068;
            parameter[68].Value = model.DZ069;
            parameter[69].Value = model.DZ070;
            parameter[70].Value = model.DZ071;
            parameter[71].Value = model.DZ072;
            parameter[72].Value = model.DZ073;
            parameter[73].Value = model.DZ074;
            parameter[74].Value = model.DZ075;
            parameter[75].Value = model.DZ076;
            parameter[76].Value = model.DZ077;

            int idx = SqlHelper.ExecuteSqlReturnId( strSql.ToString( ) ,parameter );
            return idx;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateTwo ( MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "UPDATE R_PQDZ SET " );
            strSql.Append( "DZ002=@DZ002," );
            strSql.Append( "DZ003=@DZ003," );
            strSql.Append( "DZ004=@DZ004," );
            strSql.Append( "DZ005=@DZ005," );
            strSql.Append( "DZ006=@DZ006," );
            strSql.Append( "DZ007=@DZ007," );
            strSql.Append( "DZ008=@DZ008," );
            strSql.Append( "DZ009=@DZ009," );
            strSql.Append( "DZ010=@DZ010," );
            strSql.Append( "DZ011=@DZ011," );
            strSql.Append( "DZ012=@DZ012," );
            strSql.Append( "DZ013=@DZ013," );
            strSql.Append( "DZ014=@DZ014," );
            strSql.Append( "DZ015=@DZ015," );
            strSql.Append( "DZ016=@DZ016," );
            strSql.Append( "DZ017=@DZ017," );
            strSql.Append( "DZ018=@DZ018," );
            strSql.Append( "DZ019=@DZ019," );
            strSql.Append( "DZ020=@DZ020," );
            strSql.Append( "DZ021=@DZ021," );
            strSql.Append( "DZ022=@DZ022," );
            strSql.Append( "DZ023=@DZ023," );
            strSql.Append( "DZ024=@DZ024," );
            strSql.Append( "DZ025=@DZ025," );
            strSql.Append( "DZ026=@DZ026," );
            strSql.Append( "DZ027=@DZ027," );
            strSql.Append( "DZ028=@DZ028," );
            strSql.Append( "DZ029=@DZ029," );
            strSql.Append( "DZ030=@DZ030," );
            strSql.Append( "DZ031=@DZ031," );
            strSql.Append( "DZ032=@DZ032," );
            strSql.Append( "DZ033=@DZ033," );
            strSql.Append( "DZ034=@DZ034," );
            strSql.Append( "DZ035=@DZ035," );
            strSql.Append( "DZ036=@DZ036," );
            strSql.Append( "DZ037=@DZ037," );
            strSql.Append( "DZ038=@DZ038," );
            strSql.Append( "DZ039=@DZ039," );
            strSql.Append( "DZ040=@DZ040," );
            strSql.Append( "DZ041=@DZ041," );
            strSql.Append( "DZ042=@DZ042," );
            strSql.Append( "DZ043=@DZ043," );
            strSql.Append( "DZ044=@DZ044," );
            strSql.Append( "DZ045=@DZ045," );
            strSql.Append( "DZ046=@DZ046," );
            strSql.Append( "DZ047=@DZ047," );
            strSql.Append( "DZ048=@DZ048," );
            strSql.Append( "DZ049=@DZ049," );
            strSql.Append( "DZ050=@DZ050," );
            strSql.Append( "DZ051=@DZ051," );
            strSql.Append( "DZ052=@DZ052," );
            strSql.Append( "DZ053=@DZ053," );
            strSql.Append( "DZ054=@DZ054," );
            strSql.Append( "DZ055=@DZ055," );
            strSql.Append( "DZ056=@DZ056," );
            strSql.Append( "DZ057=@DZ057," );
            strSql.Append( "DZ058=@DZ058," );
            strSql.Append( "DZ059=@DZ059," );
            strSql.Append( "DZ060=@DZ060," );
            strSql.Append( "DZ061=@DZ061," );
            strSql.Append( "DZ062=@DZ062," );
            strSql.Append( "DZ063=@DZ063," );
            strSql.Append( "DZ064=@DZ064," );
            strSql.Append( "DZ065=@DZ065," );
            strSql.Append( "DZ066=@DZ066," );
            strSql.Append( "DZ067=@DZ067," );
            strSql.Append( "DZ068=@DZ068," );
            strSql.Append( "DZ069=@DZ069," );
            strSql.Append( "DZ070=@DZ070," );
            strSql.Append( "DZ071=@DZ071," );
            strSql.Append( "DZ072=@DZ072," );
            strSql.Append( "DZ073=@DZ073," );
            strSql.Append( "DZ074=@DZ074," );
            strSql.Append( "DZ075=@DZ075," );
            strSql.Append( "DZ076=@DZ076," );
            strSql.Append( "DZ077=@DZ077" );
            strSql.Append( " WHERE idx=@idx" );
            SqlParameter[] parameter = {
                new SqlParameter("@idx",SqlDbType.Int),
                new SqlParameter("@DZ002",SqlDbType.NVarChar),
                new SqlParameter("@DZ003",SqlDbType.NVarChar),
                new SqlParameter("@DZ004",SqlDbType.NVarChar),
                new SqlParameter("@DZ005",SqlDbType.NVarChar),
                new SqlParameter("@DZ006",SqlDbType.NVarChar),
                new SqlParameter("@DZ007",SqlDbType.NVarChar),
                new SqlParameter("@DZ008",SqlDbType.Decimal),
                new SqlParameter("@DZ009",SqlDbType.DateTime),
                new SqlParameter("@DZ010",SqlDbType.DateTime),
                new SqlParameter("@DZ011",SqlDbType.DateTime),
                new SqlParameter("@DZ012",SqlDbType.DateTime),
                new SqlParameter("@DZ013",SqlDbType.Int),
                new SqlParameter("@DZ014",SqlDbType.DateTime),
                new SqlParameter("@DZ015",SqlDbType.Decimal),
                new SqlParameter("@DZ016",SqlDbType.Decimal),
                new SqlParameter("@DZ017",SqlDbType.Decimal),
                new SqlParameter("@DZ018",SqlDbType.Decimal),
                new SqlParameter("@DZ019",SqlDbType.Decimal),
                new SqlParameter("@DZ020",SqlDbType.Decimal),
                new SqlParameter("@DZ021",SqlDbType.Int),
                new SqlParameter("@DZ022",SqlDbType.Int),
                new SqlParameter("@DZ023",SqlDbType.Int),
                new SqlParameter("@DZ024",SqlDbType.Int),
                new SqlParameter("@DZ025",SqlDbType.Int),
                new SqlParameter("@DZ026",SqlDbType.Int),
                new SqlParameter("@DZ027",SqlDbType.Int),
                new SqlParameter("@DZ028",SqlDbType.Int),
                new SqlParameter("@DZ029",SqlDbType.Int),
                new SqlParameter("@DZ030",SqlDbType.Int),
                new SqlParameter("@DZ031",SqlDbType.Int),
                new SqlParameter("@DZ032",SqlDbType.Int),
                new SqlParameter("@DZ033",SqlDbType.Int),
                new SqlParameter("@DZ034",SqlDbType.Int),
                new SqlParameter("@DZ035",SqlDbType.Int),
                new SqlParameter("@DZ036",SqlDbType.Int),
                new SqlParameter("@DZ037",SqlDbType.Int),
                new SqlParameter("@DZ038",SqlDbType.Int),
                new SqlParameter("@DZ039",SqlDbType.Int),
                new SqlParameter("@DZ040",SqlDbType.Int),
                new SqlParameter("@DZ041",SqlDbType.Int),
                new SqlParameter("@DZ042",SqlDbType.Int),
                new SqlParameter("@DZ043",SqlDbType.Int),
                new SqlParameter("@DZ044",SqlDbType.Int),
                new SqlParameter("@DZ045",SqlDbType.Int),
                new SqlParameter("@DZ046",SqlDbType.Int),
                new SqlParameter("@DZ047",SqlDbType.Int),
                new SqlParameter("@DZ048",SqlDbType.Int),
                new SqlParameter("@DZ049",SqlDbType.NVarChar),
                new SqlParameter("@DZ050",SqlDbType.NVarChar),
                new SqlParameter("@DZ051",SqlDbType.Int),
                new SqlParameter("@DZ052",SqlDbType.NVarChar),
                new SqlParameter("@DZ053",SqlDbType.Int),
                new SqlParameter("@DZ054",SqlDbType.NVarChar),
                new SqlParameter("@DZ055",SqlDbType.Int),
                new SqlParameter("@DZ056",SqlDbType.NVarChar),
                new SqlParameter("@DZ057",SqlDbType.Int),
                new SqlParameter("@DZ058",SqlDbType.Int),
                new SqlParameter("@DZ059",SqlDbType.Int),
                new SqlParameter("@DZ060",SqlDbType.Int),
                new SqlParameter("@DZ061",SqlDbType.Int),
                new SqlParameter("@DZ062",SqlDbType.Int),
                new SqlParameter("@DZ063",SqlDbType.Int),
                new SqlParameter("@DZ064",SqlDbType.Int),
                new SqlParameter("@DZ065",SqlDbType.Int),
                new SqlParameter("@DZ066",SqlDbType.Int),
                new SqlParameter("@DZ067",SqlDbType.Int),
                new SqlParameter("@DZ068",SqlDbType.Int),
                new SqlParameter("@DZ069",SqlDbType.Int),
                new SqlParameter("@DZ070",SqlDbType.Int),
                new SqlParameter("@DZ071",SqlDbType.Int),
                new SqlParameter("@DZ072",SqlDbType.Int),
                new SqlParameter("@DZ073",SqlDbType.Int),
                new SqlParameter("@DZ074",SqlDbType.Int),
                new SqlParameter("@DZ075",SqlDbType.Int),
                new SqlParameter("@DZ076",SqlDbType.Int),
                new SqlParameter("@DZ077",SqlDbType.Int)
            };

            parameter[0].Value = model.IDX;
            parameter[1].Value = model.DZ002;
            parameter[2].Value = model.DZ003;
            parameter[3].Value = model.DZ004;
            parameter[4].Value = model.DZ005;
            parameter[5].Value = model.DZ006;
            parameter[6].Value = model.DZ007;
            parameter[7].Value = model.DZ008;
            parameter[8].Value = model.DZ009;
            parameter[9].Value = model.DZ010;
            parameter[10].Value = model.DZ011;
            parameter[11].Value = model.DZ012;
            parameter[12].Value = model.DZ013;
            parameter[13].Value = model.DZ014;
            parameter[14].Value = model.DZ015;
            parameter[15].Value = model.DZ016;
            parameter[16].Value = model.DZ017;
            parameter[17].Value = model.DZ018;
            parameter[18].Value = model.DZ019;
            parameter[19].Value = model.DZ020;
            parameter[20].Value = model.DZ021;
            parameter[21].Value = model.DZ022;
            parameter[22].Value = model.DZ023;
            parameter[23].Value = model.DZ024;
            parameter[24].Value = model.DZ025;
            parameter[25].Value = model.DZ026;
            parameter[26].Value = model.DZ027;
            parameter[27].Value = model.DZ028;
            parameter[28].Value = model.DZ029;
            parameter[29].Value = model.DZ030;
            parameter[30].Value = model.DZ031;
            parameter[31].Value = model.DZ032;
            parameter[32].Value = model.DZ033;
            parameter[33].Value = model.DZ034;
            parameter[34].Value = model.DZ035;
            parameter[35].Value = model.DZ036;
            parameter[36].Value = model.DZ037;
            parameter[37].Value = model.DZ038;
            parameter[38].Value = model.DZ039;
            parameter[39].Value = model.DZ040;
            parameter[40].Value = model.DZ041;
            parameter[41].Value = model.DZ042;
            parameter[42].Value = model.DZ043;
            parameter[43].Value = model.DZ044;
            parameter[44].Value = model.DZ045;
            parameter[45].Value = model.DZ046;
            parameter[46].Value = model.DZ047;
            parameter[47].Value = model.DZ048;
            parameter[48].Value = model.DZ049;
            parameter[49].Value = model.DZ050;
            parameter[50].Value = model.DZ051;
            parameter[51].Value = model.DZ052;
            parameter[52].Value = model.DZ053;
            parameter[53].Value = model.DZ054;
            parameter[54].Value = model.DZ055;
            parameter[55].Value = model.DZ056;
            parameter[56].Value = model.DZ057;
            parameter[57].Value = model.DZ058;
            parameter[58].Value = model.DZ059;
            parameter[59].Value = model.DZ060;
            parameter[60].Value = model.DZ061;
            parameter[61].Value = model.DZ062;
            parameter[62].Value = model.DZ063;
            parameter[63].Value = model.DZ064;
            parameter[64].Value = model.DZ065;
            parameter[65].Value = model.DZ066;
            parameter[66].Value = model.DZ067;
            parameter[67].Value = model.DZ068;
            parameter[68].Value = model.DZ069;
            parameter[69].Value = model.DZ070;
            parameter[70].Value = model.DZ071;
            parameter[71].Value = model.DZ072;
            parameter[72].Value = model.DZ073;
            parameter[73].Value = model.DZ074;
            parameter[74].Value = model.DZ075;
            parameter[75].Value = model.DZ076;
            parameter[76].Value = model.DZ077;

            int rows = SqlHelper.ExecuteNonQuery( strSql.ToString( ) ,parameter );
            if ( rows > 0 )
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
            strSql.Append( "SELECT DISTINCT CZ006,CZ001,CZ002 FROM R_PQCZ" );

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
            strSql.Append( "SELECT COUNT(1) FROM (SELECT DISTINCT CZ006,CZ001,CZ002 FROM R_PQCZ" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) A" );

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
        public DataTable GetDataTableByPage (string strWhere,int startIndex,int endIndex )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DISTINCT CZ006,CZ001,CZ002 FROM (" );
            strSql.Append( " SELECT ROW_NUMBER() OVER (" );
            strSql.Append( "ORDER BY T.CZ006 DESC" );
            strSql.Append( ") AS Row,T.* FROM R_PQCZ T" );
            strSql.Append( " WHERE " + strWhere );
            strSql.Append( " ) TT" );
            strSql.AppendFormat( " WHERE TT.Row BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) );
        }

        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetDataTableCacle (MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT DZ004,ISNULL(SUM(DZ019*DZ020),0) U7,ISNULL(SUM(DZ073*DZ074)+SUM(DZ022*DZ023)+SUM(DZ025*DZ026)+SUM(DZ028*DZ029),0) U0,ISNULL(SUM(DZ075*DZ076*DZ077),0) U1,ISNULL(SUM(DZ030*DZ031*DZ032),0) U2,ISNULL(SUM(DZ033*DZ034*DZ035),0) U3,ISNULL(SUM(DZ036*DZ037*DZ038),0) U4,ISNULL(SUM(DZ018),0) F0,ISNULL(SUM(DZ020),0) F1,ISNULL(SUM(DZ073*DZ074),0) F2,ISNULL(SUM(DZ025*DZ026),0) F3,ISNULL(SUM(DZ022*DZ023),0) F4,ISNULL(SUM(DZ028*DZ029),0) F5 FROM R_PQDZ" );
            strSql.Append( " WHERE DZ001=@DZ001 AND DZ002=@DZ002 AND DZ003=@DZ003" );
            strSql.Append( " GROUP BY DZ004" );
            SqlParameter[] parameter = {
                new SqlParameter("@DZ001",SqlDbType.NVarChar),
                new SqlParameter("@DZ002",SqlDbType.NVarChar),
                new SqlParameter("@DZ003",SqlDbType.NVarChar)
            };

            parameter[0].Value = model.DZ001;
            parameter[1].Value = model.DZ002;
            parameter[2].Value = model.DZ003;

            return SqlHelper.ExecuteDataTable( strSql.ToString( ) ,parameter );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append( "SELECT * FROM R_PQDZ WHERE 1=2" );

            return SqlHelper.UpdateTable( table ,strSql.ToString( ) );
        }

        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="nameNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableNum ( string nameNum ,string dateD)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "SELECT DAA001,DAA002 FROM TPADAA WHERE DAA001 LIKE '{0}%' AND DAA001!='{0}'" ,nameNum );

            DataTable dt = SqlHelper.ExecuteDataTable( strSql.ToString( ) );
            if ( dt.Rows.Count > 0 )
            {
                string list = "''", listName = "''";
                for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                {
                    list = list + "," + "'" + dt.Rows[i]["DAA001"].ToString( ) + "'";
                    listName = listName + "," + "'" + dt.Rows[i]["DAA002"].ToString( ) + "'";
                }
                StringBuilder strSq = new StringBuilder( );
                //strSq.Append( "SELECT PQF01,PQF03,PQF04,CONVERT(DECIMAL(18,2),CASE WHEN PQF09=0 THEN PQF06*PQF10 WHEN PQF09!=0 THEN PQF09*PQF06 END) U0,PQF31,HT04,DAA002 FROM R_PQF A LEFT JOIN R_PQL B ON HT01=PQF01 LEFT JOIN TPADAA ON DAA001=PQF17" );
                //strSq.AppendFormat( " WHERE PQF17 IN ({0})" ,list );
                //strSq.AppendFormat( " AND SUBSTRING(CONVERT(VARCHAR(10),PQF31),0,8)>='{0}'" ,dateD );
                //strSq.AppendFormat( " AND SUBSTRING(CONVERT(VARCHAR(10),HT04),0,8)<='{0}'" ,dateD );
                strSq.Append( "WITH CET AS (" );
                strSq.Append( "SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(AE28)) AE28 FROM (SELECT AE02,AE21,CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END AE28 FROM R_PQAE" );
                strSq.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 ) >='{0}'" ,dateD );
                strSq.Append( " GROUP BY AE21,AE02,AE12) A GROUP BY AE02)" );
                strSq.Append( " ,CFT AS (" );
                strSq.Append( "SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0), " );
                //strSq.AppendFormat( " SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateD );
                strSq.Append( " CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ) U1,CONVERT(DECIMAL(18,0),CASE WHEN SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 )='2017-01' THEN CASE WHEN PQF09!=0 THEN PQF09*PQF06 WHEN PQF09=0 THEN PQF06*PQF10*PQF45 END ELSE 0 END) U2,AE21," );
                strSq.AppendFormat( " CASE WHEN SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 )='{0}'" ,dateD );
                strSq.Append( " THEN AE28 ELSE 0 END AE28 FROM R_PQF A LEFT JOIN R_PQL B ON A.PQF01=B.HT01 LEFT JOIN CET ON AE02=PQF01" );
                strSq.Append( " WHERE PQF17 IN (" + list + ")" );
                strSq.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,PQF31 ) ,0 ,8 ) >='{0}'" ,dateD );
                strSq.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,HT04 ) ,0 ,8 ) <='{0}'" ,dateD );
                strSq.Append( " UNION " );
                strSq.Append( " SELECT AE02,AE05,AE03,PQF32,PQF31,HT04,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE06*AE12) ELSE SUM(AE06*AE10*AE11) END) U1,0 AS U2,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN SUM(AE37*AE12) ELSE SUM(AE37*AE10*AE11) END) AE28 FROM R_PQAE A LEFT JOIN R_PQF B ON A.AE02=B.PQF01 LEFT JOIN R_PQL C ON B.PQF01=C.HT01" );
                strSq.Append( " WHERE AE08 IN (" + listName + ")" );
                strSq.AppendFormat( " AND SUBSTRING( CONVERT( VARCHAR ,AE21 ) ,0 ,8 )='{0}'" ,dateD );
                strSq.Append( " GROUP BY AE02,AE12,PQF31,PQF32,AE03,AE05,HT04" );
                strSq.Append( " ),CGT AS (" );
                strSq.Append( " SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),SUM(CASE WHEN AE12!=0 THEN AE37*AE12 ELSE AE37*AE10*AE11 END)) AE28 FROM R_PQAE" );
                strSq.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateD );
                strSq.Append( " AND AE08 IN (" + listName + ")" );
                strSq.Append( " GROUP BY AE02 )," );
                strSq.Append( " CHT AS (" );
                strSq.Append( " SELECT AE02,MAX(AE21) AE21,CONVERT(DECIMAL(18,0),CASE WHEN AE12!=0 THEN AE06*AE12 ELSE AE06*AE10*AE11 END) AE06 FROM R_PQAE" );
                strSq.AppendFormat( " WHERE SUBSTRING( CONVERT( VARCHAR ,AE17 ) ,0 ,8 )<'{0}'" ,dateD );
                strSq.Append( " AND AE08 IN (" + listName + ")" );
                strSq.Append( " GROUP BY AE02,AE12,AE06,AE10,AE11" );
                strSq.Append( " ),CLT AS(" );
                strSq.Append( " SELECT PQF01,PQF03,PQF04,PQF32,PQF31,HT04,SUM(U1) U1,SUM(U2) U2,AE21,MAX(AE28) AE28 FROM CFT GROUP BY PQF01,PQF03,PQF04,PQF32,PQF31,HT04,AE21" );
                strSq.Append( " UNION" );
                strSq.Append( " SELECT AE02,PQF03,PQF04,PQF32,PQF31,HT04,AE06,U2,AE21,AE28 FROM (SELECT A.AE02,PQF03,PQF04,PQF32,PQF31,B.AE06,0 AS U2,HT04,AE28,A.AE21 FROM CGT A LEFT JOIN CHT B ON A.AE02=B.AE02 LEFT JOIN R_PQF C ON A.AE02=C.PQF01 LEFT JOIN R_PQL D ON A.AE02=D.HT01 WHERE A.AE21 IS NOT NULL GROUP BY A.AE02,AE28,B.AE06,PQF03,PQF04,PQF32,PQF31,HT04,A.AE21 HAVING AE28<B.AE06 ) A GROUP BY AE02,AE28,AE06,PQF03,PQF04	,PQF32,PQF31,HT04,U2,AE21)" );
                strSq.Append( " SELECT CLT.PQF01,PQF03,PQF04,PQF31,HT04,SUM(U1) U1,DAA002 FROM CLT LEFT JOIN (SELECT DAA002,PQF01 FROM TPADAA A LEFT JOIN R_PQF B ON A.DAA001=B.PQF17) B ON CLT.PQF01=B.PQF01 GROUP BY CLT.PQF01,PQF03,PQF04,PQF31,HT04,DAA002 ORDER BY CLT.PQF01" );

                return SqlHelper.ExecuteDataTable( strSq.ToString( ) );
            }
            else
                return null;
        } 
    }
}
